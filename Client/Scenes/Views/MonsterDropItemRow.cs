using Client.Controls;
using Library;
using Library.SystemModels;
using System;
using System.Drawing;

namespace Client.Scenes.Views
{
    public sealed class MonsterDropItemRow : DXControl
    {
        private bool _Selected;
        private DropInfo _dropInfo;
        public DXItemCell ItemCell;
        public DXLabel NameLabel;
        public DXLabel CountLabelLabel;
        public DXLabel CountLabel;
        public DXLabel ProgressLabelLabel;
        public DXLabel ProgressLabel;
        public DXLabel DateLabel;
        public DXLabel TogoLabel;
        public DXLabel DateLabelLabel;

        public bool Selected
        {
            get
            {
                return _Selected;
            }
            set
            {
                if (_Selected == value)
                    return;
                bool selected = _Selected;
                _Selected = value;
                OnSelectedChanged(selected, value);
            }
        }

        public event EventHandler<EventArgs> SelectedChanged;

        public void OnSelectedChanged(bool oValue, bool nValue)
        {
            BackColour = Selected ? Color.FromArgb(80, 80, 125) : Color.FromArgb(25, 20, 0);
            ItemCell.BorderColour = Selected ? Color.FromArgb(198, 166, 99) : Color.FromArgb(99, 83, 50);
            EventHandler<EventArgs> selectedChanged = SelectedChanged;
            if (selectedChanged == null)
                return;
            selectedChanged((object)this, EventArgs.Empty);
        }

        public DropInfo DropInfo
        {
            get
            {
                return _dropInfo;
            }
            set
            {
                DropInfo dropInfo = _dropInfo;
                _dropInfo = value;
                OnItemInfoChanged(dropInfo, value);
            }
        }

        public event EventHandler<EventArgs> ItemInfoChanged;

        public void OnItemInfoChanged(DropInfo oValue, DropInfo nValue)
        {
            EventHandler<EventArgs> itemInfoChanged1 = ItemInfoChanged;
            if (itemInfoChanged1 != null)
                itemInfoChanged1((object)this, EventArgs.Empty);
            
            Visible = nValue != null;
            if (nValue == null) return;


            ItemCell.Item = new ClientUserItem(nValue.Item, 1L);
            ItemCell.RefreshItem();
            NameLabel.Text = nValue.Item.ItemName;
            NameLabel.ForeColour = Color.FromArgb(198, 166, 99);
            UpdateInfo();

            
            /*
            if (!nValue.Item.NoMake)
            {
                EventHandler<EventArgs> itemInfoChanged1 = ItemInfoChanged;
                if (itemInfoChanged1 != null)
                    itemInfoChanged1((object)this, EventArgs.Empty);
                Visible = nValue != null;
                if (nValue == null)
                    return;


                ItemCell.Item = new ClientUserItem(nValue.Item, 1L);
                ItemCell.RefreshItem();
                NameLabel.Text = nValue.Item.ItemName;
                NameLabel.ForeColour = Color.FromArgb(198, 166, 99);
                UpdateInfo();
            }
            */
        }

        private void UpdateInfo()
        {
            if (DropInfo == null)
            {
                CountLabel.Text = "未知";
                ProgressLabel.Text = "未知";
                DateLabel.Text = "未知";
            }
            else
            {
                CountLabel.Text = DropInfo.Amount.ToString("#,##0");
                if (DropInfo.Duli)
                {
                    ProgressLabel.Text = string.Format("1 / {0}", (object)DropInfo.DuliChance);
                    ProgressLabel.ForeColour = Color.Cyan;
                    ProgressLabel.Hint = "不挂钩任何爆率加成";
                }
                else
                {
                    ProgressLabel.Text = string.Format("1 / {0}", (object)DropInfo.Chance);
                    ProgressLabel.ForeColour = Color.FromArgb(198, 166, 99);
                    ProgressLabel.Hint = "挂钩爆率加成";
                }
                DateLabel.Text = DropInfo.PartOnly ? "仅部件" : "正常";
            }
        }

