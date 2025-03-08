using Client.Envir;
using Library;
using SlimDX;

namespace Client.Models
{
    public class CSmoke : CParticleSystem
    {
        private short m_shPartNum;

        public CSmoke()
        {
            InitSystem();
        }

        ~CSmoke()
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

        public override void SetupSystem(int wCnt = 1000)
        {
            InitSystem();
            base.SetupSystem(wCnt);
            SetEnvFactor(-0.05f, new Vector3(0.0f, 1000f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f));
        }

        public bool RenderSystem()
        {
            BlendRate = 0.03137255f;
            return RenderSystem((int)m_shPartNum, 530, BlendState._BLEND_LIGHTINV, LibraryFile.ProgUse);
        }

        public void SetSmokeParticle(Vector3 vecGenPos)
        {
            int num = 0;
            for (int nNum = 0; nNum < m_nNum; ++nNum)
            {
                if (m_pxParticle[nNum].m_bIsDead)
                {
                    SetParticleDefault(nNum, vecGenPos);
                    ++m_shPartNum;
                    ++num;
                    if (num > 0)
                        break;
                }
            }
        }

        public void SetSmokeParticleEx(Vector3 vecGenPos)
        {
            int num = 0;
            for (int index = 0; index < m_nNum; ++index)
            {
                if (m_pxParticle[index].m_bIsDead)
                {
                    m_pxParticle[index].ZeroInit();
                    m_pxParticle[index].m_vecPos = vecGenPos;
                    m_pxParticle[index].m_vecVel = new Vector3((float)GetRandomNum(-12, 12), 0.0f, 0.0f);
                    m_pxParticle[index].m_nLife = GetRandomNum(200, 1200);
                    m_pxParticle[index].m_fMass = 1000f;
                    m_pxParticle[index].m_fSize = m_pxParticle[index].m_fOriSize = (float)GetRandomNum(20, 25) + (float)CEnvir.Random.NextDouble();
                    m_pxParticle[index].m_bRed = m_pxParticle[index].m_bFstRed = (byte)GetRandomNum(80, 120);
                    m_pxParticle[index].m_bGreen = m_pxParticle[index].m_bFstGreen = (byte)GetRandomNum(80, 120);
                    m_pxParticle[index].m_bBlue = m_pxParticle[index].m_bFstBlue = (byte)GetRandomNum(220, (int)byte.MaxValue);
                    m_pxParticle[index].m_nDelay = GetRandomNum(200, 300);
                    ++m_shPartNum;
                    ++num;
                    if (num > 0)
                        break;
                }
            }
        }

        public void SetSmokeParticleEx2(Vector3 vecGenPos)
        {
            int num = 0;
            for (int index = 0; index < m_nNum; ++index)
            {
                if (m_pxParticle[index].m_bIsDead)
                {
                    m_pxParticle[index].ZeroInit();
                    m_pxParticle[index].m_vecPos = vecGenPos;
                    m_pxParticle[index].m_vecVel = new Vector3((float)GetRandomNum(-20, 20), 0.0f, 0.0f);
                    m_pxParticle[index].m_nLife = GetRandomNum(400, 800);
                    m_pxParticle[index].m_fMass = 1000f;
                    m_pxParticle[index].m_fSize = m_pxParticle[index].m_fOriSize = (float)GetRandomNum(20, 25) + (float)CEnvir.Random.NextDouble();
                    m_pxParticle[index].m_bRed = m_pxParticle[index].m_bFstRed = (byte)GetRandomNum(50, 100);
                    m_pxParticle[index].m_bGreen = m_pxParticle[index].m_bFstGreen = (byte)GetRandomNum(50, 100);
                    m_pxParticle[index].m_bBlue = m_pxParticle[index].m_bFstBlue = (byte)GetRandomNum((int)byte.MaxValue, (int)byte.MaxValue);
                    m_pxParticle[index].m_nDelay = GetRandomNum(200, 300);
                    ++m_shPartNum;
                    ++num;
                    if (num > 0)
                        break;
                }
            }
        }

