using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RightWrong : MonoBehaviour
{
    [SerializeField]
    private GameObject Answer;
    [SerializeField]
    private FailCounter fc;

    PersistantSceneManager PSceneMan;

    void Start()
    {
        PSceneMan = GameObject.FindWithTag("Persistant_Scene_Manager").GetComponent<PersistantSceneManager>();
    }

    public void RightButton()
    {
        Answer.SetActive(true);
        Answer.GetComponent<Text>().text = "Correct";

        PSceneMan.PuzzleFinish(PersistantSceneManager.puzzleEndState.passed);
        
        //SceneManager.LoadScene("Level 1.2");
    }

    public void WrongButton()
    {
        Answer.SetActive(true);
        Answer.GetComponent<Text>().text = "Wrong";
        fc.IncreaseTries();
    }
}
