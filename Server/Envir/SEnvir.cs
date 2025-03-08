using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Library;
using Library.Network;
using Library.SystemModels;
using CartoonMirDB;
using Server.DBModels;
using Server.Models;
using G = Library.Network.GeneralPackets;
using S = Library.Network.ServerPackets;
using C = Library.Network.ClientPackets;
using System.Timers;
using System.Runtime.InteropServices;
using Library.Network.GeneralPackets;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using NLog;
using Newtonsoft.Json;
using System.IO.Compression;

namespace Server.Envir
{
    public static class SEnvir
    {
        #region Synchronization

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public static List<Map> MapInstance = new List<Map>();
        private static readonly SynchronizationContext Context = SynchronizationContext.Current;
        public static void Send(SendOrPostCallback method)
        {
            Context.Send(method, null);
        }
        public static void Post(SendOrPostCallback method)
        {
            Context.Post(method, null);
        }

        #endregion

        #region Logging

        public static ConcurrentQueue<string> DisplayGMLogs = new ConcurrentQueue<string>();
        public static ConcurrentQueue<string> DisplayLogs = new ConcurrentQueue<string>();
        public static ConcurrentQueue<string> Logs = new ConcurrentQueue<string>();
        public static void Log(string log, bool hardLog = true)
        {

            log = string.Format("[{0:F}]: {1}", Time.Now, log);

            if (DisplayLogs.Count < 100)
                DisplayLogs.Enqueue(log);

            if (hardLog && Logs.Count < 1000)
                Logs.Enqueue(log);
        }

        public static ConcurrentQueue<string> DisplayChatLogs = new ConcurrentQueue<string>();
        public static ConcurrentQueue<string> ChatLogs = new ConcurrentQueue<string>();
        public static void LogChat(string log)
        {
            log = string.Format("[{0:F}]: {1}", Time.Now, log);

            if (DisplayChatLogs.Count < 500)
                DisplayChatLogs.Enqueue(log);


            if (ChatLogs.Count < 1000)
                ChatLogs.Enqueue(log);
        }
        #endregion

        public static void LogError(Exception ex, bool hardLog = true)
        {
            string log = $"[{Time.Now:F}]: {ex.Message}\r\n{ex.StackTrace}";
            if (DisplayLogs.Count < 100)
            {
                DisplayLogs.Enqueue(log);
            }
            logger.Error<Exception>(ex);
        }

        public static void LogError(string log, bool hardLog = true)
        {
            log = string.Format("[{0:F}]: {1}", Time.Now, log);
            if (DisplayLogs.Count < 100)
            {
                DisplayLogs.Enqueue(log);
            }
            logger.Error(log);
        }

        public static void LogGM(string log, bool hardLog = true)
        {
            log = $"[{Time.Now:F}]: {log}";
            if (DisplayGMLogs.Count < 100)
            {
                DisplayGMLogs.Enqueue(log);
            }
            logger.Debug(log);
        }


        #region Network

        public static Dictionary<string, DateTime> IPBlocks = new Dictionary<string, DateTime>();
        public static Dictionary<string, int> IPCount = new Dictionary<string, int>();

        public static List<SConnection> Connections = new List<SConnection>();
        public static ConcurrentQueue<SConnection> NewConnections;

        public static List<NPCObject> NPCs { get; } = new List<NPCObject>();

        private static TcpListener _listener, _userCountListener;

        private static void StartNetwork(bool log = true)
        {
            try
            {
                NewConnections = new ConcurrentQueue<SConnection>();

                _listener = new TcpListener(IPAddress.Parse(Config.IPAddress), Config.Port);
                _listener.Start();
                _listener.BeginAcceptTcpClient(Connection, null);

                _userCountListener = new TcpListener(IPAddress.Parse(Config.IPAddress), Config.UserCountPort);
                _userCountListener.Start();
                _userCountListener.BeginAcceptTcpClient(CountConnection, null);

                NetworkStarted = true;
                if (log) Log("服务器启动.");
                ServerStartTime = Time.Now;
            }
            catch (Exception ex)
            {
                Started = false;
                Log(ex.ToString());
            }
        }
        private static void StopNetwork(bool log = true)
        {
            TcpListener expiredListener = _listener;
            TcpListener expiredUserListener = _userCountListener;

            _listener = null;
            _userCountListener = null;

            Started = false;

            expiredListener?.Stop();
            expiredUserListener?.Stop();

            NewConnections = null;

            try
            {
                Packet p = new G.Disconnect { Reason = DisconnectReason.ServerClosing };
                for (int i = Connections.Count - 1; i >= 0; i--)
                    Connections[i].SendDisconnect(p);

                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Log(ex.ToString());
            }

            if (log) Log("服务器停止.");
        }

        private static void Connection(IAsyncResult result)
        {
            try
            {
                if (_listener == null || !_listener.Server.IsBound) return;

                TcpClient client = _listener.EndAcceptTcpClient(result);

                string ipAddress = client.Client.RemoteEndPoint.ToString().Split(':')[0];

                if (!IPBlocks.TryGetValue(ipAddress, out DateTime banDate) || banDate < Now)
                {
                    SConnection Connection = new SConnection(client);

                    if (Connection.Connected)
                        NewConnections?.Enqueue(Connection);
                }
            }
            catch (Exception ex)
            {
                Log(ex.ToString());
            }
            finally
            {
                while (NewConnections?.Count >= 15)
                    Thread.Sleep(1);

                if (_listener != null && _listener.Server.IsBound)
                    _listener.BeginAcceptTcpClient(Connection, null);
            }
        }

        private static void CountConnection(IAsyncResult result)
        {
            try
            {
                if (_userCountListener == null || !_userCountListener.Server.IsBound) return;

                TcpClient client = _userCountListener.EndAcceptTcpClient(result);

                byte[] data = Encoding.ASCII.GetBytes(string.Format("c;/Zircon/{0}/;", Connections.Count));

                client.Client.BeginSend(data, 0, data.Length, SocketFlags.None, CountConnectionEnd, client);
            }
            catch { }
            finally
            {
                if (_userCountListener != null && _userCountListener.Server.IsBound)
                    _userCountListener.BeginAcceptTcpClient(CountConnection, null);
            }
        }
        private static void CountConnectionEnd(IAsyncResult result)
        {
            try
            {
                TcpClient client = result.AsyncState as TcpClient;

                if (client == null) return;

                client.Client.EndSend(result);

                client.Client.Dispose();
            }
            catch { }
        }

        #endregion

        #region WebServer
        private static HttpListener WebListener;
        public const string ActivationCommand = "Activation", ResetCommand = "Reset", DeleteCommand = "Delete",
              SystemDBSyncCommand = "SystemDBSync";

        private const string ActivationKey = "ActivationKey", ResetKey = "ResetKey", DeleteKey = "DeleteKey";

        private const string Completed = "Completed";
        private const string Currency = "GBP";

        private static Dictionary<decimal, int> GoldTable = new Dictionary<decimal, int>
        {
            [5M] = 500,
            [10M] = 1030,
            [15M] = 1590,
            [20M] = 2180,
            [30M] = 3360,
            [50M] = 5750,
            [100M] = 12000,
        };

        public const string VerifiedPath = @".\Database\Store\Verified\",
            InvalidPath = @".\Database\Store\Invalid\",
            CompletePath = @".\Database\Store\Complete\",
            NameListPath = @".\Envir\NameLists\",
            YueNameListPath = @".\Envir\YueNameLists\",
            GuildListPath = @".\Envir\GuildNameLists\",
            MapRegionPath = @".\Envir\MapRegionLists\",
            CDkeyPath = @".\Envir\CDkey\";


        private static HttpListener BuyListener, IPNListener;
        public static ConcurrentQueue<IPNMessage> Messages = new ConcurrentQueue<IPNMessage>();
        public static List<IPNMessage> PaymentList = new List<IPNMessage>(), HandledPayments = new List<IPNMessage>();

        public static void StartWebServer(bool log = true)
        {
            try
            {
                WebCommandQueue = new ConcurrentQueue<WebCommand>();

                WebListener = new HttpListener();
                WebListener.Prefixes.Add(Config.WebPrefix);

                WebListener.Start();
                WebListener.BeginGetContext(WebConnection, null);

                BuyListener = new HttpListener();
                BuyListener.Prefixes.Add(Config.BuyPrefix);

                IPNListener = new HttpListener();
                IPNListener.Prefixes.Add(Config.IPNPrefix);

                BuyListener.Start();
                BuyListener.BeginGetContext(BuyConnection, null);

                IPNListener.Start();
                IPNListener.BeginGetContext(IPNConnection, null);



                WebServerStarted = true;

                if (log) Log("Web服务器启动.");
            }
            catch (Exception ex)
            {
                WebServerStarted = false;
                Log(ex.ToString());

                if (WebListener != null && WebListener.IsListening)
                    WebListener?.Stop();
                WebListener = null;

                if (BuyListener != null && BuyListener.IsListening)
                    BuyListener?.Stop();
                BuyListener = null;

                if (IPNListener != null && IPNListener.IsListening)
                    IPNListener?.Stop();
                IPNListener = null;
            }
        }
        public static void StopWebServer(bool log = true)
        {
            HttpListener expiredWebListener = WebListener;
            WebListener = null;

            HttpListener expiredBuyListener = BuyListener;
            BuyListener = null;
            HttpListener expiredIPNListener = IPNListener;
            IPNListener = null;


            WebServerStarted = false;
            expiredWebListener?.Stop();
            expiredBuyListener?.Stop();
            expiredIPNListener?.Stop();

            if (log) Log("Web服务器停止.");
        }

        public static void PreLoadMaps()
        {
            DateTime localNow = Now;
            DateTime start = DateTime.Now;
            Log("已准备迷你游戏地图");
            Parallel.ForEach(Maps.Values, delegate (Map map)
            {
                try
                {
                    Now = localNow;
                    map.Process();
                }
                catch (Exception ex4)
                {
                    Log(ex4.Message);
                    Log(ex4.StackTrace);
                    File.AppendAllText(@".\Errors.txt", ex4.StackTrace + Environment.NewLine);
                }
            });
            Parallel.ForEach(MapInstance, delegate (Map map)
            {
                try
                {
                    Now = localNow;
                    map.Process();
                }
                catch (Exception ex3)
                {
                    Log(ex3.Message);
                    Log(ex3.StackTrace);
                    File.AppendAllText(@".\Errors.txt", ex3.StackTrace + Environment.NewLine);
                }
            });
            Log("已准备生成迷你游戏模式");
            foreach (SpawnInfo spawn in Spawns)
            {
                spawn.DoSpawn(eventSpawn: false);
            }
            Log("已征服战争");
            Parallel.ForEach(ConquestWars, delegate (ConquestWar war)
            {
                try
                {
                    Now = localNow;
                    war.Process();
                }
                catch (Exception ex2)
                {
                    Log(ex2.Message);
                    Log(ex2.StackTrace);
                    File.AppendAllText(@".\Errors.txt", ex2.StackTrace + Environment.NewLine);
           
                }
            });
            Log("已准备迷你游戏");
            Parallel.ForEach(MiniGames, delegate (MiniGame miniGame)
            {
                try
                {
                    Now = localNow;
                    miniGame.Process();
                }
                catch (Exception ex)
                {
                    Log(ex.Message);
                    Log(ex.StackTrace);
                    File.AppendAllText(@".\Errors.txt", ex.StackTrace + Environment.NewLine);
             
                }
            });
            TimeSpan elapsed = DateTime.Now - start;
            Log($"正在加载地图: {elapsed.Minutes.ToString().PadLeft(2, '0')}:{elapsed.Seconds.ToString().PadLeft(2, '0')}.{elapsed.Milliseconds.ToString().PadLeft(4, '0')}", true);
        }

        private static void WebConnection(IAsyncResult result)
        {
            try
            {
                HttpListenerContext context = WebListener.EndGetContext(result);

                string command = context.Request.QueryString["Type"];

                switch (command)
                {
                    case ActivationCommand:
                        Activation(context);
                        break;
                    case ResetCommand:
                        ResetPassword(context);
                        break;
                    case DeleteCommand:
                        DeleteAccount(context);
                        break;
                    case SystemDBSyncCommand:
                        SystemDBSync(context);
                        break;
                }
            }
            catch { }
            finally
            {
                if (WebListener != null && WebListener.IsListening)
                    WebListener.BeginGetContext(WebConnection, null);
            }
        }
        private static void SystemDBSync(HttpListenerContext context)
        {
            try
            {
                if (!Config.AllowSystemDBSync)
                {
                    SEnvir.Log($"正在尝试同步，但未启用");
                    context.Response.StatusCode = 401;
                    return;
                }

                if (context.Request.HttpMethod != "POST" || !context.Request.HasEntityBody)
                {
                    SEnvir.Log($"正在尝试同步，但方法不是post或没有正文");
                    context.Response.StatusCode = 401;
                    return;
                }

                if (context.Request.ContentLength64 > 1024 * 1024 * 10)
                {
                    SEnvir.Log($"正在尝试同步，但超出了SystemDB大小");
                    context.Response.StatusCode = 400;
                    return;
                }

                var masterPassword = context.Request.QueryString["Key"];
                if (string.IsNullOrEmpty(masterPassword) || !masterPassword.Equals(Config.SyncKey))
                {
                    SEnvir.Log($"正在尝试同步，但收到的密钥无效");
                    context.Response.StatusCode = 400;
                    return;
                }

                SEnvir.Log($"正在启动远程同步。。。");

                var buffer = new byte[context.Request.ContentLength64];
                var offset = 0;
                var length = 0;
                var bufferSize = 1024 * 16;

                while ((length = context.Request.InputStream.Read(buffer, offset, offset + bufferSize > buffer.Length ? buffer.Length - offset : bufferSize)) > 0)
                    offset += length;

                if (SEnvir.Session.BackUp && !Directory.Exists(Session.SystemBackupPath))
                    Directory.CreateDirectory(SEnvir.Session.SystemBackupPath);

                if (File.Exists(SEnvir.Session.SystemPath))
                {
                    if (SEnvir.Session.BackUp)
                    {
                        using (FileStream sourceStream = File.OpenRead(SEnvir.Session.SystemPath))
                        using (FileStream destStream = File.Create(SEnvir.Session.SystemBackupPath + "System " + SEnvir.Session.ToBackUpFileName(DateTime.UtcNow) + Session.Extention + Session.CompressExtention))
                        using (GZipStream compress = new GZipStream(destStream, CompressionMode.Compress))
                            sourceStream.CopyTo(compress);
                    }

                    File.Delete(SEnvir.Session.SystemPath);
                }

                File.WriteAllBytes(SEnvir.Session.SystemPath, buffer);

                context.Response.StatusCode = 200;

                SEnvir.Log($"同步已完成。。。");
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "text/plain";
                var message = Encoding.UTF8.GetBytes(ex.ToString());
                context.Response.OutputStream.Write(message, 0, message.Length);
                SEnvir.Log("同步异常: " + ex.ToString());
            }
            finally
            {
                context.Response.Close();
            }
        }
        private static void Activation(HttpListenerContext context)
        {
            string key = context.Request.QueryString[ActivationKey];

            if (string.IsNullOrEmpty(key)) return;

            AccountInfo account = null;
            for (int i = 0; i < AccountInfoList.Count; i++)
            {
                AccountInfo temp = AccountInfoList[i]; 
                if (string.Compare(temp.ActivationKey, key, StringComparison.Ordinal) != 0) continue;

                account = temp;
                break;
            }

            if (Config.AllowWebActivation && account != null)
            {
                WebCommandQueue.Enqueue(new WebCommand(CommandType.Activation, account));
                context.Response.Redirect(Config.ActivationSuccessLink);
            }
            else
                context.Response.Redirect(Config.ActivationFailLink);

            context.Response.Close();
        }
        private static void ResetPassword(HttpListenerContext context)
        {
            string key = context.Request.QueryString[ResetKey];

            if (string.IsNullOrEmpty(key)) return;

            AccountInfo account = null;
            for (int i = 0; i < AccountInfoList.Count; i++)
            {
                AccountInfo temp = AccountInfoList[i]; 
                if (string.Compare(temp.ResetKey, key, StringComparison.Ordinal) != 0) continue;

                account = temp;
                break;
            }

            if (Config.AllowWebResetPassword && account != null && account.ResetTime.AddMinutes(25) > Now)
            {
                WebCommandQueue.Enqueue(new WebCommand(CommandType.PasswordReset, account));
                context.Response.Redirect(Config.ResetSuccessLink);
            }
            else
                context.Response.Redirect(Config.ResetFailLink);

            context.Response.Close();
        }
        private static void DeleteAccount(HttpListenerContext context)
        {
            string key = context.Request.QueryString[DeleteKey];

            AccountInfo account = null;
            for (int i = 0; i < AccountInfoList.Count; i++)
            {
                AccountInfo temp = AccountInfoList[i];
                if (string.Compare(temp.ActivationKey, key, StringComparison.Ordinal) != 0) continue;

                account = temp;
                break;
            }

            if (Config.AllowDeleteAccount && account != null)
            {
                WebCommandQueue.Enqueue(new WebCommand(CommandType.AccountDelete, account));
                context.Response.Redirect(Config.DeleteSuccessLink);
            }
            else
                context.Response.Redirect(Config.DeleteFailLink);

            context.Response.Close();
        }

        private static void BuyConnection(IAsyncResult result)
        {
            try
            {
                HttpListenerContext context = BuyListener.EndGetContext(result);

                string characterName = context.Request.QueryString["Character"];

                CharacterInfo character = null;
                for (int i = 0; i < CharacterInfoList.Count; i++)
                {
                    if (string.Compare(CharacterInfoList[i].CharacterName, characterName, StringComparison.OrdinalIgnoreCase) != 0) continue;

                    character = CharacterInfoList[i];
                    break;
                }

                if (character?.Account.Key != context.Request.QueryString["Key"])
                    character = null;

                string response = character == null ? Properties.Resources.CharacterNotFound : Properties.Resources.BuyGameGold.Replace("$CHARACTERNAME$", character.CharacterName);

                using (StreamWriter writer = new StreamWriter(context.Response.OutputStream, context.Request.ContentEncoding))
                    writer.Write(response);
            }
            catch { }
            finally
            {
                if (BuyListener != null && BuyListener.IsListening) 
                    BuyListener.BeginGetContext(BuyConnection, null);
            }

        }
        private static void IPNConnection(IAsyncResult result)
        {
            const string LiveURL = @"https://ipnpb.paypal.com/cgi-bin/webscr";

            const string verified = "VERIFIED";

            try
            {
                if (IPNListener == null || !IPNListener.IsListening) return;

                HttpListenerContext context = IPNListener.EndGetContext(result);

                string rawMessage;
                using (StreamReader readStream = new StreamReader(context.Request.InputStream, Encoding.UTF8))
                    rawMessage = readStream.ReadToEnd();


                Task.Run(() =>
                {
                    string data = "cmd=_notify-validate&" + rawMessage;

                    HttpWebRequest wRequest = (HttpWebRequest)WebRequest.Create(LiveURL);

                    wRequest.Method = "POST";
                    wRequest.ContentType = "application/x-www-form-urlencoded";
                    wRequest.ContentLength = data.Length;

                    using (StreamWriter writer = new StreamWriter(wRequest.GetRequestStream(), Encoding.ASCII))
                        writer.Write(data);

                    using (StreamReader reader = new StreamReader(wRequest.GetResponse().GetResponseStream()))
                    {
                        IPNMessage message = new IPNMessage { Message = rawMessage, Verified = reader.ReadToEnd() == verified };


                        if (!Directory.Exists(VerifiedPath))
                            Directory.CreateDirectory(VerifiedPath);

                        if (!Directory.Exists(InvalidPath))
                            Directory.CreateDirectory(InvalidPath);

                        string path = (message.Verified ? VerifiedPath : InvalidPath) + Path.GetRandomFileName();

                        File.WriteAllText(path, message.Message);

                        message.FileName = path;


                        Messages.Enqueue(message);
                    }
                });

                context.Response.StatusCode = (int)HttpStatusCode.OK;
                context.Response.Close();
            }
            catch (Exception ex)
            {
                Log(ex.ToString());
            }
            finally
            {
                if (IPNListener != null && IPNListener.IsListening) 
                    IPNListener.BeginGetContext(IPNConnection, null);
            }
        }
        #endregion

        public static bool Started { get; set; }
        public static bool NetworkStarted { get; set; }
        public static bool WebServerStarted { get; set; }
        public static bool Saving { get; private set; }
        public static Thread EnvirThread { get; private set; }

        public static DateTime Now, StartTime, LastWarTime, ServerStartTime;

        public static int ProcessObjectCount, LoopCount;

        public static long DBytesSent, DBytesReceived;
        public static long TotalBytesSent, TotalBytesReceived;
        public static long DownloadSpeed, UploadSpeed;
        public static int EMailsSent;

        public static bool Shifouguanbiguajign;

        public static bool ServerBuffChanged;
        public static List<ItemInfo> TreaItemList = new List<ItemInfo>();
 
        public static List<ItemInfo> TreaItemList01 = new List<ItemInfo>();

        public static List<ItemInfo> TreaItemList02 = new List<ItemInfo>();

        public static List<ItemInfo> TreaItemList03 = new List<ItemInfo>();
    
        public static List<ItemInfo> TreaItemList04 = new List<ItemInfo>();

        public static List<ItemInfo> TreaItemList05 = new List<ItemInfo>();

        #region Database

        private static Session Session;

        public static DBCollection<MapInfo> MapInfoList;
        public static DBCollection<SafeZoneInfo> SafeZoneInfoList;
        public static DBCollection<ItemInfo> ItemInfoList;
        public static DBCollection<RespawnInfo> RespawnInfoList;
        public static DBCollection<MagicInfo> MagicInfoList;
        public static DBCollection<FubenInfo> FubenInfoList;
        public static DBCollection<MingwenInfo> MingwenInfoList;

        public static DBCollection<AccountInfo> AccountInfoList;
        public static DBCollection<CharacterInfo> CharacterInfoList;
        public static DBCollection<CharacterBeltLink> BeltLinkList;
        public static DBCollection<AutoPotionLink> AutoPotionLinkList;
        public static DBCollection<AutoFightConfig> AutoFightConfList;
        public static DBCollection<UserTeleport> UserTeleportList;
        public static DBCollection<MeiriQuestInfo> MeiriQuestInfoList;
        public static DBCollection<UserItem> UserItemList;
        public static DBCollection<RefineInfo> RefineInfoList;
        public static DBCollection<UserItemStat> UserItemStatsList;
        public static DBCollection<UserMagic> UserMagicList;
        public static DBCollection<BuffInfo> BuffInfoList;
        public static DBCollection<MonsterInfo> MonsterInfoList;
        public static DBCollection<SetInfo> SetInfoList;
        public static DBCollection<AuctionInfo> AuctionInfoList;
        public static DBCollection<MailInfo> MailInfoList;
        public static DBCollection<AuctionHistoryInfo> AuctionHistoryInfoList;
        public static DBCollection<UserDrop> UserDropList;
        public static DBCollection<StoreInfo> StoreInfoList;
        public static DBCollection<BaseStat> BaseStatList;
        public static DBCollection<MovementInfo> MovementInfoList;
        public static DBCollection<NPCInfo> NPCInfoList;
        public static DBCollection<MapRegion> MapRegionList;
        public static DBCollection<GuildInfo> GuildInfoList;
        public static DBCollection<GuildMemberInfo> GuildMemberInfoList;
        public static DBCollection<UserQuest> UserQuestList;
        public static DBCollection<UserQuestTask> UserQuestTaskList;
        public static DBCollection<MeiriUserQuest> MeiriUserQuestList;
        public static DBCollection<MeiriUserQuestTask> MeiriUserQuestTaskList;
        public static DBCollection<CompanionInfo> CompanionInfoList;
        public static DBCollection<CompanionLevelInfo> CompanionLevelInfoList;
        public static DBCollection<UserCompanion> UserCompanionList;
        public static DBCollection<UserCompanionUnlock> UserCompanionUnlockList;
        public static DBCollection<CompanionSkillInfo> CompanionSkillInfoList;
        public static DBCollection<BlockInfo> BlockInfoList;
        public static DBCollection<CastleInfo> CastleInfoList;
        public static DBCollection<UserConquest> UserConquestList;
        public static DBCollection<GameGoldPayment> GameGoldPaymentList;
        public static DBCollection<GameStoreSale> GameStoreSaleList;
        public static DBCollection<GuildWarInfo> GuildWarInfoList;
        public static DBCollection<UserConquestStats> UserConquestStatsList;
        public static DBCollection<UserFortuneInfo> UserFortuneInfoList;
        public static DBCollection<WeaponCraftStatInfo> WeaponCraftStatInfoList;
        public static DBCollection<UserCrafting> UserCraftInfoList;
        public static DBCollection<UserShenmiCount> UserShenmiInfoList;
        public static DBCollection<UserArenaPvPStats> UserArenaPvPStatsList;
        public static DBCollection<CraftLevelInfo> CraftingLevelsInfoList;
        public static DBCollection<CraftItemInfo> CraftingItemInfoList;
        public static DBCollection<MiniGameInfo> MiniGameInfoList;
        public static DBCollection<HorseInfo> HorseInfoList;
        public static DBCollection<UserHorse> UserHorseList;
        public static DBCollection<UserHorseUnlock> UserHorseUnlockList;
        private static ConcurrentDictionary<uint, MapObject> objectDictionary = new ConcurrentDictionary<uint, MapObject>();

        public static List<Map> FubenMaps = new List<Map>();

        public static ItemInfo GoldInfo, RefinementStoneInfo, FragmentInfo, Fragment2Info, Fragment3Info, FortuneCheckerInfo, ItemPartInfo, TeleportInfo, TeleportInfoHD;
        public static ItemInfo GameGoldInfo;
        public static GuildInfo StarterGuild;

        public static MapRegion MysteryShipMapRegion, LairMapRegion, yaotaMapRegion, MotaMapRegion, Huodong01MapRegion, Huodong02MapRegion, Huodong03MapRegion, Huodong04MapRegion, Huodong05MapRegion, Huodong06MapRegion, Huodong07MapRegion, Huodong08MapRegion, Huodong09MapRegion, Huodong10MapRegion, Huodong11MapRegion, Huodong12MapRegion;

        public static List<MonsterInfo> BossList = new List<MonsterInfo>();

        #endregion

        #region Game Variables

        public static Random Random;

        public static ConcurrentQueue<WebCommand> WebCommandQueue;

        public static Dictionary<MapInfo, Map> Maps = new Dictionary<MapInfo, Map>();

        private static long _ObjectID;
        public static uint ObjectID => (uint)Interlocked.Increment(ref _ObjectID);

        public static int TimerSecondTick = 90;
        public static DateTime ShowGameMessTime;
        public static string[] GameShowInfo;
        public static string MingWenConfig;
        public static Configs cfg;
        public static DateTime ShowGameShowTime;
        public static System.Timers.Timer SEvirtimer;

        public static LinkedList<MapObject> Objects = new LinkedList<MapObject>();
        public static List<MapObject> ActiveObjects = new List<MapObject>();

        public static List<PlayerObject> Players = new List<PlayerObject>();
        public static List<ConquestWar> ConquestWars = new List<ConquestWar>();
        public static List<MiniGame> MiniGames = new List<MiniGame>();

        private static readonly Regex EntryRegex = new Regex("^(?<Key>.*?)=(?<Value>.*)$", RegexOptions.Compiled);
        private static readonly Regex HeaderRegex = new Regex("^\\[(?<Header>.+)\\]$", RegexOptions.Compiled);
        public static List<SpawnInfo> Spawns = new List<SpawnInfo>();

        private static float _DayTime;
        public static float DayTime
        {
            get { return _DayTime; }
            set
            {
                if (_DayTime == value) return;

                _DayTime = value;

                Broadcast(new S.DayChanged { DayTime = DayTime });
            }
        }

        public static LinkedList<CharacterInfo> Rankings;
        public static HashSet<CharacterInfo> TopRankings;
        public static LinkedList<GuildInfo> GuildRankings;
        public static HashSet<GuildInfo> GuildTopRankings;
        public static LinkedList<GuildMemberInfo> GuildGerenRankings;
        public static HashSet<GuildMemberInfo> GuildGerenTopRankings;
        public static LinkedList<CharacterInfo> GuildGerenMankings;
        public static HashSet<CharacterInfo> GuildGerenTopMankings;

        public static long ConDelay, SaveDelay;
        #endregion



        private static void SEvirtimer_Elapsed(object name, [In] ElapsedEventArgs obj1)
        {
            if (Config.是否关闭服务器时倒计时)
            {
                --TimerSecondTick;
                if (TimerSecondTick > 0 && TimerSecondTick % 3 == 0)
                    ShowAllMessage(string.Format(Config.关闭提示, TimerSecondTick), MessageType.Announcement);
                if (TimerSecondTick == 0)
                {
                    Config.AllowLogin = false;
                    try
                    {

                        Started = false;
                       
                    }
                    catch (Exception ex)
                    {
                        Log(ex.ToString(), true);
                    }
                }
            }
            if (Now > ShowGameMessTime)
            {
                ShowGameMessTime = Now.AddMinutes(6.0);
                if (GameShowInfo.Length != 0)
                    ShowAllMessage(GameShowInfo[Random.Next(GameShowInfo.Length)], MessageType.Announcement);
            }
            if (!(Now > ShowGameShowTime))
                return;
        }

        public static void ShowAllMessage(string p, [In] MessageType obj1)
        {
            if (p == "")
                return;
            foreach (SConnection connection in Connections)
            {
                connection.ReceiveChat(p, obj1, 0U);
                /*switch (connection.Stage)
                {
                    case GameStage.Game:
                        if (connection.Player.Character.Observable)
                        {
                            connection.ReceiveChat(p, obj1, 0U);
                            continue;
                        }
                        continue;
                    case GameStage.Observer:
                        connection.ReceiveChat(p, obj1, 0U);
                        continue;
                    default:
                        continue;
                }*/
            }
        }

        public static void StartServer()
        {
            if (Started || EnvirThread != null) return;

            EnvirThread = new Thread(EnvirLoop) { IsBackground = true };
            EnvirThread.Start();
        }

        public static void LoadBroadCastInfo()
        {
            string str = ".\\Database\\";
            if (!File.Exists(str + "广播.txt"))
            {
                int num = (int)MessageBox.Show(string.Format("广播文件[{0}]不存在！", (str + "广播.txt")));
            }
            else
                GameShowInfo = File.ReadAllLines(str + "广播.txt", Encoding.Default);
        }
        public static void LoadBroadMingWenConfigs()
        {
            string str = ".\\Envir\\MingwenConfig\\";
            if (!File.Exists(str + "铭文配置文件.json"))
            {
                int num = (int)MessageBox.Show(string.Format("铭文系统配置文件[{0}]不存在！", (str + "铭文配置文件.json")));
            }
            else
            {

                MingWenConfig = File.ReadAllText(str + "铭文配置文件.json", Encoding.Default);
                cfg = JsonConvert.DeserializeObject<Configs>(MingWenConfig);
            }
        }

