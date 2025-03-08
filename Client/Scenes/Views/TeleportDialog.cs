using Client.Controls;
using Client.Envir;
using Client.Models;
using Client.UserModels;
using Library;
using Library.SystemModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using C = Library.Network.ClientPackets;

namespace Client.Scenes.Views
{
    public sealed class TeleportDialog : DXWindow
    {
        public DXListBox ListBox;
        public MarketStoreRow[] StoreRows;
        public override WindowType Type => WindowType.None;
        public override bool CustomSize => false;
        public override bool AutomaticVisiblity => false;
        public DXImageControl Image;

        public MarketStoreRow SelectedStoreRow
        {
            get => _SelectedStoreRow;
            set
            {
                if (_SelectedStoreRow == value) return;

                MarketStoreRow oldValue = _SelectedStoreRow;
                _SelectedStoreRow = value;

                OnSelectedStoreRowChanged(oldValue, value);
            }
        }
        private MarketStoreRow _SelectedStoreRow;
        public event EventHandler<EventArgs> SelectedStoreRowChanged;
        public void OnSelectedStoreRowChanged(MarketStoreRow oValue, MarketStoreRow nValue)
        {
            if (oValue != null)
                oValue.Selected = false;

            if (nValue != null)
                nValue.Selected = true;

            
            

            if (nValue?.ComboItem == null)
            {
                
            }
            else
            {
            }


            SelectedStoreRowChanged?.Invoke(this, EventArgs.Empty);
        }

        public TeleportDialog()
        {
            TitleLabel.Text = "";
            
            
            HasTopBorder = false;
            
            
            
            
            

            SetClientSize(new Size(324, 320));

            StoreRows = new MarketStoreRow[CartoonGlobals.MaxTeleportCount];

            DXImageControl dxImageControl1 = new DXImageControl();
            dxImageControl1.LibraryFile = LibraryFile.GameInter;
            dxImageControl1.Index = 616;
            dxImageControl1.Location = new Point(3, 24);
            dxImageControl1.Parent = this;
            Image = dxImageControl1;

            for (int i = 0; i < CartoonGlobals.MaxTeleportCount; i++)
            {
                int index = i;
                StoreRows[index] = new MarketStoreRow
                {
                    Parent = this,
                    Location = new Point(5, 30 + i * 30),
                };
                StoreRows[index].Index = i;
                
            }


        }

        public void LoadItems(ClientTeleport port)
        {
            MapInfo map = CartoonGlobals.MapInfoList.Binding.FirstOrDefault(x => x.Index == port.MapId);

            if (map == null)
                return;

            StoreRows[port.Index].NameLabel.Text = map.Description;
            StoreRows[port.Index].PriceLabel.Text = $"{port.TelePos.X}, {port.TelePos.Y}";
            StoreRows[port.Index].BeizhuBoxTextLabel.Text = port.Beizhu;
        }

        private void OnSelectedChanged(object sender, EventArgs e)
        {
            if (!IsVisible)
                return;

            DXListBoxItem item = sender as DXListBoxItem;

            if (!item.Selected)
                return;

            

            

            
            
        }

        private void OnMouseWheel(object sender, MouseEventArgs e)
        {
        }
    }

    public sealed class MarketStoreRow : DXControl
    {
        public DXLabel NameLabel, PriceLabel, PriceLabelLabel, BeizhuBoxTextLabel;
        public DXButton BtnAdd, GotoButton, MapBeizhu;
        public DXTextBox BeizhuBoxLabel;

        public int Index;

        public bool Selected
        {
            get => _Selected;
            set
            {
                if (_Selected == value) return;

                bool oldValue = _Selected;
                _Selected = value;

                OnSelectedChanged(oldValue, value);
            }
        }
        private bool _Selected;
        
        public void OnSelectedChanged(bool oValue, bool nValue)
        {
            

            
        }

        public ItemInfo ComboItem
        {
            get => _ComboItem;
            set
            {
                if (_ComboItem == value) return;
                ItemInfo oldValue = _ComboItem;
                _ComboItem = value;
                OnStoreInfoChanged(oldValue, value);
            }
        }
        private ItemInfo _ComboItem;
        public event EventHandler<EventArgs> StoreInfoChanged;
        public void OnStoreInfoChanged(ItemInfo oValue, ItemInfo nValue)
        {
            Visible = ComboItem != null;
            if (ComboItem == null) return;


            NameLabel.Text = ComboItem.ItemName;

            

            StoreInfoChanged?.Invoke(this, EventArgs.Empty);
        }

