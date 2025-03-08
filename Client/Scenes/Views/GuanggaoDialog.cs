using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Client.Controls;
using Client.Envir;
using Client.Models;
using Client.UserModels;
using Library;
using C = Library.Network.ClientPackets;


namespace Client.Scenes.Views
{
    public sealed class GuanggaoDialog : DXWindow
    {
        #region Properties
        private DXTabControl TabControl;
        public DXImageControl Image;


        public override WindowType Type => WindowType.GuanggaoBox;
        public override bool CustomSize => false;
        public override bool AutomaticVisiblity => false;

        #endregion

        public GuanggaoDialog()
        {
            HasTitle = true;
            SetClientSize(new Size(800, 600));
            Opacity = 0.6F;
            TitleLabel.Text = "活动栏";
            
            TabControl = new DXTabControl
            {
                Parent = this,
                Location = ClientArea.Location,
                Size = ClientArea.Size,
            };

            Image = new DXImageControl
            {
                LibraryFile = LibraryFile.Help,
                Index = 1,
                Location = new Point(-1, 0),
                Parent = TabControl,
            };

        }
    }
}
