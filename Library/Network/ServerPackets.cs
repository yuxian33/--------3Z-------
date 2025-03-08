using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Library.SystemModels;

namespace Library.Network.ServerPackets
{
    public sealed class NewAccount : Packet
    {
        public NewAccountResult Result { get; set; }
    }
    public sealed class ChangePassword : Packet
    {
        public ChangePasswordResult Result { get; set; }

        public string Message { get; set; }
        public TimeSpan Duration { get; set; }
    }

    public sealed class PatchGridSize : Packet
    {
        public int Size { get; set; }
    }

    public sealed class BaoshiGridSize : Packet
    {
        public int Size { get; set; }
    }

    public sealed class AutoTimeChanged : Packet
    {
        public long AutoTime { get; set; }
    }

    
    public sealed class HuanhuaGuagouChanged : Packet
    {
        public bool HuanhuaGuagou { get; set; }
    }

    
    public sealed class Baoshi5433Changed : Packet
    {
        public bool Baoshi5433 { get; set; }
    }

    
    public sealed class JYhuishouChanged : Packet
    {
        public int JYhuishou { get; set; }
    }

    
    public sealed class ZhuangbeiFenjieChanged : Packet
    {
        public int Fenjie { get; set; }
    }

    
    public sealed class GuildLevelChanged : Packet
    {
        public bool GuildLevel { get; set; }
    }

    
    public sealed class GuanggaolanChanged : Packet
    {
        public bool Shifoukaiqi { get; set; }
        public int Kuandu { get; set; }
        public int Gaodu { get; set; }
        public string Biaoti { get; set; }
    }
    
    public sealed class Qiehuanxunzhaoguaiwumoshi : Packet
    {
        public bool Moshi01 { get; set; }
        public bool Moshi02 { get; set; }
    }
    
    public sealed class TestGj : Packet
    {
        public string Text { get; set; }

        public TimeSpan AnswerTime { get; set; }
    }

    public sealed class ZidongGjguanbi : Packet
    {
        public bool Zdgjgongneng { get; set; }
    }
    public sealed class CraftInformation : Packet
    {
        public List<ClientUserCrafting> CraftInfo
        {
            get;
            set;
        }

        public uint ObjectID
        {
            get;
            set;
        }
    }
    public sealed class CraftingFinished : Packet
    {
        public List<CellLinkInfo> Links
        {
            get;
            set;
        }
    }

    public sealed class UpdateMiniGames : Packet
    {
        public List<ClientMiniGames> games
        {
            get;
            set;
        }
    }
    public sealed class HasFlag : Packet
    {
        public uint ObjectID
        {
            get;
            set;
        }

        public bool hasFLag
        {
            get;
            set;
        }
    }

    public sealed class ObjectFlagColour : Packet
    {
        public uint ObjectID
        {
            get;
            set;
        }

        public Color FlagColour
        {
            get;
            set;
        }

        public int FlagShape
        {
            get;
            set;
        }

        public string name
        {
            get;
            set;
        }
    }

    public sealed class SetTeam : Packet
    {
        public uint ObjectID
        {
            get;
            set;
        }

        public int team
        {
            get;
            set;
        }
    }

    public sealed class NewInstance : Packet
    {
        public ClientMapInfo newinfo
        {
            get;
            set;
        }
    }
    public sealed class HorseAdopt : Packet
    {
        public int Index
        {
            get;
            set;
        }
    }
    public sealed class HorseRetrieve : Packet
    {
        public int Index
        {
            get;
            set;
        }
    }
    public sealed class HorseStore : Packet
    {
    }
    public sealed class HorseUnlock : Packet
    {
        public int Index
        {
            get;
            set;
        }
    }
    public sealed class Login : Packet
    {
        public LoginResult Result { get; set; }

        public string Message { get; set; }
        public TimeSpan Duration { get; set; } 

        public List<SelectInfo> Characters { get; set; }
        public List<ClientUserItem> Items { get; set; }

        public List<ClientBlockInfo> BlockList { get; set; }

        public string Address { get; set; }

        public bool TestServer { get; set; }
    }
    public sealed class RequestPasswordReset : Packet
    {
        public RequestPasswordResetResult Result { get; set; }
        public string Message { get; set; }
        public TimeSpan Duration { get; set; }
    }
    public sealed class ResetPassword : Packet
    {
        public ResetPasswordResult Result { get; set; }
    }
    public sealed class Activation : Packet
    {
        public ActivationResult Result { get; set; }
    }
    public sealed class RequestActivationKey : Packet
    {
        public RequestActivationKeyResult Result { get; set; }
        public TimeSpan Duration { get; set; }
    }

    public sealed class TreasureChest : Packet
    {
        public int Count { get; set; }

        public int Cost { get; set; }

        public List<ClientUserItem> Items { get; set; }
    }
    public sealed class TreasureSel : Packet
    {
        public int Count { get; set; }

        public int Slot { get; set; }

        public int Cost { get; set; }

        public ClientUserItem Item { get; set; }
    }

    public sealed class SelectLogout : Packet
    {
    }
    public sealed class GameLogout : Packet
    {
        public List<SelectInfo> Characters { get; set; }
    }
    
    public sealed class NewCharacter : Packet
    {
        public NewCharacterResult Result { get; set; }

        public SelectInfo Character { get; set; }
    }
    
    public sealed class DeleteCharacter : Packet
    {
        public DeleteCharacterResult Result { get; set; }

        public int DeletedIndex { get; set; }
    }
    public sealed class StartGame : Packet
    {
        public StartGameResult Result { get; set; }

        public string Message { get; set; }
        public TimeSpan Duration { get; set; }

        public StartInformation StartInformation { get; set; }
    }


    public sealed class MapChanged : Packet
    {
        public int MapIndex { get; set; }
    }
    public sealed class UserLocation : Packet
    {
        public MirDirection Direction { get; set; }
        public Point Location { get; set; }
    }
    public sealed class ObjectRemove : Packet
    {
        public uint ObjectID { get; set; }
    }

    public sealed class ObjectTurn : Packet
    {
        public uint ObjectID { get; set; }
        public MirDirection Direction { get; set; }
        public Point Location { get; set; }
        public TimeSpan Slow { get; set; }
    }
    public sealed class ObjectHarvest : Packet
    {
        public uint ObjectID { get; set; }
        public MirDirection Direction { get; set; }
        public Point Location { get; set; }
        public TimeSpan Slow { get; set; }
    }

    public sealed class ObjectMount : Packet
    {
        public uint ObjectID { get; set; }
        public HorseType Horse { get; set; }
    }
    public sealed class ObjectMove : Packet
    {
        public uint ObjectID { get; set; }
        public MirDirection Direction { get; set; }
        public Point Location { get; set; }
        public int Distance { get; set; }
        public TimeSpan Slow { get; set; }
    }
    public sealed class ObjectDash : Packet
    {
        public uint ObjectID { get; set; }
        public MirDirection Direction { get; set; }
        public Point Location { get; set; }
        public int Distance { get; set; }
        public MagicType Magic { get; set; }
    }

