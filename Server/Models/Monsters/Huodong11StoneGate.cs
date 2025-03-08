using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using Server.Envir;

namespace Server.Models.Monsters
{
    public class Huodong11StoneGate : MonsterObject
    {
        public override bool CanMove => false;
        public override bool CanAttack => false;

        public DateTime DespawnTime;


        public Huodong11StoneGate()
        {
            Direction = MirDirection.Up;
        }

        public override void ProcessNameColour()
        {
            NameColour = Color.Lime;
        }

        protected override void OnSpawned()
        {
            base.OnSpawned();


            DespawnTime = SEnvir.Now.AddMinutes(Config.Huodong11Open);

            foreach (SConnection con in SEnvir.Connections)
                con.ReceiveChat(string.Format(con.Language.Huodong11Open, CurrentMap.Info.Description, CurrentLocation), MessageType.System);

        }

        public override void Process()
        {
            base.Process();

            if (SEnvir.Now >= DespawnTime)
            {
                Die();
                if (SpawnInfo != null)
                    SpawnInfo.AliveCount--;

                foreach (SConnection con in SEnvir.Connections)
                    con.ReceiveChat(con.Language.Huodong11Closed, MessageType.System);

                SpawnInfo = null;
                Despawn();
                return;
            }

            if (SEnvir.Now >= SearchTime && SEnvir.Huodong11MapRegion != null && SEnvir.Huodong11MapRegion.PointList.Count > 0)
            {
                SearchTime = SEnvir.Now.AddSeconds(3);
                Map map = SEnvir.GetMap(SEnvir.Huodong11MapRegion.Map);

                if (map == null)
                {
                    SearchTime = SEnvir.Now.AddSeconds(60);
                    return;
                }

                for (int i = CurrentMap.Objects.Count - 1; i >= 0; i--)
                {
                    MapObject ob = CurrentMap.Objects[i];

                    if (ob == this) continue;

                    if (ob is Guard) continue;

                    switch (ob.Race)
                    {
                        case ObjectType.NPC:
                            if (ob.InSafeZone) continue;
                            if (ob.Dead || !Functions.InRange(ob.CurrentLocation, CurrentLocation, MonsterInfo.ViewRange)) continue;

                            ob.Teleport(map, SEnvir.Huodong11MapRegion.PointList[SEnvir.Random.Next(SEnvir.Huodong11MapRegion.PointList.Count)]);
  
                            if (Config.活动11是否记录)
                            {
                                string fileName;
                                fileName = Path.Combine(SEnvir.NameListPath, Config.活动11记录名称 + ".txt");
                                if (!File.Exists(fileName))
                                    File.Create(fileName);
                                if (File.ReadAllLines(fileName).All(t => ob.Name != t))
                                {
                                    using (var line = File.AppendText(fileName))
                                    {
                                        line.WriteLine(ob.Name);
                                    }
                                }
                            }
                            break;
                        default:
                            continue;
                    }

                }
            }

        }

        public override void ProcessSearch()
        {
        }

        public override int Attacked(MapObject attacker, int power, Element element, bool canReflect = true, bool ignoreShield = false, bool canCrit = true, bool canStruck = true)
        {
            return 0;
        }
        public override bool ApplyPoison(Poison p)
        {
            return false;
        }
    }
}
