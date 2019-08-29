using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    public GameObject m_pTime;

    Text m_pText;

    int m_nMin;
    int m_nSecond0;
    int m_nSecond1;

    float m_fSecond;
    float m_fSecond00;
    float m_fSecond01;

    string m_strNum;
    string m_strSec;

    // Start is called before the first frame update
    void Start()
    {
        m_pText = m_pTime.GetComponent<Text>();

        m_nMin = 0;
        m_fSecond = 0.0f;
        m_fSecond00 = 0.0f;
        m_fSecond01 = 0.0f;
        m_nSecond0 = 0;
        m_nSecond1 = 0;
        m_pText.text = "0 : 00";

    }

    // Update is called once per frame
    void Update()
    {
        if(m_fSecond < 60.0f)
        {
            if (m_fSecond01 < 9.9f)
            {
                m_fSecond01 += Time.deltaTime;
            }
            else
            {
                m_fSecond01 = 0.0f;
                m_fSecond00 += 1.0f;
            }

            m_fSecond = 10.0f * m_fSecond00 + m_fSecond01;
        }
        else
        {
            m_fSecond = 0.0f;
            m_fSecond00 = 0.0f;
            m_nMin++;
        }


        m_nSecond0 = Mathf.FloorToInt(m_fSecond00);
        m_nSecond1 = Mathf.FloorToInt(m_fSecond01);

        m_strNum = m_nMin.ToString() + " : " + m_nSecond0.ToString() + m_nSecond1.ToString();
        
        m_pText.text = m_strNum;
    }
}
