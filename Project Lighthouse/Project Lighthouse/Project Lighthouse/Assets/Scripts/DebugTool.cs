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
    float count;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
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
            
    }

    public void NoClip() 
    {
        if (DebugMenu.GetComponentInChildren<Toggle>().isOn)
        {
            rb.gravityScale = 0.0f;
            noClip = true;
            player.GetComponent<BoxCollider2D>().isTrigger = true;
            player.GetComponent<PlayerMovementV2>().canClimb = true;
        }

        if (!DebugMenu.GetComponentInChildren<Toggle>().isOn)
        {
            noClip = false;
            player.GetComponent<BoxCollider2D>().isTrigger = false;
            player.GetComponent<PlayerMovementV2>().canClimb = false;
        }
    }
}