        public void SetSmokeParticleEx3(Vector3 vecGenPos)
        {
            int num1 = 0;
            for (int index = 0; index < m_nNum; ++index)
            {
                if (m_pxParticle[index].m_bIsDead)
                {
                    m_pxParticle[index].ZeroInit();
                    m_pxParticle[index].m_vecPos = vecGenPos;
                    m_pxParticle[index].m_vecVel = new Vector3(0.0f, 0.0f, 0.0f);
                    m_pxParticle[index].m_nLife = GetRandomNum(400, 500);
                    m_pxParticle[index].m_fMass = 10000f;
                    CParticle cparticle1 = m_pxParticle[index];
                    CParticle cparticle2 = m_pxParticle[index];
                    float num2 = 7f;
                    cparticle2.m_fOriSize = 7f;
                    cparticle1.m_fSize = num2;
                    m_pxParticle[index].m_bRed = m_pxParticle[index].m_bFstRed = (byte)GetRandomNum(100, 150);
                    m_pxParticle[index].m_bGreen = m_pxParticle[index].m_bFstGreen = (byte)GetRandomNum(150, 200);
                    m_pxParticle[index].m_bBlue = m_pxParticle[index].m_bFstBlue = (byte)GetRandomNum((int)byte.MaxValue, (int)byte.MaxValue);
                    m_pxParticle[index].m_nDelay = GetRandomNum(200, 300);
                    ++m_shPartNum;
                    ++num1;
                    if (num1 > 0)
                        break;
                }
            }
        }

        public void SetSmokeParticleEx4(Vector3 vecGenPos)
        {
            int num = 0;
            for (int index = 0; index < m_nNum; ++index)
            {
                if (m_pxParticle[index].m_bIsDead)
                {
                    m_pxParticle[index].ZeroInit();
                    m_pxParticle[index].m_vecPos = vecGenPos;
                    m_pxParticle[index].m_vecVel = new Vector3((float)GetRandomNum(-12, 12), (float)GetRandomNum(-120, -80), 0.0f);
                    m_pxParticle[index].m_nLife = GetRandomNum(300, 600);
                    m_pxParticle[index].m_fMass = 1000f;
                    m_pxParticle[index].m_fSize = m_pxParticle[index].m_fOriSize = (float)GetRandomNum(10, 30);
                    m_pxParticle[index].m_bRed = m_pxParticle[index].m_bFstRed = (byte)GetRandomNum(100, 150);
                    m_pxParticle[index].m_bGreen = m_pxParticle[index].m_bFstGreen = (byte)GetRandomNum(150, 200);
                    m_pxParticle[index].m_bBlue = m_pxParticle[index].m_bFstBlue = (byte)GetRandomNum((int)byte.MaxValue, (int)byte.MaxValue);
                    m_pxParticle[index].m_nDelay = GetRandomNum(200, 300);
                    ++m_shPartNum;
                    ++num;
                    if (num > 0)
                        break;
                }
            }
        }

        public void SetSmokeParticleEx5(Vector3 vecGenPos)
        {
            int num = 0;
            for (int index = 0; index < m_nNum; ++index)
            {
                if (m_pxParticle[index].m_bIsDead)
                {
                    m_pxParticle[index].ZeroInit();
                    m_pxParticle[index].m_vecPos = vecGenPos;
                    m_pxParticle[index].m_vecVel = new Vector3((float)GetRandomNum(-2, 2), 0.0f, 0.0f);
                    m_pxParticle[index].m_nLife = GetRandomNum(200, 400);
                    m_pxParticle[index].m_fMass = 1000f;
                    m_pxParticle[index].m_fSize = m_pxParticle[index].m_fOriSize = (float)GetRandomNum(8, 12) + (float)CEnvir.Random.NextDouble();
                    m_pxParticle[index].m_bRed = m_pxParticle[index].m_bFstRed = (byte)GetRandomNum(220, (int)byte.MaxValue);
                    m_pxParticle[index].m_bGreen = m_pxParticle[index].m_bFstGreen = (byte)GetRandomNum(140, 160);
                    m_pxParticle[index].m_bBlue = m_pxParticle[index].m_bFstBlue = (byte)GetRandomNum(60, 80);
                    m_pxParticle[index].m_nDelay = GetRandomNum(200, 300);
                    ++m_shPartNum;
                    ++num;
                    if (num > 0)
                        break;
                }
            }
        }

