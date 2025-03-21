﻿using System;
using DevExpress.XtraBars;
using Library;
using Library.SystemModels;

namespace Server.Views
{
    public partial class MovementInfoView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MovementInfoView()
        {
            InitializeComponent();

            MovementGridControl.DataSource = SMain.Session.GetCollection<MovementInfo>().Binding;



            MapLookUpEdit.DataSource = SMain.Session.GetCollection<MapRegion>().Binding;
            ItemLookUpEdit.DataSource = SMain.Session.GetCollection<ItemInfo>().Binding;
            SpawnLookUpEdit.DataSource = SMain.Session.GetCollection<RespawnInfo>().Binding;
            MonsterSpawnLookUpEdit.DataSource = SMain.Session.GetCollection<RespawnInfo>().Binding;

            MapIconImageComboBox.Items.AddEnum<MapIcon>();
        }

        private void SaveButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            SMain.Session.Save(true);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SMain.SetUpView(MovementGridView);
        }
    }
}