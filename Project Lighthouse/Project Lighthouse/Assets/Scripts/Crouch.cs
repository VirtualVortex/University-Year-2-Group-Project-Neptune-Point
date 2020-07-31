using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    bool isCrouched;

    Animator anim;
    PlayerMovementV2 pm;
    BoxCollider2D boxCol;

    // Start is called before the first frame update
    void Start()
    {
        boxCol = GetComponent<BoxCollider2D>();
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
                //ReduceColliderSize();
                isCrouched = true;
                pm.speed = 0.2f;
                pm.jumpForce = 0;
            }
            else if (isCrouched)
            {
                anim.SetBool("intoCrawl", false);
                isCrouched = false;
                pm.speed = 0.3f;
                pm.jumpForce = 40;
            }
        }

        anim.SetFloat("isCrawling", Mathf.Abs(Input.GetAxis("Horizontal")));

        Debug.Log(isCrouched);
    }

    public void CantMove()
    {
        pm.canMove = false;
    }

    public void CanMove() 
    {
        pm.canMove = true;
    }

    public void ColliderSize()
    {
        Debug.Log("TEST");
        
        if (isCrouched)
        {
            boxCol.size = new Vector2(boxCol.size.x, boxCol.size.y - 0.6f);
        }
        
        if (!isCrouched)
        {
            boxCol.size = new Vector2(boxCol.size.x, boxCol.size.y + 0.6f);
        }

        
    }
}
