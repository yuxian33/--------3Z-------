using Client.Envir;
using SlimDX;
using System;
using System.Drawing;

namespace Client.Models.ParticleEngine
{
    public class Particle
    {
        public Vector2 OldPosition = Vector2.Zero;
        private TimeSpan UpdateDelay = TimeSpan.FromMilliseconds(100.0);

        public ParticleImageInfo ImageInfo { get; set; }

        public Client.Models.ParticleEngine.ParticleEngine Engine { get; set; }

        public Vector2 Position
        {
            get
            {
                return _position;
            }
            set
            {
                if (_position == value)
                    return;
                OldPosition = _position;
                _position = value;
                OnPositionChanged();
            }
        }

        private Vector2 _position { get; set; }

        public Vector2 Velocity { get; set; }

        public Color Color { get; set; }

        public float Size { get; set; }

        public DateTime AliveTime { get; set; }

        public bool Blend { get; set; }

        public float BlendRate { get; set; }

        protected DateTime NextUpdateTime { get; set; }

        public virtual void Update()
        {
            if (CEnvir.Now < NextUpdateTime)
                return;
            NextUpdateTime = CEnvir.Now + UpdateDelay;
            Position += Velocity;
        }

        public void Draw()
        {
            int x = (int)Position.X;
            int y = (int)Position.Y;
            if (Blend)
                ImageInfo.Library.DrawBlend(ImageInfo.Index, (float)x, (float)y, (Color4)Color, true, BlendRate, ImageType.Image, (byte)0);
            else
                ImageInfo.Library.Draw(ImageInfo.Index, (float)x, (float)y, (Color4)Color, true, BlendRate, ImageType.Image);
        }

        protected virtual void OnPositionChanged()
        {
        }

        public virtual void OnParticleEnd()
        {
        }
    }
}
