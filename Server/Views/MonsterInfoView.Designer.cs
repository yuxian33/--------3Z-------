using DevExpress.Utils;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace Server.Views
{
    partial class MonsterInfoView : RibbonForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode3 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode4 = new GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonsterInfoView));
            MonsterInfoStatsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            colStat = new DevExpress.XtraGrid.Columns.GridColumn();
            StatComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            MonsterInfoGridControl = new DevExpress.XtraGrid.GridControl();
            RespawnsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            colMap = new DevExpress.XtraGrid.Columns.GridColumn();
            MapLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            colX = new DevExpress.XtraGrid.Columns.GridColumn();
            colY = new DevExpress.XtraGrid.Columns.GridColumn();
            colDelay = new DevExpress.XtraGrid.Columns.GridColumn();
            colSpread = new DevExpress.XtraGrid.Columns.GridColumn();
            colCount = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            DropsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ColItem = new DevExpress.XtraGrid.Columns.GridColumn();
            ItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            colChance = new DevExpress.XtraGrid.Columns.GridColumn();
            colDAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            MonsterInfoGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            colMonsterName = new DevExpress.XtraGrid.Columns.GridColumn();
            colImage = new DevExpress.XtraGrid.Columns.GridColumn();
            MonsterImageComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            StatImageComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            EffectImageComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            ActionImageComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            MonsterCustomInfoView = new DevExpress.XtraGrid.Views.Grid.GridView();
            colAI = new DevExpress.XtraGrid.Columns.GridColumn();
            colLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            colExperience = new DevExpress.XtraGrid.Columns.GridColumn();
            colViewRange = new DevExpress.XtraGrid.Columns.GridColumn();
            colCoolEye = new DevExpress.XtraGrid.Columns.GridColumn();
            colAttackDelay = new DevExpress.XtraGrid.Columns.GridColumn();
            colMoveDelay = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsBoss = new DevExpress.XtraGrid.Columns.GridColumn();
            colUndead = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            colShengwang = new DevExpress.XtraGrid.Columns.GridColumn();
            colRarity = new DevExpress.XtraGrid.Columns.GridColumn();
            CoAnimation = new DevExpress.XtraGrid.Columns.GridColumn();
            ColOrigin = new DevExpress.XtraGrid.Columns.GridColumn();
            ColFrame = new DevExpress.XtraGrid.Columns.GridColumn();
            ColFormat = new DevExpress.XtraGrid.Columns.GridColumn();
            ColLoop = new DevExpress.XtraGrid.Columns.GridColumn();
            ColCanReversed = new DevExpress.XtraGrid.Columns.GridColumn();
            ColCanStaticSpeed = new DevExpress.XtraGrid.Columns.GridColumn();
            ColEffect = new DevExpress.XtraGrid.Columns.GridColumn();
            ColStartIndex = new DevExpress.XtraGrid.Columns.GridColumn();
            ColFrameCount = new DevExpress.XtraGrid.Columns.GridColumn();
            ColFrameDelay = new DevExpress.XtraGrid.Columns.GridColumn();
            ColStartLight = new DevExpress.XtraGrid.Columns.GridColumn();
            ColEndLight = new DevExpress.XtraGrid.Columns.GridColumn();
            ColLightColour = new DevExpress.XtraGrid.Columns.GridColumn();
            ColAction = new DevExpress.XtraGrid.Columns.GridColumn();
            ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            SaveButton = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(MonsterInfoStatsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(StatComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MonsterInfoGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(RespawnsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MapLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(DropsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ItemLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MonsterInfoGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MonsterCustomInfoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(StatImageComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ActionImageComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(EffectImageComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MonsterImageComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ribbon)).BeginInit();
            SuspendLayout();
            // 
            // MonsterInfoStatsGridView
            // 
            MonsterInfoStatsGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            colStat,
            colAmount});
            MonsterInfoStatsGridView.GridControl = MonsterInfoGridControl;
            MonsterInfoStatsGridView.Name = "MonsterInfoStatsGridView";
            MonsterInfoStatsGridView.OptionsView.EnableAppearanceEvenRow = true;
            MonsterInfoStatsGridView.OptionsView.EnableAppearanceOddRow = true;
            MonsterInfoStatsGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            MonsterInfoStatsGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            MonsterInfoStatsGridView.OptionsView.ShowGroupPanel = false;
            // 
            // colStat
            // 
            colStat.ColumnEdit = StatComboBox;
            colStat.FieldName = "Stat";
            colStat.Name = "colStat";
            colStat.Visible = true;
            colStat.VisibleIndex = 0;
            // 
            // StatComboBox
            // 
            StatComboBox.AutoHeight = false;
            StatComboBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            StatComboBox.Name = "StatComboBox";
            // 
            // colAmount
            // 
            colAmount.FieldName = "Amount";
            colAmount.Name = "colAmount";
            colAmount.Visible = true;
            colAmount.VisibleIndex = 1;
            // 
            // MonsterInfoGridControl
            // 
            MonsterInfoGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = MonsterInfoStatsGridView;
            gridLevelNode1.RelationName = "MonsterInfoStats";
            gridLevelNode2.LevelTemplate = RespawnsGridView;
            gridLevelNode2.RelationName = "Respawns";
            gridLevelNode3.LevelTemplate = DropsGridView;
            gridLevelNode3.RelationName = "Drops";
            gridLevelNode4.LevelTemplate = (BaseView)MonsterCustomInfoView;
            gridLevelNode4.RelationName = "MonsterCustomInfos";
            MonsterInfoGridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2,
            gridLevelNode3,
            gridLevelNode4});
            MonsterInfoGridControl.Location = new System.Drawing.Point(0, 143);
            MonsterInfoGridControl.MainView = MonsterInfoGridView;
            MonsterInfoGridControl.MenuManager = ribbon;
            MonsterInfoGridControl.Name = "MonsterInfoGridControl";
            MonsterInfoGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            MonsterImageComboBox,
            StatComboBox,
            ItemLookUpEdit,
            MapLookUpEdit,
            StatImageComboBox,
            EffectImageComboBox,
            ActionImageComboBox});
            MonsterInfoGridControl.ShowOnlyPredefinedDetails = true;
            MonsterInfoGridControl.Size = new System.Drawing.Size(775, 374);
            MonsterInfoGridControl.TabIndex = 2;
            MonsterInfoGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            RespawnsGridView,
            DropsGridView,
            MonsterInfoGridView,
            MonsterInfoStatsGridView});
            // 
            // RespawnsGridView
            // 
            RespawnsGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            colMap,
            colX,
            colY,
            colDelay,
            colSpread,
            colCount,
            gridColumn2});
            RespawnsGridView.GridControl = MonsterInfoGridControl;
            RespawnsGridView.Name = "RespawnsGridView";
            RespawnsGridView.OptionsView.EnableAppearanceEvenRow = true;
            RespawnsGridView.OptionsView.EnableAppearanceOddRow = true;
            RespawnsGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            RespawnsGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            RespawnsGridView.OptionsView.ShowGroupPanel = false;
            // 
            // colMap
            // 
            colMap.ColumnEdit = MapLookUpEdit;
            colMap.FieldName = "Map";
            colMap.Name = "colMap";
            colMap.Visible = true;
            colMap.VisibleIndex = 0;
            // 
            // MapLookUpEdit
            // 
            MapLookUpEdit.AutoHeight = false;
            MapLookUpEdit.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            MapLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            MapLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FileName", "File Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", "Description")});
            MapLookUpEdit.DisplayMember = "Description";
            MapLookUpEdit.Name = "MapLookUpEdit";
            MapLookUpEdit.NullText = "[Map is null]";
            // 
            // colX
            // 
            colX.FieldName = "X";
            colX.Name = "colX";
            colX.Visible = true;
            colX.VisibleIndex = 1;
            // 
            // colY
            // 
            colY.FieldName = "Y";
            colY.Name = "colY";
            colY.Visible = true;
            colY.VisibleIndex = 2;
            // 
            // colDelay
            // 
            colDelay.FieldName = "Delay";
            colDelay.Name = "colDelay";
            colDelay.Visible = true;
            colDelay.VisibleIndex = 3;
            // 
            // colSpread
            // 
            colSpread.FieldName = "Spread";
            colSpread.Name = "colSpread";
            colSpread.Visible = true;
            colSpread.VisibleIndex = 4;
            // 
            // colCount
            // 
            colCount.FieldName = "Count";
            colCount.Name = "colCount";
            colCount.Visible = true;
            colCount.VisibleIndex = 5;
            // 
            // gridColumn2
            // 
            gridColumn2.FieldName = "DropSet";
            gridColumn2.Name = "gridColumn2";
            gridColumn2.Visible = true;
            gridColumn2.VisibleIndex = 6;
            // 
            // DropsGridView
            // 
            DropsGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            ColItem,
            colChance,
            colDAmount,
            gridColumn1,
            gridColumn6,
            gridColumn7});
            DropsGridView.GridControl = MonsterInfoGridControl;
            DropsGridView.Name = "DropsGridView";
            DropsGridView.OptionsView.EnableAppearanceEvenRow = true;
            DropsGridView.OptionsView.EnableAppearanceOddRow = true;
            DropsGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            DropsGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            DropsGridView.OptionsView.ShowGroupPanel = false;
            // 
            // ColItem
            // 
            ColItem.ColumnEdit = ItemLookUpEdit;
            ColItem.FieldName = "Item";
            ColItem.Name = "ColItem";
            ColItem.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            ColItem.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            ColItem.Visible = true;
            ColItem.VisibleIndex = 0;
            // 
            // ItemLookUpEdit
            // 
            ItemLookUpEdit.AutoHeight = false;
            ItemLookUpEdit.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            ItemLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            ItemLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ItemName", "Item Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ItemType", "Item Type"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Price", "Price"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StackSize", "Stack Size")});
            ItemLookUpEdit.DisplayMember = "ItemName";
            ItemLookUpEdit.Name = "ItemLookUpEdit";
            ItemLookUpEdit.NullText = "[Item is null]";
            // 
            // colChance
            // 
            colChance.FieldName = "Chance";
            colChance.Name = "colChance";
            colChance.Visible = true;
            colChance.VisibleIndex = 1;
            // 
            // colDAmount
            // 
            colDAmount.FieldName = "Amount";
            colDAmount.Name = "colDAmount";
            colDAmount.Visible = true;
            colDAmount.VisibleIndex = 2;
            // 
            // gridColumn1
            // 
            gridColumn1.FieldName = "DropSet";
            gridColumn1.Name = "gridColumn1";
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = 3;
            // 
            // gridColumn6
            // 
            gridColumn6.FieldName = "PartOnly";
            gridColumn6.Name = "gridColumn6";
            gridColumn6.Visible = true;
            gridColumn6.VisibleIndex = 4;
            MonsterCustomInfoView.Columns.AddRange(new GridColumn[]
            {
            CoAnimation,
            ColOrigin,
            ColFrame,
            ColFormat,
            ColLoop,
            ColCanReversed,
            ColCanStaticSpeed,
            ColAction,
            ColEffect,
            ColStartIndex,
            ColFrameCount,
            ColFrameDelay,
            ColStartLight,
            ColEndLight,
            ColLightColour
            });
            MonsterCustomInfoView.GridControl = MonsterInfoGridControl;
            MonsterCustomInfoView.Name = "MonsterCustomInfoView";
            MonsterCustomInfoView.OptionsView.EnableAppearanceEvenRow = true;
            MonsterCustomInfoView.OptionsView.EnableAppearanceOddRow = true;
            MonsterCustomInfoView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            MonsterCustomInfoView.OptionsView.ShowButtonMode = ShowButtonModeEnum.ShowAlways;
            MonsterCustomInfoView.OptionsView.ShowGroupPanel = false;
            CoAnimation.ColumnEdit = (RepositoryItem)StatImageComboBox;
            CoAnimation.FieldName = "Animation";
            CoAnimation.Name = "CoAnimation";
            CoAnimation.OptionsColumn.AllowSort = DefaultBoolean.True;
            CoAnimation.SortMode = ColumnSortMode.DisplayText;
            CoAnimation.Visible = true;
            CoAnimation.VisibleIndex = 0;
            StatImageComboBox.AutoHeight = false;
            StatImageComboBox.Buttons.AddRange(new EditorButton[1]
            {
              new EditorButton(ButtonPredefines.Combo)
            });
            StatImageComboBox.Name = "StatImageComboBox";
            ColOrigin.FieldName = "Origin";
            ColOrigin.Name = "ColOrigin";
            ColOrigin.Visible = true;
            ColOrigin.VisibleIndex = 1;
            ColFrame.FieldName = "Frame";
            ColFrame.Name = "ColFrame";
            ColFrame.Visible = true;
            ColFrame.VisibleIndex = 2;
            ColFormat.FieldName = "Format";
            ColFormat.Name = "ColFormat";
            ColFormat.Visible = true;
            ColFormat.VisibleIndex = 3;
            ColLoop.FieldName = "Loop";
            ColLoop.Name = "ColLoop";
            ColLoop.Visible = true;
            ColLoop.VisibleIndex = 4;
            ColCanReversed.FieldName = "CanReversed";
            ColCanReversed.Name = "ColCanReversed";
            ColCanReversed.Visible = true;
            ColCanReversed.VisibleIndex = 5;
            ColCanStaticSpeed.FieldName = "CanStaticSpeed";
            ColCanStaticSpeed.Name = "ColCanStaticSpeed";
            ColCanStaticSpeed.Visible = true;
            ColCanStaticSpeed.VisibleIndex = 6;
            ColAction.ColumnEdit = (RepositoryItem)ActionImageComboBox;
            ColAction.FieldName = "Action";
            ColAction.Name = "ColAction";
            ColAction.Visible = true;
            ColAction.VisibleIndex = 7;
            ActionImageComboBox.AutoHeight = false;
            ActionImageComboBox.Buttons.AddRange(new EditorButton[1]
            {
              new EditorButton(ButtonPredefines.Combo)
            });
            ActionImageComboBox.Name = "ActionImageComboBox";
            ColEffect.ColumnEdit = (RepositoryItem)EffectImageComboBox;
            ColEffect.FieldName = "Effect";
            ColEffect.Name = "ColEffect";
            ColEffect.Visible = true;
            ColEffect.VisibleIndex = 8;
            EffectImageComboBox.AutoHeight = false;
            EffectImageComboBox.Buttons.AddRange(new EditorButton[1]
            {
              new EditorButton(ButtonPredefines.Combo)
            });
            EffectImageComboBox.Name = "EffectImageComboBox";
            ColStartIndex.FieldName = "StartIndex";
            ColStartIndex.Name = "ColStartIndex";
            ColStartIndex.Visible = true;
            ColStartIndex.VisibleIndex = 9;
            ColFrameCount.FieldName = "FrameCount";
            ColFrameCount.Name = "ColFrameCount";
            ColFrameCount.Visible = true;
            ColFrameCount.VisibleIndex = 10;
            ColFrameDelay.FieldName = "FrameDelay";
            ColFrameDelay.Name = "ColFrameDelay";
            ColFrameDelay.Visible = true;
            ColFrameDelay.VisibleIndex = 11;
            ColStartLight.FieldName = "StartLight";
            ColStartLight.Name = "ColStartLight";
            ColStartLight.Visible = true;
            ColStartLight.VisibleIndex = 12;
            ColEndLight.FieldName = "EndLight";
            ColEndLight.Name = "ColEndLight";
            ColEndLight.Visible = true;
            ColEndLight.VisibleIndex = 13;
            ColLightColour.FieldName = "LightColour";
            ColLightColour.Name = "ColLightColour";
            ColLightColour.Visible = true;
            ColLightColour.VisibleIndex = 14;
            // 
            // MonsterInfoGridView
            // 
            MonsterInfoGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            colMonsterName,
            colImage,
            gridColumn8,
            gridColumn9,
            gridColumn10,
            gridColumn11,
            gridColumn12,
            gridColumn13,
            colAI,
            colLevel,
            colExperience,
            colViewRange,
            colCoolEye,
            colAttackDelay,
            colMoveDelay,
            colIsBoss,
            colUndead,
            gridColumn3,
            gridColumn4,
            gridColumn5,
            colShengwang,
            colRarity});
            MonsterInfoGridView.GridControl = MonsterInfoGridControl;
            MonsterInfoGridView.Name = "MonsterInfoGridView";
            MonsterInfoGridView.OptionsDetail.AllowExpandEmptyDetails = true;
            MonsterInfoGridView.OptionsView.EnableAppearanceEvenRow = true;
            MonsterInfoGridView.OptionsView.EnableAppearanceOddRow = true;
            MonsterInfoGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            MonsterInfoGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            MonsterInfoGridView.OptionsView.ShowGroupPanel = false;
            //
            //怪物序号
            //
            gridColumn8.FieldName = "Index";
            gridColumn8.Name = "gridColumn8";
            gridColumn8.Visible = true;
            gridColumn8.VisibleIndex = 0;
            gridColumn8.Width = 87;
            // 
            // colMonsterName
            // 
            colMonsterName.FieldName = "MonsterName";
            colMonsterName.Name = "colMonsterName";
            colMonsterName.Visible = true;
            colMonsterName.VisibleIndex = 1;
            // 
            // colImage
            // 
            colImage.ColumnEdit = MonsterImageComboBox;
            colImage.FieldName = "Image";
            colImage.Name = "colImage";
            colImage.Visible = true;
            colImage.VisibleIndex = 2;
            // 
            // MonsterImageComboBox
            // 
            MonsterImageComboBox.AutoHeight = false;
            MonsterImageComboBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            MonsterImageComboBox.Name = "MonsterImageComboBox";
            //
            //自定义怪物链接
            //
            gridColumn9.FieldName = "File";
            gridColumn9.Name = "gridColumn9";
            gridColumn9.Visible = true;
            gridColumn9.VisibleIndex = 3;
            //
            //怪物代码
            //
            gridColumn10.FieldName = "BodyShape";
            gridColumn10.Name = "gridColumn10";
            gridColumn10.Visible = true;
            gridColumn10.VisibleIndex = 4;
            //
            //怪物攻击声音
            //
            gridColumn11.FieldName = "AttackSound";
            gridColumn11.Name = "gridColumn11";
            gridColumn11.Visible = true;
            gridColumn11.VisibleIndex = 5;
            //
            //怪物一般声音
            //
            gridColumn12.FieldName = "StruckSound";
            gridColumn12.Name = "gridColumn12";
            gridColumn12.Visible = true;
            gridColumn12.VisibleIndex = 6;
            //
            //怪物死亡声音
            //
            gridColumn13.FieldName = "DieSound";
            gridColumn13.Name = "gridColumn13";
            gridColumn13.Visible = true;
            gridColumn13.VisibleIndex = 7;
            // 
            // colAI
            // 
            colAI.FieldName = "AI";
            colAI.Name = "colAI";
            colAI.Visible = true;
            colAI.VisibleIndex = 8;
            // 
            // colLevel
            // 
            colLevel.FieldName = "Level";
            colLevel.Name = "colLevel";
            colLevel.Visible = true;
            colLevel.VisibleIndex = 9;
            // 
            // colExperience
            // 
            colExperience.FieldName = "Experience";
            colExperience.Name = "colExperience";
            colExperience.Visible = true;
            colExperience.VisibleIndex = 10;
            // 
            // colViewRange
            // 
            colViewRange.FieldName = "ViewRange";
            colViewRange.Name = "colViewRange";
            colViewRange.Visible = true;
            colViewRange.VisibleIndex = 11;
            // 
            // colCoolEye
            // 
            colCoolEye.FieldName = "CoolEye";
            colCoolEye.Name = "colCoolEye";
            colCoolEye.Visible = true;
            colCoolEye.VisibleIndex = 12;
            // 
            // colAttackDelay
            // 
            colAttackDelay.FieldName = "AttackDelay";
            colAttackDelay.Name = "colAttackDelay";
            colAttackDelay.Visible = true;
            colAttackDelay.VisibleIndex = 13;
            // 
            // colMoveDelay
            // 
            colMoveDelay.FieldName = "MoveDelay";
            colMoveDelay.Name = "colMoveDelay";
            colMoveDelay.Visible = true;
            colMoveDelay.VisibleIndex = 14;
            // 
            // colIsBoss
            // 
            colIsBoss.FieldName = "IsBoss";
            colIsBoss.Name = "colIsBoss";
            colIsBoss.Visible = true;
            colIsBoss.VisibleIndex = 15;
            // 
            // colUndead
            // 
            colUndead.FieldName = "Undead";
            colUndead.Name = "colUndead";
            colUndead.Visible = true;
            colUndead.VisibleIndex = 16;
            // 
            // gridColumn3
            // 
            gridColumn3.FieldName = "CanPush";
            gridColumn3.Name = "gridColumn3";
            gridColumn3.Visible = true;
            gridColumn3.VisibleIndex = 17;
            // 
            // gridColumn4
            // 
            gridColumn4.FieldName = "CanTame";
            gridColumn4.Name = "gridColumn4";
            gridColumn4.Visible = true;
            gridColumn4.VisibleIndex = 18;
            // 
            // gridColumn5
            // 
            gridColumn5.FieldName = "Flag";
            gridColumn5.Name = "gridColumn5";
            gridColumn5.Visible = true;
            gridColumn5.VisibleIndex = 19;
            // 
            // 怪物增加的声望
            // 
            colShengwang.FieldName = "Shengwang";
            colShengwang.Name = "colShengwang";
            colShengwang.ToolTip = "杀死此怪物后增加的声望点";
            colShengwang.Visible = true;
            colShengwang.VisibleIndex = 20;
            // 
            // colRarity
            // 
            colRarity.FieldName = "Rarity";
            colRarity.Name = "colRarity";
            colRarity.Visible = true;
            colRarity.VisibleIndex = 21;
            colRarity.Width = 24;
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            ribbon.ExpandCollapseItem,
            SaveButton});
            ribbon.Location = new System.Drawing.Point(0, 0);
            ribbon.MaxItemId = 2;
            ribbon.Name = "ribbon";
            ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            ribbonPage1});
            ribbon.Size = new System.Drawing.Size(775, 143);
            // 
            // SaveButton
            // 
            SaveButton.Caption = "Save Database";
            SaveButton.Glyph = ((System.Drawing.Image)(resources.GetObject("SaveButton.Glyph")));
            SaveButton.Id = 1;
            SaveButton.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("SaveButton.LargeGlyph")));
            SaveButton.LargeWidth = 60;
            SaveButton.Name = "SaveButton";
            SaveButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(SaveButton_ItemClick);
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            ribbonPageGroup1});
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "Home";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.AllowTextClipping = false;
            ribbonPageGroup1.ItemLinks.Add(SaveButton);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.ShowCaptionButton = false;
            ribbonPageGroup1.Text = "Saving";
            // 
            // gridColumn7
            // 
            gridColumn7.FieldName = "EasterEvent";
            gridColumn7.Name = "gridColumn7";
            gridColumn7.Visible = true;
            gridColumn7.VisibleIndex = 5;
            // 
            // MonsterInfoView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(775, 517);
            Controls.Add(MonsterInfoGridControl);
            Controls.Add(ribbon);
            Name = "MonsterInfoView";
            Ribbon = ribbon;
            Text = "Monster Info";
            ((System.ComponentModel.ISupportInitialize)(MonsterInfoStatsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(StatComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MonsterInfoGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(RespawnsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MapLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(DropsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ItemLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MonsterInfoGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MonsterImageComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ribbon)).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem SaveButton;
        private DevExpress.XtraGrid.GridControl MonsterInfoGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView MonsterInfoGridView;
        private DevExpress.XtraGrid.Views.Grid.GridView MonsterInfoStatsGridView;
        private DevExpress.XtraGrid.Views.Grid.GridView MonsterCustomInfoView;
        private DevExpress.XtraGrid.Columns.GridColumn colStat;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox StatComboBox;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colMonsterName;
        private DevExpress.XtraGrid.Columns.GridColumn colImage;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox MonsterImageComboBox;
        private DevExpress.XtraGrid.Columns.GridColumn colAI;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn colLevel;
        private DevExpress.XtraGrid.Columns.GridColumn colExperience;
        private DevExpress.XtraGrid.Columns.GridColumn colShengwang;
        private DevExpress.XtraGrid.Columns.GridColumn colRarity;
        private DevExpress.XtraGrid.Columns.GridColumn colViewRange;
        private DevExpress.XtraGrid.Columns.GridColumn colCoolEye;
        private DevExpress.XtraGrid.Columns.GridColumn colAttackDelay;
        private DevExpress.XtraGrid.Columns.GridColumn colMoveDelay;
        private DevExpress.XtraGrid.Views.Grid.GridView RespawnsGridView;
        private DevExpress.XtraGrid.Columns.GridColumn colMap;
        private DevExpress.XtraGrid.Columns.GridColumn colX;
        private DevExpress.XtraGrid.Columns.GridColumn colY;
        private DevExpress.XtraGrid.Columns.GridColumn colDelay;
        private DevExpress.XtraGrid.Columns.GridColumn colSpread;
        private DevExpress.XtraGrid.Columns.GridColumn colCount;
        private DevExpress.XtraGrid.Views.Grid.GridView DropsGridView;
        private DevExpress.XtraGrid.Columns.GridColumn ColItem;
        private DevExpress.XtraGrid.Columns.GridColumn colChance;
        private DevExpress.XtraGrid.Columns.GridColumn colDAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit MapLookUpEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colIsBoss;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colUndead;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn ColOrigin;
        private DevExpress.XtraGrid.Columns.GridColumn ColFrame;
        private DevExpress.XtraGrid.Columns.GridColumn ColFormat;
        private DevExpress.XtraGrid.Columns.GridColumn ColLoop;
        private DevExpress.XtraGrid.Columns.GridColumn ColCanReversed;
        private DevExpress.XtraGrid.Columns.GridColumn ColCanStaticSpeed;
        private DevExpress.XtraGrid.Columns.GridColumn ColEffect;
        private DevExpress.XtraGrid.Columns.GridColumn ColStartIndex;
        private DevExpress.XtraGrid.Columns.GridColumn ColFrameCount;
        private DevExpress.XtraGrid.Columns.GridColumn ColFrameDelay;
        private DevExpress.XtraGrid.Columns.GridColumn ColStartLight;
        private DevExpress.XtraGrid.Columns.GridColumn ColEndLight;
        private DevExpress.XtraGrid.Columns.GridColumn ColLightColour;
        private DevExpress.XtraGrid.Columns.GridColumn ColAction;
        private DevExpress.XtraGrid.Columns.GridColumn CoAnimation;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox StatImageComboBox;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox EffectImageComboBox;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox ActionImageComboBox;
    }
}