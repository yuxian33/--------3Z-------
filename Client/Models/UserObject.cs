using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Controls;
using Client.Envir;
using Client.Scenes;
using Client.Scenes.Views;
using Library;
using Library.Network.ServerPackets;
using Library.SystemModels;
using C = Library.Network.ClientPackets;

namespace Client.Models
{
    public sealed class UserObject : PlayerObject
    {
        #region Stats
        public override Stats Stats
        {
            get { return _Stats; }
            set
            {
                _Stats = value;

                GameScene.Game.StatsChanged();
            }
        }
        private Stats _Stats = new Stats();
        #endregion

        #region Hermit Stats

        public Stats HermitStats
        {
            get { return _HermitStats; }
            set
            {
                if (_HermitStats == value) return;
                
                _HermitStats = value;

                GameScene.Game.StatsChanged();
            }
        }
        private Stats _HermitStats = new Stats();

        #endregion

        #region Level
        public override int Level
        {
            get { return _level; }
            set
            {
                _level = value;

                GameScene.Game.LevelChanged();
            }
        }
        private int _level;

        
        public override int Jyhuishoulevel
        {
            get { return _Jyhuishoulevel; }
            set
            {
                _Jyhuishoulevel = value;

                GameScene.Game.JyhuishoulevelChanged();
            }
        }
        private int _Jyhuishoulevel;
        #endregion

        #region Class
        public override MirClass Class
        {
            get { return _Class; }
            set
            {
                _Class = value;

                GameScene.Game.ClassChanged();
            }
        }
        private MirClass _Class;
        #endregion

        #region Experience
        public decimal Experience
        {
            get { return _Experience; }
            set
            {
                _Experience = value;

                GameScene.Game.ExperienceChanged();
            }
        }
        private decimal _Experience;

        
        public decimal Exphuishou
        {
            get { return _Exphuishou; }
            set
            {
                _Exphuishou = value;

                GameScene.Game.ExphuishouChanged();
            }
        }
        private decimal _Exphuishou;
        
        public decimal Maxexphuishou
        {
            get { return _Maxexphuishou; }
            set
            {
                _Maxexphuishou = value;

                GameScene.Game.ExphuishouChanged();
            }
        }
        private decimal _Maxexphuishou;
        #endregion

        #region MaxExperience
        public decimal MaxExperience
        { 
            get { return _MaxExperience; }
            set
            {
                _MaxExperience = value;

                GameScene.Game.ExperienceChanged();
            }
        }
        private decimal _MaxExperience;
        #endregion

        #region CurrentHP
        public override int CurrentHP
        {
            get { return _CurrentHP; }
            set
            {
                _CurrentHP = value;

                GameScene.Game.HealthChanged();
            }
        }
        private int _CurrentHP;
        #endregion

        #region CurrentMP
        public override int CurrentMP
        {
            get { return _CurrentMP; }
            set
            {
                _CurrentMP = value;

                GameScene.Game.ManaChanged();
            }
        }
        private int _CurrentMP;
        #endregion

        #region AttackMode
        public AttackMode AttackMode
        {
            get { return _AttackMode; }
            set
            {
                _AttackMode = value;

                GameScene.Game.AttackModeChanged();
            }
        }
        private AttackMode _AttackMode;
        #endregion

        #region AttackMode
        public PetMode PetMode
        {
            get { return _PetMode; }
            set
            {
                _PetMode = value;

                GameScene.Game.PetModeChanged();
            }
        }
        private PetMode _PetMode;
        #endregion

        #region Gold
        public long Gold
        {
            get { return _Gold; }
            set
            {
                _Gold = value;

                GameScene.Game.GoldChanged();
            }
        }
        private long _Gold;
        #endregion

        #region Game Gold
        public int GameGold
        {
            get { return _GameGold; }
            set
            {
                _GameGold = value;

                GameScene.Game.GoldChanged();
            }
        }
        private int _GameGold;
        #endregion

        public long AutoTime
        {
            get
            {
                return _AutoTime;
            }
            set
            {
                _AutoTime = value;
                GameScene.Game.AutoTimeChanged();
            }
        }
        private long _AutoTime;

        #region Hunt Gold
        public int HuntGold
        {
            get { return _HuntGold; }
            set
            {
                _HuntGold = value;

                GameScene.Game.GoldChanged();
            }
        }
        private int _HuntGold;
        #endregion

        
        public int Gerenshengwang
        {
            get { return _Gerenshengwang; }
            set
            {
                _Gerenshengwang = value;

                GameScene.Game.GoldChanged();
            }
        }
        private int _Gerenshengwang;

        
        public int Fubendian
        {
            get { return _Fubendian; }
            set
            {
                _Fubendian = value;

                GameScene.Game.FubenDianChanged();
            }
        }
        private int _Fubendian;

        
        public bool XunzhaoGuaiwuMoshi01, XunzhaoGuaiwuMoshi02;

        
        
        public int BagWeight, WearWeight, HandWeight, JYhuishoudengji, ZaixianFenjie;

        
        public long ItemCountyi
        {
            get { return _ItemCountyi; }
            set
            {
                _ItemCountyi = value;

                GameScene.Game.ShenmidianChanged();
            }
        }
        private long _ItemCountyi;

        public long ItemCounter
        {
            get { return _ItemCounter; }
            set
            {
                _ItemCounter = value;

                GameScene.Game.ShenmidianChanged();
            }
        }
        private long _ItemCounter;

        public long ItemCountsan
        {
            get { return _ItemCountsan; }
            set
            {
                _ItemCountsan = value;

                GameScene.Game.ShenmidianChanged();
            }
        }

        private long _ItemCountsan;

        public long ItemCountsi
        {
            get { return _ItemCountsi; }
            set
            {
                _ItemCountsi = value;

                GameScene.Game.ShenmidianChanged();
            }
        }
        private long _ItemCountsi;

        public long ItemCountwu
        {
            get { return _ItemCountwu; }
            set
            {
                _ItemCountwu = value;

                GameScene.Game.ShenmidianChanged();
            }
        }
        private long _ItemCountwu;

        public long ItemCountliu
        {
            get { return _ItemCountliu; }
            set
            {
                _ItemCountliu = value;

                GameScene.Game.ShenmidianChanged();
            }
        }
        private long _ItemCountliu;

        public long ItemCountqi
        {
            get { return _ItemCountqi; }
            set
            {
                _ItemCountqi = value;

                GameScene.Game.ShenmidianChanged();
            }
        }
        private long _ItemCountqi;

        public long ItemCountba
        {
            get { return _ItemCountba; }
            set
            {
                _ItemCountba = value;

                GameScene.Game.ShenmidianChanged();
            }
        }
        private long _ItemCountba;

        public long ItemCountjiu
        {
            get { return _ItemCountjiu; }
            set
            {
                _ItemCountjiu = value;

                GameScene.Game.ShenmidianChanged();
            }
        }
        private long _ItemCountjiu;

        public long ItemCountshi
        {
            get { return _ItemCountshi; }
            set
            {
                _ItemCountshi = value;

                GameScene.Game.ShenmidianChanged();
            }
        }
        private long _ItemCountshi;

        public bool InSafeZone
        {
            get { return _InSafeZone; }
            set
            {
                if (_InSafeZone == value) return;
                
                _InSafeZone = value;

                GameScene.Game.SafeZoneChanged();
            }
        }
        private bool _InSafeZone;

        public int HermitPoints;
        


        public List<ClientBuffInfo> Buffs = new List<ClientBuffInfo>();
        
        public Dictionary<MagicInfo, ClientUserMagic> Magics = new Dictionary<MagicInfo, ClientUserMagic>();
       
