using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject button;
    public static bool estaPausado = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(estaPausado)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Awake()
    {
        pauseMenu.SetActive(false);
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        estaPausado = false;
    }

    public void PauseGame()
    {
        EventSystem.current.SetSelectedGameObject(button.gameObject);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        estaPausado = true;
    }

    public void goMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}