using Client.Controls;
using Client.Envir;
using Client.UserModels;
using Library;
using Library.Network;
using Library.Network.ClientPackets;
using Library.SystemModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Client.Scenes.Views
{
    public sealed class GroupDialog : DXWindow
    {
        public List<ClientPlayerInfo> Members = new List<ClientPlayerInfo>();
        public List<DXLabel> Labels = new List<DXLabel>();
        public DXButton AllowGroupButton;
        public DXButton AddButton;
        public DXButton RemoveButton;
        public DXCheckBox ShowPartyList;
        private bool _AllowGroup;
        public DXTab MemberTab;
        private DXLabel _SelectedLabel;

        public bool AllowGroup
        {
            get
            {
                return _AllowGroup;
            }
            set
            {
                if (_AllowGroup == value)
                    return;
                bool allowGroup = _AllowGroup;
                _AllowGroup = value;
                OnAllowGroupChanged(allowGroup, value);
            }
        }

        public event EventHandler<EventArgs> AllowGroupChanged;

        public void OnAllowGroupChanged(bool oValue, bool nValue)
        {
            
            EventHandler<EventArgs> allowGroupChanged = AllowGroupChanged;
            if (allowGroupChanged != null)
                allowGroupChanged((object)this, EventArgs.Empty);
            if (AllowGroup)
            {
                AllowGroupButton.Index = 122;
                AllowGroupButton.Hint = "组队状态: 允许";
            }
            else
            {
                AllowGroupButton.Index = 142;
                AllowGroupButton.Hint = "组队状态: 拒绝";
            }
        }

        public DXLabel SelectedLabel
        {
            get
            {
                return _SelectedLabel;
            }
            set
            {
                if (_SelectedLabel == value)
                    return;
                DXLabel selectedLabel = _SelectedLabel;
                _SelectedLabel = value;
                OnSelectedLabelChanged(selectedLabel, value);
            }
        }

        public event EventHandler<EventArgs> SelectedLabelChanged;

        public void OnSelectedLabelChanged(DXLabel oValue, DXLabel nValue)
        {
            if (oValue != null)
            {
                oValue.ForeColour = Color.FromArgb(198, 166, 99);
                oValue.BackColour = Color.Empty;
            }
            if (nValue != null)
            {
                nValue.ForeColour = Color.White;
                nValue.BackColour = Color.FromArgb(24, 16, 16);
            }
            RemoveButton.Enabled = nValue != null && (int)Members[0].ObjectID == (int)GameScene.Game.User.ObjectID;
            
            EventHandler<EventArgs> selectedLabelChanged = SelectedLabelChanged;
            if (selectedLabelChanged == null)
                return;
            selectedLabelChanged((object)this, EventArgs.Empty);
        }

        public override WindowType Type
        {
            get
            {
                return WindowType.GroupBox;
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
                return true;
            }
        }

        public GroupDialog()
        {
            TitleLabel.Text = "组队";
            HasFooter = true;
            SetClientSize(new Size(200, 200));
            DXButton dxButton1 = new DXButton();
            dxButton1.LibraryFile = LibraryFile.GameInter2;
            dxButton1.Index = 142;
            dxButton1.Parent = (DXControl)this;
            dxButton1.Hint = "组队状态:拒绝";
            dxButton1.Location = new Point(ClientArea.X, Size.Height - 46);
            AllowGroupButton = dxButton1;
            AllowGroupButton.MouseClick += (EventHandler<MouseEventArgs>)((o, e) =>
            {
                if (GameScene.Game.Observer)
                    return;
                CEnvir.Enqueue((Packet)new GroupSwitch()
                {
                    Allow = !AllowGroup
                });
            });
            DXTabControl dxTabControl1 = new DXTabControl();
            dxTabControl1.Parent = (DXControl)this;
            dxTabControl1.Size = ClientArea.Size;
            dxTabControl1.Location = ClientArea.Location;
            DXTabControl dxTabControl2 = dxTabControl1;
            DXTab dxTab = new DXTab();
            dxTab.TabButton.Label.Text = "队员";
            dxTab.TabButton.IsControl = false;
            dxTab.Parent = (DXControl)dxTabControl2;
            dxTab.Border = true;
            MemberTab = dxTab;
            DXCheckBox dxCheckBox = new DXCheckBox();
            dxCheckBox.Label.Text = "组队界面";
            dxCheckBox.Parent = (DXControl)this;
            dxCheckBox.Visible = true;
            ShowPartyList = dxCheckBox;
            ShowPartyList.Location = new Point(ClientArea.Right - 80, 36);
            ShowPartyList.CheckedChanged += (EventHandler<EventArgs>)((o, e) =>
            {
                
                Config.是否显示组队界面 = ShowPartyList.Checked;
                GameScene.Game.PartyListBox.PopulateMembers();
            });
            DXButton dxButton2 = new DXButton();
            dxButton2.Size = new Size(60, DXControl.SmallButtonHeight);
            dxButton2.ButtonType = ButtonType.SmallButton;
            dxButton2.Label.Text = "邀请";
            dxButton2.Location = new Point(ClientArea.Right - 135, Size.Height - 40);
            dxButton2.Parent = (DXControl)this;
            AddButton = dxButton2;
            AddButton.MouseClick += (EventHandler<MouseEventArgs>)((o, e) =>
            {
                if (GameScene.Game.Observer)
                    return;
                if (Members.Count >= 15)
                    GameScene.Game.ReceiveChat("组队人数已达到上限", MessageType.System);
                else if (Members.Count >= 15)
                {
                    GameScene.Game.ReceiveChat("你不是队长，无权限操作。", MessageType.System);
                }
                else
                {
                    DXInputWindow window = new DXInputWindow("请输入你要邀请组队的玩家名字。", "邀请组队") { ConfirmButton = { Enabled = false }, Modal = true };
                    window.ValueTextBox.TextBox.TextChanged += (EventHandler)((o1, e1) => window.ConfirmButton.Enabled = CartoonGlobals.CharacterReg.IsMatch(window.ValueTextBox.TextBox.Text));
                    window.ConfirmButton.MouseClick += (EventHandler<MouseEventArgs>)((o1, e1) => CEnvir.Enqueue((Packet)new GroupInvite()
                    {
                        Name = window.Value
                    }));
                }
            });
            DXButton dxButton3 = new DXButton();
            dxButton3.Size = new Size(60, DXControl.SmallButtonHeight);
            dxButton3.ButtonType = ButtonType.SmallButton;
            dxButton3.Label.Text = "移除";
            dxButton3.Location = new Point(ClientArea.Right - 65, Size.Height - 40);
            dxButton3.Parent = (DXControl)this;
            dxButton3.Enabled = false;
            RemoveButton = dxButton3;
            RemoveButton.MouseClick += (EventHandler<MouseEventArgs>)((o, e) =>
            {
                if (GameScene.Game.Observer)
                    return;
                CEnvir.Enqueue((Packet)new GroupRemove()
                {
                    Name = SelectedLabel.Text
                });
            });
        }

        public void UpdateMembers()
        {
            SelectedLabel = (DXLabel)null;
            foreach (DXControl label in Labels)
                label.Dispose();
            Labels.Clear();
            for (int index = 0; index < Members.Count; ++index)
            {
                ClientPlayerInfo member = Members[index];
                DXLabel dxLabel = new DXLabel();
                dxLabel.Parent = (DXControl)MemberTab;
                dxLabel.Location = new Point(10 + 100 * (index % 2), 10 + 20 * (index / 2));
                dxLabel.Text = member.Name;
                DXLabel label = dxLabel;
                label.MouseClick += (EventHandler<MouseEventArgs>)((o, e) =>
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        SelectedLabel = label;
                    }
                    else
                    {
                        if (e.Button != MouseButtons.Right)
                            return;
                        GameScene.Game.BigMapBox.Visible = true;
                        GameScene.Game.BigMapBox.Opacity = 1f;
                        ClientObjectData data;
                        if (!GameScene.Game.DataDictionary.TryGetValue(member.ObjectID, out data))
                            return;
                        GameScene.Game.BigMapBox.SelectedInfo = CartoonGlobals.MapInfoList.Binding.FirstOrDefault<MapInfo>((Func<MapInfo, bool>)(x => x.Index == data.MapIndex));
                    }
                });
                Labels.Add(label);
            }
            AddButton.Enabled = Members.Count == 0 || (int)Members[0].ObjectID == (int)GameScene.Game.User.ObjectID;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing)
                return;
            _AllowGroup = false;
            
            AllowGroupChanged = (EventHandler<EventArgs>)null;
            if (AllowGroupButton != null)
            {
                if (!AllowGroupButton.IsDisposed)
                    AllowGroupButton.Dispose();
                AllowGroupButton = (DXButton)null;
            }
            if (AddButton != null)
            {
                if (!AddButton.IsDisposed)
                    AddButton.Dispose();
                AddButton = (DXButton)null;
            }
            if (RemoveButton != null)
            {
                if (!RemoveButton.IsDisposed)
                    RemoveButton.Dispose();
                RemoveButton = (DXButton)null;
            }
            if (MemberTab != null)
            {
                if (!MemberTab.IsDisposed)
                    MemberTab.Dispose();
                MemberTab = (DXTab)null;
            }
            for (int index = 0; index < Labels.Count; ++index)
            {
                if (Labels[index] != null)
                {
                    if (!Labels[index].IsDisposed)
                        Labels[index].Dispose();
                    Labels[index] = (DXLabel)null;
                }
            }
            Labels.Clear();
            Labels = (List<DXLabel>)null;
            if (_SelectedLabel != null)
            {
                if (!_SelectedLabel.IsDisposed)
                    _SelectedLabel.Dispose();
                _SelectedLabel = (DXLabel)null;
            }
            
            SelectedLabelChanged = (EventHandler<EventArgs>)null;
            Members.Clear();
            Members = (List<ClientPlayerInfo>)null;
        }
    }
}
