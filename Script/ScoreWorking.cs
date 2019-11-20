using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWorking : MonoBehaviour
{
    [SerializeField]
    public GameObject m_pScore;

    [SerializeField]
    public GameObject m_pMultipleNInfo;


    MultipleInfo m_pMNInfoScript;

    Text m_pText;

    int m_nScore;


    // Start is called before the first frame update
    void Start()
    {
        m_pText = m_pScore.GetComponent<Text>();
        m_pMNInfoScript = m_pMultipleNInfo.GetComponent<MultipleInfo>();
        m_nScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        m_nScore = m_pMNInfoScript.P_LoadNInfo(MultipleInfo.E_NINFO.E_SCORE);
        m_pText.text = m_nScore.ToString();
    }
}
