using Client.Controls;
using Library.SystemModels;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client.Scenes.Views
{
  public sealed class MonsterDropRow : DXControl
  {
    private bool _IsHeader;
    private MonsterInfo _Mail;
    public DXLabel NameLabel;
    public DXLabel LevelLabel;
    public DXLabel BossLabel;

    public bool IsHeader
    {
      get
      {
        return _IsHeader;
      }
      set
      {
        if (_IsHeader == value)
          return;
        bool isHeader = _IsHeader;
        _IsHeader = value;
        OnIsHeaderChanged(isHeader, value);
      }
    }

    public event EventHandler<EventArgs> IsHeaderChanged;

    public void OnIsHeaderChanged(bool oValue, bool nValue)
    {
      NameLabel.Text = "怪物名称";
      LevelLabel.Text = "等级";
      BossLabel.Text = "BOSS";
      NameLabel.ForeColour = Color.FromArgb(198, 166, 99);
      LevelLabel.ForeColour = Color.FromArgb(198, 166, 99);
      BossLabel.ForeColour = Color.FromArgb(198, 166, 99);
      DrawTexture = false;
      IsControl = false;
      EventHandler<EventArgs> isHeaderChanged = IsHeaderChanged;
      if (isHeaderChanged == null)
        return;
      isHeaderChanged((object) this, EventArgs.Empty);
    }

    public MonsterInfo Monster
    {
      get
      {
        return _Mail;
      }
      set
      {
        MonsterInfo mail = _Mail;
        _Mail = value;
        OnMailChanged(mail, value);
      }
    }

    public event EventHandler<EventArgs> MailChanged;

    public void OnMailChanged(MonsterInfo oValue, MonsterInfo nValue)
    {
      Visible = nValue != null;
      if (nValue == null)
        return;
      NameLabel.Text = Monster.MonsterName;
      LevelLabel.Text = Monster.Level.ToString();
      BossLabel.Text = Monster.IsBoss ? "BOSS" : "";
      RefreshIcon();
      EventHandler<EventArgs> mailChanged = MailChanged;
      if (mailChanged != null)
        mailChanged((object) this, EventArgs.Empty);
    }

    public MonsterDropRow()
    {
      Size = new Size(333, 20);
      DrawTexture = true;
      BackColour = Color.FromArgb(25, 20, 0);
      DXLabel dxLabel1 = new DXLabel();
      dxLabel1.AutoSize = false;
      dxLabel1.Size = new Size(130, 20);
      dxLabel1.Location = new Point(30, 2);
      dxLabel1.ForeColour = Color.White;
      dxLabel1.DrawFormat = TextFormatFlags.HorizontalCenter;
      dxLabel1.Parent = (DXControl) this;
      dxLabel1.IsControl = false;
      NameLabel = dxLabel1;
      DXLabel dxLabel2 = new DXLabel();
      dxLabel2.AutoSize = false;
      dxLabel2.Size = new Size(100, 20);
      dxLabel2.Location = new Point(NameLabel.Location.X + NameLabel.Size.Width, 2);
      dxLabel2.ForeColour = Color.White;
      dxLabel2.DrawFormat = TextFormatFlags.HorizontalCenter;
      dxLabel2.Parent = (DXControl) this;
      dxLabel2.IsControl = false;
      LevelLabel = dxLabel2;
      DXLabel dxLabel3 = new DXLabel();
      dxLabel3.AutoSize = false;
      dxLabel3.Size = new Size(70, 20);
      dxLabel3.Location = new Point(LevelLabel.Location.X + LevelLabel.Size.Width, 2);
      dxLabel3.ForeColour = Color.White;
      dxLabel3.DrawFormat = TextFormatFlags.HorizontalCenter;
      dxLabel3.Parent = (DXControl) this;
      dxLabel3.IsControl = false;
      BossLabel = dxLabel3;
    }

    public override void OnMouseEnter()
    {
      base.OnMouseEnter();
      if (IsHeader)
        return;
      BackColour = Color.FromArgb(80, 80, 125);
    }

    public override void OnMouseLeave()
    {
      base.OnMouseLeave();
      if (IsHeader)
        return;
      BackColour = Color.FromArgb(25, 20, 0);
    }

    public void RefreshIcon()
    {
    }

    protected override void Dispose(bool disposing)
    {
      base.Dispose(disposing);
      if (!disposing)
        return;
      _IsHeader = false;
      IsHeaderChanged = (EventHandler<EventArgs>) null;
      _Mail = (MonsterInfo) null;
      MailChanged = (EventHandler<EventArgs>) null;
      if (NameLabel != null)
      {
        if (!NameLabel.IsDisposed)
          NameLabel.Dispose();
        NameLabel = (DXLabel) null;
      }
      if (LevelLabel != null)
      {
        if (!LevelLabel.IsDisposed)
          LevelLabel.Dispose();
        LevelLabel = (DXLabel) null;
      }
      if (BossLabel != null)
      {
        if (!BossLabel.IsDisposed)
          BossLabel.Dispose();
        BossLabel = (DXLabel) null;
      }
    }
  }
}