        public void SetSmokeParticleEx6(Vector3 vecGenPos)
        {
            int num = 0;
            for (int index = 0; index < m_nNum; ++index)
            {
                if (m_pxParticle[index].m_bIsDead)
                {
                    m_pxParticle[index].ZeroInit();
                    m_pxParticle[index].m_vecPos = vecGenPos;
                    m_pxParticle[index].m_vecVel = new Vector3((float)GetRandomNum(-30, 0), (float)GetRandomNum(-60, -60), 0.0f);
                    m_pxParticle[index].m_nLife = GetRandomNum(800, 1200);
                    m_pxParticle[index].m_fMass = 2000f;
                    m_pxParticle[index].m_fSize = m_pxParticle[index].m_fOriSize = (float)GetRandomNum(20, 40);
                    m_pxParticle[index].m_bRed = m_pxParticle[index].m_bFstRed = (byte)GetRandomNum(50, 50);
                    m_pxParticle[index].m_bGreen = m_pxParticle[index].m_bFstGreen = (byte)GetRandomNum(50, 50);
                    m_pxParticle[index].m_bBlue = m_pxParticle[index].m_bFstBlue = (byte)GetRandomNum(50, 50);
                    m_pxParticle[index].m_nDelay = GetRandomNum(200, 300);
                    ++m_shPartNum;
                    ++num;
                    if (num > 0)
                        break;
                }
            }
        }

        public void SetSmokeParticleEx7(Vector3 vecGenPos)
        {
            int num1 = 0;
            for (int index = 0; index < m_nNum; ++index)
            {
                if (m_pxParticle[index].m_bIsDead)
                {
                    m_pxParticle[index].ZeroInit();
                    m_pxParticle[index].m_vecPos = vecGenPos;
                    m_pxParticle[index].m_vecVel = new Vector3(-20f, -20f, 0.0f);
                    m_pxParticle[index].m_nLife = 1000;
                    m_pxParticle[index].m_fMass = 10000f;
                    CParticle cparticle1 = m_pxParticle[index];
                    CParticle cparticle2 = m_pxParticle[index];
                    float num2 = 18f;
                    cparticle2.m_fOriSize = 18f;
                    cparticle1.m_fSize = num2;
                    m_pxParticle[index].m_bRed = m_pxParticle[index].m_bFstRed = (byte)GetRandomNum(60, 70);
                    m_pxParticle[index].m_bGreen = m_pxParticle[index].m_bFstGreen = (byte)GetRandomNum(60, 70);
                    m_pxParticle[index].m_bBlue = m_pxParticle[index].m_bFstBlue = (byte)GetRandomNum(70, 80);
                    m_pxParticle[index].m_nDelay = GetRandomNum(200, 300);
                    ++m_shPartNum;
                    ++num1;
                    if (num1 > 0)
                        break;
                }
            }
        }

        public void SetSmokeParticleEx8(Vector3 vecGenPos)
        {
            int num = 0;
            for (int index = 0; index < m_nNum; ++index)
            {
                if (m_pxParticle[index].m_bIsDead)
                {
                    m_pxParticle[index].ZeroInit();
                    m_pxParticle[index].m_vecPos = vecGenPos;
                    m_pxParticle[index].m_vecVel = new Vector3((float)GetRandomNum(-12, 12), 0.0f, 0.0f);
                    m_pxParticle[index].m_nLife = GetRandomNum(200, 400);
                    m_pxParticle[index].m_fMass = 1000f;
                    m_pxParticle[index].m_fSize = m_pxParticle[index].m_fOriSize = (float)GetRandomNum(20, 20) + (float)CEnvir.Random.NextDouble();
                    m_pxParticle[index].m_bRed = m_pxParticle[index].m_bFstRed = (byte)GetRandomNum(60, 70);
                    m_pxParticle[index].m_bGreen = m_pxParticle[index].m_bFstGreen = (byte)GetRandomNum(220, 230);
                    m_pxParticle[index].m_bBlue = m_pxParticle[index].m_bFstBlue = (byte)GetRandomNum(210, 220);
                    m_pxParticle[index].m_nDelay = GetRandomNum(200, 300);
                    ++m_shPartNum;
                    ++num;
                    if (num > 0)
                        break;
                }
            }
        }

