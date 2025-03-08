using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Client.Controls;
using Client.Envir;
using Client.Models;
using Client.UserModels;
using Library;
using Library.Network;
using Library.Network.ClientPackets;
using Library.SystemModels;
using C = Library.Network.ClientPackets;


//Cleaned
namespace Client.Scenes.Views
{
    public sealed class AutoPotionDialog : DXWindow
    {
        #region Properties
        public ClientAutoPotionLink[] Links;
        public ClientAutoFightLink[] FightLinks;

        public AutoPotionRow[] Rows;
        public DXVScrollBar ScrollBar, WaiguaScrollBar;
        public List<DXControl> Lines = new List<DXControl>();

        public override WindowType Type => WindowType.AutoPotionBox;
        public override bool CustomSize => false;
        public override bool AutomaticVisiblity => true;

        public decimal totalExperience, totalGold, totalHuntGold, totalExperiencefen, totalGoldfen, totalHuntGoldfen;
        public int skilledCount, skilledCountfen;
        public DXLabel SummerLabelEx, SummerLabelKill, SummerLabelGold, SummerLabelHuntGold, SummerLabelExfen, SummerLabelKillfen, SummerLabelGoldfen, SummerLabelHuntGoldfen, Guajishijian;
        private static DateTime LastGainEx = DateTime.Now;
        private static DateTime LastTimes = DateTime.Now;
        private static DateTime LastSuijiTimes = DateTime.Now;
        public int LastGainExp;

        private DXTabControl TabControl;

        public DXTab AutoPotionTab;

        public DXTab AutoAttackTab;
        //魔法技能配置
        public DXTab AutoMagicTab;

        public DXTab AutoSystemTab;

        public DXTab AutoHookTab;

        public DXLabel label, label1, label2, label3, label4, label5;
        public DXLabel tylabel;
        public DXCheckBox tyCheckBox, tyCheckBox1, tyCheckBox2, pickupCheckBox, pickupCheckBoxC, safezone, SetShowXue;
        public DXCheckBox zsCheckBox1, zsCheckBox2, zsCheckBox3, zsCheckBox4, zsCheckBox5;
        public DXCheckBox fsCheckBox, fsCheckBox1, fsCheckBox2, fsCheckBox3, fsCheckBox4;
        public DXCheckBox dsCheckBox1, dsCheckBox2, dsCheckBox3, dsCheckBox4, dsCheckBox5;
        public DXCheckBox ckCheckBox, ckCheckBox1, ckCheckBox2, ckCheckBox3;
        public DXLabel zsLabel, fsLabel, dsLabel, ckLabel;

        public bool AttackUpdating;
        private DateTime _protecttime, HuichengTime; //OutputTime;

        public DXLabel AutoTimeLable;
        public DXCheckBox SetAutoOnHookBox;
        public DXCheckBox Guaji;
        public DXCheckBox SetAutoPoisonBox;
        public DXCheckBox SetAutoAvoidBox;
        public DXCheckBox SuijiBox;
        public DXCheckBox SetDeathResurrectionBox;
        public DXCheckBox SetSingleHookSkillsBox;
        public DXComboBox SetSingleHookSkillsComboBox;
        public DXCheckBox SetGroupHookSkillsBox;
        public DXComboBox SetGroupHookSkillsComboBox;
        public DXCheckBox SetSummoningSkillsBox;
        public DXComboBox SetSummoningSkillsComboBox;
        public DXNumberBox TimeBox3;
        public DXNumberBox TimeBox4;
        public DXNumberBox TimeBox5, TimeBox6;
        public DXNumberBox XBox;
        public DXNumberBox YBox;
        public DXNumberBox RBox;
        public DXCheckBox FixedComBox;
        public DXCheckBox SetRandomItemBox;
        public DXComboBox SetRandomItemComboBox;
        public DXCheckBox SetHomeItemBox;
        public DXComboBox SetHomeItemComboBox;
        public DXComboBox ItemTypeBox;
        public DXComboBox SetMagicskillsComboBox;

        public DXCheckBox SuijisBox;
        public DXCheckBox SetShiftBox;
        public DXCheckBox SetDisplayBox;
        public DXCheckBox SetBrightBox;
        public DXCheckBox SetCorpseBox;
        public DXCheckBox SetFlamingSwordBox;
        public DXCheckBox SetDragobRiseBox;
        public DXCheckBox SetBladeStormBox;
        public DXCheckBox SetDefianceBox;
        public DXCheckBox SetMightBox;
        public DXCheckBox SetMagicShieldBox;
        public DXCheckBox SetCelestialBox;
        public DXCheckBox SetFourFlowersBox;
        public DXNumberBox TimeBox1;
        public DXNumberBox TimeBox2;
        public DXCheckBox SetMagicskillsBox;
        public DXComboBox SetMagicskills1ComboBox;
        public DXCheckBox SetMagicskills1Box;
        public DXCheckBox SetRenounceBox;
        public DXCheckBox SetPickUpBox, SetJsPickUpBox, SetCwPickUpBox;
        public DXCheckBox SetPoisonDustBox;
        public DXCheckBox SetEvasionBox;
        public DXCheckBox SerRagingWindBox, Jingyantishi, Bosstishi, Zidongtexiu, ZidongJinpiao, Wupinlanxuhao;



        public static int RowHeight = 20;
        public FortuneCheckerDialog sqglCheckerBox;

        private PickupItem[] SearchRows;
        //魔法技能配置
        private MagicConfig[] MagicSearchRows;

        #endregion

        public AutoPotionDialog()
        {
            TitleLabel.Text = "功能设置";
            HasFooter = true;

            SetClientSize(new Size(290, 428));

            Links = new ClientAutoPotionLink[CartoonGlobals.MaxAutoPotionCount];
            Rows = new AutoPotionRow[CartoonGlobals.MaxAutoPotionCount];

            TabControl = new DXTabControl
            {
                Parent = this,
                Size = base.ClientArea.Size,
                Location = base.ClientArea.Location
            };

            DXTab dXTab = new DXTab();
            dXTab.Parent = TabControl;
            dXTab.Border = true;
            dXTab.TabButton.Label.Text = "保护";
            AutoPotionTab = dXTab;
            DXTab dXTab1 = new DXTab();
            dXTab1.Parent = TabControl;
            dXTab1.Border = true;
            dXTab1.TabButton.Label.Text = "辅助";
            AutoAttackTab = dXTab1;
            AutoAttackTab = dXTab1;
            DXTab mofaPeizhi = new DXTab();
            mofaPeizhi.Parent = TabControl;
            mofaPeizhi.Border = true;
            mofaPeizhi.TabButton.Label.Text = "魔法";
            AutoMagicTab = mofaPeizhi;
            DXTab dXTab2 = new DXTab();
            dXTab2.Parent = TabControl;
            dXTab2.Border = true;
            dXTab2.TabButton.Label.Text = "拾取";
            AutoSystemTab = dXTab2;
            DXTab dXTab3 = new DXTab();
            dXTab3.Parent = TabControl;
            dXTab3.Border = true;
            dXTab3.TabButton.Label.Text = "挂机";
            AutoHookTab = dXTab3;


            //AttackLinks = new ClientAutoAttackLink[8];
            //AttackRows = new AutoAttackRow[8];
            DXControl parent = new DXControl
            {
                Parent = AutoAttackTab,
                Size = new Size(AutoAttackTab.Size.Width - 2, AutoAttackTab.Size.Height),
                Location = new Point(2, 1)
            };
            /*for (int i = 0; i < AttackLinks.Length; i++)
            {
                AutoAttackRow autoAttackRow = AttackRows[i] = new AutoAttackRow
                {
                    Parent = parent,
                    Location = new Point(1, 1 + (RowHeight + 6) * i),
                    Index = i
                };
            }*/
            Links = new ClientAutoPotionLink[8];
            Rows = new AutoPotionRow[8];
            ScrollBar = new DXVScrollBar
            {
                Parent = AutoPotionTab,
                Size = new Size(14, 395),
                Location = new Point(ClientArea.Right - 28, 6),
                VisibleSize = ClientArea.Height,
                MaxValue = Rows.Length * 50 - 2
            };

            WaiguaScrollBar = new DXVScrollBar
            {
                Size = new Size(14, 395),
                Location = new Point(ClientArea.Right - 28, 6),
                VisibleSize = ClientArea.Height + 300,
                Parent = AutoAttackTab,
                //MaxValue = Lines.Count * 20 - 2
            };
            WaiguaScrollBar.ValueChanged += (o, e) => UpdateWaiguaScrollBar();
            MouseWheel += WaiguaScrollBar.DoMouseWheel;

            int y = 0;

            label1 = new DXLabel
            {
                Parent = AutoAttackTab,
                Text = "————[ 战士技能 ]————",
                ForeColour = Color.Beige

            };
            label1.Location = new Point(AutoAttackTab.Size.Width / 4 - label1.Size.Width + 130, y += 20);
            label1.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(label1);

            zsCheckBox1 = new DXCheckBox
            {
                Parent = AutoAttackTab,
                Label = { Text = "破血狂杀" },

            };
            zsCheckBox1.Location = new Point(AutoAttackTab.Size.Width / 4 - zsCheckBox1.Size.Width + 40, y = 0);
            zsCheckBox1.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.PoxueToggle { Poxue = zsCheckBox1.Checked });
            };
            zsCheckBox1.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(zsCheckBox1);


