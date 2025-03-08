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
  public sealed class LuckDraw : DXImageControl
  {
    public DXItemGrid[] TreasureGrid = new DXItemGrid[15];
    public DXImageControl[] GridImage = new DXImageControl[15];
    public DXButton End;
    public DXLabel ChoiceLabel;
    public ClientUserItem[] TreasureArray;

    public LuckDraw()
    {
      LibraryFile = LibraryFile.GameInter2;
      Index = 2900;
      DXLabel dxLabel = new DXLabel();
      dxLabel.Parent = (DXControl) this;
      dxLabel.BorderColour = Color.FromArgb(99, 83, 50);
      dxLabel.ForeColour = Color.White;
      dxLabel.Font = new Font(Config.FontName, CEnvir.FontSize(10f), FontStyle.Bold);
      dxLabel.Text = "确定选择奖励道具列表。\n请选择（首次免费）。";
      dxLabel.Location = new Point(15, 170);
      ChoiceLabel = dxLabel;
      DXButton dxButton = new DXButton();
      dxButton.Parent = (DXControl) this;
      dxButton.LibraryFile = LibraryFile.GameInter2;
      dxButton.Index = 2917;
      dxButton.Location = new Point(90, 245);
      End = dxButton;
      End.MouseClick += (EventHandler<MouseEventArgs>) ((o, e) =>
      {
        for (int index = 0; index < TreasureGrid.Length; ++index)
          TreasureGrid[index].ItemGrid[0] = (ClientUserItem) null;
        for (int index = 0; index < TreasureGrid.Length; ++index)
          GridImage[index].Visible = true;
        ChoiceLabel.Text = "确定选择奖励道具列表。\n请选择（首次免费）。";
        Visible = false;
      });
      for (int index1 = 0; index1 < TreasureGrid.Length; ++index1)
      {
        DXImageControl[] gridImage = GridImage;
        int index2 = index1;
        DXImageControl dxImageControl = new DXImageControl();
        dxImageControl.Parent = (DXControl) this;
        dxImageControl.LibraryFile = LibraryFile.GameInter2;
        dxImageControl.Index = 2930;
        dxImageControl.Location = new Point(22 + index1 % 5 * 44, 28 + index1 / 5 * 44);
        gridImage[index2] = dxImageControl;
      }
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
        dxItemGrid1.Opacity = 0.5f;
        dxItemGrid1.Tag = (object) index1;
        DXItemGrid dxItemGrid2 = dxItemGrid1;
        treasureGrid[index2] = dxItemGrid2;
        foreach (DXItemCell dxItemCell in TreasureGrid[index1].Grid)
        {
          DXItemCell cell = dxItemCell;
          cell.MouseDoubleClick += (EventHandler<MouseEventArgs>) ((o, e) =>
          {
            if (cell.Item != null)
              return;
            CEnvir.Enqueue((Packet) new TreasureSelect()
            {
              Slot = (int) cell.Parent.Tag
            });
          });
        }
      }
    }
  }
}
