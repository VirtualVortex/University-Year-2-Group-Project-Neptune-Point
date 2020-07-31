using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FailCounter : MonoBehaviour
{
    [SerializeField]
    int maxTries;
    [SerializeField]
    Text counterText;

    float tries;
    PersistantSceneManager PSceneMan;

    // Start is called before the first frame update
    void Start()
    {
        tries = 0;
        PSceneMan = GameObject.FindGameObjectWithTag("Persistant_Scene_Manager").GetComponent<PersistantSceneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tries >= maxTries)
            ChangeScene();
    }

    void ChangeScene() 
    {
        PSceneMan.PuzzleFinish(PersistantSceneManager.puzzleEndState.failed);
    }

    public void IncreaseTries() 
    {
        tries++;
        counterText.text = tries.ToString();
    }
}
