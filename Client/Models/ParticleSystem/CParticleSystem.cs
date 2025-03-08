using Client.Envir;
using Library;
using SlimDX;
using System.Drawing;

namespace Client.Models
{
    public class CParticleSystem
    {
        protected Vector3[] m_vecBounding = new Vector3[2];
        public float Opacity = 1f;
        public float BlendRate = 0.7f;
        protected int m_nNum;
        protected CParticle[] m_pxParticle;
        protected float m_fDeltaTime;
        public MirLibrary Library;
        public Vector3 m_vecEnvironment;
        public float m_fAirFiction;

        public int GetRandomNum(int nFrom, int nTo)
        {
            return CEnvir.Random.Next(nFrom, nTo);
        }

        public CParticleSystem()
        {
            InitSystem();
        }

        ~CParticleSystem()
        {
            DestroySystem();
        }

        public void UpdateAirFiction(int nNum)
        {
            if (m_pxParticle[nNum].m_bIsDead)
                return;
            m_pxParticle[nNum].m_vecLocalForce.X = (0.0f - m_pxParticle[nNum].m_vecVel.X) * m_fAirFiction;
            m_pxParticle[nNum].m_vecLocalForce.Y = (0.0f - m_pxParticle[nNum].m_vecVel.Y) * m_fAirFiction;
            m_pxParticle[nNum].m_vecLocalForce.Z = m_pxParticle[nNum].m_vecVel.Z * m_fAirFiction;
        }

        public void UpdateMove(int nNum)
        {
            if (m_pxParticle[nNum].m_bIsDead)
                return;
            if ((double)m_pxParticle[nNum].m_fMass == 0.0)
                m_pxParticle[nNum].m_fMass = 1f;
            m_pxParticle[nNum].m_vecAccel.X += (m_vecEnvironment.X + m_pxParticle[nNum].m_vecLocalForce.X) / m_pxParticle[nNum].m_fMass;
            m_pxParticle[nNum].m_vecAccel.Y += (m_vecEnvironment.Y + m_pxParticle[nNum].m_vecLocalForce.Y) / m_pxParticle[nNum].m_fMass;
            m_pxParticle[nNum].m_vecAccel.Z += (m_vecEnvironment.Z + m_pxParticle[nNum].m_vecLocalForce.Z) / m_pxParticle[nNum].m_fMass;
            m_pxParticle[nNum].m_vecVel.X += m_pxParticle[nNum].m_vecAccel.X * m_fDeltaTime;
            m_pxParticle[nNum].m_vecVel.Y += m_pxParticle[nNum].m_vecAccel.Y * m_fDeltaTime;
            m_pxParticle[nNum].m_vecVel.Z += m_pxParticle[nNum].m_vecAccel.Z * m_fDeltaTime;
            m_pxParticle[nNum].m_vecOldPos = m_pxParticle[nNum].m_vecPos;
            m_pxParticle[nNum].m_vecPos.X += m_pxParticle[nNum].m_vecVel.X * m_fDeltaTime;
            m_pxParticle[nNum].m_vecPos.Y += m_pxParticle[nNum].m_vecVel.Y * m_fDeltaTime;
            m_pxParticle[nNum].m_vecPos.Z += m_pxParticle[nNum].m_vecVel.Z * m_fDeltaTime;
        }

