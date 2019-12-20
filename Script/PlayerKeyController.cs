using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerKeyController : MonoBehaviour
{
    /// <summary>
    /// Variables in Inspector;
    /// </summary>

    #region Public Variables

    [SerializeField]
    [Tooltip("Proper Player Prefab")]
    public GameObject m_pPlayer;

    [SerializeField]
    [Tooltip("Proper Player Inventory Controller Prefab")]
    public GameObject m_pUIInven;

    [SerializeField]
    [Range(0.001f, 0.01f)]
    [Tooltip("Min 0.001f Max 0.01f")]
    public float m_fMoveSpeed;

    [SerializeField]
    [Range(0.0f, 0.1f)]
    [Tooltip("Min 0.0f Max 1.0f")]
    public float m_fRotateSpeed;

    [SerializeField]
    public GameObject m_pAnimManager;

    [SerializeField]
    public GameObject m_pUIMenu;

    [SerializeField]
    public GameObject m_pUICharactor;

    [SerializeField]
    public GameObject m_pNPCShopAI;

    [SerializeField]
    public GameObject m_pNPCShopEvent;

    #endregion


    /// <summary>
    /// Class Members in PlayerKeyController Script
    /// </summary>


    #region Class Field

    AnimatorManager m_pAnimScript;
    UIMenuMsg m_pUIMenuScript;
    UIInvenWork m_pUIInvenWorkScript;
    UICharactor m_pUICharScript;
    ShopAI m_pShopAIScript;
    ShopEvent m_pShopEventScript;


    float m_fTime;
    float m_fHandleCoord;

    bool m_isMove;

    public bool P_IsPlayerMove
    {
        get { return m_isMove; }

    }

    bool m_isZMove;
    bool m_isXMove;

    bool m_isAttack;
    bool m_isRotate;

    //bool m_isGameExit;
    bool m_isAniMotion;
    bool m_isRunAction;
    bool m_isModRunSpeed;
    bool m_isActiveInven;
    bool m_isActivePauseMenu;
    bool m_isInvenPopUp;
    bool m_isGamePopUp;
    bool m_isActiveCharactor;
    bool m_isCharactorPopUp;


    public bool P_IsActiveInven
    {
        get { return m_isActiveInven; }
        set { m_isActiveInven = value; }
    }

    public bool P_IsActivePauseMenu
    {
        get { return m_isActivePauseMenu; }
        set { m_isActivePauseMenu = value; }

    }

    public bool P_IsActiveCharactor
    {
        get { return m_isActiveCharactor; }
        set { m_isActiveCharactor = value; }
    }

    public bool P_IsActiveInvenPopUp
    {
        get { return m_isInvenPopUp; }
        set { m_isInvenPopUp = value; }
    }

    public bool P_IsActivePopUp
    {
        get { return m_isGamePopUp; }
        set { m_isGamePopUp = value; }
    }

    public bool P_IsActiveCharactorPopUp
    {
        get { return m_isCharactorPopUp; }
        set { m_isCharactorPopUp = value; }
    }

    Vector3 m_vDir;

    float m_fZTranslate;
    float m_fXTranslate;

    float m_fYRotate;

    int m_nClikCount;

    #endregion

    #region Class Method
    
    public bool C_GetIsRotate()
    {
        return m_isRotate;
    }

    public float C_GetfYRotate()
    {
        return m_fYRotate;
    }

    public Vector3 C_GetVec3Translate()
    {
        return m_vDir;
    }
    void F_CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            m_isMove = true;
            m_isZMove = true;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            m_isZMove = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            m_isMove = true;
            m_isZMove = true;

        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            m_isZMove = false;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            m_isMove = true;
            m_isXMove = true;

        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            m_isXMove = false;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            m_isMove = true;
            m_isXMove = true;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            m_isXMove = false;
        }

        if( !m_isZMove && !m_isXMove)
        {
            m_isMove = false;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            m_isActivePauseMenu = !m_isActivePauseMenu;

        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(m_pShopAIScript.P_IsTrigger)
            {
                m_pShopEventScript.P_IsPressSpace = true;
            }
            else
            {
                m_pShopEventScript.P_IsPressSpace = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            m_isRunAction = !m_isRunAction;

            if(m_isModRunSpeed)
            {
                m_fMoveSpeed = 20.0f;
            }
        }

        if(Input.GetKeyDown(KeyCode.I))
        {
            m_isActiveInven = !m_isActiveInven;
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            m_isActiveCharactor = !m_isActiveCharactor;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (!m_pAnimScript[m_pAnimScript.P_nPlayer].GetCurrentAnimatorStateInfo
                (m_pAnimScript[m_pAnimScript.P_nPlayer].GetLayerIndex("Base Layer")).IsName("MK_attackWhirl"))
            {
                m_isAttack = true;
                m_nClikCount++;
            }
            else
            {
                m_isAttack = false;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            m_isAttack = false;
            m_nClikCount = 0;
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (!m_pAnimScript[m_pAnimScript.P_nPlayer].GetCurrentAnimatorStateInfo
                (m_pAnimScript[m_pAnimScript.P_nPlayer].GetLayerIndex("Base Layer")).IsName("MK_attackWhirl"))
            {
                m_isRotate = true;
            }
            else
            {
                m_isRotate = false;
            }
        
        }
        else if(Input.GetMouseButtonUp(1))
        {
            m_isRotate = false;
        }


    }
    
    void F_CheckMotion()
    {
        if (m_pAnimScript[m_pAnimScript.P_nPlayer].GetCurrentAnimatorStateInfo
            (m_pAnimScript[m_pAnimScript.P_nPlayer].GetLayerIndex("Base Layer")).IsName("MK_attackWhirl"))
        {
            m_isRotate = false;
            m_fYRotate *= 0.0f;

        }
    }

    void F_Action()
    {
        if (m_isGamePopUp || m_isInvenPopUp || m_isCharactorPopUp)
        {

        }
        else
         {
            if (m_isRotate )
            {
                if (!m_isMove && !m_isAttack && !m_pAnimScript[m_pAnimScript.P_nPlayer].GetCurrentAnimatorStateInfo
                    (m_pAnimScript[m_pAnimScript.P_nPlayer].GetLayerIndex("Base Layer")).IsName("MK_attackWhirl"))
                {
                    m_fYRotate = Input.GetAxisRaw("Mouse X");

                    m_fYRotate *= m_fTime * m_fRotateSpeed;

                }

                if (m_pAnimScript[m_pAnimScript.P_nPlayer].GetCurrentAnimatorStateInfo
                    (m_pAnimScript[m_pAnimScript.P_nPlayer].GetLayerIndex("Base Layer")).IsName("MK_attackWhirl"))
                {
                    m_fYRotate *= 0.0f;

                }
                m_pPlayer.transform.Rotate(Vector3.up, m_fYRotate, Space.Self);
                m_isMove = false;
                m_isAttack = false;
            }


            if (m_isMove)
            {
                if (!m_isRotate)
                {
                    m_fZTranslate = Input.GetAxisRaw("Vertical");
                    m_fXTranslate = Input.GetAxisRaw("Horizontal");

                    if (m_pAnimScript[m_pAnimScript.P_nPlayer].GetCurrentAnimatorStateInfo
                        (m_pAnimScript[m_pAnimScript.P_nPlayer].GetLayerIndex("Base Layer")).IsName("MK_attackWhirl"))
                    {
                        m_isAniMotion = false;


                        m_fXTranslate *= 0.0f;
                        m_fZTranslate *= 0.0f;

                    }
                    else
                    {
                        m_isAniMotion = true;

                        m_fXTranslate *= m_fTime * m_fMoveSpeed;
                        m_fZTranslate *= m_fTime * m_fMoveSpeed;

                    }

                    m_vDir = new Vector3(m_fXTranslate, 0.0f, m_fZTranslate);

                }

                if (m_isZMove)
                {
                    m_pPlayer.transform.Translate(Vector3.forward * m_fZTranslate * m_fHandleCoord);
                }
                if (m_isXMove)
                {
                    m_pPlayer.transform.Translate(Vector3.right * m_fXTranslate * m_fHandleCoord);
                }
            }
            else
            {
                m_isAniMotion = false;
            }

            if (m_isAniMotion)
            {
                if (m_isRunAction)
                {
                    m_pAnimScript[m_pAnimScript.P_nPlayer].SetBool("IsRun", true);
                    m_fMoveSpeed = 40.0f;
                    m_isModRunSpeed = true;
                }
                else
                {
                    m_pAnimScript[m_pAnimScript.P_nPlayer].SetBool("IsWalk", true);
                    m_isModRunSpeed = false;
                }
            }
            else
            {
                m_pAnimScript[m_pAnimScript.P_nPlayer].SetBool("IsRun", false);
                m_pAnimScript[m_pAnimScript.P_nPlayer].SetBool("IsWalk", false);
            }


            if (m_isAttack )
            {
                if (m_nClikCount > 0 && m_nClikCount < 2)
                {
                    m_pAnimScript[m_pAnimScript.P_nPlayer].SetBool("IsAttack", true);
                }
                else
                {
                    m_pAnimScript[m_pAnimScript.P_nPlayer].SetBool("IsAttack", false);
                    m_nClikCount = 0;
                }

            }
            else
            {
                m_pAnimScript[m_pAnimScript.P_nPlayer].SetBool("IsAttack", false);
            }
        }

        if (m_isActiveInven)
        {
            m_pUIInvenWorkScript.C_ShowInven();
        }
        else
        {
            m_pUIInvenWorkScript.C_OnClickCloseInven();
        }
        if(m_isActiveCharactor)
        {
            m_pUICharScript.C_ShowCharactor();
        }
        else
        {
            m_pUICharScript.C_OnClickCloseCharactor();
        }
        if (m_isActivePauseMenu)
        {
            m_pUIMenuScript.C_ShowPauseMsg();
        }
        else
        {
            m_pUIMenuScript.C_OnClickCloseMenu();
        }

    }



    #endregion




    /// <summary>
    ///  Unity Event Functions
    /// </summary>

    #region Unity Event Function

    // Start is called before the first frame update
    void Start()
    {

        m_pAnimScript = m_pAnimManager.GetComponent<AnimatorManager>();
        m_pUIMenuScript = m_pUIMenu.GetComponent<UIMenuMsg>();
        m_pUIInvenWorkScript = m_pUIInven.GetComponent<UIInvenWork>();
        m_pUICharScript = m_pUICharactor.GetComponent<UICharactor>();
        m_pShopAIScript = m_pNPCShopAI.GetComponent<ShopAI>();
        m_pShopEventScript = m_pNPCShopEvent.GetComponent<ShopEvent>();

        m_fYRotate = 0.0f;
        m_fXTranslate = 0.0f;
        m_fZTranslate = 0.0f;
        m_fMoveSpeed = 20.0f;
        m_fRotateSpeed = 100.0f;
        m_fTime = Time.deltaTime;
        m_isRunAction = false;
        m_isModRunSpeed = false;
        m_isActiveInven = false;
        m_isActivePauseMenu = false;
        m_isActiveCharactor = false;
        m_isCharactorPopUp = false;
        m_isInvenPopUp = false;
        m_isGamePopUp = false;
        m_isMove = false;
        m_isRotate = false;
        m_isZMove = false;
        m_isXMove = false;

        m_vDir = Vector3.zero;
        m_fHandleCoord = -1.0f;
        m_nClikCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        F_CheckInput();

        F_CheckMotion();

        F_Action();

    }

    void LateUpdate()
    {

    }

  
    #endregion


}
