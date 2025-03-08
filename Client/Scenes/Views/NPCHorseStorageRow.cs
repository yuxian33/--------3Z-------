using Client.Controls;
using Client.Envir;
using Client.Models;
using Library;
using Library.Network.ClientPackets;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client.Scenes.Views
{
	public sealed class NPCHorseStorageRow : DXControl
	{
		private ClientUserHorse _UserHorse;

		private bool _Selected;

		public MonsterObject CompanionDisplay;

		public Point CompanionDisplayPoint;

		public DXButton RetrieveButton;

		public ClientUserHorse UserHorse
		{
			get
			{
				return _UserHorse;
			}
			set
			{
				ClientUserHorse userHorse = _UserHorse;
				_UserHorse = value;
				OnUserCompanionChanged(userHorse, value);
			}
		}

		public bool Selected
		{
			get
			{
				return _Selected;
			}
			set
			{
				if (_Selected != value)
				{
					bool selected = _Selected;
					_Selected = value;
					OnSelectedChanged(selected, value);
				}
			}
		}

		public event EventHandler<EventArgs> UserHorseChanged;

		public event EventHandler<EventArgs> SelectedChanged;

		public void OnUserCompanionChanged(ClientUserHorse oValue, ClientUserHorse nValue)
		{
			UserHorseChanged?.Invoke(this, EventArgs.Empty);
			if (UserHorse == null)
			{
				base.Visible = false;
				return;
			}
			base.Visible = true;
			if (UserHorse.HorseInfo != null)
			{
				CompanionDisplay = new MonsterObject(UserHorse.HorseInfo);
			}
			if (UserHorse.HorseInfo == GameScene.Game.Horse?.HorseInfo)
			{
				Selected = true;
				return;
			}
			Selected = false;
			RetrieveButton.Enabled = true;
			RetrieveButton.Hint = null;
		}

		public void OnSelectedChanged(bool oValue, bool nValue)
		{
			base.Border = Selected;
			base.BackColour = (Selected ? Color.FromArgb(80, 80, 125) : Color.FromArgb(25, 20, 0));
			RetrieveButton.Visible = !Selected;
			SelectedChanged?.Invoke(this, EventArgs.Empty);
		}

		public NPCHorseStorageRow()
		{
			base.DrawTexture = true;
			base.BackColour = Color.FromArgb(25, 20, 0);
			base.BorderColour = Color.FromArgb(144, 144, 144);
			Size = new Size(180, 105);
			CompanionDisplayPoint = new Point(55, 45);
			DXButton dXButton = new DXButton();
			dXButton.Parent = this;
			dXButton.Location = new Point(90, 80);
			dXButton.Size = new Size(80, DXControl.SmallButtonHeight);
			dXButton.ButtonType = ButtonType.SmallButton;
			dXButton.Label.Text = "Retrieve";
			RetrieveButton = dXButton;
			RetrieveButton.MouseClick += RetrieveButton_MouseClick;
		}

		private void RetrieveButton_MouseClick(object sender, MouseEventArgs e)
		{
			CEnvir.Enqueue(new HorseRetrieve
			{
				Index = UserHorse.HorseInfo.Index
			});
		}

		public override void Process()
		{
			base.Process();
			CompanionDisplay?.Process();
		}

		protected override void OnAfterDraw()
		{
			base.OnAfterDraw();
			if (CompanionDisplay != null)
			{
				int num = base.DisplayArea.X + CompanionDisplayPoint.X;
				int num2 = base.DisplayArea.Y + CompanionDisplayPoint.Y;
				if (CompanionDisplay.Image == MonsterImage.Companion_Donkey)
				{
					num += 10;
					num2 -= 5;
				}
				CompanionDisplay.DrawShadow(num, num2);
				CompanionDisplay.DrawBody(num, num2);
			}
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (!disposing)
			{
				return;
			}
			_UserHorse = null;
			UserHorseChanged = null;
			_Selected = false;
			SelectedChanged = null;
			CompanionDisplay = null;
			CompanionDisplayPoint = Point.Empty;
			if (RetrieveButton != null)
			{
				if (!RetrieveButton.IsDisposed)
				{
					RetrieveButton.Dispose();
				}
				RetrieveButton = null;
			}
		}
	}
}