    public sealed class ObjectPushed : Packet
    {
        public uint ObjectID { get; set; }
        public MirDirection Direction { get; set; }
        public Point Location { get; set; }
    }

    public sealed class ObjectAttack : Packet
    {
        public uint ObjectID { get; set; }

        public MirDirection Direction { get; set; }
        public Point Location { get; set; }

        public MagicType AttackMagic { get; set; }
        public Element AttackElement { get; set; }

        public uint TargetID { get; set; }

        public TimeSpan Slow { get; set; }
    }
    public sealed class ObjectRangeAttack : Packet
    {
        public uint ObjectID { get; set; }

        public MirDirection Direction { get; set; }
        public Point Location { get; set; }

        public MagicType AttackMagic { get; set; }
        public Element AttackElement { get; set; }

        public List<uint> Targets { get; set; } = new List<uint>();
    }

    public sealed class MapTime : Packet
    {
        public bool OnOff { get; set; }

        public TimeSpan MapRemaining { get; set; }

        public bool ExpiryOnff { get; set; }

        public TimeSpan ExpiryRemaining { get; set; }
    }

    public sealed class ObjectMagic : Packet
    {
        public uint ObjectID { get; set; }

        public MirDirection Direction { get; set; }
        public Point CurrentLocation { get; set; }
        
        public MagicType Type { get; set; }
        public List<uint> Targets { get; set; } = new List<uint>();
        public List<Point> Locations { get; set; } = new List<Point>();
        public bool Cast { get; set; }

        public Element AttackElement { get; set; }

        public TimeSpan Slow { get; set; }
    }
    public sealed class ObjectMining : Packet
    {
        public uint ObjectID { get; set; }

        public MirDirection Direction { get; set; }
        public Point Location { get; set; }

        public TimeSpan Slow { get; set; }
        public bool Effect { get; set; }
    }

    public sealed class ObjectPetOwnerChanged : Packet
    {
        public uint ObjectID { get; set; }
        public string PetOwner { get; set; }
    }

    public sealed class ObjectShow : Packet
    {
        public uint ObjectID { get; set; }

        public MirDirection Direction { get; set; }
        public Point Location { get; set; }
    }
    public sealed class ObjectHide : Packet
    {
        public uint ObjectID { get; set; }

        public MirDirection Direction { get; set; }
        public Point Location { get; set; }
    }
    public sealed class ObjectEffect : Packet
    {
        public uint ObjectID { get; set; }

        public Effect Effect { get; set; }
    }
    public sealed class MapEffect : Packet
    {
        public Point Location { get; set; }
        public Effect Effect { get; set; }
        public MirDirection Direction { get; set; }
    }
    public sealed class Mapplayer : Packet
    {
        public Point Location { get; set; }
        public Effect Effect { get; set; }
        public MirDirection Direction { get; set; }
    }
    public sealed class Exp : Packet
    {
        public Point Location { get; set; }
        public Effect Effect { get; set; }
        public MirDirection Direction { get; set; }
    }
    public sealed class GoldExp : Packet
    {
        public Point Location { get; set; }
        public Effect Effect { get; set; }
        public MirDirection Direction { get; set; }
    }
    public sealed class Mapmonster : Packet
    {
        public Point Location { get; set; }
        public Effect Effect { get; set; }
        public MirDirection Direction { get; set; }
    }
    public sealed class Mapnpc : Packet
    {
        public Point Location { get; set; }
        public Effect Effect { get; set; }
        public MirDirection Direction { get; set; }
    }
    public sealed class RWBuffyi : Packet
    {
        public Point Location { get; set; }
        public Effect Effect { get; set; }
        public MirDirection Direction { get; set; }
    }
    public sealed class RWBuffer : Packet
    {
        public Point Location { get; set; }
        public Effect Effect { get; set; }
        public MirDirection Direction { get; set; }
    }
    public sealed class RWBuffsan : Packet
    {
        public Point Location { get; set; }
        public Effect Effect { get; set; }
        public MirDirection Direction { get; set; }
    }
    public sealed class RWBuffsi : Packet
    {
        public Point Location { get; set; }
        public Effect Effect { get; set; }
        public MirDirection Direction { get; set; }
    }
    public sealed class RWBuffwu : Packet
    {
        public Point Location { get; set; }
        public Effect Effect { get; set; }
        public MirDirection Direction { get; set; }
    }
    public sealed class RWBuffliu : Packet
    {
        public Point Location { get; set; }
        public Effect Effect { get; set; }
        public MirDirection Direction { get; set; }
    }
    public sealed class RWBuffqi : Packet
    {
        public Point Location { get; set; }
        public Effect Effect { get; set; }
        public MirDirection Direction { get; set; }
    }
    public sealed class RWBuffba : Packet
    {
        public Point Location { get; set; }
        public Effect Effect { get; set; }
        public MirDirection Direction { get; set; }
    }
    public sealed class RWBuffjiu : Packet
    {
        public Point Location { get; set; }
        public Effect Effect { get; set; }
        public MirDirection Direction { get; set; }
    }
    public sealed class RWBuffshi : Packet
    {
        public Point Location { get; set; }
        public Effect Effect { get; set; }
        public MirDirection Direction { get; set; }
    }

    public sealed class ToGetSortItem : Packet
    {
        public List<ClientUserItem> Items { get; set; }
    }
    
    public sealed class Renshu : Packet
    {
        public Point Location { get; set; }
        public Effect Effect { get; set; }
        public MirDirection Direction { get; set; }
    }
    public sealed class BossCount : Packet
    {
        public Point Location { get; set; }
        public Effect Effect { get; set; }
        public MirDirection Direction { get; set; }
    }
    public sealed class MonCount : Packet
    {
        public Point Location { get; set; }
        public Effect Effect { get; set; }
        public MirDirection Direction { get; set; }
    }
    
    public sealed class Youliang : Packet
    {
        public Point Location { get; set; }
        public Effect Effect { get; set; }
        public MirDirection Direction { get; set; }
    }
    
    public sealed class Jingzhi : Packet
    {
        public Point Location { get; set; }
        public Effect Effect { get; set; }
        public MirDirection Direction { get; set; }
    }
    
    public sealed class Chuanshuo : Packet
    {
        public Point Location { get; set; }
        public Effect Effect { get; set; }
        public MirDirection Direction { get; set; }
    }
    
