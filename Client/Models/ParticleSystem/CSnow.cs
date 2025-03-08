using Client.Envir;
using Library;
using SlimDX;
using System.Drawing;

namespace Client.Models
{
    public class CSnow : CParticleSystem
    {
        private float m_fWidth;
        private float m_fGround;
        private short m_shPartNum;

        public CSnow()
        {
            InitSystem();
        }

        ~CSnow()
        {
            DestroySystem();
        }

        public override void InitSystem()
        {
            base.InitSystem();
            float num = 0.0f;
            m_fGround = 0.0f;
            m_fWidth = num;
            m_shPartNum = (short)0;
        }

        public override void DestroySystem()
        {
            base.DestroySystem();
        }

        public void SetupSystem(int wCnt = 500, float fWidth = 1280f, float fGround = 800f)
        {
            InitSystem();
            SetupSystem(wCnt);
            m_fWidth = fWidth;
            m_fGround = fGround;
            SetEnvFactor(-0.05f, new Vector3(10f, 100f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f));
            CEnvir.LibraryList.TryGetValue(LibraryFile.ProgUse, out Library);
            BlendRate = 1f;
        }

        public bool RenderSystem()
        {
            int num = 0;
            for (int index = 0; index < m_nNum; ++index)
            {
                if (!m_pxParticle[index].m_bIsDead)
                {
                    Library.DrawBlend(500 + m_pxParticle[index].m_nCurrFrame, m_pxParticle[index].m_vecPos.X, m_pxParticle[index].m_vecPos.Y, (Color4)Color.White, m_pxParticle[index].m_fSize, m_pxParticle[index].m_fSize, BlendRate, ImageType.Image, BlendState._BLEND_LIGHT);
                    ++num;
                }
                if (num >= (int)m_shPartNum)
                    return true;
            }
            return true;
        }

        public override void UpdateSystem(int nLoopTime, Vector3 vecGenPos)
        {
            int num1 = 0;
            int num2 = 0;
            int num3 = nLoopTime / 17;
            if (num3 < 1)
                num3 = 1;
            m_fDeltaTime = 0.02f * (float)num3;
            for (int nNum = 0; nNum < m_nNum; ++nNum)
            {
                if (m_pxParticle[nNum].m_bIsDead && num1 < 5)
                {
                    SetParticleDefault(nNum, new Vector3(0.0f, 0.0f, 0.0f));
                    ++m_shPartNum;
                    ++num1;
                }
                if (!m_pxParticle[nNum].m_bIsDead)
                {
                    m_pxParticle[nNum].m_nCurrLife += nLoopTime;
                    if (m_pxParticle[nNum].m_nCurrLife > m_pxParticle[nNum].m_nLife || (double)m_pxParticle[nNum].m_vecPos.Y >= (double)m_fGround)
                    {
                        if (m_pxParticle[nNum].m_nCurrLife - m_pxParticle[nNum].m_nLife <= (int)byte.MaxValue)
                        {
                            byte num4 = (byte)((int)byte.MaxValue - (m_pxParticle[nNum].m_nCurrLife - m_pxParticle[nNum].m_nLife));
                            m_pxParticle[nNum].m_bOpa = num4;
                            if ((int)num4 < (int)m_pxParticle[nNum].m_bRed)
                                m_pxParticle[nNum].m_bRed = num4;
                            if ((int)num4 < (int)m_pxParticle[nNum].m_bGreen)
                                m_pxParticle[nNum].m_bGreen = num4;
                            if ((int)num4 < (int)m_pxParticle[nNum].m_bBlue)
                                m_pxParticle[nNum].m_bBlue = num4;
                            ++num2;
                            continue;
                        }
                        m_pxParticle[nNum].Init();
                        --m_shPartNum;
                        --num2;
                        continue;
                    }
                    UpdateAirFiction(nNum);
                    UpdateMove(nNum);
                    m_pxParticle[nNum].m_nCurrDelay += nLoopTime;
                    if (m_pxParticle[nNum].m_nCurrDelay > m_pxParticle[nNum].m_nDelay)
                    {
                        m_pxParticle[nNum].m_nCurrDelay = 0;
                        ++m_pxParticle[nNum].m_nCurrFrame;
                        if (m_pxParticle[nNum].m_nCurrFrame >= 1)
                            m_pxParticle[nNum].m_nCurrFrame = 0;
                    }
                    ++num2;
                }
                if (num2 >= (int)m_shPartNum)
                    break;
            }
        }

        public override void SetParticleDefault(int nNum, Vector3 vecGenPos)
        {
            m_pxParticle[nNum].m_vecPos = new Vector3((float)GetRandomNum(0, (int)m_fWidth), (float)GetRandomNum(-300, 0), 0.0f);
            m_pxParticle[nNum].m_vecVel = new Vector3((float)GetRandomNum(-30, 30), (float)GetRandomNum(70, 100), 0.0f);
            m_pxParticle[nNum].m_vecAccel = new Vector3(0.0f, 0.0f, 0.0f);
            m_pxParticle[nNum].m_vecOldPos = new Vector3(0.0f, 0.0f, 0.0f);
            m_pxParticle[nNum].m_vecLocalForce = new Vector3(0.0f, 0.0f, 0.0f);
            m_pxParticle[nNum].m_nLife = GetRandomNum(2500, 7000);
            m_pxParticle[nNum].m_fMass = 1000f + (float)CEnvir.Random.NextDouble();
            m_pxParticle[nNum].m_fSize = (float)GetRandomNum(2, 6) + (float)CEnvir.Random.NextDouble();
            m_pxParticle[nNum].m_bIsDead = false;
            m_pxParticle[nNum].m_bRed = m_pxParticle[nNum].m_bGreen = m_pxParticle[nNum].m_bBlue = (byte)GetRandomNum(120, 150);
            m_pxParticle[nNum].m_bBlue += (byte)100;
            m_pxParticle[nNum].m_nDelay = 300;
            m_pxParticle[nNum].m_nCurrLife = 0;
            m_pxParticle[nNum].m_nCurrDelay = 0;
            m_pxParticle[nNum].m_nCurrFrame = 0;
            m_pxParticle[nNum].m_bOpa = byte.MaxValue;
        }
    }
}
