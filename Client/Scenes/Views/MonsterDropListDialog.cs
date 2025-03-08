using Client.Controls;
using Client.UserModels;
using Library;
using Library.SystemModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Client.Scenes.Views
{
    public sealed class MonsterDropListDialog : DXWindow
    {
        public List<MonsterInfo> MonsterList = new List<MonsterInfo>();
        public DXTextBox ItemNameBox;
        public DXButton SearchButton;
        public MonsterDropRow Header;
        public DXVScrollBar ScrollBar;
        public MonsterDropRow[] Rows;

        /*
        public override void OnVisibleChanged(bool oValue, bool nValue)
        {
            base.OnVisibleChanged(oValue, nValue);
            if (Visible || GameScene.Game.ReadMailBox == null)
                return;
            GameScene.Game.ReadMailBox.Visible = false;
        }
        */

        public override void OnIsVisibleChanged(bool oValue, bool nValue)
        {
            base.OnIsVisibleChanged(oValue, nValue);
            if (!IsVisible)
                return;
            RefreshList();
        }

        public override WindowType Type
        {
            get
            {
                return WindowType.MonsterDropWindow;
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

        public MonsterDropListDialog()
        {
            TitleLabel.Text = "怪物爆率查询";
            HasFooter = false;
            SetClientSize(new Size(350, 360));
            DXControl dxControl1 = new DXControl();
            dxControl1.Parent = this;
            dxControl1.Size = new Size(ClientArea.Width, 26);
            Rectangle clientArea1 = ClientArea;
            int left1 = clientArea1.Left;
            clientArea1 = ClientArea;
            int top = clientArea1.Top;
            dxControl1.Location = new Point(left1, top);
            dxControl1.Border = true;
            dxControl1.BorderColour = Color.FromArgb(198, 166, 99);
            DXControl dxControl2 = dxControl1;
            DXLabel dxLabel1 = new DXLabel();
            dxLabel1.Parent = dxControl2;
            dxLabel1.Location = new Point(5, 5);
            dxLabel1.Text = "名称:";
            DXLabel dxLabel2 = dxLabel1;
            DXTextBox dxTextBox = new DXTextBox();
            dxTextBox.Parent = dxControl2;
            dxTextBox.Size = new Size(180, 20);
            Point location1 = dxLabel2.Location;
            int x1 = location1.X + dxLabel2.Size.Width + 5;
            location1 = dxLabel2.Location;
            int y1 = location1.Y;
            dxTextBox.Location = new Point(x1, y1);
            ItemNameBox = dxTextBox;
            ItemNameBox.TextBox.KeyPress += (s, e) =>
            {
                if (e.KeyChar != '\r')
                    return;
                e.Handled = true;
                if (SearchButton.Enabled)
                    Search();
            };
            DXButton dxButton = new DXButton();
            dxButton.Size = new Size(80, SmallButtonHeight);
            Point location2 = ItemNameBox.Location;
            int x2 = location2.X + ItemNameBox.Size.Width + 15;
            location2 = dxLabel2.Location;
            int y2 = location2.Y - 1;
            dxButton.Location = new Point(x2, y2);
            dxButton.Parent = dxControl2;
            dxButton.ButtonType = ButtonType.SmallButton;
            dxButton.Label.Text = "查找";
            SearchButton = dxButton;
            SearchButton.MouseClick += (o, e) => Search();
            MonsterList.AddRange(CartoonGlobals.MonsterInfoList.Binding);
            MonsterDropRow monsterDropRow1 = new MonsterDropRow();
            monsterDropRow1.Parent = (DXControl)this;
            Rectangle clientArea2 = ClientArea;
            int left2 = clientArea2.Left;
            clientArea2 = ClientArea;
            int y3 = clientArea2.Y + dxControl2.Size.Height + 5;
            monsterDropRow1.Location = new Point(left2, y3);
            monsterDropRow1.IsHeader = true;
            Header = monsterDropRow1;
            Rows = new MonsterDropRow[15];
            DXVScrollBar dxvScrollBar = new DXVScrollBar();
            dxvScrollBar.Parent = (DXControl)this;
            dxvScrollBar.Size = new Size(14, ClientArea.Height - 2 - 22);
            Rectangle clientArea3 = ClientArea;
            int x3 = clientArea3.Right - 14;
            clientArea3 = ClientArea;
            int y4 = clientArea3.Top + 1 + 27;
            dxvScrollBar.Location = new Point(x3, y4);
            dxvScrollBar.VisibleSize = 15;
            dxvScrollBar.Change = 3;
            ScrollBar = dxvScrollBar;
            ScrollBar.ValueChanged += new EventHandler<EventArgs>(ScrollBar_ValueChanged);
            MouseWheel += new EventHandler<MouseEventArgs>(ScrollBar.DoMouseWheel);
            DXControl dxControl3 = new DXControl();
            dxControl3.Parent = (DXControl)this;
            Point location3 = ClientArea.Location;
            int x4 = location3.X;
            location3 = ClientArea.Location;
            int y5 = location3.Y + dxControl2.Size.Height + 5 + Header.Size.Height + 2;
            dxControl3.Location = new Point(x4, y5);
            Rectangle clientArea4 = ClientArea;
            int width = clientArea4.Width - 16;
            clientArea4 = ClientArea;
            Size size = clientArea4.Size;
            int num = size.Height - 22;
            size = dxControl2.Size;
            int height1 = size.Height;
            int height2 = num - height1 - 5;
            dxControl3.Size = new Size(width, height2);
            DXControl dxControl4 = dxControl3;
            for (int index1 = 0; index1 < 15; ++index1)
            {
                int index = index1;
                MonsterDropRow[] rows = Rows;
                int index2 = index;
                MonsterDropRow monsterDropRow2 = new MonsterDropRow();
                monsterDropRow2.Parent = dxControl4;
                monsterDropRow2.Location = new Point(0, 22 * index1);
                monsterDropRow2.Visible = false;
                rows[index2] = monsterDropRow2;
                Rows[index].MouseClick += ((o, e) => GameScene.Game.MonsterDropItemsBox.Bind(Rows[index].Monster));
                Rows[index].MouseWheel += new EventHandler<MouseEventArgs>(ScrollBar.DoMouseWheel);
            }
        }

        public void Search()
        {
            MonsterList = new List<MonsterInfo>();
            ScrollBar.MaxValue = 0;
            foreach (DXControl row in Rows)
                row.Visible = true;
            foreach (MonsterInfo monsterInfo in (IEnumerable<MonsterInfo>)CartoonGlobals.MonsterInfoList.Binding)
            {
                if (monsterInfo.Drops.Count != 0 && (string.IsNullOrEmpty(ItemNameBox.TextBox.Text) || monsterInfo.MonsterName.IndexOf(ItemNameBox.TextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0))
                    MonsterList.Add(monsterInfo);
            }
            RefreshList();
        }

        private void ScrollBar_ValueChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        public void RefreshList()
        {
            if (Rows == null)
                return;
            MonsterList.Sort((Comparison<MonsterInfo>)((x1, x2) => x1.Index.CompareTo(x2.Index)));
            ScrollBar.MaxValue = MonsterList.Count;
            for (int index = 0; index < Rows.Length; ++index)
                Rows[index].Monster = index + ScrollBar.Value < MonsterList.Count ? MonsterList[index + ScrollBar.Value] : (MonsterInfo)null;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing)
                return;
            if (Header != null)
            {
                if (!Header.IsDisposed)
                    Header.Dispose();
                Header = (MonsterDropRow)null;
            }
            if (ScrollBar != null)
            {
                if (!ScrollBar.IsDisposed)
                    ScrollBar.Dispose();
                ScrollBar = (DXVScrollBar)null;
            }
            if (Rows != null)
            {
                for (int index = 0; index < Rows.Length; ++index)
                {
                    if (Rows[index] != null)
                    {
                        if (!Rows[index].IsDisposed)
                            Rows[index].Dispose();
                        Rows[index] = (MonsterDropRow)null;
                    }
                }
                Rows = (MonsterDropRow[])null;
            }
            MonsterList.Clear();
            MonsterList = (List<MonsterInfo>)null;
        }
    }
}
