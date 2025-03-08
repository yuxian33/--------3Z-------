using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Client.Controls;
using Client.Envir;
using Client.UserModels;
using Library;
using S = Library.Network.ServerPackets;
using C = Library.Network.ClientPackets;


namespace Client.Scenes.Views
{
    public sealed class InspectDialog : DXWindow
    {
        #region Properties
        private DXTabControl TabControl;
        private DXTab CharacterTab, StatsTab, elementTab, HermitTab;
        public DXLabel CharacterNameLabel, GuildNameLabel, GuildRankLabel, MarriageNameLabel, Shengwang;
        public DXImageControl MarriageIcon;
        public DXButton Fuzhi, Zudui, Hanghui;

        public DXItemCell[] Grid;

        public DXLabel WearWeightLabel, HandWeightLabel;
        public Dictionary<Stat, DXLabel> DisplayStats = new Dictionary<Stat, DXLabel>();
        public Dictionary<Stat, DXLabel> AttackStats = new Dictionary<Stat, DXLabel>();
        public Dictionary<Stat, DXLabel> AdvantageStats = new Dictionary<Stat, DXLabel>();
        public Dictionary<Stat, DXLabel> DisadvantageStats = new Dictionary<Stat, DXLabel>();

        public Dictionary<Stat, DXLabel> HermitDisplayStats = new Dictionary<Stat, DXLabel>();
        public Dictionary<Stat, DXLabel> HermitAttackStats = new Dictionary<Stat, DXLabel>();
        public DXLabel RemainingLabel;

        public Stats Stats = new Stats();
        public Stats HermitStats = new Stats();
        public int HermitPoints;
        public ClientUserItem[] Equipment = new ClientUserItem[CartoonGlobals.EquipmentSize];
        public MirClass Class;
        public MirGender Gender;
        public int HairType;
        public Color HairColour;
        
        public int Shengwangdian;
        public int Level;
        
        public bool HideShizhuang;
        public DXImageControl Image;

        public override WindowType Type => WindowType.InspectBox;
        public override bool CustomSize => false;
        public override bool AutomaticVisiblity => false;

        #endregion

        public InspectDialog()
        {
            
            HasTitle = true;
            TitleLabel.Text = "玩家信息";
            HasFooter = false;
            SetClientSize(new Size(319, 419));




            TabControl = new DXTabControl
            {
                Parent = this,
                Location = ClientArea.Location,
                Size = ClientArea.Size,
            };
            CharacterTab = new DXTab
            {
                Parent = TabControl,
                Border = true,
                TabButton = { Label = { Text = "角色" } },
            };
            DXImageControl dxImageControl1 = new DXImageControl();
            dxImageControl1.LibraryFile = LibraryFile.Interface;
            dxImageControl1.Index = 106;
            dxImageControl1.Location = new Point(-1, 0);
            dxImageControl1.Parent = CharacterTab;
            Image = dxImageControl1;
            Image.BeforeChildrenDraw += new EventHandler<EventArgs>(CharacterTab_BeforeChildrenDraw);
            
            Image.BeforeChildrenDraw += new EventHandler<EventArgs>(CharacterTab_SwChenghaoDraw);
            StatsTab = new DXTab
            {
                Parent = TabControl,
                Border = true,
                TabButton = { Label = { Text = "属性" } },
            };
            DXImageControl dxImageControl2 = new DXImageControl();
            dxImageControl2.LibraryFile = LibraryFile.Interface;
            dxImageControl2.Index = 117;
            dxImageControl2.Location = new Point(-1, 0);
            dxImageControl2.Parent = StatsTab;
            elementTab = new DXTab
            {
                Parent = TabControl,
                Border = true,
                TabButton = { Label = { Text = "元素" } },
            };
            DXImageControl dxImageControl3 = new DXImageControl();
            dxImageControl3.LibraryFile = LibraryFile.Interface;
            dxImageControl3.Index = 117;
            dxImageControl3.Location = new Point(-1, 0);
            dxImageControl3.Parent = elementTab;
            HermitTab = new DXTab
            {
                Parent = TabControl,
                Border = true,
                TabButton = { Label = { Text = "加点" } },
            };
            DXImageControl dxImageControl4 = new DXImageControl();
            dxImageControl4.LibraryFile = LibraryFile.Interface;
            dxImageControl4.Index = 133;
            dxImageControl4.Location = new Point(-1, 0);
            dxImageControl4.Parent = HermitTab;
            DXControl namePanel = new DXControl
            {
                Parent = CharacterTab,
                Size = new Size(150, 90),
                Border = false,
                BorderColour = Color.FromArgb(198, 166, 99),
                Location = new Point((CharacterTab.Size.Width - 150) / 2, 11),

            };
            CharacterNameLabel = new DXLabel
            {
                AutoSize = false,
                Size = new Size(150, 20),
                ForeColour = Color.FromArgb(222, 255, 222),
                Outline = false,
                Parent = namePanel,
                Font = new Font(Config.FontName, CEnvir.FontSize(9F), FontStyle.Bold),
                DrawFormat = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter
            };
            GuildNameLabel = new DXLabel
            {
                AutoSize = false,
                Size = new Size(150, 15),
                ForeColour = Color.FromArgb(255, 255, 181),
                Outline = false,
                Parent = namePanel,
                Location = new Point(0, CharacterNameLabel.Size.Height + 4),
                DrawFormat = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter
            };
            GuildRankLabel = new DXLabel
            {
                AutoSize = false,
                Size = new Size(150, 15),
                ForeColour = Color.FromArgb(255, 206, 148),
                Outline = false,
                Parent = namePanel,
                Location = new Point(0, CharacterNameLabel.Size.Height + GuildNameLabel.Size.Height + 7),
                DrawFormat = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter
            };
            TabControl.SelectedTab = CharacterTab;


            MarriageIcon = new DXImageControl
            {
                Parent = namePanel,
                LibraryFile = LibraryFile.GameInter,
                Index = 1298,
                Location = new Point(14, namePanel.Size.Height - 20),
                Visible = false,
            };

            MarriageNameLabel = new DXLabel
            {
                AutoSize = false,
                Size = new Size(150, 15),
                ForeColour = Color.Coral,
                Font = new Font(Config.FontName, CEnvir.FontSize(7F), FontStyle.Regular),
                Parent = namePanel,
                Location = new Point(14, 68),
                DrawFormat = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter,
                Visible = false,
            };


            Grid = new DXItemCell[CartoonGlobals.EquipmentSize];

            DXItemCell cell;
            Grid[(int)EquipmentSlot.Weapon] = cell = new DXItemCell
            {
                Location = new Point(15, 144),
                Parent = CharacterTab,
                FixedBorder = false,
                Border = true,
                Slot = (int)EquipmentSlot.Weapon,
                ItemGrid = Equipment,
                GridType = GridType.Inspect,
                ReadOnly = true,
            };
            cell.BeforeDraw += (o, e) => Draw((DXItemCell)o, 35);

            Grid[(int)EquipmentSlot.Armour] = cell = new DXItemCell
            {
                Location = new Point(15, 185),
                Parent = CharacterTab,
                FixedBorder = false,
                Border = true,
                Slot = (int)EquipmentSlot.Armour,
                ItemGrid = Equipment,
                GridType = GridType.Inspect,
                ReadOnly = true,
            };
            cell.BeforeDraw += (o, e) => Draw((DXItemCell)o, 34);

            
            Grid[(int)EquipmentSlot.Shizhuang] = cell = new DXItemCell
            {
                Location = new Point(15, 226),
                Parent = CharacterTab,
                FixedBorder = false,
                Border = true,
                Slot = (int)EquipmentSlot.Shizhuang,
                ItemGrid = Equipment,
                GridType = GridType.Inspect,
            };
            cell.BeforeDraw += (o, e) => Draw((DXItemCell)o, 34);

            
            Grid[(int)EquipmentSlot.Fabao] = cell = new DXItemCell
            {
                Location = new Point(15, 349),
                Parent = CharacterTab,
                FixedBorder = false,
                Border = true,
                Slot = (int)EquipmentSlot.Fabao,
                ItemGrid = Equipment,
                GridType = GridType.Inspect,
            };
            cell.BeforeDraw += (o, e) => Draw((DXItemCell)o, 118);

            Grid[(int)EquipmentSlot.Shield] = cell = new DXItemCell
            {
                Location = new Point(267, 185),
                Parent = CharacterTab,
                FixedBorder = false,
                Border = true,
                Slot = (int)EquipmentSlot.Shield,
                ItemGrid = Equipment,
                GridType = GridType.Inspect,
                ReadOnly = true,
            };
            cell.BeforeDraw += (o, e) => Draw((DXItemCell)o, 105);

            Fuzhi = new DXButton
            {
                LibraryFile = LibraryFile.GameInter,
                Index = 3620,
                Parent = CharacterTab,
                Hint = "复制名字",
                Location = new Point(ClientArea.Right - 39, ClientArea.Bottom - 388)
            };
            Fuzhi.MouseClick += (o, e) =>
            {
                Clipboard.SetData(DataFormats.Text, CharacterNameLabel.Text);
            };

            Zudui = new DXButton
            {
                LibraryFile = LibraryFile.GameInter,
                Index = 3620,
                Parent = CharacterTab,
                Hint = "添加组队",
                Location = new Point(ClientArea.Right - 63, ClientArea.Bottom - 371)
            };
            Zudui.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.GroupInvite { Name = CharacterNameLabel.Text });
            };

