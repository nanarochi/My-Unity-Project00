using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
   public struct S_PlayerDataStat
    {
       public float Lv;
       public float Hp;
       public float Mp;
       public float Atk;
       public float Def;
       public float Exp;
       public string Name;
    }

    S_PlayerDataStat m_sPlayerDataStat = new S_PlayerDataStat();

    public S_PlayerDataStat C_GetPlayerDataStat()
    {
        return m_sPlayerDataStat;
    }

    public void C_SetPlayerDataStat(S_PlayerDataStat sPlayerData)
    {
        m_sPlayerDataStat = sPlayerData;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_sPlayerDataStat.Hp = 300.0f;
        m_sPlayerDataStat.Lv = 100.0f;
        m_sPlayerDataStat.Mp = 100.0f;
        m_sPlayerDataStat.Name = "Player_1";
        m_sPlayerDataStat.Exp = 300.0f;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

}



