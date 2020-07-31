using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_Manager : MonoBehaviour
{
    public enum e_State
    {
        StartMenu,
        PauseMenu,
        Platforming
    }
    public e_State GUI_State;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeState(e_State state)
    {
        GUI_State = state;
        Debug.Log(GUI_State);
    }
}
