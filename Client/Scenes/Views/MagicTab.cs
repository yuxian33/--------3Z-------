using Client.Controls;
using Library;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Client.Scenes.Views
{
    public sealed class MagicTab : DXTab
    {
        public DXMirScrollBar ScrollBar;

        public override void OnSizeChanged(Size oValue, Size nValue)
        {
            base.OnSizeChanged(oValue, nValue);
            Location = new Point(0, 23);
            ScrollBar.Size = new Size(16, Size.Height - 62);
            ScrollBar.Location = new Point(Size.Width - 30, 3);
            int num = 7;
            DXControl dxControl = Controls.FirstOrDefault<DXControl>((Func<DXControl, bool>)(p => p.Tag?.ToString() == "content"));
            if (dxControl != null)
            {
                foreach (DXControl control in dxControl.Controls)
                {
                    if (control is MagicCell)
                        num += control.Size.Height + 6;
                }
            }
            ScrollBar.Change = 59;
            ScrollBar.MaxValue = num + 7;
            ScrollBar.VisibleSize = ScrollBar.Size.Height;
            UpdateLocations();
        }

        public MagicTab(MagicSchool school)
        {
            TabButton.LibraryFile = (LibraryFile)2;
            TabButton.Opacity = 0.0f;
            TabButton.Hint = school.ToString();
            TabButton.Location = new Point(56, 23);
            Border = false;
            Opacity = 0.0f;
            switch ((int)school)
            {
                case 0:
                    TabButton.Index = 64;
                    break;
                case 1:
                    TabButton.Index = 53;
                    break;
                case 2:
                    TabButton.Index = 54;
                    break;
                case 3:
                    TabButton.Index = 55;
                    break;
                case 4:
                    TabButton.Index = 56;
                    break;
                case 5:
                    TabButton.Index = 57;
                    break;
                case 6:
                    TabButton.Index = 58;
                    break;
                case 7:
                    TabButton.Index = 59;
                    break;
                case 8:
                    TabButton.Index = 61;
                    break;
                case 9:
                    TabButton.Index = 62;
                    break;
                case 10:
                    TabButton.Index = 60;
                    break;
                case 11:
                    TabButton.Index = 66;
                    break;
                case 12:
                    TabButton.Index = 67;
                    break;
                case 13:
                    TabButton.Index = 64;
                    break;
                case 14:
                    TabButton.Index = 65;
                    break;
            }
            DXMirScrollBar dxMirScrollBar = new DXMirScrollBar();
            dxMirScrollBar.Parent = (DXControl)this;
            ScrollBar = dxMirScrollBar;
            ScrollBar.ValueChanged += (o, e) => UpdateLocations();
        }

        public void UpdateLocations()
        {
            int y = -(ScrollBar.Value - ScrollBar.Value % ScrollBar.Change) + 7;
            DXControl dxControl = Controls.FirstOrDefault<DXControl>((Func<DXControl, bool>)(p => p.Tag?.ToString() == "content"));
            if (dxControl == null)
                return;
            foreach (DXControl control in dxControl.Controls)
            {
                control.Location = new Point(5, y);
                y += control.Size.Height + 6;
            }
        }

        public override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            UpdateLocations();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing || ScrollBar == null)
                return;
            if (!ScrollBar.IsDisposed)
                ScrollBar.Dispose();
            ScrollBar = (DXMirScrollBar)null;
        }
    }
}
