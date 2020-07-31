using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSymbol : MonoBehaviour
{

    public float code;

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

    int codeChosen;

    // Start is called before the first frame update
    void Start()
    {
        spawnCode();
    }

    // Update is called once per frame
    void spawnCode()
    {
        codeChosen = Random.Range(0, 9);
        Debug.Log(codeChosen);

        switch (codeChosen)
        {
            case 0:
                GetComponent<SpriteRenderer>().sprite = zero;
                code = 0;
                break;
            case 1:
                GetComponent<SpriteRenderer>().sprite = one;
                code = 1;
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = two;
                code = 2;
                break;
            case 3:
                GetComponent<SpriteRenderer>().sprite = three;
                code = 3;
                break;
            case 4:
                GetComponent<SpriteRenderer>().sprite = four;
                code = 4;
                break;
            case 5:
                GetComponent<SpriteRenderer>().sprite = five;
                code = 5;
                break;
            case 6:
                GetComponent<SpriteRenderer>().sprite = six;
                code = 6;
                break;
            case 7:
                GetComponent<SpriteRenderer>().sprite = seven;
                code = 7;
                break;
            case 8:
                GetComponent<SpriteRenderer>().sprite = eight;
                code = 8;
                break;
            case 9:
                GetComponent<SpriteRenderer>().sprite = nine;
                code = 9;
                break;
        }
    }
}