        public MarketStoreRow()
        {
            Size = new Size(324, 32);

            DrawTexture = true;
            

            

            
            NameLabel = new DXLabel
            {
                Parent = this,
                Location = new Point(1, 3),
                Text = "尚未存储",
                DrawFormat = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter,
                IsControl = false,
                Visible = false,
            };

            PriceLabel = new DXLabel
            {
                Parent = this,
                Location = new Point(1, 3),
                DrawFormat = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter,
                Text = "坐标, 坐标",
                IsControl = false,
                Visible = false,
            };
            
            BeizhuBoxTextLabel = new DXLabel
            {
                Parent = this,
                Location = new Point(5, 3),
                Text = "尚未存储",
                IsControl = false,
                
            };

            /*
            MapBeizhu = new DXButton
            {
                Location = new Point(155, 3),
                Size = new Size(60, SmallButtonHeight),
                Parent = this,
                ButtonType = ButtonType.SmallButton,
                Label = { Text = "存储名" }
            };
            */

            MapBeizhu = new DXButton
            {
                Parent = this,
                LibraryFile = LibraryFile.GameInter,
                Index = 617,
                Hint = "存储名",
                Location = new Point(153, 3),
            };
            MapBeizhu.MouseClick += (o, e) =>
            {
                GameScene.Game.TeleportMemberBox.Visible = true;
                GameScene.Game.GuildMemberBox.BringToFront();
            };
            /*
            BtnAdd = new DXButton
            {
                Location = new Point(225, 3),
                Size = new Size(60, SmallButtonHeight),
                Parent = this,
                ButtonType = ButtonType.SmallButton,
                Label = { Text = "重定位" }
            };
            */
            BtnAdd = new DXButton
            {
                Parent = this,
                LibraryFile = LibraryFile.GameInter,
                Index = 618,
                Hint = "重定位",
                Location = new Point(213, 3),
            };
            BtnAdd.MouseClick += (o, e) =>
            {
                MapInfo info = GameScene.Game.MapControl.MapInfo;

                if (!info.AllowTulingfu)
                {
                    GameScene.Game.ReceiveChat("本地图是不能用土灵符保存的地图", MessageType.System);
                    return;
                }

                Point pos = MapObject.User.CurrentLocation;
                NameLabel.Text = info.Description;
                PriceLabel.Text = $"{pos.X}, {pos.Y}";
                BeizhuBoxTextLabel.Text = GameScene.Game.TeleportMemberBox.BeizhuBoxTextLabel.TextBox.Text;

                CEnvir.Enqueue(new C.UserTeleportChanged { Index = Index, Beizhu = BeizhuBoxTextLabel.Text, MapId = info.Index, TelePos = pos });
                
            };
            /*
            GotoButton = new DXButton
            {
                Location = new Point(295, 3),
                Size = new Size(40, SmallButtonHeight),
                Parent = this,
                ButtonType = ButtonType.SmallButton,
                Label = { Text = "传送" }
            };
            */
            GotoButton = new DXButton
            {
                Parent = this,
                LibraryFile = LibraryFile.GameInter,
                Index = 619,
                Hint = "传送",
                Location = new Point(273, 3),
            };

            GotoButton.MouseClick += (o, e) =>
            {
                if (CEnvir.Now < MapObject.User.CombatTime.AddSeconds(10) && !GameScene.Game.Observer)
                {
                    GameScene.Game.ReceiveChat($"在战斗中无法使用土灵符", MessageType.System);
                    return;
                }

                CEnvir.Enqueue(new C.UserTeleport { Index = Index });
            };

            
            
            
            
            
            
            

            

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                _Selected = false;
               

                _ComboItem = null;
                StoreInfoChanged = null;


                if (NameLabel != null)
                {
                    if (!NameLabel.IsDisposed)
                        NameLabel.Dispose();

                    NameLabel = null;
                }

                if (PriceLabel != null)
                {
                    if (!PriceLabel.IsDisposed)
                        PriceLabel.Dispose();

                    PriceLabel = null;
                }

                if (BeizhuBoxTextLabel != null)
                {
                    if (!BeizhuBoxTextLabel.IsDisposed)
                        BeizhuBoxTextLabel.Dispose();

                    BeizhuBoxTextLabel = null;
                }

                if (PriceLabelLabel != null)
                {
                    if (!PriceLabelLabel.IsDisposed)
                        PriceLabelLabel.Dispose();

                    PriceLabelLabel = null;
                }

            }

        }
    }

    public sealed class TeleportMemberDialog : DXWindow
    {
        #region Properties

        public DXTextBox BeizhuBoxTextLabel;

        public DXButton ConfirmButton;

        public override WindowType Type => WindowType.TeleportMemberBox;
        public override bool CustomSize => false;
        public override bool AutomaticVisiblity => false;

        #endregion

        public TeleportMemberDialog()
        {
            SetClientSize(new Size(200, 80));

            TitleLabel.Text = "地图存储名";


            DXLabel label = new DXLabel
            {
                Parent = this,
                Text = "名字:",
            };
            label.Location = new Point(ClientArea.X + 50 - label.Size.Width, label.Location.Y + 55);

            BeizhuBoxTextLabel = new DXTextBox
            {
                Parent = this,
                Location = new Point(ClientArea.X + 50, label.Location.Y),
                Size = new Size(120, 20),
                MaxLength = CartoonGlobals.MaxTeleportCount
            };

            ConfirmButton = new DXButton
            {
                Parent = this,
                Location = new Point(ClientArea.X + 60, 90),
                ButtonType = ButtonType.SmallButton,
                Size = new Size(80, SmallButtonHeight),
                Label = { Text = "确认" },
            };
            ConfirmButton.MouseClick += (o, e) =>
            {
                Visible = false;
            };
          

        }

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {

                if (BeizhuBoxTextLabel != null)
                {
                    if (!BeizhuBoxTextLabel.IsDisposed)
                        BeizhuBoxTextLabel.Dispose();

                    BeizhuBoxTextLabel = null;
                }

                if (ConfirmButton != null)
                {
                    if (!ConfirmButton.IsDisposed)
                        ConfirmButton.Dispose();

                    ConfirmButton = null;
                }
            }

        }

        #endregion
    }


}
