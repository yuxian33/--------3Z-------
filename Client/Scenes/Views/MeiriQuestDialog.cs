using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Client.Controls;
using Client.Envir;
using Client.Models;
using Client.UserModels;
using Library;
using Library.SystemModels;
using C = Library.Network.ClientPackets;


namespace Client.Scenes.Views
{
    public sealed class MeiriQuestDialog : DXWindow
    {
        #region Properties

        public DXTabControl TabControl;
        public MeiriQuestTab AvailableTab, CurrentTab, CompletedTab, DailyRandomTab, DailyCountTab;

        public override WindowType Type => WindowType.MeiriQuestBox;
        public override bool CustomSize => false;
        public override bool AutomaticVisiblity => true;
        #endregion

        public MeiriQuestDialog()
        {
            TitleLabel.Text = "每日任务日志";

            SetClientSize(new Size(558, 430));

            TabControl = new DXTabControl
            {
                Parent = this,
                Location = ClientArea.Location,
                Size = ClientArea.Size,
            };

            CurrentTab = new MeiriQuestTab
            {
                TabButton = { Label = { Text = "未完成" } },
                Parent = TabControl,
                Border = true,
                ChoiceGrid = { ReadOnly = true }
            };

            AvailableTab = new MeiriQuestTab
            {
                TabButton = { Label = { Text = "可接受" } },
                Parent = TabControl,
                Border = true,
                ShowTrackerBox = { Visible = false },
                ToumingShowTrackerBox = { Visible = false }
            };


            CompletedTab = new MeiriQuestTab
            {
                TabButton = { Label = { Text = "已完成" } },
                Parent = TabControl,
                Border = true,
                ShowTrackerBox = { Visible = false },
                ToumingShowTrackerBox = { Visible = false }
            };

            DailyRandomTab = new MeiriQuestTab
            {
                TabButton = { Label = { Text = "随机任务" } },
                Parent = TabControl,
                Border = true,
                ShowTrackerBox = { Visible = false },
                Tree = { Visible = false },
                DailyRandomPanel = { Visible = true },
                ToumingShowTrackerBox = { Visible = false }
            };
            /*
            DailyCountTab = new MeiriQuestTab
            {
                TabButton = { Label = { Text = "特殊任务" } },
                Parent = TabControl,
                Border = true,
                ShowTrackerBox = { Visible = false },
                Tree = { Visible = false },
            };
            */
        }

        #region Methods

        public void MeiriQuestChanged(ClientMeiriUserQuest quest)
        {
            if (AvailableTab.SelectedQuest?.QuestInfo == quest.Quest)
                AvailableTab.UpdateQuestDisplay();

            if (CurrentTab.SelectedQuest?.QuestInfo == quest.Quest)
                CurrentTab.UpdateQuestDisplay();

            if (CompletedTab.SelectedQuest?.QuestInfo == quest.Quest)
                CompletedTab.UpdateQuestDisplay();

            if (DailyRandomTab.SelectedQuest?.QuestInfo == quest.Quest)
                DailyRandomTab.UpdateQuestDisplay();
            /*
            if (DailyCountTab.SelectedQuest?.QuestInfo == quest.Quest)
                DailyCountTab.UpdateQuestDisplay();
            */

        }

