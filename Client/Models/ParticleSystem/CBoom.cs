using Client.Envir;
using Library;
using SlimDX;

namespace Client.Models
{
    public class CBoom : CParticleSystem
    {
        private short m_shPartNum;

        public CBoom()
        {
            InitSystem();
        }

        ~CBoom()
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
            SetEnvFactor(-0.05f, new Vector3(0.0f, 200f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f));
        }

        public bool RenderSystem()
        {
            BlendRate = 0.03137255f;
            return RenderSystem((int)m_shPartNum, 520, BlendState._BLEND_LIGHT, LibraryFile.ProgUse);
        }

        public void SetBoomParticle(Vector3 vecGenPos)
        {
            int num = 0;
            for (int nNum = 0; nNum < m_nNum; ++nNum)
            {
                if (m_pxParticle[nNum].m_bIsDead)
                {
                    SetParticleDefault(nNum, vecGenPos);
                    ++m_shPartNum;
                    ++num;
                    if (num > 1)
                        break;
                }
            }
        }

        public void SetBoomParticle2(Vector3 vecGenPos)
        {
            int num = 0;
            for (int nNum = 0; nNum < m_nNum; ++nNum)
            {
                if (m_pxParticle[nNum].m_bIsDead)
                {
                    SetParticleDefault2(nNum, vecGenPos);
                    ++m_shPartNum;
                    ++num;
                    if (num > 20)
                        break;
                }
            }
        }

        public void SetBoomParticle3(Vector3 vecGenPos)
        {
            int num = 0;
            for (int index = 0; index < m_nNum; ++index)
            {
                if (m_pxParticle[index].m_bIsDead)
                {
                    m_pxParticle[index].ZeroInit();
                    m_pxParticle[index].m_vecPos = vecGenPos;
                    m_pxParticle[index].m_vecVel = new Vector3((float)GetRandomNum(-300, 300), (float)GetRandomNum(-300, 150), 0.0f);
                    m_pxParticle[index].m_nLife = GetRandomNum(300, 1600);
                    m_pxParticle[index].m_fMass = 10f;
                    m_pxParticle[index].m_fSize = m_pxParticle[index].m_fOriSize = (float)GetRandomNum(2, 2) + (float)CEnvir.Random.NextDouble();
                    m_pxParticle[index].m_bRed = m_pxParticle[index].m_bFstRed = (byte)GetRandomNum(30, 60);
                    m_pxParticle[index].m_bGreen = m_pxParticle[index].m_bFstGreen = (byte)GetRandomNum(130, 160);
                    m_pxParticle[index].m_bBlue = m_pxParticle[index].m_bFstBlue = (byte)GetRandomNum(130, 160);
                    m_pxParticle[index].m_nDelay = GetRandomNum(200, 300);
                    ++m_shPartNum;
                    ++num;
                    if (num > 20)
                        break;
                }
            }
        }

        public void SetBoomParticle4(Vector3 vecGenPos)
        {
            int num = 0;
            for (int nNum = 0; nNum < m_nNum; ++nNum)
            {
                if (m_pxParticle[nNum].m_bIsDead)
                {
                    SetParticleDefault3(nNum, vecGenPos);
                    ++m_shPartNum;
                    ++num;
                    if (num > 10)
                        break;
                }
            }
        }

        public void SetBoomParticle5(Vector3 vecGenPos)
        {
            int num = 0;
            for (int nNum = 0; nNum < m_nNum; ++nNum)
            {
                if (m_pxParticle[nNum].m_bIsDead)
                {
                    SetParticleDefault2(nNum, vecGenPos);
                    ++m_shPartNum;
                    ++num;
                    if (num > 5)
                        break;
                }
            }
        }

        public void SetBoomParticle6(Vector3 vecGenPos)
        {
            int num = 0;
            for (int index = 0; index < 600; ++index)
            {
                if (m_pxParticle[index].m_bIsDead)
                {
                    m_pxParticle[index].ZeroInit();
                    m_pxParticle[index].m_vecPos = vecGenPos;
                    m_pxParticle[index].m_vecVel = new Vector3((float)GetRandomNum(-80, 80), (float)GetRandomNum(-180, 10), 0.0f);
                    m_pxParticle[index].m_nLife = GetRandomNum(800, 1200);
                    m_pxParticle[index].m_fMass = 5f;
                    m_pxParticle[index].m_fSize = m_pxParticle[index].m_fOriSize = (float)GetRandomNum(4, 5) + (float)CEnvir.Random.NextDouble();
                    m_pxParticle[index].m_bRed = m_pxParticle[index].m_bFstRed = (byte)GetRandomNum(120, 130);
                    m_pxParticle[index].m_bGreen = m_pxParticle[index].m_bFstGreen = (byte)GetRandomNum(200, 210);
                    m_pxParticle[index].m_bBlue = m_pxParticle[index].m_bFstBlue = (byte)GetRandomNum(230, 240);
                    m_pxParticle[index].m_nDelay = GetRandomNum(0, 0);
                    ++m_shPartNum;
                    ++num;
                    if (num > 5)
                        break;
                }
            }
        }

