using System;
using DevExpress.XtraBars;
using Library;
using Library.SystemModels;

namespace Server.Views
{
    public partial class MingwenInfoView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MingwenInfoView()
        {
            InitializeComponent();


            MingwenInfoGridControl.DataSource = SMain.Session.GetCollection<MingwenInfo>().Binding;

            MagicImageComboBox.Items.AddEnum<MagicType>();
            SchoolImageComboBox.Items.AddEnum<MagicSchool>();
            ClassImageComboBox.Items.AddEnum<MirClass>();
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SMain.SetUpView(MingwenInfoGridView);
        }

        private void SaveButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            SMain.Session.Save(true);
        }

        private void MingwenInfoView_Load(object sender, EventArgs e)
        {

        }
    }
}