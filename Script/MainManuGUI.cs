using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManuGUI : MonoBehaviour
{
    float m_fHeightSpace = 10.0f;
    float m_fHeightOffset = 15.0f;

    void OnGUI()
    {
        if(GUI.Button(new Rect(((Screen.width - 100.0f) / 2.0f),((Screen.height - 50.0f) 
            / 2.0f - m_fHeightOffset) , 100.0f, 50.0f), "Game Start"))
        {
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }

        if (GUI.Button(new Rect(((Screen.width - 100.0f) / 2.0f), ((Screen.height - 50.0f) 
            / 2.0f + m_fHeightSpace + 50.0f - m_fHeightOffset), 100.0f, 50.0f), "Exit"))
        {
            Application.Quit();
        }

 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
