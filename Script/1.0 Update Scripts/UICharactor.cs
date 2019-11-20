using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharactor : MonoBehaviour
{
    [SerializeField]
    public GameObject m_pMultipleNInfo;

    [SerializeField]
    public GameObject m_pUITextCount;

    [SerializeField]
    public GameObject m_pUITextGoldScore;

    [SerializeField]
    public GameObject m_pUITextTotalScore;

    [SerializeField]
    public GameObject m_pInputScript;

    [SerializeField]
    public GameObject m_pGUICharactor;

    PlayerKeyController m_pPKCScript;
    MultipleInfo m_pMNInfoScript;

    Text m_pTextCount;
    Text m_pTextGoldScore;
    Text m_PTextTotalScore;

    int m_nCount;
    int m_nGoldScore;
    int m_nTotalScore;

    public void C_ShowCharactor()
    {
        Time.timeScale = 0;

        m_pPKCScript.P_IsActiveCharactor = true;

        m_pPKCScript.P_IsActiveCharactorPopUp = true;

        m_pGUICharactor.SetActive(m_pPKCScript.P_IsActiveCharactor);
    }

    public void C_OnClickCloseCharactor()
    {
        Time.timeScale = 1;

        m_pPKCScript.P_IsActiveCharactor = false;

        m_pPKCScript.P_IsActiveCharactorPopUp = false;

        m_pGUICharactor.SetActive(m_pPKCScript.P_IsActiveCharactor);
    }

    // Start is called before the first frame update
    void Start()
    {
        m_pMNInfoScript = m_pMultipleNInfo.GetComponent<MultipleInfo>();
        m_pPKCScript = m_pInputScript.GetComponent<PlayerKeyController>();
        m_pTextCount = m_pUITextCount.GetComponent<Text>();
        m_pTextGoldScore = m_pUITextGoldScore.GetComponent<Text>();
        m_PTextTotalScore = m_pUITextTotalScore.GetComponent<Text>();

        m_nCount = 0;
        m_nGoldScore = 0;
        m_nTotalScore = 0;

    }

    // Update is called once per frame
    void Update()
    {
        m_nCount = m_pMNInfoScript.P_LoadNInfo(MultipleInfo.E_NINFO.E_GOLD);
        m_nGoldScore = m_pMNInfoScript.P_LoadNInfo(MultipleInfo.E_NINFO.E_GOLDSCORE);
        m_nTotalScore = m_pMNInfoScript.P_LoadNInfo(MultipleInfo.E_NINFO.E_SCORE);

        m_pTextCount.text = m_nCount.ToString();
        m_pTextGoldScore.text = m_nGoldScore.ToString();
        m_PTextTotalScore.text = m_nTotalScore.ToString();
        
    }
}
