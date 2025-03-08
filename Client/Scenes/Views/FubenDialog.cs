using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Client.Controls;
using Client.Envir;
using Client.Models;
using Client.UserModels;
using Library;
using Library.SystemModels;
using C = Library.Network.ClientPackets;


namespace Client.Scenes.Views
{
    public sealed class FubenDialog : DXWindow
    {
        #region Properties

        private DXTabControl TabControl;
        public SortedDictionary<FubenSchool, FubenTab> SchoolTabs = new SortedDictionary<FubenSchool, FubenTab>();
        private DXImageControl BackGround;

        public Dictionary<FubenInfo, FubenCell> Fubens = new Dictionary<FubenInfo, FubenCell>();


        public override WindowType Type => WindowType.FubenBox;
        public override bool CustomSize => false;
        public override bool AutomaticVisiblity => true;

        #endregion

        public FubenDialog()
        {
            TitleLabel.Text = "副本列表";

            HasFooter = false;

            SetClientSize(new Size(525, 486));

            DXImageControl dxImageControl1 = new DXImageControl();
            dxImageControl1.Index = 6738;
            dxImageControl1.Location = new Point(9, 37);
            dxImageControl1.LibraryFile = LibraryFile.GameInter;
            dxImageControl1.Parent = (DXControl)this;
            BackGround = dxImageControl1;

            TabControl = new DXTabControl
            {
                Parent = this,
                Size = ClientArea.Size,
                Location = ClientArea.Location,
            };
            
            base.CloseButton.MouseClick += delegate (object o, MouseEventArgs e)
            {
                base.Visible = false;
                GameScene.Game.FubenMonsterDropItemsBox.Visible = false;
            };

        }

        #region Methods
        public void CreateTabs()
        {
            foreach (KeyValuePair<FubenSchool, FubenTab> pair in SchoolTabs)
                pair.Value.Dispose();

            SchoolTabs.Clear();

            List<FubenInfo> fubens = CartoonGlobals.FubenInfoList.Binding.ToList();
            fubens.Sort((x1, x2) => x1.Level.CompareTo(x2.Level));

            foreach (FubenInfo fuben in fubens)
            {
                

                FubenTab tab;

                if (!SchoolTabs.TryGetValue(fuben.School, out tab))
                {
                    SchoolTabs[fuben.School] = tab = new FubenTab(fuben.School);
                    tab.TabButton.Opacity = SchoolTabs.Count == 0 ? 1f : 0.0f;
                    tab.TabButton.MouseClick += new EventHandler<MouseEventArgs>(TabButton_MouseClick);
                    tab.MouseWheel += tab.ScrollBar.DoMouseWheel;
                    tab.PassThrough = false;
                }

                FubenCell cell = new FubenCell
                {
                    Parent = tab,
                    Info = fuben,
                };
                Fubens[fuben] = cell;
                cell.MouseWheel += tab.ScrollBar.DoMouseWheel;
            }

            foreach (KeyValuePair<FubenSchool, FubenTab> dxTab in SchoolTabs)
            {
                dxTab.Value.Parent = TabControl;
            }
        }
        private void TabButton_MouseClick(object sender, MouseEventArgs e)
        {
            using (SortedDictionary<FubenSchool, FubenTab>.Enumerator enumerator = SchoolTabs.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    KeyValuePair<FubenSchool, FubenTab> current = enumerator.Current;
                    current.Value.TabButton.Opacity = current.Value.TabButton.Equals((object)(sender as DXButton)) ? 1f : 0.0f;
                }
            }
        }
        #endregion

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                if (TabControl != null)
                {
                    if (!TabControl.IsDisposed)
                        TabControl.Dispose();

                    TabControl = null;
                }

                if (SchoolTabs != null)
                {
                    foreach (KeyValuePair<FubenSchool, FubenTab> pair in SchoolTabs)
                    {
                        if (pair.Value == null) continue;
                        if (pair.Value.IsDisposed) continue;

                        pair.Value.Dispose();
                    }
                    SchoolTabs.Clear();
                    SchoolTabs = null;
                }
                