        public void UpdateCrash(int nNum)
        {
            if (m_pxParticle[nNum].m_bIsDead)
                return;
            if ((double)m_pxParticle[nNum].m_vecPos.X <= (double)m_vecBounding[0].X || (double)m_pxParticle[nNum].m_vecPos.X >= (double)m_vecBounding[1].X)
                m_pxParticle[nNum].m_vecVel.X = (float)((0.0 - (double)m_pxParticle[nNum].m_vecVel.X) * 0.699999988079071);
            if ((double)m_pxParticle[nNum].m_vecPos.Y <= (double)m_vecBounding[0].Y || (double)m_pxParticle[nNum].m_vecPos.Y >= (double)m_vecBounding[1].Y)
            {
                float num1 = m_pxParticle[nNum].m_vecPos.X - m_pxParticle[nNum].m_vecVel.X * (float)m_pxParticle[nNum].m_nDelay;
                float num2 = m_pxParticle[nNum].m_vecPos.Y - m_pxParticle[nNum].m_vecVel.Y * (float)m_pxParticle[nNum].m_nDelay;
                float num3 = 0.0f;
                float num4 = 0.0f;
                if ((double)m_pxParticle[nNum].m_vecPos.Y - (double)num2 != 0.0)
                    num3 = (float)((double)m_pxParticle[nNum].m_nDelay * ((double)m_vecBounding[1].Y - (double)num2) / ((double)m_pxParticle[nNum].m_vecPos.Y - (double)num2));
                if ((double)m_pxParticle[nNum].m_vecPos.Y - (double)num2 != 0.0)
                    num4 = (float)((double)m_pxParticle[nNum].m_nDelay * ((double)m_pxParticle[nNum].m_vecPos.Y - (double)m_vecBounding[1].Y) / ((double)m_pxParticle[nNum].m_vecPos.Y - (double)num2));
                m_pxParticle[nNum].m_vecPos.X = num1 + m_pxParticle[nNum].m_vecVel.X * num3;
                m_pxParticle[nNum].m_vecPos.Y = num2 + m_pxParticle[nNum].m_vecVel.Y * num3;
                m_pxParticle[nNum].m_vecVel.Y = (float)((0.0 - (double)m_pxParticle[nNum].m_vecVel.Y) * 0.600000023841858);
                m_pxParticle[nNum].m_vecPos.X += m_pxParticle[nNum].m_vecVel.X * num4;
                m_pxParticle[nNum].m_vecPos.Y += m_pxParticle[nNum].m_vecVel.Y * num4;
            }
            if ((double)m_pxParticle[nNum].m_vecPos.Z > (double)m_vecBounding[0].Z && (double)m_pxParticle[nNum].m_vecPos.Z < (double)m_vecBounding[1].Y)
                return;
            m_pxParticle[nNum].m_vecVel.Z = (float)((0.0 - (double)m_pxParticle[nNum].m_vecVel.Z) * 0.600000023841858);
        }

        public void SetEnvFactor(float fAirFriction, Vector3 vecEnvironment, Vector3 vecMinBound, Vector3 vecMaxBound)
        {
            m_fAirFiction = fAirFriction;
            m_vecEnvironment = vecEnvironment;
            m_vecBounding[0] = vecMinBound;
            m_vecBounding[1] = vecMaxBound;
        }

        public virtual void InitSystem()
        {
            m_nNum = 0;
            m_pxParticle = (CParticle[])null;
            m_fDeltaTime = 0.02f;
            m_fAirFiction = -0.05f;
            m_vecBounding[0] = new Vector3(0.0f, 0.0f, 0.0f);
            m_vecBounding[1] = new Vector3(0.0f, 0.0f, 0.0f);
            m_vecEnvironment = new Vector3(0.0f, 300f, 0.0f);
        }

        public virtual void SetupSystem(int wCnt = 200)
        {
            InitSystem();
            m_nNum = wCnt;
            m_pxParticle = new CParticle[m_nNum];
            for (int index = 0; index < m_nNum; ++index)
            {
                m_pxParticle[index] = new CParticle();
                m_pxParticle[index].Init();
            }
        }

        public virtual void DestroySystem()
        {
            for (int index = 0; index < m_nNum; ++index)
                m_pxParticle[index] = (CParticle)null;
        }

        public virtual bool RenderSystem(int m_shPartNum, int FramIdx, BlendState RendState = BlendState.None, LibraryFile libraryFile = LibraryFile.ProgUse)
        {
            int num = 0;
            CEnvir.LibraryList.TryGetValue(libraryFile, out Library);
            for (int index = 0; index < m_nNum; ++index)
            {
                if (!m_pxParticle[index].m_bIsDead)
                {
                    Library.DrawBlend(FramIdx, m_pxParticle[index].m_vecPos.X, m_pxParticle[index].m_vecPos.Y, (Color4)Color.FromArgb((int)m_pxParticle[index].m_bRed, (int)m_pxParticle[index].m_bGreen, (int)m_pxParticle[index].m_bBlue), m_pxParticle[index].m_fSize, m_pxParticle[index].m_fSize, BlendRate, ImageType.Image, RendState);
                    ++num;
                }
                if (num >= m_shPartNum)
                    return true;
            }
            return true;
        }

        public virtual void UpdateSystem(int nLoopTime, Vector3 vecGenPos)
        {
        }

        public virtual void SetParticleDefault(int nNum, Vector3 vecGenPos)
        {
        }
    }
}
