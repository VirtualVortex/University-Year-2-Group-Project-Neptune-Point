using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnxietyArea : MonoBehaviour
{
    [SerializeField]
    float anxietyIntensity;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name.Contains("Player"))
        {
            collision.GetComponent<PlayerAnxiety>().anxietyIntensity = anxietyIntensity;
        }
    }
}
