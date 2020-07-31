using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary> A class that will persist between scene changes, store and manage information that needs to move between scenes </summary>
public class PersistantSceneManager : MonoBehaviour
{
    public enum puzzleEndState // state of how you ended the puzzle
    {
        unattempted,
        passed,
        failed,
        concede
    }

    public enum puzzleReturnPosition // so the player knows where to re appear when moving between scenes
    {
        mostRecentPosition,
        level1start,
        level2start,
        level3start
    }
    public puzzleReturnPosition whereToStart = puzzleReturnPosition.level1start;
    public void updateStartArea(puzzleReturnPosition startType) {whereToStart = startType;}

    public static PersistantSceneManager Instance { get; private set; }

    // variables we want to move around are public , or have getters or sumn
    
    // dictionary for all the puzzle status' ... could change to int if there are multiple levels of completion or somthing?
    // dictionary (currently) will only contain values of the passed levels;
    // if a value for a puzzle cannot be found, assume unattempted
    public Dictionary<string, puzzleEndState> dict = new Dictionary<string, puzzleEndState>(); 

    /// this will also hold the player position when moving back from scenes
    public Vector3 playerReturnPosition;
    [Tooltip("Player Starting position on Map 1")]
    public Vector3 level1Position;
    [Tooltip("Player Starting position on Map 2")]
    public Vector3 level2Position;
    [Tooltip("Player Starting position on Map 3")]
    public Vector3 level3Position;

    // the most recent checkpoint the player has activated
    Vector2 checkpointPos;

    string currentPuzzleName;
    string destinationSceneName;
    string previousSceneName;

    /// <summary> On awake, do all that is needed to make sure there is only the one scene manager at a time, forever </summary>
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(this.gameObject);
        }
    }

    void Start()
    {

    }
    /// <summary> Function to be called when Completeing, Failing, or Leaving a puzzle </summary>
    /// <param name = "puzzleName"> The name of the puzzles corrosponding animal </param>
    /// <param name = "completetion"> The status of the puzzle upon finish, uses ENUM </param>
    public void PuzzleFinish(puzzleEndState completetion)
    {
        if (dict.ContainsKey(currentPuzzleName)) // if key exists, make sure to not change it from passed to something else.
        {
            if (!(dict[currentPuzzleName] == puzzleEndState.passed)) // if the puzzle wasnt previously passed
            {
                dict[currentPuzzleName] = completetion;
            }
        }
        else
        {
            dict[currentPuzzleName] = completetion; // create Dict value and assign it a value according to how it was completed.
        }

        // after updating the dictionary, wait a lil bit then go back to the level
        whereToStart = puzzleReturnPosition.mostRecentPosition;
        StartCoroutine(waitBeforeReturn());
    }

    /// <summary> Function for the player(controller) to call, to save its position and to change to a puzzle </summary>
    /// <param name = "sceneName"> scene that you are moving to </param>
    /// <param name = "position"> position of playerm so they can be repositioned once leaving the puzzle</param>
    /// <param name = "puzzleName"> name of the NPC of the puzzle you are entering </param>
    public void PlayerChangeScene(string sceneName, Vector3 position, string puzzleName)
    {
        Scene scene = SceneManager.GetActiveScene();
        previousSceneName = scene.name;
        playerReturnPosition = position;
        currentPuzzleName = puzzleName;
        ChangeScene(sceneName);
    }


    /// <summary> Scene changing function only to be called within the scene </summary>
    private void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


    IEnumerator waitBeforeReturn()
    {
        yield return new WaitForSeconds(2);
        ChangeScene(previousSceneName);
    }

    // Because of fungus needing a function without params to call, the next two functions will be hopefully used to accomodate this

    // This function is to be called upon clicking on the NPC to interract, pretty much before the Fungus text appears. 
    // (the fungus text box could almost be called from here, but that sounds awkward... just call to different functions)
    public void OnPlayerInterract(string sceneName, Vector3 position, string puzzleName)
    {
        previousSceneName = SceneManager.GetActiveScene().name;
        playerReturnPosition = position; // the position the player is at when interacting with the NPC
        destinationSceneName = sceneName; // this is used for navigating to the correct scene, so has to be the long awkward scene name
        currentPuzzleName = puzzleName; // this is used for the dictionary. !!!! must  be the NPC's name !!!!

    }

    // this function will be the one called by Fungus
    public void FungusChangeScene()
    {
        ChangeScene(destinationSceneName);
    }

    public void SetCheckpoint(Vector2 pos)
    {
        checkpointPos = pos;
    }

    public Vector2 GetCheckpoint()
    {
        return checkpointPos;
    }
}
