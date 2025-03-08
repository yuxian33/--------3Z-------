using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Library.Network;

namespace Library
{
    public sealed class Stats
    {
        public SortedDictionary<Stat, int> Values { get; set; } = new SortedDictionary<Stat, int>();

        [IgnorePropertyPacket]
        public int Count => Values.Sum(pair => Math.Abs(pair.Value));

        [IgnorePropertyPacket]
        public int this[Stat stat]
        {
            get
            {
                int result;

                return !Values.TryGetValue(stat, out result) ? 0 : result;
            }
            set
            {
                if (value == 0)
                {
                    if (Values.ContainsKey(stat))
                        Values.Remove(stat);
                    return;
                }

                Values[stat] = value;
            }
        }

        public Stats()
        { }

        public Stats(Stats stats)
        {
            foreach (KeyValuePair<Stat, int> pair in stats.Values)
                this[pair.Key] += pair.Value;
        }
        public Stats(BinaryReader reader)
        {
            int count = reader.ReadInt32();

            for (int i = 0; i < count; i++)
                Values[(Stat)reader.ReadInt32()] = reader.ReadInt32();
        }
        public void Add(Stats stats, bool addElements = true)
        {
            foreach (KeyValuePair<Stat, int> pair in stats.Values)
                switch (pair.Key)
                {
                    case Stat.FireAttack:
                    case Stat.LightningAttack:
                    case Stat.IceAttack:
                    case Stat.WindAttack:
                    case Stat.HolyAttack:
                    case Stat.DarkAttack:
                    case Stat.PhantomAttack:
                        if (addElements)
                            this[pair.Key] += pair.Value;
                        break;
                    case Stat.ItemReviveTime:
                        if (pair.Value == 0) continue;

                        if (this[pair.Key] == 0)
                            this[pair.Key] = pair.Value;
                        else
                            this[pair.Key] = Math.Min(this[pair.Key], pair.Value);
                        break;
                    default:
                        this[pair.Key] += pair.Value;
                        break;
                }
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(Values.Count);

            foreach (KeyValuePair<Stat, int> pair in Values)
            {
                writer.Write((int)pair.Key);
                writer.Write(pair.Value);
            }

        }

        public string GetDisplay(Stat stat)
        {
            Type type = stat.GetType();

            MemberInfo[] infos = type.GetMember(stat.ToString());

            StatDescription description = infos[0].GetCustomAttribute<StatDescription>();

            if (description == null) return null;

            List<Stat> list;
            string value;
            bool neecComma;
            switch (description.Mode)
            {
                case StatType.None:
                    return null;
                case StatType.Default:
                    return description.Title + ": " + string.Format(description.Format, this[stat]);
                case StatType.Min:
                    if (this[description.MaxStat] != 0) return null;

                    return description.Title + ": " + string.Format(description.Format, this[stat]);
                case StatType.Max:
                    return description.Title + ": " + string.Format(description.Format, this[description.MinStat], this[stat]);
                case StatType.Percent:
                    return description.Title + ": " + string.Format(description.Format, this[stat] / 100D);
                case StatType.Text:
                    return description.Title;
                case StatType.Time:
                    if (this[stat] < 0)
                        return description.Title + ": 永久";

                    return description.Title + ": " + Functions.ToString(TimeSpan.FromSeconds(this[stat]), true);
                case StatType.SpellPower:
                    if (description.MinStat == stat && this[description.MaxStat] != 0) return null;

                    if (this[Stat.MinMC] != this[Stat.MinSC] || this[Stat.MaxMC] != this[Stat.MaxSC])
                        return description.Title + ": " + string.Format(description.Format, this[description.MinStat], this[stat]);

                    if (stat != Stat.MaxSC) return null;


                    return "全系列魔法: " + string.Format(description.Format, this[description.MinStat], this[stat]);
                case StatType.AttackElement:

                    list = new List<Stat>();
                    foreach (KeyValuePair<Stat, int> pair in Values)
                        if (type.GetMember(pair.Key.ToString())[0].GetCustomAttribute<StatDescription>().Mode == StatType.AttackElement) list.Add(pair.Key);

                    if (list.Count == 0 || list[0] != stat)
                        return null;

                    value = $"攻击元素: ";

                    neecComma = false;
                    foreach (Stat s in list)
                    {
                        description = type.GetMember(s.ToString())[0].GetCustomAttribute<StatDescription>();

                        if (neecComma)
                            value += $", ";

                        value += $"{description.Title} +" + this[s];
                        neecComma = true;
                    }
                    return value;
                case StatType.ElementResistance:


                    list = new List<Stat>();
                    foreach (KeyValuePair<Stat, int> pair in Values)
                    {
                        if (type.GetMember(pair.Key.ToString())[0].GetCustomAttribute<StatDescription>().Mode == StatType.ElementResistance) list.Add(pair.Key);
                    }

                    if (list.Count == 0)
                        return null;

                    bool ei;
                    bool hasAdv = false, hasDis = false;

                    foreach (Stat s in list)
                    {
                        if (this[s] > 0)
                            hasAdv = true;

                        if (this[s] < 0)
                            hasDis = true;
                    }

                    if (!hasAdv) 
                    {
                        ei = false;

                        if (list[0] != stat) return null;
                    }
                    else
                    {
                        if (!hasDis && list[0] != stat) return null;

                        ei = list[0] == stat;

                        if (!ei && list[1] != stat) return null;
                    }


                    value = ei ? $"强元素: " : $"弱元素: ";

                    neecComma = false;


                    foreach (Stat s in list)
                    {
                        description = type.GetMember(s.ToString())[0].GetCustomAttribute<StatDescription>();

                        if ((this[s] > 0) != ei) continue;

                        if (neecComma)
                            value += $", ";

                        value += $"{description.Title} x" + Math.Abs(this[s]);
                        neecComma = true;
                    }

                    return value;
                default: return null;
            }
        }