        public Dictionary<FubenInfo, FubenInfo> Fubens = new Dictionary<FubenInfo, FubenInfo>();

        public DateTime NextActionTime, ServerTime, AttackTime, NextRunTime, NextMagicTime, BuffTime = CEnvir.Now, LotusTime, CombatTime, MoveTime;
        public MagicType AttackMagic;

        public ObjectAction MagicAction;
        
        
        public bool CanPowerAttack, CanPowersAttack;
        
        
        public bool CanxuanfengyinAttack;
        
        
        public bool CanxueshaYinAttack;
        
        
        public bool CanguanyueYinAttack;
        
        
        public bool CanjiyueYinAttack;
        
        
        public bool CanShenquYinAttack;
        
        
        public bool CanShenglongYinAttack;

        
        
        public bool CanZhanchuiYinAttack, ZhanchuiYin;
        
        
        public bool CanTianshenYinAttack, TianshenYin;

        
        
        
        
        public bool GuildLvKQ, HuanhuaGuagou, BaoshiKaiqi5433, Zdgjgongneng;


        
        
        
        public float ShakeScreenCount;
        
        
        
        public Point ShakeScreenOffset;
        public DateTime ShakeScreenTime = CEnvir.Now;

        public bool CanThrusting
        {
            get { return _canThrusting; }
            set
            {
                if (_canThrusting == value) return;
                
                _canThrusting = value;

                GameScene.Game.ReceiveChat(CanThrusting ? "刺杀剑术已开启" : "刺杀剑术已关闭", MessageType.System);
            }
        }
        private bool _canThrusting;

        public bool CanHalfMoon
        {
            get { return _CanHalfMoon; }
            set
            {
                if (_CanHalfMoon == value) return;

                _CanHalfMoon = value;

                GameScene.Game.ReceiveChat(CanHalfMoon ? "半月弯刀已开启" : "半月弯刀已关闭", MessageType.System);
            }
        }
        private bool _CanHalfMoon;
        public bool CanDestructiveBlow
        {
            get { return _CanDestructiveBlow; }
            set
            {
                if (_CanDestructiveBlow == value) return;
                _CanDestructiveBlow = value;

                GameScene.Game.ReceiveChat(CanDestructiveBlow ? "十方斩已开启" : "十方斩已关闭", MessageType.System);
            }
        }
        private bool _CanDestructiveBlow;

        public bool CanFlamingSword, CanDragonRise, CanBladeStorm;

        public bool CanFlameSplash
        {
            get { return _CanFlameSplash; }
            set
            {
                if (_CanFlameSplash == value) return;
                _CanFlameSplash = value;

                GameScene.Game.ReceiveChat(CanFlameSplash ? "新月爆炎龙已开启" : "新月爆炎龙已关闭", MessageType.System);
            }
        }
        private bool _CanFlameSplash;


        public UserObject(StartInformation info)
        {
            CharacterIndex = info.Index;

            ObjectID = info.ObjectID;

            Name = info.Name;
            NameColour = info.NameColour;

            Class = info.Class;
            Gender = info.Gender;

            Title = info.GuildName;
            GuildRank = info.GuildRank;

            CurrentLocation = info.Location;
            Direction = info.Direction;

            CurrentHP = info.CurrentHP;
            CurrentMP = info.CurrentMP;

            Level = info.Level;
            Experience = info.Experience;

            
            Jyhuishoulevel = info.Jyhuishoulevel;
            Exphuishou = info.Exphuishou;

            HairType = info.HairType;
            HairColour = info.HairColour;

            ArmourShape = info.Armour;
            ArmourImage = info.ArmourImage;
            ArmourColour = info.ArmourColour;
            LibraryWeaponShape = info.Weapon;

            WeaponImage = info.WeaponImage;

            
            ShizhuangShape = info.Shizhuang;
            ShizhuangImage = info.ShizhuangImage;

            EventFlagShape = 0;
            hasFlag = false;

            Poison = info.Poison;

            InSafeZone = info.InSafeZone;

            AttackMode = info.AttackMode;
            PetMode = info.PetMode;

            Horse = info.Horse;
            Dead = info.Dead;

            HorseShape = info.HorseShape;
            HelmetShape = info.HelmetShape;
            ShieldShape = info.Shield;

            EmblemShape = info.Emblem;

            Gold = info.Gold;
            GameScene.Game.DayTime = info.DayTime;
            GameScene.Game.GroupBox.AllowGroup = info.AllowGroup;

            HermitPoints = info.HermitPoints;

            CEnvir.MiniGamesList = info.CMiniGames;

            foreach (ClientUserMagic magic in info.Magics)
                Magics[magic.Info] = magic;

            foreach (ClientBuffInfo buff in info.Buffs)
            {
                Buffs.Add(buff);
                VisibleBuffs.Add(buff.Type);
            }

            foreach (ClientMapInfo mapinfos in info.MapInfos)
            {
                MapInfo mapInfo = CartoonGlobals.MapInfoList.Binding.FirstOrDefault((MapInfo x) => x.Index == mapinfos.InstanceIndex);
                if (mapInfo == null || mapInfo.Index != mapinfos.InstanceIndex)
                {
                    CEnvir.NewMapInstance(mapinfos);
                }
            }

            UpdateLibraries();

            SetFrame(new ObjectAction(!Dead ? MirAction.Standing : MirAction.Dead, Direction, CurrentLocation));
            
            GameScene.Game.FillItems(info.Items);

            foreach (ClientBeltLink link in info.BeltLinks)
            {
                if (link.Slot < 0 || link.Slot >= GameScene.Game.BeltBox.Links.Length) continue;

                GameScene.Game.BeltBox.Links[link.Slot].LinkInfoIndex = link.LinkInfoIndex;
                GameScene.Game.BeltBox.Links[link.Slot].LinkItemIndex = link.LinkItemIndex;
            }
            GameScene.Game.BeltBox.UpdateLinks();

            foreach (ClientAutoPotionLink link in info.AutoPotionLinks)
            {
                if (link.Slot >= 0 && link.Slot < GameScene.Game.BigPatchBox.Protect.Links.Length)
                    GameScene.Game.BigPatchBox.Protect.Links[link.Slot] = link;
            }
            
            foreach (ClientTeleport link in info.Teleports)
            {
                if (link.Index < 0 || link.Index >= GameScene.Game.TeleportBox.StoreRows.Length) continue;

                GameScene.Game.TeleportBox.LoadItems(link);
            }

            
            Mingwen01 = info.Mingwen01;
            
            Mingwen02 = info.Mingwen02;
            
            Mingwen03 = info.Mingwen03;

            Huiyuan = info.Huiyuan;

            GameScene.Game.BigPatchBox.Protect.UpdateLinks();
            GameScene.Game?.BigPatchBox?.UpdateLinks(info);

            GameScene.Game.MapControl.AddObject(this);

            GameScene.Game.MeiriQuestBox.DailyRandomTab.DailyRandomResetCount.Text = "你当前拥有 " + info.DailyRandomQuestResets.ToString() + " 次每日随机任务重置机会";

            if (info.DailyRandomQuestResets > 0)
            {
                if (!info.HasDailyRandom)
                {
                    GameScene.Game.MeiriQuestBox.DailyRandomTab.DailyRandomButton.Enabled = true;
                    GameScene.Game.MeiriQuestBox.DailyRandomTab.DailyRandomResetButton.Enabled = false;
                }
                if (info.HasDailyRandom)
                {
                    GameScene.Game.MeiriQuestBox.DailyRandomTab.DailyRandomButton.Enabled = false;
                    GameScene.Game.MeiriQuestBox.DailyRandomTab.DailyRandomResetButton.Enabled = true;
                }
            }
            else
            {
                GameScene.Game.MeiriQuestBox.DailyRandomTab.DailyRandomButton.Enabled = false;
                GameScene.Game.MeiriQuestBox.DailyRandomTab.DailyRandomResetButton.Enabled = false;
            }

      

        }
        public override void LocationChanged()
        {
            base.LocationChanged();

            GameScene.Game.MapControl.UpdateMapLocation();
            GameScene.Game.MapControl.FLayer.TextureValid = false;
        }

