using Client.Controls;
using Client.Envir;
using Client.UserModels;
using Library;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Client.Scenes.Views
{
    public class ChatRDialog : DXWindow
    {
        public List<DXLabel> History = new List<DXLabel>();
        private readonly object obj = (object)1;

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

        public ChatRDialog()
        {
            Movable = false;
            Opacity = 0.0f;
            HasTitle = false;
            HasTopBorder = false;
            CloseButton.Visible = false;
            Border = false;
            PassThrough = true;
            Size = new Size(GameScene.Game.ChatBox.TextBackgroundPanel.Size.Width - 10, 70);
            History = new List<DXLabel>();
        }

        public void ReceiveChat(string message, MessageType type)
        {
            DXLabel dxLabel1 = new DXLabel();
            dxLabel1.Tag = (object)CEnvir.Now;
            dxLabel1.Parent = (DXControl)this;
            dxLabel1.PassThrough = true;
            DXLabel dxLabel2 = dxLabel1;
            string str = "";
            switch (type - 7)
            {
                case (MessageType)0:
                case (MessageType)4:
                    if (!GameScene.Game.ChatBox.IsAll)
                        return;
                    dxLabel2.ForeColour = Color.White;
                    break;
                case (MessageType)1:
                    if (!GameScene.Game.ChatBox.IsSystem && !GameScene.Game.ChatBox.IsAll)
                        return;
                    dxLabel2.ForeColour = Color.FromArgb((int)byte.MaxValue, 0, 0);
                    break;
                case (MessageType)2:
                    dxLabel2.ForeColour = Color.FromArgb(170, 150, 253);
                    break;
                case (MessageType)3:
                    if (!GameScene.Game.ChatBox.IsAll)
                        return;
                    dxLabel2.ForeColour = Color.White;
                    break;
                default:
                    return;
            }
            dxLabel2.Tag = (object)CEnvir.Now;
            dxLabel2.Text = str + message;
            DXLabel label = dxLabel2;
            Size size = Size;
            int width = size.Width - 40;
            Size height1 = DXLabel.GetHeight(label, width);
            dxLabel2.Size = new Size(height1.Width, height1.Height);
            lock (obj)
            {
                size = dxLabel2.Size;
                UpdateItems(size.Height);
                DXLabel dxLabel3 = dxLabel2;
                int x = 0;
                size = Size;
                int height2 = size.Height;
                size = dxLabel2.Size;
                int height3 = size.Height;
                int y = height2 - height3;
                Point point = new Point(x, y);
                dxLabel3.Location = point;
                History.Add(dxLabel2);
                Visible = true;
            }
        }

        public override void Process()
        {
            base.Process();
            Visible = (uint)History.Count<DXLabel>((Func<DXLabel, bool>)(p => p.Visible)) > 0U;
            if (History.Count <= 0)
                return;
            lock (obj)
            {
                DXLabel dxLabel = History.FirstOrDefault<DXLabel>((Func<DXLabel, bool>)(p => p.Visible));
                if (dxLabel != null && !dxLabel.IsDisposed && (CEnvir.Now - (DateTime)dxLabel.Tag).Seconds > 7)
                    dxLabel.Visible = false;
            }
        }

        private void UpdateItems(int height)
        {
            while (History.Count > 3)
            {
                DXLabel dxLabel = History[0];
                History.Remove(dxLabel);
                dxLabel.Dispose();
            }
            foreach (DXLabel dxLabel1 in History)
            {
                DXLabel dxLabel2 = dxLabel1;
                Point location = dxLabel1.Location;
                int x = location.X;
                location = dxLabel1.Location;
                int y = location.Y - height;
                Point point = new Point(x, y);
                dxLabel2.Location = point;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing || History == null)
                return;
            for (int index = 0; index < History.Count; ++index)
            {
                if (History[index] != null)
                {
                    if (!History[index].IsDisposed)
                        History[index].Dispose();
                    History[index] = (DXLabel)null;
                }
            }
            History.Clear();
            History = (List<DXLabel>)null;
        }
    }
}
