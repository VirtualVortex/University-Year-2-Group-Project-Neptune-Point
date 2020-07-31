using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareInteractable : MonoBehaviour
{
    Animator anim;

    private void OnTriggerStay2D(Collider2D collision)
    {
        //If collide with player create instance of animator and call coroutine
        if (collision.name.Contains("Player") && Input.GetKeyDown(KeyCode.E))
        {
            anim = GetComponent<Animator>();
            StartCoroutine(SetBool());
        }
    }

    //temperarally set boolean to true for 1 sec
    IEnumerator SetBool()
    {
        anim.SetBool("isScared", true);
        yield return new WaitForSeconds(1);
        anim.SetBool("isScared", false);
    }
}