        public void PopulateQuests()
        {
            bool available = false, current = false, completed = false, dailyrandomed = false;
            foreach (MeiriQuestInfo quest in CartoonGlobals.MeiriQuestInfoList.Binding)
            {
                ClientMeiriUserQuest userQuest = GameScene.Game.MeiriQuestLog.FirstOrDefault(x => x.Quest == quest);

                if (userQuest == null)
                {
                    if (GameScene.Game.MeiriCanAccept(quest) && !AvailableTab.Quests.Contains(quest) && quest.Type != QuestType.DailyRandom)
                    {
                        AvailableTab.Quests.Add(quest);
                        available = true;
                    }
                }
                else
                {

                    if (quest.Type == QuestType.DailyRandom)
                    {
                        dailyrandomed = true;
                    }
                    /*
                    if (quest.Type == QuestType.DailyCount)
                    {
                        dailycounted = true;
                    }
                    */
                    if (AvailableTab.Quests.Contains(quest))
                    {
                        AvailableTab.Quests.Remove(quest);
                        available = true;
                    }

                    if (userQuest.Completed)
                    {
                        if (!dailyrandomed)
                        {
                            if (!CompletedTab.Quests.Contains(quest))
                            {
                                CompletedTab.Quests.Add(quest);
                                completed = true;
                                if (CurrentTab.Quests.Contains(quest))
                                {
                                    CurrentTab.Quests.Remove(quest);
                                    current = true;
                                }
                            }
                            continue;
                        }

                        if (DailyRandomTab.Quests.Contains(quest))
                        {
                            DailyRandomTab.Quests.Remove(quest);
                            DailyRandomTab.NeedUpdate = true;
                            DailyRandomTab.UpdateQuestDisplay();
                        }

                        if (!CurrentTab.Quests.Contains(quest)) continue;

                        CurrentTab.Quests.Remove(quest);
                        current = true;
                    }
                    if (dailyrandomed && !DailyRandomTab.Quests.Contains(quest))
                    {
                        DailyRandomTab.Quests.Add(quest);
                        DailyRandomTab.NeedUpdate = true;
                        DailyRandomTab.UpdateQuestDisplay();
                    }
                    
                    if (!dailyrandomed && DailyRandomTab.Quests.Contains(quest))
                    {
                        DailyRandomTab.Quests.Remove(quest);
                        DailyRandomTab.NeedUpdate = true;
                        DailyRandomTab.UpdateQuestDisplay();
                    }
                    
                    if (!CurrentTab.Quests.Contains(quest))
                    {
                        CurrentTab.Quests.Add(quest);
                        current = true;
                    }
                }
            }
            if (available)
            {
                AvailableTab.NeedUpdate = true;
                AvailableTab.UpdateQuestDisplay();
            }
            if (current)
            {
                CurrentTab.NeedUpdate = true;
                CurrentTab.UpdateQuestDisplay();
            }
            if (completed)
            {
                CompletedTab.NeedUpdate = true;
                CompletedTab.UpdateQuestDisplay();
            }
            if (dailyrandomed)
            {
                CurrentTab.NeedUpdate = true;
                CurrentTab.UpdateQuestDisplay();
            }
        }
        #endregion

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                if (TabControl != null)
                {
                    if (!TabControl.IsDisposed)
                        TabControl.Dispose();

                    TabControl = null;
                }

                if (AvailableTab != null)
                {
                    if (!AvailableTab.IsDisposed)
                        AvailableTab.Dispose();

                    AvailableTab = null;
                }

                if (CurrentTab != null)
                {
                    if (!CurrentTab.IsDisposed)
                        CurrentTab.Dispose();

                    CurrentTab = null;
                }

