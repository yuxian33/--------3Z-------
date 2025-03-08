using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartoonMirDB;

namespace Library.SystemModels
{
    public sealed class CompanionSkillInfo : DBObject
    {
        public int Level
        {
            get { return _Level; }
            set
            {
                if (_Level == value) return;

                var oldValue = _Level;
                _Level = value;

                OnChanged(oldValue, value, "Level");
            }
        }
        private int _Level;

        public Stat StatType
        {
            get { return _StatType; }
            set
            {
                if (_StatType == value) return;

                var oldValue = _StatType;
                _StatType = value;

                OnChanged(oldValue, value, "StatType");
            }
        }
        private Stat _StatType;

        public int ImgIndex
        {
            get { return _ImgIndex; }
            set
            {
                if (_ImgIndex == value) return;

                var oldValue = _ImgIndex;
                _ImgIndex = value;

                OnChanged(oldValue, value, "ImgIndex");
            }
        }
        private int _ImgIndex;

        public int MaxAmount
        {
            get { return _MaxAmount; }
            set
            {
                if (_MaxAmount == value) return;

                var oldValue = _MaxAmount;
                _MaxAmount = value;

                OnChanged(oldValue, value, "MaxAmount");
            }
        }
        private int _MaxAmount;

        public int Weight
        {
            get { return _Weight; }
            set
            {
                if (_Weight == value) return;

                var oldValue = _Weight;
                _Weight = value;

                OnChanged(oldValue, value, "Weight");
            }
        }
        private int _Weight;
    }
}
