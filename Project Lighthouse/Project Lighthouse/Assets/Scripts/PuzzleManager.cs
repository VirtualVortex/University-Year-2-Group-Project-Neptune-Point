using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject puzzleUI;
    [SerializeField]
    private Digit[] digit = new Digit[4];
    [SerializeField]
    private Chest chest;
    [SerializeField]
    private Image dispalySymbol;

    public Sprite[] symbols;
    
    private List<float> combination = new List<float>();
    private List<float> randomCombination = new List<float>();
    private Sprite randomImg;
    private float count;
    bool checkingCombination;
    

    // Start is called before the first frame update
    void Start()
    {
        puzzleUI.SetActive(false);
        for(int i = 0; i < 4; i++)
        {
            randomCombination.Add(PuzzleInteractable.num);
        }

        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (checkingCombination) 
        {
            for (int i = 0; i < 4; i++)
            {
                if (combination[i] == digit[i].possibleDigit)
                {
                    Debug.Log(digit[i].possibleDigit);
                    count++;
                }
            }

            if (count == 4)
            {
                Debug.Log("Combination works");
                checkingCombination = false;
                chest.closeUI();
                chest.GetComponent<SpriteRenderer>().color = Color.green;
            }
            else
                checkingCombination = false;
        }
    }

    //Add random num to combination list
    public void AddDigit(float digit)
    {
        if(combination.Count < 4)
        {
            combination.Add(digit);
        }
    }

    //Show number when called
    public void ShowData(Sprite symbol)
    {
        randomImg = symbol;
        StartCoroutine("PuzzleMenu");
    }

    //Check if each digit returns true
    public void CheckCombination()
    {
        checkingCombination = true;
    }

    //Shows random num for one sec on player canvas
    private IEnumerator PuzzleMenu()
    {
        puzzleUI.SetActive(true);
        dispalySymbol.sprite = randomImg;
        yield return new WaitForSeconds(1);
        puzzleUI.SetActive(false);
    }
}
