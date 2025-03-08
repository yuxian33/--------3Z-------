using Client.Controls;
using Client.UserModels;
using Library;
using Library.SystemModels;
using CartoonMirDB;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Client.Scenes.Views
{
    public class BeltDialog : DXWindow
    {
        public ClientBeltLink[] Links;
        public DXItemGrid Grid;
        public DXImageControl Background;
        public DxMirButton CloseBtn;
        public DxMirButton Direction;
        public DXImageControl image1, image2, image3, image4, image5, image6, image7, image8, image9, image0;

        public override void OnClientAreaChanged(Rectangle oValue, Rectangle nValue)
        {
            base.OnClientAreaChanged(oValue, nValue);
            if (Links == null)
                return;
            UpdateLinks();
        }

        public override WindowType Type
        {
            get
            {
                return WindowType.BeltBox;
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

        public BeltDialog()
        {
            Size = new Size(439, 66);
            Opacity = 0.0f;
            CloseButton.Visible = false;
            HasTitle = false;
            Links = new ClientBeltLink[CartoonGlobals.MaxBeltCount];
            for (int index1 = 0; index1 < CartoonGlobals.MaxBeltCount; ++index1)
            {
                ClientBeltLink[] links = Links;
                int index2 = index1;
                ClientBeltLink clientBeltLink = new ClientBeltLink();
                clientBeltLink.Slot = index1;
                links[index2] = clientBeltLink;
            }
            DXImageControl dxImageControl = new DXImageControl();
            dxImageControl.Index = 1300;
            dxImageControl.Size = new Size(439, 66);
            dxImageControl.LibraryFile = (LibraryFile)4;
            dxImageControl.Parent = (DXControl)this;
            Background = dxImageControl;
            Background.MouseDown += new EventHandler<MouseEventArgs>(Background_MouseDown);
            DxMirButton dxMirButton1 = new DxMirButton();
            dxMirButton1.MirButtonType = MirButtonType.FourStatu;
            dxMirButton1.Index = 912;
            dxMirButton1.LibraryFile = (LibraryFile)4;
            dxMirButton1.Parent = (DXControl)this;
            Direction = dxMirButton1;
            Direction.MouseClick += new EventHandler<MouseEventArgs>(Direction_Click);
            DXItemGrid dxItemGrid = new DXItemGrid();
            dxItemGrid.Parent = (DXControl)this;
            dxItemGrid.Opacity = 0.0f;
            dxItemGrid.Border = false;
            dxItemGrid.GridSize = new Size(CartoonGlobals.MaxBeltCount, 1);
            dxItemGrid.GridType = (GridType)3;
            dxItemGrid.AllowLink = false;
            Grid = dxItemGrid;

            image1 = new DXImageControl();
            image1.Parent = (DXControl)this;
            image1.LibraryFile = (LibraryFile)3;
            image1.Index = 1673;
            

            image2 = new DXImageControl();
            image2.Parent = (DXControl)this;
            image2.LibraryFile = (LibraryFile)3;
            image2.Index = 1674;
            

            image3 = new DXImageControl();
            image3.Parent = (DXControl)this;
            image3.LibraryFile = (LibraryFile)3;
            image3.Index = 1675;
            

            image4 = new DXImageControl();
            image4.Parent = (DXControl)this;
            image4.LibraryFile = (LibraryFile)3;
            image4.Index = 1676;
            

            image5 = new DXImageControl();
            image5.Parent = (DXControl)this;
            image5.LibraryFile = (LibraryFile)3;
            image5.Index = 1677;
            

            image6 = new DXImageControl();
            image6.Parent = (DXControl)this;
            image6.LibraryFile = (LibraryFile)3;
            image6.Index = 1678;
            

            image7 = new DXImageControl();
            image7.Parent = (DXControl)this;
            image7.LibraryFile = (LibraryFile)3;
            image7.Index = 1679;
            

            image8 = new DXImageControl();
            image8.Parent = (DXControl)this;
            image8.LibraryFile = (LibraryFile)3;
            image8.Index = 1680;
            

            image9 = new DXImageControl();
            image9.Parent = (DXControl)this;
            image9.LibraryFile = (LibraryFile)3;
            image9.Index = 1681;
            

            image0 = new DXImageControl();
            image0.Parent = (DXControl)this;
            image0.LibraryFile = (LibraryFile)3;
            image0.Index = 1682;
            


            DxMirButton dxMirButton2 = new DxMirButton();
            dxMirButton2.MirButtonType = MirButtonType.FourStatu;
            dxMirButton2.Parent = (DXControl)this;
            dxMirButton2.LibraryFile = (LibraryFile)2;
            dxMirButton2.Index = 114;
            CloseBtn = dxMirButton2;
            CloseBtn.MouseClick += (EventHandler<MouseEventArgs>)((o, e) => Visible = false);
            UpdateLocation();
        }

        private void Direction_Click(object sender, MouseEventArgs e)
        {
            Size size1 = Size;
            int height1 = size1.Height;
            size1 = Size;
            int width1 = size1.Width;
            Size = new Size(height1, width1);
            DXItemGrid grid = Grid;
            Size gridSize = Grid.GridSize;
            int height2 = gridSize.Height;
            gridSize = Grid.GridSize;
            int width2 = gridSize.Width;
            Size size2 = new Size(height2, width2);
            grid.GridSize = size2;
            UpdateLocation();
            UpdateLinks();
        }

        private void Background_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }

        private void UpdateLocation()
        {
            Size size1 = Size;
            int width1 = size1.Width;
            size1 = Size;
            int height1 = size1.Height;
            if (width1 < height1)
            {
                Background.Index = 1301;
                int y1 = Location.Y;
                Size size2 = Size;
                int height2 = size2.Height;
                int num1 = y1 + height2;
                size2 = GameScene.Game.Size;
                int height3 = size2.Height;
                Point location;
                int num2;
                if (num1 <= height3)
                {
                    location = Location;
                    num2 = location.Y;
                }
                else
                {
                    size2 = GameScene.Game.Size;
                    int height4 = size2.Height;
                    size2 = Size;
                    int height5 = size2.Height;
                    num2 = height4 - height5;
                }
                int y2 = num2;
                location = Location;
                Location = new Point(location.X, y2);
                Direction.Location = new Point(18, 8);
                Grid.Location = new Point(15, 43);
                DxMirButton closeBtn = CloseBtn;
                closeBtn.Location = new Point(18, Size.Height - 35);


                DXImageControl Image1 = image1;
                Image1.Location = new Point(14, 44);

                DXImageControl Image2 = image2;
                Image2.Location = new Point(14, 80);

                DXImageControl Image3 = image3;
                Image3.Location = new Point(14, 116);

                DXImageControl Image4 = image4;
                Image4.Location = new Point(14, 151);

                DXImageControl Image5 = image5;
                Image5.Location = new Point(14, 186);

                DXImageControl Image6 = image6;
                Image6.Location = new Point(14, 221);

                DXImageControl Image7 = image7;
                Image7.Location = new Point(14, 255);

                DXImageControl Image8 = image8;
                Image8.Location = new Point(14, 290);

                DXImageControl Image9 = image9;
                Image9.Location = new Point(14, 325);

                DXImageControl Image0 = image0;
                Image0.Location = new Point(14, 360);


            }
            else
            {
                Background.Index = 1300;
                int x1 = Location.X;
                Size size2 = Size;
                int width2 = size2.Width;
                int num1 = x1 + width2;
                size2 = GameScene.Game.Size;
                int width3 = size2.Width;
                Point location;
                int num2;
                if (num1 <= width3)
                {
                    location = Location;
                    num2 = location.X;
                }
                else
                {
                    size2 = GameScene.Game.Size;
                    int width4 = size2.Width;
                    size2 = Size;
                    int width5 = size2.Width;
                    num2 = width4 - width5;
                }
                int x2 = num2;
                location = Location;
                int y1 = location.Y;
                Location = new Point(x2, y1);
                Direction.Location = new Point(5, 15);
                Grid.Location = new Point(43, 14);
                DxMirButton closeBtn = CloseBtn;
                size2 = Size;
                int x3 = size2.Width - 35;
                size2 = Size;
                int y2 = size2.Height / 2 - 15;
                Point point = new Point(x3, y2);
                closeBtn.Location = point;

                DXImageControl Image1 = image1;
                Image1.Location = new Point(44, 14);

                DXImageControl Image2 = image2;
                Image2.Location = new Point(80, 14);

                DXImageControl Image3 = image3;
                Image3.Location = new Point(116, 14);

                DXImageControl Image4 = image4;
                Image4.Location = new Point(151, 14);

                DXImageControl Image5 = image5;
                Image5.Location = new Point(186, 14);

                DXImageControl Image6 = image6;
                Image6.Location = new Point(221, 14);

                DXImageControl Image7 = image7;
                Image7.Location = new Point(255, 14);

                DXImageControl Image8 = image8;
                Image8.Location = new Point(290, 14);

                DXImageControl Image9 = image9;
                Image9.Location = new Point(325, 14);

                DXImageControl Image0 = image0;
                Image0.Location = new Point(360, 14);

            }
        }

        public void UpdateLinks()
        {
            foreach (ClientBeltLink link1 in Links)
            {
                ClientBeltLink link = link1;
                if (link.Slot >= 0 && link.Slot < Grid.Grid.Length)
                {
                    if (link.LinkInfoIndex > 0)
                        Grid.Grid[link.Slot].QuickInfo = ((IEnumerable<ItemInfo>)((DBCollection<ItemInfo>)CartoonGlobals.ItemInfoList).Binding).FirstOrDefault<ItemInfo>((Func<ItemInfo, bool>)(x => ((DBObject)x).Index == link.LinkInfoIndex));
                    else if (link.LinkItemIndex >= 0)
                        Grid.Grid[link.Slot].QuickItem = ((IEnumerable<ClientUserItem>)GameScene.Game.Inventory).FirstOrDefault<ClientUserItem>((Func<ClientUserItem, bool>)(x =>
                        {
                            int? index = x?.Index;
                            int linkItemIndex = link.LinkItemIndex;
                            return index.GetValueOrDefault() == linkItemIndex & index.HasValue;
                        }));
                }
            }
        }

        public override Size GetAcceptableResize(Size size)
        {
            Rectangle clientArea = GetClientArea(size);
            int val2_1 = (int)Math.Ceiling((double)(clientArea.Width - 10) / 38.0);
            int val2_2 = (int)Math.Ceiling((double)(clientArea.Height - 10) / 38.0);
            if (clientArea.Height > clientArea.Width)
                val2_1 = 0;
            else
                val2_2 = 0;
            int width = Math.Max(1, Math.Min(CartoonGlobals.MaxBeltCount, val2_1)) * 37 + 1;
            int height = Math.Max(1, Math.Min(CartoonGlobals.MaxBeltCount, val2_2)) * 37 + 1;
            if (width >= height)
                width += 10;
            else
                height += 10;
            return GetSize(new Size(width, height));
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing)
                return;
            if (Links != null)
            {
                for (int index = 0; index < Links.Length; ++index)
                    Links[index] = (ClientBeltLink)null;
                Links = (ClientBeltLink[])null;
            }
            if (Grid != null)
            {
                if (!Grid.IsDisposed)
                    Grid.Dispose();
                Grid = (DXItemGrid)null;
            }
            if (Background != null)
            {
                if (!Background.IsDisposed)
                    Background.Dispose();
                Background = (DXImageControl)null;
            }
            if (Direction != null)
            {
                if (!Direction.IsDisposed)
                    Direction.Dispose();
                Direction = (DxMirButton)null;
            }
            if (CloseBtn != null)
            {
                if (!CloseBtn.IsDisposed)
                    CloseBtn.Dispose();
                CloseBtn = (DxMirButton)null;
            }
        }
    }
}


