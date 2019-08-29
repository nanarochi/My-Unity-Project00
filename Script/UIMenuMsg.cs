using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuMsg : MonoBehaviour
{
    [SerializeField]
    public GameObject m_pPauseMenu;

    [SerializeField]
    public GameObject m_pClearMsg;

    [SerializeField]
    public GameObject m_pDiedMsg;

    [SerializeField]
    public GameObject m_pInputScript;

    PlayerKeyController m_pPKCScript;

    public void C_OnClickCloseClear()
    {
        m_pClearMsg.SetActive(false);     
    }

    public void C_OnClickCloseDied()
    {
        m_pDiedMsg.SetActive(false);

    }

    public void C_OnClickCloseMenu()
    {
        Time.timeScale = 1;

        m_pPKCScript.P_IsActivePauseMenu = false;

        m_pPKCScript.P_IsActivePopUp = false;

        m_pPauseMenu.SetActive(m_pPKCScript.P_IsActivePauseMenu);
    }

    public void C_OnClickRetry()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void C_OnClickMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void C_OnClickGameExit()
    {
        Application.Quit();
    }

    public void C_ShowClearMsg()
    {
        Time.timeScale = 0;

        m_pPKCScript.P_IsActivePopUp = true;
        m_pClearMsg.SetActive(m_pPKCScript.P_IsActivePopUp);
    }

    public void C_ShowDiedMsg()
    {
        Time.timeScale = 0;

        m_pPKCScript.P_IsActivePopUp = true;
        m_pDiedMsg.SetActive(m_pPKCScript.P_IsActivePopUp);
    }

    public void C_ShowPauseMsg()
    {
        Time.timeScale = 0;

        m_pPKCScript.P_IsActivePopUp = true;

        m_pPauseMenu.SetActive(m_pPKCScript.P_IsActivePopUp);
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
