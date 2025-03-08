using CartoonMirDB;
using System.Drawing;

namespace Library.SystemModels
{
  public sealed class MonsterCostomInfo : DBObject
  {
    private MonsterInfo _Monster;
    private MirAnimation _Animation;
    private int _Origin;
    private int _Frame;
    private int _Format;
    private int _Loop;
    private bool _CanReversed;
    private bool _CanStaticSpeed;
    private MirAction _Action;
    private LibraryFile _Effect;
    private int _StartIndex;
    private int _FrameCount;
    private int _FrameDelay;
    private int _StartLight;
    private int _EndLight;

    [Association("MonsterCostomInfo")]
    public MonsterInfo Monster
    {
      get
      {
        return this._Monster;
      }
      set
      {
        if (this._Monster == value)
          return;
        MonsterInfo monster = this._Monster;
        this._Monster = value;
        this.OnChanged((object) monster, (object) value, nameof (Monster));
      }
    }

    public MirAnimation Animation
    {
      get
      {
        return this._Animation;
      }
      set
      {
        if (this._Animation == value)
          return;
        MirAnimation animation = this._Animation;
        this._Animation = value;
        this.OnChanged((object) animation, (object) value, nameof (Animation));
      }
    }

    public int Origin
    {
      get
      {
        return this._Origin;
      }
      set
      {
        if (this._Origin == value)
          return;
        int origin = this._Origin;
        this._Origin = value;
        this.OnChanged((object) origin, (object) value, nameof (Origin));
      }
    }

    public int Frame
    {
      get
      {
        return this._Frame;
      }
      set
      {
        if (this._Frame == value)
          return;
        int frame = this._Frame;
        this._Frame = value;
        this.OnChanged((object) frame, (object) value, nameof (Frame));
      }
    }

    public int Format
    {
      get
      {
        return this._Format;
      }
      set
      {
        if (this._Format == value)
          return;
        int format = this._Format;
        this._Format = value;
        this.OnChanged((object) format, (object) value, nameof (Format));
      }
    }

    public int Loop
    {
      get
      {
        return this._Loop;
      }
      set
      {
        if (this._Loop == value)
          return;
        int loop = this._Loop;
        this._Loop = value;
        this.OnChanged((object) loop, (object) value, nameof (Loop));
      }
    }

    public bool CanReversed
    {
      get
      {
        return this._CanReversed;
      }
      set
      {
        if (this._CanReversed == value)
          return;
        bool canReversed = this._CanReversed;
        this._CanReversed = value;
        this.OnChanged((object) canReversed, (object) value, nameof (CanReversed));
      }
    }

    public bool CanStaticSpeed
    {
      get
      {
        return this._CanStaticSpeed;
      }
      set
      {
        if (this._CanStaticSpeed == value)
          return;
        bool canStaticSpeed = this._CanStaticSpeed;
        this._CanStaticSpeed = value;
        this.OnChanged((object) canStaticSpeed, (object) value, nameof (CanStaticSpeed));
      }
    }

    public LibraryFile MirProjectile
    {
      get
      {
        return _MirProjectile;
      }
      set
      {
        if (_MirProjectile == value)
          return;
        LibraryFile effect = this._MirProjectile;
        _MirProjectile = value;
        OnChanged( effect,  value, nameof (MirProjectile));
      }
    }
    private LibraryFile _MirProjectile;

        public int ProStartIndex
        {
            get { return _ProStartIndex; }
            set
            {
                if (_ProStartIndex == value) return;

                var oldValue = _ProStartIndex;
                _ProStartIndex = value;

                OnChanged(oldValue, value, "ProStartIndex");
            }
        }
        private int _ProStartIndex;

        public int ProFrameCount
        {
            get { return _ProFrameCount; }
            set
            {
                if (_ProFrameCount == value) return;

                var oldValue = _ProFrameCount;
                _ProFrameCount = value;

                OnChanged(oldValue, value, "ProFrameCount");
            }
        }
        private int _ProFrameCount;

        public int ProFrameDelay
        {
            get { return _ProFrameDelay; }
            set
            {
                if (_ProFrameDelay == value) return;

                var oldValue = _ProFrameDelay;
                _ProFrameDelay = value;

                OnChanged(oldValue, value, "ProFrameDelay");
            }
        }
        private int _ProFrameDelay;

        public int ProStartLight
        {
            get { return _ProStartLight; }
            set
            {
                if (_ProStartLight == value) return;

                var oldValue = _ProStartLight;
                _ProStartLight = value;

                OnChanged(oldValue, value, "ProStartLight");
            }
        }
        private int _ProStartLight;

        public int ProEndLight
        {
            get { return _ProEndLight; }
            set
            {
                if (_ProEndLight == value) return;

                var oldValue = _ProEndLight;
                _ProEndLight = value;

                OnChanged(oldValue, value, "ProEndLight");
            }
        }
        private int _ProEndLight;

