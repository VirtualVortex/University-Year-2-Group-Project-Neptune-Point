using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlsTurning : MonoBehaviour
{
    Animator anim;

    bool turn;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Player"))
        {
            turn = true;
            anim.SetBool("canTurn", turn);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.Contains("Player"))
        {
            turn = false;
            anim.SetBool("canTurn", turn);
        }
    }
}
