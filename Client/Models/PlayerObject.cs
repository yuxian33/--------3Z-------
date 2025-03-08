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
using Library;
using SlimDX;
using SlimDX.Direct3D9;
using Frame = Library.Frame;
using S = Library.Network.ServerPackets;

namespace Client.Models
{
    public class PlayerObject : MapObject
    {
        public override ObjectType Race => ObjectType.Player;

        public List<ClientUserCrafting> CraftInfo;

        public const int FemaleOffSet = 5000, AssassinOffSet = 50000, RightHandOffSet = 50;

        #region Shield Librarys
        public Dictionary<int, LibraryFile> ShieldList = new Dictionary<int, LibraryFile>
        {
            [0] = LibraryFile.M_Shield1,
            [1] = LibraryFile.M_Shield2,
            [0 + FemaleOffSet] = LibraryFile.WM_Shield1,
            [1 + FemaleOffSet] = LibraryFile.WM_Shield2
        };
        #endregion

        #region Weapon Librarys
        public Dictionary<int, LibraryFile> WeaponList = new Dictionary<int, LibraryFile>
        {
            [0] = LibraryFile.M_Weapon1,
            [1] = LibraryFile.M_Weapon2,
            [2] = LibraryFile.M_Weapon3,
            [3] = LibraryFile.M_Weapon4,
            [4] = LibraryFile.M_Weapon5,
            [5] = LibraryFile.M_Weapon6,
            [6] = LibraryFile.M_Weapon7,
            [10] = LibraryFile.M_Weapon10,
            [11] = LibraryFile.M_Weapon11,
            [12] = LibraryFile.M_Weapon12,
            [13] = LibraryFile.M_Weapon13,
            [14] = LibraryFile.M_Weapon14,
            [15] = LibraryFile.M_Weapon15,
            [16] = LibraryFile.M_Weapon16,

            [0 + FemaleOffSet] = LibraryFile.WM_Weapon1,
            [1 + FemaleOffSet] = LibraryFile.WM_Weapon2,
            [2 + FemaleOffSet] = LibraryFile.WM_Weapon3,
            [3 + FemaleOffSet] = LibraryFile.WM_Weapon4,
            [4 + FemaleOffSet] = LibraryFile.WM_Weapon5,
            [5 + FemaleOffSet] = LibraryFile.WM_Weapon6,
            [6 + FemaleOffSet] = LibraryFile.WM_Weapon7,
            [10 + FemaleOffSet] = LibraryFile.WM_Weapon10,
            [11 + FemaleOffSet] = LibraryFile.WM_Weapon11,
            [12 + FemaleOffSet] = LibraryFile.WM_Weapon12,
            [13 + FemaleOffSet] = LibraryFile.WM_Weapon13,
            [14 + FemaleOffSet] = LibraryFile.WM_Weapon14,
            [15 + FemaleOffSet] = LibraryFile.WM_Weapon15,
            [16 + FemaleOffSet] = LibraryFile.WM_Weapon16,

            [120] = LibraryFile.M_WeaponADL1,
            [122] = LibraryFile.M_WeaponADL2,
            [126] = LibraryFile.M_WeaponADL6,
            [120 + RightHandOffSet] = LibraryFile.M_WeaponADR1,
            [122 + RightHandOffSet] = LibraryFile.M_WeaponADR2,
            [126 + RightHandOffSet] = LibraryFile.M_WeaponADR6,

            [110] = LibraryFile.M_WeaponAOH1,
            [111] = LibraryFile.M_WeaponAOH2,
            [112] = LibraryFile.M_WeaponAOH3,
            [113] = LibraryFile.M_WeaponAOH3,
            [114] = LibraryFile.M_WeaponAOH4,
            [115] = LibraryFile.M_WeaponAOH5,
            [116] = LibraryFile.M_WeaponAOH6,


            [120 + FemaleOffSet] = LibraryFile.WM_WeaponADL1,
            [122 + FemaleOffSet] = LibraryFile.WM_WeaponADL2,
            [126 + FemaleOffSet] = LibraryFile.WM_WeaponADL6,
            [120 + FemaleOffSet + RightHandOffSet] = LibraryFile.WM_WeaponADR1,
            [122 + FemaleOffSet + RightHandOffSet] = LibraryFile.WM_WeaponADR2,
            [126 + FemaleOffSet + RightHandOffSet] = LibraryFile.WM_WeaponADR6,

            [110 + FemaleOffSet] = LibraryFile.WM_WeaponAOH1,
            [111 + FemaleOffSet] = LibraryFile.WM_WeaponAOH2,
            [112 + FemaleOffSet] = LibraryFile.WM_WeaponAOH3,
            [113 + FemaleOffSet] = LibraryFile.WM_WeaponAOH3,
            [114 + FemaleOffSet] = LibraryFile.WM_WeaponAOH4,
            [115 + FemaleOffSet] = LibraryFile.WM_WeaponAOH5,
            [116 + FemaleOffSet] = LibraryFile.WM_WeaponAOH6,
        };
        #endregion

        #region Helmet Librarys
        public Dictionary<int, LibraryFile> HelmetList = new Dictionary<int, LibraryFile>
        {
            [0] = LibraryFile.M_Helmet1,
            [1] = LibraryFile.M_Helmet2,
            [2] = LibraryFile.M_Helmet3,
            [3] = LibraryFile.M_Helmet4,
            [4] = LibraryFile.M_Helmet5,

            [10] = LibraryFile.M_Helmet11,
            [11] = LibraryFile.M_Helmet12,
            [12] = LibraryFile.M_Helmet13,
            [13] = LibraryFile.M_Helmet14,

            [0 + FemaleOffSet] = LibraryFile.WM_Helmet1,
            [1 + FemaleOffSet] = LibraryFile.WM_Helmet2,
            [2 + FemaleOffSet] = LibraryFile.WM_Helmet3,
            [3 + FemaleOffSet] = LibraryFile.WM_Helmet4,
            [4 + FemaleOffSet] = LibraryFile.WM_Helmet5,

            [10 + FemaleOffSet] = LibraryFile.WM_Helmet11,
            [11 + FemaleOffSet] = LibraryFile.WM_Helmet12,
            [12 + FemaleOffSet] = LibraryFile.WM_Helmet13,
            [13 + FemaleOffSet] = LibraryFile.WM_Helmet14,
            
            [0 + AssassinOffSet] = LibraryFile.M_HelmetA1,
            [1 + AssassinOffSet] = LibraryFile.M_HelmetA2,
            [2 + AssassinOffSet] = LibraryFile.M_HelmetA3,
            [3 + AssassinOffSet] = LibraryFile.M_HelmetA4,

            [0 + AssassinOffSet + FemaleOffSet] = LibraryFile.WM_HelmetA1,
            [1 + AssassinOffSet + FemaleOffSet] = LibraryFile.WM_HelmetA2,
            [2 + AssassinOffSet + FemaleOffSet] = LibraryFile.WM_HelmetA3,
            [3 + AssassinOffSet + FemaleOffSet] = LibraryFile.WM_HelmetA4,
        };
        #endregion

        #region Armour Librarys
        public Dictionary<int, LibraryFile> ArmourList = new Dictionary<int, LibraryFile>
        {
            [0] = LibraryFile.M_Hum,
            [1] = LibraryFile.M_HumEx1,
            [2] = LibraryFile.M_HumEx2,
            [3] = LibraryFile.M_HumEx3,
            [4] = LibraryFile.M_HumEx4,
            [10] = LibraryFile.M_HumEx10,
            [11] = LibraryFile.M_HumEx11,
            [12] = LibraryFile.M_HumEx12,
            [13] = LibraryFile.M_HumEx13,


            [0 + FemaleOffSet] = LibraryFile.WM_Hum,
            [1 + FemaleOffSet] = LibraryFile.WM_HumEx1,
            [2 + FemaleOffSet] = LibraryFile.WM_HumEx2,
            [3 + FemaleOffSet] = LibraryFile.WM_HumEx3,
            [4 + FemaleOffSet] = LibraryFile.WM_HumEx4,
            [10 + FemaleOffSet] = LibraryFile.WM_HumEx10,
            [11 + FemaleOffSet] = LibraryFile.WM_HumEx11,
            [12 + FemaleOffSet] = LibraryFile.WM_HumEx12,
            [13 + FemaleOffSet] = LibraryFile.WM_HumEx13,


            [0 + AssassinOffSet] = LibraryFile.M_HumA,
            [1 + AssassinOffSet] = LibraryFile.M_HumAEx1,
            [2 + AssassinOffSet] = LibraryFile.M_HumAEx2,
            [3 + AssassinOffSet] = LibraryFile.M_HumAEx3,
            
            [0 + AssassinOffSet + FemaleOffSet] = LibraryFile.WM_HumA,
            [1 + AssassinOffSet + FemaleOffSet] = LibraryFile.WM_HumAEx1,
            [2 + AssassinOffSet + FemaleOffSet] = LibraryFile.WM_HumAEx2,
            [3 + AssassinOffSet + FemaleOffSet] = LibraryFile.WM_HumAEx3,
        };
        #endregion

        
        #region Shizhuang Librarys
        public Dictionary<int, LibraryFile> ShizhuangList = new Dictionary<int, LibraryFile>
        {
            [0] = LibraryFile.M_Hum,
            [1] = LibraryFile.M_HumEx1,
            [2] = LibraryFile.M_Costume,


            [0 + FemaleOffSet] = LibraryFile.WM_Hum,
            [1 + FemaleOffSet] = LibraryFile.WM_HumEx1,
            [2 + FemaleOffSet] = LibraryFile.WM_Costume,


            [0 + AssassinOffSet] = LibraryFile.M_HumA,
            [1 + AssassinOffSet] = LibraryFile.M_HumAEx1,
            [2 + AssassinOffSet] = LibraryFile.M_CostumeA,


            [0 + AssassinOffSet + FemaleOffSet] = LibraryFile.WM_HumA,
            [1 + AssassinOffSet + FemaleOffSet] = LibraryFile.WM_HumAEx1,
            [2 + AssassinOffSet + FemaleOffSet] = LibraryFile.WM_CostumeA,

        };
        #endregion


