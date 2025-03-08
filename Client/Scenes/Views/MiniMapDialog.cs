using Client.Controls;
using Client.Envir;
using Client.Models;
using Client.UserModels;
using Library;
using Library.SystemModels;
using CartoonMirDB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SlimDX;

namespace Client.Scenes.Views
{
    public sealed class MiniMapDialog : DXWindow
    {
        private static readonly Size NormalSize = new Size(144, 157);
        public Dictionary<object, DXControl> MapInfoObjects = new Dictionary<object, DXControl>();
        private Dictionary<object, DXLabel> MomentLabs = new Dictionary<object, DXLabel>();
        private bool _isOver = false;
        private Size _oldSize = MiniMapDialog.NormalSize;
        public Rectangle Area;
        public DXLabel Title;
        public DXImageControl PanelMini;
        private DXImageControl Image;
        private DXImageControl OpacityBtn;
        private DXImageControl LarBtn;
        private DXImageControl BigBtn;
        private DXImageControl MonsterBtn;
        public DxMirButton MinBtn;
        private DXImageControl[] Borders;
        private DXImageControl[] Icons;
        public DXControl Panel;
        public DXControl PanelOver;
        public DXControl PanelBtns;
        public DXLabel Point;
        public static float ScaleX;
        public static float ScaleY;

