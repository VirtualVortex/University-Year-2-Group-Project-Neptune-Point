using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnxiety : MonoBehaviour
{
    [HideInInspector]
    public float anxietyIntensity;
    [SerializeField]
    float delay;
    [SerializeField]
    float speedAmount;

    Rigidbody2D rb;
    bool canRun;
    float timer;
    float anxietyTimer;
    bool inAnxietyArea;
    AnxietyArea aa;
    AnxietyBar canvas;

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time + delay;
        rb = GetComponent<Rigidbody2D>();
        canvas = GameObject.Find("Canvas").GetComponent<AnxietyBar>();
    }

    // Update is called once per frame
    void Update()
    {
        //When the plyer is still the bar will decrease over time
        if (Input.GetAxis("Horizontal") == 0)
        {
            if (Time.time > timer && !inAnxietyArea)
            {
                timer = Time.time + delay;
                canvas.DecreaseSliderLength(anxietyIntensity, speedAmount);
            }

        }
        else
            timer = Time.time + delay;

        //When the plyer is still the bar will increase over time
        if (Time.time > anxietyTimer && inAnxietyArea)
        {
            anxietyTimer = Time.time + delay;
            canvas.IncreaseSliderLength(anxietyIntensity, speedAmount);
        }

        //Call when specifying how farthe anxiety bar should move
        if(aa != null)
            if (aa.forNarrative)
                canvas.NarrativeAnxiety(aa.stopPoint);

        float anxiety = GameObject.Find("Canvas").transform.Find("Slider").GetComponent<Slider>().value;

    }

    //Start anxiety bar and the timer for it when entering a specific area
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name.Contains("Anxiety"))
        {
            aa = collision.GetComponent<AnxietyArea>();
            inAnxietyArea = true;
        }
    }

    //Stop increaseing the anxiety bar when leaving specified area
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.name.Contains("Anxiety"))
        {
            inAnxietyArea = false;
        }
    }
}
