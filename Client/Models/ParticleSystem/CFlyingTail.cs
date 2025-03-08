using Client.Envir;
using Library;
using SlimDX;

namespace Client.Models
{
    public class CFlyingTail : CParticleSystem
    {
        private int m_shPartNum;

        public CFlyingTail()
        {
            InitSystem();
        }

        ~CFlyingTail()
        {
            DestroySystem();
        }

        public override void InitSystem()
        {
            base.InitSystem();
            m_shPartNum = 0;
        }

        public override void DestroySystem()
        {
            base.DestroySystem();
        }

        public override void SetupSystem(int wCnt = 1000)
        {
            InitSystem();
            base.SetupSystem(wCnt);
            SetEnvFactor(-0.05f, new Vector3(100f, 1000f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f));
        }

        public bool RenderSystem()
        {
            
            BlendRate = 0.4f;
            return RenderSystem(m_shPartNum, 520, BlendState._BLEND_LIGHT, LibraryFile.ProgUse);
        }

        public void SetFlyTailParticle(Vector3 vecGenPos)
        {
            int num = 0;
            for (int nNum = 0; nNum < m_nNum; ++nNum)
            {
                if (m_pxParticle[nNum].m_bIsDead)
                {
                    SetParticleDefault(nNum, vecGenPos);
                    ++m_shPartNum;
                    ++num;
                    if (num > 2)
                        break;
                }
            }
        }

        public void SetFlyTailParticleEx(Vector3 vecGenPos)
        {
            int num = 0;
            for (int index = 0; index < m_nNum; ++index)
            {
                if (m_pxParticle[index].m_bIsDead)
                {
                    m_pxParticle[index].ZeroInit();
                    m_pxParticle[index].m_vecPos = new Vector3(vecGenPos.X + (float)GetRandomNum(-10, 10), vecGenPos.Y + (float)GetRandomNum(-10, 10), 0.0f);
                    m_pxParticle[index].m_vecVel = new Vector3((float)GetRandomNum(-150, 150), (float)GetRandomNum(-80, 150), 0.0f);
                    m_pxParticle[index].m_nLife = GetRandomNum(200, 1200);
                    m_pxParticle[index].m_fMass = 1000f;
                    m_pxParticle[index].m_fSize = m_pxParticle[index].m_fOriSize = (float)GetRandomNum(5, 10) + (float)CEnvir.Random.NextDouble();
                    m_pxParticle[index].m_bRed = m_pxParticle[index].m_bFstRed = (byte)GetRandomNum(100, 110);
                    m_pxParticle[index].m_bGreen = m_pxParticle[index].m_bFstGreen = (byte)GetRandomNum(100, 110);
                    m_pxParticle[index].m_bBlue = m_pxParticle[index].m_bFstBlue = (byte)GetRandomNum(245, (int)byte.MaxValue);
                    m_pxParticle[index].m_nDelay = GetRandomNum(200, 300);
                    ++m_shPartNum;
                    ++num;
                    if (num > 1)
                        break;
                }
            }
        }

        public void SetFlyTailParticleEx2(Vector3 vecGenPos)
        {
            int num = 0;
            for (int index = 0; index < m_nNum; ++index)
            {
                if (m_pxParticle[index].m_bIsDead)
                {
                    m_pxParticle[index].ZeroInit();
                    m_pxParticle[index].m_vecPos = new Vector3(vecGenPos.X + (float)GetRandomNum(-10, 10), vecGenPos.Y + (float)GetRandomNum(-10, 10), 0.0f);
                    m_pxParticle[index].m_vecVel = new Vector3((float)GetRandomNum(-30, 30), (float)GetRandomNum(-30, 30), 0.0f);
                    m_pxParticle[index].m_nLife = GetRandomNum(200, 1200);
                    m_pxParticle[index].m_fMass = 1000f;
                    m_pxParticle[index].m_fSize = m_pxParticle[index].m_fOriSize = (float)GetRandomNum(3, 7) + (float)CEnvir.Random.NextDouble();
                    m_pxParticle[index].m_bRed = m_pxParticle[index].m_bFstRed = (byte)GetRandomNum(100, 150);
                    m_pxParticle[index].m_bGreen = m_pxParticle[index].m_bFstGreen = (byte)GetRandomNum(150, (int)byte.MaxValue);
                    m_pxParticle[index].m_bBlue = m_pxParticle[index].m_bFstBlue = (byte)GetRandomNum(100, 150);
                    m_pxParticle[index].m_nDelay = GetRandomNum(200, 300);
                    ++m_shPartNum;
                    ++num;
                    if (num > 2)
                        break;
                }
            }
        }

