using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] journalPages;
    [SerializeField]
    GameObject journalSymbol;
    [SerializeField]
    Transform[] SpawnPoints;

    [Header("Font")]
    [SerializeField]Font font;
    [SerializeField] int fontSize;
    [SerializeField] Color fontColour;

    List<string> jounralText = new List<string>();
    List<Sprite> jounralSprite = new List<Sprite>();
    Queue<Sprite> spriteQueue = new Queue<Sprite>();
    Queue<string> textQueue = new Queue<string>();
    bool canShow = true;
    bool canSpawn;
    float textQueueLength;
    float spriteQueueLength;
    DiarySaveSystem dSS;
    string journalText;

    public static JournalManager instance { get; private set; }

    void Awake() 
    {
        //Ensure that there is only one journalManager object and that it appears in each scene
        /*if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            DestroyImmediate(this.gameObject);*/
    }

    // Start is called before the first frame update
    void Start()
    {
        dSS = GameObject.Find("PSceneMan").GetComponent<DiarySaveSystem>();

        foreach (Sprite sprite in dSS.jounralData.Values)
        {
            spriteQueue.Enqueue(sprite);
        }

        foreach (string text in dSS.jounralData.Keys)
        {
            textQueue.Enqueue(text);
        }

        /*foreach (Sprite symbol in jounralSprite)
            spriteQueue.Enqueue(symbol);*/
    }

    // Update is called once per frame
    void Update()
    {
        textQueueLength = textQueue.Count;
        spriteQueueLength = spriteQueue.Count;

        //Open and close journal when B is pressed
        if (Input.GetKeyDown(KeyCode.B)) 
        {
            if (canShow)
                OpenJournal();
            else if (!canShow)
                CloseJournal();
        }
    }

    public void OpenJournal()
    {
        //Enable all the pages in the journal
        foreach (GameObject page in journalPages)
            page.SetActive(true);

        //show all the text and spawn in all the gameobjects
        if (canShow)
        {
            ShowData();
            canShow = false;
        }
    }

    public void CloseJournal()
    {
        //Remove all the text in the textbox
        //journalPages[0].GetComponentInChildren<Text>().text = "";

        //Unenable each page
        foreach (GameObject page in journalPages)
            page.SetActive(false);

        canShow = true;
    }

    //Add each line of text to the list
    public void AddText(string textData)
    {
        //Queue is used to spawn symbol objects in the journal
        textQueue.Enqueue(textData);

        jounralText.Add(textData);

        textQueueLength = textQueue.Count;
    }

    public void AddSprite(Sprite spriteData)
    {
        //Queue is used to spawn symbol objects in the journal
        spriteQueue.Enqueue(spriteData);

        //The list is used to store all the symbols and sprites through out the game
        jounralSprite.Add(spriteData);

        spriteQueueLength = spriteQueue.Count;
    }

    void ShowData()
    {
        //Debug.Log(spriteQueue.Count);

        //Add text from the list to the text box
        /*foreach (string sentance in jounralText)
        {
            journalPages[0].GetComponentInChildren<Text>().text += sentance + "\n \n";
        }*/

        if (textQueue.Count != null) 
        {
            //Set size of text box and the stateof the text that is shown
            for (int i = 0; i < textQueueLength; i++)
            {
                Debug.Log("Spawn text");
                GameObject text = Instantiate(journalSymbol);
                text.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 100);
                text.AddComponent<Text>();

                text.GetComponent<Text>().verticalOverflow = VerticalWrapMode.Overflow;
                text.GetComponent<Text>().font = font;
                text.GetComponent<Text>().color = fontColour;
                text.GetComponent<Text>().fontSize = fontSize;
                text.GetComponent<Text>().text = textQueue.Dequeue();
                text.transform.SetParent(SpawnPoints[0].transform, false);
            }
        }

        //Until there is nothing in the queue spawn objects in the scroll list
        if (spriteQueue.Count != null)
        {
            for (int i = 0; i < spriteQueueLength; i++)
            {
                GameObject symbol = Instantiate(journalSymbol);
                symbol.AddComponent<Image>();
                symbol.GetComponent<Image>().sprite = spriteQueue.Dequeue();
                symbol.transform.SetParent(SpawnPoints[1].transform, false);
            }
        }
    }
}
