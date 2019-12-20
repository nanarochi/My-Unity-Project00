using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    [SerializeField]
    public GameObject m_pPlayer;

    [SerializeField]
    public GameObject m_pBoss;

    [SerializeField]
    public GameObject m_pEnemyA;

    [SerializeField]
    public GameObject m_pEnemyB;

    [SerializeField]
    public GameObject m_pChief;

    enum E_OBJ
    {
        E_PLAYER,
        E_BOSS,
        E_ENEMYA,
        E_ENEMYB,
        E_CHIEF,
        E_MAX
    }

    int m_nMax;

    Animator[] m_pArrAnim;

    int m_nPlayer;
    int m_nBoss;
    int m_nEnemyA;
    int m_nEnemyB;
    int m_nChief;

    public int P_nPlayer
    {
        get { return m_nPlayer; }
    }

    public int P_nBoss
    {
        get { return m_nBoss; }
    }

    public int P_nEnemyA
    {
        get { return m_nEnemyA; }
    }

    public int P_nEnemyB
    {
        get { return m_nEnemyB; }
    }

    public int P_nChief
    {
        get { return m_nChief; }
    }

    public Animator this[int i]
    {
        get { return m_pArrAnim[i]; }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_nMax = (int)E_OBJ.E_MAX;
        m_nPlayer = (int)E_OBJ.E_PLAYER;
        m_nBoss = (int)E_OBJ.E_BOSS;
        m_nEnemyA = (int)E_OBJ.E_ENEMYA;
        m_nEnemyB = (int)E_OBJ.E_ENEMYB;
        m_nChief = (int)E_OBJ.E_CHIEF;

        m_pArrAnim = new Animator[m_nMax];

        m_pArrAnim[m_nPlayer] = m_pPlayer.transform.Find("MK_BaseChrt").GetComponent<Animator>();
        m_pArrAnim[m_nBoss] = m_pBoss.transform.Find("TrollGiant").GetComponent<Animator>();
        m_pArrAnim[m_nEnemyA] = m_pEnemyA.GetComponent<Animator>();
        m_pArrAnim[m_nEnemyB] = m_pEnemyB.GetComponent<Animator>();
        m_pArrAnim[m_nChief] = m_pChief.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
