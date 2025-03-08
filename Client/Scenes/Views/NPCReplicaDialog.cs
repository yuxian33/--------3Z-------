





using Client.Controls;
using Client.Envir;
using Client.UserModels;
using Library;
using System;
using System.Drawing;

namespace Client.Scenes.Views
{
  public sealed class NPCReplicaDialog : DXWindow
  {
    public DXImageControl RightImage;
    public DXImageControl RightExplainImage;
    public DXLabel ExplainLabel;
    public DXLabel TimeLabel;
    public DateTime Expiry;

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

    public NPCReplicaDialog()
    {
      Size = new Size(250, 80);
      Opacity = 0.0f;
      Location = ClientArea.Location;
      HasTitle = false;
      HasFooter = false;
      HasTopBorder = false;
      TitleLabel.Visible = false;
      CloseButton.Visible = false;
      DXImageControl dxImageControl1 = new DXImageControl();
      dxImageControl1.Parent = (DXControl) this;
      dxImageControl1.LibraryFile = LibraryFile.GameInter;
      dxImageControl1.Index = 6903;
      dxImageControl1.ImageOpacity = 1f;
      dxImageControl1.Location = new Point(140, 5);
      RightImage = dxImageControl1;
      DXLabel dxLabel1 = new DXLabel();
      dxLabel1.Parent = (DXControl) RightImage;
      dxLabel1.Location = new Point(ClientArea.Left + 20, 6);
      dxLabel1.Font = new Font(Config.FontName, CEnvir.FontSize(10f), FontStyle.Bold);
      dxLabel1.BorderColour = Color.FromArgb(99, 83, 50);
      dxLabel1.ForeColour = Color.White;
      dxLabel1.Text = "00:00";
      dxLabel1.Size = new Size(80, 25);
      TimeLabel = dxLabel1;
      DXImageControl dxImageControl2 = new DXImageControl();
      dxImageControl2.Parent = (DXControl) this;
      dxImageControl2.LibraryFile = LibraryFile.GameInter;
      dxImageControl2.Index = 6902;
      dxImageControl2.ImageOpacity = 1f;
      dxImageControl2.Location = new Point(68, 5);
      RightExplainImage = dxImageControl2;
      DXLabel dxLabel2 = new DXLabel();
      dxLabel2.Parent = (DXControl) RightExplainImage;
      dxLabel2.Location = new Point(ClientArea.Left + 5, 6);
      dxLabel2.Font = new Font(Config.FontName, CEnvir.FontSize(10f), FontStyle.Bold);
      dxLabel2.BorderColour = Color.FromArgb(99, 83, 50);
      dxLabel2.ForeColour = Color.White;
      dxLabel2.Text = "副本说明";
      dxLabel2.Size = new Size(80, 20);
      ExplainLabel = dxLabel2;
    }

    protected override void Dispose(bool disposing)
    {
      base.Dispose(disposing);
      if (!disposing)
        return;
      if (RightImage != null)
      {
        if (!RightImage.IsDisposed)
          RightImage.Dispose();
        RightImage = (DXImageControl) null;
      }
      if (RightExplainImage != null)
      {
        if (!RightExplainImage.IsDisposed)
          RightExplainImage.Dispose();
        RightExplainImage =  null;
      }
    }
  }
}
