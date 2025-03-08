using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Client.Controls;
using Client.Envir;
using Client.Models;
using Client.UserModels;
using Library;
using Library.SystemModels;


namespace Client.Scenes.Views
{
    public sealed class CompanionDialog : DXWindow
    {
        #region Properties

        public DXItemCell[] EquipmentGrid;
        public DXItemGrid InventoryGrid;

        public MonsterObject CompanionDisplay;
        public Point CompanionDisplayPoint;

        public DXLabel WeightLabel, HungerLabel, NameLabel, ChenghaoLabel, LevelLabel, ExperienceLabel, Level3Label, Level5Label, Level7Label, Level10Label, Level11Label, Level13Label, Level15Label, Level17Label, Level20Label, Level23Label, Level25Label, Level27Label, Level30Label, Level33Label, Level35Label, Level37Label, Level40Label, HasSpaceLabel;
        public DXImageControl Level3ImgIndex, Level5ImgIndex, Level7ImgIndex, Level10ImgIndex, Level11ImgIndex, Level13ImgIndex, Level15ImgIndex, Level3Maxzhi, Level5Maxzhi, Level7Maxzhi, Level10Maxzhi, Level11Maxzhi, Level13Maxzhi, Level15Maxzhi, HuangjinCompanion;
        public DXComboBox ModeComboBox;

        public int BagWeight, MaxBagWeight, InventorySize, HasSpace;

        private DXMirScrollBar ScrollBar;
        public DXImageControl Background, InventoryBackground, ExperienceBar, EduBar, FuzhongBar;
        public DXControl Panel, AddMemberPanel;
        public DXButton InventoryButton, XinxiButton;

        public List<DXControl> Lines = new List<DXControl>();
        /*
        public override void OnSizeChanged(Size oValue, Size nValue)
        {
            base.OnSizeChanged(oValue, nValue);

            ScrollBar.Size = new Size(15, 180);
            ScrollBar.Location = new Point(ClientArea.Right - 32, ClientArea.Top + 1 + 52);
            ScrollBar.VisibleSize = 15;
        }
        */
        public override WindowType Type => WindowType.None;
        public override bool CustomSize => false;
        public override bool AutomaticVisiblity => true;

        #endregion

