using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Controls;
using Client.Envir;
using Client.Scenes;
using Client.Scenes.Views;
using Library;
using Library.SystemModels;
using SlimDX;
using SlimDX.Direct3D9;
using Frame = Library.Frame;

namespace Client.Models
{
    public abstract class MapObject
    {
        public static SortedDictionary<string, List<DXLabel>> NameLabels = new SortedDictionary<string, List<DXLabel>>();
        public static List<DXLabel> ChatLabels = new List<DXLabel>();

        public static UserObject User => GameScene.Game.User;

        
        public int Mingwen01, Mingwen02, Mingwen03;

        public int Huiyuan;

        public static MapObject MouseObject
        {
            get { return GameScene.Game.MouseObject; }
            set
            {
                if (GameScene.Game.MouseObject == value) return;

                GameScene.Game.MouseObject = value;
                
                GameScene.Game.MapControl.TextureValid = false;
            }
        }
        public static MapObject TargetObject
        {
            get { return GameScene.Game.TargetObject; }
            set
            {
                if (GameScene.Game.TargetObject == value) return;

                GameScene.Game.TargetObject = value;
                
                GameScene.Game.MapControl.TextureValid = false;
            }
        }
        public static MapObject MagicObject
        {
            get { return GameScene.Game.MagicObject; }
            set
            {
                if (GameScene.Game.MagicObject == value) return;

                GameScene.Game.MagicObject = value;
                
                GameScene.Game.MapControl.TextureValid = false;
            }
        }

        public static Texture ShadowTexture;

        public abstract ObjectType Race { get; }
        public virtual bool Blocking => Visible && !Dead;
        public bool Visible = true;

        public uint ObjectID;

        public virtual int Level { get; set; }
        public virtual int CurrentHP { get; set; }
        public virtual int CurrentMP { get; set; }

        
        public virtual int Jyhuishoulevel { get; set; }

        public uint AttackerID;

        public MagicType MagicType;
        public Element AttackElement;
        public List<MapObject> AttackTargets;
        public List<Point> MagicLocations;
        public bool MagicCast;
        public MirGender Gender;
        public bool MiningEffect;
        public ObjectType mo;

        public Point CurrentLocation
        {
            get { return _CurrentLocation; }
            set
            {
                if (_CurrentLocation == value) return;

                _CurrentLocation = value;

                LocationChanged();
            }
        }
        private Point _CurrentLocation;
        public Cell CurrentCell;

        public MirDirection Direction;

        public virtual string Name
        {
            get { return _Name; }
            set
            {
                if (_Name == value) return;
                
                _Name = value;

                NameChanged();
            }
        }
        private string _Name;

        public virtual string Title
        {
            get { return _Title; }
            set
            {
                if (_Title == value) return;

                _Title = value;

                NameChanged();
            }
        }
        private string _Title;

        public string PetOwner
        {
            get { return _PetOwner; }
            set
            {
                if (_PetOwner == value) return;

                _PetOwner = value;

                NameChanged();
            }
        }
        private string _PetOwner;


        public Color NameColour
        {
            get
            {
                if (gameTeam == 1)
                {
                    return Color.Crimson;
                }
                if (gameTeam == 2)
                {
                    return Color.Navy;
                }
                if (Race != ObjectType.Player) return _NameColour;
                
                foreach (CastleInfo castle in GameScene.Game.ConquestWars)
                {
                    if (castle.Map != GameScene.Game.MapControl.MapInfo) continue;

                    if (User.Title == Title) return Color.DarkCyan;

                    return Color.OrangeRed;
                }

                if (GameScene.Game.GuildWars.Count == 0) return _NameColour;

                if (User.Title == Title) return Color.DarkCyan;
                
                if (GameScene.Game.GuildWars.Contains(Title)) return Color.OrangeRed;

                return _NameColour;
            }
            set
            {
                if (_NameColour == value) return;
                
                _NameColour = value;

                NameChanged();
            }
        }
        private Color _NameColour;
        
        public DateTime ChatTime;
        public DXLabel NameLabel, ChatLabel, TitleNameLabel;
        public List<DamageInfo> DamageList = new List<DamageInfo>();
        public List<MirEffect> Effects = new List<MirEffect>();

        public List<BuffType> VisibleBuffs = new List<BuffType>();
        public PoisonType Poison;

        public int MoveDistance;
        public int DrawFrame
        {
            get { return _DrawFrame; }
            set
            {
                if (_DrawFrame == value) return;
                
                _DrawFrame = value;
                DrawFrameChanged();
            }
        }
        private int _DrawFrame;

        public int FrameIndex
        {
            get { return _FrameIndex; }
            set
            {
                if (_FrameIndex == value) return;
                
                _FrameIndex = value;
                FrameIndexChanged();
            }
        }
        private int _FrameIndex;
        
        public int DrawX;
        public int DrawY;

        public DateTime DrawHealthTime, StanceTime;
        
        private Point _MovingOffSet;
        public Point MovingOffSet
        {
            get
            {
                return _MovingOffSet;
            }
            set
            {
                if (_MovingOffSet == value) return;

                _MovingOffSet = value;
                MovingOffSetChanged();
            }
        }

        public int Light;
        public float Opacity = 1F;
        public Color LightColour = CartoonGlobals.NoneColour;

        public MirEffect MagicShieldEffect, WraithGripEffect, WraithGripEffect2, AssaultEffect, CelestialLightEffect, LifeStealEffect, SilenceEffect, BlindEffect, AbyssEffect, DragonRepulseEffect, DragonRepulseEffect1, DragonRepulseEffect2, DragonRepulseEffect3, DragonRepulseEffect4, ChannellingMagicEffect, ChannellingMagicEffect1,
                         RankingEffect, DeveloperEffect, FrostBiteEffect, InfectionEffect, NeutralizeEffect, FlameEffect, ThunderEffect, MoveSpeedEffect, QingtongEffect, BaiyinEffect, HuangjinEffect, GonghuiquanEffect;

        
        
        public MirEffect ChongzhuangYinEffect;

        public bool CanShowWraithGrip = true;


        public bool Skeleton;

        public bool Dead
        {
            get { return _Dead; }
            set
            {
                if (_Dead == value) return;
                
                _Dead = value;

                DeadChanged();
            }
        }
        private bool _Dead;

        public virtual Stats Stats { get; set; }

        public int gameTeam
        {
            get;
            set;
        }

        public bool Interupt;
        public MirAction CurrentAction;
        public MirAnimation CurrentAnimation;
        public Frame CurrentFrame;
        public DateTime FrameStart;
        public Dictionary<MirAnimation, Frame> Frames;
        public Color DrawColour;
        public int MaximumSuperiorMagicShield;

        public Color DefaultColour = Color.White;

        public virtual int RenderY
        {
            get
            {
                if (MovingOffSet.IsEmpty)
                    return CurrentLocation.Y;

                switch (Direction)
                {
                    case MirDirection.Up:
                    case MirDirection.UpRight:
                    case MirDirection.UpLeft:
                        return CurrentLocation.Y + MoveDistance;
                    default:
                        return CurrentLocation.Y;
                }
            }

        }
        
        public static int CellWidth => MapControl.CellWidth;
        public static int CellHeight => MapControl.CellHeight;
        public static int OffSetX => MapControl.OffSetX;
        public static int OffSetY => MapControl.OffSetY;

        public List<ObjectAction> ActionQueue = new List<ObjectAction>();

        
        public virtual void Process()
        {
            DamageInfo previous = null;
            for (int index = 0; index < DamageList.Count; index++)
            {
                DamageInfo damageInfo = DamageList[index];
                if (DamageList.Count - index > 3 && CEnvir.Now - damageInfo.StartTime > damageInfo.AppearDelay && CEnvir.Now - damageInfo.StartTime < damageInfo.AppearDelay + damageInfo.ShowDelay)
                    damageInfo.StartTime = CEnvir.Now - damageInfo.AppearDelay - damageInfo.ShowDelay;


                damageInfo.Process(previous);

                previous = damageInfo;
            }

            for (int i = DamageList.Count - 1; i >= 0; i--)
            {
                if (!DamageList[i].Visible)
                    DamageList.RemoveAt(i);
            }
            UpdateFrame();

            DrawX = CurrentLocation.X - User.CurrentLocation.X + MapControl.OffSetX;
            DrawY = CurrentLocation.Y - User.CurrentLocation.Y + MapControl.OffSetY;

            DrawX *= MapControl.CellWidth;
            DrawY *= MapControl.CellHeight;
            

            if (this != User)
            {
                DrawX += MovingOffSet.X - User.MovingOffSet.X - User.ShakeScreenOffset.X;
                DrawY += MovingOffSet.Y - User.MovingOffSet.Y - User.ShakeScreenOffset.Y;
            }

            DrawColour = DefaultColour;

            if ((Poison & PoisonType.Red) == PoisonType.Red)
                DrawColour = Color.IndianRed;
            
            if ((Poison & PoisonType.Green) == PoisonType.Green)
                DrawColour = Color.SeaGreen;
            
            if ((Poison & PoisonType.Slow) == PoisonType.Slow)
                DrawColour = Color.CornflowerBlue;

            if ((Poison & PoisonType.Paralysis) == PoisonType.Paralysis)
                DrawColour = Color.DimGray;
            
            if ((Poison & PoisonType.WraithGrip) == PoisonType.WraithGrip)
            {
                if (CanShowWraithGrip && WraithGripEffect == null)
                    WraithGripCreate();
            }
            else
            {
                if (WraithGripEffect != null)
                    WraithGripEnd();
            }

            if ((Poison & PoisonType.Silenced) == PoisonType.Silenced)
            {
                if (SilenceEffect == null)
                    SilenceCreate();
            }
            else
            {
                if (SilenceEffect != null)
                    SilenceEnd();
            }

            
            if ((Poison & PoisonType.Flamed) == PoisonType.Flamed)
                DrawColour = Color.Gold;

            
            if ((Poison & PoisonType.Flamed) == PoisonType.Flamed)
            {
                if (FlameEffect == null)
                    FlameCreate();
            }
            else
            {
                if (FlameEffect != null)
                    FlameEnd();
            }

            
            if ((Poison & PoisonType.Thunder) == PoisonType.Thunder)
                DrawColour = Color.Plum;

            
            if ((Poison & PoisonType.Thunder) == PoisonType.Thunder)
            {
                if (ThunderEffect == null)
                    ThunderCreate();
            }
            else
            {
                if (ThunderEffect != null)
                    ThunderEnd();
            }

            if ((Poison & PoisonType.Abyss) == PoisonType.Abyss)
            {
                if (BlindEffect == null)
                    BlindCreate();
            }
            else
            {
                if (BlindEffect != null)
                    BlindEnd();
            }

            if ((Poison & PoisonType.Infection) == PoisonType.Infection)
            {
                if (InfectionEffect == null)
                    InfectionCreate();
            }
            else
            {
                if (InfectionEffect != null)
                    InfectionEnd();
            }

            if ((Poison & PoisonType.Neutralize) == PoisonType.Neutralize)
            {
                if (NeutralizeEffect == null)
                    NeutralizeCreate();
            }
            else
            {
                if (NeutralizeEffect != null)
                    NeutralizeEnd();
            }

            if (VisibleBuffs.Contains(BuffType.Invisibility) || VisibleBuffs.Contains(BuffType.Cloak) || VisibleBuffs.Contains(BuffType.Transparency))
                Opacity = 0.5f;
            else
                Opacity = 1f;

            if (VisibleBuffs.Contains(BuffType.MagicShield) || VisibleBuffs.Contains(BuffType.SuperiorMagicShield))
            {
                if (MagicShieldEffect == null)
                    MagicShieldCreate();
            }
            else if (MagicShieldEffect != null)
                MagicShieldEnd();


            /*
            if (VisibleBuffs.Contains(BuffType.Developer))
            {
                if (RankingEffect != null)
                    RankingEnd();

                if (DeveloperEffect == null)
                    DeveloperCreate();
            }
            else
            {
                if (DeveloperEffect != null)
                    DeveloperEnd();

                if (VisibleBuffs.Contains(BuffType.Ranking))
                {
                    if (RankingEffect == null)
                        RankingCreate();
                }
                else if (RankingEffect != null)
                    RankingEnd();
            }
            */

            if (VisibleBuffs.Contains(BuffType.MoveSpeed))
            {
                if (MoveSpeedEffect == null)
                    MoveSpeedCreate();
            }
            else if (MoveSpeedEffect != null)
                MoveSpeedEnd();

            /*
            if (Config.是否显示会员效果)
            {
                if (VisibleBuffs.Contains(BuffType.VipMapY) || Huiyuan == 1)
                {
                    if (BaiyinEffect != null)
                        BaiyinEffectEnd();

                    if (HuangjinEffect != null)
                        HuangjinEffectEnd();

                    if (QingtongEffect == null)
                        QingtongEffectCreate();
                }
                else
                {

                    if (QingtongEffect != null)
                        QingtongEffectEnd();

                    if (VisibleBuffs.Contains(BuffType.VipMapE) || Huiyuan == 2)
                    {
                        if (HuangjinEffect != null)
                            HuangjinEffectEnd();

                        if (BaiyinEffect == null)
                            BaiyinEffectCreate();
                    }
                    else
                    {
                        if (BaiyinEffect != null)
                            BaiyinEffectEnd();

                        if (VisibleBuffs.Contains(BuffType.VipMapS) || Huiyuan == 3)
                        {
                            if (HuangjinEffect == null)
                                HuangjinEffectCreate();
                        }
                        else if (HuangjinEffect != null)
                            HuangjinEffectEnd();

                    }

                }
            }
            */

            if (Config.是否显示会员效果)
            {
                if (VisibleBuffs.Contains(BuffType.VipMapY) || Huiyuan == 1)
                {
                    if (RankingEffect != null)
                        RankingEnd();

                    if (DeveloperEffect != null)
                        DeveloperEnd();

                    if (BaiyinEffect != null)
                        BaiyinEffectEnd();

                    if (HuangjinEffect != null)
                        HuangjinEffectEnd();

                    if (QingtongEffect == null)
                        QingtongEffectCreate();
                }
                else
                {

                    if (QingtongEffect != null)
                        QingtongEffectEnd();

                    if (VisibleBuffs.Contains(BuffType.VipMapE) || Huiyuan == 2)
                    {
                        if (RankingEffect != null)
                            RankingEnd();

                        if (DeveloperEffect != null)
                            DeveloperEnd();

                        if (HuangjinEffect != null)
                            HuangjinEffectEnd();

                        if (BaiyinEffect == null)
                            BaiyinEffectCreate();
                    }
                    else
                    {
                        if (BaiyinEffect != null)
                            BaiyinEffectEnd();

                        if (VisibleBuffs.Contains(BuffType.VipMapS) || Huiyuan == 3)
                        {
                            if (RankingEffect != null)
                                RankingEnd();

                            if (DeveloperEffect != null)
                                DeveloperEnd();

                            if (HuangjinEffect == null)
                                HuangjinEffectCreate();
                        }
                        else
                        {
                            if (HuangjinEffect != null)
                                HuangjinEffectEnd();

                            if (VisibleBuffs.Contains(BuffType.Developer))
                            {
                                if (RankingEffect != null)
                                    RankingEnd();

                                if (DeveloperEffect == null)
                                    DeveloperCreate();
                            }
                            else
                            {
                                if (DeveloperEffect != null)
                                    DeveloperEnd();

                                if (VisibleBuffs.Contains(BuffType.Ranking))
                                {
                                    if (RankingEffect == null)
                                        RankingCreate();
                                }
                                else if (RankingEffect != null)
                                    RankingEnd();
                            }
                        }

                    }

                }
            }


            if (VisibleBuffs.Contains(BuffType.LifeSteal))
            {
                if (LifeStealEffect == null)
                    LifeStealCreate();
            }
            else if (LifeStealEffect != null)
                LifeStealEnd();

            if (VisibleBuffs.Contains(BuffType.CelestialLight))
            {
                if (CelestialLightEffect == null)
                    CelestialLightCreate();
            }
            else if (CelestialLightEffect != null)
                CelestialLightEnd();

            if (VisibleBuffs.Contains(BuffType.FrostBite))
            {
                if (FrostBiteEffect == null)
                    FrostBiteCreate();
            }
            else if (FrostBiteEffect != null)
                FrostBiteEnd();

        }
        public virtual void UpdateFrame()
        {
            if (Frames == null || CurrentFrame == null) return;


            switch (CurrentAction)
            {
                case MirAction.Moving:
                case MirAction.Pushed:
                    if (!GameScene.Game.MoveFrame) return;
                    break;
                case MirAction.Dead:
                    if (Visible && Config.清理尸体)
                    {
                        this.Visible = false;
                        break;
                    }
                    else if (!Visible && !Config.清理尸体)
                    {
                        Visible = true;
                        break;
                    }
                    break;
            }
            
            int frame = CurrentFrame.GetFrame(FrameStart, CEnvir.Now, (this != User || GameScene.Game.Observer) && ActionQueue.Count > 1);

            if (frame == CurrentFrame.FrameCount || (Interupt && ActionQueue.Count > 0))
            {
                DoNextAction();
                frame = CurrentFrame.GetFrame(FrameStart, CEnvir.Now, (this != User || GameScene.Game.Observer) && ActionQueue.Count > 1);
                if (frame == CurrentFrame.FrameCount)
                    frame -= 1;
            }
            
            int x = 0, y =0;
            switch (CurrentAction)
            {
                case MirAction.Moving:
                case MirAction.Pushed:
                    switch (Direction)
                    {
                        case MirDirection.Up:
                            x = 0;
                            y = (int) (CellHeight*MoveDistance/(float) CurrentFrame.FrameCount*(CurrentFrame.FrameCount - (frame + 1)));
                            break;
                        case MirDirection.UpRight:
                            x = -(int)(CellWidth * MoveDistance / (float)CurrentFrame.FrameCount * (CurrentFrame.FrameCount - (frame + 1)));
                            y = (int)(CellHeight * MoveDistance / (float)CurrentFrame.FrameCount * (CurrentFrame.FrameCount - (frame + 1)));
                            break;
                        case MirDirection.Right:
                            x = -(int)(CellWidth * MoveDistance / (float)CurrentFrame.FrameCount * (CurrentFrame.FrameCount - (frame + 1)));
                            y = 0;
                            break;
                        case MirDirection.DownRight:
                            x = -(int)(CellWidth * MoveDistance / (float)CurrentFrame.FrameCount * (CurrentFrame.FrameCount - (frame + 1)));
                            y = -(int)(CellHeight * MoveDistance / (float)CurrentFrame.FrameCount * (CurrentFrame.FrameCount - (frame + 1)));
                            break;
                        case MirDirection.Down:
                            x = 0;
                            y = -(int)(CellHeight * MoveDistance / (float)CurrentFrame.FrameCount * (CurrentFrame.FrameCount - (frame + 1)));
                            break;
                        case MirDirection.DownLeft:
                            x = (int)(CellWidth * MoveDistance / (float)CurrentFrame.FrameCount * (CurrentFrame.FrameCount - (frame + 1)));
                            y = -(int)(CellHeight * MoveDistance / (float)CurrentFrame.FrameCount * (CurrentFrame.FrameCount - (frame + 1)));
                            break;
                        case MirDirection.Left:
                            x = (int)(CellWidth * MoveDistance / (float)CurrentFrame.FrameCount * (CurrentFrame.FrameCount - (frame + 1)));
                            y = 0;
                            break;
                        case MirDirection.UpLeft:
                            x = (int)(CellWidth * MoveDistance / (float)CurrentFrame.FrameCount * (CurrentFrame.FrameCount - (frame + 1)));
                            y = (int)(CellHeight * MoveDistance / (float)CurrentFrame.FrameCount * (CurrentFrame.FrameCount - (frame + 1)));
                            break;
                    }
                    break;
            }
            x -= x % 2;
            y -= y % 2;

            if (CurrentFrame.Reversed)
            {
                frame = CurrentFrame.FrameCount - frame - 1;
                x *= -1;
                y *= -1;
            }

            if (GameScene.Game.MapControl.BackgroundImage != null)
                GameScene.Game.MapControl.BackgroundMovingOffset = new Point((int)(x / GameScene.Game.MapControl.BackgroundScaleX), (int)(y / GameScene.Game.MapControl.BackgroundScaleY));
            MovingOffSet = new Point(x, y);

            if (Race == ObjectType.Player && CurrentAction == MirAction.Pushed)
                frame = 0;

            FrameIndex = frame;
            DrawFrame = FrameIndex + CurrentFrame.StartIndex + CurrentFrame.OffSet * (int)Direction;

        }

