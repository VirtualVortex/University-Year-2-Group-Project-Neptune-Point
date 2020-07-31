using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnxietyBar : MonoBehaviour
{
    [SerializeField]
    Slider anxietyBar;
    [SerializeField]
    Image[] overlays;

    private float startSpeed;
    Color newColour;
    float speedScale;
    float speedIncreaser = 0.1f;
    PlayerMovementV2 pm;
    Vector3[] startPoss;

    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementV2>();
        startSpeed = pm.speed;

        newColour = overlays[0].color;
        anxietyBar.value = 0;
        speedScale = 1;

        startPoss = new Vector3[overlays.Length];

        for (int i = 0; i < startPoss.Length; i++)
        {
            startPoss[i] = overlays[i].rectTransform.position;
            Debug.Log(startPoss[i]);
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        //IncreaseSliderLength(0.001f);

    }

    //Increase size of anixety bar as well as decrease player speed
    public void IncreaseSliderLength(float length, float speedDecrease) 
    {
        anxietyBar.value = Mathf.Clamp(anxietyBar.value, 0.0f, 1.0f);
        anxietyBar.value += length;

        speedScale -= speedDecrease;
        ChangeSpeed();
        OverlayState();
    }

    //Decrease size of anixety bar as well as increase player speed
    public void DecreaseSliderLength(float length, float speedDecrease)
    {
        anxietyBar.value = Mathf.Clamp(anxietyBar.value, 0.0f, 1.0f);
        anxietyBar.value -= length;

        speedScale += speedDecrease;
        ChangeSpeed();
        OverlayState();
    }

    //Change the scale and alpha of the overlay over time
    void OverlayState() 
    {
        newColour.a = anxietyBar.value;

        overlays[0].rectTransform.position = Vector3.Lerp(startPoss[0], new Vector3(startPoss[0].x - 200, startPoss[0].y, 0), anxietyBar.value);
        overlays[1].rectTransform.position = Vector3.Lerp(startPoss[1], new Vector3(startPoss[1].x + 200, startPoss[1].y, 0), anxietyBar.value);

        foreach (Image overlay in overlays) 
        {
            overlay.color = newColour;
        }
    }

    //Change the player's speed once the anxiety bar is past 0.7
    void ChangeSpeed() 
    {
        float playerSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementV2>().speed;

        if (anxietyBar.value < 0.7f)
            playerSpeed = (startSpeed + 0.07f) * speedScale;

        if (playerSpeed > startSpeed)
            playerSpeed = startSpeed;
        else if (playerSpeed <= 0.0f)
            playerSpeed = 0.1f;

        if (anxietyBar.value >= 0.95f)
            playerSpeed = 0.0f;

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementV2>().speed = playerSpeed;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetFloat("Anxiety", anxietyBar.value);
    }
}