        public string GuildRank
        {
            get { return _GuildRank; }
            set
            {
                if (_GuildRank == value) return;

                _GuildRank = value;

                NameChanged();
            }
        }
        private string _GuildRank;


        public virtual MirClass Class { get; set; }

        public MirLibrary HairLibrary, HelmetLibrary;
        public int HairType;
        public Color HairColour;
        public int HairTypeOffSet;
        public int HelmetShape;

        public int HairFrame => DrawFrame + (HairType - 1) * HairTypeOffSet;
        public int HelmetFrame => DrawFrame + ((HelmetShape % 10) - 1) * ArmourShapeOffSet + ArmourShift;

        public MirLibrary WeaponLibrary1, WeaponLibrary2;
        public int WeaponShapeOffSet;
        public int WeaponShape, LibraryWeaponShape;
        public int WeaponFrame => DrawFrame + (WeaponShape % 10) * WeaponShapeOffSet;
        
        public int ShieldShape;
        public int ShieldFrame => DrawFrame + (ShieldShape % 10) * WeaponShapeOffSet;

        public MirLibrary BodyLibrary, SzBodyLibrary;
        public int ArmourShapeOffSet;
        public int ArmourShape;
        public int ArmourShift;
        public Color ArmourColour;
        public int ArmourFrame => DrawFrame + (ArmourShape % 11) * ArmourShapeOffSet + ArmourShift;

        
        public int ShizhuangShapeOffSet;
        public int ShizhuangShape;
        public int ShizhuangFrame => DrawFrame + (ShizhuangShape % 11) * ShizhuangShapeOffSet + ArmourShift;
        public int ShizhuangImage;

        public bool hasFlag;
        public int EventFlagShape;

        public MirLibrary HorseLibrary, HorseShapeLibrary, HorseShapeLibrary2;
        public int HorseShape;
        public int HorseFrame => DrawFrame + ((int) Horse - 1) * 5000;
        public HorseType Horse;

        public int ArmourImage, WeaponImage, EmblemShape, ShieldImage, WingImage;

        public bool DrawWeapon;

        public DXLabel HPratioLabel;

        public MirLibrary ShieldLibrary, EmblemLibrary;

        public int CharacterIndex;

        public PlayerObject()
        {
            if (HPratioLabel != null)
                return;
            InitHPratioLabel();
        }
        public PlayerObject(S.ObjectPlayer info)
        {
            CharacterIndex = info.Index;

            ObjectID = info.ObjectID;

            Name = info.Name;
            NameColour = info.NameColour;

            Class = info.Class;
            Gender = info.Gender;

            Poison = info.Poison;

            foreach (BuffType type in info.Buffs)
                VisibleBuffs.Add(type);

            Title = info.GuildName;

            CurrentLocation = info.Location;
            Direction = info.Direction;
            
            HairType = info.HairType;
            HairColour = info.HairColour;

            ArmourShape = info.Armour;
            ArmourColour = info.ArmourColour;
            LibraryWeaponShape = info.Weapon;
            HorseShape = info.HorseShape;
            HelmetShape = info.Helmet;
            ShieldShape = info.Shield;
            EmblemShape = info.Emblem;

            ArmourImage = info.ArmourImage;
            WeaponImage = info.WeaponImage;
            
            ShizhuangShape = info.Shizhuang;
            ShizhuangImage = info.ShizhuangImage;

            EventFlagShape = info.EventFlagShape;
            hasFlag = info.hasflag;
            gameTeam = info.eventTeam;

            Light = info.Light;

            
            Mingwen01 = info.Mingwen01;
            Mingwen02 = info.Mingwen02;
            Mingwen03 = info.Mingwen03;

            Huiyuan = info.Huiyuan;

            Dead = info.Dead;
            Horse = info.Horse;
            if (HPratioLabel == null)
                InitHPratioLabel();

            UpdateLibraries();
            
            SetFrame(new ObjectAction(!Dead ? MirAction.Standing : MirAction.Dead, MirDirection.Up, CurrentLocation));

            GameScene.Game.MapControl.AddObject(this);
        }
        
        public void InitHPratioLabel()
        {
            DXLabel dxLabel = new DXLabel();
            dxLabel.BackColour = Color.Empty;
            dxLabel.ForeColour = Color.White;
            dxLabel.Outline = true;
            dxLabel.OutlineColour = Color.Black;
            dxLabel.IsControl = false;
            dxLabel.IsVisible = true;
            HPratioLabel = dxLabel;
        }

