using Client.Envir;
using Library;
using SlimDX;
using System.Drawing;

namespace Client.Models
{
    public class CMist
    {
        public bool m_bActive;
        public int m_bMistState;
        public Vector3 m_vTrans;
        public Vector3 m_vScale;
        public float BlendRate;
        public MirLibrary Library;

        public CMist()
        {
            m_vTrans.X = 0.0f;
            m_vTrans.Y = 0.0f;
            m_vTrans.Z = 0.0f;
            BlendRate = 0.7f;
            CEnvir.LibraryList.TryGetValue(LibraryFile.ProgUse, out Library);
        }

        ~CMist()
        {
        }

        public bool Create()
        {
            return true;
        }

        public void Init()
        {
        }

        public void Destory()
        {
        }

        public void DrawMist()
        {
            ++m_bMistState;
            ++m_vTrans.X;
            m_vTrans.Y += 0.2f;
            m_vTrans.Z = 0.0f;
            m_vTrans.X %= 1280f;
            m_vTrans.Y %= 800f;
            Library.DrawBlend(550, m_vTrans.X, m_vTrans.Y, (Color4)Color.FromArgb(100, 200, 200), 1280f, 800f, BlendRate, ImageType.Image, BlendState._BLEND_INVLIGHTINV);
            Library.DrawBlend(550, m_vTrans.X - 1280f, m_vTrans.Y, (Color4)Color.FromArgb(100, 200, 200), 1280f, 800f, BlendRate, ImageType.Image, BlendState._BLEND_INVLIGHTINV);
            Library.DrawBlend(550, m_vTrans.X - 1280f, m_vTrans.Y - 800f, (Color4)Color.FromArgb(100, 200, 200), 1280f, 800f, BlendRate, ImageType.Image, BlendState._BLEND_INVLIGHTINV);
            Library.DrawBlend(550, m_vTrans.X, m_vTrans.Y - 800f, (Color4)Color.FromArgb(100, 200, 200), 1280f, 800f, BlendRate, ImageType.Image, BlendState._BLEND_INVLIGHTINV);
        }

        public void ProgressMist()
        {
            DrawMist();
        }
    }
}
