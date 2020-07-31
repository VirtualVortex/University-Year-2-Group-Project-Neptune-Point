using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpMessage : MonoBehaviour
{
    [SerializeField]
    string message;

    [SerializeField]
    GameObject messageUI;

    [SerializeField]
    float lifetime;

    float delay;
    bool runOnce = true;

    // Start is called before the first frame update
    void Start()
    {
        messageUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > delay && !runOnce) 
        {
            Destroy(gameObject);
            messageUI.SetActive(false);
            runOnce = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.transform.name.Contains("Player"))
        {
            messageUI.SetActive(true);
            messageUI.GetComponentInChildren<Text>().text = message;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        delay = Time.time + lifetime;
        runOnce = false;
    }
}
