using System.Drawing;
using System.Windows.Forms;
using Client.Envir;
using Client.Scenes;
using Client.Scenes.Views;
using Client.UserModels;
using Library;
using C = Library.Network.ClientPackets;


namespace Client.Controls
{
    public sealed class DXWangluoWindow : DXWindow
    {
        
        #region Properties
        public DXKeyBindWindow KeyBindWindow;

        private DXButton DianxinButton, LiantongButton;
        public DXButton CancelButton;

        public override WindowType Type => WindowType.WangluoBox;
        public override bool CustomSize => false;
        public override bool AutomaticVisiblity => false;
        #endregion

        public DXWangluoWindow()
        {

            Size = new Size(250, 200);
            TitleLabel.Text = "网路选择";
            HasFooter = true;

            LoginScene scene = ActiveScene as LoginScene;

            DianxinButton = new DXButton
            {
                Location = new Point(Size.Width - 185, Size.Height - 110),
                Size = new Size(120, DefaultHeight),
                Parent = this,
                Label = { Text = "四区：丝路二线" }
            };
            DianxinButton.MouseClick += DianxinSettings;

            LiantongButton = new DXButton
            {
                Location = new Point(Size.Width - 185, Size.Height - 140),
                Size = new Size(120, DefaultHeight),
                Parent = this,
                Label = { Text = "四区：丝路一线" }
            };
            LiantongButton.MouseClick += LiantongSettings;

            CloseButton.MouseClick += (o, e) => CEnvir.Target.Close();

        }

        #region Methods


        private void DianxinSettings(object o, MouseEventArgs e)
        {
            LoginScene scene = ActiveScene as LoginScene;
            if (scene == null) return;

            scene.DianxinWangluo = true;

            Visible = false;
        }

        private void LiantongSettings(object o, MouseEventArgs e)
        {
            LoginScene scene = ActiveScene as LoginScene;
            if (scene == null) return;

            scene.LiantongWangluo = true;

            Visible = false;
        }

        public override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Visible = false;
                    break;
            }
        }
        #endregion

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {

                if (KeyBindWindow != null)
                {
                    if (!KeyBindWindow.IsDisposed)
                        KeyBindWindow.Dispose();

                    KeyBindWindow = null;
                }

                if (DianxinButton != null)
                {
                    if (!DianxinButton.IsDisposed)
                        DianxinButton.Dispose();

                    DianxinButton = null;
                }

                if (LiantongButton != null)
                {
                    if (!LiantongButton.IsDisposed)
                        LiantongButton.Dispose();

                    LiantongButton = null;
                }
               
            }
        }

        #endregion
    }
}