        public override void OnSizeChanged(Size oValue, Size nValue)
        {
            base.OnSizeChanged(oValue, nValue);
            if (Panel == null)
                return;
            Panel.Size = Size;
            PanelOver.Size = Size;
            Location = new System.Drawing.Point(GameScene.Game.Size.Width - Size.Width, 0);
            UpdateLocations();
            UpdateMapPosition();
        }

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
                return true;
            }
        }

        public override bool AutomaticVisiblity
        {
            get
            {
                return true;
            }
        }

        public MiniMapDialog()
        {
            Opacity = 1f;
            TitleLabel.Visible = false;
            Tag = (object)0;
            BackColour = Color.Black;
            HasFooter = false;
            HasTopBorder = false;
            Border = false;
            AllowResize = false;
            Movable = false;
            CloseButton.Visible = false;
            Size = MiniMapDialog.NormalSize;
            Panel = new DXControl()
            {
                Parent = (DXControl)this,
                Size = Size,
                BackColour = Color.Black,
                IsControl = true
            };
            DXImageControl dxImageControl1 = new DXImageControl();
            dxImageControl1.Parent = Panel;
            dxImageControl1.LibraryFile = LibraryFile.MiniMap;
            dxImageControl1.Movable = false;
            Image = dxImageControl1;
            Image.ZoomChanged += (EventHandler<EventArgs>)((s, e) => ChangeMap());
            DrawBorders();
            DrawIcons();
            GameScene.Game.MapControl.MapInfoChanged += new EventHandler<EventArgs>(MapControl_MapInfoChanged);
            DXLabel dxLabel1 = new DXLabel();
            dxLabel1.ForeColour = Color.White;
            dxLabel1.Parent = Panel;
            Title = dxLabel1;
            DXLabel dxLabel2 = new DXLabel();
            dxLabel2.Parent = Panel;
            dxLabel2.ForeColour = Color.White;
            Point = dxLabel2;
            PanelOver = new DXControl()
            {
                Parent = Panel,
                Size = Size
            };
            PanelBtns = new DXControl()
            {
                Parent = PanelOver,
                Size = new Size(32, 108),
                Opacity = 0.0f,
                Visible = false
            };
            DXImageControl dxImageControl2 = new DXImageControl();
            dxImageControl2.LibraryFile = (LibraryFile)3;
            dxImageControl2.Index = 144;
            dxImageControl2.Parent = (DXControl)this;
            dxImageControl2.Visible = false;
            PanelMini = dxImageControl2;
            DxMirButton DXButton = new DxMirButton();
            DXButton.Parent = PanelBtns;
            DXButton.LibraryFile = (LibraryFile)3;
            DXButton.Index = 156;
            DXButton.MirButtonType = MirButtonType.TowStatu2;
            MinBtn = DXButton;
            DXImageControl dxImageControl3 = new DXImageControl();
            dxImageControl3.Parent = PanelBtns;
            dxImageControl3.LibraryFile = (LibraryFile)3;
            dxImageControl3.Index = 130;
            OpacityBtn = dxImageControl3;
            DXImageControl dxImageControl4 = new DXImageControl();
            dxImageControl4.Parent = PanelBtns;
            dxImageControl4.LibraryFile = (LibraryFile)3;
            dxImageControl4.Index = 132;
            LarBtn = dxImageControl4;
            DXImageControl dxImageControl5 = new DXImageControl();
            dxImageControl5.Parent = PanelBtns;
            dxImageControl5.LibraryFile = (LibraryFile)3;
            dxImageControl5.Index = 137;
            BigBtn = dxImageControl5;
            DXImageControl dxImageControl6 = new DXImageControl();
            dxImageControl6.Parent = PanelBtns;
            dxImageControl6.LibraryFile = (LibraryFile)3;
            dxImageControl6.Index = 138;
            dxImageControl6.Tag = (object)true;
            MonsterBtn = dxImageControl6;
            PanelBtns.MouseEnter += (EventHandler<EventArgs>)((s, e) => _isOver = true);
            PanelBtns.MouseLeave += (EventHandler<EventArgs>)((s, e) => _isOver = false);
            foreach (DXControl control in PanelBtns.Controls)
            {
                control.MouseEnter += (EventHandler<EventArgs>)((s, e) => _isOver = true);
                control.MouseLeave += (EventHandler<EventArgs>)((s, e) => _isOver = false);
            }
            PanelOver.MouseEnter += (EventHandler<EventArgs>)((s, e) =>
            {
                _isOver = false;
                if (Image.Size.Width < 2 || Image.Size.Height < 2)
                    return;
                PanelBtns.Visible = true;
            });
            PanelOver.MouseLeave += (EventHandler<EventArgs>)(async (s, e) =>
            {
                Size size = Image.Size;
                int num;
                if (size.Width >= 2)
                {
                    size = Image.Size;
                    num = size.Height < 2 ? 1 : 0;
                }
                else
                    num = 1;
                if (num != 0)
                    return;
                await Task.Delay(50);
                if (_isOver)
                    return;
                PanelBtns.Visible = false;
            });
            MinBtn.MouseClick += (EventHandler<MouseEventArgs>)((s, e) =>
            {
                int num;
                if (GameScene.Game.MapControl.MapInfo != null)
                {
                    Size size = Image.Size;
                    if (size.Width >= 2)
                    {
                        size = Image.Size;
                        num = size.Height < 2 ? 1 : 0;
                        goto label_4;
                    }
                }
                num = 1;
            label_4:
                if (num != 0)
                    PanelMini.Visible = false;
                if (!PanelMini.Visible)
                {
                    MinBtn.Reset();
                    MinBtn.Index = 154;
                    MinBtn.Parent = (DXControl)PanelMini;
                    Title.Parent = (DXControl)PanelMini;
                    Point.Parent = (DXControl)PanelMini;
                    PanelMini.Visible = true;
                    Panel.Visible = false;
                    PanelMini.Location = new System.Drawing.Point(0, 0);
                    Size = PanelMini.Size;
                }
                else
                {
                    Size = _oldSize;
                    MinBtn.Reset();
                    MinBtn.Index = 156;
                    MinBtn.Parent = PanelBtns;
                    Title.Parent = Panel;
                    Point.Parent = Panel;
                    PanelMini.Visible = false;
                    Panel.Visible = true;
                }
                UpdateLocations();
            });
            OpacityBtn.MouseClick += (EventHandler<MouseEventArgs>)((s, e) =>
            {
                if ((double)Image.Opacity == 1.0)
                {
                    Opacity = 0.5f;
                    Image.Opacity = 0.5f;
                    Image.ImageOpacity = 0.5f;
                    OpacityBtn.Index = 131;
                }
                else
                {
                    Opacity = 1f;
                    Image.Opacity = 1f;
                    Image.ImageOpacity = 1f;
                    OpacityBtn.Index = 130;
                }
            });
            LarBtn.MouseClick += (EventHandler<MouseEventArgs>)((s, e) => ChangeSize());
            BigBtn.MouseClick += (EventHandler<MouseEventArgs>)((s, e) => GameScene.Game.BigMapBox.Visible = !GameScene.Game.BigMapBox.Visible);
            MonsterBtn.MouseClick += (EventHandler<MouseEventArgs>)((s, e) =>
            {
                bool tag = (bool)MonsterBtn.Tag;
                foreach (KeyValuePair<object, DXControl> mapInfoObject in MapInfoObjects)
                {
                    if (mapInfoObject.Value != null && (mapInfoObject.Key as ClientObjectData)?.MonsterInfo != null)
                        mapInfoObject.Value.Visible = !tag;
                }
                MonsterBtn.Tag = (object)!tag;
            });
            UpdateLocations();
        }

        private void DrawBorders()
        {
            Borders = new DXImageControl[4];
            DXImageControl[] borders1 = Borders;
            int index1 = 0;
            DXImageControl dxImageControl1 = new DXImageControl();
            dxImageControl1.Parent = Panel;
            dxImageControl1.LibraryFile = (LibraryFile)3;
            dxImageControl1.Index = 142;
            dxImageControl1.FixedSize = true;
            dxImageControl1.Size = new Size(140, 26);
            borders1[index1] = dxImageControl1;
            DXImageControl[] borders2 = Borders;
            int index2 = 1;
            DXImageControl dxImageControl2 = new DXImageControl();
            dxImageControl2.Parent = Panel;
            dxImageControl2.LibraryFile = (LibraryFile)3;
            dxImageControl2.Index = 150;
            
            dxImageControl2.TilingMode = TilingMode.None;
            dxImageControl2.FixedSize = true;
            dxImageControl2.Size = new Size(12, 130);
            borders2[index2] = dxImageControl2;
            DXImageControl[] borders3 = Borders;
            int index3 = 2;
            DXImageControl dxImageControl3 = new DXImageControl();
            dxImageControl3.Parent = Panel;
            dxImageControl3.LibraryFile = (LibraryFile)3;
            dxImageControl3.Index = 151;
            
            dxImageControl3.TilingMode = TilingMode.None;
            dxImageControl3.FixedSize = true;
            dxImageControl3.Size = new Size(12, 130);
            borders3[index3] = dxImageControl3;
            DXImageControl[] borders4 = Borders;
            int index4 = 3;
            DXImageControl dxImageControl4 = new DXImageControl();
            dxImageControl4.Parent = Panel;
            dxImageControl4.LibraryFile = (LibraryFile)3;
            dxImageControl4.Index = 152;
            dxImageControl4.TilingMode = TilingMode.Horizontally;
            
            dxImageControl4.FixedSize = true;
            dxImageControl4.Size = new Size(140, 8);
            borders4[index4] = dxImageControl4;
        }

        private void DrawIcons()
        {
            Icons = new DXImageControl[5];
            DXImageControl[] icons1 = Icons;
            int index1 = 0;
            DXImageControl dxImageControl1 = new DXImageControl();
            dxImageControl1.Parent = Panel;
            dxImageControl1.LibraryFile = (LibraryFile)3;
            dxImageControl1.Index = 140;
            icons1[index1] = dxImageControl1;
            DXImageControl[] icons2 = Icons;
            int index2 = 1;
            DXImageControl dxImageControl2 = new DXImageControl();
            dxImageControl2.Parent = Panel;
            dxImageControl2.LibraryFile = (LibraryFile)3;
            dxImageControl2.Index = 141;
            icons2[index2] = dxImageControl2;
            DXImageControl[] icons3 = Icons;
            int index3 = 2;
            DXImageControl dxImageControl3 = new DXImageControl();
            dxImageControl3.Parent = Panel;
            dxImageControl3.LibraryFile = (LibraryFile)3;
            dxImageControl3.Index = 134;
            icons3[index3] = dxImageControl3;
            DXImageControl[] icons4 = Icons;
            int index4 = 3;
            DXImageControl dxImageControl4 = new DXImageControl();
            dxImageControl4.Parent = Panel;
            dxImageControl4.LibraryFile = (LibraryFile)3;
            dxImageControl4.Index = 135;
            icons4[index4] = dxImageControl4;
            DXImageControl[] icons5 = Icons;
            int index5 = 4;
            DXImageControl dxImageControl5 = new DXImageControl();
            dxImageControl5.Parent = Panel;
            dxImageControl5.LibraryFile = (LibraryFile)3;
            dxImageControl5.Index = 136;
            icons5[index5] = dxImageControl5;
        }

        private void UpdateLocations()
        {
            Size size1;
            if (Panel.Visible)
            {
                Borders[0].Size = new Size(Size.Width, 26);
                Borders[1].Size = new Size(12, Size.Height);
                Borders[2].Size = new Size(12, Size.Height);
                Borders[3].Size = new Size(Size.Width, 8);
                Borders[0].Location = new System.Drawing.Point(0, 0);
                Borders[1].Location = new System.Drawing.Point(-1, Borders[0].Size.Height);
                DXImageControl border1 = Borders[2];
                Size size2 = Size;
                int width1 = size2.Width;
                size2 = Borders[2].Size;
                int width2 = size2.Width;
                int x1 = width1 - width2 + 4;
                size2 = Borders[0].Size;
                int height1 = size2.Height;
                System.Drawing.Point point1 = new System.Drawing.Point(x1, height1);
                border1.Location = point1;
                DXImageControl border2 = Borders[3];
                int x2 = 0;
                Size size3 = Size;
                int height2 = size3.Height;
                size3 = Borders[3].Size;
                int height3 = size3.Height;
                int y1 = height2 - height3 + 4;
                System.Drawing.Point point2 = new System.Drawing.Point(x2, y1);
                border2.Location = point2;
                Icons[0].Location = new System.Drawing.Point(-1, 0);
                DXImageControl icon1 = Icons[1];
                Size size4 = Size;
                int width3 = size4.Width;
                size4 = Icons[1].Size;
                int width4 = size4.Width;
                System.Drawing.Point point3 = new System.Drawing.Point(width3 - width4 + 2, 0);
                icon1.Location = point3;
                Icons[2].Location = new System.Drawing.Point(-1, Icons[0].Size.Height - 1);
                DXImageControl icon2 = Icons[3];
                int x3 = -1;
                Size size5 = Size;
                int height4 = size5.Height;
                size5 = Icons[3].Size;
                int height5 = size5.Height;
                int y2 = height4 - height5 + 2;
                System.Drawing.Point point4 = new System.Drawing.Point(x3, y2);
                icon2.Location = point4;
                DXImageControl icon3 = Icons[4];
                size1 = Size;
                int width5 = size1.Width;
                size1 = Icons[4].Size;
                int width6 = size1.Width;
                int x4 = width5 - width6 + 2;
                size1 = Size;
                int height6 = size1.Height;
                size1 = Icons[4].Size;
                int height7 = size1.Height;
                int y3 = height6 - height7 + 2;
                System.Drawing.Point point5 = new System.Drawing.Point(x4, y3);
                icon3.Location = point5;
                DXControl panelBtns = PanelBtns;
                size1 = Size;
                int width7 = size1.Width;
                size1 = PanelBtns.Size;
                int width8 = size1.Width;
                System.Drawing.Point point6 = new System.Drawing.Point(width7 - width8, 0);
                panelBtns.Location = point6;
                MinBtn.Location = new System.Drawing.Point(0, 0);
                DXImageControl opacityBtn = OpacityBtn;
                int x5 = 5;
                size1 = MinBtn.Size;
                int height8 = size1.Height;
                System.Drawing.Point point7 = new System.Drawing.Point(x5, height8);
                opacityBtn.Location = point7;
                DXImageControl larBtn = LarBtn;
                int x6 = 5;
                int y4 = OpacityBtn.Location.Y;
                size1 = OpacityBtn.Size;
                int height9 = size1.Height;
                int y5 = y4 + height9;
                System.Drawing.Point point8 = new System.Drawing.Point(x6, y5);
                larBtn.Location = point8;
                DXImageControl bigBtn = BigBtn;
                int x7 = 5;
                int y6 = LarBtn.Location.Y;
                size1 = LarBtn.Size;
                int height10 = size1.Height;
                int y7 = y6 + height10;
                System.Drawing.Point point9 = new System.Drawing.Point(x7, y7);
                bigBtn.Location = point9;
                DXImageControl monsterBtn = MonsterBtn;
                int x8 = 5;
                int y8 = BigBtn.Location.Y;
                size1 = BigBtn.Size;
                int height11 = size1.Height;
                int y9 = y8 + height11;
                System.Drawing.Point point10 = new System.Drawing.Point(x8, y9);
                monsterBtn.Location = point10;
            }
            else
            {
                DxMirButton minBtn = MinBtn;
                size1 = Size;
                int width1 = size1.Width;
                size1 = MinBtn.Size;
                int width2 = size1.Width;
                System.Drawing.Point point = new System.Drawing.Point(width1 - width2, 0);
                minBtn.Location = point;
            }
            DXLabel title = Title;
            size1 = Size;
            int width9 = size1.Width;
            size1 = Title.Size;
            int width10 = size1.Width;
            System.Drawing.Point point11 = new System.Drawing.Point((width9 - width10) / 2, 4);
            title.Location = point11;
            DXLabel point12 = Point;
            size1 = Size;
            int width11 = size1.Width;
            size1 = Point.Size;
            int width12 = size1.Width;
            int x = (width11 - width12) / 2;
            size1 = Size;
            int height12 = size1.Height;
            size1 = Point.Size;
            int height13 = size1.Height;
            int y = height12 - height13 - 5;
            System.Drawing.Point point13 = new System.Drawing.Point(x, y);
            point12.Location = point13;
            if (GameScene.Game.BuffBox == null)
                return;
            BuffDialog buffBox = GameScene.Game.BuffBox;
            size1 = GameScene.Game.Size;
            int width13 = size1.Width;
            size1 = Size;
            int width14 = size1.Width;
            int num = width13 - width14;
            size1 = GameScene.Game.BuffBox.Size;
            int width15 = size1.Width;
            System.Drawing.Point point14 = new System.Drawing.Point(num - width15 - 5, 0);
            buffBox.Location = point14;
        }

        public void UpdatePoint()
        {
            Point? currentLocation = GameScene.Game.User?.CurrentLocation;
            Point.Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Bold);
            Point.Text = string.Format("<{0},{1}>", (object)(currentLocation.HasValue ? currentLocation.GetValueOrDefault().X : 1), (object)(currentLocation.HasValue ? currentLocation.GetValueOrDefault().Y : 1));
            if (Panel.Visible)
            {
                DXLabel point1 = Point;
                int width1 = Size.Width;
                Size size = Point.Size;
                int width2 = size.Width;
                int x = (width1 - width2) / 2;
                size = Size;
                int height1 = size.Height;
                size = Point.Size;
                int height2 = size.Height;
                int y = height1 - height2 - 5;
                System.Drawing.Point point2 = new System.Drawing.Point(x, y);
                point1.Location = point2;
            }
            else
            {
                DXLabel point1 = Point;
                Size size = PanelMini.Size;
                int width1 = size.Width;
                size = Point.Size;
                int width2 = size.Width;
                int x = (width1 - width2) / 2;
                size = PanelMini.Size;
                int height1 = size.Height;
                size = Point.Size;
                int height2 = size.Height;
                int y = height1 - height2 - 5;
                Point point2 = new Point(x, y);
                point1.Location = point2;
            }
        }

        private void Image_Moving(object sender, MouseEventArgs e)
        {
            int x = Image.Location.X;
            Size size;
            if (x + Image.Size.Width < Panel.Size.Width)
            {
                size = Panel.Size;
                int width1 = size.Width;
                size = Image.Size;
                int width2 = size.Width;
                x = width1 - width2;
            }
            if (x > 0)
                x = 0;
            int y = Image.Location.Y;
            int num1 = y;
            size = Image.Size;
            int height1 = size.Height;
            int num2 = num1 + height1;
            size = Panel.Size;
            int height2 = size.Height;
            if (num2 < height2)
            {
                size = Panel.Size;
                int height3 = size.Height;
                size = Image.Size;
                int height4 = size.Height;
                y = height3 - height4;
            }
            if (y > 0)
                y = 0;
            Image.Location = new System.Drawing.Point(x, y);
        }

        private void MapControl_MapInfoChanged(object sender, EventArgs e)
        {
            Image.Zoom = false;
            Tag = (object)0;
            Size = MiniMapDialog.NormalSize;
            if (GameScene.Game.MapControl.MapInfo == null)
                return;
            ChangeMap();
        }


        private void ChangeMap()
        {
            foreach (DXControl dxControl in MapInfoObjects.Values)
                dxControl.Dispose();
            MapInfoObjects.Clear();
            DisabledMomentLabs();
            MomentLabs = new Dictionary<object, DXLabel>();
            Title.Text = GameScene.Game.MapControl.MapInfo.Description;
            DXLabel title = Title;
            int width1 = Size.Width;
            Size size1 = Title.Size;
            int width2 = size1.Width;
            System.Drawing.Point point = new System.Drawing.Point((width1 - width2) / 2, 4);
            title.Location = point;
            if (Image.Index != GameScene.Game.MapControl.MapInfo.MiniMap)
                Image.Index = GameScene.Game.MapControl.MapInfo.MiniMap;
            Size size2;
            if (!Image.Zoom)
            {
                size2 = Image.Size;
            }
            else
            {
                size1 = Image.ScalingSize;
                int width3 = size1.Width;
                size1 = Image.ScalingSize;
                int height = size1.Height;
                size2 = new Size(width3, height);
            }
            Size size3 = size2;
            if (size3.Width < 2 || size3.Height < 2 || size3.Width > 2 && PanelMini.Visible || size3.Height > 2 && PanelMini.Visible)
                MinBtn.InvokeMouseClick();
            MiniMapDialog.ScaleX = (float)size3.Width / (float)GameScene.Game.MapControl.Width;
            MiniMapDialog.ScaleY = (float)size3.Height / (float)GameScene.Game.MapControl.Height;
            MirLibrary mirLibrary;
            if (CEnvir.LibraryList.TryGetValue((LibraryFile)281, out mirLibrary))
            {
                MirImage image = mirLibrary.CreateImage(GameScene.Game.MapControl.MapInfo.BJMap, ImageType.Image);
                GameScene.Game.MapControl.BackgroundImage = image;
                if (image != null)
                {
                    MapControl mapControl1 = GameScene.Game.MapControl;
                    double num1 = (double)(GameScene.Game.MapControl.Width * 48);
                    int width3 = (int)image.Width;
                    size1 = Config.GameSize;
                    int width4 = size1.Width;
                    double num2 = (double)(width3 - width4);
                    double num3 = num1 / num2;
                    mapControl1.BackgroundScaleX = (float)num3;
                    MapControl mapControl2 = GameScene.Game.MapControl;
                    double num4 = (double)(GameScene.Game.MapControl.Height * 48);
                    int height1 = (int)image.Height;
                    size1 = Config.GameSize;
                    int height2 = size1.Height;
                    double num5 = (double)(height1 - height2);
                    double num6 = num4 / num5;
                    mapControl2.BackgroundScaleY = (float)num6;
                }
            }
            using (IEnumerator<NPCInfo> enumerator = ((IEnumerable<NPCInfo>)((DBCollection<NPCInfo>)CartoonGlobals.NPCInfoList).Binding).GetEnumerator())
            {
                while (((IEnumerator)enumerator).MoveNext())
                    Update(enumerator.Current);
            }
            using (IEnumerator<MovementInfo> enumerator = ((IEnumerable<MovementInfo>)((DBCollection<MovementInfo>)CartoonGlobals.MovementInfoList).Binding).GetEnumerator())
            {
                while (((IEnumerator)enumerator).MoveNext())
                    Update(enumerator.Current);
            }
            using (SortedDictionary<uint, ClientObjectData>.ValueCollection.Enumerator enumerator = GameScene.Game.DataDictionary.Values.GetEnumerator())
            {
                while (enumerator.MoveNext())
                    Update(enumerator.Current);
            }
        }

        public void Update(NPCInfo ob)
        {
            if (GameScene.Game.MapControl.MapInfo == null)
                return;
            DXControl npcControl1;
            if (!MapInfoObjects.TryGetValue((object)ob, out npcControl1))
            {
                if (ob.Region?.Map != GameScene.Game.MapControl.MapInfo)
                    return;
                npcControl1 = GameScene.Game.GetNPCControl(ob);
                npcControl1.Parent = (DXControl)Image;
                npcControl1.Opacity = Image.Opacity;
                MapInfoObjects[(object)ob] = npcControl1;
            }
            else if ((QuestIcon)npcControl1.Tag == ob.CurrentIcon)
                return;
            npcControl1.Dispose();
            MapInfoObjects.Remove((object)ob);
            if (ob.Region?.Map != GameScene.Game.MapControl.MapInfo)
                return;
            DXControl npcControl2 = GameScene.Game.GetNPCControl(ob);
            npcControl2.Parent = (DXControl)Image;
            npcControl2.Opacity = Image.Opacity;
            MapInfoObjects[(object)ob] = npcControl2;
            if (ob.Region.PointList == null)
                ob.Region.CreatePoints(GameScene.Game.MapControl.Width);
            int num1 = GameScene.Game.MapControl.Width;
            int num2 = 0;
            int num3 = GameScene.Game.MapControl.Height;
            int num4 = 0;
            foreach (System.Drawing.Point point in (List<System.Drawing.Point>)ob.Region.PointList)
            {
                if (point.X < num1)
                    num1 = point.X;
                if (point.X > num2)
                    num2 = point.X;
                if (point.Y < num3)
                    num3 = point.Y;
                if (point.Y > num4)
                    num4 = point.Y;
            }
            int num5 = (num1 + num2) / 2;
            int num6 = (num3 + num4) / 2;
            npcControl2.Location = new System.Drawing.Point((int)((double)MiniMapDialog.ScaleX * (double)num5) - npcControl2.Size.Width / 2, (int)((double)MiniMapDialog.ScaleY * (double)num6) - npcControl2.Size.Height / 2);
        }

        public void Update(MovementInfo ob)
        {
            if (ob.SourceRegion == null || ob.SourceRegion.Map != GameScene.Game.MapControl.MapInfo || (ob.DestinationRegion?.Map == null || ob.Icon == 0))
                return;
            if (ob.SourceRegion.PointList == null)
                ob.SourceRegion.CreatePoints(GameScene.Game.MapControl.Width);
            int num1 = GameScene.Game.MapControl.Width;
            int num2 = 0;
            int num3 = GameScene.Game.MapControl.Height;
            int num4 = 0;
            foreach (System.Drawing.Point point in (List<System.Drawing.Point>)ob.SourceRegion.PointList)
            {
                if (point.X < num1)
                    num1 = point.X;
                if (point.X > num2)
                    num2 = point.X;
                if (point.Y < num3)
                    num3 = point.Y;
                if (point.Y > num4)
                    num4 = point.Y;
            }
            int num5 = (num1 + num2) / 2;
            int num6 = (num3 + num4) / 2;
            Dictionary<object, DXControl> mapInfoObjects = MapInfoObjects;
            MovementInfo movementInfo1 = ob;
            DXImageControl dxImageControl1 = new DXImageControl();
            dxImageControl1.LibraryFile = (LibraryFile)2;
            dxImageControl1.Parent = (DXControl)Image;
            dxImageControl1.Opacity = Image.Opacity;
            dxImageControl1.ImageOpacity = Image.Opacity;
            dxImageControl1.Hint = ob.DestinationRegion.Map.Description;
            DXImageControl dxImageControl2 = dxImageControl1;
            DXImageControl control = dxImageControl1;
            DXImageControl dxImageControl3 = dxImageControl2;
            mapInfoObjects[(object)movementInfo1] = (DXControl)dxImageControl3;
            control.OpacityChanged += (EventHandler<EventArgs>)((o, e) => control.ImageOpacity = control.Opacity);
            switch (ob.Icon - 1)
            {
                case (MapIcon)0:
                    control.Index = 70;
                    control.ForeColour = Color.Red;
                    break;
                case (MapIcon)1:
                    control.Index = 70;
                    control.ForeColour = Color.Green;
                    break;
                case (MapIcon)2:
                    control.Index = 70;
                    control.ForeColour = Color.MediumVioletRed;
                    break;
                case (MapIcon)3:
                    control.Index = 70;
                    control.ForeColour = Color.DeepSkyBlue;
                    break;
                case (MapIcon)4:
                    control.Index = 6125;
                    control.LibraryFile = (LibraryFile)3;
                    break;
                case (MapIcon)5:
                    control.Index = 6124;
                    control.LibraryFile = (LibraryFile)3;
                    break;
                case (MapIcon)7:
                    control.Index = 550;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)8:
                    control.Index = 551;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)9:
                    control.Index = 552;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)10:
                    control.Index = 553;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)11:
                    control.Index = 554;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)12:
                    control.Index = 555;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)13:
                    control.Index = 556;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)14:
                    control.Index = 557;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)15:
                    control.Index = 558;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)16:
                    control.Index = 559;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)17:
                    control.Index = 560;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)18:
                    control.Index = 561;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)19:
                    control.Index = 562;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)20:
                    control.Index = 563;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)21:
                    control.Index = 100;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)22:
                    control.Index = 102;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)23:
                    control.Index = 103;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)24:
                    control.Index = 104;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)25:
                    control.Index = 120;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)26:
                    control.Index = 121;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)27:
                    control.Index = 122;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)28:
                    control.Index = 123;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)29:
                    control.Index = 140;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)30:
                    control.Index = 141;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)31:
                    control.Index = 142;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)32:
                    control.Index = 143;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)33:
                    control.Index = 160;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)34:
                    control.Index = 161;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)35:
                    control.Index = 162;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)36:
                    control.Index = 300;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)37:
                    control.Index = 301;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)38:
                    control.Index = 302;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)39:
                    control.Index = 510;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)40:
                    control.Index = 511;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)41:
                    control.Index = 570;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)42:
                    control.Index = 571;
                    control.LibraryFile = (LibraryFile)456;
                    break;
                case (MapIcon)43:
                    control.Index = 572;
                    control.LibraryFile = (LibraryFile)456;
                    break;
            }
            DXImageControl dxImageControl4 = control;
            int x1 = (int)((double)MiniMapDialog.ScaleX * (double)num5) - control.Size.Width / 2;
            int num7 = (int)((double)MiniMapDialog.ScaleY * (double)num6);
            Size size = control.Size;
            int num8 = size.Height / 2;
            int y1 = num7 - num8;
            System.Drawing.Point point1 = new System.Drawing.Point(x1, y1);
            dxImageControl4.Location = point1;
            Dictionary<object, DXLabel> momentLabs = MomentLabs;
            MovementInfo movementInfo2 = ob;
            DXLabel dxLabel1 = new DXLabel();
            dxLabel1.Text = ob.DestinationRegion.Map.Description;
            dxLabel1.ForeColour = Color.FromArgb(211, 250, 48);
            dxLabel1.Parent = (DXControl)Image;
            DXLabel dxLabel2 = dxLabel1;
            momentLabs[(object)movementInfo2] = dxLabel1;
            int num9 = (int)((double)MiniMapDialog.ScaleX * (double)num5);
            size = dxLabel2.Size;
            int num10 = size.Width / 2;
            int num11 = num9 - num10;
            DXLabel dxLabel3 = dxLabel2;
            int x2 = num11 < 0 ? 0 : num11;
            int y2 = control.Location.Y;
            size = control.Size;
            int height = size.Height;
            int y3 = y2 + height;
            System.Drawing.Point point2 = new System.Drawing.Point(x2, y3);
            dxLabel3.Location = point2;
        }

        public void Update(ClientObjectData ob)
        {
            if (GameScene.Game.MapControl.MapInfo == null)
                return;
            DXControl control;
            if (!MapInfoObjects.TryGetValue((object)ob, out control))
            {
                if (ob.MapIndex != ((DBObject)GameScene.Game.MapControl.MapInfo).Index || ob.ItemInfo != null && ((ItemInfo)ob.ItemInfo).Rarity == 0 || ob.MonsterInfo != null && ob.Dead)
                    return;
                Dictionary<object, DXControl> mapInfoObjects = MapInfoObjects;
                ClientObjectData clientObjectData = ob;
                DXControl dxControl = new DXControl();
                dxControl.DrawTexture = true;
                dxControl.Parent = (DXControl)Image;
                dxControl.Opacity = Image.Opacity;
                control = dxControl;
                mapInfoObjects[(object)clientObjectData] = dxControl;
            }
#pragma warning disable CS0472 
            else if (ob.MapIndex != ((DBObject)GameScene.Game.MapControl.MapInfo).Index || ob.MonsterInfo != null && ob.Dead != null || ob.ItemInfo != null && ((ItemInfo)ob.ItemInfo).Rarity == 0)
#pragma warning restore CS0472 
            {
                control.Dispose();
                MapInfoObjects.Remove((object)ob);
                return;
            }
            Size size = new Size(3, 3);
            Color color = Color.White;
            string str = (string)ob.Name;
            if (ob.MonsterInfo != null)
            {
                control.Visible = (bool)MonsterBtn.Tag;
                str = ((MonsterInfo)ob.MonsterInfo).MonsterName ?? "";
                if (((MonsterInfo)ob.MonsterInfo).AI < 0)
                {
                    color = Color.LightBlue;
                }
                else
                {
                    color = Color.Red;
                    if (GameScene.Game.HasQuest((MonsterInfo)ob.MonsterInfo, GameScene.Game.MapControl.MapInfo))
                        color = Color.Orange;

                    
                    if (GameScene.Game.MeiriHasQuest(ob.MonsterInfo, GameScene.Game.MapControl.MapInfo))
                        color = Color.Orange;
                }
                if (((MonsterInfo)ob.MonsterInfo).IsBoss)
                {
                    size = new Size(5, 5);
                    if (control.Controls.Count == 0)
                    {
                        DXControl dxControl = new DXControl() { Parent = control, Location = new System.Drawing.Point(1, 1), BackColour = color, DrawTexture = true, Size = new Size(3, 3) };
                    }
                    else
                        control.Controls[0].BackColour = color;
                    color = Color.White;
                }
                if (!string.IsNullOrEmpty((string)ob.PetOwner))
                {
                    str = str + " (" + (string)ob.PetOwner + ")";
                    control.DrawTexture = false;
                }
            }
            else if (ob.ItemInfo != null)
                color = Color.DarkBlue;
            else if ((int)MapObject.User.ObjectID == ob.ObjectID)
                color = Color.Cyan;
            else if (GameScene.Game.Observer)
                control.Visible = false;
            else if (((IEnumerable<ClientPlayerInfo>)GameScene.Game.GroupBox.Members).Any<ClientPlayerInfo>((Func<ClientPlayerInfo, bool>)(p => (int)p.ObjectID == ob.ObjectID)))
                color = Color.Blue;
            else if (GameScene.Game.Partner != null && (int)GameScene.Game.Partner.ObjectID == ob.ObjectID)
                color = Color.DeepPink;
            else if (GameScene.Game.GuildBox.GuildInfo != null && ((IEnumerable<ClientGuildMemberInfo>)GameScene.Game.GuildBox.GuildInfo.Members).Any<ClientGuildMemberInfo>((Func<ClientGuildMemberInfo, bool>)(p => (int)p.ObjectID == ob.ObjectID)))
                color = Color.DeepSkyBlue;
            control.Hint = str;
            control.BackColour = color;
            control.Size = size;
            control.Location = new System.Drawing.Point((int)((double)MiniMapDialog.ScaleX * (double)ob.Location.X) - size.Width / 2, (int)((double)MiniMapDialog.ScaleY * (double)ob.Location.Y) - size.Height / 2);
            if ((int)MapObject.User.ObjectID != ob.ObjectID)
                return;
            ChangeImageLocation(control);
            UpdatePoint();
        }

        public void UpdateMapPosition()
        {
            ClientObjectData clientObjectData;
            DXControl control;
            if (MapObject.User == null || !GameScene.Game.DataDictionary.TryGetValue(MapObject.User.ObjectID, out clientObjectData) || !MapInfoObjects.TryGetValue((object)clientObjectData, out control))
                return;
            System.Drawing.Point location = control.Location;
            ChangeImageLocation(control);
        }

        private void ChangeImageLocation(DXControl control)
        {
            Size size1 = Image.Zoom ? Image.ScalingSize : Image.Size;
            if (Image.Zoom)
                return;
            int x = -control.Location.X + Size.Width / 2;
            int num1 = -control.Location.Y;
            Size size2 = Size;
            int height1 = size2.Height;
            size2 = Borders[0].Size;
            int height2 = size2.Height;
            int num2 = (height1 - height2) / 2;
            int num3 = num1 + num2;
            Size size3 = Borders[0].Size;
            int height3 = size3.Height;
            int y = num3 + height3;
            int num4 = size1.Width + x;
            size3 = Size;
            int width1 = size3.Width;
            if (num4 < width1)
            {
                int width2 = size1.Width;
                size3 = Size;
                int width3 = size3.Width;
                if (width2 >= width3)
                {
                    int width4 = size1.Width;
                    size3 = Size;
                    int width5 = size3.Width;
                    x = -(width4 - width5);
                }
            }
            int num5 = size1.Height + y;
            size3 = Size;
            int height4 = size3.Height;
            if (num5 <= height4)
            {
                int height5 = size1.Height;
                size3 = Size;
                int height6 = size3.Height;
                size3 = Borders[0].Size;
                int height7 = size3.Height;
                int num6 = height6 - height7;
                if (height5 >= num6)
                {
                    int height8 = size1.Height;
                    size3 = Size;
                    int height9 = size3.Height;
                    y = -(height8 - height9);
                }
            }
            if (x > 0)
                x = 0;
            if (y >= 0)
            {
                size3 = Borders[0].Size;
                y = size3.Height;
            }
            Image.Location = new System.Drawing.Point(x, y);
        }

        public void Remove(object ob)
        {
            DXControl dxControl;
            if (!MapInfoObjects.TryGetValue(ob, out dxControl))
                return;
            dxControl.Dispose();
            MapInfoObjects.Remove(ob);
        }

        public void ChangeSize()
        {
            BringToFront();
            if (!Panel.Visible)
                return;
            switch ((int)Tag)
            {
                case 0:
                    if (Image.Zoom)
                        Image.Zoom = false;
                    Tag = (object)1;
                    Size size1 = Image.Size;
                    int num1;
                    if (size1.Width >= 272)
                    {
                        size1 = Image.Size;
                        num1 = size1.Height >= 285 ? 1 : 0;
                    }
                    else
                        num1 = 0;
                    if (num1 != 0)
                    {
                        Size = new Size(400, 286);
                        break;
                    }
                    Tag = (object)0;
                    Size = MiniMapDialog.NormalSize;
                    break;
                case 1:
                    Size size2 = Image.Size;
                    int num2;
                    if (size2.Width > 400)
                    {
                        size2 = Image.Size;
                        num2 = size2.Height > 286 ? 1 : 0;
                    }
                    else
                        num2 = 0;
                    if (num2 != 0)
                    {
                        DXImageControl image = Image;
                        size2 = Borders[1].Size;
                        int width1 = size2.Width;
                        size2 = Borders[0].Size;
                        int height1 = size2.Height;
                        System.Drawing.Point point = new System.Drawing.Point(width1, height1);
                        image.Location = point;
                        Image.ZoomSize = new Size(400, 286);
                        Image.Zoom = true;
                        size2 = Image.ScalingSize;
                        int width2 = size2.Width;
                        size2 = Image.ZoomSize;
                        int width3 = size2.Width;
                        int num3;
                        if (width2 == width3)
                        {
                            size2 = Image.ScalingSize;
                            int height2 = size2.Height;
                            size2 = Image.ZoomSize;
                            int height3 = size2.Height;
                            num3 = height2 != height3 ? 1 : 0;
                        }
                        else
                            num3 = 1;
                        if (num3 != 0)
                        {
                            size2 = Image.ScalingSize;
                            int width4 = size2.Width;
                            size2 = Borders[1].Size;
                            int num4 = size2.Width * 2;
                            int width5 = width4 + num4;
                            size2 = Image.ScalingSize;
                            int height2 = size2.Height;
                            size2 = Borders[0].Size;
                            int height3 = size2.Height;
                            int num5 = height2 + height3;
                            size2 = Borders[3].Size;
                            int height4 = size2.Height;
                            int height5 = num5 + height4;
                            Size = new Size(width5, height5);
                        }
                        else
                        {
                            int num4 = 400;
                            size2 = Borders[1].Size;
                            int num5 = size2.Width * 2;
                            int width4 = num4 + num5;
                            int num6 = 286;
                            size2 = Borders[0].Size;
                            int height2 = size2.Height;
                            int num7 = num6 + height2;
                            size2 = Borders[3].Size;
                            int height3 = size2.Height;
                            int height4 = num7 + height3;
                            Size = new Size(width4, height4);
                        }
                        ChangeMap();
                        Tag = (object)2;
                        break;
                    }
                    Tag = (object)0;
                    Size = MiniMapDialog.NormalSize;
                    break;
                case 2:
                    if (Image.Zoom)
                        Image.Zoom = false;
                    Tag = (object)0;
                    Size = MiniMapDialog.NormalSize;
                    break;
            }
            _oldSize = Size;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing)
                return;
            Area = Rectangle.Empty;
            MiniMapDialog.ScaleX = 0.0f;
            MiniMapDialog.ScaleY = 0.0f;
            foreach (KeyValuePair<object, DXControl> mapInfoObject in MapInfoObjects)
            {
                if (mapInfoObject.Value != null && !mapInfoObject.Value.IsDisposed)
                    mapInfoObject.Value.Dispose();
            }
            MapInfoObjects.Clear();
            MapInfoObjects = (Dictionary<object, DXControl>)null;
            DisabledMomentLabs();
            if (Image != null)
            {
                if (!Image.IsDisposed)
                    Image.Dispose();
                Image = (DXImageControl)null;
            }
            if (Panel != null)
            {
                if (!Panel.IsDisposed)
                    Panel.Dispose();
                Panel = (DXControl)null;
            }
            if (Borders != null)
            {
                foreach (DXImageControl border in Borders)
                {
                    if (!border.IsDisposed)
                        border.Dispose();
                }
                Borders = (DXImageControl[])null;
            }
            if (Icons != null)
            {
                foreach (DXImageControl icon in Icons)
                {
                    if (!icon.IsDisposed)
                        icon.Dispose();
                }
                Icons = (DXImageControl[])null;
            }
            if (Title != null)
            {
                if (!Title.IsDisposed)
                    Title.Dispose();
                Title = (DXLabel)null;
            }
            if (Point != null)
            {
                if (!Point.IsDisposed)
                    Point.Dispose();
                Point = (DXLabel)null;
            }
            if (PanelBtns != null)
            {
                if (!PanelBtns.IsDisposed)
                    PanelBtns.Dispose();
                PanelBtns = (DXControl)null;
            }
            if (PanelMini != null)
            {
                if (!PanelMini.IsDisposed)
                    PanelMini.Dispose();
                PanelMini = (DXImageControl)null;
            }
            if (MinBtn != null)
            {
                if (!MinBtn.IsDisposed)
                    MinBtn.Dispose();
                MinBtn = (DxMirButton)null;
            }
            if (OpacityBtn != null)
            {
                if (!OpacityBtn.IsDisposed)
                    OpacityBtn.Dispose();
                OpacityBtn = (DXImageControl)null;
            }
            if (LarBtn != null)
            {
                if (!LarBtn.IsDisposed)
                    LarBtn.Dispose();
                LarBtn = (DXImageControl)null;
            }
            if (BigBtn != null)
            {
                if (!BigBtn.IsDisposed)
                    BigBtn.Dispose();
                BigBtn = (DXImageControl)null;
            }
            if (MonsterBtn != null)
            {
                if (!MonsterBtn.IsDisposed)
                    MonsterBtn.Dispose();
                MonsterBtn = (DXImageControl)null;
            }
            if (PanelOver != null)
            {
                if (!PanelOver.IsDisposed)
                    PanelOver.Dispose();
                PanelOver = (DXControl)null;
            }
        }

        private void DisabledMomentLabs()
        {
            foreach (KeyValuePair<object, DXLabel> momentLab in MomentLabs)
            {
                if (momentLab.Value != null && !momentLab.Value.IsDisposed)
                    momentLab.Value.Dispose();
            }
            MomentLabs.Clear();
            MomentLabs = (Dictionary<object, DXLabel>)null;
        }
    }
}
