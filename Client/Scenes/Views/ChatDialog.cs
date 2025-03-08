using Client.Controls;
using Client.Envir;
using Client.UserModels;
using Library;
using Library.Network;
using Library.Network.ClientPackets;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Client.Scenes.Views
{
    public class ChatDialog : DXWindow
    {
        public static int change = 1;
        public static int oldHeight = 0;
        public static int oldHeight2 = 0;
        public static int oldScroolHeight = 0;
        public static int oldY = 0;
        public List<DXLabel> History = new List<DXLabel>();
        private readonly int buttonHight = DXControl.SmallButtonHeight;
        private readonly int chatBoxHieght = 60;
        private readonly int BackgroudItemHeight = 15;
        public DXControl TextBackgroundPanel;
        public DXControl TextPanel;
        public DXImageControl TabPanel;
        public DXImageControl TextBoxPanel;
        public DXImageControl Background;
        public DXMirScrollBar ScrollBar;
        public DXButton AllButton;
        public DXButton GroupButton;
        public DXButton HintButton;
        public DXButton NormalButton;
        public DXButton SystemButton;
        
        public DXButton GlobalButton;
        public DXButton GuildButton;
        
        
        public DXButton CloseBtn;
        public bool IsAll;
        public bool IsHint;
        public bool IsGlobal;
        public bool IsGroup;
        public bool IsNormal;
        public bool IsSystem;
        
        public bool IsGuild;
        
        

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

        public ChatDialog()
        {
            DXImageControl dxImageControl1 = new DXImageControl();
            dxImageControl1.Parent = (DXControl)this;
            dxImageControl1.LibraryFile = (LibraryFile)3;
            dxImageControl1.Index = 3502;
            dxImageControl1.ImageOpacity = 0.7f;
            dxImageControl1.FixedSize = true;
            TextBoxPanel = dxImageControl1;
            TextBoxPanel.Size = new Size(380, 20);
            chatBoxHieght = TextBoxPanel.Size.Height;
            Size = new Size(380, 248 + chatBoxHieght);
            DXImageControl textBoxPanel = TextBoxPanel;
            int x1 = 0;
            Size size1 = Size;
            int height1 = size1.Height;
            size1 = TextBoxPanel.Size;
            int height2 = size1.Height;
            int y1 = height1 - height2;
            Point point1 = new Point(x1, y1);
            textBoxPanel.Location = point1;
            Movable = false;
            Opacity = 0.0f;
            HasTitle = false;
            HasTopBorder = false;
            CloseButton.Visible = false;
            Border = false;
            BackColour = Color.Black;
            AllowResize = false;
            CanResizeWidth = false;
            CanResizeHeightBottom = false;
            IsAll = true;
            IsNormal = true;
            IsHint = true;
            IsGlobal = true;
            IsGroup = true;
            IsSystem = true;
            
            IsGuild = true;
            
            
            DXImageControl dxImageControl2 = new DXImageControl();
            dxImageControl2.Location = new Point(0, 0);
            dxImageControl2.Parent = (DXControl)this;
            dxImageControl2.BackColour = Color.Black;
            dxImageControl2.PassThrough = true;
            dxImageControl2.ImageOpacity = 0.7f;
            dxImageControl2.Size = new Size(380, 48);
            dxImageControl2.LibraryFile = (LibraryFile)3;
            dxImageControl2.Index = 3500;
            TabPanel = dxImageControl2;
            Size size2 = new Size(48, buttonHight);
            int width1 = size2.Width;
            int x2 = 4;
            DXButton dxButton1 = new DXButton();
            dxButton1.ImageOpacity = 0.7f;
            dxButton1.LibraryFile = (LibraryFile)3;
            dxButton1.Index = 3511;
            dxButton1.ButtonType = ButtonType.SmallButton;
            dxButton1.Tag = (object)(MessageType)13;
            dxButton1.Hint = "全部";
            dxButton1.Size = size2;
            dxButton1.Parent = (DXControl)TabPanel;
            dxButton1.Location = new Point(x2, 4);
            AllButton = dxButton1;
            AllButton.MouseClick += new EventHandler<MouseEventArgs>(ChatMouseClick);
            DXButton dxButton2 = new DXButton();
            dxButton2.ImageOpacity = 0.7f;
            dxButton2.LibraryFile = (LibraryFile)3;
            dxButton2.Index = 3516;
            dxButton2.ButtonType = ButtonType.SmallButton;
            dxButton2.Tag = MessageType.Normal;
            dxButton2.Hint = "一般";
            dxButton2.Size = size2;
            dxButton2.Parent = (DXControl)TabPanel;
            dxButton2.Location = new Point(x2 + width1, 4);
            NormalButton = dxButton2;
            NormalButton.MouseClick += new EventHandler<MouseEventArgs>(ChatMouseClick);
            DXButton dxButton3 = new DXButton();
            dxButton3.ImageOpacity = 0.7f;
            dxButton3.LibraryFile = (LibraryFile)3;
            dxButton3.Index = 3521;
            dxButton3.ButtonType = ButtonType.SmallButton;
            dxButton3.Tag = (object)(MessageType)5;
            dxButton3.Hint = "组队";
            dxButton3.Size = size2;
            dxButton3.Parent = (DXControl)TabPanel;
            dxButton3.Location = new Point(x2 + width1 * 2, 4);
            GroupButton = dxButton3;
            GroupButton.MouseClick += new EventHandler<MouseEventArgs>(ChatMouseClick);
            DXButton dxButton4 = new DXButton();
            dxButton4.ImageOpacity = 0.7f;
            dxButton4.LibraryFile = (LibraryFile)3;
            dxButton4.Index = 3576;
            dxButton4.ButtonType = ButtonType.SmallButton;
            dxButton4.Tag = MessageType.Global;
            dxButton4.Hint = "世界";
            dxButton4.Size = size2;
            dxButton4.Parent = (DXControl)TabPanel;
            dxButton4.Location = new Point(x2 + width1 * 3, 4);
            GlobalButton = dxButton4;
            GlobalButton.MouseClick += new EventHandler<MouseEventArgs>(ChatMouseClick);
            DXButton dxButton5 = new DXButton();
            dxButton5.ImageOpacity = 0.7f;
            dxButton5.LibraryFile = (LibraryFile)3;
            dxButton5.Index = 3526;
            dxButton5.ButtonType = ButtonType.SmallButton;
            dxButton5.Tag = (object)(MessageType)12;
            dxButton5.Hint = "公会";
            dxButton5.Size = size2;
            dxButton5.Parent = (DXControl)TabPanel;
            dxButton5.Location = new Point(x2 + width1 * 4, 4);
            GuildButton = dxButton5;
            GuildButton.MouseClick += new EventHandler<MouseEventArgs>(ChatMouseClick);
            DXButton dxButton6 = new DXButton();
            dxButton6.ImageOpacity = 0.7f;
            dxButton6.LibraryFile = (LibraryFile)3;
            dxButton6.Index = 3531;
            dxButton6.ButtonType = ButtonType.SmallButton;
            dxButton6.Tag = (object)(MessageType)8;
            dxButton6.Hint = "系统";
            dxButton6.Size = size2;
            dxButton6.Parent = (DXControl)TabPanel;
            dxButton6.Location = new Point(x2 + width1 * 5, 4);
            SystemButton = dxButton6;
            SystemButton.MouseClick += new EventHandler<MouseEventArgs>(ChatMouseClick);
            DXButton dxButton7 = new DXButton();
            dxButton7.ImageOpacity = 0.7f;
            dxButton7.LibraryFile = LibraryFile.GameInter;
            dxButton7.Index = 3586;
            dxButton7.ButtonType = ButtonType.SmallButton;
            dxButton7.Tag = MessageType.Hint;
            dxButton7.Hint = "提示";
            dxButton7.Size = size2;
            dxButton7.Parent = (DXControl)TabPanel;
            dxButton7.Location = new Point(x2 + width1 * 6, 4);
            HintButton = dxButton7;
            HintButton.MouseClick += new EventHandler<MouseEventArgs>(ChatMouseClick);
            DXButton dxButton8 = new DXButton();
            dxButton8.ImageOpacity = 0.7f;
            dxButton8.LibraryFile = (LibraryFile)3;
            dxButton8.Index = 3545;
            dxButton8.ButtonType = ButtonType.SmallButton;
            dxButton8.Size = new Size(16, 18);
            dxButton8.Parent = (DXControl)TabPanel;
            dxButton8.Location = new Point(x2 + width1 * 7 + 4, 6);
            CloseBtn = dxButton8;
            CloseBtn.MouseClick += new EventHandler<MouseEventArgs>(CloseDialog);
            DXControl dxControl1 = new DXControl();
            dxControl1.Parent = (DXControl)this;
            dxControl1.BackColour = Color.Black;
            dxControl1.Opacity = 0.3f;
            dxControl1.PassThrough = true;
            dxControl1.Location = new Point(TabPanel.Location.X, TabPanel.Size.Height);
            Size size3 = TabPanel.Size;
            int width2 = size3.Width;
            size3 = Size;
            int height3 = size3.Height;
            size3 = TabPanel.Size;
            int height4 = size3.Height;
            int num1 = height3 - height4;
            size3 = TextBoxPanel.Size;
            int height5 = size3.Height;
            int height6 = num1 - height5;
            dxControl1.Size = new Size(width2, height6);
            TextBackgroundPanel = dxControl1;
            DXImageControl dxImageControl3 = new DXImageControl();
            dxImageControl3.Parent = TextBackgroundPanel;
            dxImageControl3.LibraryFile = (LibraryFile)2;
            dxImageControl3.Index = 130;
            
            dxImageControl3.TilingMode = TilingMode.None;
            dxImageControl3.ImageOpacity = 0.7f;
            dxImageControl3.Border = false;
            dxImageControl3.Size = new Size(360, 15);
            dxImageControl3.FixedSize = true;
            Background = dxImageControl3;
            DXControl dxControl2 = new DXControl();
            dxControl2.Parent = (DXControl)this;
            dxControl2.BackColour = Color.Black;
            dxControl2.Opacity = 0.0f;
            dxControl2.PassThrough = true;
            dxControl2.Location = new Point(TabPanel.Location.X, TabPanel.Size.Height - BackgroudItemHeight / 2);
            Size size4 = TabPanel.Size;
            int width3 = size4.Width - 10;
            size4 = Size;
            int height7 = size4.Height;
            size4 = TabPanel.Size;
            int height8 = size4.Height;
            int num2 = height7 - height8;
            size4 = TextBoxPanel.Size;
            int height9 = size4.Height;
            int height10 = num2 - height9 + BackgroudItemHeight;
            dxControl2.Size = new Size(width3, height10);
            TextPanel = dxControl2;
            DXMirScrollBar dxMirScrollBar = new DXMirScrollBar();
            dxMirScrollBar.Parent = (DXControl)this;
            dxMirScrollBar.Size = new Size(16, TextBackgroundPanel.Size.Height + BackgroudItemHeight * 2);
            dxMirScrollBar.VisibleSize = TextPanel.Size.Height;
            ScrollBar = dxMirScrollBar;
            DXMirScrollBar scrollBar = ScrollBar;
            Size size5 = Size;
            int width4 = size5.Width;
            size5 = ScrollBar.Size;
            int width5 = size5.Width;
            int x3 = width4 - width5 - 8;
            size5 = TabPanel.Size;
            int y2 = size5.Height - BackgroudItemHeight;
            Point point2 = new Point(x3, y2);
            scrollBar.Location = point2;
            ScrollBar.ValueChanged += (EventHandler<EventArgs>)((o, e) => UpdateItems());
            MouseWheel += new EventHandler<MouseEventArgs>(ScrollBar.DoMouseWheel);
            UpdateBackgrouds();
        }

        public override void OnIsResizingChanged(bool oValue, bool nValue)
        {
            ResizeChat();
            base.OnIsResizingChanged(oValue, nValue);
        }

        private void CloseDialog(object sender, MouseEventArgs e)
        {
            Visible = false;
        }

        public void ChangeSize()
        {
            if (!Visible)
            {
                Visible = true;
                GameScene.Game.ChatTextBox.ChatBoxChanged(!Visible);
            }
            else
            {
                Size size1;
                Point location;
                if (ChatDialog.oldHeight == 0)
                {
                    size1 = TextBackgroundPanel.Size;
                    ChatDialog.oldHeight = size1.Height;
                    size1 = TextPanel.Size;
                    ChatDialog.oldHeight2 = size1.Height;
                    size1 = ScrollBar.Size;
                    ChatDialog.oldScroolHeight = size1.Height;
                    location = Location;
                    ChatDialog.oldY = location.Y;
                }
                if (ChatDialog.change == 4)
                {
                    Visible = false;
                    GameScene.Game.ChatTextBox.ChatBoxChanged(!Visible);
                    ChatDialog.change = 0;
                    DXControl textBackgroundPanel = TextBackgroundPanel;
                    size1 = TextBackgroundPanel.Size;
                    Size size2 = new Size(size1.Width, ChatDialog.oldHeight);
                    textBackgroundPanel.Size = size2;
                    DXControl textPanel = TextPanel;
                    size1 = TextPanel.Size;
                    Size size3 = new Size(size1.Width, ChatDialog.oldHeight2);
                    textPanel.Size = size3;
                    DXMirScrollBar scrollBar = ScrollBar;
                    size1 = ScrollBar.Size;
                    Size size4 = new Size(size1.Width, ChatDialog.oldScroolHeight);
                    scrollBar.Size = size4;
                    location = Location;
                    Location = new Point(location.X, ChatDialog.oldY);
                }
                else
                {
                    DXControl textBackgroundPanel = TextBackgroundPanel;
                    size1 = TextBackgroundPanel.Size;
                    int width1 = size1.Width;
                    size1 = TextBackgroundPanel.Size;
                    int height1 = size1.Height - BackgroudItemHeight * 3;
                    Size size2 = new Size(width1, height1);
                    textBackgroundPanel.Size = size2;
                    DXControl textPanel = TextPanel;
                    size1 = TextPanel.Size;
                    int width2 = size1.Width;
                    size1 = TextPanel.Size;
                    int height2 = size1.Height - BackgroudItemHeight * 3;
                    Size size3 = new Size(width2, height2);
                    textPanel.Size = size3;
                    DXMirScrollBar scrollBar = ScrollBar;
                    size1 = ScrollBar.Size;
                    int width3 = size1.Width;
                    size1 = ScrollBar.Size;
                    int height3 = size1.Height - BackgroudItemHeight * 3;
                    Size size4 = new Size(width3, height3);
                    scrollBar.Size = size4;
                    location = Location;
                    int x = location.X;
                    location = Location;
                    int y = location.Y + BackgroudItemHeight * 3;
                    Location = new Point(x, y);
                }
                size1 = Size;
                int width = size1.Width;
                size1 = TabPanel.Size;
                int height4 = size1.Height;
                size1 = TextBackgroundPanel.Size;
                int height5 = size1.Height;
                int num = height4 + height5;
                size1 = TextBoxPanel.Size;
                int height6 = size1.Height;
                int height7 = num + height6;
                Size = new Size(width, height7);
                DXControl textBackgroundPanel1 = TextBackgroundPanel;
                location = TabPanel.Location;
                int x1 = location.X;
                size1 = TabPanel.Size;
                int height8 = size1.Height;
                Point point1 = new Point(x1, height8);
                textBackgroundPanel1.Location = point1;
                DXMirScrollBar scrollBar1 = ScrollBar;
                location = ScrollBar.Location;
                int x2 = location.X;
                size1 = TabPanel.Size;
                int y1 = size1.Height - BackgroudItemHeight;
                Point point2 = new Point(x2, y1);
                scrollBar1.Location = point2;
                DXControl textPanel1 = TextPanel;
                location = TabPanel.Location;
                int x3 = location.X;
                size1 = TabPanel.Size;
                int y2 = size1.Height - BackgroudItemHeight / 2;
                Point point3 = new Point(x3, y2);
                textPanel1.Location = point3;
                DXImageControl textBoxPanel = TextBoxPanel;
                location = TextBoxPanel.Location;
                int x4 = location.X;
                size1 = Size;
                int height9 = size1.Height;
                size1 = TextBoxPanel.Size;
                int height10 = size1.Height;
                int y3 = height9 - height10;
                Point point4 = new Point(x4, y3);
                textBoxPanel.Location = point4;
                ResizeChat();
                ++ChatDialog.change;
            }
        }

        private void ChatMouseClick(object sender, MouseEventArgs e)
        {
            MessageType result;
            if (!Enum.TryParse<MessageType>(((DXControl)sender).Tag.ToString(), out result))
                return;
            MessageType messageType = result;
#pragma warning disable CS0472 
            if (messageType != null)
#pragma warning restore CS0472 
            {
                switch (messageType)
                {
                    case MessageType.Normal:
                        IsNormal = !IsNormal;
                        ChangeAllButtonStatue(IsNormal);
                        NormalButton.Index = IsNormal ? 3516 : 3515;
                        break;
                    case MessageType.Group:
                        IsGroup = !IsGroup;
                        ChangeAllButtonStatue(IsGroup);
                        GroupButton.Index = IsGroup ? 3521 : 3520;
                        break;
                    case MessageType.Global:
                        IsGlobal = !IsGlobal;
                        ChangeAllButtonStatue(IsGlobal);
                        GlobalButton.Index = IsGlobal ? 3576 : 3575;
                        break;
                    
                    
                    
                    
                    
                    case MessageType.System:
                        IsSystem = !IsSystem;
                        ChangeAllButtonStatue(IsSystem);
                        SystemButton.Index = IsSystem ? 3531 : 3530;
                        break;
                    case MessageType.Hint:
                        IsHint = !IsHint;
                        ChangeAllButtonStatue(IsHint);
                        HintButton.Index = IsHint ? 3586 : 3585;
                        break;
                    case MessageType.Guild:
                        IsGuild = !IsGuild;
                        ChangeAllButtonStatue(IsGuild);
                        GuildButton.Index = IsGuild ? 3526 : 3525;
                        break;
                    case MessageType.Notice:
                        IsAll = !IsAll;
                        IsGuild = IsAll;
                        IsHint = IsAll;
                        IsGlobal = IsAll;
                        IsGroup = IsAll;
                        IsNormal = IsAll;
                        IsSystem = IsAll;
                        
                        
                        
                        AllButton.Index = IsAll ? 3511 : 3510;
                        GuildButton.Index = IsGuild ? 3526 : 3525;
                        HintButton.Index = IsHint ? 3586 : 3585;
                        GroupButton.Index = IsGroup ? 3521 : 3520;
                        NormalButton.Index = IsNormal ? 3516 : 3515;
                        SystemButton.Index = IsSystem ? 3531 : 3530;
                        GlobalButton.Index = IsGlobal ? 3576 : 3575;
                        
                        
                        
                        break;
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                }
            }
            else
            {
                IsNormal = !IsNormal;
                ChangeAllButtonStatue(IsNormal);
                NormalButton.Index = IsNormal ? 3516 : 3515;
            }
        }

        private void ChangeAllButtonStatue(bool show)
        {
            if (!show)
            {
                IsAll = false;
                AllButton.Index = IsAll ? 3511 : 3510;
            }
            else if (IsGuild && IsHint && IsGroup && IsNormal && IsSystem && IsGlobal)
            {
                IsAll = true;
                AllButton.Index = IsAll ? 3511 : 3510;
            }
        }

        public void ResizeChat()
        {
            if (IsResizing)
                return;
            foreach (DXLabel dxLabel in History)
            {
                Size size = dxLabel.Size;
                int width1 = size.Width;
                size = TextBackgroundPanel.Size;
                int width2 = size.Width;
                if (width1 != width2)
                {
                    DXLabel label = dxLabel;
                    size = TextBackgroundPanel.Size;
                    int width3 = size.Width - 10;
                    Size height = DXLabel.GetHeight(label, width3);
                    dxLabel.Size = new Size(height.Width, height.Height);
                }
            }
            UpdateBackgrouds();
            UpdateItems();
            UpdateScrollBar();
        }

        private void UpdateBackgrouds()
        {
            Background.Size = new Size(380, BackgroudItemHeight * (TextBackgroundPanel.Size.Height % BackgroudItemHeight == 0 ? TextBackgroundPanel.Size.Height / BackgroudItemHeight : Convert.ToInt32(TextBackgroundPanel.Size.Height / BackgroudItemHeight) + 1));
        }

        public void UpdateItems()
        {
            int y = -ScrollBar.Value;
            foreach (DXLabel dxLabel in History)
            {
                dxLabel.Location = new Point(TextPanel.Location.X + 16, y);
                
                y += dxLabel.Size.Height + 2;
            }
        }

        public void UpdateScrollBar()
        {
            ScrollBar.VisibleSize = TextPanel.Size.Height;
            int num = 0;
            
            foreach (DXLabel dxLabel in History)
                num += dxLabel.Size.Height + 2;
            ScrollBar.MaxValue = num;
        }

        public void ReceiveChat(string message, MessageType type)
        {
            switch ((int)type)
            {
                case 0:
                    if (!IsNormal && !IsAll) return;
                    break;
                case 2:
                case 4:
                    if (!IsNormal && !IsGroup && !IsHint && !IsSystem && !IsGlobal && !IsGuild && !IsAll) return;
                    break;
                case 5:
                    if (!IsGroup && !IsAll) return;
                    break;
                case 1:
                case 6:
                    if (!IsGlobal && !IsAll) return;
                    break;
                case 7:
                    if (!IsHint && !IsAll) return;
                    break;
                case 8:
                case 10:
                    if (!IsSystem && !IsAll) return;
                    break;
                case 9:
                    if (!IsNormal && !IsGroup && !IsHint && !IsSystem && !IsGlobal && !IsGuild && !IsAll) return;
                    break;
                
                
                
                case 11:
                    if (!IsAll) return;
                    break;
                case 12:
                    if (!IsGuild && !IsAll) return;
                    break;
            }
            DXLabel dxLabel1 = new DXLabel();
            dxLabel1.AutoSize = false;
            dxLabel1.Text = message;
            dxLabel1.Outline = false;
            dxLabel1.DrawFormat = TextFormatFlags.WordBreak | TextFormatFlags.WordEllipsis;
            dxLabel1.Parent = TextPanel;
            DXLabel label = dxLabel1;
            label.MouseWheel += new EventHandler<MouseEventArgs>(this.ScrollBar.DoMouseWheel);
            label.Tag = (object)type;
            switch ((int)type)
            {
                case 0:
                case 1:
                case 2:
                case 4:
                case 5:
                case 6:
                case 9:
                case 11:
                case 12:
                    label.MouseUp += (EventHandler<MouseEventArgs>)((o, e) =>
                    {
                        string[] strArray = label.Text.Split(':', ' ');

                        if (strArray.Length == 0) return;
                        
                        GameScene.Game.ChatTextBox.StartPM(Regex.Replace(strArray[0], "[^A-Za-z0-9\u4e00-\u9fa5]", ""));
                    });
                    break;
            }
            UpdateColours(label);
            Size height = DXLabel.GetHeight(label, TextPanel.Size.Width - 40);
            label.Size = new Size(height.Width, height.Height);
            History.Add(label);
            while (History.Count > 250)
            {
                DXLabel dxLabel2 = History[0];
                History.Remove(dxLabel2);
                dxLabel2.Dispose();
            }
            bool flag = ScrollBar.Value >= ScrollBar.MaxValue - ScrollBar.VisibleSize;
            UpdateScrollBar();
            if (flag)
                ScrollBar.Value = ScrollBar.MaxValue - label.Size.Height;
            else
                UpdateItems();
        }
        
        public void ReceiveChat(string message, MessageType type, List<ClientUserItem> itemList)           
        {
            switch ((int)type)
            {
                case 0:
                    if (!IsNormal && !IsAll) return;
                    break;
                case 2:
                case 4:
                    if (!IsNormal && !IsGroup && !IsHint && !IsSystem && !IsGlobal && !IsGuild && !IsAll) return;
                    break;
                case 5:
                    if (!IsGroup && !IsAll) return;
                    break;
                case 1:
                case 6:
                    if (!IsGlobal && !IsAll) return;
                    break;
                case 7:
                    if (!IsHint && !IsAll) return;
                    break;
                case 8:
                case 10:
                    if (!IsSystem && !IsAll) return;
                    break;
                case 9:
                    if (!IsNormal && !IsGroup && !IsHint && !IsSystem && !IsGlobal && !IsGuild && !IsAll) return;
                    break;
                
                
                
                case 11:
                    if (!IsAll) return;
                    break;
                case 12:
                    if (!IsGuild && !IsAll) return;
                    break;
            }

            DXLabel MessageLabel = new DXLabel
            {
                Parent = TextPanel,
                Location = new Point(0, 0),
            };
            MessageLabel.BackColour = Color.Empty;
            MessageLabel.MouseWheel += ScrollBar.DoMouseWheel;
            MessageLabel.Tag = type;

            string[] MessageArray = message.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (MessageArray.Length > 1)
            {
                #region 消息名字
                string name = $"{MessageArray[0]}";
                DXLabel nameLabel = new DXLabel
                {
                    AutoSize = true,
                    Outline = true,
                    DrawFormat = TextFormatFlags.WordBreak | TextFormatFlags.WordEllipsis,
                    Parent = MessageLabel,
                    Location = new Point(0, 0),
                    Text = name,
                    Tag = type,
                    
                };
                nameLabel.MouseWheel += ScrollBar.DoMouseWheel;
                DrawItemUpdateColours(nameLabel);
                nameLabel.MouseUp += (o, e) =>
                {
                    string[] parts = nameLabel.Text.Split(':');
                    if (parts.Length == 0) return;
                    GameScene.Game.ChatTextBox.StartPM(Regex.Replace(parts[0], "[^A-Za-z0-9\u4e00-\u9fa5]", ""));
                };
                
                nameLabel.MouseEnter += (o, e) =>
                {
                    nameLabel.BackColour = Color.FromArgb(254, 143, 153);
                };
                
                nameLabel.MouseLeave += (o, e) =>
                {
                    nameLabel.BackColour = Color.Empty;
                };
                int x = nameLabel.Size.Width;
                #endregion

                if (MessageArray.Length > 1)
                {
                    string messageMain = MessageArray[1];
                    if (messageMain.Contains('{') && messageMain.Contains('}'))
                    {
                        string[] AllArray = messageMain.Split(new[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < AllArray.Length; i++)
                        {
                            if (AllArray[i].Contains('<') && AllArray[i].Contains('>'))
                            {
                                string[] itemArray = AllArray[i].Split(new[] { '<', '>' }, StringSplitOptions.RemoveEmptyEntries);

                                if (itemArray.Length > 1)
                                {
                                    ClientUserItem item = new ClientUserItem();
                                    item = itemList.Find(h => h.Index == int.Parse(itemArray[1]));

                                    DXLabel itemlabel = new DXLabel
                                    {
                                        AutoSize = true,
                                        DrawFormat = TextFormatFlags.WordBreak | TextFormatFlags.WordEllipsis,
                                        Parent = MessageLabel,
                                        Location = new Point(x, nameLabel.Location.Y),
                                        Tag = type,
                                    };

                                    itemlabel.Text = $"[{item.Info.ItemName}]";
                                    itemlabel.MouseWheel += ScrollBar.DoMouseWheel;

                                    if (type == MessageType.Shout || type == MessageType.Global)
                                    {
                                        itemlabel.ForeColour = Color.White;
                                    }
                                    else
                                    {
                                        if (item.Info.Rarity == Rarity.Common)
                                            itemlabel.ForeColour = Color.Lime;
                                        else if (item.Info.Rarity == Rarity.Superior)
                                            itemlabel.ForeColour = Color.Cyan;
                                        else if (item.Info.Rarity == Rarity.Elite)
                                            itemlabel.ForeColour = Color.Yellow;
                                    }

                                    itemlabel.MouseUp += (o, e) =>
                                    {
                                        itemlabel.BackColour = Color.FromArgb(254, 143, 153);
                                        GameScene.Game.MouseItem = item;
                                    };

                                    itemlabel.MouseLeave += (o, e) =>
                                    {
                                        itemlabel.BackColour = Color.Empty;
                                        GameScene.Game.MouseItem = null;
                                    };
                                    x += itemlabel.Size.Width;
                                }
                            }
                            else
                            {
                                DXLabel strlabel = new DXLabel
                                {
                                    AutoSize = true,
                                    DrawFormat = TextFormatFlags.WordBreak | TextFormatFlags.WordEllipsis,
                                    Parent = MessageLabel,
                                    Location = new Point(x, nameLabel.Location.Y),
                                    Text = $"{AllArray[i]}",
                                    Tag = type,

                                };
                                x += strlabel.Size.Width;
                                strlabel.MouseWheel += ScrollBar.DoMouseWheel;
                                DrawItemUpdateColours(strlabel);
                            }
                        }
                    }
                    else
                    {
                        DXLabel strlabel = new DXLabel
                        {
                            AutoSize = true,
                            DrawFormat = TextFormatFlags.WordBreak | TextFormatFlags.WordEllipsis,
                            Parent = MessageLabel,
                            Location = new Point(x, nameLabel.Location.Y),
                            Text = $"{messageMain}",
                            Tag = type,

                        };
                        x += strlabel.Size.Width;
                        strlabel.MouseWheel += ScrollBar.DoMouseWheel;
                        DrawItemUpdateColours(strlabel);
                    }
                }
                MessageLabel.Size = new Size(x, nameLabel.Size.Height);
            }
            else
            {
                DXLabel strlabel = new DXLabel
                {
                    AutoSize = true,
                    DrawFormat = TextFormatFlags.WordBreak | TextFormatFlags.WordEllipsis,
                    Parent = TextPanel,
                    Location = new Point(0, 0),
                    Text = $"{message}",
                    Tag = type,

                };
                strlabel.MouseWheel += ScrollBar.DoMouseWheel;
                History.Add(strlabel);
                DrawItemUpdateColours(strlabel);
            }

            History.Add(MessageLabel);

            DrawItemUpdateColours(MessageLabel);


            while (History.Count > 250)
            {
                DXLabel oldLabel = History[0];
                History.Remove(oldLabel);
                oldLabel.Dispose();
            }

            bool update = ScrollBar.Value >= ScrollBar.MaxValue - ScrollBar.VisibleSize;

            UpdateScrollBar();

            if (update)
            {
                ScrollBar.Value = ScrollBar.MaxValue - MessageLabel.Size.Height;
            }
            else UpdateItems();
        }
        public void ReceiveChat(MessageAction action, params object[] args)
        {
            if (action != (MessageAction)1)
                return;



            DXLabel dxLabel1 = new DXLabel();
            dxLabel1.AutoSize = false;
            dxLabel1.Text = "您已经死了，点击这里在市内复活。";
            dxLabel1.Outline = false;
            dxLabel1.DrawFormat = TextFormatFlags.WordBreak | TextFormatFlags.WordEllipsis;
            dxLabel1.Parent = TextPanel;
            DXLabel label = dxLabel1;

            if (!GameScene.Game.Observer)
            {
                DXMessageBox messageBox = new DXMessageBox($"你死了, 点击确定在城里复活.", "复活确认", DXMessageBoxButtons.YesNo);
                messageBox.YesButton.MouseClick += (o, e) => CEnvir.Enqueue(new TownRevive());
            }

            label.MouseClick += (EventHandler<MouseEventArgs>)((o, e) =>
            {
                CEnvir.Enqueue((Packet)new TownRevive());
                label.Dispose();
            });
            label.MouseWheel += new EventHandler<MouseEventArgs>(ScrollBar.DoMouseWheel);
            label.Disposing += (EventHandler)((o, e) =>
            {
                if (IsDisposed)
                    return;
                History.Remove(label);
                UpdateScrollBar();
                ScrollBar.Value = ScrollBar.MaxValue - label.Size.Height;
            });
            label.Tag = (object)(MessageType)9;
            UpdateColours(label);
            Size height = DXLabel.GetHeight(label, TextPanel.Size.Width - 40);
            label.Size = new Size(height.Width, height.Height);
            History.Add(label);
            while (History.Count > 250)
            {
                DXLabel dxLabel2 = History[0];
                History.Remove(dxLabel2);
                dxLabel2.Dispose();
            }
            bool flag = ScrollBar.Value >= ScrollBar.MaxValue - ScrollBar.VisibleSize;
            UpdateScrollBar();
            if (flag)
                ScrollBar.Value = ScrollBar.MaxValue - label.Size.Height;
            else
                UpdateItems();
        }

        public void UpdateColours()
        {
            foreach (DXLabel label in History)
                UpdateColours(label);
        }

        private void UpdateColours(DXLabel label)
        {
            Color empty = Color.Empty;
            switch ((int)(MessageType)label.Tag)
            {
                case 0:
                    label.BackColour = empty;
                    label.ForeColour = Config.LocalTextColour;
                    break;
                case 1:
                    label.BackColour = Color.FromArgb(255, 255, 0);
                    label.ForeColour = Config.ShoutTextColour;
                    break;
                case 2:
                    label.BackColour = empty;
                    label.ForeColour = Config.WhisperInTextColour;
                    break;
                case 3:
                    label.BackColour = empty;
                    label.ForeColour = Config.GMWhisperInTextColour;
                    break;
                case 4:
                    label.BackColour = empty;
                    label.ForeColour = Config.WhisperOutTextColour;
                    break;
                case 5:
                    label.BackColour = empty;
                    label.ForeColour = Color.Plum;
                    break;
                case 6:
                    label.BackColour = Color.FromArgb(0, 250, 0);
                    label.ForeColour = Config.GlobalTextColour;
                    break;
                case 7:
                    label.BackColour = empty;
                    label.ForeColour = Config.HintTextColour;
                    break;
                case 8:
                    label.BackColour = Color.FromArgb((int)byte.MaxValue, 0, 0);
                    label.ForeColour = Config.SystemTextColour;
                    break;
                case 9:
                    label.BackColour = Color.FromArgb(200, 148, 150, (int)byte.MaxValue);
                    label.ForeColour = Config.AnnouncementTextColour;
                    break;
                case 10:
                    label.BackColour = Color.FromArgb(200, (int)byte.MaxValue, 130, 0); ;
                    label.ForeColour = Config.GainsTextColour;
                    break;
                case 11:
                    label.BackColour = empty;
                    label.ForeColour = Config.ObserverTextColour;
                    break;
                case 12:
                    label.BackColour = empty;
                    label.ForeColour = Config.GuildTextColour;
                    break;
                case 16:
                    label.BackColour = Color.Blue;
                    label.ForeColour = Color.White;
                    break;
                case 17:
                    label.BackColour = Color.Magenta;
                    label.ForeColour = Color.White;
                    break;
            }
        }
        private void DrawItemUpdateColours(DXLabel label)
        {
            Color empty = Color.Empty;
            switch ((int)(MessageType)label.Tag)
            {
                case 0:
                    label.BackColour = empty;
                    label.ForeColour = Config.LocalTextColour;
                    break;
                case 1:
                    label.BackColour = Color.FromArgb(255, 255, 0);
                    label.ForeColour = Color.FromArgb(224, 57, 202);
                    break;
                case 2:
                    label.BackColour = empty;
                    label.ForeColour = Config.WhisperInTextColour;
                    break;
                case 3:
                    label.BackColour = empty;
                    label.ForeColour = Config.GMWhisperInTextColour;
                    break;
                case 4:
                    label.BackColour = empty;
                    label.ForeColour = Config.WhisperOutTextColour;
                    break;
                case 5:
                    label.BackColour = empty;
                    label.ForeColour = Color.Plum;
                    break;
                case 6:
                    label.BackColour = Color.FromArgb(0, 250, 0);
                    label.ForeColour = Color.FromArgb(30, 43, 255);
                    break;
                case 7:
                    label.BackColour = empty;
                    label.ForeColour = Config.HintTextColour;
                    break;
                case 8:
                    label.BackColour = Color.FromArgb((int)byte.MaxValue, 0, 0);
                    label.ForeColour = Config.SystemTextColour;
                    break;
                case 9:
                    label.BackColour = Color.FromArgb(200, 148, 150, (int)byte.MaxValue);
                    label.ForeColour = Config.AnnouncementTextColour;
                    break;
                case 10:
                    label.BackColour = Color.FromArgb(200, (int)byte.MaxValue, 130, 0); ;
                    label.ForeColour = Config.GainsTextColour;
                    break;
                case 11:
                    label.BackColour = empty;
                    label.ForeColour = Config.ObserverTextColour;
                    break;
                case 12:
                    label.BackColour = empty;
                    label.ForeColour = Config.GuildTextColour;
                    break;
                case 16:
                    label.BackColour = Color.Blue;
                    label.ForeColour = Color.White;
                    break;
                case 17:
                    label.BackColour = Color.Magenta;
                    label.ForeColour = Color.White;
                    break;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing)
                return;
            if (TextBackgroundPanel != null)
            {
                if (!TextBackgroundPanel.IsDisposed)
                    TextBackgroundPanel.Dispose();
                TextBackgroundPanel = (DXControl)null;
            }
            if (TextPanel != null)
            {
                if (!TextPanel.IsDisposed)
                    TextPanel.Dispose();
                TextPanel = (DXControl)null;
            }
            if (TabPanel != null)
            {
                if (!TabPanel.IsDisposed)
                    TabPanel.Dispose();
                TabPanel = (DXImageControl)null;
            }
            if (ScrollBar != null)
            {
                if (!ScrollBar.IsDisposed)
                    ScrollBar.Dispose();
                ScrollBar = (DXMirScrollBar)null;
            }
            if (History != null)
            {
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
            if (AllButton != null)
            {
                if (!AllButton.IsDisposed)
                    AllButton.Dispose();
                AllButton = (DXButton)null;
            }
            if (NormalButton != null)
            {
                if (!NormalButton.IsDisposed)
                    NormalButton.Dispose();
                NormalButton = (DXButton)null;
            }
            if (GroupButton != null)
            {
                if (!GroupButton.IsDisposed)
                    GroupButton.Dispose();
                GroupButton = (DXButton)null;
            }
            if (SystemButton != null)
            {
                if (!SystemButton.IsDisposed)
                    SystemButton.Dispose();
                SystemButton = (DXButton)null;
            }
            if (GuildButton != null)
            {
                if (!GuildButton.IsDisposed)
                    GuildButton.Dispose();
                GuildButton = (DXButton)null;
            }
            if (GlobalButton != null)
            {
                if (!GlobalButton.IsDisposed)
                    GlobalButton.Dispose();
                GlobalButton = (DXButton)null;
            }
            
            
            
            
            
            
            if (HintButton != null)
            {
                if (!HintButton.IsDisposed)
                    HintButton.Dispose();
                HintButton = (DXButton)null;
            }
            if (CloseBtn != null)
            {
                if (!CloseBtn.IsDisposed)
                    CloseBtn.Dispose();
                CloseBtn = (DXButton)null;
            }
            if (TextBoxPanel != null)
            {
                if (!TextBoxPanel.IsDisposed)
                    TextBoxPanel.Dispose();
                TextBoxPanel = (DXImageControl)null;
            }
        }
    }
}
