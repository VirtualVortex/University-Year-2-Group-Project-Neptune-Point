using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour
{
    private PlayerMovementV2 pm;

    // Start is called before the first frame update
    void Start()
    {
        pm = GetComponent<PlayerMovementV2>();
    }
    
    //Makes changes to the player object so the player can move up or down
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name.Contains("Climbable"))
        {
            transform.parent = collision.transform;
            //pm.canMove = false;
            pm.canClimb = true;
        }
    }

    //Applies gravity to the player when leaving the starirs object
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.name.Contains("Climbable"))
        {
            transform.parent = null;
            //pm.canMove = true;
            pm.canClimb = false;
        }
    }
}
