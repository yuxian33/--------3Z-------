using Library;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client.Controls
{
    public sealed class DXCheckBox : DXControl
    {
        public bool bAlignRight = true;
        public bool AutoSize = true;
        private bool _Checked;
        private bool _ReadOnly;

        public bool Checked
        {
            get
            {
                return this._Checked;
            }
            set
            {
                if (this._Checked == value)
                    return;
                bool oValue = this._Checked;
                this._Checked = value;
                this.OnCheckedChanged(oValue, value);
            }
        }

        public event EventHandler<EventArgs> CheckedChanged;

        public void OnCheckedChanged(bool oValue, bool nValue)
        {
            CheckedChanged?.Invoke(this, EventArgs.Empty);

            Box.Index = Checked ? 162 : 161;
        }

        public bool ReadOnly
        {
            get
            {
                return this._ReadOnly;
            }
            set
            {
                if (this._ReadOnly == value)
                    return;
                bool oValue = this._ReadOnly;
                this._ReadOnly = value;
                this.OnReadOnlyChanged(oValue, value);
            }
        }

        public event EventHandler<EventArgs> ReadOnlyChanged;

        public void OnReadOnlyChanged(bool oValue, bool nValue)
        {
    
            EventHandler<EventArgs> readOnlyChanged = this.ReadOnlyChanged;
            if (readOnlyChanged == null)
                return;
            readOnlyChanged((object)this, EventArgs.Empty);
        }

        public DXLabel Label { get; private set; }

        public DXImageControl Box { get; private set; }

        public override void OnDisplayAreaChanged(Rectangle oValue, Rectangle nValue)
        {
            base.OnDisplayAreaChanged(oValue, nValue);
            this.UpdateControl();
        }

        public DXCheckBox()
        {
            DXLabel dxLabel = new DXLabel();
            dxLabel.Parent = (DXControl)this;
            dxLabel.IsControl = false;
            dxLabel.Location = new Point(0, -1);
            dxLabel.DrawFormat = TextFormatFlags.Default;
            this.Label = dxLabel;
            this.Label.DisplayAreaChanged += (EventHandler<EventArgs>)((o, e) =>
            {
                Rectangle displayArea;
                if (this.AutoSize)
                {
                    displayArea = this.Label.DisplayArea;
                    int width1 = displayArea.Width;
                    displayArea = this.Box.DisplayArea;
                    int width2 = displayArea.Width;
                    int width3 = width1 + width2;
                    displayArea = this.Box.DisplayArea;
                    int height = displayArea.Height;
                    this.Size = new Size(width3, height);
                }
                if (this.bAlignRight)
                {
                    Size size1;
                    if (this.AutoSize)
                    {
                        DXLabel label = this.Label;
                        size1 = this.Size;
                        int width1 = size1.Width;
                        displayArea = this.Box.DisplayArea;
                        int width2 = displayArea.Width;
                        int width3 = width1 - width2;
                        displayArea = this.Box.DisplayArea;
                        int height = displayArea.Height;
                        Size size2 = new Size(width3, height);
                        label.Size = size2;
                    }
                    else
                    {
                        DXLabel label = this.Label;
                        size1 = this.Size;
                        int width1 = size1.Width;
                        displayArea = this.Box.DisplayArea;
                        int width2 = displayArea.Width;
                        int width3 = width1 - width2;
                        size1 = this.Size;
                        int height = size1.Height;
                        Size size2 = new Size(width3, height);
                        label.Size = size2;
                    }
                    DXImageControl box = this.Box;
                    displayArea = this.Label.DisplayArea;
                    int width = displayArea.Width;
                    size1 = this.Size;
                    int height1 = size1.Height;
                    size1 = this.Label.Size;
                    int height2 = size1.Height;
                    int y = (height1 - height2) / 2;
                    Point point = new Point(width, y);
                    box.Location = point;
                }
                else
                {
                    Size size1;
                    if (this.AutoSize)
                    {
                        DXLabel label = this.Label;
                        size1 = this.Size;
                        int width1 = size1.Width;
                        displayArea = this.Box.DisplayArea;
                        int width2 = displayArea.Width;
                        int width3 = width1 - width2;
                        displayArea = this.Box.DisplayArea;
                        int height = displayArea.Height;
                        Size size2 = new Size(width3, height);
                        label.Size = size2;
                    }
                    else
                    {
                        DXLabel label = this.Label;
                        size1 = this.Size;
                        int width1 = size1.Width;
                        displayArea = this.Box.DisplayArea;
                        int width2 = displayArea.Width;
                        int width3 = width1 - width2;
                        size1 = this.Size;
                        int height = size1.Height;
                        Size size2 = new Size(width3, height);
                        label.Size = size2;
                    }
                    DXLabel label1 = this.Label;
                    displayArea = this.Box.DisplayArea;
                    int width = displayArea.Width;
                    size1 = this.Size;
                    int height1 = size1.Height;
                    size1 = this.Label.Size;
                    int height2 = size1.Height;
                    int y = (height1 - height2) / 2;
                    Point point = new Point(width, y);
                    label1.Location = point;
                }
            });
            DXImageControl dxImageControl = new DXImageControl();
            dxImageControl.Location = new Point(this.Label.Size.Width + 2, 0);
            dxImageControl.Index = 161;
            dxImageControl.LibraryFile = LibraryFile.GameInter;
            dxImageControl.Parent = (DXControl)this;
            dxImageControl.IsControl = false;
            this.Box = dxImageControl;
            this.Box.DisplayAreaChanged += (EventHandler<EventArgs>)((o, e) =>
            {
                Rectangle displayArea;
                if (this.AutoSize)
                {
                    displayArea = this.Label.DisplayArea;
                    int width1 = displayArea.Width;
                    displayArea = this.Box.DisplayArea;
                    int width2 = displayArea.Width;
                    int width3 = width1 + width2;
                    displayArea = this.Box.DisplayArea;
                    int height = displayArea.Height;
                    this.Size = new Size(width3, height);
                }
                if (this.bAlignRight)
                {
                    Size size1;
                    if (this.AutoSize)
                    {
                        DXLabel label = this.Label;
                        size1 = this.Size;
                        int width1 = size1.Width;
                        displayArea = this.Box.DisplayArea;
                        int width2 = displayArea.Width;
                        int width3 = width1 - width2;
                        displayArea = this.Box.DisplayArea;
                        int height = displayArea.Height;
                        Size size2 = new Size(width3, height);
                        label.Size = size2;
                    }
                    else
                    {
                        DXLabel label = this.Label;
                        size1 = this.Size;
                        int width1 = size1.Width;
                        displayArea = this.Box.DisplayArea;
                        int width2 = displayArea.Width;
                        int width3 = width1 - width2;
                        size1 = this.Size;
                        int height = size1.Height;
                        Size size2 = new Size(width3, height);
                        label.Size = size2;
                    }
                    DXImageControl box = this.Box;
                    displayArea = this.Label.DisplayArea;
                    int width = displayArea.Width;
                    size1 = this.Size;
                    int height1 = size1.Height;
                    size1 = this.Box.Size;
                    int height2 = size1.Height;
                    int y = (height1 - height2) / 2;
                    Point point = new Point(width, y);
                    box.Location = point;
                }
                else
                {
                    Size size1;
                    if (this.AutoSize)
                    {
                        DXLabel label = this.Label;
                        size1 = this.Size;
                        int width1 = size1.Width;
                        displayArea = this.Box.DisplayArea;
                        int width2 = displayArea.Width;
                        int width3 = width1 - width2;
                        displayArea = this.Box.DisplayArea;
                        int height = displayArea.Height;
                        Size size2 = new Size(width3, height);
                        label.Size = size2;
                    }
                    else
                    {
                        DXLabel label = this.Label;
                        size1 = this.Size;
                        int width1 = size1.Width;
                        displayArea = this.Box.DisplayArea;
                        int width2 = displayArea.Width;
                        int width3 = width1 - width2;
                        size1 = this.Size;
                        int height = size1.Height;
                        Size size2 = new Size(width3, height);
                        label.Size = size2;
                    }
                    DXLabel label1 = this.Label;
                    displayArea = this.Box.DisplayArea;
                    int width = displayArea.Width;
                    size1 = this.Size;
                    int height1 = size1.Height;
                    size1 = this.Label.Size;
                    int height2 = size1.Height;
                    int y = (height1 - height2) / 2;
                    Point point = new Point(width, y);
                    label1.Location = point;
                }
            });
            if (!this.AutoSize)
                return;
            this.Size = new Size(18, 18);
        }

        private void UpdateControl()
        {
            if (this.Label == null)
                return;
            Rectangle displayArea;
            if (this.AutoSize)
            {
                int width = this.Label.DisplayArea.Width + this.Box.DisplayArea.Width;
                displayArea = this.Box.DisplayArea;
                int height = displayArea.Height;
                this.Size = new Size(width, height);
            }
            if (this.bAlignRight)
            {
                Size size1;
                if (this.AutoSize)
                {
                    DXLabel label = this.Label;
                    size1 = this.Label.Size;
                    int width = size1.Width;
                    displayArea = this.Box.DisplayArea;
                    int height = displayArea.Height;
                    Size size2 = new Size(width, height);
                    label.Size = size2;
                }
                else
                {
                    DXLabel label = this.Label;
                    int width1 = this.Size.Width;
                    displayArea = this.Box.DisplayArea;
                    int width2 = displayArea.Width;
                    Size size2 = new Size(width1 - width2, this.Size.Height);
                    label.Size = size2;
                }
                DXLabel label1 = this.Label;
                int x = 0;
                size1 = this.Size;
                int height1 = size1.Height;
                size1 = this.Label.Size;
                int height2 = size1.Height;
                int y1 = (height1 - height2) / 2;
                Point point1 = new Point(x, y1);
                label1.Location = point1;
                DXImageControl box = this.Box;
                displayArea = this.Label.DisplayArea;
                int width3 = displayArea.Width;
                size1 = this.Size;
                int height3 = size1.Height;
                size1 = this.Box.Size;
                int height4 = size1.Height;
                int y2 = (height3 - height4) / 2;
                Point point2 = new Point(width3, y2);
                box.Location = point2;
            }
            else
            {
                Size size1;
                if (this.AutoSize)
                {
                    DXLabel label = this.Label;
                    size1 = this.Label.Size;
                    int width = size1.Width;
                    displayArea = this.Box.DisplayArea;
                    int height = displayArea.Height;
                    Size size2 = new Size(width, height);
                    label.Size = size2;
                }
                else
                {
                    DXLabel label = this.Label;
                    int width1 = this.Size.Width;
                    displayArea = this.Box.DisplayArea;
                    int width2 = displayArea.Width;
                    Size size2 = new Size(width1 - width2, this.Size.Height);
                    label.Size = size2;
                }
                DXImageControl box = this.Box;
                int x = 0;
                size1 = this.Size;
                int height1 = size1.Height;
                size1 = this.Box.Size;
                int height2 = size1.Height;
                int y1 = (height1 - height2) / 2;
                Point point1 = new Point(x, y1);
                box.Location = point1;
                DXLabel label1 = this.Label;
                displayArea = this.Box.DisplayArea;
                int width3 = displayArea.Width;
                size1 = this.Size;
                int height3 = size1.Height;
                size1 = this.Label.Size;
                int height4 = size1.Height;
                int y2 = (height3 - height4) / 2;
                Point point2 = new Point(width3, y2);
                label1.Location = point2;
            }
        }

        public override void OnMouseClick(MouseEventArgs e)
        {
            if (!this.IsEnabled)
                return;
            base.OnMouseClick(e);
            if (this.ReadOnly)
                return;
            this.Checked = !this.Checked;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing)
                return;
            if (this.Label != null)
            {
                if (!this.Label.IsDisposed)
                    this.Label.Dispose();
                this.Label = (DXLabel)null;
            }
            if (this.Box != null)
            {
                if (!this.Box.IsDisposed)
                    this.Box.Dispose();
                this.Box = (DXImageControl)null;
            }
            this._Checked = false;
            
            this.CheckedChanged = (EventHandler<EventArgs>)null;
            this._ReadOnly = false;
            
            this.ReadOnlyChanged = (EventHandler<EventArgs>)null;
        }
    }
}