        public CompanionDialog()
        {
            Opacity = 0.0f;
            TitleLabel.Visible = false;
            HasFooter = false;
            HasTopBorder = false;
            HasTitle = false;
            AllowResize = false;
            Movable = true;

            Background = new DXImageControl
            {
                LibraryFile = LibraryFile.GameInter,
                Index = 4302,
                Location = new Point(0, 0),
                Parent = this,
            };
            Size = Background.Size;
            CloseButton.Parent = Background;
            Background.MouseDown += new EventHandler<MouseEventArgs>(WindowMove);
            
            CompanionDisplayPoint = new Point(ClientArea.X + 75, ClientArea.Y + 168);

            Panel = new DXControl()
            {
                Parent = Background,
                Location = new Point(253, 66),
                Size = new Size(202, 405),
                BackColour = Color.Black
            };

            InventoryBackground = new DXImageControl
            {
                LibraryFile = LibraryFile.GameInter,
                Index = 4304,
                Location = new Point(253, 66),
                Parent = Background,
                Visible = false,
            };

            InventoryButton = new DXButton
            {
                Parent = Background,
                LibraryFile = LibraryFile.GameInter,
                Index = 86,
                Hint = "宠物包裹",
                Location = new Point(19, 419),
            };
            InventoryButton.MouseClick += ((o, e) =>
            {
                InventoryBackground.Visible = !InventoryBackground.Visible;
                InventoryGrid.Visible = !InventoryGrid.Visible;
                AddMemberPanel.Visible = !AddMemberPanel.Visible;
            });

            HasSpaceLabel = new DXLabel
            {
                Parent = this,
                Text = "包裹还有 00 空位",
                ForeColour = Color.White,
                Outline = true,
                OutlineColour = Color.Black,
                IsControl = false,
                Location = new Point(100, 428)
            };

            InventoryGrid = new DXItemGrid
            {
                GridSize = new Size(5, 10),
                Parent = this,
                GridType = GridType.CompanionInventory,
                Location = new Point(265, 80),
                Visible = false,
            };

            EquipmentGrid = new DXItemCell[CartoonGlobals.CompanionEquipmentSize];
            DXItemCell cell;
            EquipmentGrid[(int)CompanionSlot.Bag] = cell = new DXItemCell
            {
                Location = new Point(ClientArea.X + 189, ClientArea.Y + 71),
                Parent = this,
                FixedBorder = true,
                Border = true,
                Slot = (int)CompanionSlot.Bag,
                GridType = GridType.CompanionEquipment,
            };
            cell.BeforeDraw += (o, e) => Draw((DXItemCell)o, 99);

            EquipmentGrid[(int)CompanionSlot.Head] = cell = new DXItemCell
            {
                Location = new Point(ClientArea.X + 189, ClientArea.Y + 112),
                Parent = this,
                FixedBorder = true,
                Border = true,
                Slot = (int)CompanionSlot.Head,
                GridType = GridType.CompanionEquipment,
            };
            cell.BeforeDraw += (o, e) => Draw((DXItemCell)o, 100);

            EquipmentGrid[(int)CompanionSlot.Back] = cell = new DXItemCell
            {
                Location = new Point(ClientArea.X + 189, ClientArea.Y + 156),
                Parent = this,
                FixedBorder = true,
                Border = true,
                Slot = (int)CompanionSlot.Back,
                GridType = GridType.CompanionEquipment,
            };
            cell.BeforeDraw += (o, e) => Draw((DXItemCell)o, 101);

            EquipmentGrid[(int)CompanionSlot.Food] = cell = new DXItemCell
            {
                Location = new Point(ClientArea.X + 188, ClientArea.Y + 197),
                Parent = this,
                FixedBorder = true,
                Border = true,
                Slot = (int)CompanionSlot.Food,
                GridType = GridType.CompanionEquipment,
            };
            cell.BeforeDraw += (o, e) => Draw((DXItemCell)o, 102);

            DXCheckBox PickUpCheckBox = new DXCheckBox
            {
                Parent = this,
                Label = { Text = "拾取物品:" },
                Visible = false
            };
            PickUpCheckBox.Location = new Point(ClientArea.Right - PickUpCheckBox.Size.Width + 3, ClientArea.Y + 45);

            AddMemberPanel = new DXControl
            {
                Parent = this,
                Location = new Point(253, 65),
                Size = new Size((Size.Width + 24) / 2, 400),
                
                
            };

            ScrollBar = new DXMirScrollBar
            {
                Size = new Size(16, 200),
                Location = new Point(Size.Width - 26, 0),
                VisibleSize = 180,
                Parent = this,
                Change = 100,
                Visible = false
            };
            ScrollBar.ValueChanged += (o, e) => UpdateScrollBar();

            MouseWheel += ScrollBar.DoMouseWheel;

            /*
            new DXLabel
            {
                AutoSize = false,
                Parent = this,
                Outline = true,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Bold),
                ForeColour = Color.FromArgb(198, 166, 99),
                OutlineColour = Color.Black,
                IsControl = false,
                Text = "Abilities",
                Location = new Point(ClientArea.X + 196, CompanionDisplayPoint.Y - 20),
                Size = new Size(156, 20),
                DrawFormat = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter,
            };
            */

            DXLabel label = new DXLabel
            {
                Parent = AddMemberPanel,
                Outline = true,
                
                ForeColour = Color.FromArgb(198, 166, 99),
                OutlineColour = Color.Black,
                IsControl = false,
                Text = "宠物等级 3级技能",
            };
            label.Location = new Point(60, 15);
            
            

            Level3Label = new DXLabel
            {
                Parent = AddMemberPanel,
                ForeColour = Color.White,
                Outline = true,
                OutlineColour = Color.Black,
                IsControl = false,
                Location = new Point(60, 36),
                Text = "无法使用"
            };
            
            

            Level3ImgIndex = new DXImageControl
            {
                LibraryFile = LibraryFile.GameInter,
                Index = 4430,
                Parent = AddMemberPanel,
                Location = new Point(16, 14),
            };

            Level3Maxzhi = new DXImageControl
            {
                LibraryFile = LibraryFile.GameInter2,
                Index = 13,
                Parent = AddMemberPanel,
                Location = new Point(174, 13),
                Visible = false,
            };

            label = new DXLabel
            {
                Parent = AddMemberPanel,
                Outline = true,
                
                ForeColour = Color.FromArgb(198, 166, 99),
                OutlineColour = Color.Black,
                IsControl = false,
                Text = "宠物等级 5级技能",
                
            };
            label.Location = new Point(60, 71);
            
            

            Level5Label = new DXLabel
            {
                Parent = AddMemberPanel,
                ForeColour = Color.White,
                Outline = true,
                OutlineColour = Color.Black,
                IsControl = false,
                Location = new Point(60, 93),
                Text = "无法使用",
                
            };
            
            

            Level5ImgIndex = new DXImageControl
            {
                LibraryFile = LibraryFile.GameInter,
                Index = 4430,
                Parent = AddMemberPanel,
                Location = new Point(16, 71),
            };

            Level5Maxzhi = new DXImageControl
            {
                LibraryFile = LibraryFile.GameInter2,
                Index = 13,
                Parent = AddMemberPanel,
                Location = new Point(174, 70),
                Visible = false,
            };

            label = new DXLabel
            {
                Parent = AddMemberPanel,
                Outline = true,
                
                ForeColour = Color.FromArgb(198, 166, 99),
                OutlineColour = Color.Black,
                IsControl = false,
                Text = "宠物等级 7级技能",
                
            };
            label.Location = new Point(60, 129);
            
            

            Level7Label = new DXLabel
            {
                Parent = AddMemberPanel,
                ForeColour = Color.White,
                Outline = true,
                OutlineColour = Color.Black,
                IsControl = false,
                Location = new Point(60, 150),
                Text = "无法使用",
                
            };
            
            

            Level7ImgIndex = new DXImageControl
            {
                LibraryFile = LibraryFile.GameInter,
                Index = 4430,
                Parent = AddMemberPanel,
                Location = new Point(16, 128),
            };

            Level7Maxzhi = new DXImageControl
            {
                LibraryFile = LibraryFile.GameInter2,
                Index = 13,
                Parent = AddMemberPanel,
                Location = new Point(174, 127),
                Visible = false,
            };

            label = new DXLabel
            {
                Parent = AddMemberPanel,
                Outline = true,
                
                ForeColour = Color.FromArgb(198, 166, 99),
                OutlineColour = Color.Black,
                IsControl = false,
                Text = "宠物等级10级技能",
                
            };
            label.Location = new Point(60, 186);
            
            

            Level10Label = new DXLabel
            {
                Parent = AddMemberPanel,
                ForeColour = Color.White,
                Outline = true,
                OutlineColour = Color.Black,
                IsControl = false,
                Location = new Point(60, 207),
                Text = "无法使用",
                
            };
            
            

            Level10ImgIndex = new DXImageControl
            {
                LibraryFile = LibraryFile.GameInter,
                Index = 4430,
                Parent = AddMemberPanel,
                Location = new Point(16, 185),
            };

            Level10Maxzhi = new DXImageControl
            {
                LibraryFile = LibraryFile.GameInter2,
                Index = 13,
                Parent = AddMemberPanel,
                Location = new Point(174, 184),
                Visible = false,
            };

            label = new DXLabel
            {
                Parent = AddMemberPanel,
                Outline = true,
                
                ForeColour = Color.FromArgb(198, 166, 99),
                OutlineColour = Color.Black,
                IsControl = false,
                Text = "宠物等级11级技能",
                
            };
            label.Location = new Point(60, 243);
            
            

            Level11Label = new DXLabel
            {
                Parent = AddMemberPanel,
                ForeColour = Color.White,
                Outline = true,
                OutlineColour = Color.Black,
                IsControl = false,
                Location = new Point(60, 264),
                Text = "无法使用",
                
            };
            
            

            Level11ImgIndex = new DXImageControl
            {
                LibraryFile = LibraryFile.GameInter,
                Index = 4430,
                Parent = AddMemberPanel,
                Location = new Point(16, 242),
            };

            Level11Maxzhi = new DXImageControl
            {
                LibraryFile = LibraryFile.GameInter2,
                Index = 13,
                Parent = AddMemberPanel,
                Location = new Point(174, 241),
                Visible = false,
            };

            label = new DXLabel
            {
                Parent = AddMemberPanel,
                Outline = true,
                
                ForeColour = Color.FromArgb(198, 166, 99),
                OutlineColour = Color.Black,
                IsControl = false,
                Text = "宠物等级13级技能",
                
            };
            label.Location = new Point(60, 299);
            
            

            Level13Label = new DXLabel
            {
                Parent = AddMemberPanel,
                ForeColour = Color.White,
                Outline = true,
                OutlineColour = Color.Black,
                IsControl = false,
                Location = new Point(60, 321),
                Text = "无法使用",
                
            };
            
            

            Level13ImgIndex = new DXImageControl
            {
                LibraryFile = LibraryFile.GameInter,
                Index = 4430,
                Parent = AddMemberPanel,
                Location = new Point(16, 298),
            };

            Level13Maxzhi = new DXImageControl
            {
                LibraryFile = LibraryFile.GameInter2,
                Index = 13,
                Parent = AddMemberPanel,
                Location = new Point(174, 298),
                Visible = false,
            };

            label = new DXLabel
            {
                Parent = AddMemberPanel,
                Outline = true,
                
                ForeColour = Color.FromArgb(198, 166, 99),
                OutlineColour = Color.Black,
                IsControl = false,
                Text = "宠物等级15级技能",
                
            };
            label.Location = new Point(60, 356);
            
            

            Level15Label = new DXLabel
            {
                Parent = AddMemberPanel,
                ForeColour = Color.White,
                Outline = true,
                OutlineColour = Color.Black,
                IsControl = false,
                Location = new Point(60, 378),
                Text = "无法使用",
                
            };
            
            

            Level15ImgIndex = new DXImageControl
            {
                LibraryFile = LibraryFile.GameInter,
                Index = 4430,
                Parent = AddMemberPanel,
                Location = new Point(16, 355),
            };

            Level15Maxzhi = new DXImageControl
            {
                LibraryFile = LibraryFile.GameInter2,
                Index = 13,
                Parent = AddMemberPanel,
                Location = new Point(174, 355),
                Visible = false,
            };

            label = new DXLabel
            {
                Parent = AddMemberPanel,
                Outline = true,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Bold),
                ForeColour = Color.FromArgb(198, 166, 99),
                OutlineColour = Color.Black,
                IsControl = false,
                Text = "等级 17",
                Visible = false
            };
            label.Location = new Point(60 - label.Size.Width, CompanionDisplayPoint.Y + 100);
            
            

