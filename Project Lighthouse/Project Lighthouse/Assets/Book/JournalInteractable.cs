using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalInteractable : MonoBehaviour
{
    public GameObject page;
    [SerializeField]
    int pageNum;
    [SerializeField]
    JournalManagerV2 journalManager;
    
    public void SetSprite(Sprite symbol)
    {
        if (transform.GetComponentInChildren<Image>())
            transform.GetComponentInChildren<Image>().sprite = symbol;

        if (transform.GetComponentInChildren<Image>())
            Debug.Log("Has image component");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.Contains("Player"))
            journalManager.AddContent(pageNum, page);
    }
}