        public string ProColour
        {
            get { return _ProColour; }
            set
            {
                if (_ProColour == value) return;

                var oldValue = _ProColour;
                _ProColour = value;

                OnChanged(oldValue, value, "ProColour");
            }
        }
        private string _ProColour;

        public LibraryFile MirEffect
        {
            get
            {
                return _MirEffect;
            }
            set
            {
                if (_MirEffect == value)
                    return;
                LibraryFile effect = this._MirEffect;
                _MirEffect = value;
                OnChanged(effect, value, nameof(MirEffect));
            }
        }
        private LibraryFile _MirEffect;

        public int EffectStartIndex
        {
            get { return _EffectStartIndex; }
            set
            {
                if (_EffectStartIndex == value) return;

                var oldValue = _EffectStartIndex;
                _EffectStartIndex = value;

                OnChanged(oldValue, value, "EffectStartIndex");
            }
        }
        private int _EffectStartIndex;

        public int EffectFrameCount
        {
            get { return _EffectFrameCount; }
            set
            {
                if (_EffectFrameCount == value) return;

                var oldValue = _EffectFrameCount;
                _EffectFrameCount = value;

                OnChanged(oldValue, value, "EffectFrameCount");
            }
        }
        private int _EffectFrameCount;

        public int EffectFrameDelay
        {
            get { return _EffectFrameDelay; }
            set
            {
                if (_EffectFrameDelay == value) return;

                var oldValue = _EffectFrameDelay;
                _EffectFrameDelay = value;

                OnChanged(oldValue, value, "EffectFrameDelay");
            }
        }
        private int _EffectFrameDelay;

        public int EffectStartLight
        {
            get { return _EffectStartLight; }
            set
            {
                if (_EffectStartLight == value) return;

                var oldValue = _EffectStartLight;
                _EffectStartLight = value;

                OnChanged(oldValue, value, "EffectStartLight");
            }
        }
        private int _EffectStartLight;

        public int EffectEndLight
        {
            get { return _EffectEndLight; }
            set
            {
                if (_EffectEndLight == value) return;

                var oldValue = _EffectEndLight;
                _EffectEndLight = value;

                OnChanged(oldValue, value, "EffectEndLight");
            }
        }
        private int _EffectEndLight;

        public string EffectColour
        {
            get { return _EffectColour; }
            set
            {
                if (_EffectColour == value) return;

                var oldValue = _EffectColour;
                _EffectColour = value;

                OnChanged(oldValue, value, "EffectColour");
            }
        }
        private string _EffectColour;



    public MirAction Action
    {
      get
      {
        return this._Action;
      }
      set
      {
        if (this._Action == value)
          return;
        MirAction action = this._Action;
        this._Action = value;
        this.OnChanged((object) action, (object) value, nameof (Action));
      }
    }

    public LibraryFile Effect
    {
      get
      {
        return this._Effect;
      }
      set
      {
        if (this._Effect == value)
          return;
        LibraryFile effect = this._Effect;
        this._Effect = value;
        this.OnChanged((object) effect, (object) value, nameof (Effect));
      }
    }

    public int StartIndex
    {
      get
      {
        return this._StartIndex;
      }
      set
      {
        if (this._StartIndex == value)
          return;
        int startIndex = this._StartIndex;
        this._StartIndex = value;
        this.OnChanged((object) startIndex, (object) value, nameof (StartIndex));
      }
    }

    public int FrameCount
    {
      get
      {
        return this._FrameCount;
      }
      set
      {
        if (this._FrameCount == value)
          return;
        int frameCount = this._FrameCount;
        this._FrameCount = value;
        this.OnChanged((object) frameCount, (object) value, nameof (FrameCount));
      }
    }

    public int FrameDelay
    {
      get
      {
        return this._FrameDelay;
      }
      set
      {
        if (this._FrameDelay == value)
          return;
        int frameDelay = this._FrameDelay;
        this._FrameDelay = value;
        this.OnChanged((object) frameDelay, (object) value, nameof (FrameDelay));
      }
    }

    public int StartLight
    {
      get
      {
        return this._StartLight;
      }
      set
      {
        if (this._StartLight == value)
          return;
        int startLight = this._StartLight;
        this._StartLight = value;
        this.OnChanged((object) startLight, (object) value, nameof (StartLight));
      }
    }

    public int EndLight
    {
      get
      {
        return this._EndLight;
      }
      set
      {
        if (this._EndLight == value)
          return;
        int endLight = this._EndLight;
        this._EndLight = value;
        this.OnChanged((object) endLight, (object) value, nameof (EndLight));
      }
    }

        protected internal override void OnCreated()
        {
            base.OnCreated();

            ProColour = "White";
            EffectColour = "White";
        }
    }
}
