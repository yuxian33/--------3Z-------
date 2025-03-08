using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Library;
using Library.Network;
using Library.Network.ServerPackets;
using Library.SystemModels;
using Server.DBModels;
using Server.Envir;
using Server.Models.Monsters;
using S = Library.Network.ServerPackets;

namespace Server.Models
{
    public sealed class Map
    {
        public MapInfo Info { get; }

        public int Width { get; private set; }
        public int Height { get; private set; }

        public bool HasSafeZone { get; set; }

        public Cell[,] Cells { get; private set; }
        public List<Cell> ValidCells { get; } = new List<Cell>();

        public List<MapObject> Objects { get; } = new List<MapObject>();
        public List<PlayerObject> Players { get; } = new List<PlayerObject>();
        public List<MonsterObject> Bosses { get; } = new List<MonsterObject>();
        public List<NPCObject> NPCs { get; } = new List<NPCObject>();
        public HashSet<MapObject>[] OrderedObjects;

        public DateTime LastProcess;

        private DateTime _Expiry;


        public DateTime HalloweenEventTime, ChristmasEventTime;
        public PlayerObject OwnPlay;

        public Map(MapInfo info)
        {
            Info = info;
        }


        public DateTime Expiry
        {
            get
            {
                return _Expiry;
            }
            set
            {
                if (_Expiry == value)
                    return;
                DateTime expiry = _Expiry;
                _Expiry = value;
                OnExpirChanged(expiry, value);
            }
        }

        public void OnExpirChanged(DateTime oValue, DateTime nValue)
        {
            Broadcast(new MapTime()
            {
                OnOff = (MapTime > SEnvir.Now),
                MapRemaining = (MapTime - SEnvir.Now),
                ExpiryOnff = (nValue > SEnvir.Now),
                ExpiryRemaining = (nValue - SEnvir.Now)
            });
        }

        public DateTime MapTime
        {
            get { return _MapTime; }
            set
            {
                if (_MapTime == value)
                    return;
                DateTime mapTime = _MapTime;
                _MapTime = value;
                OnMapTimeChanged(mapTime, value);
            }
        }
        private DateTime _MapTime;

        public void OnMapTimeChanged(DateTime oValue, DateTime nValue)
        {
            Broadcast(new MapTime()
            {
                OnOff = (nValue > SEnvir.Now),
                MapRemaining = (nValue - SEnvir.Now),
                ExpiryOnff = (Expiry > SEnvir.Now),
                ExpiryRemaining = (Expiry - SEnvir.Now)
            });
        }

        public int MonsterCount
        {
            get
            {
                int num = 0;
                foreach (MapObject mapObject in Objects)
                {
                    if (!(mapObject is Companion))
                    {
                        MonsterObject monsterObject = mapObject as MonsterObject;
                        if (monsterObject != null && monsterObject.PetOwner == null && !monsterObject.Dead)
                            ++num;
                    }
                }
                return num;
            }
        }

        public int PlayerCount
        {
            get
            {
                return Players.Count;
            }
        }

        public int PlayerCounts
        {
            get
            {
                int num = 0;
                foreach (MapObject mapObject in Objects)
                {
                    PlayerObject playerObject = mapObject as PlayerObject;
                    if (playerObject != null && !playerObject.Character.Account.Admin)
                        ++num;
                }
                return num;
            }
        }

       

        private byte FindType(byte[] input)
        {
            if (input[2] == 67 && input[3] == 35)
            {
                return 100;
            }
            if (input[0] == 0)
            {
                return 5;
            }
            if (input[0] == 15 && input[5] == 83 && input[14] == 51)
            {
                return 6;
            }
            if (input[0] == 21 && input[4] == 50 && input[6] == 65 && input[19] == 49)
            {
                return 4;
            }
            if (input[0] == 16 && input[2] == 97 && input[7] == 49 && input[14] == 49)
            {
                return 1;
            }
            if (input[4] == 15 && input[18] == 13 && input[19] == 10)
            {
                int W = input[0] + (input[1] << 8);
                int H = input[2] + (input[3] << 8);
                if (input.Length > 52 + W * H * 14)
                {
                    return 3;
                }
                return 2;
            }
            if (input[0] == 13 && input[1] == 76 && input[7] == 32 && input[11] == 109)
            {
                return 7;
            }
            return 0;
        }

