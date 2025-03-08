using Client.Controls;
using Client.Envir;
using Client.UserModels;
using Library;
using Library.Network;
using Library.Network.ClientPackets;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Client.Scenes.Views
{
    public sealed class FangGuajiDialog : DXWindow
    {
        
        public DXLabel Label;
        public DXLabel ShowTimeLabel;
        public DXButton ConfirmButton;
        public DXTextBox ValueTextBox;
        public DateTime ShowTimeSpan;
        public string Value;
        public DXImageControl Image;

        public override WindowType Type
        {
            get
            {
                return WindowType.FangGuajiBox;
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

        public FangGuajiDialog()
        {
            Image = new DXImageControl()
            {
                Parent = this,
                LibraryFile = LibraryFile.GameInter,
                Index = 281,
                Location = new Point(0, 0),
                IsControl = false,
            };
            HasFooter = true;
            TitleLabel.Text = "防挂机验证";
            CloseButton.Visible = false;
            Label = new DXLabel()
            {
                AutoSize = false,
                Location = new Point(10, 60),
                Font = new Font(Config.FontName, CEnvir.FontSize(10f), FontStyle.Bold),
                Parent = this,
                Text = "答题加载中",
                ForeColour = Color.PaleGreen,
                DrawFormat = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak,
            };
            Label.Size = new Size(300, DXLabel.GetHeight(Label, 300).Height);

            DXLabel dxLabel2 = new DXLabel();
            dxLabel2.AutoSize = false;
            dxLabel2.Location = new Point(10, Label.Size.Height + 78);
            dxLabel2.Parent = this;
            dxLabel2.Text = "请注意，正在进行倒计时.....";
            dxLabel2.DrawFormat = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;
            ShowTimeLabel = dxLabel2;
            ShowTimeLabel.Size = new Size(300, DXLabel.GetHeight(ShowTimeLabel, 300).Height);
            DXTextBox dxTextBox = new DXTextBox();
            dxTextBox.Parent = this;
            dxTextBox.Size = new Size(200, 20);
            dxTextBox.Location = new Point(60, 87 + ShowTimeLabel.Size.Height + Label.Size.Height);
            dxTextBox.KeepFocus = true;
            dxTextBox.Border = false;
            ValueTextBox = dxTextBox;
            ValueTextBox.TextBox.TextChanged += new EventHandler(TextBox_TextChanged);
            ValueTextBox.TextBox.KeyPress += (KeyPressEventHandler)((action, obj1_2) => OnKeyPress(obj1_2));
            Size size1 = ValueTextBox.Size;
            int height1 = size1.Height;
            size1 = ShowTimeLabel.Size;
            int height2 = size1.Height;
            int num = height1 + height2;
            size1 = Label.Size;
            int height3 = size1.Height;
            SetClientSize(new Size(300, num + height3 + 40));
            
            DXButton dxButton = new DXButton();
            dxButton.Location = new Point(Size.Width / 2 - 40, Size.Height - 43);
            dxButton.Size = new Size(80, DXControl.DefaultHeight);
            dxButton.Parent = this;
            dxButton.Label.Text = "确认";
            ConfirmButton = dxButton;
            ConfirmButton.MouseClick += (EventHandler<MouseEventArgs>)((action, obj1_2) =>
            {
                ClientAnswerTestGj clientAnswerTestGj = new ClientAnswerTestGj();
                clientAnswerTestGj.Answer = Value;
                CEnvir.Enqueue((Packet)clientAnswerTestGj);
            });
            ConfirmButton.MouseClick += (EventHandler<MouseEventArgs>)((obj0, element) =>
            {
                Visible = false;
                ShowTimeSpan = CEnvir.Now;
                Label.Text = "目前没有验证内容";
                ShowTimeLabel.Text = "";
                ConfirmButton.Enabled = false;
            });
        }

        public override void OnKeyPress(KeyPressEventArgs value)
        {
            base.OnKeyPress(value);
            switch (value.KeyChar)
            {
                case '\r':
                    if (ConfirmButton != null && !ConfirmButton.IsDisposed)
                    {
                        ConfirmButton.InvokeMouseClick();
                        break;
                    }
                    break;
                case '\x001B':
                    Visible = false;
                    break;
                default:
                    return;
            }
            value.Handled = true;
        }

        private void TextBox_TextChanged(object value, [In] EventArgs obj1)
        {
            Value = ValueTextBox.TextBox.Text;
            ConfirmButton.Enabled = ValueTextBox.TextBox.Text != "";
        }

        protected override void Dispose(bool value)
        {
            base.Dispose(value);
            if (!value)
                return;
            if (Label != null)
            {
                if (!Label.IsDisposed)
                    Label.Dispose();
                Label = (DXLabel)null;
            }
            if (ShowTimeLabel != null)
            {
                if (!ShowTimeLabel.IsDisposed)
                    ShowTimeLabel.Dispose();
                ShowTimeLabel = (DXLabel)null;
            }
            if (ConfirmButton != null)
            {
                if (!ConfirmButton.IsDisposed)
                    ConfirmButton.Dispose();
                ConfirmButton = (DXButton)null;
            }
            
            if (ValueTextBox == null)
                return;
            if (!ValueTextBox.IsDisposed)
                ValueTextBox.Dispose();
            ValueTextBox = (DXTextBox)null;
            
        }
    }
}
