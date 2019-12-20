using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleInfo : MonoBehaviour
{
    public enum E_NINFO
    {
        E_GOLD,
        E_SCORE,
        E_TIME,
        E_TOTEL,
        E_GOLDSCORE,
        E_MONEY,
        E_MAX
    }

    public enum E_BINFO
    {
        E_BUFF,
        E_TRADE,
        E_MAX
    }

    int[] m_nArrInfo = new int[(int)E_NINFO.E_MAX]{0,0,0,0,0,0};
    bool[] m_isArrInfo = new bool[(int)E_BINFO.E_MAX] { false, false };

    public int C_LoadNInfo(E_NINFO eType)
    {
        return m_nArrInfo[(int)eType];
    }
    
    public void C_UpdateNInfo(int nData, E_NINFO eType)
    {
        m_nArrInfo[(int)eType] = nData;
    }
    
    public bool C_LoadBInfo(E_BINFO eType)
    {
        return m_isArrInfo[(int)eType];
    }

    public void C_UpdateBInfo(bool isFlag, E_BINFO eType)
    {
        m_isArrInfo[(int)eType] = isFlag;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }
}
