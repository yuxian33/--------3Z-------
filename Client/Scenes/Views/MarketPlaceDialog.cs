using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Client.Controls;
using Client.Envir;
using Client.Models;
using Client.UserModels;
using Library;
using Library.Network;
using Library.Network.ClientPackets;
using Library.SystemModels;
using C = Library.Network.ClientPackets;



namespace Client.Scenes.Views
{
    public sealed class MarketPlaceDialog : DXWindow
    {
        public List<ClientMarketPlaceInfo> ConsignItems = new List<ClientMarketPlaceInfo>();
        public DXTabControl TabControl;
        public DXTab SearchTab;
        public DXTextBox ItemNameBox;
        public DXTextBox BuyTotalBox;
        public DXTextBox SearchNumberSoldBox;
        public DXTextBox SearchLastPriceBox;
        public DXTextBox SearchAveragePriceBox;
        public DXTextBox SearchGameGoldLastPriceBox;
        public DXTextBox SearchGameGoldAveragePriceBox;
        public DXNumberBox BuyCountBox;
        public DXNumberBox BuyPriceBox;
        public DXComboBox ItemTypeBox;
        public DXComboBox SortBox;
        public DXControl MessagePanel;
        public DXControl BuyPanel;
        public DXControl HistoryPanel;
        public DXButton BuyButton;
        public DXButton SearchButton;
        public DXCheckBox BuyGuildBox;
        public DXLabel MessageLabel;
        public DXVScrollBar SearchScrollBar;
        public MarketPlaceRow[] SearchRows;
        public ClientMarketPlaceInfo[] SearchResults;
        public DXTab ConsignTab;
        public DXComboBox ConsignPriceLabelBox;
        public DXTextBox ConsignPriceBox;
        public DXTextBox ConsignCostBox;
        public DXTextBox NumberSoldBox;
        public DXTextBox LastPriceBox;
        public DXTextBox AveragePriceBox;
        public DXTextBox LastPriceBox1;
        public DXTextBox AveragePriceBox1;
        public DXTextBox ConsignMessageBox;
        public DXControl ConsignPanel;
        public DXControl ConsignBuyPanel;
        public DXControl ConsignConfirmPanel;
        public DXButton ConsignButton;
        public DXCheckBox ConsignGuildBox;
        public DXItemGrid ConsignGrid;
        public DXLabel ConsignPriceLabel;
        public DXVScrollBar ConsignScrollBar;
        public MarketPlaceRow[] ConsignRows;
        public DXTab StoreTab;
        public DXTextBox StoreItemNameBox;
        public DXTextBox StoreBuyTotalBox;
        public DXNumberBox StoreBuyCountBox;
        public DXNumberBox StoreBuyPriceBox;
        public DXNumberBox GameGoldBox;
        public DXNumberBox HuntGoldBox;
        public DXComboBox StoreItemTypeBox;
        public DXComboBox StoreSortBox;
        public DXControl StoreBuyPanel;
        public DXButton StoreBuyButton;
        public DXButton StoreSearchButton;
        public DXCheckBox UseHuntGoldBox;
        public DXVScrollBar StoreScrollBar;
        public DXLabel StoreBuyPriceLabel;
        public MarketPlaceStoreRow[] StoreRows;
        public List<StoreInfo> StoreSearchResults;
        private MarketPlaceRow _SelectedRow;
        private MarketPlaceStoreRow _SelectedStoreRow;
        private int _Price;
        public DateTime NextSearchTime;

        public MarketPlaceRow SelectedRow
        {
            get
            {
                return _SelectedRow;
            }
            set
            {
                if (_SelectedRow == value)
                    return;
                MarketPlaceRow selectedRow = _SelectedRow;
                _SelectedRow = value;
                OnSelectedRowChanged(selectedRow, value);
            }
        }

        public event EventHandler<EventArgs> SelectedRowChanged;

        public void OnSelectedRowChanged(MarketPlaceRow oValue, MarketPlaceRow nValue)
        {
            if (oValue != null)
                oValue.Selected = false;
            if (nValue != null)
                nValue.Selected = true;
            if (nValue?.MarketInfo == null)
            {
                MessagePanel.Enabled = false;
                MessageLabel.Text = "";
                BuyPanel.Enabled = false;
                BuyCountBox.MinValue = 0L;
                BuyCountBox.ValueTextBox.TextBox.Text = "";
                BuyPriceBox.MinValue = 0L;
                BuyPriceBox.ValueTextBox.TextBox.Text = "";
                HistoryPanel.Enabled = false;
                SearchNumberSoldBox.TextBox.Text = "";
                SearchLastPriceBox.TextBox.Text = "";
                SearchAveragePriceBox.TextBox.Text = "";
                LastPriceBox1.TextBox.Text = "";
                AveragePriceBox1.TextBox.Text = "";
            }
            else
            {
                MessagePanel.Enabled = true;
                MessageLabel.Text = nValue.MarketInfo.Message;
                BuyPanel.Enabled = !GameScene.Game.Observer;
                BuyCountBox.MinValue = 1L;
                BuyCountBox.MaxValue = nValue.MarketInfo.Item.Count;
                BuyCountBox.Value = 1L;
                BuyPriceBox.MinValue = (long)nValue.MarketInfo.Price;
                BuyPriceBox.MaxValue = (long)nValue.MarketInfo.Price;
                BuyPriceBox.Value = (long)nValue.MarketInfo.Price;
                if (nValue.MarketInfo.PriceType == CurrencyType.GameGold)
                    BuyGuildBox.Visible = false;
                else
                    BuyGuildBox.Visible = true;
                HistoryPanel.Enabled = true;
                SearchNumberSoldBox.TextBox.Text = "搜索中...";
                SearchLastPriceBox.TextBox.Text = "搜索中...";
                SearchAveragePriceBox.TextBox.Text = "搜索中...";
                LastPriceBox1.TextBox.Text = "搜索中...";
                AveragePriceBox1.TextBox.Text = "搜索中...";
                CEnvir.Enqueue(new MarketPlaceHistory()
                {
                    Index = nValue.MarketInfo.Item.Info.Index,
                    PartIndex = nValue.MarketInfo.Item.AddedStats[Stat.ItemIndex],
                    Display = 1
                });
            }
            EventHandler<EventArgs> selectedRowChanged = SelectedRowChanged;
            if (selectedRowChanged == null)
                return;
            selectedRowChanged((object)this, EventArgs.Empty);
        }

        public MarketPlaceStoreRow SelectedStoreRow
        {
            get
            {
                return _SelectedStoreRow;
            }
            set
            {
                if (_SelectedStoreRow == value)
                    return;
                MarketPlaceStoreRow selectedStoreRow = _SelectedStoreRow;
                _SelectedStoreRow = value;
                OnSelectedStoreRowChanged(selectedStoreRow, value);
            }
        }

        public event EventHandler<EventArgs> SelectedStoreRowChanged;

        public void OnSelectedStoreRowChanged(MarketPlaceStoreRow oValue, MarketPlaceStoreRow nValue)
        {
            if (oValue != null)
                oValue.Selected = false;
            if (nValue != null)
                nValue.Selected = true;
            if (nValue?.StoreInfo == null)
            {
                StoreBuyPanel.Enabled = false;
                StoreBuyCountBox.MinValue = 0L;
                StoreBuyCountBox.ValueTextBox.TextBox.Text = "";
                StoreBuyPriceBox.MinValue = 0L;
                StoreBuyPriceBox.ValueTextBox.TextBox.Text = "";
            }
            else
            {
                StoreBuyPanel.Enabled = !GameScene.Game.Observer;
                StoreBuyCountBox.MinValue = 1L;
                StoreBuyCountBox.MaxValue = (long)nValue.StoreInfo.Item.StackSize;
                StoreBuyCountBox.Value = 1L;
                StoreBuyPriceBox.MinValue = (long)nValue.StoreInfo.Price;
                StoreBuyPriceBox.MaxValue = (long)nValue.StoreInfo.Price;
                StoreBuyPriceBox.Value = (long)nValue.StoreInfo.Price;
            }
            EventHandler<EventArgs> selectedStoreRowChanged = SelectedStoreRowChanged;
            if (selectedStoreRowChanged == null)
                return;
            selectedStoreRowChanged((object)this, EventArgs.Empty);
        }

        public int Price
        {
            get
            {
                return _Price;
            }
            set
            {
                if (_Price == value)
                    return;
                int price = _Price;
                _Price = value;
                OnPriceChanged(price, value);
            }
        }

        public event EventHandler<EventArgs> PriceChanged;

        public void OnPriceChanged(int oValue, int nValue)
        {
            ConsignCostBox.TextBox.Text = Cost.ToString("#,##0");
            EventHandler<EventArgs> priceChanged = PriceChanged;
            if (priceChanged == null)
                return;
            priceChanged((object)this, EventArgs.Empty);
        }

        public int Cost
        {
            get
            {
                return 0;
            }
        }

        public override void OnVisibleChanged(bool oValue, bool nValue)
        {
            base.OnVisibleChanged(oValue, nValue);
            if (SearchRows == null)
                return;
            if (!Visible)
            {
                ConsignGrid.ClearLinks();
            }
            else
            {
                if (SearchResults == null)
                    Search();
                if (StoreSearchResults != null)
                    return;
                StoreSearch();
            }
        }

