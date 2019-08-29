using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInvenWork : MonoBehaviour
{

    [SerializeField]
    [Tooltip("Proper Player Inventory Prefab")]
    public GameObject m_pInven;

    [SerializeField]
    public GameObject m_pInputScript;

    PlayerKeyController m_pPKCScript;

    public void C_ShowInven()
    {
        Time.timeScale = 0;

        m_pPKCScript.P_IsActiveInven = true;

        m_pPKCScript.P_IsActiveInvenPopUp = true;

        m_pInven.SetActive(m_pPKCScript.P_IsActiveInven);
    }

    public void C_OnClickCloseInven()
    {
        Time.timeScale = 1;

        m_pPKCScript.P_IsActiveInven = false;

        m_pPKCScript.P_IsActiveInvenPopUp = false;

        m_pInven.SetActive(m_pPKCScript.P_IsActiveInven);
    }

    // Start is called before the first frame update
    void Start()
    {
        m_pPKCScript = m_pInputScript.GetComponent<PlayerKeyController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
