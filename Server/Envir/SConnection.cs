using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using Library;
using Library.Network;
using Library.SystemModels;
using Server.DBModels;
using Server.Envir.Translations;
using Server.Models;
using G = Library.Network.GeneralPackets;
using C = Library.Network.ClientPackets;
using S = Library.Network.ServerPackets;
using Server.Models.Monsters;
using Library.Network.ClientPackets;
using MarketPlaceConsign = Library.Network.ClientPackets.MarketPlaceConsign;

namespace Server.Envir
{
    public sealed class SConnection : BaseConnection
    {
        private static int SessionCount;

        protected override TimeSpan TimeOutDelay => Config.TimeOut;

        private DateTime PingTime;
        private bool PingSent;
        public int Ping { get; private set; }

        public GameStage Stage { get; set; }
        public AccountInfo Account { get; set; }

        
        public GuildInfo Guild { get; set; }

        public PlayerObject Player { get; set; }
        public string IPAddress { get; }
        public int SessionID { get; }

        public SConnection Observed;
        public List<SConnection> Observers = new List<SConnection>();

        public List<AuctionInfo> MPSearchResults = new List<AuctionInfo>();
        public HashSet<AuctionInfo> VisibleResults = new HashSet<AuctionInfo>();

        public StringMessages Language;

        public SConnection(TcpClient client) : base(client)
        {
            IPAddress = client.Client.RemoteEndPoint.ToString().Split(':')[0];
            SessionID = ++SessionCount;


            Language = (StringMessages) ConfigReader.ConfigObjects[typeof(EnglishMessages)]; 

            OnException += (o, e) =>
            {
                SEnvir.Log(string.Format("崩溃: 账号: {0}, 角色: {1}.", Account?.EMailAddress, Player?.Name));
                SEnvir.Log(e.ToString());
                SEnvir.Log(e.StackTrace.ToString());
                
                File.AppendAllText(@".\Errors.txt", e.StackTrace + Environment.NewLine);
            };

            SEnvir.Log(string.Format("[连接] IP地址:{0}", IPAddress));

            UpdateTimeOut();
            BeginReceive();

            Enqueue(new G.Connected());
        }

        public override void Disconnect()
        {
            if (!Connected) return;

            base.Disconnect();

            CleanUp();

            if (!SEnvir.Connections.Contains(this))
                throw new InvalidOperationException("在列表中找不到连接");

            SEnvir.Connections.Remove(this);
            SEnvir.IPCount[IPAddress]--;
            SEnvir.DBytesSent += TotalBytesSent;
            SEnvir.DBytesReceived += TotalBytesReceived;
        }

        public override void SendDisconnect(Packet p)
        {
            base.SendDisconnect(p);

            CleanUp();
        }
        
        public void Process(C.ClientAnswerTestGj p)
        {
            if (Stage != GameStage.Game) return;
            Player.AnswerTestGj(p, true);
        }
        public override void TryDisconnect()
        {
            if (Stage == GameStage.Game)
            {
                if (SEnvir.Now >= Player.CombatTime.AddSeconds(10))
                {
                    Disconnect();
                    return;
                }

                if (!Disconnecting)
                {
                    Disconnecting = true;
                    TimeOutTime = Time.Now.AddSeconds(10);
                }

                if (SEnvir.Now <= TimeOutTime) return;
            }

            Disconnect();
        }
        public override void TrySendDisconnect(Packet p)
        {
            if (Stage == GameStage.Game)
            {
                if (SEnvir.Now >= Player.CombatTime.AddSeconds(10))
                {
                    Disconnect();
                    return;
                }

                if (!Disconnecting)
                {
                    base.SendDisconnect(p);

                    TimeOutTime = Time.Now.AddSeconds(10);
                }

                if (SEnvir.Now <= TimeOutTime) return;

            }

            SendDisconnect(p);
        }

        public void EndObservation()
        {
            Observed.Observers.Remove(this);
            Observed = null;

            if (Account != null)
            {
                Stage = GameStage.Select;
                Enqueue(new S.GameLogout { Characters = Account.GetSelectInfo() });
            }
            else
            {
                Stage = GameStage.Login;
                Enqueue(new S.SelectLogout());
            }
        }
        public void CleanUp()
        {
            Stage = GameStage.Disconnected;

            if (Account != null && Account.Connection == this)
            {
                Account.TempAdmin = false;
                Account.Connection = null;
            }

            Account = null;
            Player?.StopGame();
            Player = null;

            Observed?.Observers.Remove(this);
            Observed = null;

            
            
        }
        public override void Process()
        {
            if (SEnvir.Now >= PingTime && !PingSent && Stage != GameStage.None)
            {
                PingTime = SEnvir.Now;
                PingSent = true;
                Enqueue(new G.Ping { ObserverPacket = false });
            }

            if (ReceiveList.Count > Config.MaxPacket)
            {
                TryDisconnect();
                SEnvir.IPBlocks[IPAddress] = SEnvir.Now.Add(Config.PacketBanTime);

                for (int i = SEnvir.Connections.Count - 1; i >= 0; i--)
                    if (SEnvir.Connections[i].IPAddress == IPAddress)
                        SEnvir.Connections[i].TryDisconnect();

                SEnvir.Log($"{IPAddress} 断开连接,大量数据包");
                return;
            }

            base.Process();
        }

        public override void Enqueue(Packet p)
        {
            base.Enqueue(p);

            if (p == null || !p.ObserverPacket) return;

            foreach (SConnection observer in Observers)
                observer.Enqueue(p);
        }