        public override void SetAction(ObjectAction action)
        {
            if (CEnvir.Now < ServerTime) return; 

            base.SetAction(action);

            switch (CurrentAction)
            {
                case MirAction.Die:
                case MirAction.Dead:
                    TargetObject = null;
                    break;
                case MirAction.Standing:
                    if ((GameScene.Game.MapControl.MapButtons & MouseButtons.Right) != MouseButtons.Right)
                        GameScene.Game.CanRun = false;
                    break;
            }

            if (Interupt) return;

            NextActionTime = CEnvir.Now;

            foreach (TimeSpan delay in CurrentFrame.Delays)
                NextActionTime += delay;
        }
        public void Moving(MirDirection dir, int step)
        {
            if (this.MoveTime >= CEnvir.Now)
                return;
            this.AttemptAction(new ObjectAction(MirAction.Moving, dir, Functions.Move(this.CurrentLocation, dir, step), new object[2]
            {
        (object) step,
        (object) MagicType.None
            }));
        }
        public void AttemptAction(ObjectAction action)
        {
            if (CEnvir.Now < NextActionTime || ActionQueue.Count > 0) return;
            if (CEnvir.Now < ServerTime) return; 

            switch (action.Action)
            {
                case MirAction.Moving:
                    if (CEnvir.Now < MoveTime) return;
                    break;
                case MirAction.Attack:
                    action.Extra[2] = Functions.GetElement(Stats);
                    
                    if (GameScene.Game.Equipment[(int)EquipmentSlot.Amulet]?.Info.ItemType == ItemType.DarkStone)
                    {
                        foreach (KeyValuePair<Stat, int> stats in GameScene.Game.Equipment[(int)EquipmentSlot.Amulet].Info.Stats.Values)
                        {
                            switch (stats.Key)
                            {
                                case Stat.FireAffinity:
                                    action.Extra[2] = Element.Fire;
                                    break;
                                case Stat.IceAffinity:
                                    action.Extra[2] = Element.Ice;
                                    break;
                                case Stat.LightningAffinity:
                                    action.Extra[2] = Element.Lightning;
                                    break;
                                case Stat.WindAffinity:
                                    action.Extra[2] = Element.Wind;
                                    break;
                                case Stat.HolyAffinity:
                                    action.Extra[2] = Element.Holy;
                                    break;
                                case Stat.DarkAffinity:
                                    action.Extra[2] = Element.Dark;
                                    break;
                                case Stat.PhantomAffinity:
                                    action.Extra[2] = Element.Phantom;
                                    break;
                            }
                        }
                    }

                    MagicType attackMagic = MagicType.None;

                    if (AttackMagic != MagicType.None)
                    {
                        foreach (KeyValuePair<MagicInfo, ClientUserMagic> pair in Magics)
                        {
                            if (pair.Key.Magic != AttackMagic) continue;

                            if (CEnvir.Now < pair.Value.NextCast) break;

                            if (AttackMagic == MagicType.Karma)
                            {
                                if (Stats[Stat.Health] * pair.Value.Cost / 100 > CurrentHP || Buffs.All(x => x.Type != BuffType.Cloak))
                                    break;
                            }
                            else 
                                if (pair.Value.Cost > CurrentMP) break;


                            attackMagic = AttackMagic;
                            break;
                        }
                    }
                    
                    if (CanPowerAttack && TargetObject != null)
                    {
                        foreach (KeyValuePair<MagicInfo, ClientUserMagic> pair in Magics)
                        {
                            if (pair.Key.Magic != MagicType.Slaying) continue;

                            if (pair.Value.Cost > CurrentMP) break;

                            attackMagic = pair.Key.Magic;
                            break;
                        }
                    }

                    
                    
                    if (Mingwen01 == 139 || Mingwen02 == 139 || Mingwen03 == 139)
                    {
                        if (CanxueshaYinAttack && TargetObject != null)
                        {
                            foreach (KeyValuePair<MagicInfo, ClientUserMagic> pair in Magics)
                            {
                                if (pair.Key.Magic != MagicType.Slaying) continue;

                                if (pair.Value.Cost > CurrentMP) break;

                                attackMagic = pair.Key.Magic;
                                break;
                            }
                        }
                    }
                    else { }

                    
                    
                    if (Mingwen01 == 5 || Mingwen02 == 5 || Mingwen03 == 5)
                    {
                        if (CanPowersAttack && TargetObject != null)
                        {
                            foreach (KeyValuePair<MagicInfo, ClientUserMagic> pair in Magics)
                            {
                                if (pair.Key.Magic != MagicType.SpiritSword) continue;

                                

                                attackMagic = pair.Key.Magic;
                                break;
                            }
                        }
                    }
                    else { }

                    if (CanThrusting && GameScene.Game.MapControl.CanEnergyBlast(action.Direction))
                    {
                        foreach (KeyValuePair<MagicInfo, ClientUserMagic> pair in Magics)
                        {
                            if (pair.Key.Magic != MagicType.Thrusting) continue;

                            if (pair.Value.Cost > CurrentMP) break;

                            attackMagic = pair.Key.Magic;
                            break;
                        }
                    }

                    
                    
                    if (Mingwen01 == 133 || Mingwen02 == 133 || Mingwen03 == 133)
                    {
                        if (CanxuanfengyinAttack && (TargetObject != null || (GameScene.Game.MapControl.CanXuanfengyin(action.Direction) &&
                                        (GameScene.Game.MapControl.HasTarget(Functions.Move(CurrentLocation, action.Direction)) || attackMagic != MagicType.Thrusting || !CanHalfMoon))))
                        {
                            foreach (KeyValuePair<MagicInfo, ClientUserMagic> pair in Magics)
                            {
                                if (pair.Key.Magic != MagicType.Swordsmanship) continue;

                                

                                attackMagic = pair.Key.Magic;
                                break;
                            }
                        }
                    }
                    else { }

                    if (CanHalfMoon && (TargetObject != null || (GameScene.Game.MapControl.CanHalfMoon(action.Direction) &&
                                                                 (GameScene.Game.MapControl.HasTarget(Functions.Move(CurrentLocation, action.Direction)) || attackMagic != MagicType.Thrusting))))
                    {
                        foreach (KeyValuePair<MagicInfo, ClientUserMagic> pair in Magics)
                        {
                            if (pair.Key.Magic != MagicType.HalfMoon) continue;

                            if (pair.Value.Cost > CurrentMP) break;

                            attackMagic = pair.Key.Magic;
                            break;
                        }
                    }


                    if (CanDestructiveBlow && (TargetObject != null || (GameScene.Game.MapControl.CanDestructiveBlow(action.Direction) &&
                                                                        (GameScene.Game.MapControl.HasTarget(Functions.Move(CurrentLocation, action.Direction)) || attackMagic != MagicType.Thrusting))))
                    {
                        foreach (KeyValuePair<MagicInfo, ClientUserMagic> pair in Magics)
                        {
                            if (pair.Key.Magic != MagicType.DestructiveSurge) continue;

                            if (pair.Value.Cost > CurrentMP) break;

                            attackMagic = pair.Key.Magic;
                            break;
                        }
                    }

                    if (attackMagic == MagicType.None && CanFlameSplash && (TargetObject != null || GameScene.Game.MapControl.CanDestructiveBlow(action.Direction)))
                    {
                        foreach (KeyValuePair<MagicInfo, ClientUserMagic> pair in Magics)
                        {
                            if (pair.Key.Magic != MagicType.FlameSplash) continue;

                            if (pair.Value.Cost > CurrentMP) break;

                            attackMagic = pair.Key.Magic;
                            break;
                        }
                    }


                    if (CanBladeStorm)
                        attackMagic = MagicType.BladeStorm;
                    else if (CanDragonRise)
                        attackMagic = MagicType.DragonRise;
                    else if (CanFlamingSword)
                        attackMagic = MagicType.FlamingSword;
                    

                    action.Extra[1] = attackMagic;
                    break;
                case MirAction.Mount:
                    return;
            }

            SetAction(action);

            int attackDelay;
            switch (action.Action)
            {
                case MirAction.Standing:
                    NextActionTime = CEnvir.Now + CartoonGlobals.TurnTime;
                    CEnvir.Enqueue(new C.Turn { Direction = action.Direction });
                    if ((GameScene.Game.MapControl.MapButtons & MouseButtons.Right) != MouseButtons.Right)
                        GameScene.Game.CanRun = false;
                    break;
                case MirAction.Harvest:
                    NextActionTime = CEnvir.Now + CartoonGlobals.HarvestTime;
                    CEnvir.Enqueue(new C.Harvest { Direction = action.Direction });
                    GameScene.Game.CanRun = false;
                    break;
                case MirAction.Moving:
                    MoveTime = CEnvir.Now + CartoonGlobals.MoveTime;

                    CEnvir.Enqueue(new C.Move { Direction = action.Direction, Distance = MoveDistance });
                    GameScene.Game.CanRun = true;
                    break;
                case MirAction.Attack:
                    attackDelay = CartoonGlobals.AttackDelay - Stats[Stat.AttackSpeed] * CartoonGlobals.ASpeedRate;
                    switch (MagicType)
                    {
                        case MagicType.None:
                            
                            
                            if (Class == MirClass.Warrior && Mingwen01 == 135 || Mingwen02 == 135 || Mingwen03 == 135)
                            {
                                MingwenInfo Mingweninfo = CartoonGlobals.MingwenInfoList.Binding.FirstOrDefault((MingwenInfo x) => x.MingWenID == 135);
                                attackDelay -= Mingweninfo.Canshu2 * CartoonGlobals.ASpeedRate;
                            }
                            
                            
                            if (Mingwen01 == 6 || Mingwen02 == 6 || Mingwen03 == 6)
                            {
                                MingwenInfo Mingweninfo = CartoonGlobals.MingwenInfoList.Binding.FirstOrDefault((MingwenInfo x) => x.MingWenID == 6);
                                attackDelay -= Mingweninfo.Canshu1 * CartoonGlobals.ASpeedRate;
                            }
                            break;
                        
                        
                        case MagicType.HalfMoon:
                            if (CanjiyueYinAttack && Mingwen01 == 145 || Mingwen02 == 145 || Mingwen03 == 145)
                            {
                                MingwenInfo Mingweninfo = CartoonGlobals.MingwenInfoList.Binding.FirstOrDefault((MingwenInfo x) => x.MingWenID == 145);
                                attackDelay -= Mingweninfo.Canshu2 * CartoonGlobals.ASpeedRate;
                            }
                            break;
                        case MagicType.DanceOfSwallow:
                            
                            
                            if (Mingwen01 == 239 || Mingwen02 == 239 || Mingwen03 == 239)
                            {
                                MingwenInfo Mingweninfo = CartoonGlobals.MingwenInfoList.Binding.FirstOrDefault((MingwenInfo x) => x.MingWenID == 239);
                                attackDelay -= Mingweninfo.Canshu3 * CartoonGlobals.ASpeedRate;
                            }
                            break;
                    }

                    attackDelay = Math.Max(800, attackDelay);
                    AttackTime = CEnvir.Now + TimeSpan.FromMilliseconds(attackDelay);

                    if (BagWeight > Stats[Stat.BagWeight] || (Poison & PoisonType.Neutralize) == PoisonType.Neutralize)
                        AttackTime += TimeSpan.FromMilliseconds(attackDelay);

                    CEnvir.Enqueue(new C.Attack { Direction = action.Direction, Action = action.Action, AttackMagic = MagicType });
                    GameScene.Game.CanRun = false;
                    break;
                case MirAction.Spell:
                    switch (MagicType)
                    {
                        case MagicType.Heal:
                            
                            
                            if (Mingwen01 == 4 || Mingwen02 == 4 || Mingwen03 == 4)
                            {
                                MingwenInfo Mingweninfo = CartoonGlobals.MingwenInfoList.Binding.FirstOrDefault((MingwenInfo x) => x.MingWenID == 4);
                                NextMagicTime = CEnvir.Now + TimeSpan.FromMilliseconds(Mingweninfo.Canshu2);
                                if (BagWeight > Stats[Stat.BagWeight] || (Poison & PoisonType.Neutralize) == PoisonType.Neutralize)
                                    NextMagicTime += CartoonGlobals.MagicDelay;

                                CEnvir.Enqueue(new C.Magic { Direction = action.Direction, Action = action.Action, Type = MagicType, Target = AttackTargets?.Count > 0 ? AttackTargets[0].ObjectID : 0, Location = MagicLocations?.Count > 0 ? MagicLocations[0] : Point.Empty });
                                GameScene.Game.CanRun = false;
                            }
                            else
                            {
                                NextMagicTime = CEnvir.Now + CartoonGlobals.MagicDelay;
                                if (BagWeight > Stats[Stat.BagWeight] || (Poison & PoisonType.Neutralize) == PoisonType.Neutralize)
                                    NextMagicTime += CartoonGlobals.MagicDelay;

                                CEnvir.Enqueue(new C.Magic { Direction = action.Direction, Action = action.Action, Type = MagicType, Target = AttackTargets?.Count > 0 ? AttackTargets[0].ObjectID : 0, Location = MagicLocations?.Count > 0 ? MagicLocations[0] : Point.Empty });
                                GameScene.Game.CanRun = false;
                            }
                            break;
                        case MagicType.ExplosiveTalisman:
                            
                            
                            if (Mingwen01 == 12 || Mingwen02 == 12 || Mingwen03 == 12)
                            {
                                MingwenInfo Mingweninfo = CartoonGlobals.MingwenInfoList.Binding.FirstOrDefault((MingwenInfo x) => x.MingWenID == 12);
                                NextMagicTime = CEnvir.Now + TimeSpan.FromMilliseconds(Mingweninfo.Canshu4);
                                if (BagWeight > Stats[Stat.BagWeight] || (Poison & PoisonType.Neutralize) == PoisonType.Neutralize)
                                    NextMagicTime += CartoonGlobals.MagicDelay;

                                CEnvir.Enqueue(new C.Magic { Direction = action.Direction, Action = action.Action, Type = MagicType, Target = AttackTargets?.Count > 0 ? AttackTargets[0].ObjectID : 0, Location = MagicLocations?.Count > 0 ? MagicLocations[0] : Point.Empty });
                                GameScene.Game.CanRun = false;
                            }
                            else
                            {
                                NextMagicTime = CEnvir.Now + CartoonGlobals.MagicDelay;
                                if (BagWeight > Stats[Stat.BagWeight] || (Poison & PoisonType.Neutralize) == PoisonType.Neutralize)
                                    NextMagicTime += CartoonGlobals.MagicDelay;

                                CEnvir.Enqueue(new C.Magic { Direction = action.Direction, Action = action.Action, Type = MagicType, Target = AttackTargets?.Count > 0 ? AttackTargets[0].ObjectID : 0, Location = MagicLocations?.Count > 0 ? MagicLocations[0] : Point.Empty });
                                GameScene.Game.CanRun = false;
                            }
                            break;
                        case MagicType.EvilSlayer:
                            
                            
                            if (Mingwen01 == 17 || Mingwen02 == 17 || Mingwen03 == 17)
                            {
                                MingwenInfo Mingweninfo = CartoonGlobals.MingwenInfoList.Binding.FirstOrDefault((MingwenInfo x) => x.MingWenID == 17);
                                NextMagicTime = CEnvir.Now + TimeSpan.FromMilliseconds(Mingweninfo.Canshu2);
                                if (BagWeight > Stats[Stat.BagWeight] || (Poison & PoisonType.Neutralize) == PoisonType.Neutralize)
                                    NextMagicTime += CartoonGlobals.MagicDelay;

                                CEnvir.Enqueue(new C.Magic { Direction = action.Direction, Action = action.Action, Type = MagicType, Target = AttackTargets?.Count > 0 ? AttackTargets[0].ObjectID : 0, Location = MagicLocations?.Count > 0 ? MagicLocations[0] : Point.Empty });
                                GameScene.Game.CanRun = false;
                            }
                            else
                            {
                                NextMagicTime = CEnvir.Now + CartoonGlobals.MagicDelay;
                                if (BagWeight > Stats[Stat.BagWeight] || (Poison & PoisonType.Neutralize) == PoisonType.Neutralize)
                                    NextMagicTime += CartoonGlobals.MagicDelay;

                                CEnvir.Enqueue(new C.Magic { Direction = action.Direction, Action = action.Action, Type = MagicType, Target = AttackTargets?.Count > 0 ? AttackTargets[0].ObjectID : 0, Location = MagicLocations?.Count > 0 ? MagicLocations[0] : Point.Empty });
                                GameScene.Game.CanRun = false;
                            }
                            break;
                        case MagicType.GreaterEvilSlayer:
                            
                            
                            if (Mingwen01 == 28 || Mingwen02 == 28 || Mingwen03 == 28)
                            {
                                MingwenInfo Mingweninfo = CartoonGlobals.MingwenInfoList.Binding.FirstOrDefault((MingwenInfo x) => x.MingWenID == 28);
                                NextMagicTime = CEnvir.Now + TimeSpan.FromMilliseconds(Mingweninfo.Canshu4);
                                if (BagWeight > Stats[Stat.BagWeight] || (Poison & PoisonType.Neutralize) == PoisonType.Neutralize)
                                    NextMagicTime += CartoonGlobals.MagicDelay;

                                CEnvir.Enqueue(new C.Magic { Direction = action.Direction, Action = action.Action, Type = MagicType, Target = AttackTargets?.Count > 0 ? AttackTargets[0].ObjectID : 0, Location = MagicLocations?.Count > 0 ? MagicLocations[0] : Point.Empty });
                                GameScene.Game.CanRun = false;
                            }
                            else
                            {
                                NextMagicTime = CEnvir.Now + CartoonGlobals.MagicDelay;
                                if (BagWeight > Stats[Stat.BagWeight] || (Poison & PoisonType.Neutralize) == PoisonType.Neutralize)
                                    NextMagicTime += CartoonGlobals.MagicDelay;

                                CEnvir.Enqueue(new C.Magic { Direction = action.Direction, Action = action.Action, Type = MagicType, Target = AttackTargets?.Count > 0 ? AttackTargets[0].ObjectID : 0, Location = MagicLocations?.Count > 0 ? MagicLocations[0] : Point.Empty });
                                GameScene.Game.CanRun = false;
                            }
                            break;
                        case MagicType.ImprovedExplosiveTalisman:
                            ClientUserMagic clientUserMagic;
                            MagicInfo magic = CartoonGlobals.MagicInfoList.Binding.FirstOrDefault(x => x.Magic == MagicType.CrazyImprovedExplosiveTalisman);

                            
                            
                            if (Mingwen01 == 56 || Mingwen02 == 56 || Mingwen03 == 56)
                            {
                                MingwenInfo Mingweninfo = CartoonGlobals.MingwenInfoList.Binding.FirstOrDefault((MingwenInfo x) => x.MingWenID == 56);

                                if (magic != null && User.Magics.TryGetValue(magic, out clientUserMagic))
                                {
                                    int sudu = Math.Max(1000, Mingweninfo.Canshu5 - (clientUserMagic.Level * 100));
                                    NextMagicTime = CEnvir.Now + TimeSpan.FromMilliseconds(sudu);
                                    if (BagWeight > Stats[Stat.BagWeight] || (Poison & PoisonType.Neutralize) == PoisonType.Neutralize)
                                        NextMagicTime += CartoonGlobals.MagicDelay;

                                    CEnvir.Enqueue(new C.Magic { Direction = action.Direction, Action = action.Action, Type = MagicType, Target = AttackTargets?.Count > 0 ? AttackTargets[0].ObjectID : 0, Location = MagicLocations?.Count > 0 ? MagicLocations[0] : Point.Empty });
                                    GameScene.Game.CanRun = false;
                                }
                                else
                                {
                                    NextMagicTime = CEnvir.Now + TimeSpan.FromMilliseconds(Mingweninfo.Canshu4);
                                    if (BagWeight > Stats[Stat.BagWeight] || (Poison & PoisonType.Neutralize) == PoisonType.Neutralize)
                                        NextMagicTime += CartoonGlobals.MagicDelay;

                                    CEnvir.Enqueue(new C.Magic { Direction = action.Direction, Action = action.Action, Type = MagicType, Target = AttackTargets?.Count > 0 ? AttackTargets[0].ObjectID : 0, Location = MagicLocations?.Count > 0 ? MagicLocations[0] : Point.Empty });
                                    GameScene.Game.CanRun = false;
                                }
                            }
                            else
                            {
                                if (magic != null && User.Magics.TryGetValue(magic, out clientUserMagic))
                                {
                                    int sudu = Math.Max(1400, 2000 - (clientUserMagic.Level * 200));
                                    NextMagicTime = CEnvir.Now + TimeSpan.FromMilliseconds(sudu);
                                    if (BagWeight > Stats[Stat.BagWeight] || (Poison & PoisonType.Neutralize) == PoisonType.Neutralize)
                                        NextMagicTime += CartoonGlobals.MagicDelay;

                                    CEnvir.Enqueue(new C.Magic { Direction = action.Direction, Action = action.Action, Type = MagicType, Target = AttackTargets?.Count > 0 ? AttackTargets[0].ObjectID : 0, Location = MagicLocations?.Count > 0 ? MagicLocations[0] : Point.Empty });
                                    GameScene.Game.CanRun = false;
                                }
                                else
                                {
                                    NextMagicTime = CEnvir.Now + CartoonGlobals.MagicDelay;
                                    if (BagWeight > Stats[Stat.BagWeight] || (Poison & PoisonType.Neutralize) == PoisonType.Neutralize)
                                        NextMagicTime += CartoonGlobals.MagicDelay;

                                    CEnvir.Enqueue(new C.Magic { Direction = action.Direction, Action = action.Action, Type = MagicType, Target = AttackTargets?.Count > 0 ? AttackTargets[0].ObjectID : 0, Location = MagicLocations?.Count > 0 ? MagicLocations[0] : Point.Empty });
                                    GameScene.Game.CanRun = false;
                                }
                            }
                            break;
                        case MagicType.ThunderBolt:
                            
                            
                            if (Mingwen01 == 109 || Mingwen02 == 109 || Mingwen03 == 109)
                            {
                                MingwenInfo Mingweninfo = CartoonGlobals.MingwenInfoList.Binding.FirstOrDefault((MingwenInfo x) => x.MingWenID == 109);
                                NextMagicTime = CEnvir.Now + TimeSpan.FromMilliseconds(Mingweninfo.Canshu2);
                                if (BagWeight > Stats[Stat.BagWeight] || (Poison & PoisonType.Neutralize) == PoisonType.Neutralize)
                                    NextMagicTime += CartoonGlobals.MagicDelay;

                                CEnvir.Enqueue(new C.Magic { Direction = action.Direction, Action = action.Action, Type = MagicType, Target = AttackTargets?.Count > 0 ? AttackTargets[0].ObjectID : 0, Location = MagicLocations?.Count > 0 ? MagicLocations[0] : Point.Empty });
                                GameScene.Game.CanRun = false;
                            }
                            else
                            {
                                NextMagicTime = CEnvir.Now + CartoonGlobals.MagicDelay;
                                if (BagWeight > Stats[Stat.BagWeight] || (Poison & PoisonType.Neutralize) == PoisonType.Neutralize)
                                    NextMagicTime += CartoonGlobals.MagicDelay;

                                CEnvir.Enqueue(new C.Magic { Direction = action.Direction, Action = action.Action, Type = MagicType, Target = AttackTargets?.Count > 0 ? AttackTargets[0].ObjectID : 0, Location = MagicLocations?.Count > 0 ? MagicLocations[0] : Point.Empty });
                                GameScene.Game.CanRun = false;
                            }
                            break;
                        case MagicType.FireStorm:
                            
                            
                            if (Mingwen01 == 129 || Mingwen02 == 129 || Mingwen03 == 129)
                            {
                                MingwenInfo Mingweninfo = CartoonGlobals.MingwenInfoList.Binding.FirstOrDefault((MingwenInfo x) => x.MingWenID == 129);
                                NextMagicTime = CEnvir.Now + TimeSpan.FromMilliseconds(Mingweninfo.Canshu2);
                                if (BagWeight > Stats[Stat.BagWeight] || (Poison & PoisonType.Neutralize) == PoisonType.Neutralize)
                                    NextMagicTime += CartoonGlobals.MagicDelay;

                                CEnvir.Enqueue(new C.Magic { Direction = action.Direction, Action = action.Action, Type = MagicType, Target = AttackTargets?.Count > 0 ? AttackTargets[0].ObjectID : 0, Location = MagicLocations?.Count > 0 ? MagicLocations[0] : Point.Empty });
                                GameScene.Game.CanRun = false;
                            }
                            else
                            {
                                NextMagicTime = CEnvir.Now + CartoonGlobals.MagicDelay;
                                if (BagWeight > Stats[Stat.BagWeight] || (Poison & PoisonType.Neutralize) == PoisonType.Neutralize)
                                    NextMagicTime += CartoonGlobals.MagicDelay;

                                CEnvir.Enqueue(new C.Magic { Direction = action.Direction, Action = action.Action, Type = MagicType, Target = AttackTargets?.Count > 0 ? AttackTargets[0].ObjectID : 0, Location = MagicLocations?.Count > 0 ? MagicLocations[0] : Point.Empty });
                                GameScene.Game.CanRun = false;
                            }
                            break;
                        default:
                            NextMagicTime = CEnvir.Now + CartoonGlobals.MagicDelay;
                            if (BagWeight > Stats[Stat.BagWeight] || (Poison & PoisonType.Neutralize) == PoisonType.Neutralize)
                                NextMagicTime += CartoonGlobals.MagicDelay;

                            CEnvir.Enqueue(new C.Magic { Direction = action.Direction, Action = action.Action, Type = MagicType, Target = AttackTargets?.Count > 0 ? AttackTargets[0].ObjectID : 0, Location = MagicLocations?.Count > 0 ? MagicLocations[0] : Point.Empty });
                            GameScene.Game.CanRun = false;
                            return;

                    }
                    break;
                /*
            case MirAction.Spell:
                NextMagicTime = CEnvir.Now + CartoonGlobals.MagicDelay;

                if (BagWeight > Stats[Stat.BagWeight] || (Poison & PoisonType.Neutralize) == PoisonType.Neutralize)
                    NextMagicTime += CartoonGlobals.MagicDelay;

                CEnvir.Enqueue(new C.Magic { Direction = action.Direction, Action = action.Action, Type = MagicType, Target = AttackTargets?.Count > 0 ? AttackTargets[0].ObjectID : 0, Location = MagicLocations?.Count > 0 ? MagicLocations[0] : Point.Empty });
                GameScene.Game.CanRun = false;
                break;
                */
                case MirAction.Mining:
                    attackDelay = CartoonGlobals.AttackDelay - Stats[Stat.AttackSpeed] * CartoonGlobals.ASpeedRate;
                    attackDelay = Math.Max(800, attackDelay);
                    AttackTime = CEnvir.Now + TimeSpan.FromMilliseconds(attackDelay);

                    if (BagWeight > Stats[Stat.BagWeight] || (Poison & PoisonType.Neutralize) == PoisonType.Neutralize)
                        AttackTime += TimeSpan.FromMilliseconds(attackDelay);

                    CEnvir.Enqueue(new C.Mining { Direction = action.Direction });
                    GameScene.Game.CanRun = false;
                    break;
                default:
                    GameScene.Game.CanRun = false;
                    break;
            }
            ServerTime = CEnvir.Now.AddSeconds(5);

        }

