using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Movimento : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject slotsMenu;
    public GameObject Button;
    private bool menu = true, options = false, slots = false;
    private int buttonPress = 0;

    private void Update()
    {
        if (menu == true)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                options = true;
                menu = false;
                slots = false;
                mainMenu.SetActive(menu);
                optionsMenu.SetActive(options);
                slotsMenu.SetActive(slots);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                buttonPress++;
                if (Input.GetKey(KeyCode.LeftArrow) && buttonPress == 2)
                {
                    Application.Quit();
                    buttonPress = 0;
                }
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                slots = true;
                options = false;
                menu = false;
                mainMenu.SetActive(menu);
                slotsMenu.SetActive(slots);
                optionsMenu.SetActive(options);
                EventSystem.current.SetSelectedGameObject(Button.gameObject);
            }
        }

        if (options == true)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                slots = false;
                options = false;
                menu = true;
                mainMenu.SetActive(menu);
                optionsMenu.SetActive(options);
                slotsMenu.SetActive(slots);
            }
        }

        if (slots == true)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                menu = true;
                slots = false;
                mainMenu.SetActive(menu);
                slotsMenu.SetActive(options);
            }
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                slots = false;
                options = false;
                menu = true;
                mainMenu.SetActive(menu);
                optionsMenu.SetActive(options);
                slotsMenu.SetActive(slots);
            }
        }
        
    }

}
