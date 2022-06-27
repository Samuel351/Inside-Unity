using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Movimento : MonoBehaviour
{
    public GameObject menuPrincipal;
    public GameObject menuOpcoes;
    public GameObject menuJogar;
    public GameObject Button;
    public GameObject Button2;
    public GameObject Button3;
    public AudioSource audioMp, audioMop, audioJg;
    private bool menu = true, opcoes = false, jogar = false, input = false;

    void Update()
    {
        // Navegação menu incial
        if(Input.GetKey(KeyCode.DownArrow) && !input)
        {
            if (menu == true)
            {
                EventSystem.current.SetSelectedGameObject(Button.gameObject);
                input = true;
            }
            else if(jogar == true)
            {
                EventSystem.current.SetSelectedGameObject(Button2.gameObject);
                input = true;
            }
            else if (opcoes == true)
            {
                EventSystem.current.SetSelectedGameObject(Button3.gameObject);
                input = true;
            }
        }
    }

    public void Jogar()
    {
        audioJg.Play();
        jogar = true;
        menu = false;
        input = false;
        menuPrincipal.SetActive(menu);
        menuJogar.SetActive(jogar);
    }
    public void Opcoes()
    {
        audioMop.Play();
        opcoes = true;
        menu = false;
        input = false;
        menuPrincipal.SetActive(menu);
        menuOpcoes.SetActive(opcoes); 
    }
    public void Sair()
    {
        Application.Quit();
    }
    public void Voltar()
    {
        if (opcoes == true)
        {
            audioMop.Stop();
            audioMp.Play();
            opcoes = false;
            menu = true;
            input = false;
            menuPrincipal.SetActive(menu);
            menuOpcoes.SetActive(opcoes);
        }
        if (jogar == true)
        {
            audioMp.Play();
            jogar = false;
            menu = true;
            input = false;
            menuPrincipal.SetActive(menu);
            menuJogar.SetActive(jogar);
        }
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(0);
    }
}
