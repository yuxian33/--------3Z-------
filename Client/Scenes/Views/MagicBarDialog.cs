using Client.Controls;
using Client.Envir;
using Client.Models;
using Client.UserModels;
using Library;
using Library.SystemModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Client.Scenes.Views
{
    public sealed class MagicBarDialog : DXWindow
    {
        private Dictionary<SpellKey, DXImageControl> Icons = new Dictionary<SpellKey, DXImageControl>();
        private Dictionary<SpellKey, DXLabel> Cooldowns = new Dictionary<SpellKey, DXLabel>();
        private int _SpellSet;
        public DXButton UpButton;
        public DXButton DownButton;
        public DXButton CloseBtn;
        public DXLabel SetLabel;
        public DXImageControl Background;

        public int SpellSet
        {
            get
            {
                return _SpellSet;
            }
            set
            {
                if (_SpellSet == value)
                    return;
                int spellSet = _SpellSet;
                _SpellSet = value;
                OnSpellSetChanged(spellSet, value);
            }
        }

        public event EventHandler<EventArgs> SpellSetChanged;

        public void OnSpellSetChanged(int oValue, int nValue)
        {
            
            EventHandler<EventArgs> spellSetChanged = SpellSetChanged;
            if (spellSetChanged != null)
                spellSetChanged((object)this, EventArgs.Empty);
            UpdateIcons();
            using (Dictionary<MagicInfo, MagicCell>.Enumerator enumerator = GameScene.Game.MagicBox.Magics.GetEnumerator())
            {
                while (enumerator.MoveNext())
                    enumerator.Current.Value.Refresh();
            }
        }

        public override WindowType Type
        {
            get
            {
                return WindowType.MagicBarBox;
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

        public MagicBarDialog()
        {
            Size = new Size(672, 66);
            _SpellSet = 1;
            Opacity = 0.0f;
            CloseButton.Visible = false;
            DXImageControl dxImageControl1 = new DXImageControl();
            dxImageControl1.Index = 900;
            dxImageControl1.Size = Size;
            dxImageControl1.LibraryFile = (LibraryFile)4;
            dxImageControl1.Parent = (DXControl)this;
            Background = dxImageControl1;
            Background.MouseDown += new EventHandler<MouseEventArgs>(Background_MouseDown);
            int x1 = 45;
            int y1 = 13;
            Size size1 = new Size(45, 44);
            Dictionary<SpellKey, DXImageControl> icons1 = Icons;
            int num1 = 1;
            DXImageControl dxImageControl2 = new DXImageControl();
            dxImageControl2.Parent = (DXControl)this;
            dxImageControl2.LibraryFile = (LibraryFile)19;
            dxImageControl2.Location = new Point(x1, y1);
            dxImageControl2.DrawTexture = true;
            dxImageControl2.BackColour = Color.FromArgb(20, 20, 20);
            dxImageControl2.Border = false;
            dxImageControl2.BorderColour = Color.FromArgb(198, 166, 99);
            dxImageControl2.Size = size1;
            dxImageControl2.Opacity = 0.6f;
            icons1[(SpellKey)num1] = dxImageControl2;
            DXImageControl dxImageControl3 = new DXImageControl();
            dxImageControl3.Parent = (DXControl)this;
            dxImageControl3.LibraryFile = (LibraryFile)3;
            dxImageControl3.Index = 1660;
            dxImageControl3.Location = Icons[(SpellKey)1].Location;
            Dictionary<SpellKey, DXImageControl> icons2 = Icons;
            int num2 = 2;
            DXImageControl dxImageControl4 = new DXImageControl();
            dxImageControl4.Parent = (DXControl)this;
            dxImageControl4.LibraryFile = (LibraryFile)19;
            dxImageControl4.Location = new Point(x1 + size1.Width + 3, y1);
            dxImageControl4.DrawTexture = true;
            dxImageControl4.BackColour = Color.FromArgb(20, 20, 20);
            dxImageControl4.Border = false;
            dxImageControl4.BorderColour = Color.FromArgb(198, 166, 99);
            dxImageControl4.Size = size1;
            dxImageControl4.Opacity = 0.6f;
            icons2[(SpellKey)num2] = dxImageControl4;
            DXImageControl dxImageControl5 = new DXImageControl();
            dxImageControl5.Parent = (DXControl)this;
            dxImageControl5.LibraryFile = (LibraryFile)3;
            dxImageControl5.Index = 1661;
            dxImageControl5.Location = Icons[(SpellKey)2].Location;
            Dictionary<SpellKey, DXImageControl> icons3 = Icons;
            int num3 = 3;
            DXImageControl dxImageControl6 = new DXImageControl();
            dxImageControl6.Parent = (DXControl)this;
            dxImageControl6.LibraryFile = (LibraryFile)19;
            dxImageControl6.Location = new Point(x1 + (size1.Width + 3) * 2, y1);
            dxImageControl6.DrawTexture = true;
            dxImageControl6.BackColour = Color.FromArgb(20, 20, 20);
            dxImageControl6.Border = false;
            dxImageControl6.BorderColour = Color.FromArgb(198, 166, 99);
            dxImageControl6.Size = size1;
            dxImageControl6.Opacity = 0.6f;
            icons3[(SpellKey)num3] = dxImageControl6;
            DXImageControl dxImageControl7 = new DXImageControl();
            dxImageControl7.Parent = (DXControl)this;
            dxImageControl7.LibraryFile = (LibraryFile)3;
            dxImageControl7.Index = 1662;
            dxImageControl7.Location = Icons[(SpellKey)3].Location;
            Dictionary<SpellKey, DXImageControl> icons4 = Icons;
            int num4 = 4;
            DXImageControl dxImageControl8 = new DXImageControl();
            dxImageControl8.Parent = (DXControl)this;
            dxImageControl8.LibraryFile = (LibraryFile)19;
            dxImageControl8.Location = new Point(x1 + (size1.Width + 3) * 3, y1);
            dxImageControl8.DrawTexture = true;
            dxImageControl8.BackColour = Color.FromArgb(20, 20, 20);
            dxImageControl8.Border = false;
            dxImageControl8.BorderColour = Color.FromArgb(198, 166, 99);
            dxImageControl8.Size = size1;
            dxImageControl8.Opacity = 0.6f;
            icons4[(SpellKey)num4] = dxImageControl8;
            DXImageControl dxImageControl9 = new DXImageControl();
            dxImageControl9.Parent = (DXControl)this;
            dxImageControl9.LibraryFile = (LibraryFile)3;
            dxImageControl9.Index = 1663;
            dxImageControl9.Location = Icons[(SpellKey)4].Location;
            int num5 = x1 + 5;
            Dictionary<SpellKey, DXImageControl> icons5 = Icons;
            int num6 = 5;
            DXImageControl dxImageControl10 = new DXImageControl();
            dxImageControl10.Parent = (DXControl)this;
            dxImageControl10.LibraryFile = (LibraryFile)19;
            dxImageControl10.Location = new Point(num5 + (size1.Width + 2) * 4, y1);
            dxImageControl10.DrawTexture = true;
            dxImageControl10.BackColour = Color.FromArgb(20, 20, 20);
            dxImageControl10.Border = false;
            dxImageControl10.BorderColour = Color.FromArgb(198, 166, 99);
            dxImageControl10.Size = size1;
            dxImageControl10.Opacity = 0.6f;
            icons5[(SpellKey)num6] = dxImageControl10;
            DXImageControl dxImageControl11 = new DXImageControl();
            dxImageControl11.Parent = (DXControl)this;
            dxImageControl11.LibraryFile = (LibraryFile)3;
            dxImageControl11.Index = 1664;
            dxImageControl11.Location = Icons[(SpellKey)5].Location;
            Dictionary<SpellKey, DXImageControl> icons6 = Icons;
            int num7 = 6;
            DXImageControl dxImageControl12 = new DXImageControl();
            dxImageControl12.Parent = (DXControl)this;
            dxImageControl12.LibraryFile = (LibraryFile)19;
            dxImageControl12.Location = new Point(num5 + (size1.Width + 2) * 5, y1);
            dxImageControl12.DrawTexture = true;
            dxImageControl12.BackColour = Color.FromArgb(20, 20, 20);
            dxImageControl12.Border = false;
            dxImageControl12.BorderColour = Color.FromArgb(198, 166, 99);
            dxImageControl12.Size = size1;
            dxImageControl12.Opacity = 0.6f;
            icons6[(SpellKey)num7] = dxImageControl12;
            DXImageControl dxImageControl13 = new DXImageControl();
            dxImageControl13.Parent = (DXControl)this;
            dxImageControl13.LibraryFile = (LibraryFile)3;
            dxImageControl13.Index = 1665;
            dxImageControl13.Location = Icons[(SpellKey)6].Location;
            Dictionary<SpellKey, DXImageControl> icons7 = Icons;
            int num8 = 7;
            DXImageControl dxImageControl14 = new DXImageControl();
            dxImageControl14.Parent = (DXControl)this;
            dxImageControl14.LibraryFile = (LibraryFile)19;
            dxImageControl14.Location = new Point(num5 + (size1.Width + 2) * 6, y1);
            dxImageControl14.DrawTexture = true;
            dxImageControl14.BackColour = Color.FromArgb(20, 20, 20);
            dxImageControl14.Border = false;
            dxImageControl14.BorderColour = Color.FromArgb(198, 166, 99);
            dxImageControl14.Size = size1;
            dxImageControl14.Opacity = 0.6f;
            icons7[(SpellKey)num8] = dxImageControl14;
            DXImageControl dxImageControl15 = new DXImageControl();
            dxImageControl15.Parent = (DXControl)this;
            dxImageControl15.LibraryFile = (LibraryFile)3;
            dxImageControl15.Index = 1666;
            dxImageControl15.Location = Icons[(SpellKey)7].Location;
            Dictionary<SpellKey, DXImageControl> icons8 = Icons;
            int num9 = 8;
            DXImageControl dxImageControl16 = new DXImageControl();
            dxImageControl16.Parent = (DXControl)this;
            dxImageControl16.LibraryFile = (LibraryFile)19;
            dxImageControl16.Location = new Point(num5 + (size1.Width + 2) * 7, y1);
            dxImageControl16.DrawTexture = true;
            dxImageControl16.BackColour = Color.FromArgb(20, 20, 20);
            dxImageControl16.Border = false;
            dxImageControl16.BorderColour = Color.FromArgb(198, 166, 99);
            dxImageControl16.Size = size1;
            dxImageControl16.Opacity = 0.6f;
            icons8[(SpellKey)num9] = dxImageControl16;
            DXImageControl dxImageControl17 = new DXImageControl();
            dxImageControl17.Parent = (DXControl)this;
            dxImageControl17.LibraryFile = (LibraryFile)3;
            dxImageControl17.Index = 1667;
            dxImageControl17.Location = Icons[(SpellKey)8].Location;
            int num10 = num5 + 5;
            Dictionary<SpellKey, DXImageControl> icons9 = Icons;
            int num11 = 9;
            DXImageControl dxImageControl18 = new DXImageControl();
            dxImageControl18.Parent = (DXControl)this;
            dxImageControl18.LibraryFile = (LibraryFile)19;
            dxImageControl18.Location = new Point(num10 + (size1.Width + 2) * 8, y1);
            dxImageControl18.DrawTexture = true;
            dxImageControl18.BackColour = Color.FromArgb(20, 20, 20);
            dxImageControl18.Border = false;
            dxImageControl18.BorderColour = Color.FromArgb(198, 166, 99);
            dxImageControl18.Size = size1;
            dxImageControl18.Opacity = 0.6f;
            icons9[(SpellKey)num11] = dxImageControl18;
            DXImageControl dxImageControl19 = new DXImageControl();
            dxImageControl19.Parent = (DXControl)this;
            dxImageControl19.LibraryFile = (LibraryFile)3;
            dxImageControl19.Index = 1668;
            dxImageControl19.Location = Icons[(SpellKey)9].Location;
            Dictionary<SpellKey, DXImageControl> icons10 = Icons;
            int num12 = 10;
            DXImageControl dxImageControl20 = new DXImageControl();
            dxImageControl20.Parent = (DXControl)this;
            dxImageControl20.LibraryFile = (LibraryFile)19;
            dxImageControl20.Location = new Point(num10 + (size1.Width + 2) * 9, y1);
            dxImageControl20.DrawTexture = true;
            dxImageControl20.BackColour = Color.FromArgb(20, 20, 20);
            dxImageControl20.Border = false;
            dxImageControl20.BorderColour = Color.FromArgb(198, 166, 99);
            dxImageControl20.Size = size1;
            dxImageControl20.Opacity = 0.6f;
            icons10[(SpellKey)num12] = dxImageControl20;
            DXImageControl dxImageControl21 = new DXImageControl();
            dxImageControl21.Parent = (DXControl)this;
            dxImageControl21.LibraryFile = (LibraryFile)3;
            dxImageControl21.Index = 1669;
            dxImageControl21.Location = Icons[(SpellKey)10].Location;
            Dictionary<SpellKey, DXImageControl> icons11 = Icons;
            int num13 = 11;
            DXImageControl dxImageControl22 = new DXImageControl();
            dxImageControl22.Parent = (DXControl)this;
            dxImageControl22.LibraryFile = (LibraryFile)19;
            dxImageControl22.Location = new Point(num10 + (size1.Width + 2) * 10, y1);
            dxImageControl22.DrawTexture = true;
            dxImageControl22.BackColour = Color.FromArgb(20, 20, 20);
            dxImageControl22.Border = false;
            dxImageControl22.BorderColour = Color.FromArgb(198, 166, 99);
            dxImageControl22.Size = size1;
            dxImageControl22.Opacity = 0.6f;
            icons11[(SpellKey)num13] = dxImageControl22;
            DXImageControl dxImageControl23 = new DXImageControl();
            dxImageControl23.Parent = (DXControl)this;
            dxImageControl23.LibraryFile = (LibraryFile)3;
            dxImageControl23.Index = 1670;
            dxImageControl23.Location = Icons[(SpellKey)11].Location;
            Dictionary<SpellKey, DXImageControl> icons12 = Icons;
            int num14 = 12;
            DXImageControl dxImageControl24 = new DXImageControl();
            dxImageControl24.Parent = (DXControl)this;
            dxImageControl24.LibraryFile = (LibraryFile)19;
            dxImageControl24.Location = new Point(num10 + (size1.Width + 2) * 11, y1);
            dxImageControl24.DrawTexture = true;
            dxImageControl24.BackColour = Color.FromArgb(20, 20, 20);
            dxImageControl24.Border = false;
            dxImageControl24.BorderColour = Color.FromArgb(198, 166, 99);
            dxImageControl24.Size = size1;
            dxImageControl24.Opacity = 0.6f;
            icons12[(SpellKey)num14] = dxImageControl24;
            DXImageControl dxImageControl25 = new DXImageControl();
            dxImageControl25.Parent = (DXControl)this;
            dxImageControl25.LibraryFile = (LibraryFile)3;
            dxImageControl25.Index = 1671;
            dxImageControl25.Location = Icons[(SpellKey)12].Location;
            int x2 = ClientArea.X;
            Dictionary<SpellKey, DXImageControl> icons13 = Icons;
            int num15 = 13;
            DXImageControl dxImageControl26 = new DXImageControl();
            dxImageControl26.Parent = (DXControl)this;
            dxImageControl26.LibraryFile = (LibraryFile)19;
            dxImageControl26.Location = new Point(x2, y1 + 37 + 5);
            dxImageControl26.DrawTexture = true;
            dxImageControl26.BackColour = Color.FromArgb(20, 20, 20);
            dxImageControl26.Border = false;
            dxImageControl26.BorderColour = Color.FromArgb(198, 166, 99);
            dxImageControl26.Size = size1;
            dxImageControl26.Opacity = 0.6f;
            dxImageControl26.Visible = false;
            icons13[(SpellKey)num15] = dxImageControl26;
            Dictionary<SpellKey, DXImageControl> icons14 = Icons;
            int num16 = 14;
            DXImageControl dxImageControl27 = new DXImageControl();
            dxImageControl27.Parent = (DXControl)this;
            dxImageControl27.LibraryFile = (LibraryFile)19;
            dxImageControl27.Location = new Point(x2 + size1.Width + 3, y1 + 37 + 5);
            dxImageControl27.DrawTexture = true;
            dxImageControl27.BackColour = Color.FromArgb(20, 20, 20);
            dxImageControl27.Border = false;
            dxImageControl27.BorderColour = Color.FromArgb(198, 166, 99);
            dxImageControl27.Size = size1;
            dxImageControl27.Opacity = 0.6f;
            dxImageControl27.Visible = false;
            icons14[(SpellKey)num16] = dxImageControl27;
            Dictionary<SpellKey, DXImageControl> icons15 = Icons;
            int num17 = 15;
            DXImageControl dxImageControl28 = new DXImageControl();
            dxImageControl28.Parent = (DXControl)this;
            dxImageControl28.LibraryFile = (LibraryFile)19;
            dxImageControl28.Location = new Point(x2 + (size1.Width + 3) * 2, y1 + 37 + 5);
            dxImageControl28.DrawTexture = true;
            dxImageControl28.BackColour = Color.FromArgb(20, 20, 20);
            dxImageControl28.Border = false;
            dxImageControl28.BorderColour = Color.FromArgb(198, 166, 99);
            dxImageControl28.Size = size1;
            dxImageControl28.Opacity = 0.6f;
            dxImageControl28.Visible = false;
            icons15[(SpellKey)num17] = dxImageControl28;
            Dictionary<SpellKey, DXImageControl> icons16 = Icons;
            int num18 = 16;
            DXImageControl dxImageControl29 = new DXImageControl();
            dxImageControl29.Parent = (DXControl)this;
            dxImageControl29.LibraryFile = (LibraryFile)19;
            dxImageControl29.Location = new Point(x2 + (size1.Width + 3) * 3, y1 + 37 + 5);
            dxImageControl29.DrawTexture = true;
            dxImageControl29.BackColour = Color.FromArgb(20, 20, 20);
            dxImageControl29.Border = false;
            dxImageControl29.BorderColour = Color.FromArgb(198, 166, 99);
            dxImageControl29.Size = size1;
            dxImageControl29.Opacity = 0.6f;
            dxImageControl29.Visible = false;
            icons16[(SpellKey)num18] = dxImageControl29;
            int num19 = x2 + 5;
            Dictionary<SpellKey, DXImageControl> icons17 = Icons;
            int num20 = 17;
            DXImageControl dxImageControl30 = new DXImageControl();
            dxImageControl30.Parent = (DXControl)this;
            dxImageControl30.LibraryFile = (LibraryFile)19;
            dxImageControl30.Location = new Point(num19 + (size1.Width + 3) * 4, y1 + 37 + 5);
            dxImageControl30.DrawTexture = true;
            dxImageControl30.BackColour = Color.FromArgb(20, 20, 20);
            dxImageControl30.Border = false;
            dxImageControl30.BorderColour = Color.FromArgb(198, 166, 99);
            dxImageControl30.Size = size1;
            dxImageControl30.Opacity = 0.6f;
            dxImageControl30.Visible = false;
            icons17[(SpellKey)num20] = dxImageControl30;
            Dictionary<SpellKey, DXImageControl> icons18 = Icons;
            int num21 = 18;
            DXImageControl dxImageControl31 = new DXImageControl();
            dxImageControl31.Parent = (DXControl)this;
            dxImageControl31.LibraryFile = (LibraryFile)19;
            dxImageControl31.Location = new Point(num19 + (size1.Width + 3) * 5, y1 + 37 + 5);
            dxImageControl31.DrawTexture = true;
            dxImageControl31.BackColour = Color.FromArgb(20, 20, 20);
            dxImageControl31.Border = false;
            dxImageControl31.BorderColour = Color.FromArgb(198, 166, 99);
            dxImageControl31.Size = size1;
            dxImageControl31.Opacity = 0.6f;
            dxImageControl31.Visible = false;
            icons18[(SpellKey)num21] = dxImageControl31;
            Dictionary<SpellKey, DXImageControl> icons19 = Icons;
            int num22 = 19;
            DXImageControl dxImageControl32 = new DXImageControl();
            dxImageControl32.Parent = (DXControl)this;
            dxImageControl32.LibraryFile = (LibraryFile)19;
            dxImageControl32.Location = new Point(num19 + (size1.Width + 3) * 6, y1 + 37 + 5);
            dxImageControl32.DrawTexture = true;
            dxImageControl32.BackColour = Color.FromArgb(20, 20, 20);
            dxImageControl32.Border = false;
            dxImageControl32.BorderColour = Color.FromArgb(198, 166, 99);
            dxImageControl32.Size = size1;
            dxImageControl32.Opacity = 0.6f;
            dxImageControl32.Visible = false;
            icons19[(SpellKey)num22] = dxImageControl32;
            Dictionary<SpellKey, DXImageControl> icons20 = Icons;
            int num23 = 20;
            DXImageControl dxImageControl33 = new DXImageControl();
            dxImageControl33.Parent = (DXControl)this;
            dxImageControl33.LibraryFile = (LibraryFile)19;
            dxImageControl33.Location = new Point(num19 + (size1.Width + 3) * 7, y1 + 37 + 5);
            dxImageControl33.DrawTexture = true;
            dxImageControl33.BackColour = Color.FromArgb(20, 20, 20);
            dxImageControl33.Border = false;
            dxImageControl33.BorderColour = Color.FromArgb(198, 166, 99);
            dxImageControl33.Size = size1;
            dxImageControl33.Opacity = 0.6f;
            dxImageControl33.Visible = false;
            icons20[(SpellKey)num23] = dxImageControl33;
            int num24 = num19 + 5;
            Dictionary<SpellKey, DXImageControl> icons21 = Icons;
            int num25 = 21;
            DXImageControl dxImageControl34 = new DXImageControl();
            dxImageControl34.Parent = (DXControl)this;
            dxImageControl34.LibraryFile = (LibraryFile)19;
            dxImageControl34.Location = new Point(num24 + (size1.Width + 3) * 8, y1 + 37 + 5);
            dxImageControl34.DrawTexture = true;
            dxImageControl34.BackColour = Color.FromArgb(20, 20, 20);
            dxImageControl34.Border = false;
            dxImageControl34.BorderColour = Color.FromArgb(198, 166, 99);
            dxImageControl34.Size = size1;
            dxImageControl34.Opacity = 0.6f;
            dxImageControl34.Visible = false;
            icons21[(SpellKey)num25] = dxImageControl34;
            Dictionary<SpellKey, DXImageControl> icons22 = Icons;
            int num26 = 22;
            DXImageControl dxImageControl35 = new DXImageControl();
            dxImageControl35.Parent = (DXControl)this;
            dxImageControl35.LibraryFile = (LibraryFile)19;
            dxImageControl35.Location = new Point(num24 + (size1.Width + 3) * 9, y1 + 37 + 5);
            dxImageControl35.DrawTexture = true;
            dxImageControl35.BackColour = Color.FromArgb(20, 20, 20);
            dxImageControl35.Border = false;
            dxImageControl35.BorderColour = Color.FromArgb(198, 166, 99);
            dxImageControl35.Size = size1;
            dxImageControl35.Opacity = 0.6f;
            dxImageControl35.Visible = false;
            icons22[(SpellKey)num26] = dxImageControl35;
            Dictionary<SpellKey, DXImageControl> icons23 = Icons;
            int num27 = 23;
            DXImageControl dxImageControl36 = new DXImageControl();
            dxImageControl36.Parent = (DXControl)this;
            dxImageControl36.LibraryFile = (LibraryFile)19;
            dxImageControl36.Location = new Point(num24 + (size1.Width + 3) * 10, y1 + 37 + 5);
            dxImageControl36.DrawTexture = true;
            dxImageControl36.BackColour = Color.FromArgb(20, 20, 20);
            dxImageControl36.Border = false;
            dxImageControl36.BorderColour = Color.FromArgb(198, 166, 99);
            dxImageControl36.Size = size1;
            dxImageControl36.Opacity = 0.6f;
            dxImageControl36.Visible = false;
            icons23[(SpellKey)num27] = dxImageControl36;
            Dictionary<SpellKey, DXImageControl> icons24 = Icons;
            int num28 = 24;
            DXImageControl dxImageControl37 = new DXImageControl();
            dxImageControl37.Parent = (DXControl)this;
            dxImageControl37.LibraryFile = (LibraryFile)19;
            dxImageControl37.Location = new Point(num24 + (size1.Width + 3) * 11, y1 + 37 + 5);
            dxImageControl37.DrawTexture = true;
            dxImageControl37.BackColour = Color.FromArgb(20, 20, 20);
            dxImageControl37.Border = false;
            dxImageControl37.BorderColour = Color.FromArgb(198, 166, 99);
            dxImageControl37.Size = size1;
            dxImageControl37.Opacity = 0.6f;
            dxImageControl37.Visible = false;
            icons24[(SpellKey)num28] = dxImageControl37;
            int num29 = 1;
            using (Dictionary<SpellKey, DXImageControl>.Enumerator enumerator = Icons.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    KeyValuePair<SpellKey, DXImageControl> current = enumerator.Current;
                    current.Value.MouseEnter += (EventHandler<EventArgs>)((o, e) => GameScene.Game.MouseMagic = ((DXControl)o).Tag as MagicInfo);
                    current.Value.MouseLeave += (EventHandler<EventArgs>)((o, e) => GameScene.Game.MouseMagic = (MagicInfo)null);
                    Dictionary<SpellKey, DXLabel> cooldowns = Cooldowns;
                    SpellKey key = current.Key;
                    DXLabel dxLabel = new DXLabel();
                    dxLabel.AutoSize = false;
                    dxLabel.BackColour = Color.FromArgb(125, 50, 50, 50);
                    dxLabel.Parent = (DXControl)current.Value;
                    dxLabel.Location = new Point(1, 1);
                    dxLabel.IsControl = false;
                    dxLabel.Size = size1;
                    dxLabel.DrawFormat = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
                    dxLabel.ForeColour = Color.Gold;
                    dxLabel.Outline = true;
                    dxLabel.OutlineColour = Color.Black;
                    cooldowns[key] = dxLabel;
                    ++num29;
                }
            }
            int x3 = Size.Width - 52;
            int y2 = y1 - 5;
            DXButton dxButton1 = new DXButton();
            dxButton1.Parent = (DXControl)this;
            dxButton1.Location = new Point(x3, y2);
            dxButton1.LibraryFile = (LibraryFile)4;
            dxButton1.Index = 931;
            UpButton = dxButton1;
            UpButton.MouseClick += (EventHandler<MouseEventArgs>)((o, e) => SpellSet = Math.Max(1, SpellSet - 1));
            DXLabel dxLabel1 = new DXLabel();
            dxLabel1.Parent = (DXControl)this;
            dxLabel1.Text = SpellSet.ToString();
            dxLabel1.IsControl = false;
            int x4 = x3;
            int num30 = y2;
            Size size2 = UpButton.Size;
            int height1 = size2.Height;
            int y3 = num30 + height1 + 1;
            dxLabel1.Location = new Point(x4, y3);
            dxLabel1.ForeColour = Color.White;
            SetLabel = dxLabel1;
            DXButton dxButton2 = new DXButton();
            dxButton2.Parent = (DXControl)this;
            int x5 = x3;
            int num31 = y2;
            size2 = UpButton.Size;
            int height2 = size2.Height;
            int y4 = num31 + height2 + 18;
            dxButton2.Location = new Point(x5, y4);
            dxButton2.LibraryFile = (LibraryFile)4;
            dxButton2.Index = 936;
            DownButton = dxButton2;
            DownButton.MouseClick += (EventHandler<MouseEventArgs>)((o, e) => SpellSet = Math.Min(4, SpellSet + 1));
            DXButton dxButton3 = new DXButton();
            dxButton3.Parent = (DXControl)this;
            Size size3 = Size;
            int x6 = size3.Width - 35;
            size3 = Size;
            int y5 = size3.Height / 2 - 15;
            dxButton3.Location = new Point(x6, y5);
            dxButton3.LibraryFile = (LibraryFile)2;
            dxButton3.Index = 113;
            CloseBtn = dxButton3;
            CloseBtn.MouseEnter += (EventHandler<EventArgs>)((o, e) => CloseBtn.Index = 112);
            CloseBtn.MouseLeave += (EventHandler<EventArgs>)((o, e) => CloseBtn.Index = 113);
            CloseBtn.MouseClick += (EventHandler<MouseEventArgs>)((o, e) => Visible = false);
        }

        private void Background_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }

        public void UpdateIcons()
        {
            SpellKey spellKey = (SpellKey)0;
            using (Dictionary<SpellKey, DXImageControl>.Enumerator enumerator = Icons.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    KeyValuePair<SpellKey, DXImageControl> pair = enumerator.Current;
                    GameScene game = GameScene.Game;
                    ClientUserMagic clientUserMagic1;
                    if (game == null)
                    {
                        clientUserMagic1 = (ClientUserMagic)null;
                    }
                    else
                    {
                        UserObject user = game.User;
                        clientUserMagic1 = user != null ? ((IEnumerable<ClientUserMagic>)user.Magics.Values).FirstOrDefault<ClientUserMagic>((Func<ClientUserMagic, bool>)(x =>
                        {
                            switch (SpellSet)
                            {
                                case 1:
                                    return x.Set1Key == pair.Key;
                                case 2:
                                    return x.Set2Key == pair.Key;
                                case 3:
                                    return x.Set3Key == pair.Key;
                                case 4:
                                    return x.Set4Key == pair.Key;
                                default:
                                    return false;
                            }
                        })) : (ClientUserMagic)null;
                    }
                    ClientUserMagic clientUserMagic2 = clientUserMagic1;
                    pair.Value.Tag = (object)clientUserMagic2?.Info;
                    if (clientUserMagic2 != null)
                    {
                        spellKey = pair.Key;
                        pair.Value.Index = ((MagicInfo)clientUserMagic2.Info).Icon;
                    }
                    else
                    {
                        pair.Value.Index = -1;
                        Cooldowns[pair.Key].Visible = false;
                    }
                    pair.Value.Index = clientUserMagic2 != null ? ((MagicInfo)clientUserMagic2.Info).Icon : -1;
                }
            }
            SetLabel.Text = SpellSet.ToString();
            if (spellKey >= (SpellKey)13)
            {
                Icons[(SpellKey)13].Visible = true;
                Icons[(SpellKey)14].Visible = true;
                Icons[(SpellKey)15].Visible = true;
                Icons[(SpellKey)16].Visible = true;
                Icons[(SpellKey)17].Visible = true;
                Icons[(SpellKey)18].Visible = true;
                Icons[(SpellKey)19].Visible = true;
                Icons[(SpellKey)20].Visible = true;
                Icons[(SpellKey)21].Visible = true;
                Icons[(SpellKey)22].Visible = true;
                Icons[(SpellKey)23].Visible = true;
                Icons[(SpellKey)24].Visible = true;
            }
            else
            {
                Icons[(SpellKey)13].Visible = false;
                Icons[(SpellKey)14].Visible = false;
                Icons[(SpellKey)15].Visible = false;
                Icons[(SpellKey)16].Visible = false;
                Icons[(SpellKey)17].Visible = false;
                Icons[(SpellKey)18].Visible = false;
                Icons[(SpellKey)19].Visible = false;
                Icons[(SpellKey)20].Visible = false;
                Icons[(SpellKey)21].Visible = false;
                Icons[(SpellKey)22].Visible = false;
                Icons[(SpellKey)23].Visible = false;
                Icons[(SpellKey)24].Visible = false;
            }
        }

        public override void Process()
        {
            base.Process();
            if (!Visible)
                return;
            using (Dictionary<SpellKey, DXImageControl>.Enumerator enumerator = Icons.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    KeyValuePair<SpellKey, DXImageControl> current = enumerator.Current;
                    MagicInfo tag = current.Value.Tag as MagicInfo;
                    if (tag == null)
                    {
                        Cooldowns[current.Key].Visible = false;
                    }
                    else
                    {
                        ClientUserMagic magic = GameScene.Game.User.Magics[tag];
                        if (CEnvir.Now >= (DateTime)magic.NextCast)
                        {
                            Cooldowns[current.Key].Visible = false;
                        }
                        else
                        {
                            Cooldowns[current.Key].Visible = true;
                            TimeSpan timeSpan = (DateTime)magic.NextCast - CEnvir.Now;
                            Cooldowns[current.Key].Text = string.Format("{0}s", (object)Math.Ceiling(timeSpan.TotalSeconds));
                            if (timeSpan.TotalSeconds > 5.0)
                                Cooldowns[current.Key].ForeColour = Color.Gold;
                            else
                                Cooldowns[current.Key].ForeColour = Color.Red;
                        }
                    }
                }
            }
        }
    }
}