        public override void UpdateSystem(int nLoopTime, Vector3 vecGenPos)
        {
            int num1 = nLoopTime / 17;
            int num2 = 0;
            if (num1 < 1)
                num1 = 1;
            m_fDeltaTime = 0.02f * (float)num1;
            for (int nNum = 0; nNum < m_nNum; ++nNum)
            {
                if (!m_pxParticle[nNum].m_bIsDead)
                {
                    m_pxParticle[nNum].m_nCurrLife += nLoopTime;
                    if (m_pxParticle[nNum].m_nCurrLife > m_pxParticle[nNum].m_nLife)
                    {
                        m_pxParticle[nNum].Init();
                        --m_shPartNum;
                        --num2;
                    }
                    else
                    {
                        m_pxParticle[nNum].m_nCurrDelay += nLoopTime;
                        m_pxParticle[nNum].m_fMass += 3f;
                        if ((double)m_pxParticle[nNum].m_fSize < 0.0)
                            m_pxParticle[nNum].m_fSize = 0.0f;
                        if (m_pxParticle[nNum].m_nCurrDelay > m_pxParticle[nNum].m_nDelay)
                        {
                            m_pxParticle[nNum].m_nCurrDelay = 0;
                            ++m_pxParticle[nNum].m_nCurrFrame;
                            if (m_pxParticle[nNum].m_nCurrFrame >= 4)
                                m_pxParticle[nNum].m_nCurrFrame = 0;
                        }
                        if (m_pxParticle[nNum].m_nLife == 0)
                            m_pxParticle[nNum].m_nLife = 1;
                        m_pxParticle[nNum].m_fSize = m_pxParticle[nNum].m_fOriSize - m_pxParticle[nNum].m_fOriSize * ((float)m_pxParticle[nNum].m_nCurrLife / (float)m_pxParticle[nNum].m_nLife);
                        UpdateAirFiction(nNum);
                        UpdateMove(nNum);
                        ++num2;
                    }
                }
                if (num2 >= (int)m_shPartNum)
                    break;
            }
        }

        public override void SetParticleDefault(int nNum, Vector3 vecGenPos)
        {
            m_pxParticle[nNum].ZeroInit();
            m_pxParticle[nNum].m_vecPos = vecGenPos;
            m_pxParticle[nNum].m_vecVel = new Vector3((float)GetRandomNum(-75, 75), (float)GetRandomNum(-180, -50), 0.0f);
            m_pxParticle[nNum].m_nLife = GetRandomNum(800, 1200);
            m_pxParticle[nNum].m_fMass = 1f;
            m_pxParticle[nNum].m_fSize = m_pxParticle[nNum].m_fOriSize = (float)GetRandomNum(2, 10) + (float)CEnvir.Random.NextDouble();
            m_pxParticle[nNum].m_bRed = m_pxParticle[nNum].m_bFstRed = (byte)GetRandomNum(50, 100);
            m_pxParticle[nNum].m_bGreen = m_pxParticle[nNum].m_bFstGreen = (byte)GetRandomNum(100, 200);
            m_pxParticle[nNum].m_bBlue = m_pxParticle[nNum].m_bFstBlue = (byte)GetRandomNum(200, (int)byte.MaxValue);
            m_pxParticle[nNum].m_nDelay = GetRandomNum(200, 300);
        }

        public void SetParticleDefault2(int nNum, Vector3 vecGenPos)
        {
            m_pxParticle[nNum].ZeroInit();
            m_pxParticle[nNum].m_vecPos = vecGenPos;
            m_pxParticle[nNum].m_vecVel = new Vector3((float)GetRandomNum(-175, 175), (float)GetRandomNum(-180, 10), 0.0f);
            m_pxParticle[nNum].m_nLife = GetRandomNum(800, 2000);
            m_pxParticle[nNum].m_fMass = 1f;
            m_pxParticle[nNum].m_fSize = m_pxParticle[nNum].m_fOriSize = (float)GetRandomNum(6, 7) + (float)CEnvir.Random.NextDouble();
            m_pxParticle[nNum].m_bRed = m_pxParticle[nNum].m_bFstRed = (byte)GetRandomNum(40, 50);
            m_pxParticle[nNum].m_bGreen = m_pxParticle[nNum].m_bFstGreen = (byte)GetRandomNum(40, 50);
            m_pxParticle[nNum].m_bBlue = m_pxParticle[nNum].m_bFstBlue = (byte)GetRandomNum(40, 50);
            m_pxParticle[nNum].m_nDelay = GetRandomNum(200, 300);
        }

        public void SetParticleDefault3(int nNum, Vector3 vecGenPos)
        {
            m_pxParticle[nNum].ZeroInit();
            m_pxParticle[nNum].m_vecPos = vecGenPos;
            m_pxParticle[nNum].m_vecVel = new Vector3((float)GetRandomNum(-120, 120), (float)GetRandomNum(-180, 0), 0.0f);
            m_pxParticle[nNum].m_nLife = GetRandomNum(200, 1200);
            m_pxParticle[nNum].m_fMass = 1f;
            m_pxParticle[nNum].m_fSize = m_pxParticle[nNum].m_fOriSize = (float)GetRandomNum(3, 12) + (float)CEnvir.Random.NextDouble();
            m_pxParticle[nNum].m_bRed = m_pxParticle[nNum].m_bFstRed = (byte)GetRandomNum(40, 50);
            m_pxParticle[nNum].m_bGreen = m_pxParticle[nNum].m_bFstGreen = (byte)GetRandomNum(40, 50);
            m_pxParticle[nNum].m_bBlue = m_pxParticle[nNum].m_bFstBlue = (byte)GetRandomNum(40, 50);
            m_pxParticle[nNum].m_nDelay = GetRandomNum(200, 300);
        }
    }
}
