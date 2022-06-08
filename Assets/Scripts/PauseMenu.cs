using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private GameObject pauseMenu;
    private GameObject LogicaJogo;
    private static bool isPaused = false;

    void Awake()
    {
        LogicaJogo = GameObject.Find("LogicaJogo");
        pauseMenu = GameObject.Find("menudePause");
        pauseMenu.SetActive(false);
        DontDestroyOnLoad(pauseMenu);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
    }
    public void goMainMenu()
    {
        isPaused = false;
        Destroy(LogicaJogo);
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}