        public override void Process()
        {
            base.Process();

            if (DrawColour == DefaultColour)
            {
                if (BagWeight > Stats[Stat.BagWeight] || WearWeight > Stats[Stat.WearWeight] || HandWeight > Stats[Stat.HandWeight])
                    DrawColour = Color.CornflowerBlue;
            }


            
            TimeSpan shakeTicks = CEnvir.Now - ShakeScreenTime;
            ShakeScreenTime = CEnvir.Now;
            ShakeScreenOffset = new Point(new Random().Next(-(int)Math.Abs(ShakeScreenCount * 1f), (int)Math.Abs(ShakeScreenCount * 1f)),
                                          new Random().Next(-(int)Math.Abs(ShakeScreenCount * 2f), (int)Math.Abs(ShakeScreenCount * 2f)));
            
            if (ShakeScreenCount > 0)
            {
                ShakeScreenCount -= (float)shakeTicks.TotalMilliseconds / 50f;
                GameScene.Game.MapControl.FLayer.TextureValid = false;
            }
            else if (ShakeScreenCount < 0)
            {
                ShakeScreenCount = 0;
                ShakeScreenOffset = new Point(0, 0);
                GameScene.Game.MapControl.FLayer.TextureValid = false;
            }

            TimeSpan ticks = CEnvir.Now - BuffTime;
            BuffTime = CEnvir.Now;

            foreach (ClientBuffInfo buff in Buffs)
            {
                if (buff.Pause || buff.RemainingTime == TimeSpan.MaxValue) continue;
                buff.RemainingTime = Functions.Max(TimeSpan.Zero, buff.RemainingTime - ticks);

                switch (buff.Type)
                {
                    case BuffType.VipMapY:
                        GameScene.Game.AttackModeBox.HuiyuanTimeLabel.Text = $"青铜会员持续时间: {Functions.ToString(buff.RemainingTime, true)}";
                        break;
                    case BuffType.VipMapE:
                        GameScene.Game.AttackModeBox.HuiyuanTimeLabel.Text = $"白银会员持续时间: {Functions.ToString(buff.RemainingTime, true)}";
                        break;
                    case BuffType.VipMapS:
                        GameScene.Game.AttackModeBox.HuiyuanTimeLabel.Text = $"黄金会员持续时间: {Functions.ToString(buff.RemainingTime, true)}";
                        break;
                }
            }


        }

