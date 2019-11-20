using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingSenseSystem : MonoBehaviour
{
    [SerializeField]
    public GameObject m_pPlayer;


    float m_fYpos;
    float m_fPrevYpos;

    float m_fYposScalar;

    bool m_IsYMove;


    public bool C_GetIsYMove()
    {
        return m_IsYMove;
    }

    public Vector3 C_GetYMoveValue()
    {
        Vector3 tmpVec = new Vector3(0.0f, m_fYposScalar, 0.0f);
        return tmpVec;
    }
    // Start is called before the first frame update
    void Start()
    {
        m_fYpos = m_pPlayer.transform.position.y;
        m_IsYMove = false;
        m_fYposScalar = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        m_fPrevYpos = m_fYpos;

        m_fYpos = m_pPlayer.transform.position.y;

        m_fYposScalar = m_fYpos - m_fPrevYpos;

        
        if(m_fYposScalar > 0.0f || m_fYposScalar < 0.0f)
        {
            m_IsYMove = true;
        }
        else
        {
            m_IsYMove = false;
        }
    }
}
