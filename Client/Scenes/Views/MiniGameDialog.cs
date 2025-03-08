using Client.Controls;
using Client.Envir;
using Client.Models;
using Client.UserModels;
using Library;
using Library.Network.ClientPackets;
using Library.SystemModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Client.Scenes.Views
{
	public sealed class MiniGameDialog : DXWindow
	{
		private DXTabControl TabControl;

		public Dictionary<MiniGames, DXTab> GamesTabs = new Dictionary<MiniGames, DXTab>();

		public Dictionary<MiniGames, DXControl> GamesPanels = new Dictionary<MiniGames, DXControl>();

		public Dictionary<MiniGames, DXLabel> GamesLabels = new Dictionary<MiniGames, DXLabel>();

		public Dictionary<MiniGames, bool> GamesActive = new Dictionary<MiniGames, bool>();

		public Dictionary<MiniGameInfo, DXLabel> GamesInfoLevels = new Dictionary<MiniGameInfo, DXLabel>();

		public Dictionary<MiniGameInfo, DXLabel> GamesInfoFee = new Dictionary<MiniGameInfo, DXLabel>();

		public Dictionary<MiniGameInfo, DXLabel> GamesInfoDuration = new Dictionary<MiniGameInfo, DXLabel>();

		public Dictionary<MiniGameInfo, DXButton> GamesInfoButton = new Dictionary<MiniGameInfo, DXButton>();

		public Dictionary<MiniGames, Point> GamesInfoLasTPoint = new Dictionary<MiniGames, Point>();

		public int LevelReq;

		public int Fee;

		public int Duration;

		public int MinPlayers;

		public int Button;

		public int sizeX = 500;

		public int sizeY = 350;

		public int minX;

		public bool hasfreepass = false;

		public override WindowType Type => WindowType.MiniGameBox;

		public override bool CustomSize => false;

		public override bool AutomaticVisiblity => true;

		public MiniGameDialog()
		{
			base.TitleLabel.Text = "迷你游戏(需要一个自由通行证)";
			SetClientSize(new Size(sizeX, sizeY));
			TabControl = new DXTabControl
			{
				Parent = this,
				Location = base.ClientArea.Location,
				Size = base.ClientArea.Size
			};
			LevelReq = 15;
			DXLabel dXLabel = new DXLabel
			{
				BorderColour = Color.FromArgb(198, 166, 99),
				ForeColour = Color.Yellow,
				DrawFormat = (TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter),
				Parent = this,
				Location = new Point(LevelReq, 120),
				Text = "级别要求",
				IsControl = false
			};
			Fee = dXLabel.Size.Width + dXLabel.Location.X + 5;
			dXLabel = new DXLabel
			{
				BorderColour = Color.FromArgb(198, 166, 99),
				ForeColour = Color.Yellow,
				DrawFormat = (TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter),
				Parent = this,
				Location = new Point(Fee, 120),
				Text = "参赛费",
				IsControl = false
			};
			Duration = dXLabel.Size.Width + dXLabel.Location.X + 5;
			dXLabel = new DXLabel
			{
				BorderColour = Color.FromArgb(198, 166, 99),
				ForeColour = Color.Yellow,
				DrawFormat = (TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter),
				Parent = this,
				Location = new Point(Duration, 120),
				Text = "续时间",
				IsControl = false
			};
			MinPlayers = dXLabel.Size.Width + dXLabel.Location.X + 5;
			dXLabel = new DXLabel
			{
				BorderColour = Color.FromArgb(198, 166, 99),
				ForeColour = Color.Yellow,
				DrawFormat = (TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter),
				Parent = this,
				Location = new Point(MinPlayers, 120),
				Text = "最少人数",
				IsControl = false
			};
			Button = dXLabel.Size.Width + dXLabel.Location.X + 5;
			foreach (MiniGames value in Enum.GetValues(typeof(MiniGames)))
			{
				Dictionary<MiniGames, DXTab> gamesTabs = GamesTabs;
				DXTab dXTab = new DXTab();
				dXTab.Parent = TabControl;
				dXTab.Border = true;
				dXTab.TabButton.Label.Text = value.DescriptionToString();
				gamesTabs[value] = dXTab;
				minX += GamesTabs[value].TabButton.Size.Width + 2;
				GamesActive[value] = false;
			}
			SetClientSize(new Size(minX, Size.Height));
			TabControl.Size = new Size(base.ClientArea.Size.Width - 5, base.ClientArea.Size.Height - 5);
			foreach (MiniGames value2 in Enum.GetValues(typeof(MiniGames)))
			{
				GamesTabs[value2].Size = new Size(TabControl.Size.Width - 5, TabControl.Size.Height - 5);
				GamesPanels[value2] = new DXControl
				{
					Parent = GamesTabs[value2],
					Size = new Size(GamesTabs[value2].Size.Width - 10, 45),
					Border = true,
					BorderColour = Color.FromArgb(198, 166, 99),
					Location = new Point(5, 5)
				};
				GamesLabels[value2] = new DXLabel
				{
					AutoSize = false,
					Parent = GamesPanels[value2],
					Location = new Point(5, 5),
					ForeColour = Color.LimeGreen,
					Size = new Size(GamesPanels[value2].Size.Width - 5, 45),
					Text = value2.CategoryToString()
				};
				GamesInfoLasTPoint[value2] = new Point(0, 85);
			}
			foreach (MiniGameInfo mginfo in CartoonGlobals.MiniGameInfoList.Binding)
			{
				GamesInfoLevels[mginfo] = new DXLabel
				{
					Parent = GamesTabs[mginfo.MiniGame],
					Location = new Point(LevelReq - 5, GamesInfoLasTPoint[mginfo.MiniGame].Y),
					ForeColour = Color.White,
					Text = mginfo.MinLevel + "-" + mginfo.MaxLevel
				};
				GamesInfoFee[mginfo] = new DXLabel
				{
					Parent = GamesTabs[mginfo.MiniGame],
					Location = new Point(Fee - 5, GamesInfoLasTPoint[mginfo.MiniGame].Y),
					ForeColour = Color.White,
					Text = mginfo.EntryFee.ToString("#,##0")
				};
				GamesInfoDuration[mginfo] = new DXLabel
				{
					Parent = GamesTabs[mginfo.MiniGame],
					Location = new Point(Duration - 5, GamesInfoLasTPoint[mginfo.MiniGame].Y),
					ForeColour = Color.White,
					Text = mginfo.Duration.ToString()
				};
				GamesInfoDuration[mginfo] = new DXLabel
				{
					Parent = GamesTabs[mginfo.MiniGame],
					Location = new Point(MinPlayers - 5, GamesInfoLasTPoint[mginfo.MiniGame].Y),
					ForeColour = Color.White,
					Text = mginfo.MinPlayers.ToString()
				};
				Dictionary<MiniGameInfo, DXButton> gamesInfoButton = GamesInfoButton;
				MiniGameInfo key = mginfo;
				DXButton dXButton = new DXButton();
				dXButton.Parent = GamesTabs[mginfo.MiniGame];
				dXButton.Label.Text = "开始";
				dXButton.Location = new Point(Button + 15, GamesInfoLasTPoint[mginfo.MiniGame].Y);
				dXButton.ButtonType = ButtonType.SmallButton;
				dXButton.Size = new Size(59, DXControl.SmallButtonHeight);
				dXButton.Enabled = false;
				gamesInfoButton[key] = dXButton;
				GamesInfoButton[mginfo].MouseClick += delegate
				{
					StartGame_Clicked(mginfo);
				};
				GamesInfoLasTPoint[mginfo.MiniGame] = new Point(GamesInfoLasTPoint[mginfo.MiniGame].X, GamesInfoLasTPoint[mginfo.MiniGame].Y + 20);
			}
		}

		public void StartGame_Clicked(MiniGameInfo info)
		{
			if (MapObject.User.Level >= info.MinLevel && MapObject.User.Level <= info.MaxLevel && hasfreepass && !GamesActive[info.MiniGame])
			{
				CEnvir.Enqueue(new StartMiniGame
				{
					index = info.Index
				});
			}
			if (MapObject.User.Level >= info.MinLevel && MapObject.User.Level <= info.MaxLevel && MapObject.User.Gold >= info.EntryFee && GamesActive[info.MiniGame])
			{
				CEnvir.Enqueue(new StartMiniGame
				{
					index = info.Index
				});
			}
		}

		public void UpdateEvents()
		{
			hasfreepass = false;
			foreach (MiniGames value in Enum.GetValues(typeof(MiniGames)))
			{
				GamesActive[value] = false;
			}
			foreach (ClientMiniGames CMG in CEnvir.MiniGamesList)
			{
				if (CMG.StartTime > CEnvir.Now && !CMG.Started)
				{
					MiniGameInfo miniGameInfo = CartoonGlobals.MiniGameInfoList.Binding.FirstOrDefault((MiniGameInfo x) => x.Index == CMG.index);
					GamesActive[miniGameInfo.MiniGame] = true;
				}
			}
			DXItemCell[] grid = GameScene.Game.InventoryBox.Grid.Grid;
			foreach (DXItemCell dXItemCell in grid)
			{
				if (dXItemCell.Item != null && dXItemCell.Item.Info.ItemName == "自由通行证")
				{
					hasfreepass = true;
				}
			}
			foreach (MiniGameInfo item in CartoonGlobals.MiniGameInfoList.Binding)
			{
				GamesInfoButton[item].Enabled = false;
				GamesInfoLevels[item].ForeColour = ((MapObject.User.Level < item.MinLevel || MapObject.User.Level > item.MaxLevel) ? Color.Red : Color.White);
				GamesInfoFee[item].ForeColour = ((MapObject.User.Gold < item.EntryFee) ? Color.Red : Color.White);
				GamesInfoButton[item].Label.Text = "开始";
				if (!GamesActive[item.MiniGame] && MapObject.User.Level >= item.MinLevel && MapObject.User.Level <= item.MaxLevel && hasfreepass)
				{
					GamesInfoButton[item].Enabled = true;
				}
				if (GamesActive[item.MiniGame] && MapObject.User.Level >= item.MinLevel && MapObject.User.Level <= item.MaxLevel && MapObject.User.Gold >= item.EntryFee)
				{
					GamesInfoButton[item].Enabled = true;
					GamesInfoButton[item].Label.Text = "进入";
				}
			}
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (!disposing)
			{
				return;
			}
			foreach (KeyValuePair<MiniGames, DXTab> gamesTab in GamesTabs)
			{
				if (gamesTab.Value != null && !gamesTab.Value.IsDisposed)
				{
					gamesTab.Value.Dispose();
				}
			}
			if (TabControl != null)
			{
				if (!TabControl.IsDisposed)
				{
					TabControl.Dispose();
				}
				TabControl = null;
			}
		}
	}
}
