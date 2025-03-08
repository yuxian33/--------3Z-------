using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using CartoonMirDB;
using Server.Envir;

namespace Server.DBModels
{
    [UserObject]
    public sealed class GuildMemberInfo : DBObject
    {
        [Association("Members")]
        public GuildInfo Guild
        {
            get { return _Guild; }
            set
            {
                if (_Guild == value) return;

                var oldValue = _Guild;
                _Guild = value;

                OnChanged(oldValue, value, "Guild");
            }
        }
        private GuildInfo _Guild;

        public string Rank
        {
            get { return _Rank; }
            set
            {
                if (_Rank == value) return;

                var oldValue = _Rank;
                _Rank = value;

                OnChanged(oldValue, value, "Rank");
            }
        }
        private string _Rank;

        public string MapName
        {
            get { return _MapName; }
            set
            {
                if (_MapName == value) return;

                var oldValue = _MapName;
                _MapName = value;

                OnChanged(oldValue, value, "MapName");
            }
        }
        private string _MapName;

        [Association("Member")]
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

        public DateTime JoinDate
        {
            get { return _JoinDate; }
            set
            {
                if (_JoinDate == value) return;

                var oldValue = _JoinDate;
                _JoinDate = value;

                OnChanged(oldValue, value, "JoinDate");
            }
        }
        private DateTime _JoinDate;

        public long TotalContribution
        {
            get { return _TotalContribution; }
            set
            {
                if (_TotalContribution == value) return;

                var oldValue = _TotalContribution;
                _TotalContribution = value;

                OnChanged(oldValue, value, "TotalContribution");
            }
        }
        private long _TotalContribution;

        public long JyTotalContribution
        {
            get { return _JyTotalContribution; }
            set
            {
                if (_JyTotalContribution == value) return;

                var oldValue = _JyTotalContribution;
                _JyTotalContribution = value;

                OnChanged(oldValue, value, "JyTotalContribution");
            }
        }
        private long _JyTotalContribution;

        public long DailyContribution
        {
            get { return _DailyContribution; }
            set
            {
                if (_DailyContribution == value) return;

                var oldValue = _DailyContribution;
                _DailyContribution = value;

                OnChanged(oldValue, value, "DailyContribution");
            }
        }
        private long _DailyContribution;

        public GuildPermission Permission
        {
            get { return _Permission; }
            set
            {
                if (_Permission == value) return;

                var oldValue = _Permission;
                _Permission = value;

                OnChanged(oldValue, value, "Permission");
            }
        }
        private GuildPermission _Permission;

        public LinkedListNode<GuildMemberInfo> GuildGerenRankingNode;

        protected override void OnDeleted()
        {
            Account = null;
            Guild = null;

            base.OnDeleted();
        }


        public ClientGuildMemberInfo ToClientInfo()
        {
            ClientGuildMemberInfo info = new ClientGuildMemberInfo
            {
                Index = Index,

                Name = Account.LastCharacter.CharacterName,
                Rank = Rank,
                DailyContribution = DailyContribution,
                TotalContribution = TotalContribution,
                JyTotalContribution = JyTotalContribution,
                Permission = Permission,
            };

            if (Account.Connection?.Player != null)
            {
                info.Online = TimeSpan.MinValue;
                info.MapName = Account.Connection.Player.CurrentMap.Info.Description;
                info.ObjectID = Account.Connection.Player.ObjectID;
            }
            else
                info.Online = SEnvir.Now - Account.Characters.Max(x => x.LastLogin);


            return info;
        }
    }
}