                if (Fubens != null)
                {
                    foreach (KeyValuePair<FubenInfo, FubenCell> pair in Fubens)
                    {
                        if (pair.Value == null) continue;
                        if (pair.Value.IsDisposed) continue;

                        pair.Value.Dispose();
                    }
                    Fubens.Clear();
                    Fubens = null;
                }
            }

        }

        #endregion
    }

    public sealed class FubenTab : DXTab
    {
        #region Properties
        public DXVScrollBar ScrollBar;

        public override void OnSizeChanged(Size oValue, Size nValue)
        {
            base.OnSizeChanged(oValue, nValue);

            ScrollBar.Size = new Size(14, Size.Height -2 );
            ScrollBar.Location = new Point(Size.Width - 16, 0);

            int height = 2;

            foreach (DXControl control in Controls)
            {
                if (!(control is FubenCell)) continue;

                height += control.Size.Height + 3;
            }

            ScrollBar.MaxValue = height;

            ScrollBar.VisibleSize = Size.Height;
            UpdateLocations();
        }
        
        #endregion

        public FubenTab(FubenSchool school)
        {
            TabButton.LibraryFile = LibraryFile.GameInter;
            TabButton.Opacity = 0.0f;
            TabButton.Hint = school.ToString();
            Border = true;
            Opacity = 0.0f;

            switch (school)
            {
                case FubenSchool.Common:
                    TabButton.Index = 6734;
                    TabButton.Hint = "普通副本";
                    break;
                case FubenSchool.Hell:
                    TabButton.Index = 6735;
                    TabButton.Hint = "地狱副本";
                    break;
                case FubenSchool.Juqing:
                    TabButton.Index = 6736;
                    TabButton.Hint = "剧情副本";
                    break;
                case FubenSchool.Tiaozhan:
                    TabButton.Index = 6737;
                    TabButton.Hint = "挑战副本";
                    break;
            }

            ScrollBar = new DXVScrollBar
            {
                Parent = this,
            };
            ScrollBar.ValueChanged += (o, e) => UpdateLocations();
        }

        #region Methods
        public void UpdateLocations()
        {
            int y = -ScrollBar.Value + 5;

            foreach (DXControl control in Controls)
            {
                if (!(control is FubenCell)) continue;

                control.Location = new Point(5, y);
                y += control.Size.Height + 3;
            }
        }

        public override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            UpdateLocations();
        }
        #endregion

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                if (ScrollBar != null)
                {
                    if (!ScrollBar.IsDisposed)
                        ScrollBar.Dispose();

                    ScrollBar = null;
                }
            }

        }

        #endregion
    }

    public sealed class FubenCell : DXControl
    {
        #region Properties

        #region Info
        public FubenInfo Info
        {
            get => _Info;
            set
            {
                if (_Info == value) return;

                FubenInfo oldValue = _Info;
                _Info = value;

                OnInfoChanged(oldValue, value);
            }
        }
        private FubenInfo _Info;
        public event EventHandler<EventArgs> InfoChanged;
        public void OnInfoChanged(FubenInfo oValue, FubenInfo nValue)
        {
            Image.Index = Info.Icon;
            NameLabel.Text = Info.Name;

            DXLabel label = new DXLabel
            {
                AutoSize = false,
                Text = Info.Description,
                ForeColour = Color.White,
                Parent = ShuomingLabel,
            };

            label.Size = DXLabel.GetHeight(label, 315);
            ShuomingLabel.Size = new Size(label.DisplayArea.Right + 4 > ShuomingLabel.Size.Width ? label.DisplayArea.Right + 4 : ShuomingLabel.Size.Width, label.DisplayArea.Bottom + 4);

            Refresh();
            InfoChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        public DXImageControl Image;
        public DXImageControl Image1;
        public DXControl FubendianBar;
        public DXLabel NameLabel, LevelLabel, FubendianLabel, KeyLabel, DiaoluoLabel, DangqiandianLabel, ShuomingLabel, FubenbiLabel;
        public DXButton MoveButton;

        #endregion

        public FubenCell()
        {
            Size = new Size(500, 150);

            DrawTexture = true;
            BackColour = Color.FromArgb(25, 20, 0);

            DXImageControl dxImageControl1 = new DXImageControl();
            dxImageControl1.Parent = this;
            dxImageControl1.LibraryFile = LibraryFile.GameInter;
            dxImageControl1.Index = 6714;
            dxImageControl1.Location = new Point(0, 0);
            dxImageControl1.IsControl = false;
            Image1 = dxImageControl1;

            Image = new DXImageControl
            {
                Parent = this,
                LibraryFile = LibraryFile.MonImg,
                Location = new Point(20, 19),
                Hint = "　　点击查看副本掉落",
            };
            Image.MouseClick += Image_MouseClick;
            

            FubendianBar = new DXControl
            {
                Parent = this,
                Location = new Point(166, 125),
                Size = Image1.Library.GetSize(6724),
            };
            FubendianBar.BeforeDraw += FubendianBarAfterDraw;

            MoveButton = new DXButton
            {
                Parent = this,
                LibraryFile = LibraryFile.GameInter,
                Index = 6726,
                Hint = "　　传送",
                Location = new Point(439, 121),
            };
            MoveButton.MouseClick += (o, e) =>
            {
                if (GameScene.Game.Observer) return;
                if (MouseControl != MoveButton || Info.MapParameter1 == null) return;

                DXMessageBox box = new DXMessageBox($"你确定传送副本管理员NPC旁边么？需要{Info.MoveGold}点金币", "确认", DXMessageBoxButtons.YesNo);

                box.YesButton.MouseClick += (o1, e1) =>
                {
                    if (GameScene.Game.User.Gold < Info.MoveGold)
                    {
                        GameScene.Game.ReceiveChat($"副本传送失败，传送 {Info.Name} 需要 {Info.MoveGold} 金币，", MessageType.System);
                        return;
                    }
                    else CEnvir.Enqueue(new C.FubenMove { Index = Info.Index });
                };

            };

            DangqiandianLabel = new DXLabel
            {
                Parent = this,
                Location = new Point(294, 125),
                Font = new Font(Config.FontName, CEnvir.FontSize(7F), FontStyle.Regular),
                ForeColour = Color.White,
                IsControl = false,
                Visible = false,
            };

            NameLabel = new DXLabel
            {
                Parent = this,
                Location = new Point(236, 22),
                ForeColour = Color.Yellow,
                IsControl = false,
            };

            FubenbiLabel = new DXLabel
            {
                Parent = this,
                Location = new Point(420, 22),
                ForeColour = Color.White,
                IsControl = false
            };
            
            KeyLabel = new DXLabel
            {
                Parent = Image,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Bold),
                IsControl = false,
                ForeColour = Color.Aquamarine,
                AutoSize =  false,
                Size = new Size(36,36),
                DrawFormat = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter,
                Visible = false,
            };
            KeyLabel.SizeChanged += (o, e) => KeyLabel.Location = new Point(Image.Size.Width - KeyLabel.Size.Width, Image.Size.Height - KeyLabel.Size.Height);
            
            LevelLabel = new DXLabel
            {
                Parent = this,
                Location = new Point(236, 40),
                ForeColour = Color.White,
                IsControl = false
            };


            FubendianLabel = new DXLabel
            {
                Parent = this,
                Location = new Point(420, 41),
                ForeColour = Color.White,
                IsControl = false
            };

            DiaoluoLabel = new DXLabel
            {
                Parent = this,
                Location = new Point(236, 59),
                ForeColour = Color.White,
                IsControl = false
            };

            ShuomingLabel = new DXLabel
            {
                Parent = this,
                Location = new Point(168, 65),
                ForeColour = Color.White,
                IsControl = false
            };

        }

        private void Image_MouseClick(object sender, MouseEventArgs e)
        {
            if (GameScene.Game.Observer) return;
            if (MouseControl != Image || Info.Monster == null) return;
            
            GameScene.Game.FubenMonsterDropItemsBox.Bind(Info.Monster);
            GameScene.Game.FubenMonsterDropItemsBox.Location = new Point(GameScene.Game.FubenBox.Location.X + GameScene.Game.FubenBox.Size.Width, GameScene.Game.FubenBox.Location.Y);

        }

        private void FubendianBarAfterDraw(object sender, EventArgs e)
        {
            foreach (FubenInfo fuben in CartoonGlobals.FubenInfoList.Binding)
            {
                if (Image1.Library == null) return;
                if (Info != CartoonGlobals.FubenInfoList.Binding.FirstOrDefault((FubenInfo n) => n.Index == fuben.Index)) continue;

                
                MirImage image = Image1.Library.CreateImage(6724, ImageType.Image);

                if (image == null) return;

                int x = (FubendianBar.Size.Width - image.Width) / 2;
                int y = (FubendianBar.Size.Height - image.Height) / 2;

                float percent = 1F;

                decimal maxfubendian = CartoonGlobals.Fubendian;
                decimal shengxiafubendian = GameScene.Game.User.Fubendian;

                if (maxfubendian == 0) return;
                percent = (float)Math.Min(1, Math.Max(0, shengxiafubendian / maxfubendian));

                if (percent == 0) return;

                PresentTexture(image.Image, this, new Rectangle(FubendianBar.DisplayArea.X + x, FubendianBar.DisplayArea.Y + y, (int)(image.Width * percent), image.Height), Color.White, FubendianBar);
            }
        }

        public void Refresh()
        {
            if (MapObject.User == null) return;

            

            if (MapObject.User.Level >= Info.Level)
            {
                
                

                FubenbiLabel.Text = $"{ Info.JiangliDian }";
                FubenbiLabel.ForeColour = Color.White;

                LevelLabel.Text = $"{ Info.Level }";
                LevelLabel.ForeColour = Color.White;

                FubendianLabel.Text = $"{ Info.FubenDian }";
                FubendianLabel.ForeColour = GameScene.Game.User.Fubendian >= Info.FubenDian ? Color.White : Color.Red;

            }
            else
            {

                
                

                FubenbiLabel.Text = $"{ Info.JiangliDian }";
                FubenbiLabel.ForeColour = Color.White;

                LevelLabel.Text = $"{Info.Level}";
                LevelLabel.ForeColour = Color.Red;

                FubendianLabel.Text = $"{Info.FubenDian}";
                FubendianLabel.ForeColour = GameScene.Game.User.Fubendian >= Info.FubenDian ? Color.White : Color.Red;

            }
        }

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                _Info = null;
                InfoChanged = null;

                if (Image != null)
                {
                    if (!Image.IsDisposed)
                        Image.Dispose();

                    Image = null;
                }

                if (FubendianBar != null)
                {
                    if (!FubendianBar.IsDisposed)
                        FubendianBar.Dispose();

                    FubendianBar = null;
                }

                if (NameLabel != null)
                {
                    if (!NameLabel.IsDisposed)
                        NameLabel.Dispose();

                    NameLabel = null;
                }

                if (LevelLabel != null)
                {
                    if (!LevelLabel.IsDisposed)
                        LevelLabel.Dispose();

                    LevelLabel = null;
                }

                if (FubendianLabel != null)
                {
                    if (!FubendianLabel.IsDisposed)
                        FubendianLabel.Dispose();

                    FubendianLabel = null;
                }

                if (ShuomingLabel != null)
                {
                    if (!ShuomingLabel.IsDisposed)
                        ShuomingLabel.Dispose();

                    ShuomingLabel = null;
                }

                if (DangqiandianLabel != null)
                {
                    if (!DangqiandianLabel.IsDisposed)
                        DangqiandianLabel.Dispose();

                    DangqiandianLabel = null;
                }

                if (DiaoluoLabel != null)
                {
                    if (!DiaoluoLabel.IsDisposed)
                        DiaoluoLabel.Dispose();

                    DiaoluoLabel = null;
                }

               
                if (FubenbiLabel != null)
                {
                    if (!FubenbiLabel.IsDisposed)
                        FubenbiLabel.Dispose();

                    FubenbiLabel = null;
                }
            }
        }

        #endregion
    }

}
