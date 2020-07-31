using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeInput : MonoBehaviour
{

    public float number;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Symbol Spawn").GetComponent<RandomSymbol>().code = number;
        spawnCode();
    }

    public Sprite zero;
    public Sprite one;
    public Sprite two;
    public Sprite three;
    public Sprite four;
    public Sprite five;
    public Sprite six;
    public Sprite seven;
    public Sprite eight;
    public Sprite nine;

    // Update is called once per frame
    void spawnCode()
    {
        if (number == 0)
        {
            GetComponent<SpriteRenderer>().sprite = zero;
        }
        if (number == 1)
        {
            GetComponent<SpriteRenderer>().sprite = one;
        }
        if (number == 2)
        {
            GetComponent<SpriteRenderer>().sprite = two;
        }
        if (number == 3)
        {
            GetComponent<SpriteRenderer>().sprite = three;
        }
        if (number == 4)
        {
            GetComponent<SpriteRenderer>().sprite = four;
        }
        if (number == 5)
        {
            GetComponent<SpriteRenderer>().sprite = five;
        }
        if (number == 6)
        {
            GetComponent<SpriteRenderer>().sprite = six;
        }
        if (number == 7)
        {
            GetComponent<SpriteRenderer>().sprite = seven;
        }
        if (number == 8)
        {
            GetComponent<SpriteRenderer>().sprite = eight;
        }
        if (number == 9)
        {
            GetComponent<SpriteRenderer>().sprite = nine;
        }

    }

}
