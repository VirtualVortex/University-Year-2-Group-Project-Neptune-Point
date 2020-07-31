using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsScript : MonoBehaviour
{
    [Header("Teleport Delay")]
    [SerializeField, Range(0,3), Tooltip("Keep this the same on all stairs")] float delayTimer;
    static bool canTeleport = true;

    [Header("Refs for moving among the Levels")]
    [SerializeField] GameObject up;
    [SerializeField] GameObject down;
    bool canUp;
    bool canDown;

    [Header("Up/Down Arrow Sprites")]
    [SerializeField] SpriteRenderer upArrow;
    [SerializeField] SpriteRenderer downArrow;
    bool active = false;

    [SerializeField]
    Animator anim;


    GameObject player;

    

    void Start()
    {
        canUp = up != null;         // these varaible exist so that this check doesnt need to be made all the time
        canDown = down != null;
        upArrow.gameObject.SetActive(false);
        downArrow.gameObject.SetActive(false);
        player = GameObject.FindWithTag("Player");
    }

    // I believe inputs should be handled in this script rather than the player controller,
    //  to avoid any problems that may occur when teleporting the players around
    void Update()
    {
        if (active && canTeleport)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && canUp)
            {
                anim.Play("IntroFade", 0, 0);
                StartCoroutine(TeleportDelay());
                player.transform.position = up.transform.position;

            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && canDown)
            {
                anim.Play("IntroFade", 0, 0);
                StartCoroutine(TeleportDelay());
                player.transform.position = down.transform.position;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            active = true;
            if (canUp) upArrow.gameObject.SetActive(true);
            if (canDown) downArrow.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            active = false;
            upArrow.gameObject.SetActive(false);
            downArrow.gameObject.SetActive(false);
        }
    }

    IEnumerator TeleportDelay()
    {
        canTeleport = false;
        yield return new WaitForSeconds(delayTimer);
        canTeleport = true;
    }
}
