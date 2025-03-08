using Client.Controls;
using Client.Envir;
using Client.UserModels;
using System.Drawing;
using System.Timers;

namespace Client.Scenes.Views
{
    public class MsgTipTextDialog : DXWindow
    {
        private DXLabel MainLabel;
        private DXLabel MidLabel;
        private DXLabel LastLabel;
        private Timer _timer;

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

        public MsgTipTextDialog()
        {
            Size = new Size(300, 100);
            Opacity = 0.0f;
            HasTitle = false;
            HasFooter = false;
            HasTopBorder = false;
            CloseButton.Visible = false;
            AllowResize = false;
            CanResizeHeight = false;
            Border = false;
            Movable = false;
            int num = Size.Width - 15;
            DXLabel dxLabel1 = new DXLabel();
            dxLabel1.Parent = (DXControl)this;
            MainLabel = dxLabel1;
            Font font = new Font(Config.FontName, 20f, FontStyle.Regular);
            MainLabel.Location = new Point(1, 1);
            MainLabel.Font = font;
            MainLabel.BackColour = Color.Empty;
            DXLabel dxLabel2 = new DXLabel();
            dxLabel2.Parent = (DXControl)this;
            MidLabel = dxLabel2;
            MidLabel.Location = new Point(num / 3 + 15, 8);
            MidLabel.Font = new Font(Config.FontName, 14f, FontStyle.Regular);
            MidLabel.BackColour = Color.Empty;
            MidLabel.ForeColour = Color.White;
            DXLabel dxLabel3 = new DXLabel();
            dxLabel3.Parent = (DXControl)this;
            LastLabel = dxLabel3;
            LastLabel.Location = new Point(num / 2 + 15, 1);
            LastLabel.Font = font;
            LastLabel.BackColour = Color.Empty;
            LastLabel.ForeColour = Color.FromArgb(0, 85, 75, 245);
            _timer = new Timer();
            _timer.Interval = 3000.0;
            _timer.Enabled = true;
            _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Visible = false;
        }

        public void ShowTip(string msg1, string msg2, string msg3, bool isSafe = false)
        {
            if (Visible)
                _timer.Stop();
            _timer.Start();
            Visible = true;
            MainLabel.Text = msg1;
            MainLabel.ForeColour = isSafe ? Color.FromArgb(0, 20, 175, 90) : Color.Red;
            MidLabel.Text = msg2;
            LastLabel.Text = msg3;
        }
    }
}
