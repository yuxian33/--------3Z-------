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
    public sealed class GuildGerenDialog : DXWindow
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

        public GuildGerenRankingLine[] Lines;

        public override WindowType Type => WindowType.GuildGerenBox;
        public override bool CustomSize => false;
        public override bool AutomaticVisiblity => true;
        #endregion

        public GuildGerenDialog()
        {
            SetClientSize(new Size(510, 460));

            TitleLabel.Text = "玛法贡献排行榜";

            Panel = new DXControl
            {
                Location = new Point(ClientArea.Location.X + 1, ClientArea.Location.Y),
                Size = new Size(ClientArea.Size.Width - 1, ClientArea.Size.Height),
                Parent = this,
            };

            Lines = new GuildGerenRankingLine[20];
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

            new GuildGerenRankingLine
            {
                Parent = Panel,
                Header = true,
            };

            for (int i = 0; i < Lines.Length; i++)
            {
                Lines[i] = new GuildGerenRankingLine
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

            CEnvir.Enqueue(new C.GuildGerenRankRequest
            {
                StartIndex = StartIndex,
            });
        }
        public void Update(S.GuildGerenRankings p)
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

    public sealed class GuildGerenRankingLine : DXControl
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
            CharacterNameLabel.Text = "名字";
            GuildNameLabel.Text = "公会名";
            ChenghaoLabel.Text = "称号";
            TotalContributionLabel.Text = "总贡献";
            DailyContributionLabel.Text = "每日贡献";

            DrawTexture = false;

            RankLabel.ForeColour = Color.FromArgb(198, 166, 99);
            CharacterNameLabel.ForeColour = Color.FromArgb(198, 166, 99);
            GuildNameLabel.ForeColour = Color.FromArgb(198, 166, 99);
            ChenghaoLabel.ForeColour = Color.FromArgb(198, 166, 99);
            TotalContributionLabel.ForeColour = Color.FromArgb(198, 166, 99);
            DailyContributionLabel.ForeColour = Color.FromArgb(198, 166, 99);

            HeaderChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Rank

        public GuildGerenRankInfo Rank
        {
            get => _Rank;
            set
            {
                if (_Rank == value) return;

                GuildGerenRankInfo oldValue = _Rank;
                _Rank = value;

                OnRankChanged(oldValue, value);
            }
        }
        private GuildGerenRankInfo _Rank;
        public event EventHandler<EventArgs> RankChanged;
        public void OnRankChanged(GuildGerenRankInfo oValue, GuildGerenRankInfo nValue)
        {
            if (Rank == null)
            {
                RankLabel.Text = "";
                CharacterNameLabel.Text = "";
                GuildNameLabel.Text = "";
                ChenghaoLabel.Text = "";
                TotalContributionLabel.Text = "";
                DailyContributionLabel.Text = "";

                Visible = !Loading;
            }
            else
            {
                Visible = true;
                RankLabel.Text = Rank.Rank.ToString();
                CharacterNameLabel.Text = Rank.CharacterName;
                GuildNameLabel.Text = Rank.GuildName.ToString();
                ChenghaoLabel.Text = Rank.Chenghao;
                TotalContributionLabel.Text = Rank.TotalContribution.ToString("#,##0");
                DailyContributionLabel.Text = Rank.DailyContribution.ToString("#,##0");

                RankLabel.ForeColour = Color.Silver;
                CharacterNameLabel.ForeColour = Color.Silver;
                GuildNameLabel.ForeColour = Color.Turquoise;
                ChenghaoLabel.ForeColour = Color.Silver;
                TotalContributionLabel.ForeColour = Color.Silver;
                DailyContributionLabel.ForeColour = Color.Silver;

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
                CharacterNameLabel.Text = "";
                GuildNameLabel.Text = "";
                ChenghaoLabel.Text = "";
                TotalContributionLabel.Text = "";
                DailyContributionLabel.Text = "";


                Visible = false;
                return;
            }

            Rank = null;
            CharacterNameLabel.Text = "更新...";
            CharacterNameLabel.ForeColour = Color.Orange;
            Visible = true;

            LoadingChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        public DXLabel RankLabel, GuildNameLabel, CharacterNameLabel, ChenghaoLabel, TotalContributionLabel, DailyContributionLabel;
        public DXButton ObseverButton;
        public DXImageControl OnlineImage;

        #endregion

        public GuildGerenRankingLine()
        {
            Size = new Size(490, 20);
            DrawTexture = true;
            BackColour = Color.FromArgb(25, 20, 0);

            RankLabel = new DXLabel
            {
                Parent = this,
              
                AutoSize = false,
                Location = new Point(0, 0),
                Size = new Size(30, 18),
               
                ForeColour = Color.White,
                DrawFormat = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter,
                IsControl = false,
            };

            CharacterNameLabel = new DXLabel
            {
                Parent = this,
                AutoSize = false,
                Location = new Point(RankLabel.Location.X + RankLabel.Size.Width + 1, 0),
                Size = new Size(100, 18),
                ForeColour = Color.White,
                DrawFormat = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter,
                IsControl = false,
            };

            GuildNameLabel = new DXLabel
            {
                Parent = this,
                AutoSize = false,
                Location = new Point(CharacterNameLabel.Location.X + CharacterNameLabel.Size.Width + 1, 0),
                Size = new Size(100, 18),
                ForeColour = Color.White,
                DrawFormat = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter,
                IsControl = false,
            };

            ChenghaoLabel = new DXLabel
            {
                Parent = this,
                AutoSize = false,
                Location = new Point(GuildNameLabel.Location.X + GuildNameLabel.Size.Width + 1, 0),
                Size = new Size(50, 18),
                ForeColour = Color.White,
                DrawFormat = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter,
                IsControl = false,
            };

            TotalContributionLabel = new DXLabel
            {
                Parent = this,
                AutoSize = false,
                Location = new Point(ChenghaoLabel.Location.X + ChenghaoLabel.Size.Width + 1, 0),
                Size = new Size(100, 18),
                ForeColour = Color.White,
                DrawFormat = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter,
                IsControl = false,
            };

            DailyContributionLabel = new DXLabel
            {
                Parent = this,
                AutoSize = false,
                Location = new Point(TotalContributionLabel.Location.X + TotalContributionLabel.Size.Width + 1, 0),
                Size = new Size(100, 18),
                ForeColour = Color.White,
                DrawFormat = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter,
                IsControl = false,
            };

        }

        #region Methods
        
        public override void OnMouseClick(MouseEventArgs e)
        {

        }

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

                if (CharacterNameLabel != null)
                {
                    if (!CharacterNameLabel.IsDisposed)
                        CharacterNameLabel.Dispose();

                    CharacterNameLabel = null;
                }

                if (ChenghaoLabel != null)
                {
                    if (!ChenghaoLabel.IsDisposed)
                        ChenghaoLabel.Dispose();

                    ChenghaoLabel = null;
                }

                if (TotalContributionLabel != null)
                {
                    if (!TotalContributionLabel.IsDisposed)
                        TotalContributionLabel.Dispose();

                    TotalContributionLabel = null;
                }

                if (DailyContributionLabel != null)
                {
                    if (!DailyContributionLabel.IsDisposed)
                        DailyContributionLabel.Dispose();

                    DailyContributionLabel = null;
                }

            }

        }

        #endregion
    }

}
