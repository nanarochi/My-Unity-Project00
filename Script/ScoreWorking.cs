using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWorking : MonoBehaviour
{
    [SerializeField]
    public GameObject m_pScore;

    Text m_pText;

    int m_nScore;

    public int P_nScore
    {
        get { return m_nScore; }
        set { m_nScore = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        m_pText = m_pScore.GetComponent<Text>();
        m_nScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        m_pText.text = m_nScore.ToString();
    }
}
