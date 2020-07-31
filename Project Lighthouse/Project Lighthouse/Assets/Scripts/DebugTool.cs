using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugTool : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject DebugMenu;

    public static bool noClip;

    Rigidbody2D rb;
    PlayerMovementV2 pm;
    float count;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        pm = player.GetComponent<PlayerMovementV2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            count++;

            if (count == 1)
                DebugMenu.SetActive(true);
            else if (count == 2)
            {
                DebugMenu.SetActive(false);
                count = 0;
            }
        }

        if (noClip)
        {
            rb.gravityScale = 0.0f;
            player.GetComponent<BoxCollider2D>().isTrigger = true;
            pm.y = Input.GetAxis("Vertical") * pm.speed;
            rb.mass = 0;
        }
            
    }

    public void NoClip() 
    {
        if (DebugMenu.GetComponentInChildren<Toggle>().isOn)
        {

            noClip = true;
        }

        if (!DebugMenu.GetComponentInChildren<Toggle>().isOn)
        {
            noClip = false;
            player.GetComponent<BoxCollider2D>().isTrigger = false;
            player.GetComponent<PlayerMovementV2>().y = 0;
            rb.mass = 3;
        }
    }
}
