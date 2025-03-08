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
	public sealed class CraftDialog : DXWindow
	{
		private DXTabControl TabControl;

		private DXTab SmithingTab;

		private DXTab ClothingTab;

		private DXTab JewelryTab;

		private DXTab ConsumablesTab;

		private DXTab RustedTab;

		public DXComboBox SmithingItemsCBox;

		public DXComboBox ClothingItemsCBox;

		public DXComboBox JewelryItemsCBox;

		public DXComboBox ConsumablesItemsCBox;

		public DXComboBox RustedItemsCBox;

		public DXLabel CraftingIngredientsLabel;

		public DXLabel CraftingExp;

		public DXLabel CraftingSuccess;

		public ClientUserItem[] CraftingItem = new ClientUserItem[1];

		public ClientUserItem[] IngredientItems = new ClientUserItem[4];

		public int index;

		public DXItemGrid TargetItem;

		public DXItemGrid CraftingIngredients;

		public List<CellLinkInfo> links = new List<CellLinkInfo>();

		public DXButton RefineButton;

		public DXLabel CostLabel;

		public Dictionary<CraftType, DXLabel> CraftInfoLevels = new Dictionary<CraftType, DXLabel>();

		public Dictionary<CraftType, DXLabel> CraftInfoExp = new Dictionary<CraftType, DXLabel>();

		public DXLabel CraftLevelLabel;

		public DXLabel CraftExpLabel;

		public override WindowType Type => WindowType.CraftBox;

		public override bool CustomSize => false;

		public override bool AutomaticVisiblity => true;

		public CraftDialog()
		{
			base.TitleLabel.Text = "制造系统";
			SetClientSize(new Size(305, 350));
			TabControl = new DXTabControl
			{
				Parent = this,
				Location = base.ClientArea.Location,
				Size = base.ClientArea.Size
			};
			DXTab dXTab = new DXTab();
			dXTab.Parent = TabControl;
			dXTab.Border = true;
			dXTab.TabButton.Label.Text = "锻造";
			SmithingTab = dXTab;
			SmithingTab.SelectedChanged += Tab_SelectedChanged;
			DXTab dXTab2 = new DXTab();
			dXTab2.Parent = TabControl;
			dXTab2.Border = true;
			dXTab2.TabButton.Label.Text = "军械";
			ClothingTab = dXTab2;
			ClothingTab.SelectedChanged += Tab_SelectedChanged;
			DXTab dXTab3 = new DXTab();
			dXTab3.Parent = TabControl;
			dXTab3.Border = true;
			dXTab3.TabButton.Label.Text = "宝石";
			JewelryTab = dXTab3;
			JewelryTab.SelectedChanged += Tab_SelectedChanged;
			DXTab dXTab4 = new DXTab();
			dXTab4.Parent = TabControl;
			dXTab4.Border = true;
			dXTab4.TabButton.Label.Text = "药水";
			ConsumablesTab = dXTab4;
			ConsumablesTab.SelectedChanged += Tab_SelectedChanged;
			DXTab dXTab5 = new DXTab();
			dXTab5.Parent = TabControl;
			dXTab5.Border = true;
			dXTab5.TabButton.Label.Text = "生锈";
			RustedTab = dXTab5;
			RustedTab.SelectedChanged += Tab_SelectedChanged;
			DXControl dXControl = new DXControl
			{
				Parent = TabControl,
				Size = new Size(base.ClientArea.Size.Width - 20, base.ClientArea.Size.Height - 110),
				Location = new Point(10, 100),
				Border = true,
				BorderColour = Color.FromArgb(198, 166, 99),
            };
			CraftingSuccess = new DXLabel
			{
				Parent = dXControl,
				Location = new Point(5, 5),
				Text = "成功率: ",
				Visible = false
			};
			CraftingExp = new DXLabel
			{
				Parent = dXControl,
				Location = new Point(CraftingSuccess.Location.X, CraftingSuccess.Location.Y + CraftingSuccess.Size.Height + 5),
				Text = "锻造经验获得: ",
				Visible = false
			};
			TargetItem = new DXItemGrid
			{
				GridSize = new Size(1, 1),
				Location = new Point(CraftingSuccess.Location.X, CraftingExp.Location.Y + CraftingExp.Size.Height + 5),
				Parent = dXControl,
				Border = true,
				Linked = false,
				GridType = GridType.CraftItem,
				ItemGrid = CraftingItem,
				Visible = false,
				ReadOnly = true
			};
			CraftingIngredientsLabel = new DXLabel
			{
				Parent = dXControl,
				Location = new Point(TargetItem.Location.X, TargetItem.Location.Y + TargetItem.Size.Height + 5),
				Text = "原材料",
				Visible = false
			};
			CraftingIngredients = new DXItemGrid
			{
				GridSize = new Size(4, 1),
				Location = new Point(CraftingIngredientsLabel.Location.X, CraftingIngredientsLabel.Location.Y + CraftingIngredientsLabel.Size.Height + 5),
				Parent = dXControl,
				Border = true,
				Linked = false,
				GridType = GridType.CraftIngredients,
				ItemGrid = IngredientItems,
				Visible = false,
				ReadOnly = true
			};
			DXLabel dXLabel = new DXLabel
			{
				AutoSize = false,
				Border = true,
				BorderColour = Color.FromArgb(198, 166, 99),
				ForeColour = Color.White,
				DrawFormat = (TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter),
				Parent = dXControl,
				Location = new Point(5, dXControl.Size.Height - 50),
				Text = "制作成本:",
				Size = new Size(79, 20),
				IsControl = false
			};
			CostLabel = new DXLabel
			{
				AutoSize = false,
				Border = true,
				BorderColour = Color.FromArgb(198, 166, 99),
                ForeColour = Color.White,
				DrawFormat = TextFormatFlags.VerticalCenter,
				Parent = dXControl,
				Location = new Point(dXLabel.Location.X + dXLabel.Size.Width, dXLabel.Location.Y),
				Text = "0",
				Size = new Size(dXControl.Size.Width - 90, 20),
				Sound = SoundIndex.GoldPickUp
			};
			DXButton dXButton = new DXButton();
			dXButton.Label.Text = "开始锻造";
			dXButton.Location = new Point(dXControl.Size.Width - 85, CostLabel.Location.Y + CostLabel.Size.Height + 5);
			dXButton.ButtonType = ButtonType.SmallButton;
			dXButton.Parent = dXControl;
			dXButton.Size = new Size(79, DXControl.SmallButtonHeight);
			dXButton.Enabled = false;
			RefineButton = dXButton;
			RefineButton.MouseClick += delegate
			{
				RefineButton_Clicked();
			};
			DXControl parent = new DXControl
			{
				Parent = SmithingTab,
				Size = new Size(base.ClientArea.Size.Width - 20, 55),
				Location = new Point(10, 10),
				Border = true,
				BorderColour = Color.FromArgb(198, 166, 99),
            };
			dXLabel = new DXLabel
			{
				Parent = parent,
				Text = "锻造等级:"
			};
			dXLabel.Location = new Point(5, 5);
			CraftInfoLevels[CraftType.Smithing] = new DXLabel
			{
				Parent = parent,
				Location = new Point(dXLabel.Location.X + dXLabel.Size.Width, dXLabel.Location.Y),
				ForeColour = Color.White,
				Text = "0"
			};
			dXLabel = new DXLabel
			{
				Parent = parent,
				Text = "锻造经验:"
			};
			dXLabel.Location = new Point(80, 5);
			CraftInfoExp[CraftType.Smithing] = new DXLabel
			{
				Parent = parent,
				Location = new Point(dXLabel.Location.X + dXLabel.Size.Width, dXLabel.Location.Y),
				ForeColour = Color.White,
				Text = "0"
			};
			dXLabel = new DXLabel
			{
				Parent = parent,
				Text = "物品:"
			};
			dXLabel.Location = new Point(5, 30);
			SmithingItemsCBox = new DXComboBox
			{
				Parent = parent,
				Location = new Point(dXLabel.Location.X + dXLabel.Size.Width + 5, dXLabel.Location.Y),
				Size = new Size(150, 16),
				DropDownHeight = 198
			};
			SmithingItemsCBox.SelectedItemChanged += SmithingItemsCBox_Changed;
			DXListBoxItem dXListBoxItem = new DXListBoxItem();
			dXListBoxItem.Parent = SmithingItemsCBox.ListBox;
			dXListBoxItem.Label.Text = "选择...";
			dXListBoxItem.Item = null;
			DXControl parent2 = new DXControl
			{
				Parent = ClothingTab,
				Size = new Size(base.ClientArea.Size.Width - 20, 55),
				Location = new Point(10, 10),
				Border = true,
				BorderColour = Color.FromArgb(198, 166, 99),
            };
			dXLabel = new DXLabel
			{
				Parent = parent2,
				Text = "锻造等级:"
			};
			dXLabel.Location = new Point(5, 5);
			CraftInfoLevels[CraftType.Clothing] = new DXLabel
			{
				Parent = parent2,
				Location = new Point(dXLabel.Location.X + dXLabel.Size.Width, dXLabel.Location.Y),
				ForeColour = Color.White,
				Text = "0"
			};
			dXLabel = new DXLabel
			{
				Parent = parent2,
				Text = "锻造经验:"
			};
			dXLabel.Location = new Point(80, 5);
			CraftInfoExp[CraftType.Clothing] = new DXLabel
			{
				Parent = parent2,
				Location = new Point(dXLabel.Location.X + dXLabel.Size.Width, dXLabel.Location.Y),
				ForeColour = Color.White,
				Text = "0"
			};
			dXLabel = new DXLabel
			{
				Parent = parent2,
				Location = new Point(5, 30),
				Text = "物品:"
			};
			ClothingItemsCBox = new DXComboBox
			{
				Parent = parent2,
				Location = new Point(dXLabel.Location.X + dXLabel.Size.Width + 5, dXLabel.Location.Y),
				Size = new Size(150, 16),
				DropDownHeight = 198
			};
			ClothingItemsCBox.SelectedItemChanged += ClothingItemsCBox_Changed;
			DXListBoxItem dXListBoxItem2 = new DXListBoxItem();
			dXListBoxItem2.Parent = ClothingItemsCBox.ListBox;
			dXListBoxItem2.Label.Text = "选择...";
			dXListBoxItem2.Item = null;
			DXControl parent3 = new DXControl
			{
				Parent = JewelryTab,
				Size = new Size(base.ClientArea.Size.Width - 20, 55),
				Location = new Point(10, 10),
				Border = true,
				BorderColour = Color.FromArgb(198, 166, 99),
            };
			dXLabel = new DXLabel
			{
				Parent = parent3,
				Text = "锻造等级:"
			};
			dXLabel.Location = new Point(5, 5);
			CraftInfoLevels[CraftType.Jewelry] = new DXLabel
			{
				Parent = parent3,
				Location = new Point(dXLabel.Location.X + dXLabel.Size.Width, dXLabel.Location.Y),
				ForeColour = Color.White,
				Text = "0"
			};
			dXLabel = new DXLabel
			{
				Parent = parent3,
				Text = "锻造经验:"
			};
			dXLabel.Location = new Point(80, 5);
			CraftInfoExp[CraftType.Jewelry] = new DXLabel
			{
				Parent = parent3,
				Location = new Point(dXLabel.Location.X + dXLabel.Size.Width, dXLabel.Location.Y),
				ForeColour = Color.White,
				Text = "0"
			};
			dXLabel = new DXLabel
			{
				Parent = parent3,
				Location = new Point(5, 30),
				Text = "物品:"
			};
			JewelryItemsCBox = new DXComboBox
			{
				Parent = parent3,
				Location = new Point(dXLabel.Location.X + dXLabel.Size.Width + 5, dXLabel.Location.Y),
				Size = new Size(150, 16),
				DropDownHeight = 198
			};
			JewelryItemsCBox.SelectedItemChanged += JewelryItemsCBox_SelectedItemChanged;
			DXListBoxItem dXListBoxItem3 = new DXListBoxItem();
			dXListBoxItem3.Parent = JewelryItemsCBox.ListBox;
			dXListBoxItem3.Label.Text = "选择...";
			dXListBoxItem3.Item = null;
			DXControl parent4 = new DXControl
			{
				Parent = ConsumablesTab,
				Size = new Size(base.ClientArea.Size.Width - 20, 55),
				Location = new Point(10, 10),
				Border = true,
				BorderColour = Color.FromArgb(198, 166, 99),
            };
			dXLabel = new DXLabel
			{
				Parent = parent4,
				Text = "锻造等级:"
			};
			dXLabel.Location = new Point(5, 5);
			CraftInfoLevels[CraftType.Consumables] = new DXLabel
			{
				Parent = parent4,
				Location = new Point(dXLabel.Location.X + dXLabel.Size.Width, dXLabel.Location.Y),
				ForeColour = Color.White,
				Text = "0"
			};
			dXLabel = new DXLabel
			{
				Parent = parent4,
				Text = "锻造经验:"
			};
			dXLabel.Location = new Point(80, 5);
			CraftInfoExp[CraftType.Consumables] = new DXLabel
			{
				Parent = parent4,
				Location = new Point(dXLabel.Location.X + dXLabel.Size.Width, dXLabel.Location.Y),
				ForeColour = Color.White,
				Text = "0"
			};
			dXLabel = new DXLabel
			{
				Parent = parent4,
				Location = new Point(5, 30),
				Text = "物品:"
			};
			ConsumablesItemsCBox = new DXComboBox
			{
				Parent = parent4,
				Location = new Point(dXLabel.Location.X + dXLabel.Size.Width + 5, dXLabel.Location.Y),
				Size = new Size(150, 16),
				DropDownHeight = 198
			};
			ConsumablesItemsCBox.SelectedItemChanged += ConsumablesItemsCBox_SelectedItemChanged;
			DXListBoxItem dXListBoxItem4 = new DXListBoxItem();
			dXListBoxItem4.Parent = ConsumablesItemsCBox.ListBox;
			dXListBoxItem4.Label.Text = "选择...";
			dXListBoxItem4.Item = null;
			DXControl parent5 = new DXControl
			{
				Parent = RustedTab,
				Size = new Size(base.ClientArea.Size.Width - 20, 55),
				Location = new Point(10, 10),
				Border = true,
				BorderColour = Color.FromArgb(198, 166, 99),
            };
			dXLabel = new DXLabel
			{
				Parent = parent5,
				Text = "锻造等级:"
			};
			dXLabel.Location = new Point(5, 5);
			CraftInfoLevels[CraftType.Rusted] = new DXLabel
			{
				Parent = parent5,
				Location = new Point(dXLabel.Location.X + dXLabel.Size.Width, dXLabel.Location.Y),
				ForeColour = Color.White,
				Text = "0"
			};
			dXLabel = new DXLabel
			{
				Parent = parent5,
				Text = "锻造经验:"
			};
			dXLabel.Location = new Point(80, 5);
			CraftInfoExp[CraftType.Rusted] = new DXLabel
			{
				Parent = parent5,
				Location = new Point(dXLabel.Location.X + dXLabel.Size.Width, dXLabel.Location.Y),
				ForeColour = Color.White,
				Text = "0"
			};
			dXLabel = new DXLabel
			{
				Parent = parent5,
				Location = new Point(5, 30),
				Text = "物品:"
			};
			RustedItemsCBox = new DXComboBox
			{
				Parent = parent5,
				Location = new Point(dXLabel.Location.X + dXLabel.Size.Width + 5, dXLabel.Location.Y),
				Size = new Size(150, 16),
				DropDownHeight = 198
			};
			RustedItemsCBox.SelectedItemChanged += RustedItemsCBox_SelectedItemChanged;
			DXListBoxItem dXListBoxItem5 = new DXListBoxItem();
			dXListBoxItem5.Parent = RustedItemsCBox.ListBox;
			dXListBoxItem5.Label.Text = "选择...";
			dXListBoxItem5.Item = null;
		}

		private void SetComboBoxes()
		{
			int level = MapObject.User.CraftInfo.FirstOrDefault((ClientUserCrafting x) => x.Type == CraftType.Smithing).Level;
			int level2 = MapObject.User.CraftInfo.FirstOrDefault((ClientUserCrafting x) => x.Type == CraftType.Clothing).Level;
			int level3 = MapObject.User.CraftInfo.FirstOrDefault((ClientUserCrafting x) => x.Type == CraftType.Jewelry).Level;
			int level4 = MapObject.User.CraftInfo.FirstOrDefault((ClientUserCrafting x) => x.Type == CraftType.Consumables).Level;
			int level5 = MapObject.User.CraftInfo.FirstOrDefault((ClientUserCrafting x) => x.Type == CraftType.Rusted).Level;
			foreach (CraftItemInfo item in CartoonGlobals.CraftingItemInfoList.Binding)
			{
				Label label = new Label();
				label.AutoSize = true;
				label.Text = item.Item.ItemName;
				DXListBoxItem dXListBoxItem = new DXListBoxItem();
				if (item.Type == CraftType.Smithing && item.Level <= level)
				{
					bool flag = true;
					foreach (DXControl control in SmithingItemsCBox.ListBox.Controls)
					{
						DXListBoxItem dXListBoxItem2 = control as DXListBoxItem;
						if (dXListBoxItem2 != null && dXListBoxItem2.Item != null && (int)dXListBoxItem2.Item == item.Index)
						{
							flag = false;
						}
					}
					if (flag)
					{
						DXListBoxItem dXListBoxItem3 = new DXListBoxItem();
						dXListBoxItem3.Parent = SmithingItemsCBox.ListBox;
						dXListBoxItem3.Label.Text = item.Item.ItemName;
						dXListBoxItem3.Item = item.Index;
						dXListBoxItem = dXListBoxItem3;
					}
				}
				if (item.Type == CraftType.Clothing && item.Level <= level2)
				{
					bool flag2 = true;
					foreach (DXControl control2 in ClothingItemsCBox.ListBox.Controls)
					{
						DXListBoxItem dXListBoxItem4 = control2 as DXListBoxItem;
						if (dXListBoxItem4 != null && dXListBoxItem4.Item != null && (int)dXListBoxItem4.Item == item.Index)
						{
							flag2 = false;
						}
					}
					if (flag2)
					{
						DXListBoxItem dXListBoxItem5 = new DXListBoxItem();
						dXListBoxItem5.Parent = ClothingItemsCBox.ListBox;
						dXListBoxItem5.Label.Text = item.Item.ItemName;
						dXListBoxItem5.Item = item.Index;
						dXListBoxItem = dXListBoxItem5;
					}
				}
				if (item.Type == CraftType.Jewelry && item.Level <= level3)
				{
					bool flag3 = true;
					foreach (DXControl control3 in JewelryItemsCBox.ListBox.Controls)
					{
						DXListBoxItem dXListBoxItem6 = control3 as DXListBoxItem;
						if (dXListBoxItem6 != null && dXListBoxItem6.Item != null && (int)dXListBoxItem6.Item == item.Index)
						{
							flag3 = false;
						}
					}
					if (flag3)
					{
						DXListBoxItem dXListBoxItem7 = new DXListBoxItem();
						dXListBoxItem7.Parent = JewelryItemsCBox.ListBox;
						dXListBoxItem7.Label.Text = item.Item.ItemName;
						dXListBoxItem7.Item = item.Index;
						dXListBoxItem = dXListBoxItem7;
					}
				}
				if (item.Type == CraftType.Consumables && item.Level <= level4)
				{
					bool flag4 = true;
					foreach (DXControl control4 in ConsumablesItemsCBox.ListBox.Controls)
					{
						DXListBoxItem dXListBoxItem8 = control4 as DXListBoxItem;
						if (dXListBoxItem8 != null && dXListBoxItem8.Item != null && (int)dXListBoxItem8.Item == item.Index)
						{
							flag4 = false;
						}
					}
					if (flag4)
					{
						DXListBoxItem dXListBoxItem9 = new DXListBoxItem();
						dXListBoxItem9.Parent = ConsumablesItemsCBox.ListBox;
						dXListBoxItem9.Label.Text = item.Item.ItemName;
						dXListBoxItem9.Item = item.Index;
						dXListBoxItem = dXListBoxItem9;
					}
				}
				if (item.Type == CraftType.Rusted && item.Level <= level5)
				{
					bool flag5 = true;
					foreach (DXControl control5 in RustedItemsCBox.ListBox.Controls)
					{
						DXListBoxItem dXListBoxItem10 = control5 as DXListBoxItem;
						if (dXListBoxItem10 != null && dXListBoxItem10.Item != null && (int)dXListBoxItem10.Item == item.Index)
						{
							flag5 = false;
						}
					}
					if (flag5)
					{
						DXListBoxItem dXListBoxItem11 = new DXListBoxItem();
						dXListBoxItem11.Parent = RustedItemsCBox.ListBox;
						dXListBoxItem11.Label.Text = item.Item.ItemName;
						dXListBoxItem11.Item = item.Index;
						dXListBoxItem = dXListBoxItem11;
					}
				}
			}
		}

		private void Tab_SelectedChanged(object sender, EventArgs e)
		{
			SmithingItemsCBox.SelectedItem = null;
			SmithingItemsCBox.SelectedLabel.Text = "选择...";
			SmithingItemsCBox.ListBox.SelectedItem = null;
			JewelryItemsCBox.SelectedItem = null;
			JewelryItemsCBox.SelectedLabel.Text = "选择...";
			JewelryItemsCBox.ListBox.SelectedItem = null;
			ConsumablesItemsCBox.SelectedItem = null;
			ConsumablesItemsCBox.SelectedLabel.Text = "选择...";
			ConsumablesItemsCBox.ListBox.SelectedItem = null;
			ClothingItemsCBox.SelectedItem = null;
			ClothingItemsCBox.SelectedLabel.Text = "选择...";
			ClothingItemsCBox.ListBox.SelectedItem = null;
			RustedItemsCBox.SelectedItem = null;
			RustedItemsCBox.SelectedLabel.Text = "选择...";
			RustedItemsCBox.ListBox.SelectedItem = null;
			CostLabel.ForeColour = Color.White;
			CostLabel.Text = "0";
		}

		private void RefineButton_Clicked()
		{
			CraftItemInfo craftItemInfo = CartoonGlobals.CraftingItemInfoList.Binding.FirstOrDefault((CraftItemInfo x) => x.Index == index);
			int num = 0;
			if (craftItemInfo.Ingredient1 != null)
			{
				num++;
			}
			if (craftItemInfo.Ingredient2 != null)
			{
				num++;
			}
			if (craftItemInfo.Ingredient3 != null)
			{
				num++;
			}
			if (craftItemInfo.Ingredient4 != null)
			{
				num++;
			}
			int num2 = 0;
			foreach (CellLinkInfo link in links)
			{
				ClientUserItem item = GameScene.Game.InventoryBox.Grid.Grid[link.Slot].Item;
				ClientUserItem clientUserItem = new ClientUserItem();
				if ((item.Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable)
				{
					return;
				}
				switch (num2)
				{
				case 0:
					clientUserItem = new ClientUserItem(craftItemInfo.Ingredient1, craftItemInfo.Ingredient1Amount);
					break;
				case 1:
					clientUserItem = new ClientUserItem(craftItemInfo.Ingredient2, craftItemInfo.Ingredient2Amount);
					break;
				case 2:
					clientUserItem = new ClientUserItem(craftItemInfo.Ingredient3, craftItemInfo.Ingredient3Amount);
					break;
				case 3:
					clientUserItem = new ClientUserItem(craftItemInfo.Ingredient4, craftItemInfo.Ingredient4Amount);
					break;
				}
				if (item.Info.ItemName == clientUserItem.Info.ItemName && item.Count >= clientUserItem.Count)
				{
					num2++;
				}
			}
			int cost = craftItemInfo.Cost;
			if (num2 == num && cost <= MapObject.User.Gold)
			{
				CEnvir.Enqueue(new CraftItem
				{
					Index = index,
					Ingredients = links
				});
			}
		}

		private void ResetInventory()
		{
			DXItemCell[] grid = GameScene.Game.InventoryBox.Grid.Grid;
			foreach (DXItemCell dXItemCell in grid)
			{
				if (dXItemCell.Item != null)
				{
					dXItemCell.Link = null;
				}
			}
		}

		private void SmithingItemsCBox_Changed(object sender, EventArgs e)
		{
			ResetInventory();
			if (SmithingItemsCBox.SelectedItem == null)
			{
				CraftingIngredientsLabel.Visible = false;
				CraftingExp.Visible = false;
				CraftingSuccess.Visible = false;
				TargetItem.Visible = false;
				CraftingIngredients.Visible = false;
			}
			else
			{
				index = (int)SmithingItemsCBox.SelectedItem;
				updateCrafting();
			}
		}

		private void ClothingItemsCBox_Changed(object sender, EventArgs e)
		{
			ResetInventory();
			if (ClothingItemsCBox.SelectedItem == null)
			{
				CraftingIngredientsLabel.Visible = false;
				CraftingExp.Visible = false;
				CraftingSuccess.Visible = false;
				TargetItem.Visible = false;
				CraftingIngredients.Visible = false;
			}
			else
			{
				index = (int)ClothingItemsCBox.SelectedItem;
				updateCrafting();
			}
		}

		private void JewelryItemsCBox_SelectedItemChanged(object sender, EventArgs e)
		{
			ResetInventory();
			if (JewelryItemsCBox.SelectedItem == null)
			{
				CraftingIngredientsLabel.Visible = false;
				CraftingExp.Visible = false;
				CraftingSuccess.Visible = false;
				TargetItem.Visible = false;
				CraftingIngredients.Visible = false;
			}
			else
			{
				index = (int)JewelryItemsCBox.SelectedItem;
				updateCrafting();
			}
		}

		private void ConsumablesItemsCBox_SelectedItemChanged(object sender, EventArgs e)
		{
			ResetInventory();
			if (ConsumablesItemsCBox.SelectedItem == null)
			{
				CraftingIngredientsLabel.Visible = false;
				CraftingExp.Visible = false;
				CraftingSuccess.Visible = false;
				TargetItem.Visible = false;
				CraftingIngredients.Visible = false;
			}
			else
			{
				index = (int)ConsumablesItemsCBox.SelectedItem;
				updateCrafting();
			}
		}

		private void RustedItemsCBox_SelectedItemChanged(object sender, EventArgs e)
		{
			ResetInventory();
			if (RustedItemsCBox.SelectedItem == null)
			{
				CraftingIngredientsLabel.Visible = false;
				CraftingExp.Visible = false;
				CraftingSuccess.Visible = false;
				TargetItem.Visible = false;
				CraftingIngredients.Visible = false;
			}
			else
			{
				index = (int)RustedItemsCBox.SelectedItem;
				updateCrafting();
			}
		}

		public void updateCrafting()
		{
			RefineButton.Enabled = false;
			links.Clear();
			CraftingIngredientsLabel.Visible = true;
			CraftingExp.Visible = true;
			CraftingSuccess.Visible = true;
			CraftItemInfo CraftItem = CartoonGlobals.CraftingItemInfoList.Binding.FirstOrDefault((CraftItemInfo x) => x.Index == index);
			TargetItem.Visible = true;
			CraftingItem[0] = new ClientUserItem(CraftItem.Item, CraftItem.Amount);
			TargetItem.Grid[0].RefreshItem();
			CraftingIngredients.Visible = true;
			int num = 0;
			if (CraftItem.Ingredient1 != null)
			{
				num++;
			}
			if (CraftItem.Ingredient2 != null)
			{
				num++;
			}
			if (CraftItem.Ingredient3 != null)
			{
				num++;
			}
			if (CraftItem.Ingredient4 != null)
			{
				num++;
			}
			CraftingIngredients.GridSize = new Size(num, 1);
			int num2 = 0;
			int num3 = 0;
			DXItemCell[] grid = CraftingIngredients.Grid;
			foreach (DXItemCell dXItemCell in grid)
			{
				switch (num2)
				{
				case 0:
					dXItemCell.Item = new ClientUserItem(CraftItem.Ingredient1, CraftItem.Ingredient1Amount);
					break;
				case 1:
					dXItemCell.Item = new ClientUserItem(CraftItem.Ingredient2, CraftItem.Ingredient2Amount);
					break;
				case 2:
					dXItemCell.Item = new ClientUserItem(CraftItem.Ingredient3, CraftItem.Ingredient3Amount);
					break;
				case 3:
					dXItemCell.Item = new ClientUserItem(CraftItem.Ingredient4, CraftItem.Ingredient4Amount);
					break;
				}
				num2++;
				dXItemCell.Item.CraftInfoOnly = true;
				DXItemCell[] grid2 = GameScene.Game.InventoryBox.Grid.Grid;
				foreach (DXItemCell dXItemCell2 in grid2)
				{
					if (dXItemCell2.Item != null)
					{
						bool flag = false;
						foreach (CellLinkInfo link in links)
						{
							if (dXItemCell2.Slot == link.Slot)
							{
								flag = true;
							}
						}
						if (!flag && (dXItemCell2.Item.Flags & UserItemFlags.NonRefinable) != UserItemFlags.NonRefinable && dXItemCell2.Item.Info.ItemName == dXItemCell.Item.Info.ItemName && dXItemCell2.Item.Count >= dXItemCell.Item.Count)
						{
							dXItemCell2.Link = dXItemCell;
							num3++;
							links.Add(new CellLinkInfo
							{
								Count = dXItemCell.Item.Count,
								GridType = dXItemCell.Link.GridType,
								Slot = dXItemCell.Link.Slot
							});
							break;
						}
					}
				}
			}
			int cost = CraftItem.Cost;
			CostLabel.ForeColour = ((cost >= MapObject.User.Gold) ? Color.Red : Color.White);
			CostLabel.Text = cost.ToString("#,##0");
			int num4 = Math.Min(100, CraftItem.Chance + 5 * (MapObject.User.CraftInfo.FirstOrDefault((ClientUserCrafting x) => x.Type == CraftItem.Type).Level - CraftItem.Level));
			CraftingSuccess.Text = "成功率: " + num4 + "%";
			CraftingExp.Text = "锻造经验: " + CraftItem.Exp;
			if (num3 == num && cost <= MapObject.User.Gold)
			{
				RefineButton.Enabled = true;
			}
		}

		public void UpdateStats()
		{
			foreach (KeyValuePair<CraftType, DXLabel> pair in CraftInfoLevels)
			{
				pair.Value.Text = $"{MapObject.User.CraftInfo.FirstOrDefault((ClientUserCrafting x) => x.Type == pair.Key).Level}";
			}
			foreach (KeyValuePair<CraftType, DXLabel> pair2 in CraftInfoExp)
			{
				int exp = MapObject.User.CraftInfo.FirstOrDefault((ClientUserCrafting x) => x.Type == pair2.Key).Exp;
				int exp2 = CartoonGlobals.CraftingLevelsInfoList.Binding.FirstOrDefault((CraftLevelInfo x) => x.Type == pair2.Key && x.Level == Convert.ToInt32(CraftInfoLevels[pair2.Key].Text)).Exp;
				pair2.Value.Text = string.Format("{0}", exp + "/" + exp2);
			}
			SetComboBoxes();
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (!disposing)
			{
				return;
			}
			if (SmithingItemsCBox != null)
			{
				if (!SmithingItemsCBox.IsDisposed)
				{
					SmithingItemsCBox.Dispose();
				}
				SmithingItemsCBox = null;
			}
			if (ClothingItemsCBox != null)
			{
				if (!ClothingItemsCBox.IsDisposed)
				{
					ClothingItemsCBox.Dispose();
				}
				ClothingItemsCBox = null;
			}
			if (JewelryItemsCBox != null)
			{
				if (!JewelryItemsCBox.IsDisposed)
				{
					JewelryItemsCBox.Dispose();
				}
				JewelryItemsCBox = null;
			}
			if (ConsumablesItemsCBox != null)
			{
				if (!ConsumablesItemsCBox.IsDisposed)
				{
					ConsumablesItemsCBox.Dispose();
				}
				ConsumablesItemsCBox = null;
			}
			if (SmithingTab != null)
			{
				if (!SmithingTab.IsDisposed)
				{
					SmithingTab.Dispose();
				}
				SmithingTab = null;
			}
			if (ConsumablesTab != null)
			{
				if (!ConsumablesTab.IsDisposed)
				{
					ConsumablesTab.Dispose();
				}
				ConsumablesTab = null;
			}
			if (JewelryTab != null)
			{
				if (!JewelryTab.IsDisposed)
				{
					JewelryTab.Dispose();
				}
				JewelryTab = null;
			}
			if (ConsumablesTab != null)
			{
				if (!ConsumablesTab.IsDisposed)
				{
					ConsumablesTab.Dispose();
				}
				ConsumablesTab = null;
			}
			if (TabControl != null)
			{
				if (!TabControl.IsDisposed)
				{
					TabControl.Dispose();
				}
				TabControl = null;
			}
			foreach (KeyValuePair<CraftType, DXLabel> craftInfoLevel in CraftInfoLevels)
			{
				if (craftInfoLevel.Value != null && !craftInfoLevel.Value.IsDisposed)
				{
					craftInfoLevel.Value.Dispose();
				}
			}
			foreach (KeyValuePair<CraftType, DXLabel> item in CraftInfoExp)
			{
				if (item.Value != null && !item.Value.IsDisposed)
				{
					item.Value.Dispose();
				}
			}
		}
	}
}
