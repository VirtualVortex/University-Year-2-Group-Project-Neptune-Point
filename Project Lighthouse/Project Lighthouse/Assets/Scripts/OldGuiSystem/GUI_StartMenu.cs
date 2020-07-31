using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_StartMenu : GUI_Manager
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        if (GUI_State == (int)e_State.StartMenu)
        {
            if (GUI.Button(new Rect(0, 0, 250, 250), "Play")) 
            {
                ChangeState(e_State.Platforming);
                Debug.Log("AAAAAAAAAAAAA");
            }
        }
    }
}
