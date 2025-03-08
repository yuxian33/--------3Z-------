using DevExpress.Data;
using DevExpress.Utils.Behaviors;
using DevExpress.XtraBars;
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
	public class MiniGameInfoView : RibbonForm
	{
		private IContainer components = null;

		private RibbonControl ribbon;

		private RibbonPage ribbonPage1;

		private RibbonPageGroup ribbonPageGroup1;

		private BarButtonItem SaveButton;

		private BindingSource miniGameInfoBindingSource;

		private BehaviorManager behaviorManager1;

		private RepositoryItemLookUpEdit MapLookUpEdit;

		private RepositoryItemLookUpEdit RegionLookUpEdit;

		private RepositoryItemLookUpEdit ItemLookUpEdit;

		private RepositoryItemLookUpEdit MonsterLookUpEdit;

		public GridView RewardsGridView;

		private GridColumn colItem;

		private GridColumn colChance;

		private GridColumn colAmount;

		private GridControl MonsterInfoGridControl;

		private BindingSource cTFInfoBindingSource;

		private GridView CTFGridView;

		private GridColumn colTeamAFlagSpawn;

		private GridColumn colTeamBFlagSpawn;

		private GridColumn colTeamAFlagReturn;

		private GridColumn colTeamBFlagReturn;

		private GridView MiniGameInfoGridView;

		private GridColumn colMiniGame;

		private GridColumn colMapParameter;

		private GridColumn colMapLobby;

		private GridColumn colTeamARegion;

		private GridColumn colTeamBRegion;

		private GridColumn colMinLevel;

		private GridColumn colMaxLevel;

		private GridColumn colDuration;

		private GridColumn colEntryFee;

		private GridColumn colTeamGame;

		private GridColumn colFlagMonster;

		private GridColumn colCanRevive;

		private GridColumn colReviveDelay;

		private GridColumn colTop1;

		private GridColumn colTop2;

		private GridColumn colTop3;

		private GridColumn colMinPlayers;

		private GridColumn colMaxPlayers;

		public MiniGameInfoView()
		{
			InitializeComponent();
			MonsterInfoGridControl.DataSource = SMain.Session.GetCollection<MiniGameInfo>().Binding;
			MapLookUpEdit.DataSource = SMain.Session.GetCollection<MapInfo>().Binding;
			ItemLookUpEdit.DataSource = SMain.Session.GetCollection<ItemInfo>().Binding;
			RegionLookUpEdit.DataSource = SMain.Session.GetCollection<MapRegion>().Binding;
			MonsterLookUpEdit.DataSource = SMain.Session.GetCollection<MonsterInfo>().Binding;
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			SMain.SetUpView(MiniGameInfoGridView);
			SMain.SetUpView(RewardsGridView);
			SMain.SetUpView(CTFGridView);
		}

		private void SaveButton_ItemClick(object sender, ItemClickEventArgs e)
		{
			SMain.Session.Save(commit: true);
		}

		private void MonsterInfoGridControl_Click(object sender, EventArgs e)
		{
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
			DevExpress.XtraGrid.GridLevelNode gridLevelNode3 = new DevExpress.XtraGrid.GridLevelNode();
			DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Server.Views.MiniGameInfoView));
			RewardsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
			colItem = new DevExpress.XtraGrid.Columns.GridColumn();
			ItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			colChance = new DevExpress.XtraGrid.Columns.GridColumn();
			colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
			colTop1 = new DevExpress.XtraGrid.Columns.GridColumn();
			colTop2 = new DevExpress.XtraGrid.Columns.GridColumn();
			colTop3 = new DevExpress.XtraGrid.Columns.GridColumn();
			MonsterInfoGridControl = new DevExpress.XtraGrid.GridControl();
			miniGameInfoBindingSource = new System.Windows.Forms.BindingSource(components);
			CTFGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
			colTeamAFlagSpawn = new DevExpress.XtraGrid.Columns.GridColumn();
			RegionLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			colTeamBFlagSpawn = new DevExpress.XtraGrid.Columns.GridColumn();
			colTeamAFlagReturn = new DevExpress.XtraGrid.Columns.GridColumn();
			colTeamBFlagReturn = new DevExpress.XtraGrid.Columns.GridColumn();
			colFlagMonster = new DevExpress.XtraGrid.Columns.GridColumn();
			MonsterLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			MiniGameInfoGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
			colMiniGame = new DevExpress.XtraGrid.Columns.GridColumn();
			colMapParameter = new DevExpress.XtraGrid.Columns.GridColumn();
			MapLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			colMapLobby = new DevExpress.XtraGrid.Columns.GridColumn();
			colTeamARegion = new DevExpress.XtraGrid.Columns.GridColumn();
			colTeamBRegion = new DevExpress.XtraGrid.Columns.GridColumn();
			colMinLevel = new DevExpress.XtraGrid.Columns.GridColumn();
			colMaxLevel = new DevExpress.XtraGrid.Columns.GridColumn();
			colDuration = new DevExpress.XtraGrid.Columns.GridColumn();
			colEntryFee = new DevExpress.XtraGrid.Columns.GridColumn();
			colTeamGame = new DevExpress.XtraGrid.Columns.GridColumn();
			colCanRevive = new DevExpress.XtraGrid.Columns.GridColumn();
			colReviveDelay = new DevExpress.XtraGrid.Columns.GridColumn();
			ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
			SaveButton = new DevExpress.XtraBars.BarButtonItem();
			ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
			ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			cTFInfoBindingSource = new System.Windows.Forms.BindingSource(components);
			behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(components);
			colMinPlayers = new DevExpress.XtraGrid.Columns.GridColumn();
			colMaxPlayers = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)RewardsGridView).BeginInit();
			((System.ComponentModel.ISupportInitialize)ItemLookUpEdit).BeginInit();
			((System.ComponentModel.ISupportInitialize)MonsterInfoGridControl).BeginInit();
			((System.ComponentModel.ISupportInitialize)miniGameInfoBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)CTFGridView).BeginInit();
			((System.ComponentModel.ISupportInitialize)RegionLookUpEdit).BeginInit();
			((System.ComponentModel.ISupportInitialize)MonsterLookUpEdit).BeginInit();
			((System.ComponentModel.ISupportInitialize)MiniGameInfoGridView).BeginInit();
			((System.ComponentModel.ISupportInitialize)MapLookUpEdit).BeginInit();
			((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
			((System.ComponentModel.ISupportInitialize)cTFInfoBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)behaviorManager1).BeginInit();
			SuspendLayout();
			RewardsGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[6]
			{
				colItem,
				colChance,
				colAmount,
				colTop1,
				colTop2,
				colTop3
			});
			RewardsGridView.GridControl = MonsterInfoGridControl;
			RewardsGridView.Name = "RewardsGridView";
			RewardsGridView.OptionsView.EnableAppearanceEvenRow = true;
			RewardsGridView.OptionsView.EnableAppearanceOddRow = true;
			RewardsGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
			RewardsGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			RewardsGridView.OptionsView.ShowGroupPanel = false;
			colItem.ColumnEdit = ItemLookUpEdit;
			colItem.FieldName = "Item";
			colItem.Name = "colItem";
			colItem.Visible = true;
			colItem.VisibleIndex = 0;
			ItemLookUpEdit.AutoHeight = false;
			ItemLookUpEdit.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
			ItemLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
			{
				new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
			});
			ItemLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[3]
			{
				new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index"),
				new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ItemName", "Item Name"),
				new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ItemType", "Item Type")
			});
			ItemLookUpEdit.DisplayMember = "ItemName";
			ItemLookUpEdit.Name = "ItemLookUpEdit";
			ItemLookUpEdit.NullText = "[Item is null]";
			colChance.FieldName = "Chance";
			colChance.Name = "colChance";
			colChance.Visible = true;
			colChance.VisibleIndex = 1;
			colAmount.FieldName = "Amount";
			colAmount.Name = "colAmount";
			colAmount.Visible = true;
			colAmount.VisibleIndex = 2;
			colTop1.FieldName = "Top1";
			colTop1.Name = "colTop1";
			colTop1.Visible = true;
			colTop1.VisibleIndex = 3;
			colTop2.FieldName = "Top2";
			colTop2.Name = "colTop2";
			colTop2.Visible = true;
			colTop2.VisibleIndex = 4;
			colTop3.FieldName = "Top3";
			colTop3.Name = "colTop3";
			colTop3.Visible = true;
			colTop3.VisibleIndex = 5;
			MonsterInfoGridControl.DataSource = miniGameInfoBindingSource;
			MonsterInfoGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
			gridLevelNode3.LevelTemplate = RewardsGridView;
			gridLevelNode3.RelationName = "Rewards";
			gridLevelNode2.LevelTemplate = CTFGridView;
			gridLevelNode2.RelationName = "CTFInfo";
			MonsterInfoGridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[2]
			{
				gridLevelNode3,
				gridLevelNode2
			});
			MonsterInfoGridControl.Location = new System.Drawing.Point(0, 143);
			MonsterInfoGridControl.MainView = MiniGameInfoGridView;
			MonsterInfoGridControl.MenuManager = ribbon;
			MonsterInfoGridControl.Name = "MonsterInfoGridControl";
			MonsterInfoGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[4]
			{
				MapLookUpEdit,
				RegionLookUpEdit,
				MonsterLookUpEdit,
				ItemLookUpEdit
			});
			MonsterInfoGridControl.ShowOnlyPredefinedDetails = true;
			MonsterInfoGridControl.Size = new System.Drawing.Size(631, 291);
			MonsterInfoGridControl.TabIndex = 2;
			MonsterInfoGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[3]
			{
				CTFGridView,
				MiniGameInfoGridView,
				RewardsGridView
			});
			MonsterInfoGridControl.Click += new System.EventHandler(MonsterInfoGridControl_Click);
			miniGameInfoBindingSource.DataSource = typeof(Library.SystemModels.MiniGameInfo);
			CTFGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[5]
			{
				colTeamAFlagSpawn,
				colTeamBFlagSpawn,
				colTeamAFlagReturn,
				colTeamBFlagReturn,
				colFlagMonster
			});
			CTFGridView.GridControl = MonsterInfoGridControl;
			CTFGridView.Name = "CTFGridView";
			CTFGridView.OptionsView.EnableAppearanceEvenRow = true;
			CTFGridView.OptionsView.EnableAppearanceOddRow = true;
			CTFGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
			CTFGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			CTFGridView.OptionsView.ShowGroupPanel = false;
			colTeamAFlagSpawn.ColumnEdit = RegionLookUpEdit;
			colTeamAFlagSpawn.FieldName = "TeamAFlagSpawn";
			colTeamAFlagSpawn.Name = "colTeamAFlagSpawn";
			colTeamAFlagSpawn.Visible = true;
			colTeamAFlagSpawn.VisibleIndex = 0;
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
			colTeamBFlagSpawn.ColumnEdit = RegionLookUpEdit;
			colTeamBFlagSpawn.FieldName = "TeamBFlagSpawn";
			colTeamBFlagSpawn.Name = "colTeamBFlagSpawn";
			colTeamBFlagSpawn.Visible = true;
			colTeamBFlagSpawn.VisibleIndex = 1;
			colTeamAFlagReturn.ColumnEdit = RegionLookUpEdit;
			colTeamAFlagReturn.FieldName = "TeamAFlagReturn";
			colTeamAFlagReturn.Name = "colTeamAFlagReturn";
			colTeamAFlagReturn.Visible = true;
			colTeamAFlagReturn.VisibleIndex = 2;
			colTeamBFlagReturn.ColumnEdit = RegionLookUpEdit;
			colTeamBFlagReturn.FieldName = "TeamBFlagReturn";
			colTeamBFlagReturn.Name = "colTeamBFlagReturn";
			colTeamBFlagReturn.Visible = true;
			colTeamBFlagReturn.VisibleIndex = 3;
			colFlagMonster.Caption = "colFlagMonster";
			colFlagMonster.ColumnEdit = MonsterLookUpEdit;
			colFlagMonster.FieldName = "FlagMonster";
			colFlagMonster.Name = "colFlagMonster";
			colFlagMonster.Visible = true;
			colFlagMonster.VisibleIndex = 4;
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
				new DevExpress.XtraEditors.Controls.LookUpColumnInfo("IsBoss", "Is Boss")
			});
			MonsterLookUpEdit.DisplayMember = "MonsterName";
			MonsterLookUpEdit.Name = "MonsterLookUpEdit";
			MonsterLookUpEdit.NullText = "[Monster is null]";
			MiniGameInfoGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[14]
			{
				colMiniGame,
				colMapParameter,
				colMapLobby,
				colTeamARegion,
				colTeamBRegion,
				colMinLevel,
				colMaxLevel,
				colDuration,
				colEntryFee,
				colTeamGame,
				colCanRevive,
				colReviveDelay,
				colMinPlayers,
				colMaxPlayers
			});
			MiniGameInfoGridView.GridControl = MonsterInfoGridControl;
			MiniGameInfoGridView.Name = "MiniGameInfoGridView";
			MiniGameInfoGridView.OptionsDetail.AllowExpandEmptyDetails = true;
			MiniGameInfoGridView.OptionsView.EnableAppearanceEvenRow = true;
			MiniGameInfoGridView.OptionsView.EnableAppearanceOddRow = true;
			MiniGameInfoGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
			MiniGameInfoGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			MiniGameInfoGridView.OptionsView.ShowGroupPanel = false;
			MiniGameInfoGridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[1]
			{
				new DevExpress.XtraGrid.Columns.GridColumnSortInfo(colMiniGame, DevExpress.Data.ColumnSortOrder.Ascending)
			});
			colMiniGame.FieldName = "MiniGame";
			colMiniGame.Name = "colMiniGame";
			colMiniGame.Visible = true;
			colMiniGame.VisibleIndex = 0;
			colMapParameter.ColumnEdit = MapLookUpEdit;
			colMapParameter.FieldName = "MapParameter";
			colMapParameter.Name = "colMapParameter";
			colMapParameter.Visible = true;
			colMapParameter.VisibleIndex = 1;
			MapLookUpEdit.AutoHeight = false;
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
			colMapLobby.ColumnEdit = MapLookUpEdit;
			colMapLobby.FieldName = "MapLobby";
			colMapLobby.Name = "colMapLobby";
			colMapLobby.Visible = true;
			colMapLobby.VisibleIndex = 2;
			colTeamARegion.ColumnEdit = RegionLookUpEdit;
			colTeamARegion.FieldName = "TeamASpawn";
			colTeamARegion.Name = "colTeamARegion";
			colTeamARegion.Visible = true;
			colTeamARegion.VisibleIndex = 3;
			colTeamBRegion.ColumnEdit = RegionLookUpEdit;
			colTeamBRegion.FieldName = "TeamBSpawn";
			colTeamBRegion.Name = "colTeamBRegion";
			colTeamBRegion.Visible = true;
			colTeamBRegion.VisibleIndex = 4;
			colMinLevel.FieldName = "MinLevel";
			colMinLevel.Name = "colMinLevel";
			colMinLevel.Visible = true;
			colMinLevel.VisibleIndex = 6;
			colMaxLevel.FieldName = "MaxLevel";
			colMaxLevel.Name = "colMaxLevel";
			colMaxLevel.Visible = true;
			colMaxLevel.VisibleIndex = 7;
			colDuration.FieldName = "Duration";
			colDuration.Name = "colDuration";
			colDuration.Visible = true;
			colDuration.VisibleIndex = 5;
			colEntryFee.FieldName = "EntryFee";
			colEntryFee.Name = "colEntryFee";
			colEntryFee.Visible = true;
			colEntryFee.VisibleIndex = 8;
			colTeamGame.Caption = "Team Game";
			colTeamGame.FieldName = "TeamGame";
			colTeamGame.Name = "colTeamGame";
			colTeamGame.Visible = true;
			colTeamGame.VisibleIndex = 9;
			colCanRevive.FieldName = "CanRevive";
			colCanRevive.Name = "colCanRevive";
			colCanRevive.Visible = true;
			colCanRevive.VisibleIndex = 10;
			colReviveDelay.FieldName = "ReviveDelay";
			colReviveDelay.Name = "colReviveDelay";
			colReviveDelay.Visible = true;
			colReviveDelay.VisibleIndex = 11;
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
			ribbon.Size = new System.Drawing.Size(631, 143);
			SaveButton.Caption = "Save Databasse";
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
			cTFInfoBindingSource.DataMember = "CTFInfo";
			cTFInfoBindingSource.DataSource = miniGameInfoBindingSource;
			colMinPlayers.FieldName = "MinPlayers";
			colMinPlayers.Name = "colMinPlayers";
			colMinPlayers.Visible = true;
			colMinPlayers.VisibleIndex = 12;
			colMaxPlayers.FieldName = "MaxPlayers";
			colMaxPlayers.Name = "colMaxPlayers";
			colMaxPlayers.Visible = true;
			colMaxPlayers.VisibleIndex = 13;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(631, 434);
			base.Controls.Add(MonsterInfoGridControl);
			base.Controls.Add(ribbon);
			base.Name = "MiniGameInfoView";
			Ribbon = ribbon;
			Text = "Mini Games";
			((System.ComponentModel.ISupportInitialize)RewardsGridView).EndInit();
			((System.ComponentModel.ISupportInitialize)ItemLookUpEdit).EndInit();
			((System.ComponentModel.ISupportInitialize)MonsterInfoGridControl).EndInit();
			((System.ComponentModel.ISupportInitialize)miniGameInfoBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)CTFGridView).EndInit();
			((System.ComponentModel.ISupportInitialize)RegionLookUpEdit).EndInit();
			((System.ComponentModel.ISupportInitialize)MonsterLookUpEdit).EndInit();
			((System.ComponentModel.ISupportInitialize)MiniGameInfoGridView).EndInit();
			((System.ComponentModel.ISupportInitialize)MapLookUpEdit).EndInit();
			((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
			((System.ComponentModel.ISupportInitialize)cTFInfoBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)behaviorManager1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