        public override WindowType Type
        {
            get
            {
                return WindowType.MarketPlaceBox;
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

        public MarketPlaceDialog()
        {
            TitleLabel.Text = "商城";
            SetClientSize(new Size(740, 461));
            DXTabControl dxTabControl = new DXTabControl();
            dxTabControl.Parent = (DXControl)this;
            dxTabControl.Size = ClientArea.Size;
            dxTabControl.Location = ClientArea.Location;
            TabControl = dxTabControl;
            DXTab dxTab1 = new DXTab();
            dxTab1.Parent = (DXControl)TabControl;
            dxTab1.TabButton.Label.Text = "寄售";
            dxTab1.Border = true;
            SearchTab = dxTab1;
            DXControl dxControl1 = new DXControl() { Parent = (DXControl)SearchTab, Size = new Size(SearchTab.Size.Width - 20, 26), Location = new Point(10, 10), Border = true, BorderColour = Color.FromArgb(198, 166, 99) };
            DXLabel dxLabel1 = new DXLabel();
            dxLabel1.Parent = dxControl1;
            dxLabel1.Location = new Point(5, 5);
            dxLabel1.Text = "名称:";
            DXLabel dxLabel2 = dxLabel1;
            DXTextBox dxTextBox1 = new DXTextBox();
            dxTextBox1.Parent = dxControl1;
            dxTextBox1.Size = new Size(180, 20);
            Point location1 = dxLabel2.Location;
            int x1 = location1.X + dxLabel2.Size.Width + 5;
            location1 = dxLabel2.Location;
            int y1 = location1.Y;
            dxTextBox1.Location = new Point(x1, y1);
            ItemNameBox = dxTextBox1;
            ItemNameBox.TextBox.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
            DXLabel dxLabel3 = new DXLabel();
            dxLabel3.Parent = dxControl1;
            dxLabel3.Location = new Point(ItemNameBox.Location.X + ItemNameBox.Size.Width + 10, 5);
            dxLabel3.Text = "物品:";
            DXLabel dxLabel4 = dxLabel3;
            DXComboBox dxComboBox1 = new DXComboBox();
            dxComboBox1.Parent = dxControl1;
            Point location2 = dxLabel4.Location;
            int x2 = location2.X + dxLabel4.Size.Width + 5;
            location2 = dxLabel4.Location;
            int y2 = location2.Y;
            dxComboBox1.Location = new Point(x2, y2);
            dxComboBox1.Size = new Size(95, 16);
            dxComboBox1.DropDownHeight = 198;
            ItemTypeBox = dxComboBox1;
            DXListBoxItem dxListBoxItem1 = new DXListBoxItem();
            dxListBoxItem1.Parent = (DXControl)ItemTypeBox.ListBox;
            dxListBoxItem1.Label.Text = "全部";
            dxListBoxItem1.Item = (object)null;
            System.Type type1 = typeof(ItemType);
            for (ItemType itemType = ItemType.Nothing; itemType <= ItemType.Shield; ++itemType)
            {
                DescriptionAttribute customAttribute = type1.GetMember(itemType.ToString())[0].GetCustomAttribute<DescriptionAttribute>();
                DXListBoxItem dxListBoxItem2 = new DXListBoxItem();
                dxListBoxItem2.Parent = (DXControl)ItemTypeBox.ListBox;
                dxListBoxItem2.Label.Text = customAttribute?.Description ?? itemType.ToString();
                dxListBoxItem2.Item = (object)itemType;
            }
            ItemTypeBox.ListBox.SelectItem((object)null);
            DXLabel dxLabel5 = new DXLabel();
            dxLabel5.Parent = dxControl1;
            Point location3 = ItemTypeBox.Location;
            dxLabel5.Location = new Point(location3.X + ItemTypeBox.Size.Width + 10, 5);
            dxLabel5.Text = "分类:";
            DXLabel dxLabel6 = dxLabel5;
            DXComboBox dxComboBox2 = new DXComboBox();
            dxComboBox2.Parent = dxControl1;
            location3 = dxLabel6.Location;
            int x3 = location3.X + dxLabel6.Size.Width + 5;
            location3 = dxLabel6.Location;
            int y3 = location3.Y;
            dxComboBox2.Location = new Point(x3, y3);
            dxComboBox2.Size = new Size(100, 16);
            SortBox = dxComboBox2;
            System.Type type2 = typeof(MarketPlaceSort);
            for (MarketPlaceSort marketPlaceSort = MarketPlaceSort.Newest; marketPlaceSort <= MarketPlaceSort.LowestPrice; ++marketPlaceSort)
            {
                DescriptionAttribute customAttribute = type2.GetMember(marketPlaceSort.ToString())[0].GetCustomAttribute<DescriptionAttribute>();
                DXListBoxItem dxListBoxItem2 = new DXListBoxItem();
                dxListBoxItem2.Parent = (DXControl)SortBox.ListBox;
                dxListBoxItem2.Label.Text = customAttribute?.Description ?? marketPlaceSort.ToString();
                dxListBoxItem2.Item = (object)marketPlaceSort;
            }
            SortBox.ListBox.SelectItem((object)MarketPlaceSort.Newest);
            DXButton dxButton1 = new DXButton();
            dxButton1.Size = new Size(80, DXControl.SmallButtonHeight);
            location3 = SortBox.Location;
            int x4 = location3.X + SortBox.Size.Width + 25;
            location3 = dxLabel6.Location;
            int y4 = location3.Y - 1;
            dxButton1.Location = new Point(x4, y4);
            dxButton1.Parent = dxControl1;
            dxButton1.ButtonType = ButtonType.SmallButton;
            dxButton1.Label.Text = "搜索";
            SearchButton = dxButton1;
            SearchButton.MouseClick += (EventHandler<MouseEventArgs>)((o, e) => Search());
            DXButton dxButton2 = new DXButton();
            dxButton2.Size = new Size(50, DXControl.SmallButtonHeight);
            location3 = SearchButton.Location;
            int x5 = location3.X + SearchButton.Size.Width + 40;
            location3 = dxLabel6.Location;
            int y5 = location3.Y - 1;
            dxButton2.Location = new Point(x5, y5);
            dxButton2.Parent = dxControl1;
            dxButton2.ButtonType = ButtonType.SmallButton;
            dxButton2.Label.Text = "清空";
            dxButton2.MouseClick += (EventHandler<MouseEventArgs>)((o, e) =>
            {
                ItemNameBox.TextBox.Text = "";
                ItemTypeBox.ListBox.SelectItem((object)null);
                Search();
            });
            SearchRows = new MarketPlaceRow[9];
            DXVScrollBar dxvScrollBar1 = new DXVScrollBar();
            dxvScrollBar1.Parent = (DXControl)SearchTab;
            dxvScrollBar1.Location = new Point(533, 47);
            dxvScrollBar1.Size = new Size(14, SearchTab.Size.Height - 59);
            dxvScrollBar1.VisibleSize = SearchRows.Length;
            dxvScrollBar1.Change = 3;
            SearchScrollBar = dxvScrollBar1;
            SearchScrollBar.ValueChanged += new EventHandler<EventArgs>(SearchScrollBar_ValueChanged);
            for (int index1 = 0; index1 < SearchRows.Length; ++index1)
            {
                int index = index1;
                MarketPlaceRow[] searchRows = SearchRows;
                int index2 = index;
                MarketPlaceRow marketPlaceRow = new MarketPlaceRow();
                marketPlaceRow.Parent = (DXControl)SearchTab;
                marketPlaceRow.Location = new Point(10, 46 + index1 * 43);
                searchRows[index2] = marketPlaceRow;
                SearchRows[index].MouseClick += (EventHandler<MouseEventArgs>)((o, e) => SelectedRow = SearchRows[index]);
                SearchRows[index].MouseWheel += new EventHandler<MouseEventArgs>(SearchScrollBar.DoMouseWheel);
            }
            HistoryPanel = new DXControl()
            {
                Location = new Point(555, 47),
                Parent = (DXControl)SearchTab,
                Size = new Size(175, 125),
                Border = true,
                BorderColour = Color.FromArgb(198, 166, 99),
                Enabled = false
            };
            DXLabel dxLabel7 = new DXLabel();
            dxLabel7.Text = "销售历史";
            dxLabel7.ForeColour = Color.White;
            dxLabel7.AutoSize = false;
            dxLabel7.DrawFormat = TextFormatFlags.HorizontalCenter;
            dxLabel7.Size = new Size(175, 15);
            dxLabel7.Parent = HistoryPanel;
            DXLabel dxLabel8 = new DXLabel();
            dxLabel8.Parent = HistoryPanel;
            dxLabel8.Text = "销售数量:";
            DXLabel dxLabel9 = dxLabel8;
            dxLabel9.Location = new Point(80 - dxLabel9.Size.Width, 25);
            DXTextBox dxTextBox2 = new DXTextBox();
            dxTextBox2.Location = new Point(80, 25);
            dxTextBox2.Size = new Size(85, 18);
            dxTextBox2.Parent = HistoryPanel;
            dxTextBox2.ReadOnly = true;
            dxTextBox2.Editable = false;
            SearchNumberSoldBox = dxTextBox2;
            DXLabel dxLabel10 = new DXLabel();
            dxLabel10.Parent = HistoryPanel;
            dxLabel10.Text = "金币最新:";
            DXLabel dxLabel11 = dxLabel10;
            dxLabel11.Location = new Point(80 - dxLabel11.Size.Width, 45);
            DXTextBox dxTextBox3 = new DXTextBox();
            dxTextBox3.Location = new Point(80, 45);
            dxTextBox3.Size = new Size(85, 18);
            dxTextBox3.Parent = HistoryPanel;
            dxTextBox3.ReadOnly = true;
            dxTextBox3.Editable = false;
            SearchLastPriceBox = dxTextBox3;
            DXLabel dxLabel12 = new DXLabel();
            dxLabel12.Parent = HistoryPanel;
            dxLabel12.Text = "金币均价:";
            DXLabel dxLabel13 = dxLabel12;
            dxLabel13.Location = new Point(80 - dxLabel13.Size.Width, 65);
            DXTextBox dxTextBox4 = new DXTextBox();
            dxTextBox4.Location = new Point(80, 65);
            dxTextBox4.Size = new Size(85, 18);
            dxTextBox4.Parent = HistoryPanel;
            dxTextBox4.ReadOnly = true;
            dxTextBox4.Editable = false;
            SearchAveragePriceBox = dxTextBox4;
            DXLabel dxLabel14 = new DXLabel();
            dxLabel14.Parent = HistoryPanel;
            dxLabel14.Text = "元宝最新:";
            DXLabel dxLabel15 = dxLabel14;
            dxLabel15.Location = new Point(80 - dxLabel15.Size.Width, 85);
            DXTextBox dxTextBox5 = new DXTextBox();
            dxTextBox5.Location = new Point(80, 85);
            dxTextBox5.Size = new Size(85, 18);
            dxTextBox5.Parent = HistoryPanel;
            dxTextBox5.ReadOnly = true;
            dxTextBox5.Editable = false;
            SearchGameGoldLastPriceBox = dxTextBox5;
            DXLabel dxLabel16 = new DXLabel();
            dxLabel16.Parent = HistoryPanel;
            dxLabel16.Text = "元宝均价:";
            DXLabel dxLabel17 = dxLabel16;
            DXLabel dxLabel18 = dxLabel17;
            Size size = dxLabel17.Size;
            Point point1 = new Point(80 - size.Width, 105);
            dxLabel18.Location = point1;
            DXTextBox dxTextBox6 = new DXTextBox();
            dxTextBox6.Location = new Point(80, 105);
            dxTextBox6.Size = new Size(85, 18);
            dxTextBox6.Parent = HistoryPanel;
            dxTextBox6.ReadOnly = true;
            dxTextBox6.Editable = false;
            SearchGameGoldAveragePriceBox = dxTextBox6;
            MessagePanel = new DXControl()
            {
                Location = new Point(555, 177),
                Parent = (DXControl)SearchTab,
                Size = new Size(175, 97),
                Border = true,
                BorderColour = Color.FromArgb(198, 166, 99),
                Enabled = false
            };
            DXLabel dxLabel19 = new DXLabel();
            dxLabel19.Parent = MessagePanel;
            dxLabel19.Text = "信息";
            dxLabel19.ForeColour = Color.White;
            dxLabel19.AutoSize = false;
            dxLabel19.DrawFormat = TextFormatFlags.HorizontalCenter;
            dxLabel19.Size = new Size(175, 15);
            DXLabel dxLabel20 = new DXLabel();
            dxLabel20.Location = new Point(0, 20);
            dxLabel20.Parent = MessagePanel;
            dxLabel20.Size = new Size(175, 80);
            dxLabel20.AutoSize = false;
            dxLabel20.DrawFormat = TextFormatFlags.WordBreak | TextFormatFlags.WordEllipsis;
            MessageLabel = dxLabel20;
            BuyPanel = new DXControl()
            {
                Location = new Point(555, 279),
                Parent = (DXControl)SearchTab,
                Size = new Size(175, 150),
                Border = true,
                BorderColour = Color.FromArgb(198, 166, 99),
                Enabled = false
            };
            DXLabel dxLabel21 = new DXLabel();
            dxLabel21.Parent = BuyPanel;
            dxLabel21.Text = "购买";
            dxLabel21.ForeColour = Color.White;
            dxLabel21.AutoSize = false;
            dxLabel21.DrawFormat = TextFormatFlags.HorizontalCenter;
            dxLabel21.Size = new Size(175, 15);
            DXLabel dxLabel22 = new DXLabel();
            dxLabel22.Parent = BuyPanel;
            dxLabel22.Text = "数量:";
            dxLabel22.ForeColour = Color.White;
            DXLabel dxLabel23 = dxLabel22;
            DXLabel dxLabel24 = dxLabel23;
            size = dxLabel23.Size;
            Point point2 = new Point(50 - size.Width, 20);
            dxLabel24.Location = point2;
            DXNumberBox dxNumberBox1 = new DXNumberBox();
            dxNumberBox1.Parent = BuyPanel;
            dxNumberBox1.Location = new Point(50, 20);
            dxNumberBox1.Size = new Size(125, 20);
            dxNumberBox1.ValueTextBox.Size = new Size(85, 18);
            dxNumberBox1.MaxValue = 5000L;
            dxNumberBox1.MinValue = 1L;
            dxNumberBox1.UpButton.Location = new Point(108, 1);
            BuyCountBox = dxNumberBox1;
            BuyCountBox.ValueTextBox.ValueChanged += new EventHandler<EventArgs>(UpdateBuyTotal);
            DXLabel dxLabel25 = new DXLabel();
            dxLabel25.Parent = BuyPanel;
            dxLabel25.Text = "价格:";
            dxLabel25.ForeColour = Color.White;
            DXLabel dxLabel26 = dxLabel25;
            DXLabel dxLabel27 = dxLabel26;
            size = dxLabel26.Size;
            Point point3 = new Point(50 - size.Width, 40);
            dxLabel27.Location = point3;
            DXNumberBox dxNumberBox2 = new DXNumberBox();
            dxNumberBox2.Parent = BuyPanel;
            dxNumberBox2.Location = new Point(50, 40);
            dxNumberBox2.Size = new Size(125, 20);
            dxNumberBox2.ValueTextBox.Size = new Size(85, 18);
            dxNumberBox2.ValueTextBox.ReadOnly = true;
            dxNumberBox2.ValueTextBox.Editable = false;
            dxNumberBox2.ValueTextBox.ForeColour = Color.FromArgb(198, 166, 99);
            dxNumberBox2.UpButton.Visible = false;
            dxNumberBox2.DownButton.Visible = false;
            dxNumberBox2.MaxValue = 100000000L;
            dxNumberBox2.MinValue = 0L;
            BuyPriceBox = dxNumberBox2;
            BuyPriceBox.ValueTextBox.ValueChanged += new EventHandler<EventArgs>(UpdateBuyTotal);
            DXTextBox dxTextBox7 = new DXTextBox();
            dxTextBox7.Location = new Point(69, 61);
            dxTextBox7.Size = new Size(85, 18);
            dxTextBox7.Parent = BuyPanel;
            dxTextBox7.ReadOnly = true;
            dxTextBox7.Editable = false;
            dxTextBox7.ForeColour = Color.FromArgb(198, 166, 99);
            BuyTotalBox = dxTextBox7;
            DXLabel dxLabel28 = new DXLabel();
            dxLabel28.Parent = BuyPanel;
            dxLabel28.Text = "总价:";
            dxLabel28.ForeColour = Color.White;
            DXLabel dxLabel29 = dxLabel28;
            DXLabel dxLabel30 = dxLabel29;
            size = dxLabel29.Size;
            Point point4 = new Point(50 - size.Width, 60);
            dxLabel30.Location = point4;
            DXTextBox dxTextBox8 = new DXTextBox();
            dxTextBox8.Location = new Point(69, 61);
            dxTextBox8.Size = new Size(85, 18);
            dxTextBox8.Parent = BuyPanel;
            dxTextBox8.ReadOnly = true;
            dxTextBox8.Editable = false;
            dxTextBox8.ForeColour = Color.FromArgb(198, 166, 99);
            BuyTotalBox = dxTextBox8;
            DXCheckBox dxCheckBox1 = new DXCheckBox();
            dxCheckBox1.Parent = BuyPanel;
            dxCheckBox1.Label.Text = "使用公会资金:";
            dxCheckBox1.Enabled = false;
            BuyGuildBox = dxCheckBox1;
            DXCheckBox buyGuildBox = BuyGuildBox;
            size = BuyGuildBox.Size;
            Point point5 = new Point(158 - size.Width, 101);
            buyGuildBox.Location = point5;
            DXButton dxButton3 = new DXButton();
            dxButton3.Size = new Size(85, DXControl.SmallButtonHeight);
            dxButton3.Location = new Point(69, 124);
            dxButton3.Label.Text = "购买";
            dxButton3.ButtonType = ButtonType.SmallButton;
            dxButton3.Parent = BuyPanel;
            BuyButton = dxButton3;
            BuyButton.MouseClick += new EventHandler<MouseEventArgs>(BuyButton_MouseClick);
            DXTab dxTab2 = new DXTab();
            dxTab2.Parent = (DXControl)TabControl;
            dxTab2.TabButton.Label.Text = "委托";
            dxTab2.Border = true;
            ConsignTab = dxTab2;
            DXControl dxControl2 = new DXControl() { Parent = (DXControl)ConsignTab, Size = new Size(175, 165), Location = new Point(10, 10), Border = true, BorderColour = Color.FromArgb(198, 166, 99) };
            DXLabel dxLabel31 = new DXLabel();
            dxLabel31.Parent = dxControl2;
            dxLabel31.Text = "寄售物品:";
            DXLabel dxLabel32 = dxLabel31;
            DXLabel dxLabel33 = dxLabel32;
            size = dxLabel32.Size;
            Point point6 = new Point(80 - size.Width, 15);
            dxLabel33.Location = point6;
            DXItemGrid dxItemGrid = new DXItemGrid();
            dxItemGrid.GridSize = new Size(1, 1);
            dxItemGrid.Location = new Point(79, 5);
            dxItemGrid.Parent = dxControl2;
            dxItemGrid.Border = true;
            dxItemGrid.Linked = true;
            dxItemGrid.GridType = GridType.Consign;
            ConsignGrid = dxItemGrid;
            ConsignGrid.Grid[0].LinkChanged += (EventHandler<EventArgs>)((o, e) =>
            {
                if (ConsignGrid.Grid[0].Item == null)
                {
                    NumberSoldBox.TextBox.Text = "";
                    LastPriceBox.TextBox.Text = "";
                    AveragePriceBox.TextBox.Text = "";
                    LastPriceBox1.TextBox.Text = "";
                    AveragePriceBox1.TextBox.Text = "";
                    ConsignGrid.Grid[0].LinkedCount = 0L;
                }
                else
                {
                    NumberSoldBox.TextBox.Text = "搜索中...";
                    LastPriceBox.TextBox.Text = "搜索中...";
                    AveragePriceBox.TextBox.Text = "搜索中...";
                    LastPriceBox1.TextBox.Text = "搜索中...";
                    AveragePriceBox1.TextBox.Text = "搜索中...";
                    CEnvir.Enqueue(new MarketPlaceHistory()
                    {
                        Index = ConsignGrid.Grid[0].Item.Info.Index,
                        PartIndex = ConsignGrid.Grid[0].Item.AddedStats[Stat.ItemIndex],
                        Display = 2
                    });
                }
                ConsignCostBox.TextBox.Text = Cost.ToString("#,##0");
            });
            DXLabel dxLabel34 = new DXLabel();
            dxLabel34.Parent = dxControl2;
            dxLabel34.Text = "销售历史";
            dxLabel34.ForeColour = Color.White;
            dxLabel34.AutoSize = false;
            dxLabel34.DrawFormat = TextFormatFlags.HorizontalCenter;
            dxLabel34.Size = new Size(175, 15);
            dxLabel34.Location = new Point(0, 45);
            DXLabel dxLabel35 = new DXLabel();
            dxLabel35.Parent = dxControl2;
            dxLabel35.Text = "销售数量:";
            DXLabel dxLabel36 = dxLabel35;
            DXLabel dxLabel37 = dxLabel36;
            size = dxLabel36.Size;
            Point point7 = new Point(80 - size.Width, 65);
            dxLabel37.Location = point7;
            DXTextBox dxTextBox9 = new DXTextBox();
            dxTextBox9.Location = new Point(80, 65);
            dxTextBox9.Size = new Size(85, 18);
            dxTextBox9.Parent = dxControl2;
            dxTextBox9.ReadOnly = true;
            dxTextBox9.Editable = false;
            NumberSoldBox = dxTextBox9;
            DXLabel dxLabel38 = new DXLabel();
            dxLabel38.Parent = dxControl2;
            dxLabel38.Text = "金币最新:";
            DXLabel dxLabel39 = dxLabel38;
            DXLabel dxLabel40 = dxLabel39;
            size = dxLabel39.Size;
            Point point8 = new Point(80 - size.Width, 85);
            dxLabel40.Location = point8;
            DXTextBox dxTextBox10 = new DXTextBox();
            dxTextBox10.Location = new Point(80, 85);
            dxTextBox10.Size = new Size(85, 18);
            dxTextBox10.Parent = dxControl2;
            dxTextBox10.ReadOnly = true;
            dxTextBox10.Editable = false;
            LastPriceBox = dxTextBox10;
            DXLabel dxLabel41 = new DXLabel();
            dxLabel41.Parent = dxControl2;
            dxLabel41.Text = "金币均价:";
            DXLabel dxLabel42 = dxLabel41;
            DXLabel dxLabel43 = dxLabel42;
            size = dxLabel42.Size;
            Point point9 = new Point(80 - size.Width, 105);
            dxLabel43.Location = point9;
            DXTextBox dxTextBox11 = new DXTextBox();
            dxTextBox11.Location = new Point(80, 105);
            dxTextBox11.Size = new Size(85, 18);
            dxTextBox11.Parent = dxControl2;
            dxTextBox11.ReadOnly = true;
            dxTextBox11.Editable = false;
            AveragePriceBox = dxTextBox11;
            DXLabel dxLabel44 = new DXLabel();
            dxLabel44.Parent = dxControl2;
            dxLabel44.Text = "元宝最新:";
            DXLabel dxLabel45 = dxLabel44;
            DXLabel dxLabel46 = dxLabel45;
            size = dxLabel45.Size;
            Point point10 = new Point(80 - size.Width, 125);
            dxLabel46.Location = point10;
            DXTextBox dxTextBox12 = new DXTextBox();
            dxTextBox12.Location = new Point(80, 125);
            dxTextBox12.Size = new Size(85, 18);
            dxTextBox12.Parent = dxControl2;
            dxTextBox12.ReadOnly = true;
            dxTextBox12.Editable = false;
            LastPriceBox1 = dxTextBox12;
            DXLabel dxLabel47 = new DXLabel();
            dxLabel47.Parent = dxControl2;
            dxLabel47.Text = "元宝均价:";
            DXLabel dxLabel48 = dxLabel47;
            DXLabel dxLabel49 = dxLabel48;
            size = dxLabel48.Size;
            Point point11 = new Point(80 - size.Width, 145);
            dxLabel49.Location = point11;
            DXTextBox dxTextBox13 = new DXTextBox();
            dxTextBox13.Location = new Point(80, 145);
            dxTextBox13.Size = new Size(85, 18);
            dxTextBox13.Parent = dxControl2;
            dxTextBox13.ReadOnly = true;
            dxTextBox13.Editable = false;
            AveragePriceBox1 = dxTextBox13;
            DXControl dxControl3 = new DXControl();
            dxControl3.Parent = (DXControl)ConsignTab;
            dxControl3.Size = new Size(175, 30);
            location3 = dxControl2.Location;
            int y6 = location3.Y;
            size = dxControl2.Size;
            int height1 = size.Height;
            dxControl3.Location = new Point(10, y6 + height1 + 5);
            dxControl3.Border = true;
            dxControl3.BorderColour = Color.FromArgb(198, 166, 99);
            ConsignBuyPanel = dxControl3;
            DXComboBox dxComboBox3 = new DXComboBox();
            dxComboBox3.Parent = ConsignBuyPanel;
            dxComboBox3.Location = new Point(5, 7);
            dxComboBox3.Size = new Size(70, 16);
            ConsignPriceLabelBox = dxComboBox3;
            DXListBoxItem dxListBoxItem3 = new DXListBoxItem();
            dxListBoxItem3.Parent = (DXControl)ConsignPriceLabelBox.ListBox;
            dxListBoxItem3.Label.Text = "金币";
            dxListBoxItem3.Item = (object)CurrencyType.Gold;
            DXListBoxItem dxListBoxItem4 = new DXListBoxItem();
            dxListBoxItem4.Parent = (DXControl)ConsignPriceLabelBox.ListBox;
            dxListBoxItem4.Label.Text = "元宝";
            dxListBoxItem4.Item = CurrencyType.GameGold;
            ConsignPriceLabelBox.ListBox.SelectItem((object)CurrencyType.Gold);
            DXTextBox dxTextBox14 = new DXTextBox();
            dxTextBox14.Location = new Point(80, 7);
            dxTextBox14.Size = new Size(85, 18);
            dxTextBox14.Parent = ConsignBuyPanel;
            ConsignPriceBox = dxTextBox14;
            ConsignPriceBox.TextBox.TextChanged += (EventHandler)((o, e) =>
            {
                int result;
                int.TryParse(ConsignPriceBox.TextBox.Text, out result);
                Price = result;
            });
            DXControl dxControl4 = new DXControl();
            dxControl4.Parent = (DXControl)ConsignTab;
            dxControl4.Size = new Size(175, 115);
            location3 = ConsignBuyPanel.Location;
            int y7 = location3.Y;
            size = ConsignBuyPanel.Size;
            int height2 = size.Height;
            dxControl4.Location = new Point(10, y7 + height2 + 5);
            dxControl4.Border = true;
            dxControl4.BorderColour = Color.FromArgb(198, 166, 99);
            DXControl dxControl5 = dxControl4;
            DXLabel dxLabel50 = new DXLabel();
            dxLabel50.Parent = dxControl5;
            dxLabel50.Text = "寄售信息";
            dxLabel50.ForeColour = Color.White;
            dxLabel50.AutoSize = false;
            dxLabel50.DrawFormat = TextFormatFlags.HorizontalCenter;
            dxLabel50.Size = new Size(175, 15);
            DXTextBox dxTextBox15 = new DXTextBox();
            dxTextBox15.Location = new Point(10, 25);
            dxTextBox15.Parent = dxControl5;
            dxTextBox15.TextBox.Multiline = true;
            dxTextBox15.TextBox.AcceptsReturn = true;
            size = dxControl5.Size;
            dxTextBox15.Size = new Size(size.Width - 20, 80);
            dxTextBox15.MaxLength = 150;
            ConsignMessageBox = dxTextBox15;
            DXControl dxControl6 = new DXControl();
            dxControl6.Parent = (DXControl)ConsignTab;
            dxControl6.Size = new Size(175, 90);
            location3 = dxControl5.Location;
            int y8 = location3.Y;
            size = dxControl5.Size;
            int height3 = size.Height;
            dxControl6.Location = new Point(10, y8 + height3 + 5);
            dxControl6.Border = true;
            dxControl6.BorderColour = Color.FromArgb(198, 166, 99);
            ConsignConfirmPanel = dxControl6;
            DXLabel dxLabel51 = new DXLabel();
            dxLabel51.Parent = ConsignConfirmPanel;
            dxLabel51.Text = "上架";
            dxLabel51.ForeColour = Color.White;
            dxLabel51.AutoSize = false;
            dxLabel51.DrawFormat = TextFormatFlags.HorizontalCenter;
            dxLabel51.Size = new Size(175, 15);
            DXLabel dxLabel52 = new DXLabel();
            dxLabel52.Parent = ConsignConfirmPanel;
            dxLabel52.Text = "寄售费用:";
            DXLabel dxLabel53 = dxLabel52;
            DXLabel dxLabel54 = dxLabel53;
            size = dxLabel53.Size;
            Point point12 = new Point(80 - size.Width, 25);
            dxLabel54.Location = point12;
            DXTextBox dxTextBox16 = new DXTextBox();
            dxTextBox16.Location = new Point(80, 25);
            dxTextBox16.Size = new Size(85, 18);
            dxTextBox16.Parent = ConsignConfirmPanel;
            dxTextBox16.ReadOnly = true;
            dxTextBox16.Editable = false;
            ConsignCostBox = dxTextBox16;
            DXCheckBox dxCheckBox2 = new DXCheckBox();
            dxCheckBox2.Parent = ConsignConfirmPanel;
            dxCheckBox2.Label.Text = "使用公会资金:";
            dxCheckBox2.Enabled = false;
            ConsignGuildBox = dxCheckBox2;
            DXCheckBox consignGuildBox = ConsignGuildBox;
            size = ConsignGuildBox.Size;
            Point point13 = new Point(169 - size.Width, 45);
            consignGuildBox.Location = point13;
            DXButton dxButton4 = new DXButton();
            dxButton4.Size = new Size(85, DXControl.SmallButtonHeight);
            dxButton4.Location = new Point(80, 65);
            dxButton4.Label.Text = "寄售";
            dxButton4.ButtonType = ButtonType.SmallButton;
            dxButton4.Parent = ConsignConfirmPanel;
            ConsignButton = dxButton4;
            ConsignButton.MouseClick += new EventHandler<MouseEventArgs>(ConsignButton_MouseClick);
            ConsignRows = new MarketPlaceRow[10];
            for (int index1 = 0; index1 < ConsignRows.Length; ++index1)
            {
                int index = index1;
                MarketPlaceRow[] consignRows = ConsignRows;
                int index2 = index;
                MarketPlaceRow marketPlaceRow = new MarketPlaceRow();
                marketPlaceRow.Parent = (DXControl)ConsignTab;
                marketPlaceRow.Location = new Point(190, 10 + index * 42);
                consignRows[index2] = marketPlaceRow;
                ConsignRows[index].MouseClick += (EventHandler<MouseEventArgs>)((o, e) =>
                {
                    ClientMarketPlaceInfo info = ConsignRows[index].MarketInfo;
                    if (info == null)
                        return;
                    DXItemAmountWindow window = new DXItemAmountWindow("取消寄售", info.Item);
                    window.ConfirmButton.MouseClick += (EventHandler<MouseEventArgs>)((o1, e1) =>
                    {
                        if (window.Amount <= 0L)
                            return;
                        CEnvir.Enqueue((Packet)new MarketPlaceCancelConsign()
                        {
                            Index = info.Index,
                            Count = window.Amount
                        });
                    });
                });
            }
            DXVScrollBar dxvScrollBar2 = new DXVScrollBar();
            dxvScrollBar2.Parent = (DXControl)ConsignTab;
            dxvScrollBar2.Location = new Point(713, 11);
            size = SearchTab.Size;
            dxvScrollBar2.Size = new Size(14, size.Height - 24);
            dxvScrollBar2.VisibleSize = ConsignRows.Length;
            dxvScrollBar2.Change = 3;
            ConsignScrollBar = dxvScrollBar2;
            ConsignScrollBar.ValueChanged += new EventHandler<EventArgs>(ConsignScrollBar_ValueChanged);
            DXTab dxTab3 = new DXTab();
            dxTab3.Parent = (DXControl)TabControl;
            dxTab3.TabButton.Label.Text = "元宝商城";
            dxTab3.TabButton.Size = new Size(120, DXControl.TabHeight);
            dxTab3.TabButton.RightAligned = true;
            dxTab3.Border = true;
            StoreTab = dxTab3;
            StoreTab.IsVisibleChanged += (EventHandler<EventArgs>)((o, e) => SelectedStoreRow = (MarketPlaceStoreRow)null);
            DXControl dxControl7 = new DXControl();
            dxControl7.Parent = (DXControl)StoreTab;
            size = SearchTab.Size;
            dxControl7.Size = new Size(size.Width - 20, 26);
            dxControl7.Location = new Point(10, 10);
            dxControl7.Border = true;
            dxControl7.BorderColour = Color.FromArgb(198, 166, 99);
            DXControl dxControl8 = dxControl7;
            DXLabel dxLabel55 = new DXLabel();
            dxLabel55.Parent = dxControl8;
            dxLabel55.Location = new Point(5, 5);
            dxLabel55.Text = "名称:";
            DXLabel dxLabel56 = dxLabel55;
            DXTextBox dxTextBox17 = new DXTextBox();
            dxTextBox17.Parent = dxControl8;
            dxTextBox17.Size = new Size(180, 20);
            location3 = dxLabel56.Location;
            int x6 = location3.X;
            size = dxLabel56.Size;
            int width1 = size.Width;
            int x7 = x6 + width1 + 5;
            location3 = dxLabel56.Location;
            int y9 = location3.Y;
            dxTextBox17.Location = new Point(x7, y9);
            StoreItemNameBox = dxTextBox17;
            StoreItemNameBox.TextBox.KeyPress += new KeyPressEventHandler(StoreTextBox_KeyPress);
            DXLabel dxLabel57 = new DXLabel();
            dxLabel57.Parent = dxControl8;
            location3 = StoreItemNameBox.Location;
            int x8 = location3.X;
            size = StoreItemNameBox.Size;
            int width2 = size.Width;
            dxLabel57.Location = new Point(x8 + width2 + 10, 5);
            dxLabel57.Text = "物品:";
            DXLabel dxLabel58 = dxLabel57;
            DXComboBox dxComboBox4 = new DXComboBox();
            dxComboBox4.Parent = dxControl8;
            location3 = dxLabel58.Location;
            int x9 = location3.X;
            size = dxLabel58.Size;
            int width3 = size.Width;
            int x10 = x9 + width3 + 5;
            location3 = dxLabel58.Location;
            int y10 = location3.Y;
            dxComboBox4.Location = new Point(x10, y10);
            dxComboBox4.Size = new Size(95, 16);
            dxComboBox4.DropDownHeight = 198;
            StoreItemTypeBox = dxComboBox4;
            DXListBoxItem dxListBoxItem5 = new DXListBoxItem();
            dxListBoxItem5.Parent = (DXControl)StoreItemTypeBox.ListBox;
            dxListBoxItem5.Label.Text = "全部";
            dxListBoxItem5.Item = (object)null;
            HashSet<string> source = new HashSet<string>();
            foreach (StoreInfo storeInfo in (IEnumerable<StoreInfo>)CartoonGlobals.StoreInfoList.Binding)
            {
                if (!string.IsNullOrEmpty(storeInfo.Filter))
                {
                    string filter = storeInfo.Filter;
                    char[] separator = new char[1] { ',' };
                    foreach (string str in filter.Split(separator, StringSplitOptions.RemoveEmptyEntries))
                        source.Add(str.Trim());
                }
            }
            foreach (string str in (IEnumerable<string>)source.OrderBy<string, string>((Func<string, string>)(x => x)))
            {
                DXListBoxItem dxListBoxItem2 = new DXListBoxItem();
                dxListBoxItem2.Parent = (DXControl)StoreItemTypeBox.ListBox;
                dxListBoxItem2.Label.Text = str;
                dxListBoxItem2.Item = (object)str;
            }
            StoreItemTypeBox.ListBox.SelectItem((object)null);
            DXLabel dxLabel59 = new DXLabel();
            dxLabel59.Parent = dxControl8;
            Point location4 = StoreItemTypeBox.Location;
            dxLabel59.Location = new Point(location4.X + StoreItemTypeBox.Size.Width + 10, 5);
            dxLabel59.Text = "分类:";
            DXLabel dxLabel60 = dxLabel59;
            DXComboBox dxComboBox5 = new DXComboBox();
            dxComboBox5.Parent = dxControl8;
            location4 = dxLabel60.Location;
            int x11 = location4.X + dxLabel60.Size.Width + 5;
            location4 = dxLabel60.Location;
            int y11 = location4.Y;
            dxComboBox5.Location = new Point(x11, y11);
            dxComboBox5.Size = new Size(100, 16);
            StoreSortBox = dxComboBox5;
            System.Type type3 = typeof(MarketPlaceStoreSort);
            for (MarketPlaceStoreSort marketPlaceStoreSort = MarketPlaceStoreSort.Alphabetical; marketPlaceStoreSort <= MarketPlaceStoreSort.Favourite; ++marketPlaceStoreSort)
            {
                DescriptionAttribute customAttribute = type3.GetMember(marketPlaceStoreSort.ToString())[0].GetCustomAttribute<DescriptionAttribute>();
                DXListBoxItem dxListBoxItem2 = new DXListBoxItem();
                dxListBoxItem2.Parent = (DXControl)StoreSortBox.ListBox;
                dxListBoxItem2.Label.Text = customAttribute?.Description ?? marketPlaceStoreSort.ToString();
                dxListBoxItem2.Item = (object)marketPlaceStoreSort;
            }
            StoreSortBox.ListBox.SelectItem((object)MarketPlaceStoreSort.Alphabetical);
            DXButton dxButton5 = new DXButton();
            dxButton5.Size = new Size(80, DXControl.SmallButtonHeight);
            location4 = StoreSortBox.Location;
            int x12 = location4.X + StoreSortBox.Size.Width + 25;
            location4 = dxLabel60.Location;
            int y12 = location4.Y - 1;
            dxButton5.Location = new Point(x12, y12);
            dxButton5.Parent = dxControl8;
            dxButton5.ButtonType = ButtonType.SmallButton;
            dxButton5.Label.Text = "搜索";
            StoreSearchButton = dxButton5;
            StoreSearchButton.MouseClick += (EventHandler<MouseEventArgs>)((o, e) => StoreSearch());
            DXButton dxButton6 = new DXButton();
            dxButton6.Size = new Size(50, DXControl.SmallButtonHeight);
            location4 = SearchButton.Location;
            int x13 = location4.X + SearchButton.Size.Width + 40;
            location4 = dxLabel60.Location;
            int y13 = location4.Y - 1;
            dxButton6.Location = new Point(x13, y13);
            dxButton6.Parent = dxControl8;
            dxButton6.ButtonType = ButtonType.SmallButton;
            dxButton6.Label.Text = "清空";
            dxButton6.MouseClick += (EventHandler<MouseEventArgs>)((o, e) =>
            {
                StoreItemNameBox.TextBox.Text = "";
                StoreItemTypeBox.ListBox.SelectItem((object)null);
                StoreSearch();
            });
            StoreRows = new MarketPlaceStoreRow[9];
            DXVScrollBar dxvScrollBar3 = new DXVScrollBar();
            dxvScrollBar3.Parent = (DXControl)StoreTab;
            dxvScrollBar3.Location = new Point(533, 47);
            dxvScrollBar3.Size = new Size(14, SearchTab.Size.Height - 59);
            dxvScrollBar3.VisibleSize = StoreRows.Length;
            dxvScrollBar3.Change = 3;
            StoreScrollBar = dxvScrollBar3;
            StoreScrollBar.ValueChanged += new EventHandler<EventArgs>(StoreScrollBar_ValueChanged);
            for (int index1 = 0; index1 < StoreRows.Length; ++index1)
            {
                int index = index1;
                MarketPlaceStoreRow[] storeRows = StoreRows;
                int index2 = index;
                MarketPlaceStoreRow marketPlaceStoreRow = new MarketPlaceStoreRow();
                marketPlaceStoreRow.Parent = (DXControl)StoreTab;
                marketPlaceStoreRow.Location = new Point(10, 46 + index1 * 43);
                storeRows[index2] = marketPlaceStoreRow;
                StoreRows[index].MouseClick += (EventHandler<MouseEventArgs>)((o, e) => SelectedStoreRow = StoreRows[index]);
                StoreRows[index].MouseWheel += new EventHandler<MouseEventArgs>(StoreScrollBar.DoMouseWheel);
            }
            DXControl dxControl9 = new DXControl() { Location = new Point(555, 149), Parent = (DXControl)StoreTab, Size = new Size(175, 50), Border = true, BorderColour = Color.FromArgb(198, 166, 99) };
            DXLabel dxLabel61 = new DXLabel();
            dxLabel61.Parent = dxControl9;
            dxLabel61.Text = "赏金";
            dxLabel61.ForeColour = Color.White;
            dxLabel61.AutoSize = false;
            dxLabel61.DrawFormat = TextFormatFlags.HorizontalCenter;
            dxLabel61.Size = new Size(175, 15);
            DXLabel dxLabel62 = new DXLabel();
            dxLabel62.Parent = dxControl9;
            dxLabel62.Text = "数量:";
            dxLabel62.ForeColour = Color.White;
            DXLabel dxLabel63 = dxLabel62;
            dxLabel63.Location = new Point(50 - dxLabel63.Size.Width, 20);
            DXNumberBox dxNumberBox3 = new DXNumberBox();
            dxNumberBox3.Parent = dxControl9;
            dxNumberBox3.Location = new Point(50, 20);
            dxNumberBox3.Size = new Size(125, 20);
            dxNumberBox3.ValueTextBox.Size = new Size(85, 18);
            dxNumberBox3.ValueTextBox.ReadOnly = true;
            dxNumberBox3.ValueTextBox.Editable = false;
            dxNumberBox3.ValueTextBox.ForeColour = Color.FromArgb(198, 166, 99);
            dxNumberBox3.UpButton.Visible = false;
            dxNumberBox3.DownButton.Visible = false;
            dxNumberBox3.MaxValue = 100000000L;
            dxNumberBox3.MinValue = -100000000L;
            HuntGoldBox = dxNumberBox3;
            DXControl dxControl10 = new DXControl() { Location = new Point(555, 204), Parent = (DXControl)StoreTab, Size = new Size(175, 70), Border = true, BorderColour = Color.FromArgb(198, 166, 99) };
            DXLabel dxLabel64 = new DXLabel();
            dxLabel64.Parent = dxControl10;
            dxLabel64.Text = "元宝";
            dxLabel64.ForeColour = Color.White;
            dxLabel64.AutoSize = false;
            dxLabel64.DrawFormat = TextFormatFlags.HorizontalCenter;
            dxLabel64.Size = new Size(175, 15);
            DXLabel dxLabel65 = new DXLabel();
            dxLabel65.Parent = dxControl10;
            dxLabel65.Text = "数量:";
            dxLabel65.ForeColour = Color.White;
            DXLabel dxLabel66 = dxLabel65;
            dxLabel66.Location = new Point(50 - dxLabel66.Size.Width, 20);
            DXNumberBox dxNumberBox4 = new DXNumberBox();
            dxNumberBox4.Parent = dxControl10;
            dxNumberBox4.Location = new Point(50, 20);
            dxNumberBox4.Size = new Size(125, 20);
            dxNumberBox4.ValueTextBox.Size = new Size(85, 18);
            dxNumberBox4.ValueTextBox.ReadOnly = true;
            dxNumberBox4.ValueTextBox.Editable = false;
            dxNumberBox4.ValueTextBox.ForeColour = Color.FromArgb(198, 166, 99);
            dxNumberBox4.UpButton.Visible = false;
            dxNumberBox4.DownButton.Visible = false;
            dxNumberBox4.MaxValue = 100000000L;
            dxNumberBox4.MinValue = -100000000L;
            GameGoldBox = dxNumberBox4;
            DXButton dxButton7 = new DXButton();
            dxButton7.Size = new Size(85, DXControl.SmallButtonHeight);
            dxButton7.Location = new Point(69, 45);
            dxButton7.Label.Text = "充值元宝";
            dxButton7.ButtonType = ButtonType.SmallButton;
            dxButton7.Parent = dxControl10;
            dxButton7.Enabled = !CEnvir.TestServer;
            dxButton7.MouseClick += (EventHandler<MouseEventArgs>)((o, e) =>
            {
                GameScene.Game.CZYBCodeBox.Visible = !GameScene.Game.CZYBCodeBox.Visible;

                /*
                if (GameScene.Game.Observer)
                    return;
                new DXMessageBox("你即将跳转到一个支付页面，这将使你的游戏最小化(全屏情况下),\n你想继续吗??", "充值元宝", DXMessageBoxButtons.YesNo).YesButton.MouseClick += (EventHandler<MouseEventArgs>)((o1, e1) =>
                {
                    if (string.IsNullOrEmpty(CEnvir.BuyAddress))
                        return;
                    Process.Start(CEnvir.BuyAddress);
                });
                */
            });
            StoreBuyPanel = new DXControl()
            {
                Location = new Point(555, 279),
                Parent = (DXControl)StoreTab,
                Size = new Size(175, 150),
                Border = true,
                BorderColour = Color.FromArgb(198, 166, 99),
                Enabled = false
            };
            DXLabel dxLabel67 = new DXLabel();
            dxLabel67.Parent = StoreBuyPanel;
            dxLabel67.Text = "购买";
            dxLabel67.ForeColour = Color.White;
            dxLabel67.AutoSize = false;
            dxLabel67.DrawFormat = TextFormatFlags.HorizontalCenter;
            dxLabel67.Size = new Size(175, 15);
            DXLabel dxLabel68 = new DXLabel();
            dxLabel68.Parent = StoreBuyPanel;
            dxLabel68.Text = "数量:";
            dxLabel68.ForeColour = Color.White;
            DXLabel dxLabel69 = dxLabel68;
            dxLabel69.Location = new Point(50 - dxLabel69.Size.Width, 20);
            DXNumberBox dxNumberBox5 = new DXNumberBox();
            dxNumberBox5.Parent = StoreBuyPanel;
            dxNumberBox5.Location = new Point(50, 20);
            dxNumberBox5.Size = new Size(125, 20);
            dxNumberBox5.ValueTextBox.Size = new Size(85, 18);
            dxNumberBox5.MaxValue = 5000L;
            dxNumberBox5.MinValue = 1L;
            dxNumberBox5.UpButton.Location = new Point(108, 1);
            StoreBuyCountBox = dxNumberBox5;
            StoreBuyCountBox.ValueTextBox.ValueChanged += new EventHandler<EventArgs>(UpdateStoreBuyTotal);
            DXLabel dxLabel70 = new DXLabel();
            dxLabel70.Parent = StoreBuyPanel;
            dxLabel70.Text = "元宝:";
            dxLabel70.ForeColour = Color.White;
            StoreBuyPriceLabel = dxLabel70;
            StoreBuyPriceLabel.Location = new Point(50 - StoreBuyPriceLabel.Size.Width, 40);
            DXNumberBox dxNumberBox6 = new DXNumberBox();
            dxNumberBox6.Parent = StoreBuyPanel;
            dxNumberBox6.Location = new Point(50, 40);
            dxNumberBox6.Size = new Size(125, 20);
            dxNumberBox6.ValueTextBox.Size = new Size(85, 18);
            dxNumberBox6.ValueTextBox.ReadOnly = true;
            dxNumberBox6.ValueTextBox.Editable = false;
            dxNumberBox6.ValueTextBox.ForeColour = Color.FromArgb(198, 166, 99);
            dxNumberBox6.UpButton.Visible = false;
            dxNumberBox6.DownButton.Visible = false;
            dxNumberBox6.MaxValue = 100000000L;
            dxNumberBox6.MinValue = 0L;
            StoreBuyPriceBox = dxNumberBox6;
            StoreBuyPriceBox.ValueTextBox.ValueChanged += new EventHandler<EventArgs>(UpdateStoreBuyTotal);
            DXTextBox dxTextBox18 = new DXTextBox();
            dxTextBox18.Location = new Point(69, 61);
            dxTextBox18.Size = new Size(85, 18);
            dxTextBox18.Parent = StoreBuyPanel;
            dxTextBox18.ReadOnly = true;
            dxTextBox18.Editable = false;
            dxTextBox18.ForeColour = Color.FromArgb(198, 166, 99);
            StoreBuyTotalBox = dxTextBox18;
            DXLabel dxLabel71 = new DXLabel();
            dxLabel71.Parent = StoreBuyPanel;
            dxLabel71.Text = "总价:";
            dxLabel71.ForeColour = Color.White;
            DXLabel dxLabel72 = dxLabel71;
            dxLabel72.Location = new Point(50 - dxLabel72.Size.Width, 60);
            DXTextBox dxTextBox19 = new DXTextBox();
            dxTextBox19.Location = new Point(69, 61);
            dxTextBox19.Size = new Size(85, 18);
            dxTextBox19.Parent = StoreBuyPanel;
            dxTextBox19.ReadOnly = true;
            dxTextBox19.Editable = false;
            dxTextBox19.ForeColour = Color.FromArgb(198, 166, 99);
            StoreBuyTotalBox = dxTextBox19;
            DXCheckBox dxCheckBox3 = new DXCheckBox();
            dxCheckBox3.Parent = StoreBuyPanel;
            dxCheckBox3.Label.Text = "使用赏金:";
            UseHuntGoldBox = dxCheckBox3;
            UseHuntGoldBox.Location = new Point(158 - UseHuntGoldBox.Size.Width, 101);
            UseHuntGoldBox.CheckedChanged += new EventHandler<EventArgs>(UpdateStoreBuyTotal);
            DXButton dxButton8 = new DXButton();
            dxButton8.Size = new Size(85, DXControl.SmallButtonHeight);
            dxButton8.Location = new Point(69, 124);
            dxButton8.Label.Text = "购买";
            dxButton8.ButtonType = ButtonType.SmallButton;
            dxButton8.Parent = StoreBuyPanel;
            StoreBuyButton = dxButton8;
            StoreBuyButton.MouseClick += new EventHandler<MouseEventArgs>(StoreBuyButton_MouseClick);
        }

        #region Methods


        public void Search()
        {
            SearchResults = null;

            SearchScrollBar.MaxValue = 0;


            foreach (MarketPlaceRow row in SearchRows)
            {
                row.Loading = true;
                row.Visible = true;
            }


            CEnvir.Enqueue(new C.MarketPlaceSearch
            {
                Name = ItemNameBox.TextBox.Text,

                ItemTypeFilter = ItemTypeBox.SelectedItem != null,
                ItemType = (ItemType?)ItemTypeBox.SelectedItem ?? 0,

                Sort = (MarketPlaceSort)SortBox.SelectedItem,
            });
        }
        public void StoreSearch()
        {
            StoreSearchResults = new List<StoreInfo>();

            StoreScrollBar.MaxValue = 0;


            foreach (MarketPlaceStoreRow row in StoreRows)
                row.Visible = true;

            string filter = (string)StoreItemTypeBox.SelectedItem;

            MarketPlaceStoreSort sort = (MarketPlaceStoreSort)StoreSortBox.SelectedItem;

            foreach (StoreInfo info in CartoonGlobals.StoreInfoList.Binding)
            {
                if (info.Item == null) continue;

                if (filter != null && !info.Filter.Contains(filter)) continue;

                if (!string.IsNullOrEmpty(StoreItemNameBox.TextBox.Text) && info.Item.ItemName.IndexOf(StoreItemNameBox.TextBox.Text, StringComparison.OrdinalIgnoreCase) < 0) continue;

                StoreSearchResults.Add(info);
            }

            switch (sort)
            {
                case MarketPlaceStoreSort.Alphabetical:
                    StoreSearchResults.Sort((x1, x2) => string.Compare(x1.Item.ItemName, x2.Item.ItemName, StringComparison.Ordinal));
                    break;
                case MarketPlaceStoreSort.HighestPrice:
                    StoreSearchResults.Sort((x1, x2) => x2.Price.CompareTo(x1.Price));
                    break;
                case MarketPlaceStoreSort.LowestPrice:
                    StoreSearchResults.Sort((x1, x2) => x1.Price.CompareTo(x2.Price));
                    break;
                case MarketPlaceStoreSort.Favourite:
                    
                    break;
            }

            RefreshStoreList();
        }

        public void RefreshList()
        {
            if (SearchResults == null) return;

            SearchScrollBar.MaxValue = SearchResults.Length;

            for (int i = 0; i < SearchRows.Length; i++)
            {
                if (i + SearchScrollBar.Value >= SearchResults.Length)
                {
                    SearchRows[i].MarketInfo = null;
                    SearchRows[i].Loading = false;
                    SearchRows[i].Visible = false;
                    continue;
                }

                if (SearchResults[i + SearchScrollBar.Value] == null)
                {
                    SearchRows[i].Loading = true;
                    SearchRows[i].Visible = true;
                    SearchResults[i + SearchScrollBar.Value] = new ClientMarketPlaceInfo { Loading = true };
                    CEnvir.Enqueue(new C.MarketPlaceSearchIndex { Index = i + SearchScrollBar.Value });
                    continue;
                }

                if (SearchResults[i + SearchScrollBar.Value].Loading) continue;

                SearchRows[i].Loading = false;
                SearchRows[i].MarketInfo = SearchResults[i + SearchScrollBar.Value];
            }

        }
        public void RefreshConsignList()
        {
            ConsignScrollBar.MaxValue = ConsignItems.Count;

            for (int i = 0; i < ConsignRows.Length; i++)
            {
                if (i + ConsignScrollBar.Value >= ConsignItems.Count)
                {
                    ConsignRows[i].MarketInfo = null;
                    ConsignRows[i].Visible = false;
                    continue;
                }

                if (ConsignItems[i + ConsignScrollBar.Value].Loading) continue;

                ConsignRows[i].MarketInfo = ConsignItems[i + ConsignScrollBar.Value];
            }

        }
        public void RefreshStoreList()
        {
            if (StoreSearchResults == null) return;

            StoreScrollBar.MaxValue = StoreSearchResults.Count;

            for (int i = 0; i < StoreRows.Length; i++)
            {
                if (i + StoreScrollBar.Value >= StoreSearchResults.Count)
                {
                    StoreRows[i].StoreInfo = null;
                    StoreRows[i].Visible = false;
                    continue;
                }

                StoreRows[i].StoreInfo = StoreSearchResults[i + StoreScrollBar.Value];
            }

        }

        private void BuyButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (SelectedRow?.MarketInfo?.Item == null) return;

            StringBuilder message = new StringBuilder();

            ItemInfo displayInfo = SelectedRow.MarketInfo.Item.Info;

            if (SelectedRow.MarketInfo.Item.Info.Effect == ItemEffect.ItemPart)
                displayInfo = CartoonGlobals.ItemInfoList.Binding.First(x => x.Index == SelectedRow.MarketInfo.Item.AddedStats[Stat.ItemIndex]);


            message.Append($"物品: {displayInfo.ItemName}");

            if (SelectedRow.MarketInfo.Item.Info.Effect == ItemEffect.ItemPart)
                message.Append(" - [部分]");


            if (BuyCountBox.Value > 1)
                message.Append($" x{BuyCountBox.Value:#,##0}");

            message.Append("\n\n");

            message.Append($"价格: {BuyPriceBox.Value:#,##0}");

            if (BuyCountBox.Value > 1)
                message.Append(" (每个)");

            message.Append("\n\n");

            message.Append($"总成本: {BuyTotalBox.TextBox.Text}");

            if (BuyGuildBox.Checked)
                message.Append(" (使用公会资金)");


            DXMessageBox box = new DXMessageBox(message.ToString(), "购买确认", DXMessageBoxButtons.YesNo);

            box.YesButton.MouseClick += (o1, e1) =>
            {
                BuyButton.Enabled = false;

                CEnvir.Enqueue(new C.MarketPlaceBuy { Index = SelectedRow.MarketInfo.Index, Count = BuyCountBox.Value, GuildFunds = BuyGuildBox.Checked });
                BuyGuildBox.Checked = false;
            };
        }
        private void StoreBuyButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (SelectedStoreRow?.StoreInfo?.Item == null) return;

            StringBuilder message = new StringBuilder();
            
            message.Append($"物品: {SelectedStoreRow.StoreInfo.Item.ItemName}");

            if (StoreBuyCountBox.Value > 1)
                message.Append($" x{StoreBuyCountBox.Value:#,##0}");

            message.Append("\n\n");

            message.Append($"价格: {StoreBuyPriceBox.Value:#,##0}");

            if (StoreBuyCountBox.Value > 1)
                message.Append(" (每个)");

            message.Append("\n\n");

            message.Append($"总成本: {StoreBuyTotalBox.TextBox.Text} ({(UseHuntGoldBox.Checked ? "赏金" : "元宝")})");

            DXMessageBox box = new DXMessageBox(message.ToString(), "购买确认", DXMessageBoxButtons.YesNo);

            box.YesButton.MouseClick += (o1, e1) =>
            {
                StoreBuyButton.Enabled = false;

                CEnvir.Enqueue(new C.MarketPlaceStoreBuy { Index = SelectedStoreRow.StoreInfo.Index, Count = StoreBuyCountBox.Value, UseHuntGold = UseHuntGoldBox.Checked});
            };
        }
        private void UpdateBuyTotal(object sender, EventArgs e)
        {
            BuyTotalBox.TextBox.Text = (BuyCountBox.Value * BuyPriceBox.Value).ToString("#,##0");
        }
        private void UpdateStoreBuyTotal(object sender, EventArgs e)
        {
            StoreInfo info = SelectedStoreRow?.StoreInfo;



            if (UseHuntGoldBox.Checked)
            {
                if (info != null)
                    StoreBuyPriceBox.Value = info.HuntGoldPrice == 0 ? info.Price : info.HuntGoldPrice;

                StoreBuyPriceLabel.Text = "赏金:";
            }
            else
            {
                if (info != null)
                    StoreBuyPriceBox.Value = info.Price;

                StoreBuyPriceLabel.Text = "元宝:";
            }

            StoreBuyTotalBox.TextBox.Text = (StoreBuyCountBox.Value * StoreBuyPriceBox.Value).ToString("#,##0");
        }
        private void ConsignScrollBar_ValueChanged(object sender, EventArgs e)
        {
            RefreshConsignList();
        }
        private void SearchScrollBar_ValueChanged(object sender, EventArgs e)
        {
            RefreshList();
        }
        private void ConsignButton_MouseClick(object sender, MouseEventArgs e)
        {
            DXItemCell cell = ConsignGrid.Grid[0];
            if (cell.Item == null)
                GameScene.Game.ReceiveChat("错误:没有选择任何物品。", MessageType.System);
            else if (Price <= 0)
            {
                GameScene.Game.ReceiveChat("错误:无效的价格。", MessageType.System);
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder();
                Library.SystemModels.ItemInfo itemInfo = cell.Item.Info;
                if (cell.Item.Info.Effect == ItemEffect.ItemPart)
                    itemInfo = CartoonGlobals.ItemInfoList.Binding.First<Library.SystemModels.ItemInfo>((Func<Library.SystemModels.ItemInfo, bool>)(x => x.Index == cell.Item.AddedStats[Stat.ItemIndex]));
                stringBuilder.Append("物品: " + itemInfo.ItemName);
                if (cell.Item.Info.Effect == ItemEffect.ItemPart)
                    stringBuilder.Append(" - [碎片]");
                if (cell.LinkedCount > 1L)
                    stringBuilder.Append(string.Format(" x{0:#,##0}", (object)cell.LinkedCount));
                stringBuilder.Append("\n\n");
                string str = (CurrencyType)ConsignPriceLabelBox.SelectedItem != CurrencyType.GameGold ? "金币" : "元宝";
                stringBuilder.Append(string.Format("{0}: {1:#,##0}", (object)str, (object)Price));
                if (cell.LinkedCount > 1L)
                    stringBuilder.Append(" (每个)");
                stringBuilder.Append("\n\n");
                stringBuilder.Append(string.Format("寄售费用: {0:#,##0}", (object)Cost));
                if (ConsignGuildBox.Checked)
                    stringBuilder.Append(" (使用公会资金)");
                new DXMessageBox(stringBuilder.ToString(), "寄售确认", DXMessageBoxButtons.YesNo).YesButton.MouseClick += (EventHandler<MouseEventArgs>)((o1, e1) =>
                {
                    CEnvir.Enqueue((Packet)new MarketPlaceConsign()
                    {
                        Link = new CellLinkInfo()
                        {
                            GridType = cell.Link.GridType,
                            Count = cell.LinkedCount,
                            Slot = cell.Link.Slot
                        },
                        Price = Price,
                        PriceType = (CurrencyType)ConsignPriceLabelBox.SelectedItem,
                        Message = ConsignMessageBox.TextBox.Text,
                        GuildFunds = ConsignGuildBox.Checked
                    });
                    cell.Link.Locked = true;
                    cell.Link = (DXItemCell)null;
                    ConsignPriceBox.TextBox.Text = "";
                    ConsignGuildBox.Checked = false;
                });
            }
        }
        private void StoreScrollBar_ValueChanged(object sender, EventArgs e)
        {
            RefreshStoreList();
        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter) return;