        public void SetFlyTailParticleEx3(Vector3 vecGenPos)
        {
            int num = 0;
            for (int index = 0; index < m_nNum; ++index)
            {
                if (m_pxParticle[index].m_bIsDead)
                {
                    m_pxParticle[index].ZeroInit();
                    m_pxParticle[index].m_vecPos = vecGenPos;
                    m_pxParticle[index].m_vecVel = new Vector3((float)GetRandomNum(-50, 50), (float)GetRandomNum(-30, 60), 0.0f);
                    m_pxParticle[index].m_nLife = GetRandomNum(500, 900);
                    m_pxParticle[index].m_fMass = 1000f;
                    m_pxParticle[index].m_fSize = m_pxParticle[index].m_fOriSize = (float)GetRandomNum(3, 5) + (float)CEnvir.Random.NextDouble();
                    m_pxParticle[index].m_bRed = m_pxParticle[index].m_bFstRed = (byte)GetRandomNum(200, (int)byte.MaxValue);
                    m_pxParticle[index].m_bGreen = m_pxParticle[index].m_bFstGreen = (byte)((uint)m_pxParticle[index].m_bFstRed / 2U);
                    m_pxParticle[index].m_bBlue = m_pxParticle[index].m_bFstBlue = (byte)GetRandomNum(0, 30);
                    m_pxParticle[index].m_nDelay = GetRandomNum(200, 300);
                    ++m_shPartNum;
                    ++num;
                    if (num > 4)
                        break;
                }
            }
        }

        public void SetFlyTailParticleEx4(Vector3 vecGenPos)
        {
            int num = 0;
            for (int index = 0; index < m_nNum; ++index)
            {
                if (m_pxParticle[index].m_bIsDead)
                {
                    m_pxParticle[index].ZeroInit();
                    m_pxParticle[index].m_vecPos = vecGenPos;
                    m_pxParticle[index].m_vecVel = new Vector3((float)GetRandomNum(-50, 50), (float)GetRandomNum(-30, 60), 0.0f);
                    m_pxParticle[index].m_nLife = GetRandomNum(20, 500);
                    m_pxParticle[index].m_fMass = 10000f;
                    m_pxParticle[index].m_fSize = (float)GetRandomNum(5, 15) + (float)CEnvir.Random.NextDouble();
                    m_pxParticle[index].m_bRed = m_pxParticle[index].m_bFstRed = (byte)GetRandomNum(70, 90);
                    m_pxParticle[index].m_bGreen = m_pxParticle[index].m_bFstGreen = (byte)GetRandomNum(70, 90);
                    m_pxParticle[index].m_bBlue = m_pxParticle[index].m_bFstBlue = (byte)GetRandomNum(100, 150);
                    m_pxParticle[index].m_nDelay = GetRandomNum(0, 10);
                    ++m_shPartNum;
                    ++num;
                    if (num > 2)
                        break;
                }
            }
        }

        public void SetFlyTailParticleEx5(Vector3 vecGenPos)
        {
            int num = 0;
            for (int index = 0; index < m_nNum; ++index)
            {
                if (m_pxParticle[index].m_bIsDead)
                {
                    m_pxParticle[index].ZeroInit();
                    m_pxParticle[index].m_vecPos = vecGenPos;
                    m_pxParticle[index].m_vecVel = new Vector3((float)GetRandomNum(-45, 45), (float)GetRandomNum(-150, -250), 0.0f);
                    m_pxParticle[index].m_nLife = GetRandomNum(1000, 1600);
                    m_pxParticle[index].m_fMass = 100f;
                    m_pxParticle[index].m_fSize = 4f;
                    CParticle cparticle1 = m_pxParticle[index];
                    m_pxParticle[index].m_bFstRed = byte.MaxValue;
                    cparticle1.m_bRed = byte.MaxValue;
                    CParticle cparticle2 = m_pxParticle[index];
                    m_pxParticle[index].m_bFstGreen = (byte)125;
                    cparticle2.m_bGreen = (byte)125;
                    CParticle cparticle3 = m_pxParticle[index];
                    m_pxParticle[index].m_bFstBlue = (byte)0;
                    cparticle3.m_bBlue = (byte)0;
                    m_pxParticle[index].m_nDelay = GetRandomNum(200, 300);
                    ++m_shPartNum;
                    ++num;
                    if (num > 2)
                        break;
                }
            }
        }

