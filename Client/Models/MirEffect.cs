using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Envir;
using Client.Scenes;
using Library;
using SlimDX;

namespace Client.Models
{
    public class MirEffect
    {
        public MapObject Target;
        public Point MapTarget;

        public MirLibrary Library;

        public DateTime StartTime;
        public int StartIndex;
        public int FrameCount;
        public TimeSpan[] Delays;

        public int FrameIndex;
        public Color DrawColour = Color.White;
        public bool Blend;
        public bool Reversed;
        public float Opacity = 1F;
        public float BlendRate = 0.7F;
        public bool UseOffSet = true;
        public bool Loop = false;

        public int DrawX
        {
            get { return _DrawX; }
            set
            {
                if (_DrawX == value) return;

                _DrawX = value;
                GameScene.Game.MapControl.TextureValid = false;
            }
        }
        private int _DrawX;

        public int DrawY
        {
            get { return _DrawY; }
            set
            {
                if (_DrawY == value) return;

                _DrawY = value;
                GameScene.Game.MapControl.TextureValid = false;
            }
        }
        private int _DrawY;

        public int DrawFrame
        {
            get { return _DrawFrmae; }
            set
            {
                if (_DrawFrmae == value) return;

                _DrawFrmae = value;
                GameScene.Game.MapControl.TextureValid = false;
                FrameAction?.Invoke();
            }
        }
        private int _DrawFrmae;

        public DrawType DrawType = DrawType.Object;

        public Point[] ptArr1 = new Point[16] { new Point(24, -24), new Point(24, -24), new Point(24, -24), new Point(24, -24), new Point(24, -24), new Point(8, -24), new Point(8, -24), new Point(8, -24), new Point(8, -36), new Point(8, -36), new Point(8, -36), new Point(8, -36), new Point(8, -36), new Point(24, -24), new Point(24, -24), new Point(24, -24) };
        public Point[] ptArr2 = new Point[16] { new Point(34, 37), new Point(47, 38), new Point(62, 48), new Point(73, 41), new Point(76, 34), new Point(72, 43), new Point(58, 53), new Point(50, 48), new Point(34, 49), new Point(45, 49), new Point(55, 49), new Point(56, 43), new Point(48, 35), new Point(46, 40), new Point(46, 47), new Point(47, 38) };
        public Point[] ptArr3 = new Point[16] { new Point(6, 4), new Point(26, 0), new Point(44, 2), new Point(58, 6), new Point(56, 6), new Point(52, 10), new Point(48, 30), new Point(36, 48), new Point(10, 49), new Point(6, 47), new Point(4, 30), new Point(2, 20), new Point(0, 0), new Point(2, 4), new Point(3, 0), new Point(4, -1) };
        public Point ptArr4 = new Point(6, 4);
        public Point ptArr5 = new Point(40, 40);
        public Point[] ptArr6 = new Point[16] { new Point(14, 4), new Point(28, 0), new Point(44, 4), new Point(58, 6), new Point(56, 12), new Point(52, 22), new Point(48, 32), new Point(36, 40), new Point(18, 49), new Point(2, 47), new Point(1, 30), new Point(2, 20), new Point(0, 14), new Point(2, 8), new Point(3, 6), new Point(1, -1) };
        public Point[] ptArr7 = new Point[16] { new Point(24, 8), new Point(35, 15), new Point(65, 0), new Point(60, 13), new Point(60, 20), new Point(55, 40), new Point(53, 42), new Point(30, 52), new Point(27, 65), new Point(16, 65), new Point(20, 50), new Point(26, 28), new Point(25, 24), new Point(30, 16), new Point(15, 6), new Point(25, 10) };
        public Point[] ptArr8 = new Point[8] { new Point(8, 8), new Point(1, 1), new Point(1, 1), new Point(1, 1), new Point(1, 1), new Point(2, 3), new Point(1, 1), new Point(1, 1) };

        public int Skip { get; set; }
        public MirDirection Direction { get; set; }

        public Color[] LightColours;
        public int StartLight, EndLight;

        public float FrameLight
        {
            get
            {
                if (CEnvir.Now < StartTime) return 0;

                TimeSpan enlapsed = CEnvir.Now - StartTime;

                if (Loop)
                    enlapsed = TimeSpan.FromTicks(enlapsed.Ticks % TotalDuration.Ticks);

                return StartLight + (EndLight - StartLight) * enlapsed.Ticks / TotalDuration.Ticks;

            }
        }
        public Color FrameLightColour => LightColours[FrameIndex];
        public Point CurrentLocation => Target?.CurrentLocation ?? MapTarget;
        public Point MovingOffSet => Target?.MovingOffSet ?? Point.Empty;

        public Action CompleteAction;
        public Action FrameAction;
        public Action FrameIndexAction;

        public Point AdditionalOffSet;

        public int CParticleType { get; set; }

        public TimeSpan TotalDuration
        {
            get
            {
                TimeSpan temp = TimeSpan.Zero;

                foreach (TimeSpan delay in Delays)
                    temp += delay;

                return temp;
            }
        }

