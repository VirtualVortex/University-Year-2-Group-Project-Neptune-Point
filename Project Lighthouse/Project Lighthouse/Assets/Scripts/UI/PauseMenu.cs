using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;

public class PauseMenu : MonoBehaviour {

    public bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    public StudioEventEmitter[] sEEs;
    private void Start()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);

        foreach (StudioEventEmitter sEE in sEEs)
        {
            sEE.Play();
        }
    }
    void Update () {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }else
            {
                Pause();
            }
        }

    }

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        foreach (StudioEventEmitter sEE in sEEs)
        {
            sEE.Play(); 
        }
    }
    public void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        foreach (StudioEventEmitter sEE in sEEs)
        {
            sEE.Stop();
        }
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start Menu");
    }

    public void SettingsMenu()
    {
        Debug.Log("Settings button pressed");
        SceneManager.LoadScene("Settings");
    }

    public void HelpMenu()
    {
        Debug.Log("Help Icon pressed");
        SceneManager.LoadScene("HelpMenu");
    }
        
    public void QuitGame()
    {
        Debug.Log("Quit button pressed.");
     #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
     #else
        Application.Quit();
     #endif
    }
}