        public void ReceiveChat(string text, MessageType type, uint objectID = 0)
        {

            switch (Stage)
            {
                case GameStage.Game:
                case GameStage.Observer:
                    Enqueue(new S.Chat
                    {
                        Text = text,
                        Type = type,
                        ObjectID = objectID, 

                        ObserverPacket = false,
                    });
                    break;
                default:
                    return;
            }
        }
        
        public void ReceiveChat(string text, MessageType type, List<ClientUserItem> userItems, uint objectID = 0)
        {

            switch (Stage)
            {
                case GameStage.Game:
                case GameStage.Observer:
                    Enqueue(new S.Chat
                    {
                        Text = text,
                        Type = type,
                        ObjectID = objectID, 

                        ObserverPacket = false,
                        Items = userItems,
                    });
                    break;
                default:
                    return;
            }
        }
        public void Process(C.SelectLanguage p)
        {
            switch (p.Language.ToUpper())
            {
                case "ENGLISH":
                    Language = (StringMessages)ConfigReader.ConfigObjects[typeof(EnglishMessages)]; 
                    break;
                case "CHINESE":
                    Language = (StringMessages)ConfigReader.ConfigObjects[typeof(ChineseMessages)]; 
                    break;
            }

        }
        public void Process(G.Disconnect p)
        {
            Disconnecting = true;
        }
        public void Process(G.Connected p)
        {
            if (Config.CheckVersion)
            {
                Enqueue(new G.CheckVersion());
                return;
            }

            Stage = GameStage.Login;
            Enqueue(new G.GoodVersion());
        }

        public void Process(C.SortBagItem p) 
        {
            Player.SortBagItem();
        }

        public void Process(G.Version p)
        {
            if (Stage != GameStage.None) return;

            if (!Functions.IsMatch(Config.ClientHash, p.ClientHash))
            {
                SendDisconnect(new G.Disconnect { Reason = DisconnectReason.WrongVersion });
                return;
            }

            Stage = GameStage.Login;
            Enqueue(new G.GoodVersion());
        }
        public void Process(G.Ping p)
        {
            if (Stage == GameStage.None) return;

            int ping = (int) (SEnvir.Now - PingTime).TotalMilliseconds/2;
            PingSent = false;
            PingTime = SEnvir.Now + Config.PingDelay;

            Ping = ping;
            Enqueue(new G.PingResponse { Ping = Ping, ObserverPacket = false });
        }

        public void Process(C.NewAccount p)
        {
            if (Stage != GameStage.Login) return;

            SEnvir.NewAccount(p, this);
        }
        public void Process(C.ChangePassword p)
        {
            if (Stage != GameStage.Login) return;

            SEnvir.ChangePassword(p, this);
        }
        public void Process(C.RequestPasswordReset p)
        {
            if (Stage != GameStage.Login) return;

            SEnvir.RequestPasswordReset(p, this);
        }
        public void Process(C.ResetPassword p)
        {
            if (Stage != GameStage.Login) return;

            SEnvir.ResetPassword(p, this);
        }
        public void Process(C.Activation p)
        {
            if (Stage != GameStage.Login) return;

            SEnvir.Activation(p, this);
        }
        public void Process(C.RequestActivationKey p)
        {
            if (Stage != GameStage.Login) return;

            SEnvir.RequestActivationKey(p, this);
        }
        public void Process(C.Login p)
        {
            if (Stage != GameStage.Login) return;

            SEnvir.Login(p, this);
        }
        public void Process(C.Logout p)
        {

            switch (Stage)
            {
                case GameStage.Select:
                    Stage = GameStage.Login;
                    Account.Connection = null;
                    Account = null;

                    Enqueue(new S.SelectLogout());
                    break;
                case GameStage.Game:

                    if (!Player.setConfArr[33])
                        if (SEnvir.Now < Player.CombatTime.AddSeconds(10)) return;

                    Player.StopGame();

                    Stage = GameStage.Select;

                    Enqueue(new S.GameLogout { Characters = Account.GetSelectInfo() });
                    break;
                case GameStage.Observer:
                    EndObservation();
                    break;
            }
            ;

        }

        public void Process(C.NewCharacter p)
        {
            if (Stage != GameStage.Select) return;

            SEnvir.NewCharacter(p, this);
        }
        public void Process(C.DeleteCharacter p)
        {
            if (Stage != GameStage.Select) return;

            SEnvir.DeleteCharacter(p, this);
        }
        public void Process(C.StartGame p)
        {
            if (Stage != GameStage.Select) return;


            SEnvir.StartGame(p, this);
        }
        public void Process(C.TownRevive p)
        {
            if (Stage != GameStage.Game) return;

            Player.TownRevive();
        }
        public void Process(C.Turn p)
        {
            if (Stage != GameStage.Game) return;

            if (p.Direction < MirDirection.Up || p.Direction > MirDirection.UpLeft) return;

            Player.Turn(p.Direction);
        }
        public void Process(C.Harvest p)
        {
            if (Stage != GameStage.Game) return;

            if (p.Direction < MirDirection.Up || p.Direction > MirDirection.UpLeft) return;

            Player.Harvest(p.Direction);
        }
        public void Process(C.Move p)
        {
            if (Stage != GameStage.Game) return;

            if (p.Direction < MirDirection.Up || p.Direction > MirDirection.UpLeft) return;

            /*  if (p.Distance > 1 && (Player.BagWeight > Player.Stats[Stat.BagWeight] || Player.WearWeight > Player.Stats[Stat.WearWeight]))
              {
                  Enqueue(new S.UserLocation { Direction = Player.Direction, Location = Player.CurrentLocation });
                  return;
              }*/

            Player.Move(p.Direction, p.Distance);
        }
        public void Process(C.Mount p)
        {
            if (Stage != GameStage.Game) return;

            Player.Mount();
        }
        public void Process(C.Attack p)
        {
            if (Stage != GameStage.Game) return;

            if (p.Direction < MirDirection.Up || p.Direction > MirDirection.UpLeft) return;

            Player.Attack(p.Direction, p.AttackMagic);
        }
        public void Process(C.Magic p)
        {
            if (Stage != GameStage.Game) return;

            if (p.Direction < MirDirection.Up || p.Direction > MirDirection.UpLeft) return;

            Player.Magic(p);
        }
        public void Process(C.MagicToggle p)
        {
            if (Stage != GameStage.Game) return;

            Player.MagicToggle(p);
        }
        public void Process(C.Mining p)
        {
            if (Stage != GameStage.Game) return;

            if (p.Direction < MirDirection.Up || p.Direction > MirDirection.UpLeft) return;

            Player.Mining(p.Direction);
        }