        public string GetFormat(Stat stat)
        {
            Type type = stat.GetType();

            MemberInfo[] infos = type.GetMember(stat.ToString());

            StatDescription description = infos[0].GetCustomAttribute<StatDescription>();

            if (description == null) return null;

            switch (description.Mode)
            {
                case StatType.Default:
                    return string.Format(description.Format, this[stat]);
                case StatType.Min:
                    return this[description.MaxStat] == 0 ? (string.Format(description.Format, this[stat])) : null;
                case StatType.Max:
                case StatType.SpellPower:
                    return string.Format(description.Format, this[description.MinStat], this[stat]);
                case StatType.Percent:
                    return string.Format(description.Format, this[stat] / 100D);
                case StatType.Text:
                    return description.Format;
                case StatType.Time:
                    if (this[stat] < 0)
                        return "永久";

                    return Functions.ToString(TimeSpan.FromSeconds(this[stat]), true);
                default: return null;
            }
        }

        public bool Compare(Stats s2)
        {
            if (Values.Count != s2.Values.Count) return false;

            foreach (KeyValuePair<Stat, int> value in Values)
                if (s2[value.Key] != value.Value) return false;

            return true;
        }

        public void Clear()
        {
            Values.Clear();
        }

        public bool HasElementalWeakness()
        {
            return
                this[Stat.FireResistance] <= 0 && this[Stat.IceResistance] <= 0 && this[Stat.LightningResistance] <= 0 && this[Stat.WindResistance] <= 0 &&
                this[Stat.HolyResistance] <= 0 && this[Stat.DarkResistance] <= 0 &&
                this[Stat.PhantomResistance] <= 0 && this[Stat.PhysicalResistance] <= 0;

        }

        public Stat GetWeaponElement()
        {
            switch ((Element)this[Stat.WeaponElement])
            {
                case Element.Fire:
                    return Stat.FireAttack;
                case Element.Ice:
                    return Stat.IceAttack;
                case Element.Lightning:
                    return Stat.LightningAttack;
                case Element.Wind:
                    return Stat.WindAttack;
                case Element.Holy:
                    return Stat.HolyAttack;
                case Element.Dark:
                    return Stat.DarkAttack;
                case Element.Phantom:
                    return Stat.PhantomAttack;
            }

            foreach (KeyValuePair<Stat, int> pair in Values)
            {
                switch (pair.Key)
                {
                    case Stat.FireAttack:
                        return Stat.FireAttack;
                    case Stat.IceAttack:
                        return Stat.IceAttack;
                    case Stat.LightningAttack:
                        return Stat.LightningAttack;
                    case Stat.WindAttack:
                        return Stat.WindAttack;
                    case Stat.HolyAttack:
                        return Stat.HolyAttack;
                    case Stat.DarkAttack:
                        return Stat.DarkAttack;
                    case Stat.PhantomAttack:
                        return Stat.PhantomAttack;
                }
            }

            return Stat.None;
        }

        public int GetWeaponElementValue()
        {
            return this[Stat.FireAttack] + this[Stat.IceAttack] + this[Stat.LightningAttack] + this[Stat.WindAttack] + this[Stat.HolyAttack] + this[Stat.DarkAttack] + this[Stat.PhantomAttack];
        }