            Hanghui = new DXButton
            {
                LibraryFile = LibraryFile.GameInter,
                Index = 3620,
                Parent = CharacterTab,
                Hint = "添加公会",
                Location = new Point(ClientArea.Right - 39, ClientArea.Bottom - 371)
            };
            Hanghui.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.GuildInviteMember { Name = CharacterNameLabel.Text });
            };

            Grid[(int)EquipmentSlot.Helmet] = cell = new DXItemCell
            {
                Location = new Point(267, 103),
                Parent = CharacterTab,
                FixedBorder = false,
                Border = true,
                Slot = (int)EquipmentSlot.Helmet,
                ItemGrid = Equipment,
                GridType = GridType.Inspect,
                ReadOnly = true,
            };
            cell.BeforeDraw += (o, e) => Draw((DXItemCell)o, 37);

            Grid[(int)EquipmentSlot.Torch] = cell = new DXItemCell
            {
                Location = new Point(267, 144),
                Parent = CharacterTab,
                FixedBorder = false,
                Border = true,
                Slot = (int)EquipmentSlot.Torch,
                ItemGrid = Equipment,
                GridType = GridType.Inspect,
                ReadOnly = true,
            };
            cell.BeforeDraw += (o, e) => Draw((DXItemCell)o, 38);

            Grid[(int)EquipmentSlot.Necklace] = cell = new DXItemCell
            {
                Location = new Point(267, 226),
                Parent = CharacterTab,
                FixedBorder = false,
                Border = true,
                Slot = (int)EquipmentSlot.Necklace,
                ItemGrid = Equipment,
                GridType = GridType.Inspect,
                ReadOnly = true,
            };
            cell.BeforeDraw += (o, e) => Draw((DXItemCell)o, 33);

            Grid[(int)EquipmentSlot.BraceletL] = cell = new DXItemCell
            {
                Location = new Point(15, 267),
                Parent = CharacterTab,
                FixedBorder = false,
                Border = true,
                Slot = (int)EquipmentSlot.BraceletL,
                ItemGrid = Equipment,
                GridType = GridType.Inspect,
                ReadOnly = true,
            };
            cell.BeforeDraw += (o, e) => Draw((DXItemCell)o, 32);

            Grid[(int)EquipmentSlot.BraceletR] = cell = new DXItemCell
            {
                Location = new Point(267, 267),
                Parent = CharacterTab,
                FixedBorder = false,
                Border = true,
                Slot = (int)EquipmentSlot.BraceletR,
                ItemGrid = Equipment,
                GridType = GridType.Inspect,
                ReadOnly = true,
            };
            cell.BeforeDraw += (o, e) => Draw((DXItemCell)o, 32);

            Grid[(int)EquipmentSlot.RingL] = cell = new DXItemCell
            {
                Location = new Point(15, 308),
                Parent = CharacterTab,
                FixedBorder = false,
                Border = true,
                Slot = (int)EquipmentSlot.RingL,
                ItemGrid = Equipment,
                GridType = GridType.Inspect,
                ReadOnly = true,
            };
            cell.BeforeDraw += (o, e) => Draw((DXItemCell)o, 31);

            Grid[(int)EquipmentSlot.RingR] = cell = new DXItemCell
            {
                Location = new Point(267, 308),
                Parent = CharacterTab,
                FixedBorder = false,
                Border = true,
                Slot = (int)EquipmentSlot.RingR,
                ItemGrid = Equipment,
                GridType = GridType.Inspect,
                ReadOnly = true,
            };
            cell.BeforeDraw += (o, e) => Draw((DXItemCell)o, 31);

            Grid[(int)EquipmentSlot.Emblem] = cell = new DXItemCell
            {
                Location = new Point(99, 349),
                Parent = CharacterTab,
                FixedBorder = false,
                Border = true,
                Slot = (int)EquipmentSlot.Emblem,
                ItemGrid = Equipment,
                GridType = GridType.Inspect,
                ReadOnly = true,
            };
            cell.BeforeDraw += (o, e) => Draw((DXItemCell)o, 104);

            Grid[(int)EquipmentSlot.Shoes] = cell = new DXItemCell
            {
                Location = new Point(141, 349),
                Parent = CharacterTab,
                FixedBorder = false,
                Border = true,
                Slot = (int)EquipmentSlot.Shoes,
                ItemGrid = Equipment,
                GridType = GridType.Inspect,
                ReadOnly = true,
            };
            cell.BeforeDraw += (o, e) => Draw((DXItemCell)o, 36);

            Grid[(int)EquipmentSlot.Poison] = cell = new DXItemCell
            {
                Location = new Point(183, 349),
                Parent = CharacterTab,
                FixedBorder = false,
                Border = true,
                Slot = (int)EquipmentSlot.Poison,
                ItemGrid = Equipment,
                GridType = GridType.Inspect,
                ReadOnly = true,
            };
            cell.BeforeDraw += (o, e) => Draw((DXItemCell)o, 40);

            Grid[(int)EquipmentSlot.Amulet] = cell = new DXItemCell
            {
                Location = new Point(225, 349),
                Parent = CharacterTab,
                FixedBorder = false,
                Border = true,
                Slot = (int)EquipmentSlot.Amulet,
                ItemGrid = Equipment,
                GridType = GridType.Inspect,
                ReadOnly = true,
            };
            cell.BeforeDraw += (o, e) => Draw((DXItemCell)o, 39);

            Grid[(int)EquipmentSlot.Flower] = cell = new DXItemCell
            {
                Location = new Point(267, 349),
                Parent = CharacterTab,
                FixedBorder = false,
                Border = true,
                Slot = (int)EquipmentSlot.Flower,
                ItemGrid = Equipment,
                GridType = GridType.Inspect,
                ReadOnly = true,
            };
            cell.BeforeDraw += (o, e) => Draw((DXItemCell)o, 81);

            Grid[(int)EquipmentSlot.HorseArmour] = cell = new DXItemCell
            {
                Location = new Point(57, 349),
                Parent = CharacterTab,
                FixedBorder = false,
                Border = true,
                Slot = (int)EquipmentSlot.HorseArmour,
                ItemGrid = Equipment,
                GridType = GridType.Inspect,
                ReadOnly = true,
            };
            cell.BeforeDraw += (o, e) => Draw((DXItemCell)o, 82);
            
            Grid[(int)EquipmentSlot.SwChenghao] = cell = new DXItemCell
            {
                Location = new Point(229, 9),
                Parent = CharacterTab,
                FixedBorder = false,
                Border = true,
                Slot = (int)EquipmentSlot.SwChenghao,
                ItemGrid = Equipment,
                GridType = GridType.Inspect,
                ReadOnly = true,
                Hint = "",
            };
            cell.BeforeDraw += (o, e) => Draw((DXItemCell)o, 119);



            int y = 10;
            DXLabel label = new DXLabel
            {
                Parent = StatsTab,
                Text = "破坏:"
            };
            label.Location = new Point(StatsTab.Size.Width / 4 - label.Size.Width + 0, y += 10);

            DisplayStats[Stat.MaxDC] = new DXLabel
            {
                Parent = StatsTab,
                Location = new Point(label.Location.X + label.Size.Width - 5, y),
                ForeColour = Color.White,
                Text = "0-0"
            };
            label = new DXLabel
            {
                Parent = StatsTab,
                Text = "转生次数:"
            };
            label.Location = new Point(StatsTab.Size.Width / 4 * 2 - label.Size.Width + 43, y);

            DisplayStats[Stat.Rebirth] = new DXLabel
            {
                Parent = StatsTab,
                Location = new Point(label.Location.X + label.Size.Width - 5, y),
                ForeColour = Color.White,
                Text = "0"
            };
            label = new DXLabel
            {
                Parent = StatsTab,
                Text = "PK值:"
            };
            label.Location = new Point(StatsTab.Size.Width / 4 * 3 - label.Size.Width + 27, y);

            DisplayStats[Stat.PKPoint] = new DXLabel
            {
                Parent = StatsTab,
                Location = new Point(label.Location.X + label.Size.Width - 5, y),
                ForeColour = Color.White,
                Text = "0"
            };

            label = new DXLabel
            {
                Parent = StatsTab,
                Text = "自然:"
            };
            label.Location = new Point(StatsTab.Size.Width / 4 - label.Size.Width + 0, y += 20);

            DisplayStats[Stat.MaxMC] = new DXLabel
            {
                Parent = StatsTab,
                Location = new Point(label.Location.X + label.Size.Width - 5, y),
                ForeColour = Color.White,
                Text = "0-0"
            };

            label = new DXLabel
            {
                Parent = StatsTab,
                Text = "防御:"
            };
            label.Location = new Point(StatsTab.Size.Width / 4 * 2 - label.Size.Width + 20, y);

            DisplayStats[Stat.MaxAC] = new DXLabel
            {
                Parent = StatsTab,
                Location = new Point(label.Location.X + label.Size.Width - 5, y),
                ForeColour = Color.White,
                Text = "0-0"
            };

            label = new DXLabel
            {
                Parent = StatsTab,
                Text = "魔御:"
            };
            label.Location = new Point(StatsTab.Size.Width / 4 * 3 - label.Size.Width + 25, y);

            DisplayStats[Stat.MaxMR] = new DXLabel
            {
                Parent = StatsTab,
                Location = new Point(label.Location.X + label.Size.Width - 5, y),
                ForeColour = Color.White,
                Text = "0-0"
            };


            label = new DXLabel
            {
                Parent = StatsTab,
                Text = "灵魂:"
            };
            label.Location = new Point(StatsTab.Size.Width / 4 - label.Size.Width + 0, y += 20);

            DisplayStats[Stat.MaxSC] = new DXLabel
            {
                Parent = StatsTab,
                Location = new Point(label.Location.X + label.Size.Width - 5, y),
                ForeColour = Color.White,
                Text = "0-0"
            };

            label = new DXLabel
            {
                Parent = StatsTab,
                Text = "准确:"
            };
            label.Location = new Point(StatsTab.Size.Width / 4 * 2 - label.Size.Width + 20, y);

            DisplayStats[Stat.Accuracy] = new DXLabel
            {
                Parent = StatsTab,
                Location = new Point(label.Location.X + label.Size.Width - 5, y),
                ForeColour = Color.White,
                Text = "0"
            };


            label = new DXLabel
            {
                Parent = StatsTab,
                Text = "敏捷:"
            };
            label.Location = new Point(StatsTab.Size.Width / 4 * 3 - label.Size.Width + 25, y);

            DisplayStats[Stat.Agility] = new DXLabel
            {
                Parent = StatsTab,
                Location = new Point(label.Location.X + label.Size.Width - 5, y),
                ForeColour = Color.White,
                Text = "0"
            };

            label = new DXLabel
            {
                Parent = StatsTab,
                Text = "穿戴负重:"
            };
            label.Location = new Point(StatsTab.Size.Width / 4 - label.Size.Width + 25, y += 20);

            WearWeightLabel = new DXLabel
            {
                Parent = StatsTab,
                Location = new Point(label.Location.X + label.Size.Width - 5, y),
                ForeColour = Color.White,
                Text = "0"
            };

            label = new DXLabel
            {
                Parent = StatsTab,
                Text = "腕力:"
            };
            label.Location = new Point(StatsTab.Size.Width / 4 * 3 - label.Size.Width + 25, y);

            HandWeightLabel = new DXLabel
            {
                Parent = StatsTab,
                Location = new Point(label.Location.X + label.Size.Width - 5, y),
                ForeColour = Color.White,
                Text = "0"
            };



            label = new DXLabel
            {
                Parent = StatsTab,
                Text = "攻击速度:"
            };
            label.Location = new Point(StatsTab.Size.Width / 4 - label.Size.Width + 25, y += 20);

            DisplayStats[Stat.AttackSpeed] = new DXLabel
            {
                Parent = StatsTab,
                Location = new Point(label.Location.X + label.Size.Width - 5, y),
                ForeColour = Color.White,
                Text = "0"
            };


            label = new DXLabel
            {
                Parent = StatsTab,
                Text = "幸运:"
            };
            label.Location = new Point(StatsTab.Size.Width / 4 * 2 - label.Size.Width + 25, y);

            DisplayStats[Stat.Luck] = new DXLabel
            {
                Parent = StatsTab,
                Location = new Point(label.Location.X + label.Size.Width - 5, y),
                ForeColour = Color.White,
                Text = "0"
            };

            label = new DXLabel
            {
                Parent = StatsTab,
                Text = "舒适:"
            };
            label.Location = new Point(StatsTab.Size.Width / 4 * 3 - label.Size.Width + 25, y);

            DisplayStats[Stat.Comfort] = new DXLabel
            {
                Parent = StatsTab,
                Location = new Point(label.Location.X + label.Size.Width - 5, y),
                ForeColour = Color.White,
                Text = "0"
            };



            label = new DXLabel
            {
                Parent = StatsTab,
                Text = "吸血:"
            };
            label.Location = new Point(StatsTab.Size.Width / 4 - label.Size.Width + 25, y += 20);

            DisplayStats[Stat.LifeSteal] = new DXLabel
            {
                Parent = StatsTab,
                Location = new Point(label.Location.X + label.Size.Width - 5, y),
                ForeColour = Color.White,
                Text = "0"
            };

            label = new DXLabel
            {
                Parent = StatsTab,
                Text = "金币加成:"
            };
            label.Location = new Point(StatsTab.Size.Width / 4 * 3 - label.Size.Width + 25, y);

            DisplayStats[Stat.GoldRate] = new DXLabel
            {
                Parent = StatsTab,
                Location = new Point(label.Location.X + label.Size.Width - 5, y),
                ForeColour = Color.White,
                Text = "0"
            };

            label = new DXLabel
            {
                Parent = StatsTab,
                Text = "暴击几率:"
            };
            label.Location = new Point(StatsTab.Size.Width / 4 - label.Size.Width + 25, y += 20);

            DisplayStats[Stat.CriticalChance] = new DXLabel
            {
                Parent = StatsTab,
                Location = new Point(label.Location.X + label.Size.Width - 5, y),
                ForeColour = Color.White,
                Text = "0"
            };

            label = new DXLabel
            {
                Parent = StatsTab,
                Text = "爆率加成:"
            };
            label.Location = new Point(StatsTab.Size.Width / 4 * 3 - label.Size.Width + 25, y);

            DisplayStats[Stat.DropRate] = new DXLabel
            {
                Parent = StatsTab,
                Location = new Point(label.Location.X + label.Size.Width - 5, y),
                ForeColour = Color.White,
                Text = "0"
            };

            label = new DXLabel
            {
                Parent = StatsTab,
                Text = "暴击伤害[怪]:"
            };
            label.Location = new Point(StatsTab.Size.Width / 4 - label.Size.Width + 25, y += 20);

            DisplayStats[Stat.CriticalDamage] = new DXLabel
            {
                Parent = StatsTab,
                Location = new Point(label.Location.X + label.Size.Width - 5, y),
                ForeColour = Color.White,
                Text = "0"
            };


            label = new DXLabel
            {
                Parent = StatsTab,
                Text = "经验加成:"
            };
            label.Location = new Point(StatsTab.Size.Width / 4 * 3 - label.Size.Width + 25, y);

            DisplayStats[Stat.ExperienceRate] = new DXLabel
            {
                Parent = StatsTab,
                Location = new Point(label.Location.X + label.Size.Width - 5, y),
                ForeColour = Color.White,
                Text = "0"
            };

            label = new DXLabel
            {
                Parent = StatsTab,
                Text = "拾取范围:"
            };
            label.Location = new Point(StatsTab.Size.Width / 4 - label.Size.Width + 25, y += 20);

            DisplayStats[Stat.PickUpRadius] = new DXLabel
            {
                Parent = StatsTab,
                Location = new Point(label.Location.X + label.Size.Width - 5, y),
                ForeColour = Color.White,
                Text = "0"
            };


            label = new DXLabel
            {
                Parent = StatsTab,
                Text = "审判几率:"
            };
            label.Location = new Point(StatsTab.Size.Width / 4 * 3 - label.Size.Width + 25, y);

            DisplayStats[Stat.JudgementOfHeaven] = new DXLabel
            {
                Parent = StatsTab,
                Location = new Point(label.Location.X + label.Size.Width - 5, y),
                ForeColour = Color.White,
                Text = "0"
            };

            label = new DXLabel
            {
                Parent = StatsTab,
                Text = "麻痹几率:"
            };
            label.Location = new Point(StatsTab.Size.Width / 4 - label.Size.Width + 25, y += 20);

            DisplayStats[Stat.ParalysisChance] = new DXLabel
            {
                Parent = StatsTab,
                Location = new Point(label.Location.X + label.Size.Width - 5, y),
                ForeColour = Color.White,
                Text = "0"
            };


            label = new DXLabel
            {
                Parent = StatsTab,
                Text = "降低移动速度:"
            };
            label.Location = new Point(StatsTab.Size.Width / 4 * 3 - label.Size.Width + 25, y);

            DisplayStats[Stat.SlowChance] = new DXLabel
            {
                Parent = StatsTab,
                Location = new Point(label.Location.X + label.Size.Width - 5, y),
                ForeColour = Color.White,
                Text = "0"
            };

            label = new DXLabel
            {
                Parent = StatsTab,
                Text = "沉默几率:"
            };
            label.Location = new Point(StatsTab.Size.Width / 4 - label.Size.Width + 25, y += 20);

            DisplayStats[Stat.SilenceChance] = new DXLabel
            {
                Parent = StatsTab,
                Location = new Point(label.Location.X + label.Size.Width - 5, y),
                ForeColour = Color.White,
                Text = "0"
            };


            label = new DXLabel
            {
                Parent = StatsTab,
                Text = "格挡几率:"
            };
            label.Location = new Point(StatsTab.Size.Width / 4 * 3 - label.Size.Width + 25, y);

            DisplayStats[Stat.BlockChance] = new DXLabel
            {
                Parent = StatsTab,
                Location = new Point(label.Location.X + label.Size.Width - 5, y),
                ForeColour = Color.White,
                Text = "0"
            };

            label = new DXLabel
            {
                Parent = StatsTab,
                Text = "躲避几率:"
            };
            label.Location = new Point(StatsTab.Size.Width / 4 - label.Size.Width + 25, y += 20);

            DisplayStats[Stat.EvasionChance] = new DXLabel
            {
                Parent = StatsTab,
                Location = new Point(label.Location.X + label.Size.Width - 5, y),
                ForeColour = Color.White,
                Text = "0"
            };


            label = new DXLabel
            {
                Parent = StatsTab,
                Text = "毒系抵抗:"
            };
            label.Location = new Point(StatsTab.Size.Width / 4 * 3 - label.Size.Width + 25, y);

            DisplayStats[Stat.PoisonResistance] = new DXLabel
            {
                Parent = StatsTab,
                Location = new Point(label.Location.X + label.Size.Width - 5, y),
                ForeColour = Color.White,
                Text = "0"
            };

            label = new DXLabel
            {
                Parent = StatsTab,
                Text = "绿毒几率[怪]:"
            };
            label.Location = new Point(StatsTab.Size.Width / 4 - label.Size.Width + 25, y += 20);

            DisplayStats[Stat.PoisonChance] = new DXLabel
            {
                Parent = StatsTab,
                Location = new Point(label.Location.X + label.Size.Width - 5, y),
                ForeColour = Color.White,
                Text = "0"
            };

            label = new DXLabel
            {
                Parent = StatsTab,
                Text = "声望点:"
            };
            label.Location = new Point(StatsTab.Size.Width / 4 * 3 - label.Size.Width + 25, y);

            Shengwang = new DXLabel
            {
                Parent = StatsTab,
                Location = new Point(label.Location.X + label.Size.Width - 5, y),
                ForeColour = Color.White,
                Text = "0"
            };

            #region Attack


            label = new DXLabel
            {
                Parent = elementTab,
                Text = "攻元素:"
            };
            label.Location = new Point(85 - label.Size.Width, 20);

            DXImageControl icon = new DXImageControl
            {
                Parent = elementTab,
                LibraryFile = LibraryFile.ProgUse,
                Index = 600,
                ForeColour = Color.FromArgb(60, 60, 60),
                Hint = "火",
            };
            icon.Location = new Point(label.Location.X + label.Size.Width, label.Location.Y + (label.Size.Height - icon.Size.Height) / 2);

            AttackStats[Stat.FireAttack] = new DXLabel
            {
                Parent = elementTab,
                Location = new Point(icon.Location.X + icon.Size.Width, label.Location.Y),
                ForeColour = Color.FromArgb(60, 60, 60),
                Text = "0",
                Tag = icon,
            };

            icon = new DXImageControl
            {
                Parent = elementTab,
                LibraryFile = LibraryFile.ProgUse,
                Index = 601,
                ForeColour = Color.FromArgb(60, 60, 60),
                Hint = "冰",
            };
            icon.Location = new Point(label.Location.X + label.Size.Width + 50, label.Location.Y + (label.Size.Height - icon.Size.Height) / 2);

            AttackStats[Stat.IceAttack] = new DXLabel
            {
                Parent = elementTab,
                Location = new Point(icon.Location.X + icon.Size.Width, label.Location.Y),
                ForeColour = Color.FromArgb(60, 60, 60),
                Text = "0",
                Tag = icon,
            };

            icon = new DXImageControl
            {
                Parent = elementTab,
                LibraryFile = LibraryFile.ProgUse,
                Index = 602,
                ForeColour = Color.FromArgb(60, 60, 60),
                Hint = "雷",
            };
            icon.Location = new Point(label.Location.X + label.Size.Width + 100, label.Location.Y + (label.Size.Height - icon.Size.Height) / 2);

            AttackStats[Stat.LightningAttack] = new DXLabel
            {
                Parent = elementTab,
                Location = new Point(icon.Location.X + icon.Size.Width, label.Location.Y),
                ForeColour = Color.FromArgb(60, 60, 60),
                Text = "0",
                Tag = icon,
            };

            icon = new DXImageControl
            {
                Parent = elementTab,
                LibraryFile = LibraryFile.ProgUse,
                Index = 603,
                ForeColour = Color.FromArgb(60, 60, 60),
                Hint = "风",
            };
            icon.Location = new Point(label.Location.X + label.Size.Width + 150, label.Location.Y + (label.Size.Height - icon.Size.Height) / 2);

            AttackStats[Stat.WindAttack] = new DXLabel
            {
                Parent = elementTab,
                Location = new Point(icon.Location.X + icon.Size.Width, label.Location.Y),
                ForeColour = Color.FromArgb(60, 60, 60),
                Text = "0",
                Tag = icon,
            };

            icon = new DXImageControl
            {
                Parent = elementTab,
                LibraryFile = LibraryFile.ProgUse,
                Index = 604,
                ForeColour = Color.FromArgb(60, 60, 60),
                Hint = "神圣",
            };
            icon.Location = new Point(label.Location.X + label.Size.Width, label.Location.Y + (label.Size.Height - icon.Size.Height) / 2 + 25);

            AttackStats[Stat.HolyAttack] = new DXLabel
            {
                Parent = elementTab,
                Location = new Point(icon.Location.X + icon.Size.Width, label.Location.Y + 25),
                ForeColour = Color.FromArgb(60, 60, 60),
                Text = "0",
                Tag = icon,
            };

            icon = new DXImageControl
            {
                Parent = elementTab,
                LibraryFile = LibraryFile.ProgUse,
                Index = 605,
                ForeColour = Color.FromArgb(60, 60, 60),
                Hint = "暗黑",
            };
            icon.Location = new Point(label.Location.X + label.Size.Width + 50, label.Location.Y + (label.Size.Height - icon.Size.Height) / 2 + 25);

            AttackStats[Stat.DarkAttack] = new DXLabel
            {
                Parent = elementTab,
                Location = new Point(icon.Location.X + icon.Size.Width, label.Location.Y + 25),
                ForeColour = Color.FromArgb(60, 60, 60),
                Text = "0",
                Tag = icon,
            };

            icon = new DXImageControl
            {
                Parent = elementTab,
                LibraryFile = LibraryFile.ProgUse,
                Index = 606,
                ForeColour = Color.FromArgb(60, 60, 60),
                Hint = "幻影",
            };
            icon.Location = new Point(label.Location.X + label.Size.Width + 100, label.Location.Y + (label.Size.Height - icon.Size.Height) / 2 + 25);

            AttackStats[Stat.PhantomAttack] = new DXLabel
            {
                Parent = elementTab,
                Location = new Point(icon.Location.X + icon.Size.Width, label.Location.Y + 25),
                ForeColour = Color.FromArgb(60, 60, 60),
                Text = "0",
                Tag = icon,
            };

            #endregion

            #region Resistance


            label = new DXLabel
            {
                Parent = elementTab,
                Text = "强元素:"
            };
            label.Location = new Point(85 - label.Size.Width, 80);


            icon = new DXImageControl
            {
                Parent = elementTab,
                LibraryFile = LibraryFile.ProgUse,
                Index = 600,
                ForeColour = Color.FromArgb(60, 60, 60),
                Hint = "火",
            };
            icon.Location = new Point(label.Location.X + label.Size.Width, label.Location.Y + (label.Size.Height - icon.Size.Height) / 2);

            AdvantageStats[Stat.FireResistance] = new DXLabel
            {
                Parent = elementTab,
                Location = new Point(icon.Location.X + icon.Size.Width, label.Location.Y),
                ForeColour = Color.FromArgb(60, 60, 60),
                Text = "0",
                Tag = icon,
            };

            icon = new DXImageControl
            {
                Parent = elementTab,
                LibraryFile = LibraryFile.ProgUse,
                Index = 601,
                ForeColour = Color.FromArgb(60, 60, 60),
                Hint = "冰",
            };
            icon.Location = new Point(label.Location.X + label.Size.Width + 50, label.Location.Y + (label.Size.Height - icon.Size.Height) / 2);

            AdvantageStats[Stat.IceResistance] = new DXLabel
            {
                Parent = elementTab,
                Location = new Point(icon.Location.X + icon.Size.Width, label.Location.Y),
                ForeColour = Color.FromArgb(60, 60, 60),
                Text = "0",
                Tag = icon,
            };

            icon = new DXImageControl
            {
                Parent = elementTab,
                LibraryFile = LibraryFile.ProgUse,
                Index = 602,
                ForeColour = Color.FromArgb(60, 60, 60),
                Hint = "雷",
            };
            icon.Location = new Point(label.Location.X + label.Size.Width + 100, label.Location.Y + (label.Size.Height - icon.Size.Height) / 2);

            AdvantageStats[Stat.LightningResistance] = new DXLabel
            {
                Parent = elementTab,
                Location = new Point(icon.Location.X + icon.Size.Width, label.Location.Y),
                ForeColour = Color.FromArgb(60, 60, 60),
                Text = "0",
                Tag = icon,
            };

            icon = new DXImageControl
            {
                Parent = elementTab,
                LibraryFile = LibraryFile.ProgUse,
                Index = 603,
                ForeColour = Color.FromArgb(60, 60, 60),
                Hint = "风",
            };
            icon.Location = new Point(label.Location.X + label.Size.Width + 150, label.Location.Y + (label.Size.Height - icon.Size.Height) / 2);

            AdvantageStats[Stat.WindResistance] = new DXLabel
            {
                Parent = elementTab,
                Location = new Point(icon.Location.X + icon.Size.Width, label.Location.Y),
                ForeColour = Color.FromArgb(60, 60, 60),
                Text = "0",
                Tag = icon,
            };

            icon = new DXImageControl
            {
                Parent = elementTab,
                LibraryFile = LibraryFile.ProgUse,
                Index = 604,
                ForeColour = Color.FromArgb(60, 60, 60),
                Hint = "神圣",
            };
            icon.Location = new Point(label.Location.X + label.Size.Width, label.Location.Y + (label.Size.Height - icon.Size.Height) / 2 + 25);

            AdvantageStats[Stat.HolyResistance] = new DXLabel
            {
                Parent = elementTab,
                Location = new Point(icon.Location.X + icon.Size.Width, label.Location.Y + 25),
                ForeColour = Color.FromArgb(60, 60, 60),
                Text = "0",
                Tag = icon,
            };

            icon = new DXImageControl
            {
                Parent = elementTab,
                LibraryFile = LibraryFile.ProgUse,
                Index = 605,
                ForeColour = Color.FromArgb(60, 60, 60),
                Hint = "暗黑",
            };
            icon.Location = new Point(label.Location.X + label.Size.Width + 50, label.Location.Y + (label.Size.Height - icon.Size.Height) / 2 + 25);

            AdvantageStats[Stat.DarkResistance] = new DXLabel
            {
                Parent = elementTab,
                Location = new Point(icon.Location.X + icon.Size.Width, label.Location.Y + 25),
                ForeColour = Color.FromArgb(60, 60, 60),
                Text = "0",
                Tag = icon,
            };

            icon = new DXImageControl
            {
                Parent = elementTab,
                LibraryFile = LibraryFile.ProgUse,
                Index = 606,
                ForeColour = Color.FromArgb(60, 60, 60),
                Hint = "幻影",
            };
            icon.Location = new Point(label.Location.X + label.Size.Width + 100, label.Location.Y + (label.Size.Height - icon.Size.Height) / 2 + 25);

            AdvantageStats[Stat.PhantomResistance] = new DXLabel
            {
                Parent = elementTab,
                Location = new Point(icon.Location.X + icon.Size.Width, label.Location.Y + 25),
                ForeColour = Color.FromArgb(60, 60, 60),
                Text = "0",
                Tag = icon,
            };

            icon = new DXImageControl
            {
                Parent = elementTab,
                LibraryFile = LibraryFile.GameInter,
                Index = 1517,
                ForeColour = Color.FromArgb(60, 60, 60),
                Hint = "体质",
            };
            icon.Location = new Point(label.Location.X + label.Size.Width + 150, label.Location.Y + (label.Size.Height - icon.Size.Height) / 2 + 25);

            AdvantageStats[Stat.PhysicalResistance] = new DXLabel
            {
                Parent = elementTab,
                Location = new Point(icon.Location.X + icon.Size.Width, label.Location.Y + 25),
                ForeColour = Color.FromArgb(60, 60, 60),
                Text = "0",
                Tag = icon,
            };

            #endregion

            #region Resistance


            label = new DXLabel
            {
                Parent = elementTab,
                Text = "弱元素:"
            };
            label.Location = new Point(85 - label.Size.Width, 140);

            icon = new DXImageControl
            {
                Parent = elementTab,
                LibraryFile = LibraryFile.ProgUse,
                Index = 600,
                ForeColour = Color.FromArgb(60, 60, 60),
                Hint = "火",
            };
            icon.Location = new Point(label.Location.X + label.Size.Width, label.Location.Y + (label.Size.Height - icon.Size.Height) / 2);

            DisadvantageStats[Stat.FireResistance] = new DXLabel
            {
                Parent = elementTab,
                Location = new Point(icon.Location.X + icon.Size.Width, label.Location.Y),
                ForeColour = Color.FromArgb(60, 60, 60),
                Text = "0",
                Tag = icon,
            };

            icon = new DXImageControl
            {
                Parent = elementTab,
                LibraryFile = LibraryFile.ProgUse,
                Index = 601,
                ForeColour = Color.FromArgb(60, 60, 60),
                Hint = "冰",
            };
            icon.Location = new Point(label.Location.X + label.Size.Width + 50, label.Location.Y + (label.Size.Height - icon.Size.Height) / 2);

            DisadvantageStats[Stat.IceResistance] = new DXLabel
            {
                Parent = elementTab,
                Location = new Point(icon.Location.X + icon.Size.Width, label.Location.Y),
                ForeColour = Color.FromArgb(60, 60, 60),
                Text = "0",
                Tag = icon,
            };

            icon = new DXImageControl
            {
                Parent = elementTab,
                LibraryFile = LibraryFile.ProgUse,
                Index = 602,
                ForeColour = Color.FromArgb(60, 60, 60),
                Hint = "雷",
            };
            icon.Location = new Point(label.Location.X + label.Size.Width + 100, label.Location.Y + (label.Size.Height - icon.Size.Height) / 2);

            DisadvantageStats[Stat.LightningResistance] = new DXLabel
            {
                Parent = elementTab,
                Location = new Point(icon.Location.X + icon.Size.Width, label.Location.Y),
                ForeColour = Color.FromArgb(60, 60, 60),
                Text = "0",
                Tag = icon,
            };

            icon = new DXImageControl
            {
                Parent = elementTab,
                LibraryFile = LibraryFile.ProgUse,
                Index = 603,
                ForeColour = Color.FromArgb(60, 60, 60),
                Hint = "风",
            };
            icon.Location = new Point(label.Location.X + label.Size.Width + 150, label.Location.Y + (label.Size.Height - icon.Size.Height) / 2);

            DisadvantageStats[Stat.WindResistance] = new DXLabel
            {
                Parent = elementTab,
                Location = new Point(icon.Location.X + icon.Size.Width, label.Location.Y),
                ForeColour = Color.FromArgb(60, 60, 60),
                Text = "0",
                Tag = icon,
            };

            icon = new DXImageControl
            {
                Parent = elementTab,
                LibraryFile = LibraryFile.ProgUse,
                Index = 604,
                ForeColour = Color.FromArgb(60, 60, 60),
                Hint = "神圣",
            };
            icon.Location = new Point(label.Location.X + label.Size.Width, label.Location.Y + (label.Size.Height - icon.Size.Height) / 2 + 25);

            DisadvantageStats[Stat.HolyResistance] = new DXLabel
            {
                Parent = elementTab,
                Location = new Point(icon.Location.X + icon.Size.Width, label.Location.Y + 25),
                ForeColour = Color.FromArgb(60, 60, 60),
                Text = "0",
                Tag = icon,
            };

            icon = new DXImageControl
            {
                Parent = elementTab,
                LibraryFile = LibraryFile.ProgUse,
                Index = 605,
                ForeColour = Color.FromArgb(60, 60, 60),
                Hint = "暗黑",
            };
            icon.Location = new Point(label.Location.X + label.Size.Width + 50, label.Location.Y + (label.Size.Height - icon.Size.Height) / 2 + 25);

            DisadvantageStats[Stat.DarkResistance] = new DXLabel
            {
                Parent = elementTab,
                Location = new Point(icon.Location.X + icon.Size.Width, label.Location.Y + 25),
                ForeColour = Color.FromArgb(60, 60, 60),
                Text = "0",
                Tag = icon,
            };

            icon = new DXImageControl
            {
                Parent = elementTab,
                LibraryFile = LibraryFile.ProgUse,
                Index = 606,
                ForeColour = Color.FromArgb(60, 60, 60),
                Hint = "幻影",
            };
            icon.Location = new Point(label.Location.X + label.Size.Width + 100, label.Location.Y + (label.Size.Height - icon.Size.Height) / 2 + 25);

            DisadvantageStats[Stat.PhantomResistance] = new DXLabel
            {
                Parent = elementTab,
                Location = new Point(icon.Location.X + icon.Size.Width, label.Location.Y + 25),
                ForeColour = Color.FromArgb(60, 60, 60),
                Text = "0",
                Tag = icon,
            };

            icon = new DXImageControl
            {
                Parent = elementTab,
                LibraryFile = LibraryFile.GameInter,
                Index = 1517,
                ForeColour = Color.FromArgb(60, 60, 60),
                Hint = "体质",
            };
            icon.Location = new Point(label.Location.X + label.Size.Width + 150, label.Location.Y + (label.Size.Height - icon.Size.Height) / 2 + 25);

            DisadvantageStats[Stat.PhysicalResistance] = new DXLabel
            {
                Parent = elementTab,
                Location = new Point(icon.Location.X + icon.Size.Width, label.Location.Y + 25),
                ForeColour = Color.FromArgb(60, 60, 60),
                Text = "0",
                Tag = icon,
            };
            #endregion


            
            HermitDisplayStats[Stat.MaxDC] = new DXLabel
            {
                Parent = HermitTab,
                Location = new Point(45, 72),
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Regular),
                ForeColour = Color.White,
                Text = "0-0"
            };
            
            HermitDisplayStats[Stat.MaxMC] = new DXLabel
            {
                Parent = HermitTab,
                Location = new Point(192, 72),
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Regular),
                ForeColour = Color.White,
                Text = "0-0"
            };
            
            HermitDisplayStats[Stat.MaxSC] = new DXLabel
            {
                Parent = HermitTab,
                Location = new Point(45, 109),
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Regular),
                ForeColour = Color.White,
                Text = "0-0"
            };
            
            HermitDisplayStats[Stat.MaxAC] = new DXLabel
            {
                Parent = HermitTab,
                Location = new Point(192, 109),
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Regular),
                ForeColour = Color.White,
                Text = "0-0"
            };
            
            HermitDisplayStats[Stat.MaxMR] = new DXLabel
            {
                Parent = HermitTab,
                Location = new Point(45, 146),
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Regular),
                ForeColour = Color.White,
                Text = "0-0"
            };
            
            HermitDisplayStats[Stat.Health] = new DXLabel
            {
                Parent = HermitTab,
                Location = new Point(192, 146),
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Regular),
                ForeColour = Color.White,
                Text = "0"
            };
            
            HermitDisplayStats[Stat.Mana] = new DXLabel
            {
                Parent = HermitTab,
                Location = new Point(45, 183),
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Regular),
                ForeColour = Color.White,
                Text = "0"
            };


            #region Attack
            
            HermitAttackStats[Stat.FireAttack] = new DXLabel
            {
                Parent = HermitTab,
                Location = new Point(45, 220),
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Regular),
                ForeColour = Color.White,
                Text = "0",
            };
            
            HermitAttackStats[Stat.IceAttack] = new DXLabel
            {
                Parent = HermitTab,
                Location = new Point(192, 220),
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Regular),
                ForeColour = Color.White,
                Text = "0",
            };
            
            HermitAttackStats[Stat.LightningAttack] = new DXLabel
            {
                Parent = HermitTab,
                Location = new Point(45, 257),
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Regular),
                ForeColour = Color.White,
                Text = "0",
            };
            
            HermitAttackStats[Stat.WindAttack] = new DXLabel
            {
                Parent = HermitTab,
                Location = new Point(192, 257),
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Regular),
                ForeColour = Color.White,
                Text = "0",
            };
            
            HermitAttackStats[Stat.HolyAttack] = new DXLabel
            {
                Parent = HermitTab,
                Location = new Point(45, 294),
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Regular),
                ForeColour = Color.White,
                Text = "0",
            };
            
            HermitAttackStats[Stat.DarkAttack] = new DXLabel
            {
                Parent = HermitTab,
                Location = new Point(192, 294),
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Regular),
                ForeColour = Color.White,
                Text = "0",
            };
            
            HermitAttackStats[Stat.PhantomAttack] = new DXLabel
            {
                Parent = HermitTab,
                Location = new Point(45, 331),
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Regular),
                ForeColour = Color.White,
                Text = "0",
            };

            #endregion

            label = new DXLabel
            {
                Parent = HermitTab,
                Text = "剩余点数:"
            };
            label.Location = new Point(HermitTab.Size.Width / 4 * 2 - label.Size.Width + 25, 30);

            RemainingLabel = new DXLabel
            {
                Parent = HermitTab,
                Location = new Point(label.Location.X + label.Size.Width - 5, label.Location.Y),
                ForeColour = Color.White,
                Text = "0"
            };

        }

        #region Methods

        public void Draw(DXItemCell cell, int index)
        {
            if (InterfaceLibrary == null) return;

            Size s = InterfaceLibrary.GetSize(index);
            int x = (cell.Size.Width - s.Width) / 2 + cell.DisplayArea.X;
            int y = (cell.Size.Height - s.Height) / 2 + cell.DisplayArea.Y;

            InterfaceLibrary.Draw(index, x, y, Color.White, false, 0.2F, ImageType.Image);
        }
        private void CharacterTab_BeforeChildrenDraw(object sender, EventArgs e)
        {

            MirLibrary library;


            if (!CEnvir.LibraryList.TryGetValue(LibraryFile.ProgUse, out library)) return;

            int x = 147;
            int y = 332;

            if (Grid[(int)EquipmentSlot.Armour].Item != null)
            {
                int index = Grid[(int)EquipmentSlot.Armour].Item.Info.Image;

                MirLibrary effectLibrary;
                if (!HideShizhuang || (Grid[(int)EquipmentSlot.Shizhuang].Item == null && HideShizhuang))
                {
                    if (CEnvir.LibraryList.TryGetValue(LibraryFile.EquipEffect_UI, out effectLibrary))
                    {
                        MirImage image = null;
                        switch (index)
                        {
                            
                            case 962:
                                image = effectLibrary.CreateImage(1700 + (GameScene.Game.MapControl.Animation % 10), ImageType.Image);
                                break;
                            case 972:
                                image = effectLibrary.CreateImage(1720 + (GameScene.Game.MapControl.Animation % 10), ImageType.Image);
                                break;

                            
                            case 963:
                                image = effectLibrary.CreateImage(400 + (GameScene.Game.MapControl.Animation % 15), ImageType.Image);
                                break;
                            case 973:
                                image = effectLibrary.CreateImage(420 + (GameScene.Game.MapControl.Animation % 15), ImageType.Image);
                                break;

                            
                            case 964:
                                image = effectLibrary.CreateImage(300 + (GameScene.Game.MapControl.Animation % 15), ImageType.Image);
                                break;
                            case 974:
                                image = effectLibrary.CreateImage(320 + (GameScene.Game.MapControl.Animation % 15), ImageType.Image);
                                break;

                            
                            case 965:
                                image = effectLibrary.CreateImage(200 + (GameScene.Game.MapControl.Animation % 15), ImageType.Image);
                                break;
                            case 975:
                                image = effectLibrary.CreateImage(220 + (GameScene.Game.MapControl.Animation % 15), ImageType.Image);
                                break;
                            
                            case 2007:
                                image = effectLibrary.CreateImage(500 + (GameScene.Game.MapControl.Animation % 13), ImageType.Image);
                                break;
                            case 2017:
                                image = effectLibrary.CreateImage(520 + (GameScene.Game.MapControl.Animation % 13), ImageType.Image);
                                break;
                            
                            case 3322:
                            case 6001:
                                image = effectLibrary.CreateImage(100 + (GameScene.Game.MapControl.Animation % 10), ImageType.Image);
                                break;
                            case 3332:
                            case 6011:
                                image = effectLibrary.CreateImage(120 + (GameScene.Game.MapControl.Animation % 10), ImageType.Image);
                                break;
                            
                            case 3328:
                            case 3338:
                            case 6000:
                            case 6010:
                                image = effectLibrary.CreateImage(2300 + (GameScene.Game.MapControl.Animation % 15), ImageType.Image);
                                break;
                            
                            case 3325:
                            case 3362:
                                image = effectLibrary.CreateImage(2400 + (GameScene.Game.MapControl.Animation % 14), ImageType.Image);
                                break;
                            case 3335:
                            case 3372:
                                image = effectLibrary.CreateImage(2500 + (GameScene.Game.MapControl.Animation % 14), ImageType.Image);
                                break;
                            
                            case 3381:
                            case 3382:
                                image = effectLibrary.CreateImage(2600 + (GameScene.Game.MapControl.Animation % 15), ImageType.Image);
                                break;
                            case 3391:
                            case 3392:
                                image = effectLibrary.CreateImage(2700 + (GameScene.Game.MapControl.Animation % 15), ImageType.Image);
                                break;


                            case 942:
                                image = effectLibrary.CreateImage(700, ImageType.Image);
                                break;
                            case 961:
                                image = effectLibrary.CreateImage(1600, ImageType.Image);
                                break;
                            case 982:
                                image = effectLibrary.CreateImage(800, ImageType.Image);
                                break;
                            case 983:
                                image = effectLibrary.CreateImage(1200, ImageType.Image);
                                break;
                            case 984:
                                image = effectLibrary.CreateImage(1100, ImageType.Image);
                                break;
                            case 1022:
                                image = effectLibrary.CreateImage(900, ImageType.Image);
                                break;
                            case 1023:
                                image = effectLibrary.CreateImage(1300, ImageType.Image);
                                break;
                            case 1002:
                                image = effectLibrary.CreateImage(1000, ImageType.Image);
                                break;
                            case 1003:
                                image = effectLibrary.CreateImage(1400, ImageType.Image);
                                break;

                            case 952:
                                image = effectLibrary.CreateImage(720, ImageType.Image);
                                break;
                            case 971:
                                image = effectLibrary.CreateImage(1620, ImageType.Image);
                                break;
                            case 992:
                                image = effectLibrary.CreateImage(820, ImageType.Image);
                                break;
                            case 993:
                                image = effectLibrary.CreateImage(1220, ImageType.Image);
                                break;
                            case 994:
                                image = effectLibrary.CreateImage(1120, ImageType.Image);
                                break;
                            case 1032:
                                image = effectLibrary.CreateImage(920, ImageType.Image);
                                break;
                            case 1033:
                                image = effectLibrary.CreateImage(1320, ImageType.Image);
                                break;
                            case 1012:
                                image = effectLibrary.CreateImage(1020, ImageType.Image);
                                break;
                            case 1013:
                                image = effectLibrary.CreateImage(1420, ImageType.Image);
                                break;
                            case 3321:
                            case 3331:
                                image = effectLibrary.CreateImage(2100, ImageType.Image);
                                break;
                            case 3327:
                            case 3337:
                                image = effectLibrary.CreateImage(2101, ImageType.Image);
                                break;
                            case 3324:
                            case 3334:
                                image = effectLibrary.CreateImage(2102, ImageType.Image);
                                break;
                            case 3380:
                            case 3390:
                                image = effectLibrary.CreateImage(2103, ImageType.Image);
                                break;
                        }
                        if (image != null)
                        {

                            bool oldBlend = DXManager.Blending;
                            float oldRate = DXManager.BlendRate;

                            DXManager.SetBlend(true, 0.8F);

                            PresentTexture(image.Image, CharacterTab, new Rectangle(DisplayArea.X + x + image.OffSetX, DisplayArea.Y + y + image.OffSetY, image.Width, image.Height), ForeColour, this);

                            DXManager.SetBlend(oldBlend, oldRate);
                        }
                    }
                }
            }

            if (Grid[(int)EquipmentSlot.Weapon].Item != null)
            {
                int indexs = Grid[(int)EquipmentSlot.Weapon].Item.Info.Image;

                MirLibrary effectLibrary;

                if (CEnvir.LibraryList.TryGetValue(LibraryFile.EquipEffect_UI, out effectLibrary))
                {
                    MirImage image = null;
                    switch (indexs)
                    {
                        case 1075:
                            image = effectLibrary.CreateImage(3010 + GameScene.Game.MapControl.Animation % 10, ImageType.Image);
                            break;
                        case 1076:
                            image = effectLibrary.CreateImage(2000 + GameScene.Game.MapControl.Animation % 10, ImageType.Image);
                            break;
                        case 1089:
                            image = effectLibrary.CreateImage(3024 + GameScene.Game.MapControl.Animation % 10, ImageType.Image);
                            break;
                        case 2530:
                            image = effectLibrary.CreateImage(1900 + GameScene.Game.MapControl.Animation % 12, ImageType.Image);
                            break;
                        case 2550:
                            image = Grid[0].Item.Info.Effect != ItemEffect.ChaoticHeavenGlaive ? effectLibrary.CreateImage(1900 + GameScene.Game.MapControl.Animation % 12, ImageType.Image) : effectLibrary.CreateImage(1920 + GameScene.Game.MapControl.Animation % 12, ImageType.Image);
                            break;
                    }
                    if (image != null)
                    {

                        bool oldBlend = DXManager.Blending;
                        float oldRate = DXManager.BlendRate;

                        DXManager.SetBlend(true, 0.8F);

                        PresentTexture(image.Image, CharacterTab, new Rectangle(DisplayArea.X + x + image.OffSetX, DisplayArea.Y + y + image.OffSetY, image.Width, image.Height), ForeColour, this);

                        DXManager.SetBlend(oldBlend, oldRate);
                    }
                }
            }

            if (Class == MirClass.Assassin && Gender == MirGender.Female && HairType == 1 && Grid[(int)EquipmentSlot.Helmet].Item == null)
                library.Draw(1160, DisplayArea.X + x, DisplayArea.Y + y, HairColour, true, 1F, ImageType.Image);

            switch (Gender)
            {
                case MirGender.Male:
                    library.Draw(0, DisplayArea.X + x, DisplayArea.Y + y, Color.White, true, 1F, ImageType.Image);
                    break;
                case MirGender.Female:
                    library.Draw(1, DisplayArea.X + x, DisplayArea.Y + y, Color.White, true, 1F, ImageType.Image);
                    break;
            }

            if (CEnvir.LibraryList.TryGetValue(LibraryFile.Equip, out library))
            {
                if (Grid[(int)EquipmentSlot.Shizhuang].Item != null && HideShizhuang)
                {
                    int index = Grid[(int)EquipmentSlot.Shizhuang].Item.Info.Image;

                    library.Draw(index, DisplayArea.X + x, DisplayArea.Y + y, Color.White, true, 1F, ImageType.Image);
                }
                else if (Grid[(int)EquipmentSlot.Shizhuang].Item == null || Grid[(int)EquipmentSlot.Shizhuang].Item != null && !HideShizhuang)
                {
                    if (Grid[(int)EquipmentSlot.Armour].Item != null)
                    {
                        int index = Grid[(int)EquipmentSlot.Armour].Item.Info.Image;

                        library.Draw(index, DisplayArea.X + x, DisplayArea.Y + y, Color.White, true, 1F, ImageType.Image);
                        library.Draw(index, DisplayArea.X + x, DisplayArea.Y + y, Grid[(int)EquipmentSlot.Armour].Item.Colour, true, 1F, ImageType.Overlay);
                    }
                }


                if (Grid[(int)EquipmentSlot.Weapon].Item != null)
                {
                    int index = Grid[(int)EquipmentSlot.Weapon].Item.Info.Image;

                    switch (index)
                    {
                        case 1076:
                            library.Draw(index, DisplayArea.X + x, DisplayArea.Y + y, Color.White, true, 0.7F, ImageType.Image);
                            library.Draw(index, DisplayArea.X + x, DisplayArea.Y + y, Grid[(int)EquipmentSlot.Weapon].Item.Colour, true, 0.7F, ImageType.Overlay);
                            break;
                        default:
                            library.Draw(index, DisplayArea.X + x, DisplayArea.Y + y, Color.White, true, 1F, ImageType.Image);
                            library.Draw(index, DisplayArea.X + x, DisplayArea.Y + y, Grid[(int)EquipmentSlot.Weapon].Item.Colour, true, 1F, ImageType.Overlay);
                            break;
                    }
                }

                if (Grid[(int)EquipmentSlot.Shield].Item != null)
                {
                    int index = Grid[(int)EquipmentSlot.Shield].Item.Info.Image;

                    library.Draw(index, DisplayArea.X + x, DisplayArea.Y + y, Color.White, true, 1F, ImageType.Image);
                    library.Draw(index, DisplayArea.X + x, DisplayArea.Y + y, Grid[(int)EquipmentSlot.Shield].Item.Colour, true, 1F, ImageType.Overlay);
                }
            }

            if (Grid[(int)EquipmentSlot.Shizhuang].Item == null && !HideShizhuang && Grid[(int)EquipmentSlot.Helmet].Item != null && library != null ||
                Grid[(int)EquipmentSlot.Shizhuang].Item != null && !HideShizhuang && Grid[(int)EquipmentSlot.Helmet].Item != null && library != null ||
                Grid[(int)EquipmentSlot.Shizhuang].Item == null && HideShizhuang && Grid[(int)EquipmentSlot.Helmet].Item != null && library != null)
            {
                int index = Grid[(int)EquipmentSlot.Helmet].Item.Info.Image;

                library.Draw(index, DisplayArea.X + x, DisplayArea.Y + y, Color.White, true, 1F, ImageType.Image);
                library.Draw(index, DisplayArea.X + x, DisplayArea.Y + y, Grid[(int)EquipmentSlot.Helmet].Item.Colour, true, 1F, ImageType.Overlay);
            }
            else if (HairType > 0)
            {
                library = CEnvir.LibraryList[LibraryFile.ProgUse];

                switch (Class)
                {
                    case MirClass.Warrior:
                    case MirClass.Wizard:
                    case MirClass.Taoist:
                        switch (Gender)
                        {
                            case MirGender.Male:
                                library.Draw(60 + HairType - 1, DisplayArea.X + x, DisplayArea.Y + y, HairColour, true, 1F, ImageType.Image);
                                break;
                            case MirGender.Female:
                                library.Draw(80 + HairType - 1, DisplayArea.X + x, DisplayArea.Y + y, HairColour, true, 1F, ImageType.Image);
                                break;
                        }
                        break;
                    case MirClass.Assassin:
                        switch (Gender)
                        {
                            case MirGender.Male:
                                library.Draw(1100 + HairType - 1, DisplayArea.X + x, DisplayArea.Y + y, HairColour, true, 1F, ImageType.Image);
                                break;
                            case MirGender.Female:
                                library.Draw(1120 + HairType - 1, DisplayArea.X + x, DisplayArea.Y + y, HairColour, true, 1F, ImageType.Image);
                                break;
                        }
                        break;
                }
            }



        }
        
        private void CharacterTab_SwChenghaoDraw(object sender, EventArgs e)
        {
            MirLibrary library;

            int x = 261;
            int y = 81;

            int a = 245;
            int b = 66;

            int c = 250;
            int d = 70;

            if (!CEnvir.LibraryList.TryGetValue(LibraryFile.GameInter, out library)) return;

            if (Shengwangdian > 0)
            {
                int index = Shengwangdian;

                MirLibrary effectLibrary;

                if (CEnvir.LibraryList.TryGetValue(LibraryFile.GameInter, out effectLibrary))
                {
                    MirImage image = null;
                    MirImage images = null;
                    MirImage imagess = null;

                    if (index >= 500 && index < 1000)
                    {
                        image = effectLibrary.CreateImage(1870 + (GameScene.Game.MapControl.Animation % 10), ImageType.Image);
                        Grid[(int)EquipmentSlot.SwChenghao].Hint = "江湖初出\n\n生命值 + 10\n魔法值 + 10\n防御 + 1\n魔御 + 1";
                    }
                    if (index >= 1000 && index < 2000)
                    {
                        image = effectLibrary.CreateImage(1890 + (GameScene.Game.MapControl.Animation % 10), ImageType.Image);
                        Grid[(int)EquipmentSlot.SwChenghao].Hint = "新進高手\n\n生命值 + 20\n魔法值 + 20\n防御 + 2\n魔御 + 2\n破坏 + 2\n全系列魔法 + 2";
                    }
                    if (index >= 2000 && index < 3500)
                    {
                        image = effectLibrary.CreateImage(1910 + (GameScene.Game.MapControl.Animation % 10), ImageType.Image);
                        Grid[(int)EquipmentSlot.SwChenghao].Hint = "江湖侠客\n\n生命值 + 30\n魔法值 + 30\n防御 + 4\n魔御 + 4\n破坏 + 4\n全系列魔法 + 4";
                    }
                    if (index >= 3500 && index < 5500)
                    {
                        image = effectLibrary.CreateImage(1930 + (GameScene.Game.MapControl.Animation % 10), ImageType.Image);
                        Grid[(int)EquipmentSlot.SwChenghao].Hint = "武林名宿\n\n生命值 + 50\n魔法值 + 50\n防御 + 5\n魔御 + 5\n破坏 + 6\n全系列魔法 + 6\n暴击伤害[怪] + 5";
                    }
                    if (index >= 5500 && index < 8000)
                    {
                        image = effectLibrary.CreateImage(1950 + (GameScene.Game.MapControl.Animation % 10), ImageType.Image);
                        Grid[(int)EquipmentSlot.SwChenghao].Hint = "仁义大侠\n\n生命值 + 80\n魔法值 + 80\n防御 + 7\n魔御 + 7\n破坏 + 8\n全系列魔法 + 8\n暴击伤害[怪] + 5\n攻击元素[全] + 2";
                    }
                    if (index >= 8000 && index < 11000)
                    {
                        imagess = effectLibrary.CreateImage(1970 + (GameScene.Game.MapControl.Animation % 10), ImageType.Image);
                        Grid[(int)EquipmentSlot.SwChenghao].Hint = "英雄豪杰\n\n生命值 + 100\n魔法值 + 100\n防御 + 8\n魔御 + 8\n破坏 + 10\n全系列魔法 + 10\n暴击伤害[怪] + 7\n攻击元素[全] + 3";
                    }
                    if (index >= 11000)
                    {
                        images = effectLibrary.CreateImage(1990 + (GameScene.Game.MapControl.Animation % 12), ImageType.Image);
                        Grid[(int)EquipmentSlot.SwChenghao].Hint = "武林至尊\n\n生命值 + 150\n魔法值 + 150\n防御 + 10\n魔御 + 10\n破坏 + 12\n全系列魔法 + 12\n暴击伤害[怪] + 10\n攻击元素[全] + 5";
                    }


                    if (imagess == null && images == null && image != null)
                    {

                        bool oldBlend = DXManager.Blending;
                        float oldRate = DXManager.BlendRate;

                        DXManager.SetBlend(true, 0.8F);

                        PresentTexture(image.Image, CharacterTab, new Rectangle(DisplayArea.X + x + image.OffSetX, DisplayArea.Y + y + image.OffSetY, image.Width, image.Height), ForeColour, this);

                        DXManager.SetBlend(oldBlend, oldRate);
                    }
                    else if (imagess == null && image == null && images != null)
                    {

                        bool oldBlend = DXManager.Blending;
                        float oldRate = DXManager.BlendRate;

                        DXManager.SetBlend(true, 0.8F);

                        PresentTexture(images.Image, CharacterTab, new Rectangle(DisplayArea.X + a + images.OffSetX, DisplayArea.Y + b + images.OffSetY, images.Width, images.Height), ForeColour, this);

                        DXManager.SetBlend(oldBlend, oldRate);
                    }
                    else if (image == null && images == null && imagess != null)
                    {

                        bool oldBlend = DXManager.Blending;
                        float oldRate = DXManager.BlendRate;

                        DXManager.SetBlend(true, 0.8F);

                        PresentTexture(imagess.Image, CharacterTab, new Rectangle(DisplayArea.X + c + imagess.OffSetX, DisplayArea.Y + d + imagess.OffSetY, imagess.Width, imagess.Height), ForeColour, this);

                        DXManager.SetBlend(oldBlend, oldRate);
                    }
                }
            }
        }

        public void UpdateStats()
        {
            foreach (KeyValuePair<Stat, DXLabel> pair in DisplayStats)
                pair.Value.Text = Stats.GetFormat(pair.Key);


            foreach (KeyValuePair<Stat, DXLabel> pair in AttackStats)
            {

                if (Stats[pair.Key] > 0)
                {
                    pair.Value.Text = $"+{Stats[pair.Key]}";
                    pair.Value.ForeColour = Color.DeepSkyBlue;
                    ((DXImageControl)pair.Value.Tag).ForeColour = Color.White;
                }
                else
                {
                    pair.Value.Text = "0";
                    pair.Value.ForeColour = Color.FromArgb(60, 60, 60);
                    ((DXImageControl)pair.Value.Tag).ForeColour = Color.FromArgb(60, 60, 60);
                }
            }

            foreach (KeyValuePair<Stat, DXLabel> pair in AdvantageStats)
            {
                if (Stats[pair.Key] > 0)
                {
                    pair.Value.Text = $"x{Stats[pair.Key]}";
                    pair.Value.ForeColour = Color.Lime;
                    ((DXImageControl)pair.Value.Tag).ForeColour = Color.White;
                }
                else
                {
                    pair.Value.Text = "0";
                    pair.Value.ForeColour = Color.FromArgb(60, 60, 60);
                    ((DXImageControl)pair.Value.Tag).ForeColour = Color.FromArgb(60, 60, 60);
                }
            }

            foreach (KeyValuePair<Stat, DXLabel> pair in DisadvantageStats)
            {
                pair.Value.Text = Stats.GetFormat(pair.Key);

                if (Stats[pair.Key] < 0)
                {
                    pair.Value.Text = $"x{Math.Abs(Stats[pair.Key])}";
                    pair.Value.ForeColour = Color.IndianRed;
                    ((DXImageControl)pair.Value.Tag).ForeColour = Color.White;
                }
                else
                {
                    pair.Value.Text = "0";
                    pair.Value.ForeColour = Color.FromArgb(60, 60, 60);
                    ((DXImageControl)pair.Value.Tag).ForeColour = Color.FromArgb(60, 60, 60);
                }
            }

            foreach (KeyValuePair<Stat, DXLabel> pair in HermitDisplayStats)
            {
                pair.Value.Text = HermitStats.GetFormat(pair.Key);

                if (HermitStats[pair.Key] > 0)
                {
                    pair.Value.Text = $"{HermitStats.GetFormat(pair.Key)}";
                    pair.Value.ForeColour = Color.White;
                }
                else
                {
                    pair.Value.Text = "0 - 0";
                    pair.Value.ForeColour = Color.Gray;
                }
            }

            foreach (KeyValuePair<Stat, DXLabel> pair in HermitAttackStats)
            {

                if (HermitStats[pair.Key] > 0)
                {
                    pair.Value.Text = $"+{HermitStats[pair.Key]}";
                    pair.Value.ForeColour = Color.White;
                }
                else
                {
                    pair.Value.Text = "0";
                    pair.Value.ForeColour = Color.Gray;
                }
            }

            RemainingLabel.Text = HermitPoints.ToString();

        }

        public void NewInformation(S.Inspect p)
        {
            Visible = true;
            CharacterNameLabel.Text = p.Name;
            GuildNameLabel.Text = p.GuildName;
            GuildRankLabel.Text = p.GuildRank;

            MarriageIcon.Visible = !string.IsNullOrEmpty(p.Partner);
            MarriageNameLabel.Visible = !string.IsNullOrEmpty(p.Partner);
            MarriageNameLabel.Text = p.Partner;

            Stats.Clear();

            Stats.Add(p.Stats);

            HermitStats.Clear();
            HermitStats.Add(p.HermitStats);
            HermitPoints = p.HermitPoints;

            Gender = p.Gender;
            Class = p.Class;
            Level = p.Level;

            HairColour = p.HairColour;
            HairType = p.Hair;
            
            Shengwangdian = p.Shengwangdian;

            
            HideShizhuang = p.HideShizhuang;

            foreach (DXItemCell cell in Grid)
                cell.Item = null;

            foreach (ClientUserItem item in p.Items)
                Grid[item.Slot].Item = item;

            WearWeightLabel.Text = $"{p.WearWeight}/{p.Stats[Stat.WearWeight]}";
            HandWeightLabel.Text = $"{p.HandWeight}/{p.Stats[Stat.HandWeight]}";

            WearWeightLabel.ForeColour = p.WearWeight > Stats[Stat.WearWeight] ? Color.Red : Color.White;
            HandWeightLabel.ForeColour = p.HandWeight > Stats[Stat.HandWeight] ? Color.Red : Color.White;


            UpdateStats();
        }
        #endregion


        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                Stats = null;
                HermitStats = null;
                HermitPoints = 0;

                if (Equipment != null)
                {
                    for (int i = 0; i < Equipment.Length; i++)
                    {
                        Equipment[i] = null;
                    }

                    Equipment = null;
                }

                Class = 0;
                Gender = 0;
                HairType = 0;
                HairColour = Color.Empty;
                Level = 0;



                if (TabControl != null)
                {
                    if (!TabControl.IsDisposed)
                        TabControl.Dispose();

                    TabControl = null;
                }

                if (CharacterTab != null)
                {
                    if (!CharacterTab.IsDisposed)
                        CharacterTab.Dispose();

                    CharacterTab = null;
                }

                if (StatsTab != null)
                {
                    if (!StatsTab.IsDisposed)
                        StatsTab.Dispose();

                    StatsTab = null;
                }

                if (HermitTab != null)
                {
                    if (!HermitTab.IsDisposed)
                        HermitTab.Dispose();

                    HermitTab = null;
                }

                if (CharacterNameLabel != null)
                {
                    if (!CharacterNameLabel.IsDisposed)
                        CharacterNameLabel.Dispose();

                    CharacterNameLabel = null;
                }

                if (GuildNameLabel != null)
                {
                    if (!GuildNameLabel.IsDisposed)
                        GuildNameLabel.Dispose();

                    GuildNameLabel = null;
                }

                if (GuildRankLabel != null)
                {
                    if (!GuildRankLabel.IsDisposed)
                        GuildRankLabel.Dispose();

                    GuildRankLabel = null;
                }

                if (MarriageIcon != null)
                {
                    if (!MarriageIcon.IsDisposed)
                        MarriageIcon.Dispose();

                    MarriageIcon = null;
                }
                if (MarriageNameLabel != null)
                {
                    if (!MarriageNameLabel.IsDisposed)
                        MarriageNameLabel.Dispose();

                    MarriageNameLabel = null;
                }

                if (Grid != null)
                {
                    for (int i = 0; i < Grid.Length; i++)
                    {
                        if (Grid[i] != null)
                        {
                            if (!Grid[i].IsDisposed)
                                Grid[i].Dispose();

                            Grid[i] = null;
                        }
                    }

                    Grid = null;
                }

                if (WearWeightLabel != null)
                {
                    if (!WearWeightLabel.IsDisposed)
                        WearWeightLabel.Dispose();

                    WearWeightLabel = null;
                }

                if (HandWeightLabel != null)
                {
                    if (!HandWeightLabel.IsDisposed)
                        HandWeightLabel.Dispose();

                    HandWeightLabel = null;
                }

                foreach (KeyValuePair<Stat, DXLabel> pair in DisplayStats)
                {
                    if (pair.Value == null) continue;
                    if (pair.Value.IsDisposed) continue;

                    pair.Value.Dispose();
                }
                DisplayStats.Clear();
                DisplayStats = null;

                foreach (KeyValuePair<Stat, DXLabel> pair in AttackStats)
                {
                    if (pair.Value == null) continue;
                    if (pair.Value.IsDisposed) continue;

                    pair.Value.Dispose();
                }
                AttackStats.Clear();
                AttackStats = null;

                foreach (KeyValuePair<Stat, DXLabel> pair in AdvantageStats)
                {
                    if (pair.Value == null) continue;
                    if (pair.Value.IsDisposed) continue;

                    pair.Value.Dispose();
                }
                AdvantageStats.Clear();
                AdvantageStats = null;

                foreach (KeyValuePair<Stat, DXLabel> pair in DisadvantageStats)
                {
                    if (pair.Value == null) continue;
                    if (pair.Value.IsDisposed) continue;

                    pair.Value.Dispose();
                }
                DisadvantageStats.Clear();
                DisadvantageStats = null;

                foreach (KeyValuePair<Stat, DXLabel> pair in HermitDisplayStats)
                {
                    if (pair.Value == null) continue;
                    if (pair.Value.IsDisposed) continue;

                    pair.Value.Dispose();
                }
                HermitDisplayStats.Clear();
                HermitDisplayStats = null;

                foreach (KeyValuePair<Stat, DXLabel> pair in HermitAttackStats)
                {
                    if (pair.Value == null) continue;
                    if (pair.Value.IsDisposed) continue;

                    pair.Value.Dispose();
                }
                HermitAttackStats.Clear();
                HermitAttackStats = null;

                if (RemainingLabel != null)
                {
                    if (!RemainingLabel.IsDisposed)
                        RemainingLabel.Dispose();

                    RemainingLabel = null;
                }

            }

        }

        #endregion

    }
}
