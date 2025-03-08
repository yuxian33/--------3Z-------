using Client.Controls;
using Client.UserModels;
using Library;
using System.Collections.Generic;
using System.Drawing;

namespace Client.Scenes.Views
{
    public sealed class CZYBCodeDialog : DXWindow
    {
        public List<ClientPlayerInfo> Members = new List<ClientPlayerInfo>();
        public List<DXLabel> Labels = new List<DXLabel>();
        public DXImageControl WechatIcon;
        public DXImageControl ZhifubaoIcon;

        public DXTab WechatTab;
        public DXTab ZhifubaoTab;

        public override WindowType Type { get { return WindowType.CZYBCodeBox; } }
        public override bool CustomSize { get { return false; } }
        public override bool AutomaticVisiblity { get { return true; } }


        public CZYBCodeDialog()
        {
            TitleLabel.Text = "元宝充值";
            HasFooter = true;
            SetClientSize(new Size(220, 240));
            DXTabControl dxTabControl1 = new DXTabControl();
            dxTabControl1.Parent = (DXControl)this;
            dxTabControl1.Size = ClientArea.Size;
            dxTabControl1.Location = ClientArea.Location;
            DXTabControl dxTabControl2 = dxTabControl1;
            DXTab dxTab1 = new DXTab();
            dxTab1.TabButton.Label.Text = "微信";
            dxTab1.TabButton.IsControl = true;
            dxTab1.Parent = (DXControl)dxTabControl2;
            dxTab1.Border = true;
            WechatTab = dxTab1;
            DXTab dxTab2 = new DXTab();
            dxTab2.TabButton.Label.Text = "支付宝";
            dxTab2.TabButton.IsControl = true;
            dxTab2.Parent = (DXControl)dxTabControl2;
            dxTab2.Border = true;
            ZhifubaoTab = dxTab2;
            DXImageControl dxImageControl1 = new DXImageControl();
            dxImageControl1.Parent = (DXControl)WechatTab;
            dxImageControl1.LibraryFile = LibraryFile.GameInter;
            dxImageControl1.Index = 200;
            dxImageControl1.Location = new Point(2, 2);
            dxImageControl1.Visible = true;
            WechatIcon = dxImageControl1;
            DXImageControl dxImageControl2 = new DXImageControl();
            dxImageControl2.Parent = (DXControl)ZhifubaoTab;
            dxImageControl2.LibraryFile = LibraryFile.GameInter;
            dxImageControl2.Index = 201;
            dxImageControl2.Location = new Point(2, 2);
            dxImageControl2.Visible = true;
            ZhifubaoIcon = dxImageControl2;
            DXLabel dxLabel = new DXLabel();
            dxLabel.Parent = (DXControl)this;
            dxLabel.Text = "充值比例1:5000.充值时请备注：角色姓名！";
            dxLabel.Location = new Point(ClientArea.X, Size.Height - 46);
        }
    }
}
