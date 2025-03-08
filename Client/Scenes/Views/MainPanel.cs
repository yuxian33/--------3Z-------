using System;
using System.Drawing;
using System.Windows.Forms;
using Client.Controls;
using Client.Envir;
using Client.Models;
using Client.UserModels;
using Library;
using Library.Network;
using Library.Network.ClientPackets;


namespace Client.Scenes.Views
{
    public sealed class MainPanel : DXImageControl
    {
        #region Properties

        public DXImageControl CompanionWeightBar, WeightBar, ExperienceBar, NewMailIcon, CompletedQuestIcon, AvailableQuestIcon;

        public DXLabel ClassLabel, LevelLabel, ACLabel, MRLabel, DCLabel, MCLabel, SCLabel, AccuracyLabel, AgilityLabel, HealthLabel, ManaLabel, ExperienceLabel, AttackModeLabel, PetModeLabel, DCLabelLabel, MCLabelLabel, SCLabelLabel;

        #endregion

        public MainPanel()
        {

            LibraryFile = LibraryFile.GameInter;
            Index = 50;

            WeightBar = new DXImageControl
            {
                Parent = this,
                LibraryFile = LibraryFile.GameInter,
                Index = 206,
            };
            WeightBar.Location = new Point(461, 17);
            WeightBar.AfterDraw += (o, e) =>
            {
                if (WeightBar.Library == null) return;

                int MaxBag = MapObject.User.Stats[Stat.BagWeight];
                int UserBag = MapObject.User.BagWeight;

                if (MaxBag == 0) return;

                
                MirImage image = WeightBar.Library.CreateImage(207, ImageType.Image);

                if (image == null) return;

                float percent = Math.Min(1, Math.Max(0, (1 - MapObject.User.BagWeight / (float)MapObject.User.Stats[Stat.BagWeight])));

                if (percent == 0)
                {
                    WeightBar.Index = 208;
                    return;
                }
                else
                    WeightBar.Index = 206;

                PresentTexture(image.Image, this, new Rectangle(WeightBar.DisplayArea.X, WeightBar.DisplayArea.Y, image.Width, (int)(image.Height * (double)percent)), Color.White, WeightBar);

            };

            CompanionWeightBar = new DXImageControl
            {
                Parent = this,
                LibraryFile = LibraryFile.GameInter,
                Index = 206,
            };
            CompanionWeightBar.Location = new Point(474, 17);
            CompanionWeightBar.AfterDraw += (o, e) =>
            {
                if (CompanionWeightBar.Library == null) return;

                
                

                int MaxBag = GameScene.Game.CompanionBox.MaxBagWeight;
                int UserBag = GameScene.Game.CompanionBox.BagWeight;

                if (MaxBag == 0) return;

                
                MirImage image = CompanionWeightBar.Library.CreateImage(207, ImageType.Image);

                if (image == null) return;

                float percent = Math.Min(1, Math.Max(0, (1 - UserBag / (float)MaxBag)));

                if (percent == 0)
                {
                    CompanionWeightBar.Index = 208;
                    return;
                }
                else
                    CompanionWeightBar.Index = 206;

                PresentTexture(image.Image, this, new Rectangle(CompanionWeightBar.DisplayArea.X, CompanionWeightBar.DisplayArea.Y, image.Width, (int)(image.Height * (double)percent)), Color.White, CompanionWeightBar);

            };

            ExperienceBar = new DXImageControl
            {
                Parent = this,
                LibraryFile = LibraryFile.GameInter,
                Index = 51,
            };
            ExperienceBar.Location = new Point((Size.Width - ExperienceBar.Size.Width) / 2 + 1, 2 + 1);
            ExperienceBar.BeforeDraw += (o, e) =>
            {
                if (ExperienceBar.Library == null) return;

                if (MapObject.User.Level >= CartoonGlobals.ExperienceList.Count) return;

                decimal MaxExperience = CartoonGlobals.ExperienceList[MapObject.User.Level];

                if (MaxExperience == 0) return;

                
                MirImage image = ExperienceBar.Library.CreateImage(56, ImageType.Image);

                if (image == null) return;

                int x = (ExperienceBar.Size.Width - image.Width) / 2;
                int y = (ExperienceBar.Size.Height - image.Height) / 2;


                float percent = (float)Math.Min(1, Math.Max(0, MapObject.User.Experience / MaxExperience));

                if (percent == 0) return;



                PresentTexture(image.Image, this, new Rectangle(ExperienceBar.DisplayArea.X + x, ExperienceBar.DisplayArea.Y + y - 1, (int)(image.Width * percent), image.Height), Color.White, ExperienceBar);
            };

            DXControl HealthBar = new DXControl
            {
                Parent = this,
                Location = new Point(35, 22),
                Size = ExperienceBar.Library.GetSize(52),
            };
            HealthBar.BeforeDraw += (o, e) =>
            {
                if (ExperienceBar.Library == null) return;

                if (MapObject.User.Stats[Stat.Health] == 0) return;

                float percent = Math.Min(1, Math.Max(0, MapObject.User.CurrentHP / (float)MapObject.User.Stats[Stat.Health]));

                if (percent == 0) return;

                MirImage image = ExperienceBar.Library.CreateImage(52, ImageType.Image);

                if (image == null) return;

                PresentTexture(image.Image, this, new Rectangle(HealthBar.DisplayArea.X, HealthBar.DisplayArea.Y, (int)(image.Width * percent), image.Height), Color.White, HealthBar);
            };
            DXControl ManaBar = new DXControl
            {
                Parent = this,
                Location = new Point(35, 36),
                Size = ExperienceBar.Library.GetSize(52),
            };
            ManaBar.BeforeDraw += (o, e) =>
            {
                if (ExperienceBar.Library == null) return;

                if (MapObject.User.Stats[Stat.Mana] == 0) return;

                float percent = Math.Min(1, Math.Max(0, MapObject.User.CurrentMP / (float)MapObject.User.Stats[Stat.Mana]));

                if (percent == 0) return;

                MirImage image = ExperienceBar.Library.CreateImage(54, ImageType.Image);

                if (image == null) return;

                PresentTexture(image.Image, this, new Rectangle(ManaBar.DisplayArea.X, ManaBar.DisplayArea.Y, (int)(image.Width * percent), image.Height), Color.White, ManaBar);
            };
            DXImageControl OtherBar = new DXImageControl
            {
                Parent = this,
                Location = new Point(35, 50),
                LibraryFile = LibraryFile.GameInter,
                Index = 58,
                Visible = false,
            };

            DXButton CharacterButton = new DXButton
            {
                LibraryFile = LibraryFile.GameInter,
                Index = 82,
                Parent = this,
                Location = new Point(494, 23),
                Hint = "　人物信息 [Q]"
            };
            CharacterButton.MouseClick += (o, e) =>
            {
                GameScene.Game.CharacterBox.Visible = !GameScene.Game.CharacterBox.Visible;
            };

            DXButton InventoryButton = new DXButton
            {
                LibraryFile = LibraryFile.GameInter,
                Index = 87,
                Parent = this,
                Location = new Point(533, 23),
                Hint = "　人物背包 [W]"
            };
            InventoryButton.MouseClick += (o, e) => GameScene.Game.InventoryBox.Visible = !GameScene.Game.InventoryBox.Visible;

            DXButton CompainionButton = new DXButton
            {
                LibraryFile = LibraryFile.GameInter,
                Index = 202,
                Parent = this,
                Location = new Point(572, 23),
                Hint = "　宠物背包 [U]"
            };
            CompainionButton.MouseClick += (o, e) =>
            {
                if (GameScene.Game.Companion != null)
                    GameScene.Game.CompanionBox.Visible = !GameScene.Game.CompanionBox.Visible;
                else
                    GameScene.Game.ReceiveChat("你还没有宠物，不能打开宠物界面", MessageType.System);
            };

            DXButton SpellButton = new DXButton
            {
                LibraryFile = LibraryFile.GameInter,
                Index = 92,
                Parent = this,
                Location = new Point(611, 23),
                Hint = "　技能 [E]"
            };
            SpellButton.MouseClick += (o, e) => GameScene.Game.MagicBox.Visible = !GameScene.Game.MagicBox.Visible;

            DXButton GuildButton = new DXButton
            {
                LibraryFile = LibraryFile.GameInter,
                Index = 203,
                Parent = this,
                Location = new Point(650, 23),
                Hint = "　公会信息 [G]"
            };
            GuildButton.MouseClick += (o, e) => GameScene.Game.GuildBox.Visible = !GameScene.Game.GuildBox.Visible;

            DXButton QuestButton = new DXButton
            {
                LibraryFile = LibraryFile.GameInter,
                Index = 112,
                Parent = this,
                Location = new Point(689, 23),
                Hint = "　支线任务 [J]"
            };
            QuestButton.MouseClick += (o, e) => GameScene.Game.QuestBox.Visible = !GameScene.Game.QuestBox.Visible;

            DXButton MeiriQuestButton = new DXButton
            {
                LibraryFile = LibraryFile.GameInter,
                Index = 204,
                Parent = this,
                Location = new Point(728, 23),
                Hint = "　每日任务 [N]"
            };
            MeiriQuestButton.MouseClick += (o, e) => GameScene.Game.MeiriQuestBox.Visible = !GameScene.Game.MeiriQuestBox.Visible;

            DXButton FubenButton = new DXButton
            {
                LibraryFile = LibraryFile.GameInter,
                Index = 205,
                Parent = this,
                Location = new Point(767, 23),
                Hint = "　副本系统 [ALT + U]"
            };
            FubenButton.MouseClick += (o, e) =>
            {
                GameScene.Game.FubenBox.Visible = !GameScene.Game.FubenBox.Visible;
                if (!GameScene.Game.FubenBox.Visible && GameScene.Game.FubenMonsterDropItemsBox.Visible)
                    GameScene.Game.FubenMonsterDropItemsBox.Visible = false;
            };

            DXButton MailButton = new DXButton
            {
                LibraryFile = LibraryFile.GameInter,
                Index = 97,
                Parent = this,
                Location = new Point(806, 23),
                Hint = "　邮件 [,]"
            };
            MailButton.MouseClick += (o, e) => GameScene.Game.MailBox.Visible = !GameScene.Game.MailBox.Visible;

            NewMailIcon = new DXImageControl
            {
                LibraryFile = LibraryFile.GameInter,
                Index = 240,
                Parent = MailButton,
                IsControl = false,
                Location = new Point(2, 2),
                Visible = false,
            };

            AvailableQuestIcon = new DXImageControl
            {
                LibraryFile = LibraryFile.GameInter,
                Index = 240,
                Parent = QuestButton,
                IsControl = false,
                Location = new Point(2, 2),
                Visible = false,
            };
            AvailableQuestIcon.VisibleChanged += (o, e) =>
            {
                if (AvailableQuestIcon.Visible)
                    CompletedQuestIcon.Location = new Point(2, QuestButton.Size.Height - CompletedQuestIcon.Size.Height);
                else
                    CompletedQuestIcon.Location = new Point(2, 2);
            };

            CompletedQuestIcon = new DXImageControl
            {
                LibraryFile = LibraryFile.GameInter,
                Index = 241,
                Parent = QuestButton,
                IsControl = false,
                Location = new Point(2, 2),
                Visible = false,
            };

            DXButton BeltButton = new DXButton
            {
                LibraryFile = LibraryFile.GameInter,
                Index = 107,
                Parent = this,
                Location = new Point(845, 23),
                Hint = "　快捷栏 [Z]"
            };
            BeltButton.MouseClick += (o, e) => GameScene.Game.BeltBox.Visible = !GameScene.Game.BeltBox.Visible;

            DXButton GroupButton = new DXButton
            {
                LibraryFile = LibraryFile.GameInter,
                Index = 102,
                Parent = this,
                Location = new Point(884, 23),
                Hint = "　组队 [P]"
            };
            GroupButton.MouseClick += (o, e) => GameScene.Game.GroupBox.Visible = !GameScene.Game.GroupBox.Visible;

            DXButton MenuButton = new DXButton
            {
                LibraryFile = LibraryFile.GameInter,
                Index = 117,
                Parent = this,
                Location = new Point(923, 23),
                Hint = "　主菜单",
            };
            MenuButton.MouseClick += (o, e) => GameScene.Game.MenuBox.Visible = !GameScene.Game.MenuBox.Visible;

            DXButton CashShopButton = new DXButton
            {
                LibraryFile = LibraryFile.GameInter,
                Index = 122,
                Parent = this,
                Location = new Point(972, 16),
                Hint = "　商城 [Y]"
            };
            CashShopButton.MouseClick += (o, e) =>
            {
                if (GameScene.Game.MarketPlaceBox.StoreTab.IsVisible)
                    GameScene.Game.MarketPlaceBox.Visible = false;
                else
                {
                    GameScene.Game.MarketPlaceBox.Visible = true;
                    GameScene.Game.MarketPlaceBox.StoreTab.TabButton.InvokeMouseClick();
                }
            };

            DXLabel label = new DXLabel
            {
                Parent = this,
                Font = new Font(Config.FontName, CEnvir.FontSize(8F), FontStyle.Bold),
                ForeColour = Color.FromArgb(236, 209, 99),
                Text = "职业", 
                
            };
            label.Location = new Point(305 - label.Size.Width, 22);

            label = new DXLabel
            {
                Parent = this,
                Font = new Font(Config.FontName, CEnvir.FontSize(8F), FontStyle.Bold),
                ForeColour = Color.FromArgb(236, 209, 99),
                Text = "等级",
                
            };
            label.Location = new Point(305 - label.Size.Width, 42);

            label = new DXLabel
            {
                Parent = this,
                Font = new Font(Config.FontName, CEnvir.FontSize(8F), FontStyle.Bold),
                ForeColour = Color.FromArgb(236, 209, 99),
                Text = "防御",
                
            };
            label.Location = new Point(384 - label.Size.Width, 22);

            label = new DXLabel
            {
                Parent = this,
                Font = new Font(Config.FontName, CEnvir.FontSize(8F), FontStyle.Bold),
                Text = "魔御",
                            
                Visible = false,
            };
            label.Location = new Point(474 - label.Size.Width, 22);

            DCLabelLabel = new DXLabel
            {
                Parent = this,
                Font = new Font(Config.FontName, CEnvir.FontSize(8F), FontStyle.Bold),
                ForeColour = Color.FromArgb(236, 209, 99),
                Text = "破坏",
                            
            };
            DCLabelLabel.Location = new Point(384 - label.Size.Width, 42);

            MCLabelLabel = new DXLabel
            {
                Parent = this,
                Font = new Font(Config.FontName, CEnvir.FontSize(8F), FontStyle.Bold),
                ForeColour = Color.FromArgb(236, 209, 99),
                Text = "自然",
                
            };
            MCLabelLabel.Location = new Point(384 - DCLabelLabel.Size.Width, 42);

            SCLabelLabel = new DXLabel
            {
                Parent = this,
                Font = new Font(Config.FontName, CEnvir.FontSize(8F), FontStyle.Bold),
                ForeColour = Color.FromArgb(236, 209, 99),
                Text = "灵魂",
                
            };
            SCLabelLabel.Location = new Point(384 - DCLabelLabel.Size.Width, 42);

            label = new DXLabel
            {
                Parent = this,
                Font = new Font(Config.FontName, CEnvir.FontSize(8F), FontStyle.Bold),
                Text = "准确",
                
                Visible = false,
            };
            label.Location = new Point(571 - label.Size.Width, 22);

            label = new DXLabel
            {
                Parent = this,
                Font = new Font(Config.FontName, CEnvir.FontSize(8F), FontStyle.Bold),
                Text = "敏捷",
                
                Visible = false,
            };
            label.Location = new Point(571 - label.Size.Width, 42);

            ClassLabel = new DXLabel
            {
                AutoSize = false,
                Parent = this,
                Font = new Font(Config.FontName, CEnvir.FontSize(8F)),
                ForeColour = Color.White,
                Location = new Point(295, 21),
                Size = new Size(60, 16),
                DrawFormat = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter
            };

            LevelLabel = new DXLabel
            {
                AutoSize = false,
                Parent = this,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F)),
                ForeColour = Color.White,
                Location = new Point(295, 42),
                Size = new Size(60, 16),
                DrawFormat = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter
            };