        public MirEffect(int startIndex, int frameCount, TimeSpan frameDelay, LibraryFile file, int startLight, int endLight, Color lightColour)
        {
            StartIndex = startIndex;
            FrameCount = frameCount;
            Skip = 10;

            StartTime = CEnvir.Now;
            StartLight = startLight;
            EndLight = endLight;

            Delays = new TimeSpan[FrameCount];
            LightColours = new Color[FrameCount];
            for (int i = 0; i < frameCount; i++)
            {
                Delays[i] = frameDelay;
                
                LightColours[i] = lightColour;
            }

            CEnvir.LibraryList.TryGetValue(file, out Library);

            GameScene.Game.MapControl.Effects.Add(this);

            SetParticle(startIndex, file);
        }
        public virtual void SetParticle(int startIndex, LibraryFile file)
        {
            CParticleType = 0;
            if ((startIndex == 420 || startIndex == 1640) && file == LibraryFile.Magic)
                CParticleType = 1;
            if (startIndex == 430 && file == LibraryFile.MagicEx)
                CParticleType = 2;
            if (startIndex == 2700 && file == LibraryFile.Magic)
                CParticleType = 3;
            if (startIndex == 2960 && file == LibraryFile.Magic)
                CParticleType = 4;
            if (startIndex == 3330 && file == LibraryFile.Magic)
                CParticleType = 5;
            if (startIndex == 3070 && file == LibraryFile.Magic)
                CParticleType = 6;
            if (startIndex == 1040 && file == LibraryFile.MagicEx)
                CParticleType = 7;
            if (startIndex == 1990 && file == LibraryFile.MagicEx)
                CParticleType = 8;
            if (startIndex != 90 || file != LibraryFile.MagicEx)
                return;
            CParticleType = 9;
        }

        public virtual void Process()
        {
            if (CEnvir.Now < StartTime) return;

            if (Target != null)
            {
                DrawX = Target.DrawX + AdditionalOffSet.X;
                DrawY = Target.DrawY + AdditionalOffSet.Y;
            }
            else
            {
                DrawX = (MapTarget.X - MapObject.User.CurrentLocation.X + MapObject.OffSetX) * MapObject.CellWidth - MapObject.User.MovingOffSet.X + AdditionalOffSet.X;
                DrawY = (MapTarget.Y - MapObject.User.CurrentLocation.Y + MapObject.OffSetY) * MapObject.CellHeight - MapObject.User.MovingOffSet.Y + AdditionalOffSet.Y;
            }

            int frame = GetFrame();


            if (frame == FrameCount)
            {
                CompleteAction?.Invoke();
                Remove();
                return;
            }
            else
            {
                if (Reversed)
                    frame = FrameCount - frame - 1;


                FrameIndex = frame;
                DrawFrame = FrameIndex + StartIndex + (int)Direction * Skip;

                if (Config.是否开启粒子效果)
                {

                    if (CParticleType != 7)
                    {
                        if (CParticleType == 8)
                        {
                            GameScene.Game.MapControl.m_xSmoke.SetSmokeParticleEx10(new Vector3((float)(DrawX + 24) + (float)GameScene.Game.MapControl.m_xSmoke.GetRandomNum(-10, 10), (float)(DrawY + 16) + (float)GameScene.Game.MapControl.m_xSmoke.GetRandomNum(0, 20), 0.0f));
                            GameScene.Game.MapControl.m_xBoom.SetBoomParticle5(new Vector3((float)(DrawX + 24), (float)(DrawY + 16), 0.0f));
                        }
                        else if (CParticleType == 9 && frame < FrameCount - 6)
                        {
                            GameScene.Game.MapControl.m_xSmoke.SetSmokeParticleEx4(new Vector3((float)(DrawX + 24), (float)DrawY, 0.0f));
                            GameScene.Game.MapControl.m_xBoom.SetBoomParticle(new Vector3((float)(DrawX + 24), (float)(DrawY + 16), 0.0f));
                        }
                    }
                    else if (frame < FrameCount - 5)
                    {
                        GameScene.Game.MapControl.m_xSmoke.SetSmokeParticleEx6(new Vector3((float)(DrawX + 24) + (float)GameScene.Game.MapControl.m_xSmoke.GetRandomNum(-10, 10), (float)(DrawY + 16) + (float)GameScene.Game.MapControl.m_xSmoke.GetRandomNum(0, 20), 0.0f));
                        GameScene.Game.MapControl.m_xBoom.SetBoomParticle2(new Vector3((float)(DrawX + 24), (float)(DrawY + 16), 0.0f));
                    }
                }
            }
        }

        protected virtual int GetFrame()
        {
            TimeSpan enlapsed = CEnvir.Now - StartTime;

            if (Loop)
                enlapsed = TimeSpan.FromTicks(enlapsed.Ticks % TotalDuration.Ticks);

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


        public void Draw()
        {
            if (CEnvir.Now < StartTime || Library == null) return;

            if (Blend)
                Library.DrawBlend(DrawFrame, DrawX, DrawY, DrawColour, UseOffSet, BlendRate, ImageType.Image);
            else
                Library.Draw(DrawFrame, DrawX, DrawY, DrawColour, UseOffSet, Opacity, ImageType.Image);
        }

        public void Remove()
        {
            CompleteAction = null;
            FrameAction = null;
            GameScene.Game.MapControl.Effects.Remove(this);
            Target?.Effects.Remove(this);
        }
    }

    public enum DrawType
    {
        Floor,
        Object,
        Final,
    }
}
