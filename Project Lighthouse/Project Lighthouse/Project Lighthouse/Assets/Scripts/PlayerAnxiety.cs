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

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time + delay;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //When the plyer is still the bar will decrease over time
        if(Input.GetAxis("Horizontal") == 0)
        {
            if(Time.time > timer && !inAnxietyArea)
            {
                timer = Time.time + delay;
                GameObject.Find("Canvas").GetComponent<AnxietyBar>().DecreaseSliderLength(anxietyIntensity, speedAmount);
            }
                
        }
        else
            timer = Time.time + delay;

        //When the plyer is still the bar will increase over time
        if (Time.time > anxietyTimer && inAnxietyArea)
        {
            anxietyTimer = Time.time + delay;
            GameObject.Find("Canvas").GetComponent<AnxietyBar>().IncreaseSliderLength(anxietyIntensity, speedAmount);
        }

        float anxiety = GameObject.Find("Canvas").transform.Find("Slider").GetComponent<Slider>().value;

        if (anxiety >= 1.0)
        {
            GetComponent<PositionTracker>().GetAnxietyPosition();
        }
        
    }

    //Start anxiety bar and the timer for it when entering a specific area
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name.Contains("Anxiety"))
        {
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
