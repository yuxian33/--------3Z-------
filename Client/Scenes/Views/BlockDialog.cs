using System.Collections.Generic;
using System.Drawing;
using Client.Controls;
using Client.Envir;
using Client.UserModels;
using Library;
using C = Library.Network.ClientPackets;


namespace Client.Scenes.Views
{

    public sealed class BlockDialog : DXWindow
    {
        #region Propetries
        private DXListBox ListBox;
        public List<DXListBoxItem> ListBoxItems = new List<DXListBoxItem>();

        public override WindowType Type => WindowType.BlockBox;
        public override bool CustomSize => false;
        public override bool AutomaticVisiblity => true;

        #endregion

        public BlockDialog()
        {
            TitleLabel.Text = "黑名单";

            HasFooter = false;

            SetClientSize(new Size(200, 200));

            ListBox = new DXListBox
            {
                Parent = this,
                Location = ClientArea.Location,
                Size = new Size(ClientArea.Width, ClientArea.Height - 25)
            };

            DXButton addButton = new DXButton
            {
                Label = { Text = "增加" },
                Parent = this,
                Location = new Point(ClientArea.X, ClientArea.Bottom - 20),
                Size = new Size(80, SmallButtonHeight),
                ButtonType = ButtonType.SmallButton,
            };
            addButton.MouseClick += (o, e) =>
            {
                DXInputWindow window = new DXInputWindow("请输入你要添加黑名单的玩家名字.", "添加黑名单")
                {
                    ConfirmButton = { Enabled = false },
                    Modal = true
                };
                window.ValueTextBox.TextBox.TextChanged += (o1, e1) =>
                {
                    window.ConfirmButton.Enabled = CartoonGlobals.CharacterReg.IsMatch(window.ValueTextBox.TextBox.Text);
                };
                window.ConfirmButton.MouseClick += (o1, e1) =>
                {
                    CEnvir.Enqueue(new C.BlockAdd { Name = window.Value });
                };
            };

            DXButton removeButton = new DXButton
            {
                Label = { Text = "移除" },
                Parent = this,
                Location = new Point(ClientArea.Right - 80, ClientArea.Bottom - 20),
                Size = new Size(80, SmallButtonHeight),
                ButtonType = ButtonType.SmallButton,
                Enabled = false,
            };
            removeButton.MouseClick += (o, e) =>
            {
                if (ListBox.SelectedItem == null) return;

                DXMessageBox box = new DXMessageBox($"你确定要取消吗 {ListBox.SelectedItem.Label.Text}?", "取消阻止玩家", DXMessageBoxButtons.YesNo);

                box.YesButton.MouseClick += (o1, e1) =>
                {
                    CEnvir.Enqueue(new C.BlockRemove { Index = (int)ListBox.SelectedItem.Item });
                };

            };

            ListBox.selectedItemChanged += (o, e) =>
            {
                removeButton.Enabled = ListBox.SelectedItem != null;
            };

            RefreshList();
        }

        #region Methods
        public void RefreshList()
        {
            ListBox.SelectedItem = null;

            foreach (DXListBoxItem item in ListBoxItems)
                item.Dispose();

            ListBoxItems.Clear();

            foreach (ClientBlockInfo info in CEnvir.BlockList)
            {
                ListBoxItems.Add(new DXListBoxItem
                {
                    Parent = ListBox,
                    Label = { Text = info.Name },
                    Item = info.Index
                });
            }
        }
        #endregion

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                if (ListBoxItems != null)
                {
                    for (int i = 0; i < ListBoxItems.Count; i++)
                    {
                        if (ListBoxItems[i] != null)
                        {
                            if (!ListBoxItems[i].IsDisposed)
                                ListBoxItems[i].Dispose();

                            ListBoxItems[i] = null;
                        }
                    }

                    ListBoxItems.Clear();
                    ListBoxItems = null;
                }