            Level17Label = new DXLabel
            {
                Parent = AddMemberPanel,
                ForeColour = Color.White,
                Outline = true,
                OutlineColour = Color.Black,
                IsControl = false,
                Location = new Point(60, CompanionDisplayPoint.Y + 103),
                Text = "无法使用",
                Visible = false
            };
            
            

            label = new DXLabel
            {
                Parent = AddMemberPanel,
                Outline = true,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Bold),
                ForeColour = Color.FromArgb(198, 166, 99),
                OutlineColour = Color.Black,
                IsControl = false,
                Text = "等级 20",
                Visible = false
            };
            label.Location = new Point(60 - label.Size.Width, CompanionDisplayPoint.Y + 120);
            
            

            Level20Label = new DXLabel
            {
                Parent = AddMemberPanel,
                ForeColour = Color.White,
                Outline = true,
                OutlineColour = Color.Black,
                IsControl = false,
                Location = new Point(60, CompanionDisplayPoint.Y + 123),
                Text = "无法使用",
                Visible = false
            };
            
            

            label = new DXLabel
            {
                Parent = AddMemberPanel,
                Outline = true,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Bold),
                ForeColour = Color.FromArgb(198, 166, 99),
                OutlineColour = Color.Black,
                IsControl = false,
                Text = "等级 23",
                Visible = false
            };
            label.Location = new Point(60 - label.Size.Width, CompanionDisplayPoint.Y + 140);
            
            

            Level23Label = new DXLabel
            {
                Parent = AddMemberPanel,
                ForeColour = Color.White,
                Outline = true,
                OutlineColour = Color.Black,
                IsControl = false,
                Location = new Point(60, CompanionDisplayPoint.Y + 143),
                Text = "无法使用",
                Visible = false
            };
            
            

            label = new DXLabel
            {
                Parent = AddMemberPanel,
                Outline = true,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Bold),
                ForeColour = Color.FromArgb(198, 166, 99),
                OutlineColour = Color.Black,
                IsControl = false,
                Text = "等级 25",
                Visible = false
            };
            label.Location = new Point(60 - label.Size.Width, CompanionDisplayPoint.Y + 160);
            
            

            Level25Label = new DXLabel
            {
                Parent = AddMemberPanel,
                ForeColour = Color.White,
                Outline = true,
                OutlineColour = Color.Black,
                IsControl = false,
                Location = new Point(60, CompanionDisplayPoint.Y + 163),
                Text = "无法使用",
                Visible = false
            };
            
            

            label = new DXLabel
            {
                Parent = AddMemberPanel,
                Outline = true,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Bold),
                ForeColour = Color.FromArgb(198, 166, 99),
                OutlineColour = Color.Black,
                IsControl = false,
                Text = "等级 27",
                Visible = false
            };
            label.Location = new Point(60 - label.Size.Width, CompanionDisplayPoint.Y + 180);
            
            

            Level27Label = new DXLabel
            {
                Parent = AddMemberPanel,
                ForeColour = Color.White,
                Outline = true,
                OutlineColour = Color.Black,
                IsControl = false,
                Location = new Point(60, CompanionDisplayPoint.Y + 183),
                Text = "无法使用",
                Visible = false
            };
            
            

            label = new DXLabel
            {
                Parent = AddMemberPanel,
                Outline = true,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Bold),
                ForeColour = Color.FromArgb(198, 166, 99),
                OutlineColour = Color.Black,
                IsControl = false,
                Text = "等级 30",
                Visible = false
            };
            label.Location = new Point(60 - label.Size.Width, CompanionDisplayPoint.Y + 200);
            
            

            Level30Label = new DXLabel
            {
                Parent = AddMemberPanel,
                ForeColour = Color.White,
                Outline = true,
                OutlineColour = Color.Black,
                IsControl = false,
                Location = new Point(60, CompanionDisplayPoint.Y + 203),
                Text = "无法使用",
                Visible = false
            };
            
            

            label = new DXLabel
            {
                Parent = AddMemberPanel,
                Outline = true,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Bold),
                ForeColour = Color.FromArgb(198, 166, 99),
                OutlineColour = Color.Black,
                IsControl = false,
                Text = "等级 33",
                Visible = false
            };
            label.Location = new Point(60 - label.Size.Width, CompanionDisplayPoint.Y + 220);
            
            

            Level33Label = new DXLabel
            {
                Parent = AddMemberPanel,
                ForeColour = Color.White,
                Outline = true,
                OutlineColour = Color.Black,
                IsControl = false,
                Location = new Point(60, CompanionDisplayPoint.Y + 223),
                Text = "无法使用",
                Visible = false
            };
            
            

            label = new DXLabel
            {
                Parent = AddMemberPanel,
                Outline = true,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Bold),
                ForeColour = Color.FromArgb(198, 166, 99),
                OutlineColour = Color.Black,
                IsControl = false,
                Text = "等级 35",
                Visible = false
            };
            label.Location = new Point(60 - label.Size.Width, CompanionDisplayPoint.Y + 240);
            
            

            Level35Label = new DXLabel
            {
                Parent = AddMemberPanel,
                ForeColour = Color.White,
                Outline = true,
                OutlineColour = Color.Black,
                IsControl = false,
                Location = new Point(60, CompanionDisplayPoint.Y + 243),
                Text = "无法使用",
                Visible = false
            };
            
            

            label = new DXLabel
            {
                Parent = AddMemberPanel,
                Outline = true,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Bold),
                ForeColour = Color.FromArgb(198, 166, 99),
                OutlineColour = Color.Black,
                IsControl = false,
                Text = "等级 37",
                Visible = false
            };
            label.Location = new Point(60 - label.Size.Width, CompanionDisplayPoint.Y + 260);
            
            

            Level37Label = new DXLabel
            {
                Parent = AddMemberPanel,
                ForeColour = Color.White,
                Outline = true,
                OutlineColour = Color.Black,
                IsControl = false,
                Location = new Point(60, CompanionDisplayPoint.Y + 263),
                Text = "无法使用",
                Visible = false
            };
            
            

            label = new DXLabel
            {
                Parent = AddMemberPanel,
                Outline = true,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Bold),
                ForeColour = Color.FromArgb(198, 166, 99),
                OutlineColour = Color.Black,
                IsControl = false,
                Text = "等级 40",
                Visible = false
            };
            label.Location = new Point(60 - label.Size.Width, CompanionDisplayPoint.Y + 280);
            
            

            Level40Label = new DXLabel
            {
                Parent = AddMemberPanel,
                ForeColour = Color.White,
                Outline = true,
                OutlineColour = Color.Black,
                IsControl = false,
                Location = new Point(60, CompanionDisplayPoint.Y + 283),
                Text = "无法使用",
                Visible = false
            };
            
            

            HuangjinCompanion = new DXImageControl
            {
                LibraryFile = LibraryFile.GameInter2,
                Index = 14,
                Parent = this,
                Location = new Point(30, 85),
                Visible = false,
            };

            UpdateScrollBar();

            NameLabel = new DXLabel
            {
                Parent = this,
                ForeColour = Color.White,
                Outline = true,
                OutlineColour = Color.Black,
                IsControl = false,
                Location = new Point(CompanionDisplayPoint.X, CompanionDisplayPoint.Y + 84)
            };

            label = new DXLabel
            {
                Parent = this,
                Outline = true,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Bold),
                ForeColour = Color.FromArgb(198, 166, 99),
                OutlineColour = Color.Black,
                IsControl = false,
                Text = "名字",
                Visible = false
            };
            label.Location = new Point(CompanionDisplayPoint.X + 30 - label.Size.Width, CompanionDisplayPoint.Y + 80);

            ChenghaoLabel = new DXLabel
            {
                Parent = this,
                ForeColour = Color.White,
                Outline = true,
                OutlineColour = Color.Black,
                IsControl = false,
                Location = new Point(CompanionDisplayPoint.X, CompanionDisplayPoint.Y + 106)
            };

            label = new DXLabel
            {
                Parent = this,
                Outline = true,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Bold),
                ForeColour = Color.FromArgb(198, 166, 99),
                OutlineColour = Color.Black,
                IsControl = false,
                Text = "称号",
                Visible = false
            };
            label.Location = new Point(CompanionDisplayPoint.X + 30 - label.Size.Width, CompanionDisplayPoint.Y + 60);


            LevelLabel = new DXLabel
            {
                Parent = this,
                ForeColour = Color.White,
                Outline = true,
                OutlineColour = Color.Black,
                IsControl = false,
                Location = new Point(CompanionDisplayPoint.X, CompanionDisplayPoint.Y + 129)
            };

            label = new DXLabel
            {
                Parent = this,
                Outline = true,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Bold),
                ForeColour = Color.FromArgb(198, 166, 99),
                OutlineColour = Color.Black,
                IsControl = false,
                Text = "等级",
                Visible = false
            };
            label.Location = new Point(CompanionDisplayPoint.X + 30 - label.Size.Width, CompanionDisplayPoint.Y + 80);

            ExperienceBar = new DXImageControl
            {
                Parent = this,
                LibraryFile = LibraryFile.GameInter,
                Index = 4309,
            };
            ExperienceBar.Location = new Point(CompanionDisplayPoint.X + 32 - label.Size.Width, CompanionDisplayPoint.Y + 151);

            ExperienceBar.AfterDraw += (o, e) =>
            {
                if (ExperienceBar.Library == null) return;

                CompanionLevelInfo info = CartoonGlobals.CompanionLevelInfoList.Binding.First(m => m.Level == GameScene.Game.Companion.Level);

                decimal MaxExperience = info.MaxExperience;

                if (MaxExperience == 0) return;

                
                MirImage image = ExperienceBar.Library.CreateImage(4310, ImageType.Image);

                if (image == null) return;

                int x = (ExperienceBar.Size.Width - image.Width) / 2;
                int y = (ExperienceBar.Size.Height - image.Height) / 2;


                float percent = (float)Math.Min(1, Math.Max(0, GameScene.Game.Companion.Experience / MaxExperience));

                if (percent == 0) return;



                PresentTexture(image.Image, this, new Rectangle(ExperienceBar.DisplayArea.X + x, ExperienceBar.DisplayArea.Y + y - 1, (int)(image.Width * percent), image.Height), Color.White, ExperienceBar);
            };
            ExperienceLabel = new DXLabel
            {
                Parent = this,
                ForeColour = Color.White,
                Outline = true,
                OutlineColour = Color.Black,
                IsControl = false,
                Location = new Point(CompanionDisplayPoint.X + 50, CompanionDisplayPoint.Y + 151)
            };

            label = new DXLabel
            {
                Parent = this,
                Outline = true,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Bold),
                ForeColour = Color.FromArgb(198, 166, 99),
                OutlineColour = Color.Black,
                IsControl = false,
                Text = "经验",
                Visible = false
            };
            label.Location = new Point(CompanionDisplayPoint.X + 30 - label.Size.Width, CompanionDisplayPoint.Y + 100);

            EduBar = new DXImageControl
            {
                Parent = this,
                LibraryFile = LibraryFile.GameInter,
                Index = 4309,
                
            };
            EduBar.Location = new Point(CompanionDisplayPoint.X + 32 - label.Size.Width, CompanionDisplayPoint.Y + 173);
            EduBar.AfterDraw += (o, e) =>
            {
                if (EduBar.Library == null) return;

                CompanionLevelInfo info = CartoonGlobals.CompanionLevelInfoList.Binding.First(m => m.Level == GameScene.Game.Companion.Level);

                decimal MaxHunger = info.MaxHunger;

                if (MaxHunger == 0) return;

                
                MirImage image = EduBar.Library.CreateImage(4311, ImageType.Image);

                if (image == null) return;

                int x = (EduBar.Size.Width - image.Width) / 2;
                int y = (EduBar.Size.Height - image.Height) / 2;


                float percent = (float)Math.Min(1, Math.Max(0, GameScene.Game.Companion.Hunger / MaxHunger));

                if (percent == 0) return;



                PresentTexture(image.Image, this, new Rectangle(EduBar.DisplayArea.X + x, EduBar.DisplayArea.Y + y - 1, (int)(image.Width * percent), image.Height), Color.White, EduBar);
            };

            HungerLabel = new DXLabel
            {
                Parent = this,
                ForeColour = Color.White,
                Outline = true,
                OutlineColour = Color.Black,
                IsControl = false,
                Location = new Point(CompanionDisplayPoint.X + 45, CompanionDisplayPoint.Y + 172)
            };

            label = new DXLabel
            {
                Parent = this,
                Outline = true,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Bold),
                ForeColour = Color.FromArgb(198, 166, 99),
                OutlineColour = Color.Black,
                IsControl = false,
                Text = "饥饿",
                Visible = false
            };
            label.Location = new Point(CompanionDisplayPoint.X + 30 - label.Size.Width, CompanionDisplayPoint.Y + 120);

            FuzhongBar = new DXImageControl
            {
                Parent = this,
                LibraryFile = LibraryFile.GameInter,
                Index = 4309,
                
            };
            FuzhongBar.Location = new Point(CompanionDisplayPoint.X + 32 - label.Size.Width, CompanionDisplayPoint.Y + 196);
            FuzhongBar.AfterDraw += (o, e) =>
            {
                if (FuzhongBar.Library == null) return;

                if (MaxBagWeight == 0) return;

                
                MirImage image = FuzhongBar.Library.CreateImage(4312, ImageType.Image);

                if (image == null) return;

                int x = (FuzhongBar.Size.Width - image.Width) / 2;
                int y = (FuzhongBar.Size.Height - image.Height) / 2;


                float percent = (float)Math.Min(1, Math.Max(0, BagWeight / (float)MaxBagWeight));

                if (percent == 0) return;



                PresentTexture(image.Image, this, new Rectangle(FuzhongBar.DisplayArea.X + x, FuzhongBar.DisplayArea.Y + y - 1, (int)(image.Width * percent), image.Height), Color.White, FuzhongBar);
            };

            WeightLabel = new DXLabel
            {
                Parent = this,
                ForeColour = Color.White,
                Outline = true,
                OutlineColour = Color.Black,
                IsControl = false,
                Location = new Point(CompanionDisplayPoint.X + 45, CompanionDisplayPoint.Y + 194)
            };

            label = new DXLabel
            {
                Parent = this,
                Outline = true,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Bold),
                ForeColour = Color.FromArgb(198, 166, 99),
                OutlineColour = Color.Black,
                IsControl = false,
                Text = "负重",
                Visible = false
            };
            label.Location = new Point(CompanionDisplayPoint.X + 30, CompanionDisplayPoint.Y + 140);
        }

        #region Methods
        private void WindowMove(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }
        public void CompanionChanged()
        {
            if (GameScene.Game.Companion == null)
            {
                Visible = false;
                return;
            }

            InventoryGrid.ItemGrid = GameScene.Game.Companion.InventoryArray;

            foreach (DXItemCell cell in EquipmentGrid)
                cell.ItemGrid = GameScene.Game.Companion.EquipmentArray;

            CompanionDisplay = new MonsterObject(GameScene.Game.Companion.CompanionInfo);
            NameLabel.Text = GameScene.Game.Companion.Name;

            Refresh();

        }

        public void UpdateScrollBar()
        {
            ScrollBar.MaxValue = Lines.Count * 10;

            
            

            for (int i = 1; i < Lines.Count; i += 2)
                Lines[i].Location = new Point(Lines[i].Location.X, i * 10 - ScrollBar.Value - 7);

            for (int j = 0; j < Lines.Count; j += 2)
                Lines[j].Location = new Point(Lines[j].Location.X, j * 10 - ScrollBar.Value);

        }

        public void Draw(DXItemCell cell, int index)
        {
            if (InterfaceLibrary == null) return;

            if (cell.Item != null) return;

            Size s = InterfaceLibrary.GetSize(index);
            int x = (cell.Size.Width - s.Width) / 2 + cell.DisplayArea.X;
            int y = (cell.Size.Height - s.Height) / 2 + cell.DisplayArea.Y;

            InterfaceLibrary.Draw(index, x, y, Color.White, false, 0.2F, ImageType.Image);
        }

        public override void Process()
        {
            base.Process();

            CompanionDisplay?.Process();
        }

        protected override void OnAfterDraw()
        {
            base.OnAfterDraw();


            if (CompanionDisplay == null) return;

            int x = DisplayArea.X + CompanionDisplayPoint.X;
            int y = DisplayArea.Y + CompanionDisplayPoint.Y;

            if (CompanionDisplay.Image == MonsterImage.Companion_Donkey)
            {
                x += 10;
                y -= 5;
            }


            CompanionDisplay.DrawShadow(x, y);
            CompanionDisplay.DrawBody(x, y);
        }

        public void Refresh()
        {
            if (GameScene.Game.Companion.Rebirth == 0)
                ChenghaoLabel.Text = "修炼者";
            else if (GameScene.Game.Companion.Rebirth == 1)
                ChenghaoLabel.Text = "炼者";
            else if (GameScene.Game.Companion.Rebirth == 2)
                ChenghaoLabel.Text = "灵徒";
            else if (GameScene.Game.Companion.Rebirth == 3)
                ChenghaoLabel.Text = "灵使";
            else if (GameScene.Game.Companion.Rebirth == 4)
                ChenghaoLabel.Text = "灵者";
            else if (GameScene.Game.Companion.Rebirth == 5)
                ChenghaoLabel.Text = "灵师";

            LevelLabel.Text = GameScene.Game.Companion.Level.ToString();

            CompanionLevelInfo info = CartoonGlobals.CompanionLevelInfoList.Binding.First(x => x.Level == GameScene.Game.Companion.Level);

            ExperienceLabel.Text = info.MaxExperience > 0 ? $"{GameScene.Game.Companion.Experience / (decimal)info.MaxExperience:p2}" : "100%";

            HungerLabel.Text = $"{GameScene.Game.Companion.Hunger} / {info.MaxHunger}";

            WeightLabel.Text = $"{BagWeight} / {MaxBagWeight}";

            WeightLabel.ForeColour = BagWeight >= MaxBagWeight ? Color.Red : Color.White;

            Level3Label.Text = GameScene.Game.Companion.Level3 == null ? "暂无属性" : GameScene.Game.Companion.Level3.GetDisplay(GameScene.Game.Companion.Level3.Values.Keys.First());

            Level3ImgIndex.Index = GameScene.Game.Companion.ImgIndex3 == 0 ? 4430 : GameScene.Game.Companion.ImgIndex3;

            Level3Maxzhi.Visible = GameScene.Game.Companion.Maxzhi3;

            Level5Label.Text = GameScene.Game.Companion.Level5 == null ? "暂无属性" : GameScene.Game.Companion.Level5.GetDisplay(GameScene.Game.Companion.Level5.Values.Keys.First());

            Level5ImgIndex.Index = GameScene.Game.Companion.ImgIndex5 == 0 ? 4430 : GameScene.Game.Companion.ImgIndex5;

            Level5Maxzhi.Visible = GameScene.Game.Companion.Maxzhi5;

            Level7Label.Text = GameScene.Game.Companion.Level7 == null ? "暂无属性" : GameScene.Game.Companion.Level7.GetDisplay(GameScene.Game.Companion.Level7.Values.Keys.First());

            Level7ImgIndex.Index = GameScene.Game.Companion.ImgIndex7 == 0 ? 4430 : GameScene.Game.Companion.ImgIndex7;

            Level7Maxzhi.Visible = GameScene.Game.Companion.Maxzhi7;

            Level10Label.Text = GameScene.Game.Companion.Level10 == null ? "暂无属性" : GameScene.Game.Companion.Level10.GetDisplay(GameScene.Game.Companion.Level10.Values.Keys.First());

            Level10ImgIndex.Index = GameScene.Game.Companion.ImgIndex10 == 0 ? 4430 : GameScene.Game.Companion.ImgIndex10;

            Level10Maxzhi.Visible = GameScene.Game.Companion.Maxzhi10;

            Level11Label.Text = GameScene.Game.Companion.Level11 == null ? "暂无属性" : GameScene.Game.Companion.Level11.GetDisplay(GameScene.Game.Companion.Level11.Values.Keys.First());

            Level11ImgIndex.Index = GameScene.Game.Companion.ImgIndex11 == 0 ? 4430 : GameScene.Game.Companion.ImgIndex11;

            Level11Maxzhi.Visible = GameScene.Game.Companion.Maxzhi11;

            Level13Label.Text = GameScene.Game.Companion.Level13 == null ? "暂无属性" : GameScene.Game.Companion.Level13.GetDisplay(GameScene.Game.Companion.Level13.Values.Keys.First());

            Level13ImgIndex.Index = GameScene.Game.Companion.ImgIndex13 == 0 ? 4430 : GameScene.Game.Companion.ImgIndex13;

            Level13Maxzhi.Visible = GameScene.Game.Companion.Maxzhi13;

            Level15Label.Text = GameScene.Game.Companion.Level15 == null ? "暂无属性" : GameScene.Game.Companion.Level15.GetDisplay(GameScene.Game.Companion.Level15.Values.Keys.First());

            Level15ImgIndex.Index = GameScene.Game.Companion.ImgIndex15 == 0 ? 4430 : GameScene.Game.Companion.ImgIndex15;

            Level15Maxzhi.Visible = GameScene.Game.Companion.Maxzhi15;

            Level17Label.Text = GameScene.Game.Companion.Level17 == null ? "暂无属性" : GameScene.Game.Companion.Level17.GetDisplay(GameScene.Game.Companion.Level17.Values.Keys.First());

            Level20Label.Text = GameScene.Game.Companion.Level20 == null ? "暂无属性" : GameScene.Game.Companion.Level20.GetDisplay(GameScene.Game.Companion.Level20.Values.Keys.First());

            Level23Label.Text = GameScene.Game.Companion.Level23 == null ? "暂无属性" : GameScene.Game.Companion.Level23.GetDisplay(GameScene.Game.Companion.Level23.Values.Keys.First());

            Level25Label.Text = GameScene.Game.Companion.Level25 == null ? "暂无属性" : GameScene.Game.Companion.Level25.GetDisplay(GameScene.Game.Companion.Level25.Values.Keys.First());

            Level27Label.Text = GameScene.Game.Companion.Level27 == null ? "暂无属性" : GameScene.Game.Companion.Level27.GetDisplay(GameScene.Game.Companion.Level27.Values.Keys.First());

            Level30Label.Text = GameScene.Game.Companion.Level30 == null ? "暂无属性" : GameScene.Game.Companion.Level30.GetDisplay(GameScene.Game.Companion.Level30.Values.Keys.First());

            Level33Label.Text = GameScene.Game.Companion.Level33 == null ? "暂无属性" : GameScene.Game.Companion.Level33.GetDisplay(GameScene.Game.Companion.Level33.Values.Keys.First());

            Level35Label.Text = GameScene.Game.Companion.Level35 == null ? "暂无属性" : GameScene.Game.Companion.Level35.GetDisplay(GameScene.Game.Companion.Level35.Values.Keys.First());

            Level37Label.Text = GameScene.Game.Companion.Level37 == null ? "暂无属性" : GameScene.Game.Companion.Level37.GetDisplay(GameScene.Game.Companion.Level37.Values.Keys.First());

            Level40Label.Text = GameScene.Game.Companion.Level40 == null ? "暂无属性" : GameScene.Game.Companion.Level40.GetDisplay(GameScene.Game.Companion.Level40.Values.Keys.First());

            if (GameScene.Game.Companion.Maxzhi3 && GameScene.Game.Companion.Maxzhi5 && GameScene.Game.Companion.Maxzhi7
                && GameScene.Game.Companion.Maxzhi10 && GameScene.Game.Companion.Maxzhi11 && GameScene.Game.Companion.Maxzhi13
                && GameScene.Game.Companion.Maxzhi15)
                HuangjinCompanion.Visible = true;
            else
                HuangjinCompanion.Visible = false;

            for (int i = 0; i < InventoryGrid.Grid.Length; i++)
                InventoryGrid.Grid[i].Enabled = i < InventorySize;

            GameScene.Game.MainPanel.CompanionWeightBar.Hint = $"　　{BagWeight} / {MaxBagWeight}";

            HasSpaceLabel.Text = "包裹还有 " + HasSpace.ToString() + " 空间";
        }
        #endregion

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                CompanionDisplay = null;
                CompanionDisplayPoint = Point.Empty;

                if (EquipmentGrid != null)
                {
                    for (int i = 0; i < EquipmentGrid.Length; i++)
                    {
                        if (EquipmentGrid[i] != null)
                        {
                            if (!EquipmentGrid[i].IsDisposed)
                                EquipmentGrid[i].Dispose();

                            EquipmentGrid[i] = null;
                        }
                    }

                    EquipmentGrid = null;
                }

                if (InventoryGrid != null)
                {
                    if (!InventoryGrid.IsDisposed)
                        InventoryGrid.Dispose();

                    InventoryGrid = null;
                }

                if (WeightLabel != null)
                {
                    if (!WeightLabel.IsDisposed)
                        WeightLabel.Dispose();

                    WeightLabel = null;
                }

                if (HungerLabel != null)
                {
                    if (!HungerLabel.IsDisposed)
                        HungerLabel.Dispose();

                    HungerLabel = null;
                }

                if (NameLabel != null)
                {
                    if (!NameLabel.IsDisposed)
                        NameLabel.Dispose();

                    NameLabel = null;
                }

                if (ChenghaoLabel != null)
                {
                    if (!ChenghaoLabel.IsDisposed)
                        ChenghaoLabel.Dispose();

                    ChenghaoLabel = null;
                }

                if (LevelLabel != null)
                {
                    if (!LevelLabel.IsDisposed)
                        LevelLabel.Dispose();

                    LevelLabel = null;
                }

                if (ExperienceLabel != null)
                {
                    if (!ExperienceLabel.IsDisposed)
                        ExperienceLabel.Dispose();

                    ExperienceLabel = null;
                }

                if (Level3Label != null)
                {
                    if (!Level3Label.IsDisposed)
                        Level3Label.Dispose();

                    Level3Label = null;
                }

                if (Level5Label != null)
                {
                    if (!Level5Label.IsDisposed)
                        Level5Label.Dispose();

                    Level5Label = null;
                }

                if (Level7Label != null)
                {
                    if (!Level7Label.IsDisposed)
                        Level7Label.Dispose();

                    Level7Label = null;
                }

                if (Level10Label != null)
                {
                    if (!Level10Label.IsDisposed)
                        Level10Label.Dispose();

                    Level10Label = null;
                }

                if (Level11Label != null)
                {
                    if (!Level11Label.IsDisposed)
                        Level11Label.Dispose();

                    Level11Label = null;
                }

                if (Level13Label != null)
                {
                    if (!Level13Label.IsDisposed)
                        Level13Label.Dispose();

                    Level13Label = null;
                }

                if (Level15Label != null)
                {
                    if (!Level15Label.IsDisposed)
                        Level15Label.Dispose();

                    Level15Label = null;
                }

                if (Level17Label != null)
                {
                    if (!Level17Label.IsDisposed)
                        Level17Label.Dispose();

                    Level17Label = null;
                }

                if (Level20Label != null)
                {
                    if (!Level20Label.IsDisposed)
                        Level20Label.Dispose();

                    Level20Label = null;
                }

                if (Level23Label != null)
                {
                    if (!Level23Label.IsDisposed)
                        Level23Label.Dispose();

                    Level23Label = null;
                }

                if (Level25Label != null)
                {
                    if (!Level25Label.IsDisposed)
                        Level25Label.Dispose();

                    Level25Label = null;
                }

                if (Level27Label != null)
                {
                    if (!Level27Label.IsDisposed)
                        Level27Label.Dispose();

                    Level27Label = null;
                }

                if (Level30Label != null)
                {
                    if (!Level30Label.IsDisposed)
                        Level30Label.Dispose();

                    Level30Label = null;
                }

                if (Level33Label != null)
                {
                    if (!Level33Label.IsDisposed)
                        Level33Label.Dispose();

                    Level33Label = null;
                }

                if (Level35Label != null)
                {
                    if (!Level35Label.IsDisposed)
                        Level35Label.Dispose();

                    Level35Label = null;
                }

                if (Level37Label != null)
                {
                    if (!Level37Label.IsDisposed)
                        Level37Label.Dispose();

                    Level37Label = null;
                }

                if (Level40Label != null)
                {
                    if (!Level40Label.IsDisposed)
                        Level40Label.Dispose();

                    Level40Label = null;
                }

                if (Level3ImgIndex != null)
                {
                    if (!Level3ImgIndex.IsDisposed)
                        Level3ImgIndex.Dispose();

                    Level3ImgIndex = null;
                }

                if (Level5ImgIndex != null)
                {
                    if (!Level5ImgIndex.IsDisposed)
                        Level5ImgIndex.Dispose();

                    Level5ImgIndex = null;
                }

                if (Level7ImgIndex != null)
                {
                    if (!Level7ImgIndex.IsDisposed)
                        Level7ImgIndex.Dispose();

                    Level7ImgIndex = null;
                }

                if (Level10ImgIndex != null)
                {
                    if (!Level10ImgIndex.IsDisposed)
                        Level10ImgIndex.Dispose();

                    Level10ImgIndex = null;
                }

                if (Level11ImgIndex != null)
                {
                    if (!Level11ImgIndex.IsDisposed)
                        Level11ImgIndex.Dispose();

                    Level11ImgIndex = null;
                }

                if (Level13ImgIndex != null)
                {
                    if (!Level13ImgIndex.IsDisposed)
                        Level13ImgIndex.Dispose();

                    Level13ImgIndex = null;
                }

                if (Level15ImgIndex != null)
                {
                    if (!Level15ImgIndex.IsDisposed)
                        Level15ImgIndex.Dispose();

                    Level15ImgIndex = null;
                }

                if (Level3Maxzhi != null)
                {
                    if (!Level3Maxzhi.IsDisposed)
                        Level3Maxzhi.Dispose();

                    Level3Maxzhi = null;
                }

                if (Level5Maxzhi != null)
                {
                    if (!Level5Maxzhi.IsDisposed)
                        Level5Maxzhi.Dispose();

                    Level5Maxzhi = null;
                }

                if (Level7Maxzhi != null)
                {
                    if (!Level7Maxzhi.IsDisposed)
                        Level7Maxzhi.Dispose();

                    Level7Maxzhi = null;
                }

                if (Level10Maxzhi != null)
                {
                    if (!Level10Maxzhi.IsDisposed)
                        Level10Maxzhi.Dispose();

                    Level10Maxzhi = null;
                }

                if (Level11Maxzhi != null)
                {
                    if (!Level11Maxzhi.IsDisposed)
                        Level11Maxzhi.Dispose();

                    Level11Maxzhi = null;
                }

                if (Level13Maxzhi != null)
                {
                    if (!Level13Maxzhi.IsDisposed)
                        Level13Maxzhi.Dispose();

                    Level13Maxzhi = null;
                }

                if (Level15Maxzhi != null)
                {
                    if (!Level15Maxzhi.IsDisposed)
                        Level15Maxzhi.Dispose();

                    Level15Maxzhi = null;
                }

                if (ModeComboBox != null)
                {
                    if (!ModeComboBox.IsDisposed)
                        ModeComboBox.Dispose();

                    ModeComboBox = null;
                }

                if (ScrollBar != null)
                {
                    if (!ScrollBar.IsDisposed)
                        ScrollBar.Dispose();

                    ScrollBar = null;
                }

                BagWeight = 0;
                MaxBagWeight = 0;
                InventorySize = 0;
            }

        }

        #endregion
    }
}
