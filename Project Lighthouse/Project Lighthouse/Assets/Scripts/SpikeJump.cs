using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeJump : MonoBehaviour
{
    [SerializeField]
    float applyForce;

    Rigidbody2D rb;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        /*if (collision.transform.CompareTag("Danger")) 
        {
            rb.AddForce(new Vector2(0, applyForce), ForceMode2D.Impulse);
            //Player animation when hitting the spike
            //Note: when animation will go back to idle when isjumping is false which is in the playermovmentv2 script
        }*/

        if (collision.transform.CompareTag("Player")) 
        {
            collision.transform.GetComponent<Animator>().SetBool("isJumping", true);
            collision.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, applyForce), ForceMode2D.Impulse);
        }
    }
}