    public sealed class Shenhua : Packet
    {
        public Point Location { get; set; }
        public Effect Effect { get; set; }
        public MirDirection Direction { get; set; }
    }
    public sealed class ObjectBuffAdd : Packet
    {
        public uint ObjectID { get; set; }
        public BuffType Type { get; set; }
    }
    public sealed class ObjectBuffRemove : Packet
    {
        public uint ObjectID { get; set; }
        public BuffType Type { get; set; }
    }
    public sealed class ObjectPoison : Packet
    {
        public uint ObjectID { get; set; }
        public PoisonType Poison { get; set; }
    }
    public sealed class ObjectPlayer : Packet
    {
        public int Index { get; set; }

        public uint ObjectID { get; set; }
        public string Name { get; set; }
        public Color NameColour { get; set; }
        public string GuildName { get; set; }

        public MirDirection Direction { get; set; }
        public Point Location { get; set; }

        public MirClass Class { get; set; }
        public MirGender Gender { get; set; }
        
        public int HairType { get; set; }
        public Color HairColour { get; set; }
        public int Weapon { get; set; }
        public int Shield { get; set; }
        public int Emblem { get; set; }
        public int Armour { get; set; }
        public Color ArmourColour { get; set; }
        public int ArmourImage { get; set; }
        public int WeaponImage { get; set; }

        
        public int Shizhuang { get; set; }
        public int ShizhuangImage { get; set; }

        public int Light { get; set; }

        public bool Dead { get; set; }
        public PoisonType Poison { get; set; }

        public List<BuffType> Buffs { get; set; }

        public HorseType Horse { get; set; }

        public int Helmet { get; set; }

        public int Dunpai { get; set; }

        public int HorseShape { get; set; }

        public int EventFlagShape { get; set; }

        public bool hasflag { get; set; }

        public int eventTeam { get; set; }

        
        public int Mingwen01 { get; set; }
        public int Mingwen02 { get; set; }
        public int Mingwen03 { get; set; }

        public int Huiyuan { get; set; }
    }
    public sealed class ObjectMonster : Packet
    {
        public uint ObjectID { get; set; }
        public int MonsterIndex { get; set; }
        public Color NameColour { get; set; }
        public string PetOwner { get; set; }
        
        public MirDirection Direction { get; set; }
        public Point Location { get; set; }
        
        public bool Dead { get; set; }
        public bool Skeleton { get; set; }

        public PoisonType Poison { get; set; }

        public bool EasterEvent { get; set; }
        public bool HalloweenEvent { get; set; }
        public bool ChristmasEvent { get; set; }

        public List<BuffType> Buffs { get; set; }
        public bool Extra { get; set; }

        public ClientCompanionObject CompanionObject { get; set; }

        
        

        public int eventTeam { get; set; }

    }
    public sealed class ObjectNPC : Packet
    {
        public uint ObjectID { get; set; }

        public int NPCIndex { get; set; }
        public Point CurrentLocation { get; set; }

        public MirDirection Direction { get; set; }
    }
    public sealed class ObjectItem : Packet
    {
        public uint ObjectID { get; set; }

        public ClientUserItem Item { get; set; }
        
        public Point Location { get; set; }
    }
    public sealed class ObjectSpell : Packet
    {
        public uint ObjectID { get; set; }
        public MirDirection Direction { get; set; }
        public Point Location { get; set; }
        public SpellEffect Effect { get; set; }
        public int Power { get; set; }

    }
    public sealed class ObjectSpellChanged : Packet
    {
        public uint ObjectID { get; set; }
        public int Power { get; set; }
    }
    public sealed class ObjectNameColour : Packet
    {
        public uint ObjectID { get; set; }
        public Color Colour { get; set; }
    }

    public sealed class PlayerUpdate : Packet
    {
        public uint ObjectID { get; set; }
        public int Weapon { get; set; }
        public int Shield { get; set; }
        public int Emblem { get; set; }
        public int Armour { get; set; }
        public Color ArmourColour { get; set; }
        public int ArmourImage { get; set; }
        public int WeaponImage { get; set; }

        
        public int Shizhuang { get; set; }
        public int ShizhuangImage { get; set; }

        public int HorseArmour { get; set; }
        public int Helmet { get; set; }

        public int Dunpai { get; set; }

        public int Light { get; set; }

        public int EventFlagShape { get; set; }

        public int eventTeam { get; set; }

        
        public int Mingwen01 { get; set; }
        public int Mingwen02 { get; set; }
        public int Mingwen03 { get; set; }

    }


    public sealed class MagicToggle : Packet
    {
        public MagicType Magic { get; set; }
        public bool CanUse { get; set; }
    }


    public sealed class DayChanged : Packet
    {
        public float DayTime { get; set; }
    }


    public sealed class LevelChanged : Packet
    {
        public int Level { get; set; }
        public decimal Experience { get; set; }
    }

    public sealed class ExpSjian : Packet
    {
        public string ExpShuaijian { get; set; }
    }

    public sealed class FubenDian : Packet
    {
        public int Fubendian { get; set; }
    }

    public sealed class HuiyuanUp : Packet
    {
        public int Huiyuan { get; set; }
    }

    
    public sealed class JyhuishoulevelChanged : Packet
    {
        public int Jyhuishoulevel { get; set; }
        public decimal Exphuishou { get; set; }
    }

    public sealed class ObjectLeveled : Packet
    {
        public uint ObjectID { get; set; }
    }
    public sealed class ObjectRevive : Packet
    {
        public uint ObjectID { get; set; }
        public Point Location { get; set; }
        public bool Effect { get; set; }
    }
    public sealed class GainedExperience : Packet
    {
        public decimal Amount { get; set; }
    }

    
    public sealed class Gainedhsexperience : Packet
    {
        public decimal Amount { get; set; }
    }

    
    public sealed class GainedShengwang : Packet
    {
        public int Shengwang { get; set; }
        public int Amount { get; set; }
        public string MonsterName { get; set; }
        public bool Sfbaogwming { get; set; }
    }

    
    public sealed class MingwenUpDate : Packet
    {
        public int Index01 { get; set; }
        public int Index02 { get; set; }
        public int Index03 { get; set; }
        public bool Kaiqi01 { get; set; }
        public bool Kaiqi02 { get; set; }
        public bool Kaiqi03 { get; set; }
    }

    
    public sealed class NPCShenmiSRBuyAmount : Packet
    {
        public long ItemCountyi { get; set; }
        public long ItemCounter { get; set; }
        public long ItemCountsan { get; set; }
        public long ItemCountsi { get; set; }
        public long ItemCountwu { get; set; }
        public long ItemCountliu { get; set; }
        public long ItemCountqi { get; set; }
        public long ItemCountba { get; set; }
        public long ItemCountjiu { get; set; }
        public long ItemCountshi { get; set; }
    }

