using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CartoonMirDB;

namespace Client.UserModels
{
    [UserObject]
    public sealed class KeyBindInfo : DBObject
    {
        public string Category
        {
            get { return _Category; }
            set
            {
                if (_Category == value) return;

                var oldValue = _Category;
                _Category = value;

                OnChanged(oldValue, value, "Category");
            }
        }
        private string _Category;
        
        public KeyBindAction Action
        {
            get { return _Action; }
            set
            {
                if (_Action == value) return;

                var oldValue = _Action;
                _Action = value;

                OnChanged(oldValue, value, "Action");
            }
        }
        private KeyBindAction _Action;

        public bool Control1
        {
            get { return _Control1; }
            set
            {
                if (_Control1 == value) return;

                var oldValue = _Control1;
                _Control1 = value;

                OnChanged(oldValue, value, "Control1");
            }
        }
        private bool _Control1;

        public bool Alt1
        {
            get { return _Alt1; }
            set
            {
                if (_Alt1 == value) return;

                var oldValue = _Alt1;
                _Alt1 = value;

                OnChanged(oldValue, value, "Alt1");
            }
        }
        private bool _Alt1;

        public bool Shift1
        {
            get { return _Shift1; }
            set
            {
                if (_Shift1 == value) return;

                var oldValue = _Shift1;
                _Shift1 = value;

                OnChanged(oldValue, value, "Shift1");
            }
        }
        private bool _Shift1;

        public Keys Key1
        {
            get { return _Key1; }
            set
            {
                if (_Key1 == value) return;

                var oldValue = _Key1;
                _Key1 = value;

                OnChanged(oldValue, value, "Key1");
            }
        }
        private Keys _Key1;
        

        public bool Control2
        {
            get { return _Control2; }
            set
            {
                if (_Control2 == value) return;

                var oldValue = _Control2;
                _Control2 = value;

                OnChanged(oldValue, value, "Control2");
            }
        }
        private bool _Control2;

        public bool Shift2
        {
            get { return _Shift2; }
            set
            {
                if (_Shift2 == value) return;

                var oldValue = _Shift2;
                _Shift2 = value;

                OnChanged(oldValue, value, "Shift2");
            }
        }
        private bool _Shift2;

        public bool Alt2
        {
            get { return _Alt2; }
            set
            {
                if (_Alt2 == value) return;

                var oldValue = _Alt2;
                _Alt2 = value;

                OnChanged(oldValue, value, "Alt2");
            }
        }
        private bool _Alt2;

        public Keys Key2
        {
            get { return _Key2; }
            set
            {
                if (_Key2 == value) return;

                var oldValue = _Key2;
                _Key2 = value;

                OnChanged(oldValue, value, "Key2");
            }
        }
        private Keys _Key2;
    }

