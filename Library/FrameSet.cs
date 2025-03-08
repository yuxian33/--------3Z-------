using System;
using System.Collections.Generic;

namespace Library
{
    public sealed class FrameSet
    {
        public static Dictionary<MirAnimation, Frame> Players;

        public static Dictionary<MirAnimation, Frame> DefaultItem;

        public static Dictionary<MirAnimation, Frame> DefaultNPC;

        public static Dictionary<MirAnimation, Frame> DefaultMonster;

        public static Dictionary<MirAnimation, Frame> SDMob27;
        public static Dictionary<MirAnimation, Frame> SDMob28;
        public static Dictionary<MirAnimation, Frame> SDMob29;
        public static Dictionary<MirAnimation, Frame> CrazedPrimate;
        public static Dictionary<MirAnimation, Frame> HellBringer;
        public static Dictionary<MirAnimation, Frame> YurinMon0;
        public static Dictionary<MirAnimation, Frame> YurinMon1;
        public static Dictionary<MirAnimation, Frame> WhiteBeardedTiger;
        public static Dictionary<MirAnimation, Frame> HardenedRhino;
        public static Dictionary<MirAnimation, Frame> Mammoth;
        public static Dictionary<MirAnimation, Frame> CursedSlave1;
        public static Dictionary<MirAnimation, Frame> CursedSlave2;
        public static Dictionary<MirAnimation, Frame> CursedSlave3;
        public static Dictionary<MirAnimation, Frame> PoisonousGolem;
        public static Dictionary<MirAnimation, Frame> WolongBianfu02;  
        public static Dictionary<MirAnimation, Frame> Hd1;  
        public static Dictionary<MirAnimation, Frame> Hd2;  
        public static Dictionary<MirAnimation, Frame> Horses;

        public static Dictionary<MirAnimation, Frame>
            ForestYeti, ChestnutTree, CarnivorousPlant,
            DevouringGhost,
            Larva,
            ZumaGuardian, ZumaKing,
            Monkey,
            NumaMage, CursedCactus, NetherWorldGate,
            WestDesertLizard,
            BanyaGuard, EmperorSaWoo,
            JinchonDevil,
            ArchLichTaeda,
            ShinsuBig,
            PachonTheChaosBringer,
            IcySpiritGeneral,
            FieryDancer, EmeraldDancer, QueenOfDawn,
            JinamStoneGate, OYoungBeast, YumgonWitch, JinhwanSpirit, ChiwooGeneral, DragonQueen, DragonLord,
            FerociousIceTiger,
            SamaFireGuardian, Phoenix, EnshrinementBox, BloodStone, SamaCursedBladesman, SamaCursedSlave, SamaProphet, SamaSorcerer,
            EasterEvent,
            OrangeTiger, RedTiger, OrangeBossTiger, BigBossTiger,

            SDMob3, SDMob8, SDMob15, SDMob16, SDMob17, SDMob18, SDMob19, SDMob21, SDMob22, SDMob23, SDMob24, SDMob25, SDMob26,

            LobsterLord, LobsterSpawn,

            DeadTree, BobbitWorm,
            MonasteryMon1, MonasteryMon3,

            HdBoss, HdBoss2,

            yaotaStoneGate,
            MotaStoneGate,
            Huodong01StoneGate,
            Huodong02StoneGate,
            Huodong03StoneGate,
            Huodong04StoneGate,
            Huodong05StoneGate,
            Huodong06StoneGate,
            Huodong07StoneGate,
            Huodong08StoneGate,
            Huodong09StoneGate,
            Huodong10StoneGate,
            Huodong11StoneGate,
            Huodong12StoneGate,
            GuildFbBoss,

            GardenSoldier, GardenDefender, RedBlossom, BlueBlossom, FireBird,
            
            
            FubenShiwang;




        static FrameSet()
        {
            Players = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 4, 10, TimeSpan.FromMilliseconds(500)),
                [MirAnimation.Walking] = new Frame(80, 6, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Running] = new Frame(160, 6, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.CreepStanding] = new Frame(1680, 4, 10, TimeSpan.FromMilliseconds(500)), 
                [MirAnimation.CreepWalkFast] = new Frame(1760, 6, 10, TimeSpan.FromMilliseconds(100)), 
                [MirAnimation.CreepWalkSlow] = new Frame(1760, 6, 10, TimeSpan.FromMilliseconds(200)), 
                [MirAnimation.Pushed] = new Frame(240, 6, 10, TimeSpan.FromMilliseconds(50)) { Reversed = true, StaticSpeed = true },
                
                [MirAnimation.Stance] = new Frame(400, 3, 10, TimeSpan.FromMilliseconds(500)),
                [MirAnimation.Harvest] = new Frame(480, 2, 10, TimeSpan.FromMilliseconds(300)),
                [MirAnimation.Combat1] = new Frame(560, 5, 10, TimeSpan.FromMilliseconds(100)), 
                [MirAnimation.Combat2] = new Frame(640, 5, 10, TimeSpan.FromMilliseconds(100)), 
                [MirAnimation.Combat3] = new Frame(720, 6, 10, TimeSpan.FromMilliseconds(100)), 
                [MirAnimation.Combat4] = new Frame(800, 6, 10, TimeSpan.FromMilliseconds(100)), 
                [MirAnimation.Combat5] = new Frame(880, 10, 10, TimeSpan.FromMilliseconds(60)), 
                [MirAnimation.Combat6] = new Frame(960, 10, 10, TimeSpan.FromMilliseconds(60)), 
                [MirAnimation.Combat7] = new Frame(1040, 10, 10, TimeSpan.FromMilliseconds(100)), 
                [MirAnimation.Combat8] = new Frame(1120, 6, 10, TimeSpan.FromMilliseconds(50)) { StaticSpeed = true }, 
                [MirAnimation.Combat9] = new Frame(1200, 10, 10, TimeSpan.FromMilliseconds(100)), 
                [MirAnimation.Combat10] = new Frame(1280, 10, 10, TimeSpan.FromMilliseconds(60)), 
                [MirAnimation.Combat11] = new Frame(1360, 10, 10, TimeSpan.FromMilliseconds(60)), 
                [MirAnimation.Combat12] = new Frame(1440, 10, 10, TimeSpan.FromMilliseconds(60)), 
                [MirAnimation.Combat13] = new Frame(1520, 6, 10, TimeSpan.FromMilliseconds(100)), 
                [MirAnimation.Combat14] = new Frame(1600, 8, 10, TimeSpan.FromMilliseconds(100)), 
                [MirAnimation.Combat15] = new Frame(400, 3, 10, TimeSpan.FromMilliseconds(200)),
                [MirAnimation.DragonRepulseStart] = new Frame(1600, 6, 10, TimeSpan.FromMilliseconds(100)), 
                [MirAnimation.DragonRepulseMiddle] = new Frame(1605, 1, 10, TimeSpan.FromMilliseconds(1000)), 
                [MirAnimation.DragonRepulseEnd] = new Frame(1606, 2, 10, TimeSpan.FromMilliseconds(100)), 
                [MirAnimation.Struck] = new Frame(1840, 3, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Die] = new Frame(1920, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(1929, 1, 10, TimeSpan.FromMilliseconds(1000)),
                [MirAnimation.HorseStanding] = new Frame(2240, 4, 10, TimeSpan.FromMilliseconds(500)), 
                [MirAnimation.HorseWalking] = new Frame(2320, 6, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.HorseRunning] = new Frame(2400, 6, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.HorseStruck] = new Frame(2480, 3, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.ChannellingStart] = new Frame(560, 4, 10, TimeSpan.FromMilliseconds(100)), 
                [MirAnimation.ChannellingMiddle] = new Frame(563, 1, 10, TimeSpan.FromMilliseconds(1000)), 
                [MirAnimation.ChannellingEnd] = new Frame(0, 1, 10, TimeSpan.FromMilliseconds(60)), 
                
            };

