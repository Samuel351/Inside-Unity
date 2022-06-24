using UnityEngine;
using UnityEngine.EventSystems;

public class Movimento : MonoBehaviour
{
    public GameObject menuPrincipal;
    public GameObject menuOpcoes;
    public GameObject menuJogar;
    public GameObject Button;
    public GameObject Button2;
    public GameObject Button3;
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
        jogar = true;
        menu = false;
        input = false;
        menuPrincipal.SetActive(menu);
        menuJogar.SetActive(jogar);
    }
    public void Opcoes()
    {
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
            opcoes = false;
            menu = true;
            input = false;
            menuPrincipal.SetActive(menu);
            menuOpcoes.SetActive(opcoes);
        }
        if (jogar == true)
        {
            jogar = false;
            menu = true;
            input = false;
            menuPrincipal.SetActive(menu);
            menuJogar.SetActive(jogar);
        }
    }
}
