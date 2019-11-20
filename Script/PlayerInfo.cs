using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInfo : MonoBehaviour
{
    [SerializeField]
    public GameObject m_pPlayerStats;

    PlayerStats m_pPlayerStatsScript;
    
    public float m_fLv { get; set; }
    public float m_fHp { get; set; }
    public float m_fMp { get; set; }
    public float m_fAtk { get; set; }
    public float m_fDef { get; set; }
    public float m_fExp { get; set; }
    public string m_sName { get; set; }

    public float m_fCurLv { get; set; }
    public float m_fCurHp { get; set; }
    public float m_fCurMp { get; set; }
    public float m_fCurAtk { get; set; }
    public float m_fCurDef { get; set; }
    public float m_fCurExp { get; set; }
    public string m_sCurName { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        m_pPlayerStatsScript = m_pPlayerStats.GetComponent<PlayerStats>();

        m_fLv = m_pPlayerStatsScript.C_GetPlayerDataStat().Lv;
        m_fHp = m_pPlayerStatsScript.C_GetPlayerDataStat().Hp;
        m_fMp = m_pPlayerStatsScript.C_GetPlayerDataStat().Mp;
        m_fAtk = m_pPlayerStatsScript.C_GetPlayerDataStat().Atk;
        m_fDef = m_pPlayerStatsScript.C_GetPlayerDataStat().Def;
        m_fExp = m_pPlayerStatsScript.C_GetPlayerDataStat().Exp;
        m_sName = m_pPlayerStatsScript.C_GetPlayerDataStat().Name;

        m_fCurHp = m_fHp;
        m_fCurMp = m_fMp;
        m_fCurAtk = m_fAtk;
        m_fCurDef = m_fDef;
        m_fCurLv = 1.0f;
        m_sCurName = m_sName;
        m_fCurExp = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
