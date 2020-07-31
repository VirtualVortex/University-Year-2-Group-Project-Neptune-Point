using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : PuzzleInteractable
{
    [SerializeField]
    private GameObject lockUI;

    public static bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        lockUI.SetActive(false);
    }

    public override void Awake() 
    { 
    }

    // Update is called once per frame
    public override void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            lockUI.SetActive(true);
            isOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            closeUI();
            GameObject.Find("Canvas").GetComponentInChildren<BasicPauseMenu>().Resume();
            isOpen = false;
        }
            
    }
 
    public void closeUI()
    {
        lockUI.SetActive(false);
    }
    
}