            zsCheckBox5 = new DXCheckBox
            {
                Parent = AutoAttackTab,
                Label = { Text = "铁布衫" },

            };
            zsCheckBox5.Location = new Point(AutoAttackTab.Size.Width / 4 - zsCheckBox5.Size.Width + 170, y = 0);
            zsCheckBox5.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.TiebuToggle { Tiebu = zsCheckBox5.Checked });
            };
            zsCheckBox5.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(zsCheckBox5);


            zsCheckBox2 = new DXCheckBox
            {
                Parent = AutoAttackTab,
                Label = { Text = "烈火剑法" },
            };
            zsCheckBox2.Location = new Point(AutoAttackTab.Size.Width / 4 - zsCheckBox2.Size.Width + 40, y = 20);
            zsCheckBox2.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.LiehuoToggle { Liehuo = zsCheckBox2.Checked });
            };
            zsCheckBox2.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(zsCheckBox2);


            zsCheckBox3 = new DXCheckBox
            {
                Parent = AutoAttackTab,
                Label = { Text = "翔空剑法" },
            };
            zsCheckBox3.Location = new Point(AutoAttackTab.Size.Width / 4 - zsCheckBox3.Size.Width + 170, y = 20);
            zsCheckBox3.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.XuangkongToggle { Xuangkong = zsCheckBox3.Checked });
            };
            zsCheckBox3.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(zsCheckBox3);


            zsCheckBox4 = new DXCheckBox
            {
                Parent = AutoAttackTab,
                Label = { Text = "莲月剑法" },
            };
            zsCheckBox4.Location = new Point(AutoAttackTab.Size.Width / 4 - zsCheckBox4.Size.Width + 40, y = 40);
            zsCheckBox4.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.LianyueToggle { Lianyue = zsCheckBox4.Checked });
            };
            zsCheckBox4.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(zsCheckBox4);

            //为了空行
            label5 = new DXLabel
            {
                Parent = AutoAttackTab,
                Text = "",
                ForeColour = Color.Beige,
                Visible = false,
            };
            label5.Location = new Point(AutoAttackTab.Size.Width / 4 - label5.Size.Width + 170, y = 40);
            label5.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(label5);

            label2 = new DXLabel
            {
                Parent = AutoAttackTab,
                Text = "————[ 法师技能 ]————",
                ForeColour = Color.Beige
            };
            label2.Location = new Point(AutoAttackTab.Size.Width / 4 - label2.Size.Width + 130, y += 80);
            label2.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(label2);

            //为了空行
            label5 = new DXLabel
            {
                Parent = AutoAttackTab,
                Text = "",
                ForeColour = Color.Beige,
                Visible = false,
            };
            label5.Location = new Point(AutoAttackTab.Size.Width / 4 - label5.Size.Width + 170, y = 80);
            label5.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(label5);

            fsCheckBox1 = new DXCheckBox
            {
                Parent = AutoAttackTab,
                Label = { Text = "凝血离魂" },
            };
            fsCheckBox1.Location = new Point(AutoAttackTab.Size.Width / 4 - fsCheckBox1.Size.Width + 40, y = 100);
            fsCheckBox1.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.NingxueToggle { Ningxue = fsCheckBox1.Checked });
            };
            fsCheckBox1.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(fsCheckBox1);

            fsCheckBox = new DXCheckBox
            {
                Parent = AutoAttackTab,
                Label = { Text = "魔法盾" },
            };
            fsCheckBox.Location = new Point(AutoAttackTab.Size.Width / 4 - fsCheckBox.Size.Width + 170, y = 100);
            fsCheckBox.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.MofadunToggle { Mofadun = fsCheckBox.Checked });
            };
            fsCheckBox.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(fsCheckBox);


            fsCheckBox2 = new DXCheckBox
            {
                Parent = AutoAttackTab,
                Label = { Text = "天打雷劈" },
            };
            fsCheckBox2.Location = new Point(AutoAttackTab.Size.Width / 4 - fsCheckBox2.Size.Width + 40, y = 120);
            fsCheckBox2.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.TiandaToggle { Tianda = fsCheckBox2.Checked });
            };
            fsCheckBox2.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(fsCheckBox2);

            fsCheckBox3 = new DXCheckBox
            {
                Parent = AutoAttackTab,
                Label = { Text = "魔光盾" },
            };
            fsCheckBox3.Location = new Point(AutoAttackTab.Size.Width / 4 - fsCheckBox3.Size.Width + 170, y = 120);
            fsCheckBox3.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.MoguangdunToggle { Moguangdun = fsCheckBox3.Checked });
            };
            fsCheckBox3.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(fsCheckBox3);


            label3 = new DXLabel
            {

                Parent = AutoAttackTab,

                Text = "————[ 道士技能 ]————",
                ForeColour = Color.Beige
            };
            label3.Location = new Point(AutoAttackTab.Size.Width / 4 - label3.Size.Width + 130, y += 140);
            label3.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(label3);

            //为了空行
            label5 = new DXLabel
            {
                Parent = AutoAttackTab,
                Text = "",
                ForeColour = Color.Beige,
                Visible = false,
            };
            label5.Location = new Point(AutoAttackTab.Size.Width / 4 - label5.Size.Width + 170, y = 140);
            label5.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(label5);


            dsCheckBox1 = new DXCheckBox
            {
                Parent = AutoAttackTab,
                Label = { Text = "阴阳法环" },

            };
            dsCheckBox1.Location = new Point(AutoAttackTab.Size.Width / 4 - dsCheckBox1.Size.Width + 40, y = 160);
            dsCheckBox1.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.YinyangToggle { Yinyang = dsCheckBox1.Checked });
            };
            dsCheckBox1.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(dsCheckBox1);


            dsCheckBox2 = new DXCheckBox
            {
                Parent = AutoAttackTab,
                Label = { Text = "移花接玉" },

            };
            dsCheckBox2.Location = new Point(AutoAttackTab.Size.Width / 4 - dsCheckBox2.Size.Width + 170, y = 160);
            dsCheckBox2.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.YihuaToggle { Yihua = dsCheckBox2.Checked });
            };
            dsCheckBox2.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(dsCheckBox2);


            dsCheckBox3 = new DXCheckBox
            {
                Parent = AutoAttackTab,
                Label = { Text = "传染" },

            };
            dsCheckBox3.Location = new Point(AutoAttackTab.Size.Width / 4 - dsCheckBox3.Size.Width + 40, y = 180);
            dsCheckBox3.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.YincangToggle { Yincang = dsCheckBox3.Checked });
            };
            dsCheckBox3.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(dsCheckBox3);


            dsCheckBox4 = new DXCheckBox
            {
                Parent = AutoAttackTab,
                Label = { Text = "灭魂火符" },

            };
            dsCheckBox4.Location = new Point(AutoAttackTab.Size.Width / 4 - dsCheckBox4.Size.Width + 170, y = 180);
            dsCheckBox4.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(dsCheckBox4);

            dsCheckBox5 = new DXCheckBox
            {
                Parent = AutoAttackTab,
                Label = { Text = "自动炎魔" },

            };
            dsCheckBox5.Location = new Point(AutoAttackTab.Size.Width / 4 - dsCheckBox5.Size.Width + 40, y = 200);
            dsCheckBox5.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.HuanduToggle { Huandu = dsCheckBox5.Checked });
            };
            dsCheckBox5.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(dsCheckBox5);

            //为了空行
            label5 = new DXLabel
            {
                Parent = AutoAttackTab,
                Text = "",
                ForeColour = Color.Beige,
                Visible = false,
            };
            label5.Location = new Point(AutoAttackTab.Size.Width / 4 - label5.Size.Width + 170, y = 200);
            label5.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(label5);

            label4 = new DXLabel
            {
                Parent = AutoAttackTab,
                Text = "————[ 刺客技能 ]————",
                ForeColour = Color.Beige
            };
            label4.Location = new Point(AutoAttackTab.Size.Width / 4 - label4.Size.Width + 130, y += 220);
            label4.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(label4);

            //为了空行
            label5 = new DXLabel
            {
                Parent = AutoAttackTab,
                Text = "",
                ForeColour = Color.Beige,
                Visible = false,
            };
            label5.Location = new Point(AutoAttackTab.Size.Width / 4 - label5.Size.Width + 170, y = 220);
            label5.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(label5);

            ckCheckBox = new DXCheckBox
            {
                Parent = AutoAttackTab,
                Label = { Text = "一键四花" },
                ForeColour = Color.Red,
            };
            ckCheckBox.Location = new Point(AutoAttackTab.Size.Width / 4 - ckCheckBox.Size.Width + 40, y = 240);
            ckCheckBox.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.SilianToggle { Silian = ckCheckBox.Checked });
            };
            ckCheckBox.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(ckCheckBox);

            ckCheckBox1 = new DXCheckBox
            {
                Parent = AutoAttackTab,
                Label = { Text = "风之闪避" },
                ForeColour = Color.Red,
            };
            ckCheckBox1.Location = new Point(AutoAttackTab.Size.Width / 4 - ckCheckBox1.Size.Width + 170, y = 240);
            ckCheckBox1.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.ShanbiToggle { Shanbi = ckCheckBox1.Checked });
            };
            ckCheckBox1.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(ckCheckBox1);

            ckCheckBox2 = new DXCheckBox
            {
                Parent = AutoAttackTab,
                Label = { Text = "风之守护" },
                ForeColour = Color.Red,
            };
            ckCheckBox2.Location = new Point(AutoAttackTab.Size.Width / 4 - ckCheckBox2.Size.Width + 40, y = 260);
            ckCheckBox2.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.ShouhuToggle { Shouhu = ckCheckBox2.Checked });
            };
            ckCheckBox2.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(ckCheckBox2);

            ckCheckBox3 = new DXCheckBox
            {
                Parent = AutoAttackTab,
                Label = { Text = "致命雷光" },
                ForeColour = Color.Red,
            };
            ckCheckBox3.Location = new Point(AutoAttackTab.Size.Width / 4 - ckCheckBox3.Size.Width + 170, y = 260);
            ckCheckBox3.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.LeiguangToggle { Leiguang = ckCheckBox3.Checked });
            };
            ckCheckBox3.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(ckCheckBox3);


            label = new DXLabel
            {
                Parent = AutoAttackTab,
                Text = "————[ 通用辅助 ]————",
                ForeColour = Color.Beige
            };
            label.Location = new Point(AutoAttackTab.Size.Width / 4 - label.Size.Width + 130, y += 280);
            label.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(label);

            //为了空行
            label5 = new DXLabel
            {
                Parent = AutoAttackTab,
                Text = "",
                ForeColour = Color.Beige,
                Visible = false,
            };
            label5.Location = new Point(AutoAttackTab.Size.Width / 4 - label5.Size.Width + 170, y = 280);
            label5.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(label5);

            tyCheckBox = new DXCheckBox
            {
                Parent = AutoAttackTab,
                Label = { Text = "免助跑" },

            };
            tyCheckBox.Location = new Point(AutoAttackTab.Size.Width / 4 - tyCheckBox.Size.Width + 40, y = 300);
            tyCheckBox.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.MianpaoToggle { Mianpao = tyCheckBox.Checked });
            };
            tyCheckBox.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(tyCheckBox);


            tyCheckBox1 = new DXCheckBox
            {
                Parent = AutoAttackTab,
                Label = { Text = "免Shift" },
            };
            tyCheckBox1.Location = new Point(AutoAttackTab.Size.Width / 4 - tyCheckBox1.Size.Width + 170, y = 300);
            tyCheckBox1.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.MianshiftToggle { Mianshift = tyCheckBox1.Checked });
            };
            tyCheckBox1.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(tyCheckBox1);

            tyCheckBox2 = new DXCheckBox
            {
                Parent = AutoAttackTab,
                Label = { Text = "清理尸体" },
            };
            tyCheckBox2.Location = new Point(AutoAttackTab.Size.Width / 4 - tyCheckBox2.Size.Width + 40, y = 320);
            tyCheckBox2.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.QingshitiToggle { Qingshiti = tyCheckBox2.Checked });
            };
            tyCheckBox2.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(tyCheckBox2);

            SetShowXue = new DXCheckBox
            {
                Parent = AutoAttackTab,
                Label = { Text = "数字显血" },
            };
            SetShowXue.Location = new Point(AutoAttackTab.Size.Width / 4 - SetShowXue.Size.Width + 170, y = 320);
            SetShowXue.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.SetShowHealthToggle { SetShowHealth = SetShowXue.Checked });
            };
            SetShowXue.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(SetShowXue);

            pickupCheckBox = new DXCheckBox
            {
                Parent = AutoAttackTab,
                Label = { Text = "角色快速拾取" },
            };
            pickupCheckBox.Location = new Point(AutoAttackTab.Size.Width / 4 - pickupCheckBox.Size.Width + 40, y = 340);
            //pickupCheckBox.CheckedChanged += (o, e) => { pickupCheckBoxC.Checked = !pickupCheckBox.Checked; };
            pickupCheckBox.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.JueseshiquToggle { Jueseshiqu = pickupCheckBox.Checked });
            };
            pickupCheckBox.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(pickupCheckBox);


            pickupCheckBoxC = new DXCheckBox
            {
                Parent = AutoAttackTab,
                Label = { Text = "宠物快速拾取" },
            };
            pickupCheckBoxC.Location = new Point(AutoAttackTab.Size.Width / 4 - pickupCheckBoxC.Size.Width + 170, y = 340);
            //pickupCheckBoxC.CheckedChanged += (o, e) => { pickupCheckBox.Checked = !pickupCheckBoxC.Checked; };
            pickupCheckBoxC.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.ChongwushiquToggle { Chongwushiqu = pickupCheckBoxC.Checked });
            };
            pickupCheckBoxC.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(pickupCheckBoxC);


            safezone = new DXCheckBox
            {
                Parent = AutoAttackTab,
                Label = { Text = "在安全处有效" },
            };
            safezone.Location = new Point(AutoAttackTab.Size.Width / 4 - safezone.Size.Width + 40, y = 360);
            safezone.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.AqcwxToggle { Aqcwx = safezone.Checked });
            };
            safezone.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(safezone);


            Jingyantishi = new DXCheckBox
            {
                Parent = AutoAttackTab,
                Label = { Text = "组队数字显血" },
            };
            Jingyantishi.Location = new Point(AutoAttackTab.Size.Width / 4 - Jingyantishi.Size.Width + 170, y = 360);
            Jingyantishi.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.JingyantishiToggle { Jingyantishi = Jingyantishi.Checked });
            };
            Jingyantishi.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(Jingyantishi);

            Bosstishi = new DXCheckBox
            {
                Parent = AutoAttackTab,
                Label = { Text = "Boss提示" },
            };
            Bosstishi.Location = new Point(AutoAttackTab.Size.Width / 4 - Bosstishi.Size.Width + 40, y = 380);
            Bosstishi.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.BosstishiToggle { Bosstishi = Bosstishi.Checked });
            };
            Bosstishi.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(Bosstishi);

            //自动特修
            Zidongtexiu = new DXCheckBox
            {
                Parent = AutoAttackTab,
                Label = { Text = "自动特修" },
            };
            Zidongtexiu.Location = new Point(AutoAttackTab.Size.Width / 4 - Zidongtexiu.Size.Width + 170, y = 380);
            Zidongtexiu.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.ZidongtexiuToggle { Zidongtexiu = Zidongtexiu.Checked });
            };
            Zidongtexiu.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(Zidongtexiu);

            //自动换金票
            ZidongJinpiao = new DXCheckBox
            {
                Parent = AutoAttackTab,
                Label = { Text = "自动换金票" },
            };
            ZidongJinpiao.Location = new Point(AutoAttackTab.Size.Width / 4 - ZidongJinpiao.Size.Width + 40, y = 400);
            ZidongJinpiao.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.ZidongJinpiaoToggle { ZidongJinpiao = ZidongJinpiao.Checked });
            };
            ZidongJinpiao.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(ZidongJinpiao);

            //备用备用备用
            Wupinlanxuhao = new DXCheckBox
            {
                Parent = AutoAttackTab,
                Label = { Text = "备用备用备用" },
            };
            Wupinlanxuhao.Location = new Point(AutoAttackTab.Size.Width / 4 - Wupinlanxuhao.Size.Width + 170, y = 400);
            Wupinlanxuhao.MouseClick += (o, e) =>
            {
                CEnvir.Enqueue(new C.WupinlanxuhaoToggle { Wupinlanxuhao = Wupinlanxuhao.Checked });
            };
            Wupinlanxuhao.MouseWheel += WaiguaScrollBar.DoMouseWheel;
            Lines.Add(Wupinlanxuhao);

            //为挂机爆率分开设置原因专门设置的按钮“开始挂机”
            Guaji = new DXCheckBox
            {
                Parent = AutoAttackTab,
                Label = { Text = "开始挂机" },
                Visible = false
            };
            Guaji.Location = new Point(AutoAttackTab.Size.Width / 4 - Guaji.Size.Width + 550, y = 420);

            UpdateWaiguaScrollBar();

            /*
            DXLabel dxLabel4 = new DXLabel();
            dxLabel4.Text = "┌─启动───";
            dxLabel4.Outline = true;
            dxLabel4.Parent = (DXControl)AutoHookTab;
            dxLabel4.Location = new Point(0, 10);
            */
            DXLabel dxLabel5 = new DXLabel();
            dxLabel5.Text = "┌─功能──────────────────┐";
            dxLabel5.Outline = true;
            dxLabel5.Parent = (DXControl)AutoHookTab;
            dxLabel5.Location = new Point(0, 40);
            DXLabel dxLabel6 = new DXLabel();
            dxLabel6.Text = "├─技能──────────────────┤";
            dxLabel6.Outline = true;
            dxLabel6.Parent = (DXControl)AutoHookTab;
            dxLabel6.Location = new Point(0, 100);
            DXLabel dxLabel7 = new DXLabel();
            dxLabel7.Text = "├─保护──────────────────┤";
            dxLabel7.Outline = true;
            dxLabel7.Parent = (DXControl)AutoHookTab;
            dxLabel7.Location = new Point(0, 205);
            DXLabel dxLabel8 = new DXLabel();
            dxLabel8.Text = "├─区域──────────────────┤";
            dxLabel8.Outline = true;
            dxLabel8.Parent = (DXControl)AutoHookTab;
            dxLabel8.Location = new Point(0, 140);
            DXLabel dxLabel55 = new DXLabel();
            dxLabel55.Text = "├─统计──────────────────┤";
            dxLabel55.Outline = true;
            dxLabel55.Parent = (DXControl)AutoHookTab;
            dxLabel55.Location = new Point(0, 265);
            DXLabel dxLabel56 = new DXLabel();
            dxLabel56.Text = "└─重置──────────────────┘";
            dxLabel56.Outline = true;
            dxLabel56.Parent = AutoHookTab;
            dxLabel56.Location = new Point(0, 385);
            //DXLabel dxLabel9 = new DXLabel();
            //dxLabel9.Text = "";
            //dxLabel9.Outline = true;
            //dxLabel9.ForeColour = Color.Yellow;
            //dxLabel9.Parent = (DXControl)AutoHookTab;
            //dxLabel9.Location = new Point(10, 15);
            DXLabel dxLabel10 = new DXLabel();
            dxLabel10.Text = "";
            dxLabel10.ForeColour = Color.Beige;
            dxLabel10.Outline = true;
            dxLabel10.Parent = (DXControl)AutoHookTab;
            dxLabel10.Location = new Point(10, 15);
            AutoTimeLable = dxLabel10;
            DXCheckBox dxCheckBox20 = new DXCheckBox();
            dxCheckBox20.Label.Text = "开始挂机";
            dxCheckBox20.Label.ForeColour = Color.LightCyan;
            dxCheckBox20.Parent = AutoHookTab;
            dxCheckBox20.Checked = false;
            SetAutoOnHookBox = dxCheckBox20;
            SetAutoOnHookBox.Location = new Point(270 - SetAutoOnHookBox.Size.Width, 15);
            SetAutoOnHookBox.CheckedChanged += (EventHandler<EventArgs>)((o, e) =>
            {
                if (GameScene.Game.Observer || GameScene.Game.AutoPotionBox.Updating)
                    return;
                if (SetAutoOnHookBox.Checked && GameScene.Game.User.AutoTime == 0L)
                {
                    SetAutoOnHookBox.Checked = false;
                }
                else
                {
                    CEnvir.Enqueue(new AutoFightConfChanged()
                    {
                        Enabled = SetAutoOnHookBox.Checked,
                        Slot = AutoSetConf.SetAutoOnHookBox
                    });
                }

                if (SetAutoOnHookBox.Checked)
                    GameScene.Game.ReceiveChat("自动挂机开启", MessageType.System);
                else
                    GameScene.Game.ReceiveChat("自动挂机关闭", MessageType.System);
            });
            /*
            DXCheckBox dxCheckBox21 = new DXCheckBox();
            dxCheckBox21.Label.Text = "自动捡取";
            dxCheckBox21.Parent = (DXControl)AutoHookTab;
            dxCheckBox21.Checked = false;
            SetPickUpBox = dxCheckBox21;
            SetPickUpBox.Location = new Point(250 - SetPickUpBox.Size.Width, 130);
            SetPickUpBox.CheckedChanged += (EventHandler<EventArgs>)((o, e) =>
            {
                if (GameScene.Game.Observer || GameScene.Game.AutoPotionBox.Updating)
                    return;
                CEnvir.Enqueue((Packet)new AutoFightConfChanged()
                {
                    Enabled = SetPickUpBox.Checked,
                    Slot = AutoSetConf.SetPickUpBox
                });
            });
            */
            DXCheckBox dxCheckBox22 = new DXCheckBox();
            dxCheckBox22.Label.Text = "自动上毒";
            dxCheckBox22.Parent = (DXControl)AutoHookTab;
            dxCheckBox22.Checked = false;
            SetAutoPoisonBox = dxCheckBox22;
            SetAutoPoisonBox.Location = new Point(90 - SetAutoPoisonBox.Size.Width, 60);
            SetAutoPoisonBox.CheckedChanged += (EventHandler<EventArgs>)((o, e) =>
            {
                if (GameScene.Game.Observer || GameScene.Game.AutoPotionBox.Updating)
                    return;
                CEnvir.Enqueue((Packet)new AutoFightConfChanged()
                {
                    Enabled = SetAutoPoisonBox.Checked,
                    Slot = AutoSetConf.SetAutoPoisonBox
                });
            });
            DXCheckBox dxCheckBox23 = new DXCheckBox();
            dxCheckBox23.Label.Text = "自动躲避";
            dxCheckBox23.Parent = (DXControl)AutoHookTab;
            dxCheckBox23.Checked = false;
            SetAutoAvoidBox = dxCheckBox23;
            SetAutoAvoidBox.Location = new Point(180 - SetAutoAvoidBox.Size.Width, 60);
            SetAutoAvoidBox.CheckedChanged += (EventHandler<EventArgs>)((o, e) =>
            {
                if (GameScene.Game.Observer || GameScene.Game.AutoPotionBox.Updating)
                    return;
                CEnvir.Enqueue((Packet)new AutoFightConfChanged()
                {
                    Enabled = SetAutoAvoidBox.Checked,
                    Slot = AutoSetConf.SetAutoAvoidBox
                });
            });
            DXCheckBox dxCheckBox24 = new DXCheckBox();
            dxCheckBox24.Label.Text = "死亡回城";
            dxCheckBox24.Parent = (DXControl)AutoHookTab;
            dxCheckBox24.Checked = false;
            SetDeathResurrectionBox = dxCheckBox24;
            SetDeathResurrectionBox.Location = new Point(270 - SetDeathResurrectionBox.Size.Width, 60);
            SetDeathResurrectionBox.CheckedChanged += (EventHandler<EventArgs>)((o, e) =>
            {
                if (GameScene.Game.Observer || GameScene.Game.AutoPotionBox.Updating)
                    return;
                CEnvir.Enqueue((Packet)new AutoFightConfChanged()
                {
                    Enabled = SetDeathResurrectionBox.Checked,
                    Slot = AutoSetConf.SetDeathResurrectionBox
                });
            });
            DXNumberBox dxNumberBox63 = new DXNumberBox();
            dxNumberBox63.Parent = (DXControl)AutoHookTab;
            dxNumberBox63.Location = new Point(20, 80);
            dxNumberBox63.Size = new Size(80, 20);
            dxNumberBox63.ValueTextBox.Size = new Size(30, 18);
            dxNumberBox63.MaxValue = 300L;
            dxNumberBox63.MinValue = 0L;
            dxNumberBox63.UpButton.Location = new Point(53, 1);
            TimeBox5 = dxNumberBox63;
            TimeBox5.ValueTextBox.ValueChanged += (EventHandler<EventArgs>)((o, e) =>
            {
                if (GameScene.Game.Observer || GameScene.Game.AutoPotionBox.Updating || TimeBox5.ValueTextBox.Value <= 0L)
                    return;
                CEnvir.Enqueue((Packet)new AutoFightConfChanged()
                {
                    Enabled = SuijiBox.Checked,
                    Slot = AutoSetConf.SuijiBox,
                    TimeCount = (int)TimeBox5.Value
                });
            });
            DXNumberBox dxNumberBox64 = new DXNumberBox();
            dxNumberBox64.Parent = (DXControl)AutoHookTab;
            dxNumberBox64.Location = new Point(152, 80);
            dxNumberBox64.Size = new Size(80, 20);
            dxNumberBox64.ValueTextBox.Size = new Size(30, 18);
            dxNumberBox64.MaxValue = 300L;
            dxNumberBox64.MinValue = 0L;
            dxNumberBox64.UpButton.Location = new Point(53, 1);
            TimeBox6 = dxNumberBox64;
            TimeBox6.ValueTextBox.ValueChanged += (EventHandler<EventArgs>)((o, e) =>
            {
                if (GameScene.Game.Observer || GameScene.Game.AutoPotionBox.Updating || TimeBox6.ValueTextBox.Value <= 0L)
                    return;
                CEnvir.Enqueue((Packet)new AutoFightConfChanged()
                {
                    Enabled = SuijisBox.Checked,
                    Slot = AutoSetConf.SuijisBox,
                    TimeCount = (int)TimeBox6.Value
                });
            });
            DXLabel Miaob = new DXLabel();
            Miaob.Text = "";
            Miaob.Outline = true;
            Miaob.Parent = (DXControl)AutoHookTab;
            Miaob.Location = new Point(140, 215);
            DXCheckBox Miaobcheck = new DXCheckBox();
            Miaobcheck.Label.Text = "随机";
            Miaobcheck.Parent = AutoHookTab;
            Miaobcheck.Checked = false;
            SuijiBox = Miaobcheck;
            SuijiBox.Hint = "指定时间内目标未死亡自动随机";
            SuijiBox.Location = new Point(138 - SuijiBox.Size.Width, 80);
            SuijiBox.CheckedChanged += (EventHandler<EventArgs>)((o, e) =>
            {
                if (GameScene.Game.Observer || GameScene.Game.AutoPotionBox.Updating || TimeBox5.ValueTextBox.Value <= 0L)
                    return;
                CEnvir.Enqueue((Packet)new AutoFightConfChanged()
                {
                    Enabled = SuijiBox.Checked,
                    Slot = AutoSetConf.SuijiBox,
                    TimeCount = (int)TimeBox5.Value
                });
            });
            DXCheckBox Miaobchecks = new DXCheckBox();
            Miaobchecks.Label.Text = "随机";
            Miaobchecks.Parent = AutoHookTab;
            Miaobchecks.Checked = false;
            SuijisBox = Miaobchecks;
            SuijisBox.Hint = "每指定时间自动随机";
            SuijisBox.Location = new Point(270 - SuijisBox.Size.Width, 80);
            SuijisBox.CheckedChanged += ((o, e) =>
            {
                if (GameScene.Game.Observer || GameScene.Game.AutoPotionBox.Updating || TimeBox5.ValueTextBox.Value <= 0L)
                    return;
                CEnvir.Enqueue(new AutoFightConfChanged()
                {
                    Enabled = SuijisBox.Checked,
                    Slot = AutoSetConf.SuijisBox,
                    TimeCount = (int)TimeBox6.Value
                });
            });
            DXCheckBox dxCheckBox25 = new DXCheckBox();
            dxCheckBox25.Label.Text = "单体技能";
            dxCheckBox25.Parent = (DXControl)AutoHookTab;
            dxCheckBox25.Checked = false;
            SetSingleHookSkillsBox = dxCheckBox25;
            SetSingleHookSkillsBox.Location = new Point(100 - SetSingleHookSkillsBox.Size.Width, 120);
            SetSingleHookSkillsBox.CheckedChanged += (EventHandler<EventArgs>)((o, e) =>
            {
                if (GameScene.Game.Observer || GameScene.Game.AutoPotionBox.Updating || !(SetSingleHookSkillsComboBox.SelectedItem is MagicType))
                    return;
                MagicType selectedItem = (MagicType)SetSingleHookSkillsComboBox.SelectedItem;
                CEnvir.Enqueue((Packet)new AutoFightConfChanged()
                {
                    Enabled = SetSingleHookSkillsBox.Checked,
                    Slot = AutoSetConf.SetSingleHookSkillsBox,
                    MagicIndex = selectedItem
                });
            });
            DXComboBox dxComboBox3 = new DXComboBox();
            dxComboBox3.Parent = (DXControl)AutoHookTab;
            dxComboBox3.Location = new Point(145, 120);
            dxComboBox3.Size = new Size(100, 16);
            SetSingleHookSkillsComboBox = dxComboBox3;
            SetSingleHookSkillsComboBox.SelectedItemChanged += (EventHandler<EventArgs>)((o, e) =>
            {
                if (GameScene.Game.Observer || GameScene.Game.AutoPotionBox.Updating || !(SetSingleHookSkillsComboBox.SelectedItem is MagicType))
                    return;
                MagicType selectedItem = (MagicType)SetSingleHookSkillsComboBox.SelectedItem;
                CEnvir.Enqueue((Packet)new AutoFightConfChanged()
                {
                    Enabled = SetSingleHookSkillsBox.Checked,
                    Slot = AutoSetConf.SetSingleHookSkillsBox,
                    MagicIndex = selectedItem
                });
            });
            DXLabel dxLabel11 = new DXLabel();
            dxLabel11.Text = "X坐标:";
            dxLabel11.Parent = (DXControl)AutoHookTab;
            dxLabel11.Location = new Point(25, 160);
            DXNumberBox dxNumberBox3 = new DXNumberBox();
            dxNumberBox3.Parent = (DXControl)AutoHookTab;
            dxNumberBox3.Location = new Point(65, 160);
            dxNumberBox3.Size = new Size(80, 20);
            dxNumberBox3.ValueTextBox.Size = new Size(40, 18);
            dxNumberBox3.MaxValue = 10000L;
            dxNumberBox3.MinValue = 0L;
            dxNumberBox3.UpButton.Location = new Point(63, 1);
            XBox = dxNumberBox3;
            DXLabel dxLabel12 = new DXLabel();
            dxLabel12.Text = "Y坐标:";
            dxLabel12.Parent = (DXControl)AutoHookTab;
            dxLabel12.Location = new Point(150, 160);
            DXNumberBox dxNumberBox4 = new DXNumberBox();
            dxNumberBox4.Parent = (DXControl)AutoHookTab;
            dxNumberBox4.Location = new Point(190, 160);
            dxNumberBox4.Size = new Size(80, 20);
            dxNumberBox4.ValueTextBox.Size = new Size(40, 18);
            dxNumberBox4.MaxValue = 10000L;
            dxNumberBox4.MinValue = 0L;
            dxNumberBox4.UpButton.Location = new Point(63, 1);
            YBox = dxNumberBox4;
            DXLabel dxLabel13 = new DXLabel();
            dxLabel13.Text = "范围:";
            dxLabel13.Parent = (DXControl)AutoHookTab;
            dxLabel13.Location = new Point(28, 185);
            DXNumberBox dxNumberBox5 = new DXNumberBox();
            dxNumberBox5.Parent = (DXControl)AutoHookTab;
            dxNumberBox5.Location = new Point(65, 185);
            dxNumberBox5.Size = new Size(80, 20);
            dxNumberBox5.ValueTextBox.Size = new Size(40, 18);
            dxNumberBox5.MaxValue = 100L;
            dxNumberBox5.MinValue = 0L;
            dxNumberBox5.UpButton.Location = new Point(63, 1);
            RBox = dxNumberBox5;
            DXCheckBox dxCheckBox26 = new DXCheckBox();
            dxCheckBox26.Label.Text = "定点挂机";
            dxCheckBox26.Parent = (DXControl)AutoHookTab;
            dxCheckBox26.Checked = false;
            FixedComBox = dxCheckBox26;
            FixedComBox.Location = new Point(270 - FixedComBox.Size.Width, 185);
            DXLabel dxLabel14 = new DXLabel();
            dxLabel14.Text = "血值低于";
            dxLabel14.Outline = true;
            dxLabel14.Parent = (DXControl)AutoHookTab;
            dxLabel14.Location = new Point(10, 225);
            DXNumberBox dxNumberBox6 = new DXNumberBox();
            dxNumberBox6.Parent = (DXControl)AutoHookTab;
            dxNumberBox6.Location = new Point(65, 225);
            dxNumberBox6.Size = new Size(80, 20);
            dxNumberBox6.ValueTextBox.Size = new Size(40, 18);
            dxNumberBox6.MaxValue = 100L;
            dxNumberBox6.MinValue = 0L;
            dxNumberBox6.UpButton.Location = new Point(63, 1);
            TimeBox3 = dxNumberBox6;
            TimeBox3.ValueTextBox.ValueChanged += (EventHandler<EventArgs>)((o, e) =>
            {
                if (GameScene.Game.Observer || GameScene.Game.AutoPotionBox.Updating || TimeBox3.ValueTextBox.Value <= 0L)
                    return;
                CEnvir.Enqueue((Packet)new AutoFightConfChanged()
                {
                    Enabled = SetRandomItemBox.Checked,
                    Slot = AutoSetConf.SetRandomItemBox,
                    TimeCount = (int)TimeBox3.Value
                });
            });
            DXLabel dxLabel15 = new DXLabel();
            dxLabel15.Text = "%";
            dxLabel15.Outline = true;
            dxLabel15.Parent = (DXControl)AutoHookTab;
            dxLabel15.Location = new Point(140, 225);
            DXCheckBox dxCheckBox27 = new DXCheckBox();
            dxCheckBox27.Label.Text = "随机传送卷保护";
            dxCheckBox27.Parent = (DXControl)AutoHookTab;
            dxCheckBox27.Checked = false;
            SetRandomItemBox = dxCheckBox27;
            SetRandomItemBox.Location = new Point(270 - SetRandomItemBox.Size.Width, 225);
            SetRandomItemBox.CheckedChanged += (EventHandler<EventArgs>)((o, e) =>
            {
                if (GameScene.Game.Observer || GameScene.Game.AutoPotionBox.Updating || TimeBox3.ValueTextBox.Value <= 0L)
                    return;
                CEnvir.Enqueue((Packet)new AutoFightConfChanged()
                {
                    Enabled = SetRandomItemBox.Checked,
                    Slot = AutoSetConf.SetRandomItemBox,
                    TimeCount = (int)TimeBox3.Value
                });
            });
            DXLabel dxLabel16 = new DXLabel();
            dxLabel16.Text = "血值低于";
            dxLabel16.Outline = true;
            dxLabel16.Parent = (DXControl)AutoHookTab;
            dxLabel16.Location = new Point(10, 245);
            DXNumberBox dxNumberBox7 = new DXNumberBox();
            dxNumberBox7.Parent = (DXControl)AutoHookTab;
            dxNumberBox7.Location = new Point(65, 245);
            dxNumberBox7.Size = new Size(80, 20);
            dxNumberBox7.ValueTextBox.Size = new Size(40, 18);
            dxNumberBox7.MaxValue = 100L;
            dxNumberBox7.MinValue = 0L;
            dxNumberBox7.UpButton.Location = new Point(63, 1);
            TimeBox4 = dxNumberBox7;
            TimeBox4.ValueTextBox.ValueChanged += (EventHandler<EventArgs>)((o, e) =>
            {
                if (GameScene.Game.Observer || GameScene.Game.AutoPotionBox.Updating || TimeBox4.ValueTextBox.Value <= 0L)
                    return;
                CEnvir.Enqueue((Packet)new AutoFightConfChanged()
                {
                    Enabled = SetHomeItemBox.Checked,
                    Slot = AutoSetConf.SetHomeItemBox,
                    TimeCount = (int)TimeBox4.Value
                });
            });
            DXLabel dxLabel17 = new DXLabel();
            dxLabel17.Text = "%";
            dxLabel17.Outline = true;
            dxLabel17.Parent = (DXControl)AutoHookTab;
            dxLabel17.Location = new Point(140, 245);
            DXCheckBox dxCheckBox28 = new DXCheckBox();
            dxCheckBox28.Label.Text = "回城卷保护";
            dxCheckBox28.Parent = (DXControl)AutoHookTab;
            dxCheckBox28.Checked = false;
            SetHomeItemBox = dxCheckBox28;
            SetHomeItemBox.Location = new Point(270 - SetHomeItemBox.Size.Width, 245);
            SetHomeItemBox.CheckedChanged += (EventHandler<EventArgs>)((o, e) =>
            {
                if (GameScene.Game.Observer || GameScene.Game.AutoPotionBox.Updating || TimeBox4.ValueTextBox.Value <= 0L)
                    return;
                CEnvir.Enqueue((Packet)new AutoFightConfChanged()
                {
                    Enabled = SetHomeItemBox.Checked,
                    Slot = AutoSetConf.SetHomeItemBox,
                    TimeCount = (int)TimeBox4.Value
                });
            });

            SummerLabelKill = new DXLabel()
            {
                Parent = AutoHookTab,
                Location = new Point(10, 285),
                Text = "杀怪数量:0",
            };
            SummerLabelEx = new DXLabel()
            {
                Parent = AutoHookTab,
                Location = new Point(110, 285),
                Text = "获得经验:0",
            };
            SummerLabelHuntGold = new DXLabel()
            {
                Parent = AutoHookTab,
                Location = new Point(10, 305),
                Text = "获得赏金:0",
            };
            SummerLabelGold = new DXLabel()
            {
                Parent = AutoHookTab,
                Location = new Point(110, 305),
                Text = "获得金币:0",
            };
            SummerLabelKillfen = new DXLabel()
            {
                Parent = AutoHookTab,
                Location = new Point(10, 325),
                Text = "分钟杀怪:0",
            };
            SummerLabelExfen = new DXLabel()
            {
                Parent = AutoHookTab,
                Location = new Point(110, 325),
                Text = "分钟经验:0",
            };
            SummerLabelHuntGoldfen = new DXLabel()
            {
                Parent = AutoHookTab,
                Location = new Point(10, 345),
                Text = "分钟赏金:0",
            };
            SummerLabelGoldfen = new DXLabel()
            {
                Parent = AutoHookTab,
                Location = new Point(110, 345),
                Text = "分钟金币:0",
            };
            Guajishijian = new DXLabel()
            {
                Parent = AutoHookTab,
                Location = new Point(10, 365),
                Text = "统计时间:0 小时 0 分钟 0 秒",
            };
            QingliButton = new DXButton
            {
                Size = new Size(40, 18),
                Location = new Point(229, 365),
                Label = { Text = "重置" },
                ButtonType = ButtonType.SmallButton,
                Parent = AutoHookTab,
            };
            QingliButton.MouseClick += (o, e) =>
            {
                SummerLabelKill.Text = "杀怪数量:0";
                skilledCount = 0;
                SummerLabelEx.Text = "获得经验:0";
                totalExperience = 0;
                SummerLabelHuntGold.Text = "获得赏金:0";
                totalHuntGold = 0;
                SummerLabelGold.Text = "获得金币:0";
                totalGold = 0;
                SummerLabelKillfen.Text = "分钟杀怪:0";
                SummerLabelExfen.Text = "分钟经验:0";
                SummerLabelHuntGoldfen.Text = "分钟赏金:0";
                SummerLabelGoldfen.Text = "分钟金币:0";
                Guajishijian.Text = "统计时间:0 小时 0 分钟 0 秒";
                LastTimes = DateTime.Now;

                GameScene.Game.AttackModeBox.SummerLabelEx.Text = "0";
            };


            DXControl dXControl = new DXControl
            {
                Parent = AutoPotionTab,
                Size = new Size(AutoPotionTab.Size.Width - 16, AutoPotionTab.Size.Height),
                Location = new Point(5, 5)
            };
            dXControl.MouseWheel += ScrollBar.DoMouseWheel;
            for (int j = 0; j < Links.Length; j++)
            {
                (Rows[j] = new AutoPotionRow
                {
                    Parent = dXControl,
                    Location = new Point(1, 1 + 50 * j),
                    Index = j
                }).MouseWheel += ScrollBar.DoMouseWheel;
            }

            ScrollBar.ValueChanged += (o, e) => UpdateLocations();

            InitPickupFilter();
            //魔法技能配置
            InitMagicFilter();
        }
        public void UpdateWaiguaScrollBar()
        {
            WaiguaScrollBar.MaxValue = Lines.Count * 20;

            for (int j = 1; j < Lines.Count; j += 2)
                Lines[j].Location = new Point(Lines[j].Location.X, j * 10 - WaiguaScrollBar.Value + 30);

            for (int i = 0; i < Lines.Count; i += 2)
                Lines[i].Location = new Point(Lines[i].Location.X, i * 10 - WaiguaScrollBar.Value + 20);

        }


        private int FilterPage, MaxFilterPage;
        public FilterItem[] FilterItems;

        DXButton PrevPage, NextPage, SetApply, QingliButton;
        DXTextBox FilterName, FilterNum1, FilterNum2, FilterNum3;
        string filterName = "./PickupFilter.txt";

        private Dictionary<int, string> CompanionMemory = new Dictionary<int, string>();
        private string UpdateAmount = "";

        //魔法技能配置
        DXButton MagicPrevPage, MagicNextPage, MagicSetApply;
        //魔法技能配置
        DXTextBox MagicFilterName, MagicFilterNum1, MagicFilterNum2;
        //魔法技能配置
        private int MagicFilterPage, MagicMaxFilterPage;
        public MagicFilterItem[] MagicFilterItems;

        // 循环2次. 超过5w个可以用map替换数组
        public FilterItem GetFilterItem(string itemName, int itemIdx, short xianshi)
        {
            if (itemName.Length < 1)
                return null;


            // 精准查询
            foreach (var item in FilterItems)
            {
                if (item == null)
                    continue;

                // 非模糊拾取
                if (item.canPickup != 2)
                {
                    if (item.name.Equals(itemName))
                    {
                        // 拾取
                        if (item.canPickup != 0)
                        {
                            if (!CompanionMemory.ContainsKey(itemIdx))
                            {
                                CompanionMemory.Add(itemIdx, itemName);
                                UpdateAmount = string.Concat(UpdateAmount, itemIdx, ",1;");
                            }
                        }
                        else
                        {
                            if (CompanionMemory.ContainsKey(itemIdx))
                            {
                                CompanionMemory.Remove(itemIdx);
                                UpdateAmount = string.Concat(UpdateAmount, itemIdx, ",0;");
                            }
                        }

                        return item;
                    }

                }
            }

            // 模糊查询
            foreach (var item in FilterItems)
            {
                if (item == null)
                    continue;

                // 模糊拾取
                if (item.canPickup == 2)
                {
                    if (itemName.Contains(item.name))
                    {
                        if (!CompanionMemory.ContainsKey(itemIdx))
                        {
                            CompanionMemory.Add(itemIdx, itemName);
                            UpdateAmount = string.Concat(UpdateAmount, itemIdx, ",1;");
                        }
                        return item;
                    }
                }
            }

            return null;
        }

        //魔法技能配置
        string magicconfig = "./MagicConfig.txt";
        public MagicFilterItem GetMagicFilterItem(string magicName, int itemIdx)
        {
            if (magicName.Length < 1)
                return null;

            // 精准查询
            foreach (var magic in MagicFilterItems)
            {
                if (magic == null)
                    continue;

                if (magic.name.Equals(magicName))
                    return magic;


            }
            return null;
        }
        //魔法技能配置
        private void InitMagicFilter()
        {
            MagicSearchRows = new MagicConfig[10];
            MagicFilterPage = 0;

            for (int i = 0; i < MagicSearchRows.Length; i++)
            {
                MagicSearchRows[i] = new MagicConfig()
                {
                    Parent = AutoMagicTab,
                    Location = new Point(10, 40 + i * 28),
                };
                MagicSearchRows[i].MouseClick += (o, e) => {
                    MagicSelectedFilterItem((MagicConfig)o);
                };
            }

            if (!File.Exists(magicconfig))
            {
                File.Create(magicconfig);
            }

            string[] lines = File.ReadAllLines(magicconfig);

            MagicMaxFilterPage = lines.Length / 10;
            MagicFilterItems = new MagicFilterItem[lines.Length];

            int idx = 0;
            foreach (string line in lines)
            {
                string[] item = line.Split(',');
                if (item.Length >= 3)
                {
                    MagicFilterItems[idx] = new MagicFilterItem();
                    MagicFilterItems[idx].name = item[0].Trim();
                    short pick = 0;
                    if (short.TryParse(item[1].Trim(), out pick))
                        MagicFilterItems[idx].suo = pick;
                    short highLight = 0;
                    if (short.TryParse(item[2].Trim(), out highLight))
                        MagicFilterItems[idx].fu = highLight;
                }
                idx++;
            }
            MagicPrevPage = new DXButton
            {
                Size = new Size(30, 18),
                Location = new Point(10, 330),
                Label = { Text = "上" },
                ButtonType = ButtonType.SmallButton,
                Parent = AutoMagicTab,
            };
            MagicPrevPage.MouseClick += (o, e) => {
                MagicFilterPage--;
                RefereshMagicFilterItem();
            };

            MagicNextPage = new DXButton
            {
                Size = new Size(30, 18),
                Location = new Point(45, 330),
                Label = { Text = "下" },
                ButtonType = ButtonType.SmallButton,
                Parent = AutoMagicTab,
            };
            MagicNextPage.MouseClick += (o, e) => {
                MagicFilterPage++;
                RefereshMagicFilterItem();
            };

            MagicFilterName = new DXTextBox
            {
                Parent = AutoMagicTab,
                Size = new Size(95, 28),
                Location = new Point(80, 330),
            };

            MagicFilterNum1 = new DXTextBox
            {
                Parent = AutoMagicTab,
                Size = new Size(25, 28),
                Location = new Point(180, 330),
            };

            MagicFilterNum2 = new DXTextBox
            {
                Parent = AutoMagicTab,
                Size = new Size(25, 28),
                Location = new Point(210, 330),
            };


            MagicSetApply = new DXButton
            {
                Size = new Size(40, 18),
                Location = new Point(240, 330),
                Label = { Text = "应用" },
                ButtonType = ButtonType.SmallButton,
                Parent = AutoMagicTab,
            };

            label1 = new DXLabel
            {
                Size = new Size(180, 18),
                Location = new Point(10, 15),
                Parent = AutoMagicTab,
                ForeColour = Color.Yellow,
                Text = "  技能名称                                锁定       毒符设定"
            };

            label = new DXLabel
            {
                Size = new Size(200, 18),
                Location = new Point(5, 360),
                Parent = AutoMagicTab,
                Text = "是否锁定：0  未选 ，1 锁怪 ，2 锁人 ，3 锁人锁怪",
            };
            label = new DXLabel
            {
                Size = new Size(200, 18),
                Location = new Point(5, 380),
                Parent = AutoMagicTab,
                Text = "1护 2火 3冰 4雷 5风 6神 7暗 8幻 9灵 10红 11绿 2换"
            };

            MagicSetApply.MouseClick += (o, e) => {

                if (MagicSelectedItem == null)
                    return;

                short pick = 0;
                short highlight = 0;
                if (MagicFilterName.TextBox.Text.Length > 0 &&
                    short.TryParse(MagicFilterNum1.TextBox.Text.Trim(), out pick) &&
                    short.TryParse(MagicFilterNum2.TextBox.Text.Trim(), out highlight))
                {
                    MagicSelectedItem.ResetProp(MagicFilterName.TextBox.Text, pick, highlight);
                    if (MagicSelectedItem.MagicIndex >= 0 && MagicSelectedItem.MagicIndex < MagicFilterItems.Length)
                    {
                        MagicFilterItems[MagicSelectedItem.MagicIndex].name = MagicFilterName.TextBox.Text;
                        MagicFilterItems[MagicSelectedItem.MagicIndex].suo = pick;
                        MagicFilterItems[MagicSelectedItem.MagicIndex].fu = highlight;
                    }
                }
            };


            RefereshMagicFilterItem();
        }
        //魔法技能配置
        private MagicConfig MagicSelectedItem;
        //魔法技能配置
        private void MagicSelectedFilterItem(MagicConfig magic)
        {
            for (int i = 0; i < MagicSearchRows.Length; i++)
            {
                MagicSearchRows[i].Selected = false;
            }
            magic.Selected = true;
            MagicSelectedItem = magic;

            MagicFilterName.TextBox.Text = magic.NameLabel.Text;
            MagicFilterNum1.TextBox.Text = magic.SuoLabel.Tag.ToString();
            MagicFilterNum2.TextBox.Text = magic.FuLabel.Tag.ToString();
        }
        //魔法技能配置
        private void RefereshMagicFilterItem()
        {
            if (MagicFilterPage > MagicMaxFilterPage)
                MagicFilterPage = MagicMaxFilterPage;

            if (MagicFilterPage < 0)
                MagicFilterPage = 0;

            foreach (var magic in MagicSearchRows)
            {
                magic.Visible = false;
                magic.Selected = false;
                magic.MagicIndex = -1;
            }

            MagicSelectedItem = null;
            MagicFilterName.TextBox.Text = "";
            MagicFilterNum1.TextBox.Text = "";
            MagicFilterNum2.TextBox.Text = "";

            int idx = MagicFilterPage * 10;
            int ctrlIdx = 0;
            for (; ctrlIdx < 10 && idx < MagicFilterItems.Length; idx++)
            {
                MagicFilterItem magic = MagicFilterItems[idx];
                if (magic != null)
                {
                    MagicSearchRows[ctrlIdx].ResetProp(magic.name, magic.suo, magic.fu);
                    MagicSearchRows[ctrlIdx].Visible = true;
                    MagicSearchRows[ctrlIdx].MagicIndex = idx;
                }
                ctrlIdx++;
            }

        }

        private void InitPickupFilter()
        {
            SearchRows = new PickupItem[10];
            FilterPage = 0;

            for (int i = 0; i < SearchRows.Length; i++)
            {
                SearchRows[i] = new PickupItem()
                {
                    Parent = AutoSystemTab,
                    Location = new Point(10, 40 + i * 28),
                };
                SearchRows[i].MouseClick += (o, e) => {
                    SelectedFilterItem((PickupItem)o);
                };
            }

            if (!File.Exists(filterName))
            {
                File.Create(filterName);
            }

            string[] lines = File.ReadAllLines(filterName);

            MaxFilterPage = lines.Length / 10;
            FilterItems = new FilterItem[lines.Length];

            int idx = 0;
            foreach (string line in lines)
            {
                string[] item = line.Split(',');
                if (item.Length >= 4)
                {
                    FilterItems[idx] = new FilterItem();
                    FilterItems[idx].name = item[0].Trim();
                    short pick = 0;
                    if (short.TryParse(item[1].Trim(), out pick))
                        FilterItems[idx].canPickup = pick;
                    short highLight = 0;
                    if (short.TryParse(item[2].Trim(), out highLight))
                        FilterItems[idx].highLight = highLight;
                    short xianshi = 0;
                    if (short.TryParse(item[3].Trim(), out xianshi))
                        FilterItems[idx].xianshi = xianshi;
                }
                idx++;
            }
            PrevPage = new DXButton
            {
                Size = new Size(30, 18),
                Location = new Point(10, 330),
                Label = { Text = "上" },
                ButtonType = ButtonType.SmallButton,
                Parent = AutoSystemTab,
            };
            PrevPage.MouseClick += (o, e) => {
                FilterPage--;
                RefereshFilterItem();
            };

            NextPage = new DXButton
            {
                Size = new Size(30, 18),
                Location = new Point(45, 330),
                Label = { Text = "下" },
                ButtonType = ButtonType.SmallButton,
                Parent = AutoSystemTab,
            };
            NextPage.MouseClick += (o, e) => {
                FilterPage++;
                RefereshFilterItem();
            };

            FilterName = new DXTextBox
            {
                Parent = AutoSystemTab,
                Size = new Size(80, 28),
                Location = new Point(80, 330),
            };

            FilterNum1 = new DXTextBox
            {
                Parent = AutoSystemTab,
                Size = new Size(20, 28),
                Location = new Point(165, 330),
            };

            FilterNum2 = new DXTextBox
            {
                Parent = AutoSystemTab,
                Size = new Size(20, 28),
                Location = new Point(190, 330),
            };
            FilterNum3 = new DXTextBox
            {
                Parent = AutoSystemTab,
                Size = new Size(20, 28),
                Location = new Point(215, 330),
            };

            SetApply = new DXButton
            {
                Size = new Size(40, 18),
                Location = new Point(240, 330),
                Label = { Text = "应用" },
                ButtonType = ButtonType.SmallButton,
                Parent = AutoSystemTab,
            };

            label1 = new DXLabel
            {
                Size = new Size(180, 18),
                Location = new Point(10, 15),
                Parent = AutoSystemTab,
                ForeColour = Color.Yellow,
                Text = "  物品名称                                 是否拾取   颜色  显示"
            };

            label = new DXLabel
            {
                Size = new Size(200, 18),
                Location = new Point(5, 360),
                Parent = AutoSystemTab,
                Text = " 是否拾取：0 不拾，1-2拾取，物品显示:0不显 1显示"
            };
            label = new DXLabel
            {
                Size = new Size(200, 18),
                Location = new Point(5, 380),
                Parent = AutoSystemTab,
                Text = " 颜色：0 白色，1 绿色，2-3-4 蓝色 紫色 橙色并发光"
            };

            SetApply.MouseClick += (o, e) => {

                if (SelectedItem == null)
                    return;

                short pick = 0;
                short highlight = 0;
                short xianshi = 0;
                if (FilterName.TextBox.Text.Length > 0 &&
                    short.TryParse(FilterNum1.TextBox.Text.Trim(), out pick) &&
                    short.TryParse(FilterNum2.TextBox.Text.Trim(), out highlight) &&
                    short.TryParse(FilterNum3.TextBox.Text.Trim(), out xianshi))
                {
                    SelectedItem.ResetProp(FilterName.TextBox.Text, pick, highlight, xianshi);
                    if (SelectedItem.ItemIndex >= 0 && SelectedItem.ItemIndex < FilterItems.Length)
                    {
                        FilterItems[SelectedItem.ItemIndex].name = FilterName.TextBox.Text;
                        FilterItems[SelectedItem.ItemIndex].canPickup = pick;
                        FilterItems[SelectedItem.ItemIndex].highLight = highlight;
                        FilterItems[SelectedItem.ItemIndex].xianshi = xianshi;
                    }
                }
            };


            RefereshFilterItem();
        }

        private PickupItem SelectedItem;

        private void SelectedFilterItem(PickupItem item)
        {
            for (int i = 0; i < SearchRows.Length; i++)
            {
                SearchRows[i].Selected = false;
            }
            item.Selected = true;
            SelectedItem = item;

            FilterName.TextBox.Text = item.NameLabel.Text;
            FilterNum1.TextBox.Text = item.PickupLabel.Tag.ToString();
            FilterNum2.TextBox.Text = item.HeightLightLabel.Tag.ToString();
            FilterNum3.TextBox.Text = item.xianshiLabel.Tag.ToString();
        }

        public void AutoPickupC()
        {
            if (GameScene.Game.Observer)
                return;

            if (GameScene.Game.User.Dead)
                return;

            if (CEnvir.Now < GameScene.Game.PickUpTime)
                return;

            GameScene.Game.PickUpTime = CEnvir.Now.AddMilliseconds(250);

            int range = GameScene.Game.User.Stats[Stat.PickUpRadius];

            int userPosX = GameScene.Game.User.CurrentLocation.X;
            int userPosY = GameScene.Game.User.CurrentLocation.Y;

            for (int d = 0; d <= range; d++)
            {
                for (int y = userPosY - d; y <= userPosY + d; y++)
                {
                    if (y < 0) continue;
                    if (y >= GameScene.Game.MapControl.Height) break;

                    for (int x = userPosX - d; x <= userPosX + d; x += Math.Abs(y - userPosY) == d ? 1 : d * 2)
                    {
                        if (x < 0) continue;
                        if (x >= GameScene.Game.MapControl.Width) break;

                        Cell cell = GameScene.Game.MapControl.Cells[x, y]; //Direct Access we've checked the boudaries.

                        if (cell?.Objects == null) continue;

                        foreach (MapObject cellObject in cell.Objects)
                        {
                            if (cellObject.Race != ObjectType.Item)
                                continue;

                            ItemObject item = (ItemObject)cellObject;

                            string name = item.Item.Info.ItemName;
                            int itemIdx = item.Item.Info.Index;
                            short xianshi = 0;

                            if (item.Item.Info.Effect == ItemEffect.Gold)
                            {
                                if (item.Item.Count + GameScene.Game.User.Gold > CartoonGlobals.MaxGold) continue;
                                /*
                                {
                                    if (CEnvir.Now < OutputTime) return;
                                    OutputTime = CEnvir.Now.AddSeconds(5);
                                    GameScene.Game.ReceiveChat("你当前金币数量超出了最大金额范围", MessageType.System);
                                    return;
                                }
                                */
                            }

                            if (item.Item.Info.Effect == ItemEffect.ItemPart)
                            {
                                name = item.Name;
                                itemIdx = item.Item.AddedStats[Stat.ItemIndex];
                            }

                            FilterItem filterItem = GetFilterItem(name, itemIdx, xianshi);

                            if (filterItem == null)
                            {
                                // 未在列表中, 不拾取
                                continue;
                            }

                            if (filterItem.canPickup != 0)
                            {
                                CEnvir.Enqueue(new C.PickUpC
                                {
                                    ItemIdx = item.Item.Info.Index,
                                    Xpos = x,
                                    Ypos = y,
                                });
                            }

                        }

                    }
                }
            }
        }

        public void AutoPickup()
        {
            if (GameScene.Game.Observer)
                return;

            if (GameScene.Game.User.Dead)
                return;

            if (CEnvir.Now < GameScene.Game.PickUpTime)
                return;

            GameScene.Game.PickUpTime = CEnvir.Now.AddMilliseconds(250);

            int range = GameScene.Game.User.Stats[Stat.PickUpRadius];

            int userPosX = GameScene.Game.User.CurrentLocation.X;
            int userPosY = GameScene.Game.User.CurrentLocation.Y;

            for (int d = 0; d <= range; d++)
            {
                for (int y = userPosY - d; y <= userPosY + d; y++)
                {
                    if (y < 0) continue;
                    if (y >= GameScene.Game.MapControl.Height) break;

                    for (int x = userPosX - d; x <= userPosX + d; x += Math.Abs(y - userPosY) == d ? 1 : d * 2)
                    {
                        if (x < 0) continue;
                        if (x >= GameScene.Game.MapControl.Width) break;

                        Cell cell = GameScene.Game.MapControl.Cells[x, y]; //Direct Access we've checked the boudaries.

                        if (cell?.Objects == null) continue;

                        foreach (MapObject cellObject in cell.Objects)
                        {
                            if (cellObject.Race != ObjectType.Item)
                                continue;

                            ItemObject item = (ItemObject)cellObject;

                            string name = item.Item.Info.ItemName;
                            int itemIdx = item.Item.Info.Index;
                            short xianshi = 0;

                            if (item.Item.Info.Effect == ItemEffect.Gold)
                            {
                                if (item.Item.Count + GameScene.Game.User.Gold > CartoonGlobals.MaxGold) continue;
                                /*
                                {
                                    if (CEnvir.Now < OutputTime) return;
                                    OutputTime = CEnvir.Now.AddSeconds(5);
                                    GameScene.Game.ReceiveChat("你当前金币数量超出了最大金额范围", MessageType.System);
                                    return;
                                }
                                */
                            }

                            if (item.Item.Info.Effect == ItemEffect.ItemPart)
                            {
                                name = item.Name;
                                itemIdx = item.Item.AddedStats[Stat.ItemIndex];
                            }

                            FilterItem filterItem = GetFilterItem(name, itemIdx, xianshi);

                            if (filterItem == null)
                            {
                                // 未在列表中, 不拾取
                                continue;
                            }

                            if (filterItem.canPickup != 0)
                            {
                                CEnvir.Enqueue(new C.PickUp
                                {
                                    ItemIdx = item.Item.Info.Index,
                                    Xpos = x,
                                    Ypos = y,
                                });
                            }

                        }

                    }
                }
            }
        }

        private void RefereshFilterItem()
        {
            if (FilterPage > MaxFilterPage)
                FilterPage = MaxFilterPage;

            if (FilterPage < 0)
                FilterPage = 0;

            foreach (var item in SearchRows)
            {
                item.Visible = false;
                item.Selected = false;
                item.ItemIndex = -1;
            }

            SelectedItem = null;
            FilterName.TextBox.Text = "";
            FilterNum1.TextBox.Text = "";
            FilterNum2.TextBox.Text = "";
            FilterNum3.TextBox.Text = "";

            int idx = FilterPage * 10;
            int ctrlIdx = 0;
            for (; ctrlIdx < 10 && idx < FilterItems.Length; idx++)
            {
                FilterItem item = FilterItems[idx];
                if (item != null)
                {
                    SearchRows[ctrlIdx].ResetProp(item.name, item.canPickup, item.highLight, item.xianshi);
                    SearchRows[ctrlIdx].Visible = true;
                    SearchRows[ctrlIdx].ItemIndex = idx;
                }
                ctrlIdx++;
            }

        }

        public bool CheckAssistClean()
        {
            return tyCheckBox2.Checked;
        }

        public bool CheckAttackShit()
        {
            if (tyCheckBox1.Checked)
                return true;

            return CEnvir.Shift;
        }

        public bool CheckRunUp()
        {
            return tyCheckBox.Checked;
        }


        private BuffType IsBuffSkill(MagicType magicType)
        {
            BuffType buffType;
            if (Enum.TryParse(magicType.ToString(), out buffType))
            {
                return buffType;
            }
            return BuffType.None;
        }

        private DateTime _time;


        // tick
        public void UpdateAutoAssist()
        {
            if (GameScene.Game.Observer)
            {
                return;
            }

            if (pickupCheckBoxC.Checked)
                AutoPickupC();

            if (pickupCheckBox.Checked)
                AutoPickup();

            // 骑马状态自动技能失效
            //if (GameScene.Game.User.Horse)
            //{

            //}
            /*
            if (!SetAutoOnHookBox.Checked)
                return;
               */
            if (GameScene.Game.User.Dead && SetDeathResurrectionBox.Checked)
            {
                SetAutoOnHookBox.Checked = false;
                CEnvir.Enqueue(new TownRevive());
                GameScene.Game.ReceiveChat("自动挂机关闭", MessageType.System);
            }

            if (SetRandomItemBox.Checked)
            {
                float num = TimeBox3.Value / 100f;
                if ((double)GameScene.Game.User.CurrentHP < (double)GameScene.Game.User.Stats[Stat.Health] * (double)num && CEnvir.Now > _protecttime)
                {
                    DXItemCell dxItemCell = ((IEnumerable<DXItemCell>)GameScene.Game.InventoryBox.Grid.Grid).FirstOrDefault<DXItemCell>((Func<DXItemCell, bool>)(x => x?.Item?.Info.ItemName == "随机传送卷"));
                    if (dxItemCell != null && dxItemCell.UseItem())
                        _protecttime = CEnvir.Now.AddSeconds(5.0);
                }
            }
            if (SetHomeItemBox.Checked)
            {
                float num = (float)TimeBox4.Value / 100f;
                if ((double)GameScene.Game.User.CurrentHP < (double)GameScene.Game.User.Stats[Stat.Health] * (double)num && CEnvir.Now > HuichengTime)
                {
                    DXItemCell dxItemCell = ((IEnumerable<DXItemCell>)GameScene.Game.InventoryBox.Grid.Grid).FirstOrDefault<DXItemCell>((Func<DXItemCell, bool>)(x => x?.Item?.Info.ItemName == "回城卷"));
                    if (dxItemCell != null && dxItemCell.UseItem())
                    {
                        HuichengTime = CEnvir.Now.AddSeconds(5.0);
                        SetAutoOnHookBox.Checked = false;
                        GameScene.Game.ReceiveChat("自动挂机关闭", MessageType.System);
                    }
                }
            }
            //多少秒没有杀怪物自动使用随机功能
            if (SetAutoOnHookBox.Checked && SuijiBox.Checked && !SuijisBox.Checked)
            {
                if ((DateTime.Now - LastGainEx).TotalSeconds > TimeBox5.Value)
                {
                    LastGainEx = DateTime.Now.AddSeconds(1);
                    if (skilledCount++ - LastGainExp != 0)
                    {
                        DXItemCell dxItemCell = ((IEnumerable<DXItemCell>)GameScene.Game.InventoryBox.Grid.Grid).FirstOrDefault(x => x?.Item?.Info.ItemName == "随机传送卷");
                        if (dxItemCell != null && dxItemCell.UseItem())
                            _protecttime = CEnvir.Now.AddSeconds(5.0);

                        LastGainExp = skilledCount++;
                        LastGainEx = DateTime.Now;

                        if (GameScene.Game.MapControl.AutoPath)
                            GameScene.Game.MapControl.CurrentPath = null;
                    }
                }
            }
            //每多少秒自动随机功能
            if (SetAutoOnHookBox.Checked && SuijisBox.Checked && !SuijiBox.Checked)
            {
                if ((DateTime.Now - LastSuijiTimes).TotalSeconds > TimeBox6.Value)
                {
                    LastSuijiTimes = DateTime.Now.AddSeconds(1);

                    DXItemCell dxItemCell = ((IEnumerable<DXItemCell>)GameScene.Game.InventoryBox.Grid.Grid).FirstOrDefault(x => x?.Item?.Info.ItemName == "随机传送卷");
                    if (dxItemCell != null && dxItemCell.UseItem())
                        _protecttime = CEnvir.Now.AddSeconds(5.0);

                    LastSuijiTimes = DateTime.Now;


                    if (GameScene.Game.MapControl.AutoPath)
                        GameScene.Game.MapControl.CurrentPath = null;

                }
            }

            if (SetAutoOnHookBox.Checked)
            {
                Guaji.Checked = true;
                CEnvir.Enqueue(new C.GuajiToggle { Guaji = Guaji.Checked });
            }
            else
            {
                Guaji.Checked = false;
                CEnvir.Enqueue(new C.GuajiToggle { Guaji = Guaji.Checked });
            }



            if (safezone.Checked)
            {
                if (GameScene.Game.User.Class == MirClass.Assassin)
                {
                    if (GameScene.Game.User.Mingwen01 == 225 || GameScene.Game.User.Mingwen02 == 225 || GameScene.Game.User.Mingwen03 == 225)
                        Assassin4Magic(MagicType.FullBloom, BuffType.None);
                    if (GameScene.Game.User.Mingwen01 == 209 || GameScene.Game.User.Mingwen02 == 209 || GameScene.Game.User.Mingwen03 == 209)
                        Assassin4Magic(MagicType.WhiteLotus, BuffType.FullBloom);
                    if (GameScene.Game.User.Mingwen01 == 212 || GameScene.Game.User.Mingwen02 == 212 || GameScene.Game.User.Mingwen03 == 212)
                        Assassin4Magic(MagicType.RedLotus, BuffType.WhiteLotus);
                    if (GameScene.Game.User.Mingwen01 == 217 || GameScene.Game.User.Mingwen02 == 217 || GameScene.Game.User.Mingwen03 == 217)
                        Assassin4Magic(MagicType.SweetBrier, BuffType.RedLotus);
                }
            }
            else if (!safezone.Checked && !MapObject.User.InSafeZone)
            {
                if (GameScene.Game.User.Class == MirClass.Assassin)
                {
                    if (GameScene.Game.User.Mingwen01 == 225 || GameScene.Game.User.Mingwen02 == 225 || GameScene.Game.User.Mingwen03 == 225)
                        Assassin4Magic(MagicType.FullBloom, BuffType.None);
                    if (GameScene.Game.User.Mingwen01 == 209 || GameScene.Game.User.Mingwen02 == 209 || GameScene.Game.User.Mingwen03 == 209)
                        Assassin4Magic(MagicType.WhiteLotus, BuffType.FullBloom);
                    if (GameScene.Game.User.Mingwen01 == 212 || GameScene.Game.User.Mingwen02 == 212 || GameScene.Game.User.Mingwen03 == 212)
                        Assassin4Magic(MagicType.RedLotus, BuffType.WhiteLotus);
                    if (GameScene.Game.User.Mingwen01 == 217 || GameScene.Game.User.Mingwen02 == 217 || GameScene.Game.User.Mingwen03 == 217)
                        Assassin4Magic(MagicType.SweetBrier, BuffType.RedLotus);
                }
            }


            if (CEnvir.Now < _time)
            {
                return;
            }
            _time = CEnvir.Now.AddMilliseconds(800);

            if (!GameScene.Game.InventoryBox.nowcansortItem)
            {
                if (GameScene.Game.InventoryBox.SortItemTime <= CEnvir.Now)
                {
                    GameScene.Game.InventoryBox.nowcansortItem = true;
                    GameScene.Game.InventoryBox.OnSortItemChanged();
                }
            }

            // 发送宠物过滤包
            if (UpdateAmount.Length > 0)
            {
                CEnvir.Enqueue(new C.PktFilterItem
                {
                    FilterStr = UpdateAmount,
                });
                UpdateAmount = "";
            }


            if (safezone.Checked)
            {
                // ============战士技能============
                if (GameScene.Game.User.Class == MirClass.Warrior)
                {
                    // 破血
                    AssistUseMagic(MagicType.Might, zsCheckBox1.Checked);
                    // 烈火
                    AssistUseMagic(MagicType.FlamingSword, zsCheckBox2.Checked);
                    // 翔空
                    AssistUseMagic(MagicType.DragonRise, zsCheckBox3.Checked);
                    // 莲月
                    AssistUseMagic(MagicType.BladeStorm, zsCheckBox4.Checked);
                    // 铁布
                    AssistUseMagic(MagicType.Defiance, zsCheckBox5.Checked);
                }
                // ============法师技能============
                else if (GameScene.Game.User.Class == MirClass.Wizard)
                {

                    // 魔法盾
                    AssistUseMagic(MagicType.MagicShield, fsCheckBox.Checked);
                    // 凝血
                    AssistUseMagic(MagicType.Renounce, fsCheckBox1.Checked);
                    // 天打雷劈
                    AssistUseMagic(MagicType.JudgementOfHeaven, fsCheckBox2.Checked);
                    // 魔光盾
                    AssistUseMagic(MagicType.SuperiorMagicShield, fsCheckBox3.Checked);
                }
                // ============道士技能============
                else if (GameScene.Game.User.Class == MirClass.Taoist)
                {
                    // 阴阳盾
                    AssistUseMagic(MagicType.CelestialLight, dsCheckBox1.Checked);
                    // 移花接玉
                    AssistUseMagic(MagicType.StrengthOfFaith, dsCheckBox2.Checked);
                    // 传染
                    AssistUseMagic(MagicType.Infection, dsCheckBox3.Checked);
                    // 灭魂
                    AssistUseMagic(MagicType.ImprovedExplosiveTalisman, dsCheckBox4.Checked);
                }
                // ============刺客技能============
                else if (GameScene.Game.User.Class == MirClass.Assassin)
                {

                    if (GameScene.Game.User.Mingwen01 != 225 && GameScene.Game.User.Mingwen02 != 225 && GameScene.Game.User.Mingwen03 != 225)
                        Assassin4Magic(MagicType.FullBloom, BuffType.None);
                    if (GameScene.Game.User.Mingwen01 != 209 && GameScene.Game.User.Mingwen02 != 209 && GameScene.Game.User.Mingwen03 != 209)
                        Assassin4Magic(MagicType.WhiteLotus, BuffType.FullBloom);
                    if (GameScene.Game.User.Mingwen01 != 212 && GameScene.Game.User.Mingwen02 != 212 && GameScene.Game.User.Mingwen03 != 212)
                        Assassin4Magic(MagicType.RedLotus, BuffType.WhiteLotus);
                    if (GameScene.Game.User.Mingwen01 != 217 && GameScene.Game.User.Mingwen02 != 217 && GameScene.Game.User.Mingwen03 != 217)
                        Assassin4Magic(MagicType.SweetBrier, BuffType.RedLotus);

                    //自动闪避
                    AssistUseMagic(MagicType.Evasion, ckCheckBox1.Checked);
                    //自动守护
                    AssistUseMagic(MagicType.RagingWind, ckCheckBox2.Checked);
                    //自动雷光
                    AssistUseMagic(MagicType.Concentration, ckCheckBox3.Checked);
                }
            }
            else if (!safezone.Checked && !MapObject.User.InSafeZone)
            {
                // ============战士技能============
                if (GameScene.Game.User.Class == MirClass.Warrior)
                {
                    // 破血
                    AssistUseMagic(MagicType.Might, zsCheckBox1.Checked);
                    // 烈火
                    AssistUseMagic(MagicType.FlamingSword, zsCheckBox2.Checked);
                    // 翔空
                    AssistUseMagic(MagicType.DragonRise, zsCheckBox3.Checked);
                    // 莲月
                    AssistUseMagic(MagicType.BladeStorm, zsCheckBox4.Checked);
                    // 铁布
                    AssistUseMagic(MagicType.Defiance, zsCheckBox5.Checked);
                }
                // ============法师技能============
                else if (GameScene.Game.User.Class == MirClass.Wizard)
                {
                    // 魔法盾
                    AssistUseMagic(MagicType.MagicShield, fsCheckBox.Checked);
                    // 凝血
                    AssistUseMagic(MagicType.Renounce, fsCheckBox1.Checked);
                    // 天打雷劈
                    AssistUseMagic(MagicType.JudgementOfHeaven, fsCheckBox2.Checked);
                    // 魔光盾
                    AssistUseMagic(MagicType.SuperiorMagicShield, fsCheckBox3.Checked);
                }
                // ============道士技能============
                else if (GameScene.Game.User.Class == MirClass.Taoist)
                {
                    // 阴阳盾
                    AssistUseMagic(MagicType.CelestialLight, dsCheckBox1.Checked);
                    // 移花接玉
                    AssistUseMagic(MagicType.StrengthOfFaith, dsCheckBox2.Checked);
                    // 传染
                    AssistUseMagic(MagicType.Infection, dsCheckBox3.Checked);
                    // 灭魂
                    AssistUseMagic(MagicType.ImprovedExplosiveTalisman, dsCheckBox4.Checked);
                }
                // ============刺客技能============
                else if (GameScene.Game.User.Class == MirClass.Assassin)
                {
                    if (GameScene.Game.User.Mingwen01 != 225 && GameScene.Game.User.Mingwen02 != 225 && GameScene.Game.User.Mingwen03 != 225)
                        Assassin4Magic(MagicType.FullBloom, BuffType.None);
                    if (GameScene.Game.User.Mingwen01 != 209 && GameScene.Game.User.Mingwen02 != 209 && GameScene.Game.User.Mingwen03 != 209)
                        Assassin4Magic(MagicType.WhiteLotus, BuffType.FullBloom);
                    if (GameScene.Game.User.Mingwen01 != 212 && GameScene.Game.User.Mingwen02 != 212 && GameScene.Game.User.Mingwen03 != 212)
                        Assassin4Magic(MagicType.RedLotus, BuffType.WhiteLotus);
                    if (GameScene.Game.User.Mingwen01 != 217 && GameScene.Game.User.Mingwen02 != 217 && GameScene.Game.User.Mingwen03 != 217)
                        Assassin4Magic(MagicType.SweetBrier, BuffType.RedLotus);

                    //自动闪避
                    AssistUseMagic(MagicType.Evasion, ckCheckBox1.Checked);
                    //自动守护
                    AssistUseMagic(MagicType.RagingWind, ckCheckBox2.Checked);
                    //自动雷光
                    AssistUseMagic(MagicType.Concentration, ckCheckBox3.Checked);
                }
            }
        }

        private ClientUserMagic GetUserSkill(MagicType magicType)
        {
            // 判定技能是否存在
            ClientUserMagic clientUserMagic = null;
            foreach (KeyValuePair<MagicInfo, ClientUserMagic> magic in GameScene.Game.User.Magics)
            {
                if (magic.Value.Info.Magic == magicType)
                {
                    clientUserMagic = magic.Value;
                    break;
                }
            }

            // 不存在
            if (clientUserMagic == null)
                return null;

            // 未学习
            if (clientUserMagic.Level < 0)
                return null;

            return clientUserMagic;
        }

        private bool GetBuffByType(BuffType buffer)
        {
            if (GameScene.Game.User.Buffs.Any(x => x.Type == buffer))
            {
                return true;
            }
            return false;
        }

        private List<BuffType> Assassin4Buffer = new List<BuffType>() { BuffType.FullBloom, BuffType.WhiteLotus, BuffType.RedLotus };
        /*
        private void Assassin4Magic(MagicType magicType, BuffType needBuff)
        {
            if (!ckCheckBox.Checked)
                return;

            if (GameScene.Game.User.Class != MirClass.Assassin)
                return;

            // 判定技能是否存在
            ClientUserMagic clientUserMagic = GetUserSkill(magicType);

            if (clientUserMagic == null)
                return;

            bool canUseAttack = false;
            // 
            if (needBuff != BuffType.None)
            {
                if (GameScene.Game.User.Buffs.Any(x => x.Type == needBuff))
                {
                    canUseAttack = true;
                }
            }
            else
            {
                canUseAttack = true;
                foreach (var buf in Assassin4Buffer)
                {
                    if (GameScene.Game.User.Buffs.Any(x => x.Type == buf))
                    {
                        canUseAttack = false;
                        break;
                    }
                }
            }

            if (!canUseAttack)
                return;

            if (CEnvir.Now < GameScene.Game.ToggleTime || CEnvir.Now < clientUserMagic.NextCast)
                return;

            if (GameScene.Game.User.AttackMagic != clientUserMagic.Info.Magic)
            {
                GameScene.Game.ReceiveChat($"{clientUserMagic.Info.Name} 准备就绪.", MessageType.Hint);
                int attackDelay = CartoonGlobals.AttackDelay - MapObject.User.Stats[Stat.AttackSpeed] * CartoonGlobals.ASpeedRate;
                attackDelay = Math.Max(800, attackDelay);

                GameScene.Game.ToggleTime = CEnvir.Now + TimeSpan.FromMilliseconds(attackDelay + 200);

                GameScene.Game.User.AttackMagic = clientUserMagic.Info.Magic;
            }

        }
        */

        private void Assassin4Magic(MagicType magicType, BuffType needBuff)
        {
            if (!ckCheckBox.Checked)
                return;

            if (GameScene.Game.User.Class != MirClass.Assassin)
                return;

            // 判定技能是否存在
            ClientUserMagic clientUserMagic = GetUserSkill(magicType);

            if (clientUserMagic == null)
                return;

            //bool flag = true;

            if (ckCheckBox.Checked)
            {
                if (!MapControl.User.Buffs.Any<ClientBuffInfo>((Func<ClientBuffInfo, bool>)(x =>
                {
                    if (x.Type != BuffType.FullBloom && x.Type != BuffType.WhiteLotus)
                        return x.Type == BuffType.RedLotus;
                    return true;
                })))
                {
                    GameScene.Game.UseMagic(MagicType.FullBloom);
                    //flag = false;
                }
                if (MapControl.User.Buffs.Any<ClientBuffInfo>((Func<ClientBuffInfo, bool>)(x => x.Type == BuffType.FullBloom)))
                {
                    GameScene.Game.UseMagic(MagicType.WhiteLotus);
                    //flag = false;
                }
                if (MapControl.User.Buffs.Any<ClientBuffInfo>((Func<ClientBuffInfo, bool>)(x => x.Type == BuffType.WhiteLotus)))
                {
                    GameScene.Game.UseMagic(MagicType.RedLotus);
                    //flag = false;
                }
                if (MapControl.User.Buffs.Any<ClientBuffInfo>((Func<ClientBuffInfo, bool>)(x => x.Type == BuffType.RedLotus)))
                {
                    GameScene.Game.UseMagic(MagicType.SweetBrier);
                    //flag = false;
                }
            }
        }

        private void AssistUseMagic(MagicType magicType, bool enable)
        {
            if (!enable)
                return;

            // 判定技能是否存在
            ClientUserMagic clientUserMagic = GetUserSkill(magicType);

            if (clientUserMagic == null)
                return;

            // 判定是否buff技能,
            BuffType buffType = IsBuffSkill(magicType);
            if (buffType > BuffType.None && buffType < BuffType.MagicWeakness)
            {
                // buff技能 判定buff是否存在, 
                if (!GameScene.Game.User.Buffs.Any(x => x.Type == buffType))
                {
                    TimeSpan remaining = clientUserMagic.NextCast - CEnvir.Now;
                    if (remaining.TotalMilliseconds <= 0)
                    {
                        // 不存在和Cd0就使用
                        GameScene.Game.UseMagic(SpellKey.None, clientUserMagic);
                    }
                    // 不存在就使用
                    //GameScene.Game.UseMagic(SpellKey.None, clientUserMagic);
                }
            }
            else
            {
                // 非buff技能. 查看技能cd
                TimeSpan remaining = clientUserMagic.NextCast - CEnvir.Now;
                if (remaining.TotalMilliseconds <= 0)
                {
                    GameScene.Game.UseMagic(SpellKey.None, clientUserMagic);
                }
            }
        }

        #region Methods


        public void UpdateLocations()
        {
            int y = -ScrollBar.Value;

            foreach (AutoPotionRow row in Rows)
                row.Location = new Point(1, 1 + 50 * row.Index + y);
        }

        public bool Updating;

        private void showindex(MirClass Class)
        {
            switch (Class)
            {
                case MirClass.Warrior:
                    break;
                case MirClass.Wizard:
                    break;
                case MirClass.Taoist:
                    break;
                case MirClass.Assassin:
                    break;
            }
        }

        public void UpdateLinks(StartInformation info)
        {
            showindex(info.Class);
            Updating = true;
            foreach (ClientAutoPotionLink link1 in Links)
            {
                ClientAutoPotionLink link = link1;
                if (link != null && link.Slot >= 0 && link.Slot < Rows.Length)
                {
                    Rows[link.Slot].ItemCell.QuickInfo = CartoonGlobals.ItemInfoList.Binding.FirstOrDefault<Library.SystemModels.ItemInfo>((Func<Library.SystemModels.ItemInfo, bool>)(x => x.Index == link.LinkInfoIndex));
                    Rows[link.Slot].HealthTargetBox.Value = (long)link.Health;
                    Rows[link.Slot].ManaTargetBox.Value = (long)link.Mana;
                    Rows[link.Slot].EnabledCheckBox.Checked = link.Enabled;
                }
            }

            foreach (ClientUserMagic magic in info.Magics)
            {
                DXListBoxItem dxListBoxItem3 = new DXListBoxItem();
                dxListBoxItem3.Parent = (DXControl)SetSingleHookSkillsComboBox.ListBox;
                dxListBoxItem3.Label.Text = magic.Info.Name;
                dxListBoxItem3.Item = (object)magic.Info.Magic;
            }

            foreach (ClientAutoFightLink autoFightLink in info.AutoFightLinks)
            {

                if (autoFightLink.Slot == AutoSetConf.SetAutoPoisonBox)
                    SetAutoPoisonBox.Checked = autoFightLink.Enabled;
                if (autoFightLink.Slot == AutoSetConf.SetAutoAvoidBox)
                    SetAutoAvoidBox.Checked = autoFightLink.Enabled;
                if (autoFightLink.Slot == AutoSetConf.SetDeathResurrectionBox)
                    SetDeathResurrectionBox.Checked = autoFightLink.Enabled;
                if (autoFightLink.Slot == AutoSetConf.SetSingleHookSkillsBox)
                {
                    SetSingleHookSkillsBox.Checked = autoFightLink.Enabled;
                    SetSingleHookSkillsComboBox.ListBox.SelectItem((object)autoFightLink.MagicIndex);
                }
                if (autoFightLink.Slot == AutoSetConf.SetRandomItemBox)
                {
                    SetRandomItemBox.Checked = autoFightLink.Enabled;
                    TimeBox3.Value = (long)autoFightLink.TimeCount;
                }
                if (autoFightLink.Slot == AutoSetConf.SetHomeItemBox)
                {
                    SetHomeItemBox.Checked = autoFightLink.Enabled;
                    TimeBox4.Value = (long)autoFightLink.TimeCount;
                }
                if (autoFightLink.Slot == AutoSetConf.SuijiBox)
                {
                    SuijiBox.Checked = autoFightLink.Enabled;
                    TimeBox5.Value = (long)autoFightLink.TimeCount;
                }
                if (autoFightLink.Slot == AutoSetConf.SuijisBox)
                {
                    SuijisBox.Checked = autoFightLink.Enabled;
                    TimeBox6.Value = (long)autoFightLink.TimeCount;
                }
            }

            /*
            foreach (ClientAutoFightLink autoFightLink in info.AutoFightLinks)
            {
                if (autoFightLink.Slot == AutoSetConf.SetBladeStormBox)
                    SetBladeStormBox.Checked = autoFightLink.Enabled;
                if (autoFightLink.Slot == AutoSetConf.SetBrightBox)
                {
                    SetBrightBox.Checked = autoFightLink.Enabled;
                    GameScene.Game?.MapControl?.LLayer.UpdateLights();
                }
                if (autoFightLink.Slot == AutoSetConf.SetCelestialBox)
                    SetCelestialBox.Checked = autoFightLink.Enabled;
                if (autoFightLink.Slot == AutoSetConf.SetCorpseBox)
                    SetCorpseBox.Checked = autoFightLink.Enabled;
                if (autoFightLink.Slot == AutoSetConf.SetDisplayBox)
                    SetDisplayBox.Checked = autoFightLink.Enabled;
                if (autoFightLink.Slot == AutoSetConf.SetDragobRiseBox)
                    SetDragobRiseBox.Checked = autoFightLink.Enabled;
                if (autoFightLink.Slot == AutoSetConf.SetFlamingSwordBox)
                    SetFlamingSwordBox.Checked = autoFightLink.Enabled;
                if (autoFightLink.Slot == AutoSetConf.SetFourFlowersBox)
                    SetFourFlowersBox.Checked = autoFightLink.Enabled;
                if (autoFightLink.Slot == AutoSetConf.SetMagicShieldBox)
                    SetMagicShieldBox.Checked = autoFightLink.Enabled;
                if (autoFightLink.Slot == AutoSetConf.SetMagicskills1Box)
                {
                    SetMagicskills1Box.Checked = autoFightLink.Enabled;
                    SetMagicskills1ComboBox.ListBox.SelectItem((object)autoFightLink.MagicIndex);
                    TimeBox2.Value = (long)autoFightLink.TimeCount;
                }
                if (autoFightLink.Slot == AutoSetConf.SetMagicskillsBox)
                {
                    SetMagicskillsBox.Checked = autoFightLink.Enabled;
                    SetMagicskillsComboBox.ListBox.SelectItem((object)autoFightLink.MagicIndex);
                    TimeBox1.Value = (long)autoFightLink.TimeCount;
                }
                if (autoFightLink.Slot == AutoSetConf.SetPickUpBox)
                    SetPickUpBox.Checked = autoFightLink.Enabled;
                if (autoFightLink.Slot == AutoSetConf.SetPoisonDustBox)
                    SetPoisonDustBox.Checked = autoFightLink.Enabled;
                if (autoFightLink.Slot == AutoSetConf.SetRenounceBox)
                    SetRenounceBox.Checked = autoFightLink.Enabled;
                if (autoFightLink.Slot == AutoSetConf.SetRunCheckBox)
                    SetRunCheckBox.Checked = autoFightLink.Enabled;
                if (autoFightLink.Slot == AutoSetConf.SetShiftBox)
                    SetShiftBox.Checked = autoFightLink.Enabled;
                if (autoFightLink.Slot == AutoSetConf.SetAutoPoisonBox)
                    SetAutoPoisonBox.Checked = autoFightLink.Enabled;
                if (autoFightLink.Slot == AutoSetConf.SetAutoAvoidBox)
                    SetAutoAvoidBox.Checked = autoFightLink.Enabled;
                if (autoFightLink.Slot == AutoSetConf.SetDeathResurrectionBox)
                    SetDeathResurrectionBox.Checked = autoFightLink.Enabled;
                if (autoFightLink.Slot == AutoSetConf.SetSingleHookSkillsBox)
                {
                    SetSingleHookSkillsBox.Checked = autoFightLink.Enabled;
                    SetSingleHookSkillsComboBox.ListBox.SelectItem((object)autoFightLink.MagicIndex);
                }
                if (autoFightLink.Slot == AutoSetConf.SetRandomItemBox)
                {
                    SetRandomItemBox.Checked = autoFightLink.Enabled;
                    TimeBox3.Value = (long)autoFightLink.TimeCount;
                }
                if (autoFightLink.Slot == AutoSetConf.SetHomeItemBox)
                {
                    SetHomeItemBox.Checked = autoFightLink.Enabled;
                    TimeBox4.Value = (long)autoFightLink.TimeCount;
                }
                if (autoFightLink.Slot == AutoSetConf.SetDefianceBox)
                    SetDefianceBox.Checked = autoFightLink.Enabled;
                if (autoFightLink.Slot == AutoSetConf.SetMightBox)
                    SetMightBox.Checked = autoFightLink.Enabled;
                if (autoFightLink.Slot == AutoSetConf.SetShowXue)
                    SetShowXue.Checked = autoFightLink.Enabled;
                if (autoFightLink.Slot == AutoSetConf.SetEvasionBox)
                    SetEvasionBox.Checked = autoFightLink.Enabled;
                if (autoFightLink.Slot == AutoSetConf.SerRagingWindBox)
                    SerRagingWindBox.Checked = autoFightLink.Enabled;
                if (autoFightLink.Slot == AutoSetConf.SetJsPickUpBox)
                    SetJsPickUpBox.Checked = autoFightLink.Enabled;
                if (autoFightLink.Slot == AutoSetConf.SetCwPickUpBox)
                    SetCwPickUpBox.Checked = autoFightLink.Enabled;
            }
            */
            Updating = false;
        }
        #endregion


        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (FilterItems != null)
            {
                if (!File.Exists(filterName))
                {
                    File.Create(filterName);
                }

                string[] lines1 = new string[FilterItems.Length];
                for (int i = 0; i < FilterItems.Length; i++)
                {
                    lines1[i] = $"{FilterItems[i].name}, {FilterItems[i].canPickup}, {FilterItems[i].highLight}, {FilterItems[i].xianshi}";
                }
                File.WriteAllLines(filterName, lines1);
            }

            //魔法技能配置
            if (MagicFilterItems != null)
            {
                if (!File.Exists(magicconfig))
                {
                    File.Create(magicconfig);
                }

                string[] lines1 = new string[MagicFilterItems.Length];
                for (int i = 0; i < MagicFilterItems.Length; i++)
                {
                    lines1[i] = $"{MagicFilterItems[i].name}, {MagicFilterItems[i].suo}, {MagicFilterItems[i].fu}";
                }
                File.WriteAllLines(magicconfig, lines1);
            }

            if (disposing)
            {

                if (Links != null)
                {
                    for (int i = 0; i < Links.Length; i++)
                        Links[i] = null;

                    Links = null;
                }

                for (int i = 0; i < Rows.Length; i++)
                {
                    if (Rows[i] == null) continue;

                    if (!Rows[i].IsDisposed)
                        Rows[i].Dispose();

                    Rows[i] = null;
                }

                Rows = null;

                if (ScrollBar != null)
                {
                    if (!ScrollBar.IsDisposed)
                        ScrollBar.Dispose();

                    ScrollBar = null;
                }
            }

        }

        #endregion
    }

    public sealed class AutoPotionRow : DXControl
    {
        #region Properties

        #region UseItem

        public ItemInfo UseItem
        {
            get => _UseItem;
            set
            {
                if (_UseItem == value) return;

                ItemInfo oldValue = _UseItem;
                _UseItem = value;

                OnUseItemChanged(oldValue, value);
            }
        }
        private ItemInfo _UseItem;
        public event EventHandler<EventArgs> UseItemChanged;
        public void OnUseItemChanged(ItemInfo oValue, ItemInfo nValue)
        {
            UseItemChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Index

        public int Index
        {
            get => _Index;
            set
            {
                if (_Index == value) return;

                int oldValue = _Index;
                _Index = value;

                OnIndexChanged(oldValue, value);
            }
        }
        private int _Index;
        public event EventHandler<EventArgs> IndexChanged;
        public void OnIndexChanged(int oValue, int nValue)
        {
            IndexChanged?.Invoke(this, EventArgs.Empty);
            IndexLabel.Text = (Index + 1).ToString();
            ItemCell.Slot = Index;

            UpButton.Enabled = Index > 0;
            DownButton.Enabled = Index < 7;
        }

        #endregion

        public DXLabel IndexLabel, HealthLabel, ManaLabel;
        public DXItemCell ItemCell;
        public DXNumberBox HealthTargetBox, ManaTargetBox;
        public DXCheckBox EnabledCheckBox;
        public DXButton UpButton, DownButton;

        #endregion

        public AutoPotionRow()
        {
            Size = new Size(260, 46);

            Border = true;
            BorderColour = Color.FromArgb(198, 166, 99);

            UpButton = new DXButton
            {
                Index = 44,
                LibraryFile = LibraryFile.Interface,
                Location = new Point(5, 5),
                Parent = this,
                Enabled = false,
            };
            UpButton.MouseClick += (o, e) =>
            {
                GameScene.Game.AutoPotionBox.Updating = true;

                int hp = (int)HealthTargetBox.Value;
                int mp = (int)ManaTargetBox.Value;
                bool enabled = EnabledCheckBox.Checked;
                ItemInfo info = ItemCell.QuickInfo;

                ItemCell.QuickInfo = GameScene.Game.AutoPotionBox.Rows[Index - 1].ItemCell.QuickInfo;
                HealthTargetBox.Value = GameScene.Game.AutoPotionBox.Rows[Index - 1].HealthTargetBox.Value;
                ManaTargetBox.Value = GameScene.Game.AutoPotionBox.Rows[Index - 1].ManaTargetBox.Value;
                EnabledCheckBox.Checked = GameScene.Game.AutoPotionBox.Rows[Index - 1].EnabledCheckBox.Checked;

                GameScene.Game.AutoPotionBox.Rows[Index - 1].ItemCell.QuickInfo = info;
                GameScene.Game.AutoPotionBox.Rows[Index - 1].HealthTargetBox.Value = hp;
                GameScene.Game.AutoPotionBox.Rows[Index - 1].ManaTargetBox.Value = mp;
                GameScene.Game.AutoPotionBox.Rows[Index - 1].EnabledCheckBox.Checked = enabled;

                GameScene.Game.AutoPotionBox.Updating = false;

                SendUpdate();
                GameScene.Game.AutoPotionBox.Rows[Index - 1].SendUpdate();
            };

            DownButton = new DXButton
            {
                Index = 46,
                LibraryFile = LibraryFile.Interface,
                Location = new Point(5, 29),
                Parent = this,
            };
            DownButton.MouseClick += (o, e) =>
            {
                GameScene.Game.AutoPotionBox.Updating = true;

                int hp = (int)HealthTargetBox.Value;
                int mp = (int)ManaTargetBox.Value;
                bool enabled = EnabledCheckBox.Checked;
                ItemInfo info = ItemCell.QuickInfo;

                ItemCell.QuickInfo = GameScene.Game.AutoPotionBox.Rows[Index + 1].ItemCell.QuickInfo;
                HealthTargetBox.Value = GameScene.Game.AutoPotionBox.Rows[Index + 1].HealthTargetBox.Value;
                ManaTargetBox.Value = GameScene.Game.AutoPotionBox.Rows[Index + 1].ManaTargetBox.Value;
                EnabledCheckBox.Checked = GameScene.Game.AutoPotionBox.Rows[Index + 1].EnabledCheckBox.Checked;

                GameScene.Game.AutoPotionBox.Rows[Index + 1].ItemCell.QuickInfo = info;
                GameScene.Game.AutoPotionBox.Rows[Index + 1].HealthTargetBox.Value = hp;
                GameScene.Game.AutoPotionBox.Rows[Index + 1].ManaTargetBox.Value = mp;
                GameScene.Game.AutoPotionBox.Rows[Index + 1].EnabledCheckBox.Checked = enabled;

                GameScene.Game.AutoPotionBox.Updating = false;

                SendUpdate();
                GameScene.Game.AutoPotionBox.Rows[Index + 1].SendUpdate();
            };

            ItemCell = new DXItemCell
            {
                Parent = this,
                Location = new Point(20, 5),
                AllowLink = true,
                FixedBorder = true,
                Border = true,
                GridType = GridType.AutoPotion,
            };

            IndexLabel = new DXLabel
            {
                Parent = ItemCell,
                Text = (Index + 1).ToString(),
                Font = new Font(Config.FontName, CEnvir.FontSize(8F), FontStyle.Italic),
                IsControl = false,
                Location = new Point(-2, -1)
            };


            HealthTargetBox = new DXNumberBox
            {
                Parent = this,
                Location = new Point(105, 5),
                Size = new Size(80, 20),
                ValueTextBox = { Size = new Size(40, 18) },
                MaxValue = 50000,
                MinValue = 0,
                UpButton = { Location = new Point(63, 1) }
            };
            HealthTargetBox.ValueTextBox.ValueChanged += (o, e) => SendUpdate();

            ManaTargetBox = new DXNumberBox
            {
                Parent = this,
                Location = new Point(105, 25),
                Size = new Size(80, 20),
                ValueTextBox = { Size = new Size(40, 18) },
                MaxValue = 50000,
                MinValue = 0,
                UpButton = { Location = new Point(63, 1) }
            };
            ManaTargetBox.ValueTextBox.ValueChanged += (o, e) => SendUpdate();

            HealthLabel = new DXLabel
            {
                Parent = this,
                IsControl = false,
                Text = "生命:"
            };
            HealthLabel.Location = new Point(HealthTargetBox.Location.X - HealthLabel.Size.Width, HealthTargetBox.Location.Y + (HealthTargetBox.Size.Height - HealthLabel.Size.Height) / 2);


            ManaLabel = new DXLabel
            {
                Parent = this,
                IsControl = false,
                Text = "魔法:"
            };
            ManaLabel.Location = new Point(ManaTargetBox.Location.X - ManaLabel.Size.Width, ManaTargetBox.Location.Y + (ManaTargetBox.Size.Height - ManaLabel.Size.Height) / 2);

            EnabledCheckBox = new DXCheckBox
            {
                Label = { Text = "启用" },
                Parent = this,
            };
            EnabledCheckBox.CheckedChanged += (o, e) => SendUpdate();

            EnabledCheckBox.Location = new Point(Size.Width - EnabledCheckBox.Size.Width - 5, 5);
        }

        #region Methods

        public void SendUpdate()
        {
            if (GameScene.Game.Observer) return;

            if (GameScene.Game.AutoPotionBox.Updating) return;

            CEnvir.Enqueue(new C.AutoPotionLinkChanged { Slot = Index, LinkIndex = ItemCell.Item?.Info.Index ?? -1, Enabled = EnabledCheckBox.Checked, Health = (int)HealthTargetBox.Value, Mana = (int)ManaTargetBox.Value });


        }
        #endregion

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                _UseItem = null;
                UseItemChanged = null;

                _Index = 0;
                IndexChanged = null;

                if (IndexLabel != null)
                {
                    if (!IndexLabel.IsDisposed)
                        IndexLabel.Dispose();

                    IndexLabel = null;
                }

                if (HealthLabel != null)
                {
                    if (!HealthLabel.IsDisposed)
                        HealthLabel.Dispose();

                    HealthLabel = null;
                }

                if (ManaLabel != null)
                {
                    if (!ManaLabel.IsDisposed)
                        ManaLabel.Dispose();

                    ManaLabel = null;
                }

                if (ItemCell != null)
                {
                    if (!ItemCell.IsDisposed)
                        ItemCell.Dispose();

                    ItemCell = null;
                }

                if (HealthTargetBox != null)
                {
                    if (!HealthTargetBox.IsDisposed)
                        HealthTargetBox.Dispose();

                    HealthTargetBox = null;
                }

                if (ManaTargetBox != null)
                {
                    if (!ManaTargetBox.IsDisposed)
                        ManaTargetBox.Dispose();

                    ManaTargetBox = null;
                }

                if (EnabledCheckBox != null)
                {
                    if (!EnabledCheckBox.IsDisposed)
                        EnabledCheckBox.Dispose();

                    EnabledCheckBox = null;
                }

                if (UpButton != null)
                {
                    if (!UpButton.IsDisposed)
                        UpButton.Dispose();

                    UpButton = null;
                }

                if (DownButton != null)
                {
                    if (!DownButton.IsDisposed)
                        DownButton.Dispose();

                    DownButton = null;
                }

            }

        }

        #endregion
    }


    public class FilterItem
    {
        public string name;
        public short canPickup;
        public short highLight;
        public short xianshi;

        public static Color GetHighColor(int highLight)
        {
            Color color = Color.Linen;
            switch (highLight)
            {
                case 0:
                    color = Color.Linen;
                    break;
                case 1:
                    color = Color.GreenYellow;
                    break;
                case 2:
                    color = Color.CornflowerBlue;
                    break;
                case 3:
                    color = Color.Orchid;
                    break;
                case 4:
                    color = Color.DarkOrange;
                    break;
                default:
                    break;

            }

            return color;
        }

    }

    // 过滤表
    public sealed class PickupItem : DXControl
    {


        #region Properties

        public int ItemIndex;

        #region Selected

        public bool Selected
        {
            get => _Selected;
            set
            {
                if (_Selected == value) return;

                bool oldValue = _Selected;
                _Selected = value;

                OnSelectedChanged(oldValue, value);
            }
        }
        private bool _Selected;
        //public event EventHandler<EventArgs> SelectedChanged;
        public void OnSelectedChanged(bool oValue, bool nValue)
        {
            BackColour = Selected ? Color.FromArgb(80, 80, 125) : Color.FromArgb(25, 20, 0);

            //SelectedChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        public DXLabel NameLabel, PickupLabel, HeightLightLabel, xianshiLabel;

        #endregion

        public PickupItem()
        {
            Size = new Size(270, 24);

            DrawTexture = true;
            BackColour = Selected ? Color.FromArgb(80, 80, 125) : Color.FromArgb(25, 20, 0);

            Visible = true;

            NameLabel = new DXLabel
            {
                Parent = this,
                Location = new Point(5, 2),
                IsControl = false,
            };

            PickupLabel = new DXLabel
            {
                Parent = this,
                Text = "拾",
                IsControl = false,

            };
            PickupLabel.Location = new Point(155, 2);

            HeightLightLabel = new DXLabel
            {
                Parent = this,
                Text = "发光:",
                IsControl = false,

            };
            HeightLightLabel.Location = new Point(210, 2);

            xianshiLabel = new DXLabel
            {
                Parent = this,
                Text = "显示:",
                IsControl = false,

            };
            xianshiLabel.Location = new Point(240, 2);
        }

        public void ResetProp(string name, short pickup, short highLight, short xianshi)
        {
            NameLabel.Text = name;

            if (pickup == 0)
            {
                PickupLabel.Text = "不拾";
                PickupLabel.ForeColour = Color.White;
            }
            else if (pickup == 1)
            {
                PickupLabel.Text = "精准拾取";
                PickupLabel.ForeColour = Color.Yellow;
            }
            else if (pickup == 2)
            {
                PickupLabel.Text = "模糊拾取";
                PickupLabel.ForeColour = Color.GreenYellow;
            }
            else { }

            if (highLight <= 1)
                HeightLightLabel.Text = "普通";
            else
                HeightLightLabel.Text = "发光";
            HeightLightLabel.ForeColour = FilterItem.GetHighColor(highLight);

            if (xianshi > 0)
            {
                xianshiLabel.Text = "显示";
                xianshiLabel.ForeColour = Color.GreenYellow;
            }
            else if (xianshi == 0)
            {
                xianshiLabel.Text = "不显";
                xianshiLabel.ForeColour = Color.White;
            }

            PickupLabel.Tag = pickup;
            HeightLightLabel.Tag = highLight;
            xianshiLabel.Tag = xianshi;
        }

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {

                _Selected = false;
                //SelectedChanged = null;

                if (NameLabel != null)
                {
                    if (!NameLabel.IsDisposed)
                        NameLabel.Dispose();

                    NameLabel = null;
                }

                if (PickupLabel != null)
                {
                    if (!PickupLabel.IsDisposed)
                        PickupLabel.Dispose();

                    PickupLabel = null;
                }

                if (HeightLightLabel != null)
                {
                    if (!HeightLightLabel.IsDisposed)
                        HeightLightLabel.Dispose();

                    HeightLightLabel = null;
                }

                if (xianshiLabel != null)
                {
                    if (!xianshiLabel.IsDisposed)
                        xianshiLabel.Dispose();

                    xianshiLabel = null;
                }

            }

        }

        #endregion
    }
    //魔法技能配置
    public class MagicFilterItem
    {
        public string name;
        public short suo;
        public short fu;

        public static Color GetMagicHighColor(int highLight)
        {
            Color color = Color.Linen;
            switch (highLight)
            {
                case 0:
                    color = Color.White;
                    break;
                case 1:
                    color = Color.Cyan;
                    break;
                case 2:
                    color = Color.Lime;
                    break;
                case 3:
                    color = Color.Lime;
                    break;
                case 4:
                    color = Color.Lime;
                    break;
                case 5:
                    color = Color.Lime;
                    break;
                case 6:
                    color = Color.Orange;
                    break;
                case 7:
                    color = Color.Orange;
                    break;
                case 8:
                    color = Color.LightSalmon;
                    break;
                case 9:
                    color = Color.Yellow;
                    break;
                case 10:
                    color = Color.Pink;
                    break;
                case 11:
                    color = Color.Pink;
                    break;
                case 12:
                    color = Color.Pink;
                    break;
                default:
                    color = Color.White;
                    break;

            }

            return color;
        }

    }
    //魔法技能配置
    public sealed class MagicConfig : DXControl
    {


        #region Properties

        public int MagicIndex;

        #region Selected

        public bool Selected
        {
            get => _Selected;
            set
            {
                if (_Selected == value) return;

                bool oldValue = _Selected;
                _Selected = value;

                OnSelectedChanged(oldValue, value);
            }
        }
        private bool _Selected;
        //public event EventHandler<EventArgs> SelectedChanged;
        public void OnSelectedChanged(bool oValue, bool nValue)
        {
            BackColour = Selected ? Color.FromArgb(80, 80, 125) : Color.FromArgb(25, 20, 0);

            //SelectedChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        public DXLabel NameLabel, SuoLabel, FuLabel;

        #endregion

        public MagicConfig()
        {
            Size = new Size(270, 24);

            DrawTexture = true;
            BackColour = Selected ? Color.FromArgb(80, 80, 125) : Color.FromArgb(25, 20, 0);

            Visible = true;

            NameLabel = new DXLabel
            {
                Parent = this,
                Location = new Point(5, 2),
                IsControl = false,
            };

            SuoLabel = new DXLabel
            {
                Parent = this,
                Text = "未选",
                IsControl = false,

            };
            SuoLabel.Location = new Point(150, 2);

            FuLabel = new DXLabel
            {
                Parent = this,
                Text = "未选择",
                IsControl = false,

            };
            FuLabel.Location = new Point(195, 2);
        }

        public void ResetProp(string name, short suo, short fu)
        {
            NameLabel.Text = name;

            if (suo == 0)
            {
                SuoLabel.Text = "未选";
                SuoLabel.ForeColour = Color.White;
            }
            else if (suo == 1)
            {
                SuoLabel.Text = "锁怪";
                SuoLabel.ForeColour = Color.Coral;
            }
            else if (suo == 2)
            {
                SuoLabel.Text = "锁人";
                SuoLabel.ForeColour = Color.Lime;
            }
            else if (suo == 3)
            {
                SuoLabel.Text = "锁全";
                SuoLabel.ForeColour = Color.DeepSkyBlue;
            }
            else
                SuoLabel.Text = "未选";

            if (fu == 0)
                FuLabel.Text = "未选择";
            else if (fu == 1)
                FuLabel.Text = "护身符";
            else if (fu == 2)
                FuLabel.Text = "火焰护身符";
            else if (fu == 3)
                FuLabel.Text = "寒冰护身符";
            else if (fu == 4)
                FuLabel.Text = "霹雷护身符";
            else if (fu == 5)
                FuLabel.Text = "狂风护身符";
            else if (fu == 6)
                FuLabel.Text = "神圣护身符";
            else if (fu == 7)
                FuLabel.Text = "暗黑护身符";
            else if (fu == 8)
                FuLabel.Text = "幻影护身符";
            else if (fu == 9)
                FuLabel.Text = "灵魂护身符";
            else if (fu == 10)
                FuLabel.Text = "红毒";
            else if (fu == 11)
                FuLabel.Text = "绿毒";
            else if (fu == 12)
                FuLabel.Text = "红绿毒替换";
            else
                FuLabel.Text = "未选泽";

            FuLabel.ForeColour = MagicFilterItem.GetMagicHighColor(fu);


            SuoLabel.Tag = suo;
            FuLabel.Tag = fu;
        }

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {

                _Selected = false;
                //SelectedChanged = null;

                if (NameLabel != null)
                {
                    if (!NameLabel.IsDisposed)
                        NameLabel.Dispose();

                    NameLabel = null;
                }

                if (SuoLabel != null)
                {
                    if (!SuoLabel.IsDisposed)
                        SuoLabel.Dispose();

                    SuoLabel = null;
                }

                if (FuLabel != null)
                {
                    if (!FuLabel.IsDisposed)
                        FuLabel.Dispose();

                    FuLabel = null;
                }
            }

        }

        #endregion
    }

}

