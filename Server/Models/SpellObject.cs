using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DevExpress.XtraDataLayout;
using Library;
using Library.Network;
using Library.SystemModels;
using Server.DBModels;
using Server.Envir;
using S = Library.Network.ServerPackets;


namespace Server.Models
{
    public sealed class SpellObject : MapObject
    {
        public override ObjectType Race => ObjectType.Spell;

        public override bool Blocking => false;

        public Point DisplayLocation;
        public SpellEffect Effect;
        public int TickCount;
        public TimeSpan TickFrequency;
        public DateTime TickTime;
        public MapObject Owner;
        public UserMagic Magic;
        public int Power;

        public List<MapObject> Targets = new List<MapObject>();

        public override bool CanBeSeenBy(PlayerObject ob)
        {
            return Visible && base.CanBeSeenBy(ob);
        }

        public override void Process()
        {
            base.Process();

            if (Owner != null && (Owner.Node == null || Owner.Dead))
            {
                Despawn();
                return;
            }

            if (SEnvir.Now < TickTime) return;
            
            if (TickCount-- <= 0)
            {
                switch (Effect)
                {
                    case SpellEffect.SwordOfVengeance:
                        PlayerObject player = Owner as PlayerObject;
                        if (player == null) break;

                        List<Cell> cells = CurrentMap.GetCells(CurrentLocation, 0, 3);

                        foreach (Cell cell in cells)
                        {
                            if (cell.Objects != null)
                            {
                                for (int i = cell.Objects.Count - 1; i >= 0; i--)
                                {
                                    if (i >= cell.Objects.Count) continue;
                                    MapObject target = cell.Objects[i];

                                    if (!player.CanAttackTarget(target)) continue;

                                    int damage = player.MagicAttack(new List<UserMagic> { Magic }, target, true);

                                    ActionList.Add(new DelayedAction(
                                        SEnvir.Now.AddMilliseconds(500),
                                        ActionType.DelayMagic,
                                        new List<UserMagic> { Magic },
                                        target));
                                }
                            }
                        }

                        break;
                    case SpellEffect.MonsterDeathCloud:
                        MonsterObject monster = Owner as MonsterObject;
                        if (monster == null) break;

                        for (int i = CurrentCell.Objects.Count - 1; i >= 0; i--)
                        {
                            if (i >= CurrentCell.Objects.Count) continue;

                            MapObject ob = CurrentCell.Objects[i];

                            if (!monster.CanAttackTarget(ob)) continue;


                            monster.Attack(ob, 4000, Element.None);
                            monster.Attack(ob, 4000, Element.None);
                        }


                        break;
                }

                Despawn();
                return;
            }

            TickTime = SEnvir.Now + TickFrequency;


            switch (Effect)
            {
                case SpellEffect.TrapOctagon:

                    for (int i = Targets.Count - 1; i >= 0; i--)
                    {
                        MapObject ob = Targets[i];

                        PlayerObject player = Owner as PlayerObject;

                        if (player.MW01 == 35 || player.MW02 == 35 || player.MW03 == 35)
                        {
                            MingwenInfo Mingweninfo = SEnvir.MingwenInfoList.Binding.FirstOrDefault((MingwenInfo x) => x.MingWenID == 35);

                            if (ob.Node != null && ob.ShockTime < SEnvir.Now && SEnvir.Random.Next(100) <= Mingweninfo.Canshu3)
                            {
                                ob.ApplyPoison(new Poison
                                {
                                    Type = PoisonType.Silenced,
                                    TickCount = 1,
                                    TickFrequency = TimeSpan.FromSeconds(Mingweninfo.Canshu4),
                                    Owner = player,
                                });
                            }
                        }

                        if (ob.Node != null && ob.ShockTime != DateTime.MinValue) continue;

                        Targets.Remove(ob);
                    }

                    if (Targets.Count == 0) Despawn();
                    break;
                default:

                    if (CurrentCell == null)
                    {
                        SEnvir.Log($"[错误] {Effect} CurrentCell 为空.");
                        return;
                    }

                    if (CurrentCell.Objects == null)
                    {
                        SEnvir.Log($"[错误] {Effect} CurrentCell.Objects 为空.");
                        return;
                    }

                    for (int i = CurrentCell.Objects.Count - 1; i >= 0; i--)
                    {
                        if (i >= CurrentCell.Objects.Count) continue;
                        if (CurrentCell.Objects[i] == this) continue;

                        ProcessSpell(CurrentCell.Objects[i]);

                        if (CurrentCell == null)
                        {
                            SEnvir.Log($"[错误] {Effect} CurrentCell 为空循环.");
                            return;
                        }

                        if (CurrentCell.Objects == null)
                        {
                            SEnvir.Log($"[错误] {Effect} CurrentCell.Objects 为空循环.");
                            return;
                        }


                    }
                    break;
            }
        }

