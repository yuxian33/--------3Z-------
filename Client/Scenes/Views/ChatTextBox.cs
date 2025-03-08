using Client.Controls;
using Client.Envir;
using Client.UserModels;
using Library;
using Library.Network;
using Library.Network.ClientPackets;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client.Scenes.Views
{
    public sealed class ChatTextBox : DXWindow
    {
        private ChatMode _Mode;
        public string LastPM;
        public DXTextBox TextBox;
        public DXImageControl Background;
        public DxMirButton ChangeButton;
        public DXButton ChatModeButton;

        public ChatMode Mode
        {
            get
            {
                return _Mode;
            }
            set
            {
                if (_Mode == value)
                    return;
                ChatMode mode = _Mode;
                _Mode = value;
                OnModeChanged(mode, value);
            }
        }

        public event EventHandler<EventArgs> ModeChanged;

        public void OnModeChanged(ChatMode oValue, ChatMode nValue)
        {
            
            EventHandler<EventArgs> modeChanged = ModeChanged;
            if (modeChanged != null)
                modeChanged((object)this, EventArgs.Empty);
            if (ChatModeButton == null)
                return;
            switch (nValue)
            {
                case ChatMode.Local:
                    ChatModeButton.Label.Text = "";
                    ChatModeButton.Index = 3573;
                    break;
                case ChatMode.Whisper:
                    ChatModeButton.Label.Text = "";
                    ChatModeButton.Index = 3568;
                    break;
                case ChatMode.Group:
                    ChatModeButton.Label.Text = "";
                    ChatModeButton.Index = 3523;
                    break;
                case ChatMode.Guild:
                    ChatModeButton.Label.Text = "";
                    ChatModeButton.Index = 3528;
                    break;
                case ChatMode.Shout:
                    ChatModeButton.Label.Text = "";
                    ChatModeButton.Index = 3578;
                    break;
                case ChatMode.Global:
                    ChatModeButton.Label.Text = "";
                    ChatModeButton.Index = 3578;
                    break;
                case ChatMode.Observer:
                    ChatModeButton.Label.Text = "";
                    ChatModeButton.Index = 3583;
                    break;
            }
        }

        public override void OnParentChanged(DXControl oValue, DXControl nValue)
        {
            base.OnParentChanged(oValue, nValue);
            if (GameScene.Game.MainPanel == null)
                return;
            Location = new Point(GameScene.Game.MainPanel.Location.X, GameScene.Game.MainPanel.DisplayArea.Top - Size.Height);
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
                return true;
            }
        }

        public override bool AutomaticVisiblity
        {
            get
            {
                return true;
            }
        }

        public ChatTextBox()
        {
            Size = new Size(400, 25);
            Opacity = 0.0f;
            HasTitle = false;
            HasFooter = false;
            HasTopBorder = false;
            CloseButton.Visible = false;
            AllowResize = false;
            Movable = false;
            DXImageControl dxImageControl = new DXImageControl();
            dxImageControl.LibraryFile = (LibraryFile)3;
            dxImageControl.Index = 3503;
            dxImageControl.ImageOpacity = 0.7f;
            dxImageControl.Parent = (DXControl)this;
            Background = dxImageControl;
            Background.Location = Location;
            DXButton dxButton = new DXButton();
            dxButton.LibraryFile = (LibraryFile)3;
            dxButton.Index = 3518;
            dxButton.ImageOpacity = 0.7f;
            dxButton.Size = new Size(60, 18);
            dxButton.Parent = (DXControl)this;
            dxButton.Border = false;
            dxButton.BorderSize = 0.0f;
            ChatModeButton = dxButton;
            ChatModeButton.MouseClick += (EventHandler<MouseEventArgs>)((o, e) => Mode = (ChatMode)((int)(Mode + 1) % 7));
            DxMirButton dxMirButton = new DxMirButton();
            dxMirButton.Size = new Size(20, 18);
            dxMirButton.LibraryFile = (LibraryFile)3;
            dxMirButton.Index = 3552;
            dxMirButton.Parent = (DXControl)this;
            ChangeButton = dxMirButton;
            ChangeButton.MouseClick += (EventHandler<MouseEventArgs>)((s, e) => GameScene.Game.ChatBox.ChangeSize());
            DXTextBox dxTextBox = new DXTextBox();
            dxTextBox.Size = new Size(295, 20);
            dxTextBox.Parent = (DXControl)this;
            dxTextBox.MaxLength = 120;
            dxTextBox.Opacity = 0.0f;
            
            dxTextBox.BackColour = Color.FromArgb(35, 26, 18);
            dxTextBox.IsControl = true;
            dxTextBox.BorderSize = 0.0f;
            dxTextBox.Border = false;
            TextBox = dxTextBox;
            TextBox.TextBox.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
            int width1 = TextBox.Size.Width;
            Size size = ChatModeButton.Size;
            int width2 = size.Width;
            int num1 = width1 + width2 + 15;
            size = ChangeButton.Size;
            int width3 = size.Width;
            int width4 = num1 + width3;
            size = TextBox.Size;
            int height = size.Height;
            SetClientSize(new Size(width4, height));
            DXButton chatModeButton = ChatModeButton;
            int x1 = ClientArea.Location.X;
            Rectangle clientArea = ClientArea;
            int y1 = clientArea.Y - 1;
            Point point1 = new Point(x1, y1);
            chatModeButton.Location = point1;
            DXTextBox textBox = TextBox;
            clientArea = ClientArea;
            int x2 = clientArea.Location.X;
            size = ChatModeButton.Size;
            int width5 = size.Width;
            int x3 = x2 + width5 + 1;
            clientArea = ClientArea;
            int y2 = clientArea.Y;
            Point point2 = new Point(x3, y2);
            textBox.Location = point2;
            DxMirButton changeButton = ChangeButton;
            clientArea = ClientArea;
            int x4 = clientArea.Location.X;
            size = TextBox.Size;
            int width6 = size.Width;
            int num2 = x4 + width6;
            size = ChatModeButton.Size;
            int width7 = size.Width;
            int x5 = num2 + width7 + 9;
            clientArea = ClientArea;
            int y3 = clientArea.Y - 1;
            Point point3 = new Point(x5, y3);
            changeButton.Location = point3;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '\r':
                    e.Handled = true;
                    if (!string.IsNullOrEmpty(TextBox.TextBox.Text))
                    {
                        Chat chat = new Chat();
                        chat.Text = TextBox.TextBox.Text;
                        CEnvir.Enqueue((Packet)chat);
                        if (TextBox.TextBox.Text[0] == '/')
                        {
                            string[] strArray = TextBox.TextBox.Text.Split(' ');
                            if ((uint)strArray.Length > 0U)
                                LastPM = strArray[0];
                        }
                        TextBox.TextBox.Text = string.Empty;
                    }
                    DXTextBox.ActiveTextBox = (DXTextBox)null;
                    if (GameScene.Game.ChatBox.Visible)
                        break;
                    Visible = false;
                    break;
                case '\x001B':
                    e.Handled = true;
                    DXTextBox.ActiveTextBox = (DXTextBox)null;
                    TextBox.TextBox.Text = string.Empty;
                    break;
            }
        }

        public override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            switch (e.KeyChar)
            {
                case '\r':
                case ' ':
                    OpenChat();
                    e.Handled = true;
                    break;
                case '!':
                    if (!Config.ShiftOpenChat)
                        break;
                    TextBox.SetFocus();
                    TextBox.TextBox.Text = "!";
                    TextBox.Visible = true;
                    TextBox.TextBox.SelectionLength = 0;
                    TextBox.TextBox.SelectionStart = TextBox.TextBox.Text.Length;
                    e.Handled = true;
                    break;
                case '/':
                    TextBox.SetFocus();
                    if (string.IsNullOrEmpty(LastPM))
                        TextBox.TextBox.Text = "/";
                    else
                        TextBox.TextBox.Text = LastPM + " ";
                    TextBox.Visible = true;
                    TextBox.TextBox.SelectionLength = 0;
                    TextBox.TextBox.SelectionStart = TextBox.TextBox.Text.Length;
                    e.Handled = true;
                    break;
                case '@':
                    TextBox.SetFocus();
                    TextBox.TextBox.Text = "@";
                    TextBox.Visible = true;
                    TextBox.TextBox.SelectionLength = 0;
                    TextBox.TextBox.SelectionStart = TextBox.TextBox.Text.Length;
                    e.Handled = true;
                    break;
            }
        }

        public void OpenChat()
        {
            if (string.IsNullOrEmpty(TextBox.TextBox.Text))
            {
                switch (Mode)
                {
                    case ChatMode.Whisper:
                        if (!string.IsNullOrWhiteSpace(LastPM))
                        {
                            TextBox.TextBox.Text = LastPM + " ";
                            break;
                        }
                        break;
                    case ChatMode.Group:
                        TextBox.TextBox.Text = "!!";
                        break;
                    case ChatMode.Guild:
                        TextBox.TextBox.Text = "!~";
                        break;
                    case ChatMode.Shout:
                        TextBox.TextBox.Text = "!";
                        break;
                    case ChatMode.Global:
                        TextBox.TextBox.Text = "!@";
                        break;
                    case ChatMode.Observer:
                        TextBox.TextBox.Text = "#";
                        break;
                }
            }
            TextBox.SetFocus();
            TextBox.TextBox.SelectionLength = 0;
            TextBox.TextBox.SelectionStart = TextBox.TextBox.Text.Length;
        }
        
        public void AddItem(ClientUserItem clientUserItem)
        {
            TextBox.SetFocus();
            TextBox.TextBox.Text += string.Format(@"{{{0}<{1}>}}", clientUserItem?.Info?.ItemName, clientUserItem?.Index);
            TextBox.TextBox.SelectionLength = 0;
            TextBox.TextBox.SelectionStart = TextBox.TextBox.Text.Length;
            TextBox.KeepFocus = true;
        }

        public void StartPM(string name)
        {
            TextBox.TextBox.Text = "/" + name + " ";
            TextBox.SetFocus();
            TextBox.TextBox.SelectionLength = 0;
            TextBox.TextBox.SelectionStart = TextBox.TextBox.Text.Length;
        }

        public void ChatBoxChanged(bool isUp)
        {
            ChangeButton.Reset();
            ChangeButton.Index = isUp ? 3542 : 3552;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing)
                return;
            _Mode = ChatMode.Local;
            
            ModeChanged = (EventHandler<EventArgs>)null;
            LastPM = (string)null;
            if (Background != null)
            {
                if (!Background.IsDisposed)
                    Background.Dispose();
                Background = (DXImageControl)null;
            }
            if (TextBox != null)
            {
                if (!TextBox.IsDisposed)
                    TextBox.Dispose();
                TextBox = (DXTextBox)null;
            }
            if (ChangeButton != null)
            {
                if (!ChangeButton.IsDisposed)
                    ChangeButton.Dispose();
                ChangeButton = (DxMirButton)null;
            }
            if (ChatModeButton != null)
            {
                if (!ChatModeButton.IsDisposed)
                    ChatModeButton.Dispose();
                ChatModeButton = (DXButton)null;
            }
        }
    }
}
