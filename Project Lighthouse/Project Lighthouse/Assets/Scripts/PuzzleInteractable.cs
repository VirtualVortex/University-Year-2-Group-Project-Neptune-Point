using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleInteractable : MonoBehaviour
{
    [SerializeField]
    private PuzzleManager puzzlemanager;
    [SerializeField]
    private GameObject interactIcon;
    


    public static float num;

    protected bool inRange;
    private int randomNum;
    private Sprite symbol;
    private int count = 0;
    JournalInteractable JI;

    // Start is called before the first frame update
    void Start()
    {
        RandomNum();
        interactIcon.SetActive(false);

        JI = GetComponent<JournalInteractable>();
        JI.SetSprite(symbol);
    }

    public virtual void Awake()
    {
        
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        //Shows the player the random number
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            if (puzzlemanager != null)
            {
                puzzlemanager.ShowData(symbol);
            }
        }
    }

    //Is in range of interactable
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name.Contains("Player"))
        {
            interactIcon.SetActive(true);
            inRange = true;
        }
        
    }

    //Is out of range of interactable
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name.Contains("Player"))
        {
            interactIcon.SetActive(false);
            inRange = false;
        }
    }

    //Generate random number
    void RandomNum()
    {
        randomNum = Random.Range(0, (puzzlemanager.symbols.Length));
        num = randomNum;
        symbol = puzzlemanager.symbols[randomNum];
        Debug.Log(transform.name + ": " + randomNum);
        puzzlemanager.AddDigit(randomNum);
    }

}
