using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangingPoint : MonoBehaviour
{
    
    Rigidbody2D rb;
    Rigidbody2D pointRB;
    PlayerMovementV2 pm;
    Animator anim;
    Transform point;
    bool runOnce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pm = GetComponent<PlayerMovementV2>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        
        

        if (collision.transform.name.Contains("HangePoint") && !runOnce)
        {
            Debug.Log("Found point");

            pointRB = collision.gameObject.GetComponent<Rigidbody2D>();
            point = collision.transform;

            StartCoroutine(TightRopeEvent());
            runOnce = true;
        }
    }

    IEnumerator TightRopeEvent()
    {
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("fallOff", true);
        pm.canMove = false;
        
        yield return new WaitForSeconds(2);
        anim.SetBool("fallOff", false);
    }

    void FallOff()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - 1);
        pointRB.bodyType = RigidbodyType2D.Static;
        rb.bodyType = RigidbodyType2D.Static;
    }

    void Recover()
    {
        transform.position = new Vector2(point.position.x, point.position.y + 1);
        pm.canMove = true;
        pointRB.bodyType = RigidbodyType2D.Dynamic;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
    
}
