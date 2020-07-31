using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float distanceOnLeft;
    [SerializeField]
    private float distanceOnRight;

    private Rigidbody2D rb;
    private float x;
    private float y = 0;
    private Vector2 left;
    private Vector2 right;
    public bool inAir;

    RaycastHit2D[] hit = new RaycastHit2D[2];
    Animator ani;

    public bool canMove = true;
    public bool canClimb;

    public static float rotationSpeed;

    PersistantSceneManager PSceneMan;

    // Start is called before the first frame update

    /*void Awake()
    {
        PSceneMan = GameObject.FindWithTag("Persistant_Scene_Manager").GetComponent<PersistantSceneManager>();
    }*/

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        // talk to the P.SceneMan to find out where to start
        PersistantSceneManager.puzzleReturnPosition returnType =  PSceneMan.whereToStart;
        // i know this is horrifically ugly, but its better than if statememts... need a way to find
        switch (returnType)
        {
            case PersistantSceneManager.puzzleReturnPosition.level1start:
                transform.position = PSceneMan.level1Position;
                break;
            case PersistantSceneManager.puzzleReturnPosition.level2start:
                transform.position = PSceneMan.level1Position;
                break;
            case PersistantSceneManager.puzzleReturnPosition.level3start:
                transform.position = PSceneMan.level1Position;
                break;
            case PersistantSceneManager.puzzleReturnPosition.mostRecentPosition:
                transform.position = PSceneMan.level1Position;                
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Setting positions for the two raycasts
        left = new Vector2((transform.position.x + distanceOnLeft), transform.position.y);
        right = new Vector2(transform.position.x - distanceOnRight, transform.position.y);
        
        //Creating the raycasts
        hit[0] = Physics2D.Raycast(left, Vector2.down);
        hit[1] = Physics2D.Raycast(right, Vector2.down);

        //If either of the raycast's hit distance is less than 0.65 then the character can still jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        else
           ani.SetBool("isJumping", false);
        
        rotationSpeed = rb.velocity.x;

        /*Debug.DrawRay(left, Vector2.down);
        Debug.DrawRay(right, Vector2.down);
        Debug.Log(left + " + " + hit[0].distance);
        Debug.Log(right + " + " + hit[1].distance);*/
    }

    private void FixedUpdate()
    {
        //Gravity is applied when both of the raycasts are greater than 1
        if (canMove)
        {
            if (hit[0].distance > 1f && hit[1].distance > 1f)
            {
                y = -1;
                inAir = true;
            }
            else 
                inAir = false;
        }

        //When the player is climbing gravity is reduced
        if (canClimb)
        {
            y = Input.GetAxis("Vertical") * speed;

            if (Input.GetAxis("Vertical") == 0)
                rb.gravityScale = 0.0f;
            else
                rb.gravityScale = 1.5f;
        }
        else
            rb.gravityScale = 1.5f;

        if (canMove) 
        {
            //Allowing the player to move left and right
            x = (Input.GetAxis("Horizontal") + 0.1f) * speed;
            rb.velocity += new Vector2(x, y) * speed;
            ani.SetFloat("isWalking", Mathf.Abs(x));

            //change horizontal axis of sprite
            if (x > 0)
                GetComponent<SpriteRenderer>().flipX = false;
            else if (x < 0)
                GetComponent<SpriteRenderer>().flipX = true;
        }

    }

    public void Jump()
    {
        if (hit[0].distance <= 0.83f || hit[1].distance <= 0.83f)
        {
            ani.SetBool("isJumping", true);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        else if (canClimb)
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
}
