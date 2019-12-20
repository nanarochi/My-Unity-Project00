using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinWorking : MonoBehaviour
{

    [SerializeField]
    public GameObject m_pMultipleNInfo;

    MultipleInfo m_pMNInfoScript;
    
    int m_nGoldAmount;
    const int MONEYSCALAR = 50;

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
            int nMoney = 0;

            m_nGoldAmount = m_pMNInfoScript.C_LoadNInfo(MultipleInfo.E_NINFO.E_GOLD);
            m_nGoldAmount++;
            m_pMNInfoScript.C_UpdateNInfo(m_nGoldAmount, MultipleInfo.E_NINFO.E_GOLD);
            nMoney = m_pMNInfoScript.C_LoadNInfo(MultipleInfo.E_NINFO.E_MONEY);
            nMoney += MONEYSCALAR;
            m_pMNInfoScript.C_UpdateNInfo(nMoney, MultipleInfo.E_NINFO.E_MONEY);

            Destroy(gameObject);
        }
    }
}
