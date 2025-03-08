using System;
using System.Linq;
using Library;
using Library.Network;
using S = Library.Network.ServerPackets;
using Server.DBModels;
using Server.Envir;
using Server.Models.Monsters;
using Library.SystemModels;

namespace Server.Models
{
 public sealed class ItemObject : MapObject
    {
        public override ObjectType Race => ObjectType.Item;
        public override bool Blocking => false;

        public DateTime ExpireTime { get; set; }

        public UserItem Item { get; set; }
        public AccountInfo Account { get; set; }

        public bool MonsterDrop { get; set; }

        public override void Process()
        {
            base.Process();

            if (SEnvir.Now > ExpireTime)
            {
                Despawn();
                return;
            }

        }

        public override void OnDespawned()
        {
            base.OnDespawned();

            if (Item.UserTask != null)
            {
                Item.UserTask.Objects.Remove(this);
                Item.UserTask = null;
                Item.Flags &= ~UserItemFlags.QuestItem;
            }

            if (Item.MeiriUserTask != null)
            {
                Item.MeiriUserTask.Objects.Remove(this);
                Item.MeiriUserTask = null;
                Item.Flags &= ~UserItemFlags.QuestItem;
            }

            Item = null;
            Account = null;
        }

        public override void OnSafeDespawn()
        {
            base.OnSafeDespawn();


            if (Item.UserTask != null)
            {
                Item.UserTask.Objects.Remove(this);
                Item.UserTask = null;
                Item.Flags &= ~UserItemFlags.QuestItem;
            }

            if (Item.MeiriUserTask != null)
            {
                Item.MeiriUserTask.Objects.Remove(this);
                Item.MeiriUserTask = null;
                Item.Flags &= ~UserItemFlags.QuestItem;
            }

            Item = null;
            Account = null;
        }

        public bool PickUpItem(PlayerObject ob)
        {
            if (Account != null && Account != ob.Character.Account) return false;

            long amount = 0;

            if (Item.Info.Effect == ItemEffect.Gold)
            {
                if (Item.Count + ob.Gold > CartoonGlobals.MaxGold) return false;
            }

            if (Account != null && Item.Info.Effect == ItemEffect.Gold && Account.GuildMember != null && Account.GuildMember.Guild.GuildTax > 0 && Account.GuildMember.Guild.GuildFunds <= CartoonGlobals.MaxGold)
                amount = (long)Math.Ceiling(Item.Count * Account.GuildMember.Guild.GuildTax);

            ItemCheck check = new ItemCheck(Item, Item.Count - amount, Item.Flags, Item.ExpireTime);

            if (ob.CanGainItems(false, check))
            {
                if (amount > 0)
                {
                    Item.Count -= amount;

                    Account.GuildMember.Guild.GuildFunds += amount;
                    Account.GuildMember.Guild.DailyGrowth += amount;

             
                    if (!Config.是否开启公会等级)
                    {
                        Account.GuildMember.Guild.DailyContribution += amount;
                        Account.GuildMember.Guild.TotalContribution += amount;
                        Account.GuildMember.DailyContribution += amount;
                        Account.GuildMember.TotalContribution += amount;
                    }

                    foreach (GuildMemberInfo member in Account.GuildMember.Guild.Members)
                    {
                        if (member.Account.Connection?.Player == null) continue;

                        member.Account.Connection.Enqueue(new S.GuildMemberContribution { Index = Account.GuildMember.Index, Contribution = amount, MapName = CurrentMap.Info.Description, ObserverPacket = false });
                    }
                }

                Item.UserTask?.Objects.Remove(this);

                Item.MeiriUserTask?.Objects.Remove(this);

                ob.GainItem(Item);
             
                Despawn();
                return true;
            }

            return false;
        }
        public void PickUpItem(Companion ob)
        {
            if (Account != null && Account != ob.CompanionOwner.Character.Account) return;

            long amount = 0;

            if (Item.Info.Effect == ItemEffect.Gold)
            {
                if (Item.Count + ob.CompanionOwner.Gold > CartoonGlobals.MaxGold) return;
            }

            if (Account != null && Item.Info.Effect == ItemEffect.Gold && Account.GuildMember != null && Account.GuildMember.Guild.GuildTax > 0 && Account.GuildMember.Guild.GuildFunds <= CartoonGlobals.MaxGold)
                amount = (long)Math.Ceiling(Item.Count * Account.GuildMember.Guild.GuildTax);

            ItemCheck check = new ItemCheck(Item, Item.Count - amount, Item.Flags, Item.ExpireTime);

            if (ob.CanGainItems(true, check))
            {
                if (amount > 0)
                {
                    Item.Count -= amount;

                    Account.GuildMember.Guild.GuildFunds += amount;
                    Account.GuildMember.Guild.DailyGrowth += amount;
                    
          
                    if (!Config.是否开启公会等级)
                    {
                        Account.GuildMember.Guild.DailyContribution += amount;
                        Account.GuildMember.Guild.TotalContribution += amount;
                        Account.GuildMember.DailyContribution += amount;
                        Account.GuildMember.TotalContribution += amount;
                    }

                    foreach (GuildMemberInfo member in Account.GuildMember.Guild.Members)
                    {
                        if (member.Account.Connection?.Player == null) continue;

                        member.Account.Connection.Enqueue(new S.GuildMemberContribution { Index = Account.GuildMember.Index, Contribution = amount, MapName = CurrentMap.Info.Description, ObserverPacket = false });
                    }

                }

                Item.UserTask?.Objects.Remove(this);

                Item.MeiriUserTask?.Objects.Remove(this);

                ob.GainItem(Item);
                
                Despawn();
                return;
            }


            return;
        }


        public override void ProcessHPMP()
        {
        }
        public override void ProcessNameColour()
        {
        }
        public override void ProcessBuff()
        {
        }
        public override void ProcessPoison()
        {
        }

        public override bool CanBeSeenBy(PlayerObject ob)
        {

            if (Account != null && ob.Character.Account != Account) return false;

            if (Item.UserTask != null && Item.UserTask.Quest.Character != ob.Character) return false;

            if (Item.MeiriUserTask != null && Item.MeiriUserTask.Quest.Account != ob.Character.Account) return false;

            return base.CanBeSeenBy(ob);
        }

        public override void Activate()
        {
            if (Activated) return;

            Activated = true;
            SEnvir.ActiveObjects.Add(this);
        }
        public override void DeActivate()
        {
            return;
        }

        protected override void OnSpawned()
        {
            base.OnSpawned();

            ExpireTime = SEnvir.Now + Config.DropDuration;

            AddAllObjects();

            Activate();
        }
        public override Packet GetInfoPacket(PlayerObject ob)
        {
            return new S.ObjectItem
            {
                ObjectID = ObjectID,  
                Item = Item.ToClientInfo(),
                Location = CurrentLocation,
            };
        }
        public override Packet GetDataPacket(PlayerObject ob)
        {
            return new S.DataObjectItem
            {
                ObjectID = ObjectID,

                MapIndex = CurrentMap.Info.Index,
                CurrentLocation = CurrentLocation,
                 
                ItemIndex = Item.Info.Index,
            };
        }

        internal void PickUpItem(MonsterObject monsterObject)
        {
            throw new NotImplementedException();
        }
    }
}
