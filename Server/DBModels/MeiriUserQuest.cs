using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using Library.SystemModels;
using CartoonMirDB;
using Server.Models;

namespace Server.DBModels
{
    [UserObject]
    public sealed class MeiriUserQuest : DBObject
    {
        public MeiriQuestInfo QuestInfo
        {
            get { return _QuestInfo; }
            set
            {
                if (_QuestInfo == value) return;

                var oldValue = _QuestInfo;
                _QuestInfo = value;

                OnChanged(oldValue, value, "QuestInfo");
            }
        }
        private MeiriQuestInfo _QuestInfo;

        [Association("MeiriQuests")]
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
        
        public bool Completed
        {
            get { return _Completed; }
            set
            {
                if (_Completed == value) return;

                var oldValue = _Completed;
                _Completed = value;

                OnChanged(oldValue, value, "Completed");
            }
        }
        private bool _Completed;

        public int SelectedReward
        {
            get { return _SelectedReward; }
            set
            {
                if (_SelectedReward == value) return;

                var oldValue = _SelectedReward;
                _SelectedReward = value;

                OnChanged(oldValue, value, "SelectedReward");
            }
        }
        private int _SelectedReward;

        public bool Track
        {
            get { return _Track; }
            set
            {
                if (_Track == value) return;

                var oldValue = _Track;
                _Track = value;

                OnChanged(oldValue, value, "Track");
            }
        }
        private bool _Track;
        

        [IgnoreProperty]
        public bool IsComplete => Tasks.Count == QuestInfo.Tasks.Count && Tasks.All(x => x.Completed);


        [Association("Tasks", true)]
        public DBBindingList<MeiriUserQuestTask> Tasks { get; set; }

        protected override void OnDeleted()
        {
            QuestInfo = null;
            Account = null;

            for (int i = Tasks.Count - 1; i >= 0; i--)
                Tasks[i].Delete();

            base.OnDeleted();
        }


        public ClientMeiriUserQuest ToClientInfo()
        {
            return new ClientMeiriUserQuest
            {
                Index = Index,
                QuestIndex =  QuestInfo.Index,
                Completed = Completed,
                SelectedReward = SelectedReward,
                Track = Track,


                Tasks = Tasks.Select(x=> x.ToClientInfo()).ToList(),
            };
        }

        protected override void OnCreated()
        {
            base.OnCreated();

            Track = true;
        }
    }


    [UserObject]
    public sealed class MeiriUserQuestTask : DBObject
    {
        [Association("Tasks")]
        public MeiriUserQuest Quest
        {
            get { return _Quest; }
            set
            {
                if (_Quest == value) return;

                var oldValue = _Quest;
                _Quest = value;

                OnChanged(oldValue, value, "Quest");
            }
        }
        private MeiriUserQuest _Quest;

        public MeiriQuestTask Task
        {
            get { return _Task; }
            set
            {
                if (_Task == value) return;

                var oldValue = _Task;
                _Task = value;

                OnChanged(oldValue, value, "Task");
            }
        }
        private MeiriQuestTask _Task;
        
        public long Amount
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
        private long _Amount;

        [IgnoreProperty]
        public bool Completed => Amount >= Task.Amount;

        protected override void OnDeleted()
        {
            Quest = null;
            Task = null;

            base.OnDeleted();
        }

        public ClientMeiriUserQuestTask ToClientInfo()
        {
            return new ClientMeiriUserQuestTask
            {
                Index = Index,

                TaskIndex = Task.Index,

                Amount = Amount
            };
        }

        public List<ItemObject> Objects = new List<ItemObject>();
    }
}
