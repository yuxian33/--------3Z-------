using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Library;
using Library.Network;
using Library.SystemModels;
using CartoonMirDB;
using Server.DBModels;
using Server.Envir;
using S = Library.Network.ServerPackets;


namespace Server.Models
{
    public class NPCObject : MapObject
    {

        public int AliveCount;

        public override ObjectType Race => ObjectType.NPC;

        public NPCInfo NPCInfo;

        public override string Name => NPCInfo.NPCName;

        public static DBCollection<MapInfo> MapInfoList;

        public override bool Blocking => Visible;

        public CharacterInfo Character;

        public SConnection Connection;

        public Map AddObject;
        public PlayerObject player;

        public List<MonsterObject> MinionList = new List<MonsterObject>();

        public void NPCCall(PlayerObject ob, NPCPage page)
        {
            while (true)
            {
                if (page == null) return;
                NPCPage failPage;
                if (!CheckPage(ob, page, out failPage))
                {
                    page = failPage;
                    continue;
                }

                DoActions(ob, page);

                if (page.SuccessPage != null)
                {
                    page = page.SuccessPage;
                    continue;
                }

                if (string.IsNullOrEmpty(page.Say))
                {
                    ob.NPC = null;
                    ob.NPCPage = null;
                    ob.Enqueue(new S.NPCClose());
                    return;
                }

                ob.NPC = this;
                ob.NPCPage = page;

                ob.Enqueue(new S.NPCResponse { ObjectID = ObjectID, Index = page.Index });
                break;
            }
        }