        public void UpdateLibraries()
        {
            LibraryFile file, szfile;

            WeaponLibrary2 = null;

            Frames = new Dictionary<MirAnimation, Frame>(FrameSet.Players);

            CEnvir.LibraryList.TryGetValue(LibraryFile.Horse, out HorseLibrary);

            HorseShapeLibrary = null;
            HorseShapeLibrary2 = null;

            if (LibraryWeaponShape >= 1000)
                WeaponShape = LibraryWeaponShape - 1000;
            else
                WeaponShape = LibraryWeaponShape;


            switch (HorseShape)
            {
                case 1:
                    CEnvir.LibraryList.TryGetValue(LibraryFile.HorseIron, out HorseShapeLibrary);
                    break;
                case 2:
                    CEnvir.LibraryList.TryGetValue(LibraryFile.HorseSilver, out HorseShapeLibrary);
                    break;
                case 3:
                    CEnvir.LibraryList.TryGetValue(LibraryFile.HorseGold, out HorseShapeLibrary);
                    break;
                case 4:
                    CEnvir.LibraryList.TryGetValue(LibraryFile.HorseBlue, out HorseShapeLibrary);
                    break;
                case 5:
                    CEnvir.LibraryList.TryGetValue(LibraryFile.HorseDark, out HorseShapeLibrary);
                    CEnvir.LibraryList.TryGetValue(LibraryFile.HorseDarkEffect, out HorseShapeLibrary2);
                    break;
            }
            switch (EmblemShape)
            {
                case 1:
                case 2:
                    CEnvir.LibraryList.TryGetValue(LibraryFile.GameInter, out EmblemLibrary);
                    break;
                case 3:
                    CEnvir.LibraryList.TryGetValue(LibraryFile.GameInter2, out EmblemLibrary);
                    break;
                case 4:
                    CEnvir.LibraryList.TryGetValue(LibraryFile.EquipEffect_Item, out EmblemLibrary);
                    break;
            }
            
            switch (Class)
            {
                case MirClass.Warrior:
                case MirClass.Wizard:
                case MirClass.Taoist:
                    ArmourShapeOffSet = 5000;
                    WeaponShapeOffSet = 5000;
                    HairTypeOffSet = 5000;
                    ShizhuangShapeOffSet = 5000;

                    switch (Gender)
                    {
                        case MirGender.Male:
                            if (!ArmourList.TryGetValue(ArmourShape / 11, out file))
                            {
                                file = LibraryFile.M_Hum;
                                ArmourShape = 0;
                            }
                            CEnvir.LibraryList.TryGetValue(file, out BodyLibrary);
                            if (!ShizhuangList.TryGetValue(ShizhuangShape / 11, out szfile))
                            {
                                szfile = LibraryFile.M_Hum;
                                ShizhuangShape = 0;
                            }
                            CEnvir.LibraryList.TryGetValue(szfile, out SzBodyLibrary);

                            CEnvir.LibraryList.TryGetValue(LibraryFile.M_Hair, out HairLibrary);

                            if (!HelmetList.TryGetValue(HelmetShape / 10, out file)) file = LibraryFile.None;
                            CEnvir.LibraryList.TryGetValue(file, out HelmetLibrary);

                            if (!WeaponList.TryGetValue(LibraryWeaponShape / 10, out file)) file = LibraryFile.None;
                            CEnvir.LibraryList.TryGetValue(file, out WeaponLibrary1);

                            if (ShieldShape >= 0)
                            {
                                if (!ShieldList.TryGetValue(ShieldShape / 10, out file)) file = LibraryFile.None;
                                CEnvir.LibraryList.TryGetValue(file, out WeaponLibrary2);
                            }
                            break;
                        case MirGender.Female:
                            if (!ArmourList.TryGetValue(ArmourShape / 11 + FemaleOffSet, out file))
                            {
                                file = LibraryFile.WM_Hum;
                                ArmourShape = 0;
                            }
                            CEnvir.LibraryList.TryGetValue(file, out BodyLibrary);
                            if (!ShizhuangList.TryGetValue(ShizhuangShape / 11 + FemaleOffSet, out szfile))
                            {
                                szfile = LibraryFile.WM_Hum;
                                ShizhuangShape = 0;
                            }
                            CEnvir.LibraryList.TryGetValue(szfile, out SzBodyLibrary);

                            CEnvir.LibraryList.TryGetValue(LibraryFile.WM_Hair, out HairLibrary);

                            if (!HelmetList.TryGetValue(HelmetShape / 10 + FemaleOffSet, out file)) file = LibraryFile.None;
                            CEnvir.LibraryList.TryGetValue(file, out HelmetLibrary);

                            if (!WeaponList.TryGetValue(LibraryWeaponShape / 10 + FemaleOffSet, out file)) file = LibraryFile.None;
                            CEnvir.LibraryList.TryGetValue(file, out WeaponLibrary1);

                            if (ShieldShape >= 0)
                            {
                                if (!ShieldList.TryGetValue(ShieldShape / 10 + FemaleOffSet, out file)) file = LibraryFile.None;
                                CEnvir.LibraryList.TryGetValue(file, out WeaponLibrary2);
                            }
                            break;
                    }
                    break;
                
                case MirClass.Assassin:
                    ArmourShapeOffSet = 3000;
                    ShizhuangShapeOffSet = 3000;
                    WeaponShapeOffSet = 5000;
                    HairTypeOffSet = 5000;

                    switch (Gender)
                    {
                        case MirGender.Male:
                            if (!ShizhuangList.TryGetValue(ShizhuangShape / 11 + AssassinOffSet, out szfile) && !ArmourList.TryGetValue(ArmourShape / 11 + AssassinOffSet, out file))
                            {
                                file = LibraryFile.M_HumA;
                                szfile = LibraryFile.M_HumA;
                                ArmourShape = 0;
                                ShizhuangShape = 0;
                            }
                            else if (!ArmourList.TryGetValue(ArmourShape / 11 + AssassinOffSet, out file))
                            {
                                file = LibraryFile.M_HumA;
                                ArmourShape = 0;
                            }
                            else if (!ShizhuangList.TryGetValue(ShizhuangShape / 11 + AssassinOffSet, out szfile))
                            {
                                szfile = LibraryFile.M_HumA;
                                ShizhuangShape = 0;
                            }

                            CEnvir.LibraryList.TryGetValue(szfile, out SzBodyLibrary);
                            CEnvir.LibraryList.TryGetValue(file, out BodyLibrary);

                            CEnvir.LibraryList.TryGetValue(LibraryFile.M_HairA, out HairLibrary);

                            if (!HelmetList.TryGetValue(HelmetShape / 10 + AssassinOffSet, out file)) file = LibraryFile.None;
                            CEnvir.LibraryList.TryGetValue(file, out HelmetLibrary);

                            if (!WeaponList.TryGetValue(LibraryWeaponShape / 10, out file)) file = LibraryFile.None;
                            CEnvir.LibraryList.TryGetValue(file, out WeaponLibrary1);

                            if (LibraryWeaponShape >= 1200)
                            {
                                if (!WeaponList.TryGetValue(LibraryWeaponShape / 10 + RightHandOffSet, out file)) file = LibraryFile.None;
                                CEnvir.LibraryList.TryGetValue(file, out WeaponLibrary2);
                            }
                            else if (ShieldShape >= 0)
                            {
                                if (!ShieldList.TryGetValue(ShieldShape / 10, out file)) file = LibraryFile.None;
                                CEnvir.LibraryList.TryGetValue(file, out WeaponLibrary2);
                            }
                            break;
                        case MirGender.Female:
                            if (!ShizhuangList.TryGetValue(ShizhuangShape / 11 + AssassinOffSet + FemaleOffSet, out szfile) && !ArmourList.TryGetValue(ArmourShape / 11 + AssassinOffSet + FemaleOffSet, out file))
                            {
                                file = LibraryFile.WM_HumA;
                                szfile = LibraryFile.WM_HumA;
                                ArmourShape = 0;
                                ShizhuangShape = 0;
                            }
                            else if (!ArmourList.TryGetValue(ArmourShape / 11 + AssassinOffSet + FemaleOffSet, out file))
                            {
                                file = LibraryFile.WM_HumA;
                                ArmourShape = 0;
                            }
                            else if (!ShizhuangList.TryGetValue(ShizhuangShape / 11 + AssassinOffSet + FemaleOffSet, out szfile))
                            {
                                szfile = LibraryFile.WM_HumA;
                                ShizhuangShape = 0;
                            }

                            CEnvir.LibraryList.TryGetValue(szfile, out SzBodyLibrary);
                            CEnvir.LibraryList.TryGetValue(file, out BodyLibrary);

                            CEnvir.LibraryList.TryGetValue(LibraryFile.WM_HairA, out HairLibrary);

                            if (!HelmetList.TryGetValue(HelmetShape / 10 + AssassinOffSet + FemaleOffSet, out file)) file = LibraryFile.None;
                            CEnvir.LibraryList.TryGetValue(file, out HelmetLibrary);

                            if (!WeaponList.TryGetValue(LibraryWeaponShape / 10 + FemaleOffSet, out file)) file = LibraryFile.None;
                            CEnvir.LibraryList.TryGetValue(file, out WeaponLibrary1);

                            if (LibraryWeaponShape >= 1200)
                            {
                                if (!WeaponList.TryGetValue(LibraryWeaponShape / 10 + FemaleOffSet + RightHandOffSet, out file)) file = LibraryFile.None;
                                CEnvir.LibraryList.TryGetValue(file, out WeaponLibrary2);
                            }
                            else if (ShieldShape >= 0)
                            { 
                                if (!ShieldList.TryGetValue(ShieldShape / 10 + FemaleOffSet, out file)) file = LibraryFile.None;
                                CEnvir.LibraryList.TryGetValue(file, out WeaponLibrary2);
                            }
                            break;
                    }
                    break;
            }
            
        }

