using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIPlayerStatus : MonoBehaviour
{
    /// <summary>
    /// Variables in Inspector;
    /// </summary>

    #region Public Variables

    [SerializeField]
    public GameObject m_pUIBox;

    [SerializeField]
    public GameObject m_pUIHpBar;

    [SerializeField]
    public GameObject m_pUIMpBar;

    [SerializeField]
    public GameObject m_pUIPlayerStatusList;

    [SerializeField]
    public GameObject m_pPlayerInfo;

    [SerializeField]
    public GameObject m_pUIExpBar;

    #endregion

    #region Class Field

    RectTransform m_HpCostBar;

    RectTransform m_MpCostBar;

    RectTransform m_ExpBar;

    Text m_LvText;

    PlayerInfo m_pPlayerInfoScript;

    float m_fHp;
    float m_fHpCost;
    float m_fMp;
    float m_fMpCost;
    float m_fLv;
    float m_fExp;

    Rect m_RectHpCost;
    Rect m_RectMpCost;
    Rect m_RectExp;

    #endregion

    #region Class Method

    void F_UIStatusUpdate()
    {   
        m_fHpCost = m_pPlayerInfoScript.m_fHp - m_pPlayerInfoScript.m_fCurHp;
        m_fMpCost = m_pPlayerInfoScript.m_fMp - m_pPlayerInfoScript.m_fCurMp;
        m_fExp = m_pPlayerInfoScript.m_fCurExp;

        m_fLv = m_pPlayerInfoScript.m_fCurLv;


        m_RectHpCost.width = m_fHpCost;
        m_RectMpCost.width = m_fMpCost;
        m_RectExp.width = m_fExp;
    }

    void F_UIStatusDisplay()
    {
        m_HpCostBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, m_RectHpCost.width);
        m_MpCostBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, m_RectMpCost.width);
        m_ExpBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, m_RectExp.width);

        m_LvText.text = " LV " + m_fLv;
    }

    #endregion

    #region Unity Event Function

    // Start is called before the first frame update
    void Start()
    {
        m_HpCostBar = m_pUIHpBar.transform.Find("HpCostBar").GetComponent<RectTransform>();
        m_MpCostBar = m_pUIMpBar.transform.Find("MpCostBar").GetComponent<RectTransform>();
        m_ExpBar = m_pUIExpBar.GetComponent<RectTransform>();

        m_LvText = m_pUIPlayerStatusList.transform.Find("LV").GetComponent<Text>();

        m_pPlayerInfoScript = m_pPlayerInfo.GetComponent<PlayerInfo>();

        m_RectHpCost = m_HpCostBar.rect;
        m_RectMpCost = m_MpCostBar.rect;
        m_RectExp = m_ExpBar.rect;
    }

    // Update is called once per frame
    void Update()
    {
        F_UIStatusUpdate();
       
        F_UIStatusDisplay();
       
    }

    #endregion
}