        public int GetElementValue(Element element)
        {
            switch (element)
            {
                case Element.Fire:
                    return this[Stat.FireAttack];
                case Element.Ice:
                    return this[Stat.IceAttack];
                case Element.Lightning:
                    return this[Stat.LightningAttack];
                case Element.Wind:
                    return this[Stat.WindAttack];
                case Element.Holy:
                    return this[Stat.HolyAttack];
                case Element.Dark:
                    return this[Stat.DarkAttack];
                case Element.Phantom:
                    return this[Stat.PhantomAttack];
                default:
                    return 0;
            }

        }
        public int GetAffinityValue(Element element)
        {
            switch (element)
            {
                case Element.Fire:
                    return this[Stat.FireAffinity];
                case Element.Ice:
                    return this[Stat.IceAffinity];
                case Element.Lightning:
                    return this[Stat.LightningAffinity];
                case Element.Wind:
                    return this[Stat.WindAffinity];
                case Element.Holy:
                    return this[Stat.HolyAffinity];
                case Element.Dark:
                    return this[Stat.DarkAffinity];
                case Element.Phantom:
                    return this[Stat.PhantomAffinity];
                default:
                    return 0;
            }

        }
        public int GetResistanceValue(Element element)
        {
            switch (element)
            {
                case Element.Fire:
                    return this[Stat.FireResistance];
                case Element.Ice:
                    return this[Stat.IceResistance];
                case Element.Lightning:
                    return this[Stat.LightningResistance];
                case Element.Wind:
                    return this[Stat.WindResistance];
                case Element.Holy:
                    return this[Stat.HolyResistance];
                case Element.Dark:
                    return this[Stat.DarkResistance];
                case Element.Phantom:
                    return this[Stat.PhantomResistance];
                case Element.None:
                    return this[Stat.PhysicalResistance];
                default:
                    return 0;
            }

        }
        public Element GetAffinityElement()
        {
            List<Element> elements = new List<Element>();

            if (this[Stat.FireAffinity] > 0)
                elements.Add(Element.Fire);

            if (this[Stat.IceAffinity] > 0)
                elements.Add(Element.Ice);

            if (this[Stat.LightningAffinity] > 0)
                elements.Add(Element.Lightning);

            if (this[Stat.WindAffinity] > 0)
                elements.Add(Element.Wind);

            if (this[Stat.HolyAffinity] > 0)
                elements.Add(Element.Holy);

            if (this[Stat.DarkAffinity] > 0)
                elements.Add(Element.Dark);

            if (this[Stat.PhantomAffinity] > 0)
                elements.Add(Element.Phantom);

            if (elements.Count == 0) return Element.None;

            return elements[CartoonGlobals.Random.Next(elements.Count)];
        }
    }

    public enum Stat
    {
        [StatDescription(Title = "基础生命值", Format = "{0:+#0;-#0;#0}", Mode = StatType.None), Description("BaseHealth 基础生命值")]
        BaseHealth,
        [StatDescription(Title = "基础魔法值", Format = "{0:+#0;-#0;#0}", Mode = StatType.None), Description("BaseMana 基础魔法值")]
        BaseMana,

        [StatDescription(Title = "生命值", Format = "{0:+#0;-#0;#0}", Mode = StatType.Default), Description("Health 生命值")]
        Health,
        [StatDescription(Title = "魔法值", Format = "{0:+#0;-#0;#0}", Mode = StatType.Default), Description("Mana 魔法值")]
        Mana,

        [StatDescription(Title = "物理防御", Format = "{0}-0", Mode = StatType.Min, MinStat = MinAC, MaxStat = MaxAC), Description("MinAC 最小物防")]
        MinAC,
        [StatDescription(Title = "物理防御", Format = "{0}-{1}", Mode = StatType.Max, MinStat = MinAC, MaxStat = MaxAC), Description("MaxAC 最大物防")]
        MaxAC,
        [StatDescription(Title = "魔法防御", Format = "{0}-0", Mode = StatType.Min, MinStat = MinMR, MaxStat = MaxMR), Description("MinMR 最小魔防")]
        MinMR,
        [StatDescription(Title = "魔法防御", Format = "{0}-{1}", Mode = StatType.Max, MinStat = MinMR, MaxStat = MaxMR), Description("MaxMR 最大魔防")]
        MaxMR,
        [StatDescription(Title = "破坏", Format = "{0}-0", Mode = StatType.Min, MinStat = MinDC, MaxStat = MaxDC), Description("MinDC 最小破坏")]
        MinDC,
        [StatDescription(Title = "破坏", Format = "{0}-{1}", Mode = StatType.Max, MinStat = MinDC, MaxStat = MaxDC), Description("MaxDC 最大破坏")]
        MaxDC,
        [StatDescription(Title = "自然", Format = "{0}-0", Mode = StatType.SpellPower, MinStat = MinMC, MaxStat = MaxMC), Description("MinMC 最小自然")]
        MinMC,
        [StatDescription(Title = "自然", Format = "{0}-{1}", Mode = StatType.SpellPower, MinStat = MinMC, MaxStat = MaxMC), Description("MaxMC 最大自然")]
        MaxMC,
        [StatDescription(Title = "灵魂", Format = "{0}-0", Mode = StatType.SpellPower, MinStat = MinSC, MaxStat = MaxSC), Description("MinSC 最小灵魂")]
        MinSC,
        [StatDescription(Title = "灵魂", Format = "{0}-{1}", Mode = StatType.SpellPower, MinStat = MinSC, MaxStat = MaxSC), Description("MaxSC 最大灵魂")]
        MaxSC,

