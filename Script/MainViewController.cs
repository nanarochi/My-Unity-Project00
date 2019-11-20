using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainViewController : MonoBehaviour
{
    /// <summary>
    /// Variables in Inspector;
    /// </summary>
   

    #region Public Variables

    [SerializeField]
    [Tooltip("Proper Player Prefab")]
    public GameObject m_pPlayer;

    [SerializeField]
    [Tooltip("Proper Camera Prefab")]
    public GameObject m_pCamera;

    [SerializeField]
    [Tooltip("Proper Camera Init Position Data Prefab")]
    public GameObject m_pCameraInitPos;

    #endregion


    /// <summary>
    /// Class Members in PlayerKeyController Script
    /// </summary>


    #region Class Field 

    Vector3 m_vInitPos;
    Vector3 m_vLookAtPos;
    Vector3 m_vDir;
    Vector3 m_vNowDir;
    Vector3 m_vMoveDir;
    Vector3 m_vMoveNowDir;
    Vector3 m_vMoveFixedDir;
    Vector3 m_vMovePointDir;

    PlayerKeyController m_pPlayerInputScript;
    PlayerMovingSenseSystem m_pPMSSScript;

    float m_fDistance;
    float m_fNowDistance;
    float m_fFixedDistance;
    float m_fMoveFixedDistance;
    float m_fMoveDistance;

    #endregion


    #region Class Method


    void F_CalculateDirAndDistance()
    {
        m_vMoveNowDir = new Vector3(m_pPlayer.transform.position.x, m_pCamera.transform.position.y + m_pPMSSScript.C_GetYMoveValue().y
            , m_pPlayer.transform.position.z);

        m_vMovePointDir = m_vMoveNowDir - m_pCamera.transform.position;
        m_fNowDistance = m_vMovePointDir.magnitude;

        m_vNowDir = m_vMoveNowDir - m_vMoveDir;

        m_fMoveFixedDistance = m_fNowDistance - m_fDistance;
        m_fMoveDistance = m_vNowDir.magnitude;

        m_vNowDir.Normalize();
    }

    void F_CheckAndRotateCamera()
    {
        if (m_pPlayerInputScript.C_GetIsRotate())
        {
    
            if (!m_pPlayerInputScript.P_IsPlayerMove)
            {
                m_pCamera.transform.RotateAround(m_pPlayer.transform.position, Vector3.up, m_pPlayerInputScript.C_GetfYRotate());
            }
    
        }
    }

    void F_MoveCamera()
    {
        if (m_fMoveFixedDistance != 0.0f)
        {

            m_pCamera.transform.position += m_fMoveDistance * m_vNowDir;

        }

        m_vMoveDir = m_vMoveNowDir;
    }

    #endregion

    /// <summary>
    ///  Unity Event Functions
    /// </summary>

    #region Unity Event Function

    // Start is called before the first frame update
    void Start()
    {
        m_vInitPos = m_pCameraInitPos.transform.position;

        m_pCamera.transform.position = Vector3.zero + m_pPlayer.transform.position + m_vInitPos;
        
        m_pPlayerInputScript = GameObject.Find("GameController").transform.Find("PlayerController")
            .Find("Input").gameObject.GetComponent<PlayerKeyController>();

        m_pPMSSScript = m_pPlayer.transform.Find("PlayerMovingSense").gameObject.GetComponent<PlayerMovingSenseSystem>();

        m_vMoveDir = new Vector3(m_pPlayer.transform.position.x, m_pCamera.transform.position.y, m_pPlayer.transform.position.z);

        m_vDir = m_pCamera.transform.position - m_vMoveDir;

        m_vMoveFixedDir = m_vMoveDir - m_pCamera.transform.position;

        m_fFixedDistance = m_vMoveFixedDir.magnitude;

        m_fDistance = m_fFixedDistance;

    }

    // Update is called once per frame
    void Update()
    {
 
    }
    void LateUpdate()
    {

        F_CalculateDirAndDistance();
       
        F_CheckAndRotateCamera();

        F_MoveCamera();

        
    }

    #endregion

}
