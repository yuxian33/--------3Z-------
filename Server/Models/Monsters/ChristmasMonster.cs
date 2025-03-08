using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using Server.Envir;

namespace Server.Models.Monsters
{
    // 定义一个圣诞怪物类，继承自MonsterObject类
    public class ChristmasMonster : MonsterObject
    {
        // 重写CanMove属性，返回false，表示不能移动
        public override bool CanMove => false;
        // 重写CanAttack属性，返回false，表示不能攻击
        public override bool CanAttack => false;

        // 构造函数，设置额外经验率为10
        public ChristmasMonster()
        {
            ExtraExperienceRate = 10;
        }

        // 重写RefreshStats方法，调用基类的RefreshStats方法
        public override void RefreshStats()
        {
            base.RefreshStats();
        }

        // 重写Attacked方法，调用基类的Attacked方法，并将canCrit参数设置为false，表示不能暴击
        public override int Attacked(MapObject attacker, int power, Element element, bool canReflect = true, bool ignoreShield = false, bool canCrit = true, bool canStruck = true)
        {
            return base.Attacked(attacker, 1, element, canReflect, ignoreShield, false, canStruck);
        }

        // 重写ProcessNameColour方法，设置名字颜色为AliceBlue，如果当前时间小于ShockTime，则设置为Peru，如果当前时间小于RageTime，则设置为Red
        public override void ProcessNameColour()
        {
            NameColour = Color.AliceBlue;

            if (SEnvir.Now < ShockTime)
                NameColour = Color.Peru;
            else if (SEnvir.Now < RageTime)
                NameColour = Color.Red;
        }

        // 重写Die方法，如果随机数为0，则将周围15格内的怪物传送至当前地图的随机位置，如果EXPOwner不为空，则将周围18格内的怪物设置为EXPOwner，并将HP设置为0
        public override void Die()
        {
            if (SEnvir.Random.Next(15) == 0)
            {

                for (int i = CurrentMap.Objects.Count - 1; i >= 0; i--)
                {
                    MonsterObject mob = CurrentMap.Objects[i] as MonsterObject;

                    if (mob == null) continue;

                    if (mob.PetOwner != null) continue;

                    if (mob is Guard || mob is ChristmasMonster) continue;

                    if (mob.Dead || mob.MoveDelay == 0 || !mob.CanMove) continue;

                    if (mob.Target != null) continue;

                    if (mob.Level >= 300) continue;

                    mob.Teleport(CurrentMap, CurrentMap.GetRandomLocation(CurrentLocation, 15));
                }
            }

            if (EXPOwner != null)
            {
                List<MapObject> targets = EXPOwner.GetTargets(CurrentMap, CurrentLocation, 18);

                foreach (MapObject mapObject in targets)
                {
                    if (mapObject.Race != ObjectType.Monster) continue;

                    MonsterObject mob = (MonsterObject) mapObject;

                    if (mob.MonsterInfo.IsBoss || mob.Dead) continue;

                    if (mob.EXPOwner != null && mob.EXPOwner != EXPOwner) continue;
                    
                    if (mob is ChristmasMonster) continue;

                    mob.ExtraExperienceRate = Math.Max(mob.ExtraExperienceRate, ExtraExperienceRate);
                    mob.EXPOwner = EXPOwner;
                    mob.SetHP(0);
                }
            }
            


            base.Die();


        }
    }
}

