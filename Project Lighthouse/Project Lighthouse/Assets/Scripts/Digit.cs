using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Digit : MonoBehaviour
{
    public float possibleDigit = 0;

    Text t;

    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Increase()
    {
        if(possibleDigit >= 10)
            possibleDigit = -1;

        possibleDigit++;
        t.text = possibleDigit.ToString();
    }

    public void Decrease()
    {
        if(possibleDigit <= 0)
            possibleDigit = 11;

        possibleDigit--;
        t.text = possibleDigit.ToString();
    }
}
