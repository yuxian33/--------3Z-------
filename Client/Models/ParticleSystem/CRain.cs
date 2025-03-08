using Client.Envir;
using Library;
using SlimDX;
using System.Drawing;

namespace Client.Models
{
    public class CRain : CParticleSystem
    {
        private float m_fWidth;
        private float m_fGround;
        private int m_shPartNum;
        public byte m_bGenCnt;

        public CRain()
        {
            InitSystem();
        }

        ~CRain()
        {
            DestroySystem();
        }

        public override void InitSystem()
        {
            base.InitSystem();
            float num = 0.0f;
            m_fGround = 0.0f;
            m_fWidth = num;
            m_bGenCnt = (byte)10;
        }

        public override void DestroySystem()
        {
            base.DestroySystem();
        }

        public void SetupSystem(int wCnt = 400, float fWidth = 1280f, float fGround = 800f)
        {
            InitSystem();
            SetupSystem(wCnt);
            m_fWidth = fWidth;
            m_fGround = fGround;
            SetEnvFactor(-0.05f, new Vector3(10f, 100f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f));
            CEnvir.LibraryList.TryGetValue(LibraryFile.ProgUse, out Library);
            BlendRate = 0.6f;
        }

        public bool RenderSystem()
        {
            int num = 0;
            for (int index = 0; index < m_nNum; ++index)
            {
                if (!m_pxParticle[index].m_bIsDead)
                {
                    if (m_pxParticle[index].m_nCurrLife - m_pxParticle[index].m_nLife > 0 && m_pxParticle[index].m_nCurrLife - m_pxParticle[index].m_nLife < 510)
                        Library.DrawBlend(510 + m_pxParticle[index].m_nCurrFrame, m_pxParticle[index].m_vecPos.X, m_pxParticle[index].m_vecPos.Y, (Color4)Color.White, 32f, 32f, BlendRate, ImageType.Image, BlendState._BLEND_LIGHTINV);
                    else
                        Library.DrawBlend(510 + m_pxParticle[index].m_nCurrFrame, m_pxParticle[index].m_vecPos.X, m_pxParticle[index].m_vecPos.Y, (Color4)Color.White, 32f, 32f, BlendRate, ImageType.Image, BlendState._BLEND_LIGHTINV);
                    ++num;
                }
                if (num >= m_shPartNum)
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
                if (m_pxParticle[nNum].m_bIsDead && num1 < 11)
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
                        if (m_pxParticle[nNum].m_nCurrLife - m_pxParticle[nNum].m_nLife <= 250)
                        {
                            byte num4 = (byte)(250 - (m_pxParticle[nNum].m_nCurrLife - m_pxParticle[nNum].m_nLife) / 4);
                            m_pxParticle[nNum].m_bOpa = num4;
                            m_pxParticle[nNum].m_nDelay = 50;
                            if ((int)num4 < (int)m_pxParticle[nNum].m_bRed)
                                m_pxParticle[nNum].m_bRed = num4;
                            if ((int)num4 < (int)m_pxParticle[nNum].m_bGreen)
                                m_pxParticle[nNum].m_bGreen = num4;
                            if ((int)num4 < (int)m_pxParticle[nNum].m_bBlue)
                                m_pxParticle[nNum].m_bBlue = num4;
                            m_pxParticle[nNum].m_nCurrDelay += nLoopTime;
                            if (m_pxParticle[nNum].m_nCurrDelay > m_pxParticle[nNum].m_nDelay)
                            {
                                m_pxParticle[nNum].m_nCurrDelay = 0;
                                ++m_pxParticle[nNum].m_nCurrFrame;
                                if (m_pxParticle[nNum].m_nCurrFrame >= 5)
                                    m_pxParticle[nNum].m_nCurrFrame = 0;
                            }
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
                if (num2 >= m_shPartNum)
                    break;
            }
        }

        public override void SetParticleDefault(int nNum, Vector3 vecGenPos)
        {
            m_pxParticle[nNum].ZeroInit();
            m_pxParticle[nNum].m_vecPos = new Vector3((float)GetRandomNum(-100, (int)((double)m_fWidth + 100.0)), (float)GetRandomNum(-500, 0), 0.0f);
            m_pxParticle[nNum].m_vecVel = new Vector3(0.0f, 500f, 0.0f);
            m_pxParticle[nNum].m_nLife = GetRandomNum(800, 1400);
            m_pxParticle[nNum].m_fMass = 100f;
            m_pxParticle[nNum].m_fSize = (float)GetRandomNum(3, 30) + (float)CEnvir.Random.NextDouble();
            m_pxParticle[nNum].m_bRed = m_pxParticle[nNum].m_bGreen = m_pxParticle[nNum].m_bBlue = (byte)GetRandomNum(120, 180);
            m_pxParticle[nNum].m_bBlue = (byte)125;
            m_pxParticle[nNum].m_nDelay = GetRandomNum(50, 150);
        }
    }
}
