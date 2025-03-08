using System;
using System.Drawing;
using Client.Envir;
using Library;
using SlimDX.Direct3D9;


namespace Client.Controls
{
    public class DXImageControl : DXControl
    {
        #region Properties

        #region Blend

        public bool Blend
        {
            get => _Blend;
            set
            {
                if (_Blend == value) return;

                bool oldValue = _Blend;
                _Blend = value;

                OnBlendChanged(oldValue, value);
            }
        }
        private bool _Blend;
        public event EventHandler<EventArgs> BlendChanged;
        public virtual void OnBlendChanged(bool oValue, bool nValue)
        {
            BlendChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region DrawImage

        public bool DrawImage
        {
            get => _DrawImage;
            set
            {
                if (_DrawImage == value) return;

                bool oldValue = _DrawImage;
                _DrawImage = value;

                OnDrawImageChanged(oldValue, value);
            }
        }
        private bool _DrawImage;
        public event EventHandler<EventArgs> DrawImageChanged;
        public virtual void OnDrawImageChanged(bool oValue, bool nValue)
        {
            DrawImageChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion
        
        #region FixedSize

        public bool FixedSize
        {
            get => _FixedSize;
            set
            {
                if (_FixedSize == value) return;

                bool oldValue = _FixedSize;
                _FixedSize = value;

                OnFixedSizeChanged(oldValue, value);
            }
        }
        private bool _FixedSize;
        public event EventHandler<EventArgs> FixedSizeChanged;
        public virtual void OnFixedSizeChanged(bool oValue, bool nValue)
        {
            TextureValid = false;
            UpdateDisplayArea();
            FixedSizeChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region ImageOpacity

        public float ImageOpacity
        {
            get => _ImageOpacity;
            set
            {
                if (_ImageOpacity == value) return;

                float oldValue = _ImageOpacity;
                _ImageOpacity = value;

                OnImageOpacityChanged(oldValue, value);
            }
        }
        private float _ImageOpacity;
        public event EventHandler<EventArgs> ImageOpacityChanged;
        public virtual void OnImageOpacityChanged(float oValue, float nValue)
        {
            ImageOpacityChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion
        
        #region Index

        public int Index
        {
            get => _Index;
            set
            {
                if (_Index == value) return;

                int oldValue = _Index;
                _Index = value;

                OnIndexChanged(oldValue, value);
            }
        }
        private int _Index;
        public event EventHandler<EventArgs> IndexChanged;
        public virtual void OnIndexChanged(int oValue, int nValue)
        {
            TextureValid = false;
            UpdateDisplayArea();
            IndexChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion
        
        #region LibraryFile
        public MirLibrary Library;

        public LibraryFile LibraryFile
        {
            get => _LibraryFile;
            set
            {
                if (_LibraryFile == value) return;

                LibraryFile oldValue = _LibraryFile;
                _LibraryFile = value;

                OnLibraryFileChanged(oldValue, value);
            }
        }
        private LibraryFile _LibraryFile;
        public event EventHandler<EventArgs> LibraryFileChanged;
        public virtual void OnLibraryFileChanged(LibraryFile oValue, LibraryFile nValue)
        {
            CEnvir.LibraryList.TryGetValue(LibraryFile, out Library);

            TextureValid = false;
            UpdateDisplayArea();

            LibraryFileChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region PixelDetect

        public bool PixelDetect
        {
            get => _PixelDetect;
            set
            {
                if (_PixelDetect == value) return;

                bool oldValue = _PixelDetect;
                _PixelDetect = value;

                OnPixelDetectChanged(oldValue, value);
            }
        }
        private bool _PixelDetect;
        public event EventHandler<EventArgs> PixelDetectChanged;
        public virtual void OnPixelDetectChanged(bool oValue, bool nValue)
        {
            PixelDetectChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region UseOffSet

        public bool UseOffSet
        {
            get => _UseOffSet;
            set
            {
                if (_UseOffSet == value) return;

                bool oldValue = _UseOffSet;
                _UseOffSet = value;

                OnUseOffSetChanged(oldValue, value);
            }
        }
        private bool _UseOffSet;
        public event EventHandler<EventArgs> UseOffSetChanged;
        public virtual void OnUseOffSetChanged(bool oValue, bool nValue)
        {
            UpdateDisplayArea();
            UseOffSetChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        public bool Zoom
        {
            get
            {
                return _Zoom;
            }
            set
            {
                if (_Zoom == value)
                    return;
                bool zoom = _Zoom;
                _Zoom = value;
                OnZoomChanged(zoom, value);
            }
        }
        private bool _Zoom;

        public event EventHandler<EventArgs> ZoomChanged;

        public virtual void OnZoomChanged(bool oValue, bool nValue)
        {
            TextureValid = false;
            UpdateDisplayArea();
            
            EventHandler<EventArgs> zoomChanged = ZoomChanged;
            if (zoomChanged == null)
                return;
            zoomChanged((object)this, EventArgs.Empty);
        }

        public float Scale
        {
            get
            {
                float num1 = 1f;
                if (Library != null && Index >= 0)
                {
                    Size size = Library.GetSize(Index);
                    if (ZoomSize.Width < size.Width)
                        num1 = (float)ZoomSize.Width / (float)size.Width;
                    if (ZoomSize.Height < size.Height)
                    {
                        float num2 = (float)ZoomSize.Height / (float)size.Height;
                        num1 = (double)num2 < (double)num1 ? num2 : num1;
                    }
                }
                return num1;
            }
        }

        public Size ScalingSize
        {
            get
            {
                Size size = Library.GetSize(Index);
                return new Size(Convert.ToInt32((float)size.Width * Scale), Convert.ToInt32((float)size.Height * Scale));
            }
        }

        public TilingMode TilingMode
        {
            get
            {
                return _TilingMode;
            }
            set
            {
                if (_TilingMode == value)
                    return;
                _TilingMode = value;
                TextureValid = false;
                if ((uint)value <= 0U)
                    return;
                BeforeDraw -= new EventHandler<EventArgs>(DXImageControl_BeforeDraw);
                BeforeDraw += new EventHandler<EventArgs>(DXImageControl_BeforeDraw);
            }
        }
        private TilingMode _TilingMode = TilingMode.None;

        private void DXImageControl_AfterDraw(object sender, EventArgs e)
        {
            if (DXManager.Device.GetSamplerState(0, (SamplerState)1) != 3)
                DXManager.Device.SetSamplerState(0, (SamplerState)1, (TextureAddress)3);
            if (DXManager.Device.GetSamplerState(0, (SamplerState)2) == 3)
                return;
            DXManager.Device.SetSamplerState(0, (SamplerState)2, (TextureAddress)3);
        }

        private void DXImageControl_BeforeDraw(object sender, EventArgs e)
        {
            if (TilingMode == TilingMode.Horizontally || TilingMode == TilingMode.All)
                DXManager.Device.SetSamplerState(0, (SamplerState)1, (TextureAddress)1);
            if (TilingMode != TilingMode.Vertically && TilingMode != TilingMode.All)
                return;
            DXManager.Device.SetSamplerState(0, (SamplerState)2, (TextureAddress)1);
        }


        public override Size Size
        {
            get
            {
                if (Library != null && Index >= 0 && !FixedSize)
                    return Library.GetSize(Index);

                return base.Size;
            }
            set => base.Size = value;
        }

        #endregion

        public Size ZoomSize
        {
            get
            {
                return _ZoomSize;
            }
            set
            {
                if (_ZoomSize == value)
                    return;
                _ZoomSize = value;
                TextureValid = false;
            }
        }
        private Size _ZoomSize;

        public DXImageControl()
        {
            DrawImage = true;
            Index = -1;
            ImageOpacity = 1F;
            PixelDetect = true;
        }

        #region Methods
        protected override void DrawControl()
        {
            base.DrawControl();

            if (!DrawImage) return;

            DrawMirTexture();
        }
        protected virtual void DrawMirTexture()
        {
            bool oldBlend = DXManager.Blending;
            float oldRate = DXManager.BlendRate;

            MirImage image = Library.CreateImage(Index, ImageType.Image);

            if (image?.Image == null) return;

            if (Blend)
                DXManager.SetBlend(true, ImageOpacity);
            else
                DXManager.SetOpacity(ImageOpacity);

            
            PresentTexture(image.Image, Parent, DisplayArea, IsEnabled ? ForeColour : Color.FromArgb(75, 75, 75), this);
            
            if (Blend)
                DXManager.SetBlend(oldBlend, oldRate);
            else
                DXManager.SetOpacity(1F);

            image.ExpireTime = Time.Now + Config.CacheDuration;
        }
        protected internal override void UpdateDisplayArea()
        {
            Rectangle area = new Rectangle(Location, Size);

            if (UseOffSet && Library != null)
                area.Offset(Library.GetOffSet(Index));

            if (Parent != null)
                area.Offset(Parent.DisplayArea.Location);

            DisplayArea = area;
        }


        #endregion

        #region IDisposable
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                _Blend = false;
                _DrawImage = false;
                _FixedSize = false;
                _ImageOpacity = 0F;
                _Index = -1;
                Library = null;
                _LibraryFile = LibraryFile.None;
                _PixelDetect = false;
                _UseOffSet = false;

                BlendChanged = null;
                DrawImageChanged = null;
                FixedSizeChanged = null;
                ImageOpacityChanged = null;
                IndexChanged = null;
                LibraryFileChanged = null;
                PixelDetectChanged = null;
                UseOffSetChanged = null;
            }
        }
        #endregion
    }

}
