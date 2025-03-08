using Client.Envir;
using SlimDX;
using System;
using System.Drawing;

namespace Client.Models.ParticleEngine
{
    public class FogParticle : Particle
    {
        private static int xwidth = (int)(new Decimal(512) * (Math.Ceiling((Decimal)Config.GameSize.Width / new Decimal(512)) + new Decimal(2)));
        private static int ywidth = (int)(new Decimal(512) * (Math.Ceiling((Decimal)Config.GameSize.Height / new Decimal(512)) + new Decimal(2)));
        private Vector2 xreset = new Vector2((float)FogParticle.xwidth, 0.0f);
        private Vector2 yreset = new Vector2(0.0f, (float)FogParticle.ywidth);

        public FogParticle(ParticleEngine engine, ParticleImageInfo image)
        {
            Engine = engine;
            ImageInfo = image;
        }

        public override void Update()
        {
            if (CEnvir.Now < NextUpdateTime)
                return;
            NextUpdateTime = CEnvir.Now.AddMilliseconds(100.0);
            Position = Position + Velocity;
        }

        protected override void OnPositionChanged()
        {
            if (ImageInfo.Size.Width == 0 || ImageInfo.Size.Height == 0)
                return;
            if ((double)Position.Y < (double)(-ImageInfo.Size.Height * 2))
            {
                Position = Position + yreset;
            }
            else
            {
                double y = (double)Position.Y;
                Size gameSize = Config.GameSize;
                double num1 = (double)(gameSize.Height + ImageInfo.Size.Height);
                if (y > num1)
                    Position = Position - yreset;
                else if ((double)Position.X < (double)(-ImageInfo.Size.Width * 2))
                {
                    Position = Position + xreset;
                }
                else
                {
                    double x = (double)Position.X;
                    gameSize = Config.GameSize;
                    double num2 = (double)(gameSize.Width + ImageInfo.Size.Width);
                    if (x <= num2)
                        return;
                    Position = Position - xreset;
                }
            }
        }
    }
}