        [StatDescription(Title = "准确", Format = "{0:+#0;-#0;#0}", Mode = StatType.Default), Description("Accuracy 准确")]
        Accuracy,
        [StatDescription(Title = "敏捷", Format = "{0:+#0;-#0;#0}", Mode = StatType.Default), Description("Agility 敏捷")]
        Agility,
        [StatDescription(Title = "攻击速度", Format = "{0:+#0;-#0;#0}", Mode = StatType.Default), Description("AttackSpeed 攻击速度")]
        AttackSpeed,

        [StatDescription(Title = "光照范围", Format = "{0:+#0;-#0;#0}", Mode = StatType.Default), Description("Light 光照范围")]
        Light,
        [StatDescription(Title = "强度", Format = "{0:+#0;-#0;#0}", Mode = StatType.Default), Description("Strength 强度")]
        Strength, 
        [StatDescription(Title = "幸运", Format = "{0:+#0;-#0;#0}", Mode = StatType.Default), Description("Luck 幸运")]
        Luck, 

        [StatDescription(Title = "火(火焰)", Format = "{0:+#0;-#0;#0}", Mode = StatType.AttackElement), Description("FireAttack 火攻")]
        FireAttack,
        [StatDescription(Title = "火(火焰)", Format = "{0:+#0;-#0;#0}", Mode = StatType.ElementResistance), Description("FireResistance 火防")]
        FireResistance,

        [StatDescription(Title = "冰(冰寒)", Format = "{0:+#0;-#0;#0}", Mode = StatType.AttackElement), Description("IceAttack 冰攻")]
        IceAttack,
        [StatDescription(Title = "冰(冰寒)", Format = "{0:+#0;-#0;#0}", Mode = StatType.ElementResistance), Description("IceResistance 冰防")]
        IceResistance,

        [StatDescription(Title = "雷(电击)", Format = "{0:+#0;-#0;#0}", Mode = StatType.AttackElement), Description("LightningAttack 雷攻")]
        LightningAttack,
        [StatDescription(Title = "雷(电击)", Format = "{0:+#0;-#0;#0}", Mode = StatType.ElementResistance), Description("LightningResistance 雷防")]
        LightningResistance,

        [StatDescription(Title = "风(风)", Format = "{0:+#0;-#0;#0}", Mode = StatType.AttackElement), Description("WindAttack 风攻")]
        WindAttack,
        [StatDescription(Title = "风(风)", Format = "{0:+#0;-#0;#0}", Mode = StatType.ElementResistance), Description("WindResistance 风防")]
        WindResistance,

        [StatDescription(Title = "神圣(神圣)", Format = "{0:+#0;-#0;#0}", Mode = StatType.AttackElement), Description("HolyAttack 神圣攻")]
        HolyAttack,
        [StatDescription(Title = "神圣(神圣)", Format = "{0:+#0;-#0;#0}", Mode = StatType.ElementResistance), Description("HolyResistance 神圣防")]
        HolyResistance,

        [StatDescription(Title = "暗黑(暗黑)", Format = "{0:+#0;-#0;#0}", Mode = StatType.AttackElement), Description("DarkAttack 暗黑攻")]
        DarkAttack,
        [StatDescription(Title = "暗黑(暗黑)", Format = "{0:+#0;-#0;#0}", Mode = StatType.ElementResistance), Description("DarkResistance 暗黑防")]
        DarkResistance,

        [StatDescription(Title = "幻影(幻影)", Format = "{0:+#0;-#0;#0}", Mode = StatType.AttackElement), Description("PhantomAttack 幻影攻")]
        PhantomAttack,
        [StatDescription(Title = "幻影(幻影)", Format = "{0:+#0;-#0;#0}", Mode = StatType.ElementResistance), Description("PhantomResistance 幻影防")]
        PhantomResistance,