            e.Handled = true;

            if (SearchButton.Enabled)
                Search();
        }
        private void StoreTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter) return;

            e.Handled = true;

            if (StoreSearchButton.Enabled)
                StoreSearch();
        }
        #endregion

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                if (TabControl != null)
                {
                    if (!TabControl.IsDisposed)
                        TabControl.Dispose();

                    TabControl = null;
                }

                #region Search
                
                if (SearchTab != null)
                {
                    if (!SearchTab.IsDisposed)
                        SearchTab.Dispose();

                    SearchTab = null;
                }

                if (ItemNameBox != null)
                {
                    if (!ItemNameBox.IsDisposed)
                        ItemNameBox.Dispose();

                    ItemNameBox = null;
                }

                if (BuyTotalBox != null)
                {
                    if (!BuyTotalBox.IsDisposed)
                        BuyTotalBox.Dispose();

                    BuyTotalBox = null;
                }

                if (SearchNumberSoldBox != null)
                {
                    if (!SearchNumberSoldBox.IsDisposed)
                        SearchNumberSoldBox.Dispose();

                    SearchNumberSoldBox = null;
                }

                if (SearchLastPriceBox != null)
                {
                    if (!SearchLastPriceBox.IsDisposed)
                        SearchLastPriceBox.Dispose();

                    SearchLastPriceBox = null;
                }

                if (SearchAveragePriceBox != null)
                {
                    if (!SearchAveragePriceBox.IsDisposed)
                        SearchAveragePriceBox.Dispose();

                    SearchAveragePriceBox = null;
                }

                if (BuyCountBox != null)
                {
                    if (!BuyCountBox.IsDisposed)
                        BuyCountBox.Dispose();

                    BuyCountBox = null;
                }

                if (BuyPriceBox != null)
                {
                    if (!BuyPriceBox.IsDisposed)
                        BuyPriceBox.Dispose();

                    BuyPriceBox = null;
                }

                if (ItemTypeBox != null)
                {
                    if (!ItemTypeBox.IsDisposed)
                        ItemTypeBox.Dispose();

                    ItemTypeBox = null;
                }

                if (SortBox != null)
                {
                    if (!SortBox.IsDisposed)
                        SortBox.Dispose();

                    SortBox = null;
                }

                if (MessagePanel != null)
                {
                    if (!MessagePanel.IsDisposed)
                        MessagePanel.Dispose();

                    MessagePanel = null;
                }

                if (BuyPanel != null)
                {
                    if (!BuyPanel.IsDisposed)
                        BuyPanel.Dispose();

                    BuyPanel = null;
                }

                if (HistoryPanel != null)
                {
                    if (!HistoryPanel.IsDisposed)
                        HistoryPanel.Dispose();

                    HistoryPanel = null;
                }

                if (BuyButton != null)
                {
                    if (!BuyButton.IsDisposed)
                        BuyButton.Dispose();

                    BuyButton = null;
                }

                if (SearchButton != null)
                {
                    if (!SearchButton.IsDisposed)
                        SearchButton.Dispose();

                    SearchButton = null;
                }

                if (BuyGuildBox != null)
                {
                    if (!BuyGuildBox.IsDisposed)
                        BuyGuildBox.Dispose();

                    BuyGuildBox = null;
                }

                if (MessageLabel != null)
                {
                    if (!MessageLabel.IsDisposed)
                        MessageLabel.Dispose();

                    MessageLabel = null;
                }

                if (SearchScrollBar != null)
                {
                    if (!SearchScrollBar.IsDisposed)
                        SearchScrollBar.Dispose();

                    SearchScrollBar = null;
                }
                
                if (SearchRows != null)
                {
                    for (int i = 0; i < SearchRows.Length; i++)
                    {
                        if (SearchRows[i] != null)
                        {
                            if (!SearchRows[i].IsDisposed)
                                SearchRows[i].Dispose();

                            SearchRows[i] = null;
                        }
                    }

                    SearchRows = null;
                }

                SearchResults = null;

                #endregion

                #region Consign

                if (ConsignTab != null)
                {
                    if (!ConsignTab.IsDisposed)
                        ConsignTab.Dispose();

                    ConsignTab = null;
                }

                if (ConsignPriceBox != null)
                {
                    if (!ConsignPriceBox.IsDisposed)
                        ConsignPriceBox.Dispose();

                    ConsignPriceBox = null;
                }

                if (ConsignCostBox != null)
                {
                    if (!ConsignCostBox.IsDisposed)
                        ConsignCostBox.Dispose();

                    ConsignCostBox = null;
                }

                if (NumberSoldBox != null)
                {
                    if (!NumberSoldBox.IsDisposed)
                        NumberSoldBox.Dispose();

                    NumberSoldBox = null;
                }

                if (LastPriceBox != null)
                {
                    if (!LastPriceBox.IsDisposed)
                        LastPriceBox.Dispose();

                    LastPriceBox = null;
                }

                if (AveragePriceBox != null)
                {
                    if (!AveragePriceBox.IsDisposed)
                        AveragePriceBox.Dispose();

                    AveragePriceBox = null;
                }

                if (ConsignMessageBox != null)
                {
                    if (!ConsignMessageBox.IsDisposed)
                        ConsignMessageBox.Dispose();

                    ConsignMessageBox = null;
                }

                if (ConsignPanel != null)
                {
                    if (!ConsignPanel.IsDisposed)
                        ConsignPanel.Dispose();

                    ConsignPanel = null;
                }

                if (ConsignBuyPanel != null)
                {
                    if (!ConsignBuyPanel.IsDisposed)
                        ConsignBuyPanel.Dispose();

                    ConsignBuyPanel = null;
                }

                if (ConsignConfirmPanel != null)
                {
                    if (!ConsignConfirmPanel.IsDisposed)
                        ConsignConfirmPanel.Dispose();

                    ConsignConfirmPanel = null;
                }

                if (ConsignButton != null)
                {
                    if (!ConsignButton.IsDisposed)
                        ConsignButton.Dispose();

                    ConsignButton = null;
                }

                if (ConsignGuildBox != null)
                {
                    if (!ConsignGuildBox.IsDisposed)
                        ConsignGuildBox.Dispose();

                    ConsignGuildBox = null;
                }

                if (ConsignGrid != null)
                {
                    if (!ConsignGrid.IsDisposed)
                        ConsignGrid.Dispose();

                    ConsignGrid = null;
                }

                if (ConsignPriceLabel != null)
                {
                    if (!ConsignPriceLabel.IsDisposed)
                        ConsignPriceLabel.Dispose();

                    ConsignPriceLabel = null;
                }

                if (ConsignScrollBar != null)
                {
                    if (!ConsignScrollBar.IsDisposed)
                        ConsignScrollBar.Dispose();

                    ConsignScrollBar = null;
                }
                
                if (ConsignRows != null)
                {
                    for (int i = 0; i < ConsignRows.Length; i++)
                    {
                        if (ConsignRows[i] != null)
                        {
                            if (!ConsignRows[i].IsDisposed)
                                ConsignRows[i].Dispose();

                            ConsignRows[i] = null;
                        }
                    }

                    ConsignRows = null;
                }

                #endregion

                #region Store

                if (StoreTab != null)
                {
                    if (!StoreTab.IsDisposed)
                        StoreTab.Dispose();

                    StoreTab = null;
                }

                if (StoreItemNameBox != null)
                {
                    if (!StoreItemNameBox.IsDisposed)
                        StoreItemNameBox.Dispose();

                    StoreItemNameBox = null;
                }

                if (StoreBuyTotalBox != null)
                {
                    if (!StoreBuyTotalBox.IsDisposed)
                        StoreBuyTotalBox.Dispose();

                    StoreBuyTotalBox = null;
                }

                if (StoreBuyCountBox != null)
                {
                    if (!StoreBuyCountBox.IsDisposed)
                        StoreBuyCountBox.Dispose();

                    StoreBuyCountBox = null;
                }

                if (StoreBuyPriceBox != null)
                {
                    if (!StoreBuyPriceBox.IsDisposed)
                        StoreBuyPriceBox.Dispose();

                    StoreBuyPriceBox = null;
                }

                if (GameGoldBox != null)
                {
                    if (!GameGoldBox.IsDisposed)
                        GameGoldBox.Dispose();

                    GameGoldBox = null;
                }

                if (HuntGoldBox != null)
                {
                    if (!HuntGoldBox.IsDisposed)
                        HuntGoldBox.Dispose();

                    HuntGoldBox = null;
                }

                if (StoreItemTypeBox != null)
                {
                    if (!StoreItemTypeBox.IsDisposed)
                        StoreItemTypeBox.Dispose();

                    StoreItemTypeBox = null;
                }

                if (StoreSortBox != null)
                {
                    if (!StoreSortBox.IsDisposed)
                        StoreSortBox.Dispose();

                    StoreSortBox = null;
                }

                if (StoreBuyPanel != null)
                {
                    if (!StoreBuyPanel.IsDisposed)
                        StoreBuyPanel.Dispose();

                    StoreBuyPanel = null;
                }

                if (StoreBuyButton != null)
                {
                    if (!StoreBuyButton.IsDisposed)
                        StoreBuyButton.Dispose();

                    StoreBuyButton = null;
                }

                if (StoreSearchButton != null)
                {
                    if (!StoreSearchButton.IsDisposed)
                        StoreSearchButton.Dispose();

                    StoreSearchButton = null;
                }

                if (UseHuntGoldBox != null)
                {
                    if (!UseHuntGoldBox.IsDisposed)
                        UseHuntGoldBox.Dispose();

                    UseHuntGoldBox = null;
                }

                if (StoreScrollBar != null)
                {
                    if (!StoreScrollBar.IsDisposed)
                        StoreScrollBar.Dispose();

                    StoreScrollBar = null;
                }

                if (StoreRows != null)
                {
                    for (int i = 0; i < StoreRows.Length; i++)
                    {
                        if (StoreRows[i] != null)
                        {
                            if (!StoreRows[i].IsDisposed)
                                StoreRows[i].Dispose();

                            StoreRows[i] = null;
                        }
                    }

                    StoreRows = null;
                }

                StoreSearchResults = null;

                #endregion

                _SelectedRow = null;
                SelectedRowChanged = null;

                _SelectedStoreRow = null;
                SelectedStoreRowChanged = null;

                _Price = 0;
                PriceChanged = null;

                ConsignItems = null;

                NextSearchTime = DateTime.MinValue;
            }

        }

        #endregion
    }

    public sealed class MarketPlaceRow : DXControl
    {
        private bool _Selected;
        private ClientMarketPlaceInfo _MarketInfo;
        private bool _Loading;
        public DXItemCell ItemCell;
        public DXLabel NameLabel;
        public DXLabel PriceLabel;
        public DXLabel PriceLabelLabel;
        public DXLabel SellerLabel;
        public DXLabel SellerLabelLabel;

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

        public ClientMarketPlaceInfo MarketInfo
        {
            get
            {
                return _MarketInfo;
            }
            set
            {
                ClientMarketPlaceInfo marketInfo = _MarketInfo;
                _MarketInfo = value;
                OnMarketInfoChanged(marketInfo, value);
            }
        }

        public event EventHandler<EventArgs> MarketInfoChanged;

        public void OnMarketInfoChanged(ClientMarketPlaceInfo oValue, ClientMarketPlaceInfo nValue)
        {
            Visible = MarketInfo != null;
            if (MarketInfo == null)
                return;
            ItemCell.Item = MarketInfo.Item;
            ItemCell.RefreshItem();
            ItemInfo itemInfo = MarketInfo.Item?.Info;
            if (MarketInfo.Item != null && MarketInfo.Item.Info.Effect == ItemEffect.ItemPart)
                itemInfo = CartoonGlobals.ItemInfoList.Binding.First(x => x.Index == MarketInfo.Item.AddedStats[Stat.ItemIndex]);
            string str = itemInfo?.ItemName ?? "商品已售出.";
            if (MarketInfo.Item != null && MarketInfo.Item.Info.Effect == ItemEffect.ItemPart)
                str += " - [碎片]";
            NameLabel.Text = str;
            if (MarketInfo.Item != null && MarketInfo.Item.AddedStats.Count > 0)
                NameLabel.ForeColour = Color.FromArgb(148, byte.MaxValue, 206);
            else
                NameLabel.ForeColour = Color.FromArgb(198, 166, 99);
            if (MarketInfo.PriceType == CurrencyType.GameGold)
            {
                PriceLabelLabel.ForeColour = Color.Cyan;
                PriceLabelLabel.Text = "元宝:";
            }
            else
            {
                PriceLabelLabel.ForeColour = Color.Wheat;
                PriceLabelLabel.Text = "金币:";
            }
            PriceLabel.Text = MarketInfo.Price.ToString("#,##0");
            SellerLabel.Text = MarketInfo.Seller;
            SellerLabel.ForeColour = MarketInfo.IsOwner ? Color.Yellow : Color.FromArgb(198, 166, 99);
            if (GameScene.Game.MarketPlaceBox.SelectedRow == this)
                GameScene.Game.MarketPlaceBox.SelectedRow = (MarketPlaceRow)null;
            EventHandler<EventArgs> marketInfoChanged = MarketInfoChanged;
            if (marketInfoChanged == null)
                return;
            marketInfoChanged(this, EventArgs.Empty);
        }

        public bool Loading
        {
            get
            {
                return _Loading;
            }
            set
            {
                if (_Loading == value)
                    return;
                bool loading = _Loading;
                _Loading = value;
                OnLoadingChanged(loading, value);
            }
        }

        public event EventHandler<EventArgs> LoadingChanged;

        public void OnLoadingChanged(bool oValue, bool nValue)
        {
            ItemCell.Visible = !Loading;
            PriceLabel.Visible = !Loading;
            PriceLabelLabel.Visible = !Loading;
            SellerLabel.Visible = !Loading;
            SellerLabelLabel.Visible = !Loading;
            if (Loading)
            {
                MarketInfo = (ClientMarketPlaceInfo)null;
                NameLabel.Text = "加载中...";
            }
            else
                NameLabel.Text = "";
            if (GameScene.Game.MarketPlaceBox.SelectedRow == this)
                GameScene.Game.MarketPlaceBox.SelectedRow = (MarketPlaceRow)null;
            EventHandler<EventArgs> loadingChanged = LoadingChanged;
            if (loadingChanged == null)
                return;
            loadingChanged((object)this, EventArgs.Empty);
        }

        public MarketPlaceRow()
        {
            Size = new Size(515, 40);
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
            dxLabel1.Location = new Point(x2 + width, 12);
            dxLabel1.IsControl = false;
            NameLabel = dxLabel1;
            DXLabel dxLabel2 = new DXLabel();
            dxLabel2.Parent = (DXControl)this;
            dxLabel2.Text = "价格:";
            dxLabel2.ForeColour = Color.White;
            dxLabel2.IsControl = false;
            PriceLabelLabel = dxLabel2;
            DXLabel priceLabelLabel = PriceLabelLabel;
            size = PriceLabelLabel.Size;
            Point point2 = new Point(270 - size.Width, 12);
            priceLabelLabel.Location = point2;
            DXLabel dxLabel3 = new DXLabel();
            dxLabel3.Parent = (DXControl)this;
            dxLabel3.Location = new Point(280, 12);
            dxLabel3.IsControl = false;
            PriceLabel = dxLabel3;
            DXLabel dxLabel4 = new DXLabel();
            dxLabel4.Parent = (DXControl)this;
            dxLabel4.Text = "卖家:";
            dxLabel4.ForeColour = Color.White;
            dxLabel4.IsControl = false;
            SellerLabelLabel = dxLabel4;
            DXLabel sellerLabelLabel = SellerLabelLabel;
            size = SellerLabelLabel.Size;
            Point point3 = new Point(425 - size.Width, 12);
            sellerLabelLabel.Location = point3;
            DXLabel dxLabel5 = new DXLabel();
            dxLabel5.Parent = (DXControl)this;
            dxLabel5.Location = new Point(425, 12);
            dxLabel5.IsControl = false;
            SellerLabel = dxLabel5;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing)
                return;
            _Selected = false;
            SelectedChanged = (EventHandler<EventArgs>)null;
            _MarketInfo = (ClientMarketPlaceInfo)null;
            MarketInfoChanged = (EventHandler<EventArgs>)null;
            _Loading = false;
            LoadingChanged = (EventHandler<EventArgs>)null;
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
            if (PriceLabel != null)
            {
                if (!PriceLabel.IsDisposed)
                    PriceLabel.Dispose();
                PriceLabel = (DXLabel)null;
            }
            if (PriceLabelLabel != null)
            {
                if (!PriceLabelLabel.IsDisposed)
                    PriceLabelLabel.Dispose();
                PriceLabelLabel = (DXLabel)null;
            }
            if (SellerLabel != null)
            {
                if (!SellerLabel.IsDisposed)
                    SellerLabel.Dispose();
                SellerLabel = (DXLabel)null;
            }
            if (SellerLabelLabel != null)
            {
                if (!SellerLabelLabel.IsDisposed)
                    SellerLabelLabel.Dispose();
                SellerLabelLabel = (DXLabel)null;
            }
        }
    }

    public sealed class MarketPlaceStoreRow : DXControl
    {
        private bool _Selected;
        private StoreInfo _StoreInfo;
        public DXItemCell ItemCell;
        public DXLabel NameLabel;
        public DXLabel PriceLabel;
        public DXLabel HuntPriceLabel;
        public DXLabel PriceLabelLabel;
        public DXLabel HuntPriceLabelLabel;
        public DXButton FavouriteImage;

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

        public StoreInfo StoreInfo
        {
            get
            {
                return _StoreInfo;
            }
            set
            {
                if (_StoreInfo == value)
                    return;
                StoreInfo storeInfo = _StoreInfo;
                _StoreInfo = value;
                OnStoreInfoChanged(storeInfo, value);
            }
        }

        public event EventHandler<EventArgs> StoreInfoChanged;

        public void OnStoreInfoChanged(StoreInfo oValue, StoreInfo nValue)
        {
            Visible = StoreInfo?.Item != null;
            if (StoreInfo?.Item == null)
                return;
            UserItemFlags userItemFlags = UserItemFlags.Worthless;
            TimeSpan timeSpan = TimeSpan.FromSeconds((double)StoreInfo.Duration);
            if (timeSpan != TimeSpan.Zero)
                userItemFlags |= UserItemFlags.Expirable;
            ItemCell.Item = new ClientUserItem(StoreInfo.Item, 1L)
            {
                Flags = userItemFlags,
                ExpireTime = timeSpan
            };
            ItemCell.RefreshItem();
            NameLabel.Text = StoreInfo.Item.ItemName;
            PriceLabel.Text = StoreInfo.Price.ToString("#,##0");
            if (!StoreInfo.Available)
                PriceLabel.Text = "(无法使用)";
            HuntPriceLabel.Visible = (uint)StoreInfo.HuntGoldPrice > 0U;
            HuntPriceLabelLabel.Visible = (uint)StoreInfo.HuntGoldPrice > 0U;
            HuntPriceLabel.Text = (StoreInfo.HuntGoldPrice == 0 ? StoreInfo.Price : StoreInfo.HuntGoldPrice).ToString("#,##0");
            if (!StoreInfo.Available)
                HuntPriceLabel.Text = "(无法使用)";
            if (GameScene.Game.MarketPlaceBox.SelectedStoreRow == this)
                GameScene.Game.MarketPlaceBox.SelectedStoreRow = (MarketPlaceStoreRow)null;
            EventHandler<EventArgs> storeInfoChanged = StoreInfoChanged;
            if (storeInfoChanged == null)
                return;
            storeInfoChanged((object)this, EventArgs.Empty);
        }

        public MarketPlaceStoreRow()
        {
            Size = new Size(515, 40);
            DrawTexture = true;
            BackColour = Selected ? Color.FromArgb(80, 80, 125) : Color.FromArgb(25, 20, 0);
            DXItemCell dxItemCell1 = new DXItemCell();
            dxItemCell1.Parent = (DXControl)this;
            DXItemCell dxItemCell2 = dxItemCell1;
            Size size = Size;
            int x1 = (size.Height - 36) / 2;
            size = Size;
            int y1 = (size.Height - 36) / 2;
            Point point1 = new Point(x1, y1);
            dxItemCell2.Location = point1;
            dxItemCell1.FixedBorder = true;
            dxItemCell1.Border = true;
            dxItemCell1.ReadOnly = true;
            dxItemCell1.ItemGrid = new ClientUserItem[1];
            dxItemCell1.Slot = 0;
            dxItemCell1.FixedBorderColour = true;
            dxItemCell1.ShowCountLabel = false;
            ItemCell = dxItemCell1;
            DXLabel dxLabel1 = new DXLabel();
            dxLabel1.Parent = (DXControl)this;
            int x2 = ItemCell.Location.X;
            size = ItemCell.Size;
            int width1 = size.Width;
            dxLabel1.Location = new Point(x2 + width1, 12);
            dxLabel1.IsControl = false;
            NameLabel = dxLabel1;
            DXLabel dxLabel2 = new DXLabel();
            dxLabel2.Parent = (DXControl)this;
            dxLabel2.Location = new Point(290, 12);
            dxLabel2.IsControl = false;
            PriceLabel = dxLabel2;
            DXLabel dxLabel3 = new DXLabel();
            dxLabel3.Parent = (DXControl)this;
            dxLabel3.Text = "元宝:";
            dxLabel3.ForeColour = Color.White;
            dxLabel3.IsControl = false;
            PriceLabelLabel = dxLabel3;
            DXLabel priceLabelLabel = PriceLabelLabel;
            size = PriceLabelLabel.Size;
            Point point2 = new Point(290 - size.Width, 12);
            priceLabelLabel.Location = point2;
            DXLabel dxLabel4 = new DXLabel();
            dxLabel4.Parent = (DXControl)this;
            dxLabel4.Location = new Point(420, 12);
            dxLabel4.IsControl = false;
            HuntPriceLabel = dxLabel4;
            DXLabel dxLabel5 = new DXLabel();
            dxLabel5.Parent = (DXControl)this;
            dxLabel5.Text = "赏金:";
            dxLabel5.ForeColour = Color.White;
            dxLabel5.IsControl = false;
            HuntPriceLabelLabel = dxLabel5;
            DXLabel huntPriceLabelLabel = HuntPriceLabelLabel;
            size = HuntPriceLabelLabel.Size;
            Point point3 = new Point(420 - size.Width, 12);
            huntPriceLabelLabel.Location = point3;
            DXButton dxButton = new DXButton();
            dxButton.LibraryFile = LibraryFile.GameInter;
            dxButton.Index = 6570;
            dxButton.Parent = (DXControl)this;
            dxButton.Hint = "收藏 (未激活)";
            dxButton.Enabled = false;
            dxButton.Visible = false;
            FavouriteImage = dxButton;
            DXButton favouriteImage = FavouriteImage;
            size = Size;
            int width2 = size.Width;
            size = FavouriteImage.Size;
            int width3 = size.Width;
            int x3 = width2 - width3 - 10;
            size = Size;
            int height1 = size.Height;
            size = FavouriteImage.Size;
            int height2 = size.Height;
            int y2 = (height1 - height2) / 2;
            Point point4 = new Point(x3, y2);
            favouriteImage.Location = point4;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing)
                return;
            _Selected = false;
            SelectedChanged = (EventHandler<EventArgs>)null;
            _StoreInfo = (StoreInfo)null;
            StoreInfoChanged = (EventHandler<EventArgs>)null;
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
            if (PriceLabel != null)
            {
                if (!PriceLabel.IsDisposed)
                    PriceLabel.Dispose();
                PriceLabel = (DXLabel)null;
            }
            if (PriceLabelLabel != null)
            {
                if (!PriceLabelLabel.IsDisposed)
                    PriceLabelLabel.Dispose();
                PriceLabelLabel = (DXLabel)null;
            }
            if (HuntPriceLabel != null)
            {
                if (!HuntPriceLabel.IsDisposed)
                    HuntPriceLabel.Dispose();
                HuntPriceLabel = (DXLabel)null;
            }
            if (HuntPriceLabelLabel != null)
            {
                if (!HuntPriceLabelLabel.IsDisposed)
                    HuntPriceLabelLabel.Dispose();
                HuntPriceLabelLabel = (DXLabel)null;
            }
            if (FavouriteImage != null)
            {
                if (!FavouriteImage.IsDisposed)
                    FavouriteImage.Dispose();
                FavouriteImage = (DXButton)null;
            }
        }
    }

}
