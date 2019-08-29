using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinWorking : MonoBehaviour
{
    [SerializeField]
    public GameObject m_pScore;

    ScoreWorking m_pSWScript;

    // Start is called before the first frame update
    void Start()
    {
        m_pSWScript = m_pScore.GetComponent<ScoreWorking>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_pSWScript.P_nScore += 1;
            Destroy(gameObject);
        }
    }
}