/*




using System;
using System.Drawing;
using System.Linq;
using Client.Controls;
using Client.Envir;
using Client.UserModels;
using Library;



namespace Client.Scenes.Views
{
    public sealed class BeltDialog : DXWindow
    {
        #region Properties

        public ClientBeltLink[] Links;

        public DXItemGrid Grid;

        public override void OnClientAreaChanged(Rectangle oValue, Rectangle nValue)
        {
            base.OnClientAreaChanged(oValue, nValue);

            if (Links == null) return;

            Grid?.Dispose();

            Grid = new DXItemGrid
            {
                Parent = this,
                Location = ClientArea.Location,
                GridSize = new Size(Math.Max(1, (ClientArea.Size.Width) / (DXItemCell.CellWidth - 1)), Math.Max(1, ClientArea.Size.Height / (DXItemCell.CellHeight - 1))),
                GridType = GridType.Belt,
                AllowLink = false,
            };

            for (int i = 0; i < Grid.Grid.Length; i++)
            {
                new DXLabel
                {
                    Parent = Grid.Grid[i],
                    Text = ((i + 1) % 10).ToString(),
                    Font = new Font(Config.FontName, CEnvir.FontSize(8F), FontStyle.Italic),
                    IsControl = false,
                    Location = new Point(-2, -1)
                };
            }

            UpdateLinks();
        }

        public override WindowType Type => WindowType.BeltBox;
        public override bool CustomSize => true;
        public override bool AutomaticVisiblity => true;

        #endregion

        public BeltDialog()
        {
            HasTitle = false;
            HasFooter = false;
            HasTopBorder = false;
            TitleLabel.Visible = false;
            CloseButton.Visible = false;

            AllowResize = true;

            Links = new ClientBeltLink[CartoonGlobals.MaxBeltCount];
            for (int i = 0; i < CartoonGlobals.MaxBeltCount; i++)
                Links[i] = new ClientBeltLink { Slot = i };

            Size = GetAcceptableResize(Size.Empty);
        }

        #region Methods
        public void UpdateLinks()
        {

            foreach (ClientBeltLink link in Links)
            {
                if (link.Slot < 0 || link.Slot >= Grid.Grid.Length) continue;

                if (link.LinkInfoIndex > 0)
                    Grid.Grid[link.Slot].QuickInfo = CartoonGlobals.ItemInfoList.Binding.FirstOrDefault(x => x.Index == link.LinkInfoIndex);
                else if (link.LinkItemIndex >= 0)
                    Grid.Grid[link.Slot].QuickItem = GameScene.Game.Inventory.FirstOrDefault(x => x?.Index == link.LinkItemIndex);
            }
        }
        public override Size GetAcceptableResize(Size size)
        {
            Rectangle area = GetClientArea(size);

            int x = (int)Math.Ceiling((area.Width - 10) / (float)DXItemCell.CellWidth);
            int y = (int)Math.Ceiling((area.Height - 10) / (float)DXItemCell.CellHeight);

            if (area.Height > area.Width)
                x = 0;
            else
                y = 0;

            x = Math.Max(1, Math.Min(CartoonGlobals.MaxBeltCount, x)) * (DXItemCell.CellWidth - 1) + 1;
            y = Math.Max(1, Math.Min(CartoonGlobals.MaxBeltCount, y)) * (DXItemCell.CellHeight - 1) + 1;

            if (x >= y)
                x += 10;
            else
                y += 10;

            return GetSize(new Size(x, y));
        }
        #endregion

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                if (Links != null)
                {
                    for (int i = 0; i < Links.Length; i++)
                        Links[i] = null;

                    Links = null;
                }

                if (Grid != null)
                {
                    if (!Grid.IsDisposed)
                        Grid.Dispose();

                    Grid = null;
                }
            }

        }

        #endregion
    }
}
*/
