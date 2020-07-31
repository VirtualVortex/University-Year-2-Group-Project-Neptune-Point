using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour {// Retreveid from last year's GAM130 project ~NW

    public GameObject mainMenuObject;

    /*[Header("For quit animation")] No need for animations at this point. This has been left in due possible animations later in this project ~NW
    [SerializeField]
    private bool forAnimation;
    public Animator ani;
    [SerializeField]
    private Image sr;
    [SerializeField]
    private Sprite sprite;
    private bool quitting;*/

    PersistantSceneManager PSceneMan;

    private void Start()
    {
        mainMenuObject.SetActive(true);
        //////////////////////////////////////////////////PSceneMan = GameObject.FindWithTag("Persistant_Scene_Manager").GetComponent<PermanentSceneManager>();
        //quitting = false;
    }

    public void ToggleMenuPanels()
    {
        mainMenuObject.SetActive(!mainMenuObject.activeSelf);
    }

    public void StartButton()
    {
        SceneManager.LoadScene("Game Intro");
    }
    
    public void HelpButton()
    {
        Debug.Log("Help button pressed.");
        SceneManager.LoadScene("Help-Menu");
    }

    public void SettingsButton()
    {
        Debug.Log("Settings button pressed.");
        SceneManager.LoadScene("Settings");
    }
    
    /*public void PressedQuitButton()
    {
        //Debug.Log("Quit button pressed.");

        if (forAnimation)
        {
            //UnityEditor.EditorApplication.isPlaying = false;
            sr.sprite = sprite;
            quitting = true;
            ani.SetBool("Quitting", quitting);
            Debug.Log("Quit button pressed.");
        }

    }*/

    public void QuitGame()
    {
        Debug.Log("Quitting. If you are in the editor, nothing will happen!");
        Application.Quit();
    }

    public void MenuButton()// I added this function so that I could use the same script on my game over menu and call the Main Menu ~NW
    {
        Debug.Log("Menu button pressed");
        SceneManager.LoadScene("Start Menu");
    }

    public void ControlsMenu()
    {
        Debug.Log("Controls button pressed");
        SceneManager.LoadScene("Controls");
    }

    public void StartGameWithoutVid()
    {
        SceneManager.LoadScene("Level 1.5");
    }
}
