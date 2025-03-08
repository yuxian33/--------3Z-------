using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CartoonMirDB;
using Client.Controls;
using Client.Envir;
using Client.Models;
using Client.UserModels;
using Library;
using Library.Network;
using Library.Network.ClientPackets;
using Library.SystemModels;
using C = Library.Network.ClientPackets;


namespace Client.Scenes.Views
{
    public sealed class MagicDialog : DXWindow
    {
        public Dictionary<MagicSchool, MagicTab> SchoolTabs = new Dictionary<MagicSchool, MagicTab>();
        public SortedDictionary<MagicSchool, DXControl> Contents = new SortedDictionary<MagicSchool, DXControl>();
        public Dictionary<MagicInfo, MagicCell> Magics = new Dictionary<MagicInfo, MagicCell>();
        private DXImageControl BackGround;
        private DXImageControl BackGroundList;
        private DXTabControl TabControl;

        public override WindowType Type
        {
            get
            {
                return WindowType.MagicBox;
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

        public MagicDialog()
        {
            Size = new Size(422, 512);
            Opacity = 0.0f;
            HasTitle = false;
            DXImageControl dxImageControl1 = new DXImageControl();
            dxImageControl1.Index = 800;
            dxImageControl1.Size = new Size(308, 66);
            dxImageControl1.LibraryFile = LibraryFile.GameInter2;
            dxImageControl1.Parent = (DXControl)this;
            BackGround = dxImageControl1;
            BackGround.MouseDown += new EventHandler<MouseEventArgs>(WindowMove);
            CloseButton.Parent = (DXControl)BackGround;
            DXImageControl dxImageControl2 = new DXImageControl();
            dxImageControl2.Index = 810;
            dxImageControl2.Size = new Size(420, 446);
            dxImageControl2.Location = new Point(0, BackGround.Size.Height);
            dxImageControl2.LibraryFile = (LibraryFile)4;
            dxImageControl2.Parent = (DXControl)this;
            BackGroundList = dxImageControl2;
            BackGroundList.MouseDown += new EventHandler<MouseEventArgs>(WindowMove);
            DXTabControl dxTabControl = new DXTabControl();
            dxTabControl.Parent = (DXControl)this;
            dxTabControl.Size = Size;
            dxTabControl.Location = new Point(0, 40);
            dxTabControl.Opacity = 0.0f;
            dxTabControl.OffsetX = 56;
            dxTabControl.TabMargin = 2;
            TabControl = dxTabControl;
        }

        private void WindowMove(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }

        public void CreateTabs()
        {
            using (Dictionary<MagicSchool, MagicTab>.Enumerator enumerator = SchoolTabs.GetEnumerator())
            {
                while (enumerator.MoveNext())
                    enumerator.Current.Value.Dispose();
            }
            SchoolTabs.Clear();
            MirClass mirClass = GameScene.Game.User.Class;
            int num = 800;

            if (mirClass == MirClass.Warrior)
            {
                num = 800;
                AddTab((MagicSchool)1);
                AddTab((MagicSchool)2);
                AddTab((MagicSchool)3);
            }
            else if (mirClass == (MirClass)1)
            {
                num = 801;
                AddTab((MagicSchool)4);
                AddTab((MagicSchool)5);
                AddTab((MagicSchool)6);
                AddTab((MagicSchool)7);
                AddTab((MagicSchool)10);
            }
            else if (mirClass == (MirClass)2)
            {
                num = 802;
                AddTab((MagicSchool)8);
                AddTab((MagicSchool)9);
                AddTab((MagicSchool)10);
                AddTab((MagicSchool)13);
            }
            else if (mirClass == (MirClass)3)
            {
                num = 803;
                AddTab((MagicSchool)14);
                AddTab((MagicSchool)11);
                AddTab((MagicSchool)12);
            }
            BackGround.Index = num;
            List<MagicInfo> list = ((IEnumerable<MagicInfo>)((DBCollection<MagicInfo>)CartoonGlobals.MagicInfoList).Binding).ToList<MagicInfo>();
            list.Sort((Comparison<MagicInfo>)((x1, x2) => x1.NeedLevel1.CompareTo(x2.NeedLevel1)));
            using (List<MagicInfo>.Enumerator enumerator = list.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    MagicInfo current = enumerator.Current;
                    MagicTab magicTab;
                    if (current.Class == MapObject.User.Class && current.School != 0 && SchoolTabs.TryGetValue(current.School, out magicTab))
                    {
                        DXControl dxControl;
                        Contents.TryGetValue(current.School, out dxControl);
                        MagicCell magicCell1 = new MagicCell(current);
                        magicCell1.Parent = dxControl;
                        magicCell1.Info = current;
                        MagicCell magicCell2 = magicCell1;
                        Magics[current] = magicCell2;
                        magicCell2.MouseWheel += new EventHandler<MouseEventArgs>(magicTab.ScrollBar.DoMouseWheel);
                    }
                }
            }
            using (Dictionary<MagicSchool, MagicTab>.Enumerator enumerator = SchoolTabs.GetEnumerator())
            {
                while (enumerator.MoveNext())
                    enumerator.Current.Value.Parent = TabControl;
            }
        }

        private void AddTab(MagicSchool school)
        {
            MagicTab magicTab = new MagicTab(school);
            magicTab.TabButton.Opacity = SchoolTabs.Count == 0 ? 1f : 0.0f;
            magicTab.TabButton.MouseClick += new EventHandler<MouseEventArgs>(TabButton_MouseClick);
            magicTab.PassThrough = false;
            DXControl dxControl = new DXControl() { Size = new Size(Size.Width - 40, 420), Location = new Point(10, 5), Parent = (DXControl)magicTab, Tag = (object)"content" };
            dxControl.MouseWheel += new EventHandler<MouseEventArgs>(magicTab.ScrollBar.DoMouseWheel);
            SchoolTabs.Add(school, magicTab);
            Contents.Add(school, dxControl);
        }

        private void TabButton_MouseClick(object sender, MouseEventArgs e)
        {
            using (Dictionary<MagicSchool, MagicTab>.Enumerator enumerator = SchoolTabs.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    KeyValuePair<MagicSchool, MagicTab> current = enumerator.Current;
                    current.Value.TabButton.Opacity = current.Value.TabButton.Equals((object)(sender as DXButton)) ? 1f : 0.0f;
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing)
                return;
            if (BackGround != null)
            {
                if (!BackGround.IsDisposed)
                    BackGround.Dispose();
                BackGround = (DXImageControl)null;
            }
            if (BackGroundList != null)
            {
                if (!BackGroundList.IsDisposed)
                    BackGroundList.Dispose();
                BackGroundList = (DXImageControl)null;
            }
            if (TabControl != null)
            {
                if (!TabControl.IsDisposed)
                    TabControl.Dispose();
                TabControl = (DXTabControl)null;
            }
            if (SchoolTabs != null)
            {
                using (Dictionary<MagicSchool, MagicTab>.Enumerator enumerator = SchoolTabs.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        KeyValuePair<MagicSchool, MagicTab> current = enumerator.Current;
                        if (current.Value != null && !current.Value.IsDisposed)
                            current.Value.Dispose();
                    }
                }
                SchoolTabs.Clear();
                SchoolTabs = (Dictionary<MagicSchool, MagicTab>)null;
            }
            if (Contents != null)
            {
                using (SortedDictionary<MagicSchool, DXControl>.Enumerator enumerator = Contents.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        KeyValuePair<MagicSchool, DXControl> current = enumerator.Current;
                        if (current.Value != null && !current.Value.IsDisposed)
                            current.Value.Dispose();
                    }
                }
                Contents.Clear();
                Contents = (SortedDictionary<MagicSchool, DXControl>)null;
            }
            if (Magics != null)
            {
                using (Dictionary<MagicInfo, MagicCell>.Enumerator enumerator = Magics.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        KeyValuePair<MagicInfo, MagicCell> current = enumerator.Current;
                        if (current.Value != null && !current.Value.IsDisposed)
                            current.Value.Dispose();
                    }
                }
                Magics.Clear();
                Magics = (Dictionary<MagicInfo, MagicCell>)null;
            }
        }
    }

    public sealed class MagicCell : DXControl
    {
        private MagicInfo _Info;
        public DXImageControl Image;
        public DXImageControl ExperienceBar;
        public DXLabel NameLabel;
        public DXLabel LevelLabel;
        public DXLabel PassiveLabel;
        public DXLabel KeyLabel;
        
        public DXImageControl MingwenIcon01, MingwenIcon02, MingwenIcon03;

        public MagicInfo Info
        {
            get
            {
                return _Info;
            }
            set
            {
                if (_Info == value)
                    return;
                MagicInfo info = _Info;
                _Info = value;
                OnInfoChanged(info, value);
            }
        }

        public event EventHandler<EventArgs> InfoChanged;

        public void OnInfoChanged(MagicInfo oValue, MagicInfo nValue)
        {
            Image.Index = Info.Icon;
            NameLabel.Text = Info.Name;
            Refresh();
            
            EventHandler<EventArgs> infoChanged = InfoChanged;
            if (infoChanged == null)
                return;
            infoChanged((object)this, EventArgs.Empty);
        }

        public MagicCell(MagicInfo magicInfo)
        {
            Size = new Size(368, 53);
            DrawTexture = true;
            Opacity = 0.0f;
            DXImageControl dxImageControl1 = new DXImageControl();
            dxImageControl1.Parent = (DXControl)this;
            dxImageControl1.LibraryFile = (LibraryFile)19;
            dxImageControl1.Location = new Point(10, 10);
            dxImageControl1.GrayScale = true;
            Image = dxImageControl1;
            Image.MouseClick += new EventHandler<MouseEventArgs>(Image_MouseClick);
            Image.KeyDown += new EventHandler<KeyEventArgs>(Image_KeyDown);
            DXLabel dxLabel1 = new DXLabel();
            dxLabel1.Parent = (DXControl)this;
            dxLabel1.Location = new Point(Size.Width - 50, 10);
            dxLabel1.ForeColour = Color.FromArgb(137, 225, 31);
            dxLabel1.IsControl = false;
            dxLabel1.Text = magicInfo.Action == (Passive)0 ? "主动型" : "被动型";
            PassiveLabel = dxLabel1;

            MingwenIcon01 = new DXImageControl
            {
                Parent = this,
                LibraryFile = LibraryFile.GameInter2,
                Index = 10,
                Hint = "",
                Visible = false,
            };
            MingwenIcon01.Location = new Point(Size.Width - 70, 10);

            MingwenIcon02 = new DXImageControl
            {
                Parent = this,
                LibraryFile = LibraryFile.GameInter2,
                Index = 10,
                Hint = "",
                Visible = false,
            };
            MingwenIcon02.Location = new Point(Size.Width - 70, 10);

            MingwenIcon03 = new DXImageControl
            {
                Parent = this,
                LibraryFile = LibraryFile.GameInter2,
                Index = 10,
                Hint = "",
                Visible = false,
            };
            MingwenIcon03.Location = new Point(Size.Width - 70, 10);

            DXImageControl dxImageControl2 = new DXImageControl();
            dxImageControl2.Parent = (DXControl)this;
            dxImageControl2.LibraryFile = (LibraryFile)4;
            dxImageControl2.FixedSize = true;
            dxImageControl2.Size = new Size(0, 6);
            dxImageControl2.Location = new Point(111, 36);
            dxImageControl2.Index = 812;
            dxImageControl2.IsControl = false;
            ExperienceBar = dxImageControl2;
            DXLabel dxLabel2 = new DXLabel();
            dxLabel2.Parent = (DXControl)this;
            dxLabel2.Location = new Point(62, 10);
            dxLabel2.ForeColour = Color.FromArgb(233, 233, 225);
            dxLabel2.IsControl = false;
            dxLabel2.Font = CGlobal.BlodFont;
            NameLabel = dxLabel2;

            KeyLabel = new DXLabel
            {
                Parent = Image,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Bold),
                IsControl = false,
                ForeColour = Color.Aquamarine,
                AutoSize = false,
                Size = new Size(36, 36),
                DrawFormat = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter,
            };
            KeyLabel.SizeChanged += (o, e) => KeyLabel.Location = new Point(Image.Size.Width - KeyLabel.Size.Width, Image.Size.Height - KeyLabel.Size.Height);


            DXLabel dxLabel3 = new DXLabel();
            dxLabel3.Parent = (DXControl)this;
            dxLabel3.ForeColour = NameLabel.ForeColour;
            dxLabel3.Location = new Point(NameLabel.Location.X + 1, 33);
            dxLabel3.IsControl = false;
            dxLabel3.Font = CGlobal.BloadFontEng;
            LevelLabel = dxLabel3;
        }

        private void Image_MouseClick(object sender, MouseEventArgs e)
        {
            ClientUserMagic clientUserMagic;
            if (GameScene.Game.Observer || !MapObject.User.Magics.TryGetValue(Info, out clientUserMagic))
                return;
            switch (GameScene.Game.MagicBarBox.SpellSet)
            {
                case 1:
                    clientUserMagic.Set1Key = (SpellKey)0;
                    break;
                case 2:
                    clientUserMagic.Set2Key = (SpellKey)0;
                    break;
                case 3:
                    clientUserMagic.Set3Key = (SpellKey)0;
                    break;
                case 4:
                    clientUserMagic.Set4Key = (SpellKey)0;
                    break;
            }
            MagicKey magicKey = new MagicKey();
            magicKey.Magic = ((MagicInfo)clientUserMagic.Info).Magic;
            magicKey.Set1Key = clientUserMagic.Set1Key;
            magicKey.Set2Key = clientUserMagic.Set2Key;
            magicKey.Set3Key = clientUserMagic.Set3Key;
            magicKey.Set4Key = clientUserMagic.Set4Key;
            CEnvir.Enqueue((Packet)magicKey);
            Refresh();
            GameScene.Game.MagicBarBox.UpdateIcons();
        }

        private void Image_KeyDown(object sender, KeyEventArgs e)
        {
            if (GameScene.Game.Observer || e.Handled || DXControl.MouseControl != Image)
                return;
            SpellKey spellKey = (SpellKey)0;
            foreach (KeyBindAction keyBindAction in CEnvir.GetKeyAction(e.KeyCode))
            {
                switch (keyBindAction)
                {
                    case KeyBindAction.SpellUse01:
                        spellKey = (SpellKey)1;
                        break;
                    case KeyBindAction.SpellUse02:
                        spellKey = (SpellKey)2;
                        break;
                    case KeyBindAction.SpellUse03:
                        spellKey = (SpellKey)3;
                        break;
                    case KeyBindAction.SpellUse04:
                        spellKey = (SpellKey)4;
                        break;
                    case KeyBindAction.SpellUse05:
                        spellKey = (SpellKey)5;
                        break;
                    case KeyBindAction.SpellUse06:
                        spellKey = (SpellKey)6;
                        break;
                    case KeyBindAction.SpellUse07:
                        spellKey = (SpellKey)7;
                        break;
                    case KeyBindAction.SpellUse08:
                        spellKey = (SpellKey)8;
                        break;
                    case KeyBindAction.SpellUse09:
                        spellKey = (SpellKey)9;
                        break;
                    case KeyBindAction.SpellUse10:
                        spellKey = (SpellKey)10;
                        break;
                    case KeyBindAction.SpellUse11:
                        spellKey = (SpellKey)11;
                        break;
                    case KeyBindAction.SpellUse12:
                        spellKey = (SpellKey)12;
                        break;
                    case KeyBindAction.SpellUse13:
                        spellKey = (SpellKey)13;
                        break;
                    case KeyBindAction.SpellUse14:
                        spellKey = (SpellKey)14;
                        break;
                    case KeyBindAction.SpellUse15:
                        spellKey = (SpellKey)15;
                        break;
                    case KeyBindAction.SpellUse16:
                        spellKey = (SpellKey)16;
                        break;
                    case KeyBindAction.SpellUse17:
                        spellKey = (SpellKey)17;
                        break;
                    case KeyBindAction.SpellUse18:
                        spellKey = (SpellKey)18;
                        break;
                    case KeyBindAction.SpellUse19:
                        spellKey = (SpellKey)19;
                        break;
                    case KeyBindAction.SpellUse20:
                        spellKey = (SpellKey)20;
                        break;
                    case KeyBindAction.SpellUse21:
                        spellKey = (SpellKey)21;
                        break;
                    case KeyBindAction.SpellUse22:
                        spellKey = (SpellKey)22;
                        break;
                    case KeyBindAction.SpellUse23:
                        spellKey = (SpellKey)23;
                        break;
                    case KeyBindAction.SpellUse24:
                        spellKey = (SpellKey)24;
                        break;
                    default:
                        continue;
                }
                e.Handled = true;
            }
            ClientUserMagic clientUserMagic;
            if (spellKey == 0 || !MapObject.User.Magics.TryGetValue(Info, out clientUserMagic))
                return;
            switch (GameScene.Game.MagicBarBox.SpellSet)
            {
                case 1:
                    clientUserMagic.Set1Key = spellKey;
                    break;
                case 2:
                    clientUserMagic.Set2Key = spellKey;
                    break;
                case 3:
                    clientUserMagic.Set3Key = spellKey;
                    break;
                case 4:
                    clientUserMagic.Set4Key = spellKey;
                    break;
            }
            using (Dictionary<MagicInfo, ClientUserMagic>.Enumerator enumerator = MapObject.User.Magics.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    KeyValuePair<MagicInfo, ClientUserMagic> current = enumerator.Current;
                    if (current.Key != clientUserMagic.Info)
                    {
                        if (current.Value.Set1Key == clientUserMagic.Set1Key && clientUserMagic.Set1Key > 0)
                        {
                            current.Value.Set1Key = (SpellKey)0;
                            GameScene.Game.MagicBox.Magics[current.Key].Refresh();
                        }
                        if (current.Value.Set2Key == clientUserMagic.Set2Key && clientUserMagic.Set2Key > 0)
                        {
                            current.Value.Set2Key = (SpellKey)0;
                            GameScene.Game.MagicBox.Magics[current.Key].Refresh();
                        }
                        if (current.Value.Set3Key == clientUserMagic.Set3Key && clientUserMagic.Set3Key > 0)
                        {
                            current.Value.Set3Key = (SpellKey)0;
                            GameScene.Game.MagicBox.Magics[current.Key].Refresh();
                        }
                        if (current.Value.Set4Key == clientUserMagic.Set4Key && clientUserMagic.Set4Key > 0)
                        {
                            current.Value.Set4Key = (SpellKey)0;
                            GameScene.Game.MagicBox.Magics[current.Key].Refresh();
                        }
                    }
                }
            }
            MagicKey magicKey = new MagicKey();
            magicKey.Magic = clientUserMagic.Info.Magic;
            magicKey.Set1Key = clientUserMagic.Set1Key;
            magicKey.Set2Key = clientUserMagic.Set2Key;
            magicKey.Set3Key = clientUserMagic.Set3Key;
            magicKey.Set4Key = clientUserMagic.Set4Key;
            CEnvir.Enqueue((Packet)magicKey);
            Refresh();
            GameScene.Game.MagicBarBox.UpdateIcons();
        }

        public override void OnMouseEnter()
        {
            GameScene.Game.MouseMagic = Info;
        }

        public override void OnMouseLeave()
        {
            GameScene.Game.MouseMagic = (MagicInfo)null;
        }

        private void ExperienceBarAfterDraw(object sender, EventArgs e)
        {
            ClientUserMagic clientUserMagic;
            if (!MapObject.User.Magics.TryGetValue(Info, out clientUserMagic))
                return;
            MirImage image = ExperienceBar.Library.CreateImage(69, ImageType.Image);
            if (image == null)
                return;
            int num1 = (ExperienceBar.Size.Width - (int)image.Width) / 2;
            int num2 = (ExperienceBar.Size.Height - (int)image.Height) / 2;
            float num3;
            switch (clientUserMagic.Level)
            {
                case 0:
                    if (((MagicInfo)clientUserMagic.Info).Experience1 == 0)
                        return;
                    num3 = (float)Math.Min(Decimal.One, Math.Max(Decimal.Zero, (Decimal)clientUserMagic.Experience / (Decimal)((MagicInfo)clientUserMagic.Info).Experience1));
                    break;
                case 1:
                    if (((MagicInfo)clientUserMagic.Info).Experience2 == 0)
                        return;
                    num3 = (float)Math.Min(Decimal.One, Math.Max(Decimal.Zero, (Decimal)clientUserMagic.Experience / (Decimal)((MagicInfo)clientUserMagic.Info).Experience2));
                    break;
                case 2:
                    if (((MagicInfo)clientUserMagic.Info).Experience3 == 0)
                        return;
                    num3 = (float)Math.Min(Decimal.One, Math.Max(Decimal.Zero, (Decimal)clientUserMagic.Experience / (Decimal)((MagicInfo)clientUserMagic.Info).Experience3));
                    break;
                default:
                    if (((MagicInfo)clientUserMagic.Info).Experience3 == 0)
                        return;
                    num3 = (float)Math.Min(Decimal.One, Math.Max(Decimal.Zero, (Decimal)clientUserMagic.Experience / (Decimal)((clientUserMagic.Level - 2) * 500)));
                    break;
            }
            if ((double)num3 == 0.0)
                return;
            DXControl.PresentTexture(image.Image, (DXControl)this, new Rectangle(ExperienceBar.DisplayArea.X + num1, ExperienceBar.DisplayArea.Y + num2, (int)((double)image.Width * (double)num3), (int)image.Height), Color.White, (DXControl)ExperienceBar, 0, 0);
        }

        public void Refresh()
        {
            if (MapObject.User == null) return;

            float num = 0.0f;
            ClientUserMagic clientUserMagic;
            if (MapObject.User.Magics.TryGetValue(Info, out clientUserMagic))
            {
                LevelLabel.Text = string.Format("Lv {0}", clientUserMagic.Level);
                PassiveLabel.ForeColour = Color.FromArgb(137, 225, 31);
                NameLabel.ForeColour = Color.FromArgb(233, 233, 225);
                Image.GrayScale = false;
                SpellKey spellKey = SpellKey.None;
                switch (GameScene.Game.MagicBarBox.SpellSet)
                {
                    case 1:
                        spellKey = clientUserMagic.Set1Key;
                        break;
                    case 2:
                        spellKey = clientUserMagic.Set2Key;
                        break;
                    case 3:
                        spellKey = clientUserMagic.Set3Key;
                        break;
                    case 4:
                        spellKey = clientUserMagic.Set4Key;
                        break;
                }
                

                Type type = typeof(SpellKey);
                MemberInfo[] infos = type.GetMember(spellKey.ToString());
                DescriptionAttribute description = infos[0].GetCustomAttribute<DescriptionAttribute>();
                KeyLabel.Text = description?.Description;

                if (Info.NeedLevel1 <= MapObject.User.Level)
                {
                    switch (clientUserMagic.Level)
                    {
                        case 0:
                            num = (float)clientUserMagic.Experience / (float)((MagicInfo)clientUserMagic.Info).Experience1;
                            break;
                        case 1:
                            num = (float)clientUserMagic.Experience / (float)((MagicInfo)clientUserMagic.Info).Experience2;
                            break;
                        case 2:
                            num = (float)clientUserMagic.Experience / (float)((MagicInfo)clientUserMagic.Info).Experience3;
                            break;
                        default:
                            num = (float)clientUserMagic.Experience / (float)((clientUserMagic.Level - 2) * 500);
                            break;
                    }
                }
            }
            else
            {
                LevelLabel.Text = "";
                KeyLabel.Text = "";
                PassiveLabel.ForeColour = Color.FromArgb(75, 115, 16);
                NameLabel.ForeColour = Color.FromArgb(126, 125, 120);
                Image.GrayScale = true;
            }

            ExperienceBar.Size = new Size(Convert.ToInt32(248f * num), 6);
            
            if (this == MouseControl)
            {
                GameScene.Game.MouseMagic = null;
                GameScene.Game.MouseMagic = Info;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing)
                return;
            _Info = (MagicInfo)null;
            
            InfoChanged = (EventHandler<EventArgs>)null;
            if (Image != null)
            {
                if (!Image.IsDisposed)
                    Image.Dispose();
                Image = (DXImageControl)null;
            }
            if (PassiveLabel != null)
            {
                if (!PassiveLabel.IsDisposed)
                    PassiveLabel.Dispose();
                PassiveLabel = (DXLabel)null;
            }
            if (ExperienceBar != null)
            {
                if (!ExperienceBar.IsDisposed)
                    ExperienceBar.Dispose();
                ExperienceBar = (DXImageControl)null;
            }
            if (NameLabel != null)
            {
                if (!NameLabel.IsDisposed)
                    NameLabel.Dispose();
                NameLabel = (DXLabel)null;
            }
            if (KeyLabel != null)
            {
                if (!KeyLabel.IsDisposed)
                    KeyLabel.Dispose();

                KeyLabel = null;
            }
            if (LevelLabel != null)
            {
                if (!LevelLabel.IsDisposed)
                    LevelLabel.Dispose();
                LevelLabel = (DXLabel)null;
            }
        }
    }

}