            ACLabel = new DXLabel
            {
                AutoSize = false,
                Parent = this,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F)),
                ForeColour = Color.White,
                Location = new Point(385, 22),
                Size = new Size(60, 16),
                DrawFormat = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter
            };

            MRLabel = new DXLabel
            {
                AutoSize = false,
                Parent = this,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F)),
                Location = new Point(470, 20),
                Size = new Size(60, 16),
                DrawFormat = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter,
                Visible = false,
            };

            DCLabel = new DXLabel
            {
                AutoSize = false,
                Parent = this,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F)),
                ForeColour = Color.White,
                Location = new Point(385, 42),
                Size = new Size(60, 16),
                DrawFormat = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter
            };

            MCLabel = new DXLabel
            {
                AutoSize = false,
                Parent = this,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F)),
                ForeColour = Color.White,
                Location = new Point(385, 42),
                Size = new Size(60, 16),
                DrawFormat = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter,
            };
            MCLabel.VisibleChanged += (o, e) => MCLabelLabel.Visible = MCLabel.Visible;

            SCLabel = new DXLabel
            {
                AutoSize = false,
                Parent = this,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F)),
                ForeColour = Color.White,
                Location = new Point(385, 42),
                Size = new Size(60, 16),
                DrawFormat = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter,
            };
            SCLabel.VisibleChanged += (o, e) => SCLabelLabel.Visible = SCLabel.Visible;

            AccuracyLabel = new DXLabel
            {
                AutoSize = false,
                Parent = this,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F)),
                Location = new Point(567, 20),
                Size = new Size(60, 16),
                DrawFormat = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter,
                Visible = false,
            };

            AgilityLabel = new DXLabel
            {
                AutoSize = false,
                Parent = this,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F)),
                Location = new Point(567, 40),
                Size = new Size(60, 16),
                DrawFormat = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter,
                Visible = false,
            };


            HealthLabel = new DXLabel
            {
                Parent = this,
                ForeColour = Color.White,
                Outline = true,
                OutlineColour = Color.Black,
                DrawFormat = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter
            };
            HealthLabel.SizeChanged += (o, e) =>
            {
                HealthLabel.Location = new Point(HealthBar.Location.X + (HealthBar.Size.Width - HealthLabel.Size.Width) / 2, HealthBar.Location.Y + (HealthBar.Size.Height - HealthLabel.Size.Height) / 2);
            };

            ManaLabel = new DXLabel
            {
                Parent = this,
                ForeColour = Color.White,
                Outline = true,
                OutlineColour = Color.Black,
                DrawFormat = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter
            };
            ManaLabel.SizeChanged += (o, e) =>
            {
                ManaLabel.Location = new Point(ManaBar.Location.X + (ManaBar.Size.Width - ManaLabel.Size.Width) / 2, ManaBar.Location.Y + (ManaBar.Size.Height - ManaLabel.Size.Height) / 2);
            };


            ExperienceLabel = new DXLabel
            {
                Parent = this,
                ForeColour = Color.White,
                Outline = true,
                OutlineColour = Color.Black,
                DrawFormat = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter
            };
            ExperienceLabel.SizeChanged += (o, e) =>
            {
                ExperienceLabel.Location = new Point(ExperienceBar.Location.X + (ExperienceBar.Size.Width - ExperienceLabel.Size.Width) / 2, ExperienceBar.Location.Y + (ExperienceBar.Size.Height - ExperienceLabel.Size.Height) / 2);
            };

            AttackModeLabel = new DXLabel
            {
                Parent = this,
                ForeColour = Color.Cyan,
                Outline = true,
                OutlineColour = Color.Black,
                DrawFormat = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter
            };
            AttackModeLabel.SizeChanged += (o, e) =>
            {
                AttackModeLabel.Location = new Point(OtherBar.Location.X, OtherBar.Location.Y + (OtherBar.Size.Height - AttackModeLabel.Size.Height) / 2 - 2);
            };

            PetModeLabel = new DXLabel
            {
                Parent = this,
                ForeColour = Color.Cyan,
                Outline = true,
                OutlineColour = Color.Black,
                DrawFormat = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter
            };
            PetModeLabel.SizeChanged += (o, e) =>
            {
                PetModeLabel.Location = new Point(OtherBar.Location.X + OtherBar.Size.Width - PetModeLabel.Size.Width, OtherBar.Location.Y + (OtherBar.Size.Height - PetModeLabel.Size.Height) / 2 - 2);
            };

        }

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                if (ExperienceBar != null)
                {
                    if (!ExperienceBar.IsDisposed)
                        ExperienceBar.Dispose();

                    ExperienceBar = null;
                }

                if (NewMailIcon != null)
                {
                    if (!NewMailIcon.IsDisposed)
                        NewMailIcon.Dispose();

                    NewMailIcon = null;
                }

                if (ClassLabel != null)
                {
                    if (!ClassLabel.IsDisposed)
                        ClassLabel.Dispose();

                    ClassLabel = null;
                }

                if (LevelLabel != null)
                {
                    if (!LevelLabel.IsDisposed)
                        LevelLabel.Dispose();

                    LevelLabel = null;
                }

                if (ACLabel != null)
                {
                    if (!ACLabel.IsDisposed)
                        ACLabel.Dispose();

                    ACLabel = null;
                }

                if (MRLabel != null)
                {
                    if (!MRLabel.IsDisposed)
                        MRLabel.Dispose();

                    MRLabel = null;
                }

                if (DCLabel != null)
                {
                    if (!DCLabel.IsDisposed)
                        DCLabel.Dispose();

                    DCLabel = null;
                }

                if (MCLabel != null)
                {
                    if (!MCLabel.IsDisposed)
                        MCLabel.Dispose();

                    MCLabel = null;
                }

                if (SCLabel != null)
                {
                    if (!SCLabel.IsDisposed)
                        SCLabel.Dispose();

                    SCLabel = null;
                }

                if (AccuracyLabel != null)
                {
                    if (!AccuracyLabel.IsDisposed)
                        AccuracyLabel.Dispose();

                    AccuracyLabel = null;
                }

                if (AgilityLabel != null)
                {
                    if (!AgilityLabel.IsDisposed)
                        AgilityLabel.Dispose();

                    AgilityLabel = null;
                }

                if (HealthLabel != null)
                {
                    if (!HealthLabel.IsDisposed)
                        HealthLabel.Dispose();

                    HealthLabel = null;
                }

                if (ManaLabel != null)
                {
                    if (!ManaLabel.IsDisposed)
                        ManaLabel.Dispose();

                    ManaLabel = null;
                }

                if (ExperienceLabel != null)
                {
                    if (!ExperienceLabel.IsDisposed)
                        ExperienceLabel.Dispose();

                    ExperienceLabel = null;
                }

                if (AttackModeLabel != null)
                {
                    if (!AttackModeLabel.IsDisposed)
                        AttackModeLabel.Dispose();

                    AttackModeLabel = null;
                }

                if (PetModeLabel != null)
                {
                    if (!PetModeLabel.IsDisposed)
                        PetModeLabel.Dispose();

                    PetModeLabel = null;
                }
            }

        }

        public sealed class MenuDialog : DXWindow
        {
            public DXButton SetupButton;
            public DXButton FuzhuButton;
            public DXButton GuildButton;
            public DXButton RanKingButton;
            public DXButton GuildRanKingButton;
            public DXButton MeiriQuest;
            public DXButton CompanionButton;
            public DXButton CangkuButton;
            public DXButton CaifuButton;
            public DXButton JinenglanButton;
            public DXButton ZhizuoButton;
            public DXButton MiniGameButton;
            public DXButton ExitButton;
            public DXButton TestButton;

            public override WindowType Type
            {
                get
                {
                    return WindowType.None;
                }
            }

            public override bool CustomSize
            {
                get
                {
                    return false;
                }
            }

            public override bool AutomaticVisiblity
            {
                get
                {
                    return false;
                }
            }

            public MenuDialog()
            {
                Size = new Size(150, 350);
                Location = ClientArea.Location;
                TitleLabel.Text = "主菜单";
                Visible = false;
                DXButton dxButton1 = new DXButton();
                dxButton1.Parent = this;
                dxButton1.Location = new Point(25, 40);
                dxButton1.Size = new Size(100, DefaultHeight);
                dxButton1.Label.Text = "环境设置";
                dxButton1.Hint = "　设置 [O]";
                SetupButton = dxButton1;
                SetupButton.MouseClick += (o, e) => GameScene.Game.ConfigBox.Visible = !GameScene.Game.ConfigBox.Visible;
                DXButton dxButton2 = new DXButton();
                dxButton2.Parent = this;
                dxButton2.Location = new Point(25, 70);
                dxButton2.Size = new Size(100, DefaultHeight);
                dxButton2.Label.Text = "辅助设置";
                dxButton2.Hint = "　辅助 [A]";
                FuzhuButton = dxButton2;
                FuzhuButton.MouseClick += (o, e) => GameScene.Game.BigPatchBox.Visible = !GameScene.Game.BigPatchBox.Visible;
                DXButton dxButton4 = new DXButton();
                dxButton4.Parent = this;
                dxButton4.Location = new Point(25, 100);
                dxButton4.Size = new Size(100, DefaultHeight);
                dxButton4.Label.Text = "掉落查询";
                dxButton4.Hint = "　怪物爆率情况 [Shift+P]";
                CangkuButton = dxButton4;
                CangkuButton.MouseClick += (o, e) => GameScene.Game.RateQueryBox.Visible = !GameScene.Game.RateQueryBox.Visible;
                DXButton dxButton5 = new DXButton();
                dxButton5.Parent = this;
                dxButton5.Location = new Point(25, 130);
                dxButton5.Size = new Size(100, DefaultHeight);
                dxButton5.Label.Text = "玛法排行";
                dxButton5.Hint = "　排行 [R]";
                RanKingButton = dxButton5;
                RanKingButton.MouseClick += (o, e) => GameScene.Game.RankingBox.Visible = !GameScene.Game.RankingBox.Visible;
                DXButton dxButton6 = new DXButton();
                dxButton6.Parent = this;
                dxButton6.Location = new Point(25, 160);
                dxButton6.Size = new Size(100, DefaultHeight);
                dxButton6.Label.Text = "公会排行";
                dxButton6.Hint = "　每日任务 [G]";
                GuildRanKingButton = dxButton6;
                GuildRanKingButton.MouseClick += (o, e) => GameScene.Game.GuildRankingBox.Visible = !GameScene.Game.GuildRankingBox.Visible;
                DXButton dxButton7 = new DXButton();
                dxButton7.Parent = this;
                dxButton7.Location = new Point(25, 190);
                dxButton7.Size = new Size(100, DefaultHeight);
                dxButton7.Label.Text = "财富之窗";
                dxButton7.Hint = "　财富之窗 [Ctrl + W]";
                CaifuButton = dxButton7;
                CaifuButton.MouseClick += (o, e) => GameScene.Game.FortuneCheckerBox.Visible = !GameScene.Game.FortuneCheckerBox.Visible;
                DXButton dxButton10 = new DXButton();
                dxButton10.Parent = this;
                dxButton10.Location = new Point(25, 220);
                dxButton10.Size = new Size(100, DefaultHeight);
                dxButton10.Label.Text = "技能快捷栏";
                dxButton10.Hint = "　技能快捷栏 [Ctrl + E]";
                JinenglanButton = dxButton10;
                JinenglanButton.MouseClick += (o, e) => GameScene.Game.MagicBarBox.Visible = !GameScene.Game.MagicBarBox.Visible;
                DXButton dxButton11 = new DXButton();
                dxButton11.Parent = this;
                dxButton11.Location = new Point(25, 250);
                dxButton11.Size = new Size(100, DefaultHeight);
                dxButton11.Label.Text = "制作系统";
                dxButton11.Hint = "　制作系统 [Alt + M]";
                ZhizuoButton = dxButton11;
                ZhizuoButton.MouseClick += (o, e) => GameScene.Game.CraftingBox.Visible = !GameScene.Game.CraftingBox.Visible;
                DXButton dxButton13 = new DXButton();
                dxButton13.Parent = this;
                dxButton13.Location = new Point(25, 280);
                dxButton13.Size = new Size(100, DefaultHeight);
                dxButton13.Label.Text = "迷你游戏";
                dxButton13.Hint = "　迷你游戏 [Alt + H]";
                MiniGameButton = dxButton13;
                MiniGameButton.MouseClick += (o, e) => GameScene.Game.MiniGamesBox.Visible = !GameScene.Game.MiniGamesBox.Visible;
                DXButton dxButton14 = new DXButton();
                dxButton14.Parent = this;
                dxButton14.Location = new Point(25, 310);
                dxButton14.Size = new Size(100, DefaultHeight);
                dxButton14.Label.Text = "结束游戏";
                dxButton14.Hint = "　退出 [Alt + X]";
                ExitButton = dxButton14;
                ExitButton.MouseClick += (o, e) => GameScene.Game.ExitBox.Visible = !GameScene.Game.ExitBox.Visible;
            }
        }
        public sealed class AttackModeDialog : DXWindow
        {
            public DXImageControl AttackModeBackGround;
            public DXButton AllButton;
            public DXButton PeaceButton;
            public DXButton GroupButton;
            public DXButton GuildButton;
            public DXButton WarRedBrownButton;
            public DXLabel SummerLabelEx, GuajiTimeLabel, HuiyuanTimeLabel;

            public override WindowType Type
            {
                get
                {
                    return WindowType.None;
                }
            }

            public override bool CustomSize
            {
                get
                {
                    return false;
                }
            }

            public override bool AutomaticVisiblity
            {
                get
                {
                    return true;
                }
            }

            public AttackModeDialog()
            {
                HasTitle = false;
                HasFooter = false;
                HasTopBorder = false;
                TitleLabel.Visible = false;
                CloseButton.Visible = false;
                Movable = false;
                Opacity = 0.0f;
                Size = new Size(400, 60);

                AttackModeBackGround = new DXImageControl
                {
                    Parent = this,
                    LibraryFile = LibraryFile.GameInter2,
                    Index = 2600,
                    ImageOpacity = 0f,
                    Location = new Point(0, 0),
                    IsControl = true,
                    PassThrough = true,
                };

                AllButton = new DXButton
                {
                    LibraryFile = LibraryFile.GameInter2,
                    Parent = this,
                    Index = 2611,
                    Location = new Point(23, 10),
                    Visible = false,

                };
                AllButton.MouseMove += (o, e) =>
                {
                    AttackModeBackGround.ImageOpacity = 1f;
                    
                    HuiyuanTimeLabel.Opacity = 1f;
                    SummerLabelEx.Opacity = 1f;
                };
                AllButton.MouseLeave += (o, e) =>
                {
                    AttackModeBackGround.ImageOpacity = 0f;
                    
                    HuiyuanTimeLabel.Opacity = 0f;
                    SummerLabelEx.Opacity = 0f;
                };
                AllButton.MouseClick += (o, e) =>
                {
                    GameScene.Game.User.AttackMode = AttackMode.Peace;
                    CEnvir.Enqueue((Packet)new ChangeAttackMode()
                    {
                        Mode = AttackMode.Peace
                    });
                    AllButton.Visible = false;
                    PeaceButton.Visible = true;
                    GroupButton.Visible = false;
                    GuildButton.Visible = false;
                    WarRedBrownButton.Visible = false;
                };
                DXButton dxButton2 = new DXButton();
                dxButton2.LibraryFile = LibraryFile.GameInter2;
                dxButton2.Parent = (DXControl)this;
                dxButton2.Index = 2613;
                dxButton2.Location = new Point(23, 10);
                dxButton2.Visible = false;
                PeaceButton = dxButton2;
                PeaceButton.MouseMove += (o, e) =>
                {
                    AttackModeBackGround.ImageOpacity = 1f;
                    
                    HuiyuanTimeLabel.Opacity = 1f;
                    SummerLabelEx.Opacity = 1f;
                };
                PeaceButton.MouseLeave += (o, e) =>
                {
                    AttackModeBackGround.ImageOpacity = 0f;
                    
                    HuiyuanTimeLabel.Opacity = 0f;
                    SummerLabelEx.Opacity = 0f;
                };
                PeaceButton.MouseClick += (EventHandler<MouseEventArgs>)((o, e) =>
                {
                    GameScene.Game.User.AttackMode = AttackMode.Group;
                    CEnvir.Enqueue((Packet)new ChangeAttackMode()
                    {
                        Mode = AttackMode.Group
                    });
                    AllButton.Visible = false;
                    PeaceButton.Visible = false;
                    GroupButton.Visible = true;
                    GuildButton.Visible = false;
                    WarRedBrownButton.Visible = false;
                });
                DXButton dxButton3 = new DXButton();
                dxButton3.LibraryFile = LibraryFile.GameInter2;
                dxButton3.Parent = (DXControl)this;
                dxButton3.Index = 2615;
                dxButton3.Location = new Point(23, 10);
                dxButton3.Visible = false;
                GroupButton = dxButton3;
                GroupButton.MouseMove += (o, e) =>
                {
                    AttackModeBackGround.ImageOpacity = 1f;
                    
                    HuiyuanTimeLabel.Opacity = 1f;
                    SummerLabelEx.Opacity = 1f;
                };
                GroupButton.MouseLeave += (o, e) =>
                {
                    AttackModeBackGround.ImageOpacity = 0f;
                    
                    HuiyuanTimeLabel.Opacity = 0f;
                    SummerLabelEx.Opacity = 0f;
                };
                GroupButton.MouseClick += (EventHandler<MouseEventArgs>)((o, e) =>
                {
                    GameScene.Game.User.AttackMode = AttackMode.Guild;
                    CEnvir.Enqueue((Packet)new ChangeAttackMode()
                    {
                        Mode = AttackMode.Guild
                    });
                    AllButton.Visible = false;
                    PeaceButton.Visible = false;
                    GroupButton.Visible = false;
                    GuildButton.Visible = true;
                    WarRedBrownButton.Visible = false;
                });
                DXButton dxButton4 = new DXButton();
                dxButton4.LibraryFile = LibraryFile.GameInter2;
                dxButton4.Parent = (DXControl)this;
                dxButton4.Index = 2617;
                dxButton4.Location = new Point(23, 10);
                dxButton4.Visible = false;
                GuildButton = dxButton4;
                GuildButton.MouseMove += (o, e) =>
                {
                    AttackModeBackGround.ImageOpacity = 1f;
                    
                    HuiyuanTimeLabel.Opacity = 1f;
                    SummerLabelEx.Opacity = 1f;
                };
                GuildButton.MouseLeave += (o, e) =>
                {
                    AttackModeBackGround.ImageOpacity = 0f;
                    
                    HuiyuanTimeLabel.Opacity = 0f;
                    SummerLabelEx.Opacity = 0f;
                };
                GuildButton.MouseClick += (EventHandler<MouseEventArgs>)((o, e) =>
                {
                    GameScene.Game.User.AttackMode = AttackMode.WarRedBrown;
                    CEnvir.Enqueue((Packet)new ChangeAttackMode()
                    {
                        Mode = AttackMode.WarRedBrown
                    });
                    AllButton.Visible = false;
                    PeaceButton.Visible = false;
                    GroupButton.Visible = false;
                    GuildButton.Visible = false;
                    WarRedBrownButton.Visible = true;
                });
                DXButton dxButton5 = new DXButton();
                dxButton5.LibraryFile = LibraryFile.GameInter2;
                dxButton5.Parent = (DXControl)this;
                dxButton5.Index = 2619;
                dxButton5.Location = new Point(23, 10);
                dxButton5.Visible = false;
                WarRedBrownButton = dxButton5;
                WarRedBrownButton.MouseMove += (o, e) =>
                {
                    AttackModeBackGround.ImageOpacity = 1f;
                    
                    HuiyuanTimeLabel.Opacity = 1f;
                    SummerLabelEx.Opacity = 1f;
                };
                WarRedBrownButton.MouseLeave += (o, e) =>
                {
                    AttackModeBackGround.ImageOpacity = 0f;
                    
                    HuiyuanTimeLabel.Opacity = 0f;
                    SummerLabelEx.Opacity = 0f;
                };
                WarRedBrownButton.MouseClick += (EventHandler<MouseEventArgs>)((o, e) =>
                {
                    GameScene.Game.User.AttackMode = AttackMode.All;
                    CEnvir.Enqueue((Packet)new ChangeAttackMode()
                    {
                        Mode = AttackMode.All
                    });
                    AllButton.Visible = true;
                    PeaceButton.Visible = false;
                    GroupButton.Visible = false;
                    GuildButton.Visible = false;
                    WarRedBrownButton.Visible = false;
                });

                HuiyuanTimeLabel = new DXLabel
                {
                    ForeColour = Color.Yellow,
                    Parent = this,
                    Location = new Point(140, 7),
                    Text = "会员持续时间：0 秒",
                    Opacity = 0,
                };

                SummerLabelEx = new DXLabel
                {
                    ForeColour = Color.LightPink,
                    Parent = this,
                    Location = new Point(150, 27),
                    Text = "0",
                    Opacity = 0,
                };

            }

            protected override void Dispose(bool disposing)
            {
                base.Dispose(disposing);
                if (!disposing || AttackModeBackGround == null)
                    return;
                if (!AttackModeBackGround.IsDisposed)
                    AttackModeBackGround.Dispose();
                AttackModeBackGround = null;
            }
        }

        #endregion
    }
}
