using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInvenWork : MonoBehaviour
{

    [SerializeField]
    [Tooltip("Proper Player Inventory Prefab")]
    public GameObject m_pInven;

    [SerializeField]
    public GameObject m_pInputScript;

    [SerializeField]
    public GameObject m_pMultipleNInfo;

    [SerializeField]
    public GameObject m_pOwnGoldText;

    PlayerKeyController m_pPKCScript;
    MultipleInfo m_pMNInfoScript;

    Text m_pUIGoldText;

    public void C_ShowInven()
    {
        Time.timeScale = 0;

        m_pPKCScript.P_IsActiveInven = true;

        m_pPKCScript.P_IsActiveInvenPopUp = true;

        m_pInven.SetActive(m_pPKCScript.P_IsActiveInven);
    }

    public void C_OnClickCloseInven()
    {
        Time.timeScale = 1;

        m_pPKCScript.P_IsActiveInven = false;

        m_pPKCScript.P_IsActiveInvenPopUp = false;

        m_pInven.SetActive(m_pPKCScript.P_IsActiveInven);
    }

    void F_UpdateOwnMoney()
    {
        m_pUIGoldText.text = m_pMNInfoScript.C_LoadNInfo(MultipleInfo.E_NINFO.E_MONEY).ToString();
    }


    // Start is called before the first frame update
    void Start()
    {
        m_pPKCScript = m_pInputScript.GetComponent<PlayerKeyController>();
        m_pMNInfoScript = m_pMultipleNInfo.GetComponent<MultipleInfo>();
        m_pUIGoldText = m_pOwnGoldText.GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        F_UpdateOwnMoney();
    }
}