    public sealed class NewMagic : Packet
    {
        public ClientUserMagic Magic { get; set; }
    }
    public sealed class RemoveMagic : Packet
    {
        public bool Shanchu { get; set; }
    }
    public sealed class MagicLeveled : Packet
    {
        public int InfoIndex { get; set; }
        public MagicInfo Info;
        public int Level { get; set; }
        public long Experience { get; set; }

        [CompleteObject]
        public void Complete()
        {
            Info = CartoonGlobals.MagicInfoList.Binding.FirstOrDefault(x => x.Index == InfoIndex);
        }
    }
    public sealed class MagicCooldown : Packet
    {
        public int InfoIndex { get; set; }
        public int Delay { get; set; }
        public MagicInfo Info;

        [CompleteObject]
        public void Complete()
        {
            Info = CartoonGlobals.MagicInfoList.Binding.FirstOrDefault(x => x.Index == InfoIndex);
        }
    }

    public sealed class StatsUpdate : Packet
    {
        public Stats Stats { get; set; }
        public Stats HermitStats { get; set; }
        public int HermitPoints { get; set; }
    }
    public sealed class HealthChanged : Packet
    {
        public uint ObjectID { get; set; }
        public int Change { get; set; }
        public bool Miss { get; set; }
        public bool Block { get; set; }
        public bool Critical { get; set; }
        public bool Onekill { get; set; }
    }
    public sealed class ObjectStats : Packet
    {
        public uint ObjectID { get; set; }
        public Stats Stats { get; set; }
    }

    public sealed class ManaChanged : Packet
    {
        public uint ObjectID { get; set; }
        public int Change { get; set; }
    }

    public sealed class ObjectStruck : Packet
    {
        public uint ObjectID { get; set; }
        public MirDirection Direction { get; set; }
        public Point Location { get; set; }
        public uint AttackerID { get; set; }
        public Element Element { get; set; }
    }
    public sealed class ObjectDied : Packet
    {
        public uint ObjectID { get; set; }
        public MirDirection Direction { get; set; }
        public Point Location { get; set; }
        public bool eventmap { get; set; }
    }
    public sealed class ObjectHarvested : Packet
    {
        public uint ObjectID { get; set; }
        public MirDirection Direction { get; set; }
        public Point Location { get; set; }
    }



    public sealed class ItemsGained : Packet
    {
        public List<ClientUserItem> Items { get; set; }
    }
    public sealed class ItemMove : Packet
    {
        public GridType FromGrid { get; set; }
        public GridType ToGrid { get; set; }
        public int FromSlot { get; set; }
        public int ToSlot { get; set; }
        public bool MergeItem { get; set; }

        public bool Success { get; set; }
    }

    public sealed class ItemSplit : Packet
    {
        public GridType Grid { get; set; }
        public int Slot { get; set; }
        public long Count { get; set; }
        public int NewSlot { get; set; }

        public bool Success { get; set; }
    }

    public sealed class ItemLock : Packet
    {
        public GridType Grid { get; set; }
        public int Slot { get; set; }
        public bool Locked { get; set; }

    }

    public sealed class ItemUseDelay : Packet
    {
        public TimeSpan Delay { get; set; }
    }
    public sealed class ItemChanged : Packet
    {
        public CellLinkInfo Link { get; set; }
        public bool Success { get; set; }
    }

    public sealed class ItemStatsChanged : Packet
    {
        public GridType GridType { get; set; }
        public int Slot { get; set; }
        public Stats NewStats { get; set; }
    }
    public sealed class ItemStatsRefreshed : Packet
    {
        public GridType GridType { get; set; }
        public int Slot { get; set; }
        public Stats NewStats { get; set; }
    }
    
    public sealed class ItemInfoRefreshed : Packet
    {
        public GridType GridType { get; set; }
        public int Slot { get; set; }
        public int ItemIndex { get; set; }
        public ItemInfo NewInfo { get; set; }

        [CompleteObject]
        public void OnComplete()
        {
            NewInfo = CartoonGlobals.ItemInfoList.Binding.First(x => x.Index == ItemIndex);
        }
    }
    public sealed class ItemDurability : Packet
    {
        public GridType GridType { get; set; }
        public int Slot { get; set; }
        public int CurrentDurability { get; set; }
    }
    public sealed class GoldChanged : Packet
    {
        public long Gold { get; set; }
    }
    public sealed class ItemExperience : Packet
    {
        public CellLinkInfo Target { get; set; }
        public decimal Experience { get; set; }
        public int Level { get; set; }
        public UserItemFlags Flags { get; set; }

        public BaoshiMaYi BaoshiMaYi { get; set; }
        public BaoshiMaEr BaoshiMaEr { get; set; }
        public BaoshiMaSan BaoshiMaSan { get; set; }
        public BaoshiMaSi BaoshiMaSi { get; set; }
        public BaoshiMaWu BaoshiMaWu { get; set; }
        public BaoshiMaLiu BaoshiMaLiu { get; set; }
        public BaoshiMaQi BaoshiMaQi { get; set; }
        public BaoshiMaBa BaoshiMaBa { get; set; }
        public BaoshiMaJiu BaoshiMaJiu { get; set; }
        public BaoshiMaShi BaoshiMaShi { get; set; }
        public BaoshiMaShiyi BaoshiMaShiyi { get; set; }
        public BaoshiMaShier BaoshiMaShier { get; set; }
        public BaoshiMaShisan BaoshiMaShisan { get; set; }
        public BaoshiMaShisi BaoshiMaShisi { get; set; }

        
        public MingwenMaYi MingwenMaYi { get; set; }
        public MingwenMaEr MingwenMaEr { get; set; }
        public MingwenMaSan MingwenMaSan { get; set; }
        public MingwenMaSi MingwenMaSi { get; set; }
        public MingwenMaWu MingwenMaWu { get; set; }
        public MingwenMaLiu MingwenMaLiu { get; set; }
        public MingwenMaQi MingwenMaQi { get; set; }
        public MingwenMaBa MingwenMaBa { get; set; }
        public MingwenMaJiu MingwenMaJiu { get; set; }
        public MingwenMaShi MingwenMaShi { get; set; }
        public MingwenMaShiyi MingwenMaShiyi { get; set; }
        public MingwenMaShier MingwenMaShier { get; set; }
        public MingwenMaShisan MingwenMaShisan { get; set; }
        public MingwenMaShisi MingwenMaShisi { get; set; }
        public MingwenMaShiwu MingwenMaShiwu { get; set; }
        public MingwenMaShiliu MingwenMaShiliu { get; set; }
        public MingwenMaShiqi MingwenMaShiqi { get; set; }
        public MingwenMaShiba MingwenMaShiba { get; set; }
        public MingwenMaShijiu MingwenMaShijiu { get; set; }
        public MingwenMaErshi MingwenMaErshi { get; set; }
        public MingwenMaErshiyi MingwenMaErshiyi { get; set; }
        public MingwenMaErshier MingwenMaErshier { get; set; }
        public MingwenMaErshisan MingwenMaErshisan { get; set; }
        public MingwenMaErshisi MingwenMaErshisi { get; set; }
        public MingwenMaErshiwu MingwenMaErshiwu { get; set; }
        public MingwenMaErshiliu MingwenMaErshiliu { get; set; }
        public MingwenMaErshiqi MingwenMaErshiqi { get; set; }
        public MingwenMaErshiba MingwenMaErshiba { get; set; }
        public MingwenMaErshijiu MingwenMaErshijiu { get; set; }
        public MingwenMaSanshi MingwenMaSanshi { get; set; }

