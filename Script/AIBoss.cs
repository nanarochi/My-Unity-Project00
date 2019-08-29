using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBoss : MonoBehaviour
{
    [SerializeField]
    public GameObject m_pBoss;

    [SerializeField]
    public GameObject m_pBossSearch;

    [SerializeField]
    public GameObject m_pBossFollow;

    [SerializeField]
    public GameObject m_pBuffController;

    [SerializeField]
    public GameObject m_pPlayer;

    [SerializeField]
    public GameObject m_pDetectEnemy;

    [SerializeField]
    public GameObject m_pUIMenuMsg;

    [SerializeField]
    public GameObject m_pAnimManager;

    BossDetect m_pBossRunScript;

    BossDetect m_pBossBattleScript;

    DetectEnemy m_pDEScript;

    BuffWorking m_pBuffWorkingScript;

    AnimatorManager m_pAnimScript;

    UIMenuMsg m_pUIMMScript;

    bool m_isOccur;

    bool m_isMiss;

    float m_fBossRunSpeed;

    float m_fBossRunTime;

    float m_fInitFromBossDistance;

    float m_fResetPosOffset;

    Vector3 m_vecBossFromInit;

    Vector3 m_vecBossDir;

    Vector3 m_vBossInitPos;

    Vector3 m_vBossResetPos;

    Quaternion m_qAngle;


    void F_Run()
    {
        m_pBoss.transform.LookAt(m_pPlayer.transform);

        m_vecBossDir = Vector3.forward * m_fBossRunSpeed * m_fBossRunTime;

        m_fInitFromBossDistance = m_vecBossDir.sqrMagnitude;

        m_pAnimScript[m_pAnimScript.P_nBoss].SetBool("IsRun", true);

        m_isMiss = true;

        if(m_pDEScript.C_GetIsCollision())
        {
            m_pAnimScript[m_pAnimScript.P_nBoss].SetBool("IsRun", false);          
        }
        else
        {
            m_pBoss.transform.Translate(m_vecBossDir);
            
        }
    }

    void F_ResetPosition()
    {
        m_vBossResetPos = m_vBossInitPos + new Vector3(0.0f, m_fResetPosOffset, 0.0f);
        m_pBoss.transform.position = Vector3.zero + m_vBossResetPos;
        m_isMiss = false;
    }
    bool F_Battle()
    {
        if(m_pBuffWorkingScript.C_GetBuffHave())
        {
            m_pAnimScript[m_pAnimScript.P_nBoss].SetBool("IsDie", true);

            m_pUIMMScript.C_ShowClearMsg();

        }
        else
        {
            m_pAnimScript[m_pAnimScript.P_nPlayer].SetBool("IsDie", true);

            m_pUIMMScript.C_ShowDiedMsg();
        }

        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_pBossBattleScript = m_pBossSearch.GetComponent<BossDetect>();

        m_pBossRunScript = m_pBossFollow.GetComponent<BossDetect>();

        m_pBuffWorkingScript = m_pBuffController.GetComponent<BuffWorking>();

        m_pDEScript = m_pDetectEnemy.GetComponent<DetectEnemy>();

        m_pUIMMScript = m_pUIMenuMsg.GetComponent<UIMenuMsg>();

        m_pAnimScript = m_pAnimManager.GetComponent<AnimatorManager>();


        m_isOccur = false;

        m_isMiss = false;

        m_fBossRunSpeed = 15.0f;

        m_fBossRunTime = Time.deltaTime;

        m_vecBossDir = Vector3.zero;

        m_vBossResetPos = Vector3.zero;

        m_vBossInitPos = m_pBoss.transform.position;

        m_fInitFromBossDistance = 0.0f;

        m_qAngle = Quaternion.identity;

        m_fResetPosOffset = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_pBossRunScript.C_GetIsCollision())
        {
            F_Run();
        }
        else
        {
            m_pAnimScript[m_pAnimScript.P_nBoss].SetBool("IsRun", false);

            if (m_isMiss)
            {
                F_ResetPosition();
            }
        }

        if (m_pBossBattleScript.C_GetIsCollision())
        {
            if (!m_isOccur)
            {
                m_isOccur = F_Battle();
            }
        }
    }
}
