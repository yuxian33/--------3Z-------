using Client.Controls;
using Client.Envir;
using Client.Models;
using Client.UserModels;
using Library;
using Library.Network;
using Library.Network.ClientPackets;
using Library.SystemModels;
using CartoonMirDB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SlimDX;
using System.Threading;

namespace Client.Scenes.Views
{
    public sealed class BigMapDialog : DXWindow
    {
        public Dictionary<object, DXControl> MapInfoObjects = new Dictionary<object, DXControl>();
        public Dictionary<object, DXLabel> MomentLabs = new Dictionary<object, DXLabel>();
        public Dictionary<object, DXControl> WorldPanels = new Dictionary<object, DXControl>();
        private MapInfo _SelectedInfo;
        public Rectangle Area;
        public DXImageControl Background;
        public DXImageControl Image;
        public DXImageControl CurrentNpc;
        public DXImageControl WorldMap;
        public DXImageControl CurrentWorldMap;
        public DXAnimatedControl Me;
        public DXAnimatedControl MapTitle;
        public DXControl Panel;
        public DXControl NpcPanel;
        public DxMirButton SearchBtn;
        public DxMirButton CurrentMapBtn;
        public DxMirButton WorldBtn;
        public DXLabel Title;
        public DXLabel CurrentNpcBorder;
        public DXLabel CoordinateLabel;
        public DXLabel OverPanel;
        public DXLabel MapTitleText;
        public List<DXLabel> NpcList;
        public DXMirScrollBar NpcScrollBar;
        public DXTextBox SearchBox;
        public static float ScaleX;
        public static float ScaleY;
        public int bSearching;
        public DateTime ClickTick;

        public MapInfo SelectedInfo
        {
            get
            {
                return _SelectedInfo;
            }
            set
            {
                if (_SelectedInfo == value)
                    return;
                MapInfo selectedInfo = _SelectedInfo;
                _SelectedInfo = value;
                OnSelectedInfoChanged(selectedInfo, value);
            }
        }

        public event EventHandler<EventArgs> SelectedInfoChanged;