        public decimal MingwenExp { get; set; }
        public int MingwenLv { get; set; }
    }
    public sealed class ItemsExperience : Packet
    {
        public GridType Grid { get; set; }
        public int Slot { get; set; }
        public decimal Experience { get; set; }
        public int Level { get; set; }
        public UserItemFlags Flags { get; set; }

        public BaoshiMaYi BaoshiMaYi { get; set; }
        public BaoshiMaEr BaoshiMaEr { get; set; }
        public BaoshiMaSan BaoshiMaSan { get; set; }
        public BaoshiMaSi BaoshiMaSi { get; set; }
        public BaoshiMaWu BaoshiMaWu { get; set; }
        public BaoshiMaLiu BaoshiMaLiu { get; set; }
        public BaoshiMaQi BaoshiMaQi { get; set; }
        public BaoshiMaBa BaoshiMaBa { get; set; }
        public BaoshiMaJiu BaoshiMaJiu { get; set; }
        public BaoshiMaShi BaoshiMaShi { get; set; }
        public BaoshiMaShiyi BaoshiMaShiyi { get; set; }
        public BaoshiMaShier BaoshiMaShier { get; set; }
        public BaoshiMaShisan BaoshiMaShisan { get; set; }
        public BaoshiMaShisi BaoshiMaShisi { get; set; }

        
        public MingwenMaYi MingwenMaYi { get; set; }
        public MingwenMaEr MingwenMaEr { get; set; }
        public MingwenMaSan MingwenMaSan { get; set; }
        public MingwenMaSi MingwenMaSi { get; set; }
        public MingwenMaWu MingwenMaWu { get; set; }
        public MingwenMaLiu MingwenMaLiu { get; set; }
        public MingwenMaQi MingwenMaQi { get; set; }
        public MingwenMaBa MingwenMaBa { get; set; }
        public MingwenMaJiu MingwenMaJiu { get; set; }
        public MingwenMaShi MingwenMaShi { get; set; }
        public MingwenMaShiyi MingwenMaShiyi { get; set; }
        public MingwenMaShier MingwenMaShier { get; set; }
        public MingwenMaShisan MingwenMaShisan { get; set; }
        public MingwenMaShisi MingwenMaShisi { get; set; }
        public MingwenMaShiwu MingwenMaShiwu { get; set; }
        public MingwenMaShiliu MingwenMaShiliu { get; set; }
        public MingwenMaShiqi MingwenMaShiqi { get; set; }
        public MingwenMaShiba MingwenMaShiba { get; set; }
        public MingwenMaShijiu MingwenMaShijiu { get; set; }
        public MingwenMaErshi MingwenMaErshi { get; set; }
        public MingwenMaErshiyi MingwenMaErshiyi { get; set; }
        public MingwenMaErshier MingwenMaErshier { get; set; }
        public MingwenMaErshisan MingwenMaErshisan { get; set; }
        public MingwenMaErshisi MingwenMaErshisi { get; set; }
        public MingwenMaErshiwu MingwenMaErshiwu { get; set; }
        public MingwenMaErshiliu MingwenMaErshiliu { get; set; }
        public MingwenMaErshiqi MingwenMaErshiqi { get; set; }
        public MingwenMaErshiba MingwenMaErshiba { get; set; }
        public MingwenMaErshijiu MingwenMaErshijiu { get; set; }
        public MingwenMaSanshi MingwenMaSanshi { get; set; }

        public decimal MingwenExp { get; set; }
        public int MingwenLv { get; set; }
    }

    public sealed class Chat : Packet
    {
        public uint ObjectID { get; set; }
        public string Text { get; set; }
        public MessageType Type { get; set; }
        public List<ClientUserItem> Items { get; set; }
    }

    public sealed class NPCResponse : Packet
    {
        public uint ObjectID { get; set; }
        public int Index { get; set; }
        public List<ClientRefineInfo> Extra { get; set; }

        public NPCPage Page;

        [CompleteObject]
        public void Complete()
        {
            Page = CartoonGlobals.NPCPageList.Binding.FirstOrDefault(x => x.Index == Index);
        }
    }
    public sealed class ItemsChanged : Packet
    {
        public List<CellLinkInfo> Links { get; set; }
        public bool Success { get; set; }
    }
    public sealed class NPCRepair : Packet
    {
        public List<CellLinkInfo> Links { get; set; }
        public bool Special { get; set; }
        public bool Success { get; set; }
        public TimeSpan SpecialRepairDelay { get; set; }
    }
    public sealed class NPCRefinementStone : Packet
    {
        public List<CellLinkInfo> IronOres { get; set; }
        public List<CellLinkInfo> SilverOres { get; set; }
        public List<CellLinkInfo> DiamondOres { get; set; }
        public List<CellLinkInfo> GoldOres { get; set; }
        public List<CellLinkInfo> Crystal { get; set; }
    }
    public sealed class NPCRefine : Packet
    {
        public RefineType RefineType { get; set; }
        public RefineQuality RefineQuality { get; set; }
        public List<CellLinkInfo> Ores { get; set; }
        public List<CellLinkInfo> Items { get; set; }
        public List<CellLinkInfo> Specials { get; set; }
        public bool Success { get; set; }
    }
    public sealed class NPCMasterRefine : Packet
    {
        public List<CellLinkInfo> Fragment1s { get; set; }
        public List<CellLinkInfo> Fragment2s { get; set; }
        public List<CellLinkInfo> Fragment3s { get; set; }
        public List<CellLinkInfo> Stones { get; set; }
        public List<CellLinkInfo> Specials { get; set; }

        public bool Success { get; set; }
    }
    public sealed class NPCClose : Packet
    {
    }