                if (CompletedTab != null)
                {
                    if (!CompletedTab.IsDisposed)
                        CompletedTab.Dispose();

                    CompletedTab = null;
                }
            }

        }

        #endregion
    }

    public sealed class MeiriQuestTab : DXTab
    {
        #region Properties

        #region NeedUpdate

        public bool NeedUpdate
        {
            get => _NeedUpdate;
            set
            {
                if (_NeedUpdate == value) return;

                bool oldValue = _NeedUpdate;
                _NeedUpdate = value;

                OnNeedUpdateChanged(oldValue, value);
            }
        }
        private bool _NeedUpdate;
        public event EventHandler<EventArgs> NeedUpdateChanged;
        public void OnNeedUpdateChanged(bool oValue, bool nValue)
        {
            NeedUpdateChanged?.Invoke(this, EventArgs.Empty);

            if (!NeedUpdate) return;

            if (!IsVisible) return;

            UpdateQuestTree();
        }

        #endregion


        #region SelectedQuest

        public MeiriQuestTreeEntry SelectedQuest
        {
            get => _SelectedQuest;
            set
            {

                MeiriQuestTreeEntry oldValue = _SelectedQuest;
                _SelectedQuest = value;

                OnSelectedQuestChanged(oldValue, value);
            }
        }
        private MeiriQuestTreeEntry _SelectedQuest;
        public event EventHandler<EventArgs> SelectedQuestChanged;
        public void OnSelectedQuestChanged(MeiriQuestTreeEntry oValue, MeiriQuestTreeEntry nValue)
        {
            SelectedQuestChanged?.Invoke(this, EventArgs.Empty);

            foreach (DXItemCell cell in RewardGrid.Grid)
            {
                cell.Item = null;
                cell.Tag = null;
            }

            foreach (DXItemCell cell in ChoiceGrid.Grid)
            {
                cell.Item = null;
                cell.Tag = null;
                cell.FixedBorder = false;
                cell.Border = false;
                cell.FixedBorderColour = false;
                cell.BorderColour = Color.Lime;
            }

            if (SelectedQuest?.QuestInfo == null)
            {
                TasksLabel.Text = string.Empty;
                DescriptionLabel.Text = string.Empty;
                TypeLabel.Text = string.Empty;
                EndLabel.Text = string.Empty;
                StartLabel.Text = string.Empty;
                return;
            }

            int standard = 0, choice = 0;

            foreach (MeiriQuestReward reward in SelectedQuest.QuestInfo.Rewards)
            {
                switch (MapObject.User.Class)
                {
                    case MirClass.Warrior:
                        if ((reward.Class & RequiredClass.Warrior) != RequiredClass.Warrior) continue;
                        break;
                    case MirClass.Wizard:
                        if ((reward.Class & RequiredClass.Wizard) != RequiredClass.Wizard) continue;
                        break;
                    case MirClass.Taoist:
                        if ((reward.Class & RequiredClass.Taoist) != RequiredClass.Taoist) continue;
                        break;
                    case MirClass.Assassin:
                        if ((reward.Class & RequiredClass.Assassin) != RequiredClass.Assassin) continue;
                        break;
                }

                UserItemFlags flags = UserItemFlags.None;
                TimeSpan duration = TimeSpan.FromSeconds(reward.Duration);

                if (reward.Bound)
                    flags |= UserItemFlags.Bound;

                if (duration != TimeSpan.Zero)
                    flags |= UserItemFlags.Expirable;

                ClientUserItem item = new ClientUserItem(reward.Item, reward.Amount)
                {
                    Flags = flags,
                    ExpireTime = duration
                };

                if (reward.Choice)
                {
                    if (choice >= ChoiceGrid.Grid.Length) continue;

                    ChoiceGrid.Grid[choice].Item = item;

                    if (SelectedQuest.UserQuest?.SelectedReward == reward.Index)
                    {
                        ChoiceGrid.Grid[choice].Border = true;
                        ChoiceGrid.Grid[choice].FixedBorder = true;
                        ChoiceGrid.Grid[choice].FixedBorderColour = true;
                        ChoiceGrid.Grid[choice].BorderColour = Color.Lime;
                    }
                    choice++;
                }
                else
                {
                    if (standard >= RewardGrid.Grid.Length) continue;

                    RewardGrid.Grid[standard].Item = item;

                    standard++;
                }
            }

            DescriptionLabel.Text = GameScene.Game.MeiriGetQuestText(SelectedQuest.QuestInfo, SelectedQuest.UserQuest, true);
            TasksLabel.Text = GameScene.Game.MeiriGetTaskText(SelectedQuest.QuestInfo, SelectedQuest.UserQuest);
            if (SelectedQuest.QuestInfo.Type == QuestType.None)
                TypeLabel.Text = "普通任务";
            else if (SelectedQuest.QuestInfo.Type == QuestType.DailyCount)
                TypeLabel.Text = "特殊任务";
            else if (SelectedQuest.QuestInfo.Type == QuestType.DailyRandom)
                TypeLabel.Text = "随机任务";
            else if (SelectedQuest.QuestInfo.Type == QuestType.Repeatable)
                TypeLabel.Text = "重复任务";
            else if (SelectedQuest.QuestInfo.Type == QuestType.Event)
                TypeLabel.Text = "事件任务";
            EndLabel.Text = SelectedQuest.QuestInfo.FinishNPC.RegionName;
            StartLabel.Text = SelectedQuest.QuestInfo.StartNPC.RegionName;
            
            SelectedQuestChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        public List<MeiriQuestInfo> Quests = new List<MeiriQuestInfo>();

        public DXVScrollBar ScrollBar;

        public DXLabel TasksLabel, DescriptionLabel, EndLabel, StartLabel, TypeLabel, DailyRandomResetCount;

        public DXItemGrid RewardGrid, ChoiceGrid;
        
        public ClientUserItem[] RewardArray, ChoiceArray;

        public DXCheckBox ShowTrackerBox, ToumingShowTrackerBox;

        public bool HasChoice;

        public bool DailyRndomTab;

        public int DailyRandomResetCounts;

        public DXControl DailyRandomPanel;

        public DXButton DailyRandomButton, DailyRandomResetButton;

        public MeiriQuestTree Tree;

        public override void OnIsVisibleChanged(bool oValue, bool nValue)
        {
            base.OnIsVisibleChanged(oValue, nValue);

            if (!IsVisible || !NeedUpdate) return;

            UpdateQuestTree();

        }
        

        public override void OnSizeChanged(Size oValue, Size nValue)
        {
            base.OnSizeChanged(oValue, nValue);

            if (Tree == null) return;

            Tree.Size = new Size(240, Size.Height - 10);

        }
        #endregion

        public MeiriQuestTab()
        {
            int width = 250;

            Tree = new MeiriQuestTree
            {
                Parent = this,
                Location = new Point(5, 5)
            };
            Tree.SelectedEntryChanged += (o, e) => SelectedQuest = Tree.SelectedEntry;

            DailyRandomPanel = new DXControl
            {
                Size = new Size(240, 400),
                Border = true,
                BorderColour = Color.FromArgb(198, 166, 99),
                Visible = false,
                Location = new Point(5, 5),
                Parent = this
            };
            DXLabel dXLabel = new DXLabel
            {
                Size = new Size(240, 50),
                ForeColour = Color.White,
                AutoSize = false,
                Location = new Point(5, 25),
                IsControl = false,
                Parent = DailyRandomPanel,
                Text = "　每日随机任务每天可以获得两次，如果接到不想做的任务，可以用随机点重置"
            };
            dXLabel = new DXLabel
            {
                Location = new Point(5, dXLabel.Location.Y + dXLabel.Size.Height + 5),
                IsControl = false,
                ForeColour = Color.White,
                Parent = DailyRandomPanel,
                Text = "获得一个新的每日随机任务"
            };
            DailyRandomButton = new DXButton
            {
                Label = { Text = "获得每日随机任务" },
                Parent = DailyRandomPanel,
                Location = new Point(10, dXLabel.Location.Y + dXLabel.Size.Height + 10),
                Size = new Size(120, DXControl.SmallButtonHeight),
                ButtonType = ButtonType.SmallButton,
                Visible = true,

            };
            DailyRandomButton.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.MeiriDailyRandomQuestGain());
            };
            DailyRandomResetCount = new DXLabel
            {
                Location = new Point(5, DailyRandomButton.Location.Y + 25),
                IsControl = false,
                ForeColour = Color.White,
                Parent = DailyRandomPanel,
                Text = "你今天还有2次每日随机任务重置机会"
            };
            DailyRandomResetButton = new DXButton
            {
                Label = { Text = "重置每日随机任务" },
                Parent = DailyRandomPanel,
                Location = new Point(10, DailyRandomResetCount.Location.Y + DailyRandomResetCount.Size.Height + 10),
                Size = new Size(120, DXControl.SmallButtonHeight),
                ButtonType = ButtonType.SmallButton,
                Visible = true,
            };
            DailyRandomResetButton.MouseClick += (o, e) =>
            {
                GameScene.Game.MeiriQuestBox.CurrentTab.SelectedQuest = null;
                CEnvir.Enqueue(new C.MeiriDailyRandomQuestReset());
            };
            DXLabel label = new DXLabel
            {
                Text = "任务类型:",
                Parent = this,
                Font = new Font(Config.FontName, CEnvir.FontSize(10f), FontStyle.Bold),
                
                Outline = true,
                OutlineColour = Color.Black,
                IsControl = false,
                Location = new Point(width, 4)
            };
            TypeLabel = new DXLabel
            {
                ForeColour = Color.White,
                Location = new Point(label.Location.X + label.Size.Width, 4),
                Font = new Font(Config.FontName, CEnvir.FontSize(10f), FontStyle.Bold),
                Outline = true,
                OutlineColour = Color.Black,
                IsControl = false,
                Parent = this
            };

            ShowTrackerBox = new DXCheckBox
            {
                Label = { Text = "显示任务追踪" }, 
                Parent = this,
            };
            ShowTrackerBox.Location = new Point(width + 283 - ShowTrackerBox.Size.Width, 7);
            ShowTrackerBox.CheckedChanged += (o, e) =>
            {   
                Config.MeiriQuestTrackerVisible = ShowTrackerBox.Checked;
                GameScene.Game.MeiriQuestTrackerBox.PopulateQuests();
            };

            ToumingShowTrackerBox = new DXCheckBox
            {
                
                Parent = this,
            };
            ToumingShowTrackerBox.Location = new Point(width + 303 - ToumingShowTrackerBox.Size.Width, 7);
            ToumingShowTrackerBox.CheckedChanged += (o, e) =>
            {
                Config.MeiriToumingQuestTrackerVisible = ToumingShowTrackerBox.Checked;
                if (ShowTrackerBox.Checked)
                    GameScene.Game.MeiriQuestTrackerBox.MeiriQuestTransparencyChanged();
            };


            DescriptionLabel = new DXLabel
            {
                AutoSize = false,
                Size = new Size(300 - 4, 80),
                Border = true,
                BorderColour = Color.FromArgb(198, 166, 99),
                ForeColour = Color.White,
                Location = new Point(width + 3, label.Location.Y + label.Size.Height + 5),
                Parent = this,
            };

            label = new DXLabel
            {
                Text = "完成条件",
                Parent = this,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Bold),
                
                Outline = true,
                OutlineColour = Color.Black,
                IsControl = false,
                Location = new Point(width + 0, DescriptionLabel.Location.Y + DescriptionLabel.Size.Height + 5),
            };


            TasksLabel = new DXLabel
            {
                AutoSize = false,
                Size = new Size(300 - 4, 80),
                Border = true,
                BorderColour = Color.FromArgb(198, 166, 99),
                ForeColour = Color.White,
                Location = new Point(width + 3, label.Location.Y + label.Size.Height + 5),
                Parent = this,
            };

            label = new DXLabel
            {
                Text = "任务奖励",
                Parent = this,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Bold),
                
                Outline = true,
                OutlineColour = Color.Black,
                IsControl = false,
                Location = new Point(width + 0, TasksLabel.Location.Y + TasksLabel.Size.Height + 5),
            };

            RewardArray = new ClientUserItem[8];
            RewardGrid = new DXItemGrid
            {
                Parent = this,
                Location = new Point(width + 2, label.Location.Y + label.Size.Height + 5),
                GridSize = new Size(RewardArray.Length, 1),
                ItemGrid = RewardArray,
                ReadOnly = true,
            };

            label = new DXLabel
            {
                Text = "奖励选择",
                Parent = this,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Bold),
                
                Outline = true,
                OutlineColour = Color.Black,
                IsControl = false,
                Location = new Point(width + 0, TasksLabel.Location.Y + TasksLabel.Size.Height + 68),
            };

            ChoiceArray = new ClientUserItem[8];
            ChoiceGrid = new DXItemGrid
            {
                Parent = this,
                Location = new Point(width + 2, label.Location.Y + label.Size.Height + 5),
                GridSize = new Size(ChoiceArray.Length, 1),
                ItemGrid = ChoiceArray,
                ReadOnly = true,
            };

            label = new DXLabel
            {
                Text = "开始:",
                Parent = this,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Bold),
                
                Outline = true,
                OutlineColour = Color.Black,
                IsControl = false,
            };
            label.Location = new Point(width + 50 - label.Size.Width, ChoiceGrid.Location.Y + ChoiceGrid.Size.Height + 10);

            StartLabel = new DXLabel
            {
                Parent = this,
                ForeColour = Color.White,
                Location = new Point(label.Location.X + label.Size.Width - 8, label.Location.Y + (label.Size.Height - 12) / 2),
            };
            StartLabel.MouseClick += (o, e) =>
            {
                if (SelectedQuest?.QuestInfo?.StartNPC?.Region?.Map == null) return;

                GameScene.Game.BigMapBox.Visible = true;
                GameScene.Game.BigMapBox.Opacity = 1F;
                GameScene.Game.BigMapBox.SelectedInfo = SelectedQuest.QuestInfo.StartNPC.Region.Map;
            };

            label = new DXLabel
            {
                Text = "结束:",
                Parent = this,
                Font = new Font(Config.FontName, CEnvir.FontSize(10F), FontStyle.Bold),
                
                Outline = true,
                OutlineColour = Color.Black,
                IsControl = false,
                Location = new Point(width + 0, label.Location.Y + label.Size.Height),
            };
            label.Location = new Point(width + 50 - label.Size.Width, ChoiceGrid.Location.Y + ChoiceGrid.Size.Height + 10 + label.Size.Height);

            EndLabel = new DXLabel
            {
                Parent = this,
                ForeColour = Color.White,
                Location = new Point(label.Location.X + label.Size.Width - 8, label.Location.Y + (label.Size.Height - 12)/2),
            };
            EndLabel.MouseClick += (o, e) =>
            {
                if (SelectedQuest?.QuestInfo?.FinishNPC?.Region?.Map == null) return;

                GameScene.Game.BigMapBox.Visible = true;
                GameScene.Game.BigMapBox.Opacity = 1F;
                GameScene.Game.BigMapBox.SelectedInfo = SelectedQuest.QuestInfo.FinishNPC.Region.Map;
            };

        }

        #region Methods

        public void UpdateQuestTree()
        {
            NeedUpdate = false;

            Tree.TreeList.Clear();

            Quests.Sort((x1, x2) =>
            {
                int res = string.Compare(x1.StartNPC.Region.Map.Description, x2.StartNPC.Region.Map.Description, StringComparison.Ordinal);
                if (res == 0)
                    return string.Compare(x1.QuestName, x2.QuestName, StringComparison.Ordinal);

                return res;
            });
            foreach (MeiriQuestInfo quest in Quests)
            {
                MapInfo map = quest?.StartNPC?.Region?.Map;

                if (map == null) continue;

                List<MeiriQuestInfo> quests;
                if (!Tree.TreeList.TryGetValue(map, out quests))
                    Tree.TreeList[map] = quests = new List<MeiriQuestInfo>();

                quests.Add(quest);
            }

            Tree.ListChanged();
        }

        public void UpdateQuestDisplay()
        {
            if (SelectedQuest == null)
            {
                TasksLabel.Text = string.Empty;
                return;
            }

            TasksLabel.Text = SelectedQuest?.QuestInfo == null ? string.Empty : GameScene.Game.MeiriGetTaskText(SelectedQuest.QuestInfo, SelectedQuest.UserQuest);

            if (SelectedQuest != null)
                SelectedQuest.QuestInfo = SelectedQuest.QuestInfo; 
        }
        #endregion

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                Quests.Clear();
                Quests = null;

                RewardArray = null;
                ChoiceArray = null;

                HasChoice = false;

                _SelectedQuest = null;
                SelectedQuestChanged = null;

                _NeedUpdate = false;
                NeedUpdateChanged = null;

                if (ScrollBar != null)
                {
                    if (!ScrollBar.IsDisposed)
                        ScrollBar.Dispose();

                    ScrollBar = null;
                }

                if (TasksLabel != null)
                {
                    if (!TasksLabel.IsDisposed)
                        TasksLabel.Dispose();

                    TasksLabel = null;
                }

                if (DescriptionLabel != null)
                {
                    if (!DescriptionLabel.IsDisposed)
                        DescriptionLabel.Dispose();

                    DescriptionLabel = null;
                }

                if (EndLabel != null)
                {
                    if (!EndLabel.IsDisposed)
                        EndLabel.Dispose();

                    EndLabel = null;
                }

                if (StartLabel != null)
                {
                    if (!StartLabel.IsDisposed)
                        StartLabel.Dispose();

                    StartLabel = null;
                }
                
                if (RewardGrid != null)
                {
                    if (!RewardGrid.IsDisposed)
                        RewardGrid.Dispose();

                    RewardGrid = null;
                }

                if (ChoiceGrid != null)
                {
                    if (!ChoiceGrid.IsDisposed)
                        ChoiceGrid.Dispose();

                    ChoiceGrid = null;
                }


                if (ShowTrackerBox != null)
                {
                    if (!ShowTrackerBox.IsDisposed)
                        ShowTrackerBox.Dispose();

                    ShowTrackerBox = null;
                }

                if (Tree != null)
                {
                    if (!Tree.IsDisposed)
                        Tree.Dispose();

                    Tree = null;
                }

                if (DailyRandomButton != null)
                {
                    if (!DailyRandomButton.IsDisposed)
                        DailyRandomButton.Dispose();
                    
                    DailyRandomButton = null;
                }
                if (DailyRandomResetButton != null)
                {
                    if (!DailyRandomResetButton.IsDisposed)
                        DailyRandomResetButton.Dispose();

                    DailyRandomResetButton = null;
                }
            }

        }

        #endregion
    }


    public class MeiriQuestTree : DXControl
    {
        #region Properties

        #region SelectedEntry

        public MeiriQuestTreeEntry SelectedEntry
        {
            get => _SelectedEntry;
            set
            {
                MeiriQuestTreeEntry oldValue = _SelectedEntry;
                _SelectedEntry = value;

                OnSelectedEntryChanged(oldValue, value);
            }
        }
        private MeiriQuestTreeEntry _SelectedEntry;
        public event EventHandler<EventArgs> SelectedEntryChanged;
        public virtual void OnSelectedEntryChanged(MeiriQuestTreeEntry oValue, MeiriQuestTreeEntry nValue)
        {
            SelectedEntryChanged?.Invoke(this, EventArgs.Empty);

            if (oValue != null)
                oValue.Selected = false;

            if (nValue != null)
                nValue.Selected = true;
        }

        #endregion

        public Dictionary<MapInfo, List<MeiriQuestInfo>> TreeList = new Dictionary<MapInfo, List<MeiriQuestInfo>>();

        private DXVScrollBar ScrollBar;

        public List<DXControl> Lines = new List<DXControl>();
        
        public override void OnSizeChanged(Size oValue, Size nValue)
        {
            base.OnSizeChanged(oValue, nValue);

            ScrollBar.Size = new Size(14, Size.Height);
            ScrollBar.Location = new Point(Size.Width - 14, 0);
            ScrollBar.VisibleSize = Size.Height;
        }
        #endregion
        
        public MeiriQuestTree()
        {
            Border = true;
            BorderColour = Color.FromArgb(198, 166, 99);

            ScrollBar = new DXVScrollBar
            {
                Parent = this,
                Change = 22,
            };
            ScrollBar.ValueChanged += (o, e) => UpdateScrollBar();

            MouseWheel += ScrollBar.DoMouseWheel;
        }

        #region Methods
        public void UpdateScrollBar()
        {
            ScrollBar.MaxValue = Lines.Count * 22;
            
            for (int i = 0; i < Lines.Count; i++)
                Lines[i].Location = new Point(Lines[i].Location.X, i*22 - ScrollBar.Value);
        }

        public void ListChanged()
        {
            MeiriQuestInfo selectedQuest = SelectedEntry?.QuestInfo;

            foreach (DXControl control in Lines)
                control.Dispose();

            Lines.Clear();

            _SelectedEntry = null;
            MeiriQuestTreeEntry firstEntry = null;

            foreach (KeyValuePair<MapInfo, List<MeiriQuestInfo>> pair in TreeList)
            {
                MeiriQuestTreeHeader header = new MeiriQuestTreeHeader
                {
                    Parent = this,
                    Location = new Point(1, Lines.Count*22),
                    Size = new Size(Size.Width - 17, 20),
                    Map = pair.Key
                };
                header.ExpandButton.MouseClick += (o, e) => ListChanged();
                header.MouseWheel += ScrollBar.DoMouseWheel;

                Lines.Add(header);

                if (!pair.Key.Expanded) continue;

                foreach (MeiriQuestInfo quest in pair.Value)
                {
                    MeiriQuestTreeEntry entry = new MeiriQuestTreeEntry
                    {
                        Parent = this,
                        Location = new Point(1, Lines.Count*22),
                        Size = new Size(Size.Width - 17, 20),
                        QuestInfo = quest,
                        Selected = quest == selectedQuest,
                    };
                    entry.MouseWheel += ScrollBar.DoMouseWheel;
                    entry.MouseClick += (o, e) =>
                    {
                        SelectedEntry = entry;
                    };

                    if (firstEntry == null)
                        firstEntry = entry;

                    if (entry.Selected)
                        SelectedEntry = entry;

                    entry.TrackBox.CheckedChanged += (o, e) =>
                    {
                        if (entry.UserQuest == null) return;

                        if (entry.UserQuest.Track == entry.TrackBox.Checked) return;

                        entry.UserQuest.Track = entry.TrackBox.Checked;

                        CEnvir.Enqueue(new C.MeiriQuestTrack { Index = entry.UserQuest.Index, Track = entry.UserQuest.Track });

                        GameScene.Game.MeiriQuestTrackerBox.PopulateQuests();
                        GameScene.Game.updateToggleQuests();
                    };

                    Lines.Add(entry);
                }
            }

            if (SelectedEntry == null)
                SelectedEntry = firstEntry;

            UpdateScrollBar();
        }
        #endregion

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                TreeList.Clear();
                TreeList = null;

                _SelectedEntry = null;
                SelectedEntryChanged = null;

                if (ScrollBar != null)
                {
                    if (!ScrollBar.IsDisposed)
                        ScrollBar.Dispose();

                    ScrollBar = null;
                }

                if (Lines != null)
                {
                    for (int i = 0; i < Lines.Count; i++)
                    {
                        if (Lines[i] != null)
                        {
                            if (!Lines[i].IsDisposed)
                                Lines[i].Dispose();

                            Lines[i] = null;
                        }

                    }

                    Lines.Clear();
                    Lines = null;
                }
            }

        }

        #endregion
    }

    public sealed class MeiriQuestTreeHeader : DXControl
    {
        #region Properties

        #region Expanded

        public bool Expanded
        {
            get => _Expanded;
            set
            {
                if (_Expanded == value) return;

                bool oldValue = _Expanded;
                _Expanded = value;

                OnExpandedChanged(oldValue, value);
            }
        }
        private bool _Expanded;
        public event EventHandler<EventArgs> ExpandedChanged;
        public void OnExpandedChanged(bool oValue, bool nValue)
        {
            ExpandedChanged?.Invoke(this, EventArgs.Empty);


            ExpandButton.Index = Expanded ? 4871 : 4870;

            Map.Expanded = Expanded;
        }

        #endregion

        #region Map

        public MapInfo Map
        {
            get => _Map;
            set
            {
                if (_Map == value) return;

                MapInfo oldValue = _Map;
                _Map = value;

                OnMapChanged(oldValue, value);
            }
        }
        private MapInfo _Map;
        public event EventHandler<EventArgs> MapChanged;
        public void OnMapChanged(MapInfo oValue, MapInfo nValue)
        {
            Expanded = Map.Expanded;
            MapLabel.Text = Map.Description;

            MapChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion
        
        public DXButton ExpandButton;
        public DXLabel MapLabel;
        #endregion

        public MeiriQuestTreeHeader()
        {
            ExpandButton = new DXButton
            {
                Parent = this,
                LibraryFile = LibraryFile.GameInter,
                Index = 4870,
                Location = new Point(2, 2)
            };
            ExpandButton.MouseClick += (o, e) => Expanded = !Expanded;

            MapLabel = new DXLabel
            {
                Parent = this,
                ForeColour = Color.White,
                IsControl = false,
                Location = new Point(25, 2)
            };
        }

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                _Expanded = false;
                ExpandedChanged = null;

                _Map = null;
                MapChanged = null;


                if (ExpandButton != null)
                {
                    if (!ExpandButton.IsDisposed)
                        ExpandButton.Dispose();

                    ExpandButton = null;
                }

                if (MapLabel != null)
                {
                    if (!MapLabel.IsDisposed)
                        MapLabel.Dispose();

                    MapLabel = null;
                }
            }

        }

        #endregion
    }

    public sealed class MeiriQuestTreeEntry : DXControl
    {
        #region Properties

        #region Selected

        public bool Selected
        {
            get => _Selected;
            set
            {
                if (_Selected == value) return;

                bool oldValue = _Selected;
                _Selected = value;

                OnSelectedChanged(oldValue, value);
            }
        }
        private bool _Selected;
        public event EventHandler<EventArgs> SelectedChanged;
        public void OnSelectedChanged(bool oValue, bool nValue)
        {
            SelectedChanged?.Invoke(this, EventArgs.Empty);
            Border = Selected;
            BackColour = Selected ? Color.FromArgb(80, 80, 125) : Color.FromArgb(25, 20, 0);

        }

        #endregion

        #region MeiriQuestInfo

        public MeiriQuestInfo QuestInfo
        {
            get => _QuestInfo;
            set
            {
                MeiriQuestInfo oldValue = _QuestInfo;
                _QuestInfo = value;

                OnQuestInfoChanged(oldValue, value);
            }
        }
        private MeiriQuestInfo _QuestInfo;
        public event EventHandler<EventArgs> QuestInfoChanged;
        public void OnQuestInfoChanged(MeiriQuestInfo oValue, MeiriQuestInfo nValue)
        {
            UserQuest = GameScene.Game.MeiriQuestLog.FirstOrDefault(x => x.Quest == QuestInfo);

            TrackBox.Visible = false;
            QuestNameLabel.Text = QuestInfo.QuestName;

            if (UserQuest == null)
            {
                QuestIcon.BaseIndex = 83; 
                QuestNameLabel.Location = new Point(40, 2);
            }
            else if (UserQuest.Completed)
            {
                QuestIcon.BaseIndex = 91; 
                QuestNameLabel.Location = new Point(40, 2);
            }
            else if (!UserQuest.IsComplete)
            {
                QuestIcon.BaseIndex = 85; 
                TrackBox.Visible = true;
                QuestNameLabel.Location = new Point(65, 2);
            }
            else
            {
                QuestIcon.BaseIndex = 93; 
                TrackBox.Visible = true;
                QuestNameLabel.Location = new Point(65, 2);
            }

            TrackBox.Checked = UserQuest != null && UserQuest.Track;

            QuestInfoChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region MeiriUserQuest

        public ClientMeiriUserQuest UserQuest
        {
            get => _UserQuest;
            set
            {
                ClientMeiriUserQuest oldValue = _UserQuest;
                _UserQuest = value;

                OnUserQuestChanged(oldValue, value);
            }
        }
        private ClientMeiriUserQuest _UserQuest;
        public event EventHandler<EventArgs> UserQuestChanged;
        public void OnUserQuestChanged(ClientMeiriUserQuest oValue, ClientMeiriUserQuest nValue)
        {
            UserQuestChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        public DXCheckBox TrackBox;

        public DXAnimatedControl QuestIcon;
        public DXLabel QuestNameLabel;

        #endregion

        public MeiriQuestTreeEntry()
        {
            DrawTexture = true;
            BackColour = Color.FromArgb(25, 20, 0);

            BorderColour = Color.FromArgb(198, 166, 99);
            QuestIcon = new DXAnimatedControl
            {
                Parent = this,
                Location = new Point(20, 2),
                Loop = true,
                LibraryFile = LibraryFile.Interface,
                BaseIndex = 83,
                FrameCount = 2,
                AnimationDelay = TimeSpan.FromSeconds(1),
                IsControl = false,
            };

            TrackBox = new DXCheckBox
            {
                Parent = this,
                Location = new Point(45, 3),
            };


            QuestNameLabel = new DXLabel
            {
                Parent = this,
                Location = new Point(65, 2),
                IsControl = false,
            };
        }

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                _Selected = false;
                SelectedChanged = null;

                _QuestInfo = null;
                QuestInfoChanged = null;

                _UserQuest = null;
                UserQuestChanged = null;


                if (TrackBox != null)
                {
                    if (!TrackBox.IsDisposed)
                        TrackBox.Dispose();

                    TrackBox = null;
                }

                if (QuestIcon != null)
                {
                    if (!QuestIcon.IsDisposed)
                        QuestIcon.Dispose();

                    QuestIcon = null;
                }

                if (QuestNameLabel != null)
                {
                    if (!QuestNameLabel.IsDisposed)
                        QuestNameLabel.Dispose();

                    QuestNameLabel = null;
                }

            }

        }

        #endregion
    }

}