        private static void LoadDatabase()
        {
            Random = new Random();

            Session = new Session(SessionMode.Users)
            {
                BackUpDelay = 60,
            };

            MapInfoList = Session.GetCollection<MapInfo>();
            SafeZoneInfoList = Session.GetCollection<SafeZoneInfo>();
            ItemInfoList = Session.GetCollection<ItemInfo>();
            MonsterInfoList = Session.GetCollection<MonsterInfo>();
            RespawnInfoList = Session.GetCollection<RespawnInfo>();
            MagicInfoList = Session.GetCollection<MagicInfo>();
            FubenInfoList = Session.GetCollection<FubenInfo>();
            MingwenInfoList = Session.GetCollection<MingwenInfo>();

            AccountInfoList = Session.GetCollection<AccountInfo>();
            CharacterInfoList = Session.GetCollection<CharacterInfo>();
            BeltLinkList = Session.GetCollection<CharacterBeltLink>();
            AutoPotionLinkList = Session.GetCollection<AutoPotionLink>();
            UserTeleportList = Session.GetCollection<UserTeleport>();
            MeiriQuestInfoList = Session.GetCollection<MeiriQuestInfo>();
            UserItemList = Session.GetCollection<UserItem>();
            UserItemStatsList = Session.GetCollection<UserItemStat>();
            RefineInfoList = Session.GetCollection<RefineInfo>();
            UserMagicList = Session.GetCollection<UserMagic>();
            BuffInfoList = Session.GetCollection<BuffInfo>();
            SetInfoList = Session.GetCollection<SetInfo>();
            AuctionInfoList = Session.GetCollection<AuctionInfo>();
            MailInfoList = Session.GetCollection<MailInfo>();
            AuctionHistoryInfoList = Session.GetCollection<AuctionHistoryInfo>();
            UserDropList = Session.GetCollection<UserDrop>();
            StoreInfoList = Session.GetCollection<StoreInfo>();
            BaseStatList = Session.GetCollection<BaseStat>();
            MovementInfoList = Session.GetCollection<MovementInfo>();
            NPCInfoList = Session.GetCollection<NPCInfo>();
            MapRegionList = Session.GetCollection<MapRegion>();
            GuildInfoList = Session.GetCollection<GuildInfo>();
            GuildMemberInfoList = Session.GetCollection<GuildMemberInfo>();
            UserQuestList = Session.GetCollection<UserQuest>();
            UserQuestTaskList = Session.GetCollection<UserQuestTask>();
            MeiriUserQuestList = Session.GetCollection<MeiriUserQuest>();
            MeiriUserQuestTaskList = Session.GetCollection<MeiriUserQuestTask>();
            CompanionSkillInfoList = Session.GetCollection<CompanionSkillInfo>();

            CompanionInfoList = Session.GetCollection<CompanionInfo>();
            CompanionLevelInfoList = Session.GetCollection<CompanionLevelInfo>();
            UserCompanionList = Session.GetCollection<UserCompanion>();
            UserCompanionUnlockList = Session.GetCollection<UserCompanionUnlock>();
            BlockInfoList = Session.GetCollection<BlockInfo>();
            CastleInfoList = Session.GetCollection<CastleInfo>();
            UserConquestList = Session.GetCollection<UserConquest>();
            GameGoldPaymentList = Session.GetCollection<GameGoldPayment>();
            GameStoreSaleList = Session.GetCollection<GameStoreSale>();
            GuildWarInfoList = Session.GetCollection<GuildWarInfo>();
            UserConquestStatsList = Session.GetCollection<UserConquestStats>();
            UserFortuneInfoList = Session.GetCollection<UserFortuneInfo>();
            WeaponCraftStatInfoList = Session.GetCollection<WeaponCraftStatInfo>();
            UserCraftInfoList = Session.GetCollection<UserCrafting>();
            UserShenmiInfoList = Session.GetCollection<UserShenmiCount>();
            UserArenaPvPStatsList = Session.GetCollection<UserArenaPvPStats>();
            CraftingLevelsInfoList = Session.GetCollection<CraftLevelInfo>();
            CraftingItemInfoList = Session.GetCollection<CraftItemInfo>();
            MiniGameInfoList = Session.GetCollection<MiniGameInfo>();
            HorseInfoList = Session.GetCollection<HorseInfo>();
            UserHorseList = Session.GetCollection<UserHorse>();
            UserHorseUnlockList = Session.GetCollection<UserHorseUnlock>();

            GoldInfo = ItemInfoList.Binding.First(x => x.Effect == ItemEffect.Gold);
            GameGoldInfo = ItemInfoList.Binding.First(x => x.Effect == ItemEffect.GameGold);
            RefinementStoneInfo = ItemInfoList.Binding.First(x => x.Effect == ItemEffect.RefinementStone);
            FragmentInfo = ItemInfoList.Binding.First(x => x.Effect == ItemEffect.Fragment1);
            Fragment2Info = ItemInfoList.Binding.First(x => x.Effect == ItemEffect.Fragment2);
            Fragment3Info = ItemInfoList.Binding.First(x => x.Effect == ItemEffect.Fragment3);

            ItemPartInfo = ItemInfoList.Binding.First(x => x.Effect == ItemEffect.ItemPart);
            FortuneCheckerInfo = ItemInfoList.Binding.First(x => x.Effect == ItemEffect.FortuneChecker);
            TeleportInfo = ItemInfoList.Binding.First(x => x.Effect == ItemEffect.Teleport);
            TeleportInfoHD = ItemInfoList.Binding.First(x => x.Effect == ItemEffect.TeleportHD);

            MysteryShipMapRegion = MapRegionList.Binding.FirstOrDefault(x => x.Index == Config.MysteryShipRegionIndex);
            LairMapRegion = MapRegionList.Binding.FirstOrDefault(x => x.Index == Config.LairRegionIndex);
            yaotaMapRegion = MapRegionList.Binding.FirstOrDefault(x => x.Index == Config.Yaota);
            MotaMapRegion = MapRegionList.Binding.FirstOrDefault(x => x.Index == Config.Mota);
            Huodong01MapRegion = MapRegionList.Binding.FirstOrDefault(x => x.Index == Config.Huodong01);
            Huodong02MapRegion = MapRegionList.Binding.FirstOrDefault(x => x.Index == Config.Huodong02);
            Huodong03MapRegion = MapRegionList.Binding.FirstOrDefault(x => x.Index == Config.Huodong03);
            Huodong04MapRegion = MapRegionList.Binding.FirstOrDefault(x => x.Index == Config.Huodong04);
            Huodong05MapRegion = MapRegionList.Binding.FirstOrDefault(x => x.Index == Config.Huodong05);
            Huodong06MapRegion = MapRegionList.Binding.FirstOrDefault(x => x.Index == Config.Huodong06);
            Huodong07MapRegion = MapRegionList.Binding.FirstOrDefault(x => x.Index == Config.Huodong07);
            Huodong08MapRegion = MapRegionList.Binding.FirstOrDefault(x => x.Index == Config.Huodong08);
            Huodong09MapRegion = MapRegionList.Binding.FirstOrDefault(x => x.Index == Config.Huodong09);
            Huodong10MapRegion = MapRegionList.Binding.FirstOrDefault(x => x.Index == Config.Huodong10);
            Huodong11MapRegion = MapRegionList.Binding.FirstOrDefault(x => x.Index == Config.Huodong11);
            Huodong12MapRegion = MapRegionList.Binding.FirstOrDefault(x => x.Index == Config.Huodong12);

            StarterGuild = GuildInfoList.Binding.FirstOrDefault(x => x.StarterGuild);
            AutoFightConfList = SEnvir.Session.GetCollection<AutoFightConfig>();
            if (!Directory.Exists(NameListPath))
                Directory.CreateDirectory(NameListPath);

            if (!Directory.Exists(YueNameListPath))
                Directory.CreateDirectory(YueNameListPath);

            if (!Directory.Exists(GuildListPath))
                Directory.CreateDirectory(GuildListPath);

            if (!Directory.Exists(MapRegionPath))
                Directory.CreateDirectory(MapRegionPath);

            if (!Directory.Exists(CDkeyPath))
                Directory.CreateDirectory(CDkeyPath);

            if (StarterGuild == null)
            {
                StarterGuild = GuildInfoList.CreateNewObject();
                StarterGuild.StarterGuild = true;
            }

            StarterGuild.GuildName = Config.StarterGuildName;

            #region Create Ranks
            Rankings = new LinkedList<CharacterInfo>();
            TopRankings = new HashSet<CharacterInfo>();
            foreach (CharacterInfo info in CharacterInfoList.Binding)
            {
                info.RankingNode = Rankings.AddLast(info);
                RankingSort(info, false);
            }
            UpdateLead();
            #endregion


            #region Create GuildRanks
            GuildRankings = new LinkedList<GuildInfo>();
            GuildTopRankings = new HashSet<GuildInfo>();
            foreach (GuildInfo info in GuildInfoList.Binding)
            {
                info.GuildRankingNode = GuildRankings.AddLast(info);
                GuildRankingSort(info, false);
            }
            if (Config.是否开启公会排行榜Buff)
                GuildUpdateLead();
            #endregion


            #region Create GuildGerenRanks
            GuildGerenRankings = new LinkedList<GuildMemberInfo>();
            GuildGerenTopRankings = new HashSet<GuildMemberInfo>();
            foreach (GuildMemberInfo info in GuildMemberInfoList.Binding)
            {
                info.GuildGerenRankingNode = GuildGerenRankings.AddLast(info);
                GuildGerenRankingSort(info, false);
            }
            #endregion


            #region Create GuildGerenManks
            GuildGerenMankings = new LinkedList<CharacterInfo>();
            GuildGerenTopMankings = new HashSet<CharacterInfo>();
            foreach (CharacterInfo info in CharacterInfoList.Binding)
            {
                info.GuildGerenMankingNode = GuildGerenMankings.AddLast(info);
                GuildGerenMankingSort(info, false);
            }
            if (Config.是否开启公会个人排行榜Buff)
                GuildGerenUpdateLead();
            #endregion

            TreaItemList.Clear();

            TreaItemList01.Clear();
   
            TreaItemList02.Clear();
  
            TreaItemList03.Clear();
  
            TreaItemList04.Clear();

            TreaItemList05.Clear();
            for (int index = 0; index < ItemInfoList.Count; ++index)
            {
                if (ItemInfoList[index].CanTreasure)
                    TreaItemList.Add(ItemInfoList[index]);
                if (ItemInfoList[index].CanTreasure01)
                    TreaItemList01.Add(ItemInfoList[index]);
                if (ItemInfoList[index].CanTreasure02)
                    TreaItemList02.Add(ItemInfoList[index]);
                if (ItemInfoList[index].CanTreasure03)
                    TreaItemList03.Add(ItemInfoList[index]);
                if (ItemInfoList[index].CanTreasure04)
                    TreaItemList04.Add(ItemInfoList[index]);
                if (ItemInfoList[index].CanTreasure05)
                    TreaItemList05.Add(ItemInfoList[index]);
            }

            for (int i = UserQuestList.Count - 1; i >= 0; i--)
                if (UserQuestList[i].QuestInfo == null)
                    UserQuestList[i].Delete();

            for (int i = UserQuestTaskList.Count - 1; i >= 0; i--)
                if (UserQuestTaskList[i].Task == null)
                    UserQuestTaskList[i].Delete();

            for (int i = MeiriUserQuestList.Count - 1; i >= 0; i--)
                if (MeiriUserQuestList[i].QuestInfo == null)
                    MeiriUserQuestList[i].Delete();

            for (int i = MeiriUserQuestTaskList.Count - 1; i >= 0; i--)
                if (MeiriUserQuestTaskList[i].Task == null)
                    MeiriUserQuestTaskList[i].Delete();

            foreach (MonsterInfo monster in MonsterInfoList.Binding)
            {
                if (!monster.IsBoss) continue;
                if (monster.Drops.Count == 0) continue;

                BossList.Add(monster);

            }

            Messages = new ConcurrentQueue<IPNMessage>();

            PaymentList.Clear();

            if (Directory.Exists(VerifiedPath))
            {
                string[] files = Directory.GetFiles(VerifiedPath);

                foreach (string file in files)
                    Messages.Enqueue(new IPNMessage { FileName = file, Message = File.ReadAllText(file), Verified = true });
            }

        }
        public static void RankingSort(CharacterInfo character, bool updateLead = true)
        {
            bool changed = false;

            LinkedListNode<CharacterInfo> node;
            while ((node = character.RankingNode.Previous) != null)
            {
                int nodelevel = node.Value.Level + 5000 * node.Value.Rebirth;
                int characterlevel = character.Level + 5000 * character.Rebirth;

                if (nodelevel > characterlevel) break;
                if (nodelevel == characterlevel && node.Value.Experience >= character.Experience) break;

                changed = true;

                Rankings.Remove(character.RankingNode);
                Rankings.AddBefore(node, character.RankingNode);
            }

            if (!updateLead || (TopRankings.Count >= 20 && !changed)) return; 

            UpdateLead();
        }

        public static void GuildRankingSort(GuildInfo character, bool updateLead = true)
        {
            bool changed = false;

            LinkedListNode<GuildInfo> node;
            while ((node = character.GuildRankingNode.Previous) != null)
            {
                int nodelevel = node.Value.GuildLevel;
                int characterlevel = character.GuildLevel;

                if (nodelevel > characterlevel) break;
                if (nodelevel == characterlevel && node.Value.JyTotalContribution >= character.JyTotalContribution) break;

                changed = true;

                GuildRankings.Remove(character.GuildRankingNode);
                GuildRankings.AddBefore(node, character.GuildRankingNode);
            }

            if (!updateLead || (GuildTopRankings.Count >= 10 && !changed)) return; 

            if (Config.是否开启公会排行榜Buff)
                GuildUpdateLead();
        }

        public static void GuildGerenRankingSort(GuildMemberInfo character, bool updateLead = true)
        {
            bool changed = false;

            LinkedListNode<GuildMemberInfo> node;
            while ((node = character.GuildGerenRankingNode.Previous) != null)
            {
                long nodelevel = node.Value.DailyContribution;
                long characterlevel = character.DailyContribution;

                if (nodelevel > characterlevel) break;
                if (nodelevel == characterlevel && node.Value.DailyContribution >= character.DailyContribution) break;

                changed = true;

                GuildGerenRankings.Remove(character.GuildGerenRankingNode);
                GuildGerenRankings.AddBefore(node, character.GuildGerenRankingNode);
            }

            if (!updateLead || (GuildGerenTopRankings.Count >= 20 && !changed)) return; 
        }

        public static void GuildGerenMankingSort(CharacterInfo character, bool mupdateLead = true)
        {
            bool changed = false;

            LinkedListNode<CharacterInfo> node;
            while ((node = character.GuildGerenMankingNode.Previous) != null)
            {
                long nodelevel = node.Value.DailyContribution;
                long characterlevel = character.DailyContribution;

                if (nodelevel > characterlevel) break;
                if (nodelevel == characterlevel && node.Value.DailyContribution >= character.DailyContribution) break;

                changed = true;

                GuildGerenMankings.Remove(character.GuildGerenMankingNode);
                GuildGerenMankings.AddBefore(node, character.GuildGerenMankingNode);
            }

            if (!mupdateLead || (GuildGerenTopMankings.Count >= 2 && !changed)) return;

            if (Config.是否开启公会个人排行榜Buff)
                GuildGerenUpdateLead();
        }

        public static void UpdateLead()
        {
            HashSet<CharacterInfo> newTopRankings = new HashSet<CharacterInfo>();

            int war = 5, wiz = 5, tao = 5, ass = 5;

            foreach (CharacterInfo cInfo in Rankings)
            {
                if (cInfo.Account.Admin) continue;

                switch (cInfo.Class)
                {
                    case MirClass.Warrior:
                        if (war == 0) continue;
                        war--;
                        newTopRankings.Add(cInfo);
                        break;
                    case MirClass.Wizard:
                        if (wiz == 0) continue;
                        wiz--;
                        newTopRankings.Add(cInfo);
                        break;
                    case MirClass.Taoist:
                        if (tao == 0) continue;
                        tao--;
                        newTopRankings.Add(cInfo);
                        break;
                    case MirClass.Assassin:
                        if (ass == 0) continue;
                        ass--;
                        newTopRankings.Add(cInfo);
                        break;
                }

                if (war == 0 && wiz == 0 && tao == 0 && ass == 0) break;
            }

            foreach (CharacterInfo info in TopRankings)
            {
                if (newTopRankings.Contains(info)) continue;

                info.Player?.BuffRemove(BuffType.Ranking);
            }

            foreach (CharacterInfo info in newTopRankings)
            {
                if (TopRankings.Contains(info)) continue;

                info.Player?.BuffAdd(BuffType.Ranking, TimeSpan.MaxValue, null, true, false, TimeSpan.Zero);
            }

            TopRankings = newTopRankings;
        }

        public static void GuildUpdateLead()
        {
            HashSet<GuildInfo> GuildnewTopRankings = new HashSet<GuildInfo>();

            int war = 1;

            foreach (GuildInfo cInfo in GuildRankings)
            {
                if (cInfo.Members == null) continue;

                if (war == 0) continue;
                war--;
                GuildnewTopRankings.Add(cInfo);

                if (war == 0) break;
            }

            foreach (GuildInfo info in GuildTopRankings)
            {
                if (GuildnewTopRankings.Contains(info)) continue;

                foreach (GuildMemberInfo member in info.Members)
                    member.Account.Connection?.Player?.BuffRemove(BuffType.GuildPaihang);
            }

            foreach (GuildInfo info in GuildnewTopRankings)
            {
                if (GuildTopRankings.Contains(info)) continue;

                foreach (GuildMemberInfo member in info.Members)
                    member.Account.Connection?.Player?.ApplyGuildPaihang();
            }

            GuildTopRankings = GuildnewTopRankings;
        }

        public static void GuildGerenUpdateLead()
        {
            HashSet<CharacterInfo> GuildGerennewTopMankings = new HashSet<CharacterInfo>();

            int war = 1;

            foreach (CharacterInfo cInfo in GuildGerenMankings)
            {

                if (war == 0) continue;
                war--;
                GuildGerennewTopMankings.Add(cInfo);

                if (war == 0) break;
            }

            foreach (CharacterInfo info in GuildGerenTopMankings)
            {
                if (GuildGerennewTopMankings.Contains(info)) continue;

                info.Player?.BuffRemove(BuffType.GuildGongxian);
            }
            foreach (CharacterInfo info in GuildGerennewTopMankings)
            {
                if (GuildGerenTopMankings.Contains(info)) continue;

                info.Player?.ApplyGuildGeren();
            }

            GuildGerenTopMankings = GuildGerennewTopMankings;
        }

        private static void StartEnvir()
        {
            try
            {
                LoadDatabase();
            }
            catch
            {
                SEnvir.Log("[数据库错误] 加载数据库异常.", true);
            }
            LoadBroadCastInfo();
            LoadBroadMingWenConfigs();
            SEvirtimer = new System.Timers.Timer();
            SEvirtimer.Enabled = false;
            SEvirtimer.Interval = 1000.0;
            SEvirtimer.Start();
            SEvirtimer.Elapsed += new ElapsedEventHandler(SEvirtimer_Elapsed);
            #region Load Files
            for (int i = 0; i < MapInfoList.Count; i++)
                Maps[MapInfoList[i]] = new Map(MapInfoList[i]);


            Parallel.ForEach(Maps, x => x.Value.Load());

            #endregion

            foreach (Map map in Maps.Values)
                map.Setup();

            for (int index = 0; index < MapInfoList.Count; ++index)
            {
                if (!MapInfoList[index].IsDynamic)
                    Maps[MapInfoList[index]] = new Map(MapInfoList[index]);
            }

            Parallel.ForEach(Maps, (x => x.Value.Load()));
            foreach (Map map in Maps.Values)
                map.Setup();

            Parallel.ForEach(MapRegionList.Binding, x =>
            {
                Map map = GetMap(x.Map);

                if (map == null) return;

                x.CreatePoints(map.Width);
            });



            CreateSafeZones();

            CreateMovements();

            CreateNPCs();

            CreateSpawns();
        }

        private static void CreateMovements()
        {
            foreach (MovementInfo movement in MovementInfoList.Binding)
            {
                if (movement.SourceRegion == null) continue;

                Map sourceMap = GetMap(movement.SourceRegion.Map);
                if (sourceMap == null)
                {
                    Log($"[地图错误] 错误的地图来源, 来源: {movement.SourceRegion.ServerDescription}");
                    continue;
                }

                if (movement.DestinationRegion == null)
                {
                    Log($"[地图错误] 无目的地地图, 来源: {movement.SourceRegion.ServerDescription}");
                    continue;
                }

                Map destMap = GetMap(movement.DestinationRegion.Map);
                if (destMap == null)
                {
                    Log($"[地图错误] 错误的目的地地图, 指定: {movement.DestinationRegion.ServerDescription}");
                    continue;
                }


                foreach (Point sPoint in movement.SourceRegion.PointList)
                {
                    Cell source = sourceMap.GetCell(sPoint);

                    if (source == null)
                    {
                        Log($"[地图错误] 发生错误, 来源: {movement.SourceRegion.ServerDescription}, X:{sPoint.X}, Y:{sPoint.Y}");
                        continue;
                    }

                    if (source.Movements == null)
                        source.Movements = new List<MovementInfo>();

                    source.Movements.Add(movement);
                }
            }
        }

        private static void CreateNPCs()
        {
            foreach (NPCInfo info in NPCInfoList.Binding)
            {
                if (info.Region == null) continue;

                Map map = GetMap(info.Region.Map);

                if (map == null)
                {
                    if (!info.Region.Map.IsDynamic)
                        Log(string.Format("[NPC错误] 错误地图, NPC: {0}, Map: {1}", info.NPCName, info.Region.ServerDescription));
                    continue;
                }

                NPCObject ob = new NPCObject
                {
                    NPCInfo = info,
                };

                if (!ob.Spawn(info.Region))
                    Log($"[NPC错误] 无法生成NPC, 区域: {info.Region.ServerDescription}, NPC: {info.NPCName}");
            }
        }

        private static void CreateSafeZones()
        {
            foreach (SafeZoneInfo info in SafeZoneInfoList.Binding)
            {
                if (info.Region == null) continue;

                Map map = GetMap(info.Region.Map);

                if (map == null)
                {
                    Log($"[安全区错误] 错误地图, 地图: {info.Region.ServerDescription}");
                    continue;
                }

                HashSet<Point> edges = new HashSet<Point>();

                foreach (Point point in info.Region.PointList)
                {
                    Cell cell = map.GetCell(point);

                    if (cell == null)
                    {
                        Log($"[安全区错误] 错误的位置, 区域: {info.Region.ServerDescription}, X: {point.X}, Y: {point.Y}.");

                        continue;
                    }

                    cell.SafeZone = info;

                    for (int i = 0; i < 8; i++)
                    {
                        Point test = Functions.Move(point, (MirDirection)i);

                        if (info.Region.PointList.Contains(test)) continue;

                        if (map.GetCell(test) == null) continue;

                        edges.Add(test);
                    }
                }

                map.HasSafeZone = true;

                foreach (Point point in edges)
                {
                    SpellObject ob = new SpellObject
                    {
                        Visible = true,
                        DisplayLocation = point,
                        TickCount = 10,
                        TickFrequency = TimeSpan.FromDays(365),
                        Effect = SpellEffect.SafeZone
                    };

                    ob.Spawn(map.Info, point);
                }

                if (info.BindRegion == null) continue;

                map = GetMap(info.BindRegion.Map);

                if (map == null)
                {
                    Log($"[安全区错误] 地图光圈错误, 地图: {info.Region.ServerDescription}");
                    continue;
                }

                foreach (Point point in info.BindRegion.PointList)
                {
                    Cell cell = map.GetCell(point);

                    if (cell == null)
                    {
                        Log($"[安全区错误] 错误位置, 区域: {info.BindRegion.ServerDescription}, X: {point.X}, Y: {point.Y}.");
                        continue;
                    }

                    info.ValidBindPoints.Add(point);
                }

            }
        }

        private static void CreateSpawns()
        {
            foreach (RespawnInfo info in RespawnInfoList.Binding)
            {
                if (info.Monster == null) continue;
                if (info.Region == null) continue;

                Map map = GetMap(info.Region.Map);

                if (map == null)
                {
                    if (!info.Region.Map.IsDynamic)
                        Log(string.Format("[复活点] 地图错误, 地图: {0}", info.Region.ServerDescription));
                    continue;
                }

                Spawns.Add(new SpawnInfo(info));

            }
        }

        private static void StopEnvir()
        {
            Now = DateTime.MinValue;

            Session = null;


            MapInfoList = null;
            SafeZoneInfoList = null;
            AccountInfoList = null;
            CharacterInfoList = null;


            MapInfoList = null;
            SafeZoneInfoList = null;
            ItemInfoList = null;
            MonsterInfoList = null;
            RespawnInfoList = null;
            MagicInfoList = null;

            FubenInfoList = null;

            MingwenInfoList = null;

            AccountInfoList = null;
            CharacterInfoList = null;
            BeltLinkList = null;
            UserItemList = null;
            UserItemStatsList = null;
            UserMagicList = null;
            BuffInfoList = null;
            SetInfoList = null;

            Rankings = null;
            Random = null;

            GuildRankings = null;

            GuildGerenRankings = null;

            GuildGerenMankings = null;


            Maps.Clear();
            Objects.Clear();
            ActiveObjects.Clear();
            Players.Clear();

            Spawns.Clear();

            _ObjectID = 0;


            EnvirThread = null;
        }