        public override void FrameIndexChanged()
        {
            base.FrameIndexChanged();

            switch (CurrentAction)
            {
                case MirAction.Moving:
                    switch (CurrentAnimation)
                    {
                        case MirAnimation.HorseWalking:
                            if (FrameIndex == 1)
                                DXSoundManager.Play(SoundIndex.HorseWalk1);
                            if (FrameIndex == 4)
                                DXSoundManager.Play(SoundIndex.HorseWalk2);
                            break;
                        case MirAnimation.HorseRunning:
                            if (FrameIndex != 1) return;
                            DXSoundManager.Play(SoundIndex.HorseRun);
                            break;
                        default:
                            if (FrameIndex != 1 && FrameIndex != 4) return;
                            DXSoundManager.Play((SoundIndex)((int)SoundIndex.Foot1 + CEnvir.Random.Next((int)SoundIndex.Foot4 - (int)SoundIndex.Foot1) + 1));
                            break;
                    }
                    break;
                case MirAction.Attack:
                    switch (MagicType)
                    {
                        case MagicType.SweetBrier:      
                            if (FrameIndex == 4)
                            {
                                if (Config.是否开启震动效果)
                                    ShakeScreenCount = 10F;    
                            }
                            break;
                    }
                    break;
                case MirAction.Spell:
                    switch (MagicType)
                    {
                        case MagicType.SeismicSlam:      
                            if (FrameIndex == 4)
                            {
                                if (Config.是否开启震动效果)
                                    ShakeScreenCount = 10F;    
                            }
                            break;
                        case MagicType.Asteroid:      
                            if (FrameIndex == 4)
                            {
                                if (Config.是否开启震动效果)
                                    ShakeScreenCount = 10F;    
                            }
                            break;
                        case MagicType.DemonExplosion:      
                            if (FrameIndex == 4)
                            {
                                if (Config.是否开启震动效果)
                                    ShakeScreenCount = 10F;    
                            }
                            break;
                    }
                    break;
            }
        }


        
        
        
        bool _isInSafeZone = true;
        public Point ReverseMovingOffSet = Point.Empty;
        public override void MovingOffSetChanged()
        {
            base.MovingOffSetChanged();
            GameScene.Game.MapControl.FLayer.TextureValid = false;

            if (_isInSafeZone != InSafeZone)
            {
                _isInSafeZone = InSafeZone;
                var str = InSafeZone ? "进入" : "离开";
                GameScene.Game.ReceiveChat($"你{str}安全区", MessageType.System);
            }
            for (int i = 0; i < GameScene.Game.ParticleEngines.Count; i++)
                GameScene.Game.ParticleEngines[i].ParticlesOffSet(ReverseMovingOffSet);

        }


