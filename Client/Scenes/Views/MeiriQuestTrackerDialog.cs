using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Client.Controls;
using Client.Envir;
using Client.UserModels;
using Library;
using Library.SystemModels;


namespace Client.Scenes.Views
{
    public sealed class MeiriQuestTrackerDialog : DXWindow
    {
        #region Properties
        public List<DXLabel> Lines = new List<DXLabel>();

        private DXVScrollBar ScrollBar;
        public DXControl TextPanel;

        public override void OnSizeChanged(Size oValue, Size nValue)
        {
            base.OnSizeChanged(oValue, nValue);

            if (ScrollBar == null || TextPanel == null) return;

            ScrollBar.Size = new Size(14, Size.Height);
            ScrollBar.Location = new Point(Size.Width - 14, 0);
            ScrollBar.VisibleSize = Size.Height;
            

            TextPanel.Location = new Point(0, ResizeBuffer);
            TextPanel.Size = new Size(Size.Width - ScrollBar.Size.Width - 1 - ResizeBuffer , Size.Height - ResizeBuffer * 2);

            ScrollBar.VisibleSize = TextPanel.Size.Height;
            ScrollBar.Location = new Point(Size.Width - ScrollBar.Size.Width - ResizeBuffer, ResizeBuffer);
            ScrollBar.Size = new Size(14, Size.Height - ResizeBuffer * 2);
            PopulateQuests();
        }


        public override WindowType Type => WindowType.MeiriQuestTrackerBox;
        public override bool CustomSize => true;
        public override bool AutomaticVisiblity => true;
        #endregion

        public MeiriQuestTrackerDialog()
        {
            HasTitle = false;
            HasFooter = false;
            HasTopBorder = false;
            TitleLabel.Visible = false;
            CloseButton.Visible = false;
            Opacity = 0.3F;
            AllowResize = true;
            
            ScrollBar = new DXVScrollBar
            {
                Parent = this,
                Change = 15,
            };
            ScrollBar.ValueChanged += (o, e) => UpdateScrollBar();

            TextPanel = new DXControl
            {
                Parent = this,
                PassThrough = true,
                Location = new Point(ResizeBuffer, ResizeBuffer),
                Size = new Size(Size.Width - ScrollBar.Size.Width - 1 - ResizeBuffer * 2, Size.Height - ResizeBuffer * 2),
            };

            Size = new Size(250, 100);
            MouseWheel += ScrollBar.DoMouseWheel;
        }

        #region Methods

        public void UpdateScrollBar()
        {
            ScrollBar.MaxValue = Lines.Count * 15;

            for (int i = 0; i < Lines.Count; i++)
                Lines[i].Location = new Point(Lines[i].Location.X, i * 15 - ScrollBar.Value);
        }

