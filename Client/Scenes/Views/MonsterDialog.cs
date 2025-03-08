using Client.Controls;
using Client.Envir;
using Client.Models;
using Client.UserModels;
using Library;
using Library.SystemModels;
using SlimDX.Direct3D9;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Client.Scenes.Views
{
    public sealed class MonsterDialog : DXWindow
    {
        private MonsterObject _Monster;
        private bool _Expanded;
        public DXImageControl BackGround;
        public DXImageControl AttackIcon;
        public DXLabel LevelLabel;
        public DXLabel NameLabel;
        public DXLabel HealthLabel;
        public DXLabel ACLabel;
        public DXLabel MRLabel;
        public DXLabel DCLabel;
        public DXLabel MCLabel;
        public DXLabel FireResistLabel;
        public DXLabel IceResistLabel;
        public DXLabel LightningResistLabel;
        public DXLabel WindResistLabel;
        public DXLabel HolyResistLabel;
        public DXLabel DarkResistLabel;
        public DXLabel PhantomResistLabel;
        public DXLabel PhysicalResistLabel;
        public DXButton ExpandButton;
        public int Index01 = 5430;

        public MonsterObject Monster
        {
            get
            {
                return _Monster;
            }
            set
            {
                if (_Monster == value)
                    return;
                MonsterObject monster = _Monster;
                _Monster = value;
                OnMonsterChanged(monster, value);
            }
        }

        public event EventHandler<EventArgs> MonsterChanged;

        public void OnMonsterChanged(MonsterObject oValue, MonsterObject nValue)
        {
            Visible = Monster != null && Config.MonsterBoxVisible;
            if (Monster == null)
                return;

            
            if (Monster.MonsterInfo.IsBoss)
            {
                
                BackGround.Index = 5421;
                Index01 = 5431;
            }
            
            else
            {
                
                BackGround.Index = 5401;
                Index01 = 5430;
            }

            NameLabel.Text = Monster.MonsterInfo.MonsterName;
            LevelLabel.Text = Monster.MonsterInfo.Level.ToString();
            RefreshStats();
            
            EventHandler<EventArgs> monsterChanged = MonsterChanged;
            if (monsterChanged == null)
                return;
            monsterChanged((object)this, EventArgs.Empty);
        }

        public bool Expanded
        {
            get
            {
                return _Expanded;
            }
            set
            {
                if (_Expanded == value)
                    return;
                bool expanded = _Expanded;
                _Expanded = value;
                OnExpandedChanged(expanded, value);
            }
        }

        public event EventHandler<EventArgs> ExpandedChanged;

        public void OnExpandedChanged(bool oValue, bool nValue)
        {
            ExpandButton.Index = Expanded ? 5441 : 5443;
            Size = Expanded ? new Size(Size.Width, 158) : new Size(Size.Width, 64);
            Config.MonsterBoxExpanded = Expanded;
            
            EventHandler<EventArgs> expandedChanged = ExpandedChanged;
            if (expandedChanged == null)
                return;
            expandedChanged((object)this, EventArgs.Empty);
        }

        public override WindowType Type
        {
            get
            {
                return WindowType.MonsterBox;
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

        public MonsterDialog()
        {
            Size = new Size(200, 64);
            Opacity = 0.0f;
            CloseButton.Visible = false;
            HasTitle = false;
            Location = new Point(250, 25);

            DXImageControl dxImageControl1 = new DXImageControl();
            dxImageControl1.Parent = (DXControl)this;
            dxImageControl1.LibraryFile = (LibraryFile)3;
            dxImageControl1.Index = 5401;
            dxImageControl1.ImageOpacity = 0.9f;
            BackGround = dxImageControl1;
            DXControl panel = new DXControl() { Size = Size, Border = false, Opacity = 0.0f, Parent = (DXControl)BackGround };
            DXLabel dxLabel1 = new DXLabel();
            dxLabel1.AutoSize = false;
            dxLabel1.Size = new Size(30, 18);
            dxLabel1.Location = new Point(8, 9);
            dxLabel1.Border = false;
            dxLabel1.Parent = panel;
            dxLabel1.ForeColour = Color.White;
            dxLabel1.DrawFormat = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
            dxLabel1.IsControl = false;
            LevelLabel = dxLabel1;
            DXLabel dxLabel2 = new DXLabel();
            dxLabel2.AutoSize = false;
            dxLabel2.Size = new Size(141, 18);
            Point location = LevelLabel.Location;
            int x1 = location.X + LevelLabel.Size.Width + 4;
            location = LevelLabel.Location;
            int y1 = location.Y;
            dxLabel2.Location = new Point(x1, y1);
            dxLabel2.Border = false;
            dxLabel2.Parent = panel;
            dxLabel2.ForeColour = Color.White;
            dxLabel2.DrawFormat = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
            NameLabel = dxLabel2;
            
            NameLabel.MouseDown += new EventHandler<MouseEventArgs>(WindowMove);

            panel = new DXControl()
            {
                Size = new Size(124, 16),
                Location = new Point(41, 34),
                Border = false,
                Parent = (DXControl)BackGround
            };
            DXLabel dxLabel3 = new DXLabel();
            dxLabel3.AutoSize = false;
            dxLabel3.Size = new Size(121, 20);
            dxLabel3.Location = new Point(41, 31);
            dxLabel3.Border = false;
            dxLabel3.Parent = (DXControl)BackGround;
            dxLabel3.ForeColour = Color.White;
            dxLabel3.DrawFormat = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
            HealthLabel = dxLabel3;
            panel.AfterDraw += (EventHandler<EventArgs>)((o, e) =>
            {
                MirLibrary mirLibrary;
                if (Monster == null || !CEnvir.LibraryList.TryGetValue((LibraryFile)3, out mirLibrary))
                    return;
                ClientObjectData clientObjectData;
                GameScene.Game.DataDictionary.TryGetValue(Monster.ObjectID, out clientObjectData);
                float num = Monster.CompanionObject != null ? 1f : 0.0f;
                if (clientObjectData != null && clientObjectData.MaxHealth > 0)
                    num = Math.Min(1f, Math.Max(0.0f, (float)clientObjectData.Health / (float)clientObjectData.MaxHealth));
                if ((double)num == 0.0)
                    return;
                MirImage image1 = mirLibrary.CreateImage(Index01, ImageType.Image);
                if (image1 == null)
                    return;
                Texture image2 = image1.Image;
                Rectangle displayArea1 = panel.DisplayArea;
                int x2 = displayArea1.X;
                displayArea1 = panel.DisplayArea;
                int y2 = displayArea1.Y + 3;
                int width = (int)((double)image1.Width * (double)num);
                int height = (int)image1.Height;
                Rectangle displayArea2 = new Rectangle(x2, y2, width, height);
                Color white = Color.White;
                DXControl control = panel;
                int offX = 0;
                int offY = 0;
                DXControl.PresentTexture(image2, (DXControl)this, displayArea2, white, control, offX, offY);
            });
            DXControl dxControl1 = new DXControl() { Size = new Size(31, 20), Border = false, Location = new Point(5, 30), Parent = (DXControl)BackGround, Opacity = 0.0f };
            DXImageControl dxImageControl2 = new DXImageControl();
            dxImageControl2.Parent = dxControl1;
            dxImageControl2.LibraryFile = (LibraryFile)3;
            dxImageControl2.Opacity = 0.4f;
            dxImageControl2.Location = new Point(8, 3);
            dxImageControl2.IsControl = false;
            AttackIcon = dxImageControl2;
            DXButton dxButton = new DXButton();
            dxButton.Parent = (DXControl)this;
            dxButton.Location = new Point(175, 37);
            dxButton.LibraryFile = (LibraryFile)3;
            dxButton.Index = 5442;
            ExpandButton = dxButton;
            ExpandButton.MouseEnter += (EventHandler<EventArgs>)((s, e) => ExpandButton.Index = Expanded ? 5441 : 5443);
            ExpandButton.MouseLeave += (EventHandler<EventArgs>)((s, e) => ExpandButton.Index = Expanded ? 5440 : 5442);
            ExpandButton.MouseClick += (EventHandler<MouseEventArgs>)((o, e) => Expanded = !Expanded);
            DXControl dxControl2 = new DXControl() { Size = new Size(Size.Width - 10, 85), Location = new Point(5, 66), Border = false, Parent = (DXControl)BackGround, Opacity = 0.0f };
            DXLabel dxLabel4 = new DXLabel();
            dxLabel4.Parent = dxControl2;
            dxLabel4.IsControl = false;
            dxLabel4.Text = "AC:";
            DXLabel dxLabel5 = dxLabel4;
            dxLabel5.Location = new Point(36 - dxLabel5.Size.Width, 5);
            DXLabel dxLabel6 = new DXLabel();
            dxLabel6.Parent = dxControl2;
            dxLabel6.Location = new Point(36, 5);
            dxLabel6.ForeColour = Color.White;
            ACLabel = dxLabel6;
            DXLabel dxLabel7 = new DXLabel();
            dxLabel7.Parent = dxControl2;
            dxLabel7.IsControl = false;
            dxLabel7.Text = "MR:";
            DXLabel dxLabel8 = dxLabel7;
            dxLabel8.Location = new Point(125 - dxLabel8.Size.Width, 5);
            DXLabel dxLabel9 = new DXLabel();
            dxLabel9.Parent = dxControl2;
            dxLabel9.Location = new Point(125, 5);
            dxLabel9.ForeColour = Color.White;
            MRLabel = dxLabel9;
            DXLabel dxLabel10 = new DXLabel();
            dxLabel10.Parent = dxControl2;
            dxLabel10.IsControl = false;
            dxLabel10.Text = "DC:";
            DXLabel dxLabel11 = dxLabel10;
            dxLabel11.Location = new Point(36 - dxLabel11.Size.Width, 22);
            DXLabel dxLabel12 = new DXLabel();
            dxLabel12.Parent = dxControl2;
            dxLabel12.Location = new Point(36, 22);
            dxLabel12.ForeColour = Color.White;
            DCLabel = dxLabel12;

            DXLabel MCMCLabel = new DXLabel();
            MCMCLabel.Parent = dxControl2;
            MCMCLabel.IsControl = false;
            MCMCLabel.Text = "MC:";
            DXLabel MCLabell = MCMCLabel;
            MCLabell.Location = new Point(125 - MCLabell.Size.Width, 22);

            MCLabel = new DXLabel()
            {
                Parent = dxControl2,
                Location = new Point(125, 22),
                ForeColour = Color.White,
                Text = "0 - 0",
            };

            DXImageControl dxImageControl3 = new DXImageControl();
            dxImageControl3.Parent = dxControl2;
            dxImageControl3.LibraryFile = (LibraryFile)3;
            dxImageControl3.Index = 1510;
            dxImageControl3.Location = new Point(5, 39);
            dxImageControl3.Hint = "火";
            DXImageControl dxImageControl4 = dxImageControl3;
            DXLabel dxLabel13 = new DXLabel();
            dxLabel13.Parent = dxControl2;
            dxLabel13.Location = new Point(dxImageControl4.Location.X + dxImageControl4.Size.Width, 41);
            dxLabel13.Tag = (object)dxImageControl4;
            FireResistLabel = dxLabel13;
            DXImageControl dxImageControl5 = new DXImageControl();
            dxImageControl5.Parent = dxControl2;
            dxImageControl5.LibraryFile = (LibraryFile)3;
            dxImageControl5.Index = 1511;
            dxImageControl5.Location = new Point(dxImageControl4.Location.X + 43, 39);
            dxImageControl5.Hint = "冰";
            DXImageControl dxImageControl6 = dxImageControl5;
            DXLabel dxLabel14 = new DXLabel();
            dxLabel14.Parent = dxControl2;
            dxLabel14.Location = new Point(dxImageControl6.Location.X + dxImageControl6.Size.Width, 41);
            dxLabel14.Tag = (object)dxImageControl6;
            IceResistLabel = dxLabel14;
            DXImageControl dxImageControl7 = new DXImageControl();
            dxImageControl7.Parent = dxControl2;
            dxImageControl7.LibraryFile = (LibraryFile)3;
            dxImageControl7.Index = 1512;
            dxImageControl7.Location = new Point(dxImageControl6.Location.X + 43, 39);
            dxImageControl7.Hint = "雷";
            DXImageControl dxImageControl8 = dxImageControl7;
            DXLabel dxLabel15 = new DXLabel();
            dxLabel15.Parent = dxControl2;
            dxLabel15.Location = new Point(dxImageControl8.Location.X + dxImageControl8.Size.Width, 41);
            dxLabel15.Tag = (object)dxImageControl8;
            LightningResistLabel = dxLabel15;
            DXImageControl dxImageControl9 = new DXImageControl();
            dxImageControl9.Parent = dxControl2;
            dxImageControl9.LibraryFile = (LibraryFile)3;
            dxImageControl9.Index = 1513;
            dxImageControl9.Location = new Point(dxImageControl8.Location.X + 43, 39);
            dxImageControl9.Hint = "风";
            DXImageControl dxImageControl10 = dxImageControl9;
            DXLabel dxLabel16 = new DXLabel();
            dxLabel16.Parent = dxControl2;
            dxLabel16.Location = new Point(dxImageControl10.Location.X + dxImageControl10.Size.Width, 41);
            dxLabel16.Tag = (object)dxImageControl10;
            WindResistLabel = dxLabel16;
            DXImageControl dxImageControl11 = new DXImageControl();
            dxImageControl11.Parent = dxControl2;
            dxImageControl11.LibraryFile = (LibraryFile)3;
            dxImageControl11.Index = 1514;
            dxImageControl11.Location = new Point(5, 63);
            dxImageControl11.Hint = "神圣";
            DXImageControl dxImageControl12 = dxImageControl11;
            DXLabel dxLabel17 = new DXLabel();
            dxLabel17.Parent = dxControl2;
            dxLabel17.Location = new Point(dxImageControl12.Location.X + dxImageControl12.Size.Width, 65);
            dxLabel17.Tag = (object)dxImageControl12;
            HolyResistLabel = dxLabel17;
            DXImageControl dxImageControl13 = new DXImageControl();
            dxImageControl13.Parent = dxControl2;
            dxImageControl13.LibraryFile = (LibraryFile)3;
            dxImageControl13.Index = 1515;
            dxImageControl13.Location = new Point(dxImageControl12.Location.X + 43, 63);
            dxImageControl13.Hint = "暗黑";
            DXImageControl dxImageControl14 = dxImageControl13;
            DXLabel dxLabel18 = new DXLabel();
            dxLabel18.Parent = dxControl2;
            dxLabel18.Location = new Point(dxImageControl14.Location.X + dxImageControl14.Size.Width, 65);
            dxLabel18.Tag = (object)dxImageControl14;
            DarkResistLabel = dxLabel18;
            DXImageControl dxImageControl15 = new DXImageControl();
            dxImageControl15.Parent = dxControl2;
            dxImageControl15.LibraryFile = (LibraryFile)3;
            dxImageControl15.Index = 1516;
            dxImageControl15.Location = new Point(dxImageControl14.Location.X + 43, 63);
            dxImageControl15.Hint = "幻影";
            DXImageControl dxImageControl16 = dxImageControl15;
            DXLabel dxLabel19 = new DXLabel();
            dxLabel19.Parent = dxControl2;
            dxLabel19.Location = new Point(dxImageControl16.Location.X + dxImageControl16.Size.Width, 65);
            dxLabel19.Tag = (object)dxImageControl16;
            PhantomResistLabel = dxLabel19;
            DXImageControl dxImageControl17 = new DXImageControl();
            dxImageControl17.Parent = dxControl2;
            dxImageControl17.LibraryFile = (LibraryFile)3;
            dxImageControl17.Index = 1517;
            dxImageControl17.Location = new Point(dxImageControl16.Location.X + 43, 63);
            dxImageControl17.Hint = "体质";
            DXImageControl dxImageControl18 = dxImageControl17;
            DXLabel dxLabel20 = new DXLabel();
            dxLabel20.Parent = dxControl2;
            dxLabel20.Location = new Point(dxImageControl18.Location.X + dxImageControl18.Size.Width, 65);
            dxLabel20.Tag = (object)dxImageControl18;
            PhysicalResistLabel = dxLabel20;
            Expanded = Config.MonsterBoxExpanded;
        }
        private void WindowMove(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }
        private void Label_MouseClick(object sender, MouseEventArgs e)
        {
            if (GameScene.Game.Observer) return;
            if (MouseControl != NameLabel) return;
            MonsterInfo monsterinfo = CartoonGlobals.MonsterInfoList.Binding.First(x => x.MonsterName == Monster.MonsterInfo.MonsterName);
            GameScene.Game.MMonsterDropItemsBox.Bind(monsterinfo);
            GameScene.Game.MMonsterDropItemsBox.Location = new Point(GameScene.Game.MonsterBox.Location.X + GameScene.Game.MonsterBox.Size.Width, GameScene.Game.MonsterBox.Location.Y);
           
        }
        private void PopulateLabel(Stat stat, DXLabel label, Stats stats)
        {
            label.Text = string.Format("x{0:0}", (object)Math.Abs(stats[stat]));
            if (stats[stat] == 0)
                label.ForeColour = Color.White;
            else if (stats[stat] > 0)
            {
                label.ForeColour = Color.Lime;
            }
            else
            {
                if (stats[stat] >= 0)
                    return;
                label.ForeColour = Color.IndianRed;
            }
        }

        public void RefreshHealth()
        {
            ClientObjectData data;
            HealthLabel.Text = !GameScene.Game.DataDictionary.TryGetValue(Monster.ObjectID, out data) ? string.Empty : string.Format("{0} / {1}", (object)(int)data.Health, (object)(int)data.MaxHealth);
        }

        public void RefreshStats()
        {
            ClientObjectData data;
            if (!GameScene.Game.DataDictionary.TryGetValue(Monster.ObjectID, out data) || data.Stats == null)
            {
                HealthLabel.Text = string.Empty;
                ACLabel.Text = $"{Monster.MonsterInfo.Stats[Stat.MinAC]} - {Monster.MonsterInfo.Stats[Stat.MaxAC]}";
                MRLabel.Text = $"{Monster.MonsterInfo.Stats[Stat.MinMR]} - {Monster.MonsterInfo.Stats[Stat.MaxMR]}";
                DCLabel.Text = $"{Monster.MonsterInfo.Stats[Stat.MinDC]} - {Monster.MonsterInfo.Stats[Stat.MaxDC]}";
                MCLabel.Text = $"{Monster.MonsterInfo.Stats[Stat.MinMC]} - {Monster.MonsterInfo.Stats[Stat.MaxMC]}";

                PopulateLabel(Stat.FireResistance, FireResistLabel, Monster.MonsterInfo.Stats);
                PopulateLabel(Stat.IceResistance, IceResistLabel, Monster.MonsterInfo.Stats);
                PopulateLabel(Stat.LightningResistance, LightningResistLabel, Monster.MonsterInfo.Stats);
                PopulateLabel(Stat.WindResistance, WindResistLabel, Monster.MonsterInfo.Stats);
                PopulateLabel(Stat.HolyResistance, HolyResistLabel, Monster.MonsterInfo.Stats);
                PopulateLabel(Stat.DarkResistance, DarkResistLabel, Monster.MonsterInfo.Stats);
                PopulateLabel(Stat.PhantomResistance, PhantomResistLabel, Monster.MonsterInfo.Stats);
                PopulateLabel(Stat.PhysicalResistance, PhysicalResistLabel, Monster.MonsterInfo.Stats);

                switch (Monster.Stats.GetAffinityElement())
                {
                    case Element.None:
                        AttackIcon.Index = 1517;
                        AttackIcon.Hint = "体质";
                        break;
                    case Element.Fire:
                        AttackIcon.Index = 1510;
                        AttackIcon.Hint = "火";
                        break;
                    case Element.Ice:
                        AttackIcon.Index = 1511;
                        AttackIcon.Hint = "冰";
                        break;
                    case Element.Lightning:
                        AttackIcon.Index = 1512;
                        AttackIcon.Hint = "雷";
                        break;
                    case Element.Wind:
                        AttackIcon.Index = 1513;
                        AttackIcon.Hint = "风";
                        break;
                    case Element.Holy:
                        AttackIcon.Index = 1514;
                        AttackIcon.Hint = "神圣";
                        break;
                    case Element.Dark:
                        AttackIcon.Index = 1515;
                        AttackIcon.Hint = "暗黑";
                        break;
                    case Element.Phantom:
                        AttackIcon.Index = 1516;
                        AttackIcon.Hint = "幻影";
                        break;
                }
            }
            else
            {
                HealthLabel.Text = $"{data.Health} / {data.MaxHealth}";


                ACLabel.Text = $"{data.Stats[Stat.MinAC]} - {data.Stats[Stat.MaxAC]}";
                MRLabel.Text = $"{data.Stats[Stat.MinMR]} - {data.Stats[Stat.MaxMR]}";
                DCLabel.Text = $"{data.Stats[Stat.MinDC]} - {data.Stats[Stat.MaxDC]}";
                MCLabel.Text = $"{data.Stats[Stat.MinMC]} - {data.Stats[Stat.MaxMC]}";

                PopulateLabel(Stat.FireResistance, FireResistLabel, data.Stats);
                PopulateLabel(Stat.IceResistance, IceResistLabel, data.Stats);
                PopulateLabel(Stat.LightningResistance, LightningResistLabel, data.Stats);
                PopulateLabel(Stat.WindResistance, WindResistLabel, data.Stats);
                PopulateLabel(Stat.HolyResistance, HolyResistLabel, data.Stats);
                PopulateLabel(Stat.DarkResistance, DarkResistLabel, data.Stats);
                PopulateLabel(Stat.PhantomResistance, PhantomResistLabel, data.Stats);
                PopulateLabel(Stat.PhysicalResistance, PhysicalResistLabel, data.Stats);

                switch (Monster.Stats.GetAffinityElement())
                {
                    case Element.None:
                        AttackIcon.Index = 1517;
                        AttackIcon.Hint = "体质";
                        break;
                    case Element.Fire:
                        AttackIcon.Index = 1510;
                        AttackIcon.Hint = "火";
                        break;
                    case Element.Ice:
                        AttackIcon.Index = 1511;
                        AttackIcon.Hint = "冰";
                        break;
                    case Element.Lightning:
                        AttackIcon.Index = 1512;
                        AttackIcon.Hint = "雷";
                        break;
                    case Element.Wind:
                        AttackIcon.Index = 1513;
                        AttackIcon.Hint = "风";
                        break;
                    case Element.Holy:
                        AttackIcon.Index = 1514;
                        AttackIcon.Hint = "神圣";
                        break;
                    case Element.Dark:
                        AttackIcon.Index = 1515;
                        AttackIcon.Hint = "暗黑";
                        break;
                    case Element.Phantom:
                        AttackIcon.Index = 1516;
                        AttackIcon.Hint = "幻影";
                        break;
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing)
                return;
            _Monster = (MonsterObject)null;
            
            MonsterChanged = (EventHandler<EventArgs>)null;
            _Expanded = false;
            
            ExpandedChanged = (EventHandler<EventArgs>)null;
            if (BackGround != null)
            {
                if (!BackGround.IsDisposed)
                    BackGround.Dispose();
                BackGround = (DXImageControl)null;
            }
            if (AttackIcon != null)
            {
                if (!AttackIcon.IsDisposed)
                    AttackIcon.Dispose();
                AttackIcon = (DXImageControl)null;
            }
            if (LevelLabel != null)
            {
                if (!LevelLabel.IsDisposed)
                    LevelLabel.Dispose();
                LevelLabel = (DXLabel)null;
            }
            if (NameLabel != null)
            {
                if (!NameLabel.IsDisposed)
                    NameLabel.Dispose();
                NameLabel = (DXLabel)null;
            }
            if (HealthLabel != null)
            {
                if (!HealthLabel.IsDisposed)
                    HealthLabel.Dispose();
                HealthLabel = (DXLabel)null;
            }
            if (ACLabel != null)
            {
                if (!ACLabel.IsDisposed)
                    ACLabel.Dispose();
                ACLabel = (DXLabel)null;
            }
            if (MRLabel != null)
            {
                if (!MRLabel.IsDisposed)
                    MRLabel.Dispose();
                MRLabel = (DXLabel)null;
            }
            if (DCLabel != null)
            {
                if (!DCLabel.IsDisposed)
                    DCLabel.Dispose();
                DCLabel = (DXLabel)null;
            }
            if (MCLabel != null)
            {
                if (!MCLabel.IsDisposed)
                    MCLabel.Dispose();
                MCLabel = (DXLabel)null;
            }
            if (FireResistLabel != null)
            {
                if (!FireResistLabel.IsDisposed)
                    FireResistLabel.Dispose();
                FireResistLabel = (DXLabel)null;
            }
            if (IceResistLabel != null)
            {
                if (!IceResistLabel.IsDisposed)
                    IceResistLabel.Dispose();
                IceResistLabel = (DXLabel)null;
            }
            if (LightningResistLabel != null)
            {
                if (!LightningResistLabel.IsDisposed)
                    LightningResistLabel.Dispose();
                LightningResistLabel = (DXLabel)null;
            }
            if (WindResistLabel != null)
            {
                if (!WindResistLabel.IsDisposed)
                    WindResistLabel.Dispose();
                WindResistLabel = (DXLabel)null;
            }
            if (HolyResistLabel != null)
            {
                if (!HolyResistLabel.IsDisposed)
                    HolyResistLabel.Dispose();
                HolyResistLabel = (DXLabel)null;
            }
            if (DarkResistLabel != null)
            {
                if (!DarkResistLabel.IsDisposed)
                    DarkResistLabel.Dispose();
                DarkResistLabel = (DXLabel)null;
            }
            if (PhantomResistLabel != null)
            {
                if (!PhantomResistLabel.IsDisposed)
                    PhantomResistLabel.Dispose();
                PhantomResistLabel = (DXLabel)null;
            }
            if (ExpandButton != null)
            {
                if (!ExpandButton.IsDisposed)
                    ExpandButton.Dispose();
                ExpandButton = (DXButton)null;
            }
        }
    }
}