        public void Process(C.ItemMove p)
        {
            if (Stage != GameStage.Game) return;

            Player.ItemMove(p);
        }
        public void Process(C.ItemDrop p)
        {
            if (Stage != GameStage.Game) return;

            Player.ItemDrop(p);
        }

        public void Process(C.PickUpC p)
        {
            if (Stage != GameStage.Game) return;

            Player.PickUpC(p.Xpos, p.Ypos, p.ItemIdx);
        }

        public void Process(C.PickUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.PickUp(p.Xpos, p.Ypos, p.ItemIdx);
        }

        public void Process(C.PktFilterItem p)
        {
            if (Stage != GameStage.Game) return;

            Player.FilterItem(p.FilterStr);
        }

        public void Process(C.GoldDrop p)
        {
            if (Stage != GameStage.Game) return;

            Player.GoldDrop(p);
        }
        public void Process(C.ItemUse p)
        {
            if (Stage != GameStage.Game) return;

            Player.ItemUse(p.Link);
        }

        public void Process(C.BeltLinkChanged p)
        {
            if (Stage != GameStage.Game) return;

            Player.BeltLinkChanged(p);
        }
        public void Process(C.AutoPotionLinkChanged p)
        {
            if (Stage != GameStage.Game) return;

            Player.AutoPotionLinkChanged(p);
        }

        public void Process(AutoFightConfChanged p)
        {
            if (Stage != GameStage.Game)
                return;
            Player.AutoFightConfChanged(p);
        }

        
        public void Process(C.UserTeleportChanged p)
        {
            if (Stage != GameStage.Game) return;

            Player.UserTeleportChanged(p);
        }
        
        public void Process(C.UserTeleport p)
        {
            if (Stage != GameStage.Game) return;

            Player.UserTeleport(p);
        }
        public void Process(C.Chat p)
        {
            if (p.Text.Length > CartoonGlobals.MaxChatLength) return;

            if (Stage == GameStage.Game)
                Player.Chat(p.Text);

            if (Stage == GameStage.Observer)
                Observed.Player.ObserverChat(this, p.Text);
        }
        public void Process(C.NPCCall p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCCall(p.ObjectID);
        }
        public void Process(C.NPCButton p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCButton(p.ButtonID);
        }
        
        public void Process(C.NPCBuy p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCBuy(p);
        }
        
        public void Process(C.NPCGBuy p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCGBuy(p);
        }
        
        public void Process(C.NPCYBuy p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCYBuy(p);
        }
        
        public void Process(C.NPCShenmiSRBuy p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCShenmiSRBuy(p);
        }
        
        public void Process(C.NPCBaoshiBuy p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCBaoshiBuy(p);
        }
        
        public void Process(C.NPCFubenBiBuy p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCFubenBiBuy(p);
        }
        public void Process(C.FubenMove p)
        {
            if (Stage != GameStage.Game) return;

            Player.FubenMove(p);
        }
        public void Process(C.NPCSell p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCSell(p.Links);
        }
        
        public void Process(C.NPCJyChange p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCJyChange(p.Links);
        }
        
        public void Process(C.GuildJyChange p)
        {
            if (Stage != GameStage.Game) return;

            Player.GuildJyChange(p.Links);
        }
        public void Process(C.NPCRepair p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCRepair(p);
        }
        public void Process(C.NPCRefinementStone p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCRefinementStone(p);
        }
        public void Process(C.NPCRefine p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCRefine(p);
        }
        public void Process(C.NPCRefineRetrieve p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCRefineRetrieve(p.Index);
        }
        public void Process(C.NPCMasterRefine p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCMasterRefine(p);
        }
        public void Process(C.NPCMasterRefineEvaluate p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCMasterRefineEvaluate(p);
        }
        public void Process(C.NPCClose p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPC = null;
            Player.NPCPage = null;

            foreach (SConnection con in Observers)
            {
                con.Enqueue(new S.NPCClose());
            }
        }

        
        public void Process(C.NPCMingwenUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCMingwenUp(p);
        }

        
        public void Process(C.Zhongzi p)
        {
            if (Stage != GameStage.Game) return;

            Player.Zhongzi(p);
        }

        
        public void Process(C.NPCFragment p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCFragment(p.Links);
        }
        
        public void Process(C.ZaixianNPCFragment p)
        {
            if (Stage != GameStage.Game) return;

            Player.ZaixianNPCFragment(p.Links);
        }
        
        public void Process(C.NPCXiaohui p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiaohui(p.Links);
        }
        
        public void Process(C.NPChechengbaoshi p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPChechengbaoshi(p.Links);
        }
        