        public abstract void SetAnimation(ObjectAction action);
        public virtual void SetFrame(ObjectAction action)
        {
            SetAnimation(action);
            
            FrameIndex = -1;
            CurrentAction = action.Action;
            FrameStart = CEnvir.Now;

            switch (action.Action)
            {
                case MirAction.Standing:
                case MirAction.Dead:
                    Interupt = true;
                    break;
                default:
                    Interupt = false;
                    break;
            }
        }
        public virtual void SetAction(ObjectAction action)
        {
            MirEffect spell;

            switch (CurrentAction)
            {
                case MirAction.Mining:
                    if (!MiningEffect) break;

                    Effects.Add(new MirEffect(3470, 3, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 20, 70, CartoonGlobals.NoneColour) 
                    {
                        Blend = true,
                        MapTarget = CurrentLocation,
                        Direction = Direction,
                        Skip = 10,
                    });
                    break;
                case MirAction.Spell:
                    if (!MagicCast) break;


                    switch (MagicType)
                    {
                        #region Warrior

                        

                        

                        

                        

                        

                        

                        

                        

                        

                        

                        

                        

                        

                        


                        #region Swift Blade

                        case MagicType.SwiftBlade:
                            
                            foreach (Point point in MagicLocations)
                            {
                                spell = new MirEffect(2330, 16, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx2, 10, 35, CartoonGlobals.NoneColour)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                };
                                spell.Process();
                            }

                            DXSoundManager.Play(SoundIndex.SwiftBladeEnd);
                            break;

                        #endregion

                        

                        

                        

                        

                        #endregion

                        #region Wizard

                        #region Fire Ball

                        case MagicType.FireBall:
                            foreach (Point point in MagicLocations)
                            {
                                Effects.Add(spell = new MirProjectile(420, 5, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 35, 35, CartoonGlobals.FireColour, CurrentLocation)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                });
                                spell.Process();
                            }

                            foreach (MapObject attackTarget in AttackTargets)
                            {
                                Effects.Add(spell = new MirProjectile(420, 5, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 35, 35, CartoonGlobals.FireColour, CurrentLocation)
                                {
                                    Blend = true,
                                    Target = attackTarget,
                                });

                                spell.CompleteAction = () =>
                                {
                                    attackTarget.Effects.Add(spell = new MirEffect(580, 10, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 10, 35, CartoonGlobals.FireColour)
                                    {
                                        Blend = true,
                                        Target = attackTarget,
                                    });
                                    spell.Process();

                                    DXSoundManager.Play(SoundIndex.FireBallEnd);
                                };

                                spell.Process();
                            }

                            if (MagicLocations.Count > 0 || AttackTargets.Count > 0)
                                DXSoundManager.Play(SoundIndex.FireBallTravel);
                            break;

                        #endregion

                        #region Lightning Ball

                        case MagicType.LightningBall:
                            foreach (Point point in MagicLocations)
                            {
                                Effects.Add(spell = new MirProjectile(3070, 6, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 35, 35, CartoonGlobals.LightningColour, CurrentLocation)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                });
                                spell.Process();
                            }

                            foreach (MapObject attackTarget in AttackTargets)
                            {
                                Effects.Add(spell = new MirProjectile(3070, 6, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 35, 35, CartoonGlobals.LightningColour, CurrentLocation)
                                {
                                    Blend = true,
                                    Target = attackTarget,
                                });

                                spell.CompleteAction = () =>
                                {
                                    attackTarget.Effects.Add(spell = new MirEffect(3230, 10, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 10, 35, CartoonGlobals.LightningColour)
                                    {
                                        Blend = true,
                                        Target = attackTarget,
                                    });
                                    spell.Process();

                                    DXSoundManager.Play(SoundIndex.ThunderBoltEnd);
                                };
                                spell.Process();
                            }

                            if (MagicLocations.Count > 0 || AttackTargets.Count > 0)
                                DXSoundManager.Play(SoundIndex.ThunderBoltTravel);

                            break;

                        #endregion

                        #region Ice Bolt

                        case MagicType.IceBolt:

                            foreach (Point point in MagicLocations)
                            {
                                Effects.Add(spell = new MirProjectile(2700, 3, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 35, 35, CartoonGlobals.IceColour, CurrentLocation)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                });
                                spell.Process();
                            }

                            foreach (MapObject attackTarget in AttackTargets)
                            {
                                Effects.Add(spell = new MirProjectile(2700, 3, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 35, 35, CartoonGlobals.IceColour, CurrentLocation)
                                {
                                    Blend = true,
                                    Target = attackTarget,
                                });

                                spell.CompleteAction = () =>
                                {
                                    attackTarget.Effects.Add(spell = new MirEffect(2860, 10, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 10, 35, CartoonGlobals.IceColour)
                                    {
                                        Blend = true,
                                        Target = attackTarget,
                                    });
                                    spell.Process();

                                    DXSoundManager.Play(SoundIndex.IceBoltEnd);
                                };
                                spell.Process();
                            }

                            if (MagicLocations.Count > 0 || AttackTargets.Count > 0)
                                DXSoundManager.Play(SoundIndex.IceBoltTravel);

                            break;

                        #endregion

                        #region Gust Blast

