using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour
{
    PlayerMovementV2 pm;
    Animator anim;
    Rigidbody2D rb;
    RaycastHit2D[] hit = new RaycastHit2D[2];
    float raycastDelay;

    [HideInInspector]
    public bool canClimb;

    // Start is called before the first frame update
    void Start()
    {
        pm = GetComponent<PlayerMovementV2>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        hit[0] = Physics2D.Raycast(transform.position + (transform.up * 0.5f), transform.right);
        hit[1] = Physics2D.Raycast(transform.position + (transform.up * 0.5f), -transform.right);
        //Debug.DrawRay(transform.position, hit[0].point, Color.red);
        //Debug.DrawRay(transform.position, -transform.right, Color.red);

        


        if (canClimb)
        {
            anim.SetFloat("isWalking", Mathf.Abs(pm.y));
            pm.y = Input.GetAxis("Vertical") * pm.speed;
            ChangePlayerSettings();

            /*Debug.DrawRay(hit[0].point, hit[0].normal, Color.red, 5);
            Debug.DrawRay(hit[1].point, hit[1].normal, Color.red, 5);

            Debug.LogError(hit[0].transform.name + " : " + hit[1].transform.name);*/

            //Prevent the player from jumping and changing animations unintensionally
            if (Time.time > raycastDelay)
            {
                anim.SetBool("isClimbing", canClimb);

                if (!pm.inAir)
                {
                    if (!hit[0].transform.name.Contains("Climbable") || !hit[1].transform.name.Contains("Climbable"))
                    {
                        if (hit[0].distance > 0.5f && hit[1].distance > 0.5f)
                        {
                            canClimb = false;
                            anim.SetBool("isClimbing", canClimb);
                            pm.Jump();
                        }
                    }
                }
            }

        }

        //Change to default setting when canClimb is false
        if (!canClimb)
        {
            anim.SetBool("isClimbing", canClimb);
            pm.y = 0;
            rb.gravityScale = 3;
            rb.mass = 3;
            pm.speed = 0.3f;
        }

    }

    void ChangePlayerSettings() 
    {
        rb.mass = 3;
        rb.gravityScale = 0;
        pm.speed = 0.2f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name.Contains("Climbable"))
        {
            canClimb = true;
            raycastDelay = Time.time + 0.25f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.name.Contains("Climbable"))
        {
            canClimb = false;
        }
    }
}
