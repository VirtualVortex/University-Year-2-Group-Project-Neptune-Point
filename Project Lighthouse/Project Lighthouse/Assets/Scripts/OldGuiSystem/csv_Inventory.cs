using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class csv_Inventory : MonoBehaviour
{
    private const int numOfItems = 20;
    private const int itemDetail = 4;

    private string dataPath;

    string[,] inventoryBook =  new string[numOfItems,itemDetail];  // [number of different items ,  number of details on each item]

    int[,] playerInventory =  new int[numOfItems,2];   // X = item ID in your inventory, Y = the quantity of said item

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numOfItems; i++)    // fill player inventory with "empty"
        {   playerInventory[i,0] = -1;
            playerInventory[i,1] = -1;  }


        dataPath = Application.dataPath;
        string file = "Scripts/InventoryBook.csv";
        string fullPath = Path.Combine(dataPath, file);

        try{
            using (StreamReader sr = new StreamReader(fullPath))
            {
                string line = sr.ReadLine();    // initalises the variable, and also gets rid off the first line in the csv file.
                line = sr.ReadLine();           // read the first (important) line
                int x = 0;                      // line number, corrosponds to items ID number

                do{
                    string[] splitLine = line.Split(',');           // split the single string into array of strings
                    for(int i = 0; i < itemDetail; i++)             // put the array of string into a bigger array of strings
                    {
                        inventoryBook[x,i] = splitLine[i];     
                    }
                    x++;

                    line = sr.ReadLine();
                }while(line != null);                               // while there are still inventory things to sort
            }
        }
        catch(FileNotFoundException e)                                          // file dont exist
        {   Debug.Log("Awh heck, file not found");
            Debug.Log(e.Message);
        }
        catch(DirectoryNotFoundException e)                                     // folder dont exist
        {   Debug.Log("Awh heck, directory not found");
            Debug.Log(e.Message);
        }
        catch(IOException e)                                                    // ur an absolute buffoon
        {   Debug.Log("Awh heck, IO exception, is the file still open?");
            Debug.Log(e.Message);
        }
        

    }

    public string[] getItemDetails(int itemID)
    {
        string[] returnString = new string[itemDetail];

        for (int i = 0; i < itemDetail; i++)
        {
            returnString[i] = inventoryBook[itemID,i];
        }

        return returnString;
    }

    public int[,] getInventory() { return playerInventory; } // return the player inventory in its entirety ( its just ID and quantity)

    public void addItemToInv(int itemID)
    {
        bool pass = false;
        int iter = 0;
        while (!pass && iter < numOfItems)
        {
            if (playerInventory[iter,0] == -1) // if [iter] item slot is empty:
            {
                playerInventory[iter,0] = itemID; // set item to key,
                playerInventory[iter,1] = 1; // set item quantity to 1;
                pass = true;
            }
            else if (playerInventory[iter,0] == itemID) // if [iter] item slot is the same as the:
            {
                playerInventory[iter,1]++; // increase number of keys
                pass = true;
            }
            iter++;
        }
    }

    public bool takeItemFromInv(int itemID)
    {
        int iter = 0;
        while (iter < numOfItems)
        {
            if (playerInventory[iter,0] == itemID) // if [iter] item slot is the item youre looking for:
            {
                if (playerInventory[iter,1] >= 1)
                {
                    playerInventory[iter,1]--;  // increase number of keys
                    return true;                // returns true after item is used
                }                
            }
            iter++;
        }

        return false;       // returns false after item can't be found, hopefully
    }
}