                if (ListBox != null)
                {
                    if (!ListBox.IsDisposed)
                        ListBox.Dispose();

                    ListBox = null;
                }

            }

        }

        #endregion
    }

    /*
    public sealed class BlockDialog : DXWindow
    {
        #region Propetries
        private DXTabControl SupportTabControl;
        private DXTab FriendTab, BlockTab;

        private DXListBox FriendListBox;
        private DXListBox BlockListBox;

        public List<DXListBoxItem> FriendListBoxItems = new List<DXListBoxItem>();
        public List<DXListBoxItem> BlockListBoxItems = new List<DXListBoxItem>();

        public override WindowType Type => WindowType.BlockBox;
        public override bool CustomSize => false;
        public override bool AutomaticVisiblity => true;

        #endregion

        public BlockDialog()
        {
            TitleLabel.Text = "好友管理";
            HasFooter = false;
            SetClientSize(new Size(250, 300));

            SupportTabControl = new DXTabControl
            {
                Parent = this,
                Location = ClientArea.Location,
                Size = ClientArea.Size,
            };

            FriendTab = new DXTab
            {
                Parent = SupportTabControl,
                Border = true,
                TabButton = { Label = { Text = "好友名单" } },
            };

            BlockTab = new DXTab
            {
                Parent = SupportTabControl,
                Border = true,
                TabButton = { Label = { Text = "黑名单" } },
            };

            SupportTabControl.SelectedTab = FriendTab;

            FriendListBox = new DXListBox
            {
                Parent = FriendTab,
                Location = new Point(ClientArea.X, ClientArea.Y - 27),
                Size = new Size(ClientArea.Width - 17, ClientArea.Height - 80)
            };

            DXButton addFriendButton = new DXButton
            {
                Label = { Text = "添加" },
                Parent = FriendTab,
                Location = new Point(ClientArea.X, ClientArea.Y + 208),
                Size = new Size(80, SmallButtonHeight),
                ButtonType = ButtonType.SmallButton,
            };
            addFriendButton.MouseClick += (o, e) =>
            {
                DXInputWindow window = new DXInputWindow("输入你想添加好友的玩家名字。", "确认添加")
                {
                    ConfirmButton = { Enabled = false },
                    Modal = true
                };
                window.ValueTextBox.TextBox.TextChanged += (o1, e1) =>
                {
                    window.ConfirmButton.Enabled = CartoonGlobals.CharacterReg.IsMatch(window.ValueTextBox.TextBox.Text);
                };
                window.ConfirmButton.MouseClick += (o1, e1) =>
                {
                    CEnvir.Enqueue(new C.BlockAdd { Name = window.Value }); 
                };
            };

            DXButton removeFriendButton = new DXButton
            {
                Label = { Text = "移除" },
                Parent = FriendTab,
                Location = new Point(ClientArea.Right - 98, ClientArea.Y + 208),
                Size = new Size(80, SmallButtonHeight),
                ButtonType = ButtonType.SmallButton,
                Enabled = false,
            };
            removeFriendButton.MouseClick += (o, e) =>
            {
                if (FriendListBox.SelectedItem == null) return;

                DXMessageBox box = new DXMessageBox($"确定删除好友 { FriendListBox.SelectedItem.Label.Text}吗 ? ", "移出", DXMessageBoxButtons.YesNo);

                box.YesButton.MouseClick += (o1, e1) =>
                {
                    CEnvir.Enqueue(new C.BlockRemove { Index = (int)FriendListBox.SelectedItem.Item }); 
                };

            };

            FriendListBox.selectedItemChanged += (o, e) =>
            {
                removeFriendButton.Enabled = FriendListBox.SelectedItem != null;
            };

            BlockListBox = new DXListBox
            {
                Parent = BlockTab,
                Location = new Point(ClientArea.X, ClientArea.Y - 27),
                Size = new Size(ClientArea.Width - 17, ClientArea.Height - 80)
            };

            DXButton addBlockButton = new DXButton
            {
                Label = { Text = "添加" },
                Parent = BlockTab,
                Location = new Point(ClientArea.X, ClientArea.Y + 208),
                Size = new Size(80, SmallButtonHeight),
                ButtonType = ButtonType.SmallButton,
            };
            addBlockButton.MouseClick += (o, e) =>
            {
                DXInputWindow window = new DXInputWindow("输入你想添加进黑名单的玩家名字。", "确认添加")
                {
                    ConfirmButton = { Enabled = false },
                    Modal = true
                };
                window.ValueTextBox.TextBox.TextChanged += (o1, e1) =>
                {
                    window.ConfirmButton.Enabled = CartoonGlobals.CharacterReg.IsMatch(window.ValueTextBox.TextBox.Text);
                };
                window.ConfirmButton.MouseClick += (o1, e1) =>
                {
                    CEnvir.Enqueue(new C.BlockAdd { Name = window.Value });
                };
            };

            DXButton removeBlockButton = new DXButton
            {
                Label = { Text = "移除" },
                Parent = BlockTab,
                Location = new Point(ClientArea.Right - 98, ClientArea.Y + 208),
                Size = new Size(80, SmallButtonHeight),
                ButtonType = ButtonType.SmallButton,
                Enabled = false,
            };
            removeBlockButton.MouseClick += (o, e) =>
            {
                if (BlockListBox.SelectedItem == null) return;

                DXMessageBox box = new DXMessageBox($"你确定要将玩家 { BlockListBox.SelectedItem.Label.Text}移出黑名单 ? ", "移出", DXMessageBoxButtons.YesNo);

                box.YesButton.MouseClick += (o1, e1) =>
                {
                    CEnvir.Enqueue(new C.BlockRemove { Index = (int)BlockListBox.SelectedItem.Item });
                };

            };

            BlockListBox.selectedItemChanged += (o, e) =>
            {
                removeBlockButton.Enabled = BlockListBox.SelectedItem != null;
            };

            
        }

        #region Methods
        public void RefreshList()
        {
            BlockListBox.SelectedItem = null;

            foreach (DXListBoxItem item in BlockListBoxItems)
                item.Dispose();

            BlockListBoxItems.Clear();

            foreach (ClientBlockInfo info in CEnvir.BlockList)
            {
                BlockListBoxItems.Add(new DXListBoxItem
                {
                    Parent = BlockListBox,
                    Label = { Text = info.Name },
                    Item = info.Index
                });
            }
        }
        #endregion

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                if (FriendListBoxItems != null)
                {
                    for (int i = 0; i < FriendListBoxItems.Count; i++)
                    {
                        if (FriendListBoxItems[i] != null)
                        {
                            if (!FriendListBoxItems[i].IsDisposed)
                                FriendListBoxItems[i].Dispose();

                            FriendListBoxItems[i] = null;
                        }
                    }

                    FriendListBoxItems.Clear();
                    FriendListBoxItems = null;
                }

                if (FriendListBox != null)
                {
                    if (!FriendListBox.IsDisposed)
                        FriendListBox.Dispose();

                    FriendListBox = null;
                }

                if (BlockListBoxItems != null)
                {
                    for (int i = 0; i < BlockListBoxItems.Count; i++)
                    {
                        if (BlockListBoxItems[i] != null)
                        {
                            if (!BlockListBoxItems[i].IsDisposed)
                                BlockListBoxItems[i].Dispose();

                            BlockListBoxItems[i] = null;
                        }
                    }

                    BlockListBoxItems.Clear();
                    BlockListBoxItems = null;
                }

                if (BlockListBox != null)
                {
                    if (!BlockListBox.IsDisposed)
                        BlockListBox.Dispose();

                    BlockListBox = null;
                }

            }

        }

        #endregion
    }
    */
}
