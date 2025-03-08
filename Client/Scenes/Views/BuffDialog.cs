using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Client.Controls;
using Client.Envir;
using Client.Models;
using Client.UserModels;
using Library;
using Library.SystemModels;


namespace Client.Scenes.Views
{
    public sealed class BuffDialog : DXWindow
    {
        #region Properties
        private Dictionary<ClientBuffInfo, DXImageControl> Icons = new Dictionary<ClientBuffInfo, DXImageControl>();

        public override WindowType Type => WindowType.BuffBox;
        public override bool CustomSize => false;
        public override bool AutomaticVisiblity => true;
        #endregion

        public BuffDialog()
        {
            HasTitle = false;
            HasFooter = false;
            HasTopBorder = false;
            TitleLabel.Visible = false;
            CloseButton.Visible = false;
            Opacity = 0.6F;
            
            Size = new Size(30, 30);
        }

        #region Methods
        public void BuffsChanged()
        {
            foreach (DXImageControl control in Icons.Values)
                control.Dispose();

            Icons.Clear();

            List<ClientBuffInfo> buffs = MapObject.User.Buffs.ToList();

            Stats permStats = new Stats();

            for (int i = buffs.Count - 1; i >= 0; i--)
            {
                ClientBuffInfo buff = buffs[i];

                switch (buff.Type)
                {
                    case BuffType.ItemBuff:
                        if (buff.RemainingTime != TimeSpan.MaxValue) continue;

                        permStats.Add(CartoonGlobals.ItemInfoList.Binding.First(x => x.Index == buff.ItemIndex).Stats);

                        buffs.Remove(buff);
                        break;
                    case BuffType.Ranking:
                    case BuffType.Developer:
                        buffs.Remove(buff);
                        break;
                }
            }


            if (permStats.Count > 0)
                buffs.Add(new ClientBuffInfo { Index = 0, Stats = permStats, Type = BuffType.ItemBuffPermanent, RemainingTime = TimeSpan.MaxValue });

            buffs.Sort((x1, x2) => x2.RemainingTime.CompareTo(x1.RemainingTime));




            foreach (ClientBuffInfo buff in buffs)
            {
                DXImageControl icon;
                Icons[buff] = icon = new DXImageControl
                {
                    Parent = this,
                    LibraryFile = LibraryFile.CBIcon,
                };

                switch (buff.Type)
                {
                    case BuffType.Heal:
                        icon.Index = 78;
                        break;
                    
                    
                    case BuffType.Mana:
                        icon.Index = 149;
                        break;
                    case BuffType.Invisibility:
                        icon.Index = 74;
                        break;
                    case BuffType.MagicResistance:
                        icon.Index = 92;
                        break;
                    case BuffType.Resilience:
                        icon.Index = 91;
                        break;
                    case BuffType.PoisonousCloud:
                        icon.Index = 98;
                        break;
                    case BuffType.Castle:
                        icon.Index = 242;
                        break;
                    case BuffType.FullBloom:
                        icon.Index = 162;
                        break;
                    case BuffType.WhiteLotus:
                        icon.Index = 163;
                        break;
                    case BuffType.RedLotus:
                        icon.Index = 164;
                        break;
                    case BuffType.MagicShield:
                        icon.Index = 100;
                        break;
                    case BuffType.FrostBite:
                        icon.Index = 221;
                        break;
                    case BuffType.ElementalSuperiority:
                        icon.Index = 93;
                        break;
                    case BuffType.BloodLust:
                        icon.Index = 90;
                        break;
                    case BuffType.Cloak:
                        icon.Index = 160;
                        break;
                    case BuffType.GhostWalk:
                        icon.Index = 160;
                        break;
                    case BuffType.Observable:
                        icon.Index = 172;
                        break;
                    case BuffType.TheNewBeginning:
                        icon.Index = 166;
                        break;
                    case BuffType.Veteran:
                        icon.Index = 171;
                        break;

                    case BuffType.Brown:
                        icon.Index = 229;
                        break;
                    case BuffType.PKPoint:
                        icon.Index = 266;
                        break;
                    case BuffType.Redemption:
                        icon.Index = 258;
                        break;
                    case BuffType.Renounce:
                        icon.Index = 94;
                        break;
                    case BuffType.Defiance:
                        icon.Index = 97;
                        break;
                    case BuffType.Might:
                        icon.Index = 96;
                        break;
                    case BuffType.ReflectDamage:
                        icon.Index = 98;
                        break;
                    case BuffType.Endurance:
                        icon.Index = 95;
                        break;
                    case BuffType.JudgementOfHeaven:
                        icon.Index = 99;
                        break;
                    case BuffType.StrengthOfFaith:
                        icon.Index = 141;
                        break;
                    case BuffType.CelestialLight:
                        icon.Index = 142;
                        break;
                    case BuffType.Transparency:
                        icon.Index = 160;
                        break;
                    case BuffType.LifeSteal:
                        icon.Index = 98;
                        break;
                    case BuffType.DarkConversion:
                        icon.Index = 166;
                        break;
                    case BuffType.DragonRepulse:
                        icon.Index = 165;
                        break;
                    case BuffType.Evasion:
                        icon.Index = 167;
                        break;
                    case BuffType.RagingWind:
                        icon.Index = 168;
                        break;
                    case BuffType.MagicWeakness:
                        icon.Index = 182;
                        break;
                    case BuffType.ItemBuff:
                        icon.Index = CartoonGlobals.ItemInfoList.Binding.First(x => x.Index == buff.ItemIndex).BuffIcon;
                        break;
                    case BuffType.PvPCurse:
                        icon.Index = 241;
                        break;

                    case BuffType.ItemBuffPermanent:
                        icon.Index = 81;
                        break;
                    case BuffType.HuntGold:
                        icon.Index = 264;
                        break;
                    case BuffType.Companion:
                        icon.Index = 137;
                        break;
                    case BuffType.MapEffect:
                        icon.Index = 76;
                        break;
                    case BuffType.Guild:
                        icon.Index = 140;
                        break;
                    case BuffType.Mapplayer:
                        icon.Index = 175;
                        break;
                    case BuffType.Mapmonster:
                        icon.Index = 176;
                        break;
                    /*
                case BuffType.Mapnpc:
                    icon.Index = 177;
                    break;
                    */
                    
                    case BuffType.Renshu:
                        icon.Index = 178;
                        break;
                    case BuffType.BossCount:
                        icon.Index = 179;
                        break;
                    case BuffType.Exp:
                        icon.Index = 127;
                        break;
                    case BuffType.GoldExp:
                        icon.Index = 127;
                        break;
                    case BuffType.RWBuffyi:
                        icon.Index = 187;
                        break;
                    case BuffType.RWBuffer:
                        icon.Index = 187;
                        break;
                    case BuffType.RWBuffsan:
                        icon.Index = 187;
                        break;
                    case BuffType.RWBuffsi:
                        icon.Index = 187;
                        break;
                    case BuffType.RWBuffwu:
                        icon.Index = 187;
                        break;
                    case BuffType.RWBuffliu:
                        icon.Index = 187;
                        break;
                    case BuffType.RWBuffqi:
                        icon.Index = 187;
                        break;
                    case BuffType.RWBuffba:
                        icon.Index = 187;
                        break;
                    case BuffType.RWBuffjiu:
                        icon.Index = 187;
                        break;
                    case BuffType.RWBuffshi:
                        icon.Index = 187;
                        break;
                    case BuffType.MonCount:
                        icon.Index = 176;
                        break;
                    case BuffType.Youliang:
                        icon.Index = 210;
                        break;
                    case BuffType.Jingzhi:
                        icon.Index = 211;
                        break;
                    case BuffType.Chuanshuo:
                        icon.Index = 212;
                        break;
                    case BuffType.Shenhua:
                        icon.Index = 213;
                        break;
                    case BuffType.GuildLv:
                        icon.Index = 244;
                        break;
                    case BuffType.GuildJiacheng:
                        icon.Index = 187;
                        break;
                    case BuffType.Invincibility:
                        icon.Index = 143;
                        break;
                    case BuffType.ElementalHurricane:
                        icon.Index = 98;
                        break;
                    case BuffType.SuperiorMagicShield:
                        icon.Index = 161;
                        break;
                    case BuffType.Concentration:
                        icon.Index = 201;
                        break;
                    case BuffType.GuildGongxian:
                        icon.Index = 170;
                        break;
                    case BuffType.GuildPaihang:
                        icon.Index = 72;
                        break;
                    case BuffType.VipMapYi:
                        icon.Index = 189;
                        break;
                    case BuffType.VipMapEr:
                        icon.Index = 190;
                        break;
                    case BuffType.VipMapSan:
                        icon.Index = 191;
                        break;
                    case BuffType.VipMapY:
                        icon.Index = 192;
                        break;
                    case BuffType.VipMapE:
                        icon.Index = 193;
                        break;
                    case BuffType.VipMapS:
                        icon.Index = 194;
                        break;
                    
                    
                    case BuffType.KongxiangYin:
                        icon.Index = 288;
                        break;
                    
                    case BuffType.LifeStealHeal:
                        icon.Index = 181;
                        break;
                    case BuffType.MoveSpeed:
                        icon.Index = 289;
                        break;
                    case BuffType.ChongzhuangYin:
                        icon.Index = 290;
                        break;
                    
                    
                    case BuffType.MiaoyinYin:
                        icon.Index = 291;
                        break;
                    
                    
                    case BuffType.HuoliMassHeal:
                        icon.Index = 258;
                        break;
                    default:
                        icon.Index = 73;
                        break;
                   
                }

                icon.ProcessAction = () =>
                {
                    if (MouseControl == icon)
                        icon.Hint = GetBuffHint(buff);
                };
            }

            for (int i = 0; i < buffs.Count; i++)
                Icons[buffs[i]].Location = new Point(3 + (i%6)*27, 3 + (i/6)*27);

            Size = new Size(3 + Math.Min(6, Math.Max(1, Icons.Count))*27, 3 + Math.Max(1, 1 +  (Icons.Count - 1)/6) * 27);
            
        }
        private string GetBuffHint(ClientBuffInfo buff)
        {
            string text = string.Empty;

            Stats stats = buff.Stats;

            switch (buff.Type)
            {
                case BuffType.Server:
                    text = $"服务器设置\n";
                    break;
                case BuffType.HuntGold:
                    text = $"赏金\n";
                    break;
                case BuffType.Observable:
                    text = "观察者模式\n\n允许他人观看你玩游戏\n";
                    break;
                case BuffType.Veteran:
                    text = $"回归者\n";
                    break;
                case BuffType.Brown:
                    text = $"灰名\n";
                    break;
                case BuffType.PKPoint:
                    text = $"PK值\n";
                    break;
                case BuffType.Redemption:
                    text = $"兑换钥匙\n";
                    break;
                case BuffType.Castle:
                    text = $"沙巴克城主\n";
                    break;
                case BuffType.Guild:
                    text = $"公会附加属性\n";
                    break;
                case BuffType.MapEffect:
                    text = $"地图附加属性\n";
                    break;
                case BuffType.ItemBuff:
                    ItemInfo info = CartoonGlobals.ItemInfoList.Binding.First(x => x.Index == buff.ItemIndex);
                    text = info.ItemName + "\n";
                    stats = info.Stats;
                    break;
                case BuffType.ItemBuffPermanent:
                    text = "永久附加属性\n";
                    break;
                case BuffType.Defiance:
                    text = $"铁布衫\n";
                    break;
                case BuffType.Might:
                    text = $"破血狂杀\n";
                    break;
                case BuffType.Endurance:
                    text = $"金刚之躯\n";
                    break;
                case BuffType.ReflectDamage:
                    text = $"移花接木\n";
                    break;
                case BuffType.Renounce:
                    text = $"凝血离魂\n";
                    break;
                case BuffType.MagicShield:
                    text = $"魔法盾\n";
                    break;
                case BuffType.FrostBite:
                    text = $"护身冰环\n";
                    break;
                case BuffType.JudgementOfHeaven:
                    text = $"天打雷劈\n";
                    break;
                case BuffType.Heal:
                    text = $"治愈术\n";
                    break;
                
                
                case BuffType.Mana:
                    text = $"治魔术\n";
                    break;
                case BuffType.Invisibility:
                    text = "隐身术\n" + "最显眼的地方也是最佳藏身之处\n";
                    break;
                case BuffType.MagicResistance:
                    text = $"幽灵盾\n";
                    break;
                case BuffType.Resilience:
                    text = $"神圣战甲术\n";
                    break;
                case BuffType.ElementalSuperiority:
                    text = $"强魔震法\n";
                    break;
                case BuffType.BloodLust:
                    text = $"猛虎强势\n";
                    break;
                case BuffType.StrengthOfFaith:
                    text = $"移花接玉\n";
                    break;
                case BuffType.CelestialLight:
                    text = $"阴阳法环\n";
                    break;
                case BuffType.Transparency:
                    text = $"妙影无踪\n";
                    break;
                case BuffType.LifeSteal:
                    text = $"吸星大法\n";
                    break;
                case BuffType.PoisonousCloud:
                    text = $"毒云\n";
                    break;
                case BuffType.FullBloom:
                    text = $"盛开\n";
                    break;
                case BuffType.WhiteLotus:
                    text = $"白莲\n";
                    break;
                case BuffType.RedLotus:
                    text = $"红莲\n";
                    break;
                case BuffType.Cloak:
                    text = $"潜行\n";
                    break;
                case BuffType.GhostWalk:
                    text = "鬼灵步\n\n让你在隐形的情况下移动得更快";
                    break;
                case BuffType.TheNewBeginning:
                    text = $"心机一转\n";
                    break;
                case BuffType.DarkConversion:
                    text = $"黄泉旅者\n";
                    break;
                case BuffType.DragonRepulse:
                    text = $"狂涛涌泉\n";
                    break;
                case BuffType.Evasion:
                    text = $"风之闪避\n";
                    break;
                case BuffType.RagingWind:
                    text = $"风之守护\n";
                    break;
                case BuffType.MagicWeakness:
                    text = "魔防衰弱\n\n你的魔法抗性大大降低\n";
                    break;
                case BuffType.Companion:
                    text = $"宠物附加属性\n";
                    break;
                case BuffType.Mapplayer:
                    text = $"副本剩余时间\n";
                    break;
                case BuffType.Mapmonster:
                    text = $"清理怪物时间\n";
                    break;
                    /*
                case BuffType.Mapnpc:
                    text = $"清理Npc时间\n";
                    break;
                    */
                
                case BuffType.Renshu:
                    text = $"玩家数量\n";
                    break;
                case BuffType.BossCount:
                    text = $"Boss数量\n";
                    break;
                case BuffType.Exp:
                    text = $"经验泡点\n";
                    break;
                case BuffType.GoldExp:
                    text = $"经验泡点\n";
                    break;
                case BuffType.RWBuffyi:
                    text = $"跑船任务\n";
                    break;
                case BuffType.RWBuffer:
                    text = $"雷霆跑跑剩余时间\n";
                    break;
                case BuffType.RWBuffsan:
                    text = $"任务\n";
                    break;
                case BuffType.RWBuffsi:
                    text = $"任务\n";
                    break;
                case BuffType.RWBuffwu:
                    text = $"任务\n";
                    break;
                case BuffType.RWBuffliu:
                    text = $"任务\n";
                    break;
                case BuffType.RWBuffqi:
                    text = $"任务\n";
                    break;
                case BuffType.RWBuffba:
                    text = $"任务\n";
                    break;
                case BuffType.RWBuffjiu:
                    text = $"任务\n";
                    break;
                case BuffType.RWBuffshi:
                    text = $"任务\n";
                    break;
                case BuffType.MonCount:
                    text = $"怪物数量\n";
                    break;
                case BuffType.Youliang:
                    text = $"优良套装属性\n";
                    break;
                case BuffType.Jingzhi:
                    text = $"精致套装属性\n";
                    break;
                case BuffType.Chuanshuo:
                    text = $"传说套装属性\n";
                    break;
                case BuffType.Shenhua:
                    text = $"神话套装属性\n";
                    break;
                case BuffType.GuildLv:
                    text = $"公会等级Buff\n";
                    break;
                case BuffType.GuildJiacheng:
                    text = $"公会加成活动Buff\n";
                    break;
                case BuffType.Invincibility:
                    text = $"无敌模式:你对所有伤害都免疫\n";
                    break;
                case BuffType.ElementalHurricane:
                    text = $"飓风\n";
                    break;
                case BuffType.SuperiorMagicShield:
                    text = $"魔光盾\n";
                    break;
                case BuffType.Concentration:
                    text = $"致命雷光\n";
                    break;
                case BuffType.GuildGongxian:
                    text = $"玛法贡献者\n";
                    break;
                case BuffType.GuildPaihang:
                    text = $"玛法第一公会\n";
                    break;
                case BuffType.VipMapYi:
                    text = $"青铜会员[包月]";
                    break;
                case BuffType.VipMapEr:
                    text = $"白银会员[包月]";
                    break;
                case BuffType.VipMapSan:
                    text = $"黄金会员[包月]";
                    break;
                case BuffType.VipMapY:
                    
                    info = CartoonGlobals.ItemInfoList.Binding.First(x => x.Index == buff.ItemIndex);
                    text = info.ItemName + "\n";
                    stats = info.Stats;
                    break;
                case BuffType.VipMapE:
                    
                    info = CartoonGlobals.ItemInfoList.Binding.First(x => x.Index == buff.ItemIndex);
                    text = info.ItemName + "\n";
                    stats = info.Stats;
                    break;
                case BuffType.VipMapS:
                    info = CartoonGlobals.ItemInfoList.Binding.First(x => x.Index == buff.ItemIndex);
                    text = info.ItemName + "\n";
                    stats = info.Stats;
                    
                    break;
                
                
                case BuffType.KongxiangYin:
                    text = $"隐身术【空相印】\n";
                    break;
                
                case BuffType.LifeStealHeal:
                    text = "吸血";
                    break;
                case BuffType.MoveSpeed:
                    text = "移动速度";
                    break;
                case BuffType.ChongzhuangYin:
                    text = "野蛮冲撞【冲撞印】";
                    break;
                
                
                case BuffType.MiaoyinYin:
                    text = "妙影无踪【妙影印】";
                    break;
                
                
                case BuffType.HuoliMassHeal:
                    text = "群体治愈术【活力印】";
                    break;
            }
            
            if (stats != null && stats.Count > 0)
            {
                foreach (KeyValuePair<Stat, int> pair in stats.Values)
                {
                    if (pair.Key == Stat.Duration) continue;

                    string temp = stats.GetDisplay(pair.Key);

                    if (temp == null) continue;
                    text += $"\n{temp}";
                }

                if (buff.RemainingTime != TimeSpan.MaxValue)
                    text += $"\n";
            }

            if (buff.RemainingTime != TimeSpan.MaxValue)
                text += $"\n持续时间: {Functions.ToString(buff.RemainingTime, true)}";

            if (buff.Pause) text += "\n暂停 (无效).";

            return text;
        }

        public override void Process()
        {
            base.Process();

            foreach (KeyValuePair<ClientBuffInfo, DXImageControl> pair in Icons)
            {
                if (pair.Key.Pause)
                {
                    pair.Value.ForeColour = Color.IndianRed;
                    continue;
                }
                    if (pair.Key.RemainingTime == TimeSpan.MaxValue) continue;

                if (pair.Key.RemainingTime.TotalSeconds >= 10)
                {
                    pair.Value.ForeColour = Color.White;
                    continue;
                }
                
                float rate = pair.Key.RemainingTime.Milliseconds / (float)1000;

                pair.Value.ForeColour = Functions.Lerp(Color.White, Color.CadetBlue, rate);
            }

            Hint = Icons.Count > 0 ? null : "Buff Area";


        }
        #endregion

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                foreach (KeyValuePair<ClientBuffInfo, DXImageControl> pair in Icons)
                {
                    if (pair.Value == null) continue;

                    if (pair.Value.IsDisposed) continue;

                    pair.Value.Dispose();
                }

                Icons.Clear();
                Icons = null;
            }

        }

        #endregion
    }

}
