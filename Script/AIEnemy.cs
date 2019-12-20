using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemy : MonoBehaviour
{
    [SerializeField]
    public GameObject m_pMultipleInfo;

    [SerializeField]
    public GameObject m_pUIMenuMSG;

    [SerializeField]
    public GameObject m_pAnimManager;

    [SerializeField]
    public GameObject m_pEnemys;

    [SerializeField]
    public GameObject m_pUITradeImg;

    MultipleInfo m_pMultipleBScript;
    UIMenuMsg m_pMenuMsgScript;
    AnimatorManager m_pAnimBoxScript;
    GeneralDetectPlayer m_pDetectScript;

    int m_nTime;

    void F_EnemysDieAnim()
    {
        m_pAnimBoxScript[m_pAnimBoxScript.P_nEnemyA].SetBool("IsDie", true);
        m_pAnimBoxScript[m_pAnimBoxScript.P_nEnemyB].SetBool("IsDie", true);
        m_pAnimBoxScript[m_pAnimBoxScript.P_nChief].SetBool("IsDie", true);
    }

    void F_EnemysDie()
    {
        Destroy(m_pEnemys);
        Destroy(gameObject);
    }

    void F_EnemysWinAnim()
    {
        m_pAnimBoxScript[m_pAnimBoxScript.P_nEnemyA].SetBool("IsWin", true);
        m_pAnimBoxScript[m_pAnimBoxScript.P_nEnemyB].SetBool("IsWin", true);
        m_pAnimBoxScript[m_pAnimBoxScript.P_nChief].SetBool("IsAttack", true);
    }
    // Start is called before the first frame update
    void Start()
    {
        m_pMultipleBScript = m_pMultipleInfo.GetComponent<MultipleInfo>();
        m_pMenuMsgScript = m_pUIMenuMSG.GetComponent<UIMenuMsg>();
        m_pAnimBoxScript = m_pAnimManager.GetComponent<AnimatorManager>();
        m_pDetectScript = m_pEnemys.GetComponent<GeneralDetectPlayer>();

        m_nTime = 0;


    }

    // Update is called once per frame
    void Update()
    {
        if (m_nTime < 1)
        {
            if (m_pDetectScript.C_GetIsTrigger())
            {
                if (m_pMultipleBScript.C_LoadBInfo(MultipleInfo.E_BINFO.E_TRADE))
                {
                    F_EnemysDieAnim();
                    m_pUITradeImg.SetActive(false);
                    Invoke("F_EnemysDie", 3.5f);

                }
                else
                {
                    m_pAnimBoxScript[m_pAnimBoxScript.P_nPlayer].SetBool("IsDie", true);
                    F_EnemysWinAnim();
                    m_pMenuMsgScript.C_ShowDiedMsg();
                }
            }
        }
        else
        {

        }
    }
}
