using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffWorking : MonoBehaviour
{
    [SerializeField]
    public GameObject m_pKillBuff;

    [SerializeField]
    public GameObject m_pImgKillBuff;

    BuffDetection m_pBDScript;

    bool m_isRunning;

    public bool C_GetBuffHave()
    {
        return m_isRunning;
    }
    // Start is called before the first frame update
    void Start()
    {
        m_pBDScript = m_pKillBuff.transform.GetChild(0).GetComponent<BuffDetection>();

        m_isRunning = false;


    }

    // Update is called once per frame
    void Update()
    {
        if(m_pBDScript.C_GetIsCollision())
        {
            m_pImgKillBuff.SetActive(true);
            m_pKillBuff.SetActive(false);
            m_isRunning = true;
        }
    }
}