        private void DoActions(PlayerObject ob, NPCPage page)
        {
            foreach (NPCAction action in page.Actions)
            {
                
                
                string tempString = string.Empty;
                string fileName = null;
                switch (action.ActionType)
                {
                    case NPCActionType.Teleport:
                        if (action.MapParameter1 == null) return;

                        Map map = SEnvir.GetMap(action.MapParameter1);

                        if (action.IntParameter1 == 0 && action.IntParameter2 == 0)
                            ob.Teleport(map, map.GetRandomLocation());
                        else
                            ob.Teleport(map, new Point(action.IntParameter1, action.IntParameter2));
                        break;
                    case NPCActionType.TakeGold:
                        ob.Gold -= action.IntParameter1;
                        ob.GoldChanged();
                        break;
                    case NPCActionType.ChangeElement:
                        UserItem weapon = ob.Equipment[(int)EquipmentSlot.Weapon];

                        S.ItemStatsChanged result = new S.ItemStatsChanged { GridType = GridType.Equipment, Slot = (int)EquipmentSlot.Weapon, NewStats = new Stats() };
                        result.NewStats[Stat.WeaponElement] = action.IntParameter1 - weapon.Stats[Stat.WeaponElement];

                        weapon.AddStat(Stat.WeaponElement, action.IntParameter1 - weapon.Stats[Stat.WeaponElement], StatSource.Refine);
                        weapon.StatsChanged();
                        ob.RefreshStats();

                        ob.Enqueue(result);
                        break;
                    case NPCActionType.ChangeHorse:
                        ob.Character.Account.Horse = (HorseType)action.IntParameter1;

                        ob.RemoveMount();

                        ob.RefreshStats();

                        if (ob.Character.Account.Horse != HorseType.None) ob.Mount();
                        break;
                    case NPCActionType.GiveGold:

                        long gold = ob.Gold + action.IntParameter1;
                        if (gold <= CartoonGlobals.MaxGold)
                        {
                            ob.Gold = gold;
                        }
                        else
                        {
                            MailInfo newObject1 = SEnvir.MailInfoList.CreateNewObject();

                            newObject1.Account = ob.Character.Account;
                            newObject1.Subject = "NPC";
                            newObject1.Sender = "Admin";
                            ItemInfo freshItem1 = SEnvir.GetItemInfo("金币");
                            UserItem freshItem2 = SEnvir.CreateFreshItem(freshItem1);

                            freshItem2.Count = gold - CartoonGlobals.MaxGold;
                            string str2 = "金币";
                            freshItem2.Mail = newObject1;
                            freshItem2.Slot = 0;
                            newObject1.Message = "多余金币邮寄的信息\n\n" + string.Format("你向NPC出售物品的金币，能放的金币放完包裹后，将多余的部分，包裹中的金币数量超出了最大金币范围原因，邮寄发给你了: 多余的{0} x{1}\n", (object)str2, (object)freshItem2.Count);
                            newObject1.HasItem = true;
                            if (ob.Character.Account.Connection?.Player != null)
                            {
                                SConnection connection = ob.Character.Account.Connection;
                                S.MailNew mailNew = new S.MailNew();
                                mailNew.Mail = newObject1.ToClientInfo();
                                mailNew.ObserverPacket = false;
                                connection.Enqueue(mailNew);
                            }
                            if (InSafeZone)
                            {
                                if (ob.CanGainItems(false, new ItemCheck(freshItem2, freshItem2.Count, freshItem2.Flags, freshItem2.ExpireTime)))
                                {
                                    ob.GainItem(freshItem2);
                                }
                            }
                            ob.Gold = CartoonGlobals.MaxGold;
                        }
                        ob.GoldChanged();
                        /*
                        if (!ob.Character.ZidongJinpiao)
                        {
                            if (ob.Gold < 500000000) return;
                            if (ob.Gold >= 500000000 && ob.Gold < 1000000000)
                            {
                                ItemInfo jinpiao = SEnvir.GetItemInfo("金票");
                                UserItemFlags flags = UserItemFlags.Locked;
                                ItemCheck checkem = new ItemCheck(jinpiao, 1, flags, TimeSpan.Zero);

                                if (!ob.CanGainItems(true, checkem))
                                {
                                    ob.Connection.ReceiveChat("背包空间不足", MessageType.System);
                                    foreach (SConnection con4 in ob.Connection.Observers)
                                    {
                                        con4.ReceiveChat("背包空间不足", MessageType.System);
                                    }
                                    return;
                                }
                                ob.Character.Account.Gold -= 500000000;
                                ob.GainItem(SEnvir.CreateFreshItem(checkem));
                                ob.GoldChanged();
                            }
                            else if (ob.Gold >= 1000000000)
                            {
                                ItemInfo jinpiao = SEnvir.GetItemInfo("金票");
                                UserItemFlags flags = UserItemFlags.Locked;
                                ItemCheck checkemm = new ItemCheck(jinpiao, 2, flags, TimeSpan.Zero);

                                if (!ob.CanGainItems(true, checkemm))
                                {
                                    ob.Connection.ReceiveChat("背包空间不足", MessageType.System);
                                    foreach (SConnection con4 in ob.Connection.Observers)
                                    {
                                        con4.ReceiveChat("背包空间不足", MessageType.System);
                                    }
                                    return;
                                }
                                ob.Character.Account.Gold -= 1000000000;
                                ob.GainItem(SEnvir.CreateFreshItem(checkemm));
                                ob.GoldChanged();
                            }
                        }
                        */

                        break;
                    case NPCActionType.Marriage:
                        ob.MarriageRequest();
                        break;
                    case NPCActionType.Divorce:
                        ob.MarriageLeave();
                        break;
                    case NPCActionType.RemoveWeddingRing:
                        ob.MarriageRemoveRing();
                        break;
                    case NPCActionType.GiveItem:
                        if (action.ItemParameter1 == null) continue;

                        ItemCheck check = new ItemCheck(action.ItemParameter1, action.IntParameter1, UserItemFlags.None, TimeSpan.Zero);

                        if (!ob.CanGainItems(false, check)) continue;

                        while (check.Count > 0)
                            ob.GainItem(SEnvir.CreateFreshItem(check));

                        break;
                    case NPCActionType.TakeItem:
                        if (action.ItemParameter1 == null) continue;

                        ob.TakeItem(action.ItemParameter1, action.IntParameter1);
                        break;
                    case NPCActionType.ResetWeapon:
                        ob.NPCResetWeapon();
                        break;
                    case NPCActionType.GiveItemExperience:
                        if (action.ItemParameter1 == null) continue;

                        check = new ItemCheck(action.ItemParameter1, action.IntParameter1, UserItemFlags.None, TimeSpan.Zero);

                        if (!ob.CanGainItems(false, check)) continue;

                        while (check.Count > 0)
                        {
                            UserItem item = SEnvir.CreateFreshItem(check);

                            item.Experience = action.IntParameter2;

                            if (item.Experience >= CartoonGlobals.AccessoryExperienceList[item.Level])
                            {
                                item.Experience -= CartoonGlobals.AccessoryExperienceList[item.Level];
                                item.Level++;

                                item.Flags |= UserItemFlags.Refinable;
                            }

                            ob.GainItem(item);
                        }

                        break;
                    case NPCActionType.SpecialRefine:
                        ob.NPCSpecialRefine(action.StatParameter1, action.IntParameter1);
                        break;
                    case NPCActionType.Rebirth:
                        if (Config.是否开启留级转生)
                        {
                            if (ob.Level >= 86 + (ob.Character.Rebirth * 3))
                                ob.NPCRebirth();
                        }
                        else
                        {
                            if (ob.Level >= 86 + ob.Character.Rebirth)
                                ob.NPCRebirth();
                        }
                        break;
                    /*
                case NPCActionType.PlayerTeleport:
                    if (action.MapParameter1 == null) return;

                    Map map2 = SEnvir.GetMap(action.MapParameter1);
                    if (map2.Players.Count > 0) return;

                    if (map2.Players.Count == 0)
                    {
                        if (action.IntParameter1 == 0 && action.IntParameter2 == 0)
                            ob.Teleport(map2, map2.GetRandomLocation());
                        else
                            ob.Teleport(map2, new Point(action.IntParameter1, action.IntParameter2));
                        break;
                    }
                    break;
                case NPCActionType.BoosTeleport:
                    if (action.MapParameter1 == null) return;

                    Map map3 = SEnvir.GetMap(action.MapParameter1);
                    if (map3.Bosses.Count == 0) return;
                    if (map3.Bosses.Count > 0)
                    {
                        if (action.IntParameter1 == 0 && action.IntParameter2 == 0)
                            ob.Teleport(map3, map3.GetRandomLocation());
                        else
                            ob.Teleport(map3, new Point(action.IntParameter1, action.IntParameter2));
                        break;
                    }
                    break;
                case NPCActionType.MonGenb:
                    if (action.MapParameter1 == null || action.MonsterParameter1 == null) return;
                    MonsterObject monster1 = MonsterObject.GetMonster(action.MonsterParameter1);
                    Map monmap1 = SEnvir.GetMap(action.MapParameter1);
                    if (monster1 != null)
                    {
                        monster1.DropSet = action.DropSet1;
                        monster1.Direction = 0;
                        if(action.IntParameter1 == 0 && action.IntParameter2 == 0)
                            monster1.Spawn(action.MapParameter1, monmap1.GetRandomLocation(CurrentLocation, 400));
                        else
                        monster1.Spawn(action.MapParameter1, new Point(action.IntParameter1, action.IntParameter2));
                    }
                    break;
                case NPCActionType.MonGeni:
                    if (action.MapParameter1 == null || action.MonsterParameter1 == null) return;
                    MonsterObject monster2 = MonsterObject.GetMonster(action.MonsterParameter1);
                    Map monmap2 = SEnvir.GetMap(action.MapParameter1);
                    if (monster2 != null)
                    {
                        monster2.DropSet = action.DropSet2;
                        monster2.Direction = 0;
                        if (action.IntParameter1 == 0 && action.IntParameter2 == 0)
                            monster2.Spawn(action.MapParameter1, monmap2.GetRandomLocation(CurrentLocation, 400));
                        else
                            monster2.Spawn(action.MapParameter1, new Point(action.IntParameter1, action.IntParameter2));
                    }
                    break;
                case NPCActionType.MonGenu:
                    if (action.MapParameter1 == null || action.MonsterParameter1 == null) return;
                    MonsterObject monster3 = MonsterObject.GetMonster(action.MonsterParameter1);
                    Map monmap3 = SEnvir.GetMap(action.MapParameter1);
                    if (monster3 != null)
                    {
                        monster3.DropSet = action.DropSet3;
                        monster3.Direction = 0;
                        if (action.IntParameter1 == 0 && action.IntParameter2 == 0)
                            monster3.Spawn(action.MapParameter1, monmap3.GetRandomLocation(CurrentLocation, 400));
                        else
                            monster3.Spawn(action.MapParameter1, new Point(action.IntParameter1, action.IntParameter2));
                    }
                    break;
                case NPCActionType.MonGent:
                    if (action.MapParameter1 == null || action.MonsterParameter1 == null) return;
                    MonsterObject monster4 = MonsterObject.GetMonster(action.MonsterParameter1);
                    Map monmap4 = SEnvir.GetMap(action.MapParameter1);
                    if (monster4 != null)
                    {
                        monster4.DropSet = action.DropSet4;
                        monster4.Direction = 0;
                        if (action.IntParameter1 == 0 && action.IntParameter2 == 0)
                            monster4.Spawn(action.MapParameter1, monmap4.GetRandomLocation(CurrentLocation, 400));
                        else
                            monster4.Spawn(action.MapParameter1, new Point(action.IntParameter1, action.IntParameter2));
                    }
                    break;
                    */
                    case NPCActionType.MonGen:
                        if (action.MapParameter1 == null || action.MonsterParameter1 == null) return;
                        MonsterObject monster5 = MonsterObject.GetMonster(action.MonsterParameter1);
                        Map monmap5 = SEnvir.GetMap(action.MapParameter1);
                        if (monster5 != null)
                        {
                            monster5.DropSet = action.DropSet1;
                            monster5.Direction = 0;
                            if (action.IntParameter1 == 0 && action.IntParameter2 == 0)
                                monster5.Spawn(action.MapParameter1, monmap5.GetRandomLocation(CurrentLocation, 400));
                            else
                                monster5.Spawn(action.MapParameter1, new Point(action.IntParameter1, action.IntParameter2));
                        }
                        break;
                    case NPCActionType.MonGenCountb:
                        {
                            if (action.MonsterParameter1 == null || action.MapParameter1 == null) return;
                            for (int i = AliveCount; i < action.Count1; i++)
                            {
                                MonsterObject mobcountmob1 = MonsterObject.GetMonster(action.MonsterParameter1);
                                Map mobcountmap1 = SEnvir.GetMap(action.MapParameter1);
                                mobcountmob1.Spawn(action.MapParameter1, mobcountmap1.GetRandomLocation(CurrentLocation, 400));
                                mobcountmob1.DropSet = action.DropSet1;
                                AliveCount++;
                            }
                        }
                        break;
                    case NPCActionType.MonGenCounti:
                        {
                            if (action.MonsterParameter1 == null || action.MapParameter1 == null) return;
                            for (int j = AliveCount; j < action.Count2; j++)
                            {
                                MonsterObject mobcountmob2 = MonsterObject.GetMonster(action.MonsterParameter1);
                                Map mobcountmap2 = SEnvir.GetMap(action.MapParameter1);
                                mobcountmob2.Spawn(action.MapParameter1, mobcountmap2.GetRandomLocation(CurrentLocation, 400));
                                mobcountmob2.DropSet = action.DropSet2;
                                AliveCount++;
                            }
                        }
                        break;
                    case NPCActionType.MonGenCountu:
                        {
                            if (action.MonsterParameter1 == null || action.MapParameter1 == null) return;
                            for (int u = AliveCount; u < action.Count3; u++)
                            {
                                MonsterObject mobcountmob3 = MonsterObject.GetMonster(action.MonsterParameter1);
                                Map mobcountmap3 = SEnvir.GetMap(action.MapParameter1);
                                mobcountmob3.Spawn(action.MapParameter1, mobcountmap3.GetRandomLocation(CurrentLocation, 400));
                                mobcountmob3.DropSet = action.DropSet3;
                                AliveCount++;
                            }
                        }
                        break;
                    case NPCActionType.MonGenCountt:
                        {
                            if (action.MonsterParameter1 == null || action.MapParameter1 == null) return;
                            for (int n = AliveCount; n < action.Count4; n++)
                            {
                                MonsterObject mobcountmob4 = MonsterObject.GetMonster(action.MonsterParameter1);
                                Map mobcountmap4 = SEnvir.GetMap(action.MapParameter1);
                                mobcountmob4.Spawn(action.MapParameter1, mobcountmap4.GetRandomLocation(CurrentLocation, 400));
                                mobcountmob4.DropSet = action.DropSet4;
                                AliveCount++;
                            }
                        }
                        break;
                    case NPCActionType.MonGenCountbax:
                        {
                            if (action.MonsterParameter1 == null || action.MapParameter1 == null) return;
                            for (int t = AliveCount; t < action.Count5; t++)
                            {
                                MonsterObject mobcountmob5 = MonsterObject.GetMonster(action.MonsterParameter1);
                                Map mobcountmap5 = SEnvir.GetMap(action.MapParameter1);
                                mobcountmob5.Spawn(action.MapParameter1, mobcountmap5.GetRandomLocation(CurrentLocation, 400));
                                mobcountmob5.DropSet = action.DropSet5;
                                AliveCount++;
                            }
                        }
                        break;
                    case NPCActionType.CreateNpc:
                        if (action.Count1 == 0 || action.MapParameter1 == null || action.IntParameter1 == 0 || action.IntParameter2 == 0) return;
                        NPCInfo npcInfo = SEnvir.GetNpcInfo(action.Count1);
                        Map npcmap = SEnvir.GetMap(action.MapParameter1);
                        if (npcInfo != null && npcmap != null)
                        {
                            new NPCObject() { NPCInfo = npcInfo }.Spawn(action.MapParameter1, new Point(action.IntParameter1, action.IntParameter2));
                        }
                        break;
                    case NPCActionType.CreateMap:
                        if (action.Count1 == 0) return;
                        Map createmap = SEnvir.CreateMaps(action.Count1);
                        if (createmap != null)
                        {
                            if (createmap.Players.Count > 0) return;

                            if (createmap.Players.Count == 0)
                            {
                                SEnvir.CloseMap(action.MapParameter1);
                            }
                            if (action.IntParameter1 == 0 && action.IntParameter2 == 0)
                                ob.Teleport(createmap, createmap.GetRandomLocation());
                            else
                                ob.Teleport(createmap, new Point(action.IntParameter1, action.IntParameter2));
                            break;
                        }
                        break;
                    case NPCActionType.GroupRecall:
                        if (ob.GroupMembers == null) return;

                        for (int j = 0; j < ob.GroupMembers.Count(); j++)
                        {
                            ob.GroupMembers[j].Teleport(ob.CurrentMap, ob.CurrentLocation);
                        }
                        break;
                    case NPCActionType.GroupTeleportDT:
                        if (ob.GroupMembers == null || action.Count1 == 0) return;
                        Map grouptelmap = SEnvir.CreateMaps(action.Count1);
                        if (grouptelmap == null) return;
                        for (int j = 0; j < ob.GroupMembers.Count(); j++)
                        {
                            if (action.IntParameter1 == 0 && action.IntParameter2 == 0)
                                ob.GroupMembers[j].Teleport(grouptelmap, ob.CurrentLocation);
                            else
                                ob.GroupMembers[j].Teleport(grouptelmap, new Point(action.IntParameter1, action.IntParameter2));
                        }
                        break;
                    case NPCActionType.AddNameList:
                        if (action.StringParameter1 == null) return;
                        if (action.IntParameter1 == 0)
                        {
                            fileName = Path.Combine(SEnvir.NameListPath, action.StringParameter1 + ".txt");
                        }
                        else if (action.IntParameter1 == 1)
                        {
                            fileName = Path.Combine(SEnvir.YueNameListPath, action.StringParameter1 + ".txt");
                        }
                        if (!File.Exists(fileName))
                            File.Create(fileName);
                        if (File.ReadAllLines(fileName).All(t => ob.Name != t))
                        {
                            using (var line = File.AppendText(fileName))
                            {
                                line.WriteLine(ob.Name);
                            }
                        }
                        break;
                    case NPCActionType.DelNameList:
                        if (action.StringParameter1 == null) return;
                        if (action.IntParameter1 == 0)
                            fileName = Path.Combine(SEnvir.NameListPath, action.StringParameter1 + ".txt");
                        else if (action.IntParameter1 == 1)
                            fileName = Path.Combine(SEnvir.YueNameListPath, action.StringParameter1 + ".txt");
                        if (File.Exists(fileName))
                            File.WriteAllLines(fileName, File.ReadLines(fileName).Where(l => l != ob.Name).ToList());
                        break;
                    case NPCActionType.ClearNameList:
                        if (action.StringParameter1 == null) return;
                        fileName = Path.Combine(SEnvir.NameListPath, action.StringParameter1 + ".txt");
                        if (File.Exists(fileName))
                            File.WriteAllLines(fileName, new string[] { });
                        break;
                    case NPCActionType.GiveLvExp:
                        
                        
                        if (action.Count5 == 0 && action.IntParameter1 == 0 && action.Count4 == 0) return;
                        int intamount = ob.Level * action.IntParameter1;
                        long longamount = ob.Level * action.Count4;
                        decimal percentExp = ob.MaxExperience * action.Count5 / 10000;
                        if (action.IntParameter1 > 0)
                        {
                            ob.GainExperience(intamount, false, int.MaxValue, false);
                        }
                        else if (action.Count4 > 0)
                        {
                            ob.GainExperience(longamount, false, int.MaxValue, false);
                        }
                        else if (action.Count5 > 0)
                        {
                            ob.GainExperience(percentExp, false, int.MaxValue, false);
                        }
                        break;
                    case NPCActionType.GroupAddNameLists:
                        if (action.StringParameter1 == null || ob.GroupMembers == null) return;
                        fileName = Path.Combine(SEnvir.NameListPath, action.StringParameter1 + ".txt");
                        if (!File.Exists(fileName))
                            File.Create(fileName);
                        for (int j = 0; j < ob.GroupMembers.Count(); j++)
                        {
                            if (File.ReadAllLines(fileName).All(t => ob.GroupMembers[j].Name != t))
                            {
                                using (var line = File.AppendText(fileName))
                                {
                                    line.WriteLine(ob.GroupMembers[j].Name);
                                }
                            }
                        }
                        break;
                    case NPCActionType.AddEMailList:
                        if (action.StringParameter1 == null) return;
                        if (action.IntParameter1 == 0)
                        {
                            fileName = Path.Combine(SEnvir.NameListPath, action.StringParameter1 + ".txt");
                        }
                        else if (action.IntParameter1 == 1)
                        {
                            fileName = Path.Combine(SEnvir.YueNameListPath, action.StringParameter1 + ".txt");
                        }
                        if (!File.Exists(fileName))
                            File.Create(fileName);
                        if (File.ReadAllLines(fileName).All(t => ob.Character.Account.EMailAddress != t))
                        {
                            using (var line = File.AppendText(fileName))
                            {
                                line.WriteLine(ob.Character.Account.EMailAddress);
                            }
                        }
                        break;
                    case NPCActionType.ClearGroup:
                        if (ob.GroupMembers == null) return;
                        ob.GroupRemove(ob.Name);
                        break;
                    case NPCActionType.GiveLvGold:

                        if (action.IntParameter1 == 0) return;
                        int goldamonut = ob.Level * action.IntParameter1;
                        long givelvgold = ob.Gold + goldamonut;

                        if (givelvgold <= CartoonGlobals.MaxGold)
                        {
                            ob.Gold = givelvgold;
                        }
                        else
                        {
                            MailInfo newObject1 = SEnvir.MailInfoList.CreateNewObject();

                            newObject1.Account = ob.Character.Account;
                            newObject1.Subject = "NPC";
                            newObject1.Sender = "Admin";
                            ItemInfo freshItem1 = SEnvir.GetItemInfo("金币");
                            UserItem freshItem2 = SEnvir.CreateFreshItem(freshItem1);

                            freshItem2.Count = givelvgold - CartoonGlobals.MaxGold;
                            string str2 = "金币";
                            freshItem2.Mail = newObject1;
                            freshItem2.Slot = 0;
                            newObject1.Message = "多余金币邮寄的信息\n\n" + string.Format("你向NPC出售物品的金币，能放的金币放完包裹后，将多余的部分，包裹中的金币数量超出了最大金币范围原因，邮寄发给你了: 多余的{0} x{1}\n", (object)str2, (object)freshItem2.Count);
                            newObject1.HasItem = true;
                            if (ob.Character.Account.Connection?.Player != null)
                            {
                                SConnection connection = ob.Character.Account.Connection;
                                S.MailNew mailNew = new S.MailNew();
                                mailNew.Mail = newObject1.ToClientInfo();
                                mailNew.ObserverPacket = false;
                                connection.Enqueue(mailNew);
                            }
                            if (InSafeZone)
                            {
                                if (ob.CanGainItems(false, new ItemCheck(freshItem2, freshItem2.Count, freshItem2.Flags, freshItem2.ExpireTime)))
                                {
                                    ob.GainItem(freshItem2);
                                }
                            }
                            ob.Gold = CartoonGlobals.MaxGold;
                        }
                        ob.GoldChanged();
                        /*
                        if (!ob.Character.ZidongJinpiao)
                        {
                            if (ob.Gold < 500000000) return;
                            if (ob.Gold >= 500000000 && ob.Gold < 1000000000)
                            {
                                ItemInfo jinpiao = SEnvir.GetItemInfo("金票");
                                UserItemFlags flags = UserItemFlags.Locked;
                                ItemCheck checkem = new ItemCheck(jinpiao, 1, flags, TimeSpan.Zero);

                                if (!ob.CanGainItems(true, checkem))
                                {
                                    ob.Connection.ReceiveChat("背包空间不足", MessageType.System);
                                    foreach (SConnection con4 in ob.Connection.Observers)
                                    {
                                        con4.ReceiveChat("背包空间不足", MessageType.System);
                                    }
                                    return;
                                }
                                ob.Character.Account.Gold -= 500000000;
                                ob.GainItem(SEnvir.CreateFreshItem(checkem));
                                ob.GoldChanged();
                            }
                            else if (ob.Gold >= 1000000000)
                            {
                                ItemInfo jinpiao = SEnvir.GetItemInfo("金票");
                                UserItemFlags flags = UserItemFlags.Locked;
                                ItemCheck checkemm = new ItemCheck(jinpiao, 2, flags, TimeSpan.Zero);

                                if (!ob.CanGainItems(true, checkemm))
                                {
                                    ob.Connection.ReceiveChat("背包空间不足", MessageType.System);
                                    foreach (SConnection con4 in ob.Connection.Observers)
                                    {
                                        con4.ReceiveChat("背包空间不足", MessageType.System);
                                    }
                                    return;
                                }
                                ob.Character.Account.Gold -= 1000000000;
                                ob.GainItem(SEnvir.CreateFreshItem(checkemm));
                                ob.GoldChanged();
                            }
                        }
                        */
                        break;
                    case NPCActionType.CurrentMapMonGen:
                        
                        if (CurrentMap == null) return;
                        MonsterObject monster = MonsterObject.GetMonster(action.MonsterParameter1);
                        if (monster == null) return;
                        if (action.IntParameter1 == 0 && action.IntParameter2 == 0)
                            monster.Spawn(CurrentMap.Info, CurrentMap.GetRandomLocation(CurrentLocation, 2));
                        else
                            monster.Spawn(CurrentMap.Info, new Point(action.IntParameter1, action.IntParameter2));
                        break;
                    case NPCActionType.DelallNpc:
                        Map delallmap = CurrentMap;
                        foreach (var cell in delallmap.Cells)
                        {
                            if (cell == null || cell.Objects == null) continue;

                            int obCount = cell.Objects.Count();

                            for (int m = 0; m < obCount; m++)
                            {
                                MapObject delnpcob = cell.Objects[m];

                                if (delnpcob.Race != ObjectType.NPC) continue;
                                if (delnpcob.Dead) continue;
                                delnpcob.Die();
                                delnpcob.Despawn();
                            }
                        }
                        break;
                    case NPCActionType.GiveBuff:
                        if (action.IntParameter1 == 0 && action.IntParameter2 == 0) return;
                        Stats stats = new Stats();
                        if (CurrentMap == null) return;
                        switch (action.IntParameter1)
                        {
                            case 1:
                                ob.BuffAdd(BuffType.RWBuffyi, TimeSpan.FromMinutes(action.IntParameter2), stats, false, false, TimeSpan.Zero);
                                break;
                            case 2:
                                ob.BuffAdd(BuffType.RWBuffer, TimeSpan.FromMinutes(action.IntParameter2), stats, false, false, TimeSpan.Zero);
                                break;
                            case 3:
                                ob.BuffAdd(BuffType.RWBuffsan, TimeSpan.FromMinutes(action.IntParameter2), stats, false, false, TimeSpan.Zero);
                                break;
                            case 4:
                                ob.BuffAdd(BuffType.RWBuffsi, TimeSpan.FromMinutes(action.IntParameter2), stats, false, false, TimeSpan.Zero);
                                break;
                            case 5:
                                ob.BuffAdd(BuffType.RWBuffwu, TimeSpan.FromMinutes(action.IntParameter2), stats, false, false, TimeSpan.Zero);
                                break;
                            case 6:
                                ob.BuffAdd(BuffType.RWBuffliu, TimeSpan.FromMinutes(action.IntParameter2), stats, false, false, TimeSpan.Zero);
                                break;
                            case 7:
                                ob.BuffAdd(BuffType.RWBuffqi, TimeSpan.FromMinutes(action.IntParameter2), stats, false, false, TimeSpan.Zero);
                                break;
                            case 8:
                                ob.BuffAdd(BuffType.RWBuffba, TimeSpan.FromMinutes(action.IntParameter2), stats, false, false, TimeSpan.Zero);
                                break;
                            case 9:
                                ob.BuffAdd(BuffType.RWBuffjiu, TimeSpan.FromMinutes(action.IntParameter2), stats, false, false, TimeSpan.Zero);
                                break;
                            case 10:
                                ob.BuffAdd(BuffType.RWBuffshi, TimeSpan.FromMinutes(action.IntParameter2), stats, false, false, TimeSpan.Zero);
                                break;
                        }
                        break;
                    case NPCActionType.ClearBuff:
                        if (action.IntParameter1 == 0) return;
                        switch (action.IntParameter1)
                        {
                            case 1:
                                ob.BuffRemove(BuffType.RWBuffyi);
                                break;
                            case 2:
                                ob.BuffRemove(BuffType.RWBuffer);
                                break;
                            case 3:
                                ob.BuffRemove(BuffType.RWBuffsan);
                                break;
                            case 4:
                                ob.BuffRemove(BuffType.RWBuffsi);
                                break;
                            case 5:
                                ob.BuffRemove(BuffType.RWBuffwu);
                                break;
                            case 6:
                                ob.BuffRemove(BuffType.RWBuffliu);
                                break;
                            case 7:
                                ob.BuffRemove(BuffType.RWBuffqi);
                                break;
                            case 8:
                                ob.BuffRemove(BuffType.RWBuffba);
                                break;
                            case 9:
                                ob.BuffRemove(BuffType.RWBuffjiu);
                                break;
                            case 10:
                                ob.BuffRemove(BuffType.RWBuffshi);
                                break;
                        }
                        break;
                    case NPCActionType.GroupTeleport:
                        if (ob.GroupMembers == null || action.MapParameter1 == null) return;
                        Map groupmap = SEnvir.GetMap(action.MapParameter1);
                        if (groupmap == null) return;
                        for (int j = 0; j < ob.GroupMembers.Count(); j++)
                        {
                            if (action.IntParameter1 == 0 && action.IntParameter2 == 0)
                                ob.GroupMembers[j].Teleport(groupmap, ob.CurrentLocation);
                            else
                                ob.GroupMembers[j].Teleport(groupmap, new Point(action.IntParameter1, action.IntParameter2));
                        }
                        break;
                    case NPCActionType.GroupAddEMailList:
                        if (action.StringParameter1 == null || ob.GroupMembers == null) return;
                        fileName = Path.Combine(SEnvir.NameListPath, action.StringParameter1 + ".txt");
                        if (!File.Exists(fileName))
                            File.Create(fileName);
                        for (int j = 0; j < ob.GroupMembers.Count(); j++)
                        {
                            if (File.ReadAllLines(fileName).All(t => ob.GroupMembers[j].Character.Account.EMailAddress != t))
                            {
                                using (var line = File.AppendText(fileName))
                                {
                                    line.WriteLine(ob.GroupMembers[j].Character.Account.EMailAddress);
                                }
                            }
                        }
                        break;
                    case NPCActionType.GiveShengwang:
                        
                        if (action.IntParameter1 == 0) return;

                        if (action.IntParameter1 > 0)
                        {
                            ob.GainedShengwang(action.IntParameter1, action.StringParameter1, false);
                        }
                        ob.GoldChanged();
                        break;
                    case NPCActionType.TakeShengwang:
                        
                        if (action.IntParameter1 == 0) return;

                        if (action.IntParameter1 > 0)
                        {
                            ob.GainedShengwang(-action.IntParameter1, action.StringParameter1, false);
                        }
                        ob.GoldChanged();
                        break;
                    case NPCActionType.GiveShangjin:
                        
                        if (action.IntParameter1 <= 0) return;

                        if (action.IntParameter1 > 0)
                        {
                            ob.Character.Account.HuntGold += action.IntParameter1;
                        }
                        ob.Enqueue(new S.HuntGoldChanged { HuntGold = ob.Character.Account.HuntGold });
                        break;
                    case NPCActionType.TakeShangjin:
                        
                        if (action.IntParameter1 <= 0) return;

                        if (action.IntParameter1 > 0)
                        {
                            ob.Character.Account.HuntGold -= action.IntParameter1;
                        }
                        ob.Enqueue(new S.HuntGoldChanged { HuntGold = ob.Character.Account.HuntGold });
                        break;
                    case NPCActionType.GiveYuanbao:
                        
                        if (action.IntParameter1 <= 0) return;

                        if (action.IntParameter1 > 0)
                        {
                            ob.Character.Account.GameGold += action.IntParameter1;
                        }
                        ob.Enqueue(new S.GameGoldChanged { GameGold = ob.Character.Account.GameGold });
                        break;
                    case NPCActionType.TakeYuanbao:
                        
                        if (action.IntParameter1 <= 0) return;

                        if (action.IntParameter1 > 0)
                        {
                            ob.Character.Account.GameGold -= action.IntParameter1;
                        }
                        ob.Enqueue(new S.GameGoldChanged { GameGold = ob.Character.Account.GameGold });
                        break;
                    case NPCActionType.TeleportGuildJidi:
                        
                        if (action.StringParameter1 == null || ob.Character.Account.GuildMember == null) return;
                        fileName = Path.Combine(SEnvir.GuildListPath, action.StringParameter1 + ".txt");
                        if (!File.Exists(fileName))
                            File.Create(fileName);
                        string[] lines = File.ReadAllLines(fileName);
                        int lineNumber = 0;
                        for (int i = 0; i < lines.Length; i++)
                            if (lines[i].Contains(ob.Character.Account.GuildMember.Guild.GuildName))
                            {
                                lineNumber = i + 1;
                                break;
                            }

                        if (lineNumber == 0)
                        {
                            return;
                        }
                        else if (lineNumber == 1)
                        {
                            ob.TeleportByMapIndex(700, 83, 23);
                            ob.Connection.ReceiveChat($"欢迎您来到{ob.Character.Account.GuildMember.Guild.GuildName}公会基地", MessageType.System);
                        }
                        else if (lineNumber == 2)
                        {
                            ob.TeleportByMapIndex(701, 83, 23);
                            ob.Connection.ReceiveChat($"欢迎您来到{ob.Character.Account.GuildMember.Guild.GuildName}公会基地", MessageType.System);
                        }
                        else if (lineNumber == 3)
                        {
                            ob.TeleportByMapIndex(702, 83, 23);
                            ob.Connection.ReceiveChat($"欢迎您来到{ob.Character.Account.GuildMember.Guild.GuildName}公会基地", MessageType.System);
                        }
                        else if (lineNumber == 4)
                        {
                            ob.TeleportByMapIndex(703, 83, 23);
                            ob.Connection.ReceiveChat($"欢迎您来到{ob.Character.Account.GuildMember.Guild.GuildName}公会基地", MessageType.System);
                        }
                        else if (lineNumber == 5)
                        {
                            ob.TeleportByMapIndex(704, 83, 23);
                            ob.Connection.ReceiveChat($"欢迎您来到{ob.Character.Account.GuildMember.Guild.GuildName}公会基地", MessageType.System);
                        }
                        else if (lineNumber == 6)
                        {
                            ob.TeleportByMapIndex(705, 83, 23);
                            ob.Connection.ReceiveChat($"欢迎您来到{ob.Character.Account.GuildMember.Guild.GuildName}公会基地", MessageType.System);
                        }
                        else if (lineNumber == 7)
                        {
                            ob.TeleportByMapIndex(706, 83, 23);
                            ob.Connection.ReceiveChat($"欢迎您来到{ob.Character.Account.GuildMember.Guild.GuildName}公会基地", MessageType.System);
                        }
                        else if (lineNumber == 8)
                        {
                            ob.TeleportByMapIndex(707, 83, 23);
                            ob.Connection.ReceiveChat($"欢迎您来到{ob.Character.Account.GuildMember.Guild.GuildName}公会基地", MessageType.System);
                        }
                        else if (lineNumber == 9)
                        {
                            ob.TeleportByMapIndex(708, 83, 23);
                            ob.Connection.ReceiveChat($"欢迎您来到{ob.Character.Account.GuildMember.Guild.GuildName}公会基地", MessageType.System);
                        }
                        else if (lineNumber == 10)
                        {
                            ob.TeleportByMapIndex(709, 83, 23);
                            ob.Connection.ReceiveChat($"欢迎您来到{ob.Character.Account.GuildMember.Guild.GuildName}公会基地", MessageType.System);
                        }
                        else if (lineNumber == 11)
                        {
                            ob.TeleportByMapIndex(710, 83, 23);
                            ob.Connection.ReceiveChat($"欢迎您来到{ob.Character.Account.GuildMember.Guild.GuildName}公会基地", MessageType.System);
                        }
                        else if (lineNumber == 12)
                        {
                            ob.TeleportByMapIndex(711, 83, 23);
                            ob.Connection.ReceiveChat($"欢迎您来到{ob.Character.Account.GuildMember.Guild.GuildName}公会基地", MessageType.System);
                        }
                        else if (lineNumber == 13)
                        {
                            ob.TeleportByMapIndex(712, 83, 23);
                            ob.Connection.ReceiveChat($"欢迎您来到{ob.Character.Account.GuildMember.Guild.GuildName}公会基地", MessageType.System);
                        }
                        else if (lineNumber == 14)
                        {
                            ob.TeleportByMapIndex(713, 83, 23);
                            ob.Connection.ReceiveChat($"欢迎您来到{ob.Character.Account.GuildMember.Guild.GuildName}公会基地", MessageType.System);
                        }
                        else if (lineNumber == 15)
                        {
                            ob.TeleportByMapIndex(714, 83, 23);
                            ob.Connection.ReceiveChat($"欢迎您来到{ob.Character.Account.GuildMember.Guild.GuildName}公会基地", MessageType.System);
                        }
                        else if (lineNumber == 16)
                        {
                            ob.TeleportByMapIndex(715, 83, 23);
                            ob.Connection.ReceiveChat($"欢迎您来到{ob.Character.Account.GuildMember.Guild.GuildName}公会基地", MessageType.System);
                        }
                        else if (lineNumber == 17)
                        {
                            ob.TeleportByMapIndex(716, 83, 23);
                            ob.Connection.ReceiveChat($"欢迎您来到{ob.Character.Account.GuildMember.Guild.GuildName}公会基地", MessageType.System);
                        }
                        else if (lineNumber == 18)
                        {
                            ob.TeleportByMapIndex(717, 83, 23);
                            ob.Connection.ReceiveChat($"欢迎您来到{ob.Character.Account.GuildMember.Guild.GuildName}公会基地", MessageType.System);
                        }
                        else if (lineNumber == 19)
                        {
                            ob.TeleportByMapIndex(718, 83, 23);
                            ob.Connection.ReceiveChat($"欢迎您来到{ob.Character.Account.GuildMember.Guild.GuildName}公会基地", MessageType.System);
                        }
                        else if (lineNumber >= 20)
                        {
                            ob.TeleportByMapIndex(719, 83, 23);
                            ob.Connection.ReceiveChat($"欢迎您来到{ob.Character.Account.GuildMember.Guild.GuildName}公会基地", MessageType.System);
                        }
                        break;
                    case NPCActionType.TakeGuildFunds:
                        
                        if (ob.Character.Account.GuildMember == null) return;
                        GuildInfo guild = ob.Character.Account.GuildMember.Guild;
                        guild.GuildFunds -= action.IntParameter1;
                        guild.DailyGrowth -= action.IntParameter1;

                        S.GuildUpdate update = ob.Character.Account.GuildMember.Guild.GetUpdatePacket();

                        foreach (GuildMemberInfo member in ob.Character.Account.GuildMember.Guild.Members)
                            member.Account.Connection?.Player?.Enqueue(update);
                        break;
                    case NPCActionType.AddGuildNameList:
                        
                        if (action.StringParameter1 == null || ob.Character.Account.GuildMember == null) return;
                        fileName = Path.Combine(SEnvir.NameListPath, action.StringParameter1 + ".txt");
                        if (!File.Exists(fileName))
                            File.Create(fileName);
                        if (File.ReadAllLines(fileName).All(t => ob.Character.Account.GuildMember.Guild.GuildName != t))
                        {
                            using (var line = File.AppendText(fileName))
                            {
                                line.WriteLine(ob.Character.Account.GuildMember.Guild.GuildName);
                            }
                        }
                        break;
                    case NPCActionType.DelGuildNameList:
                        
                        if (action.StringParameter1 == null || ob.Character.Account.GuildMember == null) return;
                        fileName = Path.Combine(SEnvir.NameListPath, action.StringParameter1 + ".txt");
                        if (File.Exists(fileName))
                            File.WriteAllLines(fileName, File.ReadLines(fileName).Where(l => l != ob.Character.Account.GuildMember.Guild.GuildName).ToList());
                        break;
                    case NPCActionType.ClearGuildNameList:
                        
                        if (action.StringParameter1 == null) return;
                        fileName = Path.Combine(SEnvir.NameListPath, action.StringParameter1 + ".txt");
                        if (File.Exists(fileName))
                            File.WriteAllLines(fileName, new string[] { });
                        break;
                    case NPCActionType.GuildBossMonGen:
                        
                        Map guildmonmap5 = SEnvir.GetMap(action.MapParameter1);
                        if (guildmonmap5.Bosses.Count == 0 && guildmonmap5.PlayerCount == 0)
                        {
                            if (action.MapParameter1 != null && action.MonsterParameter1 != null)
                            {
                                if (action.IntParameter1 == 0 && action.IntParameter2 == 0)
                                {
                                    new MonsterObject() { MonsterInfo = action.MonsterParameter1 }.Spawn(action.MapParameter1, guildmonmap5.GetRandomLocation(CurrentLocation, 400));
                                    foreach (GuildMemberInfo member in ob.Character.Account.GuildMember.Guild.Members)
                                        member.Account.Connection?.Player?.Connection.ReceiveChat(action.StringParameter1, MessageType.System);
                                }
                                else
                                {
                                    new MonsterObject() { MonsterInfo = action.MonsterParameter1 }.Spawn(action.MapParameter1, new Point(action.IntParameter1, action.IntParameter2));
                                    if (action.StringParameter1 == null) return;
                                    foreach (GuildMemberInfo member in ob.Character.Account.GuildMember.Guild.Members)
                                        member.Account.Connection?.Player?.Connection.ReceiveChat(action.StringParameter1, MessageType.System);
                                }
                            }

                            GuildInfo guildboss = ob.Character.Account.GuildMember.Guild;
                            guildboss.GuildBosshd01 = 2;

                            S.GuildUpdate Guildupdate = ob.Character.Account.GuildMember.Guild.GetUpdatePacket();

                            foreach (GuildMemberInfo member in ob.Character.Account.GuildMember.Guild.Members)
                                member.Account.Connection?.Player?.Enqueue(Guildupdate);
                        }
                        break;
                    case NPCActionType.GuildFubenMonGen:
                        
                        Map guildmonmap6 = SEnvir.GetMap(action.MapParameter1);
                        if (guildmonmap6.Bosses.Count == 0 && guildmonmap6.PlayerCount == 0)
                        {
                            if (action.MapParameter1 != null && action.MonsterParameter1 != null)
                            {
                                if (action.IntParameter1 == 0 && action.IntParameter2 == 0)
                                {
                                    new MonsterObject() { MonsterInfo = action.MonsterParameter1 }.Spawn(action.MapParameter1, guildmonmap6.GetRandomLocation(CurrentLocation, 400));
                                    foreach (GuildMemberInfo member in ob.Character.Account.GuildMember.Guild.Members)
                                        member.Account.Connection?.Player?.Connection.ReceiveChat(action.StringParameter1, MessageType.System);
                                }
                                else
                                {
                                    new MonsterObject() { MonsterInfo = action.MonsterParameter1 }.Spawn(action.MapParameter1, new Point(action.IntParameter1, action.IntParameter2));
                                    if (action.StringParameter1 == null) return;
                                    foreach (GuildMemberInfo member in ob.Character.Account.GuildMember.Guild.Members)
                                        member.Account.Connection?.Player?.Connection.ReceiveChat(action.StringParameter1, MessageType.System);
                                }
                            }

                            GuildInfo guildboss = ob.Character.Account.GuildMember.Guild;
                            guildboss.GuildFubenhd03 = 2;

                            S.GuildUpdate Guildupdate = ob.Character.Account.GuildMember.Guild.GetUpdatePacket();

                            foreach (GuildMemberInfo member in ob.Character.Account.GuildMember.Guild.Members)
                                member.Account.Connection?.Player?.Enqueue(Guildupdate);
                        }
                        break;
                    case NPCActionType.GuildJiacheng:
                        
                        if (ob.Character.Account.GuildMember.Guild == null) return;
                        GuildInfo guildjiacheng = ob.Character.Account.GuildMember.Guild;
                        if (CurrentMap == null) return;
                        ob.ApplyGuildJiachengBuff();
                        guildjiacheng.GuildJiachenghd04 = 2;

                        if (action.StringParameter1 == null) return;

                        S.GuildUpdate Guildupdates = ob.Character.Account.GuildMember.Guild.GetUpdatePacket();

                        foreach (GuildMemberInfo member in ob.Character.Account.GuildMember.Guild.Members)
                        {
                            member.Account.Connection?.Player?.Enqueue(Guildupdates);
                            member.Account.Connection?.Player?.Connection.ReceiveChat(action.StringParameter1, MessageType.System);
                        }
                        break;
                    case NPCActionType.WarDate:
                        if (ob.Character.Account.GuildMember == null) return;

                        foreach (CastleInfo castle in SEnvir.CastleInfoList.Binding)
                        {
                            UserConquest conquest = SEnvir.UserConquestList.Binding.FirstOrDefault(x => x.Castle == castle && (x.Guild == ob.Character.Account.GuildMember.Guild || x.Castle == ob.Character.Account.GuildMember.Guild.Castle));

                            TimeSpan warTime = TimeSpan.MinValue;
                            DateTime newDay = SEnvir.Now;

                            if (conquest != null)
                            {
                                warTime = (conquest.WarDate + conquest.Castle.StartTime) - SEnvir.Now;
                                newDay = conquest.WarDate + conquest.Castle.StartTime;

                                ob.Connection.ReceiveChat($"最近的沙巴克攻城时间是 {newDay.ToString("M")} ，还有 {Functions.ToString(warTime, true)} 时间", MessageType.System);
                            }
                            else
                                ob.Connection.ReceiveChat($"你公会还没申请沙巴克攻城战", MessageType.System);
                        }
                        break;
                    case NPCActionType.DelEmailList:
                        if (action.StringParameter1 == null) return;

                        if (action.IntParameter1 == 0)
                            fileName = Path.Combine(SEnvir.NameListPath, action.StringParameter1 + ".txt");
                        else if (action.IntParameter1 == 1)
                            fileName = Path.Combine(SEnvir.YueNameListPath, action.StringParameter1 + ".txt");

                        if (File.Exists(fileName))
                            File.WriteAllLines(fileName, File.ReadLines(fileName).Where(l => l != ob.Character.Account.EMailAddress).ToList());
                        break;
                    case NPCActionType.GroupTakeItem:
                        if (action.ItemParameter1 == null || action.IntParameter1 == 0 || ob.GroupMembers == null) return;
                        for (int j = 0; j < ob.GroupMembers.Count(); j++)
                            ob.GroupMembers[j].TakeItem(action.ItemParameter1, action.IntParameter1);
                        break;
                    case NPCActionType.CompanionRebirth: 
                        if (ob.Companion == null) return;

                        if (Config.是否开启留级转生)
                        {

                            if (ob.Companion.UserCompanion.Level >= 15 + (ob.Companion.UserCompanion.Rebirth * 5))
                                ob.NPCCompanionRebirth();
                        }
                        else
                        {
                            if (ob.Companion.UserCompanion.Level >= 15 + ob.Companion.UserCompanion.Rebirth)
                                ob.NPCCompanionRebirth();
                        }
                        break;
                    case NPCActionType.TakeFubendian:
                        if (action.IntParameter1 == 0) return;
                        ob.Character.Account.Fubendian -= action.IntParameter1;
                        ob.Enqueue(new S.FubenDian { Fubendian = ob.Character.Account.Fubendian });
                        break;
                    case NPCActionType.GroupTakeFubendian:
                        if (action.IntParameter1 == 0 || ob.GroupMembers == null) return;
                        for (int j = 0; j < ob.GroupMembers.Count(); j++)
                        {
                            ob.GroupMembers[j].Character.Account.Fubendian -= action.IntParameter1;
                            ob.GroupMembers[j].Enqueue(new S.FubenDian { Fubendian = ob.GroupMembers[j].Character.Account.Fubendian });
                        }
                        break;
                }
            }
        }