    public sealed class NPCAccessoryLevelUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }
    
    public sealed class NPCDunLevelUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }
    
    public sealed class NPCHuiLevelUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    
    public sealed class NPCMingwenUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }
    
    public sealed class NPCMingwenChuanchengUp : Packet
    {
        public CellLinkInfo TargetY { get; set; }
        public CellLinkInfo TargetE { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    
    public sealed class Zhongzi : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCGZLKaikongUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCGZLBKaikongUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCQTKaikongUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangKanGJSTUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangKanGJBSTUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangKanZRSTUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangKanZRBSTUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangKanLHSTUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangKanLHBSTUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangKanSMSTUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangKanMFSTUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangKanSDSTUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangKanFYSTUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangKanMYSTUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    
    public sealed class NPCHuanhuaUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCChaichustUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangkanjystUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangkanxxstUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangKanghuoUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangKangbingUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangKangleiUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangKangfengUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangKangshenUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangKanganUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangKanghuanUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangKanmofadunUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangKanbingdongUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangKanmabiUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangKanyidongUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangKanchenmoUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangKangedangUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangKanduobiUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangKanqhuoUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangKanqbingUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangKanqleiUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangKanqfengUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangKanqshenUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangKanqanUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangKanqhuanUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangKanlvduUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangKanzymUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCXiangKanmhhfUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    
    public sealed class NPCXiangKanjinglianUp : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }

    public sealed class NPCAccessoryUpgrade : Packet
    {
        public CellLinkInfo Target { get; set; }
        public RefineType RefineType { get; set; }
        public bool Success { get; set; }
    }
    
    public sealed class NPCDunUpgradeFY : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }
    
    public sealed class NPCDunUpgradeMY : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }
    
    public sealed class NPCDunUpgradeSM : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }
    
    public sealed class NPCDunUpgradeMF : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }
    
    public sealed class NPCHuiUpgradeGJ : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }
    
    public sealed class NPCHuiUpgradeZR : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }
    
    public sealed class NPCHuiUpgradeLH : Packet
    {
        public CellLinkInfo Target { get; set; }
        public List<CellLinkInfo> Links { get; set; }
    }


    public sealed class NPCRefineRetrieve : Packet
    {
        public int Index { get; set; }
    }
    public sealed class RefineList : Packet
    {
        public List<ClientRefineInfo> List { get; set; }
    }

    public sealed class GroupSwitch : Packet
    {
        public bool Allow { get; set; }
    }
    public sealed class GroupMember : Packet
    {
        public uint ObjectID { get; set; }
        public string Name { get; set; }
        public MirClass Class { get; set; }
    }
    public sealed class GroupRemove : Packet
    {
        public uint ObjectID { get; set; }
    }
    public sealed class GroupInvite : Packet
    {
        public string Name { get; set; }
    }
    
    public sealed class BuffAdd : Packet
    {
        public ClientBuffInfo Buff { get; set; }
    }
    public sealed class BuffRemove : Packet
    {
        public int Index { get; set; }
    }
    public sealed class BuffChanged : Packet
    {
        public int Index { get; set; }
        public Stats Stats { get; set; }
    }
    public sealed class BuffTime : Packet
    {
        public int Index { get; set; }
        public TimeSpan Time { get; set; }
    }
    public sealed class BuffPaused : Packet
    {
        public int Index { get; set; }
        public bool Paused { get; set; }
    }
    public sealed class SafeZoneChanged : Packet
    {
        public bool InSafeZone { get; set; }
    }
    public sealed class CombatTime : Packet
    {
        
    }
    public sealed class Inspect : Packet
    {
        public string Name { get; set; }
        public string GuildName { get; set; }
        public string GuildRank { get; set; }
        public string Partner { get; set; }
        public MirClass Class { get; set; }
        public int Level { get; set; }
        public MirGender Gender { get; set; }
        public Stats Stats { get; set; }
        public Stats HermitStats { get; set; }
        public int HermitPoints { get; set; }
        public List<ClientUserItem> Items { get; set; }
        public int Hair { get; set; }
        public Color HairColour { get; set; }

        public int WearWeight { get; set; }
        public int HandWeight { get; set; }
        
        public int Shengwangdian { get; set; }
        
        public bool HideShizhuang { get; set; }
    }
    public sealed class Rankings : Packet
    {
        public bool OnlineOnly { get; set; }
        public RequiredClass Class { get; set; }
        public int StartIndex { get; set; }
        public int Total { get; set; }

        public List<RankInfo> Ranks { get; set; }
    }
    
    public sealed class GuildRankings : Packet
    {
        public int StartIndex { get; set; }
        public int Total { get; set; }

        public List<GuildRankInfo> Ranks { get; set; }
    }
    
    public sealed class GuildGerenRankings : Packet
    {
        public int StartIndex { get; set; }
        public int Total { get; set; }

        public List<GuildGerenRankInfo> Ranks { get; set; }
    }

    public sealed class StartObserver : Packet
    {
        public StartInformation StartInformation { get; set; }
        public List<ClientUserItem> Items { get; set; }
    }
    public sealed class ObservableSwitch : Packet
    {
        public bool Allow { get; set; }
    }

    public sealed class MarketPlaceHistory : Packet
    {
        public int Index { get; set; }
        public long SaleCount { get; set; }
        public long LastPrice { get; set; }
        public long AveragePrice { get; set; }
        public long GameGoldLastPrice { get; set; }
        public long GameGoldAveragePrice { get; set; }
        public int Display { get; set; }
    }

    public sealed class MarketPlaceConsign : Packet
    {
        public List<ClientMarketPlaceInfo> Consignments { get; set; }
    }

    public sealed class MarketPlaceSearch : Packet
    {
        public int Count { get; set; }
        public List<ClientMarketPlaceInfo> Results { get; set; }
    }
    public sealed class MarketPlaceSearchCount : Packet
    {
        public int Count { get; set; }
    }

    public sealed class MarketPlaceSearchIndex : Packet
    {
        public int Index { get; set; }
        public ClientMarketPlaceInfo Result { get; set; }
    }

    public sealed class MarketPlaceBuy : Packet
    {
        public int Index { get; set; }
        public long Count { get; set; }
        public bool Success { get; set; }
    }
    public sealed class MarketPlaceStoreBuy : Packet
    {
    }

    public sealed class MarketPlaceConsignChanged : Packet
    {
        public int Index { get; set; }
        public long Count { get; set; }
    }


    public sealed class MailList : Packet
    {
        public List<ClientMailInfo> Mail { get; set; }
    }
    public sealed class MailNew : Packet
    {
        public ClientMailInfo Mail { get; set; }
    }
    public sealed class MailDelete : Packet
    {
        public int Index { get; set; }
    }
    public sealed class MailItemDelete : Packet
    {
        public int Index { get; set; }
        public int Slot { get; set; }
    }
    public sealed class MailSend : Packet
    {
    }

    public sealed class ChangeAttackMode : Packet
    {
        public AttackMode Mode { get; set; }
    }
    public sealed class ChangePetMode : Packet
    {
        public PetMode Mode { get; set; }
    }

    public sealed class GameGoldChanged : Packet
    {
        public int GameGold { get; set; }
    }

    public sealed class MountFailed : Packet
    {
        public HorseType Horse { get; set; }
    }

    public sealed class WeightUpdate : Packet
    {
        public int BagWeight { get; set; }
        public int WearWeight { get; set; }
        public int HandWeight { get; set; }
    }

    public sealed class HuntGoldChanged : Packet
    {
        public int HuntGold { get; set; }
    }


    public sealed class TradeRequest : Packet
    {
        public string Name { get; set; }
    }
    public sealed class TradeOpen : Packet
    {
        public string Name { get; set; }
    }

    public sealed class TradeClose : Packet { }

    public sealed class TradeAddItem : Packet
    {
        public CellLinkInfo Cell { get; set; }
        public bool Success { get; set; }
    }

    public sealed class TradeAddGold : Packet
    {
        public long Gold { get; set; }
    }

    public sealed class TradeItemAdded : Packet
    {
        public ClientUserItem Item { get; set; }
    }

    public sealed class TradeGoldAdded : Packet
    {
        public long Gold { get; set; }
    }
    public sealed class TradeUnlock : Packet { }


    public sealed class GuildCreate : Packet
    {
        
    }
    public sealed class GuildInfo : Packet
    {
        public ClientGuildInfo Guild { get; set; }
    }
    public sealed class GuildNoticeChanged : Packet
    {
        public string Notice { get; set; }
    }
    public sealed class GuildNewItem : Packet
    {
        public int Slot { get; set; }
        public ClientUserItem Item { get; set; }
        
    }
    public sealed class GuildGetItem : Packet
    {
        public GridType Grid { get; set; }
        public int Slot { get; set; }
        public ClientUserItem Item { get; set; }
    }
    public sealed class GuildUpdate : Packet
    {
        public int MemberLimit { get; set; }
        public int StorageLimit { get; set; }

        public long GuildFunds { get; set; }
        public long DailyGrowth { get; set; }

        public int GuildLevel { get; set; }
        public int Tax { get; set; }

        public long TotalContribution { get; set; }
        public long JyTotalContribution { get; set; }
        public long DailyContribution { get; set; }

        public string DefaultRank { get; set; }

        
        public int ShuangGongxian { get; set; }
        
        public int GuildBosshd01 { get; set; }
        
        public int GuildBosshdrenshu { get; set; }

        
        public int GuildQuanhd02 { get; set; }
        
        public int GuildQuanhdrenshu { get; set; }

        
        public int GuildFubenhd03 { get; set; }
        
        public int GuildFubenhdrenshu { get; set; }

        
        public int GuildJiachenghd04 { get; set; }
        
        public int GuildJiachenghdrenshu { get; set; }


        public GuildPermission DefaultPermission { get; set; }

        public List<ClientGuildMemberInfo> Members { get; set; }
    }
    public sealed class GuildKick : Packet
    {
        public int Index { get; set; }
    }
    public sealed class GuildTax : Packet
    {

    }
    public sealed class GuildIncreaseMember : Packet
    {

    }
    public sealed class GuildIncreaseStorage : Packet
    {

    }
    public sealed class GuildInviteMember : Packet
    {
        
    }
    public sealed class GuildInvite : Packet
    {
        public string Name { get; set; }
        public string GuildName { get; set; }
    }
    public sealed class GuildStats : Packet
    {
        public int Index { get; set; }
        public Stats Stats { get; set; }

    }

    public sealed class GuildMemberOffline : Packet
    {
        public int Index { get; set; }
    }
    public sealed class GuildMemberOnline : Packet
    {
        public int Index { get; set; }

        public string Name { get; set; }
        public uint ObjectID { get; set; }
    }
    public sealed class GuildMemberContribution : Packet
    {
        public int Index { get; set; }

        public long Contribution { get; set; }

        public long HuishouContribution { get; set; }

        public string MapName { get; set; }
    }
    public sealed class GuildDayReset : Packet
    {

    }
    public sealed class GuildFundsChanged : Packet
    {
        public long Change { get; set; }
    }
    public sealed class GuildChanged : Packet
    {
        public uint ObjectID { get; set; }
        public string GuildName { get; set; }
        public string GuildRank { get; set; }
    }

    public sealed class GuildWarFinished : Packet
    {
        public string GuildName { get; set; }
    }

    public sealed class GuildWar : Packet
    {
        public bool Success { get; set; }
    }

    public sealed class GuildWarStarted : Packet
    {
        public string GuildName { get; set; }
        public TimeSpan Duration { get; set; }
    }
    public sealed class GuildConquestDate : Packet
    {
        public int Index { get; set; }
        public TimeSpan WarTime { get; set; }

        public DateTime WarDate;

        [CompleteObject]
        public void Update()
        {
            if (WarTime == TimeSpan.MinValue)
                WarDate = DateTime.MinValue;
            else
                WarDate = Time.Now + WarTime;
        }
    }
    public sealed class GuildCastleInfo : Packet
    {
        public int Index { get; set; }
        public string Owner { get; set; }
    }

    public sealed class GuildConquestStarted : Packet
    {
        public int Index { get; set; }
    }

    public sealed class GuildConquestFinished : Packet
    {
        public int Index { get; set; }
    }

    public sealed class ReviveTimers : Packet
    {
        public TimeSpan ItemReviveTime { get; set; }
        public TimeSpan ReincarnationPillTime { get; set; }
    }

    public sealed class QuestChanged : Packet
    {
        public ClientUserQuest Quest { get; set; }
    }

    public sealed class MeiriQuestChanged : Packet
    {
        public ClientMeiriUserQuest Quest { get; set; }
    }

    public sealed class MeiriQuestHasDailyRandom : Packet
    {
        public bool hasdaily { get; set; }
    }
    public sealed class MeiRiDailyRandomQuestResets : Packet
    {
        public int DailyCount { get; set; }
    }
    public sealed class MeiriQuestRemoved : Packet
    {
        public ClientMeiriUserQuest Quest { get; set; }

    }

    public sealed class CompanionUnlock : Packet
    {
        public int Index { get; set; }
    }
    public sealed class CompanionAdopt : Packet
    {
        public ClientUserCompanion UserCompanion { get; set; }
    }
    public sealed class CompanionRetrieve : Packet
    {
        public int Index { get; set; }
    }
    public sealed class CompanionStore : Packet
    {
    }
    public sealed class CompanionWeightUpdate : Packet
    {
        public int BagWeight { get; set; }
        public int MaxBagWeight { get; set; }
        public int InventorySize { get; set; }
        public int CompanionBagSpace { get; set; }
    }
    public sealed class CompanionShapeUpdate : Packet
    {
        public uint ObjectID { get; set; }
        public int HeadShape { get; set; }
        public int BackShape { get; set; }
    }
    public sealed class CompanionItemsGained : Packet
    {
        public List<ClientUserItem> Items { get; set; }
    }
    public sealed class CompanionUpdate : Packet
    {
        public int Rebirth { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int Hunger { get; set; }
    }
    public sealed class CompanionSkillUpdate : Packet
    {
        public Stats Level3 { get; set; }
        public Stats Level5 { get; set; }
        public Stats Level7 { get; set; }
        public Stats Level10 { get; set; }
        public Stats Level11 { get; set; }
        public Stats Level13 { get; set; }
        public Stats Level15 { get; set; }
        public Stats Level17 { get; set; }
        public Stats Level20 { get; set; }
        public Stats Level23 { get; set; }
        public Stats Level25 { get; set; }
        public Stats Level27 { get; set; }
        public Stats Level30 { get; set; }
        public Stats Level33 { get; set; }
        public Stats Level35 { get; set; }
        public Stats Level37 { get; set; }
        public Stats Level40 { get; set; }
        public int ImgIndex3 { get; set; }
        public int ImgIndex5 { get; set; }
        public int ImgIndex7 { get; set; }
        public int ImgIndex10 { get; set; }
        public int ImgIndex11 { get; set; }
        public int ImgIndex13 { get; set; }
        public int ImgIndex15 { get; set; }
        public int ImgIndex17 { get; set; }
        public int ImgIndex20 { get; set; }
        public int ImgIndex23 { get; set; }
        public int ImgIndex25 { get; set; }
        public int ImgIndex27 { get; set; }
        public int ImgIndex30 { get; set; }
        public int ImgIndex33 { get; set; }
        public int ImgIndex35 { get; set; }
        public int ImgIndex37 { get; set; }
        public int ImgIndex40 { get; set; }
        public bool Maxzhi3 { get; set; }
        public bool Maxzhi5 { get; set; }
        public bool Maxzhi7 { get; set; }
        public bool Maxzhi10 { get; set; }
        public bool Maxzhi11 { get; set; }
        public bool Maxzhi13 { get; set; }
        public bool Maxzhi15 { get; set; }
    }


    public sealed class MarriageInvite : Packet
    {
        public string Name { get; set; }
    }
    public sealed class MarriageInfo : Packet
    {
        public ClientPlayerInfo Partner { get; set; }
    }
    public sealed class MarriageRemoveRing : Packet
    {
        
    }
    public sealed class MarriageMakeRing : Packet
    {

    }

    public sealed class MarriageOnlineChanged : Packet
    {
        public uint ObjectID { get; set; }
    }

    public sealed class HuizhangRemoveRefine : Packet { }
    public sealed class HuizhangMakeRefine : Packet
    {
        public int Level { get; set; }
        public decimal Experience { get; set; }
    }

    public sealed class DunpaiRemoveRefine : Packet { }
    public sealed class DunpaiMakeRefine : Packet
    {
        public int Level { get; set; }
        public decimal Experience { get; set; }
    }

    public sealed class DataObjectRemove : Packet
    {
        public uint ObjectID { get; set; }
    }
    public sealed class DataObjectPlayer : Packet
    {
        public uint ObjectID { get; set; }
        public int MapIndex { get; set; }
        public Point CurrentLocation { get; set; }

        public string Name { get; set; }
        
        public int Health { get; set; }
        public int Mana { get; set; }
        public bool Dead { get; set; }

        public int MaxHealth { get; set; }
        public int MaxMana { get; set; }
        public MirClass Class { get; set; }
    }
    public sealed class DataObjectMonster : Packet
    {
        public uint ObjectID { get; set; }

        public int MapIndex { get; set; }
        public Point CurrentLocation { get; set; }

        public MonsterInfo MonsterInfo;
        public int MonsterIndex { get; set; }
        public string PetOwner { get; set; }
        
        public int Health { get; set; }
        public Stats Stats { get; set; }
        public bool Dead { get; set; }
        
        [CompleteObject]
        public void OnComplete()
        {
            MonsterInfo = CartoonGlobals.MonsterInfoList.Binding.First(x => x.Index == MonsterIndex);
        }
    }
    public sealed class DataObjectItem : Packet
    {
        public uint ObjectID { get; set; }

        public int MapIndex { get; set; }
        public Point CurrentLocation { get; set; }

        public ItemInfo ItemInfo;
        public int ItemIndex { get; set; }

        [CompleteObject]
        public void OnComplete()
        {
            ItemInfo = CartoonGlobals.ItemInfoList.Binding.First(x => x.Index == ItemIndex);
        }
    }
    public sealed class DataObjectLocation : Packet
    {
        public uint ObjectID { get; set; }
        public int MapIndex { get; set; }
        public Point CurrentLocation { get; set; }
    }
    public sealed class DataObjectHealthMana : Packet
    {
        public uint ObjectID { get; set; }

        public int Health { get; set; }
        public int Mana { get; set; }
        public bool Dead { get; set; }
    }
    public sealed class DataObjectMaxHealthMana : Packet
    {
        public uint ObjectID { get; set; }

        public int MaxHealth { get; set; }
        public int MaxMana { get; set; }
        public Stats Stats { get; set; }
    }
    public sealed class BlockAdd : Packet
    {
        public ClientBlockInfo Info { get; set; }
    }

    public sealed class BlockRemove : Packet
    {
        public int Index { get; set; }
    }

    
    public sealed class ShizhuangToggle : Packet
    {
        public bool HideShizhuang { get; set; }
    }

    
    public sealed class HelmetToggle : Packet
    {
        public bool HideHelmet { get; set; }
    }

    
    public sealed class DunToggle : Packet
    {
        public bool Dun { get; set; }
    }



    public sealed class StorageSize : Packet
    {
        public int Size { get; set; }
    }

    public sealed class PlayerChangeUpdate : Packet
    {

        public uint ObjectID { get; set; }
        public string Name { get; set; }
        public MirClass Class { get; set; }
        public MirGender Gender { get; set; }
        public int HairType { get; set; }

        public Color HairColour { get; set; }
        public Color ArmourColour { get; set; }

    }

    public sealed class FortuneUpdate : Packet
    {
        public List<ClientFortuneInfo> Fortunes { get; set; }

    }
    public sealed class NPCWeaponCraft : Packet
    {
        public CellLinkInfo Template { get; set; }
        public CellLinkInfo Yellow { get; set; }
        public CellLinkInfo Blue { get; set; }
        public CellLinkInfo Red { get; set; }
        public CellLinkInfo Purple { get; set; }
        public CellLinkInfo Green { get; set; }
        public CellLinkInfo Grey { get; set; }

        public bool Success { get; set; }
    }
}