        public void PopulateQuests()
        {
            foreach (DXLabel line in Lines)
                line.Dispose();

            Lines.Clear();

            if (!Config.MeiriQuestTrackerVisible)
            {
                Visible = false;
                return;
            }

            int width = TextPanel.Size.Width - ScrollBar.Size.Width - 15;
            DXLabel dXLabel = new DXLabel
            {
                Visible = false,
                Location = new Point(25, 0)
            };

            foreach (MeiriQuestInfo quest in GameScene.Game.MeiriQuestBox.CurrentTab.Quests)
            {
                ClientMeiriUserQuest userQuest = GameScene.Game.MeiriQuestLog.First(x => x.Quest == quest);

                if (!userQuest.Track) continue;

                DXLabel label = new DXLabel
                {
                    Text = quest.QuestName,
                    Parent = TextPanel,
                    
                    Outline = true,
                    OutlineColour = Color.Black,
                    IsControl = false,
                    Location = new Point(15, Lines.Count * 15)
                };
                

                DXAnimatedControl QuestIcon = new DXAnimatedControl
                {
                    Parent = TextPanel,
                    Location = new Point(2, Lines.Count * 15),
                    Loop = true,
                    LibraryFile = LibraryFile.Interface,
                    BaseIndex = 95,
                    FrameCount = 2,
                    AnimationDelay = TimeSpan.FromSeconds(1),
                    IsControl = false,
                };
                label.Disposing += (o, e) =>
                {
                    QuestIcon.Dispose();
                };

                label.LocationChanged += (o, e) =>
                {
                    QuestIcon.Location = new Point(QuestIcon.Location.X, label.Location.Y);
                };

                QuestIcon.BaseIndex = !userQuest.IsComplete ? 87 : 91;

                int minlevel = 0, maxlevel = 150;
                string zhanshi = null, fashi = null, daoshi = null, cike = null;
                foreach (MeiriQuestRequirement requirement in quest.Requirements)
                {
                    switch (requirement.Requirement)
                    {
                        case MeiriQuestRequirementType.MinLevel:
                            if (requirement.IntParameter1 != 0)
                            {
                                minlevel = requirement.IntParameter1;
                            }
                            else
                                minlevel = 0;
                            break;
                        case MeiriQuestRequirementType.MaxLevel:
                            if (requirement.IntParameter1 != 0)
                            {
                                maxlevel = requirement.IntParameter1;
                            }
                            else
                                maxlevel = 150;
                            break;
                        case MeiriQuestRequirementType.Class:
                            switch (GameScene.Game.User.Class)
                            {
                                case MirClass.Warrior:
                                    zhanshi = "战士";
                                    break;
                                case MirClass.Wizard:
                                    fashi = "法师";
                                    break;
                                case MirClass.Taoist:
                                    daoshi = "道士";
                                    break;
                                case MirClass.Assassin:
                                    cike = "刺客";
                                    break;
                            }
                            break;
                    }
                }

                if (quest.Type == QuestType.None)
                {
                    if (GameScene.Game.MeiriQuestCanCompleted(quest))
                        label.Text = " 【普通】" + quest.QuestName;
                    else
                    {
                        label.Text = " 【普通】" + quest.QuestName + "　　任务条件：最低" + minlevel + "级，" + "最高" + maxlevel + "级，" + zhanshi + fashi + daoshi + cike + "任务";
                        
                    }
                }
                else if (quest.Type == QuestType.DailyCount)
                {
                    if (GameScene.Game.MeiriQuestCanCompleted(quest))
                        label.Text = " 【特殊】" + quest.QuestName;
                    else
                    {
                        label.Text = " 【特殊】" + quest.QuestName + "　　任务条件：最低" + minlevel + "级，" + "最高" + maxlevel + "级，" + zhanshi + fashi + daoshi + cike + "任务";
                        
                    }
                }
                else if (quest.Type == QuestType.DailyRandom)
                {
                    if (GameScene.Game.MeiriQuestCanCompleted(quest))
                        label.Text = " 【随机】" + quest.QuestName;
                    else
                    {
                        label.Text = " 【随机】" + quest.QuestName + "　　任务条件：最低" + minlevel + "级，" + "最高" + maxlevel + "级，" + zhanshi + fashi + daoshi + cike + "任务";
                        
                    }
                }
                else if (quest.Type == QuestType.Event)
                {
                    if (GameScene.Game.MeiriQuestCanCompleted(quest))
                        label.Text = " 【事件】" + quest.QuestName;
                    else
                    {
                        label.Text = " 【事件】" + quest.QuestName + "　　任务条件：最低" + minlevel + "级，" + "最高" + maxlevel + "级，" + zhanshi + fashi + daoshi + cike + "任务";
                        
                    }
                }
                else if (quest.Type == QuestType.Repeatable)
                {
                    if (GameScene.Game.MeiriQuestCanCompleted(quest))
                        label.Text = " 【重复】" + quest.QuestName;
                    else
                    {
                        label.Text = " 【重复】" + quest.QuestName + "　　任务条件：最低" + minlevel + "级，" + "最高" + maxlevel + "级，" + zhanshi + fashi + daoshi + cike + "任务";
                        
                    }
                }

                if (userQuest.IsComplete)
                    label.Text += " (完成)";

                Lines.Add(label);

                foreach (MeiriQuestTask task in quest.Tasks)
                {
                    ClientMeiriUserQuestTask userTask = userQuest.Tasks.FirstOrDefault(x => x.Task == task);

                    if (userTask != null && userTask.Completed) continue;

                    DXLabel label1 = new DXLabel
                    {
                        Text = GameScene.Game.MeiriGetTaskText(task, userQuest),
                        Parent = TextPanel,
                        ForeColour = Color.White,
                        Outline = true,
                        OutlineColour = Color.Black,
                        IsControl = false,
                        Location = new Point(25, Lines.Count * 15)
                    };

                    if (!GameScene.Game.MeiriQuestCanCompleted(quest))
                    {
                        label1.Text = GameScene.Game.MeiriGetTaskText(task, userQuest) + " (无效)";
                        
                    }

                    Lines.Add(label1);
                }
            }
            

            Visible = Lines.Count > 0;
            UpdateScrollBar();
        }
        public void MeiriQuestTransparencyChanged()
        {
            if (!GameScene.Game.MeiriQuestBox.CurrentTab.ToumingShowTrackerBox.Checked)
            {
                ScrollBar.Visible = false;
                DrawTexture = false;
                Opacity = 0F;
                AllowResize = false;
            }
            else
            {
                ScrollBar.Visible = true;
                DrawTexture = true;
                Opacity = 0.3F;
                AllowResize = true;
            }
        }
        #endregion

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
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

                if (ScrollBar != null)
                {
                    if (!ScrollBar.IsDisposed)
                        ScrollBar.Dispose();

                    ScrollBar = null;
                }

                if (TextPanel != null)
                {
                    if (!TextPanel.IsDisposed)
                        TextPanel.Dispose();

                    TextPanel = null;
                }
            }

        }

        #endregion
    }
}