        public void Process(C.NPCduihuanbaoshi p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCduihuanbaoshi(p.Links);
        }
        public void Process(C.NPCAccessoryLevelUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCAccessoryLevelUp(p);
        }
        
        public void Process(C.NPCDunLevelUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCDunLevelUp(p);
        }
        
        public void Process(C.NPCHuiLevelUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCHuiLevelUp(p);
        }
        public void Process(C.NPCGZLKaikongUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCGZLKaikongUp(p);
        }
        public void Process(C.NPCGZLBKaikongUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCGZLBKaikongUp(p);
        }
        public void Process(C.NPCQTKaikongUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCQTKaikongUp(p);
        }
        public void Process(C.NPCXiangKanGJSTUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKanGJSTUp(p);
        }
        public void Process(C.NPCXiangKanGJBSTUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKanGJBSTUp(p);
        }
        public void Process(C.NPCXiangKanZRSTUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKanZRSTUp(p);
        }
        public void Process(C.NPCXiangKanZRBSTUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKanZRBSTUp(p);
        }
        public void Process(C.NPCXiangKanLHSTUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKanLHSTUp(p);
        }
        public void Process(C.NPCXiangKanLHBSTUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKanLHBSTUp(p);
        }
        public void Process(C.NPCXiangKanSMSTUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKanSMSTUp(p);
        }
        public void Process(C.NPCXiangKanMFSTUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKanMFSTUp(p);
        }
        public void Process(C.NPCXiangKanSDSTUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKanSDSTUp(p);
        }
        public void Process(C.NPCXiangKanFYSTUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKanFYSTUp(p);
        }
        public void Process(C.NPCXiangKanMYSTUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKanMYSTUp(p);
        }
        
        public void Process(C.NPCHuanhuaUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCHuanhuaUp(p);
        }
        public void Process(C.NPCChaichustUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCChaichustUp(p);
        }
        public void Process(C.NPCXiangkanjystUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangkanjystUp(p);
        }
        public void Process(C.NPCXiangkanxxstUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangkanxxstUp(p);
        }
        public void Process(C.NPCXiangKanghuoUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKanghuoUp(p);
        }
        public void Process(C.NPCXiangKangbingUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKangbingUp(p);
        }
        public void Process(C.NPCXiangKangleiUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKangleiUp(p);
        }
        public void Process(C.NPCXiangKangfengUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKangfengUp(p);
        }
        public void Process(C.NPCXiangKangshenUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKangshenUp(p);
        }
        public void Process(C.NPCXiangKanganUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKanganUp(p);
        }
        public void Process(C.NPCXiangKanghuanUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKanghuanUp(p);
        }
        public void Process(C.NPCXiangKanmofadunUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKanmofadunUp(p);
        }
        public void Process(C.NPCXiangKanbingdongUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKanbingdongUp(p);
        }
        public void Process(C.NPCXiangKanmabiUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKanmabiUp(p);
        }
        public void Process(C.NPCXiangKanchenmoUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKanchenmoUp(p);
        }
        public void Process(C.NPCXiangKangedangUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKangedangUp(p);
        }
        public void Process(C.NPCXiangKanduobiUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKanduobiUp(p);
        }
        public void Process(C.NPCXiangKanqhuoUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKanqhuoUp(p);
        }
        public void Process(C.NPCXiangKanqbingUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKanqbingUp(p);
        }
        public void Process(C.NPCXiangKanqleiUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKanqleiUp(p);
        }
        public void Process(C.NPCXiangKanqfengUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKanqfengUp(p);
        }
        public void Process(C.NPCXiangKanqshenUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKanqshenUp(p);
        }
        public void Process(C.NPCXiangKanqanUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKanqanUp(p);
        }
        public void Process(C.NPCXiangKanqhuanUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKanqhuanUp(p);
        }
        public void Process(C.NPCXiangKanlvduUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKanlvduUp(p);
        }
        public void Process(C.NPCXiangKanyidongUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKanyidongUp(p);
        }
        public void Process(C.NPCXiangKanzymUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKanzymUp(p);
        }
        public void Process(C.NPCXiangKanmhhfUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKanmhhfUp(p);
        }
        
        public void Process(C.NPCXiangKanjinglianUp p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCXiangKanjinglianUp(p);
        }



        public void Process(C.NPCAccessoryUpgrade p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCAccessoryUpgrade(p);
        }
        
        public void Process(C.NPCDunUpgradeFY p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCDunUpgradeFY(p);
        }
        
        public void Process(C.NPCDunUpgradeMY p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCDunUpgradeMY(p);
        }
        
        public void Process(C.NPCDunUpgradeSM p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCDunUpgradeSM(p);
        }
        
        public void Process(C.NPCDunUpgradeMF p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCDunUpgradeMF(p);
        }
        
        public void Process(C.NPCHuiUpgradeGJ p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCHuiUpgradeGJ(p);
        }
        
        public void Process(C.NPCHuiUpgradeZR p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCHuiUpgradeZR(p);
        }
        
        public void Process(C.NPCHuiUpgradeLH p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCHuiUpgradeLH(p);
        }