        [StatDescription(Title = "舒适", Format = "{0:+#0;-#0;#0}", Mode = StatType.Default), Description("Comfort 舒适")]
        Comfort,
        [StatDescription(Title = "吸血几率", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("LifeSteal 吸血几率%")]
        LifeSteal,

        [StatDescription(Title = "经验加成", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("ExperienceRate 经验加成%")]
        ExperienceRate,
        [StatDescription(Title = "爆率加成", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("DropRate 爆率加成%")]
        DropRate,
        [StatDescription(Title = "空白状态", Mode = StatType.None)]
        None,
        [StatDescription(Title = "技能熟练度", Format = "x{0}", Mode = StatType.Default), Description("SkillRate 技能熟练度")]
        SkillRate,

        [StatDescription(Title = "拾取范围", Format = "{0:+#0;-#0;#0}", Mode = StatType.Default), Description("PickUpRadius 拾取范围")]
        PickUpRadius,


        [StatDescription(Title = "生命恢复", Format = "{0:+#0;-#0;#0}", Mode = StatType.Default), Description("Healing 生命恢复")]
        Healing,
        [StatDescription(Title = "最大生命恢复值", Format = "{0:+#0;-#0;#0}", Mode = StatType.Default), Description("HealingCap 最大生命恢复值")]
        HealingCap,

        [StatDescription(Title = "隐身", Mode = StatType.Text), Description("Invisibility 隐身")]
        Invisibility,

        [StatDescription(Title = "强元素: 火", Mode = StatType.Text), Description("FireAffinity 强元素: 火")]
        FireAffinity,
        [StatDescription(Title = "强元素: 冰", Mode = StatType.Text), Description("IceAffinity 强元素: 冰")]
        IceAffinity,
        [StatDescription(Title = "强元素: 雷", Mode = StatType.Text), Description("LightningAffinity 强元素: 雷")]
        LightningAffinity,
        [StatDescription(Title = "强元素: 风", Mode = StatType.Text), Description("WindAffinity 强元素: 风")]
        WindAffinity,
        [StatDescription(Title = "强元素: 神圣", Mode = StatType.Text), Description("HolyAffinity 强元素: 神圣")]
        HolyAffinity,
        [StatDescription(Title = "强元素: 暗黑", Mode = StatType.Text), Description("DarkAffinity 强元素: 暗黑")]
        DarkAffinity,
        [StatDescription(Title = "强元素: 幻影", Mode = StatType.Text), Description("PhantomAffinity 强元素: 幻影")]
        PhantomAffinity,

        [StatDescription(Title = "反弹伤害", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("ReflectDamage 反弹伤害")]
        ReflectDamage,

        [StatDescription(Mode = StatType.None), Description("WeaponElement 武器属性")]
        WeaponElement,
        [StatDescription(Title = "暂时无罪", Mode = StatType.Text), Description("Redemption 暂时无罪")]
        Redemption,
        [StatDescription(Title = "生命值", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("HealthPercent 生命值")]
        HealthPercent,

        [StatDescription(Title = "暴击几率", Format = "{0:+#0;-#0;#0}%", Mode = StatType.Default), Description("CriticalChance 暴击几率")]
        CriticalChance,

        [StatDescription(Title = "5% 收益增加", Format = "{0} 或更多", Mode = StatType.Default), Description("SaleBonus5 5% 收益增加")]
        SaleBonus5,
        [StatDescription(Title = "10% 收益增加", Format = "{0} 或更多", Mode = StatType.Default), Description("SaleBonus10 10% 收益增加")]
        SaleBonus10,
        [StatDescription(Title = "15% 收益增加", Format = "{0} 或更多", Mode = StatType.Default), Description("SaleBonus15 15% 收益增加")]
        SaleBonus15,
        [StatDescription(Title = "20% 收益增加", Format = "{0} 或更多", Mode = StatType.Default), Description("SaleBonus20 20% 收益增加")]
        SaleBonus20,

        [StatDescription(Title = "魔法盾", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("MagicShield 魔法盾")]
        MagicShield,
        [StatDescription(Title = "隐身", Mode = StatType.Text), Description("Cloak 隐身")]
        Cloak,
        [StatDescription(Title = "潜行", Format = "{0} 持续", Mode = StatType.Default), Description("CloakDamage 潜行")]
        CloakDamage,

        [StatDescription(Title = "崭新的开始", Format = "{0}", Mode = StatType.Default), Description("TheNewBeginning 新手初期费用")]
        TheNewBeginning,

        [StatDescription(Title = "灰名, 其他人可以合法攻击你", Mode = StatType.Text), Description("Brown 灰名, 其他人可以合法攻击你")]
        Brown,
        [StatDescription(Title = "PK值", Format = "{0}", Mode = StatType.Default), Description("PKPoint PK值")]
        PKPoint,


        [StatDescription(Title = "全服喊话无等级限制", Mode = StatType.Text), Description("GlobalShout 全服喊话无等级限制")]
        GlobalShout,
        [StatDescription(Title = "自然比例", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("MCPercent 自然比例")]
        MCPercent,

        [StatDescription(Title = "天打雷劈几率", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("JudgementOfHeaven 天打雷劈几率")]
        JudgementOfHeaven,

        [StatDescription(Title = "妙影无踪", Mode = StatType.Text), Description("Transparency 透明")]
        Transparency,

        [StatDescription(Title = "阴阳法环", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("CelestialLight HP恢复")]
        CelestialLight,

        [StatDescription(Title = "黄泉旅者", Format = "{0:+#0;-#0;#0}", Mode = StatType.Default), Description("DarkConversion MP转换")]
        DarkConversion,

        [StatDescription(Title = "HP恢复", Format = "{0:+#0;-#0;#0}", Mode = StatType.Default), Description("RenounceHPLost HP恢复")]
        RenounceHPLost,

        [StatDescription(Title = "背包重量", Format = "{0:+#0;-#0;#0}", Mode = StatType.Default), Description("BagWeight 背包重量")]
        BagWeight,
        [StatDescription(Title = "负重能力", Format = "{0:+#0;-#0;#0}", Mode = StatType.Default), Description("WearWeight 负重能力")]
        WearWeight,
        [StatDescription(Title = "手负重能力", Format = "{0:+#0;-#0;#0}", Mode = StatType.Default), Description("HandWeight 手负重能力")]
        HandWeight,

        [StatDescription(Title = "金币爆率", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("GoldRate 金币爆率")]
        GoldRate,

        [StatDescription(Title = "持续时间", Mode = StatType.Time), Description("OldDuration 持续时间")]
        OldDuration,
        [StatDescription(Title = "获得赏金", Format = "{0:+#0;-#0;#0}", Mode = StatType.Default), Description("AvailableHuntGold 获得赏金")]
        AvailableHuntGold,
        [StatDescription(Title = "获得赏金最大值", Format = "{0:#0}", Mode = StatType.Default), Description("AvailableHuntGoldCap 获得赏金最大值")]
        AvailableHuntGoldCap,
        [StatDescription(Title = "恢复冷却", Mode = StatType.Time), Description("ItemReviveTime 恢复冷却")]
        ItemReviveTime,
        [StatDescription(Title = "提高精炼成功几率", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("MaxRefineChance 提高精炼成功几率")]
        MaxRefineChance,

        [StatDescription(Title = "宠物背包空间", Format = "{0:+#0;-#0;#0}", Mode = StatType.Default), Description("CompanionInventory 宠物背包空间")]
        CompanionInventory,
        [StatDescription(Title = "宠物背包重量", Format = "{0:+#0;-#0;#0}", Mode = StatType.Default), Description("CompanionBagWeight 宠物背包重量")]
        CompanionBagWeight,
        [StatDescription(Title = "破坏比例", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("DCPercent 破坏比例")]
        DCPercent,
        [StatDescription(Title = "灵魂比例", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("SCPercent 灵魂比例")]
        SCPercent,
        [StatDescription(Title = "宠物饥饿度", Format = "{0:+#0;-#0;#0}", Mode = StatType.Default), Description("CompanionHunger 宠物饥饿度")]
        CompanionHunger,

        [StatDescription(Title = "宠物破坏比例", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("PetDCPercent 宠物破坏比例")]
        PetDCPercent,

        [StatDescription(Title = "在地图上定位领主", Mode = StatType.Text), Description("BossTracker 在地图上定位领主")]
        BossTracker,
        [StatDescription(Title = "在地图上定位玩家", Mode = StatType.Text), Description("PlayerTracker 在地图上定位玩家")]
        PlayerTracker,

        [StatDescription(Title = "宠物经验", Format = "x{0}", Mode = StatType.Default), Description("CompanionRate 宠物经验")]
        CompanionRate,

        [StatDescription(Title = "负重", Format = "x{0}", Mode = StatType.Default), Description("WeightRate 负重")]
        WeightRate,
        [StatDescription(Title = "最大物理防御和最大魔法防御已经提高", Mode = StatType.Text), Description("Defiance 最大物理防御和最大魔法防御已经提高")]
        Defiance,
        [StatDescription(Title = "减少你的防御来提高破坏力", Mode = StatType.Text), Description("Might 减少你的防御来提高破坏力")]
        Might,
        [StatDescription(Title = "魔法力比例", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("ManaPercent 魔法力比例")]
        ManaPercent,

        [StatDescription(Title = "传送命令: @天地合一", Mode = StatType.Text), Description("RecallSet 传送命令: @天地合一")]
        RecallSet,

        [StatDescription(Title = "怪物基础经验", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("MonsterExperience 怪物基础经验")]
        MonsterExperience,

        [StatDescription(Title = "怪物基础金币", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("MonsterGold 怪物基础金币")]
        MonsterGold,

        [StatDescription(Title = "怪物基础爆率", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("MonsterDrop 怪物基础爆率")]
        MonsterDrop,

        [StatDescription(Title = "怪物基础伤害", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("MonsterDamage 怪物基础伤害")]
        MonsterDamage,

        [StatDescription(Title = "怪物基础生命", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("MonsterHealth 怪物基础生命")]
        MonsterHealth,

        [StatDescription(Mode = StatType.None)]
        ItemIndex,

        [StatDescription(Title = "增强物品拾取能力.", Mode = StatType.Text), Description("CompanionCollection 增强物品拾取能力")]
        CompanionCollection,
        [StatDescription(Title = "护身戒指", Mode = StatType.Text), Description("ProtectionRing 护身戒指")]
        ProtectionRing,
        [StatDescription(Mode = StatType.None)]
        ClearRing,
        [StatDescription(Mode = StatType.None)]
        TeleportRing,

        [StatDescription(Title = "基础经验加成", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("BaseExperienceRate 基础经验加成")]
        BaseExperienceRate,

        [StatDescription(Title = "基础金币加成", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("BaseGoldRate 基础金币加成")]
        BaseGoldRate,

        [StatDescription(Title = "基础爆率加成", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("BaseDropRate 基础爆率加成")]
        BaseDropRate,

        [StatDescription(Title = "冰冻伤害", Format = "{0}", Mode = StatType.Default), Description("FrostBiteDamage 冰冻伤害")]
        FrostBiteDamage,

        [StatDescription(Title = "怪物最高经验", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("MaxMonsterExperience 怪物最高经验")]
        MaxMonsterExperience,

        [StatDescription(Title = "怪物最高金币", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("MaxMonsterGold 怪物最高金币")]
        MaxMonsterGold,

        [StatDescription(Title = "怪物最高爆率", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("MaxMonsterDrop 怪物最高爆率")]
        MaxMonsterDrop,

        [StatDescription(Title = "怪物最高伤害", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("MaxMonsterDamage 怪物最高伤害")]
        MaxMonsterDamage,

        [StatDescription(Title = "怪物最高生命", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("MaxMonsterHealth 怪物最高生命")]
        MaxMonsterHealth,

        [StatDescription(Title = "暴击伤害 (怪物)", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("CriticalDamage 暴击伤害 (怪物)")]
        CriticalDamage,

        [StatDescription(Title = "经验", Format = "{0}", Mode = StatType.Default), Description("Experience 经验")]
        Experience,

        [StatDescription(Title = "开启死亡掉率.", Mode = StatType.Text), Description("DeathDrops 开启死亡掉率")]
        DeathDrops,

        [StatDescription(Title = "体质(体质)", Format = "{0:+#0;-#0;#0}", Mode = StatType.ElementResistance), Description("PhysicalResistance 体质")]
        PhysicalResistance,

        [StatDescription(Title = "碎片分解成功几率", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("FragmentRate 碎片分解成功几率")]
        FragmentRate,

        [StatDescription(Title = "获得召唤随机领主的机会 ", Mode = StatType.Text), Description("MapSummoning 获得召唤随机领主的机会")]
        MapSummoning,

        [StatDescription(Title = "最大冰冻伤害", Format = "{0}", Mode = StatType.Default), Description("FrostBiteMaxDamage 最大冰冻伤害")]
        FrostBiteMaxDamage,

        [StatDescription(Title = "麻痹几率", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("ParalysisChance 麻痹几率")]
        ParalysisChance,
        [StatDescription(Title = "减速几率", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("SlowChance 减速几率")]
        SlowChance,
        [StatDescription(Title = "沉默几率", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("SilenceChance 沉默几率")]
        SilenceChance,
        [StatDescription(Title = "格挡几率", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("BlockChance 格挡几率")]
        BlockChance,
        [StatDescription(Title = "闪避几率", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("EvasionChance 闪避几率")]
        EvasionChance,

        [StatDescription(Mode = StatType.None), Description("IgnoreStealth 忽视隐身藏匿状态")]
        IgnoreStealth,
        [StatDescription(Mode = StatType.None)]
        FootballArmourAction,

        [StatDescription(Title = "毒系抵抗", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("PoisonResistance 毒系抵抗")]
        PoisonResistance,

        [StatDescription(Title = "转生", Format = "{0}", Mode = StatType.Default), Description("Rebirth 转生")]
        Rebirth,

        [StatDescription(Title = "绿毒几率[怪]", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("PoisonChance 绿毒几率[怪]")]
        PoisonChance,

        [StatDescription(Title = "真·炎魔", Format = "{0:+#0;-#0;#0}", Mode = StatType.Default), Description("Zhenyanmo 真·炎魔")]
        Zhenyanmo,

        [StatDescription(Title = "无敌", Mode = StatType.Text), Description("Invincibility 无敌")]
        Invincibility,

        [StatDescription(Title = "魔光盾", Format = "{0:+#0;-#0;#0}", Mode = StatType.Default), Description("SuperiorMagicShield 魔光盾")]
        SuperiorMagicShield,

  
        [StatDescription(Title = "额外伤害[怪物]", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("EWaiShanghaiG 额外伤害[怪物]")]
        EWaiShanghaiG,
 
        [StatDescription(Title = "额外伤害[玩家]", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("EWaiShanghaiW 额外伤害[玩家]")]
        EWaiShanghaiW,

        [StatDescription(Title = "物品爆率[转生]", Format = "{0:#0%}", Mode = StatType.Percent), Description("WupinBaolv 物品爆率[转生]")]
        WupinBaolv,
   
        [StatDescription(Title = "金币爆率[转生]", Format = "{0:#0%}", Mode = StatType.Percent), Description("JinbiBaolv 金币爆率[转生]")]
        JinbiBaolv,


 
        [StatDescription(Title = "武器基础爆率", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("BaseWeaponDropRate 武器基础爆率")]
        BaseWeaponDropRate,


        [StatDescription(Title = "衣服基础爆率", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("BaseArmourDropRate 衣服基础爆率")]
        BaseArmourDropRate,


        [StatDescription(Title = "头盔基础爆率", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("BaseHelmetDropRate 头盔基础爆率")]
        BaseHelmetDropRate,


        [StatDescription(Title = "项链基础爆率", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("BaseNecklaceDropRate 项链基础爆率")]
        BaseNecklaceDropRate,


        [StatDescription(Title = "手镯基础爆率", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("BaseBraceletDropRate 手镯基础爆率")]
        BaseBraceletDropRate,


        [StatDescription(Title = "戒指基础爆率", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("BaseRingDropRate 戒指基础爆率")]
        BaseRingDropRate,


        [StatDescription(Title = "靴子基础爆率", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("BaseShoesDropRate 靴子基础爆率")]
        BaseShoesDropRate,


        [StatDescription(Title = "矿石基础爆率", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("BaseOreDropRate 矿石基础爆率")]
        BaseOreDropRate,

  
        [StatDescription(Title = "书籍基础爆率", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("BaseBookDropRate 书籍基础爆率")]
        BaseBookDropRate,


        [StatDescription(Title = "盾牌基础爆率", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("BaseShieldDropRate 盾牌基础爆率")]
        BaseShieldDropRate,


        [StatDescription(Title = "徽章基础爆率", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("BaseEmblemDropRate 徽章基础爆率")]
        BaseEmblemDropRate,

   
        [StatDescription(Title = "宝石基础爆率", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("BaseBaoshiDropRate 宝石基础爆率")]
        BaseBaoshiDropRate,


        [StatDescription(Title = "轴卷基础爆率", Format = "{0:+#0%;-#0%;#0%}", Mode = StatType.Percent), Description("BaseScrollDropRate 轴卷基础爆率")]
        BaseScrollDropRate,

  
    
        [StatDescription(Title = "魔法恢复", Format = "{0:+#0;-#0;#0}", Mode = StatType.Default), Description("Maning 魔法恢复")]
        Maning,

        [StatDescription(Title = "最大魔法恢复值", Format = "{0:+#0;-#0;#0}", Mode = StatType.Default), Description("ManingCap 最大魔法恢复值")]
        ManingCap,

        [StatDescription(Title = "吸血生命治疗值", Format = "{0:+#0;-#0;#0}", Mode = StatType.Default), Description("LSHealing 吸血生命治疗值")]
        LSHealing,
        [StatDescription(Title = "最高吸血生命治疗值", Format = "{0:+#0;-#0;#0}", Mode = StatType.Default), Description("LSHealingCap 最高吸血生命治疗值")]
        LSHealingCap,


        [StatDescription(Title = "宠物属性", Format = "{0:+#0;-#0;#0}", Mode = StatType.Default), Description("PetAttackSpeed 宠物属性")]
        PetAttackSpeed,




        [StatDescription(Title = "持续时间", Mode = StatType.Time), Description("Duration 持续时间")]
        Duration = 10000,


    }

   

    public enum StatSource
    {
        None,
        Added,
        Refine,
        Enhancement, 
        Other,
    }

    public enum StatType
    {
        None,
        Default,
        Min,
        Max,
        Percent,
        Text,
        AttackElement,
        ElementResistance,
        SpellPower,
        Time,
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class StatDescription : Attribute
    {
        public string Title { get; set; }
        public string Format { get; set; }
        public StatType Mode { get; set; }
        public Stat MinStat { get; set; }
        public Stat MaxStat { get; set; }
    }
}
