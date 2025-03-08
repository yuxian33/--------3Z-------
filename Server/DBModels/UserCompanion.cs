using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using Library.SystemModels;
using CartoonMirDB;

namespace Server.DBModels
{
    [UserObject]
    public sealed class UserCompanion : DBObject
    {
        [Association("Companions")]
        public AccountInfo Account
        {
            get { return _Account; }
            set
            {
                if (_Account == value) return;

                var oldValue = _Account;
                _Account = value;

                OnChanged(oldValue, value, "Account");
            }
        }
        private AccountInfo _Account;
        
        [Association("Companion")]
        public CharacterInfo Character
        {
            get { return _Character; }
            set
            {
                if (_Character == value) return;

                var oldValue = _Character;
                _Character = value;

                OnChanged(oldValue, value, "Character");
            }
        }
        private CharacterInfo _Character;

        public CompanionInfo Info
        {
            get { return _Info; }
            set
            {
                if (_Info == value) return;

                var oldValue = _Info;
                _Info = value;

                OnChanged(oldValue, value, "Info");
            }
        }
        private CompanionInfo _Info;
        
        
        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name == value) return;

                var oldValue = _Name;
                _Name = value;

                OnChanged(oldValue, value, "Name");
            }
        }
        private string _Name;
        
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

        public int Rebirth
        {
            get => _Rebirth;
            set
            {
                if (_Rebirth == value) return;

                int oldValue = _Rebirth;
                _Rebirth = value;

                OnChanged(oldValue, value, "Rebirth");
            }
        }
        private int _Rebirth;

        public int Hunger
        {
            get { return _Hunger; }
            set
            {
                if (_Hunger == value) return;

                var oldValue = _Hunger;
                _Hunger = value;

                OnChanged(oldValue, value, "Hunger");
            }
        }
        private int _Hunger;

        public int Experience
        {
            get { return _Experience; }
            set
            {
                if (_Experience == value) return;

                var oldValue = _Experience;
                _Experience = value;

                OnChanged(oldValue, value, "Experience");
            }
        }
        private int _Experience;

        public Stats Level3
        {
            get { return _Level3; }
            set
            {
                if (_Level3 == value) return;

                var oldValue = _Level3;
                _Level3 = value;

                OnChanged(oldValue, value, "Level3");
            }
        }
        private Stats _Level3;

        public Stats Level5
        {
            get { return _Level5; }
            set
            {
                if (_Level5 == value) return;

                var oldValue = _Level5;
                _Level5 = value;

                OnChanged(oldValue, value, "Level5");
            }
        }
        private Stats _Level5;
        
        public Stats Level7
        {
            get { return _Level7; }
            set
            {
                if (_Level7 == value) return;

                var oldValue = _Level7;
                _Level7 = value;

                OnChanged(oldValue, value, "Level7");
            }
        }
        private Stats _Level7;

        public Stats Level10
        {
            get { return _Level10; }
            set
            {
                if (_Level10 == value) return;

                var oldValue = _Level10;
                _Level10 = value;

                OnChanged(oldValue, value, "Level10");
            }
        }
        private Stats _Level10;

        public Stats Level11
        {
            get { return _Level11; }
            set
            {
                if (_Level11 == value) return;

                var oldValue = _Level11;
                _Level11 = value;

                OnChanged(oldValue, value, "Level11");
            }
        }
        private Stats _Level11;
        
        public Stats Level13
        {
            get { return _Level13; }
            set
            {
                if (_Level13 == value) return;

                var oldValue = _Level13;
                _Level13 = value;

                OnChanged(oldValue, value, "Level13");
            }
        }
        private Stats _Level13;

        public Stats Level15
        {
            get { return _Level15; }
            set
            {
                if (_Level15 == value) return;

                var oldValue = _Level15;
                _Level15 = value;

                OnChanged(oldValue, value, "Level15");
            }
        }
        private Stats _Level15;

        public Stats Level17
        {
            get { return _Level17; }
            set
            {
                if (_Level17 == value) return;

                var oldValue = _Level17;
                _Level17 = value;

                OnChanged(oldValue, value, "Level17");
            }
        }
        private Stats _Level17;

        public Stats Level20
        {
            get { return _Level20; }
            set
            {
                if (_Level20 == value) return;

                var oldValue = _Level20;
                _Level20 = value;

                OnChanged(oldValue, value, "Level20");
            }
        }
        private Stats _Level20;

        public Stats Level23
        {
            get { return _Level23; }
            set
            {
                if (_Level23 == value) return;

                var oldValue = _Level23;
                _Level23 = value;

                OnChanged(oldValue, value, "Level23");
            }
        }
        private Stats _Level23;

        public Stats Level25
        {
            get { return _Level25; }
            set
            {
                if (_Level25 == value) return;

                var oldValue = _Level25;
                _Level25 = value;

                OnChanged(oldValue, value, "Level25");
            }
        }
        private Stats _Level25;

        public Stats Level27
        {
            get { return _Level27; }
            set
            {
                if (_Level27 == value) return;

                var oldValue = _Level27;
                _Level27 = value;

                OnChanged(oldValue, value, "Level27");
            }
        }
        private Stats _Level27;

        public Stats Level30
        {
            get { return _Level30; }
            set
            {
                if (_Level30 == value) return;

                var oldValue = _Level30;
                _Level30 = value;

                OnChanged(oldValue, value, "Level30");
            }
        }
        private Stats _Level30;

        public Stats Level33
        {
            get { return _Level33; }
            set
            {
                if (_Level33 == value) return;

                var oldValue = _Level33;
                _Level33 = value;

                OnChanged(oldValue, value, "Level33");
            }
        }
        private Stats _Level33;

        public Stats Level35
        {
            get { return _Level35; }
            set
            {
                if (_Level35 == value) return;

                var oldValue = _Level35;
                _Level35 = value;

                OnChanged(oldValue, value, "Level35");
            }
        }
        private Stats _Level35;

        public Stats Level37
        {
            get { return _Level37; }
            set
            {
                if (_Level37 == value) return;

                var oldValue = _Level37;
                _Level37 = value;

                OnChanged(oldValue, value, "Level37");
            }
        }
        private Stats _Level37;

        public Stats Level40
        {
            get { return _Level40; }
            set
            {
                if (_Level40 == value) return;

                var oldValue = _Level40;
                _Level40 = value;

                OnChanged(oldValue, value, "Level40");
            }
        }
        private Stats _Level40;

        public int ImgIndex3
        {
            get { return _ImgIndex3; }
            set
            {
                if (_ImgIndex3 == value) return;

                var oldValue = _ImgIndex3;
                _ImgIndex3 = value;

                OnChanged(oldValue, value, "ImgIndex3");
            }
        }
        private int _ImgIndex3;

        public int ImgIndex5
        {
            get { return _ImgIndex5; }
            set
            {
                if (_ImgIndex5 == value) return;

                var oldValue = _ImgIndex5;
                _ImgIndex5 = value;

                OnChanged(oldValue, value, "ImgIndex5");
            }
        }
        private int _ImgIndex5;

        public int ImgIndex7
        {
            get { return _ImgIndex7; }
            set
            {
                if (_ImgIndex7 == value) return;

                var oldValue = _ImgIndex7;
                _ImgIndex7 = value;

                OnChanged(oldValue, value, "ImgIndex7");
            }
        }
        private int _ImgIndex7;

        public int ImgIndex10
        {
            get { return _ImgIndex10; }
            set
            {
                if (_ImgIndex10 == value) return;

                var oldValue = _ImgIndex10;
                _ImgIndex10 = value;

                OnChanged(oldValue, value, "ImgIndex10");
            }
        }
        private int _ImgIndex10;

        public int ImgIndex11
        {
            get { return _ImgIndex11; }
            set
            {
                if (_ImgIndex11 == value) return;

                var oldValue = _ImgIndex11;
                _ImgIndex11 = value;

                OnChanged(oldValue, value, "ImgIndex11");
            }
        }
        private int _ImgIndex11;

        public int ImgIndex13
        {
            get { return _ImgIndex13; }
            set
            {
                if (_ImgIndex13 == value) return;

                var oldValue = _ImgIndex13;
                _ImgIndex13 = value;

                OnChanged(oldValue, value, "ImgIndex13");
            }
        }
        private int _ImgIndex13;

        public int ImgIndex15
        {
            get { return _ImgIndex15; }
            set
            {
                if (_ImgIndex15 == value) return;

                var oldValue = _ImgIndex15;
                _ImgIndex15 = value;

                OnChanged(oldValue, value, "ImgIndex15");
            }
        }
        private int _ImgIndex15;

        public int ImgIndex17
        {
            get { return _ImgIndex17; }
            set
            {
                if (_ImgIndex17 == value) return;

                var oldValue = _ImgIndex17;
                _ImgIndex17 = value;

                OnChanged(oldValue, value, "ImgIndex17");
            }
        }
        private int _ImgIndex17;

        public int ImgIndex20
        {
            get { return _ImgIndex20; }
            set
            {
                if (_ImgIndex20 == value) return;

                var oldValue = _ImgIndex20;
                _ImgIndex20 = value;

                OnChanged(oldValue, value, "ImgIndex20");
            }
        }
        private int _ImgIndex20;

        public int ImgIndex23
        {
            get { return _ImgIndex23; }
            set
            {
                if (_ImgIndex23 == value) return;

                var oldValue = _ImgIndex23;
                _ImgIndex23 = value;

                OnChanged(oldValue, value, "ImgIndex23");
            }
        }
        private int _ImgIndex23;

        public int ImgIndex25
        {
            get { return _ImgIndex25; }
            set
            {
                if (_ImgIndex25 == value) return;

                var oldValue = _ImgIndex25;
                _ImgIndex25 = value;

                OnChanged(oldValue, value, "ImgIndex25");
            }
        }
        private int _ImgIndex25;

        public int ImgIndex27
        {
            get { return _ImgIndex27; }
            set
            {
                if (_ImgIndex27 == value) return;

                var oldValue = _ImgIndex27;
                _ImgIndex27 = value;

                OnChanged(oldValue, value, "ImgIndex27");
            }
        }
        private int _ImgIndex27;

        public int ImgIndex30
        {
            get { return _ImgIndex30; }
            set
            {
                if (_ImgIndex30 == value) return;

                var oldValue = _ImgIndex30;
                _ImgIndex30 = value;

                OnChanged(oldValue, value, "ImgIndex30");
            }
        }
        private int _ImgIndex30;

        public int ImgIndex33
        {
            get { return _ImgIndex33; }
            set
            {
                if (_ImgIndex33 == value) return;

                var oldValue = _ImgIndex33;
                _ImgIndex33 = value;

                OnChanged(oldValue, value, "ImgIndex33");
            }
        }
        private int _ImgIndex33;

        public int ImgIndex35
        {
            get { return _ImgIndex35; }
            set
            {
                if (_ImgIndex35 == value) return;

                var oldValue = _ImgIndex35;
                _ImgIndex35 = value;

                OnChanged(oldValue, value, "ImgIndex35");
            }
        }
        private int _ImgIndex35;

        public int ImgIndex37
        {
            get { return _ImgIndex37; }
            set
            {
                if (_ImgIndex37 == value) return;

                var oldValue = _ImgIndex37;
                _ImgIndex37 = value;

                OnChanged(oldValue, value, "ImgIndex37");
            }
        }
        private int _ImgIndex37;

        public int ImgIndex40
        {
            get { return _ImgIndex40; }
            set
            {
                if (_ImgIndex40 == value) return;

                var oldValue = _ImgIndex40;
                _ImgIndex40 = value;

                OnChanged(oldValue, value, "ImgIndex40");
            }
        }
        private int _ImgIndex40;

        public bool Maxzhi3
        {
            get { return _Maxzhi3; }
            set
            {
                if (_Maxzhi3 == value) return;

                var oldValue = _Maxzhi3;
                _Maxzhi3 = value;

                OnChanged(oldValue, value, "Maxzhi3");
            }
        }
        private bool _Maxzhi3;

        public bool Maxzhi5
        {
            get { return _Maxzhi5; }
            set
            {
                if (_Maxzhi5 == value) return;

                var oldValue = _Maxzhi5;
                _Maxzhi5 = value;

                OnChanged(oldValue, value, "Maxzhi5");
            }
        }
        private bool _Maxzhi5;

        public bool Maxzhi7
        {
            get { return _Maxzhi7; }
            set
            {
                if (_Maxzhi7 == value) return;

                var oldValue = _Maxzhi7;
                _Maxzhi7 = value;

                OnChanged(oldValue, value, "Maxzhi7");
            }
        }
        private bool _Maxzhi7;

        public bool Maxzhi10
        {
            get { return _Maxzhi10; }
            set
            {
                if (_Maxzhi10 == value) return;

                var oldValue = _Maxzhi10;
                _Maxzhi10 = value;

                OnChanged(oldValue, value, "Maxzhi10");
            }
        }
        private bool _Maxzhi10;

        public bool Maxzhi11
        {
            get { return _Maxzhi11; }
            set
            {
                if (_Maxzhi11 == value) return;

                var oldValue = _Maxzhi11;
                _Maxzhi11 = value;

                OnChanged(oldValue, value, "Maxzhi11");
            }
        }
        private bool _Maxzhi11;

        public bool Maxzhi13
        {
            get { return _Maxzhi13; }
            set
            {
                if (_Maxzhi13 == value) return;

                var oldValue = _Maxzhi13;
                _Maxzhi13 = value;

                OnChanged(oldValue, value, "Maxzhi13");
            }
        }
        private bool _Maxzhi13;

        public bool Maxzhi15
        {
            get { return _Maxzhi15; }
            set
            {
                if (_Maxzhi15 == value) return;

                var oldValue = _Maxzhi15;
                _Maxzhi15 = value;

                OnChanged(oldValue, value, "Maxzhi15");
            }
        }
        private bool _Maxzhi15;

        [Association("Items", true)]
        public DBBindingList<UserItem> Items { get; set; }


        protected override void OnDeleted()
        {
            Account = null;
            Character = null;
            Info = null;

            base.OnDeleted();
        }

        public ClientUserCompanion ToClientInfo()
        {
            return new ClientUserCompanion
            {
                Index = Index,
                CharacterName = Character?.CharacterName,
                CompanionIndex = Info.Index,
                Name = Name,
                Level = Level,
                Rebirth = Rebirth,
                Hunger = Hunger,
                Experience = Experience,
                Level3 = Level3,
                Level5 = Level5,
                Level7 = Level7,
                Level10 = Level10,
                Level11 = Level11,
                Level13 = Level13,
                Level15 = Level15,
                Level17 = Level17,
                Level20 = Level20,
                Level23 = Level23,
                Level25 = Level25,
                Level27 = Level27,
                Level30 = Level30,
                Level33 = Level33,
                Level35 = Level35,
                Level37 = Level37,
                Level40 = Level40,
                ImgIndex3 = ImgIndex3,
                ImgIndex5 = ImgIndex5,
                ImgIndex7 = ImgIndex7,
                ImgIndex10 = ImgIndex10,
                ImgIndex11 = ImgIndex11,
                ImgIndex13 = ImgIndex13,
                ImgIndex15 = ImgIndex15,
                ImgIndex17 = ImgIndex17,
                ImgIndex20 = ImgIndex20,
                ImgIndex23 = ImgIndex23,
                ImgIndex25 = ImgIndex25,
                ImgIndex27 = ImgIndex27,
                ImgIndex30 = ImgIndex30,
                ImgIndex33 = ImgIndex33,
                ImgIndex35 = ImgIndex35,
                ImgIndex37 = ImgIndex37,
                ImgIndex40 = ImgIndex40,
                Maxzhi3 = Maxzhi3,
                Maxzhi5 = Maxzhi5,
                Maxzhi7 = Maxzhi7,
                Maxzhi10 = Maxzhi10,
                Maxzhi11 = Maxzhi11,
                Maxzhi13 = Maxzhi13,
                Maxzhi15 = Maxzhi15,

                Items = Items.Select(x => x.ToClientInfo()).ToList(),
            };
        }


        public override string ToString()
        {
            return Account?.EMailAddress ?? string.Empty;
        }
    }
}