        public override void SetAnimation(ObjectAction action)
        {
            MirAnimation animation;
            DrawWeapon = true;
            MagicType type;
            switch (action.Action)
            {
                case MirAction.Standing:
                    
                    animation = MirAnimation.Standing;

                    if (CEnvir.Now < StanceTime)
                        animation = MirAnimation.Stance;

                    if (VisibleBuffs.Contains(BuffType.Cloak))
                        animation = MirAnimation.CreepStanding;

                    if (Horse != HorseType.None)
                        animation = MirAnimation.HorseStanding;

                    if (VisibleBuffs.Contains(BuffType.DragonRepulse))
                        animation = MirAnimation.DragonRepulseMiddle;
                    else if (CurrentAnimation == MirAnimation.DragonRepulseMiddle)
                        animation = MirAnimation.DragonRepulseEnd;

                    if (VisibleBuffs.Contains(BuffType.ElementalHurricane))
                        animation = MirAnimation.ChannellingMiddle;

                    break;
                case MirAction.Moving:
                    
                  
                    animation = MirAnimation.Walking;

                    if (Horse != HorseType.None)
                        animation = MirAnimation.HorseWalking;

                    if ((MagicType)action.Extra[1] == MagicType.ShoulderDash || (MagicType)action.Extra[1] == MagicType.Assault)
                        animation = MirAnimation.Combat8;
                    else if(VisibleBuffs.Contains(BuffType.Cloak))
                        animation = VisibleBuffs.Contains(BuffType.GhostWalk) ? MirAnimation.CreepWalkFast : MirAnimation.CreepWalkSlow;
                    else if ((int) action.Extra[0] >= 2)
                    {
                        animation = MirAnimation.Running;
                        if (Horse != HorseType.None)
                            animation = MirAnimation.HorseRunning;
                    }
                    break;
                case MirAction.Pushed:
                    animation = MirAnimation.Pushed;
                    break;
                case MirAction.Attack:
                    type = (MagicType)action.Extra[1];
                    animation = Functions.GetAttackAnimation(Class, LibraryWeaponShape, type);
                    break;
                case MirAction.Mining:
                    animation = Functions.GetAttackAnimation(Class, LibraryWeaponShape, MagicType.None);
                    break;
                case MirAction.RangeAttack:
                    animation = MirAnimation.Combat1;
                    break;
                case MirAction.Spell:
                    type = (MagicType) action.Extra[0];
                    
                    animation = Functions.GetMagicAnimation(type);

                    if (type == MagicType.PoisonousCloud)
                        DrawWeapon = false;

                    if (VisibleBuffs.Contains(BuffType.ElementalHurricane))
                        animation = MirAnimation.ChannellingEnd;

                    break;
                    
                    
                    
                    
                    
                case MirAction.Die:
                    animation = MirAnimation.Die;
                    break;
                case MirAction.Dead:
                    animation = MirAnimation.Dead;
                    break;
                case MirAction.Harvest:
                    animation = MirAnimation.Harvest;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            CurrentAnimation = animation;
            if (!Frames.TryGetValue(CurrentAnimation, out CurrentFrame))
                CurrentFrame = Frame.EmptyFrame;
        }

        public sealed override void SetFrame(ObjectAction action)
        {
            base.SetFrame(action);

            switch (action.Action)
            {
                case MirAction.Spell:
                case MirAction.Attack:
                    StanceTime = CEnvir.Now.AddSeconds(3);
                    break;
            }

            switch (Class)
            {
                case MirClass.Assassin:
                    switch (CurrentAnimation)
                    {
                        case MirAnimation.Standing:
                            ArmourShift = 0;
                            break;
                        case MirAnimation.Walking:
                            ArmourShift = 1600;
                            break;
                        case MirAnimation.Running:
                            ArmourShift = 1600;
                            break;
                        case MirAnimation.CreepStanding:
                            ArmourShift = 240;
                            break;
                        case MirAnimation.CreepWalkSlow:
                        case MirAnimation.CreepWalkFast:
                            ArmourShift = 240;
                            break;
                        case MirAnimation.Pushed:
                            ArmourShift = 160;
                            
                            break;
                        case MirAnimation.Combat1:
                            ArmourShift = -400;
                            break;
                        case MirAnimation.Combat2:
                            ;
                            break;
                        case MirAnimation.Combat3:
                            ArmourShift = 0;
                            break;
                        case MirAnimation.Combat4:
                            ArmourShift = 80;
                            break;
                        case MirAnimation.Combat5:
                            ArmourShift = 400;
                            break;
                        case MirAnimation.Combat6:
                            ArmourShift = 400;
                            break;
                        case MirAnimation.Combat7:
                            ArmourShift = 400;
                            break;
                        case MirAnimation.Combat8:
                            ArmourShift = 720;
                            break;
                        case MirAnimation.Combat9:
                            ArmourShift = -960;
                            break;
                        case MirAnimation.Combat10:
                            ArmourShift = -480;
                            break;
                        case MirAnimation.Combat11:
                            ArmourShift = -400;
                            break;
                        case MirAnimation.Combat12:
                            ArmourShift = -400;
                            break;
                        case MirAnimation.Combat13:
                            ArmourShift = -400;
                            break;
                        case MirAnimation.Combat14:
                        case MirAnimation.DragonRepulseStart:
                        case MirAnimation.DragonRepulseMiddle:
                        case MirAnimation.DragonRepulseEnd:
                            ArmourShift = 0;
                            break;
                        case MirAnimation.Harvest:
                            ArmourShift = 160;
                            break;
                        case MirAnimation.Stance:
                            ArmourShift = 160;
                            break;
                        case MirAnimation.Struck:
                            ArmourShift = -640;
                            break;
                        case MirAnimation.Die:
                            ArmourShift = -400;
                            break;
                        case MirAnimation.Dead:
                            ArmourShift = -400;
                            break;
                        case MirAnimation.HorseStanding:
                            ArmourShift = 80;
                            break;
                        case MirAnimation.HorseWalking:
                            ArmourShift = 80;
                            break;
                        case MirAnimation.HorseRunning:
                            ArmourShift = 80;
                            break;
                        case MirAnimation.HorseStruck:
                            ArmourShift = 80;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    break;
            }

        }

        // 重写FrameIndexChanged方法
        public override void FrameIndexChanged()
        {
            // 根据当前动作类型进行判断
            switch (CurrentAction)
            {
                // 如果当前动作类型为施法
                case MirAction.Spell:
                    // 根据魔法类型进行判断
                    switch (MagicType)
                    {
                        // 如果魔法类型为地震波
                        case MagicType.SeismicSlam:
                            // 如果帧索引为4
                            if (FrameIndex == 4)
                            {
                                // 如果玩家拥有斩刺隐身且明文01、02、03中有一个为167
                                if (GameScene.Game.User.ZhanchuiYin && Mingwen01 == 167 || Mingwen02 == 167 || Mingwen03 == 167)
                                {
                                    // 取消玩家斩刺隐身
                                    GameScene.Game.User.ZhanchuiYin = false;
                                    // 添加特效
                                    Effects.Add(new MirEffect(1180, 7, TimeSpan.FromMilliseconds(120), LibraryFile.MagicEx10, 10, 35, CartoonGlobals.NoneColour)
                                    {
                                        Blend = true,
                                        MapTarget = Functions.Move(CurrentLocation, Direction, 2),
                                    });
                                }
                                // 如果玩家拥有天神隐身且明文01、02、03中有一个为168
                                else if (GameScene.Game.User.TianshenYin && Mingwen01 == 168 || Mingwen02 == 168 || Mingwen03 == 168)
                                {
                                    // 取消玩家天神隐身
                                    GameScene.Game.User.TianshenYin = false;
                                    // 添加特效
                                    Effects.Add(new MirEffect(1170, 7, TimeSpan.FromMilliseconds(120), LibraryFile.MagicEx10, 10, 35, CartoonGlobals.NoneColour)
                                    {
                                        Blend = true,
                                        MapTarget = Functions.Move(CurrentLocation, Direction, 2),
                                    });
                                }
                                // 否则
                                else
                                {
                                    // 添加特效
                                    Effects.Add(new MirEffect(700, 7, TimeSpan.FromMilliseconds(120), LibraryFile.MonMagicEx7, 10, 35, CartoonGlobals.LightningColour)
                                    {
                                        Blend = true,
                                        MapTarget = Functions.Move(CurrentLocation, Direction, 2),
                                    });
                                }
                            }
                            break;
                        // 如果魔法类型为毁灭打击
                        case MagicType.CrushingWave:
                            // 如果帧索引为4
                            if (FrameIndex == 4)
                            {
                                // 定义一个MirEffect对象
                                MirEffect spell;
                                // 添加特效
                                Effects.Add(spell = new MirProjectile(200, 8, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx6, 35, 35, CartoonGlobals.LightningColour, CurrentLocation)
                                {
                                    Blend = true,
                                    Has16Directions = false,
                                    MapTarget = Functions.Move(CurrentLocation, Direction, CartoonGlobals.MagicRange),
                                    Speed = 100,
                                });
                                // 处理特效
                                spell.Process();
                                // 播放音效
                                DXSoundManager.Play(SoundIndex.DestructiveBlow);

                                // 添加特效
                                Effects.Add(new MirEffect(300, 9, TimeSpan.FromMilliseconds(150), LibraryFile.MagicEx6, 10, 35, CartoonGlobals.LightningColour)
                                {
                                    Blend = true,
                                    Direction = Direction,
                                    MapTarget = Functions.Move(CurrentLocation, Direction, 1),
                                });
                            }
                            break;
                    }
                    break;
                // 默认情况下，调用基类的FrameIndexChanged方法
                default:
                    base.FrameIndexChanged();
                    break;
            }
        }
        public override void SetAction(ObjectAction action)
        {
            base.SetAction(action);

            switch (CurrentAction)
            {
                case MirAction.Attack:
                    switch (MagicType)
                    {
                        #region Sweet Brier and Karma (Karma should have different attack will do later if can be bothered)
                        case MagicType.SweetBrier:
                        case MagicType.Karma:
                            if (LibraryWeaponShape >= 1200)
                            {
                                Effects.Add(new MirEffect(300, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx4, 20, 70, CartoonGlobals.NoneColour) 
                                {
                                    Blend = true,
                                    Target = this,
                                    DrawColour = CartoonGlobals.NoneColour,
                                    Direction = Direction,
                                });
                            }
                            else if (LibraryWeaponShape >= 1100)
                            {
                                Effects.Add(new MirEffect(100, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx4, 20, 70, CartoonGlobals.NoneColour) 
                                {
                                    Blend = true,
                                    Target = this,
                                    DrawColour = CartoonGlobals.NoneColour,
                                    Direction = Direction,
                                });
                            }

                            if (Gender == MirGender.Male)
                                DXSoundManager.Play(SoundIndex.SweetBrierMale);
                            else
                                DXSoundManager.Play(SoundIndex.SweetBrierFemale);
                            break;
                            #endregion
                    }
                    break;

            }
        }
        

        
        public override void Draw()
        {
            if (BodyLibrary == null) return;

            if (SzBodyLibrary != null)
            {
                switch (Direction)
                {
                    case MirDirection.Up:
                    case MirDirection.UpRight:
                    case MirDirection.Right:
                    case MirDirection.Left:
                    case MirDirection.UpLeft:
                        break;
                    case MirDirection.DownRight:
                    case MirDirection.Down:
                    case MirDirection.DownLeft:
                        switch (ArmourImage)
                        {
                            
                            case 962:
                            case 972:
                                break;
                            default:
                                DrawWings();
                                break;

                        }
                        break;
                }
                DrawBody(true);


                switch (Direction)
                {
                    case MirDirection.Up:
                    case MirDirection.UpRight:
                    case MirDirection.Right:
                    case MirDirection.Left:
                    case MirDirection.UpLeft:
                        DrawWings();
                        break;
                    case MirDirection.DownRight:
                    case MirDirection.Down:
                    case MirDirection.DownLeft:
                        switch (ArmourImage)
                        {
                            
                            case 962:
                            case 972:
                                DrawWings();
                                break;
                        }
                        break;
                }
            }

            if (DrawWeaponEffectBehind())
                DrawWeaponEffect();
            if (DrawWeaponEffectInfront())
                DrawWeaponEffect();

            DrawEmblemEffect();
        }


        public bool DrawWeaponEffectBehind()
        {
            switch (Direction)
            {
                case MirDirection.Up:
                case MirDirection.DownLeft:
                case MirDirection.Left:
                case MirDirection.UpLeft:
                    return true;
                default:
                    return false;
            }
        }

        public bool DrawWeaponEffectInfront()
        {
            return (uint)(Direction - (byte)1) <= 3U;
        }

        public override void DrawBlend()
        {
            if (BodyLibrary == null && SzBodyLibrary == null) return;

            DXManager.SetBlend(true, 0.60F);

            DrawBody(false);
            DXManager.SetBlend(false); 
        }

        public void DrawBody(bool shadow)
        {
            
            Surface oldSurface = DXManager.CurrentSurface;
            DXManager.SetSurface(DXManager.ScratchSurface);
            DXManager.Device.Clear(ClearFlags.Target, 0, 0, 0);
            DXManager.Sprite.Flush();

            int l = int.MaxValue, t = int.MaxValue, r = int.MinValue, b = int.MinValue;


            MirImage image;
            switch (Direction)
            {
                case MirDirection.Up:
                case MirDirection.DownLeft:
                case MirDirection.Left:
                case MirDirection.UpLeft:
                    if (!DrawWeapon) break;
                    image = WeaponLibrary1?.GetImage(WeaponFrame);
                    if (image == null) break;

                    WeaponLibrary1.Draw(WeaponFrame, DrawX, DrawY, Color.White, true, 1F, ImageType.Image);

                    l = Math.Min(l, DrawX + image.OffSetX);
                    t = Math.Min(t, DrawY + image.OffSetY);
                    r = Math.Max(r, image.Width + DrawX + image.OffSetX);
                    b = Math.Max(b, image.Height + DrawY + image.OffSetY);
                    break;
                default:
                    if (!DrawWeapon) break;

                    var frame = ShieldShape >= 0 ? ShieldFrame : WeaponFrame;
                    image = WeaponLibrary2?.GetImage(frame);

                    if (image == null) break;

                    WeaponLibrary2.Draw(frame, DrawX, DrawY, Color.White, true, 1F, ImageType.Image);

                    l = Math.Min(l, DrawX + image.OffSetX);
                    t = Math.Min(t, DrawY + image.OffSetY);
                    r = Math.Max(r, image.Width + DrawX + image.OffSetX);
                    b = Math.Max(b, image.Height + DrawY + image.OffSetY);
                    break;
            }


            
            if (ShizhuangShape != 0)
            {
                image = SzBodyLibrary?.GetImage(ShizhuangFrame);
                if (image != null)
                {
                    SzBodyLibrary.Draw(ShizhuangFrame, DrawX, DrawY, Color.White, true, 1F, ImageType.Image);

                    l = Math.Min(l, DrawX + image.OffSetX);
                    t = Math.Min(t, DrawY + image.OffSetY);
                    r = Math.Max(r, image.Width + DrawX + image.OffSetX);
                    b = Math.Max(b, image.Height + DrawY + image.OffSetY);
                }
            }
            else
            {
                image = BodyLibrary?.GetImage(ArmourFrame);
                if (image != null)
                {
                    BodyLibrary.Draw(ArmourFrame, DrawX, DrawY, Color.White, true, 1F, ImageType.Image);

                    if (ArmourColour.ToArgb() != 0)
                        BodyLibrary.Draw(ArmourFrame, DrawX, DrawY, ArmourColour, true, 1F, ImageType.Overlay);

                    l = Math.Min(l, DrawX + image.OffSetX);
                    t = Math.Min(t, DrawY + image.OffSetY);
                    r = Math.Max(r, image.Width + DrawX + image.OffSetX);
                    b = Math.Max(b, image.Height + DrawY + image.OffSetY);
                }
            }

            
            switch (ShizhuangShape)
            {
                case 0:
                    if (HelmetShape > 0)
                    {
                        image = HelmetLibrary?.GetImage(HelmetFrame);
                        if (image != null)
                        {
                            HelmetLibrary.Draw(HelmetFrame, DrawX, DrawY, Color.White, true, 1F, ImageType.Image);

                            l = Math.Min(l, DrawX + image.OffSetX);
                            t = Math.Min(t, DrawY + image.OffSetY);
                            r = Math.Max(r, image.Width + DrawX + image.OffSetX);
                            b = Math.Max(b, image.Height + DrawY + image.OffSetY);
                        }
                    }
                    else if (HelmetShape <= 0 && ShizhuangShape == 0)
                    {
                        image = HairLibrary.GetImage(HairFrame);
                        if (HairType > 0 && image != null)
                        {
                            HairLibrary.Draw(HairFrame, DrawX, DrawY, HairColour, true, 1F, ImageType.Image);

                            l = Math.Min(l, DrawX + image.OffSetX);
                            t = Math.Min(t, DrawY + image.OffSetY);
                            r = Math.Max(r, image.Width + DrawX + image.OffSetX);
                            b = Math.Max(b, image.Height + DrawY + image.OffSetY);
                        }
                    }
                    break;
                case 13:
                case 14:
                case 23:
                    image = HairLibrary.GetImage(HairFrame);
                    if (HairType > 0 && image != null)
                    {
                        HairLibrary.Draw(HairFrame, DrawX, DrawY, HairColour, true, 1F, ImageType.Image);

                        l = Math.Min(l, DrawX + image.OffSetX);
                        t = Math.Min(t, DrawY + image.OffSetY);
                        r = Math.Max(r, image.Width + DrawX + image.OffSetX);
                        b = Math.Max(b, image.Height + DrawY + image.OffSetY);
                    }
                    break;
                case 27:
                    break;
            }

            /*
            if (ShizhuangShape == 0)
            {
                if (HelmetShape > 0)
                {
                    image = HelmetLibrary?.GetImage(HelmetFrame);
                    if (image != null)
                    {
                        HelmetLibrary.Draw(HelmetFrame, DrawX, DrawY, Color.White, true, 1F, ImageType.Image);

                        l = Math.Min(l, DrawX + image.OffSetX);
                        t = Math.Min(t, DrawY + image.OffSetY);
                        r = Math.Max(r, image.Width + DrawX + image.OffSetX);
                        b = Math.Max(b, image.Height + DrawY + image.OffSetY);
                    }
                }
                else if (HelmetShape <= 0 && ShizhuangShape == 0)
                {
                    image = HairLibrary.GetImage(HairFrame);
                    if (HairType > 0 && image != null)
                    {
                        HairLibrary.Draw(HairFrame, DrawX, DrawY, HairColour, true, 1F, ImageType.Image);

                        l = Math.Min(l, DrawX + image.OffSetX);
                        t = Math.Min(t, DrawY + image.OffSetY);
                        r = Math.Max(r, image.Width + DrawX + image.OffSetX);
                        b = Math.Max(b, image.Height + DrawY + image.OffSetY);
                    }
                }
            }
            else if (ShizhuangShape == 14)
            {
                image = HairLibrary.GetImage(HairFrame);
                if (HairType > 0 && image != null)
                {
                    HairLibrary.Draw(HairFrame, DrawX, DrawY, HairColour, true, 1F, ImageType.Image);

                    l = Math.Min(l, DrawX + image.OffSetX);
                    t = Math.Min(t, DrawY + image.OffSetY);
                    r = Math.Max(r, image.Width + DrawX + image.OffSetX);
                    b = Math.Max(b, image.Height + DrawY + image.OffSetY);
                }
            }
            */
            switch (Direction)
            {
                case MirDirection.UpRight:
                case MirDirection.Right:
                case MirDirection.DownRight:
                case MirDirection.Down:
                    if (!DrawWeapon) break;
                    image = WeaponLibrary1?.GetImage(WeaponFrame);
                    if (image == null) break;

                    WeaponLibrary1.Draw(WeaponFrame, DrawX, DrawY, Color.White, true, 1F, ImageType.Image);

                    l = Math.Min(l, DrawX + image.OffSetX);
                    t = Math.Min(t, DrawY + image.OffSetY);
                    r = Math.Max(r, image.Width + DrawX + image.OffSetX);
                    b = Math.Max(b, image.Height + DrawY + image.OffSetY);
                    break;
                default:
                    if (!DrawWeapon) break;

                    var frame = ShieldShape >= 0 ? ShieldFrame : WeaponFrame;
                    image = WeaponLibrary2?.GetImage(frame);

                    if (image == null) break;

                    WeaponLibrary2.Draw(frame, DrawX, DrawY, Color.White, true, 1F, ImageType.Image);

                    l = Math.Min(l, DrawX + image.OffSetX);
                    t = Math.Min(t, DrawY + image.OffSetY);
                    r = Math.Max(r, image.Width + DrawX + image.OffSetX);
                    b = Math.Max(b, image.Height + DrawY + image.OffSetY);
                    break;
            }

            DXManager.SetSurface(oldSurface);
            float oldOpacity = DXManager.Opacity;
            
            if (shadow)
            {
                switch (CurrentAnimation)
                {
                    case MirAnimation.HorseStanding:
                    case MirAnimation.HorseWalking:
                    case MirAnimation.HorseRunning:
                    case MirAnimation.HorseStruck:
                        HorseLibrary?.Draw(HorseFrame, DrawX, DrawY, Color.Black, true, 0.5F, ImageType.Shadow);
                        break;
                    default:
                        DrawShadow2(l, t, r, b);
                        break;
                }
            }

            if (oldOpacity != Opacity && !DXManager.Blending) DXManager.SetOpacity(Opacity);


            switch (CurrentAnimation)
            {
                case MirAnimation.HorseStanding:
                case MirAnimation.HorseWalking:
                case MirAnimation.HorseRunning:
                case MirAnimation.HorseStruck:

                    switch (HorseShape)
                    {
                        case 0:
                            HorseLibrary?.Draw(HorseFrame, DrawX, DrawY, Color.White, true, Opacity, ImageType.Image);
                            break;
                        case 1:
                        case 2:
                        case 3:
                            HorseShapeLibrary?.Draw(HorseFrame, DrawX, DrawY, Color.White, true, Opacity, ImageType.Image);
                            break;
                        case 4:
                            HorseShapeLibrary?.Draw(DrawFrame, DrawX, DrawY, Color.White, true, Opacity, ImageType.Image);
                            break;
                        case 5:
                            HorseShapeLibrary?.Draw(DrawFrame, DrawX, DrawY, Color.White, true, Opacity, ImageType.Image);
                            if(shadow)
                                HorseShapeLibrary2?.DrawBlend(DrawFrame, DrawX, DrawY, Color.White, true, Opacity, ImageType.Image);
                            break;

                    }

                    break;
            }



            DXManager.Sprite.Draw(DXManager.ScratchTexture, Rectangle.FromLTRB(l, t, r, b), Vector3.Zero, new Vector3(l, t, 0), DrawColour);
            CEnvir.DPSCounter++;
            if (oldOpacity != Opacity && !DXManager.Blending) DXManager.SetOpacity(oldOpacity);

            }
        
        public void DrawShadow2(int l, int t, int r, int b)
        {
            MirImage image = BodyLibrary?.GetImage(ArmourFrame);
            MirImage szimage = SzBodyLibrary?.GetImage(ShizhuangFrame);

            if (ShizhuangShape == 0)
            {
                if (image == null) return;

                int w = (DrawX + image.OffSetX) - l;
                int h = (DrawY + image.OffSetY) - t;

                Matrix m = Matrix.Scaling(1F, 0.5f, 0);

                m.M21 = -0.50F;
                DXManager.Sprite.Transform = m * Matrix.Translation(DrawX + image.ShadowOffSetX - w + (image.Height) / 2 + h / 2, DrawY + image.ShadowOffSetY - h / 2, 0);

                DXManager.Device.SetSamplerState(0, SamplerState.MinFilter, TextureFilter.None);

                float oldOpacity = DXManager.Opacity;
                if (oldOpacity != 0.649999976158142) DXManager.SetOpacity(0.65F);
                DXManager.Sprite.Draw(DXManager.ScratchTexture, Rectangle.FromLTRB(l, t, r, b), Vector3.Zero, Vector3.Zero, Color.Black);

                DXManager.Sprite.Transform = Matrix.Identity;
                DXManager.Device.SetSamplerState(0, SamplerState.MinFilter, TextureFilter.Point);

                if (0.649999976158142 != oldOpacity) DXManager.SetOpacity(oldOpacity);
            }
            else
            {

                int w = (DrawX + szimage.OffSetX) - l;
                int h = (DrawY + szimage.OffSetY) - t;

                Matrix m = Matrix.Scaling(1F, 0.5f, 0);

                m.M21 = -0.50F;
                DXManager.Sprite.Transform = m * Matrix.Translation(DrawX + szimage.ShadowOffSetX - w + (szimage.Height) / 2 + h / 2, DrawY + szimage.ShadowOffSetY - h / 2, 0);

                DXManager.Device.SetSamplerState(0, SamplerState.MinFilter, TextureFilter.None);

                float oldOpacity = DXManager.Opacity;
                if (oldOpacity != 0.649999976158142) DXManager.SetOpacity(0.65F);
                DXManager.Sprite.Draw(DXManager.ScratchTexture, Rectangle.FromLTRB(l, t, r, b), Vector3.Zero, Vector3.Zero, Color.Black);

                DXManager.Sprite.Transform = Matrix.Identity;
                DXManager.Device.SetSamplerState(0, SamplerState.MinFilter, TextureFilter.Point);

                if (0.649999976158142 != oldOpacity) DXManager.SetOpacity(oldOpacity);
            }
        }

        
        public override void DrawHealth()
        {
            if (!Config.数字显血) return;

            ClientObjectData data;
            if (!GameScene.Game.DataDictionary.TryGetValue(ObjectID, out data)) return;

            if (!Config.数字显血 && !GameScene.Game.IsAlly(ObjectID) && User.Buffs.All(x => x.Type != BuffType.Developer)) return;

            if (this == User && User.Buffs.Any(x => x.Type == BuffType.SuperiorMagicShield))
            {
                MirLibrary library;

                if (!CEnvir.LibraryList.TryGetValue(LibraryFile.Interface, out library)) return;

                float percent = Math.Min(1f, Math.Max(0.0f, User.Buffs.First(x => x.Type == BuffType.SuperiorMagicShield).Stats[Stat.SuperiorMagicShield] / (float)User.Stats[Stat.SuperiorMagicShield]));

                if (percent == 0) return;

                Size size = library.GetSize(79);

                Color color = Color.Goldenrod;

                library.Draw(80, DrawX, DrawY - 66, Color.White, false, 1F, ImageType.Image);
                library.Draw(79, DrawX + 1, DrawY - 66 + 1, color, new Rectangle(0, 0, (int)(size.Width * percent), size.Height), 1F, ImageType.Image, (byte)0);
            }

            if (data.MaxHealth > 0)
            {
                MirLibrary mirLibrary;
                if (!CEnvir.LibraryList.TryGetValue(LibraryFile.Interface, out mirLibrary))
                    return;
                float num1 = Math.Min(1f, Math.Max(0.0f, (float)data.Health / (float)data.MaxHealth));
                if ((double)num1 == 0.0)
                    return;
                Size size = mirLibrary.GetSize(79);
                Color orangeRed = Color.OrangeRed;
                int num2 = 62;
                int num3 = 75;
                if (this != MapObject.User && (!Config.数字显血 || !GameScene.Game.IsAlly(ObjectID) || data.MaxMana < 0))
                {
                    num2 = 58;
                    num3 = 71;
                }
                mirLibrary.Draw(80, (float)DrawX, (float)(DrawY - num2), (Color4)Color.White, false, 1f, ImageType.Image);
                mirLibrary.Draw(79, (float)(DrawX + 1), (float)(DrawY - num2 + 1), (Color4)orangeRed, new Rectangle(0, 0, (int)((double)size.Width * (double)num1), size.Height), 1f, ImageType.Image, (byte)0);
                if (HPratioLabel != null && Config.数字显血)
                {
                    if (this == User && User.Buffs.Any(x => x.Type == BuffType.SuperiorMagicShield))
                    {
                        HPratioLabel.Text = string.Format("{0}/{1}", (object)data.Health, (object)data.MaxHealth);
                        HPratioLabel.Location = new Point(DrawX + (50 - HPratioLabel.Size.Width) / 2, DrawY - 79);
                        HPratioLabel.Draw();
                    }
                    else
                    {
                        HPratioLabel.Text = string.Format("{0}/{1}", (object)data.Health, (object)data.MaxHealth);
                        HPratioLabel.Location = new Point(DrawX + (50 - HPratioLabel.Size.Width) / 2, DrawY - num3);
                        HPratioLabel.Draw();
                    }
                }
            }

            MirLibrary mirLibrary1;
            if (Config.数字显血 && !GameScene.Game.IsAlly(ObjectID) || data.MaxMana <= 0 || !CEnvir.LibraryList.TryGetValue(LibraryFile.Interface, out mirLibrary1))
                return;
            float num = Math.Min(1f, Math.Max(0.0f, (float)data.Mana / (float)data.MaxMana));
            if ((double)num == 0.0)
                return;
            Size size1 = mirLibrary1.GetSize(79);
            Color dodgerBlue = Color.DodgerBlue;
            mirLibrary1.Draw(80, (float)DrawX, (float)(DrawY - 58), (Color4)Color.White, false, 1f, ImageType.Image);
            mirLibrary1.Draw(79, (float)(DrawX + 1), (float)(DrawY - 58 + 1), (Color4)dodgerBlue, new Rectangle(0, 0, (int)((double)size1.Width * (double)num), size1.Height), 1f, ImageType.Image, (byte)0);
           
            
            GameScene.Game.PartyListBox.PopulateMembers();
        } 

        private void DrawWings()
        {
            if (!Config.DrawEffects) return;

            switch (CurrentAction)
            {
                case MirAction.Die:
                case MirAction.Dead:
                    break;
                default:
                    MirLibrary library;

                    if (!CEnvir.LibraryList.TryGetValue(LibraryFile.EquipEffect_Part, out library)) return;
                    if (ShizhuangShape == 0)
                    {
                        switch (ArmourImage)
                        {
                            
                            case 962:
                            case 972:
                                library.DrawBlend(820 + (GameScene.Game.MapControl.Animation / 2) % 13, DrawX, DrawY, Color.White, true, 0.7f, ImageType.Image);
                                
                                break;

                            
                            case 963:
                            case 973:
                                library.DrawBlend(400 + (GameScene.Game.MapControl.Animation / 2) % 15 + (int)Direction * 20, DrawX, DrawY, Color.White, true, 1f, ImageType.Image);
                                
                                break;

                            
                            case 964:
                            case 974:
                                library.DrawBlend(200 + (GameScene.Game.MapControl.Animation / 2) % 15 + (int)Direction * 20, DrawX, DrawY, Color.White, true, 1f, ImageType.Image);
                                
                                break;

                            
                            case 965:
                            case 975:
                                library.DrawBlend(0 + (GameScene.Game.MapControl.Animation / 2) % 15 + (int)Direction * 20, DrawX, DrawY, Color.White, true, 1f, ImageType.Image);
                                
                                break;

                            
                            case 2007:
                            case 2017:
                                
                                if (Horse != HorseType.None)
                                {
                                    library.DrawBlend(600 + (GameScene.Game.MapControl.Animation / 2) % 13 + (int)Direction * 20, DrawX, DrawY - 25, Color.White, true, 1f, ImageType.Image);
                                    break;
                                }
                                else
                                {
                                    library.DrawBlend(600 + (GameScene.Game.MapControl.Animation / 2) % 13 + (int)Direction * 20, DrawX, DrawY, Color.White, true, 1f, ImageType.Image);
                                    break;
                                }



                        }

                        if (!CEnvir.LibraryList.TryGetValue(LibraryFile.EquipEffect_Full, out library)) return;

                        switch (ArmourImage)
                        {
                            
                            case 3321:
                            case 3331:
                                
                                if (Horse != HorseType.None)
                                {
                                    library.DrawBlend(50000 + (GameScene.Game.MapControl.Animation / 2) % 4 + (int)Direction * 10, DrawX, DrawY - 25, Color.White, true, 1f, ImageType.Image);
                                    break;
                                }
                                else
                                {
                                    library.DrawBlend(50000 + (GameScene.Game.MapControl.Animation / 2) % 4 + (int)Direction * 10, DrawX, DrawY, Color.White, true, 1f, ImageType.Image);
                                    break;
                                }
                            
                            case 3322:
                            case 3332:
                            case 6001:
                            case 6011:
                                
                                if (Horse != HorseType.None)
                                {
                                    library.DrawBlend(0 + (GameScene.Game.MapControl.Animation / 2) % 4 + (int)Direction * 10, DrawX, DrawY - 25, Color.White, true, 1f, ImageType.Image);
                                    break;
                                }
                                else
                                {
                                    library.DrawBlend(0 + (GameScene.Game.MapControl.Animation / 2) % 4 + (int)Direction * 10, DrawX, DrawY, Color.White, true, 1f, ImageType.Image);
                                    break;
                                }
                            
                            case 3327:
                            case 3337:
                                
                                if (Horse != HorseType.None)
                                {
                                    library.DrawBlend(60000 + (GameScene.Game.MapControl.Animation / 2) % 4 + (int)Direction * 10, DrawX, DrawY - 25, Color.White, true, 1f, ImageType.Image);
                                    break;
                                }
                                else
                                {
                                    library.DrawBlend(60000 + (GameScene.Game.MapControl.Animation / 2) % 4 + (int)Direction * 10, DrawX, DrawY, Color.White, true, 1f, ImageType.Image);
                                    break;
                                }
                            
                            case 3324:
                            case 3334:
                                
                                if (Horse != HorseType.None)
                                {
                                    library.DrawBlend(70000 + (GameScene.Game.MapControl.Animation / 2) % 4 + (int)Direction * 10, DrawX, DrawY - 25, Color.White, true, 1f, ImageType.Image);
                                    break;
                                }
                                else
                                {
                                    library.DrawBlend(70000 + (GameScene.Game.MapControl.Animation / 2) % 4 + (int)Direction * 10, DrawX, DrawY, Color.White, true, 1f, ImageType.Image);
                                    break;
                                }

                            
                            case 3380:
                            case 3390:
                                
                                if (Horse != HorseType.None)
                                {
                                    library.DrawBlend(80000 + (GameScene.Game.MapControl.Animation / 2) % 4 + (int)Direction * 10, DrawX, DrawY - 25, Color.White, true, 1f, ImageType.Image);
                                    break;
                                }
                                else
                                {
                                    library.DrawBlend(80000 + (GameScene.Game.MapControl.Animation / 2) % 4 + (int)Direction * 10, DrawX, DrawY, Color.White, true, 1f, ImageType.Image);
                                    break;
                                }
                        }

                        if (!CEnvir.LibraryList.TryGetValue(LibraryFile.EquipEffect_FullEx1, out library)) return;

                        switch (ArmourImage)
                        {
                            
                            case 3328:
                            case 3338:
                            case 6000:
                            case 6010:
                                
                                if (Horse != HorseType.None)
                                {
                                    library.DrawBlend(0 + (GameScene.Game.MapControl.Animation / 2) % 4 + (int)Direction * 10, DrawX, DrawY - 25, Color.White, true, 1f, ImageType.Image);
                                    break;
                                }
                                else
                                {
                                    library.DrawBlend(0 + (GameScene.Game.MapControl.Animation / 2) % 4 + (int)Direction * 10, DrawX, DrawY, Color.White, true, 1f, ImageType.Image);
                                    break;
                                }


                        }

                        if (!CEnvir.LibraryList.TryGetValue(LibraryFile.EquipEffect_FullEx2, out library)) return;

                        switch (ArmourImage)
                        {
                            
                            case 3325:
                            case 3335:
                            case 3362:
                            case 3372:
                                
                                if (Horse != HorseType.None)
                                {
                                    library.DrawBlend(0 + (GameScene.Game.MapControl.Animation / 2) % 4 + (int)Direction * 10, DrawX, DrawY - 25, Color.White, true, 1f, ImageType.Image);
                                    break;
                                }
                                else
                                {
                                    library.DrawBlend(0 + (GameScene.Game.MapControl.Animation / 2) % 4 + (int)Direction * 10, DrawX, DrawY, Color.White, true, 1f, ImageType.Image);
                                    break;
                                }


                        }
                        if (!CEnvir.LibraryList.TryGetValue(LibraryFile.EquipEffect_FullEx3, out library)) return;

                        switch (ArmourImage)
                        {
                            
                            case 3381:
                            case 3391:
                            case 3382:
                            case 3392:
                                
                                if (Horse != HorseType.None)
                                {
                                    library.DrawBlend(0 + (GameScene.Game.MapControl.Animation / 2) % 4 + (int)Direction * 10, DrawX, DrawY - 25, Color.White, true, 1f, ImageType.Image);
                                    break;
                                }
                                else
                                {
                                    library.DrawBlend(0 + (GameScene.Game.MapControl.Animation / 2) % 4 + (int)Direction * 10, DrawX, DrawY, Color.White, true, 1f, ImageType.Image);
                                    break;
                                }


                        }
                    }
                    else
                    {
                        
                        if (!CEnvir.LibraryList.TryGetValue(LibraryFile.EquipEffect_Full, out library)) return;
                        /*
                        switch (ShizhuangImage)
                        {
                           
                            case 2870:
                            case 2880:
                                if (Horse != HorseType.None)
                                {
                                    library.DrawBlend(50000 + (GameScene.Game.MapControl.Animation / 2) % 4 + (int)Direction * 10, DrawX, DrawY - 25, Color.White, true, 1f, ImageType.Image);
                                    break;
                                }
                                else
                                {
                                    library.DrawBlend(50000 + (GameScene.Game.MapControl.Animation / 2) % 4 + (int)Direction * 10, DrawX, DrawY, Color.White, true, 1f, ImageType.Image);
                                    break;
                                }
                                
                        } */
                        break;
                       
                    }
                    break;
            }
        }

        // 绘制武器效果
        public void DrawWeaponEffect()
        {
            // 如果没有开启绘制效果，则返回
            if (!Config.DrawEffects)
                return;
            // 如果当前动作减去7大于1，则绘制全图效果
            if ((uint)(CurrentAction - (byte)7) > 1U)
            {
                // 获取全图效果库
                MirLibrary mirLibrary;
                if (!CEnvir.LibraryList.TryGetValue(LibraryFile.EquipEffect_Full, out mirLibrary))
                    return;
                // 根据武器图片绘制效果
                switch (WeaponImage)
                {
                    case 1076:
                        mirLibrary.DrawBlend(40000 + 5000 * (int)Gender + DrawFrame, (float)DrawX, (float)DrawY, (Color4)Color.White, true, 1f, ImageType.Image, (byte)0);
                        break;
                    case 2530:
                        mirLibrary.DrawBlend(20000 + 5000 * (int)Gender + DrawFrame, (float)DrawX, (float)DrawY, (Color4)Color.White, true, 0.8f, ImageType.Image, (byte)0);
                        break;
                    case 2550:
                        mirLibrary.DrawBlend(20000 + 5000 * (int)Gender + DrawFrame, (float)DrawX, (float)DrawY, (Color4)Color.White, true, 0.8f, ImageType.Image, (byte)0);
                        break;
                }
            }
            // 获取MY效果库
            MirLibrary mirLibrary1;
            if ((uint)(CurrentAction - (byte)7) <= 1U || !CEnvir.LibraryList.TryGetValue(LibraryFile.EquipEffect_MY, out mirLibrary1))
                return;
            // 根据武器图片绘制效果
            switch (WeaponImage)
            {
                case 1075:
                    mirLibrary1.DrawBlend(5000 * (int)Gender + DrawFrame, (float)DrawX, (float)DrawY, (Color4)Color.CornflowerBlue, true, 1f, ImageType.Image, (byte)0);
                    break;
                case 1089:
                    mirLibrary1.DrawBlend(10000 + 5000 * (int)Gender + DrawFrame, (float)DrawX, (float)DrawY, (Color4)Color.White, true, 1f, ImageType.Image, (byte)0);
                    break;
            }
        }

        public void DrawWingEffect()
        {
            MirLibrary mirLibrary;
            if (!Config.DrawEffects || (uint)(CurrentAction - (byte)7) <= 1U || !CEnvir.LibraryList.TryGetValue(LibraryFile.EquipEffect_Full, out mirLibrary))
                return;
            switch (WingImage)
            {
                case 2030:
                    mirLibrary.DrawBlend(10000 + 5000 * (int)Gender + DrawFrame, (float)DrawX, (float)DrawY, (Color4)Color.White, true, 1f, ImageType.Image, (byte)0);
                    break;
                case 2034:
                    mirLibrary.DrawBlend(50000 + 5000 * (int)Gender + DrawFrame, (float)DrawX, (float)DrawY, (Color4)Color.White, true, 1f, ImageType.Image, (byte)0);
                    break;
                case 2035:
                    mirLibrary.DrawBlend(60000 + 5000 * (int)Gender + DrawFrame, (float)DrawX, (float)DrawY, (Color4)Color.White, true, 1f, ImageType.Image, (byte)0);
                    break;
                case 2036:
                    mirLibrary.DrawBlend(70000 + 5000 * (int)Gender + DrawFrame, (float)DrawX, (float)DrawY, (Color4)Color.White, true, 1f, ImageType.Image, (byte)0);
                    break;
                case 2037:
                    mirLibrary.DrawBlend(80000 + 5000 * (int)Gender + DrawFrame, (float)DrawX, (float)DrawY, (Color4)Color.White, true, 1f, ImageType.Image, (byte)0);
                    break;
                case 2038:
                    mirLibrary.DrawBlend(90000 + 5000 * (int)Gender + DrawFrame, (float)DrawX, (float)DrawY, (Color4)Color.White, true, 1f, ImageType.Image, (byte)0);
                    break;
                case 2039:
                    mirLibrary.DrawBlend(5000 * (int)Gender + DrawFrame, (float)DrawX, (float)DrawY, (Color4)Color.White, true, 1f, ImageType.Image, (byte)0);
                    break;
            }
            if (!CEnvir.LibraryList.TryGetValue(LibraryFile.EquipEffect_FullEx1, out mirLibrary))
                return;
            if (WingImage == 2031)
                mirLibrary.DrawBlend(5000 * (int)Gender + DrawFrame, (float)DrawX, (float)DrawY, (Color4)Color.White, true, 1f, ImageType.Image, (byte)0);
            if (!CEnvir.LibraryList.TryGetValue(LibraryFile.EquipEffect_FullEx2, out mirLibrary))
                return;
            if (WingImage == 2033)
                mirLibrary.DrawBlend(5000 * (int)Gender + DrawFrame, (float)DrawX, (float)DrawY, (Color4)Color.White, true, 1f, ImageType.Image, (byte)0);
            if (!CEnvir.LibraryList.TryGetValue(LibraryFile.EquipEffect_FullEx3, out mirLibrary) || WingImage != 2032)
                return;
            mirLibrary.DrawBlend(5000 * (int)Gender + DrawFrame, (float)DrawX, (float)DrawY, (Color4)Color.White, true, 1f, ImageType.Image, (byte)0);
        }

        public void DrawShieldEffect()
        {
            if (!Config.DrawEffects || (uint)(CurrentAction - (byte)7) <= 1U || ShieldShape < 1000)
                return;
            ShieldLibrary.DrawBlend(ShieldFrame + 100, (float)DrawX, (float)DrawY, (Color4)Color.White, true, 0.8f, ImageType.Image, (byte)0);
            ShieldLibrary.Draw(ShieldFrame, (float)DrawX, (float)DrawY, (Color4)Color.White, true, 1f, ImageType.Image);
        }

        private void DrawEmblemEffect()
        {
            if (!Config.DrawEffects || EmblemLibrary == null || (uint)(CurrentAction - (byte)7) <= 1U)
                return;
            switch (EmblemShape)
            {
                case 1:
                    EmblemLibrary.DrawBlend(500 + GameScene.Game.MapControl.Animation % 40, (float)DrawX, (float)DrawY, (Color4)Color.White, true, 0.7f, ImageType.Image, (byte)0);
                    break;
                case 2:
                    EmblemLibrary.DrawBlend(3800 + GameScene.Game.MapControl.Animation % 32, (float)DrawX, (float)DrawY, (Color4)Color.White, true, 0.7f, ImageType.Image, (byte)0);
                    EmblemLibrary.DrawBlend(3850 + GameScene.Game.MapControl.Animation % 28, (float)DrawX, (float)DrawY, (Color4)Color.White, true, 0.7f, ImageType.Image, (byte)0);
                    break;
                case 3:
                    EmblemLibrary.DrawBlend(640 + GameScene.Game.MapControl.Animation % 33, (float)DrawX, (float)DrawY, (Color4)Color.White, true, 0.7f, ImageType.Image, (byte)0);
                    EmblemLibrary.DrawBlend(600 + GameScene.Game.MapControl.Animation % 28, (float)DrawX, (float)DrawY, (Color4)Color.White, true, 0.7f, ImageType.Image, (byte)0);
                    break;
            }
        }

        // 重写MouseOver方法，判断鼠标是否在对象上
        public override bool MouseOver(Point p)
        {
            // 如果对象有服装，并且服装库可见，则返回true
            if (ShizhuangShape != 0 && SzBodyLibrary != null && SzBodyLibrary.VisiblePixel(ShizhuangFrame, new Point(p.X - DrawX, p.Y - DrawY), false, true))
                return true;

            // 如果对象没有服装，并且身体库可见，则返回true
            if (ShizhuangShape == 0 && BodyLibrary != null && BodyLibrary.VisiblePixel(ArmourFrame, new Point(p.X - DrawX, p.Y - DrawY), false, true))
                return true;

            // 如果对象有头发，并且头发库可见，则返回true
            if (HairType >= 0 && HairLibrary != null && HairLibrary.VisiblePixel(HairFrame, new Point(p.X - DrawX, p.Y - DrawY), false, true))
                return true;

            // 如果对象有头盔，并且头盔库可见，则返回true
            if (HelmetShape >= 0 && HelmetLibrary != null && HelmetLibrary.VisiblePixel(HelmetFrame, new Point(p.X - DrawX, p.Y - DrawY), false, true))
                return true;

            // 如果对象有武器，并且武器库可见，则返回true
            if (LibraryWeaponShape >= 0 && WeaponLibrary1 != null && WeaponLibrary1.VisiblePixel(WeaponFrame, new Point(p.X - DrawX, p.Y - DrawY), false, true))
                return true;

            // 如果对象有武器，并且武器库可见，则返回true
            if (LibraryWeaponShape >= 0 && WeaponLibrary2 != null && WeaponLibrary2.VisiblePixel(WeaponFrame, new Point(p.X - DrawX, p.Y - DrawY), false, true))
                return true;



            // 根据当前动画，判断对象是否有马，并且马库可见，则返回true
            switch (CurrentAnimation)
            {
                case MirAnimation.HorseStanding:
                case MirAnimation.HorseWalking:
                case MirAnimation.HorseRunning:
                case MirAnimation.HorseStruck:
                    if (HorseLibrary != null && HorseLibrary.VisiblePixel(HorseFrame, new Point(p.X - DrawX, p.Y - DrawY), false, true))
                        return true;
                    break;
            }

            // 如果以上条件都不满足，则返回false
            return false;
        }

        public override void OnRemoved()
        {
        }

        public override void PlayStruckSound()
        {
            DXSoundManager.Play(Gender == MirGender.Male ? SoundIndex.MaleStruck : SoundIndex.FemaleStruck);
            DXSoundManager.Play(SoundIndex.GenericStruckPlayer);
        }
        public override void PlayDieSound()
        {
            DXSoundManager.Play(Gender == MirGender.Male ? SoundIndex.MaleDie : SoundIndex.FemaleDie);
        }
        public override void PlayAttackSound()
        {
            if (Class != MirClass.Assassin)
                PlayCommonSounds();
            else
                PlayAssassinSounds();
        }

        private void PlayAssassinSounds()
        {

            if (LibraryWeaponShape >= 1200)
                DXSoundManager.Play(SoundIndex.ClawAttack);
            else if (LibraryWeaponShape >= 1100)
                DXSoundManager.Play(SoundIndex.GlaiveAttack);
            else
                PlayCommonSounds(); 
        }
        // 播放通用声音
        private void PlayCommonSounds()
        {
            // 根据LibraryWeaponShape的值播放不同的声音
            switch (LibraryWeaponShape)
            {
                case 100:
                    // 播放魔杖挥舞的声音
                    DXSoundManager.Play(SoundIndex.WandSwing);
                    break;
                case 9:
                case 101:
                    // 播放木剑挥舞的声音
                    DXSoundManager.Play(SoundIndex.WoodSwing);
                    break;
                case 102:
                    // 播放斧头挥舞的声音
                    DXSoundManager.Play(SoundIndex.AxeSwing);
                    break;
                case 103:
                    // 播放匕首挥舞的声音
                    DXSoundManager.Play(SoundIndex.DaggerSwing);
                    break;
                case 104:
                    // 播放短剑挥舞的声音
                    DXSoundManager.Play(SoundIndex.ShortSwordSwing);
                    break;
                case 26:
                case 105:
                    // 播放铁剑挥舞的声音
                    DXSoundManager.Play(SoundIndex.IronSwordSwing);
                    break;
                default:
                    // 默认播放拳头挥舞的声音
                    DXSoundManager.Play(SoundIndex.FistSwing);
                    break;
            }
        }
    }
}