        public void Process(C.MagicKey p)
        {
            if (Stage != GameStage.Game) return;


            foreach (KeyValuePair<MagicType, UserMagic> pair in Player.Magics)
            {
                if (pair.Value.Set1Key == p.Set1Key)
                    pair.Value.Set1Key = SpellKey.None;

                if (pair.Value.Set2Key == p.Set2Key)
                    pair.Value.Set2Key = SpellKey.None;

                if (pair.Value.Set3Key == p.Set3Key)
                    pair.Value.Set3Key = SpellKey.None;

                if (pair.Value.Set4Key == p.Set4Key)
                    pair.Value.Set4Key = SpellKey.None;
            }

            UserMagic magic;

            if (!Player.Magics.TryGetValue(p.Magic, out magic)) return;

            magic.Set1Key = p.Set1Key;
            magic.Set2Key = p.Set2Key;
            magic.Set3Key = p.Set3Key;
            magic.Set4Key = p.Set4Key;
        }

        public void Process(C.GroupSwitch p)
        {
            if (Stage != GameStage.Game) return;

            Player.GroupSwitch(p.Allow);
        }
        public void Process(C.GroupInvite p)
        {
            if (Stage != GameStage.Game) return;

            Player.GroupInvite(p.Name);
        }
        
        public void Process(C.CDkey01Invite p)
        {
            if (Stage != GameStage.Game) return;

            Player.CDkey01Invite(p.CDkey);
        }
        
        public void Process(C.CDkey02Invite p)
        {
            if (Stage != GameStage.Game) return;

            Player.CDkey02Invite(p.CDkey);
        }
        
        public void Process(C.CDkey03Invite p)
        {
            if (Stage != GameStage.Game) return;

            Player.CDkey03Invite(p.CDkey);
        }
        public void Process(C.GroupRemove p)
        {
            if (Stage != GameStage.Game) return;

            Player.GroupRemove(p.Name);
        }
        public void Process(C.GroupResponse p)
        {
            if (Stage != GameStage.Game) return;

            if (p.Accept)
                Player.GroupJoin();

            Player.GroupInvitation = null;
        }

        public void Process(C.Inspect p)
        {
            if (Stage == GameStage.Game)
                Player.Inspect(p.Index, this);

            if (Stage == GameStage.Observer)
                Observed.Player.Inspect(p.Index, this);
        }
        public void Process(C.RankRequest p)
        {
            if (Stage != GameStage.Game && Stage != GameStage.Observer && Stage != GameStage.Login) return;

            Enqueue(SEnvir.GetRanks(p, Account != null && (Account.TempAdmin || Account.Observer)));
        }
        
        public void Process(C.GuildRankRequest p)
        {
            if (Stage != GameStage.Game && Stage != GameStage.Observer && Stage != GameStage.Login) return;

            Enqueue(SEnvir.GuildGetRanks(p, Guild != null));
        }
        
        public void Process(C.GuildGerenRankRequest p)
        {
            if (Stage != GameStage.Game && Stage != GameStage.Observer && Stage != GameStage.Login) return;

            Enqueue(SEnvir.GuildGerenGetRanks(p, Account != null && (Account.TempAdmin || Account.Observer)));
        }

        public void Process(C.ObserverRequest p)
        {
            if (!Config.AllowObservation && (Account == null || (!Account.TempAdmin && !Account.Observer))) return;

            PlayerObject player = SEnvir.GetPlayerByCharacter(p.Name);

            if (player == null || player == Player) return;

            if (!player.Character.Observable && (Account == null || (!Account.TempAdmin && !Account.Observer))) return;

            if (Stage == GameStage.Game)
                Player.StopGame();

            if (Stage == GameStage.Observer)
            {
                Observed.Observers.Remove(this);
                Observed = null;
            }

            player.SetUpObserver(this);
        }
        public void Process(C.ObservableSwitch p)
        {
            if (Stage != GameStage.Game) return;

            Player.ObservableSwitch(p.Allow);
        }

        public void Process(C.Hermit p)
        {
            if (Stage != GameStage.Game) return;

            Player.AssignHermit(p.Stat);
        }

        public void Process(MarketPlaceHistory p)
        {
            if (Stage != GameStage.Game && Stage != GameStage.Observer)
                return;
            Library.Network.ServerPackets.MarketPlaceHistory marketPlaceHistory1 = new Library.Network.ServerPackets.MarketPlaceHistory();
            marketPlaceHistory1.Index = p.Index;
            marketPlaceHistory1.Display = p.Display;
            marketPlaceHistory1.ObserverPacket = false;
            Library.Network.ServerPackets.MarketPlaceHistory marketPlaceHistory2 = marketPlaceHistory1;
            Enqueue((Packet)marketPlaceHistory2);
            AuctionHistoryInfo auctionHistoryInfo = SEnvir.AuctionHistoryInfoList.Binding.FirstOrDefault<AuctionHistoryInfo>((Func<AuctionHistoryInfo, bool>)(x =>
            {
                if (x.Info == p.Index)
                    return x.PartIndex == p.PartIndex;
                return false;
            }));
            if (auctionHistoryInfo == null)
                return;
            marketPlaceHistory2.SaleCount = auctionHistoryInfo.SaleCount;
            marketPlaceHistory2.LastPrice = auctionHistoryInfo.LastPrice;
            long num1 = 0;
            int num2 = 0;
            foreach (int num3 in auctionHistoryInfo.Average)
            {
                if (num3 != 0)
                {
                    num1 += num3;
                    ++num2;
                }
                else
                    break;
            }
            if (num2 != 0)
                marketPlaceHistory2.AveragePrice = num1 / num2;
            long num4 = 0;
            int num5 = 0;
            foreach (int num3 in auctionHistoryInfo.GameGoldAverage)
            {
                if (num3 != 0)
                {
                    num4 += (long)num3;
                    ++num5;
                }
                else
                    break;  
            }
            if (num5 != 0)
                marketPlaceHistory2.GameGoldAveragePrice = num4 / num5;
            marketPlaceHistory2.GameGoldLastPrice = auctionHistoryInfo.LastGameGoldPrice;
        }

