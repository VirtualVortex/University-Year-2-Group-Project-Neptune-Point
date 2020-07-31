using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractIcon : MonoBehaviour
{
    [SerializeField]
    GameObject icon;

    // Start is called before the first frame update
    void Start()
    {
        icon.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D col) 
    {
        if(col.transform.tag.Contains("Interactable"))
            icon.SetActive(true);
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.tag.Contains("Interactable"))
            icon.SetActive(false);
    }
}
