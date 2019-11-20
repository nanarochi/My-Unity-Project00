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
        E_MAX
    }

    int[] nArrInfo = new int[(int)E_NINFO.E_MAX]{0,0,0,0,0};

    public int P_LoadNInfo(E_NINFO eType)
    {
        return nArrInfo[(int)eType];
    }
    
    public void P_UpdateNInfo(int nData, E_NINFO eType)
    {
        nArrInfo[(int)eType] = nData;
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