        public void ProcessSpell(MapObject ob)
        {
            switch (Effect)
            {
                case SpellEffect.PoisonousCloud:
                    if (!Owner.CanHelpTarget(ob)) return;

                    BuffInfo buff = ob.Buffs.FirstOrDefault(x => x.Type == BuffType.PoisonousCloud);
                    TimeSpan remaining = TickTime - SEnvir.Now;

                    if (buff != null)
                        if (buff.RemainingTime > remaining) return;

                    PlayerObject player = Owner as PlayerObject;

                    ob.BuffAdd(BuffType.PoisonousCloud, remaining, new Stats { [Stat.Agility] = Power }, false, false, TimeSpan.Zero);
                    break;
                case SpellEffect.LingshanPoisonousCloud:
                    if (!Owner.CanHelpTarget(ob)) return;

                    buff = ob.Buffs.FirstOrDefault(x => x.Type == BuffType.PoisonousCloud);
                    remaining = TickTime - SEnvir.Now;

                    if (buff != null)
                        if (buff.RemainingTime > remaining) return;

                    player = Owner as PlayerObject;

                    if (player.MW01 == 207 || player.MW02 == 207 || player.MW03 == 207)
                    {
                        MingwenInfo Mingweninfo = SEnvir.MingwenInfoList.Binding.FirstOrDefault((MingwenInfo x) => x.MingWenID == 207);

                        ob.BuffAdd(BuffType.PoisonousCloud, remaining, new Stats { [Stat.Agility] = Power, [Stat.MaxAC] = Mingweninfo.Canshu3 }, false, false, TimeSpan.Zero);
                    }
                    else ob.BuffAdd(BuffType.PoisonousCloud, remaining, new Stats { [Stat.Agility] = Power }, false, false, TimeSpan.Zero);
                    break;
                case SpellEffect.JunhengPoisonousCloud:
                    if (!Owner.CanHelpTarget(ob)) return;

                    buff = ob.Buffs.FirstOrDefault(x => x.Type == BuffType.PoisonousCloud);
                    remaining = TickTime - SEnvir.Now;

                    if (buff != null)
                        if (buff.RemainingTime > remaining) return;

                    player = Owner as PlayerObject;

                    if (player.MW01 == 207 || player.MW02 == 207 || player.MW03 == 207)
                    {
                        MingwenInfo Mingweninfo = SEnvir.MingwenInfoList.Binding.FirstOrDefault((MingwenInfo x) => x.MingWenID == 207);

                        ob.BuffAdd(BuffType.PoisonousCloud, remaining, new Stats { [Stat.Agility] = Power, [Stat.MaxAC] = Mingweninfo.Canshu4 }, false, false, TimeSpan.Zero);
                    }
                    else ob.BuffAdd(BuffType.PoisonousCloud, remaining, new Stats { [Stat.Agility] = Power }, false, false, TimeSpan.Zero);
                    break;
                case SpellEffect.FireWall:
                case SpellEffect.Tempest:
                    player = Owner as PlayerObject;
                    if (player == null || !player.CanAttackTarget(ob)) return;

                    int damage = player.MagicAttack(new List<UserMagic> { Magic }, ob, true);

                    if (damage > 0 && ob.Race == ObjectType.Player)
                    {
                        foreach (SpellObject spell in player.SpellList)
                        {
                            if (spell.Effect != Effect) continue;

                            spell.TickCount--;
                        } 
                    }
                    break;
                case SpellEffect.MonsterFireWall:
                    MonsterObject monster = Owner as MonsterObject;
                    if (monster == null || !monster.CanAttackTarget(ob)) return;

                    monster.Attack(ob, monster.GetDC(), Element.Fire);
                    break;
                case SpellEffect.DarkSoulPrison:
                    player = Owner as PlayerObject;
                    if (player == null || !player.CanAttackTarget(ob)) return;

                    damage = player.MagicAttack(new List<UserMagic> { Magic }, ob, true);

                    if (damage > 0 && ob.Race == ObjectType.Player)
                    {
                        foreach (SpellObject spell in player.SpellList)
                        {
                            if (spell.Effect != Effect) continue;

                            spell.TickCount--;
                        }
                    }
                    break;
                case SpellEffect.SwordOfVengeance:
                    player = Owner as PlayerObject;
                    if (player == null) break;

                    List<Cell> cells = CurrentMap.GetCells(CurrentLocation, 0, 3);

                    foreach (Cell cell in cells)
                    {
                        if (cell.Objects != null)
                        {
                            foreach (MapObject target in cell.Objects)
                            {
                                if (player.CanAttackTarget(target))
                                {
                                    TickCount = 0; ;
                                    break;
                                }
                            }
                        }
                    }
                    break;
                case SpellEffect.HuoliMassHeal:
                    if (!Owner.CanHelpTarget(ob)) return;

                    buff = ob.Buffs.FirstOrDefault(x => x.Type == BuffType.HuoliMassHeal);
                    remaining = TickTime - SEnvir.Now;

                    if (buff != null)
                        if (buff.RemainingTime > remaining) return;

                    Stats buffStats = new Stats
                    {
                        [Stat.Healing] = 1000,
                        [Stat.HealingCap] = Power, 
                    };
                    ob.BuffAdd(BuffType.HuoliMassHeal, TimeSpan.FromSeconds(buffStats[Stat.Healing] / buffStats[Stat.HealingCap]), buffStats, false, false, TimeSpan.FromSeconds(2));

                    break;
            }
        }
        protected override void OnSpawned()
        {
            base.OnSpawned();

            Owner?.SpellList.Add(this);
            
            AddAllObjects();

            Activate();
        }
        public override void OnDespawned()
        {
            base.OnDespawned();

            Owner?.SpellList.Remove(this);
        }
        public override void OnSafeDespawn()
        {
            base.OnSafeDespawn();

            Owner?.SpellList.Remove(this);
        }

        public override void CleanUp()
        {
            base.CleanUp();
            
            Owner = null;
            Magic = null;

            Targets?.Clear();
        }

        public override Packet GetInfoPacket(PlayerObject ob)
        {
            return new S.ObjectSpell
            {
                ObjectID = ObjectID,
                Location = DisplayLocation,
                Effect = Effect,
                Direction = Direction,
                Power = Power,
            };
        }
        public override Packet GetDataPacket(PlayerObject ob)
        {
            return null;
        }

        public override bool CanDataBeSeenBy(PlayerObject ob)
        {
            return false;
        }

        public override void Activate()
        {
            if (Activated) return;

            if (Effect == SpellEffect.SafeZone) return;

            Activated = true;
            SEnvir.ActiveObjects.Add(this);
        }
        public override void DeActivate()
        {
            return;
        }

        public override void ProcessHPMP()
        {
        }
        public override void ProcessNameColour()
        {
        }
        public override void ProcessBuff()
        {
        }
        public override void ProcessPoison()
        {
        }
    }
}
