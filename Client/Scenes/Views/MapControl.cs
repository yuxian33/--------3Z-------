using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Client.Controls;
using Client.Envir;
using Client.Models;
using Library;
using Client.Models.ParticleEngine;
using Library.SystemModels;
using SlimDX;
using SlimDX.Direct3D9;
using C = Library.Network.ClientPackets;
using Library.Network.ServerPackets;


namespace Client.Scenes.Views
{
    public sealed class MapControl : DXControl
    {
        #region Properties

        public static UserObject User => GameScene.Game.User;

        #region MapInformation

        public MapInfo MapInfo
        {
            get => _MapInfo;
            set
            {
                if (_MapInfo == value) return;

                MapInfo oldValue = _MapInfo;
                _MapInfo = value;

                OnMapInfoChanged(oldValue, value);
            }
        }
        private MapInfo _MapInfo;
        public event EventHandler<EventArgs> MapInfoChanged;
        public void OnMapInfoChanged(MapInfo oValue, MapInfo nValue)
        {
            TextureValid = false;
            LoadMap();

            if (oValue != null)
            {
                if (nValue == null || nValue.Music != oValue.Music)
                    DXSoundManager.Stop(oValue.Music);
            }

            if (nValue != null)
                DXSoundManager.Play(nValue.Music);

            LLayer.UpdateLights();

            PathFinder = new PathFinder(this);

            
            
            

            GameScene.Game.MapChangeds();

            UpdateWeather();

            if (GameScene.Game != null && GameScene.Game.BigPatchBox != null)
                GameScene.Game.AutoGuajiChanged();

            MapInfoChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Animation

        public int Animation
        {
            get => _Animation;
            set
            {
                if (_Animation == value) return;

                int oldValue = _Animation;
                _Animation = value;

                OnAnimationChanged(oldValue, value);
            }
        }
        private int _Animation;
        public event EventHandler<EventArgs> AnimationChanged;
        public void OnAnimationChanged(int oValue, int nValue)
        {
            AnimationChanged?.Invoke(this, EventArgs.Empty);
            TextureValid = false;
        }



        #endregion


        #region MouseLocation

        public Point MouseLocation
        {
            get => _MouseLocation;
            set
            {
                if (_MouseLocation == value) return;

                Point oldValue = _MouseLocation;
                _MouseLocation = value;

                OnMouseLocationChanged(oldValue, value);
            }
        }
        private Point _MouseLocation;
        public event EventHandler<EventArgs> MouseLocationChanged;
        public void OnMouseLocationChanged(Point oValue, Point nValue)
        {
            MouseLocationChanged?.Invoke(this, EventArgs.Empty);
            UpdateMapLocation();
        }

        #endregion

        public override void OnSizeChanged(Size oValue, Size nValue)
        {
            base.OnSizeChanged(oValue, nValue);

            if (FLayer != null)
                FLayer.Size = Size;

            if (LLayer != null)
                LLayer.Size = Size;


            OffSetX = Size.Width / 2 / CellWidth;
            OffSetY = Size.Height / 2 / CellHeight;
        }

        public MouseButtons MapButtons;
        public Point MapLocation;
        public bool Mining;
        public Point MiningPoint;
        public MirDirection MiningDirection;

        public Floor FLayer;
        public Light LLayer;

        public Cell[,] Cells;
        public int Width, Height;

        public List<DXControl> MapInfoObjects = new List<DXControl>();
        public List<MapObject> Objects = new List<MapObject>();
        public List<MirEffect> Effects = new List<MirEffect>();

        public const int CellWidth = 48, CellHeight = 32;

        public int ViewRangeX = 12, ViewRangeY = 24;

        public static int OffSetX;
        public static int OffSetY;

        
        public DateTime TargetTime;
        
        private DateTime UpdateTarget;
        
        private Point TargetLocation;

        public MirImage BackgroundImage;
        public float BackgroundScaleX, BackgroundScaleY;
        public Point BackgroundMovingOffset = Point.Empty;

        public bool m_bShowSnow;
        public bool m_bShowMist;
        public bool m_bShowRain;

        public CFlyingTail m_xFlyingTail = new CFlyingTail();
        public CSmoke m_xSmoke = new CSmoke();
        public CBoom m_xBoom = new CBoom();
        public CMist m_xMist = new CMist();
        public CSnow m_xSnow = new CSnow();
        public CScatter m_xScatter = new CScatter();
        public CRain m_xRain = new CRain();

        public MapObject TargetObject
        {
            get
            {
                return GameScene.Game.TargetObject;
            }
            set
            {
                GameScene.Game.TargetObject = value;
                GameScene.Game.MouseObject = value;
                this.TargetTime = CEnvir.Now;
            }
        }

        public DateTime ProtectTime
        {
            get
            {
                return GameScene.Game.BigPatchBox._ProtectTime;
            }
            set
            {
                GameScene.Game.BigPatchBox._ProtectTime = value;
            }
        }

        #endregion

        public MapControl()
        {
            DrawTexture = true;

            BackColour = Color.Empty;

            FLayer = new Floor { Parent = this, Size = Size };
            LLayer = new Light { Parent = this, Location = new Point(-GameScene.Game.Location.X, -GameScene.Game.Location.Y), Size = Size };


            m_xFlyingTail.SetupSystem(1000);
            m_xSmoke.SetupSystem(1000);
            m_xBoom.SetupSystem(1000);
            
            m_xScatter.SetupSystem(2000);
            
            m_xMist.Init();

        }

        public bool AutoPath
        {
            get
            {
                return _autoPath;
            }
            set
            {
                if (_autoPath == value)
                    return;
                _autoPath = value;
                if (!_autoPath)
                    CurrentPath = null;
                if (GameScene.Game == null || Config.开始挂机)
                    return;
                GameScene.Game.ReceiveChat(value ? "[寻路:开 (停止:鼠标左键或右键)]" : "[寻路:关]", MessageType.System);
            }
        }
        private bool _autoPath;

        public PathFinder PathFinder = (PathFinder)null;
        public List<Client.Models.Node> CurrentPath = (List<Client.Models.Node>)null;
        private DateTime pathfindertime;

        #region Methods

        protected override void OnClearTexture()
        {
            base.OnClearTexture();

            if (FLayer.TextureValid)
                DXManager.Sprite.Draw(FLayer.ControlTexture, Color.White);

            if (Config.DrawEffects)
            {
                foreach (MirEffect ob in Effects)
                {
                    if (ob.DrawType != DrawType.Floor) continue;

                    ob.Draw();
                }
            }

            DrawObjects();

            if (MapObject.MouseObject != null) 
                MapObject.MouseObject.DrawBlend();

            foreach (MapObject ob in Objects)
            {
                if (ob.Dead) continue;

                switch (ob.Race)
                {
                    case ObjectType.Player:
                        if (!Config.ShowPlayerNames) continue;

                        break;
                    case ObjectType.Item:
                        if (!Config.ShowItemNames || ob.CurrentLocation == MapLocation) continue;
                        break;
                    case ObjectType.NPC:
                        break;
                    case ObjectType.Spell:
                        break;
                    case ObjectType.Monster:
                        if (!Config.ShowMonsterNames) continue;
                        break;
                }

                ob.DrawName();
            }

            if (Config.DrawEffects)
            {
                foreach (MirEffect ob in Effects)
                {
                    if (ob.DrawType != DrawType.Final) continue;

                    ob.Draw();
                }
            }

            if (MapObject.MouseObject != null && MapObject.MouseObject.Race != ObjectType.Item)
                MapObject.MouseObject.DrawName();



            foreach (MapObject ob in Objects)
            {
                ob.DrawChat();
                ob.DrawPoison();
                ob.DrawHealth();
            }

            if (Config.ShowDamageNumbers)
                foreach (MapObject ob in Objects)
                    ob.DrawDamage();

            if (MapLocation.X >= 0 && MapLocation.X < Width && MapLocation.Y >= 0 && MapLocation.Y < Height)
            {
                Cell cell = Cells[MapLocation.X, MapLocation.Y];
                int layer = 0;
                if (cell.Objects != null)
                    for (int i = cell.Objects.Count - 1; i >= 0; i--)
                    {
                        ItemObject ob = cell.Objects[i] as ItemObject;

                        ob?.DrawFocus(layer++);
                    }
            }

            foreach (ParticleEngine engine in GameScene.Game.ParticleEngines)
                engine.Draw();

            DXManager.Sprite.Flush();
            DXManager.Device.SetRenderState(RenderState.SourceBlend, Blend.DestinationColor);
            DXManager.Device.SetRenderState(RenderState.DestinationBlend, Blend.BothInverseSourceAlpha);

            DXManager.Sprite.Draw(LLayer.ControlTexture, Color.White);

            DXManager.Sprite.End();
            DXManager.Sprite.Begin(SpriteFlags.AlphaBlend);

        }
        public override void Draw()
        {
            if (!IsVisible || Size.Width == 0 || Size.Height == 0) return;

            FLayer.CheckTexture();
            LLayer.CheckTexture();

            
            OnBeforeDraw();

            DrawControl();

            DrawBorder();
            OnAfterDraw();
        }

        
        /*
        private void DrawObjects()
        {
            int num = Math.Max(0, User.CurrentLocation.X - OffSetX - 4);
            int num2 = Math.Min(Width - 1, User.CurrentLocation.X + OffSetX + 4);
            int num3 = Math.Max(0, User.CurrentLocation.Y - OffSetY - 4);
            int num4 = Math.Min(Height - 1, User.CurrentLocation.Y + OffSetY + 25);
            for (int i = num3; i <= num4; i++)
            {
                int num5 = (i - User.CurrentLocation.Y + OffSetY + 1) * 32 - User.MovingOffSet.Y;
                for (int j = num; j <= num2; j++)
                {
                    int num6 = (j - User.CurrentLocation.X + OffSetX) * 48 - User.MovingOffSet.X;
                    Cell cell = Cells[j, i];
                    if (Libraries.KROrder.TryGetValue(cell.MiddleFile, out LibraryFile value) && value != LibraryFile.WemadeMir3_Tilesc && CEnvir.LibraryList.TryGetValue(value, out MirLibrary value2))
                    {
                        int num7 = cell.MiddleImage - 1;
                        bool flag = false;
                        if (cell.MiddleAnimationFrame > 1 && cell.MiddleAnimationFrame < byte.MaxValue)
                        {
                            num7 += Animation % (cell.MiddleAnimationFrame & 0x4F);
                            flag = ((cell.MiddleAnimationFrame & 0x80) > 0);
                        }
                        Size size = value2.GetSize(num7);
                        if ((size.Width != 48 || size.Height != 32) && (size.Width != 96 || size.Height != 64))
                        {
                            if (!flag)
                            {
                                value2.Draw(num7, num6, num5 - size.Height, Color.White, useOffSet: false, 1f, ImageType.Image);
                            }
                            else
                            {
                                value2.DrawBlend(num7, num6, num5 - size.Height, Color.White, useOffSet: false, 0.5f, ImageType.Image, 0);
                            }
                        }
                    }
                    if (!Libraries.KROrder.TryGetValue(cell.FrontFile, out value) || value == LibraryFile.WemadeMir3_Tilesc || !CEnvir.LibraryList.TryGetValue(value, out value2))
                    {
                        continue;
                    }
                    int num8 = (cell.FrontImage & 0x7FFF) - 1;
                    bool flag2 = false;
                    if (cell.FrontAnimationFrame > 1 && cell.FrontAnimationFrame < byte.MaxValue)
                    {
                        num8 += Animation % (cell.FrontAnimationFrame & 0x7F);
                        flag2 = ((cell.FrontAnimationFrame & 0x80) > 0);
                    }
                    Size size2 = value2.GetSize(num8);
                    
                    {
                        if (!flag2)
                        {
                            value2.Draw(num8, num6, num5 - size2.Height, Color.White, useOffSet: false, 1f, ImageType.Image);
                        }
                        else
                        {
                            value2.DrawBlend(num8, num6, num5 - size2.Height, Color.White, num8 >= 2723 && num8 <= 2732, 0.5f, ImageType.Image, 0);
                        }
                    }
                }
                foreach (MapObject @object in Objects)
                {
                    if (@object.RenderY == i)
                    {
                        @object.Draw();
                    }
                }
                if (Config.DrawEffects)
                {
                    foreach (MirEffect effect in Effects)
                    {
                        if (effect.DrawType == DrawType.Object)
                        {
                            if (effect.MapTarget.IsEmpty && effect.Target != null)
                            {
                                if (effect.Target.RenderY == i && effect.Target != User)
                                {
                                    effect.Draw();
                                }
                            }
                            else if (effect.MapTarget.Y == i)
                            {
                                effect.Draw();
                            }
                        }
                    }
                }
            }
            if (Config.是否开启粒子效果)
            {
                m_xFlyingTail.RenderSystem();
                m_xSmoke.RenderSystem();
                m_xBoom.RenderSystem();
                if (m_bShowMist)
                    m_xMist.ProgressMist();
                if (m_bShowSnow)
                    m_xSnow.RenderSystem();
                if (m_bShowRain)
                    m_xRain.RenderSystem();
                m_xScatter.RenderSystem();
            }
            if (User.Opacity == 1f)
            {
                float opacity = MapObject.User.Opacity;
                MapObject.User.Opacity = 0.65f;
                MapObject.User.DrawBody(shadow: false);
                MapObject.User.Opacity = opacity;
                if (Config.DrawEffects)
                {
                    foreach (MirEffect effect2 in Effects)
                    {
                        if (effect2.DrawType == DrawType.Object && effect2.MapTarget.IsEmpty && effect2.Target == User)
                        {
                            effect2.Draw();
                        }
                    }
                }
            }
        }
        */

        private void DrawObjects()
        {
            int minX = Math.Max(0, User.CurrentLocation.X - OffSetX - 4), maxX = Math.Min(Width - 1, User.CurrentLocation.X + OffSetX + 4);
            int minY = Math.Max(0, User.CurrentLocation.Y - OffSetY - 4), maxY = Math.Min(Height - 1, User.CurrentLocation.Y + OffSetY + 25);

            for (int y = minY; y <= maxY; y++)
            {
                int drawY = (y - User.CurrentLocation.Y + OffSetY + 1) * CellHeight - User.MovingOffSet.Y - User.ShakeScreenOffset.Y;

                for (int x = minX; x <= maxX; x++)
                {
                    int drawX = (x - User.CurrentLocation.X + OffSetX) * CellWidth - User.MovingOffSet.X - User.ShakeScreenOffset.X;

                    Cell cell = Cells[x, y];

                    MirLibrary library;
                    LibraryFile file;

                    if (Libraries.KROrder.TryGetValue(cell.MiddleFile, out file) && file != LibraryFile.Tilesc && CEnvir.LibraryList.TryGetValue(file, out library))
                    {
                        int index = cell.MiddleImage - 1;

                        bool blend = false;
                        if (cell.MiddleAnimationFrame > 1 && cell.MiddleAnimationFrame < 255)
                        {
                            index += Animation % (cell.MiddleAnimationFrame & 0x4F);
                            blend = (cell.MiddleAnimationFrame & 0x50) > 0;
                        }

                        Size s = library.GetSize(index);

                        if ((s.Width != CellWidth || s.Height != CellHeight) && (s.Width != CellWidth * 2 || s.Height != CellHeight * 2))
                        {
                            if (!blend)
                                library.Draw(index, drawX, drawY - s.Height, Color.White, false, 1F, ImageType.Image);
                            else
                                library.DrawBlend(index, drawX, drawY - s.Height, Color.White, false, 0.5F, ImageType.Image);
                        }
                    }



                    if (Libraries.KROrder.TryGetValue(cell.FrontFile, out file) && file != LibraryFile.Tilesc && CEnvir.LibraryList.TryGetValue(file, out library))
                    {
                        int index = cell.FrontImage - 1;

                        bool blend = false;
                        if (cell.FrontAnimationFrame > 1 && cell.FrontAnimationFrame < 255)
                        {
                            index += Animation % (cell.FrontAnimationFrame & 0x7F);
                            blend = (cell.FrontAnimationFrame & 0x80) > 0;
                        }

                        Size s = library.GetSize(index);


                        if ((s.Width != CellWidth || s.Height != CellHeight) && (s.Width != CellWidth * 2 || s.Height != CellHeight * 2))
                        {
                            if (!blend)
                                library.Draw(index, drawX, drawY - s.Height, Color.White, false, 1F, ImageType.Image);
                            else
                                library.DrawBlend(index, drawX, drawY - s.Height, Color.White, false, 0.5F, ImageType.Image);
                        }
                    }
                }

                foreach (MapObject ob in Objects)
                {
                    if (ob.RenderY == y)
                        ob.Draw();
                }

                if (Config.DrawEffects)
                {
                    foreach (MirEffect ob in Effects)
                    {
                        if (ob.DrawType != DrawType.Object) continue;

                        if (ob.MapTarget.IsEmpty && ob.Target != null)
                        {
                            if (ob.Target.RenderY == y && ob.Target != User)
                                ob.Draw();
                        }
                        else if (ob.MapTarget.Y == y)
                            ob.Draw();
                    }
                }

            }

            if (Config.是否开启粒子效果)
            {
                m_xFlyingTail.RenderSystem();
                m_xSmoke.RenderSystem();
                m_xBoom.RenderSystem();
                if (m_bShowMist)
                    m_xMist.ProgressMist();
                if (m_bShowSnow)
                    m_xSnow.RenderSystem();
                if (m_bShowRain)
                    m_xRain.RenderSystem();
                m_xScatter.RenderSystem();
            }

            if (User.Opacity != 1f) return;
            float oldOpacity = MapObject.User.Opacity;
            MapObject.User.Opacity = 0.65F;

            if (MapObject.User.DrawWeaponEffectInfront())
                MapObject.User.DrawWeaponEffect();

            MapObject.User.DrawBody(false);

            MapObject.User.Opacity = oldOpacity;

            if (Config.DrawEffects)
            {
                foreach (MirEffect ob in Effects)
                {
                    if (ob.DrawType != DrawType.Object || !ob.MapTarget.IsEmpty || ob.Target != User) continue;

                    ob.Draw();
                }
            }

        }


        public void UpdateWeather()
        {
            for (int index = GameScene.Game.ParticleEngines.Count - 1; index > 0; --index)
                GameScene.Game.ParticleEngines[index].Dispose();
            GameScene.Game.ParticleEngines.Clear();
            List<ParticleImageInfo> textures = new List<ParticleImageInfo>();
            Client.Models.ParticleEngine.ParticleEngine particleEngine1 = new Client.Models.ParticleEngine.ParticleEngine(textures, new Vector2(0.0f, 0.0f));
            WeatherSetting weather = (WeatherSetting)Config.天气效果;
            if (weather == WeatherSetting.None)
                weather = GameScene.Game.MapControl.MapInfo.Weather;
            switch (weather - (byte)2)
            {
                case WeatherSetting.None:
                    textures.Add(new ParticleImageInfo(LibraryFile.ProgUse, 550));
                    Vector2 vector2_1 = new Vector2(5f, -5f);
                    int num1 = -512;
                    while (num1 < Config.GameSize.Height + 512)
                    {
                        int num2 = -512;
                        while (num2 < Config.GameSize.Width + 512)
                        {
                            Particle newParticle = particleEngine1.GenerateNewParticle(ParticleType.Fog);
                            newParticle.Position = new Vector2((float)num2, (float)num1);
                            newParticle.Velocity = vector2_1;
                            num2 += 512;
                        }
                        num1 += 512;
                    }
                    particleEngine1.GenerateParticles = false;
                    GameScene.Game.ParticleEngines.Add(particleEngine1);
                    break;
                case WeatherSetting.Default:
                    textures.Add(new ParticleImageInfo(LibraryFile.ProgUse, 550));
                    Vector2 vector2_2 = new Vector2(5f, -5f);
                    int num3 = -512;
                    while (num3 < Config.GameSize.Height + 512)
                    {
                        int num2 = -512;
                        while (num2 < Config.GameSize.Width + 512)
                        {
                            Particle newParticle = particleEngine1.GenerateNewParticle(ParticleType.BurningFog);
                            newParticle.Position = new Vector2((float)num2, (float)num3);
                            newParticle.Velocity = vector2_2;
                            num2 += 512;
                        }
                        num3 += 512;
                    }
                    particleEngine1.GenerateParticles = false;
                    GameScene.Game.ParticleEngines.Add(particleEngine1);
                    Client.Models.ParticleEngine.ParticleEngine particleEngine2 = new Client.Models.ParticleEngine.ParticleEngine(textures, new Vector2(0.0f, 0.0f));
                    vector2_2 = new Vector2(4f, -4f);
                    int num4 = -512;
                    while (num4 < Config.GameSize.Height + 512)
                    {
                        int num2 = -512;
                        while (num2 < Config.GameSize.Width + 512)
                        {
                            Particle newParticle = particleEngine2.GenerateNewParticle(ParticleType.BurningFog);
                            newParticle.Position = new Vector2((float)num2, (float)num4);
                            newParticle.Velocity = vector2_2;
                            num2 += 512;
                        }
                        num4 += 512;
                    }
                    particleEngine2.GenerateParticles = false;
                    GameScene.Game.ParticleEngines.Add(particleEngine2);
                    Client.Models.ParticleEngine.ParticleEngine particleEngine3 = new Client.Models.ParticleEngine.ParticleEngine(new List<ParticleImageInfo>() { new ParticleImageInfo(LibraryFile.ProgUse, 40), new ParticleImageInfo(LibraryFile.ProgUse, 41) }, new Vector2(0.0f, 0.0f));
                    GameScene.Game.ParticleEngines.Add(particleEngine3);
                    break;
                case WeatherSetting.Fog:
                    textures.Add(new ParticleImageInfo(LibraryFile.ProgUse, 551));
                    Vector2 vector2_3 = new Vector2(-5f, 5f);
                    int num5 = -512;
                    while (num5 < Config.GameSize.Height + 512)
                    {
                        int num2 = -512;
                        while (num2 < Config.GameSize.Width + 512)
                        {
                            Particle newParticle = particleEngine1.GenerateNewParticle(ParticleType.Snow);
                            newParticle.Position = new Vector2((float)num2, (float)num5);
                            newParticle.Velocity = vector2_3;
                            num2 += 512;
                        }
                        num5 += 512;
                    }
                    particleEngine1.GenerateParticles = false;
                    GameScene.Game.ParticleEngines.Add(particleEngine1);
                    break;
                case WeatherSetting.BurningFog:
                    textures.Add(new ParticleImageInfo(LibraryFile.ProgUse, 553));
                    Vector2 vector2_4 = new Vector2(-5f, 5f);
                    int num6 = -512;
                    while (num6 < Config.GameSize.Height + 512)
                    {
                        int num2 = -512;
                        while (num2 < Config.GameSize.Width + 512)
                        {
                            Particle newParticle = particleEngine1.GenerateNewParticle(ParticleType.Everfall);
                            newParticle.Position = new Vector2((float)num2, (float)num6);
                            newParticle.Velocity = vector2_4;
                            num2 += 512;
                        }
                        num6 += 512;
                    }
                    particleEngine1.GenerateParticles = false;
                    GameScene.Game.ParticleEngines.Add(particleEngine1);
                    break;
                case WeatherSetting.Snow:
                    textures.Add(new ParticleImageInfo(LibraryFile.ProgUse, 552));
                    Vector2 vector2_5 = new Vector2(-5f, 5f);
                    int num7 = -512;
                    while (num7 < Config.GameSize.Height + 512)
                    {
                        int num2 = -512;
                        while (num2 < Config.GameSize.Width + 512)
                        {
                            Particle newParticle = particleEngine1.GenerateNewParticle(ParticleType.Rain);
                            newParticle.Position = new Vector2((float)num2, (float)num7);
                            newParticle.Velocity = vector2_5;
                            num2 += 512;
                        }
                        num7 += 512;
                    }
                    particleEngine1.GenerateParticles = false;
                    GameScene.Game.ParticleEngines.Add(particleEngine1);
                    break;
            }
        }
        /*
        private void LoadMap()
        {
            try
            {
                if (!File.Exists(Config.MapPath + MapInfo.FileName + ".map"))
                {
                    return;
                }
                byte[] array = File.ReadAllBytes(Config.MapPath + MapInfo.FileName + ".map");
                if (array[2] == 67 && array[3] == 35)
                {
                    LoadMapType100(array);
                }
                else if (array[0] == 0)
                {
                    LoadMapType5(array);
                }
                else if (array[0] == 15 && array[5] == 83 && array[14] == 51)
                {
                    LoadMapType6(array);
                }
                else if (array[0] == 21 && array[4] == 50 && array[6] == 65 && array[19] == 49)
                {
                    LoadMapType4(array);
                }
                else if (array[0] == 16 && array[2] == 97 && array[7] == 49 && array[14] == 49)
                {
                    LoadMapType1(array);
                }
                else if (array[4] == 15 || (array[4] == 3 && array[18] == 13 && array[19] == 10))
                {
                    int num = array[0] + (array[1] << 8);
                    int num2 = array[2] + (array[3] << 8);
                    if (array.Length > 52 + num * num2 * 14)
                    {
                        LoadMapType3(array);
                    }
                    else
                    {
                        LoadMapType2(array);
                    }
                }
                else if (array[0] == 13 && array[1] == 76 && array[7] == 32 && array[11] == 109)
                {
                    LoadMapType7(array);
                }
                else
                {
                    LoadMapType0(array);
                }
            }
            catch (Exception ex)
            {
                CEnvir.SaveError(ex.ToString());
            }
            foreach (MapObject @object in Objects)
            {
                if (@object.CurrentLocation.X < Width && @object.CurrentLocation.Y < Height)
                {
                    Cells[@object.CurrentLocation.X, @object.CurrentLocation.Y].AddObject(@object);
                }
            }
        }
        */
        private void LoadMapType0(byte[] Bytes)
        {
            try
            {
                int num = 0;
                Width = BitConverter.ToInt16(Bytes, num);
                num += 2;
                Height = BitConverter.ToInt16(Bytes, num);
                Cells = new Cell[Width, Height];
                num = 52;
                for (int i = 0; i < Width; i++)
                {
                    for (int j = 0; j < Height; j++)
                    {
                        Cells[i, j] = new Cell();
                        Cells[i, j].BackFile = 0;
                        Cells[i, j].MiddleFile = 1;
                        Cells[i, j].BackImage = BitConverter.ToInt16(Bytes, num);
                        num += 2;
                        Cells[i, j].MiddleImage = BitConverter.ToInt16(Bytes, num);
                        num += 2;
                        Cells[i, j].FrontImage = BitConverter.ToInt16(Bytes, num);
                        num += 2;
                        Cells[i, j].DoorIndex = (byte)(Bytes[num++] & 0x7F);
                        Cells[i, j].DoorOffset = Bytes[num++];
                        Cells[i, j].FrontAnimationFrame = Bytes[num++];
                        Cells[i, j].FrontAnimationTick = Bytes[num++];
                        Cells[i, j].FrontFile = (short)(Bytes[num++] + 2);
                        Cells[i, j].Light = Bytes[num++];
                        if ((Cells[i, j].BackImage & 0x8000) != 0)
                        {
                            Cells[i, j].BackImage = ((Cells[i, j].BackImage & 0x7FFF) | 0x20000000);
                        }
                        if (Cells[i, j].Light >= 100 && Cells[i, j].Light <= 119)
                        {
                            Cells[i, j].FishingCell = true;
                        }
                        if ((Cells[i, j].BackImage & 0x20000000) != 0 || (Cells[i, j].FrontImage & 0x8000) != 0)
                        {
                            Cells[i, j].Flag = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CEnvir.SaveError(ex.ToString());
            }
        }

        private void LoadMapType1(byte[] Bytes)
        {
            try
            {
                int num = 21;
                int num2 = BitConverter.ToInt16(Bytes, num);
                num += 2;
                int num3 = BitConverter.ToInt16(Bytes, num);
                num += 2;
                int num4 = BitConverter.ToInt16(Bytes, num);
                Width = (num2 ^ num3);
                Height = (num4 ^ num3);
                Cells = new Cell[Width, Height];
                num = 54;
                for (int i = 0; i < Width; i++)
                {
                    for (int j = 0; j < Height; j++)
                    {
                        Cells[i, j] = new Cell
                        {
                            BackFile = 0,
                            BackImage = (int)(BitConverter.ToInt32(Bytes, num) ^ 2855840312u),
                            MiddleFile = 1,
                            MiddleImage = (short)(BitConverter.ToInt16(Bytes, num += 4) ^ num3),
                            FrontImage = (short)(BitConverter.ToInt16(Bytes, num += 2) ^ num3),
                            DoorIndex = (byte)(Bytes[num += 2] & 0x7F),
                            DoorOffset = Bytes[++num],
                            FrontAnimationFrame = Bytes[++num],
                            FrontAnimationTick = Bytes[++num],
                            FrontFile = (short)(Bytes[++num] + 2),
                            Light = Bytes[++num],
                            Unknown = Bytes[++num]
                        };
                        num++;
                        if (Cells[i, j].Light >= 100 && Cells[i, j].Light <= 119)
                        {
                            Cells[i, j].FishingCell = true;
                        }
                        if ((Cells[i, j].BackImage & 0x20000000) != 0 || (Cells[i, j].FrontImage & 0x8000) != 0)
                        {
                            Cells[i, j].Flag = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CEnvir.SaveError(ex.ToString());
            }
        }

        private void LoadMapType2(byte[] Bytes)
        {
            try
            {
                int num = 0;
                Width = BitConverter.ToInt16(Bytes, num);
                num += 2;
                Height = BitConverter.ToInt16(Bytes, num);
                Cells = new Cell[Width, Height];
                num = 52;
                for (int i = 0; i < Width; i++)
                {
                    for (int j = 0; j < Height; j++)
                    {
                        Cells[i, j] = new Cell();
                        Cells[i, j].BackImage = BitConverter.ToInt16(Bytes, num);
                        num += 2;
                        Cells[i, j].MiddleImage = BitConverter.ToInt16(Bytes, num);
                        num += 2;
                        Cells[i, j].FrontImage = BitConverter.ToInt16(Bytes, num);
                        num += 2;
                        Cells[i, j].DoorIndex = (byte)(Bytes[num++] & 0x7F);
                        Cells[i, j].DoorOffset = Bytes[num++];
                        Cells[i, j].FrontAnimationFrame = Bytes[num++];
                        Cells[i, j].FrontAnimationTick = Bytes[num++];
                        Cells[i, j].FrontFile = (short)(Bytes[num++] + 120);
                        Cells[i, j].Light = Bytes[num++];
                        Cells[i, j].BackFile = (short)(Bytes[num++] + 100);
                        Cells[i, j].MiddleFile = (short)(Bytes[num++] + 110);
                        if ((Cells[i, j].BackImage & 0x8000) != 0)
                        {
                            Cells[i, j].BackImage = ((Cells[i, j].BackImage & 0x7FFF) | 0x20000000);
                        }
                        if (Cells[i, j].Light >= 100 && Cells[i, j].Light <= 119)
                        {
                            Cells[i, j].FishingCell = true;
                        }
                        if ((Cells[i, j].BackImage & 0x20000000) != 0 || (Cells[i, j].FrontImage & 0x8000) != 0)
                        {
                            Cells[i, j].Flag = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CEnvir.SaveError(ex.ToString());
            }
        }

        private void LoadMapType3(byte[] Bytes)
        {
            try
            {
                int num = 0;
                Width = BitConverter.ToInt16(Bytes, num);
                num += 2;
                Height = BitConverter.ToInt16(Bytes, num);
                Cells = new Cell[Width, Height];
                num = 52;
                for (int i = 0; i < Width; i++)
                {
                    for (int j = 0; j < Height; j++)
                    {
                        Cells[i, j] = new Cell();
                        Cells[i, j].BackImage = BitConverter.ToInt16(Bytes, num);
                        num += 2;
                        Cells[i, j].MiddleImage = BitConverter.ToInt16(Bytes, num);
                        num += 2;
                        Cells[i, j].FrontImage = BitConverter.ToInt16(Bytes, num);
                        num += 2;
                        Cells[i, j].DoorIndex = (byte)(Bytes[num++] & 0x7F);
                        Cells[i, j].DoorOffset = Bytes[num++];
                        Cells[i, j].FrontAnimationFrame = Bytes[num++];
                        Cells[i, j].FrontAnimationTick = Bytes[num++];
                        Cells[i, j].FrontFile = (short)(Bytes[num++] + 120);
                        Cells[i, j].Light = Bytes[num++];
                        Cells[i, j].BackFile = (short)(Bytes[num++] + 100);
                        Cells[i, j].MiddleFile = (short)(Bytes[num++] + 110);
                        Cells[i, j].TileAnimationImage = BitConverter.ToInt16(Bytes, num);
                        num += 7;
                        Cells[i, j].TileAnimationFrames = Bytes[num++];
                        Cells[i, j].TileAnimationOffset = BitConverter.ToInt16(Bytes, num);
                        num += 14;
                        if ((Cells[i, j].BackImage & 0x8000) != 0)
                        {
                            Cells[i, j].BackImage = ((Cells[i, j].BackImage & 0x7FFF) | 0x20000000);
                        }
                        if (Cells[i, j].Light >= 100 && Cells[i, j].Light <= 119)
                        {
                            Cells[i, j].FishingCell = true;
                        }
                        if ((Cells[i, j].BackImage & 0x20000000) != 0 || (Cells[i, j].FrontImage & 0x8000) != 0)
                        {
                            Cells[i, j].Flag = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CEnvir.SaveError(ex.ToString());
            }
        }

        private void LoadMapType4(byte[] Bytes)
        {
            try
            {
                int num = 31;
                int num2 = BitConverter.ToInt16(Bytes, num);
                num += 2;
                int num3 = BitConverter.ToInt16(Bytes, num);
                num += 2;
                int num4 = BitConverter.ToInt16(Bytes, num);
                Width = (num2 ^ num3);
                Height = (num4 ^ num3);
                Cells = new Cell[Width, Height];
                num = 64;
                for (int i = 0; i < Width; i++)
                {
                    for (int j = 0; j < Height; j++)
                    {
                        Cells[i, j] = new Cell();
                        Cells[i, j].BackFile = 0;
                        Cells[i, j].MiddleFile = 1;
                        Cells[i, j].BackImage = (short)(BitConverter.ToInt16(Bytes, num) ^ num3);
                        num += 2;
                        Cells[i, j].MiddleImage = (short)(BitConverter.ToInt16(Bytes, num) ^ num3);
                        num += 2;
                        Cells[i, j].FrontImage = (short)(BitConverter.ToInt16(Bytes, num) ^ num3);
                        num += 2;
                        Cells[i, j].DoorIndex = (byte)(Bytes[num++] & 0x7F);
                        Cells[i, j].DoorOffset = Bytes[num++];
                        Cells[i, j].FrontAnimationFrame = Bytes[num++];
                        Cells[i, j].FrontAnimationTick = Bytes[num++];
                        Cells[i, j].FrontFile = (short)(Bytes[num++] + 2);
                        Cells[i, j].Light = Bytes[num++];
                        if ((Cells[i, j].BackImage & 0x8000) != 0)
                        {
                            Cells[i, j].BackImage = ((Cells[i, j].BackImage & 0x7FFF) | 0x20000000);
                        }
                        if (Cells[i, j].Light >= 100 && Cells[i, j].Light <= 119)
                        {
                            Cells[i, j].FishingCell = true;
                        }
                        if ((Cells[i, j].BackImage & 0x20000000) != 0 || (Cells[i, j].FrontImage & 0x8000) != 0)
                        {
                            Cells[i, j].Flag = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CEnvir.SaveError(ex.ToString());
            }
        }

        private void LoadMapType5(byte[] Bytes)
        {
            try
            {
                byte b = 0;
                int num = 20;
                short num2 = BitConverter.ToInt16(Bytes, num);
                Width = BitConverter.ToInt16(Bytes, num += 2);
                Height = BitConverter.ToInt16(Bytes, num += 2);
                num = 28;
                Cells = new Cell[Width, Height];
                for (int i = 0; i < Width; i++)
                {
                    for (int j = 0; j < Height; j++)
                    {
                        Cells[i, j] = new Cell();
                    }
                }
                for (int k = 0; k < Width / 2; k++)
                {
                    for (int l = 0; l < Height / 2; l++)
                    {
                        for (int m = 0; m < 4; m++)
                        {
                            Cells[k * 2 + m % 2, l * 2 + m / 2].BackFile = (short)((Bytes[num] != byte.MaxValue) ? (Bytes[num] + 200) : (-1));
                            Cells[k * 2 + m % 2, l * 2 + m / 2].BackImage = BitConverter.ToUInt16(Bytes, num + 1) + 1;
                        }
                        num += 3;
                    }
                }
                num = 28 + 3 * (Width / 2 + Width % 2) * (Height / 2);
                for (int n = 0; n < Width; n++)
                {
                    for (int num3 = 0; num3 < Height; num3++)
                    {
                        b = Bytes[num++];
                        Cells[n, num3].MiddleAnimationFrame = Bytes[num++];
                        Cells[n, num3].FrontAnimationFrame = (byte)((Bytes[num] != byte.MaxValue) ? Bytes[num] : 0);
                        Cells[n, num3].FrontAnimationFrame &= 143;
                        num++;
                        Cells[n, num3].MiddleAnimationTick = 0;
                        Cells[n, num3].FrontAnimationTick = 0;
                        Cells[n, num3].FrontFile = (short)((Bytes[num] != byte.MaxValue) ? (Bytes[num] + 200) : (-1));
                        num++;
                        Cells[n, num3].MiddleFile = (short)((Bytes[num] != byte.MaxValue) ? (Bytes[num] + 200) : (-1));
                        num++;
                        Cells[n, num3].MiddleImage = (ushort)(BitConverter.ToUInt16(Bytes, num) + 1);
                        num += 2;
                        Cells[n, num3].FrontImage = (ushort)(BitConverter.ToUInt16(Bytes, num) + 1);
                        if (Cells[n, num3].FrontImage == 1 && Cells[n, num3].FrontFile == 200)
                        {
                            Cells[n, num3].FrontFile = -1;
                        }
                        num += 2;
                        num += 3;
                        Cells[n, num3].Light = (byte)(Bytes[num] & 0xF);
                        num += 2;
                        if ((b & 1) != 1)
                        {
                            Cells[n, num3].BackImage |= 536870912;
                        }
                        if ((b & 2) != 2)
                        {
                            Cells[n, num3].FrontImage = (ushort)((ushort)Cells[n, num3].FrontImage | 0x8000);
                        }
                        if (Cells[n, num3].Light >= 100 && Cells[n, num3].Light <= 119)
                        {
                            Cells[n, num3].FishingCell = true;
                        }
                        else
                        {
                            Cells[n, num3].Light *= 2;
                        }
                        if ((Cells[n, num3].BackImage & 0x20000000) != 0 || (Cells[n, num3].FrontImage & 0x8000) != 0)
                        {
                            Cells[n, num3].Flag = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CEnvir.SaveError(ex.ToString());
            }
        }

        private void LoadMapType6(byte[] Bytes)
        {
            try
            {
                byte b = 0;
                int num = 16;
                Width = BitConverter.ToInt16(Bytes, num);
                num += 2;
                Height = BitConverter.ToInt16(Bytes, num);
                Cells = new Cell[Width, Height];
                num = 40;
                for (int i = 0; i < Width; i++)
                {
                    for (int j = 0; j < Height; j++)
                    {
                        Cells[i, j] = new Cell();
                        b = Bytes[num++];
                        Cells[i, j].BackFile = (short)((Bytes[num] != byte.MaxValue) ? (Bytes[num] + 300) : (-1));
                        num++;
                        Cells[i, j].MiddleFile = (short)((Bytes[num] != byte.MaxValue) ? (Bytes[num] + 300) : (-1));
                        num++;
                        Cells[i, j].FrontFile = (short)((Bytes[num] != byte.MaxValue) ? (Bytes[num] + 300) : (-1));
                        num++;
                        Cells[i, j].BackImage = (short)(BitConverter.ToInt16(Bytes, num) + 1);
                        num += 2;
                        Cells[i, j].MiddleImage = (short)(BitConverter.ToInt16(Bytes, num) + 1);
                        num += 2;
                        Cells[i, j].FrontImage = (short)(BitConverter.ToInt16(Bytes, num) + 1);
                        num += 2;
                        if (Cells[i, j].FrontImage == 1 && Cells[i, j].FrontFile == 200)
                        {
                            Cells[i, j].FrontFile = -1;
                        }
                        Cells[i, j].MiddleAnimationFrame = Bytes[num++];
                        Cells[i, j].FrontAnimationFrame = (byte)((Bytes[num] != byte.MaxValue) ? Bytes[num] : 0);
                        if (Cells[i, j].FrontAnimationFrame > 15)
                        {
                            Cells[i, j].FrontAnimationFrame = (byte)(Cells[i, j].FrontAnimationFrame & 0xF);
                        }
                        num++;
                        Cells[i, j].MiddleAnimationTick = 1;
                        Cells[i, j].FrontAnimationTick = 1;
                        Cells[i, j].Light = (byte)(Bytes[num] & 0xF);
                        Cells[i, j].Light *= 4;
                        num += 8;
                        if ((b & 1) != 1)
                        {
                            Cells[i, j].BackImage |= 536870912;
                        }
                        if ((b & 2) != 2)
                        {
                            Cells[i, j].FrontImage = (short)((ushort)Cells[i, j].FrontImage | 0x8000);
                        }
                        if ((Cells[i, j].BackImage & 0x20000000) != 0 || (Cells[i, j].FrontImage & 0x8000) != 0)
                        {
                            Cells[i, j].Flag = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CEnvir.SaveError(ex.ToString());
            }
        }

        private void LoadMapType7(byte[] Bytes)
        {
            try
            {
                int num = 21;
                Width = BitConverter.ToInt16(Bytes, num);
                num += 4;
                Height = BitConverter.ToInt16(Bytes, num);
                Cells = new Cell[Width, Height];
                num = 54;
                for (int i = 0; i < Width; i++)
                {
                    for (int j = 0; j < Height; j++)
                    {
                        Cells[i, j] = new Cell
                        {
                            BackFile = 0,
                            BackImage = BitConverter.ToInt32(Bytes, num),
                            MiddleFile = 1,
                            MiddleImage = BitConverter.ToInt16(Bytes, num += 4),
                            FrontImage = BitConverter.ToInt16(Bytes, num += 2),
                            DoorIndex = (byte)(Bytes[num += 2] & 0x7F),
                            DoorOffset = Bytes[++num],
                            FrontAnimationFrame = Bytes[++num],
                            FrontAnimationTick = Bytes[++num],
                            FrontFile = (short)(Bytes[++num] + 2),
                            Light = Bytes[++num],
                            Unknown = Bytes[++num]
                        };
                        if ((Cells[i, j].BackImage & 0x8000) != 0)
                        {
                            Cells[i, j].BackImage = ((Cells[i, j].BackImage & 0x7FFF) | 0x20000000);
                        }
                        num++;
                        if (Cells[i, j].Light >= 100 && Cells[i, j].Light <= 119)
                        {
                            Cells[i, j].FishingCell = true;
                        }
                        if ((Cells[i, j].BackImage & 0x20000000) != 0 || (Cells[i, j].FrontImage & 0x8000) != 0)
                        {
                            Cells[i, j].Flag = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CEnvir.SaveError(ex.ToString());
            }
        }

        private void LoadMapType100(byte[] Bytes)
        {
            try
            {
                int num = 4;
                if (Bytes[0] == 1 && Bytes[1] == 0)
                {
                    Width = BitConverter.ToInt16(Bytes, num);
                    num += 2;
                    Height = BitConverter.ToInt16(Bytes, num);
                    Cells = new Cell[Width, Height];
                    num = 8;
                    for (int i = 0; i < Width; i++)
                    {
                        for (int j = 0; j < Height; j++)
                        {
                            Cells[i, j] = new Cell();
                            Cells[i, j].BackFile = BitConverter.ToInt16(Bytes, num);
                            num += 2;
                            Cells[i, j].BackImage = BitConverter.ToInt32(Bytes, num);
                            num += 4;
                            Cells[i, j].MiddleFile = BitConverter.ToInt16(Bytes, num);
                            num += 2;
                            Cells[i, j].MiddleImage = BitConverter.ToInt16(Bytes, num);
                            num += 2;
                            Cells[i, j].FrontFile = BitConverter.ToInt16(Bytes, num);
                            num += 2;
                            Cells[i, j].FrontImage = BitConverter.ToInt16(Bytes, num);
                            num += 2;
                            Cells[i, j].DoorIndex = (byte)(Bytes[num++] & 0x7F);
                            Cells[i, j].DoorOffset = Bytes[num++];
                            Cells[i, j].FrontAnimationFrame = Bytes[num++];
                            Cells[i, j].FrontAnimationTick = Bytes[num++];
                            Cells[i, j].MiddleAnimationFrame = Bytes[num++];
                            Cells[i, j].MiddleAnimationTick = Bytes[num++];
                            Cells[i, j].TileAnimationImage = BitConverter.ToInt16(Bytes, num);
                            num += 2;
                            Cells[i, j].TileAnimationOffset = BitConverter.ToInt16(Bytes, num);
                            num += 2;
                            Cells[i, j].TileAnimationFrames = Bytes[num++];
                            Cells[i, j].Light = Bytes[num++];
                            if (Cells[i, j].Light >= 100 && Cells[i, j].Light <= 119)
                            {
                                Cells[i, j].FishingCell = true;
                            }
                            if ((Cells[i, j].BackImage & 0x20000000) != 0 || (Cells[i, j].FrontImage & 0x8000) != 0)
                            {
                                Cells[i, j].Flag = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CEnvir.SaveError(ex.ToString());
            }
        }

        
        private void LoadMap()
        {
            try
            {
                if (!File.Exists(Config.MapPath + MapInfo.FileName + ".map")) return;

                using (MemoryStream mStream = new MemoryStream(File.ReadAllBytes(Config.MapPath + MapInfo.FileName + ".map")))
                using (BinaryReader reader = new BinaryReader(mStream))
                {
                    mStream.Seek(22, SeekOrigin.Begin);
                    Width = reader.ReadInt16();
                    Height = reader.ReadInt16();

                    mStream.Seek(28, SeekOrigin.Begin);

                    Cells = new Cell[Width, Height];
                    for (int x = 0; x < Width; x++)
                        for (int y = 0; y < Height; y++)
                            Cells[x, y] = new Cell();

                    for (int x = 0; x < Width/2; x++)
                        for (int y = 0; y < Height/2; y++)
                        {
                            Cells[(x*2), (y*2)].BackFile = reader.ReadByte();
                            Cells[(x*2), (y*2)].BackImage = reader.ReadUInt16();
                        }

                    for (int x = 0; x < Width; x++)
                        for (int y = 0; y < Height; y++)
                        {
                            byte flag = reader.ReadByte();
                            Cells[x, y].MiddleAnimationFrame = reader.ReadByte();

                            byte value = reader.ReadByte();
                            Cells[x, y].FrontAnimationFrame = value == 255 ? 0 : value;
                            Cells[x, y].FrontAnimationFrame &= 0x8F; 

                            Cells[x, y].FrontFile = reader.ReadByte();
                            Cells[x, y].MiddleFile = reader.ReadByte();

                            Cells[x, y].MiddleImage = reader.ReadUInt16() + 1;
                            Cells[x, y].FrontImage = reader.ReadUInt16() + 1;

                            mStream.Seek(3, SeekOrigin.Current);

                            Cells[x, y].Light = (byte) (reader.ReadByte() & 0x0F)*2;

                            mStream.Seek(1, SeekOrigin.Current);

                            Cells[x, y].Flag = ((flag & 0x01) != 1) || ((flag & 0x02) != 2);
                        }
                }
            }
            catch (Exception ex)
            {
                CEnvir.SaveError(ex.ToString());
            }

            foreach (MapObject ob in Objects)
                if (ob.CurrentLocation.X < Width && ob.CurrentLocation.Y < Height)
                    Cells[ob.CurrentLocation.X, ob.CurrentLocation.Y].AddObject(ob);
        }
        
        public override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            MouseLocation = e.Location;
        }
        public override void OnMouseDown(MouseEventArgs e)
        {

            base.OnMouseDown(e);

            if (GameScene.Game.Observer) return;

            MapButtons |= e.Button;

            if (e.Button == MouseButtons.Right)
            {
                if (Config.RightClickDeTarget && MapObject.TargetObject?.Race == ObjectType.Monster)
                    MapObject.TargetObject = null;
            }

            if (e.Button == MouseButtons.Middle)
            {
                if (Config.是否开启鼠标中间按钮自动使用坐骑)
                {
                    if (!GameScene.Game.Observer)
                    {
                        if (CEnvir.Now < User.NextActionTime || User.ActionQueue.Count > 0) return;
                        if (CEnvir.Now < User.ServerTime) return; 

                        User.ServerTime = CEnvir.Now.AddSeconds(5);
                        CEnvir.Enqueue(new C.Mount());
                    }
                }
                else if (Config.是否开启鼠标中间按钮自动使用技能)
                {
                    if (!GameScene.Game.Observer)
                    {
                        switch (Config.鼠标中间按钮使用F几的技能)
                        {
                            case 1:
                                GameScene.Game.UseMagic(SpellKey.Spell01);
                                break;
                            case 2:
                                GameScene.Game.UseMagic(SpellKey.Spell02);
                                break;
                            case 3:
                                GameScene.Game.UseMagic(SpellKey.Spell03);
                                break;
                            case 4:
                                GameScene.Game.UseMagic(SpellKey.Spell04);
                                break;
                            case 5:
                                GameScene.Game.UseMagic(SpellKey.Spell05);
                                break;
                            case 6:
                                GameScene.Game.UseMagic(SpellKey.Spell06);
                                break;
                            case 7:
                                GameScene.Game.UseMagic(SpellKey.Spell07);
                                break;
                            case 8:
                                GameScene.Game.UseMagic(SpellKey.Spell08);
                                break;
                            case 9:
                                GameScene.Game.UseMagic(SpellKey.Spell09);
                                break;
                            case 10:
                                GameScene.Game.UseMagic(SpellKey.Spell10);
                                break;
                            case 11:
                                GameScene.Game.UseMagic(SpellKey.Spell11);
                                break;
                            case 12:
                                GameScene.Game.UseMagic(SpellKey.Spell12);
                                break;
                        }
                    }
                }
            }

            if (e.Button != MouseButtons.Left) return;

            DXItemCell cell = DXItemCell.SelectedCell;
            if (cell != null)
            {
                MapButtons &= ~e.Button;

                if (cell.GridType == GridType.Belt)
                {
                    cell.QuickInfo = null;
                    cell.QuickItem = null;
                    DXItemCell.SelectedCell = null;

                    ClientBeltLink link = GameScene.Game.BeltBox.Links[cell.Slot];
                    CEnvir.Enqueue(new C.BeltLinkChanged { Slot = link.Slot, LinkIndex = link.LinkInfoIndex, LinkItemIndex = link.LinkItemIndex }); 
                    return;
                }

                if (cell.GridType == GridType.AutoPotion)
                {
                    cell.QuickInfo = null;
                    cell.QuickItem = null;
                    DXItemCell.SelectedCell = null;

                    GameScene.Game?.BigPatchBox?.Protect?.Rows[cell.Slot].SendUpdate();
                    return;
                }


                if ((cell.Item.Flags & UserItemFlags.Locked) == UserItemFlags.Locked || cell.GridType != GridType.PatchGrid && cell.GridType != GridType.BaoshiItems && (cell.GridType != GridType.Inventory && cell.GridType != GridType.CompanionInventory))
                {
                    DXItemCell.SelectedCell = null;
                    return;
                }

                DXItemAmountWindow window = new DXItemAmountWindow("掉落道具", cell.Item);

                window.ConfirmButton.MouseClick += (o, a) =>
                {
                    if (window.Amount <= 0) return;

                    CEnvir.Enqueue(new C.ItemDrop
                    {
                        Link = new CellLinkInfo { GridType = cell.GridType, Slot = cell.Slot, Count = window.Amount }
                    });

                    cell.Locked = true;
                };

                DXItemCell.SelectedCell = null;
                return;
            }

            if (GameScene.Game.GoldPickedUp)
            {
                MapButtons &= ~e.Button;
                DXItemAmountWindow window = new DXItemAmountWindow("掉落道具", new ClientUserItem(CartoonGlobals.GoldInfo, User.Gold));

                window.ConfirmButton.MouseClick += (o, a) =>
                {
                    if (window.Amount <= 0 && window.Amount > CartoonGlobals.MaxGold) return;

                    CEnvir.Enqueue(new C.GoldDrop
                    {
                        Amount = window.Amount
                    });

                };

                GameScene.Game.GoldPickedUp = false;
                return;
            }

            if (CanAttack(MapObject.MouseObject))
            {
                MapObject.TargetObject = MapObject.MouseObject;

                if (MapObject.MouseObject.Race == ObjectType.Monster && ((MonsterObject)MapObject.MouseObject).MonsterInfo.AI >= 0) 
                {
                    MapObject.MagicObject = MapObject.TargetObject;
                    GameScene.Game.FocusObject = MapObject.MouseObject;
                }
                return;
            }

            MapObject.TargetObject = null;
            GameScene.Game.FocusObject = null;
            
        }
        public override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (GameScene.Game.Observer) return;

                    GameScene.Game.AutoRun = false;
                    if (MapObject.MouseObject == null) return;
                    NPCObject npc = MapObject.MouseObject as NPCObject;
                    if (npc != null)
                    {
                        if (CEnvir.Now <= GameScene.Game.NPCTime) return;

                        GameScene.Game.NPCTime = CEnvir.Now.AddSeconds(1);

                        CEnvir.Enqueue(new C.NPCCall { ObjectID = npc.ObjectID });
                    }
                    break;
                case MouseButtons.Right:
                    GameScene.Game.AutoRun = false;

                    if (User.CurrentAction == MirAction.Standing)
                        GameScene.Game.CanRun = false;

                    if (!CEnvir.Ctrl) return;

                    PlayerObject player = MapObject.MouseObject as PlayerObject;

                    if (player == null || player == MapObject.User) return;
                    if (CEnvir.Now <= GameScene.Game.InspectTime && player.ObjectID == GameScene.Game.InspectID) return;

                    GameScene.Game.InspectTime = CEnvir.Now.AddMilliseconds(2500);
                    GameScene.Game.InspectID = player.ObjectID;
                    CEnvir.Enqueue(new C.Inspect { Index = player.CharacterIndex });
                    break;
            }
        }

        public void CheckCursor()
        {
            MapObject mapObject1 = (MapObject)null;
            MapObject mapObject2 = (MapObject)null;
            for (int index1 = 0; index1 < 4; ++index1)
            {
                for (int index2 = MapLocation.Y - index1; index2 <= MapLocation.Y + index1; ++index2)
                {
                    if (index2 < Height)
                    {
                        if (index2 >= 0)
                        {
                            for (int index3 = MapLocation.X - index1; index3 <= MapLocation.X + index1; ++index3)
                            {
                                if (index3 < Width)
                                {
                                    if (index3 >= 0)
                                    {
                                        List<MapObject> objects = Cells[index3, index2].Objects;
                                        if (objects != null)
                                        {
                                            MapObject mapObject3 = (MapObject)null;
                                            for (int index4 = objects.Count - 1; index4 >= 0; --index4)
                                            {
                                                MapObject mapObject4 = objects[index4];
                                                if (mapObject4 != MapObject.User && mapObject4.Race != ObjectType.Spell && (index3 == MapLocation.X && index2 == MapLocation.Y || mapObject4.MouseOver(MouseLocation)))
                                                {
                                                    if (mapObject4.Dead || mapObject4.Race == ObjectType.Monster && ((MonsterObject)mapObject4).CompanionObject != null)
                                                    {
                                                        if (mapObject1 == null)
                                                            mapObject1 = mapObject4;
                                                    }
                                                    else if (mapObject4.Race == ObjectType.Item)
                                                    {
                                                        if (mapObject2 == null)
                                                            mapObject2 = mapObject4;
                                                    }
                                                    else if (index3 == MapLocation.X && index2 == MapLocation.Y && !mapObject4.MouseOver(MouseLocation))
                                                    {
                                                        if (mapObject3 == null)
                                                            mapObject3 = mapObject4;
                                                    }
                                                    else
                                                    {
                                                        MapObject.MouseObject = mapObject4;
                                                        return;
                                                    }
                                                }
                                            }
                                            if (mapObject3 != null)
                                            {
                                                MapObject.MouseObject = mapObject3;
                                                return;
                                            }
                                        }
                                    }
                                    else
                                        break;
                                }
                            }
                        }
                        else
                            break;
                    }
                }
            }
            MapObject mapObject5 = mapObject1 ?? mapObject2;
            if (mapObject5 == null)
            {
                Point currentLocation = MapControl.User.CurrentLocation;
                int num;
                if (currentLocation.X == MapLocation.X)
                {
                    currentLocation = MapControl.User.CurrentLocation;
                    if (currentLocation.Y == MapLocation.Y)
                    {
                        num = 1;
                        goto label_37;
                    }
                }
                num = MapControl.User.MouseOver(MouseLocation) ? 1 : 0;
                label_37:
                if (num != 0)
                    mapObject5 = (MapObject)MapControl.User;
            }
            MapObject.MouseObject = mapObject5;
        }

        public void ProcessInput()
        {
            if (GameScene.Game.Observer || (MapControl.User.Dead || (MapControl.User.Poison & PoisonType.Paralysis) == PoisonType.Paralysis || MapControl.User.Buffs.Any<ClientBuffInfo>((Func<ClientBuffInfo, bool>)(x =>
            {
                if (x.Type != BuffType.DragonRepulse)
                    return x.Type == BuffType.FrostBite;
                return true;
            }))))
                return;
            if (MapControl.User.MagicAction != null)
            {
                if (CEnvir.Now < MapObject.User.NextActionTime || (uint)MapObject.User.ActionQueue.Count > 0U)
                    return;
                MapObject.User.AttemptAction(MapControl.User.MagicAction);
                MapControl.User.MagicAction = (ObjectAction)null;
                Mining = false;
            }
            bool haselementalhurricane = MapObject.User.VisibleBuffs.Contains(BuffType.ElementalHurricane);
            if (!haselementalhurricane && MapObject.TargetObject != null && !MapObject.TargetObject.Dead && (MapObject.TargetObject.Race == ObjectType.Monster && string.IsNullOrEmpty(MapObject.TargetObject.PetOwner) || (CEnvir.Shift || Config.免SHIFT)))
            {
                bool flag = true;
                if (Config.自动四花)
                {
                    if (!User.Buffs.Any(x =>
                    {
                        if (x.Type != BuffType.FullBloom && x.Type != BuffType.WhiteLotus)
                            return x.Type == BuffType.RedLotus;
                        return true;
                    }))
                    {
                        GameScene.Game.UseMagic(MagicType.FullBloom);
                        flag = false;
                    }
                    if (MapControl.User.Buffs.Any(x => x.Type == BuffType.FullBloom))
                    {
                        GameScene.Game.UseMagic(MagicType.WhiteLotus);
                        flag = false;
                    }
                    if (MapControl.User.Buffs.Any<ClientBuffInfo>((Func<ClientBuffInfo, bool>)(x => x.Type == BuffType.WhiteLotus)))
                    {
                        GameScene.Game.UseMagic(MagicType.RedLotus);
                        flag = false;
                    }
                    if (MapControl.User.Buffs.Any<ClientBuffInfo>((Func<ClientBuffInfo, bool>)(x => x.Type == BuffType.RedLotus)))
                    {
                        GameScene.Game.UseMagic(MagicType.SweetBrier);
                        flag = false;
                    }
                }
                if (Config.开始挂机)
                {
                    pathfindertime = CEnvir.Now.AddSeconds(2.0);
                    if (Config.自动躲避 && ((MapControl.User.Class == MirClass.Wizard || MapControl.User.Class == MirClass.Taoist) && (double)Functions.Distance(MapObject.User.CurrentLocation, MapObject.TargetObject.CurrentLocation) < 3.0))
                    {
                        MirDirection mirDirection1 = Functions.ShiftDirection(Functions.DirectionFromPoint(MapObject.User.CurrentLocation, MapObject.TargetObject.CurrentLocation), 4);
                        if (!CanMove(mirDirection1, 1))
                        {
                            MirDirection mirDirection2 = DirectionBest(mirDirection1, 1, MapObject.TargetObject.CurrentLocation);
                            if (mirDirection2 == mirDirection1)
                            {
                                if (mirDirection1 != MapControl.User.Direction)
                                    MapObject.User.AttemptAction(new ObjectAction(MirAction.Standing, mirDirection1, MapObject.User.CurrentLocation, Array.Empty<object>()));
                                if (!Functions.InRange(MapObject.TargetObject.CurrentLocation, MapControl.User.CurrentLocation, 10))
                                    return;
                                GameScene.Game.UseMagic(Config.挂机自动技能);
                                return;
                            }
                            mirDirection1 = mirDirection2;
                        }
                        if (GameScene.Game.MoveFrame && (MapControl.User.Poison & PoisonType.WraithGrip) != PoisonType.WraithGrip)
                        {
                            MapObject.User.AttemptAction(new ObjectAction(MirAction.Moving, mirDirection1, Functions.Move(MapObject.User.CurrentLocation, mirDirection1, 1), new object[2]
                            {
                (object) 1,
                (object) MagicType.None
                            }));
                            return;
                        }
                    }
                    if (Config.自动上毒 && MapControl.User.Class == MirClass.Taoist && Functions.InRange(MapObject.TargetObject.CurrentLocation, MapControl.User.CurrentLocation, 10) && ((MapObject.TargetObject.Poison & PoisonType.Red) != PoisonType.Red || (MapObject.TargetObject.Poison & PoisonType.Green) != PoisonType.Green))
                    {
                        GameScene.Game.UseMagic(MagicType.PoisonDust);
                        return;
                    }
                    if ((User.Class == MirClass.Taoist || MapControl.User.Class == MirClass.Wizard) && Functions.InRange(MapObject.TargetObject.CurrentLocation, MapControl.User.CurrentLocation, 10))
                    {
                        GameScene.Game.UseMagic(Config.挂机自动技能);
                        return;
                    }
                }
                if (Functions.Distance(MapObject.TargetObject.CurrentLocation, MapObject.User.CurrentLocation) == 1 && CEnvir.Now > MapControl.User.AttackTime && MapControl.User.Horse == HorseType.None)
                {
                    if (Config.开始挂机 && (flag && MapControl.User.Class == MirClass.Assassin && Functions.InRange(MapObject.TargetObject.CurrentLocation, MapControl.User.CurrentLocation, 10)))
                        GameScene.Game.UseMagic(Config.挂机自动技能);
                    MapObject.User.AttemptAction(new ObjectAction(MirAction.Attack, Functions.DirectionFromPoint(MapObject.User.CurrentLocation, MapObject.TargetObject.CurrentLocation), MapObject.User.CurrentLocation, new object[3]
                    {
            (object) 0,
            (object) MagicType.None,
            (object) Element.None
                    }));
                    return;
                }
            }
            else if (Config.开始挂机 && (this.pathfindertime < CEnvir.Now && !GameScene.Game.MapControl.AutoPath))
            {
                int x;
                int y;
                if (Config.范围挂机)
                {
                    x = CEnvir.Random.Next((int)((long)Config.范围挂机坐标.X - Config.范围距离), (int)((long)Config.范围挂机坐标.X + Config.范围距离));
                    y = CEnvir.Random.Next((int)((long)Config.范围挂机坐标.Y - Config.范围距离), (int)((long)Config.范围挂机坐标.Y + Config.范围距离));
                }
                else
                {
                    x = CEnvir.Random.Next(10, GameScene.Game.MapControl.Width - 10);
                    y = CEnvir.Random.Next(10, GameScene.Game.MapControl.Height - 10);
                }
                List<Node> path = GameScene.Game.MapControl.PathFinder.FindPath(MapObject.User.CurrentLocation, new Point(x, y));
                if (path != null && path.Count != 0)
                {
                    GameScene.Game.MapControl.CurrentPath = path;
                    GameScene.Game.MapControl.AutoPath = true;
                }
            }
            MirDirection mirDirection3 = this.MouseDirection();

            if (GameScene.Game.AutoRun && !haselementalhurricane)
            {
                if (!GameScene.Game.MoveFrame || (MapControl.User.Poison & PoisonType.WraithGrip) == PoisonType.WraithGrip)
                    return;
                MapControl.Run(mirDirection3, true);
            }
            else
            {
                if (DXControl.MouseControl == this)
                {
                    switch (this.MapButtons)
                    {
                        case MouseButtons.Left:
                            this.Mining = false;
                            if (MapObject.TargetObject == null && (Config.免SHIFT || CEnvir.Shift))
                            {
                                if (!(CEnvir.Now > MapControl.User.AttackTime) || MapControl.User.Horse != HorseType.None || haselementalhurricane)
                                    return;
                                MapObject.User.AttemptAction(new ObjectAction(MirAction.Attack, mirDirection3, MapObject.User.CurrentLocation, new object[3]
                                {
                  (object) 0,
                  (object) MagicType.None,
                  (object) Element.None
                                }));
                                return;
                            }
                            if (CEnvir.Alt)
                            {
                                if (MapControl.User.Horse != HorseType.None && !haselementalhurricane)
                                    return;
                                MapObject.User.AttemptAction(new ObjectAction(MirAction.Harvest, mirDirection3, MapObject.User.CurrentLocation, Array.Empty<object>()));
                                return;
                            }

                            
                            if (AutoPath)
                                AutoPath = false;

                            if (MapLocation == MapObject.User.CurrentLocation)
                            {
                                
                                if (CEnvir.Now <= GameScene.Game.PickUpTime) return;

                                CEnvir.Enqueue(new C.PickUp());
                                GameScene.Game.PickUpTime = CEnvir.Now.AddMilliseconds(250);

                                return;
                            }
                            if (MapObject.MouseObject == null || MapObject.MouseObject.Race == ObjectType.Item || MapObject.MouseObject.Dead)
                            {
                                ClientUserItem clientUserItem = GameScene.Game.Equipment[0];
                                if (!haselementalhurricane && MapInfo.CanMine && clientUserItem != null && clientUserItem.Info.Effect == ItemEffect.PickAxe)
                                {
                                    this.MiningPoint = Functions.Move(MapControl.User.CurrentLocation, mirDirection3, 1);
                                    if (this.MiningPoint.X >= 0 && this.MiningPoint.Y >= 0 && (this.MiningPoint.X < this.Width && this.MiningPoint.Y < this.Height) && this.Cells[this.MiningPoint.X, this.MiningPoint.Y].Flag)
                                    {
                                        this.Mining = true;
                                        break;
                                    }
                                }
                                if (!this.CanMove(mirDirection3, 1) || haselementalhurricane)
                                {
                                    MirDirection mirDirection1 = this.MouseDirectionBest(mirDirection3, 1);
                                    if (mirDirection1 == mirDirection3)
                                    {
                                        if (mirDirection3 == MapControl.User.Direction)
                                            return;
                                        MapControl.Run(mirDirection3, true);
                                        return;
                                    }
                                    mirDirection3 = mirDirection1;
                                }
                                if (!haselementalhurricane && GameScene.Game.MoveFrame && (User.Poison & PoisonType.WraithGrip) != PoisonType.WraithGrip)
                                    MapObject.User.AttemptAction(new ObjectAction(MirAction.Moving, mirDirection3, Functions.Move(MapObject.User.CurrentLocation, mirDirection3, 1), new object[2]
                                {
                  (object) 1,
                  (object) MagicType.None
                                }));

                                return;
                            }
                            break;
                        case MouseButtons.Right:
                            this.Mining = false;

                            
                            if (AutoPath)
                                AutoPath = false;

                            if ((!(MapObject.MouseObject is PlayerObject) || MapObject.MouseObject == MapObject.User || !CEnvir.Ctrl) && (GameScene.Game.MoveFrame && (MapControl.User.Poison & PoisonType.WraithGrip) != PoisonType.WraithGrip))
                            {
                                if (Functions.InRange(this.MapLocation, MapObject.User.CurrentLocation, 1) || haselementalhurricane)
                                {
                                    if (mirDirection3 == MapControl.User.Direction)
                                        return;
                                    MapObject.User.AttemptAction(new ObjectAction(MirAction.Standing, mirDirection3, MapObject.User.CurrentLocation, Array.Empty<object>()));
                                    return;
                                }
                                MapControl.Run(mirDirection3, true);
                                return;
                            }
                            break;
                    }
                }
                if (this.Mining)
                {
                    ClientUserItem clientUserItem = GameScene.Game.Equipment[0];
                    if (this.MapInfo.CanMine && clientUserItem != null && (clientUserItem.CurrentDurability > 0 || clientUserItem.Info.Durability == 0) && (clientUserItem.Info.Effect == ItemEffect.PickAxe && this.MiningPoint.X >= 0 && (this.MiningPoint.Y >= 0 && this.MiningPoint.X < this.Width)) && (this.MiningPoint.Y < this.Height && this.Cells[this.MiningPoint.X, this.MiningPoint.Y].Flag && Functions.Distance(this.MiningPoint, MapObject.User.CurrentLocation) == 1) && MapControl.User.Horse == HorseType.None)
                    {
                        if (CEnvir.Now > MapControl.User.AttackTime)
                            MapObject.User.AttemptAction(new ObjectAction(MirAction.Mining, Functions.DirectionFromPoint(MapObject.User.CurrentLocation, this.MiningPoint), MapObject.User.CurrentLocation, new object[1]
                            {
                (object) false
                            }));
                    }
                    else
                        this.Mining = false;
                }
                if (this.AutoPath)
                {
                    if (this.CurrentPath == null || this.CurrentPath.Count == 0)
                    {
                        this.AutoPath = false;
                        return;
                    }
                    if (!GameScene.Game.MoveFrame || (MapControl.User.Poison & PoisonType.WraithGrip) == PoisonType.WraithGrip)
                        return;
                    Client.Models.Node node1 = this.CurrentPath.SingleOrDefault<Client.Models.Node>((Func<Client.Models.Node, bool>)(x => MapControl.User.CurrentLocation == x.Location));
                    if (node1 != null)
                    {
                        Client.Models.Node node2;
                        do
                        {
                            node2 = this.CurrentPath.First<Client.Models.Node>();
                            this.CurrentPath.Remove(node2);
                        }
                        while (node2 != node1);
                    }
                    if (this.CurrentPath.Count > 0)
                    {
                        MirDirection dir = Functions.DirectionFromPoint(MapControl.User.CurrentLocation, this.CurrentPath.First<Client.Models.Node>().Location);
                        if (!this.CanMove(dir, 1))
                        {
                            this.CurrentPath = this.PathFinder.FindPath(MapObject.User.CurrentLocation, this.CurrentPath.Last<Client.Models.Node>().Location);
                            return;
                        }
                        int distance = 1;
                        if (GameScene.Game.CanRun && CEnvir.Now >= MapControl.User.NextRunTime && MapControl.User.BagWeight <= MapControl.User.Stats[Stat.BagWeight] && MapControl.User.WearWeight <= MapControl.User.Stats[Stat.WearWeight])
                        {
                            ++distance;
                            if ((uint)MapControl.User.Horse > 0U)
                                ++distance;
                        }
                        Client.Models.Node node2 = (Client.Models.Node)null;
                        for (int i = distance; i > 0; i--)
                        {
                            if (this.CanMove(dir, i))
                            {
                                node2 = this.CurrentPath.SingleOrDefault<Client.Models.Node>((Func<Client.Models.Node, bool>)(x => Functions.Move(MapControl.User.CurrentLocation, dir, i) == x.Location));
                                if (node2 != null)
                                {
                                    distance = i;
                                    break;
                                }
                            }
                        }
                        if (node2 != null)
                            MapObject.User.AttemptAction(new ObjectAction(MirAction.Moving, dir, Functions.Move(MapObject.User.CurrentLocation, dir, distance), new object[2]
                            {
                (object) distance,
                (object) MagicType.None
                            }));
                    }
                }
                if (MapObject.TargetObject == null || MapObject.TargetObject.Dead || ((MapObject.TargetObject.Race == ObjectType.Player || !string.IsNullOrEmpty(MapObject.TargetObject.PetOwner)) && (!Config.免SHIFT && !CEnvir.Shift) || Functions.InRange(MapObject.TargetObject.CurrentLocation, MapObject.User.CurrentLocation, 1)))
                    return;
                MirDirection mirDirection2 = Functions.DirectionFromPoint(MapObject.User.CurrentLocation, MapObject.TargetObject.CurrentLocation);
                if (!this.CanMove(mirDirection2, 1) || haselementalhurricane)
                {
                    MirDirection mirDirection1 = this.DirectionBest(mirDirection2, 1, MapObject.TargetObject.CurrentLocation);
                    if (mirDirection1 == mirDirection2)
                    {
                        if (mirDirection2 == MapControl.User.Direction)
                            return;
                        MapObject.User.AttemptAction(new ObjectAction(MirAction.Standing, mirDirection2, MapObject.User.CurrentLocation, Array.Empty<object>()));
                        return;
                    }
                    mirDirection2 = mirDirection1;
                }

                if (!haselementalhurricane && GameScene.Game.MoveFrame && (User.Poison & PoisonType.WraithGrip) != PoisonType.WraithGrip)
                    Run(mirDirection2, true);
            }
        }

        public void DigEarth()
        {
            if (!this.Mining)
                return;
            ClientUserItem clientUserItem = GameScene.Game.Equipment[0];
            if (this.MapInfo.CanMine && clientUserItem != null && (clientUserItem.CurrentDurability > 0 || clientUserItem.Info.Durability == 0) && (clientUserItem.Info.Effect == ItemEffect.PickAxe && this.MiningPoint.X >= 0 && (this.MiningPoint.Y >= 0 && this.MiningPoint.X < this.Width)) && (this.MiningPoint.Y < this.Height && this.Cells[this.MiningPoint.X, this.MiningPoint.Y].Flag && Functions.Distance(this.MiningPoint, MapObject.User.CurrentLocation) == 1) && MapControl.User.Horse == HorseType.None)
            {
                if (CEnvir.Now > MapControl.User.AttackTime)
                    MapObject.User.AttemptAction(new ObjectAction(MirAction.Mining, Functions.DirectionFromPoint(MapObject.User.CurrentLocation, this.MiningPoint), MapObject.User.CurrentLocation, new object[1]
                    {
            (object) false
                    }));
            }
            else
                this.Mining = false;
        }

        public void AutoWalkPath()
        {
            if (this.CurrentPath == null || this.CurrentPath.Count == 0)
            {
                this.AutoPath = false;
            }
            else
            {
                if (!GameScene.Game.MoveFrame || (MapControl.User.Poison & PoisonType.WraithGrip) == PoisonType.WraithGrip)
                    return;
                Client.Models.Node node1 = this.CurrentPath.SingleOrDefault<Client.Models.Node>((Func<Client.Models.Node, bool>)(x => MapControl.User.CurrentLocation == x.Location));
                if (node1 != null)
                {
                    Client.Models.Node node2;
                    do
                    {
                        node2 = this.CurrentPath.First<Client.Models.Node>();
                        this.CurrentPath.Remove(node2);
                    }
                    while (node2 != node1);
                }
                if (this.CurrentPath.Count <= 0)
                    return;
                MirDirection dir = Functions.DirectionFromPoint(MapControl.User.CurrentLocation, this.CurrentPath.First<Client.Models.Node>().Location);
                if (!this.CanMove(dir, 1))
                {
                    this.CurrentPath = this.PathFinder.FindPath(MapObject.User.CurrentLocation, this.CurrentPath.Last<Client.Models.Node>().Location);
                }
                else
                {
                    int distance = 1;
                    if (GameScene.Game.CanRun && CEnvir.Now >= MapControl.User.NextRunTime && MapControl.User.BagWeight <= MapControl.User.Stats[Stat.BagWeight] && MapControl.User.WearWeight <= MapControl.User.Stats[Stat.WearWeight])
                    {
                        ++distance;
                        if ((uint)MapControl.User.Horse > 0U)
                            ++distance;
                    }
                    Client.Models.Node node2 = (Client.Models.Node)null;
                    for (int i = distance; i > 0; i--)
                    {
                        if (this.CanMove(dir, i))
                        {
                            node2 = this.CurrentPath.SingleOrDefault<Client.Models.Node>((Func<Client.Models.Node, bool>)(x => Functions.Move(MapControl.User.CurrentLocation, dir, i) == x.Location));
                            if (node2 != null)
                            {
                                distance = i;
                                break;
                            }
                        }
                    }
                    if (node2 != null)
                        MapObject.User.AttemptAction(new ObjectAction(MirAction.Moving, dir, Functions.Move(MapObject.User.CurrentLocation, dir, distance), new object[2]
                        {
              (object) distance,
              (object) MagicType.None
                        }));
                }
            }
        }

        public bool ForceAttack(Point target)
        {
            if (this.AutoPath || Config.开始挂机 && (MapControl.User.Class == MirClass.Taoist || MapControl.User.Class == MirClass.Wizard))
                return false;
            bool flag = false;
            if (MapControl.CanAttackAction(MapObject.TargetObject))
            {
                if (Functions.Distance(target, MapObject.User.CurrentLocation) == 1)
                {
                    if (CEnvir.Now > MapControl.User.AttackTime && MapControl.User.Horse == HorseType.None)
                        MapObject.User.AttemptAction(new ObjectAction(MirAction.Attack, Functions.DirectionFromPoint(MapObject.User.CurrentLocation, target), MapObject.User.CurrentLocation, new object[3]
                        {
              (object) 0,
              (object) MagicType.None,
              (object) Element.None
                        }));
                    flag = true;
                }
                else
                {
                    bool bDetour = true;
                    MirDirection direction = Functions.DirectionFromPoint(MapObject.User.CurrentLocation, target);
                    if (bDetour)
                        direction = MapControl.Detour(direction, target, 1);
                    if (GameScene.Game.MoveFrame && (MapControl.User.Poison & PoisonType.WraithGrip) != PoisonType.WraithGrip)
                    {
                        int num = Functions.Distance(target, MapObject.User.CurrentLocation);
                        if (num == 2)
                            MapControl.Walk(direction);
                        else if (num > 2)
                            MapControl.Run(direction, bDetour);
                    }
                }
            }
            return flag;
        }

        public static bool CanAttackAction(MapObject target)
        {
            return target != null && !target.Dead && (target.Race == ObjectType.Monster && string.IsNullOrEmpty(target.PetOwner) || (CEnvir.Shift || Config.免SHIFT));
        }

        public void ProcessInput2()
        {
            bool bDetour = true;
            if (GameScene.Game.Observer || User == null || (MapControl.User.Dead || (MapControl.User.Poison & PoisonType.Paralysis) == PoisonType.Paralysis || MapControl.User.Buffs.Any<ClientBuffInfo>((Func<ClientBuffInfo, bool>)(x =>
            {
                if (x.Type != BuffType.DragonRepulse)
                    return x.Type == BuffType.FrostBite;
                return true;
            }))))
                return;
            if (MapControl.User.MagicAction != null)
            {
                if (CEnvir.Now < MapObject.User.NextActionTime || (uint)MapObject.User.ActionQueue.Count > 0U)
                    return;
                MapObject.User.AttemptAction(MapControl.User.MagicAction);
                MapControl.User.MagicAction = (ObjectAction)null;
                this.Mining = false;
            }
            bool haselementalhurricane = MapObject.User.VisibleBuffs.Contains(BuffType.ElementalHurricane);
            if (Config.开始挂机)
            {
                if (!haselementalhurricane)
                {
                    if (this.TargetObject == null || this.TargetObject.Dead || !Functions.InRange(this.TargetObject.CurrentLocation, MapControl.User.CurrentLocation, 10))
                    {
                        MapObject mapObject = null;

                        if (GameScene.Game.User.XunzhaoGuaiwuMoshi01)
                            mapObject = LaoSelectMonster();
                        else if (GameScene.Game.User.XunzhaoGuaiwuMoshi02)
                            mapObject = SelectMonster();
                        else if (!GameScene.Game.User.XunzhaoGuaiwuMoshi01 && !GameScene.Game.User.XunzhaoGuaiwuMoshi02)
                            mapObject = LaoSelectMonster();

                        int num;
                        if (mapObject != null)
                        {
                            int objectId1 = (int)mapObject.ObjectID;
                            uint? objectId2 = this.TargetObject?.ObjectID;
                            int valueOrDefault = (int)objectId2.GetValueOrDefault();
                            num = !(objectId1 == valueOrDefault & objectId2.HasValue) ? 1 : 0;
                        }
                        else
                            num = 0;
                        if (num != 0)
                            this.TargetObject = mapObject;
                        else
                            this.ChangeAutoFightLocation();
                    }
                    else
                        this.AndroidProcess();
                }
            }
            MirDirection mirDirection1 = this.MouseDirection();
            if (GameScene.Game.AutoRun && !haselementalhurricane)
            {
                if (!GameScene.Game.MoveFrame || (MapControl.User.Poison & PoisonType.WraithGrip) == PoisonType.WraithGrip)
                    return;
                MapControl.Run(mirDirection1, true);
            }
            else
            {
                if (DXControl.MouseControl == this)
                {
                    switch (this.MapButtons)
                    {
                        case MouseButtons.Left:
                            this.Mining = false;
                            if (this.MapLocation == MapObject.User.CurrentLocation)
                            {
                                
                                if (CEnvir.Now <= GameScene.Game.PickUpTime) return;

                                CEnvir.Enqueue(new C.PickUp());
                                GameScene.Game.PickUpTime = CEnvir.Now.AddMilliseconds(250);

                                return;
                            }
                            if (MapObject.TargetObject == null && (Config.免SHIFT || CEnvir.Shift))
                            {
                                if (!(CEnvir.Now > MapControl.User.AttackTime) || MapControl.User.Horse != HorseType.None)
                                    return;
                                MapObject.User.AttemptAction(new ObjectAction(MirAction.Attack, mirDirection1, MapObject.User.CurrentLocation, new object[3]
                                {
                  (object) 0,
                  (object) MagicType.None,
                  (object) Element.None
                                }));
                                return;
                            }
                            if (CEnvir.Alt)
                            {
                                if (MapControl.User.Horse != HorseType.None)
                                    return;
                                MapObject.User.AttemptAction(new ObjectAction(MirAction.Harvest, mirDirection1, MapObject.User.CurrentLocation, Array.Empty<object>()));
                                return;
                            }

                            
                            if (AutoPath)
                                AutoPath = false;

                            if (MapObject.MouseObject == null || MapObject.MouseObject.Race == ObjectType.Item || MapObject.MouseObject.Dead)
                            {
                                ClientUserItem clientUserItem = GameScene.Game.Equipment[0];
                                if (!haselementalhurricane && this.MapInfo.CanMine && clientUserItem != null && clientUserItem.Info.Effect == ItemEffect.PickAxe)
                                {
                                    this.MiningPoint = Functions.Move(MapControl.User.CurrentLocation, mirDirection1, 1);
                                    if (this.MiningPoint.X >= 0 && this.MiningPoint.Y >= 0 && (this.MiningPoint.X < this.Width && this.MiningPoint.Y < this.Height) && this.Cells[this.MiningPoint.X, this.MiningPoint.Y].Flag)
                                    {
                                        this.Mining = true;
                                        break;
                                    }
                                }
                                if (!this.CanMove(mirDirection1, 1) || haselementalhurricane)
                                {
                                    MirDirection mirDirection2 = mirDirection1;
                                    if (bDetour)
                                        mirDirection2 = this.MouseDirectionBest(mirDirection1, 1);
                                    if (mirDirection2 == mirDirection1)
                                    {
                                        if (mirDirection1 == MapControl.User.Direction)
                                            return;
                                        MapControl.Run(mirDirection1, bDetour);
                                        return;
                                    }
                                    mirDirection1 = mirDirection2;
                                }
                                if (!haselementalhurricane && !GameScene.Game.MoveFrame || (MapControl.User.Poison & PoisonType.WraithGrip) == PoisonType.WraithGrip)
                                    return;
                                MapControl.Walk(mirDirection1);
                                return;
                            }
                            break;
                        case MouseButtons.Right:
                            this.Mining = false;

                            
                            if (AutoPath)
                                AutoPath = false;


                            if ((!(MapObject.MouseObject is PlayerObject) || MapObject.MouseObject == MapObject.User || !CEnvir.Ctrl) && (GameScene.Game.MoveFrame && (MapControl.User.Poison & PoisonType.WraithGrip) != PoisonType.WraithGrip))
                            {
                                if (Functions.InRange(this.MapLocation, MapObject.User.CurrentLocation, 1) || haselementalhurricane)
                                {
                                    if (mirDirection1 == MapControl.User.Direction)
                                        return;
                                    MapObject.User.AttemptAction(new ObjectAction(MirAction.Standing, mirDirection1, MapObject.User.CurrentLocation, Array.Empty<object>()));
                                    return;
                                }
                                MapControl.Run(mirDirection1, bDetour);
                                return;
                            }
                            break;
                    }
                }
                if (MapObject.TargetObject != null)
                {
                    if (this.UpdateTarget < CEnvir.Now)
                    {
                        this.UpdateTarget = CEnvir.Now.AddMilliseconds(200.0);
                        this.TargetLocation = MapObject.TargetObject.CurrentLocation;
                    }
                    if (this.ForceAttack(this.TargetLocation))
                        return;
                }
                this.DigEarth();
                if (!this.AutoPath)
                    return;
                this.AutoWalkPath();
            }
        }

        public void ChangeAutoFightLocation()
        {
            if (this.pathfindertime >= CEnvir.Now || this.AutoPath)
                return;
            int x = MapControl.User.CurrentLocation.X;
            int y = MapControl.User.CurrentLocation.Y;
            if (Config.范围挂机)
            {
                Random random1 = CEnvir.Random;
                int minValue1 = (int)((long)Config.范围挂机坐标.X - Config.范围距离);
                Point androidCoord = Config.范围挂机坐标;
                int maxValue1 = (int)((long)androidCoord.X + Config.范围距离);
                x = random1.Next(minValue1, maxValue1);
                Random random2 = CEnvir.Random;
                androidCoord = Config.范围挂机坐标;
                int minValue2 = (int)((long)androidCoord.Y - Config.范围距离);
                androidCoord = Config.范围挂机坐标;
                int maxValue2 = (int)((long)androidCoord.Y + Config.范围距离);
                y = random2.Next(minValue2, maxValue2);
            }
            else if (Config.是否开启随机保护)
            {
                DXItemCell dxItemCell = ((IEnumerable<DXItemCell>)GameScene.Game.InventoryBox.Grid.Grid).FirstOrDefault<DXItemCell>((Func<DXItemCell, bool>)(X => X?.Item?.Info.ItemName == "随机传送卷"));
                if (dxItemCell != null && dxItemCell.UseItem())
                    this.ProtectTime = CEnvir.Now.AddSeconds(5.0);
            }
            else
            {
                Point currentLocation = MapControl.User.CurrentLocation;
                x = CEnvir.Random.Next(currentLocation.X - 5, currentLocation.X + 5);
                y = CEnvir.Random.Next(currentLocation.Y - 5, currentLocation.Y + 5);
            }
            List<Client.Models.Node> path = this.PathFinder.FindPath(MapControl.User.CurrentLocation, new Point(x, y));
            if (path == null || path.Count == 0)
                return;
            this.CurrentPath = path;
            this.AutoPath = true;
        }

        public void AndroidProcess()
        {
            if (this.AutoPath)
                return;
            if (this.TargetObject == null || this.TargetObject.Dead)
            {
                this.CurrentPath?.Clear();
            }
            else
            {
                if (!MapControl.CanAttackAction(this.TargetObject))
                    return;
                if (MapControl.User.Class == MirClass.Wizard || MapControl.User.Class == MirClass.Taoist)
                {
                    GameScene.Game.MagicObject = this.TargetObject;
                    if (Config.自动躲避 && Functions.Distance(MapControl.User.CurrentLocation, this.TargetObject.CurrentLocation) < 3)
                    {
                        MirDirection mirDirection1 = Functions.ShiftDirection(Functions.DirectionFromPoint(MapControl.User.CurrentLocation, this.TargetObject.CurrentLocation), 4);
                        if (!this.CanMove(mirDirection1, 1))
                        {
                            MirDirection mirDirection2 = this.DirectionBest(mirDirection1, 1, this.TargetObject.CurrentLocation);
                            if (mirDirection2 == mirDirection1)
                            {
                                if (mirDirection1 != MapControl.User.Direction)
                                    MapControl.User.AttemptAction(new ObjectAction(MirAction.Standing, mirDirection1, MapControl.User.CurrentLocation, Array.Empty<object>()));
                                if (!Config.是否开启挂机自动技能 || !Functions.InRange(this.TargetObject.CurrentLocation, MapControl.User.CurrentLocation, 10))
                                    return;
                                GameScene.Game.UseMagic(Config.挂机自动技能);
                                return;
                            }
                            mirDirection1 = mirDirection2;
                        }
                        if (GameScene.Game.MoveFrame && (MapControl.User.Poison & PoisonType.WraithGrip) != PoisonType.WraithGrip)
                        {
                            MapControl.User.AttemptAction(new ObjectAction(MirAction.Moving, mirDirection1, Functions.Move(MapControl.User.CurrentLocation, mirDirection1, 1), new object[2]
                            {
                (object) 1,
                (object) MagicType.None
                            }));
                            return;
                        }
                    }
                }
                if (Config.自动上毒 && MapControl.User.Class == MirClass.Taoist && Functions.InRange(MapObject.TargetObject.CurrentLocation, MapControl.User.CurrentLocation, 10) && ((MapObject.TargetObject.Poison & PoisonType.Red) != PoisonType.Red || (MapObject.TargetObject.Poison & PoisonType.Green) != PoisonType.Green))
                    GameScene.Game.UseMagic(MagicType.PoisonDust);
                if (Config.是否开启挂机自动技能 && (MapControl.User.Class == MirClass.Taoist || MapControl.User.Class == MirClass.Wizard))
                {
                    if (Functions.InRange(this.TargetObject.CurrentLocation, MapControl.User.CurrentLocation, 10))
                    {
                        GameScene.Game.UseMagic(Config.挂机自动技能);
                        return;
                    }
                    this.TargetObject = (MapObject)null;
                }
                if (Functions.Distance(MapControl.User.CurrentLocation, this.TargetObject.CurrentLocation) == 1 && CEnvir.Now > MapControl.User.AttackTime && MapControl.User.Horse == HorseType.None)
                    MapControl.User.AttemptAction(new ObjectAction(MirAction.Attack, Functions.DirectionFromPoint(MapControl.User.CurrentLocation, this.TargetObject.CurrentLocation), MapControl.User.CurrentLocation, new object[3]
                    {
            (object) 0,
            (object) MagicType.None,
            (object) Element.None
                    }));
            }
        }

        public MapObject LaoSelectMonster()
        {
            float num1 = 100f;
            ClientObjectData minob = (ClientObjectData)null;
            foreach (ClientObjectData clientObjectData in GameScene.Game.DataDictionary.Values)
            {
                if (GameScene.Game.MapControl.MapInfo != null && clientObjectData.MapIndex == GameScene.Game.MapControl.MapInfo.Index && (clientObjectData.ItemInfo == null && clientObjectData.MonsterInfo != null) && !clientObjectData.Dead && ((clientObjectData.MonsterInfo == null || !clientObjectData.Dead) && string.IsNullOrEmpty(clientObjectData.PetOwner) && clientObjectData.MonsterInfo.AI >= 0) && (!Config.范围挂机 || clientObjectData.Location.X >= (int)(Config.范围挂机坐标.X - Config.范围距离) && clientObjectData.Location.X <= (int)(Config.范围挂机坐标.X + Config.范围距离) && (clientObjectData.Location.Y >= (int)(Config.范围挂机坐标.Y - Config.范围距离) && clientObjectData.Location.Y <= (int)(Config.范围挂机坐标.Y + Config.范围距离))))
                {
                    float num2 = (float)Functions.Distance(GameScene.Game.User.CurrentLocation, clientObjectData.Location);
                    if ((double)num2 < (double)num1)
                    {
                        num1 = num2;
                        minob = clientObjectData;
                    }
                }
            }
            if (minob == null)
                return (MapObject)null;
            if (User.Class == MirClass.Assassin || User.Class == MirClass.Warrior)
            {
                MirDirection direction = Functions.DirectionFromPoint(minob.Location, GameScene.Game.User.CurrentLocation);
                Point target = Functions.Move(minob.Location, direction, 1);
                if (minob.MapIndex != GameScene.Game.MapControl.MapInfo.Index)
                    return (MapObject)null;
                List<Client.Models.Node> path = GameScene.Game.MapControl.PathFinder.FindPath(MapObject.User.CurrentLocation, target);
                if (path == null || path.Count == 0 || (double)path.Count > (double)num1)
                    return (MapObject)null;
                path.Clear();
            }
            if ((double)num1 > 9.0)
                return (MapObject)null;
            return GameScene.Game.MapControl.Objects.FirstOrDefault<MapObject>((Func<MapObject, bool>)(x => (int)x.ObjectID == (int)minob.ObjectID));
        }

        public MapObject SelectMonster()
        {
            int num1 = 100;
            ClientObjectData minob = (ClientObjectData)null;
            List<Client.Models.Node> nodeList = (List<Client.Models.Node>)null;
            foreach (ClientObjectData clientObjectData in GameScene.Game.DataDictionary.Values)
            {
                int mapIndex = clientObjectData.MapIndex;
                int? index = GameScene.Game.MapControl?.MapInfo?.Index;
                int valueOrDefault = index.GetValueOrDefault();
                if (mapIndex == valueOrDefault & index.HasValue && clientObjectData.ItemInfo == null && (clientObjectData.MonsterInfo != null && clientObjectData.MonsterInfo.Index != 16) && !clientObjectData.Dead && ((clientObjectData.MonsterInfo == null || !clientObjectData.Dead) && string.IsNullOrEmpty(clientObjectData.PetOwner) && (clientObjectData.MonsterInfo.AI >= 0 && clientObjectData.MapIndex == GameScene.Game.MapControl.MapInfo.Index)))
                {
                    if (Config.范围挂机)
                    {
                        int x1 = clientObjectData.Location.X;
                        Point androidCoord = Config.范围挂机坐标;
                        int num2 = (int)((long)androidCoord.X - Config.范围距离);
                        int num3;
                        if (x1 >= num2)
                        {
                            int x2 = clientObjectData.Location.X;
                            androidCoord = Config.范围挂机坐标;
                            int num4 = (int)((long)androidCoord.X + Config.范围距离);
                            num3 = x2 > num4 ? 1 : 0;
                        }
                        else
                            num3 = 1;
                        if (num3 == 0)
                        {
                            int y1 = clientObjectData.Location.Y;
                            androidCoord = Config.范围挂机坐标;
                            int num4 = (int)((long)androidCoord.Y - Config.范围距离);
                            int num5;
                            if (y1 >= num4)
                            {
                                int y2 = clientObjectData.Location.Y;
                                androidCoord = Config.范围挂机坐标;
                                int num6 = (int)((long)androidCoord.Y + Config.范围距离);
                                num5 = y2 > num6 ? 1 : 0;
                            }
                            else
                                num5 = 1;
                            if (num5 != 0)
                                continue;
                        }
                        else
                            continue;
                    }
                    int num7 = Functions.Distance(GameScene.Game.User.CurrentLocation, clientObjectData.Location);
                    if (minob == null)
                    {
                        minob = clientObjectData;
                        num1 = num7;
                    }
                    else
                    {
                        if (num7 < num1)
                        {
                            num1 = num7;
                            minob = clientObjectData;
                        }
                        if ((MapControl.User.Class == MirClass.Assassin || (uint)MapControl.User.Class <= 0U) && Functions.InRange(clientObjectData.Location, MapControl.User.CurrentLocation, 10))
                        {
                            List<Client.Models.Node> path = this.PathFinder.FindPath(MapControl.User.CurrentLocation, Functions.PointNearTarget(MapControl.User.CurrentLocation, clientObjectData.Location, 1));
                            if (path != null && num7 + 25 >= path.Count)
                                nodeList = path;
                        }
                    }
                }
            }
            if (nodeList != null && nodeList.Count > 0)
            {
                this.CurrentPath = nodeList;
                this.AutoPath = true;
            }
            return this.Objects.FirstOrDefault<MapObject>((Func<MapObject, bool>)(x =>
            {
                int objectId1 = (int)x.ObjectID;
                uint? objectId2 = minob?.ObjectID;
                int valueOrDefault = (int)objectId2.GetValueOrDefault();
                return objectId1 == valueOrDefault & objectId2.HasValue;
            }));
        }

        /*
        public void ProcessInput()
        {
            if (GameScene.Game.Observer || (MapControl.User.Dead || (MapControl.User.Poison & PoisonType.Paralysis) == PoisonType.Paralysis || MapControl.User.Buffs.Any<ClientBuffInfo>((Func<ClientBuffInfo, bool>)(x =>
            {
                if (x.Type != BuffType.DragonRepulse)
                    return x.Type == BuffType.FrostBite;
                return true;
            }))))
                return;
            if (MapControl.User.MagicAction != null)
            {
                if (CEnvir.Now < MapObject.User.NextActionTime || (uint)MapObject.User.ActionQueue.Count > 0U)
                    return;
                MapObject.User.AttemptAction(MapControl.User.MagicAction);
                MapControl.User.MagicAction = (ObjectAction)null;
                Mining = false;
            }
            bool haselementalhurricane = MapObject.User.VisibleBuffs.Contains(BuffType.ElementalHurricane);
            int num1;
            if (!haselementalhurricane && MapObject.TargetObject != null && !MapObject.TargetObject.Dead)
            {
                if (MapObject.TargetObject.Race != ObjectType.Monster || !string.IsNullOrEmpty(MapObject.TargetObject.PetOwner))
                {
                    if (!CEnvir.Shift)
                    {
                        GameScene game = GameScene.Game;
                        num1 = game != null ? (game.AutoPotionBox.ckCheckBox.Checked ? 1 : 0) : 0;
                    }
                    else
                        num1 = 1;
                }
                else
                    num1 = 1;
            }
            else
                num1 = 0;
            if (num1 != 0)
            {
                bool flag = true;
                if (GameScene.Game.AutoPotionBox.SetAutoOnHookBox.Checked)
                {
                    pathfindertime = CEnvir.Now.AddSeconds(2.0);
                    if (GameScene.Game.AutoPotionBox.SetAutoAvoidBox.Checked && ((MapControl.User.Class == MirClass.Wizard || MapControl.User.Class == MirClass.Taoist) && (double)Functions.Distance(MapObject.User.CurrentLocation, MapObject.TargetObject.CurrentLocation) < 3.0))
                    {
                        MirDirection mirDirection1 = Functions.ShiftDirection(Functions.DirectionFromPoint(MapObject.User.CurrentLocation, MapObject.TargetObject.CurrentLocation), 4);
                        if (!CanMove(mirDirection1, 1))
                        {
                            MirDirection mirDirection2 = DirectionBest(mirDirection1, 1, MapObject.TargetObject.CurrentLocation);
                            if (mirDirection2 == mirDirection1)
                            {
                                if (mirDirection1 != MapControl.User.Direction)
                                    MapObject.User.AttemptAction(new ObjectAction(MirAction.Standing, mirDirection1, MapObject.User.CurrentLocation, new object[0]));
                                if (!(GameScene.Game.AutoPotionBox.SetSingleHookSkillsComboBox.SelectedItem is MagicType) || !Functions.InRange(MapObject.TargetObject.CurrentLocation, MapControl.User.CurrentLocation, 10))
                                    return;
                                GameScene.Game.UseMagic((MagicType)GameScene.Game.AutoPotionBox.SetSingleHookSkillsComboBox.SelectedItem);
                                return;
                            }
                            mirDirection1 = mirDirection2;
                        }
                        if (GameScene.Game.MoveFrame && (MapControl.User.Poison & PoisonType.WraithGrip) != PoisonType.WraithGrip)
                        {
                            MapObject.User.AttemptAction(new ObjectAction(MirAction.Moving, mirDirection1, Functions.Move(MapObject.User.CurrentLocation, mirDirection1, 1), new object[2]
                            {
                (object) 1,
                (object) MagicType.None
                            }));
                            return;
                        }
                    }
                    if (Config.AndroidPoisonDust && MapControl.User.Class == MirClass.Taoist && Functions.InRange(MapObject.TargetObject.CurrentLocation, MapControl.User.CurrentLocation, 10) && ((MapObject.TargetObject.Poison & PoisonType.Red) != PoisonType.Red || (MapObject.TargetObject.Poison & PoisonType.Green) != PoisonType.Green))
                    {
                        GameScene.Game.UseMagic(MagicType.PoisonDust);
                        return;
                    }
                    if ((MapControl.User.Class == MirClass.Taoist || MapControl.User.Class == MirClass.Wizard) && GameScene.Game.AutoPotionBox.SetSingleHookSkillsComboBox.SelectedItem is MagicType && Functions.InRange(MapObject.TargetObject.CurrentLocation, MapControl.User.CurrentLocation, 10))
                    {
                        GameScene.Game.UseMagic((MagicType)GameScene.Game.AutoPotionBox.SetSingleHookSkillsComboBox.SelectedItem);
                        return;
                    }
                }
                if (Functions.Distance(MapObject.TargetObject.CurrentLocation, MapObject.User.CurrentLocation) == 1 && CEnvir.Now > MapControl.User.AttackTime && MapControl.User.Horse == HorseType.None)
                {
                    if (GameScene.Game.AutoPotionBox.SetAutoOnHookBox.Checked && (flag && MapControl.User.Class == MirClass.Assassin && GameScene.Game.AutoPotionBox.SetSingleHookSkillsComboBox.SelectedItem is MagicType && Functions.InRange(MapObject.TargetObject.CurrentLocation, MapControl.User.CurrentLocation, 10)))
                        GameScene.Game.UseMagic((MagicType)GameScene.Game.AutoPotionBox.SetSingleHookSkillsComboBox.SelectedItem);
                    MapObject.User.AttemptAction(new ObjectAction(MirAction.Attack, Functions.DirectionFromPoint(MapObject.User.CurrentLocation, MapObject.TargetObject.CurrentLocation), MapObject.User.CurrentLocation, new object[3]
                    {
            (object) 0,
            (object) MagicType.None,
            (object) Element.None
                    }));
                    return;
                }
            }
            else if (GameScene.Game.AutoPotionBox.SetAutoOnHookBox.Checked && (pathfindertime < CEnvir.Now && !GameScene.Game.MapControl.AutoPath))
            {
                int x;
                int y;
                if (GameScene.Game.AutoPotionBox.FixedComBox.Checked)
                {
                    x = CEnvir.Random.Next((int)(GameScene.Game.AutoPotionBox.XBox.Value - GameScene.Game.AutoPotionBox.RBox.Value), (int)(GameScene.Game.AutoPotionBox.XBox.Value + GameScene.Game.AutoPotionBox.RBox.Value));
                    y = CEnvir.Random.Next((int)(GameScene.Game.AutoPotionBox.YBox.Value - GameScene.Game.AutoPotionBox.RBox.Value), (int)(GameScene.Game.AutoPotionBox.YBox.Value + GameScene.Game.AutoPotionBox.RBox.Value));
                }
                else
                {
                    x = CEnvir.Random.Next(10, GameScene.Game.MapControl.Width - 10);
                    y = CEnvir.Random.Next(10, GameScene.Game.MapControl.Height - 10);
                }
                List<Client.Models.Node> path = GameScene.Game.MapControl.PathFinder.FindPath(MapObject.User.CurrentLocation, new Point(x, y));
                if (path != null && path.Count != 0)
                {
                    GameScene.Game.MapControl.CurrentPath = path;
                    GameScene.Game.MapControl.AutoPath = true;
                }
            }
            MirDirection mirDirection3 = MouseDirection();
            if (GameScene.Game.AutoRun && !haselementalhurricane)
            {
                if (!GameScene.Game.MoveFrame || (MapControl.User.Poison & PoisonType.WraithGrip) == PoisonType.WraithGrip)
                    return;
                Run(mirDirection3);
            }
            else if (!GameScene.Game.AutoRun)
            {
                if (DXControl.MouseControl == this)
                {
                    switch (MapButtons)
                    {
                        case MouseButtons.Left:
                            Mining = false;
                            int num2;
                            if (MapObject.TargetObject == null)
                            {
                                GameScene game = GameScene.Game;
                                num2 = (game != null ? (game.AutoPotionBox.tyCheckBox1.Checked ? 1 : 0) : 0) != 0 ? 1 : (CEnvir.Shift ? 1 : 0);
                            }
                            else
                                num2 = 0;
                            if (num2 != 0)
                            {
                                if (!(CEnvir.Now > MapControl.User.AttackTime) || MapControl.User.Horse != HorseType.None || haselementalhurricane)
                                    return;
                                MapObject.User.AttemptAction(new ObjectAction(MirAction.Attack, mirDirection3, MapObject.User.CurrentLocation, new object[3]
                                {
                  (object) 0,
                  (object) MagicType.None,
                  (object) Element.None
                                }));
                                return;
                            }
                            if (CEnvir.Alt)
                            {
                                if (MapControl.User.Horse == HorseType.None && !haselementalhurricane)
                                {
                                    MapObject.User.AttemptAction(new ObjectAction(MirAction.Harvest, mirDirection3, MapObject.User.CurrentLocation, new object[0]));
                                }
                                return;
                            }

                            
                            if (AutoPath)
                                AutoPath = false;

                            if (MapLocation == MapObject.User.CurrentLocation)
                            {
                                GameScene.Game?.BigPatchBox?.PickupItems();
                            }

                          
                            if (MapObject.MouseObject == null || MapObject.MouseObject.Race == ObjectType.Item || MapObject.MouseObject.Dead)
                            {
                                ClientUserItem clientUserItem = GameScene.Game.Equipment[0];
                                if (!haselementalhurricane && MapInfo.CanMine && clientUserItem != null && clientUserItem.Info.Effect == ItemEffect.PickAxe)
                                {
                                    MiningPoint = Functions.Move(MapControl.User.CurrentLocation, mirDirection3, 1);
                                    if (MiningPoint.X >= 0 && MiningPoint.Y >= 0 && (MiningPoint.X < Width && MiningPoint.Y < Height) && Cells[MiningPoint.X, MiningPoint.Y].Flag)
                                    {
                                        Mining = true;
                                        break;
                                    }
                                }
                                if (!CanMove(mirDirection3, 1) || haselementalhurricane)
                                {
                                    MirDirection mirDirection1 = MouseDirectionBest(mirDirection3, 1);
                                    if (mirDirection1 == mirDirection3)
                                    {
                                        if (mirDirection3 == MapControl.User.Direction)
                                            return;
                                        MapObject.User.AttemptAction(new ObjectAction(MirAction.Standing, mirDirection3, MapObject.User.CurrentLocation, new object[0]));
                                        return;
                                    }
                                    mirDirection3 = mirDirection1;
                                }
                                if (!haselementalhurricane && GameScene.Game.MoveFrame && (User.Poison & PoisonType.WraithGrip) != PoisonType.WraithGrip)
                                    MapObject.User.AttemptAction(new ObjectAction(MirAction.Moving, mirDirection3, Functions.Move(MapObject.User.CurrentLocation, mirDirection3), 1, MagicType.None));
                                return;
                            }
                            break;
                        case MouseButtons.Right:
                            Mining = false;

                            
                            if (AutoPath)
                                AutoPath = false;

                            if ((!(MapObject.MouseObject is PlayerObject) || MapObject.MouseObject == MapObject.User || !CEnvir.Ctrl) && (GameScene.Game.MoveFrame && (MapControl.User.Poison & PoisonType.WraithGrip) != PoisonType.WraithGrip))
                            {
                                if (Functions.InRange(MapLocation, MapObject.User.CurrentLocation, 1) || haselementalhurricane)
                                {
                                    if (mirDirection3 == MapControl.User.Direction)
                                        return;
                                    MapObject.User.AttemptAction(new ObjectAction(MirAction.Standing, mirDirection3, MapObject.User.CurrentLocation, new object[0]));
                                    return;
                                }
                                Run(mirDirection3);
                                return;
                            }
                            break;
                    }
                }
                if (Mining)
                {
                    ClientUserItem clientUserItem = GameScene.Game.Equipment[0];
                    if (MapInfo.CanMine && clientUserItem != null && (clientUserItem.CurrentDurability > 0 || clientUserItem.Info.Durability == 0) && (clientUserItem.Info.Effect == ItemEffect.PickAxe && MiningPoint.X >= 0 && (MiningPoint.Y >= 0 && MiningPoint.X < Width)) && (MiningPoint.Y < Height && Cells[MiningPoint.X, MiningPoint.Y].Flag && Functions.Distance(MiningPoint, MapObject.User.CurrentLocation) == 1) && MapControl.User.Horse == HorseType.None)
                    {
                        if (CEnvir.Now > MapControl.User.AttackTime)
                            MapObject.User.AttemptAction(new ObjectAction(MirAction.Mining, Functions.DirectionFromPoint(MapObject.User.CurrentLocation, MiningPoint), MapObject.User.CurrentLocation, new object[1]
                            {
                (object) false
                            }));
                    }
                    else
                        Mining = false;
                }
                if (AutoPath)
                {
                    if (CurrentPath == null || CurrentPath.Count == 0)
                    {
                        AutoPath = false;
                        return;
                    }
                    if (!GameScene.Game.MoveFrame || (MapControl.User.Poison & PoisonType.WraithGrip) == PoisonType.WraithGrip)
                        return;
                    Client.Models.Node node1 = CurrentPath.SingleOrDefault<Client.Models.Node>((Func<Client.Models.Node, bool>)(x => MapControl.User.CurrentLocation == x.Location));
                    if (node1 != null)
                    {
                        Node node2;
                        do
                        {
                            node2 = CurrentPath.First<Node>();
                            CurrentPath.Remove(node2);
                        }
                        while (node2 != node1);
                    }
                    if (CurrentPath.Count > 0)
                    {
                        MirDirection dir = Functions.DirectionFromPoint(MapControl.User.CurrentLocation, CurrentPath.First<Client.Models.Node>().Location);
                        if (!CanMove(dir, 1))
                        {
                            CurrentPath = PathFinder.FindPath(MapObject.User.CurrentLocation, CurrentPath.Last<Client.Models.Node>().Location);
                            return;
                        }
                        int distance = 1;
                        if (GameScene.Game.CanRun && CEnvir.Now >= MapControl.User.NextRunTime && MapControl.User.BagWeight <= MapControl.User.Stats[Stat.BagWeight] && MapControl.User.WearWeight <= MapControl.User.Stats[Stat.WearWeight])
                        {
                            ++distance;
                            if ((uint)MapControl.User.Horse > 0U)
                                ++distance;
                        }
                        Client.Models.Node node2 = (Client.Models.Node)null;
                        for (int i = distance; i > 0; i--)
                        {
                            if (CanMove(dir, i))
                            {
                                node2 = CurrentPath.SingleOrDefault<Client.Models.Node>((Func<Client.Models.Node, bool>)(x => Functions.Move(MapControl.User.CurrentLocation, dir, i) == x.Location));
                                if (node2 != null)
                                {
                                    distance = i;
                                    break;
                                }
                            }
                        }
                        if (node2 != null)
                            MapObject.User.AttemptAction(new ObjectAction(MirAction.Moving, dir, Functions.Move(MapObject.User.CurrentLocation, dir, distance), new object[2]
                            {
                (object) distance,
                (object) MagicType.None
                            }));
                    }
                }
                if (MapObject.TargetObject == null || MapObject.TargetObject.Dead)
                    return;
                int num3;
                if (MapObject.TargetObject.Race == ObjectType.Player || !string.IsNullOrEmpty(MapObject.TargetObject.PetOwner))
                {
                    GameScene game = GameScene.Game;
                    num3 = (game != null ? (game.AutoPotionBox.tyCheckBox1.Checked ? 1 : 0) : 0) != 0 ? 0 : (!CEnvir.Shift ? 1 : 0);
                }
                else
                    num3 = 0;
                if (num3 != 0 || Functions.InRange(MapObject.TargetObject.CurrentLocation, MapObject.User.CurrentLocation, 1))
                    return;
                MirDirection mirDirection2 = Functions.DirectionFromPoint(MapObject.User.CurrentLocation, MapObject.TargetObject.CurrentLocation);
                if (!CanMove(mirDirection2, 1) || haselementalhurricane)
                {
                    MirDirection mirDirection1 = DirectionBest(mirDirection2, 1, MapObject.TargetObject.CurrentLocation);
                    if (mirDirection1 == mirDirection2)
                    {
                        if (mirDirection2 == MapControl.User.Direction)
                            return;
                        MapObject.User.AttemptAction(new ObjectAction(MirAction.Standing, mirDirection2, MapObject.User.CurrentLocation, new object[0]));
                        return;
                    }
                    mirDirection2 = mirDirection1;
                }
                if (!haselementalhurricane && GameScene.Game.MoveFrame && (User.Poison & PoisonType.WraithGrip) != PoisonType.WraithGrip)
                    
                    Run(mirDirection2);
            }
        }
         */

        public static MirDirection Detour(MirDirection direction, Point targ, int step)
        {
            MirDirection mirDirection = direction;
            if (!GameScene.Game.MapControl.CanMove(direction, step))
                mirDirection = GameScene.Game.MapControl.DirectionBest(direction, step, targ);
            return mirDirection;
        }

        public static void Walk(MirDirection direction)
        {
            MapObject.User.Moving(direction, 1);
        }

        public static void Run(MirDirection direction, bool bDetour = true)
        {
            int steps = 1;

            
            
            if (User.Mingwen01 == 148 || User.Mingwen02 == 148 || User.Mingwen03 == 148)
            {
                MingwenInfo Mingweninfo = CartoonGlobals.MingwenInfoList.Binding.FirstOrDefault((MingwenInfo x) => x.MingWenID == 148);
                ClientBuffInfo buff = User.Buffs.FirstOrDefault(x => x.Type == BuffType.MoveSpeed);
                if (buff != null)
                {
                    steps = Mingweninfo.Canshu2 - 1;
                }
            }
            
            
            else if (User.Mingwen01 == 196 || User.Mingwen02 == 196 || User.Mingwen03 == 196)
            {
                MingwenInfo Mingweninfo = CartoonGlobals.MingwenInfoList.Binding.FirstOrDefault((MingwenInfo x) => x.MingWenID == 196);
                ClientBuffInfo buff = User.Buffs.FirstOrDefault(x => x.Type == BuffType.MoveSpeed);
                if (buff != null)
                {
                    steps = Mingweninfo.Canshu2 - 1;
                }
            }

            if (Config.免助跑 || GameScene.Game.CanRun && CEnvir.Now >= MapControl.User.NextRunTime && MapControl.User.BagWeight <= MapControl.User.Stats[Stat.BagWeight] && MapControl.User.WearWeight <= MapControl.User.Stats[Stat.WearWeight])
            {
                ++steps;
                if ((uint)MapControl.User.Horse > 0U)
                    ++steps;
            }
            for (int distance2 = 1; distance2 <= steps; ++distance2)
            {
                if (!GameScene.Game.MapControl.CanMove(direction, distance2))
                {
                    MirDirection mirDirection = direction;
                    if (bDetour)
                        mirDirection = GameScene.Game.MapControl.MouseDirectionBest(direction, 1);
                    if (mirDirection == direction)
                    {
                        if (distance2 == 1)
                        {
                            if (direction == MapControl.User.Direction)
                                return;
                            MapObject.User.AttemptAction(new ObjectAction(MirAction.Standing, direction, MapObject.User.CurrentLocation, Array.Empty<object>()));
                            return;
                        }
                        steps = distance2 - 1;
                    }
                    else
                        steps = 1;
                    direction = mirDirection;
                    break;
                }
            }
            MapObject.User.AttemptAction(new ObjectAction(MirAction.Moving, direction, Functions.Move(MapObject.User.CurrentLocation, direction, steps), new object[2]
            {
        (object) steps,
        (object) MagicType.None
            }));
        }

        /*
        public void Run(MirDirection direction)
        {
            int steps = 1;

            
            
            if (User.Mingwen01 == 148 || User.Mingwen02 == 148 || User.Mingwen03 == 148)
            {
                MingwenInfo Mingweninfo = CartoonGlobals.MingwenInfoList.Binding.FirstOrDefault((MingwenInfo x) => x.MingWenID == 148);
                ClientBuffInfo buff = User.Buffs.FirstOrDefault(x => x.Type == BuffType.MoveSpeed);
                if (buff != null)
                {
                    steps = Mingweninfo.Canshu2 - 1;
                }
            }
            
            
            else if (User.Mingwen01 == 196 || User.Mingwen02 == 196 || User.Mingwen03 == 196)
            {
                MingwenInfo Mingweninfo = CartoonGlobals.MingwenInfoList.Binding.FirstOrDefault((MingwenInfo x) => x.MingWenID == 196);
                ClientBuffInfo buff = User.Buffs.FirstOrDefault(x => x.Type == BuffType.MoveSpeed);
                if (buff != null)
                {
                    steps = Mingweninfo.Canshu2 - 1;
                }
            }

            if (GameScene.Game.AutoPotionBox.CheckRunUp())
            {
                GameScene.Game.CanRun = true;
            }

            if (GameScene.Game.CanRun && User.BagWeight <= User.Stats[Stat.BagWeight] && User.WearWeight <= User.Stats[Stat.WearWeight])
            {
                steps++;
                if (User.Horse != HorseType.None)
                    steps++;
            }

            for (int i = 1; i <= steps; i++)
            {
                if (CanMove(direction, i)) continue;

                MirDirection best = MouseDirectionBest(direction, 1);

                if (best == direction)
                {
                    if (i == 1)
                    {
                        if (direction != User.Direction)
                            MapObject.User.AttemptAction(new ObjectAction(MirAction.Standing, direction, MapObject.User.CurrentLocation));
                        return;
                    }

                    steps = i - 1;
                }
                else
                {
                    steps = 1;
                }
                direction = best;
                break;
            }

            MapObject.User.AttemptAction(new ObjectAction(MirAction.Moving, direction, Functions.Move(MapObject.User.CurrentLocation, direction, steps), steps, MagicType.None));
        }
        */
        public MirDirection MouseDirectionBest(MirDirection dir, int distance) 
        {

            Point loc = Functions.Move(MapObject.User.CurrentLocation, dir, distance);

            if (loc.X >= 0 && loc.Y >= 0 && loc.X < Width && loc.Y < Height && !Cells[loc.X, loc.Y].Blocking()) return dir;


            PointF c = new PointF(OffSetX * CellWidth + CellWidth / 2F, OffSetY * CellHeight + CellHeight / 2F);
            PointF a = new PointF(c.X, 0);
            PointF b = MouseLocation;
            float bc = (float)Functions.Distance(c, b);
            float ac = bc;
            b.Y -= c.Y;
            c.Y += bc;
            b.Y += bc;
            double ab = (float)Functions.Distance(b, a);
            double x = (ac * ac + bc * bc - ab * ab) / (2 * ac * bc);
            double angle = Math.Acos(x);

            angle *= 180 / Math.PI;

            if (MouseLocation.X < c.X) angle = 360 - angle;

            MirDirection best = (MirDirection)(angle / 45F);

            if (best == dir)
                best = Functions.ShiftDirection(dir, 1);

            MirDirection next = Functions.ShiftDirection(dir, -((int)best - (int)dir));

            if (CanMove(best, distance))
                return best;

            if (CanMove(next, distance))
                return next;

            return dir;
        }
        public MirDirection DirectionBest(MirDirection dir, int distance, Point targetLocation) 
        {
            Point loc = Functions.Move(MapObject.User.CurrentLocation, dir, distance);

            if (loc.X >= 0 && loc.Y >= 0 && loc.X < Width && loc.Y < Height && !Cells[loc.X, loc.Y].Blocking()) return dir;


            PointF c = new PointF(MapObject.OffSetX * MapObject.CellWidth + MapObject.CellWidth / 2F, MapObject.OffSetY * MapObject.CellHeight + MapObject.CellHeight / 2F);
            PointF a = new PointF(c.X, 0);
            PointF b = new PointF((targetLocation.X - MapObject.User.CurrentLocation.X + MapObject.OffSetX) * MapObject.CellWidth + MapObject.CellWidth / 2F,
                (targetLocation.Y - MapObject.User.CurrentLocation.Y + MapObject.OffSetY) * MapObject.CellHeight + MapObject.CellHeight / 2F);
            float bc = (float)Functions.Distance(c, b);
            float ac = bc;
            b.Y -= c.Y;
            c.Y += bc;
            b.Y += bc;
            double ab = (float)Functions.Distance(b, a);
            double x = (ac * ac + bc * bc - ab * ab) / (2 * ac * bc);
            double angle = Math.Acos(x);

            angle *= 180 / Math.PI;

            if (b.X < c.X) angle = 360 - angle;

            MirDirection best = (MirDirection)(angle / 45F);

            if (best == dir)
                best = Functions.ShiftDirection(dir, 1);

            MirDirection next = Functions.ShiftDirection(dir, -((int)best - (int)dir));

            if (CanMove(best, distance))
                return best;

            return CanMove(next, distance) ? next : dir;
        }

        private bool CanMove(MirDirection dir, int distance)
        {
            for (int i = 1; i <= distance; i++)
            {
                Point loc = Functions.Move(User.CurrentLocation, dir, i);

                if (loc.X < 0 || loc.Y < 0 || loc.X >= Width || loc.Y > Height) return false;

                if (Cells[loc.X, loc.Y].Blocking())
                    return false;
            }
            return true;
        }

        public bool EmptyCell(Point loc)
        {
            return loc.X >= 0 && loc.Y >= 0 && loc.X < Width && loc.Y <= Height && !Cells[loc.X, loc.Y].Blocking();
        }

        public MirDirection MouseDirection() 
        {
            PointF p = new PointF(MouseLocation.X / CellWidth, MouseLocation.Y / CellHeight);

            
            if (Functions.InRange(new Point(OffSetX, OffSetY), Point.Truncate(p), 2))
                return Functions.DirectionFromPoint(new Point(OffSetX, OffSetY), Point.Truncate(p));

            PointF c = new PointF(OffSetX * CellWidth + CellWidth / 2F, OffSetY * CellHeight + CellHeight / 2F);
            PointF a = new PointF(c.X, 0);
            PointF b = new PointF(MouseLocation.X, MouseLocation.Y);
            float bc = (float)Functions.Distance(c, b);
            float ac = bc;
            b.Y -= c.Y;
            c.Y += bc;
            b.Y += bc;
            float ab = (float)Functions.Distance(b, a);
            double x = (ac * ac + bc * bc - ab * ab) / (2 * ac * bc);
            double angle = Math.Acos(x);

            angle *= 180 / Math.PI;

            if (MouseLocation.X < c.X) angle = 360 - angle;
            angle += 22.5F;
            if (angle > 360) angle -= 360;


            return (MirDirection)(angle / 45F);
        }

        public void AddObject(MapObject ob)
        {
            Objects.Add(ob);


            if (ob.CurrentLocation.X < Width && ob.CurrentLocation.Y < Height)
                Cells[ob.CurrentLocation.X, ob.CurrentLocation.Y].AddObject(ob);

        }

        public void RemoveObject(MapObject ob)
        {
            ob.OnRemoved();
            Objects.Remove(ob);

            if (ob.CurrentLocation.X < Width && ob.CurrentLocation.Y < Height)
                Cells[ob.CurrentLocation.X, ob.CurrentLocation.Y].RemoveObject(ob);
        }

        public bool CanAttack(MapObject ob)
        {
            if (ob == null || ob == User) return false;

            switch (ob.Race)
            {
                case ObjectType.Player:
                    break;
                case ObjectType.Monster:
                    MonsterObject mob = (MonsterObject)ob;

                    if (mob.MonsterInfo.AI < 0) return false;

                    break;
                default:
                    return false;
            }

            return !ob.Dead;
        }

        public void UpdateMapLocation()
        {
            if (User == null) return;


            GameScene.Game.MapControl.MapLocation = new Point((GameScene.Game.MapControl.MouseLocation.X - GameScene.Game.Location.X) / CellWidth - OffSetX + User.CurrentLocation.X,
                                                              (GameScene.Game.MapControl.MouseLocation.Y - GameScene.Game.Location.Y) / CellHeight - OffSetY + User.CurrentLocation.Y);
        }

        public bool HasTarget(Point loc)
        {
            if (loc.X < 0 || loc.Y < 0 || loc.X >= Width || loc.Y > Height) return false;

            Cell cell = Cells[loc.X, loc.Y];

            if (cell.Objects == null) return false;

            foreach (MapObject ob in cell.Objects)
                if (ob.Blocking) return true;

            return false;
        }
        public bool CanEnergyBlast(MirDirection direction)
        {
            return HasTarget(Functions.Move(MapObject.User.CurrentLocation, direction, 2));
        }

        public bool CanHalfMoon(MirDirection direction)
        {
            if (HasTarget(Functions.Move(MapObject.User.CurrentLocation, Functions.ShiftDirection(direction, -1)))) return true;
            if (HasTarget(Functions.Move(MapObject.User.CurrentLocation, Functions.ShiftDirection(direction, 1)))) return true;
            if (HasTarget(Functions.Move(MapObject.User.CurrentLocation, Functions.ShiftDirection(direction, 2)))) return true;

            return false;
        }
        public bool CanXuanfengyin(MirDirection direction)
        {
            if (HasTarget(Functions.Move(MapObject.User.CurrentLocation, Functions.ShiftDirection(direction, -1)))) return true;
            if (HasTarget(Functions.Move(MapObject.User.CurrentLocation, Functions.ShiftDirection(direction, 1)))) return true;
            if (HasTarget(Functions.Move(MapObject.User.CurrentLocation, Functions.ShiftDirection(direction, 2)))) return true;

            return false;
        }
        public bool CanDestructiveBlow(MirDirection direction)
        {
            for (int i = 1; i < 8; i++)
                if (HasTarget(Functions.Move(MapObject.User.CurrentLocation, Functions.ShiftDirection(direction, i)))) return true;

            return false;
        }


        public bool ValidCell(Point location)
        {
            if (location.X < 0 || location.Y < 0 || location.X >= Width || location.Y >= Height) return false;

            return !Cells[location.X, location.Y].Flag;
        }
        #endregion

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                _MapInfo = null;
                MapInfoChanged = null;

                _Animation = 0;
                AnimationChanged = null;

                MapButtons = 0;
                MapLocation = Point.Empty;
                Mining = false;
                MiningPoint = Point.Empty;
                MiningDirection = 0;


                if (FLayer != null)
                {
                    if (!FLayer.IsDisposed)
                        FLayer.Dispose();

                    FLayer = null;
                }

                if (LLayer != null)
                {
                    if (!LLayer.IsDisposed)
                        LLayer.Dispose();

                    LLayer = null;
                }

                Cells = null;

                Width = 0;
                Height = 0;

                MapInfoObjects.Clear();
                MapInfoObjects = null;

                Objects.Clear();
                Objects = null;

                Effects.Clear();
                Effects = null;
                ViewRangeX = 0;
                ViewRangeY = 0;
                OffSetX = 0;
                OffSetY = 0;
            }

        }

        #endregion

        public sealed class Floor : DXControl
        {
            public Floor()
            {
                IsControl = false;
            }

            #region Methods
            public void CheckTexture()
            {
                if (!TextureValid)
                    CreateTexture();
            }

            
            /*
            protected override void OnClearTexture()
            {
                base.OnClearTexture();
                if (GameScene.Game.MapControl.BackgroundImage != null)
                {
                    float num = (GameScene.Game.MapControl.BackgroundImage.Width - Config.GameSize.Width) / GameScene.Game.MapControl.Width;
                    float num2 = (GameScene.Game.MapControl.BackgroundImage.Height - Config.GameSize.Height) / GameScene.Game.MapControl.Height;
                    int x = (int)((float)User.CurrentLocation.X * num) + GameScene.Game.MapControl.BackgroundMovingOffset.X;
                    int y = (int)((float)User.CurrentLocation.Y * num2) + GameScene.Game.MapControl.BackgroundMovingOffset.Y;
                    Rectangle area = new Rectangle(x, y, base.DisplayArea.Width, base.DisplayArea.Height);
                    if (CEnvir.LibraryList.TryGetValue(LibraryFile.Background, out MirLibrary value))
                    {
                        value.Draw(GameScene.Game.MapControl.MapInfo.BJMap, 0f, 0f, Color.White, area, 1f, ImageType.Image, 0);
                    }
                }
                int num3 = Math.Max(0, User.CurrentLocation.X - OffSetX - 4);
                int num4 = Math.Min(GameScene.Game.MapControl.Width - 1, User.CurrentLocation.X + OffSetX + 4);
                int num5 = Math.Max(0, User.CurrentLocation.Y - OffSetY - 4);
                int num6 = Math.Min(GameScene.Game.MapControl.Height - 1, User.CurrentLocation.Y + OffSetY + 4);
                for (int i = num5; i <= num6; i++)
                {
                    if (i < 0)
                    {
                        continue;
                    }
                    if (i >= GameScene.Game.MapControl.Height)
                    {
                        break;
                    }
                    int num7 = (i - User.CurrentLocation.Y + OffSetY) * 32 - User.MovingOffSet.Y;
                    for (int j = num3; j <= num4; j++)
                    {
                        if (j >= 0)
                        {
                            if (j >= GameScene.Game.MapControl.Width)
                            {
                                break;
                            }
                            int num8 = (j - User.CurrentLocation.X + OffSetX) * 48 - User.MovingOffSet.X;
                            Cell cell = GameScene.Game.MapControl.Cells[j, i];
                            if (i % 2 == 0 && j % 2 == 0 && Libraries.KROrder.TryGetValue(cell.BackFile, out LibraryFile value2) && CEnvir.LibraryList.TryGetValue(value2, out MirLibrary value3))
                            {
                                value3.Draw((cell.BackImage & 0x1FFFF) - 1, num8, num7, Color.White, useOffSet: false, 1f, ImageType.Image);
                            }
                        }
                    }
                }
                for (int k = num5; k <= num6; k++)
                {
                    int num9 = (k - User.CurrentLocation.Y + OffSetY + 1) * 32 - User.MovingOffSet.Y;
                    for (int l = num3; l <= num4; l++)
                    {
                        int num10 = (l - User.CurrentLocation.X + OffSetX) * 48 - User.MovingOffSet.X;
                        Cell cell2 = GameScene.Game.MapControl.Cells[l, k];
                        if (Libraries.KROrder.TryGetValue(cell2.MiddleFile, out LibraryFile value4) && value4 != LibraryFile.WemadeMir3_Tilesc && CEnvir.LibraryList.TryGetValue(value4, out MirLibrary value5))
                        {
                            int index = cell2.MiddleImage - 1;
                            if (cell2.MiddleAnimationFrame > 1 && cell2.MiddleAnimationFrame < byte.MaxValue)
                            {
                                continue;
                            }
                            Size size = value5.GetSize(index);
                            if ((size.Width == 48 && size.Height == 32) || (size.Width == 96 && size.Height == 64))
                            {
                                value5.Draw(index, num10, num9 - 32, Color.White, useOffSet: false, 1f, ImageType.Image);
                            }
                        }
                        if (!Libraries.KROrder.TryGetValue(cell2.FrontFile, out value4) || value4 == LibraryFile.WemadeMir3_Tilesc || !CEnvir.LibraryList.TryGetValue(value4, out value5))
                        {
                            continue;
                        }
                        int index2 = cell2.FrontImage - 1;
                        if (cell2.FrontAnimationFrame <= 1 || cell2.FrontAnimationFrame >= byte.MaxValue)
                        {
                            Size size2 = value5.GetSize(index2);
                            if ((size2.Width == 48 && size2.Height == 32) || (size2.Width == 96 && size2.Height == 64))
                            {
                                value5.Draw(index2, num10, num9 - 32, Color.White, useOffSet: false, 1f, ImageType.Image);
                            }
                        }
                    }
                }
            }
            */

            protected override void OnClearTexture()
            {
                base.OnClearTexture();

                if (GameScene.Game.MapControl.BackgroundImage != null)
                {
                    float pixelspertileX = (GameScene.Game.MapControl.BackgroundImage.Width - Config.GameSize.Width) / GameScene.Game.MapControl.Width;
                    float pixelspertileY = (GameScene.Game.MapControl.BackgroundImage.Height - Config.GameSize.Height) / GameScene.Game.MapControl.Height;
                    int bgX = (int)(User.CurrentLocation.X * pixelspertileX) + GameScene.Game.MapControl.BackgroundMovingOffset.X;
                    int bgY = (int)(User.CurrentLocation.Y * pixelspertileY) + GameScene.Game.MapControl.BackgroundMovingOffset.Y;
                    Rectangle bgdisplay = new Rectangle(bgX, bgY, DisplayArea.Width, DisplayArea.Height);
                    MirLibrary bglibrary;
                    if (CEnvir.LibraryList.TryGetValue(LibraryFile.Background, out bglibrary))
                        bglibrary.Draw(GameScene.Game.MapControl.MapInfo.BJMap, 0, 0, Color.White, bgdisplay, 1F, ImageType.Image);
                }

                int minX = Math.Max(0, User.CurrentLocation.X - OffSetX - 4), maxX = Math.Min(GameScene.Game.MapControl.Width - 1, User.CurrentLocation.X + OffSetX + 4);
                int minY = Math.Max(0, User.CurrentLocation.Y - OffSetY - 4), maxY = Math.Min(GameScene.Game.MapControl.Height - 1, User.CurrentLocation.Y + OffSetY + 4);

                for (int y = minY; y <= maxY; y++)
                {
                    if (y < 0) continue;
                    if (y >= GameScene.Game.MapControl.Height) break;

                    int drawY = (y - User.CurrentLocation.Y + OffSetY) * CellHeight - User.MovingOffSet.Y - User.ShakeScreenOffset.Y;

                    for (int x = minX; x <= maxX; x++)
                    {
                        if (x < 0) continue;
                        if (x >= GameScene.Game.MapControl.Width) break;

                        int drawX = (x - User.CurrentLocation.X + OffSetX) * CellWidth - User.MovingOffSet.X - User.ShakeScreenOffset.X;

                        Cell tile = GameScene.Game.MapControl.Cells[x, y];

                        if (y % 2 == 0 && x % 2 == 0)
                        {
                            MirLibrary library;
                            LibraryFile file;

                            if (!Libraries.KROrder.TryGetValue(tile.BackFile, out file)) continue;

                            if (!CEnvir.LibraryList.TryGetValue(file, out library)) continue;

                            library.Draw(tile.BackImage, drawX, drawY, Color.White, false, 1F, ImageType.Image);
                        }
                    }
                }

                for (int y = minY; y <= maxY; y++)
                {
                    int drawY = (y - User.CurrentLocation.Y + OffSetY + 1) * CellHeight - User.MovingOffSet.Y - User.ShakeScreenOffset.Y;

                    for (int x = minX; x <= maxX; x++)
                    {
                        int drawX = (x - User.CurrentLocation.X + OffSetX) * CellWidth - User.MovingOffSet.X - User.ShakeScreenOffset.X;

                        Cell cell = GameScene.Game.MapControl.Cells[x, y];

                        MirLibrary library;
                        LibraryFile file;

                        if (Libraries.KROrder.TryGetValue(cell.MiddleFile, out file) && file != LibraryFile.Tilesc && CEnvir.LibraryList.TryGetValue(file, out library))
                        {
                            int index = cell.MiddleImage - 1;

                            if (cell.MiddleAnimationFrame > 1 && cell.MiddleAnimationFrame < 255)
                                continue;

                            Size s = library.GetSize(index);

                            if ((s.Width == CellWidth && s.Height == CellHeight) || (s.Width == CellWidth * 2 && s.Height == CellHeight * 2))
                                library.Draw(index, drawX, drawY - CellHeight, Color.White, false, 1F, ImageType.Image);
                        }


                        if (Libraries.KROrder.TryGetValue(cell.FrontFile, out file) && file != LibraryFile.Tilesc && CEnvir.LibraryList.TryGetValue(file, out library))
                        {
                            int index = cell.FrontImage - 1;

                            if (cell.FrontAnimationFrame > 1 && cell.FrontAnimationFrame < 255)
                                continue;

                            Size s = library.GetSize(index);

                            if ((s.Width == CellWidth && s.Height == CellHeight) || (s.Width == CellWidth * 2 && s.Height == CellHeight * 2))
                                library.Draw(index, drawX, drawY - CellHeight, Color.White, false, 1F, ImageType.Image);
                        }
                    }
                }
            }

            public override void Draw()
            {
            }
            protected override void DrawControl()
            {
            }

            #endregion
        }

        public sealed class Light : DXControl
        {
            public Light()
            {
                IsControl = false;
                BackColour = Color.FromArgb(15, 15, 15);
            }

            #region Methods

            public void CheckTexture()
            {
                CreateTexture();
            }

            protected override void OnClearTexture()
            {
                base.OnClearTexture();

                if (MapObject.User.Dead)
                {
                    DXManager.Device.Clear(ClearFlags.Target, Color.IndianRed, 0, 0);
                    return;
                }

                DXManager.SetBlend(true);
                DXManager.Device.SetRenderState(RenderState.SourceBlend, Blend.SourceAlpha);


                const float lightScale = 0.02F; 
                const float baseSize = 0.1F;

                float fX;
                float fY;

                if ((MapObject.User.Poison & PoisonType.Abyss) == PoisonType.Abyss)
                {
                    DXManager.Device.Clear(ClearFlags.Target, Color.Black, 0, 0);

                    float scale = baseSize + 4 * lightScale;

                    fX = (OffSetX + MapObject.User.CurrentLocation.X - User.CurrentLocation.X) * CellWidth + CellWidth / 2;
                    fY = (OffSetY + MapObject.User.CurrentLocation.Y - User.CurrentLocation.Y) * CellHeight;

                    fX -= (DXManager.LightWidth * scale) / 2;
                    fY -= (DXManager.LightHeight * scale) / 2;

                    fX /= scale;
                    fY /= scale;

                    DXManager.Sprite.Transform = Matrix.Scaling(scale, scale, 1);

                    DXManager.Sprite.Draw(DXManager.LightTexture, Vector3.Zero, new Vector3(fX, fY, 0), Color.White);

                    DXManager.Sprite.Transform = Matrix.Identity;

                    DXManager.SetBlend(false);

                    MapObject.User.AbyssEffect.Draw();
                    return;
                }


                foreach (MapObject ob in GameScene.Game.MapControl.Objects)
                {
                    if (ob.Light > 0 && (!ob.Dead || ob == MapObject.User || ob.Race == ObjectType.Spell))
                    {
                        float scale = baseSize + ob.Light * 2 * lightScale;

                        fX = (OffSetX + ob.CurrentLocation.X - User.CurrentLocation.X) * CellWidth + ob.MovingOffSet.X - User.MovingOffSet.X + CellWidth / 2;
                        fY = (OffSetY + ob.CurrentLocation.Y - User.CurrentLocation.Y) * CellHeight + ob.MovingOffSet.Y - User.MovingOffSet.Y;

                        fX -= (DXManager.LightWidth * scale) / 2;
                        fY -= (DXManager.LightHeight * scale) / 2;

                        fX /= scale;
                        fY /= scale;

                        DXManager.Sprite.Transform = Matrix.Scaling(scale, scale, 1);

                        DXManager.Sprite.Draw(DXManager.LightTexture, Vector3.Zero, new Vector3(fX, fY, 0), ob.LightColour);

                        DXManager.Sprite.Transform = Matrix.Identity;
                    }
                }

                foreach (MirEffect ob in GameScene.Game.MapControl.Effects)
                {
                    float frameLight = ob.FrameLight;

                    if (frameLight > 0)
                    {
                        float scale = baseSize + frameLight * 2 * lightScale / 5;

                        fX = ob.DrawX + CellWidth / 2;
                        fY = ob.DrawY + CellHeight / 2;

                        fX -= (DXManager.LightWidth * scale) / 2;
                        fY -= (DXManager.LightHeight * scale) / 2;

                        fX /= scale;
                        fY /= scale;

                        DXManager.Sprite.Transform = Matrix.Scaling(scale, scale, 1);

                        DXManager.Sprite.Draw(DXManager.LightTexture, Vector3.Zero, new Vector3(fX, fY, 0), ob.FrameLightColour);

                        DXManager.Sprite.Transform = Matrix.Identity;
                    }
                }

                int minX = Math.Max(0, User.CurrentLocation.X - OffSetX - 15), maxX = Math.Min(GameScene.Game.MapControl.Width - 1, User.CurrentLocation.X + OffSetX + 15);
                int minY = Math.Max(0, User.CurrentLocation.Y - OffSetY - 15), maxY = Math.Min(GameScene.Game.MapControl.Height - 1, User.CurrentLocation.Y + OffSetY + 15);

                for (int y = minY; y <= maxY; y++)
                {
                    if (y < 0) continue;
                    if (y >= GameScene.Game.MapControl.Height) break;

                    int drawY = (y - User.CurrentLocation.Y + OffSetY) * CellHeight - User.MovingOffSet.Y - User.ShakeScreenOffset.Y;

                    for (int x = minX; x <= maxX; x++)
                    {
                        if (x < 0) continue;
                        if (x >= GameScene.Game.MapControl.Width) break;

                        int drawX = (x - User.CurrentLocation.X + OffSetX) * CellWidth - User.MovingOffSet.X - User.ShakeScreenOffset.X;

                        Cell tile = GameScene.Game.MapControl.Cells[x, y];

                        if (tile.Light == 0) continue;

                        float scale = baseSize + tile.Light * 30 * lightScale;

                        fX = drawX + CellWidth / 2;
                        fY = drawY + CellHeight / 2;

                        fX -= DXManager.LightWidth * scale / 2;
                        fY -= DXManager.LightHeight * scale / 2;

                        fX /= scale;
                        fY /= scale;

                        DXManager.Sprite.Transform = Matrix.Scaling(scale, scale, 1);

                        DXManager.Sprite.Draw(DXManager.LightTexture, Vector3.Zero, new Vector3(fX, fY, 0), Color.White);

                        DXManager.Sprite.Transform = Matrix.Identity;
                    }
                }


                DXManager.SetBlend(false);
            }

            public void UpdateLights()
            {
                if (Config.免蜡烛)
                {
                    BackColour = Color.White;
                    Visible = true;
                }
                else
                {
                    BackColour = Color.FromArgb(155, 155, 155);
                    Visible = true;
                }
                /*
                else if ((!Config.ChkAvertBright && !Config.ChkAvertBrights) || (Config.ChkAvertBright && Config.ChkAvertBrights))
                {
                    switch (GameScene.Game.MapControl.MapInfo.Light)
                    {
                        case LightSetting.Default:
                            byte shading = (byte)(255 * GameScene.Game.DayTime);
                            BackColour = Color.FromArgb(shading, shading, shading);
                            Visible = true;
                            break;
                        case LightSetting.Night:
                            BackColour = Color.FromArgb(15, 15, 15);
                            Visible = true;
                            break;
                        case LightSetting.Light:
                            Visible = MapObject.User != null && (MapObject.User.Poison & PoisonType.Abyss) != PoisonType.Abyss;
                            break;
                    }
                }
                */
            }

            protected override void DrawControl()
            {
            }

            public override void Draw()
            {
            }
            #endregion
        }
    }

    public sealed class Cell
    {
        public int BackFile;
        public int BackImage;

        public int MiddleFile;
        public int MiddleImage;

        public int FrontFile;
        public int FrontImage;

        public byte DoorIndex;
        public byte DoorOffset;

        public int FrontAnimationFrame;
        public int FrontAnimationTick;

        public int MiddleAnimationFrame;
        public int MiddleAnimationTick;

        public short TileAnimationImage;
        public short TileAnimationOffset;
        public byte TileAnimationFrames;

        public int Light;

        public byte Unknown;

        public bool Flag;

        public bool FishingCell;

        public List<MapObject> Objects;

        public bool Blocking()
        {
            if (Objects != null)
            {
                foreach (MapObject ob in Objects)
                    if (ob.Blocking) return true;
            }

            return Flag;
        }

        public void AddObject(MapObject ob)
        {
            if (Objects == null)
                Objects = new List<MapObject>();

            if (ob.Race == ObjectType.Spell)
                Objects.Insert(0, ob);
            else
                Objects.Add(ob);

            ob.CurrentCell = this;
        }

        public void RemoveObject(MapObject ob)
        {
            Objects.Remove(ob);

            if (Objects.Count == 0)
                Objects = null;

            ob.CurrentCell = null;
        }
    }

}
