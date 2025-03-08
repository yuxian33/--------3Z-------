using Client.Controls;
using Client.Envir;
using Library;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client.Scenes.Views
{
    public sealed class ChatNoticeDialog : DXImageControl
    {
        public DXImageControl Layout;
        public DXLabel TextLabel1;
        public DXLabel TextLabel2;
        public DateTime CurrentTime;
        public int ViewTime;
        public long speed;
        public string str;

        public ChatNoticeDialog()
        {
            Index = 6911;
            LibraryFile = LibraryFile.GameInter;
            Movable = false;
            Sort = false;
            ImageOpacity = 0.3f;
            DXLabel dxLabel1 = new DXLabel();
            dxLabel1.Text = "";
            dxLabel1.Font = new Font(Config.FontName, CEnvir.FontSize(10f), FontStyle.Bold);
            dxLabel1.DrawFormat = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
            dxLabel1.Parent = (DXControl)this;
            dxLabel1.IsControl = true;
            dxLabel1.Location = new Point(15, 3);
            dxLabel1.Size = new Size(660, 32);
            dxLabel1.ForeColour = Color.Yellow;
            dxLabel1.BorderColour = Color.Black;
            TextLabel1 = dxLabel1;
            DXLabel dxLabel2 = new DXLabel();
            dxLabel2.Text = "";
            dxLabel2.Font = new Font(Config.FontName, CEnvir.FontSize(15f), FontStyle.Bold);
            dxLabel2.DrawFormat = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
            dxLabel2.Parent = (DXControl)this;
            dxLabel2.IsControl = true;
            dxLabel2.Location = new Point(15, 3);
            dxLabel2.Size = new Size(660, 40);
            dxLabel2.ForeColour = Color.Yellow;
            dxLabel2.BorderColour = Color.Black;
            TextLabel2 = dxLabel2;
            DXImageControl dxImageControl = new DXImageControl();
            dxImageControl.Index = 327;
            dxImageControl.LibraryFile = LibraryFile.GameInter;
            dxImageControl.Location = new Point(-2, -2);
            dxImageControl.Parent = (DXControl)this;
            Layout = dxImageControl;
            AfterDraw += new EventHandler<EventArgs>(ChatNotice_AfterDraw);
        }

        private void ChatNotice_AfterDraw(object sender, EventArgs e)
        {
            if (CurrentTime < CEnvir.Now)
                Hide();
            else if (CEnvir.Now.Ticks - speed > 150000L)
            {
                speed = CEnvir.Now.Ticks;
                if (TextLabel1.Text.Length < 300)
                {
                    DXLabel textLabel1 = TextLabel1;
                    textLabel1.Text = textLabel1.Text + "   " + str;
                    DXLabel textLabel2 = TextLabel2;
                    textLabel2.Text = textLabel2.Text + "   " + str;
                }
                DXLabel textLabel1_1 = TextLabel1;
                DXLabel textLabel2_1 = TextLabel2;
                Point point1 = new Point(TextLabel2.Location.X - 1, 3);
                Point point2 = point1;
                textLabel2_1.Location = point2;
                Point point3 = point1;
                textLabel1_1.Location = point3;
            }
        }

        public void ShowNotice(string text, int type = 0)
        {
            Index = type == 0 ? 6911 : 6913;
            Layout.Index = type == 0 ? 327 : 6912;
            str = TextLabel1.Text = TextLabel2.Text = text;
            TextLabel1.Visible = type == 0;
            TextLabel2.Visible = type == 1;
            DXLabel textLabel1 = TextLabel1;
            DXLabel textLabel2 = TextLabel2;
            Point point1 = new Point(15, 3);
            Point point2 = point1;
            textLabel2.Location = point2;
            Point point3 = point1;
            textLabel1.Location = point3;
            CurrentTime = CEnvir.Now.AddMilliseconds(20000.0);
            speed = CEnvir.Now.Ticks;
            Show();
        }

        public void Show()
        {
            if (Visible)
                return;
            Visible = true;
        }

        public void Hide()
        {
            if (!Visible)
                return;
            Visible = false;
        }
    }
}
