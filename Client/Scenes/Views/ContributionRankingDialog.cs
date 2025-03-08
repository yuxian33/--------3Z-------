using System;
using System.Drawing;
using System.Windows.Forms;
using Client.Controls;
using Client.Envir;
using Client.UserModels;
using Library;
using S =  Library.Network.ServerPackets;
using C = Library.Network.ClientPackets;
using System.Reflection;
using System.ComponentModel;


namespace Client.Scenes.Views
{
    public sealed class ContributionRankingDialog : DXWindow
    {
        #region Properties
        #region StartIndex

        public int StartIndex
        {
            get => _StartIndex;
            set
            {
                if (_StartIndex == value) return;

                int oldValue = _StartIndex;
                _StartIndex = value;

                OnStartIndexChanged(oldValue, value);
            }
        }
        private int _StartIndex;
        public event EventHandler<EventArgs> StartIndexChanged;
        public void OnStartIndexChanged(int oValue, int nValue)
        {
            UpdateTime = CEnvir.Now.AddMilliseconds(250);
            
            if (nValue > oValue)
                for (int i = 0; i < Lines.Length; i++)
                {
                    if (nValue - oValue + i < Lines.Length)
                    {
                        if (Lines[i + nValue - oValue].Rank != null)
                        {
                            Lines[i].Rank = Lines[i + nValue - oValue].Rank;
                        }
                        else
                            Lines[i].Loading = true;
                    }
                    else
                        Lines[i].Loading = true;

                }
            else
                for (int i = Lines.Length - 1; i >= 0; i--)
                {
                    if (nValue - oValue + i >= 0)
                    {
                        if (Lines[i + nValue - oValue].Rank != null)
                        Lines[i].Rank = Lines[i + nValue - oValue].Rank;
                        else
                            Lines[i].Loading = true;
                    }
                    else
                        Lines[i].Loading = true;
                }



            StartIndexChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion
        
        public DateTime UpdateTime;

        private DXControl Panel;
        private DXVScrollBar ScrollBar;

        public DXComboBox RequiredClassBox;
        public DXCheckBox OnlineOnlyBox;
        public DXButton ObserverButton;

        public GuildRankingLine[] Lines;

        public override WindowType Type => WindowType.GuildRankingBox;
        public override bool CustomSize => false;
        public override bool AutomaticVisiblity => true;
        #endregion

        public ContributionRankingDialog()
        {
            SetClientSize(new Size(510, 240));

            TitleLabel.Text = "公会排行榜";
            
            Panel = new DXControl
            {
                Location = new Point(ClientArea.Location.X + 1, ClientArea.Location.Y),
                Size = new Size(ClientArea.Size.Width - 1, ClientArea.Size.Height),
                Parent = this,
            };

            Lines = new GuildRankingLine[10];
            ScrollBar = new DXVScrollBar
            {
                Parent = Panel,
                Size = new Size(14, Panel.Size.Height - 3 - 21),
                Location = new Point(Panel.Size.Width - 16, 1 +22),
                VisibleSize = Lines.Length,
                Change = 5,
            };
            ScrollBar.ValueChanged += (o, e) => StartIndex = ScrollBar.Value;
            MouseWheel += ScrollBar.DoMouseWheel;

            new GuildRankingLine
            {
                Parent = Panel,
                Header = true,
            };

            for (int i = 0; i < Lines.Length; i++)
            {
                Lines[i] = new GuildRankingLine
                {
                    Parent = Panel,
                    Location = new Point(0, 22* (i +1)),
                    Visible = false,
                };
                Lines[i].MouseWheel += ScrollBar.DoMouseWheel;
            }
        }

        #region Methods

        public override void Process()
        {
            base.Process();

            if (CEnvir.Now < UpdateTime) return;

            UpdateTime = CEnvir.Now.AddSeconds(10);

            CEnvir.Enqueue(new C.GuildRankRequest
            {
                StartIndex = StartIndex,
            });
        }
        public void Update(S.GuildRankings p)
        {

            ScrollBar.MaxValue = p.Total;

            for (int i = 0; i < Lines.Length; i++)
            {
                Lines[i].Loading = false;
                Lines[i].Rank = i >= p.Ranks.Count ? null : p.Ranks[i];
            }
        }
        #endregion

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                _StartIndex = 0;
                StartIndexChanged = null;

                UpdateTime = DateTime.MinValue;

                if (Panel != null)
                {
                    if (!Panel.IsDisposed)
                        Panel.Dispose();

                    Panel = null;
                }

                if (ScrollBar != null)
                {
                    if (!ScrollBar.IsDisposed)
                        ScrollBar.Dispose();

                    ScrollBar = null;
                }


                if (Lines != null)
                {
                    for (int i = 0; i < Lines.Length; i++)
                    {
                        if (Lines[i] != null)
                        {
                            if (!Lines[i].IsDisposed)
                                Lines[i].Dispose();

                            Lines[i] = null;
                        }
                    }

                    Lines = null;
                }


            }

        }

