using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;


public class Win_Check : MonoBehaviour
{

    Planet_Script[] planets;
    PersistantSceneManager PScene_Man;
    public static float winDirection;
    [SerializeField, Range(0.05f,0.3f)] float win_Precision = 0.1f;
    bool checkWinStart = false;
    [SerializeField] Text winText;

    void Awake()
    {
        winDirection = Random.Range(0, 181);
    }

    void Start()
    {
        planets = FindObjectsOfType<Planet_Script>();
        PScene_Man = FindObjectOfType<PersistantSceneManager>();
        StartCoroutine(waitBeforeCheck());
    }

    void Update()
    {
        if (checkWinStart)
        {
            planets = planets.OrderBy(c => c.sumAngles).ToArray();
            if (Mathf.Abs(planets[0].sumAngles - planets[planets.Length-1].sumAngles) <= win_Precision)
            {
                Debug.Log("Done Owl Win");
                try
                {
                    StartCoroutine(waitBeforeLeave());
                }
                catch
                {
                    Debug.LogError("NO PSCENE MAN!!!");
                }
            }
        }
    }

    IEnumerator waitBeforeCheck()
    {
        yield return new WaitForSeconds(2);
        checkWinStart = true;
    }

    IEnumerator waitBeforeLeave()
    {
        winText.GetComponent<Text>().enabled = true;
        checkWinStart = false;
        yield return new WaitForSeconds(2);
        PScene_Man.PuzzleFinish(PersistantSceneManager.puzzleEndState.passed);
    }
}
