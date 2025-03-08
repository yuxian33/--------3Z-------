using Library;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client.Controls
{
  public sealed class DXMirScrollBar : DXControl
  {
    public int Change = 10;
    private int _Value;
    private int _MaxValue;
    private int _MinValue;
    private int _VisibleSize;
    public DXButton UpButton;
    public DXButton DownButton;
    public DXButton PositionBar;

    public int Value
    {
      get
      {
        return _Value;
      }
      set
      {
        if (_Value == value)
          return;
        int oValue = _Value;
        _Value = value;
        OnValueChanged(oValue, value);
      }
    }

    public event EventHandler<EventArgs> ValueChanged;

    public void OnValueChanged(int oValue, int nValue)
    {
      if (Value != Math.Max(MinValue, Math.Min(MaxValue - VisibleSize, Value)))
      {
        Value = Math.Max(MinValue, Math.Min(MaxValue - VisibleSize, Value));
      }
      else
      {
        UpdateScrollBar();
        
        EventHandler<EventArgs> valueChanged = ValueChanged;
        if (valueChanged == null)
          return;
        valueChanged((object) this, EventArgs.Empty);
      }
    }

    public int MaxValue
    {
      get
      {
        return _MaxValue;
      }
      set
      {
        if (_MaxValue == value)
          return;
        int maxValue = _MaxValue;
        _MaxValue = value;
        OnMaxValueChanged(maxValue, value);
      }
    }

    public event EventHandler<EventArgs> MaxValueChanged;

    public void OnMaxValueChanged(int oValue, int nValue)
    {
      PositionBar.Visible = MaxValue > VisibleSize;
      if (Value + VisibleSize > MaxValue)
        Value = MaxValue - VisibleSize;
      UpdateScrollBar();
      
      EventHandler<EventArgs> maxValueChanged = MaxValueChanged;
      if (maxValueChanged == null)
        return;
      maxValueChanged((object) this, EventArgs.Empty);
    }

    public int MinValue
    {
      get
      {
        return _MinValue;
      }
      set
      {
        if (_MinValue == value)
          return;
        int minValue = _MinValue;
        _MinValue = value;
        OnMinValueChanged(minValue, value);
      }
    }

    public event EventHandler<EventArgs> MinValueChanged;

    public void OnMinValueChanged(int oValue, int nValue)
    {
      UpdateScrollBar();
      
      EventHandler<EventArgs> minValueChanged = MinValueChanged;
      if (minValueChanged == null)
        return;
      minValueChanged((object) this, EventArgs.Empty);
    }

    public int VisibleSize
    {
      get
      {
        return _VisibleSize;
      }
      set
      {
        if (_VisibleSize == value)
          return;
        int visibleSize = _VisibleSize;
        _VisibleSize = value;
        OnVisibleSizeChanged(visibleSize, value);
      }
    }

    public event EventHandler<EventArgs> VisibleSizeChanged;

    public void OnVisibleSizeChanged(int oValue, int nValue)
    {
      PositionBar.Visible = MaxValue > VisibleSize;
      UpdateScrollBar();
      
      EventHandler<EventArgs> visibleSizeChanged = VisibleSizeChanged;
      if (visibleSizeChanged == null)
        return;
      visibleSizeChanged((object) this, EventArgs.Empty);
    }

    private int ScrollHeight
    {
      get
      {
        return Size.Height - 50;
      }
    }

    public override void OnSizeChanged(Size oValue, Size nValue)
    {
      base.OnSizeChanged(oValue, nValue);
      if (ScrollHeight < 0)
        return;
      DownButton.Location = new Point(UpButton.Location.X, Size.Height - 13);
      UpdateScrollBar();
    }

    public DXMirScrollBar()
    {
      Border = false;
      Opacity = 0.0f;
      DXButton dxButton1 = new DXButton();
      dxButton1.Index = 3561;
      dxButton1.LibraryFile = (LibraryFile) 3;
      dxButton1.Location = new Point(0, 2);
      dxButton1.Parent = (DXControl) this;
      UpButton = dxButton1;
      UpButton.MouseClick += (EventHandler<MouseEventArgs>) ((o, e) => Value -= Change);
      UpButton.MouseWheel += new EventHandler<MouseEventArgs>(DoMouseWheel);
      DXButton dxButton2 = new DXButton();
      dxButton2.Index = 3562;
      dxButton2.LibraryFile = (LibraryFile) 3;
      dxButton2.Location = new Point(UpButton.Location.X, 0);
      dxButton2.Parent = (DXControl) this;
      DownButton = dxButton2;
      DownButton.MouseClick += (EventHandler<MouseEventArgs>) ((o, e) => Value += Change);
      DownButton.MouseWheel += new EventHandler<MouseEventArgs>(DoMouseWheel);
      DXButton dxButton3 = new DXButton();
      dxButton3.Index = 3560;
      dxButton3.LibraryFile = (LibraryFile) 3;
      dxButton3.Location = new Point(UpButton.Location.X + 2, UpButton.Size.Height + 4);
      dxButton3.Parent = (DXControl) this;
      dxButton3.Movable = true;
      dxButton3.Sound = (SoundIndex) 0;
      dxButton3.CanBePressed = false;
      PositionBar = dxButton3;
      PositionBar.Moving += new EventHandler<MouseEventArgs>(PositionBar_Moving);
      PositionBar.MouseWheel += new EventHandler<MouseEventArgs>(DoMouseWheel);
      Size = new Size(16, 0);
    }

    private void UpdateScrollBar()
    {
      UpButton.Tag = (object) (Value > MinValue);
      DownButton.Tag = (object) (Value < MaxValue - VisibleSize);
      PositionBar.Tag = (object) (MaxValue - MinValue > VisibleSize);
      if ((uint) (MaxValue - MinValue - VisibleSize) <= 0U)
        return;
      PositionBar.Location = new Point(UpButton.Location.X + 2, 18 + (int) ((double) ScrollHeight * ((double) Value / (double) (MaxValue - MinValue - VisibleSize))));
    }

    public void DoMouseWheel(object sender, MouseEventArgs e)
    {
      Value -= e.Delta / SystemInformation.MouseWheelScrollDelta * Change;
    }

    private void PositionBar_Moving(object sender, MouseEventArgs e)
    {
      Value = (int) Math.Round((double) ((PositionBar.Location.Y - 16) * (MaxValue - MinValue - VisibleSize)) / (double) ScrollHeight);
      if (MaxValue - MinValue - VisibleSize == 0)
        return;
      PositionBar.Location = new Point(UpButton.Location.X + 2, 18 + (int) ((double) ScrollHeight * ((double) Value / (double) (MaxValue - MinValue - VisibleSize))));
    }

    public override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);
      Value = (int) Math.Round((double) ((e.Location.Y - DisplayArea.Top - 32) * (MaxValue - MinValue - VisibleSize)) / (double) ScrollHeight);
    }

    public override void OnMouseWheel(MouseEventArgs e)
    {
      base.OnMouseWheel(e);
      DoMouseWheel((object) this, e);
    }

    protected override void Dispose(bool disposing)
    {
      base.Dispose(disposing);
      if (!disposing)
        return;
      _Value = 0;
      
      ValueChanged = (EventHandler<EventArgs>) null;
      _MaxValue = 0;
      
      MaxValueChanged = (EventHandler<EventArgs>) null;
      _MinValue = 0;
      
      MinValueChanged = (EventHandler<EventArgs>) null;
      _VisibleSize = 0;
      
      VisibleSizeChanged = (EventHandler<EventArgs>) null;
      Change = 0;
      if (UpButton != null)
      {
        if (!UpButton.IsDisposed)
          UpButton.Dispose();
        UpButton = (DXButton) null;
      }
      if (DownButton != null)
      {
        if (!DownButton.IsDisposed)
          DownButton.Dispose();
        DownButton = (DXButton) null;
      }
      if (PositionBar != null)
      {
        if (!PositionBar.IsDisposed)
          PositionBar.Dispose();
        PositionBar = (DXButton) null;
      }
    }
  }
}
