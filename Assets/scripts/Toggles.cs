using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Toggles : MonoBehaviour
{
    private Menus menus;
    public GameObject pause;
    public GameObject mainMenu;
    public GameObject credits;
    public GameObject win;
    public GameObject over;
    public GameObject master;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake() {
        menus=new Menus();
    }
    private void Start() {
        if(over!=null)
        {
            over.SetActive(false);
        }
        if(win!=null)
        {
            win.SetActive(false);
        }
        if(mainMenu!=null && mainMenu.activeSelf)
        {
            Time.timeScale=0f; //pause the game at the start if main menu is active
        }
        else{
            Time.timeScale=1f;
        }
        
    }
    private void OnEnable() 
    {
        menus.menu.Enable();
        menus.menu.Pause.performed+=TogglePause;
    }
    private void OnDisable() 
    {
        menus.menu.Pause.performed-=TogglePause;
        menus.menu.Disable();
    }
    private void TogglePause(InputAction.CallbackContext context) 
    {
        pause.SetActive(true);

        Time.timeScale=0f; //pause the game
        Cursor.lockState=CursorLockMode.None; //unlock the cursor
        Cursor.visible=true; //show the cursor
    }
    public void Resume()
    {
        pause.SetActive(false);
        Time.timeScale=1f; //resume the game
    }
    public void Restart()
    {
        Time.timeScale=1f; //resume the game before restarting
        Scene currentScene=SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
    public void GoToMainMenu()
    {
        pause.SetActive(false);
        mainMenu.SetActive(true);
        Time.timeScale=0f; //pause the game
    }

    //main menu functions
    public void StartGame()
    {
        mainMenu.SetActive(false);
        Time.timeScale=1f; //resume the game
        Scene currentScene=SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void RollCredits()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
        Time.timeScale=0f; //pause the game
    }

    public void MainCredits()
    {
        credits.SetActive(false);
        mainMenu.SetActive(true);
        Time.timeScale=0f; //pause the game
    }
    public void MainWin()
    {
        win.SetActive(false);
        mainMenu.SetActive(true);
        Time.timeScale=0f; //pause the game
    }
    public void OverMenu()
    {
        over.SetActive(false);
        mainMenu.SetActive(true);
        Time.timeScale=0f; //resume the game
    }
    public void credWin()
    {
        win.SetActive(false);
        credits.SetActive(true);
        Time.timeScale=0f; //pause the game
    }
    public void RestartOver()
    {
        over.SetActive(false);
        Time.timeScale=1f; //resume the game before restarting
        Scene currentScene=SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
    public void credMenu()
    {
        credits.SetActive(false);
        mainMenu.SetActive(true);
        Time.timeScale=0f; //pause the game
    }
    public void masterBack()
    {
        master.SetActive(false);
        Time.timeScale=1f; 
    }
    
    }
