using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Button;

    void Awake()
    {
        EventSystem.current.SetSelectedGameObject(Button.gameObject); 
    }

    public void ResumeGame()
    {
        SceneManager.LoadScene(2);
    }

    public void goMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}