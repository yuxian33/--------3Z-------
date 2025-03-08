using Client.Controls;
using Client.Envir;
using Client.UserModels;
using Library;
using System;
using System.Drawing;

namespace Client.Scenes.Views
{
    public sealed class NPCTopTagDialog : DXWindow
    {
        public DXImageControl NPCTimeImage;
        public DXLabel MapLabel;
        public DXLabel TimeLabel;
        public DateTime Expiry;

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

        public NPCTopTagDialog()
        {
            Size = new Size(110, 60);
            Opacity = 0.0f;
            Location = ClientArea.Location;
            HasTitle = false;
            HasFooter = false;
            HasTopBorder = false;
            TitleLabel.Visible = false;
            CloseButton.Visible = false;
            DXImageControl dxImageControl = new DXImageControl();
            dxImageControl.Parent = (DXControl)this;
            dxImageControl.LibraryFile = LibraryFile.GameInter;
            dxImageControl.Index = 1050;
            dxImageControl.Location = new Point(1, 1);
            NPCTimeImage = dxImageControl;
            DXLabel dxLabel1 = new DXLabel();
            dxLabel1.Parent = (DXControl)NPCTimeImage;
            dxLabel1.Location = new Point(ClientArea.Width / 2 - 20, 10);
            dxLabel1.ForeColour = Color.White;
            dxLabel1.Text = "副本名称";
            MapLabel = dxLabel1;
            DXLabel dxLabel2 = new DXLabel();
            dxLabel2.Parent = (DXControl)NPCTimeImage;
            dxLabel2.Location = new Point(ClientArea.Width / 2 - 17, 30);
            dxLabel2.Font = new Font(Config.FontName, CEnvir.FontSize(8f), FontStyle.Bold);
            dxLabel2.ForeColour = Color.White;
            dxLabel2.Text = "00:00:00";
            TimeLabel = dxLabel2;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing || NPCTimeImage == null)
                return;
            if (!NPCTimeImage.IsDisposed)
                NPCTimeImage.Dispose();
            NPCTimeImage = (DXImageControl)null;
        }
    }
}
