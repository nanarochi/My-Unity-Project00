using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopAI : MonoBehaviour
{
    [SerializeField]
    public GameObject m_pShopDetect;

    [SerializeField]
    public GameObject m_pUIShopMSG01;

    public enum E_SWITHTYPE
    {
        E_OFF = 0,
        E_ON,
        E_MAX
    }

    GeneralDetectPlayer m_pDetectScript;

    bool m_isTrigger;

    public bool P_IsTrigger
    {
        get
        {
            return m_isTrigger;
        }

        set
        {
            m_isTrigger = value;
        }
    }

    void F_UISwitch(GameObject pObj, E_SWITHTYPE eType)
    {
        if(E_SWITHTYPE.E_ON == eType)
        {
            pObj.SetActive(true);
        }
        else if(E_SWITHTYPE.E_OFF == eType)
        {
            pObj.SetActive(false);
        }
    }

   
    // Start is called before the first frame update
    void Start()
    {
        m_pDetectScript = m_pShopDetect.GetComponent<GeneralDetectPlayer>();
    
        m_isTrigger = false;

    }

    // Update is called once per frame
    void Update()
    {
        m_isTrigger = m_pDetectScript.C_GetIsTrigger();

        if (m_isTrigger)
        {
            F_UISwitch(m_pUIShopMSG01, E_SWITHTYPE.E_ON);

        }
        else
        {
            F_UISwitch(m_pUIShopMSG01, E_SWITHTYPE.E_OFF);

        }
    }
}