                        case MagicType.GustBlast:
                            foreach (Point point in MagicLocations)
                            {
                                Effects.Add(spell = new MirProjectile(430, 5, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 35, 35, CartoonGlobals.WindColour, CurrentLocation)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                });
                                spell.Process();
                            }

                            foreach (MapObject attackTarget in AttackTargets)
                            {
                                Effects.Add(spell = new MirProjectile(430, 5, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 35, 35, CartoonGlobals.WindColour, CurrentLocation)
                                {
                                    Blend = true,
                                    Target = attackTarget,
                                });

                                spell.CompleteAction = () =>
                                {
                                    attackTarget.Effects.Add(spell = new MirEffect(590, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 10, 35, CartoonGlobals.WindColour)
                                    {
                                        Blend = true,
                                        Target = attackTarget,
                                    });
                                    spell.Process();

                                    DXSoundManager.Play(SoundIndex.GustBlastEnd);
                                };
                                spell.Process();
                            }

                            if (MagicLocations.Count > 0 || AttackTargets.Count > 0)
                                DXSoundManager.Play(SoundIndex.GustBlastTravel);

                            break;

                        #endregion

                        #region Electric Shock

                        case MagicType.ElectricShock:
                            foreach (Point point in MagicLocations)
                            {
                                spell = new MirEffect(10, 10, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 10, 35, CartoonGlobals.LightningColour)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                };
                                spell.Process();
                            }

                            foreach (MapObject attackTarget in AttackTargets)
                            {
                                attackTarget.Effects.Add(spell = new MirEffect(10, 10, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 10, 35, CartoonGlobals.LightningColour)
                                {
                                    Blend = true,
                                    Target = attackTarget,
                                });
                                spell.Process();
                            }

                            if (MagicLocations.Count > 0 || AttackTargets.Count > 0)
                                DXSoundManager.Play(SoundIndex.ElectricShockEnd);
                            break;

                        #endregion

                        

                        #region Adamantine Fire Ball & Meteor Shower

                        case MagicType.AdamantineFireBall:
                        case MagicType.MeteorShower:
                            /*
                             foreach (Point point in MagicLocations)
                             {
                                 Effects.Add(spell = new MirProjectile(1500, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx5, 0, 0, CartoonGlobals.NoneColour, CurrentLocation)
                                 {
                                    
                                     MapTarget = point,
                                 });
                                 spell.Process();
                             }

                             foreach (MapObject attackTarget in AttackTargets)
                             {
                                 Effects.Add(spell = new MirProjectile(1500, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx5, 0, 0, CartoonGlobals.NoneColour, CurrentLocation)
                                 {
                                     
                                     Target = attackTarget,
                                 });

                                 

                                 spell.CompleteAction = () =>
                                 {
                                     attackTarget.Effects.Add(spell = new MirEffect(1700 + CEnvir.Random.Next(3) * 10, 5, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx5, 0, 0, CartoonGlobals.NoneColour)
                                     {
                                      
                                         Target = attackTarget,
                                     });
                                     spell.Process();

                                     DXSoundManager.Play(SoundIndex.GreaterFireBallEnd);
                                 };
                                 spell.Process();
                             }

                             if (MagicLocations.Count > 0 || AttackTargets.Count > 0)
                                 DXSoundManager.Play(SoundIndex.GreaterFireBallTravel);*/
                            foreach (Point point in MagicLocations)
                            {
                                Effects.Add(spell = new MirProjectile(1640, 6, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 35, 35, CartoonGlobals.FireColour, CurrentLocation)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                });
                                spell.Process();
                            }

                            foreach (MapObject attackTarget in AttackTargets)
                            {
                                Effects.Add(spell = new MirProjectile(1640, 6, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 35, 35, CartoonGlobals.FireColour, CurrentLocation)
                                {
                                    Blend = true,
                                    Target = attackTarget,
                                });

                                

                                spell.CompleteAction = () =>
                                {
                                    attackTarget.Effects.Add(spell = new MirEffect(1800, 10, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 10, 35, CartoonGlobals.FireColour)
                                    {
                                        Blend = true,
                                        Target = attackTarget,
                                    });
                                    spell.Process();

                                    DXSoundManager.Play(SoundIndex.GreaterFireBallEnd);
                                };
                                spell.Process();
                            }

                            if (MagicLocations.Count > 0 || AttackTargets.Count > 0)
                                DXSoundManager.Play(SoundIndex.GreaterFireBallTravel);
                            break;

                        #endregion

                        #region Thunder Bolt & Thunder Strike

                        case MagicType.ThunderBolt:
                            if (Mingwen01 == 108 || Mingwen02 == 108 || Mingwen03 == 108)
                            {
                                foreach (Point point in MagicLocations)
                                {
                                    spell = new MirEffect(20, 3, TimeSpan.FromMilliseconds(150), LibraryFile.MagicEx10, 150, 50, CartoonGlobals.NoneColour)
                                    {
                                        Blend = true,
                                        MapTarget = point
                                    };
                                    spell.Process();
                                }

                                foreach (MapObject attackTarget in AttackTargets)
                                {
                                    spell = new MirEffect(20, 3, TimeSpan.FromMilliseconds(150), LibraryFile.MagicEx10, 150, 50, CartoonGlobals.NoneColour)
                                    {
                                        Blend = true,
                                        Target = attackTarget
                                    };
                                    spell.Process();
                                }
                            }
                            else if (Mingwen01 == 109 || Mingwen02 == 109 || Mingwen03 == 109)
                            {
                                foreach (Point point in MagicLocations)
                                {
                                    spell = new MirEffect(50, 3, TimeSpan.FromMilliseconds(150), LibraryFile.MagicEx10, 150, 50, CartoonGlobals.NoneColour)
                                    {
                                        Blend = true,
                                        MapTarget = point
                                    };
                                    spell.Process();
                                }

                                foreach (MapObject attackTarget in AttackTargets)
                                {
                                    spell = new MirEffect(50, 3, TimeSpan.FromMilliseconds(150), LibraryFile.MagicEx10, 150, 50, CartoonGlobals.LightningColour)
                                    {
                                        Blend = true,
                                        Target = attackTarget
                                    };
                                    spell.Process();
                                }
                            }
                            else if (Mingwen01 == 110 || Mingwen02 == 110 || Mingwen03 == 110)
                            {
                                foreach (Point point in MagicLocations)
                                {
                                    spell = new MirEffect(80, 3, TimeSpan.FromMilliseconds(150), LibraryFile.MagicEx10, 150, 50, CartoonGlobals.LightningColour)
                                    {
                                        Blend = true,
                                        MapTarget = point
                                    };
                                    spell.Process();
                                }

                                foreach (MapObject attackTarget in AttackTargets)
                                {
                                    spell = new MirEffect(80, 3, TimeSpan.FromMilliseconds(150), LibraryFile.MagicEx10, 150, 50, CartoonGlobals.LightningColour)
                                    {
                                        Blend = true,
                                        Target = attackTarget
                                    };
                                    spell.Process();
                                }
                            }
                            else
                            {
                                foreach (Point point in MagicLocations)
                                {
                                    spell = new MirEffect(1450, 3, TimeSpan.FromMilliseconds(150), LibraryFile.Magic, 150, 50, CartoonGlobals.LightningColour)
                                    {
                                        Blend = true,
                                        MapTarget = point
                                    };
                                    spell.Process();
                                }

                                foreach (MapObject attackTarget in AttackTargets)
                                {
                                    spell = new MirEffect(1450, 3, TimeSpan.FromMilliseconds(150), LibraryFile.Magic, 150, 50, CartoonGlobals.LightningColour)
                                    {
                                        Blend = true,
                                        Target = attackTarget
                                    };
                                    spell.Process();
                                }
                            }
                            if (MagicLocations.Count > 0 || AttackTargets.Count > 0)
                                DXSoundManager.Play(SoundIndex.LightningStrikeEnd);
                            break;
                        case MagicType.ThunderStrike:
                            foreach (Point point in MagicLocations)
                            {
                                spell = new MirEffect(1450, 3, TimeSpan.FromMilliseconds(150), LibraryFile.Magic, 150, 50, CartoonGlobals.LightningColour)
                                {
                                    Blend = true,
                                    MapTarget = point
                                };
                                spell.Process();
                            }

                            foreach (MapObject attackTarget in AttackTargets)
                            {
                                spell = new MirEffect(1450, 3, TimeSpan.FromMilliseconds(150), LibraryFile.Magic, 150, 50, CartoonGlobals.LightningColour)
                                {
                                    Blend = true,
                                    Target = attackTarget
                                };
                                spell.Process();
                            }

                            if (MagicLocations.Count > 0 || AttackTargets.Count > 0)
                                DXSoundManager.Play(SoundIndex.LightningStrikeEnd);
                            break;

                        #endregion

                        #region Ice Blades

                        case MagicType.IceBlades:
                            foreach (Point point in MagicLocations)
                            {
                                Effects.Add(spell = new MirProjectile(2960, 6, TimeSpan.FromMilliseconds(50), LibraryFile.Magic, 35, 35, CartoonGlobals.IceColour, CurrentLocation)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                    Skip = 0,
                                    BlendRate = 1F,
                                });
                                spell.Process();
                            }

                            foreach (MapObject attackTarget in AttackTargets)
                            {
                                Effects.Add(spell = new MirProjectile(2960, 6, TimeSpan.FromMilliseconds(50), LibraryFile.Magic, 35, 35, CartoonGlobals.IceColour, CurrentLocation)
                                {
                                    Blend = true,
                                    Target = attackTarget,
                                    Skip = 0,
                                    BlendRate = 1F,
                                });

                                spell.CompleteAction = () =>
                                {
                                    attackTarget.Effects.Add(spell = new MirEffect(2970, 10, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 10, 35, CartoonGlobals.IceColour)
                                    {
                                        Blend = true,
                                        Target = attackTarget
                                    });
                                    spell.Process();

                                    DXSoundManager.Play(SoundIndex.GreaterIceBoltEnd);
                                };
                                spell.Process();
                            }

                            if (MagicLocations.Count > 0 || AttackTargets.Count > 0)
                                DXSoundManager.Play(SoundIndex.GreaterIceBoltTravel);
                            break;

                        #endregion

                        #region Cyclone

                        case MagicType.Cyclone:
                            foreach (Point point in MagicLocations)
                            {
                                spell = new MirEffect(1990, 5, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 50, 80, CartoonGlobals.WindColour)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                };

                                spell.CompleteAction = () =>
                                {
                                    spell = new MirEffect(2000, 8, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 50, 80, CartoonGlobals.WindColour)
                                    {
                                        Blend = true,
                                        MapTarget = point
                                    };
                                    spell.Process();
                                };

                                spell.Process();
                            }

                            foreach (MapObject attackTarget in AttackTargets)
                            {
                                spell = new MirEffect(1990, 5, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 50, 80, CartoonGlobals.WindColour)
                                {
                                    Blend = true,
                                    Target = attackTarget,
                                };

                                spell.CompleteAction = () =>
                                {
                                    spell = new MirEffect(2000, 8, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 50, 80, CartoonGlobals.WindColour)
                                    {
                                        Blend = true,
                                        Target = attackTarget
                                    };
                                    spell.Process();
                                };

                                spell.Process();
                            }

                            DXSoundManager.Play(SoundIndex.CycloneEnd);
                            break;

                        #endregion

                        #region Scortched Earth

                        case MagicType.ScortchedEarth:
                            if (Config.DrawEffects && Race != ObjectType.Monster)
                                foreach (Point point in MagicLocations)
                            {
                                Effects.Add(new MirEffect(220, 1, TimeSpan.FromMilliseconds(2500), LibraryFile.ProgUse, 0, 0, CartoonGlobals.NoneColour)
                                {
                                    MapTarget = point,
                                    StartTime = CEnvir.Now.AddMilliseconds(500 + Functions.Distance(point, CurrentLocation) * 50),
                                    Opacity = 0.8F,
                                    DrawType = DrawType.Floor,
                                });

                                Effects.Add(new MirEffect(2450 + CEnvir.Random.Next(5) * 10, 10, TimeSpan.FromMilliseconds(250), LibraryFile.Magic, 0, 0, CartoonGlobals.NoneColour)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                    StartTime = CEnvir.Now.AddMilliseconds(500 + Functions.Distance(point, CurrentLocation) * 50),
                                    DrawType = DrawType.Floor,
                                });

                                Effects.Add(new MirEffect(1900, 30, TimeSpan.FromMilliseconds(50), LibraryFile.Magic, 20, 70, CartoonGlobals.FireColour)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                    StartTime = CEnvir.Now.AddMilliseconds(Functions.Distance(point, CurrentLocation) * 50),
                                    BlendRate = 1F,
                                });

                            }
                            break;

                        #endregion

                        #region Lightning Beam

                        case MagicType.LightningBeam:
                            if (Config.DrawEffects && Race != ObjectType.Monster)
                            {
                                foreach (Point point in MagicLocations)
                                {
                                    
                                    
                                    if (Mingwen01 == 114 || Mingwen02 == 114 || Mingwen03 == 114)
                                    {
                                        Effects.Add(spell = new MirEffect(1180, 4, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 150, 150, CartoonGlobals.LightningColour)
                                        {
                                            Blend = true,
                                            Target = this,
                                            Direction = Functions.DirectionFromPoint(CurrentLocation, point)
                                        });
                                        spell.Process();
                                    }
                                    
                                    
                                    else if (Mingwen01 == 115 || Mingwen02 == 115 || Mingwen03 == 115)
                                    {
                                        Effects.Add(spell = new MirEffect(110, 4, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx10, 150, 150, CartoonGlobals.NoneColour)
                                        {
                                            Blend = true,
                                            Target = this,
                                            Direction = Functions.DirectionFromPoint(CurrentLocation, point)
                                        });
                                        spell.Process();
                                    }
                                    
                                    
                                    else if (Mingwen01 == 116 || Mingwen02 == 116 || Mingwen03 == 116)
                                    {
                                        Effects.Add(spell = new MirEffect(1180, 4, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 150, 150, CartoonGlobals.LightningColour)
                                        {
                                            Blend = true,
                                            Target = this,
                                            Direction = Functions.DirectionFromPoint(CurrentLocation, point)
                                        });
                                        spell.Process();
                                    }
                                    else
                                    {
                                        Effects.Add(spell = new MirEffect(1180, 4, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 150, 150, CartoonGlobals.LightningColour)
                                        {
                                            Blend = true,
                                            Target = this,
                                            Direction = Functions.DirectionFromPoint(CurrentLocation, point)
                                        });
                                        spell.Process();
                                    }
                                }
                            }
                            DXSoundManager.Play(SoundIndex.LightningBeamEnd);
                            break;


                        #region Frozen Earth

                        case MagicType.FrozenEarth:
                            if (Config.DrawEffects && Race != ObjectType.Monster)
                                foreach (Point point in MagicLocations)
                            {
                                Effects.Add(spell = new MirEffect(90, 20, TimeSpan.FromMilliseconds(50), LibraryFile.MagicEx, 20, 70, CartoonGlobals.IceColour)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                    StartTime = CEnvir.Now.AddMilliseconds(Functions.Distance(point, CurrentLocation) * 50),
                                    Opacity = 0.5F,
                                });

                                spell.CompleteAction = () =>
                                {
                                    Effects.Add(spell = new MirEffect(260, 1, TimeSpan.FromMilliseconds(2500), LibraryFile.ProgUse, 0, 0, CartoonGlobals.IceColour)
                                    {
                                        MapTarget = point,
                                        Opacity = 0.8F,
                                        DrawType = DrawType.Floor,
                                    });
                                    spell.Process();
                                };
                                spell.Process();
                            }
                            if (MagicLocations.Count > 0)
                                DXSoundManager.Play(SoundIndex.FrozenEarthEnd);
                            break;

                        #endregion

                        #region Blow Earth

                        case MagicType.BlowEarth:
                            if (Config.DrawEffects && Race != ObjectType.Monster)
                                foreach (Point point in MagicLocations)
                            {
                                Effects.Add(spell = new MirProjectile(1990, 5, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 50, 80, CartoonGlobals.WindColour, CurrentLocation)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                    Skip = 0,
                                    Explode = true,
                                });

                                spell.CompleteAction = () =>
                                {
                                    spell = new MirEffect(2000, 8, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 50, 80, CartoonGlobals.WindColour)
                                    {
                                        Blend = true,
                                        MapTarget = point
                                    };
                                    spell.Process();
                                    DXSoundManager.Play(SoundIndex.BlowEarthEnd);
                                };

                                spell.Process();
                            }

                            if (MagicLocations.Count > 0)
                                DXSoundManager.Play(SoundIndex.BlowEarthTravel);
                            break;

                        #endregion

                        

                        #region Expel Undead

                        case MagicType.ExpelUndead:
                            foreach (MapObject attackTarget in AttackTargets)
                            {
                                spell = new MirEffect(140, 5, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 50, 80, CartoonGlobals.PhantomColour)
                                {
                                    Blend = true,
                                    Target = attackTarget,
                                };
                                spell.Process();
                            }

                            DXSoundManager.Play(SoundIndex.ExpelUndeadEnd);
                            break;

                        #endregion

                        

                        

                        #region Fire Storm

                        case MagicType.FireStorm:
                            foreach (Point point in MagicLocations)
                            {
                                spell = new MirEffect(950, 7, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 10, 35, CartoonGlobals.FireColour)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                };
                                spell.Process();
                            }

                            DXSoundManager.Play(SoundIndex.FireStormEnd);
                            break;

                        #endregion


                        #region Lightning Wave

                        case MagicType.LightningWave:
                            foreach (Point point in MagicLocations)
                            {
                                
                                
                                if (Mingwen01 == 130 || Mingwen02 == 130 || Mingwen03 == 130)
                                {
                                    spell = new MirEffect(1000, 8, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 50, 80, CartoonGlobals.NoneColour)
                                    {
                                        Blend = true,
                                        MapTarget = point,
                                    };
                                    spell.Process();
                                }
                                else
                                {
                                    spell = new MirEffect(980, 8, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 50, 80, CartoonGlobals.LightningColour)
                                    {
                                        Blend = true,
                                        MapTarget = point,
                                    };
                                    spell.Process();
                                }
                            }
                            DXSoundManager.Play(SoundIndex.LightningWaveEnd);
                            break;

                        #endregion

                        #region Ice Storm

                        case MagicType.IceStorm:
                            foreach (Point point in MagicLocations)
                            {
                                
                                
                                if (Mingwen01 == 131 || Mingwen02 == 131 || Mingwen03 == 131)
                                {
                                    spell = new MirEffect(780, 7, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 10, 35, CartoonGlobals.IceColour)
                                    {
                                        Blend = true,
                                        MapTarget = point,
                                    };
                                    spell.Process();
                                }
                                
                                
                                else if (Mingwen01 == 132 || Mingwen02 == 132 || Mingwen03 == 132)
                                {
                                    spell = new MirEffect(790, 10, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 10, 35, CartoonGlobals.NoneColour)
                                    {
                                        Blend = true,
                                        Opacity = 0.7F,
                                        MapTarget = point,
                                    };
                                    spell.Process();
                                }
                                else
                                {
                                    spell = new MirEffect(780, 7, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 10, 35, CartoonGlobals.IceColour)
                                    {
                                        Blend = true,
                                        MapTarget = point,
                                    };
                                    spell.Process();
                                }
                            }

                            DXSoundManager.Play(SoundIndex.IceStormEnd);
                            break;

                        #endregion

                        #region DragonTornado

                        case MagicType.DragonTornado:
                            foreach (Point point in MagicLocations)
                            {
                                spell = new MirEffect(1040, 16, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 10, 35, CartoonGlobals.WindColour)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                };
                                spell.Process();
                            }

                            DXSoundManager.Play(SoundIndex.DragonTornadoEnd);
                            break;

                        #endregion

                        #region Greater Frozen Earth

                        case MagicType.GreaterFrozenEarth:
                            foreach (Point point in MagicLocations)
                            {
                                Effects.Add(spell = new MirEffect(90, 20, TimeSpan.FromMilliseconds(50), LibraryFile.MagicEx, 20, 70, CartoonGlobals.IceColour)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                    StartTime = CEnvir.Now.AddMilliseconds(Functions.Distance(point, CurrentLocation) * 50),
                                    Opacity = 0.5F,
                                });

                                spell.CompleteAction = () =>
                                {
                                    Effects.Add(spell = new MirEffect(260, 1, TimeSpan.FromMilliseconds(2500), LibraryFile.ProgUse, 0, 0, CartoonGlobals.NoneColour)
                                    {
                                        MapTarget = point,
                                        Opacity = 0.8F,
                                        DrawType = DrawType.Floor,
                                    });
                                    spell.Process();
                                };
                                spell.Process();
                            }
                            if (MagicLocations.Count > 0)
                                DXSoundManager.Play(SoundIndex.GreaterFrozenEarthEnd);
                            break;

                        #endregion

                        #region Chain Lightning

                        case MagicType.ChainLightning:
                            foreach (Point point in MagicLocations)
                            {
                                
                                
                                if (Mingwen01 == 188 || Mingwen02 == 188 || Mingwen03 == 188)
                                {
                                    spell = new MirEffect(1200, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx10, 50, 80, CartoonGlobals.LightningColour)
                                    {
                                        Blend = true,
                                        MapTarget = point,
                                    };
                                    spell.Process();
                                }
                                else
                                {
                                    spell = new MirEffect(470, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx2, 50, 80, CartoonGlobals.LightningColour)
                                    {
                                        Blend = true,
                                        MapTarget = point,
                                    };
                                    spell.Process();
                                }
                            }

                            DXSoundManager.Play(SoundIndex.ChainLightningEnd);
                            break;

                        #endregion

                        case MagicType.Asteroid:

                            foreach (Point point in MagicLocations)
                            {
                                MirProjectile eff;
                                Point p = new Point(point.X + 4, point.Y - 10);
                                Effects.Add(eff = new MirProjectile(1300, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx5, 50, 80, CartoonGlobals.FireColour, p)
                                {
                                    MapTarget = point,
                                    Skip = 0,
                                    Explode = true,
                                    Blend = true,
                                });

                                eff.CompleteAction = () =>
                                {
                                    Effects.Add(new MirEffect(1320, 8, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx5, 100, 100, CartoonGlobals.NoneColour)
                                    {
                                        MapTarget = eff.MapTarget,
                                        Blend = true,
                                    });
                                };
                            }
                            break;

                        

                        

                        

                        

                        

                        

                        #endregion

                        #region Taoist


                        #region Heal

                        
                        
                        case MagicType.Heal:
                            foreach (MapObject attackTarget in AttackTargets)
                            {
                                if (Mingwen01 == 1 || Mingwen02 == 1 || Mingwen03 == 1)
                                {
                                    attackTarget.Effects.Add(spell = new MirEffect(610, 10, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 10, 35, CartoonGlobals.FireColour)
                                    {
                                        Blend = true,
                                        Target = attackTarget,
                                    });
                                    spell.Process();
                                }
                                else
                                {
                                    attackTarget.Effects.Add(spell = new MirEffect(610, 10, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 10, 35, CartoonGlobals.HolyColour)
                                    {
                                        Blend = true,
                                        Target = attackTarget,
                                    });
                                    spell.Process();
                                }
                            }
                            if (AttackTargets.Count > 0)
                                DXSoundManager.Play(SoundIndex.HealEnd);
                            break;

                        #endregion

                        #region 精神力战法
                        #endregion

                        #region Poison Dust & Greater Poison Dust

                        case MagicType.PoisonDust:
                        case MagicType.GreaterPoisonDust:
                            foreach (MapObject attackTarget in AttackTargets)
                            {
                                attackTarget.Effects.Add(spell = new MirEffect(70, 10, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 10, 35, CartoonGlobals.DarkColour)
                                {
                                    Blend = true,
                                    Target = attackTarget,
                                });
                                spell.Process();
                            }

                            if (AttackTargets.Count > 0)
                                DXSoundManager.Play(SoundIndex.PoisonDustEnd);
                            break;

                        #endregion

                        #region Explosive Talisman

                         case MagicType.ExplosiveTalisman:
                             foreach (Point point in MagicLocations)
                             {
                                 Effects.Add(spell = new MirProjectile(980, 3, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 35, 35, CartoonGlobals.DarkColour, CurrentLocation)
                                 {
                                     Blend = true,
                                     MapTarget = point,
                                     Has16Directions = false
                                 });
                                 spell.Process();
                             }

                             foreach (MapObject attackTarget in AttackTargets)
                             {
                                 Effects.Add(spell = new MirProjectile(980, 3, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 35, 35, CartoonGlobals.DarkColour, CurrentLocation)
                                 {
                                     Blend = true,
                                     Target = attackTarget,
                                     Has16Directions = true
                                 });

                                 spell.CompleteAction = () =>
                                 {
                                     attackTarget.Effects.Add(spell = new MirEffect(1140, 10, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 20, 50, CartoonGlobals.DarkColour)
                                     {
                                         Blend = true,
                                         Target = attackTarget,
                                     });
                                     spell.Process();

                                     DXSoundManager.Play(SoundIndex.ExplosiveTalismanEnd);
                                 };
                                 spell.Process();
                             }

                             if (MagicLocations.Count > 0 || AttackTargets.Count > 0)
                                 DXSoundManager.Play(SoundIndex.ExplosiveTalismanTravel);

                             break;

                         #endregion
                       

                        #region Evil Slayer

                        case MagicType.EvilSlayer:
                             foreach (Point point in MagicLocations)
                             {
                                 Effects.Add(spell = new MirProjectile(3330, 6, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 35, 35, CartoonGlobals.HolyColour, CurrentLocation)
                                 {
                                     Blend = true,
                                     MapTarget = point,
                                     Skip = 0,
                                 });
                                 spell.Process();
                             }

                             foreach (MapObject attackTarget in AttackTargets)
                             {
                                 Effects.Add(spell = new MirProjectile(3330, 6, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 35, 35, CartoonGlobals.HolyColour, CurrentLocation)
                                 {
                                     Blend = true,
                                     Target = attackTarget,
                                     Skip = 0,
                                 });

                                 spell.CompleteAction = () =>
                                 {
                                     attackTarget.Effects.Add(spell = new MirEffect(3340, 10, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 20, 50, CartoonGlobals.HolyColour)
                                     {
                                         Blend = true,
                                         Target = attackTarget,
                                     });
                                     spell.Process();

                                     DXSoundManager.Play(SoundIndex.HolyStrikeEnd);
                                 };
                                 spell.Process();
                             }

                             if (MagicLocations.Count > 0 || AttackTargets.Count > 0)
                                 DXSoundManager.Play(SoundIndex.HolyStrikeTravel);

                             break;

                         #endregion*/

                       




                        #region Magic Resistance

                        case MagicType.MagicResistance:
                            foreach (Point point in MagicLocations)
                            {
                                Effects.Add(spell = new MirProjectile(980, 3, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 35, 35, CartoonGlobals.NoneColour, CurrentLocation)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                    Explode = true,
                                });

                                spell.CompleteAction = () =>
                                {
                                    spell = new MirEffect(200, 8, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 20, 80, CartoonGlobals.NoneColour)
                                    {
                                        Blend = true,
                                        MapTarget = point,
                                    };
                                    spell.Process();

                                    DXSoundManager.Play(SoundIndex.MagicResistanceEnd);
                                };
                                spell.Process();
                            }

                            if (MagicLocations.Count > 0)
                                DXSoundManager.Play(SoundIndex.MagicResistanceTravel);

                            break;

                        #endregion

                        #region Mass Invisibility

                        case MagicType.MassInvisibility:
                            foreach (Point point in MagicLocations)
                            {
                                Effects.Add(spell = new MirProjectile(980, 3, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 35, 35, CartoonGlobals.PhantomColour, CurrentLocation)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                    Explode = true,
                                });

                                spell.CompleteAction = () =>
                                {
                                    spell = new MirEffect(820, 7, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 20, 80, CartoonGlobals.PhantomColour)
                                    {
                                        Blend = true,
                                        MapTarget = point,
                                    };
                                    spell.Process();

                                    DXSoundManager.Play(SoundIndex.MassInvisibilityEnd);
                                };
                                spell.Process();
                            }

                            if (MagicLocations.Count > 0)
                                DXSoundManager.Play(SoundIndex.MassInvisibilityTravel);
                            break;

                        #endregion

                        #region Greater Evil Slayer

                        case MagicType.GreaterEvilSlayer:
                            foreach (Point point in MagicLocations)
                            {
                                Effects.Add(spell = new MirProjectile(3440, 6, TimeSpan.FromMilliseconds(50), LibraryFile.Magic, 35, 35, CartoonGlobals.HolyColour, CurrentLocation)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                    Skip = 0,
                                });
                                spell.Process();
                            }

                            foreach (MapObject attackTarget in AttackTargets)
                            {
                                Effects.Add(spell = new MirProjectile(3440, 6, TimeSpan.FromMilliseconds(50), LibraryFile.Magic, 35, 35, CartoonGlobals.HolyColour, CurrentLocation)
                                {
                                    Blend = true,
                                    Target = attackTarget,
                                    Skip = 0,
                                });

                                spell.CompleteAction = () =>
                                {
                                    attackTarget.Effects.Add(spell = new MirEffect(3450, 10, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 20, 50, CartoonGlobals.HolyColour)
                                    {
                                        Blend = true,
                                        Target = attackTarget,
                                    });
                                    spell.Process();

                                    DXSoundManager.Play(SoundIndex.ImprovedHolyStrikeEnd);
                                };
                                spell.Process();
                            }

                            if (MagicLocations.Count > 0 || AttackTargets.Count > 0)
                                DXSoundManager.Play(SoundIndex.ImprovedHolyStrikeTravel);

                            break;

                        #endregion

                        #region Resilience

                        case MagicType.Resilience:

                            foreach (Point point in MagicLocations)
                            {
                                Effects.Add(spell = new MirProjectile(980, 3, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 35, 35, CartoonGlobals.NoneColour, CurrentLocation)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                    Explode = true,
                                });

                                spell.CompleteAction = () =>
                                {
                                    spell = new MirEffect(170, 8, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 20, 80, CartoonGlobals.NoneColour)
                                    {
                                        Blend = true,
                                        MapTarget = point,
                                    };
                                    spell.Process();

                                    DXSoundManager.Play(SoundIndex.ResilienceEnd);
                                };

                                spell.Process();
                            }

                            if (MagicLocations.Count > 0)
                                DXSoundManager.Play(SoundIndex.ResilienceTravel);

                            break;

                        #endregion

                        #region Trap Octagon

                        case MagicType.TrapOctagon:
                            DXSoundManager.Play(SoundIndex.ShacklingTalismanEnd);
                            break;

                        #endregion

                        

                        #region Elemental Superiority

                        case MagicType.ElementalSuperiority:
                            foreach (Point point in MagicLocations)
                            {
                                Effects.Add(spell = new MirProjectile(980, 3, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 35, 35, CartoonGlobals.NoneColour, CurrentLocation)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                    Explode = true,
                                });

                                spell.CompleteAction = () =>
                                {
                                    spell = new MirEffect(1870, 7, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 20, 80, CartoonGlobals.NoneColour)
                                    {
                                        Blend = true,
                                        MapTarget = point,
                                    };
                                    spell.Process();

                                    DXSoundManager.Play(SoundIndex.BloodLustTravel);
                                };
                                spell.Process();
                            }

                            if (MagicLocations.Count > 0)
                                DXSoundManager.Play(SoundIndex.BloodLustEnd);

                            break;

                        #endregion

                        

                        #region Mass Heal

                        case MagicType.MassHeal:
                            foreach (Point point in MagicLocations)
                            {
                                spell = new MirEffect(670, 7, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 40, 60, CartoonGlobals.HolyColour)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                };
                                spell.Process();
                            }

                            DXSoundManager.Play(SoundIndex.MassHealEnd);

                            break;

                        #endregion

                        

                        #region Blood Lust

                        case MagicType.BloodLust:
                            foreach (Point point in MagicLocations)
                            {
                                Effects.Add(spell = new MirProjectile(980, 3, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 35, 35, CartoonGlobals.DarkColour, CurrentLocation)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                    Explode = true,
                                });

                                spell.CompleteAction = () =>
                                {
                                    spell = new MirEffect(140, 7, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 20, 80, CartoonGlobals.DarkColour)
                                    {
                                        Blend = true,
                                        MapTarget = point,
                                    };
                                    spell.Process();

                                    DXSoundManager.Play(SoundIndex.BloodLustEnd);
                                };
                                spell.Process();
                            }

                            if (MagicLocations.Count > 0)
                                DXSoundManager.Play(SoundIndex.BloodLustTravel);
                            break;

                        #endregion

                        #region Resurrection

                        case MagicType.Resurrection:
                            foreach (MapObject attackTarget in AttackTargets)
                            {
                                attackTarget.Effects.Add(spell = new MirEffect(320, 7, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 60, 60, CartoonGlobals.HolyColour)
                                {
                                    Blend = true,
                                    Target = attackTarget,
                                });
                                spell.Process();
                            }

                            break;

                        #endregion

                        #region Purification

                        case MagicType.Purification:
                            foreach (MapObject attackTarget in AttackTargets)
                            {
                                attackTarget.Effects.Add(spell = new MirEffect(230, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx2, 20, 40, CartoonGlobals.HolyColour)
                                {
                                    Blend = true,
                                    Target = attackTarget,
                                });
                                spell.Process();
                            }

                            if (AttackTargets.Count > 0)
                                DXSoundManager.Play(SoundIndex.PurificationEnd);
                            break;

                        #endregion

                        #region Strength Of Faith

                        case MagicType.StrengthOfFaith:
                            foreach (MapObject attackTarget in AttackTargets)
                            {
                                attackTarget.Effects.Add(spell = new MirEffect(370, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx2, 20, 40, CartoonGlobals.PhantomColour)
                                {
                                    Blend = true,
                                    Target = attackTarget,
                                });
                                spell.Process();
                            }

                            if (AttackTargets.Count > 0)
                                DXSoundManager.Play(SoundIndex.StrengthOfFaithEnd);
                            break;

                        #endregion

                        

                        #region Celestial Light

                        case MagicType.CelestialLight:
                            foreach (MapObject attackTarget in AttackTargets)
                            {
                                attackTarget.Effects.Add(spell = new MirEffect(290, 9, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx2, 20, 40, CartoonGlobals.HolyColour)
                                {
                                    Blend = true,
                                    Target = attackTarget,
                                });
                                spell.Process();
                            }
                            break;

                        #endregion

                        

                        #region LifeSteal

                        case MagicType.LifeSteal:

                            foreach (MapObject attackTarget in AttackTargets)
                            {
                                attackTarget.Effects.Add(spell = new MirEffect(2500, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx2, 10, 35, CartoonGlobals.DarkColour)
                                {
                                    Blend = true,
                                    Target = attackTarget,
                                });
                                spell.Process();
                            }

                            if (AttackTargets.Count > 0)
                                DXSoundManager.Play(SoundIndex.HolyStrikeEnd);
                            break;

                        #endregion

                        #region Improved Explosive Talisman

                        case MagicType.ImprovedExplosiveTalisman:
                            foreach (Point point in MagicLocations)
                            {
                                Effects.Add(spell = new MirProjectile(980, 3, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx2, 35, 35, CartoonGlobals.DarkColour, CurrentLocation)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                    Has16Directions = false
                                });
                                spell.Process();
                            }

                            foreach (MapObject attackTarget in AttackTargets)
                            {
                                Effects.Add(spell = new MirProjectile(980, 3, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx2, 35, 35, CartoonGlobals.DarkColour, CurrentLocation)
                                {
                                    Blend = true,
                                    Target = attackTarget,
                                    Has16Directions = true
                                });

                                spell.CompleteAction = () =>
                                {
                                    attackTarget.Effects.Add(spell = new MirEffect(1160, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx2, 20, 50, CartoonGlobals.DarkColour)
                                    {
                                        Blend = true,
                                        Target = attackTarget,
                                    });
                                    spell.Process();

                                    DXSoundManager.Play(SoundIndex.FireStormEnd);
                                };
                                spell.Process();
                            }

                            if (MagicLocations.Count > 0 || AttackTargets.Count > 0)
                                DXSoundManager.Play(SoundIndex.ExplosiveTalismanTravel);

                            break;

                        #endregion

                        

                        

                        

                        

                        #region Thunder Kick

                        case MagicType.ThunderKick:
                            Effects.Add(new MirEffect(1190, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx2, 10, 35, CartoonGlobals.NoneColour)
                            {
                                Blend = true,
                                Target = this,
                                AdditionalOffSet = new Point(0, 20)
                            });

                            DXSoundManager.Play(SoundIndex.ThunderKickEnd);
                            break;

                        #endregion

                        #region Infection

                        case MagicType.Infection:
                            foreach (Point point in MagicLocations)
                            {
                                Effects.Add(spell = new MirProjectile(800, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx5, 35, 35, CartoonGlobals.NoneColour, CurrentLocation)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                    
                                });
                                spell.Process();
                            }

                            foreach (MapObject attackTarget in AttackTargets)
                            {
                                Effects.Add(spell = new MirProjectile(800, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx5, 35, 35, CartoonGlobals.NoneColour, CurrentLocation)
                                {
                                    Blend = true,
                                    Target = attackTarget,
                                    
                                });

                                spell.Process();
                            }

                            if (MagicLocations.Count > 0 || AttackTargets.Count > 0)
                                DXSoundManager.Play(SoundIndex.FireBallTravel);
                            break;

                        #endregion

                        #region Neutralize

                        case MagicType.Neutralize:
                            foreach (Point point in MagicLocations)
                            {
                                Effects.Add(spell = new MirProjectile(300, 4, TimeSpan.FromMilliseconds(80), LibraryFile.MagicEx7, 35, 35, CartoonGlobals.FireColour, CurrentLocation)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                });
                                spell.Process();
                            }

                            foreach (MapObject attackTarget in AttackTargets)
                            {
                                Effects.Add(spell = new MirProjectile(300, 4, TimeSpan.FromMilliseconds(80), LibraryFile.MagicEx7, 35, 35, CartoonGlobals.FireColour, CurrentLocation)
                                {
                                    Blend = true,
                                    Target = attackTarget,
                                });

                                spell.CompleteAction = () =>
                                {
                                    attackTarget.Effects.Add(spell = new MirEffect(460, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx7, 0, 0, CartoonGlobals.FireColour)
                                    {
                                        Blend = true,
                                        Target = attackTarget,
                                    });
                                    spell.Process();

                                    DXSoundManager.Play(SoundIndex.NeutralizeEnd);
                                };
                                spell.Process();
                            }


                            break;

                        #endregion

                        #endregion

                        #region Assassin

                        

                        

                        

                        

                        

                        

                        

                        

                        #region Wraith Grip

                        case MagicType.WraithGrip:

                            foreach (MapObject attackTarget in AttackTargets)
                            {
                                attackTarget.CanShowWraithGrip = false;
                                attackTarget.Effects.Add(spell = new MirEffect(1420, 14, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx4, 60, 60, CartoonGlobals.NoneColour)
                                {
                                    Blend = true,
                                    Target = attackTarget,
                                    BlendRate = 0.4f,
                                });
                                spell.CompleteAction = () => attackTarget.CanShowWraithGrip = true;

                                spell.Process();

                                attackTarget.Effects.Add(spell = new MirEffect(1440, 14, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx4, 60, 60, CartoonGlobals.NoneColour)
                                {
                                    Blend = true,
                                    Target = attackTarget,
                                    BlendRate = 0.4f,
                                });
                                spell.Process();
                            }

                            if (AttackTargets.Count > 0)
                                DXSoundManager.Play(SoundIndex.WraithGripEnd);
                            break;

                        #endregion

                        #region Hell Fire

                        case MagicType.HellFire:
                            foreach (MapObject attackTarget in AttackTargets)
                            {
                                attackTarget.Effects.Add(spell = new MirEffect(1500, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx4, 60, 60, CartoonGlobals.FireColour)
                                {
                                    Blend = true,
                                    Target = attackTarget,
                                });

                                spell.Process();
                            }

                            if (AttackTargets.Count > 0)
                                DXSoundManager.Play(SoundIndex.WraithGripEnd);
                            break;

                        #endregion

                        

                        

                        

                        

                        

                        

                        

                        

                        

                        

                        

                        

                        

                        

                        

                        

                        

                        

                        

                        

                        

                        

                        

                        

                        

                        



                        #region Sword of Vengeance

                        case MagicType.SwordOfVengeance:
                            foreach (Point point in MagicLocations)
                            {
                                spell = new MirEffect(900, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx6, 50, 80, CartoonGlobals.FireColour)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                };

                                
                            }

                            DXSoundManager.Play(SoundIndex.IceStormStart);
                            break;

                        #endregion

                        #endregion

                        #region Fire Ball

                        case MagicType.PinkFireBall:
                            foreach (Point point in MagicLocations)
                            {
                                Effects.Add(spell = new MirProjectile(1500, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MonMagicEx20, 35, 35, Color.Purple, CurrentLocation)
                                {
                                    Blend = true,
                                    Direction = action.Direction,
                                    MapTarget = point,
                                });
                                spell.Process();
                            }

                            foreach (MapObject attackTarget in AttackTargets)
                            {
                                Effects.Add(spell = new MirProjectile(1600, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MonMagicEx20, 35, 35, Color.Purple, CurrentLocation)
                                {
                                    Blend = true,
                                    Target = attackTarget,
                                    Has16Directions = false,
                                });

                                spell.CompleteAction = () =>
                                {
                                    attackTarget.Effects.Add(spell = new MirEffect(1700, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MonMagicEx20, 35, 35, Color.Purple)
                                    {
                                        Blend = true,
                                        Target = attackTarget,
                                        Direction = action.Direction
                                    });
                                    spell.Process();

                                    DXSoundManager.Play(SoundIndex.FireBallEnd);
                                };

                                spell.Process();
                            }

                            if (MagicLocations.Count > 0 || AttackTargets.Count > 0)
                                DXSoundManager.Play(SoundIndex.FireBallTravel);
                            break;

                        #endregion
                        #region Fire Ball

                        case MagicType.GreenSludgeBall:
                            foreach (Point point in MagicLocations)
                            {
                                Effects.Add(spell = new MirProjectile(2600, 7, TimeSpan.FromMilliseconds(100), LibraryFile.MonMagicEx23, 35, 35, Color.GreenYellow, CurrentLocation)
                                {
                                    Blend = true,
                                    Direction = action.Direction,
                                    MapTarget = point,
                                });
                                spell.Process();
                            }

                            foreach (MapObject attackTarget in AttackTargets)
                            {
                                Effects.Add(spell = new MirProjectile(2600, 7, TimeSpan.FromMilliseconds(100), LibraryFile.MonMagicEx23, 35, 35, Color.GreenYellow, CurrentLocation)
                                {
                                    Blend = true,
                                    Target = attackTarget,
                                    Has16Directions = false,
                                });

                                spell.CompleteAction = () =>
                                {
                                    attackTarget.Effects.Add(spell = new MirEffect(2780, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MonMagicEx23, 35, 35, Color.GreenYellow)
                                    {
                                        Blend = true,
                                        Target = attackTarget,
                                        Direction = action.Direction
                                    });
                                    spell.Process();

                                    DXSoundManager.Play(SoundIndex.FireBallEnd);
                                };

                                spell.Process();
                            }

                            if (MagicLocations.Count > 0 || AttackTargets.Count > 0)
                                DXSoundManager.Play(SoundIndex.FireBallTravel);
                            break;

                        #endregion


                        #region Monster Scortched Earth

                        case MagicType.MonsterScortchedEarth:
                            if (Config.DrawEffects && Race != ObjectType.Monster)
                                foreach (Point point in MagicLocations)
                            {
                                Effects.Add(new MirEffect(220, 1, TimeSpan.FromMilliseconds(2500), LibraryFile.ProgUse, 0, 0, CartoonGlobals.NoneColour)
                                {
                                    MapTarget = point,
                                    StartTime = CEnvir.Now.AddMilliseconds(500 + Functions.Distance(point, CurrentLocation) * 50),
                                    Opacity = 0.8F,
                                    DrawType = DrawType.Floor,
                                });

                                Effects.Add(new MirEffect(2450 + CEnvir.Random.Next(5) * 10, 10, TimeSpan.FromMilliseconds(250), LibraryFile.Magic, 0, 0, CartoonGlobals.NoneColour)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                    StartTime = CEnvir.Now.AddMilliseconds(500 + Functions.Distance(point, CurrentLocation) * 50),
                                    DrawType = DrawType.Floor,
                                });

                                Effects.Add(new MirEffect(1930, 30, TimeSpan.FromMilliseconds(50), LibraryFile.Magic, 20, 70, CartoonGlobals.FireColour)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                    StartTime = CEnvir.Now.AddMilliseconds(Functions.Distance(point, CurrentLocation) * 50),
                                    BlendRate = 1F,
                                });
                            }

                            
                            

                            break;

                        #endregion

                        #region PoisonousGolemLineAoE

                        case MagicType.PoisonousGolemLineAoE:
                            if (Config.DrawEffects)

                                foreach (Point point in MagicLocations)
                                {
                                    Effects.Add(new MirEffect(1210, 6, TimeSpan.FromMilliseconds(80), LibraryFile.MonMagicEx13, 0, 0, CartoonGlobals.NoneColour)
                                    {
                                        Blend = true,
                                        MapTarget = point,
                                        StartTime = CEnvir.Now.AddMilliseconds(Functions.Distance(point, CurrentLocation) * 50),
                                        BlendRate = 1F,
                                    });
                                    Effects.Add(new MirEffect(1230, 7, TimeSpan.FromMilliseconds(100), LibraryFile.MonMagicEx13, 0, 0, CartoonGlobals.NoneColour)
                                    {
                                        MapTarget = point,
                                        StartTime = CEnvir.Now.AddMilliseconds(Functions.Distance(point, CurrentLocation) * 50),
                                    });
                                }


                            
                            

                            break;

                        #endregion

                        #region Wolongbianfuhuojineng

                        case MagicType.Wolongbianfuhuojineng:
                            if (Config.DrawEffects)

                                foreach (Point point in MagicLocations)
                                {
                                    Effects.Add(new MirEffect(1210, 6, TimeSpan.FromMilliseconds(80), LibraryFile.MonMagicEx13, 0, 0, CartoonGlobals.NoneColour)
                                    {
                                        Blend = true,
                                        DrawColour = Color.Red,
                                        MapTarget = point,
                                        StartTime = CEnvir.Now.AddMilliseconds(Functions.Distance(point, CurrentLocation) * 50),
                                        BlendRate = 1F,
                                    });
                                    Effects.Add(new MirEffect(1230, 7, TimeSpan.FromMilliseconds(100), LibraryFile.MonMagicEx13, 0, 0, CartoonGlobals.NoneColour)
                                    {
                                        DrawColour = Color.Red,
                                        MapTarget = point,
                                        StartTime = CEnvir.Now.AddMilliseconds(Functions.Distance(point, CurrentLocation) * 50),
                                    });
                                }


                            
                            

                            break;

                        #endregion

                        #region Igyu Scorched Earth

                        case MagicType.IgyuScorchedEarth:
                            if (Config.DrawEffects)
                                foreach (Point point in MagicLocations)
                                {
                                    Effects.Add(new MirEffect(220, 1, TimeSpan.FromMilliseconds(2500), LibraryFile.ProgUse, 0, 0, CartoonGlobals.NoneColour)
                                    {
                                        MapTarget = point,
                                        StartTime = CEnvir.Now.AddMilliseconds(500 + Functions.Distance(point, CurrentLocation) * 50),
                                        Opacity = 0.8F,
                                        DrawType = DrawType.Floor,
                                    });

                                    Effects.Add(new MirEffect(2450 + CEnvir.Random.Next(5) * 10, 10, TimeSpan.FromMilliseconds(250), LibraryFile.Magic, 0, 0, CartoonGlobals.NoneColour)
                                    {
                                        Blend = true,
                                        MapTarget = point,
                                        StartTime = CEnvir.Now.AddMilliseconds(500 + Functions.Distance(point, CurrentLocation) * 50),
                                        DrawType = DrawType.Floor,
                                    });

                                    Effects.Add(new MirEffect(1430, 30, TimeSpan.FromMilliseconds(100), LibraryFile.MonMagicEx14, 20, 70, CartoonGlobals.FireColour)
                                    {
                                        Blend = true,
                                        MapTarget = point,
                                        StartTime = CEnvir.Now.AddMilliseconds(Functions.Distance(point, CurrentLocation) * 50),
                                        BlendRate = 1F,
                                    });
                                }

                            
                            

                            break;

                        #endregion

                        #region IgyuCyclone

                        case MagicType.IgyuCyclone:
                            foreach (Point point in MagicLocations)
                            {
                                spell = new MirEffect(900, 12, TimeSpan.FromMilliseconds(150), LibraryFile.MonMagicEx14, 50, 80, CartoonGlobals.FireColour)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                };

                                spell.Process();
                            }

                            
                            break;

                        #endregion

                        #region MonsterIceStorm

                        case MagicType.MonsterIceStorm:
                            foreach (Point point in MagicLocations)
                            {
                                Effects.Add(new MirEffect(6230, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MonMagicEx3, 20, 70, CartoonGlobals.IceColour)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                    BlendRate = 1F,
                                });
                            }
                            break;


                        case MagicType.MonsterThunderStorm:
                            foreach (Point point in MagicLocations)
                            {
                                Effects.Add(new MirEffect(650, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MonMagicEx5, 20, 70, CartoonGlobals.LightningColour)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                    BlendRate = 1F,
                                });
                            }
                            break;

                        #endregion

                        case MagicType.SamaGuardianFire:
                            if (Config.DrawEffects)
                                foreach (Point point in MagicLocations)
                            {
                                spell = new MirEffect(4000, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MonMagicEx9, 30, 80, CartoonGlobals.FireColour)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                };
                                spell.Process();
                            }
                            break;
                        case MagicType.SamaGuardianIce:
                            if (Config.DrawEffects)
                                foreach (Point point in MagicLocations)
                            {
                                spell = new MirEffect(4100, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MonMagicEx9, 30, 80, CartoonGlobals.IceColour)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                };
                                spell.Process();
                            }
                            break;
                        case MagicType.SamaGuardianLightning:
                            if (Config.DrawEffects)
                                foreach (Point point in MagicLocations)
                            {
                                spell = new MirEffect(4200, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MonMagicEx9, 30, 80, CartoonGlobals.LightningColour)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                };
                                spell.Process();
                            }
                            break;
                        case MagicType.SamaGuardianWind:
                            if (Config.DrawEffects)
                                foreach (Point point in MagicLocations)
                            {
                                spell = new MirEffect(4300, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MonMagicEx9, 30, 80, CartoonGlobals.WindColour)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                };
                                spell.Process();
                            }
                            break;

                        case MagicType.SamaPhoenixFire:
                            if (Config.DrawEffects)
                                foreach (Point point in MagicLocations)
                            {
                                spell = new MirEffect(4500, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MonMagicEx9, 30, 80, CartoonGlobals.FireColour)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                };
                                spell.Process();
                            }
                            break;
                        case MagicType.SamaBlackIce:
                            if (Config.DrawEffects)
                                foreach (Point point in MagicLocations)
                            {
                                spell = new MirEffect(4600, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MonMagicEx9, 30, 80, CartoonGlobals.IceColour)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                };
                                spell.Process();
                            }
                            break;
                        case MagicType.SamaBlueLightning:
                            if (Config.DrawEffects)
                                foreach (Point point in MagicLocations)
                            {
                                spell = new MirEffect(4700, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MonMagicEx9, 30, 80, CartoonGlobals.LightningColour)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                };
                                spell.Process();
                            }
                            break;
                        case MagicType.SamaWhiteWind:
                            if (Config.DrawEffects)
                                foreach (Point point in MagicLocations)
                            {
                                spell = new MirEffect(4800, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MonMagicEx9, 30, 80, CartoonGlobals.WindColour)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                };
                                spell.Process();
                            }
                            break;
                        case MagicType.SamaProphetFire:
                            

                            spell = new MirEffect(5600, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MonMagicEx9, 30, 80, CartoonGlobals.FireColour)
                            {
                                Blend = true,
                                MapTarget = CurrentLocation,
                            };
                            spell.Process();

                            break;
                        case MagicType.SamaProphetLightning:
                            

                            spell = new MirEffect(5200, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MonMagicEx9, 30, 80, CartoonGlobals.LightningColour)
                            {
                                Blend = true,
                                MapTarget = CurrentLocation,
                            };
                            spell.Process();

                            break;
                        case MagicType.SamaProphetWind:
                            

                            spell = new MirEffect(5400, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MonMagicEx9, 30, 80, CartoonGlobals.WindColour)
                            {
                                Blend = true,
                                MapTarget = CurrentLocation,
                            };
                            spell.Process();

                            break;
                    }

                    break;
            }

            MoveDistance = 0;

            SetFrame(action);

            Direction = action.Direction;
            CurrentLocation = action.Location;

            
            
            ChongzhuangYinEnd();
            AssaultEnd();
            List<uint> targets;

            if (action.Action != MirAction.Standing)
                ChannellingMagicEnd();

            switch (action.Action)
            {
                case MirAction.Mining:
                    MiningEffect = (bool)action.Extra[0];
                    break;
                case MirAction.Moving:
                    MoveDistance = (int)action.Extra[0];
                    MagicType = (MagicType)action.Extra[1];

                    switch (MagicType)
                    {
                        case MagicType.Assault:
                            DXSoundManager.Play(SoundIndex.AssaultStart);
                            AssaultCreate();
                            break;
                    }

                    break;
                case MirAction.Standing:

                    bool hasdragonrepulse = VisibleBuffs.Contains(BuffType.DragonRepulse);
                    bool haselementalhurricane = VisibleBuffs.Contains(BuffType.ElementalHurricane);
                    if (!hasdragonrepulse && !haselementalhurricane)
                    {
                        if (ChannellingMagicEffect != null)
                            ChannellingMagicEnd();
                        break;
                    }

                    if (ChannellingMagicEffect == null)
                        ChannellingMagicCreate();
                    else if (haselementalhurricane && ChannellingMagicEffect != null)
                        ChannellingMagicEffect.Direction = Direction;

                    break;
                case MirAction.Pushed:
                    MoveDistance = 1;
                    break;
                case MirAction.RangeAttack:

                    targets = (List<uint>)action.Extra[0];
                    AttackTargets = new List<MapObject>();
                    foreach (uint target in targets)
                    {
                        MapObject attackTarget = GameScene.Game.MapControl.Objects.FirstOrDefault(x => x.ObjectID == target);
                        if (attackTarget == null) continue;
                        AttackTargets.Add(attackTarget);
                    }
                    break;
                /*case MirAction.Struck:
                    if (VisibleBuffs.Contains(BuffType.MagicShield))
                        MagicShieldStruck();

                    if (VisibleBuffs.Contains(BuffType.CelestialLight))
                        CelestialLightStruck();


                    AttackerID = (uint)action.Extra[0];

                    Element element = (Element)action.Extra[1];
                    switch (element)
                    {
                        case Element.None:
                            Effects.Add(new MirEffect(930, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 10, 30, CartoonGlobals.NoneColour)
                            {
                                Blend = true,
                                Target = this,
                            });
                            break;
                        case Element.Fire:
                            Effects.Add(new MirEffect(790, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 10, 30, CartoonGlobals.FireColour)
                            {
                                Blend = true,
                                Target = this,
                            });
                            break;
                        case Element.Ice:
                            Effects.Add(new MirEffect(810, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 10, 30, CartoonGlobals.IceColour)
                            {
                                Blend = true,
                                Target = this,
                            });
                            break;
                        case Element.Lightning:
                            Effects.Add(new MirEffect(830, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 10, 30, CartoonGlobals.LightningColour)
                            {
                                Blend = true,
                                Target = this,
                            });
                            break;
                        case Element.Wind:
                            Effects.Add(new MirEffect(850, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 10, 30, CartoonGlobals.WindColour)
                            {
                                Blend = true,
                                Target = this,
                            });
                            break;
                        case Element.Holy:
                            Effects.Add(new MirEffect(870, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 10, 30, CartoonGlobals.HolyColour)
                            {
                                Blend = true,
                                Target = this,
                            });
                            break;
                        case Element.Dark:
                            Effects.Add(new MirEffect(890, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 10, 30, CartoonGlobals.DarkColour)
                            {
                                Blend = true,
                                Target = this,
                            });
                            break;
                        case Element.Phantom:
                            Effects.Add(new MirEffect(910, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 10, 30, CartoonGlobals.PhantomColour)
                            {
                                Blend = true,
                                Target = this,
                            });
                            break;
                    }


                    break;*/
                case MirAction.Attack:
                    MagicType = (MagicType)action.Extra[1];
                    AttackElement = (Element)action.Extra[2];

                    Color attackColour = CartoonGlobals.NoneColour;
                    switch (AttackElement)
                    {
                        case Element.Fire:
                            attackColour = CartoonGlobals.FireColour;
                            break;
                        case Element.Ice:
                            attackColour = CartoonGlobals.IceColour;
                            break;
                        case Element.Lightning:
                            attackColour = CartoonGlobals.LightningColour;
                            break;
                        case Element.Wind:
                            attackColour = CartoonGlobals.WindColour;
                            break;
                        case Element.Holy:
                            attackColour = CartoonGlobals.HolyColour;
                            break;
                        case Element.Dark:
                            attackColour = CartoonGlobals.DarkColour;
                            break;
                        case Element.Phantom:
                            attackColour = CartoonGlobals.PhantomColour;
                            break;
                    }

                    switch (MagicType)
                    {
                        case MagicType.None:
                            if (Race != ObjectType.Player || CurrentAnimation != MirAnimation.Combat3 || AttackElement == Element.None) break;

                            Effects.Add(new MirEffect(1090, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 10, 25, attackColour) 
                            {
                                Blend = true,
                                Target = this,
                                Direction = action.Direction,
                                DrawColour = attackColour
                            });
                            break;

                        #region 精神力战法
                        
                        
                        case MagicType.SpiritSword:
                            if (Mingwen01 == 5 || Mingwen02 == 5 || Mingwen03 == 5)
                            {
                                Effects.Add(new MirEffect(1350, 6, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 10, 50, attackColour) 
                                {
                                    Blend = true,
                                    Target = this,
                                    Direction = action.Direction,
                                    DrawColour = attackColour
                                });
                                if (Gender == MirGender.Male)
                                    DXSoundManager.Play(SoundIndex.SlayingMale);
                                else
                                    DXSoundManager.Play(SoundIndex.SlayingFemale);
                            }
                            else { }
                            break;
                        #endregion

                        #region 基本剑法
                        case MagicType.Swordsmanship:
                            
                            
                            if (Mingwen01 == 133 || Mingwen02 == 133 || Mingwen03 == 133)
                            {
                                Effects.Add(new MirEffect(290, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx10, 20, 70, CartoonGlobals.NoneColour) 
                                {
                                    Blend = true,
                                    Target = this,
                                    Direction = action.Direction,
                                    
                                });
                                DXSoundManager.Play(SoundIndex.HalfMoon);
                            }
                            else { }

                            break;

                        #endregion

                        #region Slaying
                        case MagicType.Slaying:
                            
                            
                            if (!GameScene.Game.User.CanxueshaYinAttack)
                            {
                                Effects.Add(new MirEffect(1350, 6, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 10, 50, attackColour) 
                                {
                                    Blend = true,
                                    Target = this,
                                    Direction = action.Direction,
                                    DrawColour = attackColour
                                });
                            }
                            else if (GameScene.Game.User.CanxueshaYinAttack && Mingwen01 == 139 || Mingwen02 == 139 || Mingwen03 == 139)
                            {
                                Effects.Add(new MirEffect(470, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx10, 10, 50, CartoonGlobals.NoneColour) 
                                {
                                    Blend = true,
                                    Target = this,
                                    Direction = action.Direction,
                                    
                                });
                            }

                            if (Gender == MirGender.Male)
                                DXSoundManager.Play(SoundIndex.SlayingMale);
                            else
                                DXSoundManager.Play(SoundIndex.SlayingFemale);
                            break;

                        #endregion

                        #region Thrusting

                        case MagicType.Thrusting:
                            Effects.Add(new MirEffect(0, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx3, 20, 70, attackColour) 
                            {
                                Blend = true,
                                Target = this,
                                Direction = action.Direction,
                                DrawColour = attackColour,
                            });
                            DXSoundManager.Play(SoundIndex.EnergyBlast);
                            break;

                        #endregion

                        #region Half Moon

                        case MagicType.HalfMoon:
                            
                            
                            if (!GameScene.Game.User.CanguanyueYinAttack)
                            {
                                Effects.Add(new MirEffect(230, 6, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 20, 70, attackColour) 
                                {
                                    Blend = true,
                                    Target = this,
                                    Direction = action.Direction,
                                    DrawColour = attackColour
                                });
                            }
                            else if (GameScene.Game.User.CanguanyueYinAttack && Mingwen01 == 144 || Mingwen02 == 144 || Mingwen03 == 144)
                            {
                                Effects.Add(new MirEffect(290, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx10, 20, 70, CartoonGlobals.NoneColour) 
                                {
                                    Blend = true,
                                    Target = this,
                                    Direction = action.Direction,
                                    
                                });
                            }
                            DXSoundManager.Play(SoundIndex.HalfMoon);
                            break;

                        #endregion

                        #region Destructive Surge

                        case MagicType.DestructiveSurge:

                            Effects.Add(new MirEffect(1420, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx2, 20, 70, attackColour) 
                            {
                                Blend = true,
                                Target = this,
                                DrawColour = attackColour
                            });
                            DXSoundManager.Play(SoundIndex.DestructiveBlow);
                            break;

                        #endregion

                        #region Flaming Sword

                        case MagicType.FlamingSword:
                            Effects.Add(new MirEffect(1470, 6, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 10, 50, CartoonGlobals.FireColour) 
                            {
                                Blend = true,
                                Target = this,
                                Direction = action.Direction,
                            });

                            DXSoundManager.Play(SoundIndex.FlamingSword);
                            break;

                        #endregion

                        #region Dragon Rise

                        case MagicType.DragonRise:
                            if (!GameScene.Game.User.CanShenquYinAttack && !GameScene.Game.User.CanShenglongYinAttack)
                            {
                                Effects.Add(new MirEffect(2180, 10, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 20, 70, attackColour) 
                                {
                                    Blend = true,
                                    Target = this,
                                    Direction = action.Direction,
                                    DrawColour = attackColour,
                                    
                                });
                            }
                            
                            
                            else if (GameScene.Game.User.CanShenquYinAttack && Mingwen01 == 155 || Mingwen02 == 155 || Mingwen03 == 155)
                            {
                                Effects.Add(new MirEffect(740, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx10, 20, 70, CartoonGlobals.NoneColour) 
                                {
                                    Blend = true,
                                    Target = this,
                                    Direction = action.Direction,
                                    
                                    
                                });
                            }
                            
                            
                            else if (GameScene.Game.User.CanShenglongYinAttack && Mingwen01 == 156 || Mingwen02 == 156 || Mingwen03 == 156)
                            {
                                Effects.Add(new MirEffect(650, 8, TimeSpan.FromMilliseconds(120), LibraryFile.MagicEx10, 40, 90, CartoonGlobals.NoneColour) 
                                {
                                    Blend = true,
                                    Target = this,
                                    Direction = action.Direction,
                                    StartTime = CEnvir.Now.AddMilliseconds(500)
                                });
                            }

                            DXSoundManager.Play(SoundIndex.DragonRise);
                            break;

                        #endregion

                        #region Blade Storm

                        case MagicType.BladeStorm:
                            Effects.Add(new MirEffect(1780, 10, TimeSpan.FromMilliseconds(60), LibraryFile.MagicEx, 20, 70, attackColour) 
                            {
                                Blend = true,
                                Target = this,
                                Direction = action.Direction,
                                DrawColour = attackColour,
                            });

                            DXSoundManager.Play(SoundIndex.BladeStorm);
                            break;

                        #endregion

                        #region Flame Splash

                        case MagicType.FlameSplash:
                            Effects.Add(new MirEffect(900, 8, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx4, 20, 70, CartoonGlobals.FireColour) 
                            {
                                Blend = true,
                                Target = this,
                            });

                            DXSoundManager.Play(SoundIndex.BladeStorm);
                            break;

                        #endregion

                        #region Dance Of Swallow

                        case MagicType.DanceOfSwallow:
                            break;

                            #endregion

                    }
                    break;
                case MirAction.Spell:
                    MagicType = (MagicType)action.Extra[0];

                    targets = (List<uint>)action.Extra[1];
                    AttackTargets = new List<MapObject>();
                    foreach (uint target in targets)
                    {
                        MapObject attackTarget = GameScene.Game.MapControl.Objects.FirstOrDefault(x => x.ObjectID == target);
                        if (attackTarget == null) continue;
                        AttackTargets.Add(attackTarget);
                    }
                    MagicLocations = (List<Point>)action.Extra[2];
                    MagicCast = (bool)action.Extra[3];

                    Point location;
                    switch (MagicType)
                    {

                        #region Warrior
                        

                        

                        

                        

                        

                        

                        

                        

                        

                        

                        #region Interchange

                        case MagicType.Interchange:
                            Effects.Add(new MirEffect(0, 9, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx2, 60, 60, CartoonGlobals.NoneColour)
                            {
                                Blend = true,
                                Target = this,
                            });
                            DXSoundManager.Play(SoundIndex.TeleportationStart);
                            break;

                        #endregion

                        #region Defiance

                        case MagicType.Defiance:
                        case MagicType.Invincibility:
                            Effects.Add(new MirEffect(40, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx2, 60, 60, CartoonGlobals.NoneColour)
                            {
                                Blend = true,
                                Target = this,
                            });
                            DXSoundManager.Play(SoundIndex.DefianceStart);
                            break;

                        #endregion

                        #region Beckon

                        case MagicType.Beckon:
                        case MagicType.MassBeckon:
                            Effects.Add(new MirEffect(580, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx2, 60, 60, CartoonGlobals.NoneColour)
                            {
                                Blend = true,
                                Target = this,
                                Direction = action.Direction
                            });
                            DXSoundManager.Play(SoundIndex.TeleportationStart);
                            break;

                        #endregion

                        #region Might

                        case MagicType.Might:
                            Effects.Add(new MirEffect(60, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx2, 60, 60, CartoonGlobals.NoneColour)
                            {
                                Blend = true,
                                Target = this,
                            });
                            DXSoundManager.Play(SoundIndex.DragonRise); 
                            break;

                        #endregion

                        #region Lightning Beam

                        case MagicType.SeismicSlam:
                            
                            
                            if (GameScene.Game.User.CanZhanchuiYinAttack && Mingwen01 == 167 || Mingwen02 == 167 || Mingwen03 == 167)
                            {
                                GameScene.Game.User.ZhanchuiYin = true;
                                Effects.Add(spell = new MirEffect(4900, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx5, 10, 35, CartoonGlobals.FireColour)
                                {
                                    Blend = true,
                                    Target = this,
                                    Direction = action.Direction,
                                });
                            }
                            
                            
                            else if (GameScene.Game.User.CanTianshenYinAttack && Mingwen01 == 168 || Mingwen02 == 168 || Mingwen03 == 168)
                            {
                                GameScene.Game.User.TianshenYin = true;
                                Effects.Add(spell = new MirEffect(1090, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx10, 10, 35, CartoonGlobals.NoneColour)
                                {
                                    Blend = true,
                                    Target = this,
                                    Direction = action.Direction,
                                });
                            }
                            else
                            {
                                Effects.Add(spell = new MirEffect(4900, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx5, 10, 35, CartoonGlobals.LightningColour)
                                {
                                    Blend = true,
                                    Target = this,
                                    Direction = action.Direction,
                                });
                            }
                            break;

                        #endregion

                        #region Crushing Wave

                        case MagicType.CrushingWave:
                            Effects.Add(spell = new MirEffect(100, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx6, 0, 0, CartoonGlobals.LightningColour)
                            {
                                Blend = true,
                                Target = this,
                                Direction = action.Direction,
                            });
                            break;

                        #endregion

                        

                        

                        

                        #region Reflect Damage

                        case MagicType.ReflectDamage:
                            Effects.Add(new MirEffect(1220, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx2, 60, 60, CartoonGlobals.NoneColour)
                            {
                                Blend = true,
                                Target = this
                            });
                            DXSoundManager.Play(SoundIndex.DefianceStart);
                            break;

                        #endregion

                        #region Fetter

                        case MagicType.Fetter:
                            Effects.Add(new MirEffect(2370, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx2, 60, 60, CartoonGlobals.NoneColour)
                            {
                                Blend = true,
                                Target = this
                            });
                            break;

                        #endregion

                        #endregion
                            
                        #region Wizard

                        #region Fire Ball

                        case MagicType.FireBall:
                            Effects.Add(spell = new MirEffect(1820, 8, TimeSpan.FromMilliseconds(70), LibraryFile.Magic, 10, 35, CartoonGlobals.FireColour)
                            {
                                Blend = true,
                                Target = this,
                                Direction = action.Direction
                            });

                            DXSoundManager.Play(SoundIndex.FireBallStart);
                            break;

                        #endregion

                        #region Lightning Ball

                        case MagicType.LightningBall:
                            Effects.Add(spell = new MirEffect(2990, 6, TimeSpan.FromMilliseconds(80), LibraryFile.Magic, 10, 35, CartoonGlobals.LightningColour)
                            {
                                Blend = true,
                                Target = this,
                                Direction = action.Direction
                            });
                            DXSoundManager.Play(SoundIndex.ThunderBoltStart);
                            break;

                        #endregion

                        #region Ice Bolt

                        case MagicType.IceBolt:
                            Effects.Add(spell = new MirEffect(2620, 6, TimeSpan.FromMilliseconds(80), LibraryFile.Magic, 10, 35, CartoonGlobals.IceColour)
                            {
                                Blend = true,
                                Target = this,
                                Direction = action.Direction
                            });

                            DXSoundManager.Play(SoundIndex.IceBoltStart);
                            break;

                        #endregion

                        #region Gust Blast

                        case MagicType.GustBlast:
                            Effects.Add(spell = new MirEffect(350, 7, TimeSpan.FromMilliseconds(50), LibraryFile.MagicEx, 10, 35, CartoonGlobals.WindColour)
                            {
                                Blend = true,
                                Target = this,
                                Direction = action.Direction
                            });
                            DXSoundManager.Play(SoundIndex.GustBlastStart);
                            break;

                        #endregion

                        case MagicType.Repulsion:
                            
                            
                            if (Mingwen01 == 98 || Mingwen02 == 98 || Mingwen03 == 98)
                            {
                                Effects.Add(new MirEffect(3560, 10, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 10, 35, CartoonGlobals.NoneColour)
                                {
                                    Blend = true,
                                    Target = this,
                                });
                            }
                            
                            
                            else if (Mingwen01 == 99 || Mingwen02 == 99 || Mingwen03 == 99)
                            {
                                Effects.Add(new MirEffect(3550, 10, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 10, 35, CartoonGlobals.NoneColour)
                                {
                                    Blend = true,
                                    Target = this,
                                });
                            }
                            else
                            {
                                Effects.Add(new MirEffect(90, 10, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 10, 35, CartoonGlobals.WindColour)
                                {
                                    Blend = true,
                                    Target = this,
                                });
                            }
                            DXSoundManager.Play(SoundIndex.RepulsionEnd);
                            break;

                        #endregion

                        #region Electric Shock

                        case MagicType.ElectricShock:
                            Effects.Add(spell = new MirEffect(0, 10, TimeSpan.FromMilliseconds(60), LibraryFile.Magic, 10, 35, CartoonGlobals.LightningColour)
                            {
                                Blend = true,
                                Target = this,
                            });
                            DXSoundManager.Play(SoundIndex.ElectricShockStart);
                            break;

                        #endregion

                        case MagicType.Teleportation:
                            
                            
                            if (Mingwen01 == 104 || Mingwen02 == 104 || Mingwen03 == 104)
                            {
                                Effects.Add(new MirEffect(3580, 10, TimeSpan.FromMilliseconds(60), LibraryFile.Magic, 10, 35, CartoonGlobals.NoneColour)
                                {
                                    Blend = true,
                                    Target = this,
                                });
                            }
                            else
                            {
                                Effects.Add(new MirEffect(110, 10, TimeSpan.FromMilliseconds(60), LibraryFile.Magic, 10, 35, CartoonGlobals.PhantomColour)
                                {
                                    Blend = true,
                                    Target = this,
                                });
                            }
                            DXSoundManager.Play(SoundIndex.TeleportationStart);
                            break;

                        #endregion

                        #region Adamantine Fire Ball & MeteorShower

                        case MagicType.AdamantineFireBall:
                        case MagicType.MeteorShower:
                            Effects.Add(spell = new MirEffect(1560, 9, TimeSpan.FromMilliseconds(65), LibraryFile.Magic, 10, 35, CartoonGlobals.FireColour)
                            {
                                Blend = true,
                                Target = this,
                                Direction = action.Direction
                            });

                            DXSoundManager.Play(SoundIndex.GreaterFireBallStart);
                            break;

                        #endregion

                        #region Thunder Bolt

                        case MagicType.ThunderBolt:
                            
                            
                            if (Mingwen01 == 108 || Mingwen02 == 108 || Mingwen03 == 108)
                            {
                                Effects.Add(spell = new MirEffect(0, 12, TimeSpan.FromMilliseconds(50), LibraryFile.MagicEx10, 10, 35, CartoonGlobals.NoneColour)
                                {
                                    Blend = true,
                                    Target = this,
                                });
                            }
                            
                            
                            else if (Mingwen01 == 109 || Mingwen02 == 109 || Mingwen03 == 109)
                            {
                                Effects.Add(spell = new MirEffect(30, 12, TimeSpan.FromMilliseconds(50), LibraryFile.MagicEx10, 10, 35, CartoonGlobals.NoneColour)
                                {
                                    Blend = true,
                                    Target = this,
                                });
                            }
                            
                            
                            else if (Mingwen01 == 110 || Mingwen02 == 110 || Mingwen03 == 110)
                            {
                                Effects.Add(spell = new MirEffect(60, 12, TimeSpan.FromMilliseconds(50), LibraryFile.MagicEx10, 10, 35, CartoonGlobals.NoneColour)
                                {
                                    Blend = true,
                                    Target = this,
                                });
                            }
                            else
                            {
                                Effects.Add(spell = new MirEffect(1430, 12, TimeSpan.FromMilliseconds(50), LibraryFile.Magic, 10, 35, CartoonGlobals.LightningColour)
                                {
                                    Blend = true,
                                    Target = this,
                                });
                            }
                            DXSoundManager.Play(SoundIndex.LightningStrikeStart);
                            break;

                        #endregion

                        #region Ice Blades

                        case MagicType.IceBlades:
                            Effects.Add(spell = new MirEffect(2880, 6, TimeSpan.FromMilliseconds(80), LibraryFile.Magic, 10, 35, CartoonGlobals.IceColour)
                            {
                                Blend = true,
                                Target = this,
                                Direction = action.Direction
                            });

                            DXSoundManager.Play(SoundIndex.GreaterIceBoltStart);
                            break;

                        #endregion

                        #region Cyclone

                        case MagicType.Cyclone:
                            Effects.Add(spell = new MirEffect(1970, 10, TimeSpan.FromMilliseconds(60), LibraryFile.MagicEx, 10, 35, CartoonGlobals.WindColour)
                            {
                                Blend = true,
                                Target = this,
                            });
                            DXSoundManager.Play(SoundIndex.CycloneStart);
                            break;

                        #endregion

                        #region Scortched Earth

                        case MagicType.ScortchedEarth:
                            if (Config.DrawEffects && Race != ObjectType.Monster)
                            {
                                Effects.Add(spell = new MirEffect(1820, 8, TimeSpan.FromMilliseconds(60), LibraryFile.Magic, 10, 35, CartoonGlobals.FireColour)
                                {
                                    Blend = true,
                                    Target = this,
                                    Direction = action.Direction,
                                });
                                DXSoundManager.Play(SoundIndex.LavaStrikeStart);
                            }

                            break;

                        #endregion

                        #region Lightning Beam

                        case MagicType.LightningBeam:
                            Effects.Add(spell = new MirEffect(1970, 10, TimeSpan.FromMilliseconds(30), LibraryFile.Magic, 10, 35, CartoonGlobals.LightningColour)
                            {
                                Blend = true,
                                Target = this,
                                Direction = action.Direction
                            });
                            break;

                        #endregion

                        #region Frozen Earth

                        case MagicType.FrozenEarth:
                            Effects.Add(spell = new MirEffect(0, 10, TimeSpan.FromMilliseconds(50), LibraryFile.MagicEx, 10, 35, CartoonGlobals.IceColour)
                            {
                                Blend = true,
                                Target = this,
                                Direction = action.Direction
                            });
                            DXSoundManager.Play(SoundIndex.FrozenEarthStart);
                            break;

                        #endregion

                        #region Blow Earth

                        case MagicType.BlowEarth:
                            Effects.Add(spell = new MirEffect(1970, 10, TimeSpan.FromMilliseconds(60), LibraryFile.MagicEx, 10, 35, CartoonGlobals.WindColour)
                            {
                                Blend = true,
                                Target = this,
                            });
                            DXSoundManager.Play(SoundIndex.BlowEarthStart);
                            break;

                        #endregion

                        #region Fire Wall

                        case MagicType.FireWall:
                            Effects.Add(new MirEffect(910, 10, TimeSpan.FromMilliseconds(60), LibraryFile.Magic, 10, 35, CartoonGlobals.FireColour)
                            {
                                Blend = true,
                                Target = this,
                            });
                            DXSoundManager.Play(SoundIndex.FireWallStart);
                            break;

                        #endregion

                        #region Expel Undead

                        case MagicType.ExpelUndead:
                            Effects.Add(spell = new MirEffect(130, 10, TimeSpan.FromMilliseconds(60), LibraryFile.Magic, 10, 35, CartoonGlobals.PhantomColour)
                            {
                                Blend = true,
                                Target = this,
                            });
                            DXSoundManager.Play(SoundIndex.ExpelUndeadStart);
                            break;

                        #endregion

                        #region GeoManipulation

                        case MagicType.GeoManipulation:
                            
                            
                            if (Mingwen01 == 125 || Mingwen02 == 125 || Mingwen03 == 125)
                            {
                                Effects.Add(new MirEffect(3580, 10, TimeSpan.FromMilliseconds(60), LibraryFile.Magic, 10, 35, CartoonGlobals.NoneColour)
                                {
                                    Blend = true,
                                    Target = this,
                                });
                            }
                            else
                            {
                                Effects.Add(new MirEffect(110, 10, TimeSpan.FromMilliseconds(60), LibraryFile.Magic, 10, 35, CartoonGlobals.PhantomColour)
                                {
                                    Blend = true,
                                    Target = this,
                                });
                            }
                            DXSoundManager.Play(SoundIndex.TeleportationStart);
                            break;

                        #endregion

                        #region Magic Shield

                        case MagicType.MagicShield:
                            
                            
                            if (Mingwen01 == 126 || Mingwen02 == 126 || Mingwen03 == 126)
                            {
                                Effects.Add(new MirEffect(190, 19, TimeSpan.FromMilliseconds(60), LibraryFile.MagicEx10, 10, 35, CartoonGlobals.NoneColour)
                                {
                                    Blend = true,
                                    Target = this,
                                });
                            }
                            
                            
                            else if (Mingwen01 == 127 || Mingwen02 == 127 || Mingwen03 == 127)
                            {
                                Effects.Add(new MirEffect(220, 19, TimeSpan.FromMilliseconds(60), LibraryFile.MagicEx10, 10, 35, CartoonGlobals.NoneColour)
                                {
                                    Blend = true,
                                    Target = this,
                                });
                            }
                            
                            
                            else if (Mingwen01 == 128 || Mingwen02 == 128 || Mingwen03 == 128)
                            {
                                Effects.Add(new MirEffect(250, 19, TimeSpan.FromMilliseconds(60), LibraryFile.MagicEx10, 10, 35, CartoonGlobals.NoneColour)
                                {
                                    Blend = true,
                                    Target = this,
                                });
                            }
                            else
                            {
                                Effects.Add(new MirEffect(830, 19, TimeSpan.FromMilliseconds(60), LibraryFile.Magic, 10, 35, CartoonGlobals.PhantomColour)
                                {
                                    Blend = true,
                                    Target = this,
                                });
                            }
                            DXSoundManager.Play(SoundIndex.MagicShieldStart);
                            break;

                        #endregion

                        #region Fire Storm

                        case MagicType.FireStorm:
                            Effects.Add(spell = new MirEffect(940, 10, TimeSpan.FromMilliseconds(60), LibraryFile.Magic, 10, 35, CartoonGlobals.FireColour)
                            {
                                Blend = true,
                                Target = this,
                            });
                            DXSoundManager.Play(SoundIndex.FireStormStart);
                            break;

                        #endregion

                        #region Lightning Wave

                        case MagicType.LightningWave:
                            
                            
                            if (Mingwen01 == 130 || Mingwen02 == 130 || Mingwen03 == 130)
                            {
                                Effects.Add(spell = new MirEffect(60, 12, TimeSpan.FromMilliseconds(50), LibraryFile.MagicEx10, 10, 35, CartoonGlobals.NoneColour)
                                {
                                    Blend = true,
                                    Target = this
                                });
                            }
                            else
                            {
                                Effects.Add(spell = new MirEffect(1430, 12, TimeSpan.FromMilliseconds(50), LibraryFile.Magic, 10, 35, CartoonGlobals.LightningColour)
                                {
                                    Blend = true,
                                    Target = this
                                });
                            }
                            DXSoundManager.Play(SoundIndex.LightningWaveStart);
                            break;

                        #endregion

                        #region Ice Storm

                        case MagicType.IceStorm:
                            Effects.Add(spell = new MirEffect(770, 10, TimeSpan.FromMilliseconds(60), LibraryFile.Magic, 10, 35, CartoonGlobals.IceColour)
                            {
                                Blend = true,
                                Target = this,
                            });
                            DXSoundManager.Play(SoundIndex.IceStormStart);
                            break;

                        #endregion

                        #region DragonTornado

                        case MagicType.DragonTornado:
                            Effects.Add(spell = new MirEffect(1030, 10, TimeSpan.FromMilliseconds(60), LibraryFile.MagicEx, 10, 35, CartoonGlobals.WindColour)
                            {
                                Blend = true,
                                Target = this,
                            });
                            DXSoundManager.Play(SoundIndex.DragonTornadoStart);
                            break;

                        #endregion

                        #region Greater Frozen Earth

                        case MagicType.GreaterFrozenEarth:
                            Effects.Add(spell = new MirEffect(0, 10, TimeSpan.FromMilliseconds(50), LibraryFile.MagicEx, 10, 35, CartoonGlobals.IceColour)
                            {
                                Blend = true,
                                Target = this,
                                Direction = action.Direction
                            });
                            DXSoundManager.Play(SoundIndex.GreaterFrozenEarthStart);
                            break;

                        #endregion

                        #region Chain Lightning

                        case MagicType.ChainLightning:
                            
                            
                            if (Mingwen01 == 188 || Mingwen02 == 188 || Mingwen03 == 188)
                            {
                                Effects.Add(spell = new MirEffect(60, 12, TimeSpan.FromMilliseconds(50), LibraryFile.MagicEx10, 10, 35, CartoonGlobals.NoneColour)
                                {
                                    Blend = true,
                                    Target = this
                                });
                            }
                            else
                            {
                                Effects.Add(spell = new MirEffect(1430, 12, TimeSpan.FromMilliseconds(50), LibraryFile.Magic, 10, 35, CartoonGlobals.LightningColour)
                                {
                                    Blend = true,
                                    Target = this
                                });
                            }
                            DXSoundManager.Play(SoundIndex.ChainLightningStart);
                            break;

                        #endregion

                        

                        #region Renounce

                        case MagicType.Renounce:
                            Effects.Add(new MirEffect(80, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx2, 10, 35, CartoonGlobals.PhantomColour)
                            {
                                Blend = true,
                                Target = this,
                            });
                            DXSoundManager.Play(SoundIndex.DefianceStart);
                            break;

                        #endregion

                        #region Tempest

                        case MagicType.Tempest:
                            Effects.Add(new MirEffect(910, 10, TimeSpan.FromMilliseconds(60), LibraryFile.MagicEx2, 10, 35, CartoonGlobals.WindColour)
                            {
                                Blend = true,
                                Target = this,
                            });
                            DXSoundManager.Play(SoundIndex.BlowEarthStart);
                            break;

                        #endregion

                        #region Judgement Of Heaven

                        case MagicType.JudgementOfHeaven:
                            DXSoundManager.Play(SoundIndex.LightningStrikeEnd);
                            break;

                        #endregion

                        #region Thunder Strike

                        case MagicType.ThunderStrike:
                            DXSoundManager.Play(SoundIndex.LightningStrikeStart);
                            break;

                        #endregion

                        #region Mirror Image

                        case MagicType.MirrorImage:
                            DXSoundManager.Play(SoundIndex.ShacklingTalismanStart);
                            break;

                        #endregion


                        #region Frost Bite

                        case MagicType.FrostBite:
                            Effects.Add(new MirEffect(500, 16, TimeSpan.FromMilliseconds(60), LibraryFile.MagicEx5, 10, 35, CartoonGlobals.IceColour)
                            {
                                Blend = true,
                                Target = this,
                            });
                            DXSoundManager.Play(SoundIndex.FrostBiteStart);
                            break;

                        #endregion



                        #region Superior Magic Shield

                        case MagicType.SuperiorMagicShield:
                            Effects.Add(new MirEffect(1900, 17, TimeSpan.FromMilliseconds(60), LibraryFile.MagicEx2, 10, 35, CartoonGlobals.FireColour)
                            {
                                Blend = true,
                                Target = this,
                            });
                            DXSoundManager.Play(SoundIndex.MagicShieldStart);
                            break;

                        #endregion

                        #region Taoist

                        #region Heal

                        
                        
                        case MagicType.Heal:
                            if (Mingwen01 == 1 || Mingwen02 == 1 || Mingwen03 == 1)
                            {
                                Effects.Add(spell = new MirEffect(660, 10, TimeSpan.FromMilliseconds(60), LibraryFile.Magic, 10, 35, CartoonGlobals.FireColour)
                                {
                                    Blend = true,
                                    Target = this,
                                });
                            }
                            else
                            {
                                Effects.Add(spell = new MirEffect(660, 10, TimeSpan.FromMilliseconds(60), LibraryFile.Magic, 10, 35, CartoonGlobals.HolyColour)
                                {
                                    Blend = true,
                                    Target = this,
                                });
                            }
                            DXSoundManager.Play(SoundIndex.HealStart);
                            break;

                        #endregion

                        

                        #region Poison Dust

                        case MagicType.PoisonDust:
                            Effects.Add(spell = new MirEffect(60, 10, TimeSpan.FromMilliseconds(60), LibraryFile.Magic, 10, 35, CartoonGlobals.DarkColour)
                            {
                                Blend = true,
                                Target = this,
                            });
                            DXSoundManager.Play(SoundIndex.PoisonDustStart);
                            break;

                        #endregion

                        #region Explosive Talisman

                        case MagicType.ExplosiveTalisman:
                            Effects.Add(spell = new MirEffect(2080, 6, TimeSpan.FromMilliseconds(80), LibraryFile.Magic, 10, 35, CartoonGlobals.DarkColour)
                            {
                                Blend = true,
                                Target = this,
                                Direction = action.Direction
                            });

                            DXSoundManager.Play(SoundIndex.ExplosiveTalismanStart);
                            break;

                        #endregion

                        #region Evil Slayer

                        case MagicType.EvilSlayer:
                            Effects.Add(spell = new MirEffect(3250, 6, TimeSpan.FromMilliseconds(80), LibraryFile.Magic, 10, 35, CartoonGlobals.HolyColour)
                            {
                                Blend = true,
                                Target = this,
                                Direction = action.Direction
                            });

                            DXSoundManager.Play(SoundIndex.HolyStrikeStart);
                            break;

                        #endregion

                        #region Summon Skeleton & Summon Jin Skeleton

                        case MagicType.SummonSkeleton:
                        case MagicType.SummonJinSkeleton:
                        case MagicType.Scarecrow:
                            for (int i = 0; i < 5; i++)
                            {
                                Effects.Add(new MirEffect(740, 10, TimeSpan.FromMilliseconds(60), LibraryFile.Magic, 10, 35, CartoonGlobals.PhantomColour)
                                {
                                    Blend = true,
                                    Target = this,
                                });
                            }
                            DXSoundManager.Play(SoundIndex.SummonSkeletonStart);
                            break;

                        #endregion

                        #region Invisibility

                        case MagicType.Invisibility:
                            Effects.Add(new MirEffect(810, 10, TimeSpan.FromMilliseconds(60), LibraryFile.Magic, 10, 35, CartoonGlobals.PhantomColour)
                            {
                                Blend = true,
                                Target = this,
                            });
                            DXSoundManager.Play(SoundIndex.InvisibilityEnd);
                            break;

                        #endregion

                        #region Magic Resistance

                        case MagicType.MagicResistance:
                            Effects.Add(spell = new MirEffect(2080, 6, TimeSpan.FromMilliseconds(80), LibraryFile.Magic, 10, 35, CartoonGlobals.NoneColour)
                            {
                                Blend = true,
                                Target = this,
                                Direction = action.Direction
                            });
                            break;

                        #endregion

                        #region Mass Invisibility

                        case MagicType.MassInvisibility:
                            Effects.Add(spell = new MirEffect(2080, 6, TimeSpan.FromMilliseconds(80), LibraryFile.Magic, 10, 35, CartoonGlobals.PhantomColour)
                            {
                                Blend = true,
                                Target = this,
                                Direction = action.Direction
                            });

                            break;

                        #endregion

                        #region Greater Evil Slayer

                        case MagicType.GreaterEvilSlayer:
                            Effects.Add(spell = new MirEffect(3360, 6, TimeSpan.FromMilliseconds(80), LibraryFile.Magic, 10, 35, CartoonGlobals.HolyColour)
                            {
                                Blend = true,
                                Target = this,
                                Direction = action.Direction
                            });

                            DXSoundManager.Play(SoundIndex.ImprovedHolyStrikeStart);
                            break;

                        #endregion

                        #region Resilience

                        case MagicType.Resilience:
                            Effects.Add(spell = new MirEffect(2080, 6, TimeSpan.FromMilliseconds(80), LibraryFile.Magic, 10, 35, CartoonGlobals.NoneColour)
                            {
                                Blend = true,
                                Target = this,
                                Direction = action.Direction
                            });
                            break;

                        #endregion

                        #region Trap Octagon

                        case MagicType.TrapOctagon:
                            Effects.Add(spell = new MirEffect(630, 10, TimeSpan.FromMilliseconds(60), LibraryFile.Magic, 10, 35, CartoonGlobals.DarkColour)
                            {
                                Blend = true,
                                Target = this,
                            });

                            DXSoundManager.Play(SoundIndex.ShacklingTalismanStart);
                            break;

                        #endregion

                        #region Taoist Combat Kick

                        case MagicType.TaoistCombatKick:
                            DXSoundManager.Play(SoundIndex.TaoistCombatKickStart);
                            break;

                        #endregion

                        #region Elemental Superiority

                        case MagicType.ElementalSuperiority:
                            Effects.Add(spell = new MirEffect(2080, 6, TimeSpan.FromMilliseconds(80), LibraryFile.Magic, 10, 35, CartoonGlobals.NoneColour)
                            {
                                Blend = true,
                                Target = this,
                                Direction = action.Direction
                            });

                            break;

                        #endregion

                        #region Summon Shinsu
                        case MagicType.SummonShinsu:
                            Effects.Add(new MirEffect(2590, 19, TimeSpan.FromMilliseconds(60), LibraryFile.Magic, 10, 35, CartoonGlobals.PhantomColour)
                            {
                                Target = this,
                            });
                            DXSoundManager.Play(SoundIndex.SummonShinsuStart);
                            break;
                        #endregion

                        #region Mass Heal

                        case MagicType.MassHeal:
                            Effects.Add(spell = new MirEffect(660, 10, TimeSpan.FromMilliseconds(60), LibraryFile.Magic, 10, 35, CartoonGlobals.HolyColour)
                            {
                                Blend = true,
                                Target = this,
                            });
                            DXSoundManager.Play(SoundIndex.MassHealStart);
                            break;

                        #endregion

                        

                        #region Blood Lust

                        case MagicType.BloodLust:
                            Effects.Add(spell = new MirEffect(2080, 6, TimeSpan.FromMilliseconds(80), LibraryFile.Magic, 10, 35, CartoonGlobals.DarkColour)
                            {
                                Blend = true,
                                Target = this,
                                Direction = action.Direction
                            });
                            break;

                        #endregion

                        #region Resurrection

                        case MagicType.Resurrection:
                            Effects.Add(spell = new MirEffect(310, 10, TimeSpan.FromMilliseconds(60), LibraryFile.MagicEx, 60, 60, CartoonGlobals.HolyColour)
                            {
                                Blend = true,
                                Target = this,
                            });
                            DXSoundManager.Play(SoundIndex.ResurrectionStart);
                            break;

                        #endregion

                        #region Purification

                        case MagicType.Purification:
                            Effects.Add(spell = new MirEffect(220, 10, TimeSpan.FromMilliseconds(60), LibraryFile.MagicEx2, 20, 40, CartoonGlobals.HolyColour)
                            {
                                Blend = true,
                                Target = this,
                            });
                            DXSoundManager.Play(SoundIndex.PurificationStart);
                            break;

                        #endregion

                        #region Strength Of Faith

                        case MagicType.StrengthOfFaith:
                            Effects.Add(spell = new MirEffect(360, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx2, 20, 40, CartoonGlobals.PhantomColour)
                            {
                                Blend = true,
                                Target = this,
                            });
                            DXSoundManager.Play(SoundIndex.StrengthOfFaithStart);
                            break;

                        #endregion

                        #region Transparency

                        case MagicType.Transparency:
                            Effects.Add(new MirEffect(430, 7, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx2, 10, 35, CartoonGlobals.PhantomColour)
                            {
                                Blend = true,
                                Target = this,
                            });
                            DXSoundManager.Play(SoundIndex.InvisibilityEnd);
                            break;

                        #endregion

                        #region Celestial Light

                        case MagicType.CelestialLight:
                            Effects.Add(new MirEffect(280, 8, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx2, 10, 35, CartoonGlobals.HolyColour)
                            {
                                Blend = true,
                                Target = this,
                                DrawColour = Color.Yellow,
                            });
                            DXSoundManager.Play(SoundIndex.MagicShieldStart);
                            break;

                        #endregion

                        #region Life Steal

                        case MagicType.LifeSteal:
                            Effects.Add(new MirEffect(2410, 9, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx2, 10, 35, CartoonGlobals.DarkColour)
                            {
                                Blend = true,
                                Target = this,
                                Direction = action.Direction,
                            });
                            DXSoundManager.Play(SoundIndex.HolyStrikeStart);
                            break;

                        #endregion

                        #region Improved Explosive Talisman

                        case MagicType.ImprovedExplosiveTalisman:
                            Effects.Add(spell = new MirEffect(980, 6, TimeSpan.FromMilliseconds(80), LibraryFile.MagicEx2, 10, 35, CartoonGlobals.DarkColour)
                            {
                                Blend = true,
                                Target = this,
                                Direction = action.Direction
                            });

                            DXSoundManager.Play(SoundIndex.ExplosiveTalismanStart);
                            break;

                        #endregion

                        

                        

                        #region Thunder Kick

                        case MagicType.ThunderKick:
                            DXSoundManager.Play(SoundIndex.TaoistCombatKickStart);
                            break;

                        #endregion


                        #region Dark Soul Prison

                        case MagicType.DarkSoulPrison:
                            Effects.Add(new MirEffect(600, 9, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx6, 10, 35, CartoonGlobals.DarkColour)
                            {
                                Blend = true,
                                Target = this,
                            });
                            DXSoundManager.Play(SoundIndex.DarkSoulPrison);
                            break;

                        #endregion

                        #endregion

                        #region Assassin

                        

                        

                        

                        

                        

                        #region Cloak

                        case MagicType.Cloak:
                            Effects.Add(new MirEffect(600, 10, TimeSpan.FromMilliseconds(60), LibraryFile.MagicEx4, 10, 35, CartoonGlobals.PhantomColour)
                            {
                                Blend = true,
                                MapTarget = CurrentLocation,
                            });
                            DXSoundManager.Play(SoundIndex.CloakStart);
                            break;

                        #endregion

                        

                        

                        #region Wraith Grip

                        case MagicType.WraithGrip:
                            Effects.Add(spell = new MirEffect(1460, 15, TimeSpan.FromMilliseconds(60), LibraryFile.MagicEx4, 60, 60, CartoonGlobals.NoneColour)
                            {
                                Blend = true,
                                Target = this,
                                BlendRate = 0.4f,
                            });
                            DXSoundManager.Play(SoundIndex.WraithGripStart);
                            break;

                        #endregion

                        #region Hell Fire

                        case MagicType.HellFire:
                            Effects.Add(spell = new MirEffect(1520, 15, TimeSpan.FromMilliseconds(60), LibraryFile.MagicEx4, 60, 60, CartoonGlobals.FireColour)
                            {
                                Blend = true,
                                Target = this,
                            });
                            DXSoundManager.Play(SoundIndex.WraithGripStart);
                            break;

                        #endregion

                        

                        #region Rake

                        case MagicType.Rake:
                            Effects.Add(spell = new MirEffect(1200, 9, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx4, 60, 60, CartoonGlobals.IceColour)
                            {
                                Blend = true,
                                Target = this,
                                Direction = action.Direction,
                                Skip = 10,
                            });
                            DXSoundManager.Play(SoundIndex.RakeStart);
                            break;

                        #endregion

                        

                        #region Summon Puppet

                        case MagicType.SummonPuppet:
                            Effects.Add(new MirEffect(800, 16, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx4, 80, 50, CartoonGlobals.PhantomColour)
                            {
                                Blend = true,
                                MapTarget = CurrentLocation,
                            });
                            DXSoundManager.Play(SoundIndex.SummonPuppet);
                            break;

                        #endregion

                        

                        

                        

                        

                        

                        

                        

                        

                        

                        

                        

                        #region The New Beginning

                        case MagicType.TheNewBeginning:
                            Effects.Add(spell = new MirEffect(2300, 9, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx4, 60, 60, CartoonGlobals.NoneColour)
                            {
                                Blend = true,
                                Target = this,
                                Direction = action.Direction
                            });
                            DXSoundManager.Play(SoundIndex.TheNewBeginning);
                            break;

                        #endregion

                        

                        

                        #region Dragon Repulse

                        case MagicType.DragonRepulse:
                            Effects.Add(new MirEffect(1000, 10, TimeSpan.FromMilliseconds(60), LibraryFile.MagicEx4, 0, 0, CartoonGlobals.NoneColour)
                            {
                                MapTarget = CurrentLocation,
                            });
                            Effects.Add(new MirEffect(1020, 10, TimeSpan.FromMilliseconds(60), LibraryFile.MagicEx4, 80, 50, CartoonGlobals.LightningColour)
                            {
                                Blend = true,
                                MapTarget = CurrentLocation,
                            });
                            DXSoundManager.Play(SoundIndex.DragonRepulseStart);
                            break;

                        #endregion

                        

                        

                        #region Abyss

                        case MagicType.Abyss:
                            Effects.Add(new MirEffect(2000, 14, TimeSpan.FromMilliseconds(70), LibraryFile.MagicEx4, 80, 50, CartoonGlobals.PhantomColour)
                            {
                                Blend = true,
                                MapTarget = CurrentLocation,
                            });
                            DXSoundManager.Play(SoundIndex.AbyssStart);
                            break;

                        #endregion

                        #region Flash Of Light

                        case MagicType.FlashOfLight:
                            break;

                        #endregion

                        

                        #region Evasion

                        case MagicType.Evasion:
                            Effects.Add(new MirEffect(2500, 12, TimeSpan.FromMilliseconds(70), LibraryFile.MagicEx4, 80, 50, CartoonGlobals.NoneColour)
                            {
                                Blend = true,
                                MapTarget = CurrentLocation,
                            });
                            DXSoundManager.Play(SoundIndex.EvasionStart);
                            break;

                        #endregion

                        #region RagingWind

                        case MagicType.RagingWind:
                            Effects.Add(new MirEffect(2600, 12, TimeSpan.FromMilliseconds(70), LibraryFile.MagicEx4, 80, 50, CartoonGlobals.NoneColour)
                            {
                                Blend = true,
                                MapTarget = CurrentLocation,
                            });
                            DXSoundManager.Play(SoundIndex.RagingWindStart);
                            break;

                        #endregion

                        #region Concentration

                        case MagicType.Concentration:
                            Effects.Add(new MirEffect(300, 15, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx5, 10, 35, CartoonGlobals.DarkColour)
                            {
                                Blend = true,
                                Target = this,
                            });
                            DXSoundManager.Play(SoundIndex.Concentration);
                            break;

                        #endregion

                        #endregion


                        #region Monster Scortched Earth

                        case MagicType.MonsterScortchedEarth:

                            location = CurrentLocation;

                            if (Config.DrawEffects && Race != ObjectType.Monster)
                                foreach (Point point in MagicLocations)
                            {
                                Effects.Add(new MirEffect(220, 1, TimeSpan.FromMilliseconds(2500), LibraryFile.ProgUse, 0, 0, CartoonGlobals.NoneColour)
                                {
                                    MapTarget = point,
                                    StartTime = CEnvir.Now.AddMilliseconds(500 + Functions.Distance(point, location) * 50),
                                    Opacity = 0.8F,
                                    DrawType = DrawType.Floor,
                                });

                                Effects.Add(new MirEffect(2450 + CEnvir.Random.Next(5) * 10, 10, TimeSpan.FromMilliseconds(250), LibraryFile.Magic, 0, 0, CartoonGlobals.NoneColour)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                    StartTime = CEnvir.Now.AddMilliseconds(500 + Functions.Distance(point, location) * 50),
                                    DrawType = DrawType.Floor,
                                });

                                Effects.Add(new MirEffect(1930, 30, TimeSpan.FromMilliseconds(50), LibraryFile.Magic, 20, 70, CartoonGlobals.FireColour)
                                {
                                    Blend = true,
                                    MapTarget = point,
                                    StartTime = CEnvir.Now.AddMilliseconds(Functions.Distance(point, location) * 50),
                                    BlendRate = 1F,
                                });
                            }

                            
                            

                            break;
                        case MagicType.DoomClawRightPinch:

                            spell = new MirEffect(2640, 7, TimeSpan.FromMilliseconds(100), LibraryFile.MonMagicEx19, 0, 0, CartoonGlobals.NoneColour)
                            {
                                Blend = true,
                                MapTarget = CurrentLocation,
                            };
                            spell.Process();

                            spell.CompleteAction = () =>
                            {
                                spell = new MirEffect(2680, 9, TimeSpan.FromMilliseconds(100), LibraryFile.MonMagicEx19, 0, 0, CartoonGlobals.NoneColour)
                                {
                                    Blend = true,
                                    MapTarget = Functions.Move(Functions.Move(CurrentLocation, MirDirection.Down, 0), MirDirection.Right, 5),
                                };
                                spell.Process();
                            };

                            break;
                        case MagicType.DoomClawLeftPinch:

                            spell = new MirEffect(2660, 7, TimeSpan.FromMilliseconds(100), LibraryFile.MonMagicEx19, 0, 0, CartoonGlobals.NoneColour)
                            {
                                Blend = true,
                                MapTarget = CurrentLocation,
                            };
                            spell.Process();

                            spell.CompleteAction = () =>
                            {
                                spell = new MirEffect(2680, 9, TimeSpan.FromMilliseconds(100), LibraryFile.MonMagicEx19, 0, 0, CartoonGlobals.NoneColour)
                                {
                                    Blend = true,
                                    MapTarget = Functions.Move(CurrentLocation, MirDirection.Right, 5),
                                };
                                spell.Process();
                            };
                            break;
                        case MagicType.DoomClawRightSwipe:

                            spell = new MirEffect(2700, 8, TimeSpan.FromMilliseconds(100), LibraryFile.MonMagicEx19, 0, 0, CartoonGlobals.NoneColour)
                            {
                                Blend = true,
                                MapTarget = CurrentLocation,
                            };
                            spell.Process();
                            break;
                        case MagicType.DoomClawLeftSwipe:

                            spell = new MirEffect(2720, 8, TimeSpan.FromMilliseconds(100), LibraryFile.MonMagicEx19, 0, 0, CartoonGlobals.NoneColour)
                            {
                                Blend = true,
                                MapTarget = CurrentLocation,
                            };
                            spell.Process();
                            break;
                        case MagicType.DoomClawSpit:
                            foreach (Point point in MagicLocations)
                            {
                                MirProjectile eff;
                                Point p = new Point(point.X , point.Y - 10);
                                Effects.Add(eff = new MirProjectile(2500, 7, TimeSpan.FromMilliseconds(100), LibraryFile.MonMagicEx19, 0, 0, CartoonGlobals.NoneColour, p)
                                {
                                    MapTarget = point,
                                    Skip = 0,
                                    Explode = true,
                                    Blend = true,
                                });

                                eff.CompleteAction = () =>
                                {
                                    Effects.Add(new MirEffect(2520, 8, TimeSpan.FromMilliseconds(100), LibraryFile.MonMagicEx19, 0, 0, CartoonGlobals.NoneColour)
                                    {
                                        MapTarget = eff.MapTarget,
                                        Blend = true,
                                    });
                                };

                            }
                            break;

                            #endregion


                    }


                    break;
            }
        }

        public virtual void DoNextAction()
        {
            if (ActionQueue.Count == 0)
            {
                switch (CurrentAction)
                {
                    
                    case MirAction.Die:
                    case MirAction.Dead:
                        ActionQueue.Add(new ObjectAction(MirAction.Dead, Direction, CurrentLocation));
                        break;
                    default:
                        ActionQueue.Add(new ObjectAction(MirAction.Standing, Direction, CurrentLocation));
                        break;
                }

            }

            switch (ActionQueue[0].Action)
            {
                case MirAction.Moving:
               
               
                case MirAction.Pushed:
                    if (!GameScene.Game.MoveFrame) return;
                    break;

            }
            SetAction(ActionQueue[0]);
            ActionQueue.RemoveAt(0);
        }


        public virtual void DrawFrameChanged()
        {
            GameScene.Game.MapControl.TextureValid = false;

        }
        public virtual void FrameIndexChanged()
        {
            switch (CurrentAction)
            {
                case MirAction.Attack:
                    if (FrameIndex != 1) return;
                    PlayAttackSound();
                    break;
                case MirAction.RangeAttack:
                    if (FrameIndex != 4) return;
                    CreateProjectile();
                    PlayAttackSound();
                    break;
              /*  case MirAction.Struck:
                    if (FrameIndex == 0)
                        PlayStruckSound();
                    break;*/
                case MirAction.Die:
                    if (FrameIndex == 0)
                        PlayDieSound();
                    break;
            }
        }

        public virtual void CreateProjectile()
        {
        }
        public virtual void MovingOffSetChanged()
        {
            GameScene.Game.MapControl.TextureValid = false;
        }
        public virtual void LocationChanged()
        {
            if (CurrentCell == null) return;

            CurrentCell.RemoveObject(this);

            if (CurrentLocation.X < GameScene.Game.MapControl.Width && CurrentLocation.Y < GameScene.Game.MapControl.Height)
                GameScene.Game.MapControl.Cells[CurrentLocation.X, CurrentLocation.Y].AddObject(this);

        }
        public virtual void DeadChanged()
        {
            ;
            ;
        }

        public void Struck(uint attackerID, Element element)
        {
            AttackerID = attackerID;

            PlayStruckSound();

            if (VisibleBuffs.Contains(BuffType.MagicShield) || VisibleBuffs.Contains(BuffType.SuperiorMagicShield))
                MagicShieldStruck();

            if (VisibleBuffs.Contains(BuffType.CelestialLight))
                CelestialLightStruck();
            
            switch (element)
            {
                case Element.None:
                    Effects.Add(new MirEffect(930, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 10, 30, CartoonGlobals.NoneColour)
                    {
                        Blend = true,
                        Target = this,
                    });
                    break;
                case Element.Fire:
                    Effects.Add(new MirEffect(790, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 10, 30, CartoonGlobals.FireColour)
                    {
                        Blend = true,
                        Target = this,
                    });
                    break;
                case Element.Ice:
                    Effects.Add(new MirEffect(810, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 10, 30, CartoonGlobals.IceColour)
                    {
                        Blend = true,
                        Target = this,
                    });
                    break;
                case Element.Lightning:
                    Effects.Add(new MirEffect(830, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 10, 30, CartoonGlobals.LightningColour)
                    {
                        Blend = true,
                        Target = this,
                    });
                    break;
                case Element.Wind:
                    Effects.Add(new MirEffect(850, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 10, 30, CartoonGlobals.WindColour)
                    {
                        Blend = true,
                        Target = this,
                    });
                    break;
                case Element.Holy:
                    Effects.Add(new MirEffect(870, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 10, 30, CartoonGlobals.HolyColour)
                    {
                        Blend = true,
                        Target = this,
                    });
                    break;
                case Element.Dark:
                    Effects.Add(new MirEffect(890, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 10, 30, CartoonGlobals.DarkColour)
                    {
                        Blend = true,
                        Target = this,
                    });
                    break;
                case Element.Phantom:
                    Effects.Add(new MirEffect(910, 6, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx, 10, 30, CartoonGlobals.PhantomColour)
                    {
                        Blend = true,
                        Target = this,
                    });
                    break;
            }
        }

        public virtual void Draw()
        {
            


        }
        public virtual void DrawBlend()
        {
            
        }
        
        public void Chat(string text)
        {
            const int chatWidth = 200;

            Color colour = Dead ? Color.Gray : Color.White;
            ChatLabel = ChatLabels.FirstOrDefault(x => x.Text == text && x.ForeColour == colour);

            ChatTime = CEnvir.Now.AddSeconds(5);

            if (ChatLabel != null) return;

            ChatLabel = new DXLabel
            {
                AutoSize =  false,
                Outline = true,
                OutlineColour = Color.Black,
                ForeColour = colour,
                Text = text,
                IsVisible = true,
                DrawFormat = TextFormatFlags.WordBreak | TextFormatFlags.WordEllipsis ,
            };
            ChatLabel.Size = DXLabel.GetHeight(ChatLabel, chatWidth);
            ChatLabel.Disposing += (o, e) => ChatLabels.Remove(ChatLabel);
            ChatLabels.Add(ChatLabel);

        }

        public virtual void NameChanged()
        {
            if (string.IsNullOrEmpty(Name))
            {
                NameLabel = null;
            }
            else
            {
                if (!NameLabels.TryGetValue(Name, out List<DXLabel> names))
                    NameLabels[Name] = names = new List<DXLabel>();

                NameLabel = names.FirstOrDefault(x => x.ForeColour == NameColour && x.BackColour == Color.Empty);

                if (NameLabel == null)
                {
                    NameLabel = new DXLabel
                    {
                        BackColour = Color.Empty,
                        ForeColour = NameColour,
                        Outline = true,
                        OutlineColour = Color.Black,
                        Text = Name,
                        IsControl = false,
                        IsVisible = true,
                        DrawFormat = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak,
                    };

                    NameLabel.Disposing += (o, e) => names.Remove(NameLabel);
                    names.Add(NameLabel);
                }
            }

            if (string.IsNullOrEmpty(Title))
            {
                TitleNameLabel = null;
            }
            else
            {
                string title = Title;

                if (Race == ObjectType.Player)
                {
                    foreach (KeyValuePair<CastleInfo, string> pair in GameScene.Game.CastleOwners)
                    {
                        if (pair.Value != Title) continue;

                        title += $" ({pair.Key.Name})";
                    }
                }

                if (!NameLabels.TryGetValue(title, out List<DXLabel> titles))
                    NameLabels[title] = titles = new List<DXLabel>();

                TitleNameLabel = titles.FirstOrDefault(x => x.ForeColour == NameColour && x.BackColour == Color.Empty);

                if (TitleNameLabel != null) return;

                TitleNameLabel = new DXLabel
                {
                    BackColour = Color.Empty,
                    ForeColour = Race != ObjectType.Player ? Color.Orange : NameColour,
                    Outline = true,
                    OutlineColour = Color.Black,
                    Text = title,
                    IsControl = false,
                    IsVisible = true,
                };

                TitleNameLabel.Disposing += (o, e) => titles.Remove(TitleNameLabel);
                titles.Add(TitleNameLabel);
            }
        }
        public virtual void DrawName()
        {
            Size size;
            if (NameLabel != null)
            {
                int drawX = DrawX;
                int num1 = 48;
                size = NameLabel.Size;
                int width = size.Width;
                int num2 = (num1 - width) / 2;
                int x = drawX + num2;
                int drawY = DrawY;
                int num3 = 32;
                size = NameLabel.Size;
                int height = size.Height;
                int num4 = (num3 - height) / 2;
                int num5 = drawY - num4;
                if (mo == ObjectType.Monster && NameLabel.Text.Contains("\r\n"))
                    num5 -= 18;
                else if (mo == ObjectType.Player)
                    num5 -= 13;
                int y = !Dead ? num5 - 6 : num5 + 21;
                if (mo != ObjectType.Player && TitleNameLabel != null)
                    y -= 13;
                NameLabel.Location = new Point(x, y);
                NameLabel.Draw();
            }
            if (TitleNameLabel == null)
                return;
            int drawX1 = DrawX;
            int num6 = 48;
            size = TitleNameLabel.Size;
            int width1 = size.Width;
            int num7 = (num6 - width1) / 2;
            int x1 = drawX1 + num7;
            int drawY1 = DrawY;
            int num8 = 32;
            size = TitleNameLabel.Size;
            int height1 = size.Height;
            int num9 = (num8 - height1) / 2;
            int num10 = drawY1 - num9;
            int y1 = !Dead ? num10 - 6 : num10 + 21;
            TitleNameLabel.Location = new Point(x1, y1);
            TitleNameLabel.Draw();
        }
        public virtual void DrawDamage()
        {

            foreach (DamageInfo damageInfo in DamageList)
                damageInfo.Draw(DrawX, DrawY);
        }

        
        public void DrawChat()
        {
            if (this.ChatLabel == null || this.ChatLabel.IsDisposed || CEnvir.Now > this.ChatTime)
                return;

            int x = this.DrawX + (48 - this.ChatLabel.Size.Width) / 2;

            int y = this.DrawY - 76 + this.ChatLabel.Size.Height;

            if (this is PlayerObject && !Config.数字显血)
                y += 20;

            if (this == User && User.VisibleBuffs.Contains(BuffType.SuperiorMagicShield))
                y -= 10;

            if (this.Dead)
                y += 35;
            this.ChatLabel.ForeColour = this.Dead ? Color.Gray : Color.White;
            this.ChatLabel.Location = new Point(x, y);
            this.ChatLabel.Draw();
        }

        /*
        public void DrawChat()
        {
            if (ChatLabel == null || ChatLabel.IsDisposed || CEnvir.Now > ChatTime)
                return;
            int drawX = DrawX;
            int num1 = 62;
            Size size = ChatLabel.Size;
            int width = size.Width;
            int num2 = (num1 - width) / 2;
            int x = drawX + num2;
            int drawY = DrawY;
            int num3 = 74;
            size = ChatLabel.Size;
            int height = size.Height;
            int num4 = num3 + height;
            int y = drawY - num4;
            if (CEnvir.Now < DrawHealthTime)
                y -= 20;

            if (this == User && User.VisibleBuffs.Contains(BuffType.SuperiorMagicShield))
                y -= 10;

            if (Dead)
                y += 35;
            ChatLabel.ForeColour = Dead ? Color.Gray : Color.White;
            ChatLabel.Location = new Point(x, y);
            ChatLabel.Draw();
        }
        */
        public virtual void PlayAttackSound()
        {
            
        }
        public virtual void PlayStruckSound()
        {
            
        }
        public virtual void PlayDieSound()
        {
            

        }

        public void DrawPoison()
        {
            
            if (Dead) return;

            int count = 0;

            if ((Poison & PoisonType.Paralysis) == PoisonType.Paralysis)
            {
                DXManager.Sprite.Draw(DXManager.PoisonTexture, Vector3.Zero, new Vector3(DrawX + count * 5, DrawY - 50, 0), Color.DimGray);
                count++;
            }
            if ((Poison & PoisonType.Slow) == PoisonType.Slow)
            {
                DXManager.Sprite.Draw(DXManager.PoisonTexture, Vector3.Zero, new Vector3(DrawX + count * 5, DrawY - 50, 0), Color.CornflowerBlue);
                count++;
            }

            if ((Poison & PoisonType.Red) == PoisonType.Red)
            {
                DXManager.Sprite.Draw(DXManager.PoisonTexture, Vector3.Zero, new Vector3(DrawX + count * 5, DrawY - 50, 0), Color.IndianRed);
                count++;
            }

            if ((Poison & PoisonType.Green) == PoisonType.Green)
                DXManager.Sprite.Draw(DXManager.PoisonTexture, Vector3.Zero, new Vector3(DrawX + count * 5, DrawY - 50, 0), Color.SeaGreen);


            
            if ((Poison & PoisonType.Flamed) == PoisonType.Flamed)
                DXManager.Sprite.Draw(DXManager.PoisonTexture, Vector3.Zero, new Vector3(DrawX + count * 5, DrawY - 50, 0), Color.Gold);

            
            if ((Poison & PoisonType.Thunder) == PoisonType.Thunder)
                DXManager.Sprite.Draw(DXManager.PoisonTexture, Vector3.Zero, new Vector3(DrawX + count * 5, DrawY - 50, 0), Color.Plum);
        }
        public virtual void DrawHealth()
        {
          
        }

        public abstract bool MouseOver(Point p);

        public abstract void OnRemoved();

        public virtual void UpdateQuests()
        {
            
        }
        
        public virtual void MeiriUpdateQuests()
        {

        }
        
        public void WraithGripCreate()
        {
            WraithGripEffect = new MirEffect(1424, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx4, 40, 40, CartoonGlobals.NoneColour)
            {
                Blend = true,
                Target = this,
                Loop = true,
                BlendRate = 0.4f,
            };
            WraithGripEffect2 = new MirEffect(1444, 10, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx4, 40, 40, CartoonGlobals.NoneColour)
            {
                Blend = true,
                Target = this,
                Loop = true,
                BlendRate = 0.4f,
            };
        }
        public void WraithGripEnd()
        {
            WraithGripEffect?.Remove();
            WraithGripEffect = null;
            WraithGripEffect2?.Remove();
            WraithGripEffect2 = null;
        }
        
        public void MagicShieldCreate()
        {
            if (VisibleBuffs.Contains(BuffType.MagicShield))
            {
                
                
                if (Mingwen01 == 126 || Mingwen02 == 126 || Mingwen03 == 126)
                {
                    MagicShieldEffect = new MirEffect(210, 3, TimeSpan.FromMilliseconds(200), LibraryFile.MagicEx10, 40, 40, CartoonGlobals.NoneColour)
                    {
                        Blend = true,
                        Target = this,
                        Loop = true,
                    };
                }
                
                
                else if (Mingwen01 == 127 || Mingwen02 == 127 || Mingwen03 == 127)
                {
                    MagicShieldEffect = new MirEffect(240, 3, TimeSpan.FromMilliseconds(200), LibraryFile.MagicEx10, 40, 40, CartoonGlobals.NoneColour)
                    {
                        Blend = true,
                        Target = this,
                        Loop = true,
                    };
                }
                
                
                else if (Mingwen01 == 128 || Mingwen02 == 128 || Mingwen03 == 128)
                {
                    MagicShieldEffect = new MirEffect(270, 3, TimeSpan.FromMilliseconds(200), LibraryFile.MagicEx10, 40, 40, CartoonGlobals.NoneColour)
                    {
                        Blend = true,
                        Target = this,
                        Loop = true,
                    };
                }
                else
                {
                    MagicShieldEffect = new MirEffect(850, 3, TimeSpan.FromMilliseconds(200), LibraryFile.Magic, 40, 40, CartoonGlobals.WindColour)
                    {
                        Blend = true,
                        Target = this,
                        Loop = true,
                    };
                }
            }
            else
            {
                MagicShieldEffect = new MirEffect(1920, 3, TimeSpan.FromMilliseconds(200), LibraryFile.MagicEx2, 40, 40, CartoonGlobals.FireColour)
                {
                    Blend = true,
                    Target = this,
                    Loop = true,
                };
            }
            MagicShieldEffect.Process();
        }
        
        public void MagicShieldStruck()
        {
            MagicShieldEnd();

            if (VisibleBuffs.Contains(BuffType.MagicShield))
            {
                
                
                if (Mingwen01 == 126 || Mingwen02 == 126 || Mingwen03 == 126)
                {
                    MagicShieldEffect = new MirEffect(213, 3, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx10, 40, 40, CartoonGlobals.NoneColour)
                    {
                        Blend = true,
                        Target = this,
                        CompleteAction = MagicShieldCreate,
                    };
                }
                
                
                else if (Mingwen01 == 127 || Mingwen02 == 127 || Mingwen03 == 127)
                {
                    MagicShieldEffect = new MirEffect(243, 3, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx10, 40, 40, CartoonGlobals.NoneColour)
                    {
                        Blend = true,
                        Target = this,
                        CompleteAction = MagicShieldCreate,
                    };
                }
                
                
                else if (Mingwen01 == 128 || Mingwen02 == 128 || Mingwen03 == 128)
                {
                    MagicShieldEffect = new MirEffect(273, 3, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx10, 40, 40, CartoonGlobals.NoneColour)
                    {
                        Blend = true,
                        Target = this,
                        CompleteAction = MagicShieldCreate,
                    };
                }
                else
                {
                    MagicShieldEffect = new MirEffect(853, 3, TimeSpan.FromMilliseconds(100), LibraryFile.Magic, 40, 40, CartoonGlobals.WindColour)
                    {
                        Blend = true,
                        Target = this,
                        CompleteAction = MagicShieldCreate,
                    };
                }
            }
            else
            {
                MagicShieldEffect = new MirEffect(1923, 3, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx2, 40, 40, CartoonGlobals.FireColour)
                {
                    Blend = true,
                    Target = this,
                    CompleteAction = MagicShieldCreate,
                };
            }
            MagicShieldEffect.Process();
        }

        public void MagicShieldEnd()
        {
            MagicShieldEffect?.Remove();
            MagicShieldEffect = null;
        }
        public void AssaultCreate()
        {
            AssaultEffect = new MirEffect(740, 3, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx2, 40, 40, CartoonGlobals.NoneColour)
            {
                Blend = true,
                Target = this,
                Loop = true,
                Direction = Direction,
            };
            AssaultEffect.Process();
        }
        public void AssaultEnd()
        {
            AssaultEffect?.Remove();
            AssaultEffect = null;
        }
        
        
        public void ChongzhuangYinCreate()
        {
            ChongzhuangYinEffect = new MirEffect(560, 8, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx10, 10, 100, CartoonGlobals.NoneColour)
            {
                Target = this,
                
                Direction = Direction,
            };
            
        }
        
        
        public void ChongzhuangYinEnd()
        {
            ChongzhuangYinEffect?.Remove();
            ChongzhuangYinEffect = null;
        }
        public void CelestialLightCreate()
        {
            CelestialLightEffect = new MirEffect(300, 3, TimeSpan.FromMilliseconds(200), LibraryFile.MagicEx2, 40, 40, CartoonGlobals.HolyColour)
            {
                Blend = true,
                Target = this,
                Loop = true,
            };
            CelestialLightEffect.Process();
        }
        public void CelestialLightStruck()
        {
            CelestialLightEnd();

            CelestialLightEffect = new MirEffect(303, 3, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx2, 40, 40, CartoonGlobals.HolyColour)
            {
                Blend = true,
                Target = this,
                CompleteAction = CelestialLightCreate,
            };
            CelestialLightEffect.Process();

        }
        public void CelestialLightEnd()
        {
            CelestialLightEffect?.Remove();
            CelestialLightEffect = null;
        }
        public void LifeStealCreate()
        {
            LifeStealEffect = new MirEffect(1260, 6, TimeSpan.FromMilliseconds(150), LibraryFile.MagicEx2, 40, 40, CartoonGlobals.DarkColour)
            {
                Blend = true,
                Target = this,
                Loop = true,
            };
        }
        public void LifeStealEnd()
        {
            LifeStealEffect?.Remove();
            LifeStealEffect = null;
        }

        public void FrostBiteCreate()
        {
            FrostBiteEffect = new MirEffect(600, 7, TimeSpan.FromMilliseconds(150), LibraryFile.MagicEx5, 40, 40, CartoonGlobals.IceColour)
            {
                Blend = true,
                Target = this,
                Loop = true,
            };
        }
        public void FrostBiteEnd()
        {
            FrostBiteEffect?.Remove();
            FrostBiteEffect = null;
        }
        public void SilenceCreate()
        {
            SilenceEffect = new MirEffect(680, 6, TimeSpan.FromMilliseconds(150), LibraryFile.ProgUse, 0, 0, CartoonGlobals.NoneColour)
            {
                Blend = true,
                Target = this,
                Loop = true,
            };
        }
        public void SilenceEnd()
        {
            SilenceEffect?.Remove();
            SilenceEffect = null;
        }
        
        public void FlameCreate()
        {
            FlameEffect = new MirEffect(790, 6, TimeSpan.FromMilliseconds(150), LibraryFile.MagicEx, 0, 0, CartoonGlobals.NoneColour)
            {
                Blend = true,
                Target = this,
                Loop = true,
            };
        }
        
        public void FlameEnd()
        {
            FlameEffect?.Remove();
            FlameEffect = null;
        }
        
        public void ThunderCreate()
        {
            ThunderEffect = new MirEffect(830, 10, TimeSpan.FromMilliseconds(150), LibraryFile.MagicEx, 0, 0, CartoonGlobals.NoneColour)
            {
                Blend = true,
                Target = this,
                Loop = true,
            };
        }
        
        public void ThunderEnd()
        {
            ThunderEffect?.Remove();
            ThunderEffect = null;
        }
        public void BlindCreate()
        {
            BlindEffect = new MirEffect(680, 6, TimeSpan.FromMilliseconds(150), LibraryFile.ProgUse, 0, 0, CartoonGlobals.NoneColour)
            {
                
                Target = this,
                Loop = true,
                DrawColour = Color.Black,
                Opacity = 0.8F
            };

            if (this != User) return;

            AbyssEffect = new MirEffect(2100, 19, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx4, 0, 0, CartoonGlobals.NoneColour)
            {
                Blend = true,
                Target = this,
                Loop = true,
                AdditionalOffSet = new Point(0, -64)
            };
        }
        public void BlindEnd()
        {
            BlindEffect?.Remove();
            BlindEffect = null;
            AbyssEffect?.Remove();
            AbyssEffect = null;
        }
        public void InfectionCreate()
        {
            InfectionEffect = new MirEffect(900, 7, TimeSpan.FromMilliseconds(100), LibraryFile.MagicEx5, 0, 0, CartoonGlobals.NoneColour)
            {
                Blend = true,
                Target = this,
                Loop = true,
              
                Opacity = 0.8F
            };
        }
        public void InfectionEnd()
        {
            InfectionEffect?.Remove();
            InfectionEffect = null;
        }

        public void NeutralizeCreate()
        {
            NeutralizeEffect = new MirEffect(470, 6, TimeSpan.FromMilliseconds(120), LibraryFile.MagicEx7, 0, 0, CartoonGlobals.NoneColour)
            {
                Blend = true,
                Target = this,
                Loop = true,
                Opacity = 0.8F
            };
        }
        public void NeutralizeEnd()
        {
            NeutralizeEffect?.Remove();
            NeutralizeEffect = null;
        }

        public void ChannellingMagicCreate()
        {
            if (VisibleBuffs.Contains(BuffType.DragonRepulse))
            {
                ChannellingMagicEffect = new MirEffect(1011, 4, TimeSpan.FromMilliseconds(150), LibraryFile.MagicEx4, 0, 0, CartoonGlobals.NoneColour)
                {
                    Target = this,
                    Loop = true,
                };
                ChannellingMagicEffect1 = new MirEffect(1031, 4, TimeSpan.FromMilliseconds(150), LibraryFile.MagicEx4, 80, 80, CartoonGlobals.LightningColour)
                {
                    Blend = true,
                    Target = this,
                    Loop = true,
                };
            }
            else if (VisibleBuffs.Contains(BuffType.ElementalHurricane))
            {
                if (Config.DrawEffects && Race != ObjectType.Monster)
                {
                    Color attackColour = CartoonGlobals.NoneColour;
                    switch (AttackElement)
                    {
                        case Element.Fire:
                            attackColour = CartoonGlobals.FireColour;
                            break;
                        case Element.Ice:
                            attackColour = CartoonGlobals.IceColour;
                            break;
                        case Element.Lightning:
                            attackColour = CartoonGlobals.LightningColour;
                            break;
                        case Element.Wind:
                            attackColour = CartoonGlobals.WindColour;
                            break;
                        case Element.Holy:
                            attackColour = CartoonGlobals.HolyColour;
                            break;
                        case Element.Dark:
                            attackColour = CartoonGlobals.DarkColour;
                            break;
                        case Element.Phantom:
                            attackColour = CartoonGlobals.PhantomColour;
                            break;
                    }

                    ChannellingMagicEffect = new MirEffect(370, 4, TimeSpan.FromMilliseconds(140), LibraryFile.MagicEx3, 0, 0, CartoonGlobals.LightningColour)
                    {
                        Blend = true,
                        Target = this,
                        Direction = Direction,
                        DrawColour = attackColour,
                        Loop = true,
                    };
                    ChannellingMagicEffect.FrameIndexAction = () =>
                    {
                        if (ChannellingMagicEffect.FrameIndex == 0)
                            DXSoundManager.Play(SoundIndex.ElementalHurricane);

                    };
                    ChannellingMagicEffect.Process();
                }
                
            }
        }
        public void ChannellingMagicEnd()
        {
            ChannellingMagicEffect?.Remove();
            ChannellingMagicEffect = null;
            ChannellingMagicEffect1?.Remove();
            ChannellingMagicEffect1 = null;
        }

        public void RankingCreate()
        {
            RankingEffect = new MirEffect(3420, 7, TimeSpan.FromMilliseconds(150), LibraryFile.GameInter, 0, 0, CartoonGlobals.NoneColour)
            {
                Blend = true,
                Target = this,
                Loop = true,
                AdditionalOffSet = new Point(0, -35)
            };
            RankingEffect.Process();
        }
        public void RankingEnd()
        {
            RankingEffect?.Remove();
            RankingEffect = null;
        }

        public void DeveloperCreate()
        {
            DeveloperEffect = new MirEffect(3410, 7, TimeSpan.FromMilliseconds(150), LibraryFile.GameInter, 0, 0, CartoonGlobals.NoneColour)
            {
                Blend = true,
                Target = this,
                Loop = true,
                AdditionalOffSet = new Point(10, -35)
            };
            DeveloperEffect.Process();
        }
        public void DeveloperEnd()
        {
            DeveloperEffect?.Remove();
            DeveloperEffect = null;
        }
        public void MoveSpeedCreate()
        {
            MoveSpeedEffect = new MirEffect(3810, 15, TimeSpan.FromMilliseconds(150), LibraryFile.GameInter2, 0, 0, CartoonGlobals.NoneColour)
            {
                Blend = true,
                Target = this,
                Loop = true,
                BlendRate = 1F,
            };
            MoveSpeedEffect.Process();
        }
        public void MoveSpeedEnd()
        {
            MoveSpeedEffect?.Remove();
            MoveSpeedEffect = null;
        }

        
        public void QingtongEffectCreate()
        {
            
            QingtongEffect = new MirEffect(3450, 7, TimeSpan.FromMilliseconds(250), LibraryFile.GameInter, 0, 0, CartoonGlobals.NoneColour)
            {
                Blend = true,
                Target = this,
                Loop = true,
                AdditionalOffSet = new Point(0, -92)

                
                
                
                

            };
            QingtongEffect.Process();
        }
        public void QingtongEffectEnd()
        {
            QingtongEffect?.Remove();
            QingtongEffect = null;
        }

        
        public void BaiyinEffectCreate()
        {
            
            BaiyinEffect = new MirEffect(3440, 7, TimeSpan.FromMilliseconds(250), LibraryFile.GameInter, 0, 0, CartoonGlobals.NoneColour)
            {
                Blend = true,
                Target = this,
                Loop = true,
                AdditionalOffSet = new Point(0, -92)
               
                
                
                
                
         

            };
            BaiyinEffect.Process();
        }
        public void BaiyinEffectEnd()
        {
            BaiyinEffect?.Remove();
            BaiyinEffect = null;
        }

        
        public void HuangjinEffectCreate()
        {
            
            HuangjinEffect = new MirEffect(3430, 7, TimeSpan.FromMilliseconds(250), LibraryFile.GameInter, 0, 0, CartoonGlobals.NoneColour)
            {

                Blend = true,
                Target = this,
                Loop = true,
                AdditionalOffSet = new Point(0, -92)

                
                
                
                
            };
            HuangjinEffect.Process();
        }
        public void HuangjinEffectEnd()
        {
            HuangjinEffect?.Remove();
            HuangjinEffect = null;
        }

        
        /*
        public void GonghuiquanEffectCreate()
        {
            GonghuiquanEffect = new MirEffect(3810, 15, TimeSpan.FromMilliseconds(150), LibraryFile.GameInter2, 0, 0, CartoonGlobals.NoneColour)
            {
                Blend = true,
                Loop = true,
                Target = this,
                BlendRate = 1F,
            };
            GonghuiquanEffect.Process();
        }

        public void GonghuiquanEffectEnd()
        {
            GonghuiquanEffect?.Remove();
            GonghuiquanEffect = null;
        }
        */

        public virtual void Remove()
        {
            GameScene.Game.MapControl.RemoveObject(this);

            MagicShieldEnd();
            CelestialLightEnd();
            WraithGripEnd();
            LifeStealEnd();
            SilenceEnd();
            
            FlameEnd();
            
            ThunderEnd();
            BlindEnd();
            ChannellingMagicEnd();
            RankingEnd();
            DeveloperEnd();
            MoveSpeedEnd();
            QingtongEffectEnd();
            BaiyinEffectEnd();
            HuangjinEffectEnd();
            
            
            
            ChongzhuangYinEnd();
            AssaultEnd();
            FrostBiteEnd();
            InfectionEnd();

            for (int i = Effects.Count - 1; i >= 0; i--)
            {
                MirEffect effect = Effects[i];
                effect.Remove();
            }
        }
    }
}
