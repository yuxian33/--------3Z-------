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
    public class MirProjectile : MirEffect
    {
        public Point Origin { get; set; }
        public int Speed { get; set; }
        public bool Explode { get; set; }

        public int Direction16 { get; set; }
        public bool Has16Directions { get; set; }

        public MirProjectile(int startIndex, int frameCount, TimeSpan frameDelay, LibraryFile file, int startlight, int endlight, Color lightColour, Point origin) : base(startIndex, frameCount, frameDelay, file, startlight, endlight, lightColour)
        {
            Has16Directions = true;

            Origin = origin;
            Speed = 50;
            Explode = false;
        }

        public override void Process()
        {
            Point location = Target?.CurrentLocation ?? MapTarget;

            if (location == Origin)
            {
                CompleteAction?.Invoke();
                Remove();
                return;
            }
            else
            {
                int x = (Origin.X - MapObject.User.CurrentLocation.X + MapObject.OffSetX) * MapObject.CellWidth - MapObject.User.MovingOffSet.X;
                int y = (Origin.Y - MapObject.User.CurrentLocation.Y + MapObject.OffSetY) * MapObject.CellHeight - MapObject.User.MovingOffSet.Y;

                int x1 = (location.X - MapObject.User.CurrentLocation.X + MapObject.OffSetX) * MapObject.CellWidth - MapObject.User.MovingOffSet.X;
                int y1 = (location.Y - MapObject.User.CurrentLocation.Y + MapObject.OffSetY) * MapObject.CellHeight - MapObject.User.MovingOffSet.Y;

                Direction16 = Functions.Direction16(new Point(x, y / 32 * 48), new Point(x1, y1 / 32 * 48));
                long duration = Functions.Distance(new Point(x, y / 32 * 48), new Point(x1, y1 / 32 * 48)) * TimeSpan.TicksPerMillisecond;

                if (!Has16Directions)
                    Direction16 /= 2;

                if (duration == 0)
                {
                    CompleteAction?.Invoke();
                    Remove();
                    return;
                }
                else
                {
                    int x2 = x1 - x;
                    int y2 = y1 - y;

                    if (x2 == 0) x2 = 1;
                    if (y2 == 0) y2 = 1;

                    TimeSpan time = CEnvir.Now - StartTime;

                    int frame = GetFrame();

                    if (Reversed)
                        frame = FrameCount - frame - 1;

                    DrawFrame = frame + StartIndex + Direction16 * Skip;

                    DrawX = x + (int)(time.Ticks / (duration / x2)) + AdditionalOffSet.X;
                    DrawY = y + (int)(time.Ticks / (duration / y2)) + AdditionalOffSet.Y;

                    if (Config.是否开启粒子效果)
                    {
                        if (CParticleType == 1)
                        {
                            GameScene.Game.MapControl.m_xFlyingTail.SetFlyTailParticle(new Vector3((float)(DrawX + ptArr1[Direction16].X), (float)(DrawY + ptArr1[Direction16].Y), 0.0f));
                            GameScene.Game.MapControl.m_xSmoke.SetSmokeParticle(new Vector3((float)(DrawX + ptArr1[Direction16].X), (float)(DrawY + ptArr1[Direction16].Y), 0.0f));
                        }
                        else if (CParticleType != 2)
                        {
                            if (CParticleType == 3)
                                GameScene.Game.MapControl.m_xSmoke.SetSmokeParticleEx(new Vector3((float)(DrawX + ptArr1[Direction16].X), (float)(DrawY + ptArr1[Direction16].Y), 0.0f));
                            else if (CParticleType == 4)
                            {
                                GameScene.Game.MapControl.m_xSmoke.SetSmokeParticleEx2(new Vector3((float)(DrawX + ptArr1[Direction16].X), (float)(DrawY + ptArr1[Direction16].Y), 0.0f));
                                GameScene.Game.MapControl.m_xFlyingTail.SetFlyTailParticleEx(new Vector3((float)(DrawX + ptArr1[Direction16].X), (float)(DrawY + ptArr1[Direction16].Y), 0.0f));
                            }
                            else if (CParticleType == 5)
                                GameScene.Game.MapControl.m_xFlyingTail.SetFlyTailParticleEx2(new Vector3((float)(DrawX + ptArr1[Direction16].X), (float)(DrawY + ptArr1[Direction16].Y), 0.0f));
                            else if (CParticleType != 6)
                            {
                                if (CParticleType != 7)
                                {
                                    if (CParticleType == 8)
                                    {
                                        GameScene.Game.MapControl.m_xSmoke.SetSmokeParticleEx10(new Vector3((float)(DrawX + 24) + (float)GameScene.Game.MapControl.m_xSmoke.GetRandomNum(-10, 10), (float)(DrawY + 16) + (float)GameScene.Game.MapControl.m_xSmoke.GetRandomNum(0, 20), 0.0f));
                                        GameScene.Game.MapControl.m_xBoom.SetBoomParticle5(new Vector3((float)(DrawX + 24), (float)(DrawY + 16), 0.0f));
                                    }
                                    else if (CParticleType == 9 && frame < FrameCount - 26)
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
                            else
                                GameScene.Game.MapControl.m_xSmoke.SetSmokeParticleEx3(new Vector3((float)(DrawX + ptArr1[Direction16].X), (float)(DrawY + ptArr1[Direction16].Y), 0.0f));
                        }
                        else
                        {
                            GameScene.Game.MapControl.m_xFlyingTail.SetFlyTailParticleEx4(new Vector3((float)(DrawX + ptArr1[Direction16].X), (float)(DrawY + ptArr1[Direction16].Y), 0.0f));
                            GameScene.Game.MapControl.m_xSmoke.SetSmokeParticleEx8(new Vector3((float)(DrawX + ptArr1[Direction16].X), (float)(DrawY + ptArr1[Direction16].Y), 0.0f));
                        }
                    }
                    if ((CEnvir.Now - StartTime).Ticks > duration)
                    {
                        if (Target == null && !Explode)
                        {
                            Size s = Library.GetSize(FrameIndex);

                            if (DrawX + s.Width > 0 && DrawX < GameScene.Game.Size.Width &&
                                DrawY + s.Height > 0 && DrawY < GameScene.Game.Size.Height) return;
                        }

                        CompleteAction?.Invoke();
                        Remove();
                        return;
                    }
                }
            }
        }
        protected override int GetFrame()
        {

            TimeSpan enlapsed = CEnvir.Now - StartTime;

            enlapsed = TimeSpan.FromTicks(enlapsed.Ticks % TotalDuration.Ticks);

            for (int i = 0; i < Delays.Length; i++)
            {
                enlapsed -= Delays[i];
                if (enlapsed >= TimeSpan.Zero) continue;

                return i;
            }

            return FrameCount;
        }
    }
}
