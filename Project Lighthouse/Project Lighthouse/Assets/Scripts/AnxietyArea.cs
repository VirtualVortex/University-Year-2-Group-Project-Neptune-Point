using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnxietyArea : MonoBehaviour
{
    [SerializeField]
    float anxietyIntensity;

    [Header("For Narrative")]
    public bool forNarrative;
    public float stopPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name.Contains("Player"))
        {
            collision.GetComponent<PlayerAnxiety>().anxietyIntensity = anxietyIntensity; //Had too high a level of protection to be used, when being imported as a package. 
        }
    }
}
