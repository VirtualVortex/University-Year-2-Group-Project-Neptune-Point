using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class JournalManagerV2 : MonoBehaviour
{
    [SerializeField]
    GameObject JournalUI;
    [SerializeField]
    GameObject pageHolder;

    Dictionary<float, Page> content = new Dictionary<float, Page>();
    List<int> pageNums = new List<int>();
    Queue<Page> contentQueue = new Queue<Page>();
    int idNum = 0;
    int pageNum = 1;
    bool journalOpen;

    [HideInInspector]
    public bool canShow = true;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //Open and close journal when B is pressed
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (canShow)
                OpenJournal();
            else if (!canShow)
                CloseJournal();
        }

        //when you reach either end go to the opposite end
        if (pageNum > content.Count)
        {
            pageNum = 1;
        }
        if (pageNum < 1)
        {
            if (content.Count % 2 == 0)
                pageNum = content.Count - 1;

            if (content.Count % 2 == 1)
                pageNum = content.Count;
        }
        

        //Move to different pages
        if (Input.GetKeyDown(KeyCode.A))
        {
            pageNum -= 2;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            pageNum += 2;
        }

        EnablePage();

    }

    //Add content to the journal
    public void AddContent(int pageNum,GameObject _obj)
    {
        Page tempPage = new Page(pageNum, _obj);

        //Check if content isn't already in the dictonary
        if (!content.ContainsValue(tempPage))
        {
            idNum++;
            Page page = new Page(pageNum, _obj);
            content.Add(idNum, page);
            contentQueue.Enqueue(page);

            //Create an object of the content and add it to the book
            GameObject inst = Instantiate(_obj, SetPagePos(pageNum), Quaternion.identity);
            inst.SetActive(false);
            inst.transform.SetParent(pageHolder.transform);
        }
    }

    //Start at the first page
    public void OpenJournal()
    {
        pageNum = 1;

        //show all the text and spawn in all the gameobjects
        if (canShow)
        {
            JournalUI.SetActive(true);
            canShow = false;
        }
    }

    public void CloseJournal()
    {
        JournalUI.SetActive(false);
        canShow = true;
    }

    void EnablePage()
    {
        //only enable content on the realive page
        if (content.Count != 0)
        {
            foreach (KeyValuePair<float, Page> c in content)
            {
                foreach (Transform child in pageHolder.transform)
                {
                    if (!canShow)
                    {
                        if (child.name.Contains(pageNum.ToString()))
                            child.gameObject.SetActive(true);

                        if (!child.name.Contains(pageNum.ToString()))
                        {
                            child.gameObject.SetActive(false);

                            if (child.name.Contains((pageNum + 1).ToString()))
                                child.gameObject.SetActive(true);
                        }
                    }
                    else
                        child.gameObject.SetActive(false);


                }
            }
        }
    }

    //Set the page object pos based on if the page num is odd or even
    Vector2 SetPagePos(int pageNum)
    {
        if (pageNum % 2 == 0)
            return pageHolder.transform.position + (Vector3.right * 200);

        if (pageNum % 2 == 1)
            return pageHolder.transform.position - (Vector3.right * 200);

        return pageHolder.transform.position;
    }
}
