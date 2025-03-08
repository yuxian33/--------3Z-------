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
	public sealed class NPCAdoptHorseDialog : DXWindow
	{
		public MonsterObject HorseDisplay;

		public Point HorseDisplayPoint;

		public DXLabel NameLabel;

		public DXLabel IndexLabel;

		public DXLabel PriceLabel;

		public DXButton LeftButton;

		public DXButton RightButton;

		public DXButton AdoptButton;

		public DXButton UnlockButton;

		public List<HorseInfo> AvailableHorses = new List<HorseInfo>();

		private HorseInfo _SelectedHorseInfo;

		private int _SelectedIndex;

		private bool _AdoptAttempted;

		public HorseInfo SelectedHorseInfo
		{
			get
			{
				return _SelectedHorseInfo;
			}
			set
			{
				if (_SelectedHorseInfo != value)
				{
					HorseInfo selectedHorseInfo = _SelectedHorseInfo;
					_SelectedHorseInfo = value;
					OnSelectedHorseInfoChanged(selectedHorseInfo, value);
				}
			}
		}

		public int SelectedIndex
		{
			get
			{
				return _SelectedIndex;
			}
			set
			{
				int selectedIndex = _SelectedIndex;
				_SelectedIndex = value;
				OnSelectedIndexChanged(selectedIndex, value);
			}
		}

		public bool AdoptAttempted
		{
			get
			{
				return _AdoptAttempted;
			}
			set
			{
				if (_AdoptAttempted != value)
				{
					bool adoptAttempted = _AdoptAttempted;
					_AdoptAttempted = value;
					OnAdoptAttemptedChanged(adoptAttempted, value);
				}
			}
		}

		public bool CanAdopt => GameScene.Game.User != null && SelectedHorseInfo != null && SelectedHorseInfo.Price <= GameScene.Game.User.Gold && !AdoptAttempted && !UnlockButton.Visible;

		public override WindowType Type => WindowType.None;

		public override bool CustomSize => false;

		public override bool AutomaticVisiblity => false;

		public event EventHandler<EventArgs> SelectedHorseInfoChanged;

		public event EventHandler<EventArgs> SelectedIndexChanged;

		public event EventHandler<EventArgs> AdoptAttemptedChanged;

		public void OnSelectedHorseInfoChanged(HorseInfo oValue, HorseInfo nValue)
		{
			HorseDisplay = null;
			if (SelectedHorseInfo?.MonsterInfo != null)
			{
				HorseDisplay = new MonsterObject(SelectedHorseInfo);
				RefreshUnlockButton();
				PriceLabel.Text = SelectedHorseInfo.Price.ToString("#,##0");
				NameLabel.Text = SelectedHorseInfo.MonsterInfo.MonsterName;
				SelectedHorseInfoChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		public void OnSelectedIndexChanged(int oValue, int nValue)
		{
			if (SelectedIndex < CartoonGlobals.HorseInfoList.Count)
			{
				SelectedHorseInfo = CartoonGlobals.HorseInfoList[SelectedIndex];
				IndexLabel.Text = $"{SelectedIndex + 1} of {CartoonGlobals.HorseInfoList.Count}";
				LeftButton.Enabled = (SelectedIndex > 0);
				RightButton.Enabled = (SelectedIndex < CartoonGlobals.HorseInfoList.Count - 1);
				SelectedIndexChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		public void OnAdoptAttemptedChanged(bool oValue, bool nValue)
		{
			RefreshUnlockButton();
			AdoptAttemptedChanged?.Invoke(this, EventArgs.Empty);
		}

		public NPCAdoptHorseDialog()
		{
			base.TitleLabel.Text = "Purchase Horse";
			base.Movable = false;
			SetClientSize(new Size(275, 130));
			HorseDisplayPoint = new Point(55, 95);
			NameLabel = new DXLabel
			{
				Parent = this,
				Font = new Font(Config.FontName, CEnvir.FontSize(10f), FontStyle.Bold),
				Outline = true,
				OutlineColour = Color.Black,
				IsControl = false
			};
			NameLabel.SizeChanged += delegate
			{
				NameLabel.Location = new Point(HorseDisplayPoint.X + 25 - NameLabel.Size.Width / 2, HorseDisplayPoint.Y + 30);
			};
			IndexLabel = new DXLabel
			{
				Parent = this,
				Location = new Point(HorseDisplayPoint.X, 200)
			};
			IndexLabel.SizeChanged += delegate
			{
				IndexLabel.Location = new Point(HorseDisplayPoint.X + 25 - IndexLabel.Size.Width / 2, HorseDisplayPoint.Y + 55);
			};
			LeftButton = new DXButton
			{
				Parent = this,
				LibraryFile = LibraryFile.GameInter,
				Index = 32,
				Location = new Point(HorseDisplayPoint.X - 20, HorseDisplayPoint.Y + 55)
			};
			LeftButton.MouseClick += delegate
			{
				SelectedIndex--;
			};
			RightButton = new DXButton
			{
				Parent = this,
				LibraryFile = LibraryFile.GameInter,
				Index = 37,
				Location = new Point(HorseDisplayPoint.X + 60, HorseDisplayPoint.Y + 55)
			};
			RightButton.MouseClick += delegate
			{
				SelectedIndex++;
			};
			DXLabel dXLabel = new DXLabel
			{
				Parent = this,
				Text = "Price:"
			};
			dXLabel.Location = new Point(210 - dXLabel.Size.Width, HorseDisplayPoint.Y);
			PriceLabel = new DXLabel
			{
				Parent = this,
				Location = new Point(210, HorseDisplayPoint.Y),
				ForeColour = Color.White
			};
			DXButton dXButton = new DXButton();
			dXButton.Parent = this;
			dXButton.Location = new Point(dXLabel.Location.X, PriceLabel.Location.Y + 27);
			dXButton.Size = new Size(80, DXControl.SmallButtonHeight);
			dXButton.ButtonType = ButtonType.SmallButton;
			dXButton.Label.Text = "Purchase";
			AdoptButton = dXButton;
			AdoptButton.MouseClick += AdoptButton_MouseClick;
			DXButton dXButton2 = new DXButton();
			dXButton2.Parent = this;
			dXButton2.Location = new Point(base.ClientArea.Right - 80, base.ClientArea.Y);
			dXButton2.Size = new Size(80, DXControl.SmallButtonHeight);
			dXButton2.ButtonType = ButtonType.SmallButton;
			dXButton2.Label.Text = "Unlock";
			UnlockButton = dXButton2;
			UnlockButton.MouseClick += UnlockButton_MouseClick;
			SelectedIndex = 0;
		}

		private void AdoptButton_MouseClick(object sender, MouseEventArgs e)
		{
			AdoptAttempted = true;
			CEnvir.Enqueue(new HorseAdopt
			{
				Index = SelectedHorseInfo.Index
			});
		}

		private void UnlockButton_MouseClick(object sender, MouseEventArgs e)
		{
			if (GameScene.Game.Inventory.All((ClientUserItem x) => x == null || x.Info.Effect != ItemEffect.HorseTicket))
			{
				GameScene.Game.ReceiveChat("You need a Horse Ticket to unlock a new appearance", MessageType.System);
				return;
			}
			DXMessageBox dXMessageBox = new DXMessageBox("Are you sure you want to use a Horse Ticket?\n\n" + $"This will unlock the {SelectedHorseInfo.MonsterInfo.MonsterName} appearance for new Horses", "Unlock Appearance", DXMessageBoxButtons.YesNo);
			dXMessageBox.YesButton.MouseClick += delegate
			{
				CEnvir.Enqueue(new HorseUnlock
				{
					Index = SelectedHorseInfo.Index
				});
				UnlockButton.Enabled = false;
			};
		}

		public override void Process()
		{
			base.Process();
			HorseDisplay?.Process();
		}

		protected override void OnAfterDraw()
		{
			base.OnAfterDraw();
			if (HorseDisplay != null)
			{
				int x = base.DisplayArea.X + HorseDisplayPoint.X;
				int y = base.DisplayArea.Y + HorseDisplayPoint.Y;
				HorseDisplay.DrawShadow(x, y);
				HorseDisplay.DrawBody(x, y);
			}
		}

		public void RefreshUnlockButton()
		{
			if (SelectedHorseInfo == null) return;
			UnlockButton.Visible = (!SelectedHorseInfo.Available && !AvailableHorses.Contains(SelectedHorseInfo));
			if (GameScene.Game.User == null || SelectedHorseInfo == null || SelectedHorseInfo.Price <= GameScene.Game.User.Gold)
			{
				PriceLabel.ForeColour = Color.FromArgb(144, 144, 144);
			}
			else
			{
				PriceLabel.ForeColour = Color.Red;
			}
			ClientUserHorse clientUserHorse = new ClientUserHorse();
			clientUserHorse.HorseInfo = SelectedHorseInfo;
			clientUserHorse.HorseNum = SelectedHorseInfo.Index;
			bool enabled = true;
			if (!SelectedHorseInfo.Available)
			{
				enabled = AvailableHorses.Contains(SelectedHorseInfo);
			}
			foreach (ClientUserHorse horse in GameScene.Game.NPCHorseStorageBox.Horses)
			{
				if (horse.HorseInfo == clientUserHorse.HorseInfo)
				{
					enabled = false;
					break;
				}
			}
			AdoptButton.Enabled = enabled;
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (!disposing)
			{
				return;
			}
			HorseDisplay = null;
			HorseDisplayPoint = Point.Empty;
			_SelectedHorseInfo = null;
			SelectedHorseInfoChanged = null;
			_SelectedIndex = 0;
			SelectedIndexChanged = null;
			_AdoptAttempted = false;
			AdoptAttemptedChanged = null;
			if (NameLabel != null)
			{
				if (!NameLabel.IsDisposed)
				{
					NameLabel.Dispose();
				}
				NameLabel = null;
			}
			if (IndexLabel != null)
			{
				if (!IndexLabel.IsDisposed)
				{
					IndexLabel.Dispose();
				}
				IndexLabel = null;
			}
			if (PriceLabel != null)
			{
				if (!PriceLabel.IsDisposed)
				{
					PriceLabel.Dispose();
				}
				PriceLabel = null;
			}
			if (LeftButton != null)
			{
				if (!LeftButton.IsDisposed)
				{
					LeftButton.Dispose();
				}
				LeftButton = null;
			}
			if (RightButton != null)
			{
				if (!RightButton.IsDisposed)
				{
					RightButton.Dispose();
				}
				RightButton = null;
			}
			if (AdoptButton != null)
			{
				if (!AdoptButton.IsDisposed)
				{
					AdoptButton.Dispose();
				}
				AdoptButton = null;
			}
			if (UnlockButton != null)
			{
				if (!UnlockButton.IsDisposed)
				{
					UnlockButton.Dispose();
				}
				UnlockButton = null;
			}
		}
	}
}
