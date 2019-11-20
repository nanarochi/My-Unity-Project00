using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCal : MonoBehaviour
{
    [SerializeField]
    public GameObject m_pMultipleNInfo;

    [SerializeField]
    public GameObject m_pNumberCounter;

    MultipleInfo m_pMNInfoScript;
    NumCounter m_pCounterScript;

    int m_nInit;
    int m_nValue;
    int m_nResult;

    const int m_nGOLD = 1;

    int m_nGoldScore;


    // Start is called before the first frame update
    void Start()
    {
        m_pMNInfoScript = m_pMultipleNInfo.GetComponent<MultipleInfo>();
        m_pCounterScript = m_pNumberCounter.GetComponent<NumCounter>();

        m_nInit = 0;
        m_nValue = 0;
        m_nResult = 0;
        m_nGoldScore = 0;

    }

    // Update is called once per frame
    void Update()
    {
        m_nInit = 0;
        m_nValue = m_pMNInfoScript.P_LoadNInfo(MultipleInfo.E_NINFO.E_GOLD) * m_nGOLD;

        m_nGoldScore = m_nValue;

        m_pMNInfoScript.P_UpdateNInfo(m_nGoldScore, MultipleInfo.E_NINFO.E_GOLDSCORE);

        m_pCounterScript.C_NumberCount(m_nInit, m_nValue,
            ref m_nResult );

        m_pMNInfoScript.P_UpdateNInfo(m_nResult, MultipleInfo.E_NINFO.E_SCORE);


    }
}
