using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Library;
using Library.SystemModels;

namespace Server.Views
{
    public partial class MonsterInfoView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MonsterInfoView()
        {
            InitializeComponent();

            MonsterInfoGridControl.DataSource = SMain.Session.GetCollection<MonsterInfo>().Binding;

            MapLookUpEdit.DataSource = SMain.Session.GetCollection<MapInfo>().Binding;
            ItemLookUpEdit.DataSource = SMain.Session.GetCollection<ItemInfo>().Binding;

            MonsterImageComboBox.Items.AddEnum<MonsterImage>();
            StatComboBox.Items.AddEnum<Stat>();

            StatImageComboBox.Items.AddEnum<MirAnimation>();
            EffectImageComboBox.Items.AddEnum<LibraryFile>();
            ActionImageComboBox.Items.AddEnum<MirAction>();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SMain.SetUpView(MonsterInfoGridView);
            SMain.SetUpView(MonsterInfoStatsGridView);
            SMain.SetUpView(DropsGridView);
            SMain.SetUpView(RespawnsGridView);
        }

        private void SaveButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            SMain.Session.Save(true);
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            ExportImportHelp.ExportExcel(Text, MonsterInfoGridView);
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)null;
                ExportImportHelp.ImportExcel(MonsterInfoGridView, ref dt);
                if (dt == null || dt.Rows.Count <= 0)
                    return;
                for (int rowHandle = 0; rowHandle < dt.Rows.Count; ++rowHandle)
                {
                    MonsterInfo row1 = MonsterInfoGridView.GetRow(rowHandle) as MonsterInfo;
                    DataRow row2 = dt.Rows[rowHandle];
                    row1.Image = (MonsterImage)Enum.Parse(typeof(MonsterImage), Convert.ToString(row2["Image"]));
                    row1.File = (LibraryFile)Enum.Parse(typeof(LibraryFile), Convert.ToString(row2["File"]));
                    row1.AttackSound = (SoundIndex)Enum.Parse(typeof(SoundIndex), Convert.ToString(row2["AttackSound"]));
                    row1.StruckSound = (SoundIndex)Enum.Parse(typeof(SoundIndex), Convert.ToString(row2["StruckSound"]));
                    row1.DieSound = (SoundIndex)Enum.Parse(typeof(SoundIndex), Convert.ToString(row2["DieSound"]));
                    row1.Flag = (MonsterFlag)Enum.Parse(typeof(MonsterFlag), Convert.ToString(row2["Flag"]));
                }
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("操作失败" + ex.Message, "提示");
            }
        }
    }
}