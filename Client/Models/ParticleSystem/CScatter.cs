using Client.Envir;
using Library;
using SlimDX;
using System;

namespace Client.Models
{
    public class CScatter : CParticleSystem
    {
        private short m_shPartNum;

        public CScatter()
        {
            InitSystem();
        }

        ~CScatter()
        {
            DestroySystem();
        }

        public override void InitSystem()
        {
            base.InitSystem();
            m_shPartNum = (short)0;
        }

        public override void DestroySystem()
        {
            base.DestroySystem();
        }

        public override void SetupSystem(int wCnt = 2000)
        {
            InitSystem();
            base.SetupSystem(wCnt);
        }

        public bool RenderSystem()
        {
            BlendRate = 0.03137255f;
            return RenderSystem((int)m_shPartNum, 520, BlendState._BLEND_INVLIGHTINV, LibraryFile.ProgUse);
        }

        public void SetParticles(Vector3 vecDstPos)
        {
            int num = 0;
            for (int index = 0; index < m_nNum; ++index)
            {
                if (m_pxParticle[index].m_bIsDead)
                {
                    m_pxParticle[index].m_vecPos = new Vector3(vecDstPos.X + (float)GetRandomNum(-400, 400), vecDstPos.Y + (float)GetRandomNum(-400, 400), 0.0f);
                    m_pxParticle[index].m_vecDstPos = vecDstPos;
                    m_pxParticle[index].m_nLife = GetRandomNum(2000, 2200);
                    m_pxParticle[index].m_fMass = 1000f + (float)CEnvir.Random.NextDouble();
                    m_pxParticle[index].m_fSize = (float)GetRandomNum(30, 100) + (float)CEnvir.Random.NextDouble();
                    m_pxParticle[index].m_bIsDead = false;
                    m_pxParticle[index].m_bRed = m_pxParticle[index].m_bFstRed = (byte)GetRandomNum(100, 125);
                    m_pxParticle[index].m_bGreen = m_pxParticle[index].m_bFstGreen = (byte)((uint)m_pxParticle[index].m_bFstRed / 2U);
                    m_pxParticle[index].m_bBlue = m_pxParticle[index].m_bFstBlue = (byte)GetRandomNum(0, 15);
                    m_pxParticle[index].m_nDelay = 300;
                    m_pxParticle[index].m_nCurrDelay = 0;
                    m_pxParticle[index].m_nCurrFrame = 0;
                    m_pxParticle[index].m_bOpa = byte.MaxValue;
                    ++m_shPartNum;
                    ++num;
                    if (num >= 150)
                        break;
                }
            }
        }

        public override void UpdateSystem(int nLoopTime, Vector3 vecGenPos)
        {
            int num1 = 0;
            for (int index = 0; index < m_nNum; ++index)
            {
                if (!m_pxParticle[index].m_bIsDead)
                {
                    if (!m_pxParticle[index].m_bIsDead)
                        m_pxParticle[index].m_nCurrLife += nLoopTime;
                    int num2 = (double)m_pxParticle[index].m_vecPos.X == (double)m_pxParticle[index].m_vecDstPos.X ? 1 : (int)Math.Abs(m_pxParticle[index].m_vecDstPos.X - m_pxParticle[index].m_vecPos.X);
                    int num3 = (double)m_pxParticle[index].m_vecPos.Y == (double)m_pxParticle[index].m_vecDstPos.Y ? 1 : (int)Math.Abs(m_pxParticle[index].m_vecDstPos.Y - m_pxParticle[index].m_vecPos.Y);
                    if (num2 == 0)
                        num2 = 1;
                    if (num3 == 0)
                        num3 = 1;
                    float num4 = 500f / (float)num2;
                    float num5 = 500f / (float)num3;
                    int num6;
                    int num7;
                    if (num2 > num3)
                    {
                        num6 = (int)(((double)m_pxParticle[index].m_vecDstPos.X - (double)m_pxParticle[index].m_vecPos.X) * (double)num4);
                        num7 = (int)(((double)m_pxParticle[index].m_vecDstPos.Y - (double)m_pxParticle[index].m_vecPos.Y) * (double)num4);
                    }
                    else
                    {
                        num6 = (int)(((double)m_pxParticle[index].m_vecDstPos.X - (double)m_pxParticle[index].m_vecPos.X) * (double)num5);
                        num7 = (int)(((double)m_pxParticle[index].m_vecDstPos.Y - (double)m_pxParticle[index].m_vecPos.Y) * (double)num5);
                    }
                    float num8 = (float)num6 / 1000f;
                    float num9 = (float)num7 / 1000f;
                    m_pxParticle[index].m_vecOldPos.X = m_pxParticle[index].m_vecPos.X;
                    m_pxParticle[index].m_vecOldPos.Y = m_pxParticle[index].m_vecPos.Y;
                    m_pxParticle[index].m_vecPos.X += num8 * (float)nLoopTime;
                    m_pxParticle[index].m_vecPos.Y += num9 * (float)nLoopTime;
                    int num10 = (int)Math.Abs(m_pxParticle[index].m_vecDstPos.X - m_pxParticle[index].m_vecPos.X);
                    int num11 = (int)Math.Abs(m_pxParticle[index].m_vecDstPos.Y - m_pxParticle[index].m_vecPos.Y);
                    if (num10 <= 10 && num11 <= 10 || (double)num10 >= (double)m_pxParticle[index].m_vecPrevDis.X && (double)num11 >= (double)m_pxParticle[index].m_vecPrevDis.Y)
                    {
                        m_pxParticle[index].Init();
                        --m_shPartNum;
                    }
                    else
                    {
                        m_pxParticle[index].m_vecPrevDis.X = (float)num10;
                        m_pxParticle[index].m_vecPrevDis.Y = (float)num11;
                    }
                    ++num1;
                }
                if (num1 >= (int)m_shPartNum)
                    break;
            }
        }

        private static float smethod_1(float float_0)
        {
            return Math.Abs(float_0);
        }
    }
}
