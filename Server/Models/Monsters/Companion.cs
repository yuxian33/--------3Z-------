using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using Library.Network;
using Library.SystemModels;
using Server.DBModels;
using Server.Envir;
using S = Library.Network.ServerPackets;

namespace Server.Models.Monsters
{
    public sealed class Companion : MonsterObject
    {
        public override bool Blocking => false;

        public int BagWeight, HasSpace;

        public ItemObject TargetItem;
        public UserCompanion UserCompanion;
        public PlayerObject CompanionOwner;
        public DateTime MaxGoldTime;

        public CompanionLevelInfo LevelInfo;


        public UserItem[] Inventory;
        public UserItem[] Equipment;

        private int HeadShape, BackShape;

        public Companion(UserCompanion companion)
        {
            Visible = false;
            PreventSpellCheck = true;
            UserCompanion = companion;

            MonsterInfo = companion.Info.MonsterInfo;

            Equipment = new UserItem[CartoonGlobals.CompanionEquipmentSize];

            foreach (UserItem item in companion.Items)
            {
                if (item.Slot < CartoonGlobals.EquipmentOffSet) continue;

                if (item.Slot - CartoonGlobals.EquipmentOffSet >= Equipment.Length)
                {
                    SEnvir.Log($"[宠物包裹装备] 位置: {item.Slot}, 名称: {UserCompanion.Character.CharacterName}, 宠物名: {UserCompanion.Name}");
                    continue;
                }

                if (item.Info.ItemType == ItemType.CompanionHead)
                {
                    HeadShape = item.Info.ShapeNum;
                }
                else if (item.Info.ItemType == ItemType.CompanionBack)
                {
                    BackShape = item.Info.ShapeNum;
                }

                Equipment[item.Slot - CartoonGlobals.EquipmentOffSet] = item;
            }

            Inventory = new UserItem[CartoonGlobals.CompanionInventorySize];

            foreach (UserItem item in companion.Items)
            {
                if (item.Slot >= CartoonGlobals.EquipmentOffSet) continue;

                if (item.Slot >= Inventory.Length)
                {
                    SEnvir.Log($"[宠物包裹清单] 位置: {item.Slot}, 名称: {UserCompanion.Character.CharacterName}, 宠物名: {UserCompanion.Name}");
                    continue;
                }

                Inventory[item.Slot] = item;
            }
        }


        public override void ProcessAI()
        {
            if (!CompanionOwner.VisibleObjects.Contains(this))
                Recall();

            if (TargetItem?.Node == null || TargetItem.CurrentMap != CurrentMap || !Functions.InRange(CurrentLocation, TargetItem.CurrentLocation, ViewRange))
                TargetItem = null;

            ProcessSearch();
            ProcessRoam();
            ProcessTarget();
        }

        public override void RefreshStats()
        {
            Stats.Clear();
            Stats.Add(MonsterInfo.Stats);

            LevelInfo = SEnvir.CompanionLevelInfoList.Binding.First(x => x.Level == UserCompanion.Level);

            MoveDelay = MonsterInfo.MoveDelay;
            AttackDelay = MonsterInfo.AttackDelay;

            foreach (UserItem item in Equipment)
            {
                if (item == null) continue;

                Stats.Add(item.Info.Stats);
                Stats.Add(item.Stats);
            }

            Stats[Stat.CompanionBagWeight] += LevelInfo.InventoryWeight;
            Stats[Stat.CompanionInventory] += LevelInfo.InventorySpace;

            RefreshWeight();
        }

        public void RefreshWeight()
        {
            BagWeight = 0;

            HasSpace = 0;
            for (int k = 0; k < Stats[Stat.CompanionInventory]; k++)
                if (Inventory[k] == null) HasSpace++;

            foreach (UserItem item in Inventory)
            {
                if (item == null) continue;

                BagWeight += item.Weight;

                if (item.Info.ItemType == ItemType.CompanionHead)
                {
                    HeadShape = item.Info.ShapeNum;
                }
                else if (item.Info.ItemType == ItemType.CompanionBack)
                {
                    BackShape = item.Info.ShapeNum;
                }
            }

            CompanionOwner.Enqueue(new S.CompanionWeightUpdate { BagWeight = BagWeight, MaxBagWeight = Stats[Stat.CompanionBagWeight], InventorySize = Stats[Stat.CompanionInventory], CompanionBagSpace = HasSpace });
        }