        public MonsterDropItemRow()
        {
            Size = new Size(465, 55);
            DrawTexture = true;
            BackColour = Selected ? Color.FromArgb(80, 80, 125) : Color.FromArgb(25, 20, 0);
            Visible = false;
            DXItemCell dxItemCell1 = new DXItemCell();
            dxItemCell1.Parent = (DXControl)this;
            DXItemCell dxItemCell2 = dxItemCell1;
            Size size = Size;
            int x1 = (size.Height - 36) / 2;
            size = Size;
            int y = (size.Height - 36) / 2;
            Point point1 = new Point(x1, y);
            dxItemCell2.Location = point1;
            dxItemCell1.FixedBorder = true;
            dxItemCell1.Border = true;
            dxItemCell1.ReadOnly = true;
            dxItemCell1.ItemGrid = new ClientUserItem[1];
            dxItemCell1.Slot = 0;
            dxItemCell1.FixedBorderColour = true;
            ItemCell = dxItemCell1;
            DXLabel dxLabel1 = new DXLabel();
            dxLabel1.Parent = (DXControl)this;
            int x2 = ItemCell.Location.X;
            size = ItemCell.Size;
            int width = size.Width;
            dxLabel1.Location = new Point(x2 + width, 22);
            dxLabel1.IsControl = false;
            NameLabel = dxLabel1;
            DXLabel dxLabel2 = new DXLabel();
            dxLabel2.Parent = (DXControl)this;
            dxLabel2.Text = "掉落数量:";
            dxLabel2.ForeColour = Color.White;
            dxLabel2.IsControl = false;
            CountLabelLabel = dxLabel2;
            DXLabel countLabelLabel = CountLabelLabel;
            size = CountLabelLabel.Size;
            Point point2 = new Point(320 - size.Width, 5);
            countLabelLabel.Location = point2;
            DXLabel dxLabel3 = new DXLabel();
            dxLabel3.Parent = (DXControl)this;
            dxLabel3.Location = new Point(320, 5);
            dxLabel3.IsControl = false;
            CountLabel = dxLabel3;
            DXLabel dxLabel4 = new DXLabel();
            dxLabel4.Parent = (DXControl)this;
            dxLabel4.Text = "掉落几率:";
            dxLabel4.ForeColour = Color.White;
            dxLabel4.IsControl = false;
            ProgressLabelLabel = dxLabel4;
            DXLabel progressLabelLabel = ProgressLabelLabel;
            size = ProgressLabelLabel.Size;
            Point point3 = new Point(320 - size.Width, 20);
            progressLabelLabel.Location = point3;
            DXLabel dxLabel5 = new DXLabel();
            dxLabel5.Parent = (DXControl)this;
            dxLabel5.Location = new Point(320, 20);
            dxLabel5.IsControl = false;
            ProgressLabel = dxLabel5;
            DXLabel dxLabel6 = new DXLabel();
            dxLabel6.Parent = (DXControl)this;
            dxLabel6.Text = "掉落方式:";
            dxLabel6.ForeColour = Color.White;
            dxLabel6.IsControl = false;
            DateLabelLabel = dxLabel6;
            DXLabel dateLabelLabel = DateLabelLabel;
            size = DateLabelLabel.Size;
            Point point4 = new Point(320 - size.Width, 35);
            dateLabelLabel.Location = point4;
            DXLabel dxLabel7 = new DXLabel();
            dxLabel7.Parent = (DXControl)this;
            dxLabel7.Location = new Point(320, 35);
            dxLabel7.IsControl = false;
            DateLabel = dxLabel7;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing)
                return;
            _Selected = false;
            SelectedChanged = (EventHandler<EventArgs>)null;
            _dropInfo = (DropInfo)null;
            ItemInfoChanged = (EventHandler<EventArgs>)null;
            if (ItemCell != null)
            {
                if (!ItemCell.IsDisposed)
                    ItemCell.Dispose();
                ItemCell = (DXItemCell)null;
            }
            if (NameLabel != null)
            {
                if (!NameLabel.IsDisposed)
                    NameLabel.Dispose();
                NameLabel = (DXLabel)null;
            }
            if (CountLabelLabel != null)
            {
                if (!CountLabelLabel.IsDisposed)
                    CountLabelLabel.Dispose();
                CountLabelLabel = (DXLabel)null;
            }
            if (CountLabel != null)
            {
                if (!CountLabel.IsDisposed)
                    CountLabel.Dispose();
                CountLabel = (DXLabel)null;
            }
            if (ProgressLabelLabel != null)
            {
                if (!ProgressLabelLabel.IsDisposed)
                    ProgressLabelLabel.Dispose();
                ProgressLabelLabel = (DXLabel)null;
            }
            if (ProgressLabel != null)
            {
                if (!ProgressLabel.IsDisposed)
                    ProgressLabel.Dispose();
                ProgressLabel = (DXLabel)null;
            }
        }
    }
}
