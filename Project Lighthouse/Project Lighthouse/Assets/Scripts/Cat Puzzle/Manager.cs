using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Transform restartPoint;

    private Vector2 startPos;

    PersistantSceneManager PSceneMan;

    // Start is called before the first frame update
    void Start()
    {
        PSceneMan = GameObject.FindWithTag("Persistant_Scene_Manager").GetComponent<PersistantSceneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            StartPuzzle();
        }
    }

    public void StartPuzzle()
    {
        player.transform.position = restartPoint.position;
    }

    public void EndPuzzle(string scene)
    {
        GameObject Manager =  GameObject.FindWithTag("Persistant_Scene_Manager");
        // Name of puzzle is stored in P.SceneMan now
        PSceneMan.PuzzleFinish(PersistantSceneManager.puzzleEndState.passed);
        //SceneManager.LoadScene(scene);
    }

}
