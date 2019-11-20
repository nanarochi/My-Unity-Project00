﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemy : MonoBehaviour
{
    bool m_isCollision;

    // Start is called before the first frame update
    void Start()
    {
        m_isCollision = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Boss")
        {
            m_isCollision = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Boss")
        {
            m_isCollision = false;
        }
    }

    public bool C_GetIsCollision()
    {
        return m_isCollision;
    }
}
