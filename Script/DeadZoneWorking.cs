using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneWorking : MonoBehaviour
{
    [SerializeField]
    public GameObject m_pUIMenuMsg;

    [SerializeField]
    public GameObject m_pAnimatorManager;

    [SerializeField]
    public GameObject m_pDeadZone01;

    [SerializeField]
    public GameObject m_pDeadZone02;

    [SerializeField]
    public GameObject m_pDeadZone03;

    UIMenuMsg m_pMenuMsgScript;

    AnimatorManager m_pAnimScript;

    GeneralDetectPlayer[] m_pGDPScripts;

    int m_nDeadZoneMax;

    bool m_isOccur;

    // Start is called before the first frame update
    void Start()
    {
        m_nDeadZoneMax = 3;

        m_isOccur = false;

        m_pGDPScripts = new GeneralDetectPlayer[m_nDeadZoneMax];

        m_pMenuMsgScript = m_pUIMenuMsg.GetComponent<UIMenuMsg>();
        m_pAnimScript = m_pAnimatorManager.GetComponent<AnimatorManager>();

        m_pGDPScripts[0] = m_pDeadZone01.GetComponent<GeneralDetectPlayer>();
        m_pGDPScripts[1] = m_pDeadZone02.GetComponent<GeneralDetectPlayer>();
        m_pGDPScripts[2] = m_pDeadZone03.GetComponent<GeneralDetectPlayer>();


    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < m_nDeadZoneMax; i++)
        {
            if(m_pGDPScripts[i].C_GetIsCollision() & !m_isOccur)
            {
                m_isOccur = true;
                m_pAnimScript[m_pAnimScript.P_nPlayer].SetBool("IsDie", true);
                m_pMenuMsgScript.C_ShowDiedMsg();
            }
        }
    }
}