        public void SetSmokeParticleEx9(Vector3 vecGenPos)
        {
            int num = 0;
            for (int index = 0; index < m_nNum; ++index)
            {
                if (m_pxParticle[index].m_bIsDead)
                {
                    m_pxParticle[index].ZeroInit();
                    m_pxParticle[index].m_vecPos = vecGenPos;
                    m_pxParticle[index].m_vecVel = new Vector3((float)GetRandomNum(-20, 0), (float)GetRandomNum(-90, -150), 0.0f);
                    m_pxParticle[index].m_nLife = GetRandomNum(1000, 3000);
                    m_pxParticle[index].m_fMass = 2000f;
                    m_pxParticle[index].m_fSize = m_pxParticle[index].m_fOriSize = (float)GetRandomNum(8, 10) + (float)CEnvir.Random.NextDouble();
                    m_pxParticle[index].m_bRed = m_pxParticle[index].m_bFstRed = m_pxParticle[index].m_bGreen = m_pxParticle[index].m_bFstGreen = m_pxParticle[index].m_bBlue = m_pxParticle[index].m_bFstBlue = (byte)GetRandomNum(120, 150);
                    m_pxParticle[index].m_nDelay = GetRandomNum(200, 300);
                    ++m_shPartNum;
                    ++num;
                    if (num > 1)
                        break;
                }
            }
        }

        public void SetSmokeParticleEx10(Vector3 vecGenPos)
        {
            int num = 0;
            for (int index = 0; index < m_nNum; ++index)
            {
                if (m_pxParticle[index].m_bIsDead)
                {
                    m_pxParticle[index].ZeroInit();
                    m_pxParticle[index].m_vecPos = vecGenPos;
                    m_pxParticle[index].m_vecVel = new Vector3((float)GetRandomNum(-10, 10), (float)GetRandomNum(-80, 0), 0.0f);
                    m_pxParticle[index].m_nLife = GetRandomNum(800, 1200);
                    m_pxParticle[index].m_fMass = 2000f;
                    m_pxParticle[index].m_fSize = m_pxParticle[index].m_fOriSize = (float)GetRandomNum(20, 40);
                    m_pxParticle[index].m_bRed = m_pxParticle[index].m_bFstRed = (byte)GetRandomNum(50, 50);
                    m_pxParticle[index].m_bGreen = m_pxParticle[index].m_bFstGreen = (byte)GetRandomNum(50, 50);
                    m_pxParticle[index].m_bBlue = m_pxParticle[index].m_bFstBlue = (byte)GetRandomNum(50, 50);
                    m_pxParticle[index].m_nDelay = GetRandomNum(200, 300);
                    ++m_shPartNum;
                    ++num;
                    if (num > 0)
                        break;
                }
            }
        }

        public void SetSmokeParticleEx11(Vector3 vecGenPos)
        {
            int num = 0;
            for (int index = 0; index < m_nNum; ++index)
            {
                if (m_pxParticle[index].m_bIsDead)
                {
                    m_pxParticle[index].ZeroInit();
                    m_pxParticle[index].m_vecPos = vecGenPos;
                    m_pxParticle[index].m_vecVel = new Vector3((float)GetRandomNum(-55, 5), (float)GetRandomNum(-100, -50), 0.0f);
                    m_pxParticle[index].m_nLife = GetRandomNum(900, 1000);
                    m_pxParticle[index].m_fMass = 2000f;
                    m_pxParticle[index].m_fSize = m_pxParticle[index].m_fOriSize = (float)GetRandomNum(20, 40);
                    m_pxParticle[index].m_bRed = m_pxParticle[index].m_bFstRed = (byte)GetRandomNum(50, 50);
                    m_pxParticle[index].m_bGreen = m_pxParticle[index].m_bFstGreen = (byte)GetRandomNum(50, 50);
                    m_pxParticle[index].m_bBlue = m_pxParticle[index].m_bFstBlue = (byte)GetRandomNum(50, 50);
                    m_pxParticle[index].m_nDelay = GetRandomNum(200, 300);
                    ++m_shPartNum;
                    ++num;
                    if (num > 0)
                        break;
                }
            }
        }

