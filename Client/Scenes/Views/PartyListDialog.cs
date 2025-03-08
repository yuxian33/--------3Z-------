using Client.Controls;
using Client.Envir;
using Client.UserModels;
using Library;
using SlimDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Client.Scenes.Views
{
    public sealed class PartyListDialog : DXWindow
    {
        public List<DXLabel> Lines = new List<DXLabel>();
        public List<DXControl> HealthBars = new List<DXControl>();
        public List<DXControl> ClassImages = new List<DXControl>();
        public List<ClientPlayerInfo> Members = new List<ClientPlayerInfo>();
        public DXControl TextPanel;

        public override WindowType Type
        {
            get
            {
                return WindowType.None;
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
                return false;
            }
        }

        public PartyListDialog()
        {
            HasTitle = false;
            HasFooter = false;
            HasTopBorder = false;
            TitleLabel.Visible = false;
            CloseButton.Visible = false;
            Opacity = 0.1f;
            AllowResize = true;
            TextPanel = new DXControl()
            {
                Parent = (DXControl)this,
                PassThrough = true,
                Location = new Point(9, 9),
                Size = new Size(250, 500)
            };
            Size = new Size(150, 100);
        }

        public void PopulateMembers()
        {
            foreach (DXControl line in Lines)
                line.Dispose();
            Lines.Clear();
            foreach (DXControl healthBar in HealthBars)
                healthBar.Dispose();
            HealthBars.Clear();
            foreach (DXControl classImage in ClassImages)
                classImage.Dispose();
            ClassImages.Clear();

            if (!Config.是否显示组队界面)
            {
                Visible = false;
            }
            else
            {
                MirLibrary mirLibrary;
                if (!CEnvir.LibraryList.TryGetValue(LibraryFile.GameInter, out mirLibrary))
                    return;
                MirImage image = mirLibrary.CreateImage(315, ImageType.Image);
                MirImage image2 = mirLibrary.CreateImage(316, ImageType.Image);

                foreach (ClientPlayerInfo member in GameScene.Game.GroupBox.Members)
                {
                    ClientObjectData clientObjectData;
                    if (!GameScene.Game.DataDictionary.TryGetValue(member.ObjectID, out clientObjectData))
                        return;
                    float percent = Math.Min(1f, Math.Max(0.0f, (float)clientObjectData.Health / (float)clientObjectData.MaxHealth));
                    string str1 = string.Join(" / ", (object)clientObjectData.Health, (object)clientObjectData.MaxHealth);
                    int index = 317;
                    string str3;



                    switch (member.Class)
                    {
                        case MirClass.Warrior:
                            index = 317;
                            break;
                        case MirClass.Wizard:
                            index = 318;
                            break;
                        case MirClass.Taoist:
                            index = 319;
                            break;
                        case MirClass.Assassin:
                            index = 320;
                            break;
                    }

                    if (Config.组队数字显血)
                        str3 = member.Name + "　（" + str1 + "）";
                    else
                        str3 = member.Name;

                    DXLabel dxLabel = new DXLabel();
                    dxLabel.Parent = TextPanel;
                    dxLabel.Text = str3;
                    dxLabel.Outline = true;
                    dxLabel.OutlineColour = Color.Black;
                    dxLabel.ForeColour = Color.FromArgb((int)byte.MaxValue, (int)byte.MaxValue, 0);
                    dxLabel.IsControl = false;

                    if (Config.组队数字显血)
                        dxLabel.Location = new Point(25, Lines.Count * 30);
                    else
                        dxLabel.Location = new Point(25, Lines.Count * 30);

                    Lines.Add(dxLabel);

                    DXControl HealthBar = new DXControl() { Parent = TextPanel, Location = new Point(28, Lines.Count * 30 - 12), Size = new Size(88, 6) };
                    HealthBars.Add(HealthBar);
                    HealthBar.BeforeDraw += (EventHandler<EventArgs>)((o, e) =>
                    {
                        
                        
                        if (image == null) return;

                        if ((double)percent < 1E-06) percent = 0;

                        Texture image1 = image2.Image;
                        DXControl parent1 = HealthBar;
                        Rectangle displayArea1 = HealthBar.DisplayArea;
                        int x1 = displayArea1.X;
                        displayArea1 = HealthBar.DisplayArea;
                        int y1 = displayArea1.Y;
                        int width1 = (int)image.Width;
                        int height1 = (int)image.Height;
                        Rectangle displayArea2 = new Rectangle(x1, y1, width1, height1);
                        Color white1 = Color.White;
                        DXControl control1 = HealthBar;
                        int offX1 = 0;
                        int offY1 = 0;
                        int num1 = 0;
                        double num2 = 1.0;
                        DXControl.PresentTexture(image1, parent1, displayArea2, white1, control1, offX1, offY1, num1 != 0, (float)num2);
                        Texture image3 = image.Image;
                        DXControl parent2 = HealthBar;
                        Rectangle displayArea3 = HealthBar.DisplayArea;
                        int x2 = displayArea3.X;
                        displayArea3 = HealthBar.DisplayArea;
                        int y2 = displayArea3.Y;
                        int width2 = (int)((double)image.Width * (double)percent);
                        int height2 = (int)image.Height;
                        Rectangle displayArea4 = new Rectangle(x2, y2, width2, height2);
                        Color white2 = Color.White;
                        DXControl control2 = HealthBar;
                        int offX2 = 0;
                        int offY2 = 0;
                        int num3 = 0;
                        double num4 = 1.0;
                        PresentTexture(image3, parent2, displayArea4, white2, control2, offX2, offY2, num3 != 0, (float)num4);

                    });

                    DXControl ClassImage = new DXControl() { Parent = TextPanel, Location = new Point(2, Lines.Count * 30 - 29), Size = new Size(21, 21) };
                    ClassImages.Add(ClassImage);
                    ClassImage.BeforeDraw += (EventHandler<EventArgs>)((o, e) =>
                    {

                        if ((double)percent < 1E-06 || (double)percent == 0)
                            index = 321;

                        MirImage image5 = mirLibrary.CreateImage(index, ImageType.Image);

                        if (image5 == null) return;

                        Texture image6 = image5.Image;
                        DXControl parent5 = ClassImage;
                        Rectangle displayArea5 = ClassImage.DisplayArea;
                        int x1 = displayArea5.X;
                        displayArea5 = ClassImage.DisplayArea;
                        int y1 = displayArea5.Y;
                        int width1 = (int)image5.Width;
                        int height1 = (int)image5.Height;
                        Rectangle displayArea6 = new Rectangle(x1, y1, width1, height1);
                        Color white1 = Color.White;
                        DXControl control1 = ClassImage;
                        int offX1 = 0;
                        int offY1 = 0;
                        int num1 = 0;
                        double num2 = 1.0;
                        DXControl.PresentTexture(image6, parent5, displayArea6, white1, control1, offX1, offY1, num1 != 0, (float)num2);
                    });
                }
                Visible = true;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing || TextPanel == null)
                return;
            if (!TextPanel.IsDisposed)
                TextPanel.Dispose();
            TextPanel = (DXControl)null;
            foreach (DXControl line in Lines)
                line.Dispose();
            Lines.Clear();
            foreach (DXControl healthBar in HealthBars)
                healthBar.Dispose();
            HealthBars.Clear();
            foreach (DXControl classImage in ClassImages)
                classImage.Dispose();
            ClassImages.Clear();
        }
    }
}
