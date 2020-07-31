using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    bool isCrouched;

    Animator anim;
    PlayerMovementV2 pm;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        pm = GetComponent<PlayerMovementV2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            
            if (!isCrouched)
            {
                anim.SetBool("intoCrawl", true);
                GetComponent<BoxCollider2D>().size = new Vector2(GetComponent<BoxCollider2D>().size.x, GetComponent<BoxCollider2D>().size.y - 0.6f);
                isCrouched = true;
            }
            else if (isCrouched)
            {
                anim.SetBool("intoCrawl", false);
                GetComponent<BoxCollider2D>().size = new Vector2(GetComponent<BoxCollider2D>().size.x, GetComponent<BoxCollider2D>().size.y + 0.6f);
                isCrouched = false;
            }
        }

        if (isCrouched)
            anim.SetFloat("isCrawling", Mathf.Abs(Input.GetAxis("Horizontal")));
    }

    public void CantMove()
    {
        pm.canMove = false;
    }

    public void CanMove() 
    {
        pm.canMove = true;
    }
}