        public void SendShapeUpdate()
        {
            HeadShape = 0;
            BackShape = 0;

            foreach (UserItem item in Equipment)
            {
                if (item == null) continue;

                if (item.Info.ItemType == ItemType.CompanionHead)
                {
                    HeadShape = item.Info.ShapeNum;
                }
                else if (item.Info.ItemType == ItemType.CompanionBack)
                {
                    BackShape = item.Info.ShapeNum;
                }
            }

            Broadcast(new S.CompanionShapeUpdate { ObjectID = ObjectID, HeadShape = HeadShape, BackShape = BackShape });
        }


        public void Recall()
        {
            Cell cell = CompanionOwner.CurrentMap.GetCell(Functions.Move(CompanionOwner.CurrentLocation, CompanionOwner.Direction, -1));

            if (cell == null || cell.Movements != null)
                cell = CompanionOwner.CurrentCell;

            Teleport(CompanionOwner.CurrentMap, cell.Location);
        }

        public override void ProcessSearch()
        {
            if (!CanMove || SEnvir.Now < SearchTime) return;

            int bestDistance = int.MaxValue;

            List<ItemObject> closest = new List<ItemObject>();

            foreach (MapObject ob in CompanionOwner.VisibleObjects)
            {
                if (ob.Race != ObjectType.Item) continue;

                int distance = Functions.Distance(ob.CurrentLocation, CurrentLocation);

                if (distance > ViewRange) continue;

                if (distance > bestDistance) continue;


                ItemObject item = (ItemObject)ob;

                if (item.Account != CompanionOwner.Character.Account || !item.MonsterDrop) continue;

                long amount = 0;

                if (item.Item.Info.Effect == ItemEffect.Gold && item.Account.GuildMember != null && item.Account.GuildMember.Guild.GuildTax > 0 && item.Account.GuildMember.Guild.GuildFunds <= CartoonGlobals.MaxGold)
                    amount = (long)Math.Ceiling(item.Item.Count * item.Account.GuildMember.Guild.GuildTax);

                if (CompanionOwner.Gold + item.Item.Count > CartoonGlobals.MaxGold) continue;

                ItemCheck check = new ItemCheck(item.Item, item.Item.Count - amount, item.Item.Flags, item.Item.ExpireTime);

                if (!CanGainItems(true, check)) continue;


                if (distance != bestDistance) closest.Clear();

                int itemIdx = item.Item.Info.Index;
                if (item.Item.Info.Effect == ItemEffect.ItemPart)
                {
                    itemIdx = item.Item.Stats[Stat.ItemIndex];
                }

                if (!CompanionOwner.CompanionMemory.ContainsKey(itemIdx))
                    continue;

                closest.Add(item);
                bestDistance = distance;
            }

            if (closest.Count == 0)
            {
                SearchTime = SEnvir.Now.AddSeconds(1);
                return;
            }

            TargetItem = closest[SEnvir.Random.Next(closest.Count)];

        }
        public override void ProcessRoam()
        {
            if (TargetItem != null) return;

            MoveTo(Functions.Move(CompanionOwner.CurrentLocation, CompanionOwner.Direction, -1));
        }
        public override void ProcessTarget()
        {
            if (TargetItem == null) return;

            MoveTo(TargetItem.CurrentLocation);

            if (TargetItem.CurrentLocation != CurrentLocation) return;

            TargetItem.PickUpItem(this);
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

        public void RemoveItem(UserItem item)
        {
            item.Slot = -1;
            item.Character = null;
            item.Account = null;
            item.Mail = null;
            item.Auction = null;
            item.Companion = null;
            item.Guild = null;
            

            item.Flags &= ~UserItemFlags.Locked;
        }

        public bool CanWearItem(UserItem item, CompanionSlot slot)
        {
            if (!Functions.CorrectSlot(item.Info.ItemType, slot) || !CanUseItem(item.Info))
                return false;

            return true;
        }
        public bool CanUseItem(ItemInfo info)
        {
            switch (info.RequiredType)
            {
                case RequiredType.CompanionLevel:
                    if (UserCompanion.Level < info.RequiredAmount) return false;
                    break;
                case RequiredType.MaxCompanionLevel:
                    if (UserCompanion.Level > info.RequiredAmount) return false;
                    break;
            }

            return true;
        }

        public void AutoFeed()
        {
            if (UserCompanion.Hunger > 0) return;

            UserItem item = Equipment[(int) CompanionSlot.Food];

            if (item == null || !CanUseItem(item.Info)) return;


            UserCompanion.Hunger = Math.Min(LevelInfo.MaxHunger, item.Info.Stats[Stat.CompanionHunger]);

            S.ItemChanged result = new S.ItemChanged
            {
                Link = new CellLinkInfo { GridType = GridType.CompanionEquipment, Slot = (int)CompanionSlot.Food },
                Success = true,
            };

            CompanionOwner.Enqueue(result);
            if (item.Count > 1)
            {
                item.Count--;
                result.Link.Count = item.Count;
            }
            else
            {
                RemoveItem(item);
                Equipment[(int)CompanionSlot.Food] = null;
                item.Delete();

                result.Link.Count = 0;
            }
        }

        public void CheckSkills()
        {
            bool result = false;

            Stats lvStatss = new Stats();

            if (UserCompanion.Level >= 3 && (UserCompanion.Level3 == null || UserCompanion.Level3.Count == 0))
            {
                UserCompanion.Level3 = GetSkill(3);
                result = true;
            }

            if (UserCompanion.Level >= 5 && (UserCompanion.Level5 == null || UserCompanion.Level5.Count == 0))
            {
                UserCompanion.Level5 = GetSkill(5);
                result = true;
            }

            if (UserCompanion.Level >= 7 && (UserCompanion.Level7 == null || UserCompanion.Level7.Count == 0))
            {
                UserCompanion.Level7 = GetSkill(7);
                result = true;
            }

            if (UserCompanion.Level >= 10 && (UserCompanion.Level10 == null || UserCompanion.Level10.Count == 0))
            {
                UserCompanion.Level10 = GetSkill(10);
                result = true;
            }

            if (UserCompanion.Level >= 11 && (UserCompanion.Level11 == null || UserCompanion.Level11.Count == 0))
            {
                UserCompanion.Level11 = GetSkill(11);
                result = true;
            }

            if (UserCompanion.Level >= 13 && (UserCompanion.Level13 == null || UserCompanion.Level13.Count == 0))
            {
                UserCompanion.Level13 = GetSkill(13);
                result = true;
            }

            if (UserCompanion.Level >= 15 && (UserCompanion.Level15 == null || UserCompanion.Level15.Count == 0))
            {
                UserCompanion.Level15 = GetSkill(15);
                result = true;
            }

            if (UserCompanion.Level >= 17 && (UserCompanion.Level17 == null || UserCompanion.Level17.Count == 0))
            {
                UserCompanion.Level17 = GetSkill(17);
                result = true;
            }

            if (UserCompanion.Level >= 20 && (UserCompanion.Level20 == null || UserCompanion.Level20.Count == 0))
            {
                UserCompanion.Level20 = GetSkill(20);
                result = true;
            }

            if (UserCompanion.Level >= 23 && (UserCompanion.Level23 == null || UserCompanion.Level23.Count == 0))
            {
                UserCompanion.Level23 = GetSkill(23);
                result = true;
            }

            if (UserCompanion.Level >= 25 && (UserCompanion.Level25 == null || UserCompanion.Level25.Count == 0))
            {
                UserCompanion.Level25 = GetSkill(25);
                result = true;
            }

            if (UserCompanion.Level >= 27 && (UserCompanion.Level27 == null || UserCompanion.Level27.Count == 0))
            {
                UserCompanion.Level27 = GetSkill(27);
                result = true;
            }

            if (UserCompanion.Level >= 30 && (UserCompanion.Level30 == null || UserCompanion.Level30.Count == 0))
            {
                UserCompanion.Level30 = GetSkill(30);
                result = true;
            }

            if (UserCompanion.Level >= 33 && (UserCompanion.Level33 == null || UserCompanion.Level33.Count == 0))
            {
                UserCompanion.Level33 = GetSkill(33);
                result = true;
            }

            if (UserCompanion.Level >= 35 && (UserCompanion.Level35 == null || UserCompanion.Level35.Count == 0))
            {
                UserCompanion.Level35 = GetSkill(35);
                result = true;
            }

            if (UserCompanion.Level >= 37 && (UserCompanion.Level37 == null || UserCompanion.Level37.Count == 0))
            {
                UserCompanion.Level37 = GetSkill(37);
                result = true;
            }

            if (UserCompanion.Level >= 40 && (UserCompanion.Level40 == null || UserCompanion.Level40.Count == 0))
            {
                UserCompanion.Level40 = GetSkill(40);
                result = true;
            }


            CompanionOwner.CompanionRefreshBuff();

            if (!result) return;

            CompanionOwner.Enqueue(new S.CompanionSkillUpdate
            {
                Level3 = UserCompanion.Level3,
                ImgIndex3 = UserCompanion.ImgIndex3,
                Maxzhi3 = UserCompanion.Maxzhi3,
                Level5 = UserCompanion.Level5,
                ImgIndex5 = UserCompanion.ImgIndex5,
                Maxzhi5 = UserCompanion.Maxzhi5,
                Level7 = UserCompanion.Level7,
                ImgIndex7 = UserCompanion.ImgIndex7,
                Maxzhi7 = UserCompanion.Maxzhi7,
                Level10 = UserCompanion.Level10,
                ImgIndex10 = UserCompanion.ImgIndex10,
                Maxzhi10 = UserCompanion.Maxzhi10,
                Level11 = UserCompanion.Level11,
                ImgIndex11 = UserCompanion.ImgIndex11,
                Maxzhi11 = UserCompanion.Maxzhi11,
                Level13 = UserCompanion.Level13,
                ImgIndex13 = UserCompanion.ImgIndex13,
                Maxzhi13 = UserCompanion.Maxzhi13,
                Level15 = UserCompanion.Level15,
                ImgIndex15 = UserCompanion.ImgIndex15,
                Maxzhi15 = UserCompanion.Maxzhi15,
                Level17 = UserCompanion.Level17,
                ImgIndex17 = UserCompanion.ImgIndex17,
                Level20 = UserCompanion.Level20,
                ImgIndex20 = UserCompanion.ImgIndex20,
                Level23 = UserCompanion.Level23,
                ImgIndex23 = UserCompanion.ImgIndex23,
                Level25 = UserCompanion.Level25,
                ImgIndex25 = UserCompanion.ImgIndex25,
                Level27 = UserCompanion.Level27,
                ImgIndex27 = UserCompanion.ImgIndex27,
                Level30 = UserCompanion.Level30,
                ImgIndex30 = UserCompanion.ImgIndex30,
                Level33 = UserCompanion.Level33,
                ImgIndex33 = UserCompanion.ImgIndex33,
                Level35 = UserCompanion.Level35,
                ImgIndex35 = UserCompanion.ImgIndex35,
                Level37 = UserCompanion.Level37,
                ImgIndex37 = UserCompanion.ImgIndex37,
                Level40 = UserCompanion.Level40,
                ImgIndex40 = UserCompanion.ImgIndex40,

            });
            
        }
        public Stats GetSkill(int level)
        {
            int total = 0;

            foreach (CompanionSkillInfo info in SEnvir.CompanionSkillInfoList.Binding)
            {
                if (info.Level != level) continue;

                total += info.Weight;
            }


            Stats lvStats = new Stats();

            int value = SEnvir.Random.Next(total);

            foreach (CompanionSkillInfo info in SEnvir.CompanionSkillInfoList.Binding)
            {
                if (info.Level != level) continue;

                value -= info.Weight;

                if (value >= 0) continue;

                lvStats[info.StatType] = SEnvir.Random.Next(info.MaxAmount) + 1;

                if (level == 3)
                {
                    UserCompanion.ImgIndex3 = info.ImgIndex;

                    if (lvStats[info.StatType] == info.MaxAmount)
                        UserCompanion.Maxzhi3 = true;
                    else if (lvStats[info.StatType] != info.MaxAmount)
                        UserCompanion.Maxzhi3 = false;
                }
                else if (level == 5)
                {
                    UserCompanion.ImgIndex5 = info.ImgIndex;

                    if (lvStats[info.StatType] == info.MaxAmount)
                        UserCompanion.Maxzhi5 = true;
                    else if (lvStats[info.StatType] != info.MaxAmount)
                        UserCompanion.Maxzhi5 = false;
                }
                else if (level == 7)
                {
                    UserCompanion.ImgIndex7 = info.ImgIndex;

                    if (lvStats[info.StatType] == info.MaxAmount)
                        UserCompanion.Maxzhi7 = true;
                    else if (lvStats[info.StatType] != info.MaxAmount)
                        UserCompanion.Maxzhi7 = false;
                }
                else if (level == 10)
                {
                    UserCompanion.ImgIndex10 = info.ImgIndex;

                    if (lvStats[info.StatType] == info.MaxAmount)
                        UserCompanion.Maxzhi10 = true;
                    else if (lvStats[info.StatType] != info.MaxAmount)
                        UserCompanion.Maxzhi10 = false;
                }
                else if (level == 11)
                {
                    UserCompanion.ImgIndex11 = info.ImgIndex;

                    if (lvStats[info.StatType] == info.MaxAmount)
                        UserCompanion.Maxzhi11 = true;
                    else if (lvStats[info.StatType] != info.MaxAmount)
                        UserCompanion.Maxzhi11 = false;
                }
                else if (level == 13)
                {
                    UserCompanion.ImgIndex13 = info.ImgIndex;

                    if (lvStats[info.StatType] == info.MaxAmount)
                        UserCompanion.Maxzhi13 = true;
                    else if (lvStats[info.StatType] != info.MaxAmount)
                        UserCompanion.Maxzhi13 = false;
                }
                else if (level == 15)
                {
                    UserCompanion.ImgIndex15 = info.ImgIndex;

                    if (lvStats[info.StatType] == info.MaxAmount)
                        UserCompanion.Maxzhi15 = true;
                    else if (lvStats[info.StatType] != info.MaxAmount)
                        UserCompanion.Maxzhi15 = false;
                }
                else if (level == 17)
                    UserCompanion.ImgIndex17 = info.ImgIndex;
                else if (level == 20)
                    UserCompanion.ImgIndex20 = info.ImgIndex;
                else if (level == 23)
                    UserCompanion.ImgIndex23 = info.ImgIndex;
                else if (level == 25)
                    UserCompanion.ImgIndex25 = info.ImgIndex;
                else if (level == 27)
                    UserCompanion.ImgIndex27 = info.ImgIndex;
                else if (level == 30)
                    UserCompanion.ImgIndex30 = info.ImgIndex;
                else if (level == 33)
                    UserCompanion.ImgIndex33 = info.ImgIndex;
                else if (level == 35)
                    UserCompanion.ImgIndex35 = info.ImgIndex;
                else if (level == 37)
                    UserCompanion.ImgIndex37 = info.ImgIndex;
                else if (level == 40)
                    UserCompanion.ImgIndex40 = info.ImgIndex;

                break;
            }

            return lvStats;
        }

        protected override void MoveTo(Point target)
        {
            if (!CanMove || CurrentLocation == target) return;
            
            MirDirection direction = Functions.DirectionFromPoint(CurrentLocation, target);

            int rotation = SEnvir.Random.Next(2) == 0 ? 1 : -1;

            for (int d = 0; d < 8; d++)
            {
                if (Walk(direction)) return;

                direction = Functions.ShiftDirection(direction, rotation);
            }
        }
        public override bool Walk(MirDirection direction)
        {
            Cell cell = CurrentMap.GetCell(Functions.Move(CurrentLocation, direction));
            if (cell == null) return false;

            BuffRemove(BuffType.Invisibility);
            BuffRemove(BuffType.Transparency);

            Direction = direction;

            UpdateMoveTime();

            CurrentCell = cell;

            RemoveAllObjects();
            AddAllObjects();


            Broadcast(new S.ObjectMove { ObjectID = ObjectID, Direction = direction, Location = CurrentLocation, Distance = 1 });
            return true;
        }

        public bool CanGainItems(bool checkWeight, params ItemCheck[] checks)
        {
            int index = 0;
            foreach (ItemCheck check in checks)
            {
                if ((check.Flags & UserItemFlags.QuestItem) == UserItemFlags.QuestItem) continue;

                long count = check.Count;

                if (check.Info.Effect == ItemEffect.Experience) continue;
                if (check.Info.Effect == ItemEffect.Gold)
                {
                    if (count + CompanionOwner.Gold > CartoonGlobals.MaxGold)
                    {
                        if (SEnvir.Now < MaxGoldTime) return false;
                        MaxGoldTime = SEnvir.Now.AddSeconds(5);
                        CompanionOwner.Connection.ReceiveChat(CompanionOwner.Connection.Language.TradeMaxGold, MessageType.System);
                        return false;
                    }
                    else
                        continue;
                }

                if (checkWeight)
                {
                    switch (check.Info.ItemType)
                    {
                        case ItemType.Amulet:
                        case ItemType.Poison:
                            if (BagWeight + check.Info.Weight > Stats[Stat.CompanionBagWeight]) return false;
                            break;
                        default:
                            if (BagWeight + check.Info.Weight * count > Stats[Stat.CompanionBagWeight]) return false;
                            break;
                    }
                }

                if (check.Info.StackSize > 1 && (check.Flags & UserItemFlags.Expirable) != UserItemFlags.Expirable)
                {
                    foreach (UserItem oldItem in Inventory)
                    {
                        if (oldItem == null) continue;

                        if (oldItem.Info != check.Info || oldItem.Count >= check.Info.StackSize) continue;

                        if ((oldItem.Flags & UserItemFlags.Expirable) == UserItemFlags.Expirable) continue;
                        if ((oldItem.Flags & UserItemFlags.Bound) != (check.Flags & UserItemFlags.Bound)) continue;
                        if ((oldItem.Flags & UserItemFlags.Worthless) != (check.Flags & UserItemFlags.Worthless)) continue;
                        if ((oldItem.Flags & UserItemFlags.NonRefinable) != (check.Flags & UserItemFlags.NonRefinable)) continue;
                        if (!oldItem.Stats.Compare(check.Stats)) continue;

                        count -= check.Info.StackSize - oldItem.Count;

                        if (count <= 0) break;
                    }

                    if (count <= 0) break;
                }

                for (int i = index; i < Stats[Stat.CompanionInventory]; i++)
                {
                    index++;
                    UserItem item = Inventory[i];
                    if (item == null)
                    {
                        count -= check.Info.StackSize;

                        if (count <= 0) break;
                    }
                }

                if (count > 0) return false;
            }

            return true;
        }
        public void GainItem(params UserItem[] items)
        {
            CompanionOwner.Enqueue(new S.CompanionItemsGained { Items = items.Where(x => x.Info.Effect != ItemEffect.Experience).Select(x => x.ToClientInfo()).ToList() });

            HashSet<UserQuest> changedQuests = new HashSet<UserQuest>();

            HashSet<MeiriUserQuest> meirichangedQuests = new HashSet<MeiriUserQuest>();

            foreach (UserItem item in items)
            {
                if (item.UserTask != null)
                {
                    if (item.UserTask.Completed) continue;

                    item.UserTask.Amount = Math.Min(item.UserTask.Task.Amount, item.UserTask.Amount + item.Count);

                    changedQuests.Add(item.UserTask.Quest);

                    if (item.UserTask.Completed)
                    {
                        for (int i = item.UserTask.Objects.Count - 1; i >= 0; i--)
                            item.UserTask.Objects[i].Despawn();
                    }

                    item.UserTask = null;
                    item.Flags &= ~UserItemFlags.QuestItem;


                    item.IsTemporary = true;
                    item.Delete();
                    continue;
                }

                if (item.MeiriUserTask != null)
                {
                    if (item.MeiriUserTask.Completed) continue;

                    item.MeiriUserTask.Amount = Math.Min(item.MeiriUserTask.Task.Amount, item.MeiriUserTask.Amount + item.Count);

                    meirichangedQuests.Add(item.MeiriUserTask.Quest);

                    if (item.MeiriUserTask.Completed)
                    {
                        for (int i = item.MeiriUserTask.Objects.Count - 1; i >= 0; i--)
                            item.MeiriUserTask.Objects[i].Despawn();
                    }

                    item.MeiriUserTask = null;
                    item.Flags &= ~UserItemFlags.QuestItem;


                    item.IsTemporary = true;
                    item.Delete();
                    continue;
                }

                if (item.Info.Effect == ItemEffect.Gold)
                {
                    if (CompanionOwner.Gold + item.Count <= CartoonGlobals.MaxGold)
                    {
                        CompanionOwner.Gold += item.Count;
                        item.IsTemporary = true;
                        item.Delete();
                        continue;
                    }
                    else
                    {
                        if (SEnvir.Now < MaxGoldTime) return;
                        MaxGoldTime = SEnvir.Now.AddSeconds(5);
                        CompanionOwner.Connection.ReceiveChat(CompanionOwner.Connection.Language.TradeMaxGold, MessageType.System);
                        return;
                    }
                }

                if (item.Info.Effect == ItemEffect.Experience)
                {
                    CompanionOwner.GainExperience(item.Count, false);
                    item.IsTemporary = true;
                    item.Delete();
                    continue;
                }

                bool handled = false;
                if (item.Info.StackSize > 1 && (item.Flags & UserItemFlags.Expirable) != UserItemFlags.Expirable)
                {
                    foreach (UserItem oldItem in Inventory)
                    {
                        if (oldItem == null || oldItem.Info != item.Info || oldItem.Count >= oldItem.Info.StackSize) continue;


                        if ((oldItem.Flags & UserItemFlags.Expirable) == UserItemFlags.Expirable) continue;
                        if ((oldItem.Flags & UserItemFlags.Bound) != (item.Flags & UserItemFlags.Bound)) continue;
                        if ((oldItem.Flags & UserItemFlags.Worthless) != (item.Flags & UserItemFlags.Worthless)) continue;
                        if ((oldItem.Flags & UserItemFlags.NonRefinable) != (item.Flags & UserItemFlags.NonRefinable)) continue;
                        if (!oldItem.Stats.Compare(item.Stats)) continue;

                        if (oldItem.Count + item.Count <= item.Info.StackSize)
                        {
                            oldItem.Count += item.Count;
                            item.IsTemporary = true;
                            item.Delete();
                            handled = true;
                            break;
                        }

                        item.Count -= item.Info.StackSize - oldItem.Count;
                        oldItem.Count = item.Info.StackSize;
                    }
                    if (handled) continue;
                }

                for (int i = 0; i < Stats[Stat.CompanionInventory]; i++)
                {
                    if (Inventory[i] != null) continue;

                    Inventory[i] = item;
                    item.Slot = i;
                    item.Companion = UserCompanion;
                    item.IsTemporary = false;
                    break;
                }
            }

            foreach (UserQuest quest in changedQuests)
                CompanionOwner.Enqueue(new S.QuestChanged { Quest = quest.ToClientInfo() });

            foreach (MeiriUserQuest quest in meirichangedQuests)
                CompanionOwner.Enqueue(new S.MeiriQuestChanged { Quest = quest.ToClientInfo() });

            RefreshStats();
        }

        public override bool CanBeSeenBy(PlayerObject ob)
        {
            if (ob == CompanionOwner)
                return base.CanBeSeenBy(ob);

            return CompanionOwner != null && CompanionOwner.CanBeSeenBy(ob);
        }

        public override bool CanDataBeSeenBy(PlayerObject ob)
        {
            return false;
        }

        public override Packet GetInfoPacket(PlayerObject ob)
        {
            return new S.ObjectMonster
            {
                ObjectID = ObjectID,
                MonsterIndex = MonsterInfo.Index,

                Location = CurrentLocation,

                NameColour = NameColour,
                Direction = Direction,

                PetOwner = CompanionOwner.Name,
                
                Poison = Poison,

                Buffs = Buffs.Where(x => x.Visible).Select(x => x.Type).ToList(),

                CompanionObject = new ClientCompanionObject
                {
                    Name = UserCompanion.Name,
                    HeadShape = HeadShape,
                    BackShape = BackShape,
                }
            };
        }
        public override Packet GetDataPacket(PlayerObject ob)
        {
            return null;
        }
    }
}
