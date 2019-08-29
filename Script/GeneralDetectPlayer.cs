using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralDetectPlayer : MonoBehaviour
{
    bool m_isCollision;
    bool m_isTrigger;

    // Start is called before the first frame update
    void Start()
    {
        m_isCollision = false;
        m_isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            m_isCollision = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            m_isCollision = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_isTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_isTrigger = false;
        }
    }

    public bool C_GetIsCollision()
    {
        return m_isCollision;
    }

    public bool C_GetIsTrigger()
    {
        return m_isTrigger;
    }
}
