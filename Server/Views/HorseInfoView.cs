using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Library;
using Library.SystemModels;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Server.Views
{
	public class HorseInfoView : RibbonForm
	{
		private IContainer components = null;

		private RibbonControl ribbon;

		private RibbonPage ribbonPage1;

		private RibbonPageGroup ribbonPageGroup1;

		private BarButtonItem SaveButton;

		private GridControl HorseInfoGridControl;

		private GridView HorseInfoGridView;

		private RepositoryItemLookUpEdit MonsterLookUpEdit;

		private RepositoryItemLookUpEdit RegionLookUpEdit;

		private RepositoryItemLookUpEdit MapLookUpEdit;

		private RepositoryItemTextEdit repositoryItemTextEdit1;

		private RepositoryItemLookUpEdit ItemLookUpEdit;

		//private GridColumn outpostMon;

		private BindingSource horseInfoBindingSource;

		private GridColumn colHorse;

		private GridColumn colMonsterInfo;

		private GridColumn colPrice;

		private GridColumn colAvailable;

		private RepositoryItemImageComboBox HorseTypeImageComboBox;

		public HorseInfoView()
		{
			InitializeComponent();
			HorseInfoGridControl.DataSource = SMain.Session.GetCollection<HorseInfo>().Binding;
			MonsterLookUpEdit.DataSource = SMain.Session.GetCollection<MonsterInfo>().Binding;
			RegionLookUpEdit.DataSource = SMain.Session.GetCollection<MapRegion>().Binding;
			MapLookUpEdit.DataSource = SMain.Session.GetCollection<MapInfo>().Binding;
			ItemLookUpEdit.DataSource = SMain.Session.GetCollection<ItemInfo>().Binding;
			HorseTypeImageComboBox.Items.AddEnum<HorseType>();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			SMain.SetUpView(HorseInfoGridView);
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
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Server.Views.HorseInfoView));
			HorseInfoGridControl = new DevExpress.XtraGrid.GridControl();
			horseInfoBindingSource = new System.Windows.Forms.BindingSource(components);
			HorseInfoGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
			colHorse = new DevExpress.XtraGrid.Columns.GridColumn();
			colMonsterInfo = new DevExpress.XtraGrid.Columns.GridColumn();
			MonsterLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
			colAvailable = new DevExpress.XtraGrid.Columns.GridColumn();
			ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
			SaveButton = new DevExpress.XtraBars.BarButtonItem();
			ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
			ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			RegionLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			MapLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
			ItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			HorseTypeImageComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
			((System.ComponentModel.ISupportInitialize)HorseInfoGridControl).BeginInit();
			((System.ComponentModel.ISupportInitialize)horseInfoBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)HorseInfoGridView).BeginInit();
			((System.ComponentModel.ISupportInitialize)MonsterLookUpEdit).BeginInit();
			((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
			((System.ComponentModel.ISupportInitialize)RegionLookUpEdit).BeginInit();
			((System.ComponentModel.ISupportInitialize)MapLookUpEdit).BeginInit();
			((System.ComponentModel.ISupportInitialize)repositoryItemTextEdit1).BeginInit();
			((System.ComponentModel.ISupportInitialize)ItemLookUpEdit).BeginInit();
			((System.ComponentModel.ISupportInitialize)HorseTypeImageComboBox).BeginInit();
			SuspendLayout();
			HorseInfoGridControl.DataSource = horseInfoBindingSource;
			HorseInfoGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
			HorseInfoGridControl.Location = new System.Drawing.Point(0, 147);
			HorseInfoGridControl.MainView = HorseInfoGridView;
			HorseInfoGridControl.MenuManager = ribbon;
			HorseInfoGridControl.Name = "HorseInfoGridControl";
			HorseInfoGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[5]
			{
				MonsterLookUpEdit,
				RegionLookUpEdit,
				MapLookUpEdit,
				repositoryItemTextEdit1,
				ItemLookUpEdit
			});
			HorseInfoGridControl.ShowOnlyPredefinedDetails = true;
			HorseInfoGridControl.Size = new System.Drawing.Size(742, 377);
			HorseInfoGridControl.TabIndex = 2;
			HorseInfoGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1]
			{
				HorseInfoGridView
			});
			horseInfoBindingSource.DataSource = typeof(Library.SystemModels.HorseInfo);
			HorseInfoGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[4]
			{
				colHorse,
				colMonsterInfo,
				colPrice,
				colAvailable
			});
			HorseInfoGridView.GridControl = HorseInfoGridControl;
			HorseInfoGridView.Name = "HorseInfoGridView";
			HorseInfoGridView.OptionsDetail.AllowExpandEmptyDetails = true;
			HorseInfoGridView.OptionsView.EnableAppearanceEvenRow = true;
			HorseInfoGridView.OptionsView.EnableAppearanceOddRow = true;
			HorseInfoGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
			HorseInfoGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			HorseInfoGridView.OptionsView.ShowGroupPanel = false;
			colHorse.FieldName = "Horse";
			colHorse.Name = "colHorse";
			colHorse.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.True;
			colHorse.Visible = true;
			colHorse.VisibleIndex = 0;
			colMonsterInfo.ColumnEdit = MonsterLookUpEdit;
			colMonsterInfo.FieldName = "MonsterInfo";
			colMonsterInfo.Name = "colMonsterInfo";
			colMonsterInfo.Visible = true;
			colMonsterInfo.VisibleIndex = 1;
			MonsterLookUpEdit.AutoHeight = false;
			MonsterLookUpEdit.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
			MonsterLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
			{
				new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
			});
			MonsterLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[6]
			{
				new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index"),
				new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MonsterName", "Monster Name"),
				new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AI", "AI"),
				new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Level", "Level"),
				new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Experience", "Experience"),
				new DevExpress.XtraEditors.Controls.LookUpColumnInfo("IsBoss", "IsBoss")
			});
			MonsterLookUpEdit.DisplayMember = "MonsterName";
			MonsterLookUpEdit.Name = "MonsterLookUpEdit";
			MonsterLookUpEdit.NullText = "[Monster is Null]";
			colPrice.FieldName = "Price";
			colPrice.Name = "colPrice";
			colPrice.Visible = true;
			colPrice.VisibleIndex = 2;
			colAvailable.FieldName = "Available";
			colAvailable.Name = "colAvailable";
			colAvailable.Visible = true;
			colAvailable.VisibleIndex = 3;
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
			ribbon.Size = new System.Drawing.Size(742, 147);
			SaveButton.Caption = "Save Database";
			SaveButton.Id = 1;
			SaveButton.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("SaveButton.ImageOptions.Image");
			SaveButton.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("SaveButton.ImageOptions.LargeImage");
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
			RegionLookUpEdit.AutoHeight = false;
			RegionLookUpEdit.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
			RegionLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
			{
				new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
			});
			RegionLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[1]
			{
				new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServerDescription", "Description")
			});
			RegionLookUpEdit.DisplayMember = "ServerDescription";
			RegionLookUpEdit.Name = "RegionLookUpEdit";
			RegionLookUpEdit.NullText = "[Region is null]";
			MapLookUpEdit.AutoHeight = false;
			MapLookUpEdit.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
			MapLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
			{
				new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
			});
			MapLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[3]
			{
				new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index"),
				new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FileName", "File Name"),
				new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", "Description")
			});
			MapLookUpEdit.DisplayMember = "Description";
			MapLookUpEdit.Name = "MapLookUpEdit";
			MapLookUpEdit.NullText = "[Map is null]";
			repositoryItemTextEdit1.AutoHeight = false;
			repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
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
			HorseTypeImageComboBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
			{
				new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
			});
			HorseTypeImageComboBox.Name = "HorseTypeImageComboBox";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(742, 524);
			base.Controls.Add(HorseInfoGridControl);
			base.Controls.Add(ribbon);
			base.Name = "HorseInfoView";
			Ribbon = ribbon;
			Text = "Horse Info";
			((System.ComponentModel.ISupportInitialize)HorseInfoGridControl).EndInit();
			((System.ComponentModel.ISupportInitialize)horseInfoBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)HorseInfoGridView).EndInit();
			((System.ComponentModel.ISupportInitialize)MonsterLookUpEdit).EndInit();
			((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
			((System.ComponentModel.ISupportInitialize)RegionLookUpEdit).EndInit();
			((System.ComponentModel.ISupportInitialize)MapLookUpEdit).EndInit();
			((System.ComponentModel.ISupportInitialize)repositoryItemTextEdit1).EndInit();
			((System.ComponentModel.ISupportInitialize)ItemLookUpEdit).EndInit();
			((System.ComponentModel.ISupportInitialize)HorseTypeImageComboBox).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
