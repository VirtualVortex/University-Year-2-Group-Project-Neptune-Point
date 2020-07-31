using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_Platforming : GUI_Manager
{
    public csv_Inventory G_Inv;

    private bool invOpen = false; // is the inventory open?

    public enum itemType {   ID, Name, Lore, PicLocation     }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(Screen.width-100,0,100,50), "YEET");
        bool pasta = GUI_State == e_State.Platforming ? true : false;
        Debug.Log(pasta);
        Debug.Log(GUI_State);
        if (pasta){    
            if (invOpen == false)
            {
                if (GUI.Button(new Rect((Screen.width - 150)/2, (Screen.height - 30), 150, 30), "Open Inventory")) 
                {
                    invOpen = true;
                }
            }
            if (invOpen == true)
            {
                int[,] playerInventory = G_Inv.getInventory();

                if (GUI.Button(new Rect((Screen.width - 150)/2, (Screen.height - 90), 150, 30), "Close Inventory"))
                {
                    invOpen = false;
                }

                // TEST BUTTONS
                if (GUI.Button(new Rect(0, 0, 150, 75), "Add Key (TEST)")) // adds a key to the inventory
                {
                    bool pass = false;
                    int iter = 0;
                    while (!pass && iter < playerInventory.GetLength(0))
                    {
                        if (playerInventory[iter,0] == -1) // if [iter] item slot is empty:
                        {
                            playerInventory[iter,0] = 0; // set item to key,
                            playerInventory[iter,1] = 1; // set item quantity to 1;
                            pass = true;
                            Debug.Log("KEY CREATED");
                        }
                        else if (playerInventory[iter,0] == 0) // if [iter] item slot is another key:
                        {
                            playerInventory[iter,1]++; // increase number of keys
                            pass = true;
                            Debug.Log("KEY ADDED");
                        }
                        iter++;
                    }
                }
                if (GUI.Button(new Rect(160, 0, 150, 75), "Add Key Shard (TEST)")) // adds a keyshard to the inventory
                {
                    bool pass = false;
                    int iter = 0;
                    while (!pass && iter < playerInventory.GetLength(0))
                    {
                        if (playerInventory[iter,0] == -1) // if [iter] item slot is empty:
                        {
                            playerInventory[iter,0] = 1; // set item to keyshard,
                            playerInventory[iter,1] = 1; // set item quantity to 1;
                            pass = true;
                            Debug.Log("KEYSHARD CREATED");
                        }
                        else if (playerInventory[iter,0] == 1) // if [iter] item slot is another keyshard:
                        {
                            playerInventory[iter,1]++; // increase number of keyshards
                            pass = true;
                            Debug.Log("KEYSHARD ADDED");
                        }
                        iter++;
                    }
                }


                // outlining inventory box
                GUI.Box(new Rect(20, (Screen.height - 60), Screen.width - 40, 60), "");

                int tallyInvItems = 0;
                for (int i = 0; i < playerInventory.GetLength(0); i++)
                {
                    if(playerInventory[i,0] != -1)
                    {
                        string textForBox = G_Inv.getItemDetails(i)[(int)itemType.Name]; 
                        GUI.Box(new Rect(30 + (tallyInvItems * 80), (Screen.height - 50), 70, 40), textForBox);
                        
                        string numForBox = playerInventory[i,1].ToString();
                        GUI.Box(new Rect(75 + (tallyInvItems * 80), (Screen.height - 30), 25, 20), numForBox);

                        
                        tallyInvItems++;

                        
                    }
                }
            }
        }
    }
}