        public void OnSelectedInfoChanged(MapInfo oValue, MapInfo nValue)
        {
            
            EventHandler<EventArgs> selectedInfoChanged = SelectedInfoChanged;
            if (selectedInfoChanged != null)
                selectedInfoChanged((object)this, EventArgs.Empty);
            CurrentNpc.Visible = false;
            foreach (DXControl dxControl in MapInfoObjects.Values)
                dxControl.Dispose();
            MapInfoObjects.Clear();
            if (SelectedInfo == null)
                return;
            Title.Text = SelectedInfo.Description;
            SearchBox.TextBox.Text = Title.Text;
            Title.Location = new Point((Size.Width - Title.Size.Width) / 2, 8);
            Image.Index = SelectedInfo.MiniMap;
            DXImageControl image = Image;
            Size size = Panel.Size;
            int width1 = size.Width;
            size = Image.ScalingSize;
            int width2 = size.Width;
            int x1 = (width1 - width2) / 2;
            size = Panel.Size;
            int height1 = size.Height;
            size = Image.ScalingSize;
            int height2 = size.Height;
            int y1 = (height1 - height2) / 2;
            Point point1 = new Point(x1, y1);
            image.Location = point1;

            Size mapSize = GetMapSize(SelectedInfo.FileName);
            ScaleX = Image.ScalingSize.Width / (float)mapSize.Width;
            ScaleY = Image.ScalingSize.Height / (float)mapSize.Height;

            Me.Visible = GameScene.Game.MapControl.MapInfo == _SelectedInfo;
            CurrentNpcBorder.Visible = false;
            DisabledNpcList();
            NpcList = new List<DXLabel>();
            int num = 0;
            using (IEnumerator<NPCInfo> enumerator = ((IEnumerable<NPCInfo>)((DBCollection<NPCInfo>)CartoonGlobals.NPCInfoList).Binding).GetEnumerator())
            {
                while (((IEnumerator)enumerator).MoveNext())
                {
                    NPCInfo current = enumerator.Current;
                    Update(current);
                    DXControl dxControl;
                    if (MapInfoObjects.TryGetValue((object)current, out dxControl))
                    {
                        string str = string.IsNullOrEmpty(current?.NPCName) ? "NPC" : current.NPCName;
                        DXLabel dxLabel = new DXLabel();
                        size = NpcPanel.Size;
                        dxLabel.Size = new Size(size.Width, 16);
                        dxLabel.ForeColour = GameScene.Game.MapControl.MapInfo == _SelectedInfo ? Color.White : Color.FromArgb(100, 100, 99);
                        dxLabel.Parent = NpcPanel;
                        dxLabel.AutoSize = false;
                        dxLabel.Text = str;
                        dxLabel.Tag = (object)dxControl;
                        dxLabel.DrawFormat = TextFormatFlags.VerticalCenter;
                        DXLabel label = dxLabel;
                        Point point2 = new Point(0, 19 * num);
                        BigMapDialog.Points points = dxControl.Tag as BigMapDialog.Points;
                        label.MouseClick += (EventHandler<MouseEventArgs>)((s, e) =>
                        {
                            CurrentNpc.Visible = true;
                            CurrentNpc.Location = points.Location;
                            CurrentNpc.Tag = (object)points.Point;
                            CurrentNpcBorder.Visible = true;
                            CurrentNpcBorder.Tag = (object)label;
                            DXLabel currentNpcBorder = CurrentNpcBorder;
                            Point location = label.Location;
                            int x2 = location.X + 1;
                            location = label.Location;
                            int y2 = location.Y + 2;
                            Point point3 = new Point(x2, y2);
                            currentNpcBorder.Location = point3;
                        });
                        NpcList.Add(label);
                        label.Location = point2;
                        ++num;
                    }
                }
            }
            NpcScrollBar.MaxValue = 19 * NpcList.Count;
            DisabledMomentLabs();
            MomentLabs = new Dictionary<object, DXLabel>();
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
        
        private Size GetMapSize(string fileName)
        {
            if (!File.Exists(Config.MapPath + fileName + ".map"))
                return Size.Empty;
            using (FileStream fileStream = File.OpenRead(Config.MapPath + fileName + ".map"))
            {
                using (BinaryReader binaryReader = new BinaryReader((Stream)fileStream))
                {
                    fileStream.Seek(22L, SeekOrigin.Begin);
                    return new Size((int)binaryReader.ReadInt16(), (int)binaryReader.ReadInt16());
                }
            }
        }
        
        /*
        private Size GetMapSize(string fileName)
        {
            if (!File.Exists(Config.MapPath + fileName + ".map"))
            {
                return Size.Empty;
            }
            byte[] array = File.ReadAllBytes(Config.MapPath + fileName + ".map");
            if (array[2] == 67 && array[3] == 35)
            {
                return LoadMapType100(array);
            }
            if (array[0] == 0)
            {
                return LoadMapType5(array);
            }
            if (array[0] == 15 && array[5] == 83 && array[14] == 51)
            {
                return LoadMapType6(array);
            }
            if (array[0] == 21 && array[4] == 50 && array[6] == 65 && array[19] == 49)
            {
                return LoadMapType4(array);
            }
            if (array[0] == 16 && array[2] == 97 && array[7] == 49 && array[14] == 49)
            {
                return LoadMapType1(array);
            }
            if (array[4] == 15 || (array[4] == 3 && array[18] == 13 && array[19] == 10))
            {
                int num = array[0] + (array[1] << 8);
                int num2 = array[2] + (array[3] << 8);
                if (array.Length > 52 + num * num2 * 14)
                {
                    return LoadMapType3(array);
                }
                return LoadMapType2(array);
            }
            if (array[0] == 13 && array[1] == 76 && array[7] == 32 && array[11] == 109)
            {
                return LoadMapType7(array);
            }
            return LoadMapType0(array);
        }
        */
        private Size LoadMapType0(byte[] Bytes)
        {
            try
            {
                int num = 0;
                int width = BitConverter.ToInt16(Bytes, num);
                num += 2;
                int height = BitConverter.ToInt16(Bytes, num);
                return new Size(width, height);
            }
            catch (Exception ex)
            {
                CEnvir.SaveError(ex.ToString());
            }
            return Size.Empty;
        }

        private Size LoadMapType1(byte[] Bytes)
        {
            try
            {
                int num = 21;
                int num2 = BitConverter.ToInt16(Bytes, num);
                num += 2;
                int num3 = BitConverter.ToInt16(Bytes, num);
                num += 2;
                int num4 = BitConverter.ToInt16(Bytes, num);
                int width = num2 ^ num3;
                int height = num4 ^ num3;
                return new Size(width, height);
            }
            catch (Exception ex)
            {
                CEnvir.SaveError(ex.ToString());
            }
            return Size.Empty;
        }

        private Size LoadMapType2(byte[] Bytes)
        {
            try
            {
                int num = 0;
                int width = BitConverter.ToInt16(Bytes, num);
                num += 2;
                int height = BitConverter.ToInt16(Bytes, num);
                return new Size(width, height);
            }
            catch (Exception ex)
            {
                CEnvir.SaveError(ex.ToString());
            }
            return Size.Empty;
        }

        private Size LoadMapType3(byte[] Bytes)
        {
            try
            {
                int num = 0;
                int width = BitConverter.ToInt16(Bytes, num);
                num += 2;
                int height = BitConverter.ToInt16(Bytes, num);
                return new Size(width, height);
            }
            catch (Exception ex)
            {
                CEnvir.SaveError(ex.ToString());
            }
            return Size.Empty;
        }

        private Size LoadMapType4(byte[] Bytes)
        {
            try
            {
                int num = 31;
                int num2 = BitConverter.ToInt16(Bytes, num);
                num += 2;
                int num3 = BitConverter.ToInt16(Bytes, num);
                num += 2;
                int num4 = BitConverter.ToInt16(Bytes, num);
                int width = num2 ^ num3;
                int height = num4 ^ num3;
                return new Size(width, height);
            }
            catch (Exception ex)
            {
                CEnvir.SaveError(ex.ToString());
            }
            return Size.Empty;
        }

        private Size LoadMapType5(byte[] Bytes)
        {
            try
            {
                int num = 20;
                short num2 = BitConverter.ToInt16(Bytes, num);
                int width = BitConverter.ToInt16(Bytes, num += 2);
                int height = BitConverter.ToInt16(Bytes, num += 2);
                return new Size(width, height);
            }
            catch (Exception ex)
            {
                CEnvir.SaveError(ex.ToString());
            }
            return Size.Empty;
        }

        private Size LoadMapType6(byte[] Bytes)
        {
            try
            {
                
                int num = 16;
                int width = BitConverter.ToInt16(Bytes, num);
                num += 2;
                int height = BitConverter.ToInt16(Bytes, num);
                return new Size(width, height);
            }
            catch (Exception ex)
            {
                CEnvir.SaveError(ex.ToString());
            }
            return Size.Empty;
        }

        private Size LoadMapType7(byte[] Bytes)
        {
            try
            {
                int num = 21;
                int width = BitConverter.ToInt16(Bytes, num);
                num += 4;
                int height = BitConverter.ToInt16(Bytes, num);
                return new Size(width, height);
            }
            catch (Exception ex)
            {
                CEnvir.SaveError(ex.ToString());
            }
            return Size.Empty;
        }

        private Size LoadMapType100(byte[] Bytes)
        {
            try
            {
                int num = 4;
                if (Bytes[0] != 1 || Bytes[1] != 0)
                {
                    return Size.Empty;
                }
                int width = BitConverter.ToInt16(Bytes, num);
                num += 2;
                int height = BitConverter.ToInt16(Bytes, num);
                return new Size(width, height);
            }
            catch (Exception ex)
            {
                CEnvir.SaveError(ex.ToString());
            }
            return Size.Empty;
        }

        public override void OnClientAreaChanged(Rectangle oValue, Rectangle nValue)
        {
            base.OnClientAreaChanged(oValue, nValue);

            if (Panel == null) return;

            Panel.Location = ClientArea.Location;
            Panel.Size = ClientArea.Size;
        }

        public override void OnIsVisibleChanged(bool oValue, bool nValue)
        {
            base.OnIsVisibleChanged(oValue, nValue);
            SelectedInfo = IsVisible ? GameScene.Game.MapControl.MapInfo : (MapInfo)null;
        }

        public override void OnOpacityChanged(float oValue, float nValue)
        {
            base.OnOpacityChanged(oValue, nValue);

            foreach (DXControl control in Controls)
                control.Opacity = Opacity;

            foreach (DXControl control in MapInfoObjects.Values)
                control.Opacity = Opacity;

            if (Image != null)
            {
                Image.Opacity = Opacity;
                Image.ImageOpacity = 0.9f;
            }
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

        public BigMapDialog()
        {
            Opacity = 0.0f;
            HasFooter = false;
            HasTopBorder = false;
            HasTitle = false;
            AllowResize = false;
            Movable = true;
            DXImageControl dxImageControl1 = new DXImageControl();
            dxImageControl1.LibraryFile = (LibraryFile)3;
            dxImageControl1.Index = 6100;
            dxImageControl1.Parent = (DXControl)this;
            Background = dxImageControl1;
            Background.MouseDown += (EventHandler<MouseEventArgs>)((s, e) => OnMouseDown(e));
            Background.MouseEnter += (EventHandler<EventArgs>)((s, e) =>
            {
                OverPanel.Visible = false;
                CurrentWorldMap.Visible = false;
                MapTitle.Visible = false;
                MapTitleText.Visible = false;
            });
            Size = Background.Size;
            CloseButton.Parent = Background;
            DXLabel dxLabel1 = new DXLabel();
            dxLabel1.Parent = (DXControl)this;
            dxLabel1.ForeColour = Color.White;
            dxLabel1.Font = CGlobal.BlodFont;
            dxLabel1.DrawFormat = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
            Title = dxLabel1;
            Panel = new DXControl()
            {
                Parent = (DXControl)Background,
                Location = new Point(8, 45),
                Size = new Size(600, 420),
                BackColour = Color.Black
            };
            DXImageControl dxImageControl2 = new DXImageControl();
            dxImageControl2.Parent = Panel;
            dxImageControl2.LibraryFile = LibraryFile.MiniMap;
            dxImageControl2.ZoomSize = new Size(600, 420);
            dxImageControl2.ImageOpacity = 0.9f;
            dxImageControl2.Zoom = true;
            Image = dxImageControl2;
            Image.MouseMove += new EventHandler<MouseEventArgs>(Image_MouseMove);
            Image.MouseClick += new EventHandler<MouseEventArgs>(Image_MouseClick);
            Image.MouseEnter += (EventHandler<EventArgs>)((s, e) => CoordinateLabel.Visible = true);
            Image.MouseLeave += (EventHandler<EventArgs>)((s, e) => CoordinateLabel.Visible = false);
            DXLabel dxLabel2 = new DXLabel();
            dxLabel2.Parent = Panel;
            dxLabel2.AutoSize = false;
            dxLabel2.Size = new Size(54, 20);
            dxLabel2.ForeColour = Color.White;
            dxLabel2.DrawFormat = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
            Size size1 = Panel.Size;
            int x1 = size1.Width - 54;
            size1 = Panel.Size;
            int y1 = size1.Height - 22;
            dxLabel2.Location = new Point(x1, y1);
            CoordinateLabel = dxLabel2;
            DXImageControl dxImageControl3 = new DXImageControl();
            dxImageControl3.Parent = (DXControl)Image;
            dxImageControl3.LibraryFile = (LibraryFile)3;
            dxImageControl3.Index = 6132;
            dxImageControl3.Visible = false;
            CurrentNpc = dxImageControl3;
            CurrentNpc.MouseEnter += (EventHandler<EventArgs>)((s, e) => ChangeCoordinate((Point)CurrentNpc.Tag));
            DXAnimatedControl dxAnimatedControl1 = new DXAnimatedControl();
            dxAnimatedControl1.Parent = (DXControl)Image;
            dxAnimatedControl1.LibraryFile = (LibraryFile)3;
            dxAnimatedControl1.BaseIndex = 6130;
            dxAnimatedControl1.Animated = true;
            dxAnimatedControl1.AnimationDelay = TimeSpan.FromSeconds(1.0);
            dxAnimatedControl1.FrameCount = 2;
            Me = dxAnimatedControl1;
            Me.MouseEnter += (EventHandler<EventArgs>)((s, e) => ChangeCoordinate((Point)Me.Tag));
            NpcPanel = new DXControl()
            {
                Parent = (DXControl)Background,
                Location = new Point(Size.Width - 170, 83),
                Size = new Size(140, 340)
            };
            DXMirScrollBar dxMirScrollBar = new DXMirScrollBar()
            {
                Parent = Background,
                Location = new Point(NpcPanel.Location.X + NpcPanel.Size.Width + 4, NpcPanel.Location.Y - 2),
                Size = new Size(16, NpcPanel.Size.Height + 8),
            };
            NpcScrollBar = dxMirScrollBar;
            NpcScrollBar.ValueChanged += (EventHandler<EventArgs>)((o, e) => UpdateLocations());
            NpcScrollBar.Change = 19;
            NpcScrollBar.VisibleSize = NpcScrollBar.Size.Height;
            DXLabel dxLabel3 = new DXLabel();
            dxLabel3.Size = new Size(NpcPanel.Size.Width - 2, 16);
            dxLabel3.Border = true;
            dxLabel3.Parent = NpcPanel;
            dxLabel3.BorderColour = Color.FromArgb(205, (int)byte.MaxValue, 0);
            dxLabel3.Visible = false;
            CurrentNpcBorder = dxLabel3;
            DXImageControl dxImageControl4 = new DXImageControl();
            dxImageControl4.LibraryFile = (LibraryFile)280;
            dxImageControl4.Index = 0;
            dxImageControl4.Parent = (DXControl)Background;
            dxImageControl4.FixedSize = true;
            dxImageControl4.Size = new Size(770, 415);
            dxImageControl4.Visible = false;
            dxImageControl4.Location = Panel.Location;
            WorldMap = dxImageControl4;
            DXImageControl dxImageControl5 = new DXImageControl();
            dxImageControl5.LibraryFile = (LibraryFile)280;
            dxImageControl5.Parent = (DXControl)WorldMap;
            dxImageControl5.Visible = false;
            CurrentWorldMap = dxImageControl5;
            CurrentWorldMap.MouseLeave += (EventHandler<EventArgs>)((s, e) =>
            {
                CurrentWorldMap.Visible = false;
                MapTitle.Visible = false;
                MapTitleText.Visible = false;
            });
            CurrentWorldMap.MouseClick += (EventHandler<MouseEventArgs>)((s, e) =>
            {
                Panel.Size = new Size(600, 420);
                Panel.Visible = true;
                NpcPanel.Visible = true;
                WorldMap.Visible = false;
                CoordinateLabel.Text = "[0, 0]";
                MapInfo mapInfo = ((IEnumerable<MapInfo>)((DBCollection<MapInfo>)CartoonGlobals.MapInfoList).Binding).FirstOrDefault<MapInfo>((Func<MapInfo, bool>)(p => p.FileName == CurrentWorldMap.Tag.ToString()));
                if (mapInfo == null)
                    return;
                SelectedInfo = mapInfo;
            });
            DXLabel dxLabel4 = new DXLabel();
            dxLabel4.Border = false;
            dxLabel4.BackColour = Color.Black;
            dxLabel4.Size = WorldMap.Size;
            dxLabel4.Opacity = 0.8f;
            dxLabel4.Parent = (DXControl)WorldMap;
            dxLabel4.Visible = false;
            OverPanel = dxLabel4;
            DXImageControl dxImageControl6 = new DXImageControl();
            dxImageControl6.Blend = true;
            dxImageControl6.LibraryFile = (LibraryFile)280;
            dxImageControl6.Index = 2;
            dxImageControl6.Parent = (DXControl)WorldMap;
            dxImageControl6.ImageOpacity = 0.8f;
            dxImageControl6.Visible = false;
            dxImageControl6.Location = new Point(0, 0);
            if (CEnvir.Now.Month == 11 || CEnvir.Now.Month == 12 || CEnvir.Now.Month == 1)
            {
                DXImageControl dxImageControl7 = new DXImageControl();
                dxImageControl7.Blend = true;
                dxImageControl7.LibraryFile = (LibraryFile)280;
                dxImageControl7.Index = 1;
                dxImageControl7.Parent = (DXControl)WorldMap;
                dxImageControl7.Visible = false;
                dxImageControl7.Location = new Point(0, 0);
            }
            string str1 = "15";
            WorldPanels[(object)str1] = new DXControl()
            {
                Size = new Size(110, 136),
                Parent = (DXControl)WorldMap,
                Location = new Point(350, 20),
                Tag = (object)new BigMapDialog.MapIndex()
                {
                    Index = 29,
                    FileName = str1
                }
            };
            WorldPanels[(object)str1].MouseEnter += new EventHandler<EventArgs>(WorldPanel_MouseEnter);
            string str2 = "D009";
            WorldPanels[(object)str2] = new DXControl()
            {
                Size = new Size(174, 64),
                Parent = (DXControl)WorldMap,
                Location = new Point(595, 0),
                Tag = (object)new BigMapDialog.MapIndex()
                {
                    Index = 38,
                    FileName = str2
                }
            };
            WorldPanels[(object)str2].MouseEnter += new EventHandler<EventArgs>(WorldPanel_MouseEnter);
            string str3 = "8";
            WorldPanels[(object)str3] = new DXControl()
            {
                Size = new Size(226, 112),
                Parent = (DXControl)WorldMap,
                Location = new Point(420, 0),
                Tag = (object)new BigMapDialog.MapIndex()
                {
                    Index = 28,
                    FileName = str3
                }
            };
            WorldPanels[(object)str3].MouseEnter += new EventHandler<EventArgs>(WorldPanel_MouseEnter);
            string str4 = "1";
            WorldPanels[(object)str4] = new DXControl()
            {
                Size = new Size(124, 120),
                Parent = (DXControl)WorldMap,
                Location = new Point(525, 95),
                Tag = (object)new BigMapDialog.MapIndex()
                {
                    Index = 25,
                    FileName = str4
                }
            };
            WorldPanels[(object)str4].MouseEnter += new EventHandler<EventArgs>(WorldPanel_MouseEnter);
            string str5 = "0";
            WorldPanels[(object)str5] = new DXControl()
            {
                Size = new Size(156, 144),
                Parent = (DXControl)WorldMap,
                Location = new Point(615, 85),
                Tag = (object)new BigMapDialog.MapIndex()
                {
                    Index = 20,
                    FileName = str5
                }
            };
            WorldPanels[(object)str5].MouseEnter += new EventHandler<EventArgs>(WorldPanel_MouseEnter);
            string str6 = "5";
            WorldPanels[(object)str6] = new DXControl()
            {
                Size = new Size(184, 148),
                Parent = (DXControl)WorldMap,
                Location = new Point(435, 150),
                Tag = (object)new BigMapDialog.MapIndex()
                {
                    Index = 23,
                    FileName = str6
                }
            };
            WorldPanels[(object)str6].MouseEnter += new EventHandler<EventArgs>(WorldPanel_MouseEnter);
            string str7 = "3";
            WorldPanels[(object)str7] = new DXControl()
            {
                Size = new Size(116, 86),
                Parent = (DXControl)WorldMap,
                Location = new Point(600, 178),
                Tag = (object)new BigMapDialog.MapIndex()
                {
                    Index = 21,
                    FileName = str7
                }
            };
            WorldPanels[(object)str7].MouseEnter += new EventHandler<EventArgs>(WorldPanel_MouseEnter);
            string str8 = "4";
            WorldPanels[(object)str8] = new DXControl()
            {
                Size = new Size(216, 192),
                Parent = (DXControl)WorldMap,
                Location = new Point(375, 185),
                Tag = (object)new BigMapDialog.MapIndex()
                {
                    Index = 24,
                    FileName = str8
                }
            };
            WorldPanels[(object)str8].MouseEnter += new EventHandler<EventArgs>(WorldPanel_MouseEnter);
            string str9 = "2";
            WorldPanels[(object)str9] = new DXControl()
            {
                Size = new Size(95, 95),
                Parent = (DXControl)WorldMap,
                Location = new Point(687, 278),
                Tag = (object)new BigMapDialog.MapIndex()
                {
                    Index = 22,
                    FileName = str9
                }
            };
            WorldPanels[(object)str9].MouseEnter += new EventHandler<EventArgs>(WorldPanel_MouseEnter);
            string str10 = "12";
            WorldPanels[(object)str10] = new DXControl()
            {
                Size = new Size(90, 64),
                Parent = (DXControl)WorldMap,
                Location = new Point(605, 308),
                Tag = (object)new BigMapDialog.MapIndex()
                {
                    Index = 35,
                    FileName = str10
                }
            };
            WorldPanels[(object)str10].MouseEnter += new EventHandler<EventArgs>(WorldPanel_MouseEnter);
            string str11 = "D010";
            WorldPanels[(object)str11] = new DXControl()
            {
                Size = new Size(156, 94),
                Parent = (DXControl)WorldMap,
                Location = new Point(580, 45),
                Tag = (object)new BigMapDialog.MapIndex()
                {
                    Index = 26,
                    FileName = str11
                }
            };
            WorldPanels[(object)str11].MouseEnter += new EventHandler<EventArgs>(WorldPanel_MouseEnter);
            string str12 = "D005";
            WorldPanels[(object)str12] = new DXControl()
            {
                Size = new Size(110, 88),
                Parent = (DXControl)WorldMap,
                Location = new Point(475, 65),
                Tag = (object)new BigMapDialog.MapIndex()
                {
                    Index = 27,
                    FileName = str12
                }
            };
            WorldPanels[(object)str12].MouseEnter += new EventHandler<EventArgs>(WorldPanel_MouseEnter);
            string str13 = "15_001";
            WorldPanels[(object)str13] = new DXControl()
            {
                Size = new Size(142, 102),
                Parent = (DXControl)WorldMap,
                Location = new Point(270, 25),
                Tag = (object)new BigMapDialog.MapIndex()
                {
                    Index = 30,
                    FileName = str13
                }
            };
            WorldPanels[(object)str13].MouseEnter += new EventHandler<EventArgs>(WorldPanel_MouseEnter);
            string str14 = "15_003";
            WorldPanels[(object)str14] = new DXControl()
            {
                Size = new Size(146, 110),
                Parent = (DXControl)WorldMap,
                Location = new Point(260, 85),
                Tag = (object)new BigMapDialog.MapIndex()
                {
                    Index = 31,
                    FileName = str14
                }
            };
            WorldPanels[(object)str14].MouseEnter += new EventHandler<EventArgs>(WorldPanel_MouseEnter);
            string str15 = "D3904";
            WorldPanels[(object)str15] = new DXControl()
            {
                Size = new Size(154, 142),
                Parent = (DXControl)WorldMap,
                Location = new Point(150, 65),
                Tag = (object)new BigMapDialog.MapIndex()
                {
                    Index = 32,
                    FileName = str15
                }
            };
            WorldPanels[(object)str15].MouseEnter += new EventHandler<EventArgs>(WorldPanel_MouseEnter);
            string str16 = "19";
            WorldPanels[(object)str16] = new DXControl()
            {
                Size = new Size(262, 220),
                Parent = (DXControl)WorldMap,
                Location = new Point(138, 155),
                Tag = (object)new BigMapDialog.MapIndex()
                {
                    Index = 33,
                    FileName = str16
                }
            };
            WorldPanels[(object)str16].MouseEnter += new EventHandler<EventArgs>(WorldPanel_MouseEnter);
            string str17 = "17";
            WorldPanels[(object)str17] = new DXControl()
            {
                Size = new Size(198, 196),
                Parent = (DXControl)WorldMap,
                Location = new Point(43, 230),
                Tag = (object)new BigMapDialog.MapIndex()
                {
                    Index = 34,
                    FileName = str17
                }
            };
            WorldPanels[(object)str17].MouseEnter += new EventHandler<EventArgs>(WorldPanel_MouseEnter);
            string str18 = "20";
            WorldPanels[(object)str18] = new DXControl()
            {
                Size = new Size(94, 86),
                Parent = (DXControl)WorldMap,
                Location = new Point(515, 335),
                Tag = (object)new BigMapDialog.MapIndex()
                {
                    Index = 36,
                    FileName = str18
                }
            };
            WorldPanels[(object)str18].MouseEnter += new EventHandler<EventArgs>(WorldPanel_MouseEnter);
            string str19 = "D3400";
            WorldPanels[(object)str19] = new DXControl()
            {
                Size = new Size(114, 82),
                Parent = (DXControl)WorldMap,
                Location = new Point(670, 345),
                Tag = (object)new BigMapDialog.MapIndex()
                {
                    Index = 37,
                    FileName = str19
                }
            };
            WorldPanels[(object)str19].MouseEnter += new EventHandler<EventArgs>(WorldPanel_MouseEnter);
            DXAnimatedControl dxAnimatedControl2 = new DXAnimatedControl();
            dxAnimatedControl2.LibraryFile = (LibraryFile)3;
            dxAnimatedControl2.BaseIndex = 6160;
            dxAnimatedControl2.AnimationDelay = TimeSpan.FromMilliseconds(300.0);
            dxAnimatedControl2.FrameCount = 5;
            dxAnimatedControl2.Parent = (DXControl)WorldMap;
            dxAnimatedControl2.Location = new Point((WorldMap.Size.Width - 180) / 2, 4);
            dxAnimatedControl2.Loop = false;
            dxAnimatedControl2.Visible = false;
            MapTitle = dxAnimatedControl2;
            DXLabel dxLabel5 = new DXLabel();
            dxLabel5.Text = "";
            dxLabel5.Border = false;
            dxLabel5.Outline = false;
            dxLabel5.ForeColour = Color.FromArgb(58, 58, 42);
            dxLabel5.Font = new Font(Config.FontName, CEnvir.FontSize(18f));
            dxLabel5.Parent = (DXControl)WorldMap;
            dxLabel5.Visible = false;
            MapTitleText = dxLabel5;
            MapTitle.IndexChanged += (EventHandler<EventArgs>)((s, e) =>
            {
                if (MapTitle.FrameCount == 6 || MapTitle.Index != MapTitle.BaseIndex + 2)
                    return;
                MapTitleText.Visible = false;
            });
            MapTitle.AfterAnimation += (EventHandler)((s, e) =>
            {
                if (MapTitle.FrameCount != 6)
                    return;
                MapTitle.BaseIndex = 6160;
                MapTitle.FrameCount = 5;
                MapTitle.AnimationStart = DateTime.MinValue;
                MapTitle.Animated = true;
            });
            DxMirButton dxMirButton1 = new DxMirButton();
            dxMirButton1.MirButtonType = MirButtonType.FourStatu;
            dxMirButton1.LibraryFile = (LibraryFile)3;
            dxMirButton1.Index = 6187;
            dxMirButton1.Parent = (DXControl)Background;
            dxMirButton1.Location = new Point(15, Size.Height - 49);
            SearchBtn = dxMirButton1;
            SearchBtn.MouseClick += (EventHandler<MouseEventArgs>)((s, e) =>
            {
                string value = SearchBox.TextBox.Text.Trim();
                if (string.IsNullOrEmpty(value))
                    return;
                Panel.Size = new Size(600, 420);
                Panel.Visible = true;
                NpcPanel.Visible = true;
                WorldMap.Visible = false;
                MapInfo mapInfo = ((IEnumerable<MapInfo>)((DBCollection<MapInfo>)CartoonGlobals.MapInfoList).Binding).FirstOrDefault<MapInfo>((Func<MapInfo, bool>)(p => p.Description == value));
                if (mapInfo != null)
                {
                    SelectedInfo = mapInfo;
                    if (string.IsNullOrEmpty(Title.Text))
                        Title.Text = mapInfo.Description;
                }
            });
            DxMirButton dxMirButton2 = new DxMirButton();
            dxMirButton2.MirButtonType = MirButtonType.FourStatu;
            dxMirButton2.LibraryFile = (LibraryFile)3;
            dxMirButton2.Index = 6177;
            dxMirButton2.Parent = (DXControl)Background;
            int x3 = SearchBtn.Location.X + 420;
            Point location2 = SearchBtn.Location;
            int y3 = location2.Y + 2;
            dxMirButton2.Location = new Point(x3, y3);
            WorldBtn = dxMirButton2;
            WorldBtn.MouseClick += (EventHandler<MouseEventArgs>)((s, e) =>
            {
                Panel.Visible = false;
                WorldMap.Visible = false;
                NpcPanel.Visible = false;
                Title.Text = "";
                Panel.Size = new Size(770, 420);
            });
            DxMirButton dxMirButton3 = new DxMirButton();
            dxMirButton3.MirButtonType = MirButtonType.FourStatu;
            dxMirButton3.LibraryFile = (LibraryFile)3;
            dxMirButton3.Index = 6172;
            dxMirButton3.Parent = (DXControl)Background;
            location2 = WorldBtn.Location;
            int x4 = location2.X + WorldBtn.Size.Width + 15;
            location2 = WorldBtn.Location;
            int y4 = location2.Y;
            dxMirButton3.Location = new Point(x4, y4);
            CurrentMapBtn = dxMirButton3;
            CurrentMapBtn.MouseClick += (EventHandler<MouseEventArgs>)((s, e) =>
            {
                Panel.Size = new Size(600, 420);
                Panel.Visible = true;
                NpcPanel.Visible = true;
                WorldMap.Visible = false;
                SelectedInfo = GameScene.Game.MapControl.MapInfo;
                if (!string.IsNullOrEmpty(Title.Text))
                    return;
                Title.Text = GameScene.Game.MapControl.MapInfo.Description;
            });
            DXImageControl dxImageControl8 = new DXImageControl();
            dxImageControl8.LibraryFile = (LibraryFile)3;
            dxImageControl8.Index = 6190;
            dxImageControl8.Parent = (DXControl)Background;
            location2 = SearchBtn.Location;
            int x5 = location2.X;
            Size size2 = SearchBtn.Size;
            int width1 = size2.Width;
            int x6 = x5 + width1 + 5;
            location2 = SearchBtn.Location;
            int y5 = location2.Y + 5;
            dxImageControl8.Location = new Point(x6, y5);
            DXImageControl dxImageControl9 = dxImageControl8;
            DXTextBox dxTextBox = new DXTextBox();
            dxTextBox.Parent = (DXControl)dxImageControl9;
            size2 = dxImageControl9.Size;
            int width2 = size2.Width - 6;
            size2 = dxImageControl9.Size;
            int height = size2.Height - 4;
            dxTextBox.Size = new Size(width2, height);
            dxTextBox.Location = new Point(4, 1);
            dxTextBox.Border = false;
            dxTextBox.BackColour = Color.FromArgb(19, 8, 6);
            dxTextBox.Opacity = 1f;
            dxTextBox.ForeColour = Color.White;
            SearchBox = dxTextBox;
        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            if (Image.Index == 0)
                return;
            int x1 = e.Location.X;
            Rectangle displayArea = Image.DisplayArea;
            int x2 = displayArea.X;
            int x3 = (int)((double)(x1 - x2) / (double)BigMapDialog.ScaleX);
            int y1 = e.Location.Y;
            displayArea = Image.DisplayArea;
            int y2 = displayArea.Y;
            int y3 = (int)((double)(y1 - y2) / (double)BigMapDialog.ScaleY);
            ChangeCoordinate(x3, y3);
        }

        private void ChangeCoordinate(Point point)
        {
            CoordinateLabel.Visible = true;
            CoordinateLabel.Text = string.Format("[{0}, {1}]", (object)point.X, (object)point.Y);
        }

        private void ChangeCoordinate(int x, int y)
        {
            ChangeCoordinate(new Point(x, y));
        }

        private void WorldPanel_MouseEnter(object sender, EventArgs e)
        {
            DXControl dxControl = sender as DXControl;
            CurrentWorldMap.Parent = dxControl;
            BigMapDialog.MapIndex map = (BigMapDialog.MapIndex)dxControl.Tag;
            CurrentWorldMap.Visible = true;
            CurrentWorldMap.Index = map.Index;
            CurrentWorldMap.Tag = (object)map.FileName;
            OverPanel.Visible = true;
            MapTitleText.Text = ((IEnumerable<MapInfo>)((DBCollection<MapInfo>)CartoonGlobals.MapInfoList).Binding).FirstOrDefault<MapInfo>((Func<MapInfo, bool>)(p => p.FileName == map.FileName))?.Description;
            MapTitleText.Location = new Point((WorldMap.Size.Width - MapTitleText.Size.Width) / 2, MapTitle.Location.Y + 10);
            MapTitle.BaseIndex = 6164;
            MapTitle.FrameCount = 6;
            MapTitle.Visible = true;
            MapTitle.AnimationStart = DateTime.MinValue;
            MapTitle.Animated = true;
        }

        private void UpdateLocations()
        {
            int y = -(NpcScrollBar.Value - NpcScrollBar.Value % NpcScrollBar.Change);
            foreach (DXLabel npc in NpcList)
            {
                npc.Location = new Point(npc.Location.X, y);
                y += 19;
            }
            if (!CurrentNpcBorder.Visible)
                return;
            DXLabel tag = CurrentNpcBorder.Tag as DXLabel;
            CurrentNpcBorder.Location = new Point(tag.Location.X + 1, tag.Location.Y + 2);
        }

        private void Image_MouseClick(object sender, MouseEventArgs e)
        {
            GameScene.Game.MapControl.AutoPath = false;
            int x = (int)((double)(e.Location.X - Image.DisplayArea.X) / (double)BigMapDialog.ScaleX);
            int y = (int)((double)(e.Location.Y - Image.DisplayArea.Y) / (double)BigMapDialog.ScaleY);

            if ((e.Button & MouseButtons.Right) == MouseButtons.Right)
            {
                int x1 = e.Location.X;
                Rectangle displayArea = Image.DisplayArea;
                int x2 = displayArea.X;
                int x3 = (int)((double)(x1 - x2) / (double)BigMapDialog.ScaleX);
                int y1 = e.Location.Y;
                displayArea = Image.DisplayArea;
                int y2 = displayArea.Y;
                int y3 = (int)((double)(y1 - y2) / (double)BigMapDialog.ScaleY);
                TeleportRing teleportRing = new TeleportRing();
                teleportRing.Location = new Point(x3, y3);
                teleportRing.Index = ((DBObject)SelectedInfo).Index;
                CEnvir.Enqueue((Packet)teleportRing);
            }
            else
            {
                if ((e.Button & MouseButtons.Left) != MouseButtons.Left)
                    return;
                DateTime clickTick = ClickTick;
                ClickTick = CEnvir.Now;
                if (clickTick.AddSeconds(1.0) > ClickTick)
                    GameScene.Game.ReceiveChat("你点击的太快了，请稍侯再试。。。", MessageType.System);
                else if (Interlocked.Exchange(ref bSearching, 1) == 0)
                {
                    try
                    {
                        GameScene.Game.MapControl.AutoPath = false;
                        PathFinder pathFinder = new PathFinder(GameScene.Game.MapControl);
                        List<Client.Models.Node> path = pathFinder.FindPath(MapObject.User.CurrentLocation, new Point(x, y));
                        if (path == null || path.Count == 0)
                        {
                            GameScene.Game.ReceiveChat("无法找到合适的路径", MessageType.System);
                        }
                        else
                        {
                            GameScene.Game.MapControl.PathFinder = pathFinder;
                            GameScene.Game.MapControl.CurrentPath = path;
                            GameScene.Game.MapControl.AutoPath = true;
                        }
                    }
                    finally
                    {
                        Interlocked.Exchange(ref bSearching, 0);
                    }
                }
                else
                    GameScene.Game.ReceiveChat("正在为你查找合适的线路，请稍等。。。", MessageType.System);
            }
        }

        public override void Draw()
        {

            Size size;
            int num1;
            if (IsVisible)
            {
                size = Size;
                if (size.Width != 0)
                {
                    size = Size;
                    num1 = size.Height == 0 ? 1 : 0;
                    goto label_4;
                }
            }
            num1 = 1;
        label_4:
            if (num1 != 0)
                return;

            OnBeforeDraw();
            DrawControl();
            OnBeforeChildrenDraw();
            DrawChildControls();
            DrawWindow();
            TitleLabel.Draw();
            DrawBorder();
            OnAfterDraw();
            if (!GameScene.Game.MapControl.AutoPath)
                return;
            List<Vector2> vector2List = new List<Vector2>();
            Color cyan = Color.Cyan;
            foreach (Node node in GameScene.Game.MapControl.CurrentPath)
            {
                double num2 = (double)node.Location.X * (double)BigMapDialog.ScaleX;
                Rectangle displayArea = Image.DisplayArea;
                double x1 = (double)displayArea.X;
                float x2 = (float)(num2 + x1);
                double num3 = (double)node.Location.Y * (double)BigMapDialog.ScaleY;
                displayArea = Image.DisplayArea;
                double y1 = (double)displayArea.Y;
                float y2 = (float)(num3 + y1);
                double num4 = (double)x2;
                size = Size;
                int width = size.Width;
                displayArea = Image.DisplayArea;
                int x3 = displayArea.X;
                double num5 = (double)(width + x3 - 24);
                int num6;
                if (num4 <= num5)
                {
                    double num7 = (double)y2;
                    displayArea = Image.DisplayArea;
                    int y3 = displayArea.Y;
                    size = Size;
                    int height = size.Height;
                    double num8 = (double)(y3 + height - 48);
                    num6 = num7 > num8 ? 1 : 0;
                }
                else
                    num6 = 1;
                if (num6 == 0)
                    vector2List.Add(new Vector2(x2, y2));
            }
            if (vector2List.Count > 1)
                DXManager.Line.Draw(vector2List.ToArray(), cyan);
        }
        /*
        public void Update(NPCInfo ob)
        {
            if (SelectedInfo == null) return;

            DXControl control;

            if (!MapInfoObjects.TryGetValue(ob, out control))
            {
                if (ob.Region?.Map != SelectedInfo) return;

                control = GameScene.Game.GetNPCControl(ob);
                control.Parent = Image;
                control.Opacity = Opacity;
                MapInfoObjects[ob] = control;
            }
            else if ((QuestIcon)control.Tag == ob.CurrentIcon) return;

            control.Dispose();
            MapInfoObjects.Remove(ob);
            if (ob.Region?.Map != SelectedInfo) return;

            control = GameScene.Game.GetNPCControl(ob);
            control.Parent = Image;
            control.Opacity = Opacity;
            MapInfoObjects[ob] = control;

            Size size = GetMapSize(SelectedInfo.FileName);

            if (ob.Region.PointList == null)
                ob.Region.CreatePoints(size.Width);

            int minX = size.Width, maxX = 0, minY = size.Height, maxY = 0;

            foreach (Point point in ob.Region.PointList)
            {
                if (point.X < minX)
                    minX = point.X;
                if (point.X > maxX)
                    maxX = point.X;

                if (point.Y < minY)
                    minY = point.Y;
                if (point.Y > maxY)
                    maxY = point.Y;
            }

            int x = (minX + maxX) / 2;
            int y = (minY + maxY) / 2;


            control.Location = new Point((int)(ScaleX * x) - control.Size.Width / 2, (int)(ScaleY * y) - control.Size.Height / 2);
        }
        */

        public void Update(NPCInfo ob)
        {
            if (SelectedInfo == null)
                return;
            DXControl npcControl1;
            if (!MapInfoObjects.TryGetValue((object)ob, out npcControl1))
            {
                if (ob.Region?.Map != SelectedInfo)
                    return;
                npcControl1 = GameScene.Game.GetNPCControl(ob);
                npcControl1.Parent = (DXControl)Image;
                npcControl1.Visible = false;
                MapInfoObjects[(object)ob] = npcControl1;
            }
            

            npcControl1.Dispose();
            MapInfoObjects.Remove(ob);
            if (ob.Region?.Map != SelectedInfo) return;
            DXControl npcControl2 = GameScene.Game.GetNPCControl(ob);
            npcControl2.Visible = npcControl2.GetType() == typeof(DXImageControl);
            npcControl2.Parent = (DXControl)Image;
            MapInfoObjects[(object)ob] = npcControl2;
            Size mapSize = GetMapSize(SelectedInfo.FileName);

            if (ob.Region.PointList == null)
                ob.Region.CreatePoints(mapSize.Width);

            int num1 = mapSize.Width;
            int num2 = 0;
            int num3 = mapSize.Height;
            int num4 = 0;

            foreach (Point point in (List<Point>)ob.Region.PointList)
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
            int x1 = (num1 + num2) / 2;
            int y1 = (num3 + num4) / 2;

            DXControl dxControl1 = npcControl2;
            BigMapDialog.Points points = new BigMapDialog.Points();
            points.Point = new Point(x1, y1);

            points.Location = new Point((int)((double)BigMapDialog.ScaleX * (double)x1) - CurrentNpc.Size.Width / 2, (int)((double)BigMapDialog.ScaleY * (double)y1) - CurrentNpc.Size.Height / 2);
            dxControl1.Tag = points;
            npcControl2.Location = new Point((int)((double)BigMapDialog.ScaleX * (double)x1) - npcControl2.Size.Width / 2, (int)((double)BigMapDialog.ScaleY * (double)y1) - npcControl2.Size.Height / 2);
        }

        public void Update(MovementInfo ob)
        {
            if (ob.SourceRegion == null || ob.SourceRegion.Map != SelectedInfo || (ob.DestinationRegion?.Map == null || ob.Icon == 0))
                return;
            Size mapSize = GetMapSize(SelectedInfo.FileName);
            if (ob.SourceRegion.PointList == null)
                ob.SourceRegion.CreatePoints(mapSize.Width);
            int num1 = mapSize.Width;
            int num2 = 0;
            int num3 = mapSize.Height;
            int num4 = 0;
            foreach (Point point in (List<Point>)ob.SourceRegion.PointList)
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
            int x = (num1 + num2) / 2;
            int y = (num3 + num4) / 2;
            Dictionary<object, DXControl> mapInfoObjects = MapInfoObjects;
            MovementInfo movementInfo1 = ob;
            DXImageControl dxImageControl1 = new DXImageControl();
            dxImageControl1.LibraryFile = (LibraryFile)2;
            dxImageControl1.Parent = (DXControl)Image;
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
            control.MouseClick += (EventHandler<MouseEventArgs>)((o, e) => SelectedInfo = ob.DestinationRegion.Map);
            DXImageControl dxImageControl4 = control;
            int num5 = (int)((double)BigMapDialog.ScaleX * (double)x);
            Size size = control.Size;
            int num6 = size.Width / 2;
            int x1 = num5 - num6;
            int num7 = (int)((double)BigMapDialog.ScaleY * (double)y);
            size = control.Size;
            int num8 = size.Height / 2;
            int y1 = num7 - num8;
            Point point1 = new Point(x1, y1);
            dxImageControl4.Location = point1;
            Dictionary<object, DXLabel> momentLabs = MomentLabs;
            MovementInfo movementInfo2 = ob;
            DXLabel dxLabel1 = new DXLabel();
            dxLabel1.Text = ob.DestinationRegion.Map.Description;
            dxLabel1.ForeColour = Color.White;
            dxLabel1.Parent = (DXControl)Image;
            DXLabel dxLabel2 = dxLabel1;
            momentLabs[(object)movementInfo2] = dxLabel1;
            int num9 = (int)((double)BigMapDialog.ScaleX * (double)x);
            size = dxLabel2.Size;
            int num10 = size.Width / 2;
            int num11 = num9 - num10;
            DXLabel dxLabel3 = dxLabel2;
            int x2 = num11 < 0 ? 0 : num11;
            int y2 = control.Location.Y;
            size = control.Size;
            int height = size.Height;
            int y3 = y2 + height;
            Point point2 = new Point(x2, y3);
            dxLabel3.Location = point2;
            dxLabel2.MouseMove += (EventHandler<MouseEventArgs>)((s, e) => ChangeCoordinate(x, y));
        }
        /*
        public void Update(ClientObjectData ob)
        {
            if (SelectedInfo == null)
                return;
            DXControl dxControl;
            if (!MapInfoObjects.TryGetValue((object)ob, out dxControl))
            {
                if (ob.MapIndex != ((DBObject)SelectedInfo).Index || ob.ItemInfo != null && ((ItemInfo)ob.ItemInfo).Rarity == 0 || ob.MonsterInfo != null && ob.Dead)
                    return;
                MapInfoObjects[(object)ob] = new DXControl()
                {
                    DrawTexture = true,
                    Parent = (DXControl)Image
                };
            }
#pragma warning disable CS0472 
            else if (ob.MapIndex != ((DBObject)SelectedInfo).Index || ob.MonsterInfo != null && ob.Dead != null || ob.ItemInfo != null && ((ItemInfo)ob.ItemInfo).Rarity == 0)
#pragma warning restore CS0472 
            {
                dxControl.Dispose();
                MapInfoObjects.Remove((object)ob);
                return;
            }
            if (ob.MonsterInfo != null || ob.ItemInfo != null || (int)MapObject.User.ObjectID != ob.ObjectID)
                return;
            Me.Visible = GameScene.Game.MapControl.MapInfo == _SelectedInfo;
            Me.Tag = (object)new Point(ob.Location.X, ob.Location.Y);
            DXAnimatedControl me = Me;
            int num1 = (int)((double)BigMapDialog.ScaleX * (double)ob.Location.X);
            Size size = Me.Size;
            int num2 = size.Width / 2;
            int x = num1 - num2;
            int num3 = (int)((double)BigMapDialog.ScaleY * (double)ob.Location.Y);
            size = Me.Size;
            int num4 = size.Width / 2;
            int y = num3 - num4;
            Point point = new Point(x, y);
            me.Location = point;
        }
        */

        public void Update(ClientObjectData ob)
        {
            if (SelectedInfo == null) return;

            DXControl control;

            if (!MapInfoObjects.TryGetValue(ob, out control))
            {
                if (ob.MapIndex != SelectedInfo.Index) return;
                if (ob.ItemInfo != null && ob.ItemInfo.Rarity == Rarity.Common) return;
                if (ob.MonsterInfo != null && ob.Dead) return;

                MapInfoObjects[ob] = control = new DXControl
                {
                    DrawTexture = true,
                    Parent = Image,
                    
                };
            }
            else if (ob.MapIndex != SelectedInfo.Index || (ob.MonsterInfo != null && ob.Dead) || (ob.ItemInfo != null && ob.ItemInfo.Rarity == Rarity.Common))
            {
                control.Dispose();
                MapInfoObjects.Remove(ob);
                return;
            }

            Size size = new Size(3, 3);
            Color colour = Color.White;
            string name = ob.Name;

            if (ob.MonsterInfo != null)
            {

                name = $"{ob.MonsterInfo.MonsterName}";
                if (ob.MonsterInfo.AI < 0)
                {
                    colour = Color.LightBlue;
                }
                else
                {
                    colour = Color.Red;

                    if (GameScene.Game.HasQuest(ob.MonsterInfo, GameScene.Game.MapControl.MapInfo))
                        colour = Color.Orange;
                    
                    if (GameScene.Game.MeiriHasQuest(ob.MonsterInfo, GameScene.Game.MapControl.MapInfo))
                        colour = Color.Orange;
                }

                if (ob.MonsterInfo.IsBoss)
                {
                    size = new Size(5, 5);  

                    if (control.Controls.Count == 0) 
                    {
                        new DXControl
                        {
                            Parent = control,
                            Location = new Point(1, 1),
                            BackColour = colour,
                            DrawTexture = true,
                            Size = new Size(3, 3)
                        };
                    }
                    else
                        control.Controls[0].BackColour = colour;

                    colour = Color.White;  

                }

                if (!string.IsNullOrEmpty(ob.PetOwner))
                {
                    name += $" ({ob.PetOwner})";
                    control.DrawTexture = false;
                }
            }
            else if (ob.ItemInfo != null)
            {
                colour = Color.DarkBlue;
            }
            else
            {
                if (MapObject.User.ObjectID == ob.ObjectID)
                {
                    Me.Visible = GameScene.Game.MapControl.MapInfo == _SelectedInfo;
                    Me.Tag = new Point(ob.Location.X, ob.Location.Y);
                    DXAnimatedControl me = Me;

                    me.Location = new Point((int)(ScaleX * ob.Location.X) - Me.Size.Width / 2, (int)(ScaleY * ob.Location.Y) - Me.Size.Width / 2);

                    control.Visible = false;
                }
                else if (GameScene.Game.Observer)
                {
                    control.Visible = false;
                }
                else if (GameScene.Game.GroupBox.Members.Any(x => x.ObjectID == ob.ObjectID))
                {
                    colour = Color.Blue;
                }
                else if (GameScene.Game.Partner != null && GameScene.Game.Partner.ObjectID == ob.ObjectID)
                {
                    colour = Color.DeepPink;
                }
                else if (GameScene.Game.GuildBox.GuildInfo != null && GameScene.Game.GuildBox.GuildInfo.Members.Any(x => x.ObjectID == ob.ObjectID))
                {
                    colour = Color.DeepSkyBlue;
                }
            }

            control.Hint = name;
            control.BackColour = colour;
            control.Size = size;
            control.Location = new Point((int)(ScaleX * ob.Location.X) - size.Width / 2, (int)(ScaleY * ob.Location.Y) - size.Height / 2);
        }

        public void Remove(object ob)
        {
            DXControl dxControl;
            if (!MapInfoObjects.TryGetValue(ob, out dxControl))
                return;
            dxControl.Dispose();
            MapInfoObjects.Remove(ob);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing)
                return;
            _SelectedInfo = (MapInfo)null;
            
            SelectedInfoChanged = (EventHandler<EventArgs>)null;
            Area = Rectangle.Empty;
            BigMapDialog.ScaleX = 0.0f;
            BigMapDialog.ScaleY = 0.0f;
            foreach (KeyValuePair<object, DXControl> mapInfoObject in MapInfoObjects)
            {
                if (mapInfoObject.Value != null && !mapInfoObject.Value.IsDisposed)
                    mapInfoObject.Value.Dispose();
            }
            MapInfoObjects.Clear();
            MapInfoObjects = (Dictionary<object, DXControl>)null;
            foreach (KeyValuePair<object, DXControl> worldPanel in WorldPanels)
            {
                if (worldPanel.Value != null && !worldPanel.Value.IsDisposed)
                    worldPanel.Value.Dispose();
            }
            WorldPanels.Clear();
            WorldPanels = (Dictionary<object, DXControl>)null;
            DisabledMomentLabs();
            if (SearchBtn != null)
            {
                if (!SearchBtn.IsDisposed)
                    SearchBtn.Dispose();
                SearchBtn = (DxMirButton)null;
            }
            if (CurrentMapBtn != null)
            {
                if (!CurrentMapBtn.IsDisposed)
                    CurrentMapBtn.Dispose();
                CurrentMapBtn = (DxMirButton)null;
            }
            if (WorldBtn != null)
            {
                if (!WorldBtn.IsDisposed)
                    WorldBtn.Dispose();
                WorldBtn = (DxMirButton)null;
            }
            if (CurrentWorldMap != null)
            {
                if (!CurrentWorldMap.IsDisposed)
                    CurrentWorldMap.Dispose();
                CurrentWorldMap = (DXImageControl)null;
            }
            if (Title != null)
            {
                if (!Title.IsDisposed)
                    Title.Dispose();
                Title = (DXLabel)null;
            }
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
            DisabledNpcList();
            if (NpcPanel != null)
            {
                if (!NpcPanel.IsDisposed)
                    NpcPanel.Dispose();
                NpcPanel = (DXControl)null;
            }
            if (CoordinateLabel != null)
            {
                if (!CoordinateLabel.IsDisposed)
                    CoordinateLabel.Dispose();
                CoordinateLabel = (DXLabel)null;
            }
            if (NpcScrollBar != null)
            {
                if (!NpcScrollBar.IsDisposed)
                    NpcScrollBar.Dispose();
                NpcScrollBar = (DXMirScrollBar)null;
            }
            if (SearchBox != null)
            {
                if (!SearchBox.IsDisposed)
                    SearchBox.Dispose();
                SearchBox = (DXTextBox)null;
            }
            if (CurrentNpc != null)
            {
                if (!CurrentNpc.IsDisposed)
                    CurrentNpc.Dispose();
                CurrentNpc = (DXImageControl)null;
            }
            if (WorldMap != null)
            {
                if (!WorldMap.IsDisposed)
                    WorldMap.Dispose();
                WorldMap = (DXImageControl)null;
            }
            if (Me != null)
            {
                if (!Me.IsDisposed)
                    Me.Dispose();
                Me = (DXAnimatedControl)null;
            }
            if (CurrentNpcBorder != null)
            {
                if (!CurrentNpcBorder.IsDisposed)
                    CurrentNpcBorder.Dispose();
                CurrentNpcBorder = (DXLabel)null;
            }
            if (OverPanel != null)
            {
                if (!OverPanel.IsDisposed)
                    OverPanel.Dispose();
                OverPanel = (DXLabel)null;
            }
            if (MapTitle != null)
            {
                if (!MapTitle.IsDisposed)
                    MapTitle.Dispose();
                MapTitle = (DXAnimatedControl)null;
            }
        }

        private void DisabledNpcList()
        {
            if (NpcList == null)
                return;
            foreach (DXLabel npc in NpcList)
            {
                if (npc != null && !npc.IsDisposed)
                    npc.Dispose();
            }
            NpcList.Clear();
            NpcList = (List<DXLabel>)null;
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

        private class Points
        {
            public Point Location { get; set; }

            public Point Point { get; set; }
        }

        private class MapIndex
        {
            public string FileName { get; set; }

            public int Index { get; set; }
        }
    }
}