        public override void NameChanged()
        {
            base.NameChanged();

            GameScene.Game.CharacterBox.GuildNameLabel.Text = Title;
            GameScene.Game.CharacterBox.GuildRankLabel.Text = GuildRank;

            GameScene.Game.CharacterBox.CharacterNameLabel.Text = Name;
            GameScene.Game.TradeBox.UserLabel.Text = Name;
        }

        public void AddBuff(ClientBuffInfo buff)
        {
            Buffs.Add(buff);
            VisibleBuffs.Add(buff.Type);

            if (buff.Type == BuffType.SuperiorMagicShield)
            {
                MaximumSuperiorMagicShield = buff.Stats[Stat.SuperiorMagicShield];
                MagicShieldEnd();
            }
        }

        #region 平滑绘制

        public int SubFrame = -1;
        public int Mir2SubFrame = -1;
        public int LastFrame = -1;
        public int Mir2LastFrame = -1;
        public int FrameCount = -1;
        public int Mir2FrameCount = -1;
        #endregion


        public override void UpdateFrame()
        {
            
            
            
            

            
            if (Frames == null || CurrentFrame == null) return;
            switch (CurrentAction)
            {
                case MirAction.Moving:  
                case MirAction.Pushed:  
                    
                    if (Config.SmoothRendering)
                    {
                        if (!CurrentFrame.Reversed)
                            if (!GameScene.Game.MoveFrame && !GameScene.Game.SubMoveFrame) return;
                    }
                    else
                    {
                        if (!GameScene.Game.MoveFrame) return;
                    }
                    break;
            }

            if (Config.SmoothRendering)
            {
                if (CurrentAction - 1 > MirAction.Moving || GameScene.Game.MoveFrame)
                {
                    FrameCount = CurrentFrame.GetFrame(FrameStart, CEnvir.Now, (this != User || GameScene.Game.Observer) && ActionQueue.Count > 1);

                    if (FrameCount == CurrentFrame.FrameCount || (Interupt && ActionQueue.Count > 0))
                    {
                        DoNextAction();
                        FrameCount = CurrentFrame.GetFrame(FrameStart, CEnvir.Now, (this != User || GameScene.Game.Observer) && ActionQueue.Count > 1);

                        if (FrameCount == CurrentFrame.FrameCount)
                        {
                            FrameCount--;
                        }

                    }
                }
            }
            else
            {
                
                FrameCount = CurrentFrame.GetFrame(FrameStart, CEnvir.Now, (this != User || GameScene.Game.Observer) && ActionQueue.Count > 1);

                if (FrameCount == CurrentFrame.FrameCount || (Interupt && ActionQueue.Count > 0))
                {
                    DoNextAction();
                    FrameCount = CurrentFrame.GetFrame(FrameStart, CEnvir.Now, (this != User || GameScene.Game.Observer) && ActionQueue.Count > 1);

                    if (FrameCount == CurrentFrame.FrameCount)
                        FrameCount -= 1;
                }
            }

            
            if (Config.SmoothRendering)
            {
                if (LastFrame != FrameCount)
                {
                    LastFrame = FrameCount;
                    SubFrame = FrameCount * Config.SmoothRenderingRate;
                }
            }

            int x = 0, y = 0, reversex = 0, reversey = 0;
            if (Config.SmoothRendering)
            {
                switch (CurrentAction)
                {
                    case MirAction.Moving:
                    case MirAction.Pushed:
                        switch (Direction)
                        {
                            case MirDirection.Up:
                                x = 0;
                                reversex = 0;

                                y = (int)((float)(CellHeight * MoveDistance) / (float)(CurrentFrame.FrameCount * Config.SmoothRenderingRate) * (float)(CurrentFrame.FrameCount * Config.SmoothRenderingRate - (SubFrame + 1)));

                                if (y < 0)
                                {
                                    y = 0;
                                }
                                reversey = 6;
                                break;
                            case MirDirection.UpRight:

                                x = -(int)((float)(CellWidth * MoveDistance) / (float)(CurrentFrame.FrameCount * Config.SmoothRenderingRate) * (float)(CurrentFrame.FrameCount * Config.SmoothRenderingRate - (SubFrame + 1)));
                                y = (int)((float)(CellHeight * MoveDistance) / (float)(CurrentFrame.FrameCount * Config.SmoothRenderingRate) * (float)(CurrentFrame.FrameCount * Config.SmoothRenderingRate - (SubFrame + 1)));

                                if (x > 0)
                                {
                                    x = 0;
                                }
                                if (y < 0)
                                {
                                    y = 0;
                                }
                                reversex = -8;
                                reversey = 6;
                                break;
                            case MirDirection.Right:

                                x = -(int)((float)(CellWidth * MoveDistance) / (float)(CurrentFrame.FrameCount * Config.SmoothRenderingRate) * (float)(CurrentFrame.FrameCount * Config.SmoothRenderingRate - (SubFrame + 1)));

                                if (x > 0)
                                {
                                    x = 0;
                                }
                                reversex = -8;
                                y = 0;
                                reversey = 0;
                                break;
                            case MirDirection.DownRight:

                                x = -(int)((float)(CellWidth * MoveDistance) / (float)(CurrentFrame.FrameCount * Config.SmoothRenderingRate) * (float)(CurrentFrame.FrameCount * Config.SmoothRenderingRate - (SubFrame + 1)));
                                y = -(int)((float)(CellHeight * MoveDistance) / (float)(CurrentFrame.FrameCount * Config.SmoothRenderingRate) * (float)(CurrentFrame.FrameCount * Config.SmoothRenderingRate - (SubFrame + 1)));

                                if (x > 0)
                                {
                                    x = 0;
                                }
                                if (y > 0)
                                {
                                    y = 0;
                                }
                                reversex = -8;
                                reversey = -6;
                                break;
                            case MirDirection.Down:
                                x = 0;
                                reversex = 0;

                                y = -(int)((float)(CellHeight * MoveDistance) / (float)(CurrentFrame.FrameCount * Config.SmoothRenderingRate) * (float)(CurrentFrame.FrameCount * Config.SmoothRenderingRate - (SubFrame + 1)));

                                if (y > 0)
                                {
                                    y = 0;
                                }
                                reversey = -6;
                                break;
                            case MirDirection.DownLeft:

                                x = (int)((float)(CellWidth * MoveDistance) / (float)(CurrentFrame.FrameCount * Config.SmoothRenderingRate) * (float)(CurrentFrame.FrameCount * Config.SmoothRenderingRate - (SubFrame + 1)));
                                y = -(int)((float)(CellHeight * MoveDistance) / (float)(CurrentFrame.FrameCount * Config.SmoothRenderingRate) * (float)(CurrentFrame.FrameCount * Config.SmoothRenderingRate - (SubFrame + 1)));

                                if (x < 0)
                                {
                                    x = 0;
                                }
                                if (y > 0)
                                {
                                    y = 0;
                                }
                                reversex = 8;
                                reversey = -6;
                                break;
                            case MirDirection.Left:

                                x = (int)((float)(CellWidth * MoveDistance) / (float)(CurrentFrame.FrameCount * Config.SmoothRenderingRate) * (float)(CurrentFrame.FrameCount * Config.SmoothRenderingRate - (SubFrame + 1)));

                                if (x < 0)
                                {
                                    x = 0;
                                }
                                reversex = 8;
                                y = 0;
                                reversey = 0;
                                break;
                            case MirDirection.UpLeft:

                                x = (int)((float)(CellWidth * MoveDistance) / (float)(CurrentFrame.FrameCount * Config.SmoothRenderingRate) * (float)(CurrentFrame.FrameCount * Config.SmoothRenderingRate - (SubFrame + 1)));
                                y = (int)((float)(CellHeight * MoveDistance) / (float)(CurrentFrame.FrameCount * Config.SmoothRenderingRate) * (float)(CurrentFrame.FrameCount * Config.SmoothRenderingRate - (SubFrame + 1)));

                                if (x < 0)
                                {
                                    x = 0;
                                }
                                if (y < 0)
                                {
                                    y = 0;
                                }
                                reversex = 8;
                                reversey = 6;
                                break;
                        }

                        SubFrame++;
                        break;
                }
            }
            else
            {
                switch (CurrentAction)
                {
                    case MirAction.Moving:
                    case MirAction.Pushed:
                        switch (Direction)
                        {
                            case MirDirection.Up:
                                x = 0;
                                reversex = 0;

                                y = (int)(CellHeight * MoveDistance / (float)CurrentFrame.FrameCount * (CurrentFrame.FrameCount - (FrameCount + 1)));

                                reversey = 6;
                                break;
                            case MirDirection.UpRight:

                                x = -(int)(CellWidth * MoveDistance / (float)CurrentFrame.FrameCount * (CurrentFrame.FrameCount - (FrameCount + 1)));
                                y = (int)(CellHeight * MoveDistance / (float)CurrentFrame.FrameCount * (CurrentFrame.FrameCount - (FrameCount + 1)));

                                reversex = -8;
                                reversey = 6;
                                break;
                            case MirDirection.Right:

                                x = -(int)(CellWidth * MoveDistance / (float)CurrentFrame.FrameCount * (CurrentFrame.FrameCount - (FrameCount + 1)));

                                reversex = -8;
                                y = 0;
                                reversey = 0;
                                break;
                            case MirDirection.DownRight:

                                x = -(int)(CellWidth * MoveDistance / (float)CurrentFrame.FrameCount * (CurrentFrame.FrameCount - (FrameCount + 1)));
                                y = -(int)(CellHeight * MoveDistance / (float)CurrentFrame.FrameCount * (CurrentFrame.FrameCount - (FrameCount + 1)));

                                reversex = -8;
                                reversey = -6;
                                break;
                            case MirDirection.Down:

                                y = -(int)(CellHeight * MoveDistance / (float)CurrentFrame.FrameCount * (CurrentFrame.FrameCount - (FrameCount + 1)));

                                x = 0;
                                reversex = 0;
                                reversey = -6;
                                break;
                            case MirDirection.DownLeft:

                                x = (int)(CellWidth * MoveDistance / (float)CurrentFrame.FrameCount * (CurrentFrame.FrameCount - (FrameCount + 1)));
                                y = -(int)(CellHeight * MoveDistance / (float)CurrentFrame.FrameCount * (CurrentFrame.FrameCount - (FrameCount + 1)));

                                reversex = 8;
                                reversey = -6;
                                break;
                            case MirDirection.Left:

                                x = (int)(CellWidth * MoveDistance / (float)CurrentFrame.FrameCount * (CurrentFrame.FrameCount - (FrameCount + 1)));

                                reversex = 8;
                                y = 0;
                                reversey = 0;
                                break;
                            case MirDirection.UpLeft:

                                x = (int)(CellWidth * MoveDistance / (float)CurrentFrame.FrameCount * (CurrentFrame.FrameCount - (FrameCount + 1)));
                                y = (int)(CellHeight * MoveDistance / (float)CurrentFrame.FrameCount * (CurrentFrame.FrameCount - (FrameCount + 1)));

                                reversex = 8;
                                reversey = 6;
                                break;
                        }
                        break;
                }

            }

            x -= x % 2;
            y -= y % 2;
            reversex -= reversex % 2;
            reversey -= reversey % 2;

            if (CurrentFrame.Reversed)
            {
                FrameCount = CurrentFrame.FrameCount - FrameCount - 1;
                x *= -1;
                y *= -1;
                reversex *= -1;
                reversey *= -1;
            }

            
            if (GameScene.Game.MapControl.BackgroundImage != null)
                GameScene.Game.MapControl.BackgroundMovingOffset = new Point((int)(x / GameScene.Game.MapControl.BackgroundScaleX), (int)(y / GameScene.Game.MapControl.BackgroundScaleY));

            ReverseMovingOffSet = new Point(reversex, reversey);

            
            MovingOffSet = new Point(x, y);

            if (CurrentAction == MirAction.Pushed)
            {
                FrameCount = 0;
                Mir2FrameCount = 0;
            }

            FrameIndex = FrameCount;
            
            if (Config.SmoothRendering)
            {
                DrawFrame = FrameIndex % (CurrentFrame.FrameCount / CurrentFrame.RepeatTimes) + CurrentFrame.StartIndex + CurrentFrame.OffSet * (int)Direction;
            }
            else
            {
                DrawFrame = FrameIndex + CurrentFrame.StartIndex + CurrentFrame.OffSet * (int)Direction;
            }
        }
    }
}
