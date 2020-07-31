using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementV2 : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    [SerializeField]
    private float distanceOnLeft;
    [SerializeField]
    private float distanceOnRight;

    private Rigidbody2D rb;
    private float x;

    [HideInInspector]
    public float y = 0;

    private Vector2 left;
    private Vector2 right;
    private float drag;
    public bool inAir;
    
    RaycastHit2D[] hit = new RaycastHit2D[2];
    Animator ani;
    Climbing climb;

    public bool canMove = true;
    public bool canClimb;

    public static float rotationSpeed;

    PersistantSceneManager PSceneMan;
    JournalManagerV2 jm;

    // Start is called before the first frame update

    void Awake()
    {
        PSceneMan = GameObject.FindWithTag("Persistant_Scene_Manager").GetComponent<PersistantSceneManager>();
        climb = GetComponent<Climbing>();
        jm = GameObject.Find("Canvas").GetComponent<JournalManagerV2>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        drag = rb.drag;
        // talk to the P.SceneMan to find out where to start
        PersistantSceneManager.puzzleReturnPosition returnType = PSceneMan.whereToStart;
        PSceneMan.SetCheckpoint(transform.position);



        // i know this is horrifically ugly, but its better than if statememts... need a way to find
        switch (returnType)
        {
            case PersistantSceneManager.puzzleReturnPosition.level1start:
                transform.position = PSceneMan.level1Position;
                break;
            case PersistantSceneManager.puzzleReturnPosition.level2start:
                transform.position = PSceneMan.level2Position;
                break;
            case PersistantSceneManager.puzzleReturnPosition.level3start:
                transform.position = PSceneMan.level3Position;
                break;
            case PersistantSceneManager.puzzleReturnPosition.mostRecentPosition:
                transform.position = PSceneMan.playerReturnPosition;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!jm.canShow)
            canMove = false;

        //Setting positions for the two raycasts
        left = new Vector2((transform.position.x + distanceOnLeft), transform.position.y);
        right = new Vector2(transform.position.x - distanceOnRight, transform.position.y);

        //Creating the raycasts
        hit[0] = Physics2D.Raycast(left, Vector2.down);
        hit[1] = Physics2D.Raycast(right, Vector2.down);

        //If either of the raycast's hit distance is less than 0.65 then the character can still jump
        if (!DebugTool.noClip)
        {
            if (hit[0].distance <= 0.83f || hit[1].distance <= 0.83f)
            {
                if (hit[0].transform.tag.Contains("Ground") || hit[1].transform.tag.Contains("Ground"))
                {
                    rb.drag = drag;
                    rb.gravityScale = 2f;
                    inAir = false;

                    ani.SetBool("isJumping", false);

                    if (Input.GetKeyDown(KeyCode.Space) && canMove)
                    {
                        Jump();
                        Debug.Log("Jump");
                    }
                }
            }
            else
            {
                rb.drag = drag * 0.15f;
                rb.gravityScale += 0.05f;
                ani.SetBool("isJumping", false);
                inAir = true;
            }
        }

        rotationSpeed = rb.velocity.x;

        //Debug.DrawRay(left, Vector2.down);
        //Debug.DrawRay(right, Vector2.down);
        //Debug.Log(left + " + " + hit[0].distance);
        //Debug.Log(right + " + " + hit[1].distance);

       
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            //Allowing the player to move left and right
            x = (Input.GetAxis("Horizontal")) * speed;
            transform.position += new Vector3(x,y,0) * speed;
            ani.SetFloat("isWalking", Mathf.Abs(x));

            //change horizontal axis of sprite
            if (!climb.canClimb)
            {
                if (x > 0)
                    GetComponent<SpriteRenderer>().flipX = false;
                else if (x < 0)
                    GetComponent<SpriteRenderer>().flipX = true;
            }

            //Apply gravity
            /*if (hit[0].distance > 4.6f && hit[1].distance > 4.6f)
            {
                rb.drag = drag * 0.15f;
                
                inAir = true;
            }
            else
            {
                inAir = false;
                rb.drag = drag;
                
            }*/
        }

        
    }

    public void Jump()
    {

        ani.SetBool("isJumping", true);
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        
    }

    void OnTriggerEnter2D(Collider2D col) 
    {
        if (!col.CompareTag("Stairs"))
            PSceneMan.OnPlayerInterract(col.transform.name, transform.position, col.transform.name);
    }

    public void doRespawn()
    {
        StartCoroutine("Respawn");
    }

    IEnumerator Respawn()
    {
        canMove = false;
        yield return new WaitForSeconds(1);
        transform.position = PSceneMan.GetCheckpoint();
        yield return new WaitForSeconds(1);
        canMove = true;
    }
}
