using System;
using System.Windows.Forms;

namespace Client.Controls
{
    public class DxMirButton : DXImageControl
    {
        private int _normalIndex = -1;

        public MirButtonType MirButtonType { get; set; } = MirButtonType.Normal;

        public void Reset()
        {
            _normalIndex = -1;
            Index = _normalIndex;
        }

        public override void OnEnabledChanged(bool oValue, bool nValue)
        {
            if (MirButtonType == MirButtonType.FourStatuReverse)
            {
                Index = !nValue ? _normalIndex + 1 : _normalIndex;
            }
            else
            {
                if (MirButtonType != MirButtonType.FourStatu)
                    return;
                Index = !nValue ? _normalIndex - 2 : _normalIndex;
            }
        }

        public override void OnIndexChanged(int oValue, int nValue)
        {
            base.OnIndexChanged(oValue, nValue);
            if (_normalIndex != -1)
                return;
            _normalIndex = nValue == 0 ? oValue : nValue;
        }

        public DxMirButton()
        {
            MouseEnter += (EventHandler<EventArgs>)((s, e) =>
            {
                if (!Enabled)
                    return;
                if (MirButtonType == MirButtonType.FourStatu)
                {
                    Index = _normalIndex - 2;
                }
                else
                {
                    if (MirButtonType != MirButtonType.FourStatuReverse && MirButtonType != MirButtonType.TowStatu2)
                        return;
                    Index = _normalIndex + 1;
                }
            });
            MouseDown += (EventHandler<MouseEventArgs>)((s, e) =>
            {
                if (!Enabled || MirButtonType == MirButtonType.Normal || MirButtonType != MirButtonType.FourStatu && MirButtonType != MirButtonType.FourStatuReverse)
                    return;
                Index = _normalIndex - 1;
            });
            MouseUp += (EventHandler<MouseEventArgs>)((s, e) =>
            {
                if (!Enabled || MirButtonType == MirButtonType.Normal)
                    return;
                if (MirButtonType == MirButtonType.FourStatu)
                {
                    Index = _normalIndex;
                }
                else
                {
                    if (MirButtonType != MirButtonType.TowStatu && MirButtonType != MirButtonType.FourStatuReverse)
                        return;
                    Index = _normalIndex + 1;
                }
            });
            MouseLeave += (EventHandler<EventArgs>)((s, e) =>
            {
                if (!Enabled || MirButtonType == MirButtonType.Normal)
                    return;
                Index = _normalIndex;
            });
        }
    }
}