    public enum KeyBindAction
    { 
        None,
        [Description("设置")]
        ConfigWindow,
        [Description("角色")]
        CharacterWindow,
        [Description("背包")]
        InventoryWindow,
        [Description("技能")]
        MagicWindow,
        [Description("技能快捷栏")]
        MagicBarWindow,
        [Description("排行榜")]
        RankingWindow,
        [Description("游戏商店")]
        GameStoreWindow,
        [Description("宠物")]
        CompanionWindow,
        [Description("组队")]
        GroupWindow,
        [Description("辅助功能")]
        AutoPotionWindow,
        [Description("仓库")]
        StorageWindow,
        [Description("自动挂机")]
        Guaji,
        [Description("黑名单")]
        BlockListWindow,
        [Description("公会")]
        GuildWindow,
        [Description("支线任务日志")]
        QuestLogWindow,
        [Description("支线任务跟踪")]
        QuestTrackerWindow,
        [Description("每日任务日志")]
        MeiriQuestLogWindow,
        [Description("每日任务跟踪")]
        MeiriQuestTrackerWindow,
        [Description("物品快捷栏")]
        BeltWindow,
        [Description("商城")]
        MarketPlaceWindow,
        [Description("小地图")]
        MapMiniWindow,
        [Description("大地图")]
        MapBigWindow,
        [Description("邮箱")]
        MailBoxWindow,
        [Description("发送邮件")]
        MailSendWindow,
        [Description("聊天设置")]
        ChatOptionsWindow,
        [Description("退出游戏")]
        ExitGameWindow,
        [Description("切换攻击模式")]
        ChangeAttackMode,
        [Description("切换宠物模式")]
        ChangePetMode,
        [Description("切换允许组队")]
        GroupAllowSwitch,
        [Description("将目标添加到组队")]
        GroupTarget,
        [Description("请求交易")]
        TradeRequest,
        [Description("切换允许交易")]
        TradeAllowSwitch,
        [Description("拾取物品")]
        ItemPickUp,
        [Description("夫妻传送")]
        PartnerTeleport,
        [Description("切换骑乘")]
        MountToggle,
        [Description("切换自动跑步")]
        AutoRunToggle,
        [Description("切换聊天模式")]
        ChangeChatMode,
        [Description("物品快捷栏 1")]
        UseBelt01,
        [Description("物品快捷栏 2")]
        UseBelt02,
        [Description("物品快捷栏 3")]
        UseBelt03,
        [Description("物品快捷栏 4")]
        UseBelt04,
        [Description("物品快捷栏 5")]
        UseBelt05,
        [Description("物品快捷栏 6")]
        UseBelt06,
        [Description("物品快捷栏 7")]
        UseBelt07,
        [Description("物品快捷栏 8")]
        UseBelt08,
        [Description("物品快捷栏 9")]
        UseBelt09,
        [Description("使用药水栏 10")]
        UseBelt10,
        [Description("技能快捷栏 1")]
        SpellSet01,
        [Description("技能快捷栏 2")]
        SpellSet02,
        [Description("技能快捷栏 3")]
        SpellSet03,
        [Description("技能快捷栏 4")]
        SpellSet04,
        [Description("使用技能 1")]
        SpellUse01,
        [Description("使用技能 2")]
        SpellUse02,
        [Description("使用技能 3")]
        SpellUse03,
        [Description("使用技能 4")]
        SpellUse04,
        [Description("使用技能 5")]
        SpellUse05,
        [Description("使用技能 6")]
        SpellUse06,
        [Description("使用技能 7")]
        SpellUse07,
        [Description("使用技能 8")]
        SpellUse08,
        [Description("使用技能 9")]
        SpellUse09,
        [Description("使用技能 10")]
        SpellUse10,
        [Description("使用技能 11")]
        SpellUse11,
        [Description("使用技能 12")]
        SpellUse12,
        [Description("使用技能 13")]
        SpellUse13,
        [Description("使用技能 14")]
        SpellUse14,
        [Description("使用技能 15")]
        SpellUse15,
        [Description("使用技能 16")]
        SpellUse16,
        [Description("使用技能 17")]
        SpellUse17,
        [Description("使用技能 18")]
        SpellUse18,
        [Description("使用技能 19")]
        SpellUse19,
        [Description("使用技能 20")]
        SpellUse20,
        [Description("使用技能 21")]
        SpellUse21,
        [Description("使用技能 22")]
        SpellUse22,
        [Description("使用技能 23")]
        SpellUse23,
        [Description("使用技能 24")]
        SpellUse24,
        [Description("锁定/解锁物品")]
        ToggleItemLock,

        [Description("财富之窗")]
        FortuneWindow,

        [Description("装备制作")]
        CraftWindow,

        [Description("传送[传送戒指]")]
        MoveTeleport,

        [Description("迷你游戏")]
        MiniGameWindow,

        [Description("土灵符")]
        TeleportWindow,

        [Description("副本系统")]
        FubenWindow,

        
        [Description("验证挂机窗口")]
        FangGuajiWindow,

        [Description("聊天输入窗口")]
        ChatInputWindow,

        [Description("聊天窗口")] 
        ChatWindow,

        [Description("爆率查询")]
        MonsterDropWindow,
    }
}
