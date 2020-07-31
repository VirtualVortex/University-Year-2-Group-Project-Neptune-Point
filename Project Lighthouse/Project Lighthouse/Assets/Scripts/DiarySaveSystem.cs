using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiarySaveSystem : MonoBehaviour
{
    [HideInInspector]
    public Dictionary<string, Sprite> Dict = new Dictionary<string, Sprite>();
    [HideInInspector]
    public Dictionary<string, string> jounralText = new Dictionary<string, string>();
    [HideInInspector]
    public Dictionary<string, Sprite> jounralSprite = new Dictionary<string, Sprite>();

    [HideInInspector]
    public Dictionary<string, Sprite> jounralData = new Dictionary<string, Sprite>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckDict(string name) 
    {
        if (Dict.Count > 0)
        {
            Debug.Log("Dict count: " + Dict.Count);
            foreach (string key in Dict.Keys)
            {
                if (key == name)
                {
                    Debug.Log("Found key in dict");
                    return true;
                }
            }
        }

        return false;
    }

    public Sprite GetHintSprite(string name)
    {
        foreach (string key in Dict.Keys)
        {
            if (key.Contains(name))
            {
                return Dict[name];
            }
        }

        return null;
    }

    /*public string GetJournalText(string name)
    {
        foreach (string key in jounralText.Keys)
        {
            if (key.Contains(name))
            {
                Debug.Log("Found text key");
                return key;
            }
        }

        return "";
    }

    public Sprite GetJournalSprite(string name)
    {
        foreach (string key in jounralSprite.Keys)
        {
            if (key.Contains(name))
            {
                return jounralSprite[name];
            }
        }

        return null;
    }*/
}