        private bool CheckPage(PlayerObject ob, NPCPage page, out NPCPage failPage)
        {
            failPage = null;
            foreach (NPCCheck check in page.Checks)
            {
                failPage = check.FailPage;
                UserItem weap;
                var regexQuote = new Regex("\"([^\"]*)\"");
                switch (check.CheckType)
                {
                    case NPCCheckType.Level:
                        if (!Compare(check.Operator, ob.Level, check.IntParameter1)) return false;
                        break;
                    case NPCCheckType.Class:
                        if (!Compare(check.Operator, (int)ob.Class, check.IntParameter1)) return false;
                        break;
                    case NPCCheckType.Gold:
                        if (!Compare(check.Operator, ob.Gold, check.IntParameter1)) return false;
                        break;

                    case NPCCheckType.HasWeapon:
                        if (ob.Equipment[(int)EquipmentSlot.Weapon] != null != (check.Operator == Operator.Equal)) return false;
                        break;

                    case NPCCheckType.WeaponLevel:
                        if (!Compare(check.Operator, ob.Equipment[(int)EquipmentSlot.Weapon].Level, check.IntParameter1)) return false;
                        break;

                    case NPCCheckType.WeaponCanRefine:
                        if ((ob.Equipment[(int)EquipmentSlot.Weapon].Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable != (check.Operator == Operator.Equal)) return false;
                        break;
                    case NPCCheckType.WeaponAddedStats:
                        if (!Compare(check.Operator, ob.Equipment[(int)EquipmentSlot.Weapon].Stats[check.StatParameter1], check.IntParameter1)) return false;
                        break;
                    case NPCCheckType.WeaponElement:
                        weap = ob.Equipment[(int)EquipmentSlot.Weapon];

                        Stat element;
                        int value = 0;

                        switch ((Element)check.IntParameter1)
                        {
                            case Element.None:
                                value += weap.Stats.GetWeaponElementValue();
                                value += weap.Info.Stats.GetWeaponElementValue();
                                break;
                            case Element.Fire:
                                element = weap.Stats.GetWeaponElement();

                                if (element == Stat.None)
                                    element = weap.Info.Stats.GetWeaponElement();

                                if (element == Stat.FireAttack)
                                {
                                    value += weap.Stats.GetWeaponElementValue();
                                    value += weap.Info.Stats.GetWeaponElementValue();
                                }

                                break;
                            case Element.Ice:
                                element = weap.Stats.GetWeaponElement();

                                if (element == Stat.None)
                                    element = weap.Info.Stats.GetWeaponElement();

                                if (element == Stat.IceAttack)
                                {
                                    value += weap.Stats.GetWeaponElementValue();
                                    value += weap.Info.Stats.GetWeaponElementValue();
                                }

                                break;
                            case Element.Lightning:
                                element = weap.Stats.GetWeaponElement();

                                if (element == Stat.None)
                                    element = weap.Info.Stats.GetWeaponElement();

                                if (element == Stat.LightningAttack)
                                {
                                    value += weap.Stats.GetWeaponElementValue();
                                    value += weap.Info.Stats.GetWeaponElementValue();
                                }

                                break;
                            case Element.Wind:
                                element = weap.Stats.GetWeaponElement();

                                if (element == Stat.None)
                                    element = weap.Info.Stats.GetWeaponElement();

                                if (element == Stat.WindAttack)
                                {
                                    value += weap.Stats.GetWeaponElementValue();
                                    value += weap.Info.Stats.GetWeaponElementValue();
                                }

                                break;
                            case Element.Holy:
                                element = weap.Stats.GetWeaponElement();

                                if (element == Stat.None)
                                    element = weap.Info.Stats.GetWeaponElement();

                                if (element == Stat.HolyAttack)
                                {
                                    value += weap.Stats.GetWeaponElementValue();
                                    value += weap.Info.Stats.GetWeaponElementValue();
                                }

                                break;
                            case Element.Dark:
                                element = weap.Stats.GetWeaponElement();

                                if (element == Stat.None)
                                    element = weap.Info.Stats.GetWeaponElement();

                                if (element == Stat.DarkAttack)
                                {
                                    value += weap.Stats.GetWeaponElementValue();
                                    value += weap.Info.Stats.GetWeaponElementValue();
                                }

                                break;
                            case Element.Phantom:
                                element = weap.Stats.GetWeaponElement();

                                if (element == Stat.None)
                                    element = weap.Info.Stats.GetWeaponElement();

                                if (element == Stat.PhantomAttack)
                                {
                                    value += weap.Stats.GetWeaponElementValue();
                                    value += weap.Info.Stats.GetWeaponElementValue();
                                }
                                break;
                        }


                        if (!Compare(check.Operator, value, check.IntParameter2)) return false;
                        break;
                    case NPCCheckType.PKPoints:
                        if (!Compare(check.Operator, ob.Stats[Stat.PKPoint], check.IntParameter1 == 0 ? Config.RedPoint : check.IntParameter1) && ob.Stats[Stat.Redemption] == 0)
                            return false;
                        break;
                    case NPCCheckType.Horse:
                        if (!Compare(check.Operator, (int)ob.Character.Account.Horse, check.IntParameter1)) return false;
                        break;
                    case NPCCheckType.Marriage:
                        if (check.Operator == Operator.Equal)
                        {
                            if (ob.Character.Partner == null) return false;
                        }
                        else
                        {
                            if (ob.Character.Partner != null) return false;
                        }
                        break;
                    case NPCCheckType.WeddingRing:
                        if (check.Operator == Operator.Equal)
                        {
                            if (ob.Equipment[(int)EquipmentSlot.RingL] == null || (ob.Equipment[(int)EquipmentSlot.RingL].Flags & UserItemFlags.Marriage) != UserItemFlags.Marriage) return false;
                        }
                        else
                        {
                            if (ob.Equipment[(int)EquipmentSlot.RingL] != null && (ob.Equipment[(int)EquipmentSlot.RingL].Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                        }
                        break;
                    case NPCCheckType.HasItem:
                        if (check.ItemParameter1 == null) continue;
                        if (!Compare(check.Operator, ob.GetItemCount(check.ItemParameter1), check.IntParameter1)) return false;
                        break;
                    case NPCCheckType.CanGainItem:
                        if (check.ItemParameter1 == null) continue;

                        ItemCheck itemCheck = new ItemCheck(check.ItemParameter1, check.IntParameter1, UserItemFlags.None, TimeSpan.Zero);

                        if (!ob.CanGainItems(false, itemCheck)) return false;
                        break;
                    case NPCCheckType.CanResetWeapon:
                        if (check.Operator == Operator.Equal)
                        {
                            if (SEnvir.Now < ob.Equipment[(int)EquipmentSlot.Weapon].ResetCoolDown) return false;
                        }
                        else
                        {
                            if (SEnvir.Now >= ob.Equipment[(int)EquipmentSlot.Weapon].ResetCoolDown) return false;
                        }
                        break;
                    case NPCCheckType.Random:
                        if (check.StringParameter1 == null)
                        {
                            if (!Compare(check.Operator, SEnvir.Random.Next(check.IntParameter1), check.IntParameter2)) return false;
                        }
                        else
                            if (!Compare(check.Operator, SEnvir.Random.Next(0, check.IntParameter1), check.IntParameter2)) return false;
                        break;
                    case NPCCheckType.Daily:
                        if (!Compare(check.Operator, DateTime.Now.DayOfYear, check.Accept.DayOfYear)) return false;
                        break;
                    case NPCCheckType.Hour:
                        if (!Compare(check.Operator, DateTime.Now.Hour, check.IntParameter1)) return false;
                        break;
                    case NPCCheckType.Minute:
                        if (!Compare(check.Operator, DateTime.Now.Minute, check.IntParameter1)) return false;
                        break;
                    case NPCCheckType.DayOfWeek:
                        if (!check.Accept.DayOfWeek.Equals(DateTime.Now.DayOfWeek)) return false;
                        break;
                    case NPCCheckType.PlayerTeleport:
                        if (check.MapParameter1 == null) return false;
                        Map map = SEnvir.GetMap(check.MapParameter1);
                        if (!Compare(check.Operator, map.Players.Count, check.IntParameter1)) return false;
                        break;
                    case NPCCheckType.BoosTeleport:
                        if (check.MapParameter1 == null) return false;
                        Map map1 = SEnvir.GetMap(check.MapParameter1);
                        if (!Compare(check.Operator, map1.Bosses.Count, check.IntParameter1)) return false;
                        break;
                    case NPCCheckType.Groupleader:
                        if (ob.GroupMembers == null || ob.GroupMembers[0] != ob) return false;
                        break;
                    case NPCCheckType.GroupCount:
                        if (ob.GroupMembers == null || !Compare(check.Operator, ob.GroupMembers.Count, check.IntParameter1)) return false;
                        break;
                    case NPCCheckType.GroupCheckNearby:
                        Point target = new Point(-1, -1);
                        for (int j = 0; j < ob.CurrentMap.NPCs.Count; j++)
                        {
                            NPCObject nearbyob = ob.CurrentMap.NPCs[j];
                            if (nearbyob.ObjectID != ob.ObjectID) continue;
                            target = nearbyob.CurrentLocation;
                            break;
                        }
                        if (ob.GroupMembers == null || ob.GroupMembers[0] != ob) return false;
                        else
                        {
                            for (int j = 0; j < ob.GroupMembers.Count; j++)
                            {
                                if (ob.GroupMembers[j] == null) continue;
                                if (!Functions.InRange(ob.GroupMembers[j].CurrentLocation, ob.CurrentLocation, 9)) return false;
                            }
                        }
                        break;
                    case NPCCheckType.InGuild:
                        if (ob.Character.Account.GuildMember == null) return false;
                        break;
                    case NPCCheckType.CheckNameList:
                        if (check.StringParameter1 == null) return false;
                        if (check.IntParameter1 == 0)
                        {
                            var fileNames = Path.Combine(SEnvir.NameListPath, check.StringParameter1 + ".txt");
                            if (File.Exists(fileNames))
                            {
                                var read = File.ReadAllLines(fileNames);
                                if (read.Contains(ob.Name)) return false;
                            }
                        }
                        else if (check.IntParameter1 == 1)
                        {
                            var fileNames = Path.Combine(SEnvir.YueNameListPath, check.StringParameter1 + ".txt");
                            if (File.Exists(fileNames))
                            {
                                var read = File.ReadAllLines(fileNames);
                                if (read.Contains(ob.Name)) return false;
                            }
                        }
                        break;
                    case NPCCheckType.CheckMon:
                        if (!Compare(check.Operator, ob.CurrentMap.MonsterCount, check.IntParameter1)) return false;
                        break;
                    case NPCCheckType.CheckBoss:
                        if (!Compare(check.Operator, ob.CurrentMap.Bosses.Count, check.IntParameter1)) return false;
                        break;
                    case NPCCheckType.CheckPlayer:
                        Map checkmap = CurrentMap;
                        foreach (var cell in checkmap.Cells)
                        {
                            if (cell == null || cell.Objects == null) continue;

                            int obCount = cell.Objects.Count();

                            for (int m = 0; m < obCount; m++)
                            {
                                MapObject checkob = cell.Objects[m];

                                if (checkob.Race != ObjectType.Player) continue;
                                if (checkob.Dead)
                                {
                                    return true;
                                }
                            }
                        }
                        if (!Compare(check.Operator, ob.CurrentMap.PlayerCount, check.IntParameter1)) return false;
                        
                        break;
                    case NPCCheckType.CheckNameListFan:
                        if (check.StringParameter1 == null) return false;
                        if (check.IntParameter1 == 0)
                        {
                            var checknamefileName = Path.Combine(SEnvir.NameListPath, check.StringParameter1 + ".txt");

                            if (File.Exists(checknamefileName))
                            {
                                var read = File.ReadAllLines(checknamefileName);
                                if (!read.Contains(ob.Name)) return false;
                            }
                        }
                        else if (check.IntParameter1 == 1)
                        {
                            var checknamefileName = Path.Combine(SEnvir.YueNameListPath, check.StringParameter1 + ".txt");

                            if (File.Exists(checknamefileName))
                            {
                                var read = File.ReadAllLines(checknamefileName);
                                if (!read.Contains(ob.Name)) return false;
                            }
                        }
                        break;
                    case NPCCheckType.GroupCheckNameLists:
                        if (check.StringParameter1 == null || ob.GroupMembers == null) return false;
                        var groupfileName = Path.Combine(SEnvir.NameListPath, check.StringParameter1 + ".txt");
                        if (File.Exists(groupfileName))
                        {
                            for (int j = 0; j < ob.GroupMembers.Count(); j++)
                            {
                                var read = File.ReadAllLines(groupfileName);
                                if (read.Contains(ob.GroupMembers[j].Name)) return false;
                            }
                        }
                        break;
                    case NPCCheckType.CheckEMailList:
                        if (check.StringParameter1 == null) return false;
                        if (check.IntParameter1 == 0)
                        {
                            var emailfileName = Path.Combine(SEnvir.NameListPath, check.StringParameter1 + ".txt");
                            if (File.Exists(emailfileName))
                            {
                                var read = File.ReadAllLines(emailfileName);
                                if (read.Contains(ob.Character.Account.EMailAddress)) return false;
                            }
                        }
                        else if (check.IntParameter1 == 1)
                        {
                            var emailfileName = Path.Combine(SEnvir.YueNameListPath, check.StringParameter1 + ".txt");
                            if (File.Exists(emailfileName))
                            {
                                var read = File.ReadAllLines(emailfileName);
                                if (read.Contains(ob.Character.Account.EMailAddress)) return false;
                            }
                        }
                        break;
                    case NPCCheckType.GroupCheckLevel:
                        for (int j = 0; j < ob.GroupMembers.Count(); j++)
                        {
                            if (!Compare(check.Operator, ob.GroupMembers[j].Level, check.IntParameter1)) return false;
                        }
                        break;
                    case NPCCheckType.CheckBagSpace:
                        int slotCount = 0;
                        for (int k = 0; k < ob.Inventory.Length; k++)
                            if (ob.Inventory[k] == null) slotCount++;
                        if (!Compare(check.Operator, slotCount, check.IntParameter1)) return false;
                        break;
                    case NPCCheckType.CheckBuff:
                        if (check.IntParameter1 == 0) return false;
                        switch (check.IntParameter1)
                        {
                            case 1:
                                if (!ob.Buffs.Any(x => x.Type == BuffType.RWBuffyi)) return false;
                                break;
                            case 2:
                                if (!ob.Buffs.Any(x => x.Type == BuffType.RWBuffer)) return false;
                                break;
                            case 3:
                                if (!ob.Buffs.Any(x => x.Type == BuffType.RWBuffsan)) return false;
                                break;
                            case 4:
                                if (!ob.Buffs.Any(x => x.Type == BuffType.RWBuffsi)) return false;
                                break;
                            case 5:
                                if (!ob.Buffs.Any(x => x.Type == BuffType.RWBuffwu)) return false;
                                break;
                            case 6:
                                if (!ob.Buffs.Any(x => x.Type == BuffType.RWBuffliu)) return false;
                                break;
                            case 7:
                                if (!ob.Buffs.Any(x => x.Type == BuffType.RWBuffqi)) return false;
                                break;
                            case 8:
                                if (!ob.Buffs.Any(x => x.Type == BuffType.RWBuffba)) return false;
                                break;
                            case 9:
                                if (!ob.Buffs.Any(x => x.Type == BuffType.RWBuffjiu)) return false;
                                break;
                            case 10:
                                if (!ob.Buffs.Any(x => x.Type == BuffType.RWBuffshi)) return false;
                                break;
                            case 11:
                                if (!ob.Buffs.Any(x => x.Type == BuffType.VipMapYi) & !ob.Buffs.Any(x => x.Type == BuffType.VipMapY)) return false;
                                break;
                            case 12:
                                if (!ob.Buffs.Any(x => x.Type == BuffType.VipMapEr) & !ob.Buffs.Any(x => x.Type == BuffType.VipMapE)) return false;
                                break;
                            case 13:
                                if (!ob.Buffs.Any(x => x.Type == BuffType.VipMapSan) & !ob.Buffs.Any(x => x.Type == BuffType.VipMapS)) return false;
                                break;
                            case 14:
                                if (!ob.Buffs.Any(x => x.Type == BuffType.VipMapYi)) return false;
                                break;
                            case 15:
                                if (!ob.Buffs.Any(x => x.Type == BuffType.VipMapEr)) return false;
                                break;
                            case 16:
                                if (!ob.Buffs.Any(x => x.Type == BuffType.VipMapSan)) return false;
                                break;
                            case 17:
                                if (!ob.Buffs.Any(x => x.Type == BuffType.VipMapY)) return false;
                                break;
                            case 18:
                                if (!ob.Buffs.Any(x => x.Type == BuffType.VipMapE)) return false;
                                break;
                            case 19:
                                if (!ob.Buffs.Any(x => x.Type == BuffType.VipMapS)) return false;
                                break;
                        }
                        break;
                    case NPCCheckType.InGroupfan:
                        if (ob.GroupMembers != null) return false;
                        break;
                    case NPCCheckType.CheckEMailListFan:
                        if (check.StringParameter1 == null) return false;
                        if (check.IntParameter1 == 0)
                        {
                            var emailfileNamefan = Path.Combine(SEnvir.NameListPath, check.StringParameter1 + ".txt");
                            if (File.Exists(emailfileNamefan))
                            {
                                var read = File.ReadAllLines(emailfileNamefan);
                                if (!read.Contains(ob.Character.Account.EMailAddress)) return false;
                            }
                        }
                        else if (check.IntParameter1 == 1)
                        {
                            var emailfileNamefan = Path.Combine(SEnvir.YueNameListPath, check.StringParameter1 + ".txt");
                            if (File.Exists(emailfileNamefan))
                            {
                                var read = File.ReadAllLines(emailfileNamefan);
                                if (!read.Contains(ob.Character.Account.EMailAddress)) return false;
                            }
                        }
                        break;
                    case NPCCheckType.GroupCheckEMailList:
                        if (check.StringParameter1 == null || ob.GroupMembers == null) return false;
                        var groupemailfileName = Path.Combine(SEnvir.NameListPath, check.StringParameter1 + ".txt");
                        if (File.Exists(groupemailfileName))
                        {
                            for (int j = 0; j < ob.GroupMembers.Count(); j++)
                            {
                                var read = File.ReadAllLines(groupemailfileName);
                                if (read.Contains(ob.GroupMembers[j].Character.Account.EMailAddress)) return false;
                            }
                        }
                        break;
                    case NPCCheckType.CheckShengwang:
                        
                        if (!Compare(check.Operator, ob.Shengwang, check.IntParameter1)) return false;
                        break;
                    case NPCCheckType.CheckShangjin:
                        
                        if (!Compare(check.Operator, ob.Character.Account.HuntGold, check.IntParameter1)) return false;
                        break;
                    case NPCCheckType.CheckYuanbao:
                        
                        if (!Compare(check.Operator, ob.Character.Account.GameGold, check.IntParameter1)) return false;
                        break;
                    case NPCCheckType.CheckQuest:
                        
                        if (!ob.Character.Quests.Any(x => x.QuestInfo == check.QuestParameter)) return false;
                        break;
                    /*
                case NPCCheckType.CheckQuestZuowan:
                    
                    if (ob.Character.Quests.Any(x => x.QuestInfo == check.QuestParameter && x.Completed)) break;
                    break;
                case NPCCheckType.CheckQuestMeiZuo:
                    
                    if (ob.Character.Quests.Any(x => x.QuestInfo == check.QuestParameter && x.Completed)) return false;
                    break;
                    */
                    case NPCCheckType.CheckMeiriQuest:
                        
                        if (!ob.Character.Account.MeiriQuests.Any(x => x.QuestInfo == check.MeiriQuest)) return false;
                        break;
                    /*
                    case NPCCheckType.CheckMeiriZuowan:
                    
                    if (ob.Character.MeiriQuests.Any(x => x.QuestInfo == check.MeiriQuest && x.Completed)) break;
                    break;
                    case NPCCheckType.CheckMeiriMeiZuo:
                    
                    if (ob.Character.MeiriQuests.Any(x => x.QuestInfo == check.MeiriQuest && x.Completed)) return false;
                    break;
                    */
                    case NPCCheckType.CheckGuildFunds:
                        
                        if (ob.Character.Account.GuildMember == null) return false;
                        GuildInfo guild = ob.Character.Account.GuildMember.Guild;
                        if (!Compare(check.Operator, guild.GuildFunds, check.IntParameter1)) return false;
                        break;
                    case NPCCheckType.CheckGuildNameList:
                        
                        if (check.StringParameter1 == null || ob.Character.Account.GuildMember == null) return false;
                        var fileName = Path.Combine(SEnvir.NameListPath, check.StringParameter1 + ".txt");
                        if (File.Exists(fileName))
                        {
                            var read = File.ReadAllLines(fileName);
                            if (read.Contains(ob.Character.Account.GuildMember.Guild.GuildName)) return false;
                        }
                        break;
                    case NPCCheckType.CheckGuildleader:
                        
                        if (ob.Character.Account.GuildMember == null) return false;
                        if ((ob.Character.Account.GuildMember.Permission & GuildPermission.Leader) != GuildPermission.Leader) return false;
                        break;
                    case NPCCheckType.CheckSabukleader:
                        if (ob.Character.Account.GuildMember == null) return false;
                        if (ob.Character.Account.GuildMember.Guild.Castle == null) return false;
                        if ((ob.Character.Account.GuildMember.Permission & GuildPermission.Leader) != GuildPermission.Leader) return false;
                        break;
                    case NPCCheckType.CheckSabukMember:
                        if (ob.Character.Account.GuildMember == null) return false;
                        if (ob.Character.Account.GuildMember.Guild.Castle == null) return false;
                        break;
                    case NPCCheckType.CheckGuildLevel:
                        
                        if (ob.Character.Account.GuildMember == null) return false;
                        if (!Compare(check.Operator, ob.Character.Account.GuildMember.Guild.GuildLevel, check.IntParameter1)) return false;
                        break;
                    case NPCCheckType.CheckGuildNameListFan:
                        
                        if (check.StringParameter1 == null || ob.Character.Account.GuildMember == null) return false;
                        fileName = Path.Combine(SEnvir.GuildListPath, check.StringParameter1 + ".txt");
                        if (File.Exists(fileName))
                        {
                            var read = File.ReadAllLines(fileName);
                            if (!read.Contains(ob.Character.Account.GuildMember.Guild.GuildName)) return false;
                        }
                        break;
                    case NPCCheckType.Rebirth:
                        if (!Compare(check.Operator, ob.Character.Rebirth, check.IntParameter1)) return false;
                        break;
                    case NPCCheckType.GroupHasItem:
                        if (check.ItemParameter1 == null || check.IntParameter1 == 0 || ob.GroupMembers == null) continue;
                        for (int j = 0; j < ob.GroupMembers.Count(); j++)
                            if (!Compare(check.Operator, ob.GroupMembers[j].GetItemCount(check.ItemParameter1), check.IntParameter1)) return false;
                        break;
                    case NPCCheckType.InGroup:
                        if (ob.GroupMembers == null) return true;
                        else if (ob.GroupMembers != null)
                        {
                            return false;
                        }
                        break;
                    case NPCCheckType.CompanionLevel:
                        if (!Compare(check.Operator, ob.Companion.UserCompanion.Level, check.IntParameter1)) return false;
                        break;
                    case NPCCheckType.CompanionRebirth:
                        if (!Compare(check.Operator, ob.Companion.UserCompanion.Rebirth, check.IntParameter1)) return false;
                        break;
                    case NPCCheckType.CheckFubendian:
                        if (!Compare(check.Operator, ob.Character.Account.Fubendian, check.IntParameter1)) return false;
                        break;
                    case NPCCheckType.GroupCheckFubendian:
                        if (check.IntParameter1 == 0 || ob.GroupMembers == null) return false;
                        for (int j = 0; j < ob.GroupMembers.Count(); j++)
                        {
                            if (!Compare(check.Operator, ob.GroupMembers[j].Character.Account.Fubendian, check.IntParameter1)) return false;
                        }
                        break;


                }


            }
            return true;
        }


        private bool Compare(Operator op, long pValue, long cValue)
        {
            switch (op)
            {
                case Operator.Equal:
                    return pValue == cValue;
                case Operator.NotEqual:
                    return pValue != cValue;
                case Operator.LessThan:
                    return pValue < cValue;
                case Operator.LessThanOrEqual:
                    return pValue <= cValue;
                case Operator.GreaterThan:
                    return pValue > cValue;
                case Operator.GreaterThanOrEqual:
                    return pValue >= cValue;
                default: return false;
            }
        }

        public override Packet GetInfoPacket(PlayerObject ob)
        {
            return new S.ObjectNPC
            {
                ObjectID = ObjectID,

                NPCIndex = NPCInfo.Index,

                CurrentLocation = CurrentLocation,

                Direction = Direction,
            };
        }

        public override bool CanBeSeenBy(PlayerObject ob)
        {
            return Visible && base.CanBeSeenBy(ob);
        }

        public override bool CanDataBeSeenBy(PlayerObject ob)
        {
            return false;
        }

        public override Packet GetDataPacket(PlayerObject ob)
        {
            return null;
        }
    }
}
