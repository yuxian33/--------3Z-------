using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Library;
using Library.SystemModels;

namespace Server.Views
{
    public partial class MeiriQuestInfoView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MeiriQuestInfoView()
        {
            InitializeComponent();

            RequirementImageComboBox.Items.AddEnum<MeiriQuestRequirementType>();
            TaskImageComboBox.Items.AddEnum<MeiriQuestTaskType>();
            RequiredClassImageComboBox.Items.AddEnum<RequiredClass>();

            QuestInfoGridControl.DataSource = SMain.Session.GetCollection<MeiriQuestInfo>().Binding;

            QuestInfoLookUpEdit.DataSource = SMain.Session.GetCollection<MeiriQuestInfo>().Binding;
            ItemInfoLookUpEdit.DataSource = SMain.Session.GetCollection<ItemInfo>().Binding;
            MonsterInfoLookUpEdit.DataSource = SMain.Session.GetCollection<MonsterInfo>().Binding;
            MapInfoLookUpEdit.DataSource = SMain.Session.GetCollection<MapInfo>().Binding;
            NPCLookUpEdit.DataSource = SMain.Session.GetCollection<NPCInfo>().Binding;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SMain.SetUpView(QuestInfoGridView);
            SMain.SetUpView(RequirementsGridView);
            SMain.SetUpView(TaskGridView);
            SMain.SetUpView(MonsterDetailsGridView);
            SMain.SetUpView(RewardsGridView);
        }

        private void SaveButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            SMain.Session.Save(true);
        }
    }
}