        public void Process(Library.Network.ClientPackets.MarketPlaceConsign p)
        {
            if (Stage != GameStage.Game)
                return;
            Player.MarketPlaceConsign(p);
        }

        public void Process(Library.Network.ClientPackets.MarketPlaceSearch p)
        {
            if (Stage != GameStage.Game && Stage != GameStage.Observer)
                return;
            MPSearchResults.Clear();
            VisibleResults.Clear();
            HashSet<int> intSet = new HashSet<int>();
            foreach (Library.SystemModels.ItemInfo itemInfo in (IEnumerable<Library.SystemModels.ItemInfo>)SEnvir.ItemInfoList.Binding)
            {
                try
                {
                    if (!string.IsNullOrEmpty(p.Name))
                    {
                        if (itemInfo.ItemName.IndexOf(p.Name, StringComparison.OrdinalIgnoreCase) < 0)
                            continue;
                    }
                    intSet.Add(itemInfo.Index);
                }
                catch (Exception ex)
                {
                    Console.WriteLine((object)ex);
                    throw;
                }
            }
            foreach (AuctionInfo auctionInfo in (IEnumerable<AuctionInfo>)SEnvir.AuctionInfoList.Binding)
            {
                if (auctionInfo.Item != null && (!p.ItemTypeFilter || auctionInfo.Item.Info.ItemType == p.ItemType))
                {
                    if (auctionInfo.Item.Info.Effect == ItemEffect.ItemPart)
                    {
                        if (!intSet.Contains(auctionInfo.Item.Stats[Stat.ItemIndex]))
                            continue;
                    }
                    else if (!intSet.Contains(auctionInfo.Item.Info.Index))
                        continue;
                    MPSearchResults.Add(auctionInfo);
                }
            }
            switch (p.Sort)
            {
                case MarketPlaceSort.Newest:
                    MPSearchResults.Sort((Comparison<AuctionInfo>)((x1, x2) => x2.Index.CompareTo(x1.Index)));
                    break;
                case MarketPlaceSort.Oldest:
                    MPSearchResults.Sort((Comparison<AuctionInfo>)((x1, x2) => x1.Index.CompareTo(x2.Index)));
                    break;
                case MarketPlaceSort.HighestPrice:
                    MPSearchResults.Sort((Comparison<AuctionInfo>)((x1, x2) => x2.Price.CompareTo(x1.Price)));
                    break;
                case MarketPlaceSort.LowestPrice:
                    MPSearchResults.Sort((Comparison<AuctionInfo>)((x1, x2) => x1.Price.CompareTo(x2.Price)));
                    break;
            }
            List<ClientMarketPlaceInfo> clientMarketPlaceInfoList = new List<ClientMarketPlaceInfo>();
            foreach (AuctionInfo mpSearchResult in MPSearchResults)
            {
                if (clientMarketPlaceInfoList.Count < 9)
                {
                    clientMarketPlaceInfoList.Add(mpSearchResult.ToClientInfo(Account));
                    VisibleResults.Add(mpSearchResult);
                }
                else
                    break;
            }
            Library.Network.ServerPackets.MarketPlaceSearch marketPlaceSearch = new Library.Network.ServerPackets.MarketPlaceSearch();
            marketPlaceSearch.Count = MPSearchResults.Count;
            marketPlaceSearch.Results = clientMarketPlaceInfoList;
            marketPlaceSearch.ObserverPacket = false;
            Enqueue((Packet)marketPlaceSearch);
        }

        public void Process(Library.Network.ClientPackets.MarketPlaceSearchIndex p)
        {
            if (Stage != GameStage.Game && Stage != GameStage.Observer || (p.Index < 0 || p.Index >= MPSearchResults.Count))
                return;
            AuctionInfo mpSearchResult = MPSearchResults[p.Index];
            if (VisibleResults.Contains(mpSearchResult))
                return;
            VisibleResults.Add(mpSearchResult);
            Library.Network.ServerPackets.MarketPlaceSearchIndex placeSearchIndex = new Library.Network.ServerPackets.MarketPlaceSearchIndex();
            placeSearchIndex.Index = p.Index;
            placeSearchIndex.Result = mpSearchResult.ToClientInfo(Account);
            placeSearchIndex.ObserverPacket = false;
            Enqueue((Packet)placeSearchIndex);
        }

        public void Process(MarketPlaceCancelConsign p)
        {
            if (Stage != GameStage.Game)
                return;
            Player.MarketPlaceCancelConsign(p);
        }

        public void Process(MarketPlaceBuy p)
        {
            if (Stage != GameStage.Game)
                return;
            Player.MarketPlaceBuy(p);
        }

        public void Process(Library.Network.ClientPackets.MarketPlaceStoreBuy p)
        {
            if (Stage != GameStage.Game)
                return;
            Player.MarketPlaceStoreBuy(p);
        }

        public void Process(C.MailOpened p)
        {
            if (Stage != GameStage.Game) return;

            MailInfo mail = Account.Mail.FirstOrDefault(x => x.Index == p.Index);

            if (mail == null) return;

            mail.Opened = true;
        }
        public void Process(C.MailGetItem p)
        {
            if (Stage != GameStage.Game) return;

            Player.MailGetItem(p);
        }
        public void Process(C.MailDelete p)
        {
            if (Stage != GameStage.Game) return;

            Player.MailDelete(p.Index);
        }
        public void Process(C.MailSend p)
        {
            if (Stage != GameStage.Game) return;

            Player.MailSend(p);
        }

