using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetManager : MonoBehaviour
{
    [SerializeField]
    public GameObject[] m_pGameObjs;

    int m_nMax;

    public void C_RunDestroyAll()
    {
        for(int i = 0; i < m_nMax; i++)
        {
            Destroy(m_pGameObjs[i]);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        m_nMax = 7;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
