using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    [SerializeField]
    public GameObject m_pPlayer;

    [SerializeField]
    public GameObject m_pBoss;

    enum E_OBJ
    {
        E_PLAYER,
        E_BOSS,
        E_MAX
    }

    int m_nMax;

    Animator[] m_pArrAnim;

    int m_nPlayer;
    int m_nBoss;

    public int P_nPlayer
    {
        get { return m_nPlayer; }
    }

    public int P_nBoss
    {
        get { return m_nBoss; }
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

        m_pArrAnim = new Animator[m_nMax];

        m_pArrAnim[m_nPlayer] = m_pPlayer.transform.Find("MK_BaseChrt").GetComponent<Animator>();
        m_pArrAnim[m_nBoss] = m_pBoss.transform.Find("TrollGiant").GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