        public void Process(C.ChangeAttackMode p)
        {
            if (Stage != GameStage.Game) return;

            switch (p.Mode)
            {
                case AttackMode.Peace:
                case AttackMode.Group:
                case AttackMode.Guild:
                case AttackMode.WarRedBrown:
                case AttackMode.All:
                    Player.AttackMode = p.Mode;
                    Enqueue(new S.ChangeAttackMode { Mode = p.Mode });
                    break;
            }
        }
        public void Process(C.ChangePetMode p)
        {
            if (Stage != GameStage.Game) return;

            switch (p.Mode)
            {
                case PetMode.Both:
                case PetMode.Move:
                case PetMode.Attack:
                case PetMode.PvP:
                case PetMode.None:
                    Player.PetMode = p.Mode;
                    Enqueue(new S.ChangePetMode { Mode = p.Mode });
                    break;
            }
        }
        
        public void Process(C.ItemSplit p)
        {
            if (Stage != GameStage.Game) return;

            Player.ItemSplit(p);
        }
        public void Process(C.ItemLock p)
        {
            if (Stage != GameStage.Game) return;

            Player.ItemLock(p);
        }


        public void Process(C.TradeRequest p)
        {
            if (Stage != GameStage.Game) return;

            Player.TradeRequest();
        }
        public void Process(C.TradeRequestResponse p)
        {
            if (Stage != GameStage.Game) return;

            if (p.Accept)
                Player.TradeAccept();

            Player.TradePartnerRequest = null;
        }
        public void Process(C.TradeClose p)
        {
            if (Stage != GameStage.Game) return;

            Player.TradeClose();
        }
        public void Process(C.TradeAddItem p)
        {
            if (Stage != GameStage.Game) return;

            Player.TradeAddItem(p.Cell);
        }
        public void Process(C.TradeAddGold p)
        {
            if (Stage != GameStage.Game) return;

            Player.TradeAddGold(p.Gold);
        }
        public void Process(C.TradeConfirm p)
        {
            if (Stage != GameStage.Game) return;

            Player.TradeConfirm();
        }

        public void Process(C.GuildCreate p)
        {
            if (Stage != GameStage.Game) return;

            Player.GuildCreate(p);
        }
        public void Process(C.GuildEditNotice p)
        {
            if (Stage != GameStage.Game) return;

            Player.GuildEditNotice(p);
        }
        public void Process(C.GuildEditMember p)
        {
            if (Stage != GameStage.Game) return;

            Player.GuildEditMember(p);
        }
        public void Process(C.GuildTax p)
        {
            if (Stage != GameStage.Game) return;

            Player.GuildTax(p);
        }
        public void Process(C.GuildIncreaseMember p)
        {
            if (Stage != GameStage.Game) return;

            Player.GuildIncreaseMember(p);
        }
        public void Process(C.GuildIncreaseStorage p)
        {
            if (Stage != GameStage.Game) return;

            Player.GuildIncreaseStorage(p);
        }
        public void Process(C.GuildInviteMember p)
        {
            if (Stage != GameStage.Game) return;

            Player.GuildInviteMember(p);
        }
        public void Process(C.GuildKickMember p)
        {
            if (Stage != GameStage.Game) return;

            Player.GuildKickMember(p);
        }
        public void Process(C.GuildResponse p)
        {
            if (Stage != GameStage.Game) return;

            if (p.Accept)
                Player.GuildJoin();

            Player.GuildInvitation = null;
        }
        public void Process(C.GuildWar p)
        {
            if (Stage != GameStage.Game) return;

            Player.GuildWar(p.GuildName);
        }
        public void Process(C.GuildRequestConquest p)
        {
            if (Stage != GameStage.Game) return;

            Player.GuildConquest(p.Index);
        }

        public void Process(C.QuestAccept p)
        {
            if (Stage != GameStage.Game) return;

            Player.QuestAccept(p.Index);
        }
        public void Process(C.QuestComplete p)
        {
            if (Stage != GameStage.Game) return;

            Player.QuestComplete(p);
        }
        public void Process(C.QuestTrack p)
        {
            if (Stage != GameStage.Game) return;

            Player.QuestTrack(p);
        }

        public void Process(C.MeiriQuestAccept p)
        {
            if (Stage != GameStage.Game) return;

            Player.MeiriQuestAccept(p.Index);
        }
        public void Process(C.MeiriQuestComplete p)
        {
            if (Stage != GameStage.Game) return;

            Player.MeiriQuestComplete(p);
        }
        public void Process(C.MeiriQuestTrack p)
        {
            if (Stage != GameStage.Game) return;

            Player.MeiriQuestTrack(p);
        }
        public void Process(C.MeiriDailyRandomQuestGain p)
        {
            if (Stage == GameStage.Game)
            {
                Player.MeiriQuestDailyRandomGained();
            }
        }

        public void Process(C.MeiriDailyRandomQuestReset p)
        {
            if (Stage == GameStage.Game)
            {
                Player.MeiriQuestDailyRandomReset();
            }
        }

        public void Process(C.CompanionUnlock p)
        {
            if (Stage != GameStage.Game) return;

            Player.CompanionUnlock(p.Index);
        }
        public void Process(C.CompanionAdopt p)
        {
            if (Stage != GameStage.Game) return;

            Player.CompanionAdopt(p);
        }
        public void Process(C.CompanionRetrieve p)
        {
            if (Stage != GameStage.Game) return;

            Player.CompanionRetrieve(p.Index);
        }

