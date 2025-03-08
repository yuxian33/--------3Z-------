





using Client.Controls;
using Client.Envir;
using Library;
using Library.Network;
using Library.Network.ClientPackets;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client.Scenes.Views
{
  public sealed class TreasureChest : DXImageControl
  {
    public DXItemGrid[] TreasureGrid = new DXItemGrid[15];
    public DXButton Decision;
    public DXButton Reset;
    public DXImageControl Number;
    public DXLabel ExplainLabel;
    public DXLabel NumberLabel;
    public ClientUserItem[] TreasureArray;

    public TreasureChest()
    {
      LibraryFile = LibraryFile.GameInter2;
      Index = 2900;
      DXButton dxButton1 = new DXButton();
      dxButton1.Parent = this;
      dxButton1.LibraryFile = LibraryFile.GameInter2;
      dxButton1.Index = 2912;
      dxButton1.Location = new Point(160, 245);
      Decision = dxButton1;
      Decision.MouseClick += (o, e) =>
      {
        GameScene.Game.TreasureChestBox.Visible = false;
        GameScene.Game.LuckDrawBox.Visible = true;
      };
      DXImageControl dxImageControl = new DXImageControl();
      dxImageControl.Parent = this;
      dxImageControl.LibraryFile = LibraryFile.GameInter2;
      dxImageControl.Index = 2921;
      dxImageControl.Location = new Point(15, 235);
      Number = dxImageControl;
      DXLabel dxLabel1 = new DXLabel();
      dxLabel1.Parent = (DXControl) Number;
      dxLabel1.BorderColour = Color.FromArgb(99, 83, 50);
      dxLabel1.ForeColour = Color.Moccasin;
      dxLabel1.Text = "开启次数：5次";
      dxLabel1.Location = new Point(15, 2);
      NumberLabel = dxLabel1;
      DXButton dxButton2 = new DXButton();
      dxButton2.Parent = (DXControl) this;
      dxButton2.LibraryFile = LibraryFile.GameInter2;
      dxButton2.Index = 2926;
      dxButton2.BorderColour = Color.FromArgb(99, 83, 50);
      dxButton2.ForeColour = Color.White;
      dxButton2.Label.Text = "重置（500元宝）";
      dxButton2.Location = new Point(15, 260);
      dxButton2.Visible = true;
      Reset = dxButton2;
      Reset.MouseClick += (o, e) => CEnvir.Enqueue( new TreasureChange());
      DXLabel dxLabel2 = new DXLabel();
      dxLabel2.Parent = this;
      dxLabel2.BorderColour = Color.FromArgb(99, 83, 50);
      dxLabel2.ForeColour = Color.White;
      dxLabel2.Font = new Font(Config.FontName, CEnvir.FontSize(10f), FontStyle.Bold);
      dxLabel2.Text = "可获得的奖励道具。\n没有想要的奖励道具，\n可以选择重置。";
      dxLabel2.Location = new Point(15, 170);
      ExplainLabel = dxLabel2;
      for (int index1 = 0; index1 < TreasureGrid.Length; ++index1)
      {
        DXItemGrid[] treasureGrid = TreasureGrid;
        int index2 = index1;
        DXItemGrid dxItemGrid1 = new DXItemGrid();
        dxItemGrid1.Parent = (DXControl) this;
        dxItemGrid1.Location = new Point(22 + index1 % 5 * 44, 28 + index1 / 5 * 44);
        dxItemGrid1.GridSize = new Size(1, 1);
        dxItemGrid1.ItemGrid = new ClientUserItem[1];
        dxItemGrid1.ReadOnly = true;
        DXItemGrid dxItemGrid2 = dxItemGrid1;
        treasureGrid[index2] = dxItemGrid2;
      }
    }
  }
}
