using Client.Scenes;
using Client.UserModels;
using Library;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client.Controls
{
    public sealed class DXConfirmWindow : DXWindow
    {
        private bool _HasBootm;
        public DXButton ConfirmButton;
        public DXButton CancelButton;
        public DXImageControl TopPanel;
        public DXImageControl ContentPanel;
        public DXImageControl BottomPanel;
        public DXLabel Content;

        public bool HasBootm
        {
            get
            {
                return this._HasBootm;
            }
            set
            {
                if (this._HasBootm == value)
                    return;
                bool hasBootm = this._HasBootm;
                this._HasBootm = value;
                this.OnHasBootmChanged(hasBootm, value);
            }
        }

        public void OnHasBootmChanged(bool oValue, bool nValue)
        {
            this.BottomPanel.Index = nValue ? 422 : 423;
            this.ConfirmButton.Visible = nValue;
            this.CancelButton.Visible = nValue;
            this.UpdateLocations();
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

        public DXConfirmWindow(string content, Action ok = null, Action cancel = null)
        {
            DXConfirmWindow dxConfirmWindow = this;
            this.HasFooter = true;
            this.TitleLabel.Visible = false;
            this.Parent = (DXControl)DXControl.ActiveScene;
            DXControl.MessageBoxList.Add((DXControl)this);
            this.Modal = true;
            DXImageControl dxImageControl1 = new DXImageControl();
            dxImageControl1.Parent = (DXControl)this;
            dxImageControl1.LibraryFile = (LibraryFile)3;
            dxImageControl1.Index = 420;
            this.TopPanel = dxImageControl1;
            this.CloseButton.Parent = (DXControl)this.TopPanel;
            this.CloseButton.MouseClick += (EventHandler<MouseEventArgs>)((s, e) => dxConfirmWindow.CancelButton.InvokeMouseClick());
            DXImageControl dxImageControl2 = new DXImageControl();
            dxImageControl2.Size = new Size(this.TopPanel.Size.Width, 100);
            dxImageControl2.Parent = (DXControl)this;
            dxImageControl2.LibraryFile = (LibraryFile)3;
            dxImageControl2.Index = 421;
            dxImageControl2.FixedSize = true;
            dxImageControl2.TilingMode = TilingMode.Vertically;
            this.ContentPanel = dxImageControl2;
            DXLabel dxLabel = new DXLabel();
            dxLabel.Text = content;
            dxLabel.Parent = (DXControl)this.ContentPanel;
            dxLabel.DrawFormat = content.IndexOf("\n") != -1 ? TextFormatFlags.VerticalCenter : TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
            dxLabel.ForeColour = Color.White;
            dxLabel.AutoSize = false;
            dxLabel.Location = content.IndexOf("\n") != -1 ? new Point(20, 0) : Point.Empty;
            this.Content = dxLabel;
            DXLabel content1 = this.Content;
            Size size1 = this.ContentPanel.Size;
            int width1 = size1.Width - 40;
            size1 = DXLabel.GetHeight(content1, width1);
            int height = size1.Height;
            size1 = this.ContentPanel.Size;
            if (size1.Height < height)
            {
                DXImageControl contentPanel = this.ContentPanel;
                size1 = this.ContentPanel.Size;
                Size size2 = new Size(size1.Width, height);
                contentPanel.Size = size2;
            }
            DXLabel content2 = this.Content;
            DXImageControl contentPanel1 = this.ContentPanel;
            size1 = new Size(this.ContentPanel.Size.Width, height);
            Size size3 = size1;
            contentPanel1.Size = size3;
            Size size4 = size1;
            content2.Size = size4;
            DXImageControl dxImageControl3 = new DXImageControl();
            dxImageControl3.Parent = (DXControl)this;
            dxImageControl3.LibraryFile = (LibraryFile)3;
            dxImageControl3.Index = 422;
            this.BottomPanel = dxImageControl3;
            DXButton dxMirButton1 = new DXButton();
            dxMirButton1.MirButtonType = ButtonType.FourStatuReverse;
            dxMirButton1.LibraryFile = (LibraryFile)3;
            dxMirButton1.Index = 426;
            dxMirButton1.Location = new Point(50, 33);
            dxMirButton1.Size = new Size(80, DXControl.DefaultHeight);
            dxMirButton1.Parent = (DXControl)this.BottomPanel;
            this.ConfirmButton = dxMirButton1;
            this.ConfirmButton.MouseClick += (EventHandler<MouseEventArgs>)((o, e) =>
            {
                //DXItemCell.SelectedInventoryCell = (DXItemCell)null;
                //GameScene.Game.ConfirmWindow = (DXConfirmWindow)null;
                Action action = ok;
                if (action != null)
                    action();
                dxConfirmWindow.Dispose();
            });
            DXButton dxMirButton2 = new DXButton();
            dxMirButton2.MirButtonType = ButtonType.FourStatuReverse;
            dxMirButton2.LibraryFile = (LibraryFile)3;
            dxMirButton2.Index = 430;
            dxMirButton2.Size = new Size(80, DXControl.DefaultHeight);
            dxMirButton2.Parent = (DXControl)this.BottomPanel;
            this.CancelButton = dxMirButton2;
            DXButton cancelButton = this.CancelButton;
            size1 = this.BottomPanel.Size;
            int width2 = size1.Width;
            size1 = this.CancelButton.Size;
            int width3 = size1.Width;
            Point point = new Point(width2 - width3 - 50, 33);
            cancelButton.Location = point;
            this.CancelButton.MouseClick += (EventHandler<MouseEventArgs>)((s, e) =>
            {
                //DXItemCell.SelectedInventoryCell = (DXItemCell)null;
                //GameScene.Game.ConfirmWindow = (DXConfirmWindow)null;
                Action action = cancel;
                if (action != null)
                    action();
                dxConfirmWindow.Dispose();
            });
            this.HasBootm = true;
            //GameScene.Game.ConfirmWindow = this;
        }

        public void OnEnter()
        {
            this.ConfirmButton.InvokeMouseClick();
        }

        private void UpdateLocations()
        {
            this.ContentPanel.Location = new Point(0, this.TopPanel.Size.Height);
            this.BottomPanel.Location = new Point(0, this.ContentPanel.Location.Y + this.ContentPanel.Size.Height);
            Size size = this.TopPanel.Size;
            int width1 = size.Width;
            int y1 = this.BottomPanel.Location.Y;
            size = this.BottomPanel.Size;
            int height1 = size.Height;
            int height2 = y1 + height1;
            this.Size = new Size(width1, height2);
            Rectangle displayArea = DXControl.ActiveScene.DisplayArea;
            int width2 = displayArea.Width;
            displayArea = this.DisplayArea;
            int width3 = displayArea.Width;
            int x = (width2 - width3) / 2;
            displayArea = DXControl.ActiveScene.DisplayArea;
            int height3 = displayArea.Height;
            displayArea = this.DisplayArea;
            int height4 = displayArea.Height;
            int y2 = (height3 - height4 - 68) / 2;
            this.Location = new Point(x, y2);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing)
                return;
            if (this.TopPanel != null)
            {
                if (!this.TopPanel.IsDisposed)
                    this.TopPanel.Dispose();
                this.TopPanel = (DXImageControl)null;
            }
            if (this.ContentPanel != null)
            {
                if (!this.ContentPanel.IsDisposed)
                    this.ContentPanel.Dispose();
                this.ContentPanel = (DXImageControl)null;
            }
            if (this.Content != null)
            {
                if (!this.Content.IsDisposed)
                    this.Content.Dispose();
                this.Content = (DXLabel)null;
            }
            if (this.BottomPanel != null)
            {
                if (!this.BottomPanel.IsDisposed)
                    this.BottomPanel.Dispose();
                this.BottomPanel = (DXImageControl)null;
            }
            if (this.ConfirmButton != null)
            {
                if (!this.ConfirmButton.IsDisposed)
                    this.ConfirmButton.Dispose();
                this.ConfirmButton = (DXButton)null;
            }
            if (this.CancelButton != null)
            {
                if (!this.CancelButton.IsDisposed)
                    this.CancelButton.Dispose();
                this.CancelButton = (DXButton)null;
            }
        }
    }
}