        private void LoadMapCellsv0(byte[] fileBytes)
        {
            int offSet6 = 0;
            Width = BitConverter.ToInt16(fileBytes, offSet6);
            offSet6 += 2;
            Height = BitConverter.ToInt16(fileBytes, offSet6);
            Cells = new Cell[Width, Height];
            offSet6 = 52;
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    bool validcell = true;
                    if ((BitConverter.ToInt16(fileBytes, offSet6) & 0x8000) != 0)
                    {
                        validcell = false;
                    }
                    offSet6 += 2;
                    if ((BitConverter.ToInt16(fileBytes, offSet6) & 0x8000) != 0)
                    {
                        validcell = false;
                    }
                    offSet6 += 2;
                    if ((BitConverter.ToInt16(fileBytes, offSet6) & 0x8000) != 0)
                    {
                        validcell = false;
                    }
                    offSet6 += 4;
                    offSet6 += 3;
                    byte light = fileBytes[offSet6++];
                    if (validcell)
                    {
                        List<Cell> validCells = ValidCells;
                        Cell[,] cells = Cells;
                        int num = x;
                        int num2 = y;
                        Cell obj = new Cell(new Point(x, y))
                        {
                            Map = this
                        };
                        Cell item = obj;
                        cells[num, num2] = obj;
                        validCells.Add(item);
                    }
                }
            }
        }

        private void LoadMapCellsv1(byte[] fileBytes)
        {
            int offSet7 = 21;
            int w = BitConverter.ToInt16(fileBytes, offSet7);
            offSet7 += 2;
            int xor = BitConverter.ToInt16(fileBytes, offSet7);
            offSet7 += 2;
            int h = BitConverter.ToInt16(fileBytes, offSet7);
            Width = (w ^ xor);
            Height = (h ^ xor);
            Cells = new Cell[Width, Height];
            offSet7 = 54;
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    bool validcell = true;
                    if (((BitConverter.ToInt32(fileBytes, offSet7) ^ 2855840312u) & 0x20000000) != 0)
                    {
                        validcell = false;
                    }
                    offSet7 += 6;
                    if (((BitConverter.ToInt16(fileBytes, offSet7) ^ xor) & 0x8000) != 0)
                    {
                        validcell = false;
                    }
                    offSet7 += 2;
                    offSet7 += 5;
                    byte light = fileBytes[offSet7++];
                    offSet7++;
                    if (validcell)
                    {
                        List<Cell> validCells = ValidCells;
                        Cell[,] cells = Cells;
                        int num = x;
                        int num2 = y;
                        Cell obj = new Cell(new Point(x, y))
                        {
                            Map = this
                        };
                        Cell item = obj;
                        cells[num, num2] = obj;
                        validCells.Add(item);
                    }
                }
            }
        }

        private void LoadMapCellsv2(byte[] fileBytes)
        {
            int offSet7 = 0;
            Width = BitConverter.ToInt16(fileBytes, offSet7);
            offSet7 += 2;
            Height = BitConverter.ToInt16(fileBytes, offSet7);
            Cells = new Cell[Width, Height];
            offSet7 = 52;
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    bool validcell = true;
                    if ((BitConverter.ToInt16(fileBytes, offSet7) & 0x8000) != 0)
                    {
                        validcell = false;
                    }
                    offSet7 += 2;
                    if ((BitConverter.ToInt16(fileBytes, offSet7) & 0x8000) != 0)
                    {
                        validcell = false;
                    }
                    offSet7 += 2;
                    if ((BitConverter.ToInt16(fileBytes, offSet7) & 0x8000) != 0)
                    {
                        validcell = false;
                    }
                    offSet7 += 2;
                    offSet7 += 5;
                    byte light = fileBytes[offSet7++];
                    offSet7 += 2;
                    if (validcell)
                    {
                        List<Cell> validCells = ValidCells;
                        Cell[,] cells = Cells;
                        int num = x;
                        int num2 = y;
                        Cell obj = new Cell(new Point(x, y))
                        {
                            Map = this
                        };
                        Cell item = obj;
                        cells[num, num2] = obj;
                        validCells.Add(item);
                    }
                }
            }
        }

        private void LoadMapCellsv3(byte[] fileBytes)
        {
            int offSet7 = 0;
            Width = BitConverter.ToInt16(fileBytes, offSet7);
            offSet7 += 2;
            Height = BitConverter.ToInt16(fileBytes, offSet7);
            Cells = new Cell[Width, Height];
            offSet7 = 52;
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    bool validcell = true;
                    if ((BitConverter.ToInt16(fileBytes, offSet7) & 0x8000) != 0)
                    {
                        validcell = false;
                    }
                    offSet7 += 2;
                    if ((BitConverter.ToInt16(fileBytes, offSet7) & 0x8000) != 0)
                    {
                        validcell = false;
                    }
                    offSet7 += 2;
                    if ((BitConverter.ToInt16(fileBytes, offSet7) & 0x8000) != 0)
                    {
                        validcell = false;
                    }
                    offSet7 += 2;
                    offSet7 += 12;
                    byte light = fileBytes[offSet7++];
                    offSet7 += 17;
                    if (validcell)
                    {
                        List<Cell> validCells = ValidCells;
                        Cell[,] cells = Cells;
                        int num = x;
                        int num2 = y;
                        Cell obj = new Cell(new Point(x, y))
                        {
                            Map = this
                        };
                        Cell item = obj;
                        cells[num, num2] = obj;
                        validCells.Add(item);
                    }
                }
            }
        }

        private void LoadMapCellsv4(byte[] fileBytes)
        {
            int offSet6 = 31;
            int w = BitConverter.ToInt16(fileBytes, offSet6);
            offSet6 += 2;
            int xor = BitConverter.ToInt16(fileBytes, offSet6);
            offSet6 += 2;
            int h = BitConverter.ToInt16(fileBytes, offSet6);
            Width = (w ^ xor);
            Height = (h ^ xor);
            Cells = new Cell[Width, Height];
            offSet6 = 64;
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    bool validcell = true;
                    if ((BitConverter.ToInt16(fileBytes, offSet6) & 0x8000) != 0)
                    {
                        validcell = false;
                    }
                    offSet6 += 2;
                    if ((BitConverter.ToInt16(fileBytes, offSet6) & 0x8000) != 0)
                    {
                        validcell = false;
                    }
                    offSet6 += 4;
                    offSet6 += 6;
                    if (validcell)
                    {
                        List<Cell> validCells = ValidCells;
                        Cell[,] cells = Cells;
                        int num = x;
                        int num2 = y;
                        Cell obj = new Cell(new Point(x, y))
                        {
                            Map = this
                        };
                        Cell item = obj;
                        cells[num, num2] = obj;
                        validCells.Add(item);
                    }
                }
            }
        }

        private void LoadMapCellsv5(byte[] fileBytes)
        {
            int offSet3 = 22;
            Width = BitConverter.ToInt16(fileBytes, offSet3);
            offSet3 += 2;
            Height = BitConverter.ToInt16(fileBytes, offSet3);
            Cells = new Cell[Width, Height];
            offSet3 = 28 + 3 * (Width / 2 + Width % 2) * (Height / 2);
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    bool validcell = true;
                    if ((fileBytes[offSet3] & 1) != 1)
                    {
                        validcell = false;
                    }
                    else if ((fileBytes[offSet3] & 2) != 2)
                    {
                        validcell = false;
                    }
                    offSet3 += 13;
                    byte light = fileBytes[offSet3++];
                    if (validcell)
                    {
                        List<Cell> validCells = ValidCells;
                        Cell[,] cells = Cells;
                        int num = x;
                        int num2 = y;
                        Cell obj = new Cell(new Point(x, y))
                        {
                            Map = this
                        };
                        Cell item = obj;
                        cells[num, num2] = obj;
                        validCells.Add(item);
                    }
                }
            }
        }

        private void LoadMapCellsv6(byte[] fileBytes)
        {
            int offSet3 = 16;
            Width = BitConverter.ToInt16(fileBytes, offSet3);
            offSet3 += 2;
            Height = BitConverter.ToInt16(fileBytes, offSet3);
            Cells = new Cell[Width, Height];
            offSet3 = 40;
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    bool validcell = true;
                    if ((fileBytes[offSet3] & 1) != 1)
                    {
                        validcell = false;
                    }
                    else if ((fileBytes[offSet3] & 2) != 2)
                    {
                        validcell = false;
                    }
                    offSet3 += 20;
                    if (validcell)
                    {
                        List<Cell> validCells = ValidCells;
                        Cell[,] cells = Cells;
                        int num = x;
                        int num2 = y;
                        Cell obj = new Cell(new Point(x, y))
                        {
                            Map = this
                        };
                        Cell item = obj;
                        cells[num, num2] = obj;
                        validCells.Add(item);
                    }
                }
            }
        }

        private void LoadMapCellsv7(byte[] fileBytes)
        {
            int offSet6 = 21;
            Width = BitConverter.ToInt16(fileBytes, offSet6);
            offSet6 += 4;
            Height = BitConverter.ToInt16(fileBytes, offSet6);
            Cells = new Cell[Width, Height];
            offSet6 = 54;
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    bool validcell = true;
                    if ((BitConverter.ToInt16(fileBytes, offSet6) & 0x8000) != 0)
                    {
                        validcell = false;
                    }
                    offSet6 += 6;
                    if ((BitConverter.ToInt16(fileBytes, offSet6) & 0x8000) != 0)
                    {
                        validcell = false;
                    }
                    offSet6 += 2;
                    offSet6 += 4;
                    byte light = fileBytes[offSet6++];
                    offSet6 += 2;
                    if (validcell)
                    {
                        List<Cell> validCells = ValidCells;
                        Cell[,] cells = Cells;
                        int num = x;
                        int num2 = y;
                        Cell obj = new Cell(new Point(x, y))
                        {
                            Map = this
                        };
                        Cell item = obj;
                        cells[num, num2] = obj;
                        validCells.Add(item);
                    }
                }
            }
        }

        private void LoadMapCellsV100(byte[] Bytes)
        {
            int offset6 = 4;
            if (Bytes[0] != 1 || Bytes[1] != 0)
            {
                return;
            }
            Width = BitConverter.ToInt16(Bytes, offset6);
            offset6 += 2;
            Height = BitConverter.ToInt16(Bytes, offset6);
            Cells = new Cell[Width, Height];
            offset6 = 8;
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    bool validcell = true;
                    offset6 += 2;
                    if ((BitConverter.ToInt32(Bytes, offset6) & 0x20000000) != 0)
                    {
                        validcell = false;
                    }
                    offset6 += 10;
                    if ((BitConverter.ToInt16(Bytes, offset6) & 0x8000) != 0)
                    {
                        validcell = false;
                    }
                    offset6 += 2;
                    offset6 += 11;
                    byte light = Bytes[offset6++];
                    if (validcell)
                    {
                        List<Cell> validCells = ValidCells;
                        Cell[,] cells = Cells;
                        int num = x;
                        int num2 = y;
                        Cell obj = new Cell(new Point(x, y))
                        {
                            Map = this
                        };
                        Cell item = obj;
                        cells[num, num2] = obj;
                        validCells.Add(item);
                    }
                }
            }
        }

        
        public void Load()
        {
            string fileName = $"{Config.MapPath}{Info.FileName}.map";

            if (!File.Exists(fileName))
            {
                SEnvir.Log($"Map: {fileName} 找不到.");
                return;
            }


            byte[] fileBytes = File.ReadAllBytes(fileName);

            Width = fileBytes[23] << 8 | fileBytes[22];
            Height = fileBytes[25] << 8 | fileBytes[24];

            Cells = new Cell[Width, Height];

            int offSet = 28 + Width * Height / 4 * 3;

            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                {
                    byte flag = fileBytes[offSet + (x * Height + y) * 14];

                    if ((flag & 0x02) != 2 || (flag & 0x01) != 1) continue;

                    ValidCells.Add(Cells[x, y] = new Cell(new Point(x, y)) { Map = this });
                }

            OrderedObjects = new HashSet<MapObject>[Width];
            for (int i = 0; i < OrderedObjects.Length; i++)
                OrderedObjects[i] = new HashSet<MapObject>();
        }
        
        public void Setup()
        {
            CreateGuards();
        }

        private void CreateGuards()
        {
            foreach (GuardInfo info in Info.Guards)
            {
                MonsterObject mob = MonsterObject.GetMonster(info.Monster);
                mob.Direction = info.Direction;

                if (!mob.Spawn(Info, new Point(info.X, info.Y)))
                {
                
                    SEnvir.Log($"守卫地图生成失败:{Info.Description}, 位置: {info.X}, {info.Y}");
                    continue;
                }
            }
        }


        public void Process()
        {
        }

        public void AddObject(MapObject ob)
        {
            Objects.Add(ob);

            switch (ob.Race)
            {
                case ObjectType.Player:
                    Players.Add((PlayerObject)ob);
                    break;
                case ObjectType.Item:
                    break;
                case ObjectType.NPC:
                    NPCs.Add((NPCObject)ob);
                    break;
                case ObjectType.Spell:
                    break;
                case ObjectType.Monster:
                    MonsterObject mob = (MonsterObject)ob;
                    if (mob.MonsterInfo.IsBoss)
                        Bosses.Add(mob);
                    break;
            }
        }
        public void RemoveObject(MapObject ob)
        {
            Objects.Remove(ob);

            switch (ob.Race)
            {
                case ObjectType.Player:
                    Players.Remove((PlayerObject)ob);
                    break;
                case ObjectType.Item:
                    break;
                case ObjectType.NPC:
                    NPCs.Remove((NPCObject)ob);
                    break;
                case ObjectType.Spell:
                    break;
                case ObjectType.Monster:
                    MonsterObject mob = (MonsterObject)ob;
                    if (mob.MonsterInfo.IsBoss)
                        Bosses.Remove(mob);
                    break;
            }
        }

        public void CreateNpc(int x, int y, string NpcName)
        {
            NPCInfo npcInfo = SEnvir.GetNpcInfo(NpcName);
            new NPCObject() { NPCInfo = npcInfo }.Spawn(Info, new Point(x, y));
        }

        public void CreateNpc(int x, int y, int NpcIndex)
        {
            NPCInfo npcInfo = SEnvir.GetNpcInfo(NpcIndex);
            new NPCObject() { NPCInfo = npcInfo }.Spawn(Info, new Point(x, y));
        }

        public void DeleteNpc(string NpcName)
        {
            NPCInfo npcInfo = SEnvir.GetNpcInfo(NpcName);
            for (int index = Objects.Count - 1; index >= 0; --index)
            {
                NPCObject npcObject = Objects[index] as NPCObject;
                if (npcObject.NPCInfo.Equals((object)npcInfo))
                    RemoveObject((MapObject)npcObject);
            }
        }

        public void DeleteNpc(int NpcIndex)
        {
            NPCInfo npcInfo = SEnvir.GetNpcInfo(NpcIndex);
            for (int index = Objects.Count - 1; index >= 0; --index)
            {
                NPCObject npcObject = Objects[index] as NPCObject;
                if (npcObject.NPCInfo.Equals((object)npcInfo))
                    RemoveObject((MapObject)npcObject);
            }
        }

        public void CreateMon(int x, int y, int range, string monname, int count = 1)
        {
            MonsterInfo monsterInfo = SEnvir.GetMonsterInfo(monname);
            if (monsterInfo == null)
                return;
            for (; count > 0; --count)
            {
                MonsterObject monster = MonsterObject.GetMonster(monsterInfo);
                int num = 0;
                while (num < 20 && !monster.Spawn(Info, new Point(SEnvir.Random.Next(Math.Max(x - range, 10), Math.Min(x + range, Width - 10)), SEnvir.Random.Next(Math.Max(y - range, 10), Math.Min(y + range, Height - 10)))))
                    ++num;
            }
        }


        public void CreateMon(int x, int y, int range, int monindex, int count = 1)
        {
            MonsterInfo monsterInfo = SEnvir.GetMonsterInfo(monindex);
            if (monsterInfo == null)
                return;
            for (; count > 0; --count)
            {
                MonsterObject monster = MonsterObject.GetMonster(monsterInfo);
                int num = 0;
                while (num < 20 && !monster.Spawn(Info, new Point(SEnvir.Random.Next(Math.Max(x - range, 10), Math.Min(x + range, Width - 10)), SEnvir.Random.Next(Math.Max(y - range, 10), Math.Min(y + range, Height - 10)))))
                    ++num;
            }
        }


        public void ClearAllMonsters()
        {
            for (int index = Objects.Count - 1; index >= 0; --index)
            {
                MonsterObject monsterObject = Objects[index] as MonsterObject;
                if (monsterObject != null && monsterObject.PetOwner == null && !monsterObject.Dead)
                {
                    monsterObject.EXPOwner = null;
                    monsterObject.Drops = null;
                    monsterObject.Die();
                    monsterObject.Despawn();
                }
            }
        }

        public void ClearAllNpcs()
        {
            for (int index = Objects.Count - 1; index >= 0; --index)
            {
                NPCObject npcObject = Objects[index] as NPCObject;
                if (npcObject != null && !npcObject.Dead)
                {
                    npcObject.Die();
                    npcObject.Despawn();
                }
            }
        }

        public void ClearAllPlayers()
        {
            for (int index = Objects.Count - 1; index >= 0; --index)
            {
                PlayerObject playerObject = Objects[index] as PlayerObject;
                if (playerObject != null && !playerObject.Dead)
                    playerObject.Teleport(SEnvir.Maps[playerObject.Character.BindPoint.BindRegion.Map], playerObject.Character.BindPoint.ValidBindPoints[SEnvir.Random.Next(playerObject.Character.BindPoint.ValidBindPoints.Count)], true);
            }
        }

        public void ClearAllItems()
        {
            for (int index = Objects.Count - 1; index >= 0; --index)
                (Objects[index] as ItemObject)?.Despawn();
        }

        public void ClearSpellObjects()
        {
            for (int index = Objects.Count - 1; index >= 0; --index)
                (Objects[index] as SpellObject)?.Despawn();
        }

        public void ClearAllObjects()
        {
            for (int index = Objects.Count - 1; index >= 0; --index)
            {
                MapObject mapObject = Objects[index];
                if (mapObject != null && !mapObject.Dead)
                {
                    mapObject.Die();
                    mapObject.Despawn();
                }
            }
        }

        public void MapMsg(string msg, MessageType type)
        {
            Broadcast(new Chat()
            {
                Text = msg,
                Type = type
            });
        }

        public Cell GetCell(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height) return null;

            return Cells[x, y];
        }
        public Cell GetCell(Point location)
        {
            return GetCell(location.X, location.Y);
        }
        public List<Cell> GetCells(Point location, int minRadius, int maxRadius)
        {
            List<Cell> cells = new List<Cell>();

            for (int d = 0; d <= maxRadius; d++)
            {
                for (int y = location.Y - d; y <= location.Y + d; y++)
                {
                    if (y < 0) continue;
                    if (y >= Height) break;

                    for (int x = location.X - d; x <= location.X + d; x += Math.Abs(y - location.Y) == d ? 1 : d * 2)
                    {
                        if (x < 0) continue;
                        if (x >= Width) break;

                        Cell cell = Cells[x, y]; 

                        if (cell == null) continue;

                        cells.Add(cell);
                    }
                }
            }

            return cells;
        }


        public Point GetRandomLocation()
        {
            return ValidCells.Count > 0 ? ValidCells[SEnvir.Random.Next(ValidCells.Count)].Location : Point.Empty;
        }

        public Point GetRandomLocation(Point location, int range, int attempts = 25)
        {
            int minX = Math.Max(0, location.X - range);
            int maxX = Math.Min(Width, location.X + range);
            int minY = Math.Max(0, location.Y - range);
            int maxY = Math.Min(Height, location.Y + range);

            for (int i = 0; i < attempts; i++)
            {
                Point test = new Point(SEnvir.Random.Next(minX, maxX), SEnvir.Random.Next(minY, maxY));

                if (GetCell(test) != null)
                    return test;
            }

            return Point.Empty;
        }

        public Point GetRandomLocation(int minX, int maxX, int minY, int maxY, int attempts = 25)
        {
            for (int i = 0; i < attempts; i++)
            {
                Point test = new Point(SEnvir.Random.Next(minX, maxX), SEnvir.Random.Next(minY, maxY));

                if (GetCell(test) != null)
                    return test;
            }

            return Point.Empty;
        }

        public void Broadcast(Point location, Packet p)
        {
            foreach (PlayerObject player in Players)
            {
                if (!Functions.InRange(location, player.CurrentLocation, Config.MaxViewRange)) continue;
                player.Enqueue(p);
            }
        }
        public void Broadcast(Packet p)
        {
            foreach (PlayerObject player in Players)
                player.Enqueue(p);
        }

    }

    public class SpawnInfo
    {
        public RespawnInfo Info;
        public Map CurrentMap;

        public DateTime NextSpawn;
        public int AliveCount;

        public DateTime LastCheck;


        public SpawnInfo(RespawnInfo info)
        {
            Info = info;
            CurrentMap = SEnvir.GetMap(info.Region.Map);
            LastCheck = SEnvir.Now;
        }

        public void DoSpawn(bool eventSpawn)
        {
            if (!eventSpawn)
            {
                if (Info.EventSpawn || SEnvir.Now < NextSpawn) return;

                if (Info.Delay >= 1000000)
                {
                    TimeSpan timeofDay = TimeSpan.FromMinutes(Info.Delay - 1000000);

                    if (LastCheck.TimeOfDay >= timeofDay || SEnvir.Now.TimeOfDay < timeofDay)
                    {
                        LastCheck = SEnvir.Now;
                        return;
                    }

                    LastCheck = SEnvir.Now;
                }
                else
                {
                    if (Info.Announce)
                        NextSpawn = SEnvir.Now.AddSeconds(Info.Delay * 60);
                    else
                    {
                        if (Config.是否开启刷怪时间波动)
                            NextSpawn = SEnvir.Now.AddSeconds(SEnvir.Random.Next(Info.Delay * 60) + Info.Delay * 30);
                        else
                            NextSpawn = SEnvir.Now.AddSeconds(Info.Delay * 60);
                    }
                }
            }

            for (int i = AliveCount; i < Info.Count; i++)
            {
                MonsterObject mob = MonsterObject.GetMonster(Info.Monster);

   
                if (!Info.Monster.IsBoss)
                {
                    if (SEnvir.Now > Config.HalloweenEventTime && SEnvir.Now <= Config.HalloweenEventEnd)
                    {
                        mob = new HalloweenMonster { MonsterInfo = Info.Monster, HalloweenEventMob = true };
                        CurrentMap.HalloweenEventTime = SEnvir.Now.AddHours(1);
                    }
                    else if (SEnvir.Now > Config.ChristmasEventTime && SEnvir.Now <= Config.ChristmasEventEnd)
                    {
                        mob = new ChristmasMonster { MonsterInfo = Info.Monster, ChristmasEventMob = true };
                        CurrentMap.ChristmasEventTime = SEnvir.Now.AddMinutes(20);
                    }
                }


                mob.SpawnInfo = this;

                if (!mob.Spawn(Info.Region))
                {
                    mob.SpawnInfo = null;
                    continue;
                }

                if (Info.Announce)
                {
                    if (Info.Delay >= 1000000)
                    {
                        foreach (SConnection con in SEnvir.Connections)
                            con.ReceiveChat($"{mob.MonsterInfo.MonsterName} 已经出现.", MessageType.System);
                    }
                    else
                    {
                        foreach (SConnection con in SEnvir.Connections)
                            con.ReceiveChat(string.Format(con.Language.BossSpawn, CurrentMap.Info.Description), MessageType.System);
                    }
                }

                mob.DropSet = Info.DropSet;
                AliveCount++;
            }
        }
    }

    public class Cell
    {
        public Point Location;

        public Map Map;

        public List<MapObject> Objects;
        public SafeZoneInfo SafeZone;

        public List<MovementInfo> Movements;
        public bool HasMovement;


        public Cell(Point location)
        {
            Location = location;
        }


        public void AddObject(MapObject ob)
        {
            if (Objects == null)
                Objects = new List<MapObject>();

            Objects.Add(ob);

            ob.CurrentMap = Map;
            ob.CurrentLocation = Location;

            Map.OrderedObjects[Location.X].Add(ob);
        }
        public void RemoveObject(MapObject ob)
        {
            Objects.Remove(ob);

            if (Objects.Count == 0)
                Objects = null;

            Map.OrderedObjects[Location.X].Remove(ob);
        }
        public bool IsBlocking(MapObject checker, bool cellTime)
        {
            if (Objects == null) return false;

            foreach (MapObject ob in Objects)
            {
                if (!ob.Blocking) continue;
                if (cellTime && SEnvir.Now < ob.CellTime) continue;

                if (ob.Stats == null) return true;

                if (ob.Buffs.Any(x => x.Type == BuffType.Cloak || x.Type == BuffType.Transparency) && ob.Level > checker.Level && !ob.InGroup(checker)) continue;


                return true;
            }

            return false;
        }
        public Cell GetMovement(MapObject ob)
        {

            if (Movements == null || Movements.Count == 0)
                return this;
            Map map = null;

            bool grouprecall = false;
            bool groupforecall = false;
            bool gerenrecall = false;

            for (int i = 0; i < 5; i++) 
            {

                MovementInfo movement = Movements[SEnvir.Random.Next(Movements.Count)];

                if (movement.Fuben)
                    map = SEnvir.CreateMaps(movement.DestinationRegion.Map.Index);
                else
                    map = SEnvir.GetMap(movement.DestinationRegion.Map);


                Cell cell = map.GetCell(movement.DestinationRegion.PointList[SEnvir.Random.Next(movement.DestinationRegion.PointList.Count)]);

                if (cell == null) continue;

                PlayerObject player = (PlayerObject)ob;
                if (ob.Race == ObjectType.Player)
                {

                    if (movement.CurrentMapBoos)
                    {
                        if (ob.CurrentMap.Bosses.Count > 0)
                        {
                            player.Connection.ReceiveChat(string.Format(player.Connection.Language.CurrentMapBoos, ob.CurrentMap.Bosses.Count), MessageType.System);

                            foreach (SConnection con in player.Connection.Observers)
                                con.ReceiveChat(string.Format(con.Language.CurrentMapBoos, ob.CurrentMap.Bosses.Count), MessageType.System);
                            break;
                        }
                    }
                    if (movement.CurrentMapMon)
                    {
                        if (ob.CurrentMap.MonsterCount > 0)
                        {
                            player.Connection.ReceiveChat(string.Format(player.Connection.Language.CurrentMapMon, ob.CurrentMap.MonsterCount), MessageType.System);

                            foreach (SConnection con in player.Connection.Observers)
                                con.ReceiveChat(string.Format(con.Language.CurrentMapMon, ob.CurrentMap.MonsterCount), MessageType.System);
                            break;
                        }
                    }

                    if (movement.DestinationRegion.Map.MinimumLevel > ob.Level && !player.Character.Account.TempAdmin)
                    {
                        player.Connection.ReceiveChat(string.Format(player.Connection.Language.NeedLevel, movement.DestinationRegion.Map.MinimumLevel), MessageType.System);

                        foreach (SConnection con in player.Connection.Observers)
                            con.ReceiveChat(string.Format(con.Language.NeedLevel, movement.DestinationRegion.Map.MinimumLevel), MessageType.System);

                        break;
                    }
                    if (movement.DestinationRegion.Map.MaximumLevel > 0 && movement.DestinationRegion.Map.MaximumLevel < ob.Level && !player.Character.Account.TempAdmin)
                    {
                        player.Connection.ReceiveChat(string.Format(player.Connection.Language.NeedMaxLevel, movement.DestinationRegion.Map.MaximumLevel), MessageType.System);

                        foreach (SConnection con in player.Connection.Observers)
                            con.ReceiveChat(string.Format(con.Language.NeedMaxLevel, movement.DestinationRegion.Map.MaximumLevel), MessageType.System);

                        break;
                    }


                    if (movement.NeedSpawn != null)
                    {
                        SpawnInfo spawn = SEnvir.Spawns.FirstOrDefault(x => x.Info == movement.NeedSpawn);

                        if (spawn == null)
                            break;

                        if (spawn.AliveCount == 0)
                        {
                            player.Connection.ReceiveChat(player.Connection.Language.NeedMonster, MessageType.System);

                            foreach (SConnection con in player.Connection.Observers)
                                con.ReceiveChat(con.Language.NeedMonster, MessageType.System);

                            break;
                        }
                    }

                    if (movement.MonsterSpawn != null)
                    {

                        SpawnInfo spawn = SEnvir.Spawns.FirstOrDefault(x => x.Info == movement.MonsterSpawn);
                        if (spawn == null) continue;

                        spawn.DoSpawn(true);
                        player.Connection.ReceiveChat(string.Format(player.Connection.Language.MonsterSpawn, spawn.Info.MonsterName), MessageType.System);

                        foreach (SConnection con in player.Connection.Observers)
                            con.ReceiveChat(string.Format(player.Connection.Language.MonsterSpawn, spawn.Info.MonsterName), MessageType.System);

                    }

                    if (movement.Days != 0)
                    {
                        if (SEnvir.Now.DayOfYear - Config.ReleaseDate.DayOfYear < movement.Days)
                        {

                            int dayofyear = Config.ReleaseDate.DayOfYear + movement.Days - SEnvir.Now.DayOfYear;

                            DateTime newDay = SEnvir.Now;

                            if (dayofyear > 0)
                                newDay = DateTime.Now.AddDays(dayofyear);

                            player.Connection.ReceiveChat(string.Format(player.Connection.Language.Shijianbufu, map.Info.Description, newDay.ToString("M")), MessageType.System);

                            foreach (SConnection con in player.Connection.Observers)
                                con.ReceiveChat(string.Format(con.Language.Shijianbufu, map.Info.Description, newDay.ToString("M")), MessageType.System);
                            break;
                        }
                    }
                    if (movement.Fuben)
                    {
                        if (movement.Group && !movement.Geren)
                        {
                            if (player.GroupMembers == null)
                            {
                                player.Connection.ReceiveChat(player.Connection.Language.MovementGroupOK, MessageType.System);

                                foreach (SConnection con in player.Connection.Observers)
                                    con.ReceiveChat(con.Language.MovementGroupOK, MessageType.System);
                                break;
                            }
                            if (player.GroupMembers != null && player.GroupMembers[0] == player)
                            {
                                if (player.GroupMembers.Count == 16)
                                {
                                    if (player.GroupMembers[0].CurrentMap == player.GroupMembers[1].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[2].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[3].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[4].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[5].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[6].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[7].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[8].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[9].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[10].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[11].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[12].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[13].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[14].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[15].CurrentMap)
                                        grouprecall = true;
                                    else
                                    {
                                        player.Connection.ReceiveChat(player.Connection.Language.GroupNearby, MessageType.System);

                                        foreach (SConnection con in player.Connection.Observers)
                                            con.ReceiveChat(con.Language.GroupNearby, MessageType.System);
                                        break;
                                    }
                                }
                                else if (player.GroupMembers.Count == 15)
                                {
                                    if (player.GroupMembers[0].CurrentMap == player.GroupMembers[1].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[2].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[3].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[4].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[5].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[6].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[7].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[8].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[9].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[10].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[11].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[12].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[13].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[14].CurrentMap)
                                        grouprecall = true;
                                    else
                                    {
                                        player.Connection.ReceiveChat(player.Connection.Language.GroupNearby, MessageType.System);

                                        foreach (SConnection con in player.Connection.Observers)
                                            con.ReceiveChat(con.Language.GroupNearby, MessageType.System);
                                        break;
                                    }
                                }
                                else if (player.GroupMembers.Count == 14)
                                {
                                    if (player.GroupMembers[0].CurrentMap == player.GroupMembers[1].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[2].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[3].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[4].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[5].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[6].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[7].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[8].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[9].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[10].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[11].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[12].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[13].CurrentMap)
                                        grouprecall = true;
                                    else
                                    {
                                        player.Connection.ReceiveChat(player.Connection.Language.GroupNearby, MessageType.System);

                                        foreach (SConnection con in player.Connection.Observers)
                                            con.ReceiveChat(con.Language.GroupNearby, MessageType.System);
                                        break;
                                    }
                                }
                                else if (player.GroupMembers.Count == 13)
                                {
                                    if (player.GroupMembers[0].CurrentMap == player.GroupMembers[1].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[2].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[3].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[4].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[5].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[6].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[7].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[8].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[9].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[10].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[11].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[12].CurrentMap)
                                        grouprecall = true;
                                    else
                                    {
                                        player.Connection.ReceiveChat(player.Connection.Language.GroupNearby, MessageType.System);

                                        foreach (SConnection con in player.Connection.Observers)
                                            con.ReceiveChat(con.Language.GroupNearby, MessageType.System);
                                        break;
                                    }
                                }
                                else if (player.GroupMembers.Count == 12)
                                {
                                    if (player.GroupMembers[0].CurrentMap == player.GroupMembers[1].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[2].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[3].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[4].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[5].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[6].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[7].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[8].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[9].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[10].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[11].CurrentMap)
                                        grouprecall = true;
                                    else
                                    {
                                        player.Connection.ReceiveChat(player.Connection.Language.GroupNearby, MessageType.System);

                                        foreach (SConnection con in player.Connection.Observers)
                                            con.ReceiveChat(con.Language.GroupNearby, MessageType.System);
                                        break;
                                    }
                                }
                                else if (player.GroupMembers.Count == 11)
                                {
                                    if (player.GroupMembers[0].CurrentMap == player.GroupMembers[1].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[2].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[3].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[4].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[5].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[6].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[7].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[8].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[9].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[10].CurrentMap)
                                        grouprecall = true;
                                    else
                                    {
                                        player.Connection.ReceiveChat(player.Connection.Language.GroupNearby, MessageType.System);

                                        foreach (SConnection con in player.Connection.Observers)
                                            con.ReceiveChat(con.Language.GroupNearby, MessageType.System);
                                        break;
                                    }
                                }
                                else if (player.GroupMembers.Count == 10)
                                {
                                    if (player.GroupMembers[0].CurrentMap == player.GroupMembers[1].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[2].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[3].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[4].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[5].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[6].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[7].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[8].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[9].CurrentMap)
                                        grouprecall = true;
                                    else
                                    {
                                        player.Connection.ReceiveChat(player.Connection.Language.GroupNearby, MessageType.System);

                                        foreach (SConnection con in player.Connection.Observers)
                                            con.ReceiveChat(con.Language.GroupNearby, MessageType.System);
                                        break;
                                    }
                                }
                                else if (player.GroupMembers.Count == 9)
                                {
                                    if (player.GroupMembers[0].CurrentMap == player.GroupMembers[1].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[2].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[3].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[4].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[5].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[6].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[7].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[8].CurrentMap)
                                        grouprecall = true;
                                    else
                                    {
                                        player.Connection.ReceiveChat(player.Connection.Language.GroupNearby, MessageType.System);

                                        foreach (SConnection con in player.Connection.Observers)
                                            con.ReceiveChat(con.Language.GroupNearby, MessageType.System);
                                        break;
                                    }
                                }
                                else if (player.GroupMembers.Count == 8)
                                {
                                    if (player.GroupMembers[0].CurrentMap == player.GroupMembers[1].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[2].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[3].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[4].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[5].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[6].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[7].CurrentMap)
                                        grouprecall = true;
                                    else
                                    {
                                        player.Connection.ReceiveChat(player.Connection.Language.GroupNearby, MessageType.System);

                                        foreach (SConnection con in player.Connection.Observers)
                                            con.ReceiveChat(con.Language.GroupNearby, MessageType.System);
                                        break;
                                    }
                                }
                                else if (player.GroupMembers.Count == 7)
                                {
                                    if (player.GroupMembers[0].CurrentMap == player.GroupMembers[1].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[2].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[3].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[4].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[5].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[6].CurrentMap)
                                        grouprecall = true;
                                    else
                                    {
                                        player.Connection.ReceiveChat(player.Connection.Language.GroupNearby, MessageType.System);

                                        foreach (SConnection con in player.Connection.Observers)
                                            con.ReceiveChat(con.Language.GroupNearby, MessageType.System);
                                        break;
                                    }
                                }
                                else if (player.GroupMembers.Count == 6)
                                {
                                    if (player.GroupMembers[0].CurrentMap != player.GroupMembers[1].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[2].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[3].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[4].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[5].CurrentMap)
                                        grouprecall = true;
                                    else
                                    {
                                        player.Connection.ReceiveChat(player.Connection.Language.GroupNearby, MessageType.System);

                                        foreach (SConnection con in player.Connection.Observers)
                                            con.ReceiveChat(con.Language.GroupNearby, MessageType.System);
                                        break;
                                    }
                                }
                                else if (player.GroupMembers.Count == 5)
                                {
                                    if (player.GroupMembers[0].CurrentMap == player.GroupMembers[1].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[2].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[3].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[4].CurrentMap)
                                        grouprecall = true;
                                    else
                                    {
                                        player.Connection.ReceiveChat(player.Connection.Language.GroupNearby, MessageType.System);

                                        foreach (SConnection con in player.Connection.Observers)
                                            con.ReceiveChat(con.Language.GroupNearby, MessageType.System);
                                        break;
                                    }
                                }
                                else if (player.GroupMembers.Count == 4)
                                {
                                    if (player.GroupMembers[0].CurrentMap == player.GroupMembers[1].CurrentMap
                                       && player.GroupMembers[0].CurrentMap == player.GroupMembers[2].CurrentMap
                                       && player.GroupMembers[0].CurrentMap == player.GroupMembers[3].CurrentMap)
                                        grouprecall = true;
                                    else
                                    {
                                        player.Connection.ReceiveChat(player.Connection.Language.GroupNearby, MessageType.System);

                                        foreach (SConnection con in player.Connection.Observers)
                                            con.ReceiveChat(con.Language.GroupNearby, MessageType.System);
                                        break;
                                    }
                                }
                                else if (player.GroupMembers.Count == 3)
                                {
                                    if (player.GroupMembers[0].CurrentMap == player.GroupMembers[1].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[2].CurrentMap)
                                        grouprecall = true;
                                    else
                                    {
                                        player.Connection.ReceiveChat(player.Connection.Language.GroupNearby, MessageType.System);

                                        foreach (SConnection con in player.Connection.Observers)
                                            con.ReceiveChat(con.Language.GroupNearby, MessageType.System);
                                        break;
                                    }
                                }
                                else if (player.GroupMembers.Count == 2)
                                {
                                    if (player.GroupMembers[0].CurrentMap == player.GroupMembers[1].CurrentMap)
                                        grouprecall = true;
                                    else
                                    {
                                        player.Connection.ReceiveChat(player.Connection.Language.GroupNearby, MessageType.System);

                                        foreach (SConnection con in player.Connection.Observers)
                                            con.ReceiveChat(con.Language.GroupNearby, MessageType.System);
                                        break;
                                    }
                                }
                            }
                            if (player.GroupMembers != null && player.GroupMembers[0] != player)
                            {
                                if (player.GroupMembers[0].CurrentMap == player.CurrentMap)
                                {
                                    player.Connection.ReceiveChat(string.Format(player.Connection.Language.MovementGroup, player.GroupMembers[0].Name), MessageType.System);

                                    foreach (SConnection con in player.Connection.Observers)
                                        con.ReceiveChat(string.Format(player.Connection.Language.MovementGroup, player.GroupMembers[0].Name), MessageType.System);
                                    break;
                                }
                                else if (player.GroupMembers[0].CurrentMap != player.CurrentMap && !player.GroupMembers[0].CurrentMap.Info.IsDynamic)
                                {
                                    player.Connection.ReceiveChat(string.Format(player.Connection.Language.MovementGroupDuizhanghuiqu, player.GroupMembers[0].Name), MessageType.System);

                                    foreach (SConnection con in player.Connection.Observers)
                                        con.ReceiveChat(string.Format(player.Connection.Language.MovementGroupDuizhanghuiqu, player.GroupMembers[0].Name), MessageType.System);
                                    break;
                                }
                                else if (player.GroupMembers[0].CurrentMap != player.CurrentMap && player.GroupMembers[0].CurrentMap.Info.IsDynamic)
                                    groupforecall = true;
                            }

                        }
                        if (movement.Group && movement.Geren)
                        {
                            if (player.GroupMembers == null)
                                gerenrecall = true;
                            if (player.GroupMembers != null && player.GroupMembers[0] == player)
                            {
                                if (player.GroupMembers.Count == 16)
                                {
                                    if (player.GroupMembers[0].CurrentMap == player.GroupMembers[1].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[2].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[3].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[4].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[5].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[6].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[7].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[8].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[9].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[10].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[11].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[12].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[13].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[14].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[15].CurrentMap)
                                        grouprecall = true;
                                    else
                                    {
                                        player.Connection.ReceiveChat(player.Connection.Language.GroupNearby, MessageType.System);

                                        foreach (SConnection con in player.Connection.Observers)
                                            con.ReceiveChat(con.Language.GroupNearby, MessageType.System);
                                        break;
                                    }
                                }
                                else if (player.GroupMembers.Count == 15)
                                {
                                    if (player.GroupMembers[0].CurrentMap == player.GroupMembers[1].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[2].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[3].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[4].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[5].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[6].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[7].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[8].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[9].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[10].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[11].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[12].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[13].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[14].CurrentMap)
                                        grouprecall = true;
                                    else
                                    {
                                        player.Connection.ReceiveChat(player.Connection.Language.GroupNearby, MessageType.System);

                                        foreach (SConnection con in player.Connection.Observers)
                                            con.ReceiveChat(con.Language.GroupNearby, MessageType.System);
                                        break;
                                    }
                                }
                                else if (player.GroupMembers.Count == 14)
                                {
                                    if (player.GroupMembers[0].CurrentMap == player.GroupMembers[1].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[2].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[3].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[4].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[5].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[6].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[7].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[8].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[9].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[10].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[11].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[12].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[13].CurrentMap)
                                        grouprecall = true;
                                    else
                                    {
                                        player.Connection.ReceiveChat(player.Connection.Language.GroupNearby, MessageType.System);

                                        foreach (SConnection con in player.Connection.Observers)
                                            con.ReceiveChat(con.Language.GroupNearby, MessageType.System);
                                        break;
                                    }
                                }
                                else if (player.GroupMembers.Count == 13)
                                {
                                    if (player.GroupMembers[0].CurrentMap == player.GroupMembers[1].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[2].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[3].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[4].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[5].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[6].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[7].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[8].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[9].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[10].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[11].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[12].CurrentMap)
                                        grouprecall = true;
                                    else
                                    {
                                        player.Connection.ReceiveChat(player.Connection.Language.GroupNearby, MessageType.System);

                                        foreach (SConnection con in player.Connection.Observers)
                                            con.ReceiveChat(con.Language.GroupNearby, MessageType.System);
                                        break;
                                    }
                                }
                                else if (player.GroupMembers.Count == 12)
                                {
                                    if (player.GroupMembers[0].CurrentMap == player.GroupMembers[1].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[2].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[3].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[4].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[5].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[6].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[7].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[8].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[9].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[10].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[11].CurrentMap)
                                        grouprecall = true;
                                    else
                                    {
                                        player.Connection.ReceiveChat(player.Connection.Language.GroupNearby, MessageType.System);

                                        foreach (SConnection con in player.Connection.Observers)
                                            con.ReceiveChat(con.Language.GroupNearby, MessageType.System);
                                        break;
                                    }
                                }
                                else if (player.GroupMembers.Count == 11)
                                {
                                    if (player.GroupMembers[0].CurrentMap == player.GroupMembers[1].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[2].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[3].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[4].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[5].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[6].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[7].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[8].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[9].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[10].CurrentMap)
                                        grouprecall = true;
                                    else
                                    {
                                        player.Connection.ReceiveChat(player.Connection.Language.GroupNearby, MessageType.System);

                                        foreach (SConnection con in player.Connection.Observers)
                                            con.ReceiveChat(con.Language.GroupNearby, MessageType.System);
                                        break;
                                    }
                                }
                                else if (player.GroupMembers.Count == 10)
                                {
                                    if (player.GroupMembers[0].CurrentMap == player.GroupMembers[1].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[2].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[3].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[4].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[5].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[6].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[7].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[8].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[9].CurrentMap)
                                        grouprecall = true;
                                    else
                                    {
                                        player.Connection.ReceiveChat(player.Connection.Language.GroupNearby, MessageType.System);

                                        foreach (SConnection con in player.Connection.Observers)
                                            con.ReceiveChat(con.Language.GroupNearby, MessageType.System);
                                        break;
                                    }
                                }
                                else if (player.GroupMembers.Count == 9)
                                {
                                    if (player.GroupMembers[0].CurrentMap == player.GroupMembers[1].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[2].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[3].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[4].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[5].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[6].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[7].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[8].CurrentMap)
                                        grouprecall = true;
                                    else
                                    {
                                        player.Connection.ReceiveChat(player.Connection.Language.GroupNearby, MessageType.System);

                                        foreach (SConnection con in player.Connection.Observers)
                                            con.ReceiveChat(con.Language.GroupNearby, MessageType.System);
                                        break;
                                    }
                                }
                                else if (player.GroupMembers.Count == 8)
                                {
                                    if (player.GroupMembers[0].CurrentMap == player.GroupMembers[1].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[2].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[3].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[4].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[5].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[6].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[7].CurrentMap)
                                        grouprecall = true;
                                    else
                                    {
                                        player.Connection.ReceiveChat(player.Connection.Language.GroupNearby, MessageType.System);

                                        foreach (SConnection con in player.Connection.Observers)
                                            con.ReceiveChat(con.Language.GroupNearby, MessageType.System);
                                        break;
                                    }
                                }
                                else if (player.GroupMembers.Count == 7)
                                {
                                    if (player.GroupMembers[0].CurrentMap == player.GroupMembers[1].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[2].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[3].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[4].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[5].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[6].CurrentMap)
                                        grouprecall = true;
                                    else
                                    {
                                        player.Connection.ReceiveChat(player.Connection.Language.GroupNearby, MessageType.System);

                                        foreach (SConnection con in player.Connection.Observers)
                                            con.ReceiveChat(con.Language.GroupNearby, MessageType.System);
                                        break;
                                    }
                                }
                                else if (player.GroupMembers.Count == 6)
                                {
                                    if (player.GroupMembers[0].CurrentMap != player.GroupMembers[1].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[2].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[3].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[4].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[5].CurrentMap)
                                        grouprecall = true;
                                    else
                                    {
                                        player.Connection.ReceiveChat(player.Connection.Language.GroupNearby, MessageType.System);

                                        foreach (SConnection con in player.Connection.Observers)
                                            con.ReceiveChat(con.Language.GroupNearby, MessageType.System);
                                        break;
                                    }
                                }
                                else if (player.GroupMembers.Count == 5)
                                {
                                    if (player.GroupMembers[0].CurrentMap == player.GroupMembers[1].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[2].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[3].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[4].CurrentMap)
                                        grouprecall = true;
                                    else
                                    {
                                        player.Connection.ReceiveChat(player.Connection.Language.GroupNearby, MessageType.System);

                                        foreach (SConnection con in player.Connection.Observers)
                                            con.ReceiveChat(con.Language.GroupNearby, MessageType.System);
                                        break;
                                    }
                                }
                                else if (player.GroupMembers.Count == 4)
                                {
                                    if (player.GroupMembers[0].CurrentMap == player.GroupMembers[1].CurrentMap
                                       && player.GroupMembers[0].CurrentMap == player.GroupMembers[2].CurrentMap
                                       && player.GroupMembers[0].CurrentMap == player.GroupMembers[3].CurrentMap)
                                        grouprecall = true;
                                    else
                                    {
                                        player.Connection.ReceiveChat(player.Connection.Language.GroupNearby, MessageType.System);

                                        foreach (SConnection con in player.Connection.Observers)
                                            con.ReceiveChat(con.Language.GroupNearby, MessageType.System);
                                        break;
                                    }
                                }
                                else if (player.GroupMembers.Count == 3)
                                {
                                    if (player.GroupMembers[0].CurrentMap == player.GroupMembers[1].CurrentMap
                                        && player.GroupMembers[0].CurrentMap == player.GroupMembers[2].CurrentMap)
                                        grouprecall = true;
                                    else
                                    {
                                        player.Connection.ReceiveChat(player.Connection.Language.GroupNearby, MessageType.System);

                                        foreach (SConnection con in player.Connection.Observers)
                                            con.ReceiveChat(con.Language.GroupNearby, MessageType.System);
                                        break;
                                    }
                                }
                                else if (player.GroupMembers.Count == 2)
                                {
                                    if (player.GroupMembers[0].CurrentMap == player.GroupMembers[1].CurrentMap)
                                        grouprecall = true;
                                    else
                                    {
                                        player.Connection.ReceiveChat(player.Connection.Language.GroupNearby, MessageType.System);

                                        foreach (SConnection con in player.Connection.Observers)
                                            con.ReceiveChat(con.Language.GroupNearby, MessageType.System);
                                        break;
                                    }
                                }
                            }
                            if (player.GroupMembers != null && player.GroupMembers[0] != player)
                            {
                                if (player.GroupMembers[0].CurrentMap == player.CurrentMap)
                                {
                                    player.Connection.ReceiveChat(string.Format(player.Connection.Language.MovementGroup, player.GroupMembers[0].Name), MessageType.System);

                                    foreach (SConnection con in player.Connection.Observers)
                                        con.ReceiveChat(string.Format(player.Connection.Language.MovementGroup, player.GroupMembers[0].Name), MessageType.System);
                                    break;
                                }
                                else
                                    groupforecall = true;
                            }

                        }
                        if (!movement.Group && movement.Geren)
                        {
                            if (player.GroupMembers != null)
                            {
                                player.Connection.ReceiveChat(player.Connection.Language.MovementGeren, MessageType.System);

                                foreach (SConnection con in player.Connection.Observers)
                                    con.ReceiveChat(con.Language.MovementGeren, MessageType.System);
                                break;
                            }
                            if (player.GroupMembers == null)
                                gerenrecall = true;
                        }
                    }
                    if (movement.NeedItem != null)
                    {
                        if (player.GetItemCount(movement.NeedItem) == 0)
                        {
                            player.Connection.ReceiveChat(string.Format(player.Connection.Language.NeedItem, movement.NeedItem.ItemName, movement.NeedItemCount), MessageType.System);

                            foreach (SConnection con in player.Connection.Observers)
                                con.ReceiveChat(string.Format(con.Language.NeedItem, movement.NeedItem.ItemName, movement.NeedItemCount), MessageType.System);
                            break;
                        }
                        if (player.GetItemCount(movement.NeedItem) < movement.NeedItemCount)
                        {
                            player.Connection.ReceiveChat(string.Format(player.Connection.Language.NeedItem, movement.NeedItem.ItemName, movement.NeedItemCount), MessageType.System);

                            foreach (SConnection con in player.Connection.Observers)
                                con.ReceiveChat(string.Format(con.Language.NeedItem, movement.NeedItem.ItemName, movement.NeedItemCount), MessageType.System);
                            break;
                        }
                        player.TakeItem(movement.NeedItem, movement.NeedItemCount);

                    }
                    if (movement.GiveItem != null)
                    {
                        player.GiveItems(movement.GiveItem, movement.GiveItemCount);
                    }

                    switch (movement.Effect)
                    {
                        case MovementEffect.SpecialRepair:
                            player.SpecialRepair(EquipmentSlot.Weapon);
                            player.SpecialRepair(EquipmentSlot.Shield);
                            player.SpecialRepair(EquipmentSlot.Helmet);
                            player.SpecialRepair(EquipmentSlot.Armour);
                            player.SpecialRepair(EquipmentSlot.Shizhuang);
                            player.SpecialRepair(EquipmentSlot.Necklace);
                            player.SpecialRepair(EquipmentSlot.BraceletL);
                            player.SpecialRepair(EquipmentSlot.BraceletR);
                            player.SpecialRepair(EquipmentSlot.RingL);
                            player.SpecialRepair(EquipmentSlot.RingR);
                            player.SpecialRepair(EquipmentSlot.Shoes);

                            player.RefreshStats();
                            break;
                    }


                }
  
                if (movement.Jilu)
                {
                    string fileName;
                    fileName = Path.Combine(SEnvir.NameListPath, movement.JiluName + ".txt");
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

                if (movement.Fuben)
                {
                    if (movement.Group && grouprecall)
                    {
                        for (int j = 0; j < ob.GroupMembers.Count(); j++)
                        {
                            if (player.GroupMembers[0] == player)
                                return cell.GetMovement(ob);
                        }
                    }
                    else if (movement.Group && groupforecall)
                    {
                        return player.GroupMembers[0].CurrentMap.GetCell(movement.DestinationRegion.PointList[SEnvir.Random.Next(movement.DestinationRegion.PointList.Count)]).GetMovement(ob);
                    }

                    if (movement.Geren && gerenrecall)
                        return cell.GetMovement(ob);
                }
                else
                    return cell.GetMovement(ob);


                if (movement.Fuben)
                    SEnvir.CloseMap(map);

            }

            return this;
        }


    }
}
