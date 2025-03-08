using Client.Controls;
using Library;
using System.Drawing;

namespace Client.Scenes.Views
{
    public sealed class BeltDialogVertical : BeltDialog
    {
        public BeltDialogVertical()
        {
            Size size1 = Size;
            int height1 = size1.Height;
            size1 = Size;
            int width1 = size1.Width;
            Size = new Size(height1, width1);
            DXItemGrid grid = Grid;
            Size size2 = Grid.Size;
            int height2 = size2.Height;
            size2 = Grid.Size;
            int width2 = size2.Width;
            Size size3 = new Size(height2, width2);
            grid.Size = size3;
            Background.Index = 1301;
        }
    }
}
