﻿using CartoonMirDB;

namespace Library.SystemModels
{
    public sealed class DropInfo : DBObject
    {
        [Association("Drops")]
        public MonsterInfo Monster
        {
            get { return _Monster; }
            set
            {
                if (_Monster == value) return;

                var oldValue = _Monster;
                _Monster = value;

                OnChanged(oldValue, value, "Monster");
            }
        }
        private MonsterInfo _Monster;

        [Association("Drops")]
        public ItemInfo Item
        {
            get { return _Item; }
            set
            {
                if (_Item == value) return;

                var oldValue = _Item;
                _Item = value;

                OnChanged(oldValue, value, "Item");
            }
        }
        private ItemInfo _Item;

        public int Chance
        {
            get { return _Chance; }
            set
            {
                if (_Chance == value) return;

                var oldValue = _Chance;
                _Chance = value;

                OnChanged(oldValue, value, "Chance");
            }
        }
        private int _Chance;

        public int DuliChance
        {
            get { return _DuliChance; }
            set
            {
                if (_DuliChance == value) return;

                var oldValue = _DuliChance;
                _DuliChance = value;

                OnChanged(oldValue, value, "DuliChance");
            }
        }
        private int _DuliChance;

        public bool Duli
        {
            get { return _Duli; }
            set
            {
                if (_Duli == value) return;

                var oldValue = _Duli;
                _Duli = value;

                OnChanged(oldValue, value, "Duli");
            }
        }
        private bool _Duli;

        public int Amount
        {
            get { return _Amount; }
            set
            {
                if (_Amount == value) return;

                var oldValue = _Amount;
                _Amount = value;

                OnChanged(oldValue, value, "Amount");
            }
        }
        private int _Amount;

        public int DropSet
        {
            get { return _DropSet; }
            set
            {
                if (_DropSet == value) return;

                var oldValue = _DropSet;
                _DropSet = value;

                OnChanged(oldValue, value, "DropSet");
            }
        }
        private int _DropSet;

        public bool PartOnly
        {
            get { return _PartOnly; }
            set
            {
                if (_PartOnly == value) return;

                var oldValue = _PartOnly;
                _PartOnly = value;

                OnChanged(oldValue, value, "PartOnly");
            }
        }
        private bool _PartOnly;

        public bool EasterEvent
        {
            get { return _EasterEvent; }
            set
            {
                if (_EasterEvent == value) return;

                var oldValue = _EasterEvent;
                _EasterEvent = value;

                OnChanged(oldValue, value, "EasterEvent");
            }
        }
        private bool _EasterEvent;

        public bool 圣诞节活动
        {
            get { return _圣诞节活动; }
            set
            {
                if (_圣诞节活动 == value) return;

                var oldValue = _圣诞节活动;
                _圣诞节活动 = value;

                OnChanged(oldValue, value, "圣诞节活动");
            }
        }
        private bool _圣诞节活动;

        protected internal override void OnCreated()
        {
            base.OnCreated();

            Amount = 1;
        }
    }
}
