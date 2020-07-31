using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WillOWisp_Interact : MonoBehaviour //We don't want the dialogue system to interfere with Fungus, so I have commented all the message variables out of the code ~NW
{
    //[SerializeField]
    //string message;

    //[SerializeField]
    //GameObject messageUI;


    public GameObject self;
    Animator anim;
    public Light lighting;

    // Start is called before the first frame update
    void Start()
    {
        //messageUI.SetActive(false);

        anim = self.GetComponent<Animator>();
        lighting.color = Color.red;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.name.Contains("Player"))
        {
            //messageUI.SetActive(true);
            //messageUI.GetComponentInChildren<Text>().text = message;
            anim.SetBool("On", true);
            lighting.color = Color.blue;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        //messageUI.SetActive(false);
    }
}