        #endregion
    }

    public sealed class GuildRankingLine : DXControl
    {
        #region Properties

        #region Header

        public bool Header
        {
            get => _Header;
            set
            {
                if (_Header == value) return;

                bool oldValue = _Header;
                _Header = value;

                OnHeaderChanged(oldValue, value);
            }
        }
        private bool _Header;
        public event EventHandler<EventArgs> HeaderChanged;
        public void OnHeaderChanged(bool oValue, bool nValue)
        {
            RankLabel.Text = "排行";
            NameLabel.Text = "公会名";
            HuizhangLabel.Text = "会长";
            LevelLabel.Text = "等级";
            MemberLimitLabel.Text = "成员";
            GuildFundsLabel.Text = "公会经费";

            DrawTexture = false;

            RankLabel.ForeColour = Color.FromArgb(198, 166, 99);
            NameLabel.ForeColour = Color.FromArgb(198, 166, 99);
            HuizhangLabel.ForeColour = Color.FromArgb(198, 166, 99);
            LevelLabel.ForeColour = Color.FromArgb(198, 166, 99);
            MemberLimitLabel.ForeColour = Color.FromArgb(198, 166, 99);
            GuildFundsLabel.ForeColour = Color.FromArgb(198, 166, 99);

            HeaderChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Rank

        public GuildRankInfo Rank
        {
            get => _Rank;
            set
            {
                if (_Rank == value) return;

                GuildRankInfo oldValue = _Rank;
                _Rank = value;

                OnRankChanged(oldValue, value);
            }
        }
        private GuildRankInfo _Rank;
        public event EventHandler<EventArgs> RankChanged;
        public void OnRankChanged(GuildRankInfo oValue, GuildRankInfo nValue)
        {
            if (Rank == null)
            {
                RankLabel.Text = "";
                NameLabel.Text = "";
                HuizhangLabel.Text = "";
                LevelLabel.Text = "";
                MemberLimitLabel.Text = "";
                GuildFundsLabel.Text = "";

                Visible = !Loading;
            }
            else
            {
                Visible = true;
                RankLabel.Text = Rank.Rank.ToString();
                NameLabel.Text = Rank.GuildName;
                MemberLimitLabel.Text = $"{Rank.MembersCount} / {Rank.MemberLimit}";
                HuizhangLabel.Text = Rank.GuildLeaderName;
                GuildFundsLabel.Text = Rank.GuildFunds.ToString("#,##0");


                RankLabel.ForeColour = Color.Silver;
                NameLabel.ForeColour = Color.Silver;
                HuizhangLabel.ForeColour = Color.Silver;
                LevelLabel.ForeColour = Color.Silver;
                MemberLimitLabel.ForeColour = Color.Silver;
                GuildFundsLabel.ForeColour = Color.Silver;


                decimal percent = 0;

                if (Rank.Level < 0) return;

                if (Rank.Level < CartoonGlobals.GonghuiContributionList.Count)
                    percent = Math.Min(1, Math.Max(0, CartoonGlobals.GonghuiContributionList[Rank.Level] > 0 ? Rank.Experience / CartoonGlobals.GonghuiContributionList[Rank.Level] : 0));

                LevelLabel.Text = $"{Rank.Level} - {percent:0.##%}";

            }

            RankChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Loading

        public bool Loading
        {
            get => _Loading;
            set
            {
                if (_Loading == value) return;

                bool oldValue = _Loading;
                _Loading = value;

                OnLoadingChanged(oldValue, value);
            }
        }
        private bool _Loading;
        public event EventHandler<EventArgs> LoadingChanged;
        public void OnLoadingChanged(bool oValue, bool nValue)
        {
            if (!Loading)
            {
                RankLabel.Text = "";
                NameLabel.Text = "";
                HuizhangLabel.Text = "";
                LevelLabel.Text = "";
                MemberLimitLabel.Text = "";
                GuildFundsLabel.Text = "";


                Visible = false;
                return;
            }

            Rank = null;
            NameLabel.Text = "更新...";
            NameLabel.ForeColour = Color.Orange;
            Visible = true;

            LoadingChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        public DXLabel RankLabel, NameLabel, HuizhangLabel, LevelLabel, MemberLimitLabel, GuildFundsLabel;
        public DXButton ObseverButton;
        public DXImageControl OnlineImage;

        #endregion

        public GuildRankingLine()
        {
            Size = new Size(490, 20);
            DrawTexture = true;
            BackColour = Color.FromArgb(25, 20, 0);

            RankLabel = new DXLabel
            {
                Parent = this,
              
                AutoSize = false,
                Location = new Point(0, 0),
                Size = new Size(40, 18),
               
                ForeColour = Color.White,
                DrawFormat = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter,
                IsControl = false,
            };

            NameLabel = new DXLabel
            {
                Parent = this,
                AutoSize = false,
                Location = new Point(RankLabel.Location.X + RankLabel.Size.Width + 1, 0),
                Size = new Size(100, 18),
                ForeColour = Color.White,
                DrawFormat = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter,
                IsControl = false,
            };

            HuizhangLabel = new DXLabel
            {
                Parent = this,
                AutoSize = false,
                Location = new Point(NameLabel.Location.X + NameLabel.Size.Width + 1, 0),
                Size = new Size(100, 18),
                ForeColour = Color.White,
                DrawFormat = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter,
                IsControl = false,
            };

            LevelLabel = new DXLabel
            {
                Parent = this,
                AutoSize = false,
                Location = new Point(HuizhangLabel.Location.X + HuizhangLabel.Size.Width + 1, 0),
                Size = new Size(80, 18),
                ForeColour = Color.White,
                DrawFormat = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter,
                IsControl = false,
            };

            MemberLimitLabel = new DXLabel
            {
                Parent = this,
                AutoSize = false,
                Location = new Point(LevelLabel.Location.X + LevelLabel.Size.Width + 1, 0),
                Size = new Size(70, 18),
                ForeColour = Color.White,
                DrawFormat = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter,
                IsControl = false,
            };

            GuildFundsLabel = new DXLabel
            {
                Parent = this,
                AutoSize = false,
                Location = new Point(MemberLimitLabel.Location.X + MemberLimitLabel.Size.Width + 1, 0),
                Size = new Size(100, 18),
                ForeColour = Color.White,
                DrawFormat = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter,
                IsControl = false,
            };

        }

        #region Methods
        /*
        public override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (GameScene.Game == null || Rank == null) return;

            CEnvir.Enqueue(new C.Inspect { Index = Rank.Index });
        }
        */
        public override void OnMouseEnter()
        {
            base.OnMouseEnter();
            if (Header) return;
            BackColour = Color.FromArgb(80, 80, 125);
        }

        public override void OnMouseLeave()
        {
            base.OnMouseLeave();

            if (Header) return;

            BackColour = Color.FromArgb(25, 20, 0);
        }
        #endregion

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                _Header = false;
                HeaderChanged = null;

                _Rank = null;
                RankChanged = null;

                _Loading = false;
                LoadingChanged = null;

                if (RankLabel != null)
                {
                    if (!RankLabel.IsDisposed)
                        RankLabel.Dispose();

                    RankLabel = null;
                }

                if (NameLabel != null)
                {
                    if (!NameLabel.IsDisposed)
                        NameLabel.Dispose();

                    NameLabel = null;
                }

                if (LevelLabel != null)
                {
                    if (!LevelLabel.IsDisposed)
                        LevelLabel.Dispose();

                    LevelLabel = null;
                }

                if (HuizhangLabel != null)
                {
                    if (!HuizhangLabel.IsDisposed)
                        HuizhangLabel.Dispose();

                    HuizhangLabel = null;
                }

                if (MemberLimitLabel != null)
                {
                    if (!MemberLimitLabel.IsDisposed)
                        MemberLimitLabel.Dispose();

                    MemberLimitLabel = null;
                }

                if (GuildFundsLabel != null)
                {
                    if (!GuildFundsLabel.IsDisposed)
                        GuildFundsLabel.Dispose();

                    GuildFundsLabel = null;
                }

            }

        }

        #endregion
    }

}
