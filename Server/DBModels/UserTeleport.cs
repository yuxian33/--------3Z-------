using Library;
using Library.SystemModels;
using CartoonMirDB;
using System.Drawing;

namespace Server.DBModels
{
    [UserObject]
    public class UserTeleport : DBObject
    {
        [Association("UserTeleports")]
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

        public new int Index
        {
            get { return _Index; }
            set
            {
                if (_Index == value) return;

                var oldValue = _Index;
                _Index = value;

                OnChanged(oldValue, value, "Index");
            }
        }
        private int _Index;

        public MapInfo Map
        {
            get { return _Map; }
            set
            {
                if (_Map == value) return;

                var oldValue = _Map;
                _Map = value;

                OnChanged(oldValue, value, "Map");
            }
        }
        private MapInfo _Map;

        public string Beizhu
        {
            get { return _Beizhu; }
            set
            {
                if (_Beizhu == value) return;

                var oldValue = _Beizhu;
                _Beizhu = value;

                OnChanged(oldValue, value, "Beizhu");
            }
        }
        private string _Beizhu;

        public Point TelePos
        {
            get { return _TelePos; }
            set
            {
                if (_TelePos == value) return;

                var oldValue = _TelePos;
                _TelePos = value;

                OnChanged(oldValue, value, "TelePos");
            }
        }
        private Point _TelePos;


        protected override void OnDeleted()
        {
            Character = null;

            base.OnDeleted();
        }


        public ClientTeleport ToClientInfo()
        {
            return new ClientTeleport
            {
                Index = Index,
                MapId = Map.Index,
                Beizhu = Beizhu,
                TelePos = TelePos,
            };
        }
    }
}