            Players[MirAnimation.Combat1].Delays[1] = TimeSpan.FromMilliseconds(200);
            Players[MirAnimation.Combat2].Delays[3] = TimeSpan.FromMilliseconds(200);

            /*
            Assassin = new Dictionary<MirAction, Frame>
            {
                [MirAction.Standing] = new Frame(0, 4, 10, TimeSpan.FromMilliseconds(500)),
                [MirAction.Walking] = new Frame(80, 6, 10, TimeSpan.FromMilliseconds(100)),
                [MirAction.Running] = new Frame(160, 6, 10, TimeSpan.FromMilliseconds(100)),
                [MirAction.Stance] = new Frame(560, 3, 10, TimeSpan.FromMilliseconds(500)),

                [MirAction.Harvest] = new Frame(480, 2, 10, TimeSpan.FromMilliseconds(300)),
                [MirAction.Attack1] = new Frame(720, 6, 10, TimeSpan.FromMilliseconds(100)),
                [MirAction.Struck] = new Frame(1840, 3, 10, TimeSpan.FromMilliseconds(100)),
                [MirAction.Die] = new Frame(1920, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAction.Dead] = new Frame(1929, 1, 10, TimeSpan.FromMilliseconds(1000)),
            };*/

            DefaultItem = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 1, 0, TimeSpan.FromMilliseconds(1000)),
            };

            DefaultNPC = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 4, 0, TimeSpan.FromMilliseconds(1000)),
            };

            DefaultMonster = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 4, 10, TimeSpan.FromMilliseconds(500)),
                [MirAnimation.Walking] = new Frame(80, 6, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Pushed] = new Frame(80, 6, 10, TimeSpan.FromMilliseconds(50)) { Reversed = true, StaticSpeed = true },
                [MirAnimation.Combat1] = new Frame(160, 6, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat2] = new Frame(160, 6, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat3] = new Frame(160, 6, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Struck] = new Frame(240, 2, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Die] = new Frame(320, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(329, 1, 10, TimeSpan.FromMilliseconds(1000)),
                [MirAnimation.Skeleton] = new Frame(880, 1, 10, TimeSpan.FromMilliseconds(1000)),
                [MirAnimation.Show] = new Frame(640, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Hide] = new Frame(640, 10, 10, TimeSpan.FromMilliseconds(100)) { Reversed = true },
                [MirAnimation.StoneStanding] = new Frame(640, 1, 10, TimeSpan.FromMilliseconds(500)),
                
            };



            ForestYeti = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Die] = new Frame(320, 4, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(323, 1, 10, TimeSpan.FromMilliseconds(1000)),
            };


            ChestnutTree = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Die] = new Frame(320, 9, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(328, 1, 10, TimeSpan.FromMilliseconds(1000)),
            };

            CarnivorousPlant = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 4, 0, TimeSpan.FromMilliseconds(500)),
                [MirAnimation.Show] = new Frame(640, 8, 0, TimeSpan.FromMilliseconds(100)) { Reversed = true, },
                [MirAnimation.Hide] = new Frame(640, 8, 0, TimeSpan.FromMilliseconds(100)),
            };

            DevouringGhost = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Show] = new Frame(400, 10, 10, TimeSpan.FromMilliseconds(100)),
            };

            Larva = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(80, 6, 10, TimeSpan.FromMilliseconds(500)),
            };

            HdBoss = new Dictionary<MirAnimation, Frame>()
            {
                [MirAnimation.Standing] = new Frame(0, 26, 30, TimeSpan.FromMilliseconds(300)),
                [MirAnimation.Struck] = new Frame(30, 6, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Show] = new Frame(40, 14, 0, TimeSpan.FromMilliseconds(150)),
                [MirAnimation.Hide] = new Frame(40, 14, 0, TimeSpan.FromMilliseconds(150)) { Reversed = true, },
                [MirAnimation.Combat1] = new Frame(60, 15, 20, TimeSpan.FromMilliseconds(200)),
                [MirAnimation.Combat2] = new Frame(80, 20, 20, TimeSpan.FromMilliseconds(200)),
                
                
                /*
                [MirAnimation.Combat2] = new Frame(0, 26, 30, TimeSpan.FromMilliseconds(300)),
                [MirAnimation.Struck] = new Frame(30, 6, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat1] = new Frame(40, 14, 20, TimeSpan.FromMilliseconds(150)),
                [MirAnimation.Combat5] = new Frame(60, 15, 20, TimeSpan.FromMilliseconds(200)),
                [MirAnimation.Combat6] = new Frame(80, 20, 20, TimeSpan.FromMilliseconds(200)),
                [MirAnimation.Show] = new Frame(640, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Hide] = new Frame(640, 10, 10, TimeSpan.FromMilliseconds(100)) { Reversed = true, },
                */
            };

            HdBoss2 = new Dictionary<MirAnimation, Frame>()
            {
                [MirAnimation.Combat1] = new Frame(0, 19, 30, TimeSpan.FromMilliseconds(300.0)),
                [MirAnimation.Combat2] = new Frame(50, 21, 30, TimeSpan.FromMilliseconds(200.0)),
                [MirAnimation.Combat3] = new Frame(80, 8, 10, TimeSpan.FromMilliseconds(200.0)),
                [MirAnimation.Struck] = new Frame(30, 8, 10, TimeSpan.FromMilliseconds(100.0)),
            };

            ZumaGuardian = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Show] = new Frame(640, 6, 10, TimeSpan.FromMilliseconds(100)),
            };

            ZumaKing = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Show] = new Frame(640, 20, 0, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.StoneStanding] = new Frame(640, 1, 0, TimeSpan.FromMilliseconds(500)),
            };

            Monkey = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Combat2] = new Frame(400, 6, 10, TimeSpan.FromMilliseconds(100)),
            };

            NetherWorldGate = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 10, 0, TimeSpan.FromMilliseconds(200)),
            };

            CursedCactus = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 1, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat1] = new Frame(80, 10, 10, TimeSpan.FromMilliseconds(100)),
            };

            NumaMage = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Combat3] = new Frame(480, 6, 10, TimeSpan.FromMilliseconds(100)),
            };

            WestDesertLizard = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Combat2] = new Frame(480, 6, 10, TimeSpan.FromMilliseconds(100)),
            };

            BanyaGuard = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Combat2] = new Frame(400, 6, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat3] = new Frame(400, 6, 10, TimeSpan.FromMilliseconds(100)),
            };

            JinchonDevil = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Combat1] = new Frame(160, 9, 10, TimeSpan.FromMilliseconds(70)),
                [MirAnimation.Combat2] = new Frame(400, 9, 10, TimeSpan.FromMilliseconds(70)),
                [MirAnimation.Combat3] = new Frame(480, 8, 10, TimeSpan.FromMilliseconds(70)),
            };


            EmperorSaWoo = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Combat2] = new Frame(480, 6, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat3] = new Frame(480, 6, 10, TimeSpan.FromMilliseconds(100)),
            };

            ArchLichTaeda = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Combat2] = new Frame(400, 6, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Show] = new Frame(480, 6, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Die] = new Frame(720, 20, 20, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(739, 1, 20, TimeSpan.FromMilliseconds(500)),
            };
            
            PachonTheChaosBringer = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Combat1] = new Frame(160, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat3] = new Frame(480, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.DragonRepulseStart] = new Frame(480, 7, 10, TimeSpan.FromMilliseconds(100)), 
                [MirAnimation.DragonRepulseMiddle] = new Frame(486, 1, 10, TimeSpan.FromMilliseconds(1000)), 
                [MirAnimation.DragonRepulseEnd] = new Frame(487, 3, 10, TimeSpan.FromMilliseconds(100)), 
            };

            IcySpiritGeneral = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Combat3] = new Frame(400, 6, 10, TimeSpan.FromMilliseconds(100)),
            };

            FieryDancer = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 10, 10, TimeSpan.FromMilliseconds(500)),
                [MirAnimation.Walking] = new Frame(80, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Pushed] = new Frame(80, 10, 10, TimeSpan.FromMilliseconds(50)) { Reversed = true, StaticSpeed = true },
                [MirAnimation.Combat1] = new Frame(160, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat2] = new Frame(160, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat3] = new Frame(160, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Struck] = new Frame(240, 4, 10, TimeSpan.FromMilliseconds(100)),
                
            };


            EmeraldDancer = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 10, 10, TimeSpan.FromMilliseconds(500)),
                [MirAnimation.Walking] = new Frame(80, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Pushed] = new Frame(80, 10, 10, TimeSpan.FromMilliseconds(50)) { Reversed = true, StaticSpeed = true },
                [MirAnimation.Combat1] = new Frame(160, 20, 20, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat2] = new Frame(320, 20, 20, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat3] = new Frame(320, 20, 20, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Struck] = new Frame(480, 4, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Die] = new Frame(560, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(569, 1, 10, TimeSpan.FromMilliseconds(500)),
            };

            QueenOfDawn = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Combat2] = new Frame(400, 9, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat3] = new Frame(400, 9, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Die] = new Frame(320, 7, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(326, 1, 10, TimeSpan.FromMilliseconds(500)),
            };

            OYoungBeast = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 6, 10, TimeSpan.FromMilliseconds(500)),
                [MirAnimation.Combat1] = new Frame(160, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat2] = new Frame(400, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat3] = new Frame(400, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Struck] = new Frame(240, 5, 10, TimeSpan.FromMilliseconds(100)),
            };

            YumgonWitch = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 10, 10, TimeSpan.FromMilliseconds(500)),
                [MirAnimation.Walking] = new Frame(80, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Pushed] = new Frame(80, 10, 10, TimeSpan.FromMilliseconds(50)) { Reversed = true, StaticSpeed = true },
                [MirAnimation.Combat1] = new Frame(160, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat2] = new Frame(400, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat3] = new Frame(400, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Struck] = new Frame(240, 4, 10, TimeSpan.FromMilliseconds(100)),
            };

            JinhwanSpirit = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Combat2] = new Frame(400, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat3] = new Frame(400, 10, 10, TimeSpan.FromMilliseconds(100)),
            };

            ChiwooGeneral = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 10, 10, TimeSpan.FromMilliseconds(500)),
                [MirAnimation.Combat1] = new Frame(160, 8, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat2] = new Frame(400, 8, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat3] = new Frame(400, 8, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Die] = new Frame(320, 6, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(325, 1, 10, TimeSpan.FromMilliseconds(500)),
            };

            DragonQueen = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 10, 10, TimeSpan.FromMilliseconds(500)),
                [MirAnimation.Walking] = new Frame(80, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Pushed] = new Frame(80, 10, 10, TimeSpan.FromMilliseconds(50)) { Reversed = true, StaticSpeed = true },
                [MirAnimation.Combat1] = new Frame(160, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat2] = new Frame(160, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat3] = new Frame(160, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Struck] = new Frame(240, 3, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Die] = new Frame(320, 8, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(327, 1, 10, TimeSpan.FromMilliseconds(500)),
            };

            DragonLord = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 10, 10, TimeSpan.FromMilliseconds(500)),
                [MirAnimation.Walking] = new Frame(80, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Pushed] = new Frame(80, 10, 10, TimeSpan.FromMilliseconds(50)) { Reversed = true, StaticSpeed = true },
                [MirAnimation.Combat1] = new Frame(160, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat2] = new Frame(160, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat3] = new Frame(160, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Struck] = new Frame(240, 4, 10, TimeSpan.FromMilliseconds(100)),
            };

            FerociousIceTiger = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 6, 10, TimeSpan.FromMilliseconds(500)),
                [MirAnimation.Walking] = new Frame(80, 8, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Struck] = new Frame(240, 3, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Die] = new Frame(320, 6, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(325, 1, 10, TimeSpan.FromMilliseconds(500)),
                [MirAnimation.Combat1] = new Frame(480, 9, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat2] = new Frame(560, 16, 0, TimeSpan.FromMilliseconds(40)),
                [MirAnimation.Combat3] = new Frame(560, 16, 0, TimeSpan.FromMilliseconds(100)),
            };
            SamaFireGuardian = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Walking] = new Frame(80, 8, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat1] = new Frame(160, 8, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat2] = new Frame(240, 8, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Struck] = new Frame(320, 3, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Die] = new Frame(400, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(409, 1, 10, TimeSpan.FromMilliseconds(500)),
            };
            Phoenix = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Walking] = new Frame(80, 8, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat1] = new Frame(160, 8, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat2] = new Frame(240, 9, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat3] = new Frame(320, 7, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Struck] = new Frame(400, 3, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Die] = new Frame(480, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(489, 1, 10, TimeSpan.FromMilliseconds(500)),
            };

            EnshrinementBox = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 1, 0, TimeSpan.FromMilliseconds(200)),
                [MirAnimation.Struck] = new Frame(0, 1, 0, TimeSpan.FromMilliseconds(200)),
                [MirAnimation.Die] = new Frame(80, 10, 0, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(89, 1, 0, TimeSpan.FromMilliseconds(500)),
            };

            BloodStone = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 4, 0, TimeSpan.FromMilliseconds(200)),
                [MirAnimation.Struck] = new Frame(240, 2, 0, TimeSpan.FromMilliseconds(200)),
                [MirAnimation.Die] = new Frame(320, 9, 0, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(328, 1, 0, TimeSpan.FromMilliseconds(500)),
            };
            SamaCursedBladesman = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Combat1] = new Frame(160, 9, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Struck] = new Frame(240, 3, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Die] = new Frame(320, 7, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(326, 1, 10, TimeSpan.FromMilliseconds(500)),
            };
            SamaCursedSlave = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Combat1] = new Frame(160, 8, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Struck] = new Frame(240, 3, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Die] = new Frame(320, 7, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(326, 1, 10, TimeSpan.FromMilliseconds(500)),
            };

            SamaProphet = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(50, 4, 0, TimeSpan.FromMilliseconds(500)),
                [MirAnimation.Combat1] = new Frame(130, 9, 0, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat2] = new Frame(210, 9, 0, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat3] = new Frame(290, 10, 0, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Struck] = new Frame(370, 3, 0, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Die] = new Frame(450, 10, 0, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(459, 1, 10, TimeSpan.FromMilliseconds(500)),
            };
            SamaSorcerer = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Combat1] = new Frame(160, 9, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat2] = new Frame(240, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat3] = new Frame(320, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Struck] = new Frame(400, 3, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Die] = new Frame(480, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(489, 1, 10, TimeSpan.FromMilliseconds(500)),
            };
            EasterEvent = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Die] = new Frame(320, 6, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(325, 1, 10, TimeSpan.FromMilliseconds(500)),
                [MirAnimation.Show] = new Frame(0, 4, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Hide] = new Frame(0, 4, 10, TimeSpan.FromMilliseconds(100)) { Reversed = true },
                [MirAnimation.StoneStanding] = new Frame(0, 1, 10, TimeSpan.FromMilliseconds(500)),
                [MirAnimation.DragonRepulseStart] = new Frame(0, 4, 10, TimeSpan.FromMilliseconds(100)), 
                [MirAnimation.DragonRepulseMiddle] = new Frame(0, 4, 10, TimeSpan.FromMilliseconds(1000)), 
                [MirAnimation.DragonRepulseEnd] = new Frame(0, 4, 10, TimeSpan.FromMilliseconds(100)), 
            };

            OrangeTiger = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Walking] = new Frame(80, 8, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Pushed] = new Frame(80, 8, 10, TimeSpan.FromMilliseconds(50)) { Reversed = true, StaticSpeed = true },
                [MirAnimation.Die] = new Frame(320, 6, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(325, 1, 10, TimeSpan.FromMilliseconds(500)),
            };

            RedTiger = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Walking] = new Frame(80, 8, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Pushed] = new Frame(80, 8, 10, TimeSpan.FromMilliseconds(50)) { Reversed = true, StaticSpeed = true },
                [MirAnimation.Die] = new Frame(320, 6, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(325, 1, 10, TimeSpan.FromMilliseconds(500)),
                [MirAnimation.Combat2] = new Frame(400, 6, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat3] = new Frame(400, 6, 10, TimeSpan.FromMilliseconds(100)),
            };

            OrangeBossTiger = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 6, 0, TimeSpan.FromMilliseconds(500)),
                [MirAnimation.Walking] = new Frame(80, 8, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Pushed] = new Frame(80, 8, 10, TimeSpan.FromMilliseconds(50)) { Reversed = true, StaticSpeed = true },
                [MirAnimation.Combat1] = new Frame(160, 8, 10, TimeSpan.FromMilliseconds(100)),
                
                [MirAnimation.Struck] = new Frame(320, 3, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat2] = new Frame(400, 7, 10, TimeSpan.FromMilliseconds(100)), 
                [MirAnimation.Combat3] = new Frame(400, 7, 10, TimeSpan.FromMilliseconds(100)),

                [MirAnimation.Die] = new Frame(400, 7, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(406, 1, 10, TimeSpan.FromMilliseconds(500)),
            };

            BigBossTiger = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 6, 0, TimeSpan.FromMilliseconds(500)),

                [MirAnimation.Walking] = new Frame(80, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Pushed] = new Frame(80, 10, 10, TimeSpan.FromMilliseconds(50)) { Reversed = true, StaticSpeed = true },

                [MirAnimation.Combat1] = new Frame(160, 10, 10, TimeSpan.FromMilliseconds(100)),
                
                [MirAnimation.Struck] = new Frame(240, 2, 10, TimeSpan.FromMilliseconds(100)),

                [MirAnimation.Die] = new Frame(320, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(329, 1, 10, TimeSpan.FromMilliseconds(500)),

                [MirAnimation.Combat2] = new Frame(400, 7, 10, TimeSpan.FromMilliseconds(100)), 

                [MirAnimation.Combat3] = new Frame(480, 6, 10, TimeSpan.FromMilliseconds(100)),

                [MirAnimation.Combat4] = new Frame(560, 10, 10, TimeSpan.FromMilliseconds(100)),

            };

            SDMob3 = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Show] = new Frame(640, 10, 10, TimeSpan.FromMilliseconds(100)) { Reversed = true },
                [MirAnimation.Hide] = new Frame(640, 10, 10, TimeSpan.FromMilliseconds(100)) ,
            };

            SDMob8 = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Combat2] = new Frame(480, 6, 10, TimeSpan.FromMilliseconds(100)),
            };

            SDMob15 = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 7, 10, TimeSpan.FromMilliseconds(500)),
                
                [MirAnimation.Combat1] = new Frame(160, 8, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat2] = new Frame(240, 6, 10, TimeSpan.FromMilliseconds(100)),

                [MirAnimation.Struck] = new Frame(320, 4, 10, TimeSpan.FromMilliseconds(100)),

                [MirAnimation.Die] = new Frame(400, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(409, 1, 10, TimeSpan.FromMilliseconds(500)),
            };

            SDMob16 = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 7, 10, TimeSpan.FromMilliseconds(100)),

                [MirAnimation.Walking] = new Frame(80, 7, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Pushed] = new Frame(80, 7, 10, TimeSpan.FromMilliseconds(50)) { Reversed = true, StaticSpeed = true },

                [MirAnimation.Combat1] = new Frame(160, 8, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat2] = new Frame(240, 9, 10, TimeSpan.FromMilliseconds(100)), 

                [MirAnimation.Struck] = new Frame(320, 3, 10, TimeSpan.FromMilliseconds(100)),

                [MirAnimation.Die] = new Frame(400, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(409, 1, 10, TimeSpan.FromMilliseconds(500)),
            };
            SDMob17 = new Dictionary<MirAnimation, Frame>
            {

                [MirAnimation.Combat1] = new Frame(160, 9, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat1] = new Frame(240, 9, 10, TimeSpan.FromMilliseconds(100)),

                [MirAnimation.Struck] = new Frame(320, 3, 10, TimeSpan.FromMilliseconds(100)),

                [MirAnimation.Die] = new Frame(400, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(409, 1, 10, TimeSpan.FromMilliseconds(500)),
            };

            SDMob18 = new Dictionary<MirAnimation, Frame>
            {

                [MirAnimation.Combat1] = new Frame(160, 10, 10, TimeSpan.FromMilliseconds(100)),

                [MirAnimation.Struck] = new Frame(240, 3, 10, TimeSpan.FromMilliseconds(100)),

                [MirAnimation.Die] = new Frame(320, 9, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(328, 1, 10, TimeSpan.FromMilliseconds(500)),
            };

            SDMob19 = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 6, 10, TimeSpan.FromMilliseconds(500)),

                [MirAnimation.Combat1] = new Frame(160, 9, 10, TimeSpan.FromMilliseconds(100)),

                [MirAnimation.Struck] = new Frame(240, 3, 10, TimeSpan.FromMilliseconds(100)),

                [MirAnimation.Die] = new Frame(320, 7, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(326, 1, 10, TimeSpan.FromMilliseconds(500)),

                
                
            };

            SDMob21 = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 6, 10, TimeSpan.FromMilliseconds(500)),

                [MirAnimation.Combat1] = new Frame(160, 10, 10, TimeSpan.FromMilliseconds(100)),

                [MirAnimation.Struck] = new Frame(240, 3, 10, TimeSpan.FromMilliseconds(100)),

                [MirAnimation.Die] = new Frame(320, 7, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(326, 1, 10, TimeSpan.FromMilliseconds(500)),

                
                
            };

            SDMob22 = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 6, 10, TimeSpan.FromMilliseconds(500)),

                [MirAnimation.Combat1] = new Frame(400, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat2] = new Frame(400, 10, 10, TimeSpan.FromMilliseconds(100)),

                [MirAnimation.Struck] = new Frame(240, 3, 10, TimeSpan.FromMilliseconds(100)),

                [MirAnimation.Die] = new Frame(320, 6, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(325, 1, 10, TimeSpan.FromMilliseconds(500)),

                
                
            };
            SDMob23 = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 10, 10, TimeSpan.FromMilliseconds(500)),

                [MirAnimation.Walking] = new Frame(80, 8, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Pushed] = new Frame(80, 8, 10, TimeSpan.FromMilliseconds(50)) { Reversed = true, StaticSpeed = true },

                [MirAnimation.Combat1] = new Frame(160, 10, 10, TimeSpan.FromMilliseconds(70)),

                [MirAnimation.Struck] = new Frame(240, 3, 10, TimeSpan.FromMilliseconds(100)),

                [MirAnimation.Die] = new Frame(320, 8, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(327, 1, 10, TimeSpan.FromMilliseconds(500)),

                
                
            };

            SDMob24 = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 7, 10, TimeSpan.FromMilliseconds(500)),

                [MirAnimation.Walking] = new Frame(80, 8, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Pushed] = new Frame(80, 8, 10, TimeSpan.FromMilliseconds(50)) { Reversed = true, StaticSpeed = true },

                [MirAnimation.Combat1] = new Frame(160, 9, 10, TimeSpan.FromMilliseconds(70)),

                [MirAnimation.Struck] = new Frame(240, 3, 10, TimeSpan.FromMilliseconds(100)),

                [MirAnimation.Combat2] = new Frame(400, 9, 10, TimeSpan.FromMilliseconds(70)),
            };

            SDMob25 = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 7, 10, TimeSpan.FromMilliseconds(500)),

                [MirAnimation.Walking] = new Frame(80, 8, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Pushed] = new Frame(80, 8, 10, TimeSpan.FromMilliseconds(50)) { Reversed = true, StaticSpeed = true },

                [MirAnimation.Combat1] = new Frame(160, 8, 10, TimeSpan.FromMilliseconds(70)),

                [MirAnimation.Struck] = new Frame(240, 3, 10, TimeSpan.FromMilliseconds(100)),

                [MirAnimation.Combat2] = new Frame(400, 10, 10, TimeSpan.FromMilliseconds(70)),
            };

            SDMob26 = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 7, 10, TimeSpan.FromMilliseconds(500)),

                [MirAnimation.Walking] = new Frame(80, 8, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Pushed] = new Frame(80, 8, 10, TimeSpan.FromMilliseconds(50)) { Reversed = true, StaticSpeed = true },

                [MirAnimation.Combat1] = new Frame(160, 10, 10, TimeSpan.FromMilliseconds(70)),

                [MirAnimation.Struck] = new Frame(240, 4, 10, TimeSpan.FromMilliseconds(100)),

                [MirAnimation.Combat2] = new Frame(400, 8, 10, TimeSpan.FromMilliseconds(70)),

                [MirAnimation.Die] = new Frame(320, 7, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(326, 1, 10, TimeSpan.FromMilliseconds(500)),
            };

            LobsterLord = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(20, 6, 0, TimeSpan.FromMilliseconds(500)),

                [MirAnimation.Combat1] = new Frame(30, 7, 0, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat2] = new Frame(40, 7, 0, TimeSpan.FromMilliseconds(100)), 
                [MirAnimation.Combat3] = new Frame(60, 7, 0, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat4] = new Frame(70, 7, 0, TimeSpan.FromMilliseconds(100)), 
                [MirAnimation.Combat5] = new Frame(80, 7, 0, TimeSpan.FromMilliseconds(100)), 
                [MirAnimation.Combat6] = new Frame(110, 8, 0, TimeSpan.FromMilliseconds(100)), 
                [MirAnimation.Combat7] = new Frame(120, 4, 0, TimeSpan.FromMilliseconds(100)), 

                [MirAnimation.Struck] = new Frame(50, 4, 0, TimeSpan.FromMilliseconds(100)),
                
                [MirAnimation.Die] = new Frame(130, 9, 0, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(138, 1, 0, TimeSpan.FromMilliseconds(500)),
            };

            JinamStoneGate = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 1, 0, TimeSpan.FromMilliseconds(200)),
            };


            DeadTree = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 1, 0, TimeSpan.FromMilliseconds(200)),
                [MirAnimation.Struck] = new Frame(0, 1, 0, TimeSpan.FromMilliseconds(200)),
                [MirAnimation.Die] = new Frame(0, 1, 0, TimeSpan.FromMilliseconds(200)),
                [MirAnimation.Dead] = new Frame(0, 1, 0, TimeSpan.FromMilliseconds(200)),
            };

            MonasteryMon1 = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 15, 20, TimeSpan.FromMilliseconds(500)),
                [MirAnimation.Walking] = new Frame(160, 7, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Pushed] = new Frame(160, 7, 10, TimeSpan.FromMilliseconds(50)) { Reversed = true, StaticSpeed = true },
                [MirAnimation.Combat1] = new Frame(240, 9, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat2] = new Frame(320, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat3] = new Frame(320, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Struck] = new Frame(400, 4, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Die] = new Frame(480, 9, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(488, 1, 10, TimeSpan.FromMilliseconds(1000)),
            };
            MonasteryMon3 = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 15, 20, TimeSpan.FromMilliseconds(500)),
                [MirAnimation.Walking] = new Frame(160, 7, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Pushed] = new Frame(160, 7, 10, TimeSpan.FromMilliseconds(50)) { Reversed = true, StaticSpeed = true },
                [MirAnimation.Combat1] = new Frame(240, 9, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat2] = new Frame(320, 9, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat3] = new Frame(400, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Struck] = new Frame(480, 4, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Die] = new Frame(560, 9, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(568, 1, 10, TimeSpan.FromMilliseconds(1000)),
            };

            yaotaStoneGate = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 1, 0, TimeSpan.FromMilliseconds(200)),
            };
            MotaStoneGate = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 1, 0, TimeSpan.FromMilliseconds(200)),
            };
            Huodong01StoneGate = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 1, 0, TimeSpan.FromMilliseconds(200)),
            };
            Huodong02StoneGate = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 1, 0, TimeSpan.FromMilliseconds(200)),
            };
            Huodong03StoneGate = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 1, 0, TimeSpan.FromMilliseconds(200)),
            };
            Huodong04StoneGate = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 1, 0, TimeSpan.FromMilliseconds(200)),
            };
            Huodong05StoneGate = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 1, 0, TimeSpan.FromMilliseconds(200)),
            };
            Huodong06StoneGate = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 1, 0, TimeSpan.FromMilliseconds(200)),
            };
            Huodong07StoneGate = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 1, 0, TimeSpan.FromMilliseconds(200)),
            };
            Huodong08StoneGate = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 1, 0, TimeSpan.FromMilliseconds(200)),
            };
            Huodong09StoneGate = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 1, 0, TimeSpan.FromMilliseconds(200)),
            };
            Huodong10StoneGate = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 1, 0, TimeSpan.FromMilliseconds(200)),
            };
            Huodong11StoneGate = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 1, 0, TimeSpan.FromMilliseconds(200)),
            };
            Huodong12StoneGate = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 1, 0, TimeSpan.FromMilliseconds(200)),
            };

            BobbitWorm = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Show] = new Frame(400, 7, 10, TimeSpan.FromMilliseconds(100)) ,
                [MirAnimation.Hide] = new Frame(400, 7, 10, TimeSpan.FromMilliseconds(100)) { Reversed = true, },
            };
            
            GuildFbBoss = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Combat2] = new Frame(400, 9, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat3] = new Frame(400, 9, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Die] = new Frame(320, 7, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(326, 1, 10, TimeSpan.FromMilliseconds(500)),
            };
            FrameSet.SDMob27 = new Dictionary<MirAnimation, Frame>()
            {
                [MirAnimation.StoneStanding] = new Frame(0, 1, 10, TimeSpan.FromMilliseconds(500.0)),
                [MirAnimation.Show] = new Frame(80, 10, 10, TimeSpan.FromMilliseconds(200.0)),
                [MirAnimation.Walking] = new Frame(240, 8, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Combat1] = new Frame(320, 9, 10, TimeSpan.FromMilliseconds(70.0)),
                [MirAnimation.Combat2] = new Frame(400, 10, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Pushed] = new Frame(480, 3, 10, TimeSpan.FromMilliseconds(50.0))
                {
                    Reversed = true,
                    StaticSpeed = true
                },
                [MirAnimation.Struck] = new Frame(240, 4, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Die] = new Frame(560, 10, 20, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Dead] = new Frame(713, 1, 10, TimeSpan.FromMilliseconds(1000.0))
            };
            FrameSet.SDMob28 = new Dictionary<MirAnimation, Frame>()
            {
                [MirAnimation.Die] = new Frame(480, 10, 10, TimeSpan.FromMilliseconds(200.0)),
                [MirAnimation.Dead] = new Frame(560, 1, 10, TimeSpan.FromMilliseconds(1000.0))
            };
            FrameSet.SDMob29 = new Dictionary<MirAnimation, Frame>()
            {
                [MirAnimation.Show] = new Frame(0, 13, 20, TimeSpan.FromMilliseconds(500.0)),
                [MirAnimation.Standing] = new Frame(160, 4, 10, TimeSpan.FromMilliseconds(500.0)),
                [MirAnimation.Walking] = new Frame(240, 6, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Combat1] = new Frame(320, 8, 10, TimeSpan.FromMilliseconds(70.0)),
                [MirAnimation.Pushed] = new Frame(400, 3, 10, TimeSpan.FromMilliseconds(50.0))
                {
                    Reversed = true,
                    StaticSpeed = true
                },
                [MirAnimation.Die] = new Frame(480, 11, 20, TimeSpan.FromMilliseconds(200.0)),
                [MirAnimation.Dead] = new Frame(560, 1, 10, TimeSpan.FromMilliseconds(1000.0))
            };
            FrameSet.CrazedPrimate = new Dictionary<MirAnimation, Frame>()
            {
                [MirAnimation.Standing] = new Frame(0, 6, 10, TimeSpan.FromMilliseconds(500.0)),
                [MirAnimation.Combat1] = new Frame(160, 7, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Combat3] = new Frame(400, 8, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Struck] = new Frame(240, 3, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Die] = new Frame(320, 8, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Dead] = new Frame(327, 1, 10, TimeSpan.FromMilliseconds(1000.0))
            };
            FrameSet.HellBringer = new Dictionary<MirAnimation, Frame>()
            {
                [MirAnimation.Standing] = new Frame(0, 6, 10, TimeSpan.FromMilliseconds(500.0)),
                [MirAnimation.Walking] = new Frame(80, 8, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Pushed] = new Frame(80, 8, 10, TimeSpan.FromMilliseconds(50.0))
                {
                    Reversed = true,
                    StaticSpeed = true
                },
                [MirAnimation.Combat1] = new Frame(160, 10, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Combat2] = new Frame(480, 8, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Combat3] = new Frame(400, 10, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Combat4] = new Frame(560, 8, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Struck] = new Frame(240, 4, 10, TimeSpan.FromMilliseconds(100.0))
            };
            FrameSet.YurinMon0 = new Dictionary<MirAnimation, Frame>()
            {
                [MirAnimation.Combat1] = new Frame(160, 8, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Struck] = new Frame(240, 3, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Die] = new Frame(320, 9, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Dead] = new Frame(328, 1, 10, TimeSpan.FromMilliseconds(1000.0))
            };
            FrameSet.YurinMon1 = new Dictionary<MirAnimation, Frame>()
            {
                [MirAnimation.Combat1] = new Frame(160, 9, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Combat3] = new Frame(400, 10, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Struck] = new Frame(240, 3, 10, TimeSpan.FromMilliseconds(100.0))
            };
            Horses = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(400, 6, 10, TimeSpan.FromMilliseconds(150.0))
            };
            FrameSet.WhiteBeardedTiger = new Dictionary<MirAnimation, Frame>()
            {
                [MirAnimation.Standing] = new Frame(0, 6, 10, TimeSpan.FromMilliseconds(500.0)),
                [MirAnimation.Combat1] = new Frame(160, 7, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Combat3] = new Frame(400, 6, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Struck] = new Frame(240, 3, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Die] = new Frame(320, 9, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Dead] = new Frame(328, 1, 10, TimeSpan.FromMilliseconds(1000.0))
            };
            FrameSet.HardenedRhino = new Dictionary<MirAnimation, Frame>()
            {
                [MirAnimation.Standing] = new Frame(0, 6, 10, TimeSpan.FromMilliseconds(500.0)),
                [MirAnimation.Walking] = new Frame(80, 10, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Pushed] = new Frame(80, 10, 10, TimeSpan.FromMilliseconds(50.0))
                {
                    Reversed = true,
                    StaticSpeed = true
                },
                [MirAnimation.Combat1] = new Frame(160, 7, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Combat2] = new Frame(400, 6, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Combat3] = new Frame(480, 7, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Struck] = new Frame(240, 3, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Die] = new Frame(320, 7, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Dead] = new Frame(326, 1, 10, TimeSpan.FromMilliseconds(1000.0))
            };
            FrameSet.Mammoth = new Dictionary<MirAnimation, Frame>()
            {
                [MirAnimation.Standing] = new Frame(0, 6, 10, TimeSpan.FromMilliseconds(500.0)),
                [MirAnimation.Walking] = new Frame(80, 10, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Pushed] = new Frame(80, 10, 10, TimeSpan.FromMilliseconds(50.0))
                {
                    Reversed = true,
                    StaticSpeed = true
                },
                [MirAnimation.Combat2] = new Frame(400, 6, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Combat3] = new Frame(480, 6, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Struck] = new Frame(240, 3, 10, TimeSpan.FromMilliseconds(100.0))
            };
            FrameSet.CursedSlave1 = new Dictionary<MirAnimation, Frame>()
            {
                [MirAnimation.Walking] = new Frame(80, 8, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Pushed] = new Frame(80, 8, 10, TimeSpan.FromMilliseconds(50.0))
                {
                    Reversed = true,
                    StaticSpeed = true
                },
                [MirAnimation.Combat1] = new Frame(160, 7, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Combat3] = new Frame(400, 8, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Struck] = new Frame(240, 3, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Die] = new Frame(320, 9, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Dead] = new Frame(328, 1, 10, TimeSpan.FromMilliseconds(1000.0))
            };
            FrameSet.CursedSlave2 = new Dictionary<MirAnimation, Frame>()
            {
                [MirAnimation.Walking] = new Frame(80, 8, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Pushed] = new Frame(80, 8, 10, TimeSpan.FromMilliseconds(50.0))
                {
                    Reversed = true,
                    StaticSpeed = true
                },
                [MirAnimation.Combat1] = new Frame(160, 7, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Combat2] = new Frame(400, 7, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Struck] = new Frame(240, 3, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Die] = new Frame(320, 9, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Dead] = new Frame(328, 1, 10, TimeSpan.FromMilliseconds(1000.0))
            };
            FrameSet.CursedSlave3 = new Dictionary<MirAnimation, Frame>()
            {
                [MirAnimation.Walking] = new Frame(80, 8, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Pushed] = new Frame(80, 8, 10, TimeSpan.FromMilliseconds(50.0))
                {
                    Reversed = true,
                    StaticSpeed = true
                },
                [MirAnimation.Combat1] = new Frame(160, 9, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Combat2] = new Frame(400, 8, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Struck] = new Frame(240, 3, 10, TimeSpan.FromMilliseconds(100.0))
            };
            FrameSet.PoisonousGolem = new Dictionary<MirAnimation, Frame>()
            {
                [MirAnimation.Standing] = new Frame(0, 6, 10, TimeSpan.FromMilliseconds(500.0)),
                [MirAnimation.Walking] = new Frame(80, 10, 10, TimeSpan.FromMilliseconds(80.0)),
                [MirAnimation.Pushed] = new Frame(80, 10, 10, TimeSpan.FromMilliseconds(50.0))
                {
                    Reversed = true,
                    StaticSpeed = true
                },
                [MirAnimation.Combat3] = new Frame(400, 7, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Struck] = new Frame(240, 3, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Die] = new Frame(320, 7, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Dead] = new Frame(326, 1, 10, TimeSpan.FromMilliseconds(1000.0))
            };

            GardenSoldier = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 10, 10, TimeSpan.FromMilliseconds(500)),
                [MirAnimation.Combat1] = new Frame(160, 7, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat2] = new Frame(240, 9, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Struck] = new Frame(400, 3, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Die] = new Frame(480, 9, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(488, 1, 10, TimeSpan.FromMilliseconds(1000)),
            };
            GardenDefender = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 9, 10, TimeSpan.FromMilliseconds(500)),
                [MirAnimation.Combat1] = new Frame(160, 7, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat2] = new Frame(240, 8, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Struck] = new Frame(320, 3, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Die] = new Frame(400, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(409, 1, 10, TimeSpan.FromMilliseconds(1000)),
            };
            RedBlossom = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 10, 10, TimeSpan.FromMilliseconds(500)),
                [MirAnimation.Combat1] = new Frame(160, 9, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat2] = new Frame(240, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Struck] = new Frame(320, 3, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Die] = new Frame(400, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(409, 1, 10, TimeSpan.FromMilliseconds(1000)),
            };
            BlueBlossom = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 10, 10, TimeSpan.FromMilliseconds(500)),
                [MirAnimation.Combat2] = new Frame(160, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Struck] = new Frame(240, 3, 10, TimeSpan.FromMilliseconds(100)),
            };
            FireBird = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Standing] = new Frame(0, 8, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat1] = new Frame(160, 7, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat2] = new Frame(320, 5, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat3] = new Frame(240, 5, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Combat4] = new Frame(400, 8, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Struck] = new Frame(480, 3, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Die] = new Frame(560, 10, 10, TimeSpan.FromMilliseconds(100)),
                [MirAnimation.Dead] = new Frame(569, 1, 10, TimeSpan.FromMilliseconds(1000)),
            };

            FrameSet.WolongBianfu02 = new Dictionary<MirAnimation, Frame>()
            {
                [MirAnimation.Standing] = new Frame(0, 4, 10, TimeSpan.FromMilliseconds(300.0)),
                [MirAnimation.Walking] = new Frame(80, 6, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Pushed] = new Frame(80, 6, 10, TimeSpan.FromMilliseconds(50.0))
                {
                    Reversed = true,
                    StaticSpeed = true
                },
                [MirAnimation.Combat3] = new Frame(240, 5, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Struck] = new Frame(320, 3, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Die] = new Frame(400, 8, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Dead] = new Frame(407, 1, 10, TimeSpan.FromMilliseconds(1000.0))
            };
            
            FrameSet.Hd1 = new Dictionary<MirAnimation, Frame>()
            {
                [MirAnimation.Standing] = new Frame(0, 6, 10, TimeSpan.FromMilliseconds(500.0)),
                [MirAnimation.Walking] = new Frame(80, 6, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Pushed] = new Frame(80, 6, 10, TimeSpan.FromMilliseconds(50.0))
                {
                    Reversed = true,
                    StaticSpeed = true
                },
                [MirAnimation.Combat1] = new Frame(160, 6, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Combat2] = new Frame(400, 7, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Combat3] = new Frame(480, 8, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Struck] = new Frame(240, 3, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Die] = new Frame(320, 9, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Dead] = new Frame(328, 1, 10, TimeSpan.FromMilliseconds(100.0))
            };
            
            FrameSet.Hd2 = new Dictionary<MirAnimation, Frame>()
            {
                [MirAnimation.Standing] = new Frame(0, 6, 10, TimeSpan.FromMilliseconds(500.0)),
                [MirAnimation.Walking] = new Frame(80, 6, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Pushed] = new Frame(80, 6, 10, TimeSpan.FromMilliseconds(50.0))
                {
                    Reversed = true,
                    StaticSpeed = true
                },
                [MirAnimation.Combat1] = new Frame(160, 6, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Combat2] = new Frame(400, 7, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Struck] = new Frame(240, 3, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Die] = new Frame(320, 9, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Dead] = new Frame(328, 1, 10, TimeSpan.FromMilliseconds(100.0))
            };
            
            FubenShiwang = new Dictionary<MirAnimation, Frame>
            {
                [MirAnimation.Walking] = new Frame(80, 8, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Combat2] = new Frame(160, 7, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Struck] = new Frame(240, 2, 2, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Die] = new Frame(260, 4, 10, TimeSpan.FromMilliseconds(100.0)),
                [MirAnimation.Dead] = new Frame(263, 1, 10, TimeSpan.FromMilliseconds(100.0)),
            };
        }
    }


    public sealed class Frame
    {
        public static Frame EmptyFrame = new Frame(0, 0, 0, TimeSpan.Zero);

        public int StartIndex;
        public int FrameCount;
        public int OffSet;

        
        
        
        public int RepeatTimes = 1;
        
        
        
        public bool Reversed;
        
        
        
        public bool StaticSpeed;
        
        
        
        public TimeSpan[] Delays; 


        public Frame(int startIndex, int frameCount, int offSet, TimeSpan frameDelay, int repeatTimes = 1)
        {
            StartIndex = startIndex;
            FrameCount = frameCount * RepeatTimes;
            OffSet = offSet;
            
            RepeatTimes = repeatTimes;

            Delays = new TimeSpan[FrameCount];
            for (int i = 0; i < Delays.Length; i++)
                Delays[i] = frameDelay;
        }
        public Frame(Frame frame)
        {
            StartIndex = frame.StartIndex;
            FrameCount = frame.FrameCount;
            OffSet = frame.OffSet;

            
            RepeatTimes = frame.RepeatTimes;

            Delays = new TimeSpan[FrameCount];
            for (int i = 0; i < Delays.Length; i++)
                Delays[i] = frame.Delays[i];
        }
        public int GetFrame(DateTime start, DateTime now, bool doubleSpeed)
        {
            TimeSpan enlapsed = now - start;

            if (doubleSpeed && !StaticSpeed)
                enlapsed += enlapsed;


            if (Reversed)
            {
                for (int i = 0; i < Delays.Length; i++)
                {
                    enlapsed -= Delays[Delays.Length - 1 - i];
                    if (enlapsed >= TimeSpan.Zero) continue;

                    return i;
                }
            }
            else
            {
                for (int i = 0; i < Delays.Length; i++)
                {
                    enlapsed -= Delays[i];
                    if (enlapsed >= TimeSpan.Zero) continue;

                    return i;
                }
            }


            return FrameCount;
        }
    }
}
