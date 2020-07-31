using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_PauseMenu : MonoBehaviour
{
    public GUI_Manager G_Man;


    /* I have been made aware that this is old and redundent, but I will be continuing 
        to work on it as it is very fun to work with, and can help later on *supposedly* */
    void OnGUI()
    {
        if (G_Man.GUI_State == GUI_Manager.e_State.PauseMenu)
        {
            if (GUI.Button(new Rect((Screen.width/2)-125,(Screen.height/2)-150, 250, 100), "Resume")) 
            {
                G_Man.ChangeState(GUI_Manager.e_State.Platforming);
            }
            if (GUI.Button(new Rect((Screen.width/2)-125,(Screen.height/2)+50, 250, 100), "Menu")) 
            {
                G_Man.ChangeState(GUI_Manager.e_State.StartMenu);
            }
        }
    }
}
