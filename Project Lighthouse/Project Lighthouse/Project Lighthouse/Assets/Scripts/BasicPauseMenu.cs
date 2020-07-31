using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicPauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !Chest.isOpen)
        {
            pauseMenu.SetActive(true);
        }

    }

    public void MainMenu() 
    {
        SceneManager.LoadScene("Start Menu");
    }

    public void Resume() 
    {
        pauseMenu.SetActive(false);
    }
}