        public override void UpdateSystem(int nLoopTime, Vector3 vecGenPos)
        {
            int num1 = 0;
            int num2 = nLoopTime / 17;
            if (num2 < 1)
                num2 = 1;
            m_fDeltaTime = 0.02f * (float)num2;
            for (int nNum = 0; nNum < m_nNum; ++nNum)
            {
                if (!m_pxParticle[nNum].m_bIsDead)
                {
                    m_pxParticle[nNum].m_nCurrLife += nLoopTime;
                    if (m_pxParticle[nNum].m_nCurrLife > m_pxParticle[nNum].m_nLife)
                    {
                        m_pxParticle[nNum].Init();
                        --m_shPartNum;
                        --num1;
                    }
                    else
                    {
                        m_pxParticle[nNum].m_nCurrDelay += nLoopTime;
                        if (m_pxParticle[nNum].m_nCurrDelay > m_pxParticle[nNum].m_nDelay)
                        {
                            m_pxParticle[nNum].m_nCurrDelay = 0;
                            ++m_pxParticle[nNum].m_nCurrFrame;
                            if (m_pxParticle[nNum].m_nCurrFrame >= 1)
                                m_pxParticle[nNum].m_nCurrFrame = 0;
                        }
                        if (m_pxParticle[nNum].m_nLife == 0)
                            m_pxParticle[nNum].m_nLife = 1;
                        byte num3 = (byte)((double)m_pxParticle[nNum].m_bFstRed - (double)m_pxParticle[nNum].m_bFstRed * ((double)m_pxParticle[nNum].m_nCurrLife / (double)m_pxParticle[nNum].m_nLife));
                        m_pxParticle[nNum].m_bRed = num3;
                        byte num4 = (byte)((double)m_pxParticle[nNum].m_bFstGreen - (double)m_pxParticle[nNum].m_bFstGreen * ((double)m_pxParticle[nNum].m_nCurrLife / (double)m_pxParticle[nNum].m_nLife));
                        m_pxParticle[nNum].m_bGreen = num4;
                        byte num5 = (byte)((double)m_pxParticle[nNum].m_bFstBlue - (double)m_pxParticle[nNum].m_bFstBlue * ((double)m_pxParticle[nNum].m_nCurrLife / (double)m_pxParticle[nNum].m_nLife));
                        m_pxParticle[nNum].m_bBlue = num5;
                        UpdateAirFiction(nNum);
                        UpdateMove(nNum);
                        ++num1;
                    }
                }
                if (num1 >= m_shPartNum)
                    break;
            }
        }

        public override void SetParticleDefault(int nNum, Vector3 vecGenPos)
        {
            m_pxParticle[nNum].ZeroInit();
            m_pxParticle[nNum].m_vecPos = vecGenPos;
            m_pxParticle[nNum].m_vecVel = new Vector3((float)GetRandomNum(-50, 50), (float)GetRandomNum(-30, 60), 0.0f);
            m_pxParticle[nNum].m_nLife = GetRandomNum(150, 400);
            m_pxParticle[nNum].m_fMass = 1000f;
            m_pxParticle[nNum].m_fSize = (float)GetRandomNum(5, 15) + (float)CEnvir.Random.NextDouble();
            m_pxParticle[nNum].m_bRed = m_pxParticle[nNum].m_bFstRed = (byte)GetRandomNum(200, (int)byte.MaxValue);
            m_pxParticle[nNum].m_bGreen = m_pxParticle[nNum].m_bFstGreen = (byte)((uint)m_pxParticle[nNum].m_bFstRed / 2U);
            m_pxParticle[nNum].m_bBlue = m_pxParticle[nNum].m_bFstBlue = (byte)GetRandomNum(0, 30);
            m_pxParticle[nNum].m_nDelay = GetRandomNum(200, 300);
        }
    }
}
