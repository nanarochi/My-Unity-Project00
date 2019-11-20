using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinWorking : MonoBehaviour
{

    [SerializeField]
    public GameObject m_pMultipleNInfo;

    MultipleInfo m_pMNInfoScript;
    
    int m_nGoldAmount;

    // Start is called before the first frame update
    void Start()
    {
        m_pMNInfoScript = m_pMultipleNInfo.GetComponent<MultipleInfo>();

        m_nGoldAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_nGoldAmount = m_pMNInfoScript.P_LoadNInfo(MultipleInfo.E_NINFO.E_GOLD);
            m_nGoldAmount++;
            m_pMNInfoScript.P_UpdateNInfo(m_nGoldAmount, MultipleInfo.E_NINFO.E_GOLD);
            Destroy(gameObject);
        }
    }
}
