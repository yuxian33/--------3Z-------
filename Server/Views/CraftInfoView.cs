using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Library.SystemModels;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Server.Views
{
	public class CraftInfoView : RibbonForm
	{
		private IContainer components = null;

		private RibbonControl ribbon;

		private RibbonPage ribbonPage1;

		private RibbonPageGroup ribbonPageGroup1;

		private BarButtonItem SaveButton;

		private GridControl CraftInfoGridControl;

		private GridView CraftInfoGridView;

		private GridColumn CraftInfoItemType;

		private GridColumn CraftInfoItemItem;

		private GridColumn CraftInfoItemLevel;

		private GridColumn CraftInfoItemIngredient1;

		private GridColumn CraftInfoItemIngredient1Amount;

		private GridColumn CraftInfoItemIngredient2;

		private GridColumn CraftInfoItemIngredient2Amount;

		private GridColumn CraftInfoItemIngredient3;

		private GridColumn CraftInfoItemIngredient3Amount;

		private GridColumn CraftInfoItemIngredient4;

		private GridColumn CraftInfoItemIngredient4Amount;

		private GridColumn CraftInfoItemCost;

		private GridColumn CraftInfoItemAmount;

		private GridColumn CraftInfoItemChance;

		private GridColumn CraftInfoItemExp;

		private TabPane tabPane1;

		private TabNavigationPage tabNavigationPage1;

		private TabNavigationPage tabNavigationPage2;

		private RepositoryItemLookUpEdit ItemLookUpEdit;

		private GridControl CraftLevelInfoGridControl;

		private GridView CraftLevelInfoGridView;

		private GridColumn CraftLevelInfoType;

		private GridColumn CraftLevelInfoLevel;

		private GridColumn CraftLevelInfoExp;

		public CraftInfoView()
		{
			InitializeComponent();
			CraftInfoGridControl.DataSource = SMain.Session.GetCollection<CraftItemInfo>().Binding;
			CraftLevelInfoGridControl.DataSource = SMain.Session.GetCollection<CraftLevelInfo>().Binding;
			ItemLookUpEdit.DataSource = SMain.Session.GetCollection<ItemInfo>().Binding;
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			SMain.SetUpView(CraftInfoGridView);
			SMain.SetUpView(CraftLevelInfoGridView);
		}

		private void SaveButton_ItemClick(object sender, ItemClickEventArgs e)
		{
			SMain.Session.Save(commit: true);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Server.Views.CraftInfoView));
			ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
			SaveButton = new DevExpress.XtraBars.BarButtonItem();
			ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
			ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			CraftInfoGridControl = new DevExpress.XtraGrid.GridControl();
			CraftInfoGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
			CraftInfoItemType = new DevExpress.XtraGrid.Columns.GridColumn();
			CraftInfoItemItem = new DevExpress.XtraGrid.Columns.GridColumn();
			ItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			CraftInfoItemLevel = new DevExpress.XtraGrid.Columns.GridColumn();
			CraftInfoItemIngredient1 = new DevExpress.XtraGrid.Columns.GridColumn();
			CraftInfoItemIngredient1Amount = new DevExpress.XtraGrid.Columns.GridColumn();
			CraftInfoItemIngredient2 = new DevExpress.XtraGrid.Columns.GridColumn();
			CraftInfoItemIngredient2Amount = new DevExpress.XtraGrid.Columns.GridColumn();
			CraftInfoItemIngredient3 = new DevExpress.XtraGrid.Columns.GridColumn();
			CraftInfoItemIngredient3Amount = new DevExpress.XtraGrid.Columns.GridColumn();
			CraftInfoItemIngredient4 = new DevExpress.XtraGrid.Columns.GridColumn();
			CraftInfoItemIngredient4Amount = new DevExpress.XtraGrid.Columns.GridColumn();
			CraftInfoItemCost = new DevExpress.XtraGrid.Columns.GridColumn();
			CraftInfoItemChance = new DevExpress.XtraGrid.Columns.GridColumn();
			CraftInfoItemAmount = new DevExpress.XtraGrid.Columns.GridColumn();
			CraftInfoItemExp = new DevExpress.XtraGrid.Columns.GridColumn();
			tabPane1 = new DevExpress.XtraBars.Navigation.TabPane();
			tabNavigationPage1 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
			tabNavigationPage2 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
			CraftLevelInfoGridControl = new DevExpress.XtraGrid.GridControl();
			CraftLevelInfoGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
			CraftLevelInfoType = new DevExpress.XtraGrid.Columns.GridColumn();
			CraftLevelInfoLevel = new DevExpress.XtraGrid.Columns.GridColumn();
			CraftLevelInfoExp = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
			((System.ComponentModel.ISupportInitialize)CraftInfoGridControl).BeginInit();
			((System.ComponentModel.ISupportInitialize)CraftInfoGridView).BeginInit();
			((System.ComponentModel.ISupportInitialize)ItemLookUpEdit).BeginInit();
			((System.ComponentModel.ISupportInitialize)tabPane1).BeginInit();
			tabPane1.SuspendLayout();
			tabNavigationPage1.SuspendLayout();
			tabNavigationPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)CraftLevelInfoGridControl).BeginInit();
			((System.ComponentModel.ISupportInitialize)CraftLevelInfoGridView).BeginInit();
			SuspendLayout();
			ribbon.ExpandCollapseItem.Id = 0;
			ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[2]
			{
				ribbon.ExpandCollapseItem,
				SaveButton
			});
			ribbon.Location = new System.Drawing.Point(0, 0);
			ribbon.MaxItemId = 2;
			ribbon.Name = "ribbon";
			ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[1]
			{
				ribbonPage1
			});
			ribbon.Size = new System.Drawing.Size(972, 144);
			SaveButton.Caption = "Save Database";
			SaveButton.Glyph = (System.Drawing.Image)resources.GetObject("SaveButton.Glyph");
			SaveButton.Id = 1;
			SaveButton.LargeGlyph = (System.Drawing.Image)resources.GetObject("SaveButton.LargeGlyph");
			SaveButton.LargeWidth = 60;
			SaveButton.Name = "SaveButton";
			SaveButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(SaveButton_ItemClick);
			ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[1]
			{
				ribbonPageGroup1
			});
			ribbonPage1.Name = "ribbonPage1";
			ribbonPage1.Text = "Home";
			ribbonPageGroup1.AllowTextClipping = false;
			ribbonPageGroup1.ItemLinks.Add(SaveButton);
			ribbonPageGroup1.Name = "ribbonPageGroup1";
			ribbonPageGroup1.ShowCaptionButton = false;
			ribbonPageGroup1.Text = "Saving";
			CraftInfoGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
			CraftInfoGridControl.Location = new System.Drawing.Point(0, 0);
			CraftInfoGridControl.MainView = CraftInfoGridView;
			CraftInfoGridControl.MenuManager = ribbon;
			CraftInfoGridControl.Name = "CraftInfoGridControl";
			CraftInfoGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[1]
			{
				ItemLookUpEdit
			});
			CraftInfoGridControl.Size = new System.Drawing.Size(954, 355);
			CraftInfoGridControl.TabIndex = 2;
			CraftInfoGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1]
			{
				CraftInfoGridView
			});
			CraftInfoGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[15]
			{
				CraftInfoItemType,
				CraftInfoItemItem,
				CraftInfoItemLevel,
				CraftInfoItemIngredient1,
				CraftInfoItemIngredient1Amount,
				CraftInfoItemIngredient2,
				CraftInfoItemIngredient2Amount,
				CraftInfoItemIngredient3,
				CraftInfoItemIngredient3Amount,
				CraftInfoItemIngredient4,
				CraftInfoItemIngredient4Amount,
				CraftInfoItemCost,
				CraftInfoItemChance,
				CraftInfoItemAmount,
				CraftInfoItemExp
			});
			CraftInfoGridView.GridControl = CraftInfoGridControl;
			CraftInfoGridView.Name = "CraftInfoGridView";
			CraftInfoGridView.OptionsView.EnableAppearanceEvenRow = true;
			CraftInfoGridView.OptionsView.EnableAppearanceOddRow = true;
			CraftInfoGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
			CraftInfoGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			CraftInfoGridView.OptionsView.ShowGroupPanel = false;
			CraftInfoItemType.FieldName = "Type";
			CraftInfoItemType.Name = "CraftInfoItemType";
			CraftInfoItemType.Visible = true;
			CraftInfoItemType.VisibleIndex = 0;
			CraftInfoItemItem.ColumnEdit = ItemLookUpEdit;
			CraftInfoItemItem.FieldName = "Item";
			CraftInfoItemItem.Name = "CraftInfoItemItem";
			CraftInfoItemItem.Visible = true;
			CraftInfoItemItem.VisibleIndex = 1;
			ItemLookUpEdit.AutoHeight = false;
			ItemLookUpEdit.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
			ItemLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
			{
				new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
			});
			ItemLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[5]
			{
				new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index"),
				new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ItemName", "Item Name"),
				new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ItemType", "Item Type"),
				new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Price", "Price"),
				new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StackSize", "Stack Size")
			});
			ItemLookUpEdit.DisplayMember = "ItemName";
			ItemLookUpEdit.Name = "ItemLookUpEdit";
			ItemLookUpEdit.NullText = "[Item is null]";
			CraftInfoItemLevel.FieldName = "Level";
			CraftInfoItemLevel.Name = "CraftInfoItemLevel";
			CraftInfoItemLevel.Visible = true;
			CraftInfoItemLevel.VisibleIndex = 2;
			CraftInfoItemIngredient1.ColumnEdit = ItemLookUpEdit;
			CraftInfoItemIngredient1.FieldName = "Ingredient1";
			CraftInfoItemIngredient1.Name = "CraftInfoItemIngredient1";
			CraftInfoItemIngredient1.Visible = true;
			CraftInfoItemIngredient1.VisibleIndex = 3;
			CraftInfoItemIngredient1Amount.FieldName = "Ingredient1Amount";
			CraftInfoItemIngredient1Amount.Name = "CraftInfoItemIngredient1Amount";
			CraftInfoItemIngredient1Amount.Visible = true;
			CraftInfoItemIngredient1Amount.VisibleIndex = 4;
			CraftInfoItemIngredient2.ColumnEdit = ItemLookUpEdit;
			CraftInfoItemIngredient2.FieldName = "Ingredient2";
			CraftInfoItemIngredient2.Name = "CraftInfoItemIngredient2";
			CraftInfoItemIngredient2.Visible = true;
			CraftInfoItemIngredient2.VisibleIndex = 5;
			CraftInfoItemIngredient2Amount.FieldName = "Ingredient2Amount";
			CraftInfoItemIngredient2Amount.Name = "CraftInfoItemIngredient2Amount";
			CraftInfoItemIngredient2Amount.Visible = true;
			CraftInfoItemIngredient2Amount.VisibleIndex = 6;
			CraftInfoItemIngredient3.ColumnEdit = ItemLookUpEdit;
			CraftInfoItemIngredient3.FieldName = "Ingredient3";
			CraftInfoItemIngredient3.Name = "CraftInfoItemIngredient3";
			CraftInfoItemIngredient3.Visible = true;
			CraftInfoItemIngredient3.VisibleIndex = 7;
			CraftInfoItemIngredient3Amount.FieldName = "Ingredient3Amount";
			CraftInfoItemIngredient3Amount.Name = "CraftInfoItemIngredient3Amount";
			CraftInfoItemIngredient3Amount.Visible = true;
			CraftInfoItemIngredient3Amount.VisibleIndex = 8;
			CraftInfoItemIngredient4.ColumnEdit = ItemLookUpEdit;
			CraftInfoItemIngredient4.FieldName = "Ingredient4";
			CraftInfoItemIngredient4.Name = "CraftInfoItemIngredient4";
			CraftInfoItemIngredient4.Visible = true;
			CraftInfoItemIngredient4.VisibleIndex = 9;
			CraftInfoItemIngredient4Amount.FieldName = "Ingredient4Amount";
			CraftInfoItemIngredient4Amount.Name = "CraftInfoItemIngredient4Amount";
			CraftInfoItemIngredient4Amount.Visible = true;
			CraftInfoItemIngredient4Amount.VisibleIndex = 10;
			CraftInfoItemCost.FieldName = "Cost";
			CraftInfoItemCost.Name = "CraftInfoItemCost";
			CraftInfoItemCost.Visible = true;
			CraftInfoItemCost.VisibleIndex = 11;
			CraftInfoItemAmount.FieldName = "Amount";
			CraftInfoItemAmount.Name = "CraftInfoItemAmount";
			CraftInfoItemAmount.Visible = true;
			CraftInfoItemAmount.VisibleIndex = 12;
			CraftInfoItemChance.FieldName = "Chance";
			CraftInfoItemChance.Name = "CraftInfoItemChance";
			CraftInfoItemChance.Visible = true;
			CraftInfoItemChance.VisibleIndex = 13;
			CraftInfoItemExp.FieldName = "Exp";
			CraftInfoItemExp.Name = "CraftInfoItemExp";
			CraftInfoItemExp.Visible = true;
			CraftInfoItemExp.VisibleIndex = 14;
			tabPane1.Controls.Add(tabNavigationPage1);
			tabPane1.Controls.Add(tabNavigationPage2);
			tabPane1.Dock = System.Windows.Forms.DockStyle.Fill;
			tabPane1.Location = new System.Drawing.Point(0, 144);
			tabPane1.Name = "tabPane1";
			tabPane1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[2]
			{
				tabNavigationPage1,
				tabNavigationPage2
			});
			tabPane1.RegularSize = new System.Drawing.Size(972, 400);
			tabPane1.SelectedPage = tabNavigationPage1;
			tabPane1.Size = new System.Drawing.Size(972, 400);
			tabPane1.TabIndex = 3;
			tabNavigationPage1.Caption = "Craft Info";
			tabNavigationPage1.Controls.Add(CraftInfoGridControl);
			tabNavigationPage1.Name = "tabNavigationPage1";
			tabNavigationPage1.Size = new System.Drawing.Size(954, 355);
			tabNavigationPage2.Caption = "Craft Level Info";
			tabNavigationPage2.Controls.Add(CraftLevelInfoGridControl);
			tabNavigationPage2.Name = "tabNavigationPage2";
			tabNavigationPage2.Size = new System.Drawing.Size(960, 358);
			CraftLevelInfoGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
			CraftLevelInfoGridControl.Location = new System.Drawing.Point(0, 0);
			CraftLevelInfoGridControl.MainView = CraftLevelInfoGridView;
			CraftLevelInfoGridControl.MenuManager = ribbon;
			CraftLevelInfoGridControl.Name = "CraftLevelInfoGridControl";
			CraftLevelInfoGridControl.Size = new System.Drawing.Size(960, 358);
			CraftLevelInfoGridControl.TabIndex = 2;
			CraftLevelInfoGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1]
			{
				CraftLevelInfoGridView
			});
			CraftLevelInfoGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[3]
			{
				CraftLevelInfoType,
				CraftLevelInfoLevel,
				CraftLevelInfoExp
			});
			CraftLevelInfoGridView.GridControl = CraftLevelInfoGridControl;
			CraftLevelInfoGridView.Name = "CraftLevelInfoGridView";
			CraftLevelInfoGridView.OptionsView.EnableAppearanceEvenRow = true;
			CraftLevelInfoGridView.OptionsView.EnableAppearanceOddRow = true;
			CraftLevelInfoGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
			CraftLevelInfoGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			CraftLevelInfoGridView.OptionsView.ShowGroupPanel = false;
			CraftLevelInfoType.FieldName = "Type";
			CraftLevelInfoType.Name = "CraftLevelInfoType";
			CraftLevelInfoType.Visible = true;
			CraftLevelInfoType.VisibleIndex = 0;
			CraftLevelInfoLevel.FieldName = "Level";
			CraftLevelInfoLevel.Name = "CraftLevelInfoLevel";
			CraftLevelInfoLevel.Visible = true;
			CraftLevelInfoLevel.VisibleIndex = 1;
			CraftLevelInfoExp.FieldName = "Exp";
			CraftLevelInfoExp.Name = "CraftLevelInfoExp";
			CraftLevelInfoExp.Visible = true;
			CraftLevelInfoExp.VisibleIndex = 2;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(972, 544);
			base.Controls.Add(tabPane1);
			base.Controls.Add(ribbon);
			base.Name = "CraftInfoView";
			Ribbon = ribbon;
			Text = "CraftInfoView";
			((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
			((System.ComponentModel.ISupportInitialize)CraftInfoGridControl).EndInit();
			((System.ComponentModel.ISupportInitialize)CraftInfoGridView).EndInit();
			((System.ComponentModel.ISupportInitialize)ItemLookUpEdit).EndInit();
			((System.ComponentModel.ISupportInitialize)tabPane1).EndInit();
			tabPane1.ResumeLayout(false);
			tabNavigationPage1.ResumeLayout(false);
			tabNavigationPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)CraftLevelInfoGridControl).EndInit();
			((System.ComponentModel.ISupportInitialize)CraftLevelInfoGridView).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
