using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CrouchV2 : MonoBehaviour
{
    bool isCrouched;

    Animator anim;
    PlayerMovementV2 playMov;
    BoxCollider2D boxCol;

    public CinemachineVirtualCamera cam;

    public static float t = 2.0f;
    public float zoomedIn = 3.0f;
    public float zoomedOut = 6.0f;
    private float zoomAmount = 0.0f;

    void Start()
    {
        boxCol = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        playMov = GetComponent<PlayerMovementV2>();
        zoomAmount = cam.m_Lens.OrthographicSize;
    }

    void Update()
    {

        if (cam.m_Lens.OrthographicSize != zoomAmount)
        {
            cam.m_Lens.OrthographicSize = Mathf.Lerp(cam.m_Lens.OrthographicSize, zoomAmount, Time.deltaTime * t);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name.Contains("Crouchable"))
        {
            transform.parent = collision.transform;
            
            zoomAmount = zoomedIn;
            //cam.m_Lens.OrthographicSize -= 3.0f;
            

            if (!isCrouched)
            {
                anim.SetBool("intoCrawl", true);
                //ReduceColliderSize();
                isCrouched = true;
                playMov.speed = 0.2f;
                playMov.jumpForce = 0;

            }

            anim.SetFloat("isCrawling", Mathf.Abs(Input.GetAxis("Horizontal")));

            Debug.Log(isCrouched);

 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.name.Contains("Crouchable"))
        {
            transform.parent = null;
            anim.SetBool("intoCrawl", false);
            isCrouched = false;
            playMov.speed = 0.3f;
            playMov.jumpForce = 40;

            zoomAmount = zoomedOut;
        }
    }


    public void CantMove()
    {
        playMov.canMove = false;
    }

    public void CanMove()
    {
        playMov.canMove = true;
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
