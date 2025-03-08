using Client.Controls;
using Client.UserModels;
using Library;
using System.Collections.Generic;
using System.Drawing;

namespace Client.Scenes.Views
{
	public sealed class NPCHorseStorageDialog : DXWindow
	{
		private DXVScrollBar ScrollBar;

		public NPCHorseStorageRow[] Rows;

		public List<ClientUserHorse> Horses = new List<ClientUserHorse>();

		public override WindowType Type => WindowType.None;

		public override bool CustomSize => false;

		public override bool AutomaticVisiblity => false;

		public NPCHorseStorageDialog()
		{
			base.TitleLabel.Text = "Stable";
			base.Movable = false;
			SetClientSize(new Size(198, 429));
			Rows = new NPCHorseStorageRow[4];
			for (int i = 0; i < Rows.Length; i++)
			{
				Rows[i] = new NPCHorseStorageRow
				{
					Parent = this,
					Location = new Point(base.ClientArea.X, base.ClientArea.Y + i * 108)
				};
			}
			ScrollBar = new DXVScrollBar
			{
				Parent = this,
				Location = new Point(base.ClientArea.Right - 15, base.ClientArea.Y + 1),
				Size = new Size(14, Rows.Length * 107 - 1),
				VisibleSize = Rows.Length,
				Change = 1
			};
			ScrollBar.ValueChanged += delegate
			{
				UpdateScrollBar();
			};
		}

		public void UpdateScrollBar()
		{
			ScrollBar.MaxValue = Horses.Count;
			for (int i = 0; i < Rows.Length; i++)
			{
				Rows[i].UserHorse = ((i + ScrollBar.Value >= Horses.Count) ? null : Horses[i + ScrollBar.Value]);
			}
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (!disposing)
			{
				return;
			}
			Horses.Clear();
			Horses = null;
			if (Rows != null)
			{
				for (int i = 0; i < Rows.Length; i++)
				{
					if (Rows[i] != null)
					{
						if (!Rows[i].IsDisposed)
						{
							Rows[i].Dispose();
						}
						Rows[i] = null;
					}
				}
				Rows = null;
			}
			if (ScrollBar != null)
			{
				if (!ScrollBar.IsDisposed)
				{
					ScrollBar.Dispose();
				}
				ScrollBar = null;
			}
		}
	}
}
