using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopEvent : MonoBehaviour
{
    [SerializeField]
    public GameObject m_pMultipleNInfo;

    [SerializeField]
    public GameObject m_pUIShopMSG01;

    [SerializeField]
    public GameObject m_pShopButton;

    [SerializeField]
    public GameObject m_pUITradeImg;

    MultipleInfo m_pMNInfoScript;

    Image m_pUIButtonImg;

    bool m_isPressSpace;
    bool m_isTrade;

    const int EVENT_MONEY = 1500;

    public bool P_IsPressSpace
    {
        get { return m_isPressSpace; }
        set { m_isPressSpace = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        m_pMNInfoScript = m_pMultipleNInfo.GetComponent<MultipleInfo>();
        m_pUIButtonImg = m_pShopButton.GetComponent<Image>();
        
        m_isPressSpace = false;
        m_isTrade = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (m_pUIButtonImg.color == Color.red)
        {
            m_isPressSpace = false;
            m_pUIButtonImg.color = Color.white;
        }

        if (m_isPressSpace)
        {
            m_pUIButtonImg.color = Color.red;     

            if (m_pMNInfoScript.C_LoadNInfo(MultipleInfo.E_NINFO.E_MONEY) >= EVENT_MONEY)
            {
                if(!m_isTrade)
                {
                    int nTrade = 0;

                    nTrade = m_pMNInfoScript.C_LoadNInfo(MultipleInfo.E_NINFO.E_MONEY) - EVENT_MONEY;
                    m_pMNInfoScript.C_UpdateNInfo(nTrade, MultipleInfo.E_NINFO.E_MONEY);

                    m_pUITradeImg.SetActive(true);
                    m_isTrade = true;
                    m_pMNInfoScript.C_UpdateBInfo(m_isTrade, MultipleInfo.E_BINFO.E_TRADE);
                }
            }
            else
            {
                
            }
        }

    }
}
