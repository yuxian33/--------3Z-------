using DevExpress.Utils;
using DevExpress.Utils.Menu;
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Server.Views
{
    public class MonsterCustomInfoView : RibbonForm
    {
        private IContainer components = (IContainer)null;
        private RibbonControl ribbon;
        private RibbonPage ribbonPage1;
        private RibbonPageGroup ribbonPageGroup1;
        private BarButtonItem SaveButton;
        private GridControl MonsterCustomInfoGridControl;
        private GridView MonsterCustomInfoGridView;
        private GridColumn gridColumn1;
        private GridColumn gridColumn2;
        private GridColumn gridColumn3;
        private GridColumn gridColumn4;
        private GridColumn gridColumn5;
        private GridColumn gridColumn6;
        private GridColumn gridColumn7;
        private GridColumn gridColumn8;
        private RepositoryItemLookUpEdit MonsterLookUpEdit;
        private RepositoryItemImageComboBox StatImageComboBox;
        private GridColumn gridColumn9;
        private GridColumn gridColumn10;
        private GridColumn gridColumn11;
        private GridColumn gridColumn12;
        private GridColumn gridColumn13;
        private GridColumn gridColumn14;
        private GridColumn gridColumn15;
        private GridColumn gridColumn16;
        private GridColumn gridColumn17;
        private GridColumn gridColumn18;
        private GridColumn gridColumn19;
        private GridColumn gridColumn20;
        private GridColumn gridColumn21;
        private GridColumn gridColumn22;
        private GridColumn gridColumn23;
        private GridColumn gridColumn24;
        private GridColumn gridColumn25;
        private GridColumn gridColumn26;
        private GridColumn gridColumn27;
        private GridColumn gridColumn28;
        private GridColumn gridColumn29;
        private RepositoryItemImageComboBox EffectImageComboBox;
        private GridColumn Action;
        private RepositoryItemImageComboBox ActionImageComboBox;
        private BarButtonItem barButtonItem1;
        private BarButtonItem barButtonItem2;
        private RibbonPage ribbonPage2;
        private RibbonPageGroup ribbonPageGroup2;

        public MonsterCustomInfoView()
        {
            InitializeComponent();
            MonsterCustomInfoGridControl.DataSource = (object)SMain.Session.GetCollection<MonsterCostomInfo>().Binding;
            MonsterLookUpEdit.DataSource = (object)SMain.Session.GetCollection<MonsterInfo>().Binding;
            StatImageComboBox.Items.AddEnum<MirAnimation>();
            EffectImageComboBox.Items.AddEnum<LibraryFile>();
            ActionImageComboBox.Items.AddEnum<MirAction>();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SMain.SetUpView(MonsterCustomInfoGridView);
        }

        private void SaveButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            SMain.Session.Save(true);
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            ExportImportHelp.ExportExcel(Text, MonsterCustomInfoGridView);
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)null;
                ExportImportHelp.ImportExcel(MonsterCustomInfoGridView, ref dt);
                if (dt == null || dt.Rows.Count <= 0)
                    return;
                IList<MonsterInfo> binding = SMain.Session.GetCollection<MonsterInfo>().Binding;
                for (int rowHandle = 0; rowHandle < dt.Rows.Count; ++rowHandle)
                {
                    MonsterCostomInfo row = MonsterCustomInfoGridView.GetRow(rowHandle) as MonsterCostomInfo;
                    DataRow DataRow = dt.Rows[rowHandle];
                    row.Monster = binding.FirstOrDefault<MonsterInfo>((Func<MonsterInfo, bool>)(o => o.MonsterName == Convert.ToString(DataRow["Monster"])));
                    row.Animation = ExportImportHelp.GetEnumName<MirAnimation>(Convert.ToString(DataRow["Animation"]));
                    row.Action = ExportImportHelp.GetEnumName<MirAction>(Convert.ToString(DataRow["Action"]));
                    row.Effect = (LibraryFile)Enum.Parse(typeof(LibraryFile), Convert.ToString(DataRow["Effect"]));
                    row.MirEffect = (LibraryFile)Enum.Parse(typeof(LibraryFile), Convert.ToString(DataRow["Effect"]));
                    row.MirProjectile = (LibraryFile)Enum.Parse(typeof(LibraryFile), Convert.ToString(DataRow["Effect"]));
                }
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("操作失败" + ex.Message, "提示");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MonsterCustomInfoView));
            ribbon = new RibbonControl();
            SaveButton = new BarButtonItem();
            ribbonPage1 = new RibbonPage();
            ribbonPageGroup1 = new RibbonPageGroup();
            MonsterCustomInfoGridControl = new GridControl();
            MonsterCustomInfoGridView = new GridView();
            gridColumn1 = new GridColumn();
            MonsterLookUpEdit = new RepositoryItemLookUpEdit();
            gridColumn2 = new GridColumn();
            StatImageComboBox = new RepositoryItemImageComboBox();
            gridColumn3 = new GridColumn();
            gridColumn4 = new GridColumn();
            gridColumn5 = new GridColumn();
            gridColumn6 = new GridColumn();
            gridColumn7 = new GridColumn();
            gridColumn8 = new GridColumn();
            gridColumn9 = new GridColumn();
            EffectImageComboBox = new RepositoryItemImageComboBox();
            gridColumn10 = new GridColumn();
            gridColumn11 = new GridColumn();
            gridColumn12 = new GridColumn();
            gridColumn13 = new GridColumn();
            gridColumn14 = new GridColumn();
            gridColumn15 = new GridColumn();
            gridColumn16 = new GridColumn();
            gridColumn17 = new GridColumn();
            gridColumn18 = new GridColumn();
            gridColumn19 = new GridColumn();
            gridColumn20 = new GridColumn();
            gridColumn21 = new GridColumn();
            gridColumn22 = new GridColumn();
            gridColumn23 = new GridColumn();
            gridColumn24 = new GridColumn();
            gridColumn25 = new GridColumn();
            gridColumn26 = new GridColumn();
            gridColumn27 = new GridColumn();
            gridColumn28 = new GridColumn();
            gridColumn29 = new GridColumn();
            Action = new GridColumn();
            ActionImageComboBox = new RepositoryItemImageComboBox();
            ribbonPage2 = new RibbonPage();
            ribbonPageGroup2 = new RibbonPageGroup();
            barButtonItem1 = new BarButtonItem();
            barButtonItem2 = new BarButtonItem();
            ribbon.BeginInit();
            MonsterCustomInfoGridControl.BeginInit();
            MonsterCustomInfoGridView.BeginInit();
            MonsterLookUpEdit.BeginInit();
            StatImageComboBox.BeginInit();
            EffectImageComboBox.BeginInit();
            ActionImageComboBox.BeginInit();
            SuspendLayout();
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Items.AddRange(new BarItem[4]
            {
        (BarItem) ribbon.ExpandCollapseItem,
        (BarItem) SaveButton,
        (BarItem) barButtonItem1,
        (BarItem) barButtonItem2
            });
            ribbon.Location = new Point(0, 0);
            ribbon.MaxItemId = 4;
            ribbon.Name = "ribbon";
            ribbon.Pages.AddRange(new RibbonPage[2]
            {
        ribbonPage1,
        ribbonPage2
            });
            ribbon.Size = new Size(807, 147);
            SaveButton.Caption = "Save Database";
            SaveButton.Id = 1;
            SaveButton.ImageOptions.Image = (Image)componentResourceManager.GetObject("SaveButton.ImageOptions.Image");
            SaveButton.ImageOptions.LargeImage = (Image)componentResourceManager.GetObject("SaveButton.ImageOptions.LargeImage");
            SaveButton.LargeWidth = 60;
            SaveButton.Name = "SaveButton";
            SaveButton.ItemClick += new ItemClickEventHandler(SaveButton_ItemClick);
            ribbonPage1.Groups.AddRange(new RibbonPageGroup[1]
            {
        ribbonPageGroup1
            });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "主页";
            ribbonPageGroup1.AllowTextClipping = false;
            ribbonPageGroup1.ItemLinks.Add((BarItem)SaveButton);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.ShowCaptionButton = false;
            ribbonPageGroup1.Text = "保存";
            MonsterCustomInfoGridControl.Dock = DockStyle.Fill;
            MonsterCustomInfoGridControl.Location = new Point(0, 147);
            MonsterCustomInfoGridControl.MainView = (BaseView)MonsterCustomInfoGridView;
            MonsterCustomInfoGridControl.MenuManager = (IDXMenuManager)ribbon;
            MonsterCustomInfoGridControl.Name = "MonsterCustomInfoGridControl";
            MonsterCustomInfoGridControl.RepositoryItems.AddRange(new RepositoryItem[4]
            {
        (RepositoryItem) MonsterLookUpEdit,
        (RepositoryItem) StatImageComboBox,
        (RepositoryItem) EffectImageComboBox,
        (RepositoryItem) ActionImageComboBox
            });
            MonsterCustomInfoGridControl.Size = new Size(807, 362);
            MonsterCustomInfoGridControl.TabIndex = 2;
            MonsterCustomInfoGridControl.ViewCollection.AddRange(new BaseView[1]
            {
        (BaseView) MonsterCustomInfoGridView
            });
            MonsterCustomInfoGridView.Columns.AddRange(new GridColumn[30]
            {
        gridColumn1,
        gridColumn2,
        gridColumn3,
        gridColumn4,
        gridColumn5,
        gridColumn6,
        gridColumn7,
        gridColumn8,
        gridColumn9,
        gridColumn10,
        gridColumn11,
        gridColumn12,
        gridColumn13,
        gridColumn14,
        gridColumn15,
        gridColumn16,
        gridColumn17,
        gridColumn18,
        gridColumn19,
        gridColumn20,
        gridColumn21,
        gridColumn22,
        gridColumn23,
        gridColumn24,
        gridColumn25,
        gridColumn26,
        gridColumn27,
        gridColumn28,
        gridColumn29,
        Action
            });
            MonsterCustomInfoGridView.DetailHeight = 377;
            MonsterCustomInfoGridView.GridControl = MonsterCustomInfoGridControl;
            MonsterCustomInfoGridView.Name = "MonsterCustomInfoGridView";
            MonsterCustomInfoGridView.OptionsView.EnableAppearanceEvenRow = true;
            MonsterCustomInfoGridView.OptionsView.EnableAppearanceOddRow = true;
            MonsterCustomInfoGridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            MonsterCustomInfoGridView.OptionsView.ShowButtonMode = ShowButtonModeEnum.ShowAlways;
            MonsterCustomInfoGridView.OptionsView.ShowGroupPanel = false;
            //
            //
            //
            gridColumn1.ColumnEdit = (RepositoryItem)MonsterLookUpEdit;
            gridColumn1.FieldName = "Monster";
            gridColumn1.MinWidth = 23;
            gridColumn1.Name = "gridColumn1";
            gridColumn1.OptionsColumn.AllowSort = DefaultBoolean.True;
            gridColumn1.SortMode = ColumnSortMode.DisplayText;
            gridColumn1.ToolTip = "怪物的名字";
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = 0;
            gridColumn1.Width = 56;
            //
            //
            //
            MonsterLookUpEdit.AutoHeight = false;
            MonsterLookUpEdit.BestFitMode = BestFitMode.BestFitResizePopup;
            MonsterLookUpEdit.Buttons.AddRange(new EditorButton[1]
            {
        new EditorButton(ButtonPredefines.Combo)
            });
            MonsterLookUpEdit.Columns.AddRange(new LookUpColumnInfo[8]
            {
        new LookUpColumnInfo("Index", "Index"),
        new LookUpColumnInfo("MonsterName", "Monster Name"),
        new LookUpColumnInfo("File", "File"),
        new LookUpColumnInfo("BodyShape", "BodyShape"),
        new LookUpColumnInfo("AI", "AI"),
        new LookUpColumnInfo("Level", "Level"),
        new LookUpColumnInfo("Experience", "Experience"),
        new LookUpColumnInfo("IsBoss", "IsBoss")
            });
            MonsterLookUpEdit.DisplayMember = "MonsterName";
            MonsterLookUpEdit.Name = "MonsterLookUpEdit";
            MonsterLookUpEdit.NullText = "[Monster is null]";
            //
            //
            //
            gridColumn2.ColumnEdit = (RepositoryItem)StatImageComboBox;
            gridColumn2.FieldName = "Animation";
            gridColumn2.MinWidth = 23;
            gridColumn2.Name = "gridColumn2";
            gridColumn2.ToolTip = "具体行为动画，比方站立，行走，攻击等等，每一个一行";
            gridColumn2.Visible = true;
            gridColumn2.VisibleIndex = 1;
            gridColumn2.Width = 56;
            StatImageComboBox.AutoHeight = false;
            StatImageComboBox.Buttons.AddRange(new EditorButton[1]
            {
        new EditorButton(ButtonPredefines.Combo)
            });
            StatImageComboBox.Name = "StatImageComboBox";
            //
            //
            //
            gridColumn3.FieldName = "Origin";
            gridColumn3.MinWidth = 23;
            gridColumn3.Name = "gridColumn3";
            gridColumn3.ToolTip = "起始图片动画序号，数据库里动画的起始值";
            gridColumn3.Visible = true;
            gridColumn3.VisibleIndex = 2;
            gridColumn3.Width = 56;
            //
            //
            //
            gridColumn4.FieldName = "Frame";
            gridColumn4.MinWidth = 23;
            gridColumn4.Name = "gridColumn4";
            gridColumn4.ToolTip = "图片动画的帧数，有多少张图片";
            gridColumn4.Visible = true;
            gridColumn4.VisibleIndex = 3;
            gridColumn4.Width = 56;
            //
            //
            //
            gridColumn5.FieldName = "Format";
            gridColumn5.MinWidth = 23;
            gridColumn5.Name = "gridColumn5";
            gridColumn5.ToolTip = "图片动画的格式，多少张为一组";
            gridColumn5.Visible = true;
            gridColumn5.VisibleIndex = 4;
            gridColumn5.Width = 56;
            //
            //
            //
            gridColumn6.FieldName = "Loop";
            gridColumn6.MinWidth = 23;
            gridColumn6.Name = "gridColumn6";
            gridColumn6.ToolTip = "图片动画循环，单位为毫秒";
            gridColumn6.Visible = true;
            gridColumn6.VisibleIndex = 5;
            gridColumn6.Width = 56;
            //
            //
            //
            gridColumn7.FieldName = "CanReversed";
            gridColumn7.MinWidth = 23;
            gridColumn7.Name = "gridColumn7";
            gridColumn7.ToolTip = "是否反序";
            gridColumn7.Visible = true;
            gridColumn7.VisibleIndex = 6;
            gridColumn7.Width = 56;
            //
            //
            //
            gridColumn8.FieldName = "CanStaticSpeed";
            gridColumn8.MinWidth = 23;
            gridColumn8.Name = "gridColumn8";
            gridColumn8.ToolTip = "是否静态速度";
            gridColumn8.Visible = true;
            gridColumn8.VisibleIndex = 7;
            gridColumn8.Width = 56;
            //
            //
            //
            gridColumn16.ColumnEdit = EffectImageComboBox;
            gridColumn16.FieldName = "MirProjectile";
            gridColumn16.Name = "gridColumn16";
            gridColumn16.ToolTip = "远程技能射击魔法特效库";
            gridColumn16.Visible = true;
            gridColumn16.VisibleIndex = 8;
            gridColumn16.Width = 48;
            //
            //
            //
            gridColumn17.FieldName = "ProStartIndex";
            gridColumn17.Name = "gridColumn17";
            gridColumn17.ToolTip = "远程技能特效起始图片序号";
            gridColumn17.Visible = true;
            gridColumn17.VisibleIndex = 9;
            gridColumn17.Width = 90;
            //
            //
            //
            gridColumn18.FieldName = "ProFrameCount";
            gridColumn18.Name = "gridColumn18";
            gridColumn18.ToolTip = "远程技能特效图片张数";
            gridColumn18.Visible = true;
            gridColumn18.VisibleIndex = 10;
            gridColumn18.Width = 90;
            //
            //
            //
            gridColumn19.FieldName = "ProFrameDelay";
            gridColumn19.Name = "gridColumn19";
            gridColumn19.ToolTip = "远程技能特效图片循环时间";
            gridColumn19.Visible = true;
            gridColumn19.VisibleIndex = 10;
            gridColumn19.Width = 90;
            //
            //
            //
            gridColumn20.FieldName = "ProStartLight";
            gridColumn20.Name = "gridColumn20";
            gridColumn20.ToolTip = "远程技能光效开启时间";
            gridColumn20.Visible = true;
            gridColumn20.VisibleIndex = 11;
            gridColumn20.Width = 90;
            //
            //
            //
            gridColumn21.FieldName = "ProEndLight";
            gridColumn21.Name = "gridColumn21";
            gridColumn21.ToolTip = "远程技能光效结束时间";
            gridColumn21.Visible = true;
            gridColumn21.VisibleIndex = 12;
            gridColumn21.Width = 90;
            //
            //
            //
            gridColumn22.FieldName = "ProColour";
            gridColumn22.Name = "gridColumn22";
            gridColumn22.ToolTip = "远程技能光效颜色";
            gridColumn22.Visible = true;
            gridColumn22.VisibleIndex = 13;
            gridColumn22.Width = 90;
            //
            //
            //
            gridColumn23.ColumnEdit = EffectImageComboBox;
            gridColumn23.FieldName = "MirEffect";
            gridColumn23.Name = "gridColumn23";
            gridColumn23.ToolTip = "远程技能被攻击者魔法特效库";
            gridColumn23.Visible = true;
            gridColumn23.VisibleIndex = 14;
            gridColumn23.Width = 48;
            //
            //
            //
            gridColumn24.FieldName = "EffectStartIndex";
            gridColumn24.Name = "gridColumn24";
            gridColumn24.ToolTip = "远程技能被攻击者特效起始图片序号";
            gridColumn24.Visible = true;
            gridColumn24.VisibleIndex = 15;
            gridColumn24.Width = 90;
            //
            //
            //
            gridColumn25.FieldName = "EffectFrameCount";
            gridColumn25.Name = "gridColumn25";
            gridColumn25.ToolTip = "远程技能被攻击者特效图片张数";
            gridColumn25.Visible = true;
            gridColumn25.VisibleIndex = 16;
            gridColumn25.Width = 90;
            //
            //
            //
            gridColumn26.FieldName = "EffectFrameDelay";
            gridColumn26.Name = "gridColumn26";
            gridColumn26.ToolTip = "远程技能被攻击者特效图片循环时间";
            gridColumn26.Visible = true;
            gridColumn26.VisibleIndex = 17;
            gridColumn26.Width = 90;
            //
            //
            //
            gridColumn27.FieldName = "EffectStartLight";
            gridColumn27.Name = "gridColumn27";
            gridColumn27.ToolTip = "远程技能被攻击者光效开启时间";
            gridColumn27.Visible = true;
            gridColumn27.VisibleIndex = 18;
            gridColumn27.Width = 90;
            //
            //
            //
            gridColumn28.FieldName = "EffectEndLight";
            gridColumn28.Name = "gridColumn28";
            gridColumn28.ToolTip = "远程技能被攻击者光效结束时间";
            gridColumn28.Visible = true;
            gridColumn28.VisibleIndex = 19;
            gridColumn28.Width = 90;
            //
            //
            //
            gridColumn29.FieldName = "EffectColour";
            gridColumn29.Name = "gridColumn29";
            gridColumn29.ToolTip = "远程技能被攻击者光效颜色";
            gridColumn29.Visible = true;
            gridColumn29.VisibleIndex = 20;
            gridColumn29.Width = 90;
            //
            //
            //
            Action.ColumnEdit = (RepositoryItem)ActionImageComboBox;
            Action.FieldName = "Action";
            Action.Name = "Action";
            Action.ToolTip = "怪物技能魔法特效具体行为动画，比方站立，攻击，范围攻击等等，每一个一行，可以随便选择，并不需要和前面的自定义动画对应";
            Action.Visible = true;
            Action.VisibleIndex = 22;
            ActionImageComboBox.AutoHeight = false;
            ActionImageComboBox.Buttons.AddRange(new EditorButton[1]
            {
        new EditorButton(ButtonPredefines.Combo)
            });
            ActionImageComboBox.Name = "ActionImageComboBox";
            ribbonPage2.Groups.AddRange(new RibbonPageGroup[1]
            {
        ribbonPageGroup2
            });
            //
            //
            //
            gridColumn9.ColumnEdit = (RepositoryItem)EffectImageComboBox;
            gridColumn9.FieldName = "Effect";
            gridColumn9.Name = "gridColumn9";
            gridColumn9.ToolTip = "技能魔法特效库";
            gridColumn9.Visible = true;
            gridColumn9.VisibleIndex = 23;
            gridColumn9.Width = 48;
            //
            //
            //
            EffectImageComboBox.AutoHeight = false;
            EffectImageComboBox.Buttons.AddRange(new EditorButton[1]
            {
        new EditorButton(ButtonPredefines.Combo)
            });
            EffectImageComboBox.Name = "EffectImageComboBox";
            //
            //
            //
            gridColumn10.FieldName = "StartIndex";
            gridColumn10.Name = "gridColumn10";
            gridColumn10.ToolTip = "特效起始图片序号";
            gridColumn10.Visible = true;
            gridColumn10.VisibleIndex = 24;
            gridColumn10.Width = 90;
            //
            //
            //
            gridColumn11.FieldName = "FrameCount";
            gridColumn11.Name = "gridColumn11";
            gridColumn11.ToolTip = "特效图片张数";
            gridColumn11.Visible = true;
            gridColumn11.VisibleIndex = 25;
            gridColumn11.Width = 39;
            //
            //
            //
            gridColumn12.FieldName = "FrameDelay";
            gridColumn12.Name = "gridColumn12";
            gridColumn12.ToolTip = "特效图片循环时间";
            gridColumn12.Visible = true;
            gridColumn12.VisibleIndex = 26;
            gridColumn12.Width = 39;
            //
            //
            //
            gridColumn13.FieldName = "StartLight";
            gridColumn13.Name = "gridColumn13";
            gridColumn13.ToolTip = "光效开启时间";
            gridColumn13.Visible = true;
            gridColumn13.VisibleIndex = 27;
            gridColumn13.Width = 39;
            //
            //
            //
            gridColumn14.FieldName = "EndLight";
            gridColumn14.Name = "gridColumn14";
            gridColumn14.ToolTip = "光效结束时间";
            gridColumn14.Visible = true;
            gridColumn14.VisibleIndex = 28;
            gridColumn14.Width = 39;
            //
            //
            //
            gridColumn15.FieldName = "LightColour";
            gridColumn15.Name = "gridColumn15";
            gridColumn15.ToolTip = "光效颜色";
            gridColumn15.Visible = true;
            gridColumn15.VisibleIndex = 29;
            gridColumn15.Width = 47;
            //
            //
            //
            ribbonPage2.Name = "ribbonPage2";
            ribbonPage2.Text = "数据";
            ribbonPageGroup2.ItemLinks.Add((BarItem)barButtonItem1);
            ribbonPageGroup2.ItemLinks.Add((BarItem)barButtonItem2);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = "数据";
            barButtonItem1.Caption = "导出";
            barButtonItem1.Id = 2;
            barButtonItem1.ImageOptions.Image = (Image)componentResourceManager.GetObject("barButtonItem1.ImageOptions.Image");
            barButtonItem1.ImageOptions.LargeImage = (Image)componentResourceManager.GetObject("barButtonItem1.ImageOptions.LargeImage");
            barButtonItem1.Name = "barButtonItem1";
            barButtonItem1.ItemClick += new ItemClickEventHandler(barButtonItem1_ItemClick);
            barButtonItem2.Caption = "导入";
            barButtonItem2.Id = 3;
            barButtonItem2.ImageOptions.Image = (Image)componentResourceManager.GetObject("barButtonItem2.ImageOptions.Image");
            barButtonItem2.ImageOptions.LargeImage = (Image)componentResourceManager.GetObject("barButtonItem2.ImageOptions.LargeImage");
            barButtonItem2.Name = "barButtonItem2";
            barButtonItem2.ItemClick += new ItemClickEventHandler(barButtonItem2_ItemClick);
            AutoScaleDimensions = new SizeF(7f, 14f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(807, 509);
            Controls.Add((Control)MonsterCustomInfoGridControl);
            Controls.Add((Control)ribbon);
            Name = nameof(MonsterCustomInfoView);
            Ribbon = ribbon;
            Text = "Monster Custom Info";
            ribbon.EndInit();
            MonsterCustomInfoGridControl.EndInit();
            MonsterCustomInfoGridView.EndInit();
            MonsterLookUpEdit.EndInit();
            StatImageComboBox.EndInit();
            EffectImageComboBox.EndInit();
            ActionImageComboBox.EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
