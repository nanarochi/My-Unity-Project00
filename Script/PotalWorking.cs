using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotalWorking : MonoBehaviour
{
    [SerializeField]
    public GameObject m_pPlayer;

    [SerializeField]
    public GameObject m_pPortalMove01;

    [SerializeField]
    public GameObject m_pPortalMove02;

    [SerializeField]
    public GameObject m_pPortalBossMove01;

    [SerializeField]
    public GameObject m_pPortalBossMove02;

    [SerializeField]
    public GameObject m_pPortalGold01;

    [SerializeField]
    public GameObject m_pPortalGold02;

    [SerializeField]
    public GameObject m_pPortalBack01;

    [SerializeField]
    public GameObject m_pPortalBack02;


    Vector3 m_vTargetPos;

    PortalDetection[] m_pPDScripts;

    GameObject[] m_pPortalChild;

    float m_fPortalOffset;
    int m_nPortalMax;

    enum E_PORTAL
    {
        E_PORTAL01 = 0,
        E_PORTAL02 = 1,
        E_PORTALBOSS01 = 2,
        E_PORTALBOSS02 = 3,
        E_PORTALGOLD01 = 4,
        E_PORTALGOLD02 = 5,
        E_PORTALBACK01 = 6,
        E_PORTALBACK02 = 7,
        E_MAX = 8
    }


    // Start is called before the first frame update
    void Start()
    {
        m_vTargetPos = Vector3.zero;

        m_fPortalOffset = 1.0f;

        m_nPortalMax = 8;

        m_pPortalChild = new GameObject[m_nPortalMax];
        
        m_pPDScripts = new PortalDetection[m_nPortalMax];

        m_pPortalChild[0] = m_pPortalMove01.transform.GetChild(0).gameObject;
        m_pPortalChild[1] = m_pPortalMove02.transform.GetChild(0).gameObject;
        m_pPortalChild[2] = m_pPortalBossMove01.transform.GetChild(0).gameObject;
        m_pPortalChild[3] = m_pPortalBossMove02.transform.GetChild(0).gameObject;
        m_pPortalChild[4] = m_pPortalGold01.transform.GetChild(0).gameObject;
        m_pPortalChild[5] = m_pPortalGold02.transform.GetChild(0).gameObject;
        m_pPortalChild[6] = m_pPortalBack01.transform.GetChild(0).gameObject;
        m_pPortalChild[7] = m_pPortalBack02.transform.GetChild(0).gameObject;

        for (int i = 0; i < m_nPortalMax; i++)
        {
            m_pPDScripts[i] = m_pPortalChild[i].GetComponent<PortalDetection>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        m_vTargetPos = Vector3.zero;


        if (m_pPDScripts[(int)E_PORTAL.E_PORTAL01].C_GetIsCollision())
        {

            m_vTargetPos = m_pPortalChild[(int)E_PORTAL.E_PORTAL02].transform.position + new Vector3(0.0f, m_fPortalOffset, 0.0f);

            m_pPlayer.transform.position = Vector3.zero + m_vTargetPos;

        }

        if (m_pPDScripts[(int)E_PORTAL.E_PORTALBOSS01].C_GetIsCollision())
        {

            m_vTargetPos = m_pPortalChild[(int)E_PORTAL.E_PORTALBOSS02].transform.position + new Vector3(0.0f, m_fPortalOffset, 0.0f);

            m_pPlayer.transform.position = Vector3.zero + m_vTargetPos;


        }

        if (m_pPDScripts[(int)E_PORTAL.E_PORTALGOLD01].C_GetIsCollision())
        {

            m_vTargetPos = m_pPortalChild[(int)E_PORTAL.E_PORTALGOLD02].transform.position + new Vector3(0.0f, m_fPortalOffset, 0.0f);

            m_pPlayer.transform.position = Vector3.zero + m_vTargetPos;

        }

        if (m_pPDScripts[(int)E_PORTAL.E_PORTALBACK01].C_GetIsCollision())
        {

            m_vTargetPos = m_pPortalChild[(int)E_PORTAL.E_PORTALBACK02].transform.position + new Vector3(0.0f, m_fPortalOffset, 0.0f);

            m_pPlayer.transform.position = Vector3.zero + m_vTargetPos;


        }

    }
}
