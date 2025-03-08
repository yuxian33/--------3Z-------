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
    public sealed class FubenMonsterDropItemsDialog : DXWindow
    {
        public DXVScrollBar SearchScrollBar;
        public List<DropInfo> SearchResults;
        private FubenMonsterDropItemRow[] SearchRows;

        public override WindowType Type
        {
            get { return WindowType.None; }
        }

        public override bool CustomSize
        {
            get { return false; }
        }

        public override bool AutomaticVisiblity
        {
            get { return false; }
        }

        public FubenMonsterDropItemsDialog()
        {
            TitleLabel.Text = "副本掉落";
            SetClientSize(new Size(191, 486));
            SearchRows = new FubenMonsterDropItemRow[8];
            DXVScrollBar dxvScrollBar = new DXVScrollBar();
            dxvScrollBar.Parent = (DXControl)this;
            dxvScrollBar.Location = new Point(ClientArea.Size.Width - 14 + ClientArea.Left, ClientArea.Y + 5);
            dxvScrollBar.Size = new Size(14, ClientArea.Height - 5);
            dxvScrollBar.VisibleSize = SearchRows.Length;
            dxvScrollBar.Change = 3;
            SearchScrollBar = dxvScrollBar;
            SearchScrollBar.ValueChanged += new EventHandler<EventArgs>(SearchScrollBar_ValueChanged);
            for (int index1 = 0; index1 < SearchRows.Length; ++index1)
            {
                int index2 = index1;
                FubenMonsterDropItemRow[] searchRows = SearchRows;
                int index3 = index2;
                FubenMonsterDropItemRow monsterDropItemRow = new FubenMonsterDropItemRow();
                monsterDropItemRow.Parent = (DXControl)this;
                Rectangle clientArea = ClientArea;
                int x = clientArea.X;
                clientArea = ClientArea;
                int y = clientArea.Y + 5 + index1 * 60;
                monsterDropItemRow.Location = new Point(x, y);
                searchRows[index3] = monsterDropItemRow;
                SearchRows[index2].MouseWheel += new EventHandler<MouseEventArgs>(SearchScrollBar.DoMouseWheel);
            }
        }

        public void Bind(MonsterInfo monster)
        {
            SearchResults = new List<DropInfo>();
            SearchScrollBar.MaxValue = 0;
            foreach (DXControl searchRow in SearchRows)
                searchRow.Visible = true;
            foreach (DropInfo dropInfo in CartoonGlobals.DropInfoList.Binding)
            {
                if (dropInfo.Monster == monster)
                    SearchResults.Add(dropInfo);
            }
            RefreshList();
            Visible = true;
            TitleLabel.Text = "副本掉落";
        }

        public void RefreshList()
        {
            if (SearchResults == null)
                return;
            SearchScrollBar.MaxValue = SearchResults.Count;
            for (int index = 0; index < SearchRows.Length; ++index)
            {
                if (index + SearchScrollBar.Value >= SearchResults.Count)
                {
                    SearchRows[index].DropInfo = (DropInfo)null;
                    SearchRows[index].Visible = false;
                }
                else
                    SearchRows[index].DropInfo = SearchResults[index + SearchScrollBar.Value];
            }
        }

        private void SearchScrollBar_ValueChanged(object sender, EventArgs e)
        {
            RefreshList();
        }
    }
}