        public void SetSmokeParticleEx12(Vector3 vecGenPos)
        {
            int num = 0;
            for (int index = 0; index < m_nNum; ++index)
            {
                if (m_pxParticle[index].m_bIsDead)
                {
                    m_pxParticle[index].ZeroInit();
                    m_pxParticle[index].m_vecPos = vecGenPos;
                    m_pxParticle[index].m_vecVel = new Vector3((float)GetRandomNum(-10, 10), 0.0f, 0.0f);
                    m_pxParticle[index].m_nLife = GetRandomNum(500, 500);
                    m_pxParticle[index].m_fMass = 1000f;
                    m_pxParticle[index].m_fSize = m_pxParticle[index].m_fOriSize = (float)GetRandomNum(10, 30) + (float)CEnvir.Random.NextDouble();
                    m_pxParticle[index].m_bRed = m_pxParticle[index].m_bFstRed = m_pxParticle[index].m_bGreen = m_pxParticle[index].m_bFstGreen = m_pxParticle[index].m_bBlue = m_pxParticle[index].m_bFstBlue = (byte)GetRandomNum(100, 150);
                    m_pxParticle[index].m_nDelay = GetRandomNum(200, 300);
                    ++m_shPartNum;
                    ++num;
                    if (num > 0)
                        break;
                }
            }
        }

        public void SetSmokeParticleEx13(Vector3 vecGenPos)
        {
            int num = 0;
            for (int index = 0; index < m_nNum; ++index)
            {
                if (m_pxParticle[index].m_bIsDead)
                {
                    m_pxParticle[index].ZeroInit();
                    m_pxParticle[index].m_vecPos = vecGenPos;
                    m_pxParticle[index].m_vecVel = new Vector3((float)GetRandomNum(-30, 0), (float)GetRandomNum(-130, -100), 0.0f);
                    m_pxParticle[index].m_nLife = GetRandomNum(800, 900);
                    m_pxParticle[index].m_fMass = 1000f;
                    m_pxParticle[index].m_fSize = m_pxParticle[index].m_fOriSize = (float)GetRandomNum(20, 30);
                    m_pxParticle[index].m_bRed = m_pxParticle[index].m_bFstRed = (byte)GetRandomNum(0, 10);
                    m_pxParticle[index].m_bGreen = m_pxParticle[index].m_bFstGreen = (byte)GetRandomNum(65, 75);
                    m_pxParticle[index].m_bBlue = m_pxParticle[index].m_bFstBlue = (byte)GetRandomNum(140, 150);
                    m_pxParticle[index].m_nDelay = GetRandomNum(1000, 1500);
                    ++m_shPartNum;
                    ++num;
                    if (num > 0)
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
                        m_pxParticle[nNum].m_fSize = m_pxParticle[nNum].m_fOriSize + (float)((double)m_pxParticle[nNum].m_fOriSize * 7.0 * ((double)m_pxParticle[nNum].m_nCurrLife / (double)m_pxParticle[nNum].m_nLife));
                        Vector3 vector3 = new Vector3((float)GetRandomNum(-1, 1), 0.0f, 0.0f);
                        m_pxParticle[nNum].m_vecVel.X += vector3.X;
                        m_pxParticle[nNum].m_vecVel.Y += vector3.Y;
                        m_pxParticle[nNum].m_vecVel.Z += vector3.Z;
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
                if (num1 >= (int)m_shPartNum)
                    break;
            }
        }

        public override void SetParticleDefault(int nNum, Vector3 vecGenPos)
        {
            m_pxParticle[nNum].ZeroInit();
            m_pxParticle[nNum].m_vecPos = vecGenPos;
            m_pxParticle[nNum].m_vecVel = new Vector3((float)GetRandomNum(-8, 8), 0.0f, 0.0f);
            m_pxParticle[nNum].m_nLife = GetRandomNum(150, 400);
            m_pxParticle[nNum].m_fMass = 1000f;
            m_pxParticle[nNum].m_fSize = m_pxParticle[nNum].m_fOriSize = (float)GetRandomNum(5, 10) + (float)CEnvir.Random.NextDouble();
            m_pxParticle[nNum].m_bRed = m_pxParticle[nNum].m_bFstRed = m_pxParticle[nNum].m_bGreen = m_pxParticle[nNum].m_bFstGreen = m_pxParticle[nNum].m_bBlue = m_pxParticle[nNum].m_bFstBlue = (byte)GetRandomNum(100, 150);
            m_pxParticle[nNum].m_nDelay = GetRandomNum(200, 300);
        }
    }
}
