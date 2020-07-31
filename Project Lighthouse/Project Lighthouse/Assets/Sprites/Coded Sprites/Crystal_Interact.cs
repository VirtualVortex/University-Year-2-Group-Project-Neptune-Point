using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal_Interact : MonoBehaviour
{
    public Sprite off;
    public Sprite on;
    public GameObject self;
    public Light lighting;

    // Start is called before the first frame update
    void Start()
    {
        self.GetComponent<SpriteRenderer>().sprite = off;
        lighting.color = Color.red;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("interacted");
            Interacted();
        }
    }

    void Interacted()
    {
        self.GetComponent<SpriteRenderer>().sprite = on;
        lighting.color = Color.blue;
    }
}