        public void Process(C.CompanionStore p)
        {
            if (Stage != GameStage.Game) return;

            Player.CompanionStore(p.Index);
        }
        public void Process(C.HorseUnlock p)
        {
            if (Stage == GameStage.Game)
            {
                Player.HorseUnlock(p.Index);
            }
        }

        public void Process(C.HorseAdopt p)
        {
            if (Stage == GameStage.Game)
            {
                Player.HorseAdopt(p);
            }
        }
        public void Process(C.HorseRetrieve p)
        {
            if (Stage == GameStage.Game)
            {
                Player.HorseRetrieve(p.Index);
            }
        }
        public void Process(C.HorseStore p)
        {
            if (Stage == GameStage.Game)
            {
                Player.HorseStore(p.Index);
            }
        }

        public void Process(C.MarriageResponse p)
        {
            if (Stage != GameStage.Game) return;

            if (p.Accept)
                Player.MarriageJoin();

            Player.MarriageInvitation = null;
        }
        public void Process(C.MarriageMakeRing p)
        {
            if (Stage != GameStage.Game) return;

            Player.MarriageMakeRing(p.Slot);

        }
        public void Process(C.MoveTeleport p)
        {
            if (Stage != GameStage.Game) return;

            Player.MoveTeleport();
        }
        public void Process(C.MarriageTeleport p)
        {
            if (Stage != GameStage.Game) return;

            Player.MarriageTeleport();
        }

        public void Process(C.BlockAdd p)
        {
            if (Stage != GameStage.Game && Stage != GameStage.Observer) return;

            if (Account == null) return;

            CharacterInfo info = SEnvir.GetCharacter(p.Name);

            if (info == null)
            {
                ReceiveChat(string.Format(Language.CannotFindPlayer, p.Name), MessageType.System);

                return;
            }

            foreach (BlockInfo blockInfo in Account.BlockingList)
            {
                if (blockInfo.BlockedAccount == info.Account)
                {
                    ReceiveChat(string.Format(Language.AlreadyBlocked, p.Name), MessageType.System);
                    return;
                }
            }

            BlockInfo block = SEnvir.BlockInfoList.CreateNewObject();

            block.Account = Account;
            block.BlockedAccount = info.Account;
            block.BlockedName = info.CharacterName;

            Enqueue(new S.BlockAdd { Info = block.ToClientInfo(), ObserverPacket = false });
        }
        public void Process(C.BlockRemove p)
        {
            if (Stage != GameStage.Game && Stage != GameStage.Observer) return;

            BlockInfo block = Account?.BlockingList.FirstOrDefault(x => x.Index == p.Index);

            if (block == null) return;

            block.Delete();

            Enqueue(new S.BlockRemove { Index = p.Index, ObserverPacket = false });
        }

        
        public void Process(C.ShizhuangToggle p)
        {
            if (Stage != GameStage.Game) return;

            Player.ShizhuangToggle(p.HideShizhuang);
        }

        
        public void Process(C.HelmetToggle p)
        {
            if (Stage != GameStage.Game) return;

            Player.HelmetToggle(p.HideHelmet);
        }

        
        public void Process(C.DunToggle p)
        {
            if (Stage != GameStage.Game) return;

            Player.DunToggle(p.Dun);
        }
        
        public void Process(C.GenderChange p)
        {
            if (Stage != GameStage.Game) return;

            
            Player.GenderChange(p);
        }
        
        public void Process(C.ClassChange p)
        {
            if (Stage != GameStage.Game) return;


            Player.ClassChange(p);
        }
        public void Process(C.HairChange p)
        {
            if (Stage != GameStage.Game) return;


            Player.HairChange(p);

        }
        public void Process(C.ArmourDye p)
        {
            if (Stage != GameStage.Game) return;


            Player.ArmourDye(p.ArmourColour);
        }
        public void Process(C.NameChange p)
        {
            if (Stage != GameStage.Game) return;

            
            Player.NameChange(p.Name);
        }

        public void Process(C.FortuneCheck p)
        {
            if (Stage != GameStage.Game) return;
            
            Player.FortuneCheck(p.ItemIndex);
        }
        public void Process(C.TeleportRing p)
        {
            if (Stage != GameStage.Game) return;

            Player.TeleportRing(p.Location, p.Index);

        }
        public void Process(C.JoinStarterGuild p)
        {
            if (Stage != GameStage.Game) return;

            Player.JoinStarterGuild();

        }
        public void Process(C.NPCAccessoryReset p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCAccessoryReset(p);
        }
        
        public void Process(C.NPCDunReset p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCDunReset(p);
        }
        
        public void Process(C.NPCHuiReset p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCHuiReset(p);
        }

        public void Process(C.NPCWeaponCraft p)
        {
            if (Stage != GameStage.Game) return;

            Player.NPCWeaponCraft(p);
        }
        public void Process(TreasureSelect p)
        {
            if (Stage != GameStage.Game)
                return;
            Player.SelectTrea(p);
        }

        public void Process(TreasureChange p)
        {
            if (Stage != GameStage.Game)
                return;
            Player.ChangeTrea(p);
        }

        public void Process(C.CraftInformation p)
        {
            if (Stage == GameStage.Game)
            {
                Player.CraftInformation();
            }
        }

        public void Process(CraftItem p)
        {
            if (Stage == GameStage.Game)
            {
                Player.CraftItem(p);
            }
        }

        
        public void Process(StartMiniGame p)
        {
            if (Stage == GameStage.Game)
            {
                Player.StartMiniGame(p);
            }
        }

    }


    public enum GameStage
    {
        None,
        Login,
        Select,
        Game,
        Observer,
        Disconnected,
    }
}
