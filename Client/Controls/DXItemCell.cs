using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Client.Envir;
using Client.Models;
using Client.Scenes;
using Client.Scenes.Views;
using Client.UserModels;
using Library;
using Library.SystemModels;
using SlimDX;
using static Client.Scenes.Views.BigPatchDialog;
using C = Library.Network.ClientPackets;


namespace Client.Controls
{
    public sealed class DXItemCell : DXControl
    {
        #region Static
        public static DXItemCell SelectedCell
        {
            get => GameScene.Game.SelectedCell;
            set => GameScene.Game.SelectedCell = value;
        }
        public static int CellWidth = 36;
        public static int CellHeight = 36;

        public DXAnimatedControl ItemSpecialEffect;

        #endregion
        #region Properties

        #region FixedBorder
        public bool FixedBorder
        {
            get => _FixedBorder;
            set
            {
                if (_FixedBorder == value) return;
                bool oldValue = _FixedBorder;
                _FixedBorder = value;
                OnFixedBorderChanged(oldValue, value);
            }
        }
        private bool _FixedBorder;
        public event EventHandler<EventArgs> FixedBorderChanged;
        public void OnFixedBorderChanged(bool oValue, bool nValue)
        {
            FixedBorderChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion
        #region FixedBorderColour
        public bool FixedBorderColour
        {
            get => _FixedBorderColour;
            set
            {
                if (_FixedBorderColour == value) return;
                bool oldValue = _FixedBorderColour;
                _FixedBorderColour = value;
                OnFixedBorderColourChanged(oldValue, value);
            }
        }
        private bool _FixedBorderColour;
        public event EventHandler<EventArgs> FixedBorderColourChanged;
        public void OnFixedBorderColourChanged(bool oValue, bool nValue)
        {
            FixedBorderColourChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region GridType
        public GridType GridType
        {
            get => _GridType;
            set
            {
                if (_GridType == value) return;
                GridType oldValue = _GridType;
                _GridType = value;
                OnGridTypeChanged(oldValue, value);
            }
        }
        private GridType _GridType;
        public event EventHandler<EventArgs> GridTypeChanged;
        public void OnGridTypeChanged(GridType oValue, GridType nValue)
        {
            GridTypeChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion
        #region HostGrid
        public DXItemGrid HostGrid
        {
            get => _HostGrid;
            set
            {
                if (_HostGrid == value) return;
                DXItemGrid oldValue = _HostGrid;
                _HostGrid = value;
                OnHostGridChanged(oldValue, value);
            }
        }
        private DXItemGrid _HostGrid;
        public event EventHandler<EventArgs> HostGridChanged;
        public void OnHostGridChanged(DXItemGrid oValue, DXItemGrid nValue)
        {
            HostGridChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region Item
        public ClientUserItem Item
        {
            get
            {
                if (GridType == GridType.Belt || GridType == GridType.AutoPotion)
                {
                    if (QuickInfo != null)
                        return QuickInfoItem;
                    return QuickItem;
                }
                if (Linked)
                    return Link?.Item;
                if (ItemGrid == null || Slot >= ItemGrid.Length) return null;
                return ItemGrid[Slot];
            }
            set
            {
                if (ItemGrid[Slot] == value || Linked || Slot >= ItemGrid.Length) return;
                ClientUserItem oldValue = ItemGrid[Slot];
                ItemGrid[Slot] = value;
                OnItemChanged(oldValue, value);
            }
        }
        public event EventHandler<EventArgs> ItemChanged;
        public void OnItemChanged(ClientUserItem oValue, ClientUserItem nValue)
        {
            ItemChanged?.Invoke(this, EventArgs.Empty);
            RefreshItem();
        }
        #endregion
        #region ItemGrid
        public ClientUserItem[] ItemGrid
        {
            get => _ItemGrid;
            set
            {
                if (_ItemGrid == value) return;
                ClientUserItem[] oldValue = _ItemGrid;
                _ItemGrid = value;
                OnItemGridChanged(oldValue, value);
            }
        }
        private ClientUserItem[] _ItemGrid;
        public event EventHandler<EventArgs> ItemGridChanged;
        public void OnItemGridChanged(ClientUserItem[] oValue, ClientUserItem[] nValue)
        {
            ItemGridChanged?.Invoke(this, EventArgs.Empty);
            ItemChanged?.Invoke(this, EventArgs.Empty);
            RefreshItem();
        }
        #endregion
        #region Locked
        public bool Locked
        {
            get => _Locked;
            set
            {
                if (_Locked == value) return;
                bool oldValue = _Locked;
                _Locked = value;
                OnLockedChanged(oldValue, value);
            }
        }
        private bool _Locked;
        public event EventHandler<EventArgs> LockedChanged;
        public void OnLockedChanged(bool oValue, bool nValue)
        {
            LockedChanged?.Invoke(this, EventArgs.Empty);

            UpdateBorder();
        }
        #endregion
        #region ReadOnly
        public bool ReadOnly
        {
            get => _ReadOnly;
            set
            {
                if (_ReadOnly == value) return;
                bool oldValue = _ReadOnly;
                _ReadOnly = value;
                OnReadOnlyChanged(oldValue, value);
            }
        }
        private bool _ReadOnly;
        public event EventHandler<EventArgs> ReadOnlyChanged;
        public void OnReadOnlyChanged(bool oValue, bool nValue)
        {
            ReadOnlyChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion
        #region Selected
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
        public event EventHandler<EventArgs> SelectedChanged;
        public void OnSelectedChanged(bool oValue, bool nValue)
        {
            SelectedChanged?.Invoke(this, EventArgs.Empty);

            UpdateBorder();
        }
        #endregion
        #region Slot
        public int Slot
        {
            get => _Slot;
            set
            {
                if (_Slot == value) return;
                int oldValue = _Slot;
                _Slot = value;
                OnSlotChanged(oldValue, value);
            }
        }
        private int _Slot;
        public event EventHandler<EventArgs> SlotChanged;
        public void OnSlotChanged(int oValue, int nValue)
        {
            SlotChanged?.Invoke(this, EventArgs.Empty);
            ItemChanged?.Invoke(this, EventArgs.Empty);
            RefreshItem();
        }
        #endregion
        #region ShowCountLabel
        public bool ShowCountLabel
        {
            get => _ShowCountLabel;
            set
            {
                if (_ShowCountLabel == value) return;
                bool oldValue = _ShowCountLabel;
                _ShowCountLabel = value;
                OnShowCountLabelChanged(oldValue, value);
            }
        }
        private bool _ShowCountLabel;
        public event EventHandler<EventArgs> ShowCountLabelChanged;
        public void OnShowCountLabelChanged(bool oValue, bool nValue)
        {
            ShowCountLabelChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        public ClientUserItem QuickInfoItem { get; private set; }
        #region QuickInfo
        public ItemInfo QuickInfo
        {
            get => _QuickInfo;
            set
            {
                if (_QuickInfo == value) return;
                ItemInfo oldValue = _QuickInfo;
                _QuickInfo = value;
                OnLinkedInfoChanged(oldValue, value);
            }
        }
        private ItemInfo _QuickInfo;
        public event EventHandler<EventArgs> LinkedInfoChanged;
        public void OnLinkedInfoChanged(ItemInfo oValue, ItemInfo nValue)
        {
            if (nValue != null)
            {
                QuickInfoItem = new ClientUserItem(nValue, 1);
                QuickItem = null;
                if (GridType == GridType.Belt)
                    GameScene.Game.BeltBox.Links[Slot].LinkInfoIndex = nValue.Index;
            }
            else
            {
                QuickInfoItem = null;
                if (GridType == GridType.Belt)
                    GameScene.Game.BeltBox.Links[Slot].LinkInfoIndex = -1;
            }

            RefreshItem();
            LinkedInfoChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion
        #region QuickItem
        public ClientUserItem QuickItem
        {
            get => _QuickItem;
            set
            {
                if (_QuickItem == value) return;
                ClientUserItem oldValue = _QuickItem;
                _QuickItem = value;
                OnLinkedItemChanged(oldValue, value);
            }
        }
        private ClientUserItem _QuickItem;
        public event EventHandler<EventArgs> LinkedItemChanged;
        public void OnLinkedItemChanged(ClientUserItem oValue, ClientUserItem nValue)
        {
            if (nValue != null)
            {
                QuickInfo = null;
                GameScene.Game.BeltBox.Links[Slot].LinkItemIndex = nValue.Index;
            }
            else
            {
                GameScene.Game.BeltBox.Links[Slot].LinkItemIndex = -1;
            }

            RefreshItem();
            LinkedItemChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion
        #region Link
        public DXItemCell Link
        {
            get => _Link;
            set
            {
                if (_Link == value) return;
                DXItemCell oldValue = _Link;
                _Link = value;
                OnLinkChanged(oldValue, value);
            }
        }
        private DXItemCell _Link;
        public event EventHandler<EventArgs> LinkChanged;
        public void OnLinkChanged(DXItemCell oValue, DXItemCell nValue)
        {
            if (oValue?.Link == this) oValue.Link = null;
            if (nValue != null && nValue.Link != this) nValue.Link = this;
            RefreshItem();
            UpdateBorder();
            LinkChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region LinkedCount
        public long LinkedCount
        {
            get => _LinkedCount;
            set
            {
                if (_LinkedCount == value) return;
                long oldValue = _LinkedCount;
                _LinkedCount = value;
                OnLinkedCountChanged(oldValue, value);
            }
        }
        private long _LinkedCount;
        public event EventHandler<EventArgs> LinkedCountChanged;
        public void OnLinkedCountChanged(long oValue, long nValue)
        {
            LinkedCountChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion
        #region Linked
        public bool Linked
        {
            get => _Linked;
            set
            {
                if (_Linked == value) return;
                bool oldValue = _Linked;
                _Linked = value;
                OnLinkedChanged(oldValue, value);
            }
        }
        private bool _Linked;
        public event EventHandler<EventArgs> LinkedChanged;
        public void OnLinkedChanged(bool oValue, bool nValue)
        {
            LinkedChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion
        #region AllowLink
        public bool AllowLink
        {
            get => _AllowLink;
            set
            {
                if (_AllowLink == value) return;
                bool oldValue = _AllowLink;
                _AllowLink = value;
                OnAllowLinkChanged(oldValue, value);
            }
        }
        private bool _AllowLink;
        public event EventHandler<EventArgs> AllowLinkChanged;
        public void OnAllowLinkChanged(bool oValue, bool nValue)
        {
            AllowLinkChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        public DXLabel CountLabel;
        public override void OnIsVisibleChanged(bool oValue, bool nValue)
        {
            base.OnIsVisibleChanged(oValue, nValue);
            if (HostGrid == null && !IsVisible)
                Link = null;
        }
        public override void OnBorderChanged(bool oValue, bool nValue)
        {
            base.OnBorderChanged(oValue, nValue);

            TextureValid = false;
            UpdateBorder();
        }
        public override void OnBorderColourChanged(Color oValue, Color nValue)
        {
            base.OnBorderColourChanged(oValue, nValue);
            TextureValid = false;
            UpdateBorder();
        }
        public override void OnEnabledChanged(bool oValue, bool nValue)
        {
            base.OnEnabledChanged(oValue, nValue);
            UpdateBorder();
        }
        #endregion
        public DXItemCell(int nWidth = 36, int nHeight = 36)
        {
            BackColour = Color.Empty;
            DrawTexture = true;
            ShowCountLabel = true;
            AllowLink = true;

            CellWidth = nWidth;
            CellHeight = nHeight;

            BorderColour = Color.FromArgb(99, 83, 50);
            Size = new Size(CellWidth, CellHeight);
            CountLabel = new DXLabel
            {
                ForeColour = Color.Yellow,
                IsControl = false,
                Parent = this,
            };
            CountLabel.SizeChanged += CountLabel_SizeChanged;
           
            /*
            DXAnimatedControl dxAnimatedControl = new DXAnimatedControl();
            dxAnimatedControl.Parent = this;
            dxAnimatedControl.Location = new Point(0, 0);
            dxAnimatedControl.Loop = true;
            dxAnimatedControl.LibraryFile = LibraryFile.DunyaHaritisi;
            dxAnimatedControl.BaseIndex = 0;
            dxAnimatedControl.FrameCount = 0;
            dxAnimatedControl.AnimationDelay = TimeSpan.FromMilliseconds(1200.0);
            dxAnimatedControl.Blend = true;
            dxAnimatedControl.Visible = false;
            dxAnimatedControl.IsControl = false;
            dxAnimatedControl.Size = new Size(36, 36);
            this.ItemSpecialEffect = dxAnimatedControl;
            */
        }
        #region Methods
        private void CountLabel_SizeChanged(object sender, EventArgs e)
        {
            CountLabel.Location = new Point(Size.Width - CountLabel.Size.Width, Size.Height - CountLabel.Size.Height);
        }
        protected override void OnClearTexture()
        {
            base.OnClearTexture();
            if (!Border || BorderInformation == null) return;
            DXManager.Line.Draw(BorderInformation, BorderColour);
        }
        protected internal override void UpdateBorderInformation()
        {
            BorderInformation = null;
            if (!Border || Size.Width == 0 || Size.Height == 0) return;
            BorderInformation = new[]
                    {
                new Vector2(0, 0),
                new Vector2(Size.Width - 1, 0 ),
                new Vector2(Size.Width - 1, Size.Height - 1),
                new Vector2(0 , Size.Height - 1),
                new Vector2(0 , 0 )
            };
            TextureValid = false;
        }
        protected override void DrawBorder()
        {
        }
        protected override void DrawControl()
        {
            MirLibrary Library;
            CEnvir.LibraryList.TryGetValue(LibraryFile.StoreItems, out Library);
            if (Library != null && Item != null)
            {
                int drawIndex;
                if (Item.Info.Effect == ItemEffect.Gold)
                {
                    if (Item.Count < 100)
                        drawIndex = 120;
                    else if (Item.Count < 200)
                        drawIndex = 121;
                    else if (Item.Count < 500)
                        drawIndex = 122;
                    else if (Item.Count < 1000)
                        drawIndex = 123;
                    else if (Item.Count < 1000000) 
                        drawIndex = 124;
                    else if (Item.Count < 5000000) 
                        drawIndex = 125;
                    else if (Item.Count < 10000000) 
                        drawIndex = 126;
                    else
                        drawIndex = 127;
                }
                else
                {
                    ItemInfo info = Item.Info;
                    if (info.Effect == ItemEffect.ItemPart && Item.AddedStats[Stat.ItemIndex] > 0)
                        info = CartoonGlobals.ItemInfoList.Binding.First(x => x.Index == Item.AddedStats[Stat.ItemIndex]);
                    drawIndex = info.Image;
                }

                MirImage image = Library.CreateImage(drawIndex, ImageType.Image);
                if (image != null)
                {
                    Rectangle area = new Rectangle(DisplayArea.X, DisplayArea.Y, image.Width, image.Height);
                    area.Offset((Size.Width - image.Width) / 2, (Size.Height - image.Height) / 2);
                    PresentTexture(image.Image, this, area, Item.Count > 0 ? Color.White : Color.Gray, this);
                }
            }
            if (InterfaceLibrary != null)
            {
                MirImage image = InterfaceLibrary.CreateImage(47, ImageType.Image);
                if (Item != null && Item.New && image != null)
                    PresentTexture(image.Image, this, new Rectangle(DisplayArea.X + 1, DisplayArea.Y + 1, image.Width, image.Height), Item.Count > 0 ? Color.White : Color.Gray, this);
                image = InterfaceLibrary.CreateImage(48, ImageType.Image);
                if (Item != null && (Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked && image != null)
                    PresentTexture(image.Image, this, new Rectangle(DisplayArea.X + 1, DisplayArea.Y + 1, image.Width, image.Height), Item.Count > 0 ? Color.White : Color.Gray, this);

                image = InterfaceLibrary.CreateImage(49, ImageType.Image);
                if (Item != null && GameScene.Game != null && !GameScene.Game.CanUseItem(Item) && image != null)
                    PresentTexture(image.Image, this, new Rectangle(DisplayArea.Right - 12, DisplayArea.Y + 1, image.Width, image.Height), Item.Count > 0 ? Color.White : Color.Gray, this);
                image = InterfaceLibrary.CreateImage(103, ImageType.Image);
                if (Item != null && GameScene.Game != null && image != null && Item.Info.Effect == ItemEffect.ItemPart)
                    PresentTexture(image.Image, this, new Rectangle(DisplayArea.Right - 16, DisplayArea.Y + 1, image.Width, image.Height), Item.Count > 0 ? Color.White : Color.Gray, this);
            }
            base.DrawControl();
        }
        public void UpdateBorder()
        {
            BackColour = Color.Empty;
            if (!Enabled)
                BackColour = Color.FromArgb(125, 0, 125, 125);
            else if (Locked || Selected || (!Linked && Link != null))
                BackColour = Color.FromArgb(125, 255, 125, 125);
            DrawTexture = MouseControl == this || !Enabled || Locked || Selected || FixedBorder || (!Linked && Link != null);

            if (MouseControl == this || Locked || Selected || (!Linked && Link != null))
            {
                if (!FixedBorderColour)
                    BorderColour = Color.Lime;
                Border = true;
            }
            else
            {
                if (!FixedBorderColour)
                    BorderColour = Color.FromArgb(99, 83, 50);
                Border = FixedBorder;
            }
        }
        public void RefreshItem()
        {
            if ((GridType == GridType.Inventory || GridType == GridType.CompanionInventory || GridType == GridType.PatchGrid || GridType == GridType.BaoshiItems) && GameScene.Game.BeltBox?.Grid != null)
                foreach (DXItemCell cell in GameScene.Game.BeltBox.Grid.Grid)
                    cell.RefreshItem();
            if ((GridType == GridType.Inventory || GridType == GridType.CompanionInventory || GridType == GridType.PatchGrid || GridType == GridType.BaoshiItems) && GameScene.Game?.BigPatchBox != null)
                 foreach (AutoPotionRow row in GameScene.Game.BigPatchBox.Protect.Rows)
                    row.ItemCell.RefreshItem();

            if ((GridType == GridType.Belt || GridType == GridType.AutoPotion) && QuickInfo != null)
                QuickInfoItem.Count = GameScene.Game.Inventory.Where(x => x?.Info == QuickInfo).Sum(x => x.Count) + (GameScene.Game.Companion?.InventoryArray.Where(x => x?.Info == QuickInfo).Sum(x => x.Count) ?? 0);

            if (MouseControl == this)
            {
                GameScene.Game.MouseItem = null;
                GameScene.Game.MouseItem = Item;
            }
            CountLabel.Visible = ShowCountLabel && Item != null && (Item.Info.Effect != ItemEffect.Gold && Item.Info.Effect != ItemEffect.Experience && Item.Info.Effect != ItemEffect.GameGold && Item.Info.Effect != ItemEffect.Shengwang) && (Item.Info.StackSize > 1 || Item.Count > 1);
            CountLabel.Text = Linked ? LinkedCount.ToString() : Item?.Count.ToString();
        }
        public void MoveItem()
        {
            if (SelectedCell == null)
            {
                if (Item == null) return;
                if (Linked && Link != null)
                {
                    Link = null;
                    return;
                }
                SelectedCell = this;
                return;
            }
            
            if (SelectedCell == this || SelectedCell.Item == null)
            {
                SelectedCell = null;
                return;
            }


            switch (SelectedCell.GridType) 
            {
                case GridType.Equipment:
                    
                    if (GridType == GridType.Equipment)
                    {
                        
                        return;
                    }
                    if (Item == null || (SelectedCell.Item.Info == Item.Info && SelectedCell.Item.Count < SelectedCell.Item.Info.StackSize))
                        SelectedCell.MoveItem(this);
                    else
                        SelectedCell.MoveItem(HostGrid);
                    SelectedCell = null;
                    return;
                case GridType.CompanionEquipment:
                    
                    if (GridType == GridType.CompanionEquipment)
                    {
                        
                        return;
                    }


                    if (Item == null || (SelectedCell.Item.Info == Item.Info && SelectedCell.Item.Count < SelectedCell.Item.Info.StackSize))
                        SelectedCell.MoveItem(this);
                    else
                        SelectedCell.MoveItem(HostGrid);
                    SelectedCell = null;
                    return;
            }
            switch (GridType) 
            {
                case GridType.Equipment:
                    if (!Functions.CorrectSlot(SelectedCell.Item.Info.ItemType, (EquipmentSlot)Slot) || SelectedCell.GridType == GridType.Belt) return;
                    ToEquipment(SelectedCell);
                    return;
                case GridType.CompanionEquipment:
                    if (!Functions.CorrectSlot(SelectedCell.Item.Info.ItemType, (CompanionSlot)Slot) || SelectedCell.GridType == GridType.Belt) return;
                    ToCompanionEquipment(SelectedCell);
                    return;
            }
            
            SelectedCell.MoveItem(this);
        }
        public void ToEquipment(DXItemCell fromCell)
        {
            if (Locked || ReadOnly) return;
            if (Item != null && (Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return;
            if (fromCell == SelectedCell) SelectedCell = null;
            if (!GameScene.Game.CanWearItem(fromCell.Item, (EquipmentSlot)Slot)) return;
            C.ItemMove packet = new C.ItemMove
            {
                FromGrid = fromCell.GridType,
                ToGrid = GridType,
                FromSlot = fromCell.Slot,
                ToSlot = Slot
            };
            if (Item != null && Item.Info == fromCell.Item.Info && Item.Count < Item.Info.StackSize &&
                        (Item.Flags & UserItemFlags.Bound) == (fromCell.Item.Flags & UserItemFlags.Bound) &&
                        (Item.Flags & UserItemFlags.Worthless) == (fromCell.Item.Flags & UserItemFlags.Worthless) &&
                        (Item.Flags & UserItemFlags.NonRefinable) == (fromCell.Item.Flags & UserItemFlags.NonRefinable) &&
                        (Item.Flags & UserItemFlags.Expirable) == (fromCell.Item.Flags & UserItemFlags.Expirable) &&
                        Item.AddedStats.Compare(fromCell.Item.AddedStats) &&
                        Item.ExpireTime == fromCell.Item.ExpireTime)
                packet.MergeItem = true;
            Locked = true;
            fromCell.Locked = true;
            CEnvir.Enqueue(packet);
        }
        public void ToCompanionEquipment(DXItemCell fromCell)
        {
            if (Locked || ReadOnly) return;
            if (fromCell == SelectedCell) SelectedCell = null;
            if (!GameScene.Game.CanCompanionWearItem(fromCell.Item, (CompanionSlot)Slot)) return;
            C.ItemMove packet = new C.ItemMove
            {
                FromGrid = fromCell.GridType,
                ToGrid = GridType,
                FromSlot = fromCell.Slot,
                ToSlot = Slot
            };
            if (Item != null && Item.Info == fromCell.Item.Info && Item.Count < Item.Info.StackSize &&
                        (Item.Flags & UserItemFlags.Bound) == (fromCell.Item.Flags & UserItemFlags.Bound) &&
                        (Item.Flags & UserItemFlags.Worthless) == (fromCell.Item.Flags & UserItemFlags.Worthless) &&
                        (Item.Flags & UserItemFlags.NonRefinable) == (fromCell.Item.Flags & UserItemFlags.NonRefinable) &&
                        (Item.Flags & UserItemFlags.Expirable) == (fromCell.Item.Flags & UserItemFlags.Expirable) &&
                        Item.AddedStats.Compare(fromCell.Item.AddedStats) &&
                        Item.ExpireTime == fromCell.Item.ExpireTime)
                packet.MergeItem = true;
            Locked = true;
            fromCell.Locked = true;
            CEnvir.Enqueue(packet);
        }
        public void MoveItem(DXItemCell toCell)
        {
            ClientBeltLink link;
            #region Belt
            if (toCell.GridType == GridType.Belt)
            {
                ItemInfo info = null;
                ClientUserItem item = null;
                if (GridType == toCell.GridType)
                {
                    info = toCell.QuickInfo;
                    item = toCell.QuickItem;
                }
                if (Item.Info.ItemType == ItemType.ItemPart)
                    return;

                if (Item.Info.ShouldLinkInfo)
                    toCell.QuickInfo = Item.Info;
                else
                    toCell.QuickItem = Item;
                if (GridType == toCell.GridType)
                {
                    QuickInfo = info;
                    QuickItem = item;
                    link = GameScene.Game.BeltBox.Links[Slot];
                    CEnvir.Enqueue(new C.BeltLinkChanged { Slot = link.Slot, LinkIndex = link.LinkInfoIndex, LinkItemIndex = link.LinkItemIndex });
                }
                if (Selected) SelectedCell = null;

                link = GameScene.Game.BeltBox.Links[toCell.Slot];
                CEnvir.Enqueue(new C.BeltLinkChanged { Slot = link.Slot, LinkIndex = link.LinkInfoIndex, LinkItemIndex = link.LinkItemIndex });

                return;
            }
            #endregion
            #region Auto Potion
            if (toCell.GridType == GridType.AutoPotion)
            {

                if (GridType == toCell.GridType) return;
                if (!Item.Info.CanAutoPot) return;
                if (Selected) SelectedCell = null;
                toCell.QuickInfo = Item.Info;

                GameScene.Game.BigPatchBox.Protect.Rows[toCell.Slot].SendUpdate();
                return;
            }
            #endregion
            if (GridType == GridType.Belt)
            {
                QuickInfo = null;
                QuickItem = null;
                link = GameScene.Game.BeltBox.Links[Slot];
                CEnvir.Enqueue(new C.BeltLinkChanged { Slot = link.Slot, LinkIndex = link.LinkInfoIndex, LinkItemIndex = link.LinkItemIndex });
                if (Selected) SelectedCell = null;
                return;
            }
            if (GridType == GridType.AutoPotion)
            {
                QuickInfo = null;
                GameScene.Game.BigPatchBox.Protect.Rows[toCell.Slot].SendUpdate();
                if (Selected) SelectedCell = null;
                return;
            }
            if (toCell.Linked)
            {
                if (!CheckLink(toCell.HostGrid)) return;
                if (Selected) SelectedCell = null;
                if (Item?.Count > 1)
                {
                    DXItemAmountWindow window = new DXItemAmountWindow("数量", Item);
                    if (toCell.GridType == GridType.Sell)
                        window.AmountBox.Value = Item.Count;
                    
                    else if (toCell.GridType == GridType.Jyhuishou)
                        window.AmountBox.Value = Item.Count;

                    
                    else if (toCell.GridType == GridType.GuildContribution)
                        window.AmountBox.Value = Item.Count;

                    window.ConfirmButton.MouseClick += (o, e) =>
                    {
                        toCell.LinkedCount = window.Amount;
                        toCell.Link = this;
                    };

                    return;
                }
                toCell.LinkedCount = 1;
                toCell.Link = this;
                return;
            }

            C.ItemMove packet = new C.ItemMove
            {
                FromGrid = GridType,
                ToGrid = toCell.GridType,
                FromSlot = Slot,
                ToSlot = toCell.Slot
            };
            if (toCell.Item != null && toCell.Item.Info == Item.Info && toCell.Item.Count < toCell.Item.Info.StackSize &&
                        (Item.Flags & UserItemFlags.Bound) == (toCell.Item.Flags & UserItemFlags.Bound) &&
                        (Item.Flags & UserItemFlags.Worthless) == (toCell.Item.Flags & UserItemFlags.Worthless) &&
                        (Item.Flags & UserItemFlags.NonRefinable) == (toCell.Item.Flags & UserItemFlags.NonRefinable) &&
                        (Item.Flags & UserItemFlags.Expirable) == (toCell.Item.Flags & UserItemFlags.Expirable) &&
                        Item.AddedStats.Compare(toCell.Item.AddedStats) &&
                        Item.ExpireTime == toCell.Item.ExpireTime)
                packet.MergeItem = true;
            if (Selected) SelectedCell = null;
            Locked = true;
            toCell.Locked = true;
            CEnvir.Enqueue(packet);
        }
        public bool MoveItem(DXItemGrid toGrid, bool skipCount = false)
        {
            if (toGrid.GridType == GridType.Belt || toGrid.GridType == GridType.AutoPotion) return false;

            C.ItemMove packet = new C.ItemMove
            {
                FromGrid = GridType,
                FromSlot = Slot,
            };
            DXItemCell toCell = null;
            foreach (DXItemCell cell in toGrid.Grid)
            {
                if (cell.Locked || !cell.Enabled) continue;
                ClientUserItem toItem = cell.Item;
                if (toItem == null)
                {
                    if (cell.Linked)
                    {
                        if (!CheckLink(toGrid)) return false;
                        if (Selected) SelectedCell = null;
                        switch (toGrid.GridType)
                        {
                            case GridType.RefineSpecial:
                                cell.LinkedCount = 1;
                                break;
                            case GridType.RefinementStoneCrystal:
                                cell.LinkedCount = 25;
                                break;
                            case GridType.MasterRefineFragment1:
                            case GridType.MasterRefineFragment2:
                                cell.LinkedCount = 10;
                                break;
                            case GridType.MasterRefineSpecial:
                                cell.LinkedCount = 1;
                                break;
                            case GridType.MasterRefineStone:
                                cell.LinkedCount = 1;
                                break;
                            case GridType.hechengbaoshi:
                                if (GameScene.Game.User.BaoshiKaiqi5433)
                                {
                                    if (Item.Info.Weight == 1)
                                        cell.LinkedCount = 5;
                                    else if (Item.Info.Weight == 2)
                                        cell.LinkedCount = 4;
                                    else if (Item.Info.Weight == 3)
                                        cell.LinkedCount = 3;
                                    else if (Item.Info.Weight == 4)
                                        cell.LinkedCount = 3;
                                }
                                else
                                    cell.LinkedCount = 5;
                                break;
                            default:
                                if (Item.Count > 1 && !skipCount)
                                {
                                    DXItemAmountWindow window = new DXItemAmountWindow("数量", Item);
                                    if (cell.GridType == GridType.Sell)
                                        window.AmountBox.Value = Item.Count;

                                    
                                    else if (cell.GridType == GridType.GuildContribution)
                                        window.AmountBox.Value = Item.Count;

                                    
                                    else if (cell.GridType == GridType.Jyhuishou)
                                        window.AmountBox.Value = Item.Count;

                                    window.ConfirmButton.MouseClick += (o, e) =>
                                    {
                                        cell.LinkedCount = window.Amount;
                                        cell.Link = this;
                                    };
                                    return true;
                                }
                                cell.LinkedCount = Item.Count;
                                break;
                            case GridType.WeaponCraftTemplate:
                                cell.LinkedCount = 1;
                                break;
                            case GridType.WeaponCraftYellow:
                                cell.LinkedCount = 1;
                                break;
                            case GridType.WeaponCraftBlue:
                                cell.LinkedCount = 1;
                                break;
                            case GridType.WeaponCraftRed:
                                cell.LinkedCount = 1;
                                break;
                            case GridType.WeaponCraftPurple:
                                cell.LinkedCount = 1;
                                break;
                            case GridType.WeaponCraftGreen:
                                cell.LinkedCount = 1;
                                break;
                            case GridType.WeaponCraftGrey:
                                cell.LinkedCount = 1;
                                break;
                                
                            case GridType.GZLKaikongItems:
                            case GridType.GZLBKaikongItems:
                            case GridType.QTKaikongItems:
                            case GridType.XiangKanGJSTItems:
                            case GridType.XiangKanGJBSTItems:
                            case GridType.XiangKanZRSTItems:
                            case GridType.XiangKanZRBSTItems:
                            case GridType.XiangKanLHSTItems:
                            case GridType.XiangKanLHBSTItems:
                            case GridType.XiangKanSMSTItems:
                            case GridType.XiangKanMFSTItems:
                            case GridType.XiangKanSDSTItems:
                            case GridType.XiangKanFYSTItems:
                            case GridType.XiangKanMYSTItems:
                            case GridType.Chaichustitems:
                            case GridType.Xiangkanjystitems:
                            case GridType.Xiangkanxxstitems:
                            case GridType.XiangKanghuoitems:
                            case GridType.XiangKangbingitems:
                            case GridType.XiangKangleiitems:
                            case GridType.XiangKangfengitems:
                            case GridType.XiangKangshenitems:
                            case GridType.XiangKanganitems:
                            case GridType.XiangKanghuanitems:
                            case GridType.XiangKanmofadunitems:
                            case GridType.XiangKanbingdongitems:
                            case GridType.XiangKanmabiitems:
                            case GridType.XiangKanyidongitems:
                            case GridType.XiangKanchenmoitems:
                            case GridType.XiangKangedangitems:
                            case GridType.XiangKanduobiitems:
                            case GridType.XiangKanqhuoitems:
                            case GridType.XiangKanqbingitems:
                            case GridType.XiangKanqleiitems:
                            case GridType.XiangKanqfengitems:
                            case GridType.XiangKanqshenitems:
                            case GridType.XiangKanqanitems:
                            case GridType.XiangKanqhuanitems:
                            case GridType.XiangKanlvduitems:
                            case GridType.XiangKanzymitems:
                            case GridType.XiangKanmhhfitems:
                            case GridType.Huanhuaitems:
                            
                            case GridType.XiangKanjinglianitems:
                            
                            case GridType.ZhongziItems:
                            
                            case GridType.DunRefineUpgradeItems:
                            
                            case GridType.HuiRefineUpgradeItems:
                                cell.LinkedCount = 1;
                                break;
                            
                            case GridType.MingwenItems:
                                cell.LinkedCount = 1;
                                break;
                        }
                        cell.Link = this;
                        return true;
                    }
                    if (toCell == null) toCell = cell;
                    continue;
                }
                if (cell.Linked || toItem.Info != Item.Info || toItem.Count >= toItem.Info.StackSize) continue;
                if ((Item.Flags & UserItemFlags.Bound) != (toItem.Flags & UserItemFlags.Bound)) continue;
                if ((Item.Flags & UserItemFlags.Worthless) != (toItem.Flags & UserItemFlags.Worthless)) continue;
                if ((Item.Flags & UserItemFlags.NonRefinable) != (toItem.Flags & UserItemFlags.NonRefinable)) continue;
                if ((Item.Flags & UserItemFlags.Expirable) != (toItem.Flags & UserItemFlags.Expirable)) continue;
                if (!Item.AddedStats.Compare(toItem.AddedStats)) continue;
                if (Item.ExpireTime != toItem.ExpireTime) continue;

                toCell = cell;
                packet.MergeItem = true;
                break;
            }
            if (toCell == null) return false;
            if (toCell.Selected) SelectedCell = null;
            packet.ToSlot = toCell.Slot;
            packet.ToGrid = toCell.GridType;
            Locked = true;
            toCell.Locked = true;
            CEnvir.Enqueue(packet);
            return true;
        }
        public bool CheckLink(DXItemGrid grid)
        {
            if (!AllowLink || Item == null || (!Linked && Link != null) || grid == null) return false;

            switch (grid.GridType)
            {
                case GridType.Sell:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.PatchGrid && GridType != GridType.BaoshiItems) || (Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked || (Item.Flags & UserItemFlags.Worthless) == UserItemFlags.Worthless || !Item.Info.CanSell)
                        return false;
                    break;
                    
                case GridType.Jyhuishou:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.PatchGrid) || (Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked || (Item.Flags & UserItemFlags.Worthless) == UserItemFlags.Worthless || !Item.Info.CanJyChange || Item.Info.ItemType == ItemType.Ore || Item.Info.ItemType == ItemType.Nothing || (Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable)
                        return false;
                    break;
                
                case GridType.GuildContribution:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.PatchGrid) || (Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked || (Item.Flags & UserItemFlags.Worthless) == UserItemFlags.Worthless || !Item.Info.CanJyChange || (Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    switch (Item.Info.ItemName)
                    {
                        
                        
                        
                        
                        
                        case "火星手镯[低]":
                        case "火星戒指[低]":
                        case "火星项链[低]":
                        case "火星手镯[中]":
                        case "火星戒指[中]":
                        case "火星项链[中]":
                            return false;
                        default:
                            break ;
                    }
                    break;
                case GridType.Repair:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if (GameScene.Game.NPCBox.Page.Types.All(x => x.ItemType != Item.Info.ItemType) || !Item.Info.CanRepair || Item.CurrentDurability >= Item.MaxDurability || (GameScene.Game.NPCRepairBox.SpecialCheckBox.Checked && CEnvir.Now < Item.NextSpecialRepair))
                        return false;
                    break;
                case GridType.Storage:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if (!MapObject.User.InSafeZone) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.Equipment) return false;
                    if (!Item.Info.CanStore) return false;
                    break;
                case GridType.RefinementStoneIronOre:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if (Item.Info.Effect != ItemEffect.IronOre || (Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    break;
                case GridType.RefinementStoneSilverOre:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if (Item.Info.Effect != ItemEffect.SilverOre || (Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    break;
                case GridType.RefinementStoneDiamond:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if (Item.Info.Effect != ItemEffect.Diamond || (Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    break;
                case GridType.RefinementStoneGoldOre:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if (Item.Info.Effect != ItemEffect.GoldOre || (Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    break;
                case GridType.RefinementStoneCrystal:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if (Item.Info.Effect != ItemEffect.Crystal || (Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    break;
                case GridType.RefineBlackIronOre:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if (Item.Info.Effect != ItemEffect.BlackIronOre || (Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    break;
                case GridType.RefineAccessory:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Necklace:
                        case ItemType.Bracelet:
                        case ItemType.Ring:
                            break;
                        default:
                            return false;
                    }
                    break;
                case GridType.RefineSpecial:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    switch (Item.Info.ItemType)
                    {
                        case ItemType.RefineSpecial:
                            if (Item.Info.ShapeNum != 1) return false; 
                            break;
                        default:
                            return false;
                    }
                    break;
                case GridType.ItemFragment:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.PatchGrid) || (Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked || !Item.CanFragment())
                        return false;
                    break;
                
                case GridType.Xiaohui:
                    if ((GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.PatchGrid && GridType != GridType.BaoshiItems) || (Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked)
                        return false;
                    break;
                
                case GridType.hechengbaoshi:
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.PatchGrid && GridType != GridType.BaoshiItems) || (Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked)
                        return false;
                    break;
                
                case GridType.duihuanbaoshi:
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.PatchGrid && GridType != GridType.BaoshiItems) || (Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked)
                        return false;
                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Baoshi:
                            break;
                        default:
                            return false;
                    }
                    break;
                case GridType.Consign:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.Storage) return false;
                    if (GridType == GridType.Inventory && !MapObject.User.InSafeZone) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if (!Item.Info.CanTrade) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound) return false;
                    break;
                case GridType.SendMail:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.Storage) return false;
                    if (GridType == GridType.Inventory && !MapObject.User.InSafeZone) return false;
                    break;
                case GridType.TradeUser:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.Storage && GridType != GridType.Equipment) return false;
                    break;
                case GridType.GuildStorage:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if (!Item.Info.CanTrade) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.Storage && GridType != GridType.Equipment) return false;
                    break;
                case GridType.WeddingRing:
                    if (GridType != GridType.Inventory) return false;
                    if (Item.Info.ItemType != ItemType.Ring) return false;
                    break;
                case GridType.AccessoryRefineUpgradeTarget:
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Necklace:
                        case ItemType.Bracelet:
                        case ItemType.Ring:
                            break;
                        default:
                            return false;
                    }
                    if ((Item.Flags & UserItemFlags.Refinable) != UserItemFlags.Refinable) return false;
                    break;
                case GridType.AccessoryRefineLevelTarget:
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Necklace:
                        case ItemType.Bracelet:
                        case ItemType.Ring:
                            break;
                        default:
                            return false;
                    }
                    if ((Item.Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable) return false;
                    if (Item.Level >= CartoonGlobals.AccessoryExperienceList.Count) return false;
                    break;
                case GridType.AccessoryRefineLevelItems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Necklace:
                        case ItemType.Bracelet:
                        case ItemType.Ring:
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCAccessoryLevelBox.TargetCell.Grid[0].Link?.Item?.Info != Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCAccessoryLevelBox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return false;
                    break;
                case GridType.AccessoryReset:
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Necklace:
                        case ItemType.Bracelet:
                        case ItemType.Ring:
                            break;
                        default:
                            return false;
                    }
                    if (Item.Level >= CartoonGlobals.AccessoryExperienceList.Count) return false;
                    break;
                
                case GridType.DunRefineUpgradeTarget:
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if (Item.Level > 10) return false;
                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Shield:
                            break;
                        default:
                            return false;
                    }
                    if ((Item.Flags & UserItemFlags.Refinable) != UserItemFlags.Refinable) return false;
                    if (Item.Level >= CartoonGlobals.DunExperienceList.Count) return false;
                    break;
                
                case GridType.DunRefineUpgradeItems:
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    switch (Item.Info.ItemName)
                    {
                        case "蓝色珠子[1级]":
                        case "蓝色珠子[2级]":
                        case "蓝色珠子[3级]":
                        case "蓝色珠子[4级]":
                        case "蓝色珠子[5级]":
                            break;
                        default:
                            return false;
                    }
                    break;
                
                case GridType.DunRefineLevelTarget:
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Shield:
                            break;
                        default:
                            return false;
                    }
                    if ((Item.Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable) return false;
                    if (Item.Level >= CartoonGlobals.DunExperienceList.Count) return false;
                    break;
                
                case GridType.DunRefineLevelItems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    switch (Item.Info.ItemName)
                    {
                        case "蓝色石头":
                            break;
                        default:
                            return false;
                    }
                    
                    break;
                
                case GridType.DunReset:
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Shield:
                            break;
                        default:
                            return false;
                    }
                    if (Item.Level >= CartoonGlobals.DunExperienceList.Count) return false;
                    break;
                
                case GridType.HuiRefineUpgradeTarget:
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if (Item.Level > 10) return false;
                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Emblem:
                            break;
                        default:
                            return false;
                    }
                    if ((Item.Flags & UserItemFlags.Refinable) != UserItemFlags.Refinable) return false;
                    if (Item.Level >= CartoonGlobals.HuiExperienceList.Count) return false;
                    break;
                
                case GridType.HuiRefineUpgradeItems:
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    switch (Item.Info.ItemName)
                    {
                        case "红色珠子[1级]":
                        case "红色珠子[2级]":
                        case "红色珠子[3级]":
                        case "红色珠子[4级]":
                        case "红色珠子[5级]":
                            break;
                        default:
                            return false;
                    }
                    break;
                
                case GridType.HuiRefineLevelTarget:
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Emblem:
                            break;
                        default:
                            return false;
                    }
                    if ((Item.Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable) return false;
                    if (Item.Level >= CartoonGlobals.HuiExperienceList.Count) return false;
                    break;
                
                case GridType.HuiRefineLevelItems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    switch (Item.Info.ItemName)
                    {
                        case "红色石头":
                            break;
                        default:
                            return false;
                    }
                    
                    break;
                
                case GridType.HuiReset:
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Emblem:
                            break;
                        default:
                            return false;
                    }
                    if (Item.Level >= CartoonGlobals.HuiExperienceList.Count) return false;
                    break;
                case GridType.MasterRefineFragment1:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if (Item.Info.Effect != ItemEffect.Fragment1 || (Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    break;
                case GridType.MasterRefineFragment2:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if (Item.Info.Effect != ItemEffect.Fragment2 || (Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    break;
                case GridType.MasterRefineFragment3:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if (Item.Info.Effect != ItemEffect.Fragment3 || (Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    break;
                case GridType.MasterRefineStone:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if (Item.Info.Effect != ItemEffect.RefinementStone || (Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    break;
                case GridType.MasterRefineSpecial:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    switch (Item.Info.ItemType)
                    {
                        case ItemType.RefineSpecial:
                            if (Item.Info.ShapeNum != 5) return false; 
                            break;
                        default:
                            return false;
                    }
                    break;
                case GridType.WeaponCraftTemplate:
                    if (Item.Info.ItemType != ItemType.Weapon && Item.Info.Effect != ItemEffect.WeaponTemplate) return false;
                    if ((Item.BaoshiMaYi & BaoshiMaYi.XiangKanXXY) == BaoshiMaYi.XiangKanXXY || (Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXE) == BaoshiMaEr.XiangKanXXE || (Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS)
                    {
                        GameScene.Game.ReceiveChat($"无法制造，因为 {Item.Info.ItemName} 已有镶嵌的宝石，请拆除宝石后试一试。", MessageType.System);
                        return false;
                    }
                    break;
                case GridType.WeaponCraftBlue:
                    if (Item.Info.Effect != ItemEffect.BlueSlot) return false;
                    break;
                case GridType.WeaponCraftGreen:
                    if (Item.Info.Effect != ItemEffect.GreenSlot) return false;
                    break;
                case GridType.WeaponCraftGrey:
                    if (Item.Info.Effect != ItemEffect.GreySlot) return false;
                    break;
                case GridType.WeaponCraftPurple:
                    if (Item.Info.Effect != ItemEffect.PurpleSlot) return false;
                    break;
                case GridType.WeaponCraftRed:
                    if (Item.Info.Effect != ItemEffect.RedSlot) return false;
                    break;
                case GridType.WeaponCraftYellow:
                    if (Item.Info.Effect != ItemEffect.YellowSlot) return false;
                    break;
                case GridType.PatchGrid:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage || (GridType != GridType.Inventory && GridType != GridType.Equipment || !Item.Info.CanStore))
                        return false;
                    break;
                case GridType.BaoshiItems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage || (GridType != GridType.Inventory && GridType != GridType.Equipment || !Item.Info.CanStore))
                        return false;
                    break;
                
                case GridType.Mingwen:
                    
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Weapon:
                            break;
                        default:
                            return false;
                    }
                    break;
                
                case GridType.MingwenItems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    switch (Item.Info.ItemName)
                    {
                        case "战士铭文":
                        case "法师铭文":
                        case "道士铭文":
                        case "刺客铭文":
                        case "战士铭文[活动]":
                        case "法师铭文[活动]":
                        case "道士铭文[活动]":
                        case "刺客铭文[活动]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCMingwenBox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCMingwenBox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.GZLKaikong:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) == BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Necklace:
                        case ItemType.Bracelet:
                        case ItemType.Ring:
                        
                        case ItemType.Shizhuang:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;

                case GridType.GZLKaikongItems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "红色打孔石":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCGZLKaikongBox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCGZLKaikongBox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.GZLBKaikong:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) == BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Necklace:
                        case ItemType.Bracelet:
                        case ItemType.Ring:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;

                case GridType.GZLBKaikongItems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "黄色打孔石":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCGZLBKaikongBox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCGZLBKaikongBox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.QTKaikong:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) == BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Necklace:
                        case ItemType.Bracelet:
                        case ItemType.Ring:
                        case ItemType.Armour:
                        case ItemType.Shoes:
                        case ItemType.Helmet:
                        case ItemType.Weapon:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;

                case GridType.QTKaikongItems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "绿色打孔石":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCQTKaikongBox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCQTKaikongBox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.XiangKanGJST:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.GZLKaikongy) != BaoshiMaEr.GZLKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.GZLKaikonge) != BaoshiMaEr.GZLKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.GZLKaikongs) != BaoshiMaEr.GZLKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Necklace:
                        case ItemType.Bracelet:
                        case ItemType.Ring:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;

                case GridType.XiangKanGJSTItems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "攻击宝石":
                        case "攻击宝石[1级]":
                        case "攻击宝石[2级]":
                        case "攻击宝石[3级]":
                        case "攻击宝石[4级]":
                        case "攻击宝石[5级]":
                        case "攻击宝石[6级]":
                        case "攻击宝石[7级]":
                        case "攻击宝石[8级]":
                        case "攻击宝石[9级]":
                        case "攻击宝石[10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKanGJSTBox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKanGJSTBox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.XiangKanGJBST:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.GZLBKaikongy) != BaoshiMaEr.GZLBKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.GZLBKaikonge) != BaoshiMaEr.GZLBKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.GZLBKaikongs) != BaoshiMaEr.GZLBKaikongs) return false;
                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Necklace:
                        case ItemType.Bracelet:
                        case ItemType.Ring:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.XiangKanGJBSTItems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType == GridType.Inventory && GridType == GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "攻击几率宝石":
                        case "攻击几率宝石[1级]":
                        case "攻击几率宝石[2级]":
                        case "攻击几率宝石[3级]":
                        case "攻击几率宝石[4级]":
                        case "攻击几率宝石[5级]":
                        case "攻击几率宝石[6级]":
                        case "攻击几率宝石[7级]":
                        case "攻击几率宝石[8级]":
                        case "攻击几率宝石[9级]":
                        case "攻击几率宝石[10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKanGJBSTBox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKanGJBSTBox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.XiangKanZRST:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.GZLKaikongy) != BaoshiMaEr.GZLKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.GZLKaikonge) != BaoshiMaEr.GZLKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.GZLKaikongs) != BaoshiMaEr.GZLKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Necklace:
                        case ItemType.Bracelet:
                        case ItemType.Ring:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.XiangKanZRSTItems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "自然宝石":
                        case "自然宝石[1级]":
                        case "自然宝石[2级]":
                        case "自然宝石[3级]":
                        case "自然宝石[4级]":
                        case "自然宝石[5级]":
                        case "自然宝石[6级]":
                        case "自然宝石[7级]":
                        case "自然宝石[8级]":
                        case "自然宝石[9级]":
                        case "自然宝石[10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKanZRSTBox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKanZRSTBox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.XiangKanZRBST:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.GZLBKaikongy) != BaoshiMaEr.GZLBKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.GZLBKaikonge) != BaoshiMaEr.GZLBKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.GZLBKaikongs) != BaoshiMaEr.GZLBKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Necklace:
                        case ItemType.Bracelet:
                        case ItemType.Ring:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.XiangKanZRBSTItems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "自然几率宝石":
                        case "自然几率宝石[1级]":
                        case "自然几率宝石[2级]":
                        case "自然几率宝石[3级]":
                        case "自然几率宝石[4级]":
                        case "自然几率宝石[5级]":
                        case "自然几率宝石[6级]":
                        case "自然几率宝石[7级]":
                        case "自然几率宝石[8级]":
                        case "自然几率宝石[9级]":
                        case "自然几率宝石[10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKanZRBSTBox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKanZRBSTBox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.XiangKanLHST:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.GZLKaikongy) != BaoshiMaEr.GZLKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.GZLKaikonge) != BaoshiMaEr.GZLKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.GZLKaikongs) != BaoshiMaEr.GZLKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Necklace:
                        case ItemType.Bracelet:
                        case ItemType.Ring:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.XiangKanLHSTItems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "灵魂宝石":
                        case "灵魂宝石[1级]":
                        case "灵魂宝石[2级]":
                        case "灵魂宝石[3级]":
                        case "灵魂宝石[4级]":
                        case "灵魂宝石[5级]":
                        case "灵魂宝石[6级]":
                        case "灵魂宝石[7级]":
                        case "灵魂宝石[8级]":
                        case "灵魂宝石[9级]":
                        case "灵魂宝石[10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKanLHSTBox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKanLHSTBox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.XiangKanLHBST:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.GZLBKaikongy) != BaoshiMaEr.GZLBKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.GZLBKaikonge) != BaoshiMaEr.GZLBKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.GZLBKaikongs) != BaoshiMaEr.GZLBKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Necklace:
                        case ItemType.Bracelet:
                        case ItemType.Ring:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.XiangKanLHBSTItems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "灵魂几率宝石":
                        case "灵魂几率宝石[1级]":
                        case "灵魂几率宝石[2级]":
                        case "灵魂几率宝石[3级]":
                        case "灵魂几率宝石[4级]":
                        case "灵魂几率宝石[5级]":
                        case "灵魂几率宝石[6级]":
                        case "灵魂几率宝石[7级]":
                        case "灵魂几率宝石[8级]":
                        case "灵魂几率宝石[9级]":
                        case "灵魂几率宝石[10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKanLHBSTBox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKanLHBSTBox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.XiangKanSMST:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.QTKaikongy) != BaoshiMaEr.QTKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikonge) != BaoshiMaEr.QTKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikongs) != BaoshiMaEr.QTKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Necklace:
                        case ItemType.Bracelet:
                        case ItemType.Ring:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.XiangKanSMSTItems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "生命宝石":
                        case "生命宝石[1级]":
                        case "生命宝石[2级]":
                        case "生命宝石[3级]":
                        case "生命宝石[4级]":
                        case "生命宝石[5级]":
                        case "生命宝石[6级]":
                        case "生命宝石[7级]":
                        case "生命宝石[8级]":
                        case "生命宝石[9级]":
                        case "生命宝石[10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKanSMSTBox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKanSMSTBox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.XiangKanMFST:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.QTKaikongy) != BaoshiMaEr.QTKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikonge) != BaoshiMaEr.QTKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikongs) != BaoshiMaEr.QTKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Necklace:
                        case ItemType.Bracelet:
                        case ItemType.Ring:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.XiangKanMFSTItems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "魔法宝石":
                        case "魔法宝石[1级]":
                        case "魔法宝石[2级]":
                        case "魔法宝石[3级]":
                        case "魔法宝石[4级]":
                        case "魔法宝石[5级]":
                        case "魔法宝石[6级]":
                        case "魔法宝石[7级]":
                        case "魔法宝石[8级]":
                        case "魔法宝石[9级]":
                        case "魔法宝石[10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKanMFSTBox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKanMFSTBox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.XiangKanSDST:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.QTKaikongy) != BaoshiMaEr.QTKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikonge) != BaoshiMaEr.QTKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikongs) != BaoshiMaEr.QTKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Necklace:
                        case ItemType.Bracelet:
                        case ItemType.Ring:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.XiangKanSDSTItems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "速度宝石":
                        case "速度宝石[1级]":
                        case "速度宝石[2级]":
                        case "速度宝石[3级]":
                        case "速度宝石[4级]":
                        case "速度宝石[5级]":
                        case "速度宝石[6级]":
                        case "速度宝石[7级]":
                        case "速度宝石[8级]":
                        case "速度宝石[9级]":
                        case "速度宝石[10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKanSDSTBox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKanSDSTBox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.XiangKanFYST:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.QTKaikongy) != BaoshiMaEr.QTKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikonge) != BaoshiMaEr.QTKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikongs) != BaoshiMaEr.QTKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Necklace:
                        case ItemType.Bracelet:
                        case ItemType.Ring:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.XiangKanFYSTItems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "防御宝石":
                        case "防御宝石[1级]":
                        case "防御宝石[2级]":
                        case "防御宝石[3级]":
                        case "防御宝石[4级]":
                        case "防御宝石[5级]":
                        case "防御宝石[6级]":
                        case "防御宝石[7级]":
                        case "防御宝石[8级]":
                        case "防御宝石[9级]":
                        case "防御宝石[10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKanFYSTBox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKanFYSTBox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.XiangKanMYST:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.QTKaikongy) != BaoshiMaEr.QTKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikonge) != BaoshiMaEr.QTKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikongs) != BaoshiMaEr.QTKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Necklace:
                        case ItemType.Bracelet:
                        case ItemType.Ring:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.XiangKanMYSTItems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "魔御宝石":
                        case "魔御宝石[1级]":
                        case "魔御宝石[2级]":
                        case "魔御宝石[3级]":
                        case "魔御宝石[4级]":
                        case "魔御宝石[5级]":
                        case "魔御宝石[6级]":
                        case "魔御宝石[7级]":
                        case "魔御宝石[8级]":
                        case "魔御宝石[9级]":
                        case "魔御宝石[10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKanMYSTBox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKanMYSTBox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.Chaichust:
                    
                    if ((Item.BaoshiMaYi & BaoshiMaYi.XiangKanXXY) != BaoshiMaYi.XiangKanXXY & (Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXE) != BaoshiMaEr.XiangKanXXE & (Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) != BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Necklace:
                        case ItemType.Bracelet:
                        case ItemType.Ring:
                        case ItemType.Armour:
                        case ItemType.Shoes:
                        case ItemType.Helmet:
                        case ItemType.Weapon:
                        
                        case ItemType.Shizhuang:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.Chaichustitems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "拆除宝石卷":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCChaichustBox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCChaichustBox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.Xiangkanjyst:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.QTKaikongy) != BaoshiMaEr.QTKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikonge) != BaoshiMaEr.QTKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikongs) != BaoshiMaEr.QTKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Armour:
                        case ItemType.Shoes:
                        case ItemType.Helmet:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.Xiangkanjystitems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "经验宝石":
                        case "经验宝石[1级]":
                        case "经验宝石[2级]":
                        case "经验宝石[3级]":
                        case "经验宝石[4级]":
                        case "经验宝石[5级]":
                        case "经验宝石[6级]":
                        case "经验宝石[7级]":
                        case "经验宝石[8级]":
                        case "经验宝石[9级]":
                        case "经验宝石[10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangkanjystbox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangkanjystbox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.Xiangkanxxst:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.QTKaikongy) != BaoshiMaEr.QTKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikonge) != BaoshiMaEr.QTKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikongs) != BaoshiMaEr.QTKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Armour:
                        case ItemType.Shoes:
                        case ItemType.Helmet:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.Xiangkanxxstitems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "吸血宝石":
                        case "吸血宝石[1级]":
                        case "吸血宝石[2级]":
                        case "吸血宝石[3级]":
                        case "吸血宝石[4级]":
                        case "吸血宝石[5级]":
                        case "吸血宝石[6级]":
                        case "吸血宝石[7级]":
                        case "吸血宝石[8级]":
                        case "吸血宝石[9级]":
                        case "吸血宝石[10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangkanxxstbox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangkanxxstbox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.XiangKanghuo:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.QTKaikongy) != BaoshiMaEr.QTKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikonge) != BaoshiMaEr.QTKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikongs) != BaoshiMaEr.QTKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Weapon:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.XiangKanghuoitems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "攻击元素[火]":
                        case "攻击元素[火][1级]":
                        case "攻击元素[火][2级]":
                        case "攻击元素[火][3级]":
                        case "攻击元素[火][4级]":
                        case "攻击元素[火][5级]":
                        case "攻击元素[火][6级]":
                        case "攻击元素[火][7级]":
                        case "攻击元素[火][8级]":
                        case "攻击元素[火][9级]":
                        case "攻击元素[火][10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKanghuobox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKanghuobox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.XiangKangbing:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.QTKaikongy) != BaoshiMaEr.QTKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikonge) != BaoshiMaEr.QTKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikongs) != BaoshiMaEr.QTKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Weapon:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.XiangKangbingitems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "攻击元素[冰]":
                        case "攻击元素[冰][1级]":
                        case "攻击元素[冰][2级]":
                        case "攻击元素[冰][3级]":
                        case "攻击元素[冰][4级]":
                        case "攻击元素[冰][5级]":
                        case "攻击元素[冰][6级]":
                        case "攻击元素[冰][7级]":
                        case "攻击元素[冰][8级]":
                        case "攻击元素[冰][9级]":
                        case "攻击元素[冰][10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKangbingbox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKangbingbox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.XiangKanglei:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.QTKaikongy) != BaoshiMaEr.QTKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikonge) != BaoshiMaEr.QTKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikongs) != BaoshiMaEr.QTKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Weapon:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.XiangKangleiitems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "攻击元素[雷]":
                        case "攻击元素[雷][1级]":
                        case "攻击元素[雷][2级]":
                        case "攻击元素[雷][3级]":
                        case "攻击元素[雷][4级]":
                        case "攻击元素[雷][5级]":
                        case "攻击元素[雷][6级]":
                        case "攻击元素[雷][7级]":
                        case "攻击元素[雷][8级]":
                        case "攻击元素[雷][9级]":
                        case "攻击元素[雷][10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKangleibox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKangleibox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.XiangKangfeng:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.QTKaikongy) != BaoshiMaEr.QTKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikonge) != BaoshiMaEr.QTKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikongs) != BaoshiMaEr.QTKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Weapon:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.XiangKangfengitems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "攻击元素[风]":
                        case "攻击元素[风][1级]":
                        case "攻击元素[风][2级]":
                        case "攻击元素[风][3级]":
                        case "攻击元素[风][4级]":
                        case "攻击元素[风][5级]":
                        case "攻击元素[风][6级]":
                        case "攻击元素[风][7级]":
                        case "攻击元素[风][8级]":
                        case "攻击元素[风][9级]":
                        case "攻击元素[风][10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKangfengbox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKangfengbox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.XiangKangshen:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.QTKaikongy) != BaoshiMaEr.QTKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikonge) != BaoshiMaEr.QTKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikongs) != BaoshiMaEr.QTKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Weapon:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.XiangKangshenitems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "攻击元素[神圣]":
                        case "攻击元素[神圣][1级]":
                        case "攻击元素[神圣][2级]":
                        case "攻击元素[神圣][3级]":
                        case "攻击元素[神圣][4级]":
                        case "攻击元素[神圣][5级]":
                        case "攻击元素[神圣][6级]":
                        case "攻击元素[神圣][7级]":
                        case "攻击元素[神圣][8级]":
                        case "攻击元素[神圣][9级]":
                        case "攻击元素[神圣][10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKangshenbox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKangshenbox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.XiangKangan:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.QTKaikongy) != BaoshiMaEr.QTKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikonge) != BaoshiMaEr.QTKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikongs) != BaoshiMaEr.QTKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Weapon:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.XiangKanganitems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "攻击元素[暗黑]":
                        case "攻击元素[暗黑][1级]":
                        case "攻击元素[暗黑][2级]":
                        case "攻击元素[暗黑][3级]":
                        case "攻击元素[暗黑][4级]":
                        case "攻击元素[暗黑][5级]":
                        case "攻击元素[暗黑][6级]":
                        case "攻击元素[暗黑][7级]":
                        case "攻击元素[暗黑][8级]":
                        case "攻击元素[暗黑][9级]":
                        case "攻击元素[暗黑][10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKanganbox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKanganbox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.XiangKanghuan:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.QTKaikongy) != BaoshiMaEr.QTKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikonge) != BaoshiMaEr.QTKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikongs) != BaoshiMaEr.QTKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Weapon:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.XiangKanghuanitems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "攻击元素[幻影]":
                        case "攻击元素[幻影][1级]":
                        case "攻击元素[幻影][2级]":
                        case "攻击元素[幻影][3级]":
                        case "攻击元素[幻影][4级]":
                        case "攻击元素[幻影][5级]":
                        case "攻击元素[幻影][6级]":
                        case "攻击元素[幻影][7级]":
                        case "攻击元素[幻影][8级]":
                        case "攻击元素[幻影][9级]":
                        case "攻击元素[幻影][10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKanghuanbox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKanghuanbox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.XiangKanmofadun:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.QTKaikongy) != BaoshiMaEr.QTKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikonge) != BaoshiMaEr.QTKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikongs) != BaoshiMaEr.QTKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Weapon:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.XiangKanmofadunitems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "强化宝石[魔法盾]":
                        case "强化宝石[魔法盾][1级]":
                        case "强化宝石[魔法盾][2级]":
                        case "强化宝石[魔法盾][3级]":
                        case "强化宝石[魔法盾][4级]":
                        case "强化宝石[魔法盾][5级]":
                        case "强化宝石[魔法盾][6级]":
                        case "强化宝石[魔法盾][7级]":
                        case "强化宝石[魔法盾][8级]":
                        case "强化宝石[魔法盾][9级]":
                        case "强化宝石[魔法盾][10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKanmofadunbox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKanmofadunbox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.XiangKanbingdong:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.QTKaikongy) != BaoshiMaEr.QTKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikonge) != BaoshiMaEr.QTKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikongs) != BaoshiMaEr.QTKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Weapon:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.XiangKanbingdongitems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "强化宝石[冰冻伤害]":
                        case "强化宝石[冰冻伤害][1级]":
                        case "强化宝石[冰冻伤害][2级]":
                        case "强化宝石[冰冻伤害][3级]":
                        case "强化宝石[冰冻伤害][4级]":
                        case "强化宝石[冰冻伤害][5级]":
                        case "强化宝石[冰冻伤害][6级]":
                        case "强化宝石[冰冻伤害][7级]":
                        case "强化宝石[冰冻伤害][8级]":
                        case "强化宝石[冰冻伤害][9级]":
                        case "强化宝石[冰冻伤害][10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKanbingdongbox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKanbingdongbox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.XiangKanmabi:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.QTKaikongy) != BaoshiMaEr.QTKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikonge) != BaoshiMaEr.QTKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikongs) != BaoshiMaEr.QTKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Weapon:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.XiangKanmabiitems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "麻痹几率宝石":
                        case "麻痹几率宝石[1级]":
                        case "麻痹几率宝石[2级]":
                        case "麻痹几率宝石[3级]":
                        case "麻痹几率宝石[4级]":
                        case "麻痹几率宝石[5级]":
                        case "麻痹几率宝石[6级]":
                        case "麻痹几率宝石[7级]":
                        case "麻痹几率宝石[8级]":
                        case "麻痹几率宝石[9级]":
                        case "麻痹几率宝石[10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKanmabibox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKanmabibox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.XiangKanyidong:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.QTKaikongy) != BaoshiMaEr.QTKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikonge) != BaoshiMaEr.QTKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikongs) != BaoshiMaEr.QTKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Weapon:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.XiangKanyidongitems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "减速宝石":
                        case "减速宝石[1级]":
                        case "减速宝石[2级]":
                        case "减速宝石[3级]":
                        case "减速宝石[4级]":
                        case "减速宝石[5级]":
                        case "减速宝石[6级]":
                        case "减速宝石[7级]":
                        case "减速宝石[8级]":
                        case "减速宝石[9级]":
                        case "减速宝石[10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKanyidongbox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKanyidongbox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.XiangKanchenmo:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.QTKaikongy) != BaoshiMaEr.QTKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikonge) != BaoshiMaEr.QTKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikongs) != BaoshiMaEr.QTKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Weapon:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.XiangKanchenmoitems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "沉默宝石":
                        case "沉默宝石[1级]":
                        case "沉默宝石[2级]":
                        case "沉默宝石[3级]":
                        case "沉默宝石[4级]":
                        case "沉默宝石[5级]":
                        case "沉默宝石[6级]":
                        case "沉默宝石[7级]":
                        case "沉默宝石[8级]":
                        case "沉默宝石[9级]":
                        case "沉默宝石[10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKanchenmobox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKanchenmobox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.XiangKangedang:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.QTKaikongy) != BaoshiMaEr.QTKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikonge) != BaoshiMaEr.QTKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikongs) != BaoshiMaEr.QTKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Weapon:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.XiangKangedangitems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "格挡宝石":
                        case "格挡宝石[1级]":
                        case "格挡宝石[2级]":
                        case "格挡宝石[3级]":
                        case "格挡宝石[4级]":
                        case "格挡宝石[5级]":
                        case "格挡宝石[6级]":
                        case "格挡宝石[7级]":
                        case "格挡宝石[8级]":
                        case "格挡宝石[9级]":
                        case "格挡宝石[10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKangedangbox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKangedangbox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.XiangKanduobi:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.QTKaikongy) != BaoshiMaEr.QTKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikonge) != BaoshiMaEr.QTKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikongs) != BaoshiMaEr.QTKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Weapon:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.XiangKanduobiitems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "躲避宝石":
                        case "躲避宝石[1级]":
                        case "躲避宝石[2级]":
                        case "躲避宝石[3级]":
                        case "躲避宝石[4级]":
                        case "躲避宝石[5级]":
                        case "躲避宝石[6级]":
                        case "躲避宝石[7级]":
                        case "躲避宝石[8级]":
                        case "躲避宝石[9级]":
                        case "躲避宝石[10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKanduobibox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKanduobibox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.XiangKanqhuo:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.QTKaikongy) != BaoshiMaEr.QTKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikonge) != BaoshiMaEr.QTKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikongs) != BaoshiMaEr.QTKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Armour:
                        case ItemType.Shoes:
                        case ItemType.Helmet:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.XiangKanqhuoitems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "强元素[火]":
                        case "强元素[火][1级]":
                        case "强元素[火][2级]":
                        case "强元素[火][3级]":
                        case "强元素[火][4级]":
                        case "强元素[火][5级]":
                        case "强元素[火][6级]":
                        case "强元素[火][7级]":
                        case "强元素[火][8级]":
                        case "强元素[火][9级]":
                        case "强元素[火][10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKanqhuobox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKanqhuobox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.XiangKanqbing:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.QTKaikongy) != BaoshiMaEr.QTKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikonge) != BaoshiMaEr.QTKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikongs) != BaoshiMaEr.QTKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Armour:
                        case ItemType.Shoes:
                        case ItemType.Helmet:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.XiangKanqbingitems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "强元素[冰]":
                        case "强元素[冰][1级]":
                        case "强元素[冰][2级]":
                        case "强元素[冰][3级]":
                        case "强元素[冰][4级]":
                        case "强元素[冰][5级]":
                        case "强元素[冰][6级]":
                        case "强元素[冰][7级]":
                        case "强元素[冰][8级]":
                        case "强元素[冰][9级]":
                        case "强元素[冰][10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKanqbingbox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKanqbingbox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.XiangKanqlei:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.QTKaikongy) != BaoshiMaEr.QTKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikonge) != BaoshiMaEr.QTKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikongs) != BaoshiMaEr.QTKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Armour:
                        case ItemType.Shoes:
                        case ItemType.Helmet:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.XiangKanqleiitems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "强元素[雷]":
                        case "强元素[雷][1级]":
                        case "强元素[雷][2级]":
                        case "强元素[雷][3级]":
                        case "强元素[雷][4级]":
                        case "强元素[雷][5级]":
                        case "强元素[雷][6级]":
                        case "强元素[雷][7级]":
                        case "强元素[雷][8级]":
                        case "强元素[雷][9级]":
                        case "强元素[雷][10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKanqleibox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKanqleibox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.XiangKanqfeng:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.QTKaikongy) != BaoshiMaEr.QTKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikonge) != BaoshiMaEr.QTKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikongs) != BaoshiMaEr.QTKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Armour:
                        case ItemType.Shoes:
                        case ItemType.Helmet:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.XiangKanqfengitems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "强元素[风]":
                        case "强元素[风][1级]":
                        case "强元素[风][2级]":
                        case "强元素[风][3级]":
                        case "强元素[风][4级]":
                        case "强元素[风][5级]":
                        case "强元素[风][6级]":
                        case "强元素[风][7级]":
                        case "强元素[风][8级]":
                        case "强元素[风][9级]":
                        case "强元素[风][10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKanqfengbox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKanqfengbox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.XiangKanqshen:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.QTKaikongy) != BaoshiMaEr.QTKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikonge) != BaoshiMaEr.QTKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikongs) != BaoshiMaEr.QTKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Armour:
                        case ItemType.Shoes:
                        case ItemType.Helmet:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.XiangKanqshenitems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "强元素[神圣]":
                        case "强元素[神圣][1级]":
                        case "强元素[神圣][2级]":
                        case "强元素[神圣][3级]":
                        case "强元素[神圣][4级]":
                        case "强元素[神圣][5级]":
                        case "强元素[神圣][6级]":
                        case "强元素[神圣][7级]":
                        case "强元素[神圣][8级]":
                        case "强元素[神圣][9级]":
                        case "强元素[神圣][10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKanqshenbox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKanqshenbox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.XiangKanqan:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.QTKaikongy) != BaoshiMaEr.QTKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikonge) != BaoshiMaEr.QTKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikongs) != BaoshiMaEr.QTKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Armour:
                        case ItemType.Shoes:
                        case ItemType.Helmet:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.XiangKanqanitems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "强元素[暗黑]":
                        case "强元素[暗黑][1级]":
                        case "强元素[暗黑][2级]":
                        case "强元素[暗黑][3级]":
                        case "强元素[暗黑][4级]":
                        case "强元素[暗黑][5级]":
                        case "强元素[暗黑][6级]":
                        case "强元素[暗黑][7级]":
                        case "强元素[暗黑][8级]":
                        case "强元素[暗黑][9级]":
                        case "强元素[暗黑][10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKanqanbox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKanqanbox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.XiangKanqhuan:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.QTKaikongy) != BaoshiMaEr.QTKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikonge) != BaoshiMaEr.QTKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikongs) != BaoshiMaEr.QTKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Armour:
                        case ItemType.Shoes:
                        case ItemType.Helmet:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.XiangKanqhuanitems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "强元素[幻影]":
                        case "强元素[幻影][1级]":
                        case "强元素[幻影][2级]":
                        case "强元素[幻影][3级]":
                        case "强元素[幻影][4级]":
                        case "强元素[幻影][5级]":
                        case "强元素[幻影][6级]":
                        case "强元素[幻影][7级]":
                        case "强元素[幻影][8级]":
                        case "强元素[幻影][9级]":
                        case "强元素[幻影][10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKanqhuanbox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKanqhuanbox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.XiangKanlvdu:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.QTKaikongy) != BaoshiMaEr.QTKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikonge) != BaoshiMaEr.QTKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikongs) != BaoshiMaEr.QTKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        
                        case ItemType.Shoes:
                        
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.XiangKanlvduitems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "绿毒宝石":
                        case "绿毒宝石[1级]":
                        case "绿毒宝石[2级]":
                        case "绿毒宝石[3级]":
                        case "绿毒宝石[4级]":
                        case "绿毒宝石[5级]":
                        case "绿毒宝石[6级]":
                        case "绿毒宝石[7级]":
                        case "绿毒宝石[8级]":
                        case "绿毒宝石[9级]":
                        case "绿毒宝石[10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKanlvdubox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKanlvdubox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.XiangKanzym:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.QTKaikongy) != BaoshiMaEr.QTKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikonge) != BaoshiMaEr.QTKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikongs) != BaoshiMaEr.QTKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Weapon:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.XiangKanzymitems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "真炎魔宝石":
                        case "真炎魔宝石[1级]":
                        case "真炎魔宝石[2级]":
                        case "真炎魔宝石[3级]":
                        case "真炎魔宝石[4级]":
                        case "真炎魔宝石[5级]":
                        case "真炎魔宝石[6级]":
                        case "真炎魔宝石[7级]":
                        case "真炎魔宝石[8级]":
                        case "真炎魔宝石[9级]":
                        case "真炎魔宝石[10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKanzymbox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKanzymbox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.XiangKanmhhf:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.QTKaikongy) != BaoshiMaEr.QTKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikonge) != BaoshiMaEr.QTKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.QTKaikongs) != BaoshiMaEr.QTKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Shoes:
                            break;
                        default:
                            return false;
                    }
                    
                    
                    break;
                case GridType.XiangKanmhhfitems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "灭魂宝石":
                        case "灭魂宝石[1级]":
                        case "灭魂宝石[2级]":
                        case "灭魂宝石[3级]":
                        case "灭魂宝石[4级]":
                        case "灭魂宝石[5级]":
                        case "灭魂宝石[6级]":
                        case "灭魂宝石[7级]":
                        case "灭魂宝石[8级]":
                        case "灭魂宝石[9级]":
                        case "灭魂宝石[10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKanmhhfbox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKanmhhfbox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                
                case GridType.XiangKanjinglian:
                    
                    if ((Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.Kaikongxxs) != BaoshiMaEr.Kaikongxxs) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    if ((Item.BaoshiMaEr & BaoshiMaEr.GZLKaikongy) != BaoshiMaEr.GZLKaikongy & (Item.BaoshiMaEr & BaoshiMaEr.GZLKaikonge) != BaoshiMaEr.GZLKaikonge & (Item.BaoshiMaEr & BaoshiMaEr.GZLKaikongs) != BaoshiMaEr.GZLKaikongs) return false;
                    

                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Shizhuang:
                            break;
                        default:
                            return false;
                    }
                    break;
                
                case GridType.XiangKanjinglianitems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    
                    switch (Item.Info.ItemName)
                    {
                        case "精炼宝石":
                        case "精炼宝石[1级]":
                        case "精炼宝石[2级]":
                        case "精炼宝石[3级]":
                        case "精炼宝石[4级]":
                        case "精炼宝石[5级]":
                        case "精炼宝石[6级]":
                        case "精炼宝石[7级]":
                        case "精炼宝石[8级]":
                        case "精炼宝石[9级]":
                        case "精炼宝石[10级]":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCXiangKanjinglianBox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCXiangKanjinglianBox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                
                case GridType.Huanhua:
                    if ((Item.BaoshiMaYi & BaoshiMaYi.XiangKanXXY) == BaoshiMaYi.XiangKanXXY || (Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXE) == BaoshiMaEr.XiangKanXXE || (Item.BaoshiMaEr & BaoshiMaEr.XiangKanXXS) == BaoshiMaEr.XiangKanXXS) return false;
                    if ((Item.BaoshiMaShisan & BaoshiMaShisan.Huanhua) == BaoshiMaShisan.Huanhua) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;


                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Necklace:
                        case ItemType.Bracelet:
                        case ItemType.Ring:
                        case ItemType.Armour:
                        case ItemType.Shoes:
                        case ItemType.Helmet:
                        case ItemType.Weapon:
                        case ItemType.Shizhuang:
                            break;
                        default:
                            return false;
                    }
                    break;
                
                case GridType.Huanhuaitems:
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage) return false;
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    switch (Item.Info.ItemName)
                    {
                        case "装备幻化卷":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCHuanhuaBox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) == UserItemFlags.Bound && (GameScene.Game.NPCHuanhuaBox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;
                case GridType.Zhongzi:
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType == GridType.Equipment && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    switch (Item.Info.ItemType)
                    {
                        case ItemType.Fabao:
                            break;
                        default:
                            return false;
                    }
                    break;
                case GridType.ZhongziItems:
                    if ((Item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;
                    if ((Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked) return false;
                    if (GridType != GridType.Inventory && GridType != GridType.CompanionInventory && GridType != GridType.Storage) return false;
                    switch (Item.Info.ItemName)
                    {
                        case "攻击种子":
                        case "自然种子":
                        case "灵魂种子":
                        case "生命种子":
                        case "魔法种子":
                            break;
                        default:
                            return false;
                    }
                    if (GameScene.Game.NPCZhongziBox.TargetCell.Grid[0].Link?.Item?.Info == Item.Info) return false;
                    if ((Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound && (GameScene.Game.NPCZhongziBox.TargetCell.Grid[0].Link.Item.Flags & UserItemFlags.Bound) != UserItemFlags.Bound) return true;
                    break;


            }
            return true;
        }
        public bool UseItem()
        {
            if (Item == null || Locked || ReadOnly || SelectedCell == this || (!Linked && Link != null) || !GameScene.Game.CanUseItem(Item) || GameScene.Game.Observer) return false;
            if (GridType == GridType.Belt || GridType == GridType.Belt)
            {
                DXItemCell cell;
                if (QuickInfo != null)
                {
                    cell = GameScene.Game.InventoryBox.Grid.Grid.FirstOrDefault(x => x?.Item?.Info == QuickInfo) ??
                           GameScene.Game.CompanionBox.InventoryGrid?.Grid.FirstOrDefault(x => x?.Item?.Info == QuickInfo);
                }
                else
                    cell = GameScene.Game.InventoryBox.Grid.Grid.FirstOrDefault(x => x?.Item == QuickItem);


                return cell?.UseItem() == true;
            }
            switch (Item.Info.ItemType)
            {
                case ItemType.Weapon:
                    GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Weapon].ToEquipment(this);
                    break;
                case ItemType.Armour:
                    GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Armour].ToEquipment(this);
                    break;
                
                case ItemType.Shizhuang:
                    GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Shizhuang].ToEquipment(this);
                    break;
                case ItemType.Torch:
                    GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Torch].ToEquipment(this);
                    break;
                case ItemType.Helmet:
                    GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Helmet].ToEquipment(this);
                    break;
                case ItemType.Necklace:
                    GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Necklace].ToEquipment(this);
                    break;
                case ItemType.Bracelet:
                    if (GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.BraceletL].Item == null)
                        GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.BraceletL].ToEquipment(this);
                    else
                        GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.BraceletR].ToEquipment(this);
                    break;
                case ItemType.Ring:
                    if (GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.RingL].Item == null)
                        GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.RingL].ToEquipment(this);
                    else
                        GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.RingR].ToEquipment(this);
                    break;
                case ItemType.Shoes:
                    GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Shoes].ToEquipment(this);
                    break;
                case ItemType.Poison:
                    GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Poison].ToEquipment(this);
                    break;
                case ItemType.Amulet:
                case ItemType.DarkStone:
                    GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Amulet].ToEquipment(this);
                    break;
                case ItemType.Flower:
                    GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Flower].ToEquipment(this);
                    break;
                case ItemType.Emblem:
                    GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Emblem].ToEquipment(this);
                    break;
                case ItemType.Shield:
                    GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Shield].ToEquipment(this);
                    break;
                
                case ItemType.SwChenghao:
                    GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.SwChenghao].ToEquipment(this);
                    break;
                
                case ItemType.Fabao:
                    GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Fabao].ToEquipment(this);
                    break;
                case ItemType.HorseArmour:
                    GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.HorseArmour].ToEquipment(this);
                    break;
                case ItemType.CompanionBag:
                    if (GameScene.Game.Companion != null)
                        GameScene.Game.CompanionBox.EquipmentGrid[(int)CompanionSlot.Bag].ToEquipment(this);
                    break;
                case ItemType.CompanionHead:
                    if (GameScene.Game.Companion != null)
                        GameScene.Game.CompanionBox.EquipmentGrid[(int)CompanionSlot.Head].ToEquipment(this);
                    break;
                case ItemType.CompanionBack:
                    if (GameScene.Game.Companion != null)
                        GameScene.Game.CompanionBox.EquipmentGrid[(int)CompanionSlot.Back].ToEquipment(this);
                    break;
                case ItemType.Consumable:
                case ItemType.Scroll:
                case ItemType.CompanionFood:
                case ItemType.ItemPart:
                    if (!GameScene.Game.CanUseItem(Item) ||
                        GridType != GridType.Inventory && GridType != GridType.CompanionEquipment && GridType != GridType.CompanionInventory && GridType != GridType.PatchGrid) return false;
                    if ((CEnvir.Now < GameScene.Game.UseItemTime && Item.Info.Effect != ItemEffect.ElixirOfPurification)) return false;
                    
                    if (MapObject.User.Horse != HorseType.None)
                    {
                        
                        GameScene.Game.ReceiveChat("骑行状态无法使用任何物品", MessageType.System);
                        return false;
                    }
                    GameScene.Game.UseItemTime = CEnvir.Now.AddMilliseconds(Math.Max(250, Item.Info.Durability));

                    Locked = true;
                    CEnvir.Enqueue(new C.ItemUse { Link = new CellLinkInfo { GridType = GridType, Slot = Slot, Count = 1 } });
                    PlayItemSound();
                    break;
                case ItemType.Book:
                    if (!GameScene.Game.CanUseItem(Item) || GridType != GridType.Inventory) return false;
                    if (CEnvir.Now < GameScene.Game.UseItemTime || MapObject.User.Horse != HorseType.None) return false;

                    GameScene.Game.UseItemTime = CEnvir.Now.AddMilliseconds(250);
                    Locked = true;
                    CEnvir.Enqueue(new C.ItemUse { Link = new CellLinkInfo { GridType = GridType, Slot = Slot, Count = 1 } });
                    PlayItemSound();
                    break;
                case ItemType.System:
                    if (!GameScene.Game.CanUseItem(Item) || GridType != GridType.Inventory) return false;
                    switch (Item.Info.Effect)
                    {
                        case ItemEffect.GenderChange:
                            if (GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Armour].Item != null || GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Shizhuang].Item != null)
                            {
                                GameScene.Game.ReceiveChat("你穿着衣服或者穿着时装无法改变性别.", MessageType.System);
                                return false;
                            }
                            GameScene.Game.EditCharacterBox.Visible = true;
                            GameScene.Game.EditCharacterBox.SelectedClass = GameScene.Game.User.Class;
                            GameScene.Game.EditCharacterBox.SelectedGender = GameScene.Game.User.Gender;
                            GameScene.Game.EditCharacterBox.HairColour.BackColour = GameScene.Game.User.HairColour;
                            GameScene.Game.EditCharacterBox.HairNumberBox.Value = GameScene.Game.User.HairType;
                            GameScene.Game.EditCharacterBox.Change = ChangeType.GenderChange;
                            break;
                        case ItemEffect.ClassChange:
                            if (!MapObject.User.InSafeZone)
                            {
                                GameScene.Game.ReceiveChat("你在非安全区域无法使用", MessageType.System);
                                return false;
                            }
                            if (GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Weapon].Item != null
                                || GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Armour].Item != null
                                || GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Helmet].Item != null
                                || GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Torch].Item != null
                                || GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Necklace].Item != null
                                || GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.BraceletL].Item != null
                                || GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.BraceletR].Item != null
                                || GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.RingL].Item != null
                                || GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.RingR].Item != null
                                || GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Shoes].Item != null
                                || GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Poison].Item != null
                                || GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Amulet].Item != null
                                || GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Flower].Item != null
                                || GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.HorseArmour].Item != null
                                || GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Emblem].Item != null
                                || GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Shield].Item != null
                                || GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Shizhuang].Item != null
                                || GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Fabao].Item != null)
                            {
                                GameScene.Game.ReceiveChat("你身上的所有装备取消后再试一试", MessageType.System);
                                return false;
                            }

                            GameScene.Game.EditCharacterBox.Visible = true;
                            GameScene.Game.EditCharacterBox.SelectedClass = GameScene.Game.User.Class;
                            GameScene.Game.EditCharacterBox.SelectedGender = GameScene.Game.User.Gender;
                            GameScene.Game.EditCharacterBox.HairColour.BackColour = GameScene.Game.User.HairColour;
                            GameScene.Game.EditCharacterBox.HairNumberBox.Value = GameScene.Game.User.HairType;
                            GameScene.Game.EditCharacterBox.Change = ChangeType.ClassChange;
                            break;
                        case ItemEffect.HairChange:
                            GameScene.Game.EditCharacterBox.Visible = true;
                            GameScene.Game.EditCharacterBox.SelectedClass = GameScene.Game.User.Class;
                            GameScene.Game.EditCharacterBox.SelectedGender = GameScene.Game.User.Gender;
                            GameScene.Game.EditCharacterBox.HairColour.BackColour = GameScene.Game.User.HairColour;
                            GameScene.Game.EditCharacterBox.HairNumberBox.Value = GameScene.Game.User.HairType;
                            GameScene.Game.EditCharacterBox.Change = ChangeType.HairChange;
                            if (GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Armour].Item != null)
                                GameScene.Game.EditCharacterBox.ArmourColour.BackColour = GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Armour].Item.Colour;
                            break;
                        case ItemEffect.ArmourDye:
                            if (GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Armour].Item == null)
                            {
                                GameScene.Game.ReceiveChat("你需要穿上衣服才能染上颜色.", MessageType.System);
                                return false;
                            }
                            GameScene.Game.EditCharacterBox.Visible = true;
                            GameScene.Game.EditCharacterBox.SelectedClass = GameScene.Game.User.Class;
                            GameScene.Game.EditCharacterBox.SelectedGender = GameScene.Game.User.Gender;
                            GameScene.Game.EditCharacterBox.HairColour.BackColour = GameScene.Game.User.HairColour;
                            GameScene.Game.EditCharacterBox.HairNumberBox.Value = GameScene.Game.User.HairType;
                            GameScene.Game.EditCharacterBox.Change = ChangeType.ArmourDye;
                            GameScene.Game.EditCharacterBox.ArmourColour.BackColour = GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Armour].Item.Colour;
                            break;
                        case ItemEffect.NameChange:
                            GameScene.Game.EditCharacterBox.Visible = true;
                            GameScene.Game.EditCharacterBox.SelectedClass = GameScene.Game.User.Class;
                            GameScene.Game.EditCharacterBox.SelectedGender = GameScene.Game.User.Gender;
                            GameScene.Game.EditCharacterBox.HairColour.BackColour = GameScene.Game.User.HairColour;
                            GameScene.Game.EditCharacterBox.HairNumberBox.Value = GameScene.Game.User.HairType;
                            if (GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Armour].Item != null)
                                GameScene.Game.EditCharacterBox.ArmourColour.BackColour = GameScene.Game.CharacterBox.Grid[(int)EquipmentSlot.Armour].Item.Colour;
                            GameScene.Game.EditCharacterBox.Change = ChangeType.NameChange;

                            GameScene.Game.EditCharacterBox.CharacterNameTextBox.TextBox.Text = GameScene.Game.User.Name;
                            break;
                            
                        case ItemEffect.Teleport:
                            GameScene.Game.TeleportBox.Visible = true;
                            break;
                        
                        case ItemEffect.TeleportHD:
                            GameScene.Game.TeleportBox.Visible = true;
                            break;
                        case ItemEffect.FortuneChecker:
                            GameScene.Game.FortuneCheckerBox.Visible = true;
                            break;
                    }
                    break;
            }
            return true;
        }
        private void PlayItemSound()
        {
            if (Item == null) return;
            switch (Item.Info.ItemType)
            {
                case ItemType.Weapon:
                    DXSoundManager.Play(SoundIndex.ItemWeapon);
                    break;
                case ItemType.Armour:
                case ItemType.Shizhuang:
                    DXSoundManager.Play(SoundIndex.ItemArmour);
                    break;
                case ItemType.Helmet:
                    DXSoundManager.Play(SoundIndex.ItemHelmet);
                    break;
                case ItemType.Necklace:
                    DXSoundManager.Play(SoundIndex.ItemNecklace);
                    break;
                case ItemType.Bracelet:
                    DXSoundManager.Play(SoundIndex.ItemBracelet);
                    break;
                case ItemType.Fabao:
                case ItemType.Ring:
                    DXSoundManager.Play(SoundIndex.ItemRing);
                    break;
                case ItemType.Shoes:
                    DXSoundManager.Play(SoundIndex.ItemShoes);
                    break;
                case ItemType.Consumable:
                    DXSoundManager.Play(Item.Info.ShapeNum > 0 ? SoundIndex.ItemDefault : SoundIndex.ItemPotion);
                    break;
                default:
                    DXSoundManager.Play(SoundIndex.ItemDefault);
                    break;
            }
        }
        public override void OnMouseEnter()
        {
            base.OnMouseEnter();
            GameScene.Game.MouseItem = Item;
            if (Item != null)
                Item.New = false;
            UpdateBorder();
        }
        public override void OnMouseLeave()
        {
            base.OnMouseLeave();
            GameScene.Game.MouseItem = null;
            UpdateBorder();
        }
        public override void OnMouseClick(MouseEventArgs e)
        {
            if (Locked || GameScene.Game.GoldPickedUp || (!Linked && Link != null) || GameScene.Game.Observer) return;
            base.OnMouseClick(e);

            if (ReadOnly || !Enabled) return;

            if (Linked && Link != null)
            {
                Link = null;
                if (SelectedCell == null)
                    return;
            }

            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (CEnvir.Alt)
                    {
                        
                        return;
                    }
                    
                    if (CEnvir.Ctrl)
                    {
                        if (Item != null)
                        {
                            GameScene.Game.ChatTextBox.AddItem(Item);
                        }
                        return;
                    }
                    if (CEnvir.Shift)
                    {
                        if (Item == null || (GridType != GridType.Inventory && GridType != GridType.Storage && GridType != GridType.GuildStorage && GridType != GridType.CompanionInventory && GridType != GridType.PatchGrid && GridType != GridType.BaoshiItems) || Item.Count <= 1) return;
                        DXItemAmountWindow window = new DXItemAmountWindow("道具分解", Item);

                        window.ConfirmButton.MouseClick += (o, e1) =>
                        {
                            Locked = true;
                            CEnvir.Enqueue(new C.ItemSplit { Grid = GridType, Slot = Slot, Count = window.Amount });
                        };

                        return;
                    }
                  
                    if (Item != null && SelectedCell == null)
                        PlayItemSound();

                    MoveItem();
                    break;
                case MouseButtons.Middle:
                    if (Item != null)
                        CEnvir.Enqueue(new C.ItemLock { GridType = GridType, SlotIndex = Slot, Locked = (Item.Flags & UserItemFlags.Locked) != UserItemFlags.Locked });
                    break;
                case MouseButtons.Right:


                    switch (GridType)
                    {
                        case GridType.Belt:
                        case GridType.AutoPotion:
                            if (Item == null) return;
                            UseItem(); 
                            break;
                        case GridType.Inventory:
                            if (Item == null) return;
                            if (GameScene.Game.NPCRepairBox.IsVisible)
                            {
                                if (Item.CurrentDurability >= Item.MaxDurability || !Item.Info.CanRepair)
                                    GameScene.Game.ReceiveChat($"无法修复 {Item.Info.ItemName}, 它已经修好了.", MessageType.System);
                                else if (!MoveItem(GameScene.Game.NPCRepairBox.Grid))
                                    GameScene.Game.ReceiveChat($"在这里无法修复 {Item.Info.ItemName} .", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCSellBox.IsVisible)
                            {
                                if (!Item.Info.CanSell)
                                    GameScene.Game.ReceiveChat($"无法出售 {Item.Info.ItemName}, 它不能出售.", MessageType.System);
                                else if (!MoveItem(GameScene.Game.NPCSellBox.Grid))
                                    GameScene.Game.ReceiveChat($"在这里无法出售 {Item.Info.ItemName} .", MessageType.System);
                                return;
                            }
                            
                            if (GameScene.Game.NPCJyhuishouBox.IsVisible)
                            {
                                if (!Item.Info.CanJyChange || Item.Info.ItemType == ItemType.Ore || Item.Info.ItemType == ItemType.Nothing)
                                    GameScene.Game.ReceiveChat($"无法经验回收 {Item.Info.ItemName}, 它不能回收.", MessageType.System);
                                else if (!MoveItem(GameScene.Game.NPCJyhuishouBox.Grid))
                                    GameScene.Game.ReceiveChat($"在这里无法回收 {Item.Info.ItemName} .", MessageType.System);
                                return;
                            }
                            
                            if (GameScene.Game.NPCGuildhuishouBox.IsVisible)
                            {
                                if (!Item.Info.CanJyChange)
                                    GameScene.Game.ReceiveChat($"无法贡献回收 {Item.Info.ItemName}, 它不能回收.", MessageType.System);
                                else if (!MoveItem(GameScene.Game.NPCGuildhuishouBox.Grid))
                                    GameScene.Game.ReceiveChat($"在这里无法回收 {Item.Info.ItemName} .", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCMasterRefineBox.IsVisible)
                            {
                                switch (Item.Info.Effect)
                                {
                                    case ItemEffect.Fragment1:
                                        if (MoveItem(GameScene.Game.NPCMasterRefineBox.Fragment1Grid))
                                            return;
                                        break;
                                    case ItemEffect.Fragment2:
                                        if (MoveItem(GameScene.Game.NPCMasterRefineBox.Fragment2Grid))
                                            return;
                                        break;
                                    case ItemEffect.Fragment3:
                                        if (MoveItem(GameScene.Game.NPCMasterRefineBox.Fragment3Grid))
                                            return;
                                        break;
                                    case ItemEffect.RefinementStone:
                                        if (MoveItem(GameScene.Game.NPCMasterRefineBox.RefinementStoneGrid))
                                            return;
                                        break;
                                }
                                switch (Item.Info.ItemType)
                                {
                                    case ItemType.RefineSpecial:
                                        if (MoveItem(GameScene.Game.NPCMasterRefineBox.SpecialGrid))
                                            return;
                                        break;
                                }
                                GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 精炼.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCRefinementStoneBox.IsVisible)
                            {
                                switch (Item.Info.Effect)
                                {
                                    case ItemEffect.IronOre:
                                        MoveItem(GameScene.Game.NPCRefinementStoneBox.IronOreGrid);
                                        return;
                                    case ItemEffect.SilverOre:
                                        MoveItem(GameScene.Game.NPCRefinementStoneBox.SilverOreGrid);
                                        return;
                                    case ItemEffect.Diamond:
                                        MoveItem(GameScene.Game.NPCRefinementStoneBox.DiamondGrid);
                                        return;
                                    case ItemEffect.GoldOre:
                                        MoveItem(GameScene.Game.NPCRefinementStoneBox.GoldOreGrid);
                                        return;
                                    case ItemEffect.Crystal:
                                        MoveItem(GameScene.Game.NPCRefinementStoneBox.CrystalGrid);
                                        return;
                                }
                                GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 合成精炼石", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCWeaponCraftBox.IsVisible)
                            {
                                switch (Item.Info.Effect)
                                {
                                    case ItemEffect.WeaponTemplate:
                                        MoveItem(GameScene.Game.NPCWeaponCraftBox.TemplateCell);
                                        return;
                                    case ItemEffect.YellowSlot:
                                        MoveItem(GameScene.Game.NPCWeaponCraftBox.YellowCell);
                                        return;
                                    case ItemEffect.BlueSlot:
                                        MoveItem(GameScene.Game.NPCWeaponCraftBox.BlueCell);
                                        return;
                                    case ItemEffect.RedSlot:
                                        MoveItem(GameScene.Game.NPCWeaponCraftBox.RedCell);
                                        return;
                                    case ItemEffect.PurpleSlot:
                                        MoveItem(GameScene.Game.NPCWeaponCraftBox.PurpleCell);
                                        return;
                                    case ItemEffect.GreenSlot:
                                        MoveItem(GameScene.Game.NPCWeaponCraftBox.GreenCell);
                                        return;
                                    case ItemEffect.GreySlot:
                                        MoveItem(GameScene.Game.NPCWeaponCraftBox.GreyCell);
                                        return;
                                }
                                switch (Item.Info.ItemType)
                                {
                                    case ItemType.Weapon:
                                        MoveItem(GameScene.Game.NPCWeaponCraftBox.TemplateCell);
                                        return;
                                }
                                GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 制造.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCItemFragmentBox.IsVisible)
                            {
                                if (!Item.CanFragment())
                                    GameScene.Game.ReceiveChat($"无法分解 {Item.Info.ItemName}, 它不能分解成碎片.", MessageType.System);
                                else MoveItem(GameScene.Game.NPCItemFragmentBox.Grid);

                                return;
                            }
                            
                            if (GameScene.Game.NPCItemZaixianFragmentBox.IsVisible)
                            {
                                if (!Item.CanFragment())
                                    GameScene.Game.ReceiveChat($"无法分解 {Item.Info.ItemName}, 它不能分解成碎片.", MessageType.System);
                                else MoveItem(GameScene.Game.NPCItemZaixianFragmentBox.Grid);

                                return;
                            }
                            
                            if (GameScene.Game.NPCXiaohuiBox.IsVisible)
                            {
                                switch (Item.Info.ItemType)
                                {
                                    case ItemType.Consumable:
                                    case ItemType.Weapon:
                                    case ItemType.Armour:
                                    case ItemType.Torch:
                                    case ItemType.Helmet:
                                    case ItemType.Necklace:
                                    case ItemType.Bracelet:
                                    case ItemType.Ring:
                                    case ItemType.Shoes:
                                    case ItemType.Poison:
                                    case ItemType.Amulet:
                                    case ItemType.Meat:
                                    case ItemType.Ore:
                                    case ItemType.Book:
                                    case ItemType.Scroll:
                                    case ItemType.DarkStone:
                                    case ItemType.RefineSpecial:
                                    case ItemType.HorseArmour:
                                    case ItemType.Flower:
                                    case ItemType.CompanionFood:
                                    case ItemType.CompanionBag:
                                    case ItemType.CompanionHead:
                                    case ItemType.CompanionBack:
                                    case ItemType.System:
                                    case ItemType.ItemPart:
                                    case ItemType.Emblem:
                                    case ItemType.Shield:
                                    case ItemType.Baoshi:
                                    case ItemType.Shizhuang:
                                    case ItemType.Fabao:
                                        MoveItem(GameScene.Game.NPCXiaohuiBox.Grid);
                                        return;
                                }
                                GameScene.Game.ReceiveChat($"无法销毁 {Item.Info.ItemName}", MessageType.System);
                                return;
                            }
                            
                            if (GameScene.Game.NPCBShechengBox.IsVisible)
                            {
                                switch (Item.Info.ItemName)
                                {
                                    case "攻击宝石":
                                    case "攻击宝石[1级]":
                                    case "攻击宝石[2级]":
                                    case "攻击宝石[3级]":
                                    case "攻击宝石[4级]":
                                    case "攻击宝石[5级]":
                                    case "攻击宝石[6级]":
                                    case "攻击宝石[7级]":
                                    case "攻击宝石[8级]":
                                    case "攻击宝石[9级]":
                                    case "攻击宝石[10级]":
                                    case "攻击几率宝石":
                                    case "攻击几率宝石[1级]":
                                    case "攻击几率宝石[2级]":
                                    case "攻击几率宝石[3级]":
                                    case "攻击几率宝石[4级]":
                                    case "攻击几率宝石[5级]":
                                    case "攻击几率宝石[6级]":
                                    case "攻击几率宝石[7级]":
                                    case "攻击几率宝石[8级]":
                                    case "攻击几率宝石[9级]":
                                    case "攻击几率宝石[10级]":
                                    case "自然宝石":
                                    case "自然宝石[1级]":
                                    case "自然宝石[2级]":
                                    case "自然宝石[3级]":
                                    case "自然宝石[4级]":
                                    case "自然宝石[5级]":
                                    case "自然宝石[6级]":
                                    case "自然宝石[7级]":
                                    case "自然宝石[8级]":
                                    case "自然宝石[9级]":
                                    case "自然宝石[10级]":
                                    case "自然几率宝石":
                                    case "自然几率宝石[1级]":
                                    case "自然几率宝石[2级]":
                                    case "自然几率宝石[3级]":
                                    case "自然几率宝石[4级]":
                                    case "自然几率宝石[5级]":
                                    case "自然几率宝石[6级]":
                                    case "自然几率宝石[7级]":
                                    case "自然几率宝石[8级]":
                                    case "自然几率宝石[9级]":
                                    case "自然几率宝石[10级]":
                                    case "灵魂宝石":
                                    case "灵魂宝石[1级]":
                                    case "灵魂宝石[2级]":
                                    case "灵魂宝石[3级]":
                                    case "灵魂宝石[4级]":
                                    case "灵魂宝石[5级]":
                                    case "灵魂宝石[6级]":
                                    case "灵魂宝石[7级]":
                                    case "灵魂宝石[8级]":
                                    case "灵魂宝石[9级]":
                                    case "灵魂宝石[10级]":
                                    case "灵魂几率宝石":
                                    case "灵魂几率宝石[1级]":
                                    case "灵魂几率宝石[2级]":
                                    case "灵魂几率宝石[3级]":
                                    case "灵魂几率宝石[4级]":
                                    case "灵魂几率宝石[5级]":
                                    case "灵魂几率宝石[6级]":
                                    case "灵魂几率宝石[7级]":
                                    case "灵魂几率宝石[8级]":
                                    case "灵魂几率宝石[9级]":
                                    case "灵魂几率宝石[10级]":
                                    case "生命宝石":
                                    case "生命宝石[1级]":
                                    case "生命宝石[2级]":
                                    case "生命宝石[3级]":
                                    case "生命宝石[4级]":
                                    case "生命宝石[5级]":
                                    case "生命宝石[6级]":
                                    case "生命宝石[7级]":
                                    case "生命宝石[8级]":
                                    case "生命宝石[9级]":
                                    case "生命宝石[10级]":
                                    case "魔法宝石":
                                    case "魔法宝石[1级]":
                                    case "魔法宝石[2级]":
                                    case "魔法宝石[3级]":
                                    case "魔法宝石[4级]":
                                    case "魔法宝石[5级]":
                                    case "魔法宝石[6级]":
                                    case "魔法宝石[7级]":
                                    case "魔法宝石[8级]":
                                    case "魔法宝石[9级]":
                                    case "魔法宝石[10级]":
                                    case "速度宝石":
                                    case "速度宝石[1级]":
                                    case "速度宝石[2级]":
                                    case "速度宝石[3级]":
                                    case "速度宝石[4级]":
                                    case "速度宝石[5级]":
                                    case "速度宝石[6级]":
                                    case "速度宝石[7级]":
                                    case "速度宝石[8级]":
                                    case "速度宝石[9级]":
                                    case "速度宝石[10级]":
                                    case "防御宝石":
                                    case "防御宝石[1级]":
                                    case "防御宝石[2级]":
                                    case "防御宝石[3级]":
                                    case "防御宝石[4级]":
                                    case "防御宝石[5级]":
                                    case "防御宝石[6级]":
                                    case "防御宝石[7级]":
                                    case "防御宝石[8级]":
                                    case "防御宝石[9级]":
                                    case "防御宝石[10级]":
                                    case "魔御宝石":
                                    case "魔御宝石[1级]":
                                    case "魔御宝石[2级]":
                                    case "魔御宝石[3级]":
                                    case "魔御宝石[4级]":
                                    case "魔御宝石[5级]":
                                    case "魔御宝石[6级]":
                                    case "魔御宝石[7级]":
                                    case "魔御宝石[8级]":
                                    case "魔御宝石[9级]":
                                    case "魔御宝石[10级]":
                                    case "经验宝石":
                                    case "经验宝石[1级]":
                                    case "经验宝石[2级]":
                                    case "经验宝石[3级]":
                                    case "经验宝石[4级]":
                                    case "经验宝石[5级]":
                                    case "经验宝石[6级]":
                                    case "经验宝石[7级]":
                                    case "经验宝石[8级]":
                                    case "经验宝石[9级]":
                                    case "经验宝石[10级]":
                                    /*
                                    case "吸血宝石":
                                    case "吸血宝石[1级]":
                                    case "吸血宝石[2级]":
                                    case "吸血宝石[3级]":
                                    case "吸血宝石[4级]":
                                    case "吸血宝石[5级]":
                                    case "吸血宝石[6级]":
                                    case "吸血宝石[7级]":
                                    case "吸血宝石[8级]":
                                    case "吸血宝石[9级]":
                                    case "吸血宝石[10级]":
                                    */
                                    case "攻击元素[火]":
                                    case "攻击元素[火][1级]":
                                    case "攻击元素[火][2级]":
                                    case "攻击元素[火][3级]":
                                    case "攻击元素[火][4级]":
                                    case "攻击元素[火][5级]":
                                    case "攻击元素[火][6级]":
                                    case "攻击元素[火][7级]":
                                    case "攻击元素[火][8级]":
                                    case "攻击元素[火][9级]":
                                    case "攻击元素[火][10级]":
                                    case "攻击元素[冰]":
                                    case "攻击元素[冰][1级]":
                                    case "攻击元素[冰][2级]":
                                    case "攻击元素[冰][3级]":
                                    case "攻击元素[冰][4级]":
                                    case "攻击元素[冰][5级]":
                                    case "攻击元素[冰][6级]":
                                    case "攻击元素[冰][7级]":
                                    case "攻击元素[冰][8级]":
                                    case "攻击元素[冰][9级]":
                                    case "攻击元素[冰][10级]":
                                    case "攻击元素[雷]":
                                    case "攻击元素[雷][1级]":
                                    case "攻击元素[雷][2级]":
                                    case "攻击元素[雷][3级]":
                                    case "攻击元素[雷][4级]":
                                    case "攻击元素[雷][5级]":
                                    case "攻击元素[雷][6级]":
                                    case "攻击元素[雷][7级]":
                                    case "攻击元素[雷][8级]":
                                    case "攻击元素[雷][9级]":
                                    case "攻击元素[雷][10级]":
                                    case "攻击元素[风]":
                                    case "攻击元素[风][1级]":
                                    case "攻击元素[风][2级]":
                                    case "攻击元素[风][3级]":
                                    case "攻击元素[风][4级]":
                                    case "攻击元素[风][5级]":
                                    case "攻击元素[风][6级]":
                                    case "攻击元素[风][7级]":
                                    case "攻击元素[风][8级]":
                                    case "攻击元素[风][9级]":
                                    case "攻击元素[风][10级]":
                                    case "攻击元素[神圣]":
                                    case "攻击元素[神圣][1级]":
                                    case "攻击元素[神圣][2级]":
                                    case "攻击元素[神圣][3级]":
                                    case "攻击元素[神圣][4级]":
                                    case "攻击元素[神圣][5级]":
                                    case "攻击元素[神圣][6级]":
                                    case "攻击元素[神圣][7级]":
                                    case "攻击元素[神圣][8级]":
                                    case "攻击元素[神圣][9级]":
                                    case "攻击元素[神圣][10级]":
                                    case "攻击元素[暗黑]":
                                    case "攻击元素[暗黑][1级]":
                                    case "攻击元素[暗黑][2级]":
                                    case "攻击元素[暗黑][3级]":
                                    case "攻击元素[暗黑][4级]":
                                    case "攻击元素[暗黑][5级]":
                                    case "攻击元素[暗黑][6级]":
                                    case "攻击元素[暗黑][7级]":
                                    case "攻击元素[暗黑][8级]":
                                    case "攻击元素[暗黑][9级]":
                                    case "攻击元素[暗黑][10级]":
                                    case "攻击元素[幻影]":
                                    case "攻击元素[幻影][1级]":
                                    case "攻击元素[幻影][2级]":
                                    case "攻击元素[幻影][3级]":
                                    case "攻击元素[幻影][4级]":
                                    case "攻击元素[幻影][5级]":
                                    case "攻击元素[幻影][6级]":
                                    case "攻击元素[幻影][7级]":
                                    case "攻击元素[幻影][8级]":
                                    case "攻击元素[幻影][9级]":
                                    case "攻击元素[幻影][10级]":
                                    case "强化宝石[魔法盾]":
                                    case "强化宝石[魔法盾][1级]":
                                    case "强化宝石[魔法盾][2级]":
                                    case "强化宝石[魔法盾][3级]":
                                    case "强化宝石[魔法盾][4级]":
                                    case "强化宝石[魔法盾][5级]":
                                    case "强化宝石[魔法盾][6级]":
                                    case "强化宝石[魔法盾][7级]":
                                    case "强化宝石[魔法盾][8级]":
                                    case "强化宝石[魔法盾][9级]":
                                    case "强化宝石[魔法盾][10级]":
                                    case "强化宝石[冰冻伤害]":
                                    case "强化宝石[冰冻伤害][1级]":
                                    case "强化宝石[冰冻伤害][2级]":
                                    case "强化宝石[冰冻伤害][3级]":
                                    case "强化宝石[冰冻伤害][4级]":
                                    case "强化宝石[冰冻伤害][5级]":
                                    case "强化宝石[冰冻伤害][6级]":
                                    case "强化宝石[冰冻伤害][7级]":
                                    case "强化宝石[冰冻伤害][8级]":
                                    case "强化宝石[冰冻伤害][9级]":
                                    case "强化宝石[冰冻伤害][10级]":
                                    /*
                                    case "麻痹几率宝石":
                                    case "麻痹几率宝石[1级]":
                                    case "麻痹几率宝石[2级]":
                                    case "麻痹几率宝石[3级]":
                                    case "麻痹几率宝石[4级]":
                                    case "麻痹几率宝石[5级]":
                                    case "麻痹几率宝石[6级]":
                                    case "麻痹几率宝石[7级]":
                                    case "麻痹几率宝石[8级]":
                                    case "麻痹几率宝石[9级]":
                                    case "麻痹几率宝石[10级]":
                                    case "减速宝石":
                                    case "减速宝石[1级]":
                                    case "减速宝石[2级]":
                                    case "减速宝石[3级]":
                                    case "减速宝石[4级]":
                                    case "减速宝石[5级]":
                                    case "减速宝石[6级]":
                                    case "减速宝石[7级]":
                                    case "减速宝石[8级]":
                                    case "减速宝石[9级]":
                                    case "减速宝石[10级]":
                                    case "沉默宝石":
                                    case "沉默宝石[1级]":
                                    case "沉默宝石[2级]":
                                    case "沉默宝石[3级]":
                                    case "沉默宝石[4级]":
                                    case "沉默宝石[5级]":
                                    case "沉默宝石[6级]":
                                    case "沉默宝石[7级]":
                                    case "沉默宝石[8级]":
                                    case "沉默宝石[9级]":
                                    case "沉默宝石[10级]":
                                    case "格挡宝石":
                                    case "格挡宝石[1级]":
                                    case "格挡宝石[2级]":
                                    case "格挡宝石[3级]":
                                    case "格挡宝石[4级]":
                                    case "格挡宝石[5级]":
                                    case "格挡宝石[6级]":
                                    case "格挡宝石[7级]":
                                    case "格挡宝石[8级]":
                                    case "格挡宝石[9级]":
                                    case "格挡宝石[10级]":
                                    case "躲避宝石":
                                    case "躲避宝石[1级]":
                                    case "躲避宝石[2级]":
                                    case "躲避宝石[3级]":
                                    case "躲避宝石[4级]":
                                    case "躲避宝石[5级]":
                                    case "躲避宝石[6级]":
                                    case "躲避宝石[7级]":
                                    case "躲避宝石[8级]":
                                    case "躲避宝石[9级]":
                                    case "躲避宝石[10级]":
                                    case "强元素[火]":
                                    case "强元素[火][1级]":
                                    case "强元素[火][2级]":
                                    case "强元素[火][3级]":
                                    case "强元素[火][4级]":
                                    case "强元素[火][5级]":
                                    case "强元素[火][6级]":
                                    case "强元素[火][7级]":
                                    case "强元素[火][8级]":
                                    case "强元素[火][9级]":
                                    case "强元素[火][10级]":
                                    case "强元素[冰]":
                                    case "强元素[冰][1级]":
                                    case "强元素[冰][2级]":
                                    case "强元素[冰][3级]":
                                    case "强元素[冰][4级]":
                                    case "强元素[冰][5级]":
                                    case "强元素[冰][6级]":
                                    case "强元素[冰][7级]":
                                    case "强元素[冰][8级]":
                                    case "强元素[冰][9级]":
                                    case "强元素[冰][10级]":
                                    case "强元素[雷]":
                                    case "强元素[雷][1级]":
                                    case "强元素[雷][2级]":
                                    case "强元素[雷][3级]":
                                    case "强元素[雷][4级]":
                                    case "强元素[雷][5级]":
                                    case "强元素[雷][6级]":
                                    case "强元素[雷][7级]":
                                    case "强元素[雷][8级]":
                                    case "强元素[雷][9级]":
                                    case "强元素[雷][10级]":
                                    case "强元素[风]":
                                    case "强元素[风][1级]":
                                    case "强元素[风][2级]":
                                    case "强元素[风][3级]":
                                    case "强元素[风][4级]":
                                    case "强元素[风][5级]":
                                    case "强元素[风][6级]":
                                    case "强元素[风][7级]":
                                    case "强元素[风][8级]":
                                    case "强元素[风][9级]":
                                    case "强元素[风][10级]":
                                    case "强元素[神圣]":
                                    case "强元素[神圣][1级]":
                                    case "强元素[神圣][2级]":
                                    case "强元素[神圣][3级]":
                                    case "强元素[神圣][4级]":
                                    case "强元素[神圣][5级]":
                                    case "强元素[神圣][6级]":
                                    case "强元素[神圣][7级]":
                                    case "强元素[神圣][8级]":
                                    case "强元素[神圣][9级]":
                                    case "强元素[神圣][10级]":
                                    case "强元素[暗黑]":
                                    case "强元素[暗黑][1级]":
                                    case "强元素[暗黑][2级]":
                                    case "强元素[暗黑][3级]":
                                    case "强元素[暗黑][4级]":
                                    case "强元素[暗黑][5级]":
                                    case "强元素[暗黑][6级]":
                                    case "强元素[暗黑][7级]":
                                    case "强元素[暗黑][8级]":
                                    case "强元素[暗黑][9级]":
                                    case "强元素[暗黑][10级]":
                                    case "强元素[幻影]":
                                    case "强元素[幻影][1级]":
                                    case "强元素[幻影][2级]":
                                    case "强元素[幻影][3级]":
                                    case "强元素[幻影][4级]":
                                    case "强元素[幻影][5级]":
                                    case "强元素[幻影][6级]":
                                    case "强元素[幻影][7级]":
                                    case "强元素[幻影][8级]":
                                    case "强元素[幻影][9级]":
                                    case "强元素[幻影][10级]":
                                    */
                                    case "绿毒宝石":
                                    case "绿毒宝石[1级]":
                                    case "绿毒宝石[2级]":
                                    case "绿毒宝石[3级]":
                                    case "绿毒宝石[4级]":
                                    case "绿毒宝石[5级]":
                                    case "绿毒宝石[6级]":
                                    case "绿毒宝石[7级]":
                                    case "绿毒宝石[8级]":
                                    case "绿毒宝石[9级]":
                                    case "绿毒宝石[10级]":
                                    case "真炎魔宝石":
                                    case "真炎魔宝石[1级]":
                                    case "真炎魔宝石[2级]":
                                    case "真炎魔宝石[3级]":
                                    case "真炎魔宝石[4级]":
                                    case "真炎魔宝石[5级]":
                                    case "真炎魔宝石[6级]":
                                    case "真炎魔宝石[7级]":
                                    case "真炎魔宝石[8级]":
                                    case "真炎魔宝石[9级]":
                                    case "真炎魔宝石[10级]":
                                    /*
                                    case "灭魂宝石":
                                    case "灭魂宝石[1级]":
                                    case "灭魂宝石[2级]":
                                    case "灭魂宝石[3级]":
                                    case "灭魂宝石[4级]":
                                    case "灭魂宝石[5级]":
                                    case "灭魂宝石[6级]":
                                    case "灭魂宝石[7级]":
                                    case "灭魂宝石[8级]":
                                    case "灭魂宝石[9级]":
                                    case "灭魂宝石[10级]":
                                    */
                                    case "精炼宝石":
                                    case "精炼宝石[1级]":
                                    case "精炼宝石[2级]":
                                    case "精炼宝石[3级]":
                                    case "精炼宝石[4级]":
                                    case "精炼宝石[5级]":
                                    case "精炼宝石[6级]":
                                    case "精炼宝石[7级]":
                                    case "精炼宝石[8级]":
                                    case "精炼宝石[9级]":
                                    case "精炼宝石[10级]":
                                        break;
                                    default:
                                        GameScene.Game.ReceiveChat($"无法合成 {Item.Info.ItemName}, 它不能用于宝石合成", MessageType.System);
                                        return;
                                }

                                if (GameScene.Game.User.BaoshiKaiqi5433)
                                {
                                    if (Item.Info.Weight == 1 && Item.Count < 5)
                                    {
                                        GameScene.Game.ReceiveChat($"无法合成 {Item.Info.ItemName}，数量不够5颗", MessageType.System);
                                    }
                                    else if (Item.Info.Weight == 2 && Item.Count < 4)
                                    {
                                        GameScene.Game.ReceiveChat($"无法合成 {Item.Info.ItemName}，数量不够4颗", MessageType.System);
                                    }
                                    else if (Item.Info.Weight == 3 && Item.Count < 3)
                                    {
                                        GameScene.Game.ReceiveChat($"无法合成 {Item.Info.ItemName}，数量不够3颗", MessageType.System);
                                    }
                                    else if (Item.Info.Weight == 4 && Item.Count < 3)
                                    {
                                        GameScene.Game.ReceiveChat($"无法合成 {Item.Info.ItemName}，数量不够3颗", MessageType.System);
                                    }
                                    else if (Item.Info.Weight == 5)
                                        GameScene.Game.ReceiveChat($"不能再合成 {Item.Info.ItemName}, 它已经最高等级的宝石了", MessageType.System);
                                    else MoveItem(GameScene.Game.NPCBShechengBox.Grid);
                                }
                                else
                                {
                                    if (Item.Count < 5)
                                    {
                                        GameScene.Game.ReceiveChat($"无法合成 {Item.Info.ItemName}，数量达不到要求", MessageType.System);
                                    }
                                    else if (Item.Info.Weight == 5)
                                        GameScene.Game.ReceiveChat($"不能再合成 {Item.Info.ItemName}, 它已经最高等级的宝石了", MessageType.System);
                                    else MoveItem(GameScene.Game.NPCBShechengBox.Grid);
                                }

                                return;
                            }
                            if (GameScene.Game.NPCAccessoryLevelBox.IsVisible)
                            {
                                if (GameScene.Game.NPCAccessoryLevelBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCAccessoryLevelBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能提升 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCAccessoryLevelBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 提升.", MessageType.System);
                                return;
                            }
                            
                            if (GameScene.Game.NPCDunLevelBox.IsVisible)
                            {
                                if (GameScene.Game.NPCDunLevelBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCDunLevelBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能提升 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCDunLevelBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 提升.", MessageType.System);
                                return;
                            }
                            
                            if (GameScene.Game.NPCHuiLevelBox.IsVisible)
                            {
                                if (GameScene.Game.NPCHuiLevelBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCHuiLevelBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能提升 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCHuiLevelBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 提升.", MessageType.System);
                                return;
                            }
                            
                            if (GameScene.Game.NPCMingwenBox.IsVisible)
                            {
                                if (GameScene.Game.NPCMingwenBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCMingwenBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"{Item.Info.ItemName}不能开铭文印", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCMingwenBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 开铭文印.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCGZLKaikongBox.IsVisible)
                            {
                                if (GameScene.Game.NPCGZLKaikongBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCGZLKaikongBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能开孔 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCGZLKaikongBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 开孔.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCGZLBKaikongBox.IsVisible)
                            {
                                if (GameScene.Game.NPCGZLBKaikongBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCGZLBKaikongBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能开孔 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCGZLBKaikongBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 开孔.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCQTKaikongBox.IsVisible)
                            {
                                if (GameScene.Game.NPCQTKaikongBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCQTKaikongBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能开孔 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCQTKaikongBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 开孔.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanGJSTBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanGJSTBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanGJSTBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanGJSTBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            
                            if (GameScene.Game.NPCZhongziBox.IsVisible)
                            {
                                if (GameScene.Game.NPCZhongziBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCZhongziBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能升级 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCZhongziBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 升级.", MessageType.System);
                                return;
                            }
                            
                            if (GameScene.Game.NPCXiangKanjinglianBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanjinglianBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanjinglianBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanjinglianBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            
                            if (GameScene.Game.NPCBSduihuanBox.IsVisible)
                            {
                                if (GameScene.Game.NPCBSduihuanBox.Grid.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCBSduihuanBox.Grid))
                                        GameScene.Game.ReceiveChat($"无法分解 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else
                                    MoveItem(GameScene.Game.NPCBSduihuanBox.Grid);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanGJBSTBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanGJBSTBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanGJBSTBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanGJBSTBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanZRSTBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanZRSTBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanZRSTBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanZRSTBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanZRBSTBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanZRBSTBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanZRBSTBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanZRBSTBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanLHSTBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanLHSTBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanLHSTBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanLHSTBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanLHBSTBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanLHBSTBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanLHBSTBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanLHBSTBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanSMSTBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanSMSTBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanSMSTBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanSMSTBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanMFSTBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanMFSTBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanMFSTBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanMFSTBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanSDSTBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanSDSTBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanSDSTBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanSDSTBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanFYSTBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanFYSTBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanFYSTBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanFYSTBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanMYSTBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanMYSTBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanMYSTBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanMYSTBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangkanjystbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangkanjystbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangkanjystbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangkanjystbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangkanxxstbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangkanxxstbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangkanxxstbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangkanxxstbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCChaichustBox.IsVisible)
                            {
                                if (GameScene.Game.NPCChaichustBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCChaichustBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能拆除 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCChaichustBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 拆除.", MessageType.System);
                                return;
                            }
                            
                            if (GameScene.Game.NPCHuanhuaBox.IsVisible)
                            {
                                if (GameScene.Game.NPCHuanhuaBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCHuanhuaBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能幻化 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCHuanhuaBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 幻化.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanghuobox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanghuobox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanghuobox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanghuobox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKangbingbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKangbingbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKangbingbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKangbingbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKangleibox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKangleibox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKangleibox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKangleibox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKangfengbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKangfengbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKangfengbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKangfengbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKangshenbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKangshenbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKangshenbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKangshenbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanganbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanganbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanganbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanganbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanghuanbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanghuanbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanghuanbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanghuanbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanmofadunbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanmofadunbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanmofadunbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanmofadunbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanbingdongbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanbingdongbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanbingdongbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanbingdongbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanmabibox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanmabibox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanmabibox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanmabibox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanyidongbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanyidongbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanyidongbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanyidongbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanchenmobox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanchenmobox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanchenmobox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanchenmobox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKangedangbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKangedangbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKangedangbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKangedangbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanduobibox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanduobibox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanduobibox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanduobibox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanqhuobox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanqhuobox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanqhuobox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanqhuobox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanqbingbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanqbingbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanqbingbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanqbingbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanqleibox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanqleibox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanqleibox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanqleibox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanqfengbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanqfengbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanqfengbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanqfengbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanqshenbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanqshenbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanqshenbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanqshenbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanqanbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanqanbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanqanbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanqanbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanqhuanbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanqhuanbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanqhuanbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanqhuanbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanlvdubox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanlvdubox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanlvdubox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanlvdubox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanzymbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanzymbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanzymbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanzymbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanmhhfbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanmhhfbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanmhhfbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanmhhfbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }


                            if (GameScene.Game.NPCAccessoryUpgradeBox.IsVisible)
                            {
                                if (!Item.CanAccessoryUpgrade())
                                    GameScene.Game.ReceiveChat($"无法升级 {Item.Info.ItemName}.", MessageType.System);
                                else
                                    MoveItem(GameScene.Game.NPCAccessoryUpgradeBox.TargetCell);
                                return;
                            }
                            if (GameScene.Game.NPCAccessoryResetBox.IsVisible)
                            {
                                if (!MoveItem(GameScene.Game.NPCAccessoryResetBox.AccessoryGrid))
                                    GameScene.Game.ReceiveChat($"无法重置 {Item.Info.ItemName}.", MessageType.System);

                                return;
                            }
                            
                            if (GameScene.Game.NPCDunUpgradeBox.IsVisible)
                            {
                                if (GameScene.Game.NPCDunUpgradeBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCDunUpgradeBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"无法升级 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCDunUpgradeBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 升级.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCDunResetBox.IsVisible)
                            {
                                if (!MoveItem(GameScene.Game.NPCDunResetBox.AccessoryGrid))
                                    GameScene.Game.ReceiveChat($"无法重置 {Item.Info.ItemName}.", MessageType.System);

                                return;
                            }
                            
                            if (GameScene.Game.NPCHuiUpgradeBox.IsVisible)
                            {
                                if (GameScene.Game.NPCHuiUpgradeBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCHuiUpgradeBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"无法升级 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCHuiUpgradeBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 升级.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCHuiResetBox.IsVisible)
                            {
                                if (!MoveItem(GameScene.Game.NPCHuiResetBox.AccessoryGrid))
                                    GameScene.Game.ReceiveChat($"无法重置 {Item.Info.ItemName}.", MessageType.System);

                                return;
                            }
                            if (GameScene.Game.NPCRefineBox.IsVisible)
                            {
                                switch (Item.Info.ItemType)
                                {
                                    case ItemType.Ore:
                                        if (Item.Info.Effect != ItemEffect.BlackIronOre)
                                            GameScene.Game.ReceiveChat($"只能使用黑铁矿石.", MessageType.System);
                                        else
                                            MoveItem(GameScene.Game.NPCRefineBox.BlackIronGrid);
                                        return;
                                    case ItemType.Necklace:
                                    case ItemType.Bracelet:
                                    case ItemType.Ring:
                                        MoveItem(GameScene.Game.NPCRefineBox.AccessoryGrid);
                                        return;
                                    case ItemType.RefineSpecial:
                                        MoveItem(GameScene.Game.NPCRefineBox.SpecialGrid);
                                        return;
                                }
                                GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 精炼.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.MarketPlaceBox.ConsignTab.IsVisible)
                            {
                                MoveItem(GameScene.Game.MarketPlaceBox.ConsignGrid);
                                return;
                            }

                            if (GameScene.Game.SendMailBox.IsVisible)
                            {
                                MoveItem(GameScene.Game.SendMailBox.Grid);
                                return;
                            }
                            if (GameScene.Game.StorageBox.IsVisible)
                            {
                                if (!MoveItem(GameScene.Game.StorageBox.Grid))
                                    GameScene.Game.ReceiveChat("仓库空间不足.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.TradeBox.IsVisible)
                            {
                                if (!MoveItem(GameScene.Game.TradeBox.UserGrid))
                                    GameScene.Game.ReceiveChat("无法交易此物品.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.GuildBox.StorageTab.IsVisible)
                            {
                                if (!MoveItem(GameScene.Game.GuildBox.StorageGrid))
                                    GameScene.Game.ReceiveChat("无法将此物品存储在公会仓库中.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.CompanionBox.IsVisible)
                            {
                                if (!MoveItem(GameScene.Game.CompanionBox.InventoryGrid))
                                    GameScene.Game.ReceiveChat("对方的包裹没有可用空间.", MessageType.System);
                                return;
                            }

                            UseItem(); 
                            break;
                        case GridType.CompanionInventory:
                            if (Item == null) return;
                            if (GameScene.Game.NPCRepairBox.IsVisible)
                            {
                                if (Item.CurrentDurability >= Item.MaxDurability || !Item.Info.CanRepair)
                                    GameScene.Game.ReceiveChat($"无法修复 {Item.Info.ItemName}, 它已完全修复.", MessageType.System);
                                else if (!MoveItem(GameScene.Game.NPCRepairBox.Grid))
                                    GameScene.Game.ReceiveChat($"在这里无法修复 {Item.Info.ItemName} .", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCSellBox.IsVisible)
                            {
                                if (!Item.Info.CanSell)
                                    GameScene.Game.ReceiveChat($"无法出售 {Item.Info.ItemName}, 它不能出售.", MessageType.System);
                                else if (!MoveItem(GameScene.Game.NPCSellBox.Grid))
                                    GameScene.Game.ReceiveChat($"在这里无法出售 {Item.Info.ItemName} .", MessageType.System);
                                return;
                            }
                            
                            if (GameScene.Game.NPCJyhuishouBox.IsVisible)
                            {
                                if (!Item.Info.CanJyChange || Item.Info.ItemType == ItemType.Ore || Item.Info.ItemType == ItemType.Nothing)
                                    GameScene.Game.ReceiveChat($"无法经验回收 {Item.Info.ItemName}, 它不能回收.", MessageType.System);
                                else if (!MoveItem(GameScene.Game.NPCJyhuishouBox.Grid))
                                    GameScene.Game.ReceiveChat($"在这里无法回收 {Item.Info.ItemName} .", MessageType.System);
                                return;
                            }
                            
                            if (GameScene.Game.NPCGuildhuishouBox.IsVisible)
                            {
                                if (!Item.Info.CanJyChange)
                                    GameScene.Game.ReceiveChat($"无法贡献回收 {Item.Info.ItemName}, 它不能回收.", MessageType.System);
                                else if (!MoveItem(GameScene.Game.NPCGuildhuishouBox.Grid))
                                    GameScene.Game.ReceiveChat($"在这里无法回收 {Item.Info.ItemName} .", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCRefineBox.IsVisible)
                            {
                                switch (Item.Info.ItemType)
                                {
                                    case ItemType.Ore:
                                        if (Item.Info.Effect != ItemEffect.BlackIronOre)
                                            GameScene.Game.ReceiveChat($"只能使用黑铁矿石.", MessageType.System);
                                        else
                                            MoveItem(GameScene.Game.NPCRefineBox.BlackIronGrid);
                                        return;
                                    case ItemType.Necklace:
                                    case ItemType.Bracelet:
                                    case ItemType.Ring:
                                        MoveItem(GameScene.Game.NPCRefineBox.AccessoryGrid);
                                        return;
                                    case ItemType.RefineSpecial:
                                        MoveItem(GameScene.Game.NPCRefineBox.SpecialGrid);
                                        return;
                                }
                                GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 精炼.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCMasterRefineBox.IsVisible)
                            {
                                switch (Item.Info.Effect)
                                {
                                    case ItemEffect.Fragment1:
                                        if (MoveItem(GameScene.Game.NPCMasterRefineBox.Fragment1Grid))
                                            return;
                                        break;
                                    case ItemEffect.Fragment2:
                                        if (MoveItem(GameScene.Game.NPCMasterRefineBox.Fragment2Grid))
                                            return;
                                        break;
                                    case ItemEffect.Fragment3:
                                        if (MoveItem(GameScene.Game.NPCMasterRefineBox.Fragment3Grid))
                                            return;
                                        break;
                                    case ItemEffect.RefinementStone:
                                        if (MoveItem(GameScene.Game.NPCMasterRefineBox.RefinementStoneGrid))
                                            return;
                                        break;
                                }
                                switch (Item.Info.ItemType)
                                {
                                    case ItemType.RefineSpecial:
                                        if (MoveItem(GameScene.Game.NPCMasterRefineBox.SpecialGrid))
                                            return;
                                        break;
                                }
                                GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 精炼.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCAccessoryLevelBox.IsVisible)
                            {
                                if (GameScene.Game.NPCAccessoryLevelBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCAccessoryLevelBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能提升 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCAccessoryLevelBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 提升.", MessageType.System);
                                return;
                            }
                            
                            if (GameScene.Game.NPCDunLevelBox.IsVisible)
                            {
                                if (GameScene.Game.NPCDunLevelBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCDunLevelBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能提升 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCDunLevelBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 提升.", MessageType.System);
                                return;
                            }
                            
                            if (GameScene.Game.NPCHuiLevelBox.IsVisible)
                            {
                                if (GameScene.Game.NPCHuiLevelBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCHuiLevelBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能提升 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCHuiLevelBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 提升.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCGZLKaikongBox.IsVisible)
                            {
                                if (GameScene.Game.NPCGZLKaikongBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCGZLKaikongBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能开孔 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCGZLKaikongBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 开孔.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCGZLBKaikongBox.IsVisible)
                            {
                                if (GameScene.Game.NPCGZLBKaikongBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCGZLBKaikongBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能开孔 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCGZLBKaikongBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 开孔.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCQTKaikongBox.IsVisible)
                            {
                                if (GameScene.Game.NPCQTKaikongBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCQTKaikongBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能开孔 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCQTKaikongBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 开孔.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanGJSTBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanGJSTBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanGJSTBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanGJSTBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            
                            if (GameScene.Game.NPCMingwenBox.IsVisible)
                            {
                                if (GameScene.Game.NPCMingwenBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCMingwenBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"{Item.Info.ItemName}不能开铭文印", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCMingwenBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 开铭文印.", MessageType.System);
                                return;
                            }
                            
                            if (GameScene.Game.NPCZhongziBox.IsVisible)
                            {
                                if (GameScene.Game.NPCZhongziBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCZhongziBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能升级 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCZhongziBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 升级.", MessageType.System);
                                return;
                            }
                            
                            if (GameScene.Game.NPCXiangKanjinglianBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanjinglianBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanjinglianBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanjinglianBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            
                            if (GameScene.Game.NPCBSduihuanBox.IsVisible)
                            {
                                if (GameScene.Game.NPCBSduihuanBox.Grid.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCBSduihuanBox.Grid))
                                        GameScene.Game.ReceiveChat($"不能分解 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else
                                    MoveItem(GameScene.Game.NPCBSduihuanBox.Grid);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanGJBSTBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanGJBSTBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanGJBSTBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanGJBSTBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanZRSTBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanZRSTBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanZRSTBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanZRSTBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanZRBSTBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanZRBSTBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanZRBSTBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanZRBSTBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanLHSTBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanLHSTBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanLHSTBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanLHSTBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanLHBSTBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanLHBSTBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanLHBSTBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanLHBSTBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanSMSTBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanSMSTBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanSMSTBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanSMSTBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanMFSTBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanMFSTBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanMFSTBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanMFSTBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanSDSTBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanSDSTBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanSDSTBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanSDSTBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanFYSTBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanFYSTBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanFYSTBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanFYSTBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanMYSTBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanMYSTBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanMYSTBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanMYSTBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            
                            if (GameScene.Game.NPCHuanhuaBox.IsVisible)
                            {
                                if (GameScene.Game.NPCHuanhuaBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCHuanhuaBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能幻化 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCHuanhuaBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 幻化.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCChaichustBox.IsVisible)
                            {
                                if (GameScene.Game.NPCChaichustBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCChaichustBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能拆除 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCChaichustBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 拆除.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangkanjystbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangkanjystbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangkanjystbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangkanjystbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangkanxxstbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangkanxxstbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangkanxxstbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangkanxxstbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanghuobox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanghuobox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanghuobox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanghuobox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKangbingbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKangbingbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKangbingbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKangbingbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKangleibox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKangleibox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKangleibox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKangleibox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKangfengbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKangfengbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKangfengbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKangfengbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKangshenbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKangshenbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKangshenbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKangshenbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanganbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanganbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanganbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanganbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanghuanbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanghuanbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanghuanbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanghuanbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanmofadunbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanmofadunbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanmofadunbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanmofadunbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanbingdongbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanbingdongbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanbingdongbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanbingdongbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanmabibox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanmabibox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanmabibox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanmabibox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanyidongbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanyidongbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanyidongbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanyidongbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanchenmobox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanchenmobox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanchenmobox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanchenmobox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKangedangbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKangedangbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKangedangbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKangedangbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanduobibox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanduobibox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanduobibox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanduobibox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanqhuobox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanqhuobox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanqhuobox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanqhuobox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanqbingbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanqbingbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanqbingbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanqbingbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanqleibox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanqleibox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanqleibox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanqleibox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanqfengbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanqfengbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanqfengbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanqfengbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanqshenbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanqshenbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanqshenbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanqshenbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanqanbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanqanbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanqanbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanqanbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanqhuanbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanqhuanbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanqhuanbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanqhuanbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanlvdubox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanlvdubox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanlvdubox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanlvdubox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanzymbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanzymbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanzymbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanzymbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanmhhfbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanmhhfbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanmhhfbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCXiangKanmhhfbox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 镶嵌.", MessageType.System);
                                return;
                            }



                            if (GameScene.Game.NPCAccessoryUpgradeBox.IsVisible)
                            {
                                if (!Item.CanAccessoryUpgrade())
                                    GameScene.Game.ReceiveChat($"无法升级 {Item.Info.ItemName}.", MessageType.System);
                                else
                                    MoveItem(GameScene.Game.NPCAccessoryUpgradeBox.TargetCell);
                                return;
                            }
                            if (GameScene.Game.NPCAccessoryResetBox.IsVisible)
                            {
                                if (!MoveItem(GameScene.Game.NPCAccessoryResetBox.AccessoryGrid))
                                    GameScene.Game.ReceiveChat($"无法重置 {Item.Info.ItemName}.", MessageType.System);
                                return;
                            }
                            
                            if (GameScene.Game.NPCDunUpgradeBox.IsVisible)
                            {
                                if (GameScene.Game.NPCDunUpgradeBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCDunUpgradeBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"无法升级 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCDunUpgradeBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 升级.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCDunResetBox.IsVisible)
                            {
                                if (!MoveItem(GameScene.Game.NPCDunResetBox.AccessoryGrid))
                                    GameScene.Game.ReceiveChat($"无法重置 {Item.Info.ItemName}.", MessageType.System);
                                return;
                            }
                            
                            if (GameScene.Game.NPCHuiUpgradeBox.IsVisible)
                            {
                                if (GameScene.Game.NPCHuiUpgradeBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCHuiUpgradeBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"无法升级 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCHuiUpgradeBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 升级.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCHuiResetBox.IsVisible)
                            {
                                if (!MoveItem(GameScene.Game.NPCHuiResetBox.AccessoryGrid))
                                    GameScene.Game.ReceiveChat($"无法重置 {Item.Info.ItemName}.", MessageType.System);
                                return;
                            }

                            if (GameScene.Game.MarketPlaceBox.ConsignTab.IsVisible)
                            {
                                MoveItem(GameScene.Game.MarketPlaceBox.ConsignGrid);
                                return;
                            }
                            if (GameScene.Game.SendMailBox.IsVisible)
                            {
                                MoveItem(GameScene.Game.SendMailBox.Grid);
                                return;
                            }
                            if (GameScene.Game.StorageBox.IsVisible)
                            {
                                if (!MoveItem(GameScene.Game.StorageBox.Grid))
                                    GameScene.Game.ReceiveChat("仓库空间不足.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.TradeBox.IsVisible)
                            {
                                if (!MoveItem(GameScene.Game.TradeBox.UserGrid))
                                    GameScene.Game.ReceiveChat("无法交易此物品.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.GuildBox.StorageTab.IsVisible)
                            {
                                if (!MoveItem(GameScene.Game.GuildBox.StorageGrid))
                                    GameScene.Game.ReceiveChat("无法将此物品存储在公会仓库中.", MessageType.System);
                                return;
                            }
                            switch (Item.Info.ItemType)
                            {
                                case ItemType.ItemPart:
                                    if (!MoveItem(GameScene.Game.InventoryBox.PatchGrid))
                                        GameScene.Game.ReceiveChat("碎片包裹空间不足.", MessageType.System);
                                    break;
                                case ItemType.Baoshi:
                                    if (!MoveItem(GameScene.Game.InventoryBox.BaoshiGrid))
                                        GameScene.Game.ReceiveChat("宝石包裹空间不足.", MessageType.System);
                                    break;
                                default:
                                    if (!MoveItem(GameScene.Game.InventoryBox.Grid))
                                        GameScene.Game.ReceiveChat("包裹空间不足.", MessageType.System);
                                    break;
                            }
                            break;
                        case GridType.Storage:
                            if (Item == null) return;
                            if (GameScene.Game.NPCRepairBox.Visible)
                            {
                                if (Item.CurrentDurability >= Item.MaxDurability || !Item.Info.CanRepair)
                                    GameScene.Game.ReceiveChat($"无法修复 {Item.Info.ItemName}, 它已完全修复.", MessageType.System);
                                else if (!MoveItem(GameScene.Game.NPCRepairBox.Grid))
                                    GameScene.Game.ReceiveChat($"在这里无法修复 {Item.Info.ItemName} .", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCMasterRefineBox.IsVisible)
                            {
                                switch (Item.Info.Effect)
                                {
                                    case ItemEffect.Fragment1:
                                        if (MoveItem(GameScene.Game.NPCMasterRefineBox.Fragment1Grid))
                                            return;
                                        break;
                                    case ItemEffect.Fragment2:
                                        if (MoveItem(GameScene.Game.NPCMasterRefineBox.Fragment2Grid))
                                            return;
                                        break;
                                    case ItemEffect.Fragment3:
                                        if (MoveItem(GameScene.Game.NPCMasterRefineBox.Fragment3Grid))
                                            return;
                                        break;
                                    case ItemEffect.RefinementStone:
                                        if (MoveItem(GameScene.Game.NPCMasterRefineBox.RefinementStoneGrid))
                                            return;
                                        break;
                                }
                                switch (Item.Info.ItemType)
                                {
                                    case ItemType.RefineSpecial:
                                        if (MoveItem(GameScene.Game.NPCMasterRefineBox.SpecialGrid))
                                            return;
                                        break;
                                }
                                GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 精炼.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.NPCRefineBox.Visible)
                            {
                                switch (Item.Info.ItemType)
                                {
                                    case ItemType.Ore:
                                        if (Item.Info.Effect != ItemEffect.BlackIronOre)
                                            GameScene.Game.ReceiveChat($"只能使用黑铁矿石.", MessageType.System);
                                        else
                                            MoveItem(GameScene.Game.NPCRefineBox.BlackIronGrid);
                                        return;
                                    case ItemType.Necklace:
                                    case ItemType.Bracelet:
                                    case ItemType.Ring:
                                        MoveItem(GameScene.Game.NPCRefineBox.AccessoryGrid);
                                        return;
                                }
                                GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 精炼.", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.MarketPlaceBox.ConsignTab.IsVisible)
                            {
                                MoveItem(GameScene.Game.MarketPlaceBox.ConsignGrid);
                                return;
                            }
                            
                            
                            switch (Item.Info.ItemType)
                            {
                                case ItemType.ItemPart:
                                    if (!MoveItem(GameScene.Game.InventoryBox.PatchGrid))
                                        GameScene.Game.ReceiveChat("碎片包裹空间不足.", MessageType.System);
                                    break;
                                case ItemType.Baoshi:
                                    if (!MoveItem(GameScene.Game.InventoryBox.BaoshiGrid))
                                        GameScene.Game.ReceiveChat("宝石包裹空间不足.", MessageType.System);
                                    break;
                                default:
                                    if (!MoveItem(GameScene.Game.InventoryBox.Grid))
                                        GameScene.Game.ReceiveChat("包裹空间不足.", MessageType.System);
                                    break;
                            }
                            return;
                        case GridType.GuildStorage:
                            if (Item == null) return;


                            if (GameScene.Game.NPCRepairBox.Visible)
                            {
                                if (Item.CurrentDurability >= Item.MaxDurability || !Item.Info.CanRepair)
                                    GameScene.Game.ReceiveChat($"无法修复 {Item.Info.ItemName}, 它已完全修复.", MessageType.System);
                                else if (!MoveItem(GameScene.Game.NPCRepairBox.Grid))
                                    GameScene.Game.ReceiveChat($"在这里无法修复 {Item.Info.ItemName} .", MessageType.System);
                                return;
                            }
                            
                            if (GameScene.Game.MarketPlaceBox.ConsignTab.IsVisible)
                            {
                                MoveItem(GameScene.Game.MarketPlaceBox.ConsignGrid);
                                return;
                            }
                            
                            
                            switch (Item.Info.ItemType)
                            {
                                case ItemType.ItemPart:
                                    if (!MoveItem(GameScene.Game.InventoryBox.PatchGrid))
                                        GameScene.Game.ReceiveChat("碎片包裹空间不足.", MessageType.System);
                                    break;
                                case ItemType.Baoshi:
                                    if (!MoveItem(GameScene.Game.InventoryBox.BaoshiGrid))
                                        GameScene.Game.ReceiveChat("宝石包裹空间不足.", MessageType.System);
                                    break;
                                default:
                                    if (!MoveItem(GameScene.Game.InventoryBox.Grid))
                                        GameScene.Game.ReceiveChat("包裹空间不足.", MessageType.System);
                                    break;
                            }
                            return;
                        case GridType.Equipment:

                            if (Item == null) return;
                            
                            if (GameScene.Game.NPCRepairBox.Visible)
                            {
                                if (Item.CurrentDurability >= Item.MaxDurability || !Item.Info.CanRepair)
                                    GameScene.Game.ReceiveChat($"无法修复 {Item.Info.ItemName}, 它已完全修复.", MessageType.System);
                                else if (!MoveItem(GameScene.Game.NPCRepairBox.Grid))
                                    GameScene.Game.ReceiveChat($"在这里无法修复 {Item.Info.ItemName} .", MessageType.System);
                                return;
                            }

                            if (GameScene.Game.NPCAccessoryLevelBox.IsVisible)
                            {
                                if (GameScene.Game.NPCAccessoryLevelBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCAccessoryLevelBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能提升 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            
                            if (GameScene.Game.NPCDunLevelBox.IsVisible)
                            {
                                if (GameScene.Game.NPCDunLevelBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCDunLevelBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能提升 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            
                            if (GameScene.Game.NPCHuiLevelBox.IsVisible)
                            {
                                if (GameScene.Game.NPCHuiLevelBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCHuiLevelBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能提升 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCGZLKaikongBox.IsVisible)
                            {
                                if (GameScene.Game.NPCGZLKaikongBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCGZLKaikongBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能开孔 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCGZLBKaikongBox.IsVisible)
                            {
                                if (GameScene.Game.NPCGZLBKaikongBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCGZLBKaikongBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能开孔 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCQTKaikongBox.IsVisible)
                            {
                                if (GameScene.Game.NPCQTKaikongBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCQTKaikongBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能开孔 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanGJSTBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanGJSTBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanGJSTBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            
                            if (GameScene.Game.NPCMingwenBox.IsVisible)
                            {
                                if (GameScene.Game.NPCMingwenBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCMingwenBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"{Item.Info.ItemName}不能开铭文印", MessageType.System);
                                }
                                return;
                            }
                            
                            if (GameScene.Game.NPCZhongziBox.IsVisible)
                            {
                                if (GameScene.Game.NPCZhongziBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCZhongziBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能升级 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            
                            if (GameScene.Game.NPCXiangKanjinglianBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanjinglianBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanjinglianBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCBSduihuanBox.IsVisible)
                            {
                                if (GameScene.Game.NPCBSduihuanBox.Grid.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCBSduihuanBox.Grid))
                                        GameScene.Game.ReceiveChat($"不能分解 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanGJBSTBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanGJBSTBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanGJBSTBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanZRSTBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanZRSTBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanZRSTBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanZRBSTBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanZRBSTBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanZRBSTBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanLHSTBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanLHSTBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanLHSTBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanLHBSTBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanLHBSTBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanLHBSTBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanSMSTBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanSMSTBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanSMSTBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanMFSTBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanMFSTBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanMFSTBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanSDSTBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanSDSTBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanSDSTBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanFYSTBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanFYSTBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanFYSTBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanMYSTBox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanMYSTBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanMYSTBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return; 
                            }
                            if (GameScene.Game.NPCXiangkanjystbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangkanjystbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangkanjystbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCXiangkanxxstbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangkanxxstbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangkanxxstbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            
                            if (GameScene.Game.NPCHuanhuaBox.IsVisible)
                            {
                                if (GameScene.Game.NPCHuanhuaBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCHuanhuaBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能幻化 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCChaichustBox.IsVisible)
                            {
                                if (GameScene.Game.NPCChaichustBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCChaichustBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能拆除 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return; 
                            }
                            if (GameScene.Game.NPCXiangKanghuobox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanghuobox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanghuobox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCXiangKangbingbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKangbingbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKangbingbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCXiangKangleibox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKangleibox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKangleibox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCXiangKangfengbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKangfengbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKangfengbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCXiangKangshenbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKangshenbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKangshenbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanganbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanganbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanganbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanghuanbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanghuanbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanghuanbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanmofadunbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanmofadunbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanmofadunbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanbingdongbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanbingdongbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanbingdongbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanmabibox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanmabibox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanmabibox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanyidongbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanyidongbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanyidongbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanchenmobox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanchenmobox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanchenmobox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCXiangKangedangbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKangedangbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKangedangbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanduobibox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanduobibox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanduobibox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanqhuobox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanqhuobox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanqhuobox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanqbingbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanqbingbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanqbingbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanqleibox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanqleibox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanqleibox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanqfengbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanqfengbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanqfengbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanqshenbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanqshenbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanqshenbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanqanbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanqanbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanqanbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanqhuanbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanqhuanbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanqhuanbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanlvdubox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanlvdubox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanlvdubox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanzymbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanzymbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanzymbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }
                            if (GameScene.Game.NPCXiangKanmhhfbox.IsVisible)
                            {
                                if (GameScene.Game.NPCXiangKanmhhfbox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCXiangKanmhhfbox.TargetCell))
                                        GameScene.Game.ReceiveChat($"不能镶嵌 {Item.Info.ItemName}.", MessageType.System);
                                }
                                return;
                            }



                            if (GameScene.Game.NPCAccessoryUpgradeBox.IsVisible)
                            {
                                if (!Item.CanAccessoryUpgrade())
                                    GameScene.Game.ReceiveChat($"无法升级 {Item.Info.ItemName}.", MessageType.System);
                                else
                                    MoveItem(GameScene.Game.NPCAccessoryUpgradeBox.TargetCell);

                                return;
                            }

                            if (GameScene.Game.NPCDunUpgradeBox.IsVisible)
                            {
                                if (GameScene.Game.NPCDunUpgradeBox.TargetCell.Grid[0].Link == null)
                                {
                                    if (!MoveItem(GameScene.Game.NPCDunUpgradeBox.TargetCell))
                                        GameScene.Game.ReceiveChat($"无法升级 {Item.Info.ItemName}.", MessageType.System);
                                }
                                else if (!MoveItem(GameScene.Game.NPCDunUpgradeBox.Grid))
                                    GameScene.Game.ReceiveChat($"无法使用 {Item.Info.ItemName} 升级.", MessageType.System);
                                return;
                            }

                            if (GameScene.Game.NPCHuiUpgradeBox.IsVisible)
                            {
                                if (!Item.CanHuiUpgrade())
                                    GameScene.Game.ReceiveChat($"无法升级 {Item.Info.ItemName}.", MessageType.System);
                                else
                                    MoveItem(GameScene.Game.NPCHuiUpgradeBox.TargetCell);

                                return;
                            }


                            if (Item != null && (Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage)
                            {
                                if (e.Button == MouseButtons.Right)
                                    CEnvir.Enqueue(new C.MarriageTeleport());
                                return;
                            }


                            if (!MoveItem(GameScene.Game.InventoryBox.Grid))
                                GameScene.Game.ReceiveChat("包裹空间不足.", MessageType.System);

                            break;
                        case GridType.CompanionEquipment:

                            if (Item == null) return;

                            if (GameScene.Game.NPCRepairBox.Visible)
                            {
                                if (Item.CurrentDurability >= Item.MaxDurability || !Item.Info.CanRepair)
                                    GameScene.Game.ReceiveChat($"无法修复 {Item.Info.ItemName}, 它已完全修复.", MessageType.System);
                                else if (!MoveItem(GameScene.Game.NPCRepairBox.Grid))
                                    GameScene.Game.ReceiveChat($"在这里无法修复 {Item.Info.ItemName} .", MessageType.System);
                                return;
                            }



                            if (!MoveItem(GameScene.Game.InventoryBox.Grid))
                                GameScene.Game.ReceiveChat("包裹空间不足.", MessageType.System);

                            break;
                        case GridType.PatchGrid:
                            if (Item == null)
                                return;
                            if (GameScene.Game.MarketPlaceBox.ConsignTab.IsVisible)
                            {
                                MoveItem(GameScene.Game.MarketPlaceBox.ConsignGrid, false);
                                return;
                            }
                            if (GameScene.Game.SendMailBox.IsVisible)
                            {
                                MoveItem(GameScene.Game.SendMailBox.Grid, false);
                                return;
                            }
                            if (GameScene.Game.StorageBox.IsVisible)
                            {
                                if (MoveItem(GameScene.Game.StorageBox.Grid, false))
                                    return;
                                GameScene.Game.ReceiveChat("仓库空间不足。", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.TradeBox.IsVisible)
                            {
                                if (MoveItem(GameScene.Game.TradeBox.UserGrid, false))
                                    return;
                                GameScene.Game.ReceiveChat("无法交易此物品。", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.GuildBox.StorageTab.IsVisible)
                            {
                                if (MoveItem(GameScene.Game.GuildBox.StorageGrid, false))
                                    return;
                                GameScene.Game.ReceiveChat("无法将此物品存储到公会仓库中。", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.InventoryBox.IsVisible)
                            {
                                if (MoveItem(GameScene.Game.InventoryBox.Grid, false))
                                    return;
                                GameScene.Game.ReceiveChat("包裹没有可用空间。", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.CompanionBox.IsVisible)
                            {
                                if (MoveItem(GameScene.Game.CompanionBox.InventoryGrid, false))
                                    return;
                                GameScene.Game.ReceiveChat("宠物的包裹没有可用空间。", MessageType.System);
                                return;
                            }
                            UseItem();
                            return;
                        case GridType.BaoshiItems:
                            if (Item == null)
                                return;
                            if (GameScene.Game.MarketPlaceBox.ConsignTab.IsVisible)
                            {
                                MoveItem(GameScene.Game.MarketPlaceBox.ConsignGrid, false);
                                return;
                            }
                            if (GameScene.Game.SendMailBox.IsVisible)
                            {
                                MoveItem(GameScene.Game.SendMailBox.Grid, false);
                                return;
                            }
                            if (GameScene.Game.StorageBox.IsVisible)
                            {
                                if (MoveItem(GameScene.Game.StorageBox.Grid, false))
                                    return;
                                GameScene.Game.ReceiveChat("仓库空间不足。", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.TradeBox.IsVisible)
                            {
                                if (MoveItem(GameScene.Game.TradeBox.UserGrid, false))
                                    return;
                                GameScene.Game.ReceiveChat("无法交易此物品。", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.GuildBox.StorageTab.IsVisible)
                            {
                                if (MoveItem(GameScene.Game.GuildBox.StorageGrid, false))
                                    return;
                                GameScene.Game.ReceiveChat("无法将此物品存储到公会仓库中。", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.InventoryBox.IsVisible)
                            {
                                if (MoveItem(GameScene.Game.InventoryBox.Grid, false))
                                    return;
                                GameScene.Game.ReceiveChat("包裹没有可用空间。", MessageType.System);
                                return;
                            }
                            if (GameScene.Game.CompanionBox.IsVisible)
                            {
                                if (MoveItem(GameScene.Game.CompanionBox.InventoryGrid, false))
                                    return;
                                GameScene.Game.ReceiveChat("宠物的包裹没有可用空间。", MessageType.System);
                                return;
                            }
                            UseItem();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    break;
            }
        }
        public override void OnMouseDoubleClick(MouseEventArgs e)
        {
            if (Locked || GameScene.Game.GoldPickedUp || (!Linked && Link != null) || GameScene.Game.Observer) return;
            base.OnMouseDoubleClick(e);
            if (ReadOnly || e.Button != MouseButtons.Left) return;

            switch (GridType)
            {
                case GridType.Belt:
                case GridType.AutoPotion:
                    UseItem();
                    break;
                case GridType.Inventory:
                case GridType.CompanionInventory:
                case GridType.CompanionEquipment:
                case GridType.PatchGrid:
                case GridType.BaoshiItems:
                    UseItem();
                    return;

                case GridType.Storage:

                    UseItem();
                    return;
                case GridType.Equipment:
                    if (Item == null) return;
                    if ((Item.Flags & UserItemFlags.Marriage) == UserItemFlags.Marriage)
                        CEnvir.Enqueue(new C.MarriageTeleport());
                    break;
            }

        }
        public override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (MouseControl != this) return;
            foreach (KeyBindAction action in CEnvir.GetKeyAction(e.KeyCode))
            {
                switch (action)
                {
                    case KeyBindAction.ToggleItemLock:
                        if (Locked || GameScene.Game.GoldPickedUp || (!Linked && Link != null) || GameScene.Game.Observer) return;
                        if (ReadOnly || !Enabled) return;

                        if (Item != null)
                        {
                            CEnvir.Enqueue(new C.ItemLock { GridType = GridType, SlotIndex = Slot, Locked = (Item.Flags & UserItemFlags.Locked) != UserItemFlags.Locked });
                            e.Handled = true;
                        }
                        break;
                    default: continue;
                }
            }
        }
        #endregion
        #region IDisposable
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                _FixedBorder = false;
                _FixedBorderColour = false;
                _GridType = GridType.None;
                _HostGrid = null;
                _ItemGrid = null;
                _Locked = false;
                _ReadOnly = false;
                _Selected = false;
                _Slot = 0;
                _ShowCountLabel = false;
                QuickInfoItem = null;
                _QuickInfo = null;
                _QuickItem = null;
                DXItemCell oldLink = _Link;
                _Link = null;
                if (oldLink != null)
                    oldLink.Link = null;
                _LinkedCount = 0;
                _Linked = false;
                _AllowLink = false;
                FixedBorderChanged = null;
                FixedBorderColourChanged = null;
                GridTypeChanged = null;
                HostGridChanged = null;
                ItemChanged = null;
                ItemGridChanged = null;
                LockedChanged = null;
                ReadOnlyChanged = null;
                SelectedChanged = null;
                SlotChanged = null;
                ShowCountLabelChanged = null;
                LinkChanged = null;
                LinkedCountChanged = null;
                LinkedChanged = null;
                AllowLinkChanged = null;
                if (CountLabel != null)
                {
                    if (!CountLabel.IsDisposed)
                        CountLabel.Dispose();
                    CountLabel = null;
                }
            }
            if (SelectedCell == this) SelectedCell = null;
        }
        #endregion
    }
}
