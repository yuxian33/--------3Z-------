using System;
using DevExpress.XtraBars;
using Library;
using Library.SystemModels;

namespace Server.Views
{
    public partial class FubenInfoView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FubenInfoView()
        {
            InitializeComponent();


            FubenInfoGridControl.DataSource = SMain.Session.GetCollection<FubenInfo>().Binding;

            SchoolImageComboBox.Items.AddEnum<FubenSchool>();
            //ClassImageComboBox.Items.AddEnum<MirClass>();
            MonsterLookUpEdit.DataSource = SMain.Session.GetCollection<MonsterInfo>().Binding;
            MapLookUpEdit.DataSource = SMain.Session.GetCollection<MapInfo>().Binding;
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SMain.SetUpView(FubenInfoGridView);
        }

        private void SaveButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            SMain.Session.Save(true);
        }

        private void FubenInfoView_Load(object sender, EventArgs e)
        {

        }
    }
}