        public static void EnvirLoop()
        {
            Now = Time.Now;
            DateTime DBTime = Now + Config.DBSaveDelay;

            StartEnvir();
            StartNetwork();
            StartWebServer();

            Started = NetworkStarted;

            int count = 0, loopCount = 0;
            DateTime nextCount = Now.AddSeconds(1), UserCountTime = Now.AddMinutes(5), saveTime;
            long previousTotalSent = 0, previousTotalReceived = 0;
            int lastindex = 0;
            long conDelay = 0;
            Thread logThread = new Thread(WriteLogsLoop) { IsBackground = true };
            logThread.Start();

            LastWarTime = Now;

            Log($"加载时间: {Functions.ToString(Time.Now - Now, true)}");

            while (Started)
            {
                Now = Time.Now;
                loopCount++;

                try
                {
                    SConnection connection;
                    while (!NewConnections.IsEmpty)
                    {
                        if (!NewConnections.TryDequeue(out connection)) break;

                        IPCount.TryGetValue(connection.IPAddress, out var ipCount);
                        IPCount[connection.IPAddress] = ipCount + 1;

                        Connections.Add(connection);
                    }

                    long bytesSent = 0;
                    long bytesReceived = 0;

                    for (int i = Connections.Count - 1; i >= 0; i--)
                    {
                        if (i >= Connections.Count) break;

                        connection = Connections[i];

                        connection.Process();
                        bytesSent += connection.TotalBytesSent;
                        bytesReceived += connection.TotalBytesReceived;
                    }

                    long delay = (Time.Now - Now).Ticks / TimeSpan.TicksPerMillisecond;
                    if (delay > conDelay)
                        conDelay = delay;

                    for (int i = Players.Count - 1; i >= 0; i--)
                        Players[i].StartProcess();

                    TotalBytesSent = DBytesSent + bytesSent;
                    TotalBytesReceived = DBytesReceived + bytesReceived;

                    if (ServerBuffChanged)
                    {
                        for (int i = Players.Count - 1; i >= 0; i--)
                            Players[i].ApplyServerBuff();

                        ServerBuffChanged = false;
                    }

                    DateTime loopTime = Time.Now.AddMilliseconds(1);

                    if (lastindex < 0) lastindex = ActiveObjects.Count;

                    while (Time.Now <= loopTime)
                    {
                        lastindex--;

                        if (lastindex >= ActiveObjects.Count) continue;

                        if (lastindex < 0) break;

                        MapObject ob = ActiveObjects[lastindex];

                        if (ob.Race == ObjectType.Player) continue;

                        try
                        {
                            ob.StartProcess();
                            count++;
                        }
                        catch (Exception ex)
                        {
                            ActiveObjects.Remove(ob);
                            ob.Activated = false;

                            Log(ex.Message);
                            Log(ex.StackTrace);
                            File.AppendAllText(@".\Errors.txt", ex.StackTrace + Environment.NewLine);
                        }
                    }

                    if (Now >= nextCount)
                    {
                        if (Now >= DBTime && !Saving)
                        {
                            DBTime = Time.Now + Config.DBSaveDelay;
                            saveTime = Time.Now;

                            Save();

                            SaveDelay = (Time.Now - saveTime).Ticks / TimeSpan.TicksPerMillisecond;
                        }

                        ProcessObjectCount = count;
                        LoopCount = loopCount;
                        ConDelay = conDelay;

                        count = 0;
                        loopCount = 0;
                        conDelay = 0;

                        DownloadSpeed = TotalBytesReceived - previousTotalReceived;
                        UploadSpeed = TotalBytesSent - previousTotalSent;

                        previousTotalReceived = TotalBytesReceived;
                        previousTotalSent = TotalBytesSent;

                        if (Now >= UserCountTime)
                        {
                            UserCountTime = Now.AddMinutes(5);

                            foreach (SConnection conn in Connections)
                            {
                                conn.ReceiveChat(string.Format(conn.Language.OnlineCount, Players.Count, Connections.Count(x => x.Stage == GameStage.Observer)), MessageType.System);

                                switch (conn.Stage)
                                {
                                    case GameStage.Game:
                                        if (conn.Player.Character.Observable)
                                            conn.ReceiveChat(string.Format(conn.Language.ObserverCount, conn.Observers.Count), MessageType.System);
                                        break;
                                    case GameStage.Observer:
                                        conn.ReceiveChat(string.Format(conn.Language.ObserverCount, conn.Observed.Observers.Count), MessageType.System);
                                        break;
                                }
                            }
                        }

                        CalculateLights();

                        CheckGuildWars();

                        string checktime;
                        string time;
                        checktime = "00:00";
                        time = DateTime.Now.ToString("HH:mm:ss");
                        if (time.Equals(checktime + ":30"))

                        {
                         
                            
                            KillGuildBoss();
                            KillGuildFuben();
                            foreach (PlayerObject ob in Players)
                            {
                                if (ob.Character.Account.GuildMember != null)
                                {
                                    GuildInfo guild = ob.Character.Account.GuildMember.Guild;
                              
                                    guild.GuildBosshd01 = 1;
                      
                                    guild.GuildFubenhd03 = 1;
                            
                                    guild.GuildJiachenghd04 = 1;
                           
                                    guild.ShuangGongxian = 1;

                                    S.GuildUpdate update = ob.Character.Account.GuildMember.Guild.GetUpdatePacket();

                                    foreach (GuildMemberInfo member in ob.Character.Account.GuildMember.Guild.Members)
                                        member.Account.Connection?.Player?.Enqueue(update);
                                }
                            }

                        }
        
                        checktime = "04:00";
                        if (time.Equals(checktime + ":10"))
                        {
                            foreach (PlayerObject ob in Players)
                            {
                                if (ob.Character.Account.GuildMember != null)
                                {
                                    GuildInfo guild = ob.Character.Account.GuildMember.Guild;
                                    guild.GuildQuanhd02 = 2;

                                    S.GuildUpdate update = ob.Character.Account.GuildMember.Guild.GetUpdatePacket();

                                    foreach (GuildMemberInfo member in ob.Character.Account.GuildMember.Guild.Members)
                                        member.Account.Connection?.Player?.Enqueue(update);
                                }
                            }
                            foreach (SConnection con in Connections)
                                con.ReceiveChat($"公会活动提示：公会泉活动已开启，04:00—23:00", MessageType.Notice);
                        }


   
                        if (Config.是否自动挂机功能下班期间关闭)
                        {
                            checktime = "17:59";
                            if (time.Equals(checktime + ":45"))
                            {
                                Shifouguanbiguajign = true;
                                foreach (PlayerObject player in Players)
                                    player.Enqueue(new S.ZidongGjguanbi { Zdgjgongneng = Shifouguanbiguajign });
                            }
                            checktime = "21:59";
                            if (time.Equals(checktime + ":45"))
                            {
                                Shifouguanbiguajign = false;
                                foreach (PlayerObject player in Players)
                                    player.Enqueue(new S.ZidongGjguanbi { Zdgjgongneng = Shifouguanbiguajign });
                            }
                        }

  
                        checktime = "20:00";
                        if (time.Equals(checktime + ":15"))
                        {
                            Config.是否开启额外经验加成 = true;
                            foreach (PlayerObject player in Players)
                                player.ApplyServerBuff();
                            foreach (SConnection con in Connections)
                                con.ReceiveChat($"活动提示：每天额外爆率加成活动开启了，开启时间20:00—0:00。", MessageType.Notice);
                        }
                        
                        checktime = "23:00";
                        if (time.Equals(checktime + ":10"))
                        {
                            foreach (PlayerObject ob in Players)
                            {
                                if (ob.Character.Account.GuildMember != null)
                                {

                                    GuildInfo guild = ob.Character.Account.GuildMember.Guild;
                                    guild.GuildQuanhd02 = 3;

                                    S.GuildUpdate update = ob.Character.Account.GuildMember.Guild.GetUpdatePacket();

                                    foreach (GuildMemberInfo member in ob.Character.Account.GuildMember.Guild.Members)
                                        member.Account.Connection?.Player?.Enqueue(update);
                                }
                            }
                            foreach (SConnection con in Connections)
                                con.ReceiveChat($"公会活动提示：公会泉活动已关闭", MessageType.Notice);
                        }
                        
                        checktime = "23:50";
                        if (time.Equals(checktime + ":30"))
                        {
                            Config.是否开启额外经验加成 = false;
                            foreach (PlayerObject player in Players)
                                player.ApplyServerBuff();
                            foreach (SConnection con in Connections)
                                con.ReceiveChat($"活动提示：每天额外爆率加成活动结束了，开启时间20:00—0:00。", MessageType.Notice);
                        }


                        string checkday;
                        string day;
                        checkday = "Monday";
                        day = DateTime.Now.DayOfWeek.ToString("");
                        if (day.Equals(checkday))
                        {
                            checktime = "20:59";
                            if (time.Equals(checktime + ":58"))
                            {
                                foreach (SConnection con in Connections)
                                    con.ReceiveChat($"活动提示：【砍树打宝】活动开始了，去比奇县找比奇公告NPC", MessageType.Notice);
                            }

                            checktime = "21:59";
                            if (time.Equals(checktime + ":58"))
                            {
                                foreach (SConnection con in Connections)
                                    con.ReceiveChat($"活动提示：【砍树打宝】活动已结束", MessageType.Notice);
                            }
                        }
                        checkday = "Wednesday";
                        day = DateTime.Now.DayOfWeek.ToString("");
                        if (day.Equals(checkday))
                        {
                            checktime = "20:59";
                            if (time.Equals(checktime + ":58"))
                            {
                                foreach (SConnection con in Connections)
                                    con.ReceiveChat($"活动提示：【砍树打宝】活动开始了，去比奇县找比奇公告NPC", MessageType.Notice);
                            }

                            checktime = "21:59";
                            if (time.Equals(checktime + ":58"))
                            {
                                foreach (SConnection con in Connections)
                                    con.ReceiveChat($"活动提示：【砍树打宝】活动已结束", MessageType.Notice);
                            }
                        }
                        checkday = "Friday";
                        day = DateTime.Now.DayOfWeek.ToString("");
                        if (day.Equals(checkday))
                        {
                            checktime = "20:59";
                            if (time.Equals(checktime + ":58"))
                            {
                                foreach (SConnection con in Connections)
                                    con.ReceiveChat($"活动提示：【砍树打宝】活动开始了，去比奇县找比奇公告NPC", MessageType.Notice);
                            }

                            checktime = "21:59";
                            if (time.Equals(checktime + ":58"))
                            {
                                foreach (SConnection con in Connections)
                                    con.ReceiveChat($"活动提示：【砍树打宝】活动已结束", MessageType.Notice);
                            }
                        }
                        checkday = "Sunday";
                        day = DateTime.Now.DayOfWeek.ToString("");
                        if (day.Equals(checkday))
                        {
                            checktime = "20:59";
                            if (time.Equals(checktime + ":58"))
                            {
                                foreach (SConnection con in Connections)
                                    con.ReceiveChat($"活动提示：【砍树打宝】活动开始了，去比奇县找比奇公告NPC", MessageType.Notice);
                            }

                            checktime = "21:59";
                            if (time.Equals(checktime + ":58"))
                            {
                                foreach (SConnection con in Connections)
                                    con.ReceiveChat($"活动提示：【砍树打宝】活动已结束", MessageType.Notice);
                            }
                        }
                        

                        checkday = "1";
                        day = DateTime.Now.Day.ToString("");
                        if (day.Equals(checkday))
                        {
                            checktime = "00:00";
                            if (time.Equals(checktime + ":40"))
                            {
                                string PathUserDatas = null;
                                StreamWriter t = null;

                                string fileNames = YueNameListPath;

                                string[] yues_files = Directory.GetFiles(fileNames, "*.txt");
                                foreach (string yues_file in yues_files)
                                {
                                    PathUserDatas = yues_file;
                                    t = new StreamWriter(PathUserDatas, false, Encoding.UTF8);
                                    t.Write("");
                                    t.Close();
                                }
                            }

                        }

                      


                      

                        foreach (KeyValuePair<MapInfo, Map> pair in Maps)
                            pair.Value.Process();

                        foreach (SpawnInfo spawn in Spawns)
                            spawn.DoSpawn(false);

                        for (int i = ConquestWars.Count - 1; i >= 0; i--)
                            ConquestWars[i].Process();

      
                        for (int j = MiniGames.Count - 1; j >= 0; j--)
                        {
                            MiniGames[j].Process();
                        }

                        while (!WebCommandQueue.IsEmpty)
                        {
                            if (!WebCommandQueue.TryDequeue(out WebCommand webCommand)) continue;

                            switch (webCommand.Command)
                            {
                                case CommandType.None:
                                    break;
                                case CommandType.Activation:
                                    webCommand.Account.Activated = true;
                                    webCommand.Account.ActivationKey = string.Empty;
                                    break;
                                case CommandType.PasswordReset:
                                    string password = Functions.RandomString(Random, 10);

                                    webCommand.Account.Password = CreateHash(password);
                                    webCommand.Account.ResetKey = string.Empty;
                                    webCommand.Account.WrongPasswordCount = 0;
                                    SendResetPasswordEmail(webCommand.Account, password);
                                    break;
                                case CommandType.AccountDelete:
                                    if (webCommand.Account.Activated) continue;

                                    webCommand.Account.Delete();
                                    break;
                            }
                        }

                        if (Config.ProcessGameGold)
                            ProcessGameGold();

                        nextCount = Now.AddSeconds(1);
            
                        if (nextCount.Day != Now.Day)
                        {
                            foreach (GuildInfo guild in GuildInfoList.Binding)
                            {
                                guild.DailyContribution = 0;
                                guild.DailyGrowth = 0;
                                guild.GuildJiachenghdrenshu = 0;

                                foreach (GuildMemberInfo member in guild.Members)
                                {
                                    member.DailyContribution = 0;

                                    if (member.Account.Connection?.Player == null) continue;

                                    member.Account.Connection.Enqueue(new S.GuildDayReset { ObserverPacket = false });
                                }
                            }
                            foreach (CharacterInfo info in CharacterInfoList.Binding)
                            {
                                info.DailyContribution = 0;
                            }

                    
                            string PathUserData = null;
                            StreamWriter t = null;

                            string fileName = NameListPath;

                            string[] s_files = Directory.GetFiles(fileName, "*.txt");
                            foreach (string s_file in s_files)
                            {
                                PathUserData = s_file;
                                t = new StreamWriter(PathUserData, false, Encoding.UTF8);
                                t.Write("");
                                t.Close();
                            }
              

                            foreach (PlayerObject ob in Players)
                            {
                   
                                ob.Character.Account.Fubendian = CartoonGlobals.Fubendian;
                                ob.Enqueue(new S.FubenDian { Fubendian = ob.Character.Account.Fubendian });

                                foreach (MeiriQuestInfo quest in MeiriQuestInfoList.Binding)
                                {
                                    MeiriUserQuest userQuest = ob.Character.Account.MeiriQuests.FirstOrDefault(x => x.QuestInfo == quest);
                                    if (userQuest != null)
                                    {
                                        ob.Enqueue(new S.MeiriQuestRemoved
                                        {
                                            Quest = userQuest.ToClientInfo()
                                        });
                                    }
                                }

                                ob.Character.Account.LastMeiriQuestGained = SEnvir.Now;
                                ob.Character.Account.HasDailyRandom = false;
                                ob.Character.Account.DailyRandomQuestResets = 2;

                                ob.Enqueue(new S.MeiRiDailyRandomQuestResets
                                {
                                    DailyCount = ob.Character.Account.DailyRandomQuestResets
                                });
                            }
            
                            for (int i = MeiriUserQuestList.Count - 1; i >= 0; i--)
                                if (MeiriUserQuestList[i].QuestInfo != null)
                                    MeiriUserQuestList[i].Delete();
              
                            for (int i = MeiriUserQuestTaskList.Count - 1; i >= 0; i--)
                                if (MeiriUserQuestTaskList[i].Task != null)
                                    MeiriUserQuestTaskList[i].Delete();

            

                            GC.Collect(2, GCCollectionMode.Forced);
                        }

                        foreach (CastleInfo info in CastleInfoList.Binding)
                        {
                            if (nextCount.TimeOfDay < info.StartTime) continue;
                            if (Now.TimeOfDay > info.StartTime) continue;

                            StartConquest(info, false);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Session = null;

                    Log(ex.Message);
                    Log(ex.StackTrace);
                    File.AppendAllText(@".\Errors.txt", ex.StackTrace + Environment.NewLine);

                    Packet p = new G.Disconnect { Reason = DisconnectReason.Crashed };
                    for (int i = Connections.Count - 1; i >= 0; i--)
                        Connections[i].SendDisconnect(p);

                    Thread.Sleep(3000);
                    break;
                }
            }

            StopWebServer();
            StopNetwork();
            SEvirtimer.Stop();

            while (Saving) Thread.Sleep(1);
            if (Session != null)
                Session.BackUpDelay = 0;
            Save();
            while (Saving) Thread.Sleep(1);

            StopEnvir();
        }

        public static bool HasObject(uint objectID)
        {
            return objectDictionary.ContainsKey(objectID);
        }

        private static void Save()
        {
            if (Session == null) return;

            Saving = true;
            Session.Save(false);

            HandledPayments.AddRange(PaymentList);

            Thread saveThread = new Thread(CommitChanges) { IsBackground = true };
            saveThread.Start(Session);
        }
        private static void CommitChanges(object data)
        {
            Session session = (Session)data;
            session?.Commit();

            foreach (IPNMessage message in HandledPayments)
            {
                if (message.Duplicate)
                {
                    File.Delete(message.FileName);
                    continue;
                }

                if (!Directory.Exists(CompletePath))
                    Directory.CreateDirectory(CompletePath);

                File.Move(message.FileName, CompletePath + Path.GetFileName(message.FileName) + ".txt");
                PaymentList.Remove(message);
            }
            HandledPayments.Clear();


            Saving = false;
        }
        private static void WriteLogsLoop()
        {
            DateTime NextLogTime = Now.AddSeconds(10);

            while (Started)
            {
                if (Now < NextLogTime)
                {
                    Thread.Sleep(1);
                    continue;
                }

                WriteLogs();

                NextLogTime = Now.AddSeconds(10);
            }
        }
        private static void WriteLogs()
        {
            List<string> lines = new List<string>();
            while (!Logs.IsEmpty)
            {
                if (!Logs.TryDequeue(out string line)) continue;
                lines.Add(line);
            }

            File.AppendAllLines(@".\Logs.txt", lines);

            lines.Clear();

            while (!ChatLogs.IsEmpty)
            {
                if (!ChatLogs.TryDequeue(out string line)) continue;
                lines.Add(line);
            }

            File.AppendAllLines(@".\Chat Logs.txt", lines);

            lines.Clear();


            lines.Clear();
        }
        private static void _ProcessGameGold()
        {
            if (!File.Exists(Config.OrderPath))
                return;
            try
            {
                string[] strArray = File.ReadAllLines(Config.OrderPath, Encoding.Default);
                if ((uint)strArray.Length <= 0U)
                    return;
                File.WriteAllText(Config.OrderPath, "");
                Dictionary<string, Dictionary<string, string>> dictionary1 = new Dictionary<string, Dictionary<string, string>>();
                Dictionary<string, string> dictionary2 = null;
                foreach (string input in strArray)
                {
                    Match match1 = SEnvir.HeaderRegex.Match(input);
                    if (match1.Success)
                    {
                        dictionary2 = new Dictionary<string, string>();
                        dictionary1[match1.Groups["Header"].Value] = dictionary2;
                    }
                    else if (dictionary2 != null)
                    {
                        Match match2 = SEnvir.EntryRegex.Match(input);
                        if (match2.Success)
                            dictionary2[match2.Groups["Key"].Value] = match2.Groups["Value"].Value;
                    }
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> keyValuePair in dictionary1)
                {
                    GameGoldPayment newObject = SEnvir.GameGoldPaymentList.CreateNewObject();
                    newObject.CharacterName = keyValuePair.Key;
                    int result = 0;
                    int.TryParse(keyValuePair.Value["RMB"], out result);
                    newObject.GameGoldAmount = result;
                    CharacterInfo character = SEnvir.GetCharacter(newObject.CharacterName);
                    newObject.Status = "正在充值";
                    newObject.Error = false;
                    if (character == null || newObject.Error)
                    {
                        newObject.Status = "充值出错";
                        SEnvir.Log(string.Format("[交易错误] 交易账号:{0} 交易状态:{1}, 数量{2}.", (object)newObject.CharacterName, (object)newObject.Status, (object)newObject.GameGoldAmount), true);
                    }
                    else
                    {
                        newObject.Status = "充值完成";
                        newObject.Account = character.Account;
                        newObject.PaymentDate = Time.Now.ToString();
                        newObject.Account.GameGold += newObject.GameGoldAmount;
                        newObject.Price = newObject.GameGoldAmount / 100;
       
                        character.Account.GameGoldPrice += newObject.Price;
                        character.Account.Connection?.ReceiveChat(string.Format(character.Account.Connection.Language.PaymentComplete, (object)newObject.GameGoldAmount), MessageType.System, 0U);
                        PlayerObject player = character.Player;
                        if (player != null)
                            player.Enqueue(new S.GameGoldChanged()
                            {
                                GameGold = newObject.Account.GameGold
                            });
                        AccountInfo referral = newObject.Account.Referral;
                        if (referral != null)
                        {
                            referral.HuntGold += newObject.GameGoldAmount / 10;
                            if (referral.Connection != null)
                            {
                                referral.Connection.ReceiveChat(string.Format(referral.Connection.Language.ReferralPaymentComplete, (object)(newObject.GameGoldAmount / 10)), MessageType.System, 0U);
                                if (referral.Connection.Stage == GameStage.Game)
                                    referral.Connection.Player.Enqueue((Packet)new S.HuntGoldChanged()
                                    {
                                        HuntGold = referral.GameGold
                                    });
                            }
                        }
  
                        player.ZanzhujiluChange();
                        Log(string.Format("[元宝购买] 角色: {0}, 数量: {1}.", (object)character.CharacterName, (object)newObject.GameGoldAmount), true);
                    }
                }
            }
            catch
            {
            }
        }
        private static void ProcessGameGold()
        {
            _ProcessGameGold();
            while (!Messages.IsEmpty)
            {
                IPNMessage message;

                if (!Messages.TryDequeue(out message) || message == null) return;

                PaymentList.Add(message);

                if (!message.Verified)
                {
                    Log("网上充值失败 " + message.Message);
                    continue;
                }

                string[] data = message.Message.Split('&');

                Dictionary<string, string> values = new Dictionary<string, string>();

                for (int i = 0; i < data.Length; i++)
                {
                    string[] keypair = data[i].Split('=');

                    values[keypair[0]] = keypair.Length > 1 ? keypair[1] : null;
                }

                bool error = false;
                string tempString, paymentStatus, transactionID;
                decimal tempDecimal;
                int tempInt;

                if (!values.TryGetValue("payment_status", out paymentStatus))
                    error = true;

                if (!values.TryGetValue("txn_id", out transactionID))
                    error = true;


                for (int i = 0; i < GameGoldPaymentList.Count; i++)
                {
                    if (GameGoldPaymentList[i].TransactionID != transactionID) continue;
                    if (GameGoldPaymentList[i].Status != paymentStatus) continue;


                    Log(string.Format("[复制交易] 角色:{0} 情况:{1}.", transactionID, paymentStatus));
                    message.Duplicate = true;
                    return;
                }

                GameGoldPayment payment = GameGoldPaymentList.CreateNewObject();
                payment.RawMessage = message.Message;
                payment.Error = error;

                if (values.TryGetValue("payment_date", out tempString))
                    payment.PaymentDate = HttpUtility.UrlDecode(tempString);

                if (values.TryGetValue("receiver_email", out tempString))
                    payment.Receiver_EMail = HttpUtility.UrlDecode(tempString);
                else
                    payment.Error = true;

                if (values.TryGetValue("mc_fee", out tempString) && decimal.TryParse(tempString, out tempDecimal))
                    payment.Fee = tempDecimal;
                else
                    payment.Error = true;

                if (values.TryGetValue("mc_gross", out tempString) && decimal.TryParse(tempString, out tempDecimal))
                    payment.Price = tempDecimal;
                else
                    payment.Error = true;

                if (values.TryGetValue("custom", out tempString))
                    payment.CharacterName = tempString;
                else
                    payment.Error = true;

                if (values.TryGetValue("mc_currency", out tempString))
                    payment.Currency = tempString;
                else
                    payment.Error = true;

                if (values.TryGetValue("txn_type", out tempString))
                    payment.TransactionType = tempString;
                else
                    payment.Error = true;

                if (values.TryGetValue("payer_email", out tempString))
                    payment.Payer_EMail = HttpUtility.UrlDecode(tempString);

                if (values.TryGetValue("payer_id", out tempString))
                    payment.Payer_ID = tempString;

                payment.Status = paymentStatus;
                payment.TransactionID = transactionID;
       
                switch (payment.Status)
                {
                    case "Completed":
                        break;
                }
                if (payment.Status != Completed) continue;

        
                if (string.Compare(payment.Receiver_EMail, Config.ReceiverEMail, StringComparison.OrdinalIgnoreCase) != 0)
                    payment.Error = true;


                if (payment.Currency != Currency)
                    payment.Error = true;

                if (GoldTable.TryGetValue(payment.Price, out tempInt))
                    payment.GameGoldAmount = tempInt;
                else
                    payment.Error = true;

                CharacterInfo character = GetCharacter(payment.CharacterName);

                if (character == null || payment.Error)
                {
                    Log($"[交易错误] 交易账号:{transactionID} 交易状态:{paymentStatus}, 数量{payment.Price}.");
                    continue;
                }

                payment.Account = character.Account;
                payment.Account.GameGold += payment.GameGoldAmount;
                character.Account.Connection?.ReceiveChat(string.Format(character.Account.Connection.Language.PaymentComplete, payment.GameGoldAmount), MessageType.System);
                character.Player?.Enqueue(new S.GameGoldChanged { GameGold = payment.Account.GameGold });

                AccountInfo referral = payment.Account.Referral;

                if (referral != null)
                {
                    referral.HuntGold += payment.GameGoldAmount / 10;

                    if (referral.Connection != null)
                    {
                        referral.Connection.ReceiveChat(string.Format(referral.Connection.Language.ReferralPaymentComplete, payment.GameGoldAmount / 10), MessageType.System);

                        if (referral.Connection.Stage == GameStage.Game)
                            referral.Connection.Player.Enqueue(new S.HuntGoldChanged { HuntGold = referral.GameGold });
                    }
                }

                Log($"[元宝购买] 角色: {character.CharacterName}, 数量: {payment.GameGoldAmount}.");
            }
        }

        public static void CheckGuildWars()
        {
            TimeSpan change = Now - LastWarTime;
            LastWarTime = Now;

            for (int i = GuildWarInfoList.Count - 1; i >= 0; i--)
            {
                GuildWarInfo warInfo = GuildWarInfoList[i];

                warInfo.Duration -= change;

                if (warInfo.Duration > TimeSpan.Zero) continue;

                foreach (GuildMemberInfo member in warInfo.Guild1.Members)
                    member.Account.Connection?.Player?.Enqueue(new S.GuildWarFinished { GuildName = warInfo.Guild2.GuildName });

                foreach (GuildMemberInfo member in warInfo.Guild2.Members)
                    member.Account.Connection?.Player?.Enqueue(new S.GuildWarFinished { GuildName = warInfo.Guild1.GuildName });

                warInfo.Guild1 = null;
                warInfo.Guild2 = null;

                warInfo.Delete();
            }

        }

        public static void CalculateLights()
        {
            DayTime = Math.Max(0.05F, Math.Abs((float)Math.Round(((Now.TimeOfDay.TotalMinutes * Config.DayCycleCount) % 1440) / 1440F * 2 - 1, 2))); 
        }
        public static void StartConquest(CastleInfo info, bool forced)
        {
            List<GuildInfo> participants = new List<GuildInfo>();

            if (!forced)
            {
                foreach (UserConquest conquest in UserConquestList.Binding)
                {
                    if (conquest.Castle != info) continue;
                    if (conquest.WarDate > Now.Date) continue;

                    participants.Add(conquest.Guild);
                }

                if (participants.Count == 0) return;

                foreach (GuildInfo guild in GuildInfoList.Binding)
                {
                    if (guild.Castle != info) continue;

                    participants.Add(guild);
                }

            }

            ConquestWar War = new ConquestWar
            {
                Castle = info,
                Participants = participants,
                EndTime = Now + info.Duration,
                StartTime = Now.Date + info.StartTime,
            };

            War.StartWar();
        }
        public static void StartConquest(CastleInfo info, List<GuildInfo> participants)
        {

            ConquestWar War = new ConquestWar
            {
                Castle = info,
                Participants = participants,
                EndTime = Now + TimeSpan.FromMinutes(15),
                StartTime = Now.Date + info.StartTime,
            };

            War.StartWar();
        }

        public static NPCInfo CreateLeitingNpc()
        {
            NPCInfo npcInfo = GetNpcInfo(209);
            Map npcmap = GetMap(Huodong10MapRegion.Map);
            if (npcmap.NPCs.Count == 0)
            {
                if (npcInfo != null && npcmap != null)
                {
                    new NPCObject() { NPCInfo = npcInfo }.Spawn(Huodong10MapRegion.Map, new Point(23, 23));
                }
            }
            return npcInfo;
        }

        public static UserItem CreateFreshItem(UserItem item)
        {
            UserItem freshItem = UserItemList.CreateNewObject();

            freshItem.Colour = item.Colour;

            freshItem.Info = item.Info;
            freshItem.CurrentDurability = item.CurrentDurability;
            freshItem.MaxDurability = item.MaxDurability;

            freshItem.Flags = item.Flags;

            freshItem.ExpireTime = item.ExpireTime;

            foreach (UserItemStat stat in item.AddedStats)
                freshItem.AddStat(stat.Stat, stat.Amount, stat.StatSource);
            freshItem.StatsChanged();

            return freshItem;
        }
        public static UserItem CreateFreshItem(ItemCheck check)
        {
            UserItem item = check.Item != null ? CreateFreshItem(check.Item) : CreateFreshItem(check.Info);

            item.Flags = check.Flags;
            item.ExpireTime = check.ExpireTime;

            if (item.Info.Effect == ItemEffect.Gold || item.Info.Effect == ItemEffect.Experience || item.Info.Effect == ItemEffect.GameGold || item.Info.Effect == ItemEffect.Shengwang)
                item.Count = check.Count;
            else
                item.Count = Math.Min(check.Info.StackSize, check.Count);

            check.Count -= item.Count;

            return item;
        }
        public static UserItem CreateFreshItem(ItemInfo info)
        {
            UserItem item = UserItemList.CreateNewObject();

            item.Colour = Color.FromArgb(Random.Next(256), Random.Next(256), Random.Next(256));

            item.Info = info;
            item.CurrentDurability = info.Durability;
            item.MaxDurability = info.Durability;
            item.Rarity = info.Rarity;
            return item;
        }
  
        public static UserItem CreateDropItems(ItemInfo info, int chance = 1000, int RarityInc = 1000)
        {
            UserItem item = UserItemList.CreateNewObject();
            chance = Math.Min(chance, Config.极品的爆率);
            RarityInc = Math.Min(RarityInc, Config.极品的大小5);
            int MaxRareAdded = Math.Min(RarityInc, 5);
            item.Info = info;
            item.MaxDurability = info.Durability;
            item.CraftInfoOnly = false;
            item.Info.Rarity = info.Rarity;
            int minadded = 0;
            item.Colour = Color.FromArgb(Random.Next(256), Random.Next(256), Random.Next(256));
            if (Random.Next(RarityInc) == 0)
            {
                ItemType itemType = info.ItemType;
                if (itemType - 2 <= ItemType.Consumable || itemType - 5 <= ItemType.Torch || itemType == ItemType.Shield)
                {
                    if (info.Rarity == Rarity.Common)
                    {
                        item.Info.Rarity = Rarity.Superior;
                        minadded += 3;
                        if (Random.Next(MaxRareAdded) == 0)
                        {
                            item.Info.Rarity = Rarity.Superior;
                        }
                    }
                    if (info.Rarity == Rarity.Superior)
                    {
                        item.Info.Rarity = Rarity.Elite;
                        minadded += 3;
                        if (Random.Next(MaxRareAdded) == 0)
                        {
                            item.Info.Rarity = Rarity.Elite;
                        }
                    }
                }
            }
            if (Random.Next(chance) == 0 || minadded > 0)
            {
                if (minadded == 0)
                {
                    minadded = 1;
                }
                switch (info.ItemType)
                {
                    case ItemType.Weapon:
                        UpgradeSuperiorWeapon(item);
                        break;
                    case ItemType.Shield:
                        UpgradeSuperiorShield(item);
                        break;
                    case ItemType.Armour:
                        UpgradeSuperiorArmour(item);
                        break;
                    case ItemType.Helmet:
                        UpgradeSuperiorHelmet(item);
                        break;
                    case ItemType.Necklace:
                        UpgradeSuperiorNecklace(item);
                        break;
                    case ItemType.Bracelet:
                        UpgradeSuperiorBracelet(item);
                        break;
                    case ItemType.Ring:
                        UpgradeSuperiorRing(item);
                        break;
                    case ItemType.Shoes:
                        UpgradeSuperiorShoes(item);
                        break;
                }
                item.StatsChanged();
            }
            switch (info.ItemType)
            {
                case ItemType.Weapon:
                case ItemType.Armour:
                case ItemType.Helmet:
                case ItemType.Necklace:
                case ItemType.Bracelet:
                case ItemType.Ring:
                case ItemType.Shoes:
                case ItemType.Shield:
                    item.CurrentDurability = Math.Min(Random.Next(info.Durability) + 1000, item.MaxDurability);
                    break;
                case ItemType.Meat:
                    item.CurrentDurability = Random.Next(info.Durability * 2) + 2000;
                    break;
                case ItemType.Ore:
                    item.CurrentDurability = Random.Next(info.Durability * 3) + 3000;
                    break;
                case ItemType.Book:
                    item.CurrentDurability = Random.Next(9) + 2;
                    item.CurrentDurability = Random.Next(81) + 20;
                    break;
                default:
                    item.CurrentDurability = info.Durability;
                    break;
            }
            return item;
        }

        public static UserItem CreateDropItem(ItemCheck check, int chance = 15)
        {
            int chances = Config.极品的爆率;

            UserItem item = CreateCommonDropItem(check.Info, chances);

            item.Flags = check.Flags;
            item.ExpireTime = check.ExpireTime;

            if (item.Info.Effect == ItemEffect.Gold || item.Info.Effect == ItemEffect.Experience)
                item.Count = check.Count;
            else
                item.Count = Math.Min(check.Info.StackSize, check.Count);

            check.Count -= item.Count;

            return item;
        }

        public static UserItem CreateCommonDropItem(ItemInfo info, int chance = 15)
        {
            UserItem item = UserItemList.CreateNewObject();

            item.Info = info;
            item.MaxDurability = info.Durability;

            item.Colour = Color.FromArgb(Random.Next(256), Random.Next(256), Random.Next(256));

            item.Rarity = info.Rarity;

            switch (info.ItemType)
            {
                case ItemType.Weapon:
                case ItemType.Shield:
                case ItemType.Armour:
                case ItemType.Helmet:
                case ItemType.Necklace:
                case ItemType.Bracelet:
                case ItemType.Ring:
                case ItemType.Shoes:
                    item.CurrentDurability = Math.Min(Random.Next(info.Durability) + 1000, item.MaxDurability);
                    break;
                case ItemType.Meat:
                    item.CurrentDurability = Random.Next(info.Durability * 2) + 2000;
                    break;
                case ItemType.Ore:
                    item.CurrentDurability = Random.Next(info.Durability * 3) + 3000;
                    break;
                case ItemType.Book:
                    item.CurrentDurability = Random.Next(96) + 5; 
                    break;
                default:
                    item.CurrentDurability = info.Durability;
                    break;
            }


            return item;
        }
        public static UserItem CreateSuperiorDropItem(ItemInfo info, int chance = 15)
        {
            UserItem item = UserItemList.CreateNewObject();

            chance = Math.Min(chance, Config.高级产生极品的概率);

            item.Info = info;
            item.MaxDurability = info.Durability;

            item.Colour = Color.FromArgb(Random.Next(256), Random.Next(256), Random.Next(256));

            if (item.Info.Rarity != Rarity.Common)
                chance *= 2;

            if (Random.Next(chance) == 0)
            {
                switch (info.ItemType)
                {
                    case ItemType.Weapon:
                        UpgradeSuperiorWeapon(item);
                        break;
                    case ItemType.Shield:
                        UpgradeSuperiorShield(item);
                        break;
                    case ItemType.Armour:
                        UpgradeSuperiorArmour(item);
                        break;
                    case ItemType.Helmet:
                        UpgradeSuperiorHelmet(item);
                        break;
                    case ItemType.Necklace:
                        UpgradeSuperiorNecklace(item);
                        break;
                    case ItemType.Bracelet:
                        UpgradeSuperiorBracelet(item);
                        break;
                    case ItemType.Ring:
                        UpgradeSuperiorRing(item);
                        break;
                    case ItemType.Shoes:
                        UpgradeSuperiorShoes(item);
                        break;
                }
                item.StatsChanged();
            }

            switch (info.ItemType)
            {
                case ItemType.Weapon:
                case ItemType.Shield:
                case ItemType.Armour:
                case ItemType.Helmet:
                case ItemType.Necklace:
                case ItemType.Bracelet:
                case ItemType.Ring:
                case ItemType.Shoes:
                    item.CurrentDurability = Math.Min(Random.Next(info.Durability) + 1000, item.MaxDurability);
                    break;
                case ItemType.Meat:
                    item.CurrentDurability = Random.Next(info.Durability * 2) + 2000;
                    break;
                case ItemType.Ore:
                    item.CurrentDurability = Random.Next(info.Durability * 3) + 3000;
                    break;
                case ItemType.Book:
                    item.CurrentDurability = Random.Next(96) + 5; 
                    break;
                default:
                    item.CurrentDurability = info.Durability;
                    break;
            }


            return item;
        }
        public static UserItem CreateEliteDropItem(ItemInfo info, int chance = 15)
        {
            UserItem item = UserItemList.CreateNewObject();

            chance = Math.Min(chance, Config.稀世产生极品的概率);

            item.Info = info;
            item.MaxDurability = info.Durability;

            item.Colour = Color.FromArgb(Random.Next(256), Random.Next(256), Random.Next(256));

            if (item.Info.Rarity != Rarity.Common)
                chance *= 2;

            if (Random.Next(chance) == 0)
            {
                switch (info.ItemType)
                {
                    case ItemType.Weapon:
                        UpgradeEliteWeapon(item);
                        break;
                    case ItemType.Shield:
                        UpgradeEliteShield(item);
                        break;
                    case ItemType.Armour:
                        UpgradeEliteArmour(item);
                        break;
                    case ItemType.Helmet:
                        UpgradeEliteHelmet(item);
                        break;
                    case ItemType.Necklace:
                        UpgradeEliteNecklace(item);
                        break;
                    case ItemType.Bracelet:
                        UpgradeEliteBracelet(item);
                        break;
                    case ItemType.Ring:
                        UpgradeEliteRing(item);
                        break;
                    case ItemType.Shoes:
                        UpgradeEliteShoes(item);
                        break;
                }
                item.StatsChanged();
            }

            switch (info.ItemType)
            {
                case ItemType.Weapon:
                case ItemType.Shield:
                case ItemType.Armour:
                case ItemType.Helmet:
                case ItemType.Necklace:
                case ItemType.Bracelet:
                case ItemType.Ring:
                case ItemType.Shoes:
                    item.CurrentDurability = Math.Min(Random.Next(info.Durability) + 1000, item.MaxDurability);
                    break;
                case ItemType.Meat:
                    item.CurrentDurability = Random.Next(info.Durability * 2) + 2000;
                    break;
                case ItemType.Ore:
                    item.CurrentDurability = Random.Next(info.Durability * 3) + 3000;
                    break;
                case ItemType.Book:
                    item.CurrentDurability = Random.Next(96) + 5; 
                    break;
                default:
                    item.CurrentDurability = info.Durability;
                    break;
            }


            return item;
        }

        public static ItemInfo GetItemInfo(string name)
        {
            for (int i = 0; i < ItemInfoList.Count; i++)
                if (string.Compare(ItemInfoList[i].ItemName.Replace(" ", ""), name, StringComparison.OrdinalIgnoreCase) == 0)
                    return ItemInfoList[i];

            return null;
        }

        public static MonsterInfo GetMonsterInfo(string name)
        {
            return MonsterInfoList.Binding.FirstOrDefault
            (monster => string.Compare(monster.MonsterName.Replace(" ", ""), name,
                            StringComparison.OrdinalIgnoreCase) == 0);
        }

        public static MonsterInfo GetMonsterInfo(int index)
        {
            return MonsterInfoList.Binding.FirstOrDefault(x => x.Index == index);
        }


        public static MonsterInfo GetMonsterInfo(Dictionary<MonsterInfo, int> list)
        {
            int total = 0;

            foreach (KeyValuePair<MonsterInfo, int> pair in list)
                total += pair.Value;

            int value = Random.Next(total);

            foreach (KeyValuePair<MonsterInfo, int> pair in list)
            {
                value -= pair.Value;

                if (value >= 0) continue;

                return pair.Key;
            }


            return null;
        }

        public static NPCInfo GetNpcInfo(string name)
        {
            return NPCInfoList.Binding.FirstOrDefault(x => string.Compare(x.NPCName.Replace(" ", ""), name, StringComparison.OrdinalIgnoreCase) == 0);
        }

        public static NPCInfo GetNpcInfo(int index)
        {
            return NPCInfoList.Binding.FirstOrDefault(x => x.Index == index);
        }

   
        public static void UpgradeSuperiorWeapon(UserItem item)
        {
            if (Random.Next(Config.高级武器攻击极品属性产生概率) == 0)
            {
                int value = Config.高级武器产生攻击极品属性的大小;

                if (Random.Next(Config.高级武器攻击加二极品属性的产生率) == 0)
                    value += Config.高级武器产生攻击极品属性的大小;

                if (Random.Next(Config.高级武器攻击加三极品属性的产生率) == 0)
                    value += Config.高级武器产生攻击极品属性的大小;

                if (Random.Next(Config.高级武器攻击加四极品属性的产生率) == 0)
                    value += Config.高级武器产生攻击极品属性的大小;

                if (Random.Next(Config.高级武器攻击加五极品属性的产生率) == 0)
                    value += Config.高级武器产生攻击极品属性的大小;

                item.AddStat(Stat.MaxDC, value, StatSource.Added);
            }

            if (Random.Next(Config.高级武器自然灵魂极品属性产生概率) == 0)
            {
                int value = Config.高级武器产生自然灵魂极品属性的大小;

                if (Random.Next(Config.高级武器自然灵魂加二极品属性的产生率) == 0)
                    value += Config.高级武器产生自然灵魂极品属性的大小;

                if (Random.Next(Config.高级武器自然灵魂加三极品属性的产生率) == 0)
                    value += Config.高级武器产生自然灵魂极品属性的大小;

                if (Random.Next(Config.高级武器自然灵魂加四极品属性的产生率) == 0)
                    value += Config.高级武器产生自然灵魂极品属性的大小;

                if (Random.Next(Config.高级武器自然灵魂加五极品属性的产生率) == 0)
                    value += Config.高级武器产生自然灵魂极品属性的大小;

           
                if (item.Info.Stats[Stat.MinMC] == 0 && item.Info.Stats[Stat.MaxMC] == 0 && item.Info.Stats[Stat.MinSC] == 0 && item.Info.Stats[Stat.MaxSC] == 0)
                {
                    item.AddStat(Stat.MaxMC, value, StatSource.Added);
                    item.AddStat(Stat.MaxSC, value, StatSource.Added);
                }


                if (item.Info.Stats[Stat.MinMC] > 0 || item.Info.Stats[Stat.MaxMC] > 0)
                    item.AddStat(Stat.MaxMC, value, StatSource.Added);

                if (item.Info.Stats[Stat.MinSC] > 0 || item.Info.Stats[Stat.MaxSC] > 0)
                    item.AddStat(Stat.MaxSC, value, StatSource.Added);

            }

            if (Random.Next(Config.高级武器准确极品属性产生概率) == 0)
            {
                int value = Config.高级武器产生准确极品属性的大小;

                if (Random.Next(Config.高级武器准确加二极品属性的产生率) == 0)
                    value += Config.高级武器产生准确极品属性的大小;

                if (Random.Next(Config.高级武器准确加三极品属性的产生率) == 0)
                    value += Config.高级武器产生准确极品属性的大小;

                if (Random.Next(Config.高级武器准确加四极品属性的产生率) == 0)
                    value += Config.高级武器产生准确极品属性的大小;

                if (Random.Next(Config.高级武器准确加五极品属性的产生率) == 0)
                    value += Config.高级武器产生准确极品属性的大小;

                item.AddStat(Stat.Accuracy, value, StatSource.Added);
            }

            List<Stat> Elements = new List<Stat>
            {
                Stat.FireAttack, Stat.IceAttack, Stat.LightningAttack, Stat.WindAttack,
                Stat.HolyAttack, Stat.DarkAttack,
                Stat.PhantomAttack,
            };


            if (Random.Next(Config.高级武器攻击元素极品属性产生概率) == 0)
            {
                int value = Config.高级武器产生攻击元素极品属性的大小;

                if (Random.Next(Config.高级武器攻击元素加二极品属性的产生率) == 0)
                    value += Config.高级武器产生攻击元素极品属性的大小;

                if (Random.Next(Config.高级武器攻击元素加三极品属性的产生率) == 0)
                    value += Config.高级武器产生攻击元素极品属性的大小;

                if (Random.Next(Config.高级武器攻击元素加四极品属性的产生率) == 0)
                    value += Config.高级武器产生攻击元素极品属性的大小;

                if (Random.Next(Config.高级武器攻击元素加五极品属性的产生率) == 0)
                    value += Config.高级武器产生攻击元素极品属性的大小;

                item.AddStat(Elements[Random.Next(Elements.Count)], value, StatSource.Added);
            }
        }
  
        public static void UpgradeSuperiorShield(UserItem item)
        {
            if (Random.Next(Config.高级盾牌攻击几率极品属性产生概率) == 0)
            {
                int value = Config.高级盾牌产生攻击几率极品属性的大小;

                if (Random.Next(Config.高级盾牌攻击几率加二极品属性的产生率) == 0)
                    value += Config.高级盾牌产生攻击几率极品属性的大小;

                if (Random.Next(Config.高级盾牌攻击几率加三极品属性的产生率) == 0)
                    value += Config.高级盾牌产生攻击几率极品属性的大小;

                if (Random.Next(Config.高级盾牌攻击几率加四极品属性的产生率) == 0)
                    value += Config.高级盾牌产生攻击几率极品属性的大小;

                if (Random.Next(Config.高级盾牌攻击几率加五极品属性的产生率) == 0)
                    value += Config.高级盾牌产生攻击几率极品属性的大小;

                item.AddStat(Stat.DCPercent, value, StatSource.Added);
            }

            if (Random.Next(Config.高级盾牌自然灵魂几率极品属性产生概率) == 0)
            {
                int value = Config.高级盾牌产生自然灵魂几率极品属性的大小;

                if (Random.Next(Config.高级盾牌自然灵魂几率加二极品属性的产生率) == 0)
                    value += Config.高级盾牌产生自然灵魂几率极品属性的大小;

                if (Random.Next(Config.高级盾牌自然灵魂几率加三极品属性的产生率) == 0)
                    value += Config.高级盾牌产生自然灵魂几率极品属性的大小;

                if (Random.Next(Config.高级盾牌自然灵魂几率加四极品属性的产生率) == 0)
                    value += Config.高级盾牌产生自然灵魂几率极品属性的大小;

                if (Random.Next(Config.高级盾牌自然灵魂几率加五极品属性的产生率) == 0)
                    value += Config.高级盾牌产生自然灵魂几率极品属性的大小;

                item.AddStat(Stat.MCPercent, value, StatSource.Added);
                item.AddStat(Stat.SCPercent, value, StatSource.Added);

            }

            if (Random.Next(Config.高级盾牌格挡几率极品属性产生概率) == 0)
            {
                int value = Config.高级盾牌产生格挡几率极品属性的大小;

                if (Random.Next(Config.高级盾牌格挡几率加二极品属性的产生率) == 0)
                    value += Config.高级盾牌产生格挡几率极品属性的大小;

                if (Random.Next(Config.高级盾牌格挡几率加三极品属性的产生率) == 0)
                    value += Config.高级盾牌产生格挡几率极品属性的大小;

                if (Random.Next(Config.高级盾牌格挡几率加四极品属性的产生率) == 0)
                    value += Config.高级盾牌产生格挡几率极品属性的大小;

                if (Random.Next(Config.高级盾牌格挡几率加五极品属性的产生率) == 0)
                    value += Config.高级盾牌产生格挡几率极品属性的大小;

                item.AddStat(Stat.BlockChance, value, StatSource.Added);
            }

            if (Random.Next(Config.高级盾牌闪避几率极品属性产生概率) == 0)
            {
                int value = Config.高级盾牌产生闪避几率极品属性的大小;

                if (Random.Next(Config.高级盾牌闪避几率加二极品属性的产生率) == 0)
                    value += Config.高级盾牌产生闪避几率极品属性的大小;

                if (Random.Next(Config.高级盾牌闪避几率加三极品属性的产生率) == 0)
                    value += Config.高级盾牌产生闪避几率极品属性的大小;

                if (Random.Next(Config.高级盾牌闪避几率加四极品属性的产生率) == 0)
                    value += Config.高级盾牌产生闪避几率极品属性的大小;

                if (Random.Next(Config.高级盾牌闪避几率加五极品属性的产生率) == 0)
                    value += Config.高级盾牌产生闪避几率极品属性的大小;

                item.AddStat(Stat.EvasionChance, value, StatSource.Added);
            }

            if (Random.Next(Config.高级盾牌毒系抵抗几率极品属性产生概率) == 0)
            {
                int value = Config.高级盾牌产生毒系抵抗几率极品属性的大小;

                if (Random.Next(Config.高级盾牌毒系抵抗几率加二极品属性的产生率) == 0)
                    value += Config.高级盾牌产生毒系抵抗几率极品属性的大小;

                if (Random.Next(Config.高级盾牌毒系抵抗几率加三极品属性的产生率) == 0)
                    value += Config.高级盾牌产生毒系抵抗几率极品属性的大小;

                if (Random.Next(Config.高级盾牌毒系抵抗几率加四极品属性的产生率) == 0)
                    value += Config.高级盾牌产生毒系抵抗几率极品属性的大小;

                if (Random.Next(Config.高级盾牌毒系抵抗几率加五极品属性的产生率) == 0)
                    value += Config.高级盾牌产生毒系抵抗几率极品属性的大小;

                item.AddStat(Stat.PoisonResistance, value, StatSource.Added);
            }

            List<Stat> Elements = new List<Stat>
            {
                Stat.FireResistance, Stat.IceResistance, Stat.LightningResistance, Stat.WindResistance,
                Stat.HolyResistance, Stat.DarkResistance,
                Stat.PhantomResistance, Stat.PhysicalResistance,
            };

            if (Random.Next(Config.高级盾牌强元素极品属性产生概率) == 0)
            {
                Stat element = Elements[Random.Next(Elements.Count)];

                Elements.Remove(element);

                if (item.Stats[element] == 0)
                    item.AddStat(element, Config.高级盾牌产生强元素属性的大小, StatSource.Added);

                if (Random.Next(Config.高级盾牌弱元素第二属性的产生率) == 0)
                {
                    element = Elements[Random.Next(Elements.Count)];

                    Elements.Remove(element);

                    if (item.Stats[element] == 0)
                        item.AddStat(element, -Config.高级盾牌产生强元素属性的大小, StatSource.Added);
                }

                if (Random.Next(Config.高级盾牌强元素第三属性产生概率) == 0)
                {
                    element = Elements[Random.Next(Elements.Count)];

                    Elements.Remove(element);

                    if (item.Stats[element] == 0)
                        item.AddStat(element, Config.高级盾牌产生强元素属性的大小, StatSource.Added);

                    if (Random.Next(Config.高级盾牌弱元素第四属性的产生率) == 0)
                    {
                        element = Elements[Random.Next(Elements.Count)];

                        Elements.Remove(element);

                        if (item.Stats[element] == 0)
                            item.AddStat(element, -Config.高级盾牌产生强元素属性的大小, StatSource.Added);
                    }

                    if (Random.Next(Config.高级盾牌强元素第五属性产生概率) == 0)
                    {
                        element = Elements[Random.Next(Elements.Count)];

                        Elements.Remove(element);

                        if (item.Stats[element] == 0)
                            item.AddStat(element, Config.高级盾牌产生强元素属性的大小, StatSource.Added);

                        if (Random.Next(Config.高级盾牌弱元素第六属性产生概率) == 0)
                        {
                            element = Elements[Random.Next(Elements.Count)];

                            Elements.Remove(element);

                            if (item.Stats[element] == 0)
                                item.AddStat(element, -Config.高级盾牌产生强元素属性的大小, StatSource.Added);
                        }

                    }
                    else if (Random.Next(Config.高级盾牌弱元素第五属性产生概率) == 0)
                    {
                        element = Elements[Random.Next(Elements.Count)];

                        Elements.Remove(element);

                        if (item.Stats[element] == 0)
                            item.AddStat(element, -Config.高级盾牌产生强元素属性的大小, StatSource.Added);
                    }
                }
                else if (Random.Next(Config.高级盾牌弱元素第三属性产生概率) == 0)
                {
                    element = Elements[Random.Next(Elements.Count)];

                    Elements.Remove(element);

                    if (item.Stats[element] == 0)
                        item.AddStat(element, -Config.高级盾牌产生强元素属性的大小, StatSource.Added);
                }
            }
            else if (Random.Next(Config.高级盾牌弱元素极品属性产生概率) == 0)
            {
                Stat element = Elements[Random.Next(Elements.Count)];

                Elements.Remove(element);

                if (item.Stats[element] == 0)
                    item.AddStat(element, -Config.高级盾牌产生强元素属性的大小, StatSource.Added);
            }
        }
 
        public static void UpgradeSuperiorArmour(UserItem item)
        {
            if (Random.Next(Config.高级衣服防御极品属性产生概率) == 0)
            {
                int value = Config.高级衣服产生防御极品属性的大小;

                if (Random.Next(Config.高级衣服防御加二极品属性的产生率) == 0)
                    value += Config.高级衣服产生防御极品属性的大小;

                if (Random.Next(Config.高级衣服防御加三极品属性的产生率) == 0)
                    value += Config.高级衣服产生防御极品属性的大小;

                if (Random.Next(Config.高级衣服防御加四极品属性的产生率) == 0)
                    value += Config.高级衣服产生防御极品属性的大小;

                if (Random.Next(Config.高级衣服防御加五极品属性的产生率) == 0)
                    value += Config.高级衣服产生防御极品属性的大小;

                item.AddStat(Stat.MaxAC, value, StatSource.Added);
            }

            if (Random.Next(Config.高级衣服魔御极品属性产生概率) == 0)
            {
                int value = Config.高级衣服产生魔御极品属性的大小;

                if (Random.Next(Config.高级衣服魔御加二极品属性的产生率) == 0)
                    value += Config.高级衣服产生魔御极品属性的大小;

                if (Random.Next(Config.高级衣服魔御加三极品属性的产生率) == 0)
                    value += Config.高级衣服产生魔御极品属性的大小;

                if (Random.Next(Config.高级衣服魔御加四极品属性的产生率) == 0)
                    value += Config.高级衣服产生魔御极品属性的大小;

                if (Random.Next(Config.高级衣服魔御加五极品属性的产生率) == 0)
                    value += Config.高级衣服产生魔御极品属性的大小;

                item.AddStat(Stat.MaxMR, value, StatSource.Added);
            }

            List<Stat> Elements = new List<Stat>
            {
                Stat.FireResistance, Stat.IceResistance, Stat.LightningResistance, Stat.WindResistance,
                Stat.HolyResistance, Stat.DarkResistance,
                Stat.PhantomResistance, Stat.PhysicalResistance,
            };

            if (Random.Next(Config.高级衣服强元素极品属性产生概率) == 0)
            {
                Stat element = Elements[Random.Next(Elements.Count)];

                Elements.Remove(element);

                if (item.Stats[element] == 0)
                    item.AddStat(element, Config.高级衣服产生强元素属性的大小, StatSource.Added);

                if (Random.Next(Config.高级衣服弱元素第二属性的产生率) == 0)
                {
                    element = Elements[Random.Next(Elements.Count)];

                    Elements.Remove(element);

                    if (item.Stats[element] == 0)
                        item.AddStat(element, -Config.高级衣服产生强元素属性的大小, StatSource.Added);
                }

                if (Random.Next(Config.高级衣服强元素第三属性产生概率) == 0)
                {
                    element = Elements[Random.Next(Elements.Count)];

                    Elements.Remove(element);

                    if (item.Stats[element] == 0)
                        item.AddStat(element, Config.高级衣服产生强元素属性的大小, StatSource.Added);

                    if (Random.Next(Config.高级衣服弱元素第四属性的产生率) == 0)
                    {
                        element = Elements[Random.Next(Elements.Count)];

                        Elements.Remove(element);

                        if (item.Stats[element] == 0)
                            item.AddStat(element, -Config.高级衣服产生强元素属性的大小, StatSource.Added);
                    }

                    if (Random.Next(Config.高级衣服强元素第五属性产生概率) == 0)
                    {
                        element = Elements[Random.Next(Elements.Count)];

                        Elements.Remove(element);

                        if (item.Stats[element] == 0)
                            item.AddStat(element, Config.高级衣服产生强元素属性的大小, StatSource.Added);

                        if (Random.Next(Config.高级衣服弱元素第六属性产生概率) == 0)
                        {
                            element = Elements[Random.Next(Elements.Count)];

                            Elements.Remove(element);

                            if (item.Stats[element] == 0)
                                item.AddStat(element, -Config.高级衣服产生强元素属性的大小, StatSource.Added);
                        }

                    }
                    else if (Random.Next(Config.高级衣服弱元素第五属性产生概率) == 0)
                    {
                        element = Elements[Random.Next(Elements.Count)];

                        Elements.Remove(element);

                        if (item.Stats[element] == 0)
                            item.AddStat(element, -Config.高级衣服产生强元素属性的大小, StatSource.Added);
                    }
                }
                else if (Random.Next(Config.高级衣服弱元素第三属性产生概率) == 0)
                {
                    element = Elements[Random.Next(Elements.Count)];

                    Elements.Remove(element);

                    if (item.Stats[element] == 0)
                        item.AddStat(element, -Config.高级衣服产生强元素属性的大小, StatSource.Added);
                }
            }
            else if (Random.Next(Config.高级衣服弱元素极品属性产生概率) == 0)
            {
                Stat element = Elements[Random.Next(Elements.Count)];

                Elements.Remove(element);

                if (item.Stats[element] == 0)
                    item.AddStat(element, -Config.高级衣服产生强元素属性的大小, StatSource.Added);
            }
        }

        public static void UpgradeSuperiorHelmet(UserItem item)
        {
            if (Random.Next(Config.高级头盔防御极品属性产生概率) == 0)
            {
                int value = Config.高级头盔产生防御极品属性的大小;

                if (Random.Next(Config.高级头盔防御加二极品属性的产生率) == 0)
                    value += Config.高级头盔产生防御极品属性的大小;

                if (Random.Next(Config.高级头盔防御加三极品属性的产生率) == 0)
                    value += Config.高级头盔产生防御极品属性的大小;

                if (Random.Next(Config.高级头盔防御加四极品属性的产生率) == 0)
                    value += Config.高级头盔产生防御极品属性的大小;

                if (Random.Next(Config.高级头盔防御加五极品属性的产生率) == 0)
                    value += Config.高级头盔产生防御极品属性的大小;

                item.AddStat(Stat.MaxAC, value, StatSource.Added);
            }

            if (Random.Next(Config.高级头盔魔御极品属性产生概率) == 0)
            {
                int value = Config.高级头盔产生魔御极品属性的大小;

                if (Random.Next(Config.高级头盔魔御加二极品属性的产生率) == 0)
                    value += Config.高级头盔产生魔御极品属性的大小;

                if (Random.Next(Config.高级头盔魔御加三极品属性的产生率) == 0)
                    value += Config.高级头盔产生魔御极品属性的大小;

                if (Random.Next(Config.高级头盔魔御加四极品属性的产生率) == 0)
                    value += Config.高级头盔产生魔御极品属性的大小;

                if (Random.Next(Config.高级头盔魔御加五极品属性的产生率) == 0)
                    value += Config.高级头盔产生魔御极品属性的大小;

                item.AddStat(Stat.MaxMR, value, StatSource.Added);
            }


            List<Stat> Elements = new List<Stat>
            {
                Stat.FireResistance, Stat.IceResistance, Stat.LightningResistance, Stat.WindResistance,
                Stat.HolyResistance, Stat.DarkResistance,
                Stat.PhantomResistance, Stat.PhysicalResistance,
            };
            if (Random.Next(Config.高级头盔强元素极品属性产生概率) == 0)
            {
                Stat element = Elements[Random.Next(Elements.Count)];

                Elements.Remove(element);

                if (item.Stats[element] == 0)
                    item.AddStat(element, Config.高级头盔产生强元素属性的大小, StatSource.Added);

                if (Random.Next(Config.高级头盔弱元素第二属性的产生率) == 0)
                {
                    element = Elements[Random.Next(Elements.Count)];

                    Elements.Remove(element);

                    if (item.Stats[element] == 0)
                        item.AddStat(element, -Config.高级头盔产生强元素属性的大小, StatSource.Added);
                }

                if (Random.Next(Config.高级头盔强元素第三属性产生概率) == 0)
                {
                    element = Elements[Random.Next(Elements.Count)];

                    Elements.Remove(element);

                    if (item.Stats[element] == 0)
                        item.AddStat(element, Config.高级头盔产生强元素属性的大小, StatSource.Added);

                    if (Random.Next(Config.高级头盔弱元素第四属性的产生率) == 0)
                    {
                        element = Elements[Random.Next(Elements.Count)];

                        Elements.Remove(element);

                        if (item.Stats[element] == 0)
                            item.AddStat(element, -Config.高级头盔产生强元素属性的大小, StatSource.Added);
                    }

                    if (Random.Next(Config.高级头盔强元素第五属性产生概率) == 0)
                    {
                        element = Elements[Random.Next(Elements.Count)];

                        Elements.Remove(element);

                        if (item.Stats[element] == 0)
                            item.AddStat(element, Config.高级头盔产生强元素属性的大小, StatSource.Added);

                        if (Random.Next(Config.高级头盔弱元素第六属性产生概率) == 0)
                        {
                            element = Elements[Random.Next(Elements.Count)];

                            Elements.Remove(element);

                            if (item.Stats[element] == 0)
                                item.AddStat(element, -Config.高级头盔产生强元素属性的大小, StatSource.Added);
                        }

                    }
                    else if (Random.Next(Config.高级头盔弱元素第五属性产生概率) == 0)
                    {
                        element = Elements[Random.Next(Elements.Count)];

                        Elements.Remove(element);

                        if (item.Stats[element] == 0)
                            item.AddStat(element, -Config.高级头盔产生强元素属性的大小, StatSource.Added);
                    }
                }
                else if (Random.Next(Config.高级头盔弱元素第三属性产生概率) == 0)
                {
                    element = Elements[Random.Next(Elements.Count)];

                    Elements.Remove(element);

                    if (item.Stats[element] == 0)
                        item.AddStat(element, -Config.高级头盔产生强元素属性的大小, StatSource.Added);
                }
            }
            else if (Random.Next(Config.高级头盔弱元素极品属性产生概率) == 0)
            {
                Stat element = Elements[Random.Next(Elements.Count)];

                Elements.Remove(element);

                if (item.Stats[element] == 0)
                    item.AddStat(element, -Config.高级头盔产生强元素属性的大小, StatSource.Added);
            }


            Elements = new List<Stat>
            {
                Stat.FireAttack, Stat.IceAttack, Stat.LightningAttack, Stat.WindAttack,
                Stat.HolyAttack, Stat.DarkAttack,
                Stat.PhantomAttack,
            };


            if (Random.Next(Config.高级头盔攻击元素极品属性产生概率) == 0)
            {
                int value = Config.高级头盔产生攻击元素极品属性的大小;

                if (Random.Next(Config.高级头盔攻击元素加二极品属性的产生率) == 0)
                    value += Config.高级头盔产生攻击元素极品属性的大小;

                if (Random.Next(Config.高级头盔攻击元素加三极品属性的产生率) == 0)
                    value += Config.高级头盔产生攻击元素极品属性的大小;

                item.AddStat(Elements[Random.Next(Elements.Count)], value, StatSource.Added);

                if (Random.Next(Config.高级头盔攻击元素加四极品属性的产生率) == 0)
                    item.AddStat(Elements[Random.Next(Elements.Count)], Config.高级头盔产生攻击元素极品属性的大小, StatSource.Added);

                if (Random.Next(Config.高级头盔攻击元素加五极品属性的产生率) == 0)
                    item.AddStat(Elements[Random.Next(Elements.Count)], Config.高级头盔产生攻击元素极品属性的大小, StatSource.Added);

            }

        }

        public static void UpgradeSuperiorNecklace(UserItem item)
        {
            if (Random.Next(Config.高级项链攻击极品属性产生概率) == 0)
            {
                int value = Config.高级项链产生攻击极品属性的大小;

                if (Random.Next(Config.高级项链攻击加二极品属性的产生率) == 0)
                    value += Config.高级项链产生攻击极品属性的大小;

                if (Random.Next(Config.高级项链攻击加三极品属性的产生率) == 0)
                    value += Config.高级项链产生攻击极品属性的大小;

                if (Random.Next(Config.高级项链攻击加四极品属性的产生率) == 0)
                    value += Config.高级项链产生攻击极品属性的大小;

                if (Random.Next(Config.高级项链攻击加五极品属性的产生率) == 0)
                    value += Config.高级项链产生攻击极品属性的大小;

                item.AddStat(Stat.MaxDC, value, StatSource.Added);
            }


            if (Random.Next(Config.高级项链自然灵魂极品属性产生概率) == 0)
            {
                int value = Config.高级项链产生自然灵魂极品属性的大小;

                if (Random.Next(Config.高级项链自然灵魂加二极品属性的产生率) == 0)
                    value += Config.高级项链产生自然灵魂极品属性的大小;

                if (Random.Next(Config.高级项链自然灵魂加三极品属性的产生率) == 0)
                    value += Config.高级项链产生自然灵魂极品属性的大小;

                if (Random.Next(Config.高级项链自然灵魂加四极品属性的产生率) == 0)
                    value += Config.高级项链产生自然灵魂极品属性的大小;

                if (Random.Next(Config.高级项链自然灵魂加五极品属性的产生率) == 0)
                    value += Config.高级项链产生自然灵魂极品属性的大小;

         
                if (item.Info.Stats[Stat.MinMC] == 0 && item.Info.Stats[Stat.MaxMC] == 0 && item.Info.Stats[Stat.MinSC] == 0 && item.Info.Stats[Stat.MaxSC] == 0)
                {
                    item.AddStat(Stat.MaxMC, value, StatSource.Added);
                    item.AddStat(Stat.MaxSC, value, StatSource.Added);
                }


                if (item.Info.Stats[Stat.MinMC] > 0 || item.Info.Stats[Stat.MaxMC] > 0)
                    item.AddStat(Stat.MaxMC, value, StatSource.Added);

                if (item.Info.Stats[Stat.MinSC] > 0 || item.Info.Stats[Stat.MaxSC] > 0)
                    item.AddStat(Stat.MaxSC, value, StatSource.Added);
            }


            if (Random.Next(Config.高级项链准确极品属性产生概率) == 0)
            {
                int value = Config.高级项链产生准确极品属性的大小;

                if (Random.Next(Config.高级项链准确加二极品属性的产生率) == 0)
                    value += Config.高级项链产生准确极品属性的大小;

                if (Random.Next(Config.高级项链准确加三极品属性的产生率) == 0)
                    value += Config.高级项链产生准确极品属性的大小;

                if (Random.Next(Config.高级项链准确加四极品属性的产生率) == 0)
                    value += Config.高级项链产生准确极品属性的大小;

                if (Random.Next(Config.高级项链准确加五极品属性的产生率) == 0)
                    value += Config.高级项链产生准确极品属性的大小;


                item.AddStat(Stat.Accuracy, value, StatSource.Added);
            }


            if (Random.Next(Config.高级项链敏捷极品属性产生概率) == 0)
            {
                int value = Config.高级项链产生敏捷极品属性的大小;

                if (Random.Next(Config.高级项链敏捷加二极品属性的产生率) == 0)
                    value += Config.高级项链产生敏捷极品属性的大小;

                if (Random.Next(Config.高级项链敏捷加三极品属性的产生率) == 0)
                    value += Config.高级项链产生敏捷极品属性的大小;

                if (Random.Next(Config.高级项链敏捷加四极品属性的产生率) == 0)
                    value += Config.高级项链产生敏捷极品属性的大小;

                if (Random.Next(Config.高级项链敏捷加五极品属性的产生率) == 0)
                    value += Config.高级项链产生敏捷极品属性的大小;

                item.AddStat(Stat.Agility, value, StatSource.Added);
            }

            List<Stat> Elements = new List<Stat>
            {
                Stat.FireAttack, Stat.IceAttack, Stat.LightningAttack, Stat.WindAttack,
                Stat.HolyAttack, Stat.DarkAttack,
                Stat.PhantomAttack,
            };

            if (Random.Next(Config.高级项链攻击元素极品属性产生概率) == 0)
            {
                int value = Config.高级项链产生攻击元素极品属性的大小;

                if (Random.Next(Config.高级项链攻击元素加二极品属性的产生率) == 0)
                    value += Config.高级项链产生攻击元素极品属性的大小;

                if (Random.Next(Config.高级项链攻击元素加三极品属性的产生率) == 0)
                    value += Config.高级项链产生攻击元素极品属性的大小;

                item.AddStat(Elements[Random.Next(Elements.Count)], value, StatSource.Added);

                if (Random.Next(Config.高级项链攻击元素加四极品属性的产生率) == 0)
                    item.AddStat(Elements[Random.Next(Elements.Count)], Config.高级项链产生攻击元素极品属性的大小, StatSource.Added);

                if (Random.Next(Config.高级项链攻击元素加五极品属性的产生率) == 0)
                    item.AddStat(Elements[Random.Next(Elements.Count)], Config.高级项链产生攻击元素极品属性的大小, StatSource.Added);
            }

          
        }

        public static void UpgradeSuperiorBracelet(UserItem item)
        {
            if (Random.Next(Config.高级手镯防御极品属性产生概率) == 0)
            {
                int value = Config.高级手镯产生防御极品属性的大小;

                if (Random.Next(Config.高级手镯防御加二极品属性的产生率) == 0)
                    value += Config.高级手镯产生防御极品属性的大小;

                if (Random.Next(Config.高级手镯防御加三极品属性的产生率) == 0)
                    value += Config.高级手镯产生防御极品属性的大小;

                if (Random.Next(Config.高级手镯防御加四极品属性的产生率) == 0)
                    value += Config.高级手镯产生防御极品属性的大小;

                if (Random.Next(Config.高级手镯防御加五极品属性的产生率) == 0)
                    value += Config.高级手镯产生防御极品属性的大小;

                item.AddStat(Stat.MaxAC, value, StatSource.Added);
            }

            if (Random.Next(Config.高级手镯魔御极品属性产生概率) == 0)
            {
                int value = Config.高级手镯产生魔御极品属性的大小;

                if (Random.Next(Config.高级手镯魔御加二极品属性的产生率) == 0)
                    value += Config.高级手镯产生魔御极品属性的大小;

                if (Random.Next(Config.高级手镯魔御加三极品属性的产生率) == 0)
                    value += Config.高级手镯产生魔御极品属性的大小;

                if (Random.Next(Config.高级手镯魔御加四极品属性的产生率) == 0)
                    value += Config.高级手镯产生魔御极品属性的大小;

                if (Random.Next(Config.高级手镯魔御加五极品属性的产生率) == 0)
                    value += Config.高级手镯产生魔御极品属性的大小;

                item.AddStat(Stat.MaxMR, value, StatSource.Added);
            }


            if (Random.Next(Config.高级手镯攻击极品属性产生概率) == 0)
            {
                int value = Config.高级手镯产生攻击极品属性的大小;

                if (Random.Next(Config.高级手镯攻击加二极品属性的产生率) == 0)
                    value += Config.高级手镯产生攻击极品属性的大小;

                if (Random.Next(Config.高级手镯攻击加三极品属性的产生率) == 0)
                    value += Config.高级手镯产生攻击极品属性的大小;

                if (Random.Next(Config.高级手镯攻击加四极品属性的产生率) == 0)
                    value += Config.高级手镯产生攻击极品属性的大小;

                if (Random.Next(Config.高级手镯攻击加五极品属性的产生率) == 0)
                    value += Config.高级手镯产生攻击极品属性的大小;

                item.AddStat(Stat.MaxDC, value, StatSource.Added);
            }

            if (Random.Next(Config.高级手镯自然灵魂极品属性产生概率) == 0)
            {
                int value = Config.高级手镯产生自然灵魂极品属性的大小;

                if (Random.Next(Config.高级手镯自然灵魂加二极品属性的产生率) == 0)
                    value += Config.高级手镯产生自然灵魂极品属性的大小;

                if (Random.Next(Config.高级手镯自然灵魂加三极品属性的产生率) == 0)
                    value += Config.高级手镯产生自然灵魂极品属性的大小;

                if (Random.Next(Config.高级手镯自然灵魂加四极品属性的产生率) == 0)
                    value += Config.高级手镯产生自然灵魂极品属性的大小;

                if (Random.Next(Config.高级手镯自然灵魂加五极品属性的产生率) == 0)
                    value += Config.高级手镯产生自然灵魂极品属性的大小;

       
                if (item.Info.Stats[Stat.MinMC] == 0 && item.Info.Stats[Stat.MaxMC] == 0 && item.Info.Stats[Stat.MinSC] == 0 && item.Info.Stats[Stat.MaxSC] == 0)
                {
                    item.AddStat(Stat.MaxMC, value, StatSource.Added);
                    item.AddStat(Stat.MaxSC, value, StatSource.Added);
                }


                if (item.Info.Stats[Stat.MinMC] > 0 || item.Info.Stats[Stat.MaxMC] > 0)
                    item.AddStat(Stat.MaxMC, value, StatSource.Added);

                if (item.Info.Stats[Stat.MinSC] > 0 || item.Info.Stats[Stat.MaxSC] > 0)
                    item.AddStat(Stat.MaxSC, value, StatSource.Added);
            }

            if (Random.Next(Config.高级手镯准确极品属性产生概率) == 0)
            {
                int value = Config.高级手镯产生准确极品属性的大小;

                if (Random.Next(Config.高级手镯准确加二极品属性的产生率) == 0)
                    value += Config.高级手镯产生准确极品属性的大小;

                if (Random.Next(Config.高级手镯准确加三极品属性的产生率) == 0)
                    value += Config.高级手镯产生准确极品属性的大小;

                if (Random.Next(Config.高级手镯准确加四极品属性的产生率) == 0)
                    value += Config.高级手镯产生准确极品属性的大小;

                if (Random.Next(Config.高级手镯准确加五极品属性的产生率) == 0)
                    value += Config.高级手镯产生准确极品属性的大小;

                item.AddStat(Stat.Accuracy, value, StatSource.Added);
            }

            if (Random.Next(Config.高级手镯敏捷极品属性产生概率) == 0)
            {
                int value = Config.高级手镯产生敏捷极品属性的大小;

                if (Random.Next(Config.高级手镯敏捷加二极品属性的产生率) == 0)
                    value += Config.高级手镯产生敏捷极品属性的大小;

                if (Random.Next(Config.高级手镯敏捷加三极品属性的产生率) == 0)
                    value += Config.高级手镯产生敏捷极品属性的大小;

                if (Random.Next(Config.高级手镯敏捷加四极品属性的产生率) == 0)
                    value += Config.高级手镯产生敏捷极品属性的大小;

                if (Random.Next(Config.高级手镯敏捷加五极品属性的产生率) == 0)
                    value += Config.高级手镯产生敏捷极品属性的大小;

                item.AddStat(Stat.Agility, value, StatSource.Added);
            }


            List<Stat> Elements = new List<Stat>
            {
                Stat.FireResistance, Stat.IceResistance, Stat.LightningResistance, Stat.WindResistance,
                Stat.HolyResistance, Stat.DarkResistance,
                Stat.PhantomResistance, Stat.PhysicalResistance,
            };

            if (Random.Next(Config.高级手镯强元素极品属性产生概率) == 0)
            {
                Stat element = Elements[Random.Next(Elements.Count)];

                Elements.Remove(element);

                if (item.Stats[element] == 0)
                    item.AddStat(element, Config.高级手镯产生强元素属性的大小, StatSource.Added);

                if (Random.Next(Config.高级手镯弱元素第二属性的产生率) == 0)
                {
                    element = Elements[Random.Next(Elements.Count)];

                    Elements.Remove(element);

                    if (item.Stats[element] == 0)
                        item.AddStat(element, -Config.高级手镯产生强元素属性的大小, StatSource.Added);
                }

                if (Random.Next(Config.高级手镯强元素第三属性产生概率) == 0)
                {
                    element = Elements[Random.Next(Elements.Count)];

                    Elements.Remove(element);

                    if (item.Stats[element] == 0)
                        item.AddStat(element, Config.高级手镯产生强元素属性的大小, StatSource.Added);

                    if (Random.Next(Config.高级手镯弱元素第四属性的产生率) == 0)
                    {
                        element = Elements[Random.Next(Elements.Count)];

                        Elements.Remove(element);

                        if (item.Stats[element] == 0)
                            item.AddStat(element, -Config.高级手镯产生强元素属性的大小, StatSource.Added);
                    }

                    if (Random.Next(Config.高级手镯强元素第五属性产生概率) == 0)
                    {
                        element = Elements[Random.Next(Elements.Count)];

                        Elements.Remove(element);

                        if (item.Stats[element] == 0)
                            item.AddStat(element, Config.高级手镯产生强元素属性的大小, StatSource.Added);

                        if (Random.Next(Config.高级手镯弱元素第六属性产生概率) == 0)
                        {
                            element = Elements[Random.Next(Elements.Count)];

                            Elements.Remove(element);

                            if (item.Stats[element] == 0)
                                item.AddStat(element, -Config.高级手镯产生强元素属性的大小, StatSource.Added);
                        }

                    }
                    else if (Random.Next(Config.高级手镯弱元素第五属性产生概率) == 0)
                    {
                        element = Elements[Random.Next(Elements.Count)];

                        Elements.Remove(element);

                        if (item.Stats[element] == 0)
                            item.AddStat(element, -Config.高级手镯产生强元素属性的大小, StatSource.Added);
                    }
                }
                else if (Random.Next(Config.高级手镯弱元素第三属性产生概率) == 0)
                {
                    element = Elements[Random.Next(Elements.Count)];

                    Elements.Remove(element);

                    if (item.Stats[element] == 0)
                        item.AddStat(element, -Config.高级手镯产生强元素属性的大小, StatSource.Added);
                }
            }
            else if (Random.Next(Config.高级手镯弱元素极品属性产生概率) == 0)
            {
                Stat element = Elements[Random.Next(Elements.Count)];

                Elements.Remove(element);

                if (item.Stats[element] == 0)
                    item.AddStat(element, -Config.高级手镯产生强元素属性的大小, StatSource.Added);
            }


            Elements = new List<Stat>
            {
                Stat.FireAttack, Stat.IceAttack, Stat.LightningAttack, Stat.WindAttack,
                Stat.HolyAttack, Stat.DarkAttack,
                Stat.PhantomAttack,
            };

            if (Random.Next(Config.高级手镯攻击元素极品属性产生概率) == 0)
            {
                int value = Config.高级手镯产生攻击元素极品属性的大小;

                if (Random.Next(Config.高级手镯攻击元素加二极品属性的产生率) == 0)
                    value += Config.高级手镯产生攻击元素极品属性的大小;

                if (Random.Next(Config.高级手镯攻击元素加三极品属性的产生率) == 0)
                    value += Config.高级手镯产生攻击元素极品属性的大小;

                item.AddStat(Elements[Random.Next(Elements.Count)], value, StatSource.Added);

                if (Random.Next(Config.高级手镯攻击元素加四极品属性的产生率) == 0)
                    item.AddStat(Elements[Random.Next(Elements.Count)], Config.高级手镯产生攻击元素极品属性的大小, StatSource.Added);

                if (Random.Next(Config.高级手镯攻击元素加五极品属性的产生率) == 0)
                    item.AddStat(Elements[Random.Next(Elements.Count)], Config.高级手镯产生攻击元素极品属性的大小, StatSource.Added);
            }

         
        }

        public static void UpgradeSuperiorRing(UserItem item)
        {

            if (Random.Next(Config.高级戒指攻击极品属性产生概率) == 0)
            {
                int value = Config.高级戒指产生攻击极品属性的大小;

                if (Random.Next(Config.高级戒指攻击加二极品属性的产生率) == 0)
                    value += Config.高级戒指产生攻击极品属性的大小;

                if (Random.Next(Config.高级戒指攻击加三极品属性的产生率) == 0)
                    value += Config.高级戒指产生攻击极品属性的大小;

                if (Random.Next(Config.高级戒指攻击加四极品属性的产生率) == 0)
                    value += Config.高级戒指产生攻击极品属性的大小;

                if (Random.Next(Config.高级戒指攻击加五极品属性的产生率) == 0)
                    value += Config.高级戒指产生攻击极品属性的大小;

                item.AddStat(Stat.MaxDC, value, StatSource.Added);
            }

            if (Random.Next(Config.高级戒指自然灵魂极品属性产生概率) == 0)
            {
                int value = Config.高级戒指产生自然灵魂极品属性的大小;

                if (Random.Next(Config.高级戒指自然灵魂加二极品属性的产生率) == 0)
                    value += Config.高级戒指产生自然灵魂极品属性的大小;

                if (Random.Next(Config.高级戒指自然灵魂加三极品属性的产生率) == 0)
                    value += Config.高级戒指产生自然灵魂极品属性的大小;

                if (Random.Next(Config.高级戒指自然灵魂加四极品属性的产生率) == 0)
                    value += Config.高级戒指产生自然灵魂极品属性的大小;

                if (Random.Next(Config.高级戒指自然灵魂加五极品属性的产生率) == 0)
                    value += Config.高级戒指产生自然灵魂极品属性的大小;

        
                if (item.Info.Stats[Stat.MinMC] == 0 && item.Info.Stats[Stat.MaxMC] == 0 && item.Info.Stats[Stat.MinSC] == 0 && item.Info.Stats[Stat.MaxSC] == 0)
                {
                    item.AddStat(Stat.MaxMC, value, StatSource.Added);
                    item.AddStat(Stat.MaxSC, value, StatSource.Added);
                }


                if (item.Info.Stats[Stat.MinMC] > 0 || item.Info.Stats[Stat.MaxMC] > 0)
                    item.AddStat(Stat.MaxMC, value, StatSource.Added);

                if (item.Info.Stats[Stat.MinSC] > 0 || item.Info.Stats[Stat.MaxSC] > 0)
                    item.AddStat(Stat.MaxSC, value, StatSource.Added);
            }

            if (Random.Next(Config.高级戒指拾取范围极品属性产生概率) == 0)
            {
                int value = Config.高级戒指产生拾取范围极品属性的大小;

                if (Random.Next(Config.高级戒指拾取范围加二极品属性的产生率) == 0)
                    value += Config.高级戒指产生拾取范围极品属性的大小;

                if (Random.Next(Config.高级戒指拾取范围加三极品属性的产生率) == 0)
                    value += Config.高级戒指产生拾取范围极品属性的大小;

                if (Random.Next(Config.高级戒指拾取范围加四极品属性的产生率) == 0)
                    value += Config.高级戒指产生拾取范围极品属性的大小;

                if (Random.Next(Config.高级戒指拾取范围加五极品属性的产生率) == 0)
                    value += Config.高级戒指产生拾取范围极品属性的大小;

                item.AddStat(Stat.PickUpRadius, value, StatSource.Added);
            }

            List<Stat> Elements = new List<Stat>
            {
                Stat.FireAttack, Stat.IceAttack, Stat.LightningAttack, Stat.WindAttack,
                Stat.HolyAttack, Stat.DarkAttack,
                Stat.PhantomAttack,
            };

            if (Random.Next(Config.高级戒指攻击元素极品属性产生概率) == 0)
            {
                int value = Config.高级戒指产生攻击元素极品属性的大小;

                if (Random.Next(Config.高级戒指攻击元素加二极品属性的产生率) == 0)
                    value += Config.高级戒指产生攻击元素极品属性的大小;

                if (Random.Next(Config.高级戒指攻击元素加三极品属性的产生率) == 0)
                    value += Config.高级戒指产生攻击元素极品属性的大小;

                item.AddStat(Elements[Random.Next(Elements.Count)], value, StatSource.Added);

                if (Random.Next(Config.高级戒指攻击元素加四极品属性的产生率) == 0)
                    item.AddStat(Elements[Random.Next(Elements.Count)], Config.高级戒指产生攻击元素极品属性的大小, StatSource.Added);

                if (Random.Next(Config.高级戒指攻击元素加五极品属性的产生率) == 0)
                    item.AddStat(Elements[Random.Next(Elements.Count)], Config.高级戒指产生攻击元素极品属性的大小, StatSource.Added);
            }

           
        }
 
        public static void UpgradeSuperiorShoes(UserItem item)
        {
            if (Random.Next(Config.高级鞋子防御极品属性产生概率) == 0)
            {
                int value = Config.高级鞋子产生防御极品属性的大小;

                if (Random.Next(Config.高级鞋子防御加二极品属性的产生率) == 0)
                    value += Config.高级鞋子产生防御极品属性的大小;

                if (Random.Next(Config.高级鞋子防御加三极品属性的产生率) == 0)
                    value += Config.高级鞋子产生防御极品属性的大小;

                if (Random.Next(Config.高级鞋子防御加四极品属性的产生率) == 0)
                    value += Config.高级鞋子产生防御极品属性的大小;

                if (Random.Next(Config.高级鞋子防御加五极品属性的产生率) == 0)
                    value += Config.高级鞋子产生防御极品属性的大小;

                item.AddStat(Stat.MaxAC, value, StatSource.Added);
            }

            if (Random.Next(Config.高级鞋子魔御极品属性产生概率) == 0)
            {
                int value = Config.高级鞋子产生魔御极品属性的大小;

                if (Random.Next(Config.高级鞋子魔御加二极品属性的产生率) == 0)
                    value += Config.高级鞋子产生魔御极品属性的大小;

                if (Random.Next(Config.高级鞋子魔御加三极品属性的产生率) == 0)
                    value += Config.高级鞋子产生魔御极品属性的大小;

                if (Random.Next(Config.高级鞋子魔御加四极品属性的产生率) == 0)
                    value += Config.高级鞋子产生魔御极品属性的大小;

                if (Random.Next(Config.高级鞋子魔御加五极品属性的产生率) == 0)
                    value += Config.高级鞋子产生魔御极品属性的大小;

                item.AddStat(Stat.MaxMR, value, StatSource.Added);
            }

            if (Random.Next(Config.高级鞋子舒适极品属性产生概率) == 0)
            {
                int value = Config.高级鞋子产生舒适极品属性的大小;

                if (Random.Next(Config.高级鞋子舒适加二极品属性的产生率) == 0)
                    value += Config.高级鞋子产生舒适极品属性的大小;

                if (Random.Next(Config.高级鞋子舒适加三极品属性的产生率) == 0)
                    value += Config.高级鞋子产生舒适极品属性的大小;

                if (Random.Next(Config.高级鞋子舒适加四极品属性的产生率) == 0)
                    value += Config.高级鞋子产生舒适极品属性的大小;

                if (Random.Next(Config.高级鞋子舒适加五极品属性的产生率) == 0)
                    value += Config.高级鞋子产生舒适极品属性的大小;

                item.AddStat(Stat.Comfort, value, StatSource.Added);
            }


            List<Stat> Elements = new List<Stat>
            {
                Stat.FireResistance, Stat.IceResistance, Stat.LightningResistance, Stat.WindResistance,
                Stat.HolyResistance, Stat.DarkResistance,
                Stat.PhantomResistance, Stat.PhysicalResistance,
            };
            if (Random.Next(Config.高级鞋子强元素极品属性产生概率) == 0)
            {
                Stat element = Elements[Random.Next(Elements.Count)];

                Elements.Remove(element);

                if (item.Stats[element] == 0)
                    item.AddStat(element, Config.高级鞋子产生强元素属性的大小, StatSource.Added);

                if (Random.Next(Config.高级鞋子弱元素第二属性的产生率) == 0)
                {
                    element = Elements[Random.Next(Elements.Count)];

                    Elements.Remove(element);

                    if (item.Stats[element] == 0)
                        item.AddStat(element, -Config.高级鞋子产生强元素属性的大小, StatSource.Added);
                }

                if (Random.Next(Config.高级鞋子强元素第三属性产生概率) == 0)
                {
                    element = Elements[Random.Next(Elements.Count)];

                    Elements.Remove(element);

                    if (item.Stats[element] == 0)
                        item.AddStat(element, Config.高级鞋子产生强元素属性的大小, StatSource.Added);

                    if (Random.Next(Config.高级鞋子弱元素第四属性的产生率) == 0)
                    {
                        element = Elements[Random.Next(Elements.Count)];

                        Elements.Remove(element);

                        if (item.Stats[element] == 0)
                            item.AddStat(element, -Config.高级鞋子产生强元素属性的大小, StatSource.Added);
                    }

                    if (Random.Next(Config.高级鞋子强元素第五属性产生概率) == 0)
                    {
                        element = Elements[Random.Next(Elements.Count)];

                        Elements.Remove(element);

                        if (item.Stats[element] == 0)
                            item.AddStat(element, Config.高级鞋子产生强元素属性的大小, StatSource.Added);

                        if (Random.Next(Config.高级鞋子弱元素第六属性产生概率) == 0)
                        {
                            element = Elements[Random.Next(Elements.Count)];

                            Elements.Remove(element);

                            if (item.Stats[element] == 0)
                                item.AddStat(element, -Config.高级鞋子产生强元素属性的大小, StatSource.Added);
                        }

                    }
                    else if (Random.Next(Config.高级鞋子弱元素第五属性产生概率) == 0)
                    {
                        element = Elements[Random.Next(Elements.Count)];

                        Elements.Remove(element);

                        if (item.Stats[element] == 0)
                            item.AddStat(element, -Config.高级鞋子产生强元素属性的大小, StatSource.Added);
                    }
                }
                else if (Random.Next(Config.高级鞋子弱元素第三属性产生概率) == 0)
                {
                    element = Elements[Random.Next(Elements.Count)];

                    Elements.Remove(element);

                    if (item.Stats[element] == 0)
                        item.AddStat(element, -Config.高级鞋子产生强元素属性的大小, StatSource.Added);
                }
            }
            else if (Random.Next(Config.高级鞋子弱元素极品属性产生概率) == 0)
            {
                Stat element = Elements[Random.Next(Elements.Count)];

                Elements.Remove(element);

                if (item.Stats[element] == 0)
                    item.AddStat(element, -Config.高级鞋子产生强元素属性的大小, StatSource.Added);
            }
        }


        public static void UpgradeEliteWeapon(UserItem item)
        {
            if (Random.Next(Config.稀世武器攻击极品属性产生概率) == 0)
            {
                int value = Config.稀世武器产生攻击极品属性的大小;

                if (Random.Next(Config.稀世武器攻击加二极品属性的产生率) == 0)
                    value += Config.稀世武器产生攻击极品属性的大小;

                if (Random.Next(Config.稀世武器攻击加三极品属性的产生率) == 0)
                    value += Config.稀世武器产生攻击极品属性的大小;

                if (Random.Next(Config.稀世武器攻击加四极品属性的产生率) == 0)
                    value += Config.稀世武器产生攻击极品属性的大小;

                if (Random.Next(Config.稀世武器攻击加五极品属性的产生率) == 0)
                    value += Config.稀世武器产生攻击极品属性的大小;

                item.AddStat(Stat.MaxDC, value, StatSource.Added);
            }

            if (Random.Next(Config.稀世武器自然灵魂极品属性产生概率) == 0)
            {
                int value = Config.稀世武器产生自然灵魂极品属性的大小;

                if (Random.Next(Config.稀世武器自然灵魂加二极品属性的产生率) == 0)
                    value += Config.稀世武器产生自然灵魂极品属性的大小;

                if (Random.Next(Config.稀世武器自然灵魂加三极品属性的产生率) == 0)
                    value += Config.稀世武器产生自然灵魂极品属性的大小;

                if (Random.Next(Config.稀世武器自然灵魂加四极品属性的产生率) == 0)
                    value += Config.稀世武器产生自然灵魂极品属性的大小;

                if (Random.Next(Config.稀世武器自然灵魂加五极品属性的产生率) == 0)
                    value += Config.稀世武器产生自然灵魂极品属性的大小;

   
                if (item.Info.Stats[Stat.MinMC] == 0 && item.Info.Stats[Stat.MaxMC] == 0 && item.Info.Stats[Stat.MinSC] == 0 && item.Info.Stats[Stat.MaxSC] == 0)
                {
                    item.AddStat(Stat.MaxMC, value, StatSource.Added);
                    item.AddStat(Stat.MaxSC, value, StatSource.Added);
                }


                if (item.Info.Stats[Stat.MinMC] > 0 || item.Info.Stats[Stat.MaxMC] > 0)
                    item.AddStat(Stat.MaxMC, value, StatSource.Added);

                if (item.Info.Stats[Stat.MinSC] > 0 || item.Info.Stats[Stat.MaxSC] > 0)
                    item.AddStat(Stat.MaxSC, value, StatSource.Added);

            }

            if (Random.Next(Config.稀世武器准确极品属性产生概率) == 0)
            {
                int value = Config.稀世武器产生准确极品属性的大小;

                if (Random.Next(Config.稀世武器准确加二极品属性的产生率) == 0)
                    value += Config.稀世武器产生准确极品属性的大小;

                if (Random.Next(Config.稀世武器准确加三极品属性的产生率) == 0)
                    value += Config.稀世武器产生准确极品属性的大小;

                if (Random.Next(Config.稀世武器准确加四极品属性的产生率) == 0)
                    value += Config.稀世武器产生准确极品属性的大小;

                if (Random.Next(Config.稀世武器准确加五极品属性的产生率) == 0)
                    value += Config.稀世武器产生准确极品属性的大小;

                item.AddStat(Stat.Accuracy, value, StatSource.Added);
            }

            List<Stat> Elements = new List<Stat>
            {
                Stat.FireAttack, Stat.IceAttack, Stat.LightningAttack, Stat.WindAttack,
                Stat.HolyAttack, Stat.DarkAttack,
                Stat.PhantomAttack,
            };


            if (Random.Next(Config.稀世武器攻击元素极品属性产生概率) == 0)
            {
                int value = Config.稀世武器产生攻击元素极品属性的大小;

                if (Random.Next(Config.稀世武器攻击元素加二极品属性的产生率) == 0)
                    value += Config.稀世武器产生攻击元素极品属性的大小;

                if (Random.Next(Config.稀世武器攻击元素加三极品属性的产生率) == 0)
                    value += Config.稀世武器产生攻击元素极品属性的大小;

                if (Random.Next(Config.稀世武器攻击元素加四极品属性的产生率) == 0)
                    value += Config.稀世武器产生攻击元素极品属性的大小;

                if (Random.Next(Config.稀世武器攻击元素加五极品属性的产生率) == 0)
                    value += Config.稀世武器产生攻击元素极品属性的大小;

                item.AddStat(Elements[Random.Next(Elements.Count)], value, StatSource.Added);
            }
        }

        public static void UpgradeEliteShield(UserItem item)
        {
            if (Random.Next(Config.稀世盾牌攻击几率极品属性产生概率) == 0)
            {
                int value = Config.稀世盾牌产生攻击几率极品属性的大小;

                if (Random.Next(Config.稀世盾牌攻击几率加二极品属性的产生率) == 0)
                    value += Config.稀世盾牌产生攻击几率极品属性的大小;

                if (Random.Next(Config.稀世盾牌攻击几率加三极品属性的产生率) == 0)
                    value += Config.稀世盾牌产生攻击几率极品属性的大小;

                if (Random.Next(Config.稀世盾牌攻击几率加四极品属性的产生率) == 0)
                    value += Config.稀世盾牌产生攻击几率极品属性的大小;

                if (Random.Next(Config.稀世盾牌攻击几率加五极品属性的产生率) == 0)
                    value += Config.稀世盾牌产生攻击几率极品属性的大小;

                item.AddStat(Stat.DCPercent, value, StatSource.Added);
            }

            if (Random.Next(Config.稀世盾牌自然灵魂几率极品属性产生概率) == 0)
            {
                int value = Config.稀世盾牌产生自然灵魂几率极品属性的大小;

                if (Random.Next(Config.稀世盾牌自然灵魂几率加二极品属性的产生率) == 0)
                    value += Config.稀世盾牌产生自然灵魂几率极品属性的大小;

                if (Random.Next(Config.稀世盾牌自然灵魂几率加三极品属性的产生率) == 0)
                    value += Config.稀世盾牌产生自然灵魂几率极品属性的大小;

                if (Random.Next(Config.稀世盾牌自然灵魂几率加四极品属性的产生率) == 0)
                    value += Config.稀世盾牌产生自然灵魂几率极品属性的大小;

                if (Random.Next(Config.稀世盾牌自然灵魂几率加五极品属性的产生率) == 0)
                    value += Config.稀世盾牌产生自然灵魂几率极品属性的大小;

                item.AddStat(Stat.MCPercent, value, StatSource.Added);
                item.AddStat(Stat.SCPercent, value, StatSource.Added);

            }

            if (Random.Next(Config.稀世盾牌格挡几率极品属性产生概率) == 0)
            {
                int value = Config.稀世盾牌产生格挡几率极品属性的大小;

                if (Random.Next(Config.稀世盾牌格挡几率加二极品属性的产生率) == 0)
                    value += Config.稀世盾牌产生格挡几率极品属性的大小;

                if (Random.Next(Config.稀世盾牌格挡几率加三极品属性的产生率) == 0)
                    value += Config.稀世盾牌产生格挡几率极品属性的大小;

                if (Random.Next(Config.稀世盾牌格挡几率加四极品属性的产生率) == 0)
                    value += Config.稀世盾牌产生格挡几率极品属性的大小;

                if (Random.Next(Config.稀世盾牌格挡几率加五极品属性的产生率) == 0)
                    value += Config.稀世盾牌产生格挡几率极品属性的大小;

                item.AddStat(Stat.BlockChance, value, StatSource.Added);
            }

            if (Random.Next(Config.稀世盾牌闪避几率极品属性产生概率) == 0)
            {
                int value = Config.稀世盾牌产生闪避几率极品属性的大小;

                if (Random.Next(Config.稀世盾牌闪避几率加二极品属性的产生率) == 0)
                    value += Config.稀世盾牌产生闪避几率极品属性的大小;

                if (Random.Next(Config.稀世盾牌闪避几率加三极品属性的产生率) == 0)
                    value += Config.稀世盾牌产生闪避几率极品属性的大小;

                if (Random.Next(Config.稀世盾牌闪避几率加四极品属性的产生率) == 0)
                    value += Config.稀世盾牌产生闪避几率极品属性的大小;

                if (Random.Next(Config.稀世盾牌闪避几率加五极品属性的产生率) == 0)
                    value += Config.稀世盾牌产生闪避几率极品属性的大小;

                item.AddStat(Stat.EvasionChance, value, StatSource.Added);
            }

            if (Random.Next(Config.稀世盾牌毒系抵抗几率极品属性产生概率) == 0)
            {
                int value = Config.稀世盾牌产生毒系抵抗几率极品属性的大小;

                if (Random.Next(Config.稀世盾牌毒系抵抗几率加二极品属性的产生率) == 0)
                    value += Config.稀世盾牌产生毒系抵抗几率极品属性的大小;

                if (Random.Next(Config.稀世盾牌毒系抵抗几率加三极品属性的产生率) == 0)
                    value += Config.稀世盾牌产生毒系抵抗几率极品属性的大小;

                if (Random.Next(Config.稀世盾牌毒系抵抗几率加四极品属性的产生率) == 0)
                    value += Config.稀世盾牌产生毒系抵抗几率极品属性的大小;

                if (Random.Next(Config.稀世盾牌毒系抵抗几率加五极品属性的产生率) == 0)
                    value += Config.稀世盾牌产生毒系抵抗几率极品属性的大小;

                item.AddStat(Stat.PoisonResistance, value, StatSource.Added);
            }

            List<Stat> Elements = new List<Stat>
            {
                Stat.FireResistance, Stat.IceResistance, Stat.LightningResistance, Stat.WindResistance,
                Stat.HolyResistance, Stat.DarkResistance,
                Stat.PhantomResistance, Stat.PhysicalResistance,
            };

            if (Random.Next(Config.稀世盾牌强元素极品属性产生概率) == 0)
            {
                Stat element = Elements[Random.Next(Elements.Count)];

                Elements.Remove(element);

                if (item.Stats[element] == 0)
                    item.AddStat(element, Config.稀世盾牌产生强元素属性的大小, StatSource.Added);

                if (Random.Next(Config.稀世盾牌弱元素第二属性的产生率) == 0)
                {
                    element = Elements[Random.Next(Elements.Count)];

                    Elements.Remove(element);

                    if (item.Stats[element] == 0)
                        item.AddStat(element, -Config.稀世盾牌产生强元素属性的大小, StatSource.Added);
                }

                if (Random.Next(Config.稀世盾牌强元素第三属性产生概率) == 0)
                {
                    element = Elements[Random.Next(Elements.Count)];

                    Elements.Remove(element);

                    if (item.Stats[element] == 0)
                        item.AddStat(element, Config.稀世盾牌产生强元素属性的大小, StatSource.Added);

                    if (Random.Next(Config.稀世盾牌弱元素第四属性的产生率) == 0)
                    {
                        element = Elements[Random.Next(Elements.Count)];

                        Elements.Remove(element);

                        if (item.Stats[element] == 0)
                            item.AddStat(element, -Config.稀世盾牌产生强元素属性的大小, StatSource.Added);
                    }

                    if (Random.Next(Config.稀世盾牌强元素第五属性产生概率) == 0)
                    {
                        element = Elements[Random.Next(Elements.Count)];

                        Elements.Remove(element);

                        if (item.Stats[element] == 0)
                            item.AddStat(element, Config.稀世盾牌产生强元素属性的大小, StatSource.Added);

                        if (Random.Next(Config.稀世盾牌弱元素第六属性产生概率) == 0)
                        {
                            element = Elements[Random.Next(Elements.Count)];

                            Elements.Remove(element);

                            if (item.Stats[element] == 0)
                                item.AddStat(element, -Config.稀世盾牌产生强元素属性的大小, StatSource.Added);
                        }

                    }
                    else if (Random.Next(Config.稀世盾牌弱元素第五属性产生概率) == 0)
                    {
                        element = Elements[Random.Next(Elements.Count)];

                        Elements.Remove(element);

                        if (item.Stats[element] == 0)
                            item.AddStat(element, -Config.稀世盾牌产生强元素属性的大小, StatSource.Added);
                    }
                }
                else if (Random.Next(Config.稀世盾牌弱元素第三属性产生概率) == 0)
                {
                    element = Elements[Random.Next(Elements.Count)];

                    Elements.Remove(element);

                    if (item.Stats[element] == 0)
                        item.AddStat(element, -Config.稀世盾牌产生强元素属性的大小, StatSource.Added);
                }
            }
            else if (Random.Next(Config.稀世盾牌弱元素极品属性产生概率) == 0)
            {
                Stat element = Elements[Random.Next(Elements.Count)];

                Elements.Remove(element);

                if (item.Stats[element] == 0)
                    item.AddStat(element, -Config.稀世盾牌产生强元素属性的大小, StatSource.Added);
            }
        }

        public static void UpgradeEliteArmour(UserItem item)
        {
            if (Random.Next(Config.稀世衣服防御极品属性产生概率) == 0)
            {
                int value = Config.稀世衣服产生防御极品属性的大小;

                if (Random.Next(Config.稀世衣服防御加二极品属性的产生率) == 0)
                    value += Config.稀世衣服产生防御极品属性的大小;

                if (Random.Next(Config.稀世衣服防御加三极品属性的产生率) == 0)
                    value += Config.稀世衣服产生防御极品属性的大小;

                if (Random.Next(Config.稀世衣服防御加四极品属性的产生率) == 0)
                    value += Config.稀世衣服产生防御极品属性的大小;

                if (Random.Next(Config.稀世衣服防御加五极品属性的产生率) == 0)
                    value += Config.稀世衣服产生防御极品属性的大小;

                item.AddStat(Stat.MaxAC, value, StatSource.Added);
            }

            if (Random.Next(Config.稀世衣服魔御极品属性产生概率) == 0)
            {
                int value = Config.稀世衣服产生魔御极品属性的大小;

                if (Random.Next(Config.稀世衣服魔御加二极品属性的产生率) == 0)
                    value += Config.稀世衣服产生魔御极品属性的大小;

                if (Random.Next(Config.稀世衣服魔御加三极品属性的产生率) == 0)
                    value += Config.稀世衣服产生魔御极品属性的大小;

                if (Random.Next(Config.稀世衣服魔御加四极品属性的产生率) == 0)
                    value += Config.稀世衣服产生魔御极品属性的大小;

                if (Random.Next(Config.稀世衣服魔御加五极品属性的产生率) == 0)
                    value += Config.稀世衣服产生魔御极品属性的大小;

                item.AddStat(Stat.MaxMR, value, StatSource.Added);
            }

            List<Stat> Elements = new List<Stat>
            {
                Stat.FireResistance, Stat.IceResistance, Stat.LightningResistance, Stat.WindResistance,
                Stat.HolyResistance, Stat.DarkResistance,
                Stat.PhantomResistance, Stat.PhysicalResistance,
            };

            if (Random.Next(Config.稀世衣服强元素极品属性产生概率) == 0)
            {
                Stat element = Elements[Random.Next(Elements.Count)];

                Elements.Remove(element);

                if (item.Stats[element] == 0)
                    item.AddStat(element, Config.稀世衣服产生强元素属性的大小, StatSource.Added);

                if (Random.Next(Config.稀世衣服弱元素第二属性的产生率) == 0)
                {
                    element = Elements[Random.Next(Elements.Count)];

                    Elements.Remove(element);

                    if (item.Stats[element] == 0)
                        item.AddStat(element, -Config.稀世衣服产生强元素属性的大小, StatSource.Added);
                }

                if (Random.Next(Config.稀世衣服强元素第三属性产生概率) == 0)
                {
                    element = Elements[Random.Next(Elements.Count)];

                    Elements.Remove(element);

                    if (item.Stats[element] == 0)
                        item.AddStat(element, Config.稀世衣服产生强元素属性的大小, StatSource.Added);

                    if (Random.Next(Config.稀世衣服弱元素第四属性的产生率) == 0)
                    {
                        element = Elements[Random.Next(Elements.Count)];

                        Elements.Remove(element);

                        if (item.Stats[element] == 0)
                            item.AddStat(element, -Config.稀世衣服产生强元素属性的大小, StatSource.Added);
                    }

                    if (Random.Next(Config.稀世衣服强元素第五属性产生概率) == 0)
                    {
                        element = Elements[Random.Next(Elements.Count)];

                        Elements.Remove(element);

                        if (item.Stats[element] == 0)
                            item.AddStat(element, Config.稀世衣服产生强元素属性的大小, StatSource.Added);

                        if (Random.Next(Config.稀世衣服弱元素第六属性产生概率) == 0)
                        {
                            element = Elements[Random.Next(Elements.Count)];

                            Elements.Remove(element);

                            if (item.Stats[element] == 0)
                                item.AddStat(element, -Config.稀世衣服产生强元素属性的大小, StatSource.Added);
                        }

                    }
                    else if (Random.Next(Config.稀世衣服弱元素第五属性产生概率) == 0)
                    {
                        element = Elements[Random.Next(Elements.Count)];

                        Elements.Remove(element);

                        if (item.Stats[element] == 0)
                            item.AddStat(element, -Config.稀世衣服产生强元素属性的大小, StatSource.Added);
                    }
                }
                else if (Random.Next(Config.稀世衣服弱元素第三属性产生概率) == 0)
                {
                    element = Elements[Random.Next(Elements.Count)];

                    Elements.Remove(element);

                    if (item.Stats[element] == 0)
                        item.AddStat(element, -Config.稀世衣服产生强元素属性的大小, StatSource.Added);
                }
            }
            else if (Random.Next(Config.稀世衣服弱元素极品属性产生概率) == 0)
            {
                Stat element = Elements[Random.Next(Elements.Count)];

                Elements.Remove(element);

                if (item.Stats[element] == 0)
                    item.AddStat(element, -Config.稀世衣服产生强元素属性的大小, StatSource.Added);
            }
        }
     
        public static void UpgradeEliteHelmet(UserItem item)
        {
            if (Random.Next(Config.稀世头盔防御极品属性产生概率) == 0)
            {
                int value = Config.稀世头盔产生防御极品属性的大小;

                if (Random.Next(Config.稀世头盔防御加二极品属性的产生率) == 0)
                    value += Config.稀世头盔产生防御极品属性的大小;

                if (Random.Next(Config.稀世头盔防御加三极品属性的产生率) == 0)
                    value += Config.稀世头盔产生防御极品属性的大小;

                if (Random.Next(Config.稀世头盔防御加四极品属性的产生率) == 0)
                    value += Config.稀世头盔产生防御极品属性的大小;

                if (Random.Next(Config.稀世头盔防御加五极品属性的产生率) == 0)
                    value += Config.稀世头盔产生防御极品属性的大小;

                item.AddStat(Stat.MaxAC, value, StatSource.Added);
            }

            if (Random.Next(Config.稀世头盔魔御极品属性产生概率) == 0)
            {
                int value = Config.稀世头盔产生魔御极品属性的大小;

                if (Random.Next(Config.稀世头盔魔御加二极品属性的产生率) == 0)
                    value += Config.稀世头盔产生魔御极品属性的大小;

                if (Random.Next(Config.稀世头盔魔御加三极品属性的产生率) == 0)
                    value += Config.稀世头盔产生魔御极品属性的大小;

                if (Random.Next(Config.稀世头盔魔御加四极品属性的产生率) == 0)
                    value += Config.稀世头盔产生魔御极品属性的大小;

                if (Random.Next(Config.稀世头盔魔御加五极品属性的产生率) == 0)
                    value += Config.稀世头盔产生魔御极品属性的大小;

                item.AddStat(Stat.MaxMR, value, StatSource.Added);
            }


            List<Stat> Elements = new List<Stat>
            {
                Stat.FireResistance, Stat.IceResistance, Stat.LightningResistance, Stat.WindResistance,
                Stat.HolyResistance, Stat.DarkResistance,
                Stat.PhantomResistance, Stat.PhysicalResistance,
            };
            if (Random.Next(Config.稀世头盔强元素极品属性产生概率) == 0)
            {
                Stat element = Elements[Random.Next(Elements.Count)];

                Elements.Remove(element);

                if (item.Stats[element] == 0)
                    item.AddStat(element, Config.稀世头盔产生强元素属性的大小, StatSource.Added);

                if (Random.Next(Config.稀世头盔弱元素第二属性的产生率) == 0)
                {
                    element = Elements[Random.Next(Elements.Count)];

                    Elements.Remove(element);

                    if (item.Stats[element] == 0)
                        item.AddStat(element, -Config.稀世头盔产生强元素属性的大小, StatSource.Added);
                }

                if (Random.Next(Config.稀世头盔强元素第三属性产生概率) == 0)
                {
                    element = Elements[Random.Next(Elements.Count)];

                    Elements.Remove(element);

                    if (item.Stats[element] == 0)
                        item.AddStat(element, Config.稀世头盔产生强元素属性的大小, StatSource.Added);

                    if (Random.Next(Config.稀世头盔弱元素第四属性的产生率) == 0)
                    {
                        element = Elements[Random.Next(Elements.Count)];

                        Elements.Remove(element);

                        if (item.Stats[element] == 0)
                            item.AddStat(element, -Config.稀世头盔产生强元素属性的大小, StatSource.Added);
                    }

                    if (Random.Next(Config.稀世头盔强元素第五属性产生概率) == 0)
                    {
                        element = Elements[Random.Next(Elements.Count)];

                        Elements.Remove(element);

                        if (item.Stats[element] == 0)
                            item.AddStat(element, Config.稀世头盔产生强元素属性的大小, StatSource.Added);

                        if (Random.Next(Config.稀世头盔弱元素第六属性产生概率) == 0)
                        {
                            element = Elements[Random.Next(Elements.Count)];

                            Elements.Remove(element);

                            if (item.Stats[element] == 0)
                                item.AddStat(element, -Config.稀世头盔产生强元素属性的大小, StatSource.Added);
                        }

                    }
                    else if (Random.Next(Config.稀世头盔弱元素第五属性产生概率) == 0)
                    {
                        element = Elements[Random.Next(Elements.Count)];

                        Elements.Remove(element);

                        if (item.Stats[element] == 0)
                            item.AddStat(element, -Config.稀世头盔产生强元素属性的大小, StatSource.Added);
                    }
                }
                else if (Random.Next(Config.稀世头盔弱元素第三属性产生概率) == 0)
                {
                    element = Elements[Random.Next(Elements.Count)];

                    Elements.Remove(element);

                    if (item.Stats[element] == 0)
                        item.AddStat(element, -Config.稀世头盔产生强元素属性的大小, StatSource.Added);
                }
            }
            else if (Random.Next(Config.稀世头盔弱元素极品属性产生概率) == 0)
            {
                Stat element = Elements[Random.Next(Elements.Count)];

                Elements.Remove(element);

                if (item.Stats[element] == 0)
                    item.AddStat(element, -Config.稀世头盔产生强元素属性的大小, StatSource.Added);
            }


            Elements = new List<Stat>
            {
                Stat.FireAttack, Stat.IceAttack, Stat.LightningAttack, Stat.WindAttack,
                Stat.HolyAttack, Stat.DarkAttack,
                Stat.PhantomAttack,
            };

            if (Random.Next(Config.稀世头盔攻击元素极品属性产生概率) == 0)
            {
                int value = Config.稀世头盔产生攻击元素极品属性的大小;

                if (Random.Next(Config.稀世头盔攻击元素加二极品属性的产生率) == 0)
                    value += Config.稀世头盔产生攻击元素极品属性的大小;

                if (Random.Next(Config.稀世头盔攻击元素加三极品属性的产生率) == 0)
                    value += Config.稀世头盔产生攻击元素极品属性的大小;

                item.AddStat(Elements[Random.Next(Elements.Count)], value, StatSource.Added);

                if (Random.Next(Config.稀世头盔攻击元素加四极品属性的产生率) == 0)
                    item.AddStat(Elements[Random.Next(Elements.Count)], Config.稀世头盔产生攻击元素极品属性的大小, StatSource.Added);

                if (Random.Next(Config.稀世头盔攻击元素加五极品属性的产生率) == 0)
                    item.AddStat(Elements[Random.Next(Elements.Count)], Config.稀世头盔产生攻击元素极品属性的大小, StatSource.Added);
            }

          
        }

        public static void UpgradeEliteNecklace(UserItem item)
        {
            if (Random.Next(Config.稀世项链攻击极品属性产生概率) == 0)
            {
                int value = Config.稀世项链产生攻击极品属性的大小;

                if (Random.Next(Config.稀世项链攻击加二极品属性的产生率) == 0)
                    value += Config.稀世项链产生攻击极品属性的大小;

                if (Random.Next(Config.稀世项链攻击加三极品属性的产生率) == 0)
                    value += Config.稀世项链产生攻击极品属性的大小;

                if (Random.Next(Config.稀世项链攻击加四极品属性的产生率) == 0)
                    value += Config.稀世项链产生攻击极品属性的大小;

                if (Random.Next(Config.稀世项链攻击加五极品属性的产生率) == 0)
                    value += Config.稀世项链产生攻击极品属性的大小;

                item.AddStat(Stat.MaxDC, value, StatSource.Added);
            }


            if (Random.Next(Config.稀世项链自然灵魂极品属性产生概率) == 0)
            {
                int value = Config.稀世项链产生自然灵魂极品属性的大小;

                if (Random.Next(Config.稀世项链自然灵魂加二极品属性的产生率) == 0)
                    value += Config.稀世项链产生自然灵魂极品属性的大小;

                if (Random.Next(Config.稀世项链自然灵魂加三极品属性的产生率) == 0)
                    value += Config.稀世项链产生自然灵魂极品属性的大小;

                if (Random.Next(Config.稀世项链自然灵魂加四极品属性的产生率) == 0)
                    value += Config.稀世项链产生自然灵魂极品属性的大小;

                if (Random.Next(Config.稀世项链自然灵魂加五极品属性的产生率) == 0)
                    value += Config.稀世项链产生自然灵魂极品属性的大小;

  
                if (item.Info.Stats[Stat.MinMC] == 0 && item.Info.Stats[Stat.MaxMC] == 0 && item.Info.Stats[Stat.MinSC] == 0 && item.Info.Stats[Stat.MaxSC] == 0)
                {
                    item.AddStat(Stat.MaxMC, value, StatSource.Added);
                    item.AddStat(Stat.MaxSC, value, StatSource.Added);
                }


                if (item.Info.Stats[Stat.MinMC] > 0 || item.Info.Stats[Stat.MaxMC] > 0)
                    item.AddStat(Stat.MaxMC, value, StatSource.Added);

                if (item.Info.Stats[Stat.MinSC] > 0 || item.Info.Stats[Stat.MaxSC] > 0)
                    item.AddStat(Stat.MaxSC, value, StatSource.Added);
            }


            if (Random.Next(Config.稀世项链准确极品属性产生概率) == 0)
            {
                int value = Config.稀世项链产生准确极品属性的大小;

                if (Random.Next(Config.稀世项链准确加二极品属性的产生率) == 0)
                    value += Config.稀世项链产生准确极品属性的大小;

                if (Random.Next(Config.稀世项链准确加三极品属性的产生率) == 0)
                    value += Config.稀世项链产生准确极品属性的大小;

                if (Random.Next(Config.稀世项链准确加四极品属性的产生率) == 0)
                    value += Config.稀世项链产生准确极品属性的大小;

                if (Random.Next(Config.稀世项链准确加五极品属性的产生率) == 0)
                    value += Config.稀世项链产生准确极品属性的大小;


                item.AddStat(Stat.Accuracy, value, StatSource.Added);
            }


            if (Random.Next(Config.稀世项链敏捷极品属性产生概率) == 0)
            {
                int value = Config.稀世项链产生敏捷极品属性的大小;

                if (Random.Next(Config.稀世项链敏捷加二极品属性的产生率) == 0)
                    value += Config.稀世项链产生敏捷极品属性的大小;

                if (Random.Next(Config.稀世项链敏捷加三极品属性的产生率) == 0)
                    value += Config.稀世项链产生敏捷极品属性的大小;

                if (Random.Next(Config.稀世项链敏捷加四极品属性的产生率) == 0)
                    value += Config.稀世项链产生敏捷极品属性的大小;

                if (Random.Next(Config.稀世项链敏捷加五极品属性的产生率) == 0)
                    value += Config.稀世项链产生敏捷极品属性的大小;

                item.AddStat(Stat.Agility, value, StatSource.Added);
            }

            List<Stat> Elements = new List<Stat>
            {
                Stat.FireAttack, Stat.IceAttack, Stat.LightningAttack, Stat.WindAttack,
                Stat.HolyAttack, Stat.DarkAttack,
                Stat.PhantomAttack,
            };

            if (Random.Next(Config.稀世项链攻击元素极品属性产生概率) == 0)
            {
                int value = Config.稀世项链产生攻击元素极品属性的大小;

                if (Random.Next(Config.稀世项链攻击元素加二极品属性的产生率) == 0)
                    value += Config.稀世项链产生攻击元素极品属性的大小;

                if (Random.Next(Config.稀世项链攻击元素加三极品属性的产生率) == 0)
                    value += Config.稀世项链产生攻击元素极品属性的大小;

                item.AddStat(Elements[Random.Next(Elements.Count)], value, StatSource.Added);

                if (Random.Next(Config.稀世项链攻击元素加四极品属性的产生率) == 0)
                    item.AddStat(Elements[Random.Next(Elements.Count)], Config.稀世项链产生攻击元素极品属性的大小, StatSource.Added);

                if (Random.Next(Config.稀世项链攻击元素加五极品属性的产生率) == 0)
                    item.AddStat(Elements[Random.Next(Elements.Count)], Config.稀世项链产生攻击元素极品属性的大小, StatSource.Added);
            }

         
        }

        public static void UpgradeEliteBracelet(UserItem item)
        {
            if (Random.Next(Config.稀世手镯防御极品属性产生概率) == 0)
            {
                int value = Config.稀世手镯产生防御极品属性的大小;

                if (Random.Next(Config.稀世手镯防御加二极品属性的产生率) == 0)
                    value += Config.稀世手镯产生防御极品属性的大小;

                if (Random.Next(Config.稀世手镯防御加三极品属性的产生率) == 0)
                    value += Config.稀世手镯产生防御极品属性的大小;

                if (Random.Next(Config.稀世手镯防御加四极品属性的产生率) == 0)
                    value += Config.稀世手镯产生防御极品属性的大小;

                if (Random.Next(Config.稀世手镯防御加五极品属性的产生率) == 0)
                    value += Config.稀世手镯产生防御极品属性的大小;

                item.AddStat(Stat.MaxAC, value, StatSource.Added);
            }

            if (Random.Next(Config.稀世手镯魔御极品属性产生概率) == 0)
            {
                int value = Config.稀世手镯产生魔御极品属性的大小;

                if (Random.Next(Config.稀世手镯魔御加二极品属性的产生率) == 0)
                    value += Config.稀世手镯产生魔御极品属性的大小;

                if (Random.Next(Config.稀世手镯魔御加三极品属性的产生率) == 0)
                    value += Config.稀世手镯产生魔御极品属性的大小;

                if (Random.Next(Config.稀世手镯魔御加四极品属性的产生率) == 0)
                    value += Config.稀世手镯产生魔御极品属性的大小;

                if (Random.Next(Config.稀世手镯魔御加五极品属性的产生率) == 0)
                    value += Config.稀世手镯产生魔御极品属性的大小;

                item.AddStat(Stat.MaxMR, value, StatSource.Added);
            }


            if (Random.Next(Config.稀世手镯攻击极品属性产生概率) == 0)
            {
                int value = Config.稀世手镯产生攻击极品属性的大小;

                if (Random.Next(Config.稀世手镯攻击加二极品属性的产生率) == 0)
                    value += Config.稀世手镯产生攻击极品属性的大小;

                if (Random.Next(Config.稀世手镯攻击加三极品属性的产生率) == 0)
                    value += Config.稀世手镯产生攻击极品属性的大小;

                if (Random.Next(Config.稀世手镯攻击加四极品属性的产生率) == 0)
                    value += Config.稀世手镯产生攻击极品属性的大小;

                if (Random.Next(Config.稀世手镯攻击加五极品属性的产生率) == 0)
                    value += Config.稀世手镯产生攻击极品属性的大小;

                item.AddStat(Stat.MaxDC, value, StatSource.Added);
            }

            if (Random.Next(Config.稀世手镯自然灵魂极品属性产生概率) == 0)
            {
                int value = Config.稀世手镯产生自然灵魂极品属性的大小;

                if (Random.Next(Config.稀世手镯自然灵魂加二极品属性的产生率) == 0)
                    value += Config.稀世手镯产生自然灵魂极品属性的大小;

                if (Random.Next(Config.稀世手镯自然灵魂加三极品属性的产生率) == 0)
                    value += Config.稀世手镯产生自然灵魂极品属性的大小;

                if (Random.Next(Config.稀世手镯自然灵魂加四极品属性的产生率) == 0)
                    value += Config.稀世手镯产生自然灵魂极品属性的大小;

                if (Random.Next(Config.稀世手镯自然灵魂加五极品属性的产生率) == 0)
                    value += Config.稀世手镯产生自然灵魂极品属性的大小;

     
                if (item.Info.Stats[Stat.MinMC] == 0 && item.Info.Stats[Stat.MaxMC] == 0 && item.Info.Stats[Stat.MinSC] == 0 && item.Info.Stats[Stat.MaxSC] == 0)
                {
                    item.AddStat(Stat.MaxMC, value, StatSource.Added);
                    item.AddStat(Stat.MaxSC, value, StatSource.Added);
                }


                if (item.Info.Stats[Stat.MinMC] > 0 || item.Info.Stats[Stat.MaxMC] > 0)
                    item.AddStat(Stat.MaxMC, value, StatSource.Added);

                if (item.Info.Stats[Stat.MinSC] > 0 || item.Info.Stats[Stat.MaxSC] > 0)
                    item.AddStat(Stat.MaxSC, value, StatSource.Added);
            }

            if (Random.Next(Config.稀世手镯准确极品属性产生概率) == 0)
            {
                int value = Config.稀世手镯产生准确极品属性的大小;

                if (Random.Next(Config.稀世手镯准确加二极品属性的产生率) == 0)
                    value += Config.稀世手镯产生准确极品属性的大小;

                if (Random.Next(Config.稀世手镯准确加三极品属性的产生率) == 0)
                    value += Config.稀世手镯产生准确极品属性的大小;

                if (Random.Next(Config.稀世手镯准确加四极品属性的产生率) == 0)
                    value += Config.稀世手镯产生准确极品属性的大小;

                if (Random.Next(Config.稀世手镯准确加五极品属性的产生率) == 0)
                    value += Config.稀世手镯产生准确极品属性的大小;

                item.AddStat(Stat.Accuracy, value, StatSource.Added);
            }

            if (Random.Next(Config.稀世手镯敏捷极品属性产生概率) == 0)
            {
                int value = Config.稀世手镯产生敏捷极品属性的大小;

                if (Random.Next(Config.稀世手镯敏捷加二极品属性的产生率) == 0)
                    value += Config.稀世手镯产生敏捷极品属性的大小;

                if (Random.Next(Config.稀世手镯敏捷加三极品属性的产生率) == 0)
                    value += Config.稀世手镯产生敏捷极品属性的大小;

                if (Random.Next(Config.稀世手镯敏捷加四极品属性的产生率) == 0)
                    value += Config.稀世手镯产生敏捷极品属性的大小;

                if (Random.Next(Config.稀世手镯敏捷加五极品属性的产生率) == 0)
                    value += Config.稀世手镯产生敏捷极品属性的大小;

                item.AddStat(Stat.Agility, value, StatSource.Added);
            }


            List<Stat> Elements = new List<Stat>
            {
                Stat.FireResistance, Stat.IceResistance, Stat.LightningResistance, Stat.WindResistance,
                Stat.HolyResistance, Stat.DarkResistance,
                Stat.PhantomResistance, Stat.PhysicalResistance,
            };

            if (Random.Next(Config.稀世手镯强元素极品属性产生概率) == 0)
            {
                Stat element = Elements[Random.Next(Elements.Count)];

                Elements.Remove(element);

                if (item.Stats[element] == 0)
                    item.AddStat(element, Config.稀世手镯产生强元素属性的大小, StatSource.Added);

                if (Random.Next(Config.稀世手镯弱元素第二属性的产生率) == 0)
                {
                    element = Elements[Random.Next(Elements.Count)];

                    Elements.Remove(element);

                    if (item.Stats[element] == 0)
                        item.AddStat(element, -Config.稀世手镯产生强元素属性的大小, StatSource.Added);
                }

                if (Random.Next(Config.稀世手镯强元素第三属性产生概率) == 0)
                {
                    element = Elements[Random.Next(Elements.Count)];

                    Elements.Remove(element);

                    if (item.Stats[element] == 0)
                        item.AddStat(element, Config.稀世手镯产生强元素属性的大小, StatSource.Added);

                    if (Random.Next(Config.稀世手镯弱元素第四属性的产生率) == 0)
                    {
                        element = Elements[Random.Next(Elements.Count)];

                        Elements.Remove(element);

                        if (item.Stats[element] == 0)
                            item.AddStat(element, -Config.稀世手镯产生强元素属性的大小, StatSource.Added);
                    }

                    if (Random.Next(Config.稀世手镯强元素第五属性产生概率) == 0)
                    {
                        element = Elements[Random.Next(Elements.Count)];

                        Elements.Remove(element);

                        if (item.Stats[element] == 0)
                            item.AddStat(element, Config.稀世手镯产生强元素属性的大小, StatSource.Added);

                        if (Random.Next(Config.稀世手镯弱元素第六属性产生概率) == 0)
                        {
                            element = Elements[Random.Next(Elements.Count)];

                            Elements.Remove(element);

                            if (item.Stats[element] == 0)
                                item.AddStat(element, -Config.稀世手镯产生强元素属性的大小, StatSource.Added);
                        }

                    }
                    else if (Random.Next(Config.稀世手镯弱元素第五属性产生概率) == 0)
                    {
                        element = Elements[Random.Next(Elements.Count)];

                        Elements.Remove(element);

                        if (item.Stats[element] == 0)
                            item.AddStat(element, -Config.稀世手镯产生强元素属性的大小, StatSource.Added);
                    }
                }
                else if (Random.Next(Config.稀世手镯弱元素第三属性产生概率) == 0)
                {
                    element = Elements[Random.Next(Elements.Count)];

                    Elements.Remove(element);

                    if (item.Stats[element] == 0)
                        item.AddStat(element, -Config.稀世手镯产生强元素属性的大小, StatSource.Added);
                }
            }
            else if (Random.Next(Config.稀世手镯弱元素极品属性产生概率) == 0)
            {
                Stat element = Elements[Random.Next(Elements.Count)];

                Elements.Remove(element);

                if (item.Stats[element] == 0)
                    item.AddStat(element, -Config.稀世手镯产生强元素属性的大小, StatSource.Added);
            }

            Elements = new List<Stat>
            {
                Stat.FireAttack, Stat.IceAttack, Stat.LightningAttack, Stat.WindAttack,
                Stat.HolyAttack, Stat.DarkAttack,
                Stat.PhantomAttack,
            };

            if (Random.Next(Config.稀世手镯攻击元素极品属性产生概率) == 0)
            {
                int value = Config.稀世手镯产生攻击元素极品属性的大小;

                if (Random.Next(Config.稀世手镯攻击元素加二极品属性的产生率) == 0)
                    value += Config.稀世手镯产生攻击元素极品属性的大小;

                if (Random.Next(Config.稀世手镯攻击元素加三极品属性的产生率) == 0)
                    value += Config.稀世手镯产生攻击元素极品属性的大小;

                item.AddStat(Elements[Random.Next(Elements.Count)], value, StatSource.Added);

                if (Random.Next(Config.稀世手镯攻击元素加四极品属性的产生率) == 0)
                    item.AddStat(Elements[Random.Next(Elements.Count)], Config.稀世手镯产生攻击元素极品属性的大小, StatSource.Added);

                if (Random.Next(Config.稀世手镯攻击元素加五极品属性的产生率) == 0)
                    item.AddStat(Elements[Random.Next(Elements.Count)], Config.稀世手镯产生攻击元素极品属性的大小, StatSource.Added);

            }

          
        }
  
        public static void UpgradeEliteRing(UserItem item)
        {

            if (Random.Next(Config.稀世戒指攻击极品属性产生概率) == 0)
            {
                int value = Config.稀世戒指产生攻击极品属性的大小;

                if (Random.Next(Config.稀世戒指攻击加二极品属性的产生率) == 0)
                    value += Config.稀世戒指产生攻击极品属性的大小;

                if (Random.Next(Config.稀世戒指攻击加三极品属性的产生率) == 0)
                    value += Config.稀世戒指产生攻击极品属性的大小;

                if (Random.Next(Config.稀世戒指攻击加四极品属性的产生率) == 0)
                    value += Config.稀世戒指产生攻击极品属性的大小;

                if (Random.Next(Config.稀世戒指攻击加五极品属性的产生率) == 0)
                    value += Config.稀世戒指产生攻击极品属性的大小;

                item.AddStat(Stat.MaxDC, value, StatSource.Added);
            }

            if (Random.Next(Config.稀世戒指自然灵魂极品属性产生概率) == 0)
            {
                int value = Config.稀世戒指产生自然灵魂极品属性的大小;

                if (Random.Next(Config.稀世戒指自然灵魂加二极品属性的产生率) == 0)
                    value += Config.稀世戒指产生自然灵魂极品属性的大小;

                if (Random.Next(Config.稀世戒指自然灵魂加三极品属性的产生率) == 0)
                    value += Config.稀世戒指产生自然灵魂极品属性的大小;

                if (Random.Next(Config.稀世戒指自然灵魂加四极品属性的产生率) == 0)
                    value += Config.稀世戒指产生自然灵魂极品属性的大小;

                if (Random.Next(Config.稀世戒指自然灵魂加五极品属性的产生率) == 0)
                    value += Config.稀世戒指产生自然灵魂极品属性的大小;

    
                if (item.Info.Stats[Stat.MinMC] == 0 && item.Info.Stats[Stat.MaxMC] == 0 && item.Info.Stats[Stat.MinSC] == 0 && item.Info.Stats[Stat.MaxSC] == 0)
                {
                    item.AddStat(Stat.MaxMC, value, StatSource.Added);
                    item.AddStat(Stat.MaxSC, value, StatSource.Added);
                }


                if (item.Info.Stats[Stat.MinMC] > 0 || item.Info.Stats[Stat.MaxMC] > 0)
                    item.AddStat(Stat.MaxMC, value, StatSource.Added);

                if (item.Info.Stats[Stat.MinSC] > 0 || item.Info.Stats[Stat.MaxSC] > 0)
                    item.AddStat(Stat.MaxSC, value, StatSource.Added);
            }

            if (Random.Next(Config.稀世戒指拾取范围极品属性产生概率) == 0)
            {
                int value = Config.稀世戒指产生拾取范围极品属性的大小;

                if (Random.Next(Config.稀世戒指拾取范围加二极品属性的产生率) == 0)
                    value += Config.稀世戒指产生拾取范围极品属性的大小;

                if (Random.Next(Config.稀世戒指拾取范围加三极品属性的产生率) == 0)
                    value += Config.稀世戒指产生拾取范围极品属性的大小;

                if (Random.Next(Config.稀世戒指拾取范围加四极品属性的产生率) == 0)
                    value += Config.稀世戒指产生拾取范围极品属性的大小;

                if (Random.Next(Config.稀世戒指拾取范围加五极品属性的产生率) == 0)
                    value += Config.稀世戒指产生拾取范围极品属性的大小;

                item.AddStat(Stat.PickUpRadius, value, StatSource.Added);
            }

            List<Stat> Elements = new List<Stat>
            {
                Stat.FireAttack, Stat.IceAttack, Stat.LightningAttack, Stat.WindAttack,
                Stat.HolyAttack, Stat.DarkAttack,
                Stat.PhantomAttack,
            };

            if (Random.Next(Config.稀世戒指攻击元素极品属性产生概率) == 0)
            {
                int value = Config.稀世戒指产生攻击元素极品属性的大小;

                if (Random.Next(Config.稀世戒指攻击元素加二极品属性的产生率) == 0)
                    value += Config.稀世戒指产生攻击元素极品属性的大小;

                if (Random.Next(Config.稀世戒指攻击元素加三极品属性的产生率) == 0)
                    value += Config.稀世戒指产生攻击元素极品属性的大小;

                item.AddStat(Elements[Random.Next(Elements.Count)], value, StatSource.Added);

                if (Random.Next(Config.稀世戒指攻击元素加四极品属性的产生率) == 0)
                    item.AddStat(Elements[Random.Next(Elements.Count)], Config.稀世戒指产生攻击元素极品属性的大小, StatSource.Added);

                if (Random.Next(Config.稀世戒指攻击元素加五极品属性的产生率) == 0)
                    item.AddStat(Elements[Random.Next(Elements.Count)], Config.稀世戒指产生攻击元素极品属性的大小, StatSource.Added);
            }

          
        }
   
        public static void UpgradeEliteShoes(UserItem item)
        {
            if (Random.Next(Config.稀世鞋子防御极品属性产生概率) == 0)
            {
                int value = Config.稀世鞋子产生防御极品属性的大小;

                if (Random.Next(Config.稀世鞋子防御加二极品属性的产生率) == 0)
                    value += Config.稀世鞋子产生防御极品属性的大小;

                if (Random.Next(Config.稀世鞋子防御加三极品属性的产生率) == 0)
                    value += Config.稀世鞋子产生防御极品属性的大小;

                if (Random.Next(Config.稀世鞋子防御加四极品属性的产生率) == 0)
                    value += Config.稀世鞋子产生防御极品属性的大小;

                if (Random.Next(Config.稀世鞋子防御加五极品属性的产生率) == 0)
                    value += Config.稀世鞋子产生防御极品属性的大小;

                item.AddStat(Stat.MaxAC, value, StatSource.Added);
            }

            if (Random.Next(Config.稀世鞋子魔御极品属性产生概率) == 0)
            {
                int value = Config.稀世鞋子产生魔御极品属性的大小;

                if (Random.Next(Config.稀世鞋子魔御加二极品属性的产生率) == 0)
                    value += Config.稀世鞋子产生魔御极品属性的大小;

                if (Random.Next(Config.稀世鞋子魔御加三极品属性的产生率) == 0)
                    value += Config.稀世鞋子产生魔御极品属性的大小;

                if (Random.Next(Config.稀世鞋子魔御加四极品属性的产生率) == 0)
                    value += Config.稀世鞋子产生魔御极品属性的大小;

                if (Random.Next(Config.稀世鞋子魔御加五极品属性的产生率) == 0)
                    value += Config.稀世鞋子产生魔御极品属性的大小;

                item.AddStat(Stat.MaxMR, value, StatSource.Added);
            }

            if (Random.Next(Config.稀世鞋子舒适极品属性产生概率) == 0)
            {
                int value = Config.稀世鞋子产生舒适极品属性的大小;

                if (Random.Next(Config.稀世鞋子舒适加二极品属性的产生率) == 0)
                    value += Config.稀世鞋子产生舒适极品属性的大小;

                if (Random.Next(Config.稀世鞋子舒适加三极品属性的产生率) == 0)
                    value += Config.稀世鞋子产生舒适极品属性的大小;

                if (Random.Next(Config.稀世鞋子舒适加四极品属性的产生率) == 0)
                    value += Config.稀世鞋子产生舒适极品属性的大小;

                if (Random.Next(Config.稀世鞋子舒适加五极品属性的产生率) == 0)
                    value += Config.稀世鞋子产生舒适极品属性的大小;

                item.AddStat(Stat.Comfort, value, StatSource.Added);
            }


            List<Stat> Elements = new List<Stat>
            {
                Stat.FireResistance, Stat.IceResistance, Stat.LightningResistance, Stat.WindResistance,
                Stat.HolyResistance, Stat.DarkResistance,
                Stat.PhantomResistance, Stat.PhysicalResistance,
            };
            if (Random.Next(Config.稀世鞋子强元素极品属性产生概率) == 0)
            {
                Stat element = Elements[Random.Next(Elements.Count)];

                Elements.Remove(element);

                if (item.Stats[element] == 0)
                    item.AddStat(element, Config.稀世鞋子产生强元素属性的大小, StatSource.Added);

                if (Random.Next(Config.稀世鞋子弱元素第二属性的产生率) == 0)
                {
                    element = Elements[Random.Next(Elements.Count)];

                    Elements.Remove(element);

                    if (item.Stats[element] == 0)
                        item.AddStat(element, -Config.稀世鞋子产生强元素属性的大小, StatSource.Added);
                }

                if (Random.Next(Config.稀世鞋子强元素第三属性产生概率) == 0)
                {
                    element = Elements[Random.Next(Elements.Count)];

                    Elements.Remove(element);

                    if (item.Stats[element] == 0)
                        item.AddStat(element, Config.稀世鞋子产生强元素属性的大小, StatSource.Added);

                    if (Random.Next(Config.稀世鞋子弱元素第四属性的产生率) == 0)
                    {
                        element = Elements[Random.Next(Elements.Count)];

                        Elements.Remove(element);

                        if (item.Stats[element] == 0)
                            item.AddStat(element, -Config.稀世鞋子产生强元素属性的大小, StatSource.Added);
                    }

                    if (Random.Next(Config.稀世鞋子强元素第五属性产生概率) == 0)
                    {
                        element = Elements[Random.Next(Elements.Count)];

                        Elements.Remove(element);

                        if (item.Stats[element] == 0)
                            item.AddStat(element, Config.稀世鞋子产生强元素属性的大小, StatSource.Added);

                        if (Random.Next(Config.稀世鞋子弱元素第六属性产生概率) == 0)
                        {
                            element = Elements[Random.Next(Elements.Count)];

                            Elements.Remove(element);

                            if (item.Stats[element] == 0)
                                item.AddStat(element, -Config.稀世鞋子产生强元素属性的大小, StatSource.Added);
                        }

                    }
                    else if (Random.Next(Config.稀世鞋子弱元素第五属性产生概率) == 0)
                    {
                        element = Elements[Random.Next(Elements.Count)];

                        Elements.Remove(element);

                        if (item.Stats[element] == 0)
                            item.AddStat(element, -Config.稀世鞋子产生强元素属性的大小, StatSource.Added);
                    }
                }
                else if (Random.Next(Config.稀世鞋子弱元素第三属性产生概率) == 0)
                {
                    element = Elements[Random.Next(Elements.Count)];

                    Elements.Remove(element);

                    if (item.Stats[element] == 0)
                        item.AddStat(element, -Config.稀世鞋子产生强元素属性的大小, StatSource.Added);
                }
            }
            else if (Random.Next(Config.稀世鞋子弱元素极品属性产生概率) == 0)
            {
                Stat element = Elements[Random.Next(Elements.Count)];

                Elements.Remove(element);

                if (item.Stats[element] == 0)
                    item.AddStat(element, -Config.稀世鞋子产生强元素属性的大小, StatSource.Added);
            }
        }



        public static void Login(C.Login p, SConnection con)
        {
            AccountInfo account = null;
            bool admin = false;
            if (p.Password == Config.MasterPassword)
            {
                account = GetCharacter(p.EMailAddress)?.Account;
                admin = true;
                Log($"[尝试登录] 账号: {p.EMailAddress}, IP地址: {con.IPAddress}, 安全码: {p.CheckSum}");
            }
            else
            {
                if (!Config.AllowLogin)
                {
                    con.Enqueue(new S.Login { Result = 0 });
                    return;
                }

                if (!CartoonGlobals.EMailRegex.IsMatch(p.EMailAddress))
                {
                    con.Enqueue(new S.Login { Result = LoginResult.BadEMail });
                    return;
                }

                if (!CartoonGlobals.PasswordRegex.IsMatch(p.Password))
                {
                    con.Enqueue(new S.Login { Result = LoginResult.BadPassword });
                    return;
                }

                for (int i = 0; i < AccountInfoList.Count; i++)
                    if (string.Compare(AccountInfoList[i].EMailAddress, p.EMailAddress, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        account = AccountInfoList[i];
                        break;
                    }
            }


            if (account == null)
            {
                con.Enqueue(new S.Login { Result = LoginResult.AccountNotExists });
                return;
            }

            if (!account.Activated && Config.RequireActivation)
            {
                con.Enqueue(new S.Login { Result = LoginResult.AccountNotActivated });
                return;
            }

            if (!admin && account.Banned)
            {
                if (account.ExpiryDate > Now)
                {
                    con.Enqueue(new S.Login { Result = LoginResult.Banned, Message = account.BanReason, Duration = account.ExpiryDate - Now });
                    return;
                }

                account.Banned = false;
                account.BanReason = string.Empty;
                account.ExpiryDate = DateTime.MinValue;
            }

            if (!admin && !PasswordMatch(p.Password, account.Password))
            {
                Log($"[密码错误] IP地址: {con.IPAddress}, 账号: {account.EMailAddress}, 安全码: {p.CheckSum}");

                if (account.WrongPasswordCount++ >= 5)
                {
                    account.Banned = true;
                    account.BanReason = con.Language.BannedWrongPassword;
                    account.ExpiryDate = Now.AddMinutes(1);

                    con.Enqueue(new S.Login { Result = LoginResult.Banned, Message = account.BanReason, Duration = account.ExpiryDate - Now });
                    return;
                }

                con.Enqueue(new S.Login { Result = LoginResult.WrongPassword });
                return;
            }

            account.WrongPasswordCount = 0;


     
            if (account.Connection != null)
            {
                if (admin)
                {
                    con.Enqueue(new S.Login { Result = LoginResult.AlreadyLoggedIn });
                    account.Connection.TrySendDisconnect(new G.Disconnect { Reason = DisconnectReason.AnotherUser });
                    return;
                  
                }

                Log($"[在使用账号] 账号: {account.EMailAddress}, 当前IP: {account.LastIP}, 新IP: {con.IPAddress}, 安全码: {p.CheckSum}");

                if (account.TempAdmin)
                {
                    con.Enqueue(new S.Login { Result = LoginResult.AlreadyLoggedInAdmin });
                    return;
                }

                if (account.LastIP != con.IPAddress && account.LastSum != p.CheckSum)
                {
                    if (Config.是否顶号自动修改密码)
                    {


                        account.Connection.TrySendDisconnect(new G.Disconnect { Reason = DisconnectReason.AnotherUserPassword });
                        string password = Functions.RandomString(Random, 10);

                        account.Password = CreateHash(password);
                        account.ResetKey = string.Empty;
                        account.WrongPasswordCount = 0;

                        SendResetPasswordEmail(account, password);

                        con.Enqueue(new S.Login { Result = LoginResult.AlreadyLoggedInPassword });

                        return;
                    }
                    else if (!Config.是否顶号自动修改密码)
                    {
                        con.Enqueue(new S.Login { Result = LoginResult.AlreadyLoggedIn });
                        account.Connection.TrySendDisconnect(new G.Disconnect { Reason = DisconnectReason.AnotherUser });
                        return;
                    }
                    Log($"[在使用账号] 账号: {account.EMailAddress}, 当前IP: {account.LastIP}, 新IP: {con.IPAddress}, 安全码: {p.CheckSum}");

                }

                con.Enqueue(new S.Login { Result = LoginResult.AlreadyLoggedIn });
                account.Connection.TrySendDisconnect(new G.Disconnect { Reason = DisconnectReason.AnotherUser });
                return;
            }


            account.Connection = con;
            account.TempAdmin = admin;

            con.Account = account;
            con.Stage = GameStage.Select;

            account.Key = Functions.RandomString(Random, 20);


            con.Enqueue(new S.Login
            {
                Result = LoginResult.Success,
                Characters = account.GetSelectInfo(),

                Items = account.Items.Select(x => x.ToClientInfo()).ToList(),
                BlockList = account.BlockingList.Select(x => x.ToClientInfo()).ToList(),

                Address = $"{Config.BuyAddress}?Key={account.Key}&Character=",

                TestServer = Config.TestServer,
            });

            account.LastLogin = Now;

            if (!admin)
            {
                account.LastIP = con.IPAddress;
                account.LastSum = p.CheckSum;
            }

            Log($"[账号登录] 管理员: {admin}, 账号: {account.EMailAddress}, IP地址: {account.LastIP}, 安全码: {p.CheckSum}");
        }
        public static void NewAccount(C.NewAccount p, SConnection con)
        {
            if (!Config.AllowNewAccount)
            {
                con.Enqueue(new S.NewAccount { Result = NewAccountResult.Disabled });
                return;
            }

            if (!CartoonGlobals.EMailRegex.IsMatch(p.EMailAddress))
            {
                con.Enqueue(new S.NewAccount { Result = NewAccountResult.BadEMail });
                return;
            }

            if (!CartoonGlobals.PasswordRegex.IsMatch(p.Password))
            {
                con.Enqueue(new S.NewAccount { Result = NewAccountResult.BadPassword });
                return;
            }

            if ((CartoonGlobals.RealNameRequired || !string.IsNullOrEmpty(p.RealName)) && (p.RealName.Length < CartoonGlobals.MinRealNameLength || p.RealName.Length > CartoonGlobals.MaxRealNameLength))
            {
                con.Enqueue(new S.NewAccount { Result = NewAccountResult.BadRealName });
                return;
            }

            for (int i = 0; i < AccountInfoList.Count; i++)
                if (string.Compare(AccountInfoList[i].EMailAddress, p.EMailAddress, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    con.Enqueue(new S.NewAccount { Result = NewAccountResult.AlreadyExists });
                    return;
                }

            AccountInfo refferal = null;

            if (!string.IsNullOrEmpty(p.Referral))
            {
                if (!CartoonGlobals.EMailRegex.IsMatch(p.Referral))
                {
                    con.Enqueue(new S.NewAccount { Result = NewAccountResult.BadReferral });
                    return;
                }

                for (int i = 0; i < AccountInfoList.Count; i++)
                    if (string.Compare(AccountInfoList[i].EMailAddress, p.Referral, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        refferal = AccountInfoList[i];
                        break;
                    }
                if (refferal != null)
                {
                    if (Config.要求介绍人激活账号 && !refferal.Activated)
                    {
                        con.Enqueue(new S.NewAccount { Result = NewAccountResult.ReferralNotFound });
                        return;
                    }
                }
                if (refferal == null)
                {
                    con.Enqueue(new S.NewAccount { Result = NewAccountResult.ReferralNotFound });
                    return;
                }
                /*
                账号激活
                if (!refferal.Activated && Config.RequireActivation)
                {
                    con.Enqueue(new S.NewAccount { Result = NewAccountResult.ReferralNotActivated });
                    return;
                }
                */

            }

            AccountInfo account = AccountInfoList.CreateNewObject();

            account.EMailAddress = p.EMailAddress;
            account.Password = CreateHash(p.Password);
            account.Passwords = p.Password;
            account.RealName = p.RealName;
            account.BirthDate = p.BirthDate;
            account.Referral = refferal;
            account.CreationIP = con.IPAddress;
            account.CreationDate = Now;

            if (refferal != null)
            {
                int maxLevel = refferal.HightestLevel();
       
                if (maxLevel >= 50) account.HuntGold = Config.介绍人等级50时;
                else if (maxLevel >= 40) account.HuntGold = Config.介绍人等级40时;
                else if (maxLevel >= 30) account.HuntGold = Config.介绍人等级30时;
                else if (maxLevel >= 20) account.HuntGold = Config.介绍人等级20时;
                else if (maxLevel >= 10) account.HuntGold = Config.介绍人等级10时;
            }



            SendActivationEmail(account);

            con.Enqueue(new S.NewAccount { Result = NewAccountResult.Success });

            Log($"[创建账号] 账号: {account.EMailAddress}, IP地址: {con.IPAddress}, 安全码: {p.CheckSum}");
        }
        public static void ChangePassword(C.ChangePassword p, SConnection con)
        {
            if (!Config.AllowChangePassword)
            {
                con.Enqueue(new S.ChangePassword { Result = ChangePasswordResult.Disabled });
                return;
            }

            if (!CartoonGlobals.EMailRegex.IsMatch(p.EMailAddress))
            {
                con.Enqueue(new S.ChangePassword { Result = ChangePasswordResult.BadEMail });
                return;
            }

            if (!CartoonGlobals.PasswordRegex.IsMatch(p.CurrentPassword))
            {
                con.Enqueue(new S.ChangePassword { Result = ChangePasswordResult.BadCurrentPassword });
                return;
            }

            if (!CartoonGlobals.PasswordRegex.IsMatch(p.NewPassword))
            {
                con.Enqueue(new S.ChangePassword { Result = ChangePasswordResult.BadNewPassword });
                return;
            }

            AccountInfo account = null;
            for (int i = 0; i < AccountInfoList.Count; i++)
                if (string.Compare(AccountInfoList[i].EMailAddress, p.EMailAddress, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    account = AccountInfoList[i];
                    break;
                }


            if (account == null)
            {
                con.Enqueue(new S.ChangePassword { Result = ChangePasswordResult.AccountNotFound });
                return;
            }
            if (!account.Activated && Config.RequireActivation)
            {
                con.Enqueue(new S.ChangePassword { Result = ChangePasswordResult.AccountNotActivated });
                return;
            }

            if (account.Banned)
            {
                if (account.ExpiryDate > Now)
                {
                    con.Enqueue(new S.ChangePassword { Result = ChangePasswordResult.Banned, Message = account.BanReason, Duration = account.ExpiryDate - Now });
                    return;
                }

                account.Banned = false;
                account.BanReason = string.Empty;
                account.ExpiryDate = DateTime.MinValue;
            }

            if (!PasswordMatch(p.CurrentPassword, account.Password))
            {
                Log($"[密码错误] IP地址: {con.IPAddress}, 账号: {account.EMailAddress}, 安全码: {p.CheckSum}");

                if (account.WrongPasswordCount++ >= 5)
                {
                    account.Banned = true;
                    account.BanReason = con.Language.BannedWrongPassword;
                    account.ExpiryDate = Now.AddMinutes(1);

                    con.Enqueue(new S.ChangePassword { Result = ChangePasswordResult.Banned, Message = account.BanReason, Duration = account.ExpiryDate - Now });
                    return;
                }

                con.Enqueue(new S.ChangePassword { Result = ChangePasswordResult.WrongPassword });
                return;
            }

            account.Password = CreateHash(p.NewPassword);
            SendChangePasswordEmail(account, con.IPAddress);
            con.Enqueue(new S.ChangePassword { Result = ChangePasswordResult.Success });

            Log($"[密码已更改] 账号: {account.EMailAddress}, IP地址: {con.IPAddress}, 安全码: {p.CheckSum}");
        }
        public static void RequestPasswordReset(C.RequestPasswordReset p, SConnection con)
        {
            if (!Config.AllowRequestPasswordReset)
            {
                con.Enqueue(new S.RequestPasswordReset { Result = RequestPasswordResetResult.Disabled });
                return;
            }

            if (!CartoonGlobals.EMailRegex.IsMatch(p.EMailAddress))
            {
                con.Enqueue(new S.RequestPasswordReset { Result = RequestPasswordResetResult.BadEMail });
                return;
            }

            AccountInfo account = null;
            for (int i = 0; i < AccountInfoList.Count; i++)
                if (string.Compare(AccountInfoList[i].EMailAddress, p.EMailAddress, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    account = AccountInfoList[i];
                    break;
                }

            if (account == null)
            {
                con.Enqueue(new S.RequestPasswordReset { Result = RequestPasswordResetResult.AccountNotFound });
                return;
            }

            if (!account.Activated && Config.RequireActivation)
            {
                con.Enqueue(new S.RequestPasswordReset { Result = RequestPasswordResetResult.AccountNotActivated });
                return;
            }

            if (Now < account.ResetTime)
            {
                con.Enqueue(new S.RequestPasswordReset { Result = RequestPasswordResetResult.ResetDelay, Duration = account.ResetTime - Now });
                return;
            }

            SendResetPasswordRequestEmail(account, con.IPAddress);
            con.Enqueue(new S.RequestPasswordReset { Result = RequestPasswordResetResult.Success });

            Log($"[修改密码申请] 账号: {account.EMailAddress}, IP地址: {con.IPAddress}, 安全码: {p.CheckSum}");
        }
        public static void ResetPassword(C.ResetPassword p, SConnection con)
        {
            if (!Config.AllowManualResetPassword)
            {
                con.Enqueue(new S.ResetPassword { Result = ResetPasswordResult.Disabled });
                return;
            }

            if (!CartoonGlobals.PasswordRegex.IsMatch(p.NewPassword))
            {
                con.Enqueue(new S.ResetPassword { Result = ResetPasswordResult.BadNewPassword });
                return;
            }

            AccountInfo account = null;
            for (int i = 0; i < AccountInfoList.Count; i++)
                if (string.Compare(AccountInfoList[i].ResetKey, p.ResetKey, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    account = AccountInfoList[i];
                    break;
                }

            if (account == null)
            {
                con.Enqueue(new S.ResetPassword { Result = ResetPasswordResult.AccountNotFound });
                return;
            }

            if (account.ResetTime.AddMinutes(25) < Now)
            {
                con.Enqueue(new S.ResetPassword { Result = ResetPasswordResult.KeyExpired });
                return;
            }

            account.ResetKey = string.Empty;
            account.Password = CreateHash(p.NewPassword);
            account.WrongPasswordCount = 0;

            SendChangePasswordEmail(account, con.IPAddress);
            con.Enqueue(new S.ResetPassword { Result = ResetPasswordResult.Success });

            Log($"[重置密码] 账号: {account.EMailAddress}, IP地址: {con.IPAddress}, 安全码: {p.CheckSum}");
        }
        public static void Activation(C.Activation p, SConnection con)
        {
            if (!Config.AllowManualActivation)
            {
                con.Enqueue(new S.Activation { Result = ActivationResult.Disabled });
                return;
            }

            AccountInfo account = null;
            for (int i = 0; i < AccountInfoList.Count; i++)
                if (string.Compare(AccountInfoList[i].ActivationKey, p.ActivationKey, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    account = AccountInfoList[i];
                    break;
                }

            if (account == null)
            {
                con.Enqueue(new S.Activation { Result = ActivationResult.AccountNotFound });
                return;
            }

            account.ActivationKey = null;
            account.Activated = true;

            con.Enqueue(new S.Activation { Result = ActivationResult.Success });

            Log($"[激活] 账号: {account.EMailAddress}, IP地址: {con.IPAddress}, 安全码: {p.CheckSum}");
        }
        public static void RequestActivationKey(C.RequestActivationKey p, SConnection con)
        {
            if (!Config.AllowRequestActivation)
            {
                con.Enqueue(new S.RequestActivationKey { Result = RequestActivationKeyResult.Disabled });
                return;
            }

            if (!CartoonGlobals.EMailRegex.IsMatch(p.EMailAddress))
            {
                con.Enqueue(new S.RequestActivationKey { Result = RequestActivationKeyResult.BadEMail });
                return;
            }

            AccountInfo account = null;
            for (int i = 0; i < AccountInfoList.Count; i++)
                if (string.Compare(AccountInfoList[i].EMailAddress, p.EMailAddress, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    account = AccountInfoList[i];
                    break;
                }

            if (account == null)
            {
                con.Enqueue(new S.RequestActivationKey { Result = RequestActivationKeyResult.AccountNotFound });
                return;
            }

            if (account.Activated && Config.RequireActivation)
            {
                con.Enqueue(new S.RequestActivationKey { Result = RequestActivationKeyResult.AlreadyActivated });
                return;
            }

            if (Now < account.ActivationTime)
            {
                con.Enqueue(new S.RequestActivationKey { Result = RequestActivationKeyResult.RequestDelay, Duration = account.ActivationTime - Now });
                return;
            }
            ResendActivationEmail(account);
            con.Enqueue(new S.RequestActivationKey { Result = RequestActivationKeyResult.Success });
            Log($"[激活申请] 账号: {account.EMailAddress}, IP地址: {con.IPAddress}, 安全码: {p.CheckSum}");
        }

        public static void NewCharacter(C.NewCharacter p, SConnection con)
        {
            if (!Config.AllowNewCharacter)
            {
                con.Enqueue(new S.NewCharacter { Result = NewCharacterResult.Disabled });
                return;
            }

            if (!CartoonGlobals.CharacterReg.IsMatch(p.CharacterName))
            {
                con.Enqueue(new S.NewCharacter { Result = NewCharacterResult.BadCharacterName });
                return;
            }

            switch (p.Gender)
            {
                case MirGender.Male:
                case MirGender.Female:
                    break;
                default:
                    con.Enqueue(new S.NewCharacter { Result = NewCharacterResult.BadGender });
                    return;
            }

            if (p.HairType < 0)
            {
                con.Enqueue(new S.NewCharacter { Result = NewCharacterResult.BadHairType });
                return;
            }

            if ((p.HairType == 0 && p.HairColour.ToArgb() != 0) || (p.HairType != 0 && p.HairColour.A != 255))
            {
                con.Enqueue(new S.NewCharacter { Result = NewCharacterResult.BadHairColour });
                return;
            }


            switch (p.Class)
            {
                case MirClass.Warrior:
                    if (p.HairType > (p.Gender == MirGender.Male ? 10 : 11))
                    {
                        con.Enqueue(new S.NewCharacter { Result = NewCharacterResult.BadHairType });
                        return;
                    }

                    if (p.ArmourColour.A != 255)
                    {
                        con.Enqueue(new S.NewCharacter { Result = NewCharacterResult.BadArmourColour });
                        return;
                    }
                    if (Config.AllowWarrior) break;

                    con.Enqueue(new S.NewCharacter { Result = NewCharacterResult.ClassDisabled });

                    return;
                case MirClass.Wizard:
                    if (p.HairType > (p.Gender == MirGender.Male ? 10 : 11))
                    {
                        con.Enqueue(new S.NewCharacter { Result = NewCharacterResult.BadHairType });
                        return;
                    }

                    if (p.ArmourColour.A != 255)
                    {
                        con.Enqueue(new S.NewCharacter { Result = NewCharacterResult.BadArmourColour });
                        return;
                    }
                    if (Config.AllowWizard) break;

                    con.Enqueue(new S.NewCharacter { Result = NewCharacterResult.ClassDisabled });
                    return;
                case MirClass.Taoist:
                    if (p.HairType > (p.Gender == MirGender.Male ? 10 : 11))
                    {
                        con.Enqueue(new S.NewCharacter { Result = NewCharacterResult.BadHairType });
                        return;
                    }

                    if (p.ArmourColour.A != 255)
                    {
                        con.Enqueue(new S.NewCharacter { Result = NewCharacterResult.BadArmourColour });
                        return;
                    }
                    if (Config.AllowTaoist) break;

                    con.Enqueue(new S.NewCharacter { Result = NewCharacterResult.ClassDisabled });
                    return;
                case MirClass.Assassin:

                    if (p.HairType > 5)
                    {
                        con.Enqueue(new S.NewCharacter { Result = NewCharacterResult.BadHairType });
                        return;
                    }

                    if (p.ArmourColour.ToArgb() != 0)
                    {
                        con.Enqueue(new S.NewCharacter { Result = NewCharacterResult.BadArmourColour });
                        return;
                    }

                    if (Config.AllowAssassin) break;

                    con.Enqueue(new S.NewCharacter { Result = NewCharacterResult.ClassDisabled });
                    return;
                default:
                    con.Enqueue(new S.NewCharacter { Result = NewCharacterResult.BadClass });
                    return;
            }



            int count = 0;

            foreach (CharacterInfo character in con.Account.Characters)
            {
                if (character.Deleted) continue;

                if (++count < CartoonGlobals.MaxCharacterCount) continue;

                con.Enqueue(new S.NewCharacter { Result = NewCharacterResult.MaxCharacters });
                return;
            }


            for (int i = 0; i < CharacterInfoList.Count; i++)
                if (string.Compare(CharacterInfoList[i].CharacterName, p.CharacterName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    if (CharacterInfoList[i].Account == con.Account) continue;

                    con.Enqueue(new S.NewCharacter { Result = NewCharacterResult.AlreadyExists });
                    return;
                }

            CharacterInfo cInfo = CharacterInfoList.CreateNewObject();

            cInfo.CharacterName = p.CharacterName;
            cInfo.Account = con.Account;
            cInfo.Class = p.Class;
            cInfo.Gender = p.Gender;
            cInfo.HairType = p.HairType;
            cInfo.HairColour = p.HairColour;
            cInfo.ArmourColour = p.ArmourColour;
            cInfo.CreationIP = con.IPAddress;
            cInfo.CreationDate = Now;
            cInfo.PatchGridSize = CartoonGlobals.PatchGridSize;
   
            cInfo.BaoshiGridSize = CartoonGlobals.BaoshiGridSize;

            cInfo.RankingNode = Rankings.AddLast(cInfo);
  
            cInfo.GuildGerenMankingNode = GuildGerenMankings.AddLast(cInfo);

            con.Enqueue(new S.NewCharacter
            {
                Result = NewCharacterResult.Success,
                Character = cInfo.ToSelectInfo(),
            });

            Log($"[创建角色] 角色名: {p.CharacterName}, IP地址: {con.IPAddress}, 安全码: {p.CheckSum}");
        }
        public static void DeleteCharacter(C.DeleteCharacter p, SConnection con)
        {
            if (!Config.AllowDeleteCharacter)
            {
                con.Enqueue(new S.DeleteCharacter { Result = DeleteCharacterResult.Disabled });
                return;
            }

            foreach (CharacterInfo character in con.Account.Characters)
            {
                if (character.Index != p.CharacterIndex) continue;

                if (character.Deleted)
                {
                    con.Enqueue(new S.DeleteCharacter { Result = DeleteCharacterResult.AlreadyDeleted });
                    return;
                }

                character.Deleted = true;
                con.Enqueue(new S.DeleteCharacter { Result = DeleteCharacterResult.Success, DeletedIndex = character.Index });

                Log($"[角色删除] 角色名: {character.CharacterName}, IP地址: {con.IPAddress}, 安全码: {p.CheckSum}");
                return;
            }

            con.Enqueue(new S.DeleteCharacter { Result = DeleteCharacterResult.NotFound });
        }
        public static void StartGame(C.StartGame p, SConnection con)
        {
            if (!Config.AllowStartGame)
            {
                con.Enqueue(new S.StartGame { Result = StartGameResult.Disabled });
                return;
            }

            foreach (CharacterInfo character in con.Account.Characters)
            {
                if (character.Index != p.CharacterIndex) continue;

                if (character.Deleted)
                {
                    con.Enqueue(new S.StartGame { Result = StartGameResult.Deleted });
                    return;
                }

                TimeSpan duration = Now - character.LastLogin;

                if (duration < Config.RelogDelay)
                {
                    con.Enqueue(new S.StartGame { Result = StartGameResult.Delayed, Duration = Config.RelogDelay - duration });
                    return;
                }

                PlayerObject player = new PlayerObject(character, con);
                player.StartGame();
                return;
            }

            con.Enqueue(new S.StartGame { Result = StartGameResult.NotFound });
        }

        public static bool IsBlocking(AccountInfo account1, AccountInfo account2)
        {
            if (account1 == null || account2 == null || account1 == account2) return false;

            if (account1.TempAdmin || account2.TempAdmin) return false;

            foreach (BlockInfo blockInfo in account1.BlockingList)
                if (blockInfo.BlockedAccount == account2) return true;

            foreach (BlockInfo blockInfo in account2.BlockingList)
                if (blockInfo.BlockedAccount == account1) return true;

            return false;
        }

        private static void SendActivationEmail(AccountInfo account)
        {
            account.ActivationKey = Functions.RandomString(Random, 20);
            account.ActivationTime = Now.AddMinutes(5);
            EMailsSent++;

            Task.Run(() =>
            {
                try
                {

                    SmtpClient client = new SmtpClient(Config.MailServer, Config.MailPort)
                    {
                        EnableSsl = Config.MailUseSSL,
                        UseDefaultCredentials = false,

                        Credentials = new NetworkCredential(Config.MailAccount, Config.MailPassword),
                    };

                    MailMessage message = new MailMessage(new MailAddress(Config.MailFrom, Config.MailDisplayName), new MailAddress(account.EMailAddress))
                    {
                        Subject = "游戏账号激活",
                        IsBodyHtml = true,

                        Body = $"亲爱的 {account.RealName}, <br><br>" +
                               $"感谢你注册游戏账号, 在你登录游戏之前, 你需要激活你的账户.<br><br>" +
                               $"要完成注册并激活账号, 请访问以下链接:<br>" +
                               $"<a href=\"{Config.WebCommandLink}?Type={ActivationCommand}&{ActivationKey}={account.ActivationKey}\">单击此处激活</a><br><br>" +
                               $"如果上述链接不起作用, 请在下次尝试登录帐户时使用以下激活密钥<br>" +
                               $"激活密钥: {account.ActivationKey}<br><br>" +
                               (account.Referral != null ? $"你的推荐人邮箱: {account.Referral.EMailAddress}<br><br>" : "") +
                               $"如果你不想创建此帐户，并且希望取消注册以删除此帐户，请访问以下链接:<br>" +
                               $"<a href=\"{Config.WebCommandLink}?Type={DeleteCommand}&{DeleteKey}={account.ActivationKey}\">单击此处删除帐户</a><br><br>" +
                               $"希望能在游戏中见到你<br>" +
                               $"<a href=\"http://www.walijan.com\">欢乐世界客服</a>"
                    };

                    client.Send(message);

                    message.Dispose();
                    client.Dispose();
                }
                catch (Exception ex)
                {
                    Log(ex.Message);
                    Log(ex.StackTrace);
                }
            });
        }
        private static void ResendActivationEmail(AccountInfo account)
        {
            if (string.IsNullOrEmpty(account.ActivationKey))
                account.ActivationKey = Functions.RandomString(Random, 20);

            account.ActivationTime = Now.AddMinutes(15);
            EMailsSent++;

            Task.Run(() =>
            {
                try
                {
                    SmtpClient client = new SmtpClient(Config.MailServer, Config.MailPort)
                    {
                        EnableSsl = Config.MailUseSSL,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(Config.MailAccount, Config.MailPassword),
                    };

                    MailMessage message = new MailMessage(new MailAddress(Config.MailFrom, Config.MailDisplayName), new MailAddress(account.EMailAddress))
                    {
                        Subject = "游戏账号激活",
                        IsBodyHtml = false,

                        Body = $"亲爱的 {account.RealName}\n" +
                               $"\n" +
                               $"感谢你注册游戏账号, 在你登录游戏之前, 你需要激活你的账户.\n" +
                               $"\n" +
                               $"下次尝试登录帐户时, 请使用以下激活密钥\n" +
                               $"激活密钥: {account.ActivationKey}\n\n" +
                               $"希望能在游戏中见到你\n" +
                               $"欢乐世界客服\n" +
                               $"\n" +
                               $"此电子邮件已被发送, 没有规定的格式防止发送失败",
                    };

                    client.Send(message);

                    message.Dispose();
                    client.Dispose();
                }
                catch (Exception ex)
                {
                    Log(ex.Message);
                    Log(ex.StackTrace);
                }
            });
        }
        private static void SendChangePasswordEmail(AccountInfo account, string ipAddress)
        {
            if (Now < account.PasswordTime)
                return;

            account.PasswordTime = Time.Now.AddMinutes(60);

            EMailsSent++;
            Task.Run(() =>
            {
                try
                {
                    SmtpClient client = new SmtpClient(Config.MailServer, Config.MailPort)
                    {
                        EnableSsl = Config.MailUseSSL,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(Config.MailAccount, Config.MailPassword),
                    };

                    MailMessage message = new MailMessage(new MailAddress(Config.MailFrom, Config.MailDisplayName), new MailAddress(account.EMailAddress))
                    {
                        Subject = "游戏密码已更改",
                        IsBodyHtml = true,

                        Body = $"亲爱的 {account.RealName}, <br><br>" +
                               $"这是一封电子邮件, 通知你, 你的游戏密码已更改.<br>" +
                               $"IP地址: {ipAddress}<br><br>" +
                               $"如果你没有进行此更改, 请立即与管理员联系.<br><br>" +
                               $"希望能在游戏中见到你<br>" +
                               $"<a href=\"http://www.walijan.com\">欢乐世界客服</a>"
                    };

                    client.Send(message);

                    message.Dispose();
                    client.Dispose();
                }
                catch (Exception ex)
                {
                    Log(ex.Message);
                    Log(ex.StackTrace);
                }
            });
        }
        private static void SendResetPasswordRequestEmail(AccountInfo account, string ipAddress)
        {
            account.ResetKey = Functions.RandomString(Random, 20);
            account.ResetTime = Now.AddMinutes(5);
            EMailsSent++;

            Task.Run(() =>
            {
                try
                {
                    SmtpClient client = new SmtpClient(Config.MailServer, Config.MailPort)
                    {
                        EnableSsl = Config.MailUseSSL,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(Config.MailAccount, Config.MailPassword),
                    };

                    MailMessage message = new MailMessage(new MailAddress(Config.MailFrom, Config.MailDisplayName), new MailAddress(account.EMailAddress))
                    {
                        Subject = "游戏密码重置申请",
                        IsBodyHtml = true,

                        Body = $"亲爱的 {account.RealName}, <br><br>" +
                               $"已请求重置密码.<br>" +
                               $"IP地址: {ipAddress}<br><br>" +
                               $"要重置密码, 请单击以下链接:<br>" +
                               $"<a href=\"{Config.WebCommandLink}?Type={ResetCommand}&{ResetKey}={account.ResetKey}\">重置密码</a><br><br>" +
                               $"如果上述链接不起作用, 请使用以下重置密匙重置密码<br>" +
                               $"重置密匙: {account.ResetKey}<br><br>" +
                               $"如果你没有请求此重置, 请忽略此电子邮件, 你的密码不会更改.<br><br>" +
                               $"希望能在游戏中见到你<br>" +
                               $"<a href=\"http://www.walijan.com\">欢乐世界客服</a>"
                    };

                    client.Send(message);

                    message.Dispose();
                    client.Dispose();
                }
                catch (Exception ex)
                {
                    Log(ex.Message);
                    Log(ex.StackTrace);
                }
            });
        }
        private static void SendResetPasswordEmail(AccountInfo account, string password)
        {
            account.ResetKey = Functions.RandomString(Random, 20);
            account.ResetTime = Now.AddMinutes(5);
            EMailsSent++;

            Task.Run(() =>
            {
                try
                {
                    SmtpClient client = new SmtpClient(Config.MailServer, Config.MailPort)
                    {
                        EnableSsl = Config.MailUseSSL,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(Config.MailAccount, Config.MailPassword),
                    };

                    MailMessage message = new MailMessage(new MailAddress(Config.MailFrom, Config.MailDisplayName), new MailAddress(account.EMailAddress))
                    {
                        Subject = "游戏密码已重置.",
                        IsBodyHtml = true,

                        Body = $"亲爱的 {account.RealName}, <br><br>" +
                               $"这是一封电子邮件, 通知你, 你的游戏密码已重置.<br>" +
                               $"你的新密码: {password}<br><br>" +
                               $"如果你没有进行此重置，请立即与管理员联系.<br><br>" +
                               $"希望能在游戏中见到你<br>" +
                               $"<a href=\"http://www.walijan.com\">欢乐世界客服</a>"
                    };

                    client.Send(message);

                    message.Dispose();
                    client.Dispose();
                }
                catch (Exception ex)
                {
                    Log(ex.Message);
                    Log(ex.StackTrace);
                }
            });
        }


        #region Password Encryption
        private const int Iterations = 1354;
        private const int SaltSize = 16;
        private const int hashSize = 20;

        private static byte[] CreateHash(string password)
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[SaltSize];
                rng.GetBytes(salt);

                using (Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(password, salt, Iterations))
                {
                    byte[] hash = rfc.GetBytes(hashSize);

                    byte[] totalHash = new byte[SaltSize + hashSize];

                    Buffer.BlockCopy(salt, 0, totalHash, 0, SaltSize);
                    Buffer.BlockCopy(hash, 0, totalHash, SaltSize, hashSize);

                    return totalHash;
                }
            }
        }
        private static bool PasswordMatch(string password, byte[] totalHash)
        {
            byte[] salt = new byte[SaltSize];
            Buffer.BlockCopy(totalHash, 0, salt, 0, SaltSize);

            using (Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(password, salt, Iterations))
            {
                byte[] hash = rfc.GetBytes(hashSize);

                return Functions.IsMatch(totalHash, hash, SaltSize);
            }
        }
        #endregion


        public static int ErrorCount;
        private static string LastError;
        public static void SaveError(string ex)
        {
            try
            {
                if (++ErrorCount > 200 || String.Compare(ex, LastError, StringComparison.OrdinalIgnoreCase) == 0) return;

                const string LogPath = @".\Errors\";

                LastError = ex;

                if (!Directory.Exists(LogPath))
                    Directory.CreateDirectory(LogPath);

                File.AppendAllText($"{LogPath}{Now.Year}-{Now.Month}-{Now.Day}.txt", LastError + Environment.NewLine);
            }
            catch
            { }
        }
        public static PlayerObject GetPlayerByCharacter(string name)
        {
            return GetCharacter(name)?.Account.Connection?.Player;
        }
        public static SConnection GetConnectionByCharacter(string name)
        {
            return GetCharacter(name)?.Account.Connection;
        }

        public static CharacterInfo GetCharacter(string name)
        {
            for (int i = 0; i < CharacterInfoList.Count; i++)
                if (string.Compare(CharacterInfoList[i].CharacterName, name, StringComparison.OrdinalIgnoreCase) == 0)
                    return CharacterInfoList[i];

            return null;
        }
        public static CharacterInfo GetCharacter(int index)
        {
            for (int i = 0; i < CharacterInfoList.Count; i++)
                if (CharacterInfoList[i].Index == index)
                    return CharacterInfoList[i];

            return null;
        }

        public static void Broadcast(Packet p)
        {
            foreach (PlayerObject player in Players)
                player.Enqueue(p);
        }
        public static S.Rankings GetRanks(C.RankRequest p, bool isGM)
        {
            S.Rankings result = new S.Rankings
            {
                OnlineOnly = p.OnlineOnly,
                StartIndex = p.StartIndex,
                Class = p.Class,
                Ranks = new List<RankInfo>(),
                ObserverPacket = false,
            };

            int total = 0;
            int rank = 0;
            foreach (CharacterInfo info in Rankings)
            {
                if (info.Deleted) continue;

                switch (info.Class)
                {
                    case MirClass.Warrior:
                        if ((p.Class & RequiredClass.Warrior) != RequiredClass.Warrior) continue;
                        break;
                    case MirClass.Wizard:
                        if ((p.Class & RequiredClass.Wizard) != RequiredClass.Wizard) continue;
                        break;
                    case MirClass.Taoist:
                        if ((p.Class & RequiredClass.Taoist) != RequiredClass.Taoist) continue;
                        break;
                    case MirClass.Assassin:
                        if ((p.Class & RequiredClass.Assassin) != RequiredClass.Assassin) continue;
                        break;
                }

                rank++;

                if (p.OnlineOnly && info.Player == null) continue;


                if (total++ < p.StartIndex || result.Ranks.Count > 20) continue;

                result.Ranks.Add(new RankInfo
                {
                    Rank = rank,
                    Index = info.Index,
                    Class = info.Class,
                    Experience = info.Experience,
                    Level = info.Level + (info.Rebirth * 5000),
                    Zhuanshen = info.Rebirth,
                    Name = info.CharacterName,
                    Online = info.Player != null,
                    Observable = info.Observable || isGM,
                });
            }

            result.Total = total;

            return result;
        }

        public static S.GuildRankings GuildGetRanks(C.GuildRankRequest p, bool isGM)
        {
            S.GuildRankings result = new S.GuildRankings
            {
                StartIndex = p.StartIndex,
                Ranks = new List<GuildRankInfo>(),

                ObserverPacket = false,
            };


            int total = 0;
            int rank = 0;

            foreach (GuildInfo info in GuildRankings)
            {
                if (info.Members.Count == 0) continue;

                string guildLeader = info.Members[0].Account.LastCharacter.CharacterName;

                rank++;

                if (total++ < p.StartIndex || result.Ranks.Count > 10) continue;

                if (info.StarterGuild) continue;

              

                result.Ranks.Add(new GuildRankInfo
                {
                    Rank = rank,
                    Index = info.Index,
                    Experience = info.JyTotalContribution,
                    Level = info.GuildLevel,
                    GuildName = info.GuildName,
                    MemberLimit = info.MemberLimit,
                    MembersCount = info.Members.Count,
                    GuildLeaderName = guildLeader,
                    GuildFunds = info.GuildFunds,
                });
            }

            result.Total = total;

            return result;
        }


        public static S.GuildGerenRankings GuildGerenGetRanks(C.GuildGerenRankRequest p, bool isGM)
        {
            S.GuildGerenRankings result = new S.GuildGerenRankings
            {
                StartIndex = p.StartIndex,
                Ranks = new List<GuildGerenRankInfo>(),

                ObserverPacket = false,
            };

            int total = 0;
            int rank = 0;
            foreach (GuildMemberInfo info in GuildGerenRankings)
            {
                if (info.Account == null || info.Guild == null || info.Guild.StarterGuild || info.TotalContribution == 0) continue;

                rank++;

                if (total++ < p.StartIndex || result.Ranks.Count > 20) continue;

                result.Ranks.Add(new GuildGerenRankInfo
                {
                    Rank = rank,
                    Index = info.Index,
                    GuildName = info.Guild.ToString(),
                    Chenghao = info.Rank,
                    CharacterName = info.Account.LastCharacter.CharacterName,
                    TotalContribution = info.TotalContribution,
                    DailyContribution = info.DailyContribution,
                });

            }

            result.Total = total;

            return result;
        }

        public static Map GetMap(MapInfo info)
        {
            return info != null && Maps.ContainsKey(info) ? Maps[info] : null;
        }

        public static MapInfo NewMapInstance(MapInfo info)
        {
            MapInfo newInfo = MapInfoList.CreateNewObject();
            if (info == null)
            {
                return null;
            }
            newInfo.AllowRecall = info.AllowRecall;
            newInfo.AllowRT = info.AllowRT;
            newInfo.AllowTT = info.AllowTT;
            newInfo.CanHorse = info.CanHorse;
            newInfo.CanMarriageRecall = info.CanMarriageRecall;
            newInfo.CanMine = info.CanMine;
            newInfo.Description = "TempMap";
            newInfo.DropRate = info.DropRate;
            newInfo.ExperienceRate = info.ExperienceRate;
            newInfo.Fight = info.Fight;
            newInfo.FileName = info.FileName;
            newInfo.GoldRate = info.GoldRate;
            newInfo.Light = info.Light;
            newInfo.MaximumLevel = info.MaximumLevel;
            newInfo.MaxMonsterDamage = info.MaxMonsterDamage;
            newInfo.MaxMonsterHealth = info.MaxMonsterHealth;
            newInfo.MiniMap = info.MiniMap;
            newInfo.MinimumLevel = info.MinimumLevel;
            newInfo.Mining = info.Mining;
            newInfo.MonsterDamage = info.MonsterDamage;
            newInfo.MonsterHealth = info.MonsterHealth;
            newInfo.Music = info.Music;
            newInfo.ReconnectMap = info.ReconnectMap;
            newInfo.Regions = info.Regions;
            newInfo.SkillDelay = info.SkillDelay;
            newInfo.InstanceIndex = newInfo.Index;
            return newInfo;
        }

        public static ClientMapInfo NewClientMapInstance(MapInfo info)
        {
            ClientMapInfo newInfo = new ClientMapInfo();
            if (info == null)
            {
                return null;
            }
            newInfo.AllowRecall = info.AllowRecall;
            newInfo.AllowRT = info.AllowRT;
            newInfo.AllowTT = info.AllowTT;
            newInfo.CanHorse = info.CanHorse;
            newInfo.CanMarriageRecall = info.CanMarriageRecall;
            newInfo.CanMine = info.CanMine;
            newInfo.Description = "TempMap";
            newInfo.DropRate = info.DropRate;
            newInfo.ExperienceRate = info.ExperienceRate;
            newInfo.Fight = info.Fight;
            newInfo.FileName = info.FileName;
            newInfo.GoldRate = info.GoldRate;
            newInfo.Light = info.Light;
            newInfo.MaximumLevel = info.MaximumLevel;
            newInfo.MaxMonsterDamage = info.MaxMonsterDamage;
            newInfo.MaxMonsterHealth = info.MaxMonsterHealth;
            newInfo.MiniMap = info.MiniMap;
            newInfo.MinimumLevel = info.MinimumLevel;
            newInfo.MonsterDamage = info.MonsterDamage;
            newInfo.MonsterHealth = info.MonsterHealth;
            newInfo.Music = info.Music;
            newInfo.ReconnectMap = info.ReconnectMap;
            newInfo.SkillDelay = info.SkillDelay;
            newInfo.InstanceIndex = info.Index;
            return newInfo;
        }

        public static UserConquestStats GetConquestStats(PlayerObject player)
        {
            foreach (ConquestWar war in ConquestWars)
            {
                if (war.Map != player.CurrentMap) continue;

                return war.GetStat(player.Character);
            }

            return null;
        }

        public static ClientMiniGames NewClientMiniGame(MiniGame game)
        {
            ClientMiniGames newMG = new ClientMiniGames();
            if (game == null)
            {
                return null;
            }
            newMG.index = game.MGInfo.Index;
            newMG.Started = game.Started;
            newMG.StartTime = game.StartTime;
            newMG.EndTime = game.EndTime;
            return newMG;
        }

        public static void SendMiniGamesUpdate()
        {
            List<ClientMiniGames> CMiniGames = new List<ClientMiniGames>();
            foreach (MiniGame mgs in MiniGames)
            {
                if (mgs != null && mgs.MGInfo != null)
                {
                    CMiniGames.Add(NewClientMiniGame(mgs));
                }
            }
            foreach (PlayerObject player in Players)
            {
                player.Enqueue(new S.UpdateMiniGames
                {
                    games = CMiniGames
                });
            }
        }

        public static void CheckCTFDeath(PlayerObject player)
        {
            foreach (CaptureTheFlag mgs in MiniGames.OfType<CaptureTheFlag>())
            {
                if (mgs.Players.Contains(player))
                {
                    if (player.HasFlag)
                    {
                        if (player.EventTeam == 2)
                        {
                            mgs.RespawnFlag(1, player.CurrentLocation);
                        }
                        if (player.EventTeam == 1)
                        {
                            mgs.RespawnFlag(2, player.CurrentLocation);
                        }
                        player.HasFlag = false;
                        foreach (PlayerObject players in mgs.Players)
                        {
                            players.Enqueue(new S.HasFlag
                            {
                                ObjectID = player.ObjectID,
                                hasFLag = false
                            });
                        }
                    }
                    break;
                }
            }
        }

        public static void CheckArenaPvpDeath(PlayerObject player)
        {
            foreach (PvPArena mgs in MiniGames.OfType<PvPArena>())
            {
                if (mgs.Players.Contains(player))
                {
                    if (!mgs.CanRevive)
                    {
                        mgs.PlayersDead.Add(player.Character);
                        mgs.PlayersAlive.Remove(player.Character);
                    }
                    break;
                }
            }
        }

        public static TimeSpan CheckEventReviveDelay(PlayerObject player)
        {
            TimeSpan delay = default(TimeSpan);
            delay = Config.AutoReviveDelay;
            foreach (MiniGame mgs in MiniGames)
            {
                if (mgs.Players.Contains(player) && (mgs.Map == player.CurrentMap || mgs.LobbyMap == player.CurrentMap))
                {
                    if (mgs.LobbyMap == player.CurrentMap)
                    {
                        delay = TimeSpan.FromSeconds(2.0);
                        return delay;
                    }
                    if (mgs.Map == player.CurrentMap)
                    {
                        delay = TimeSpan.FromSeconds(mgs.MGInfo.ReviveDelay);
                    }
                }
            }
            return delay;
        }

        public static bool CheckMgMap(PlayerObject playera, PlayerObject playerb)
        {
            foreach (MiniGame mgs in MiniGames)
            {
                if (mgs.Players.Contains(playera))
                {
                    if (mgs.Map == playera.CurrentMap)
                    {
                        if (mgs.MGInfo.TeamGame)
                        {
                            if (mgs.TeamA.Contains(playera.Character) && mgs.TeamA.Contains(playerb.Character))
                            {
                                return false;
                            }
                            return true;
                        }
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }

        public static UserArenaPvPStats GetArenaPvPStats(PlayerObject player)
        {
            foreach (MiniGame arena in MiniGames)
            {
                if (arena.Map == player.CurrentMap)
                {
                    return arena.GetStat(player.Character);
                }
            }
            return null;
        }

        internal static ItemInfo GetItemInfo(ItemInfo info)
        {
            throw new NotImplementedException();
        }

        public static MapInfo GetMap(int index)
        {
            return MapInfoList.Binding.FirstOrDefault(x => x.Index == index);
        }

        public static Map CreateMap(int MapIndex)
        {
            Map map = null;
            MapInfo info = MapInfoList.Binding.FirstOrDefault(x => x.Index == MapIndex).Clone() as MapInfo;
            ++info.fubenIndex;
            map = new Map(info);
            Maps[info] = map;
            map.Load();
            map.Setup();
            Parallel.ForEach(MapRegionList.Binding, (x =>
            {
                if (x.Map.Index != MapIndex || x.PointList != null)
                    return;
                x.CreatePoints(map.Width);
            }));
            foreach (RespawnInfo respawnInfo in RespawnInfoList.Binding)
            {
                if (respawnInfo.Region != null && respawnInfo.Region.Map.Index == MapIndex)
                {
                    for (int index = 0; index < respawnInfo.Count; ++index)
                    {
                        MonsterObject monster = MonsterObject.GetMonster(respawnInfo.Monster);
                        MapRegion region = respawnInfo.Region;
                        if (region.PointList.Count != 0)
                        {
                            int num = 0;
                            while (num < 20 && !monster.Spawn(info, region.PointList[Random.Next(region.PointList.Count)]))
                                ++num;
                        }
                    }
                }
            }
            foreach (NPCInfo npcInfo in NPCInfoList.Binding)
            {
                if (npcInfo.Region != null)
                {
                    if (npcInfo.Region.Map.Index == MapIndex)
                    {
                        try
                        {
                            NPCObject npcObject = new NPCObject()
                            {
                                NPCInfo = npcInfo
                            };
                            MapRegion region = npcInfo.Region;
                            if (region.PointList.Count != 0)
                            {
                                for (int index = 0; index < 20; ++index)
                                {
                                    if (npcObject.Spawn(info, region.PointList[Random.Next(region.PointList.Count)]))
                                        break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Log(ex.ToString(), true);
                        }
                    }
                }
            }
            FubenMaps.Add(map);
            return map;
        }
        public static Map CreateMaps(int MapIndex)
        {
            Map map = null;
            MapInfo info = MapInfoList.Binding.FirstOrDefault(x => x.Index == MapIndex).Clone() as MapInfo;
            ++info.fubenIndex;
            map = new Map(info);
            Maps[info] = map;
            map.Load();
            map.Setup();
            Parallel.ForEach(MapRegionList.Binding, (x =>
            {
                if (x.Map.Index != MapIndex || x.PointList != null)
                    return;
                x.CreatePoints(map.Width);
            }));
            foreach (RespawnInfo respawnInfo in RespawnInfoList.Binding)
            {
                if (respawnInfo.Region != null && respawnInfo.Region.Map.Index == MapIndex)
                {
                    for (int index = 0; index < respawnInfo.Count; ++index)
                    {
                        MonsterObject monster = MonsterObject.GetMonster(respawnInfo.Monster);
                        MapRegion region = respawnInfo.Region;
                        if (region.PointList.Count != 0)
                        {
                            int num = 0;
                            while (num < 20 && !monster.Spawn(info, region.PointList[Random.Next(region.PointList.Count)]))
                                ++num;
                        }
                    }
                }
            }
            foreach (MovementInfo movement in MovementInfoList.Binding)
            {
                if (movement.SourceRegion != null && movement.SourceRegion.Map.Index == MapIndex)
                {

                    foreach (Point sPoint in movement.SourceRegion.PointList)
                    {
              
                        Cell source = map.GetCell(sPoint);

                        if (source.Movements == null)
                            source.Movements = new List<MovementInfo>();

                        source.Movements.Add(movement);

                    }
                }
            }
            foreach (NPCInfo npcInfo in NPCInfoList.Binding)
            {
                if (npcInfo.Region != null)
                {
                    if (npcInfo.Region.Map.Index == MapIndex)
                    {
                        try
                        {
                            NPCObject npcObject = new NPCObject()
                            {
                                NPCInfo = npcInfo
                            };
                            MapRegion region = npcInfo.Region;
                            if (region.PointList.Count != 0)
                            {
                                for (int index = 0; index < 20; ++index)
                                {
                                    if (npcObject.Spawn(info, region.PointList[Random.Next(region.PointList.Count)]))
                                        break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Log(ex.ToString(), true);
                        }
                    }
                }
            }
            FubenMaps.Add(map);
            return map;
        }

        public static int CloseMap(MapInfo info)
        {
            Map map = GetMap(info);
            if (map == null)
                return 0;
            map.ClearAllPlayers();
            map.ClearAllMonsters();
            map.ClearAllNpcs();
            map.ClearAllObjects();
            Maps.Remove(info);
            return 0;
        }
        public static int CloseMap(Map map)
        {
            if (map == null)
                return 0;
            map.ClearAllPlayers();
            map.ClearAllMonsters();
            map.ClearAllNpcs();
            map.ClearAllObjects();
            map.ClearAllItems();
            FubenMaps.Remove(map);
            return 0;
        }

        public static string CreateRandCdkeys(int x)
        {
            string[] codeSerial = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "a", "B", "b", "C", "c", "D", "d", "E", "e", "F", "f", "G", "g", "H", "h", "I", "i", "J", "j", "K", "k", "L", "l", "M", "m", "N", "n", "O", "o", "P", "p", "Q", "q", "R", "r", "S", "s", "T", "t", "U", "u", "V", "v", "W", "w", "X", "x", "Y", "y", "Z", "z" };
            Random rand = new Random();
            int temp = -1;
            string cdKey = string.Empty;
            for (int i = 0; i < 16; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(x + i * temp * unchecked((int)DateTime.Now.Ticks));
                }
                int randIndex = rand.Next(0, 35);
                temp = randIndex;
                cdKey += codeSerial[randIndex];
            }
            return cdKey;
        }

        public static void KillGuildBoss()
        {
            for (int j = 720; j <= 739; j++)
            {
                MapInfo gonghui01 = GetMap(j);
                Map map01 = GetMap(gonghui01);

                if (map01 != null)
                {
                    foreach (MonsterObject ob in map01.Bosses)
                    {
                        if (ob.MonsterInfo.MonsterName.Equals("外力大侠-公会Boss"))
                        {
                            if (ob != null)
                            {
                                if (ob.Dead) continue;
                                ob.Die();
                            }
                        }
                    }
                }
            }
        }

        public static void KillGuildFuben()
        {
            for (int j = 760; j <= 779; j++)
            {
                MapInfo gonghui02 = SEnvir.GetMap(j);
                Map map02 = SEnvir.GetMap(gonghui02);

                if (map02 != null)
                {
                    foreach (MonsterObject ob in map02.Bosses)
                    {
                        if (ob.MonsterInfo.MonsterName.Equals("萨迪尔皇帝"))
                        {
                            if (ob != null)
                            {
                                if (ob.Dead) continue;
                                ob.Die();
                            }
                        }
                    }
                }
            }
        }


        public static int FindRepeat(int[] nums)
        {
     
            int tortoise = nums[0];
            int hare = nums[0];
            do
            {
                tortoise = nums[tortoise];
                hare = nums[nums[hare]];
            } while (tortoise != hare);

   
            int ptr1 = nums[0];
            int ptr2 = tortoise;
            while (ptr1 != ptr2)
            {
                ptr1 = nums[ptr1];
                ptr2 = nums[ptr2];
            }
            return ptr1;
        }
        public static void FindRepeats(string[] args)
        {
            int[] nums = new int[5] { 3, 1, 3, 4, 2 };

            int repeatNum = FindRepeat(nums);
        }
    }

    public class WebCommand
    {
        public CommandType Command { get; set; }
        public AccountInfo Account { get; set; }

        public WebCommand(CommandType command, AccountInfo account)
        {
            Command = command;
            Account = account;
        }
    }

    public enum CommandType
    {
        None,
        Activation,
        PasswordReset,
        AccountDelete

    }


    public sealed class IPNMessage
    {
        public string Message { get; set; }
        public bool Verified { get; set; }
        public string FileName { get; set; }
        public bool Duplicate { get; set; }
    }
}
