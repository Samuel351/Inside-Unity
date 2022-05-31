using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject slotsMenu;
    public GameObject Button;
    private bool menu = true, options = false, slots = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) && menu == true)
        {
            options = true;
            menu = false;
            slots = false;
            mainMenu.SetActive(menu);
            optionsMenu.SetActive(options);
            slotsMenu.SetActive(slots);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && options == true)
        {
            slots = false;
            options = false;
            menu = true;
            mainMenu.SetActive(menu);
            optionsMenu.SetActive(options);
            slotsMenu.SetActive(slots);
        }
        else if (Input.GetKey(KeyCode.KeypadEnter) && menu == true)
        {
            slots = true;
            options = false;
            menu = false;
            mainMenu.SetActive(menu);
            slotsMenu.SetActive(slots);
            optionsMenu.SetActive(options);
            EventSystem.current.SetSelectedGameObject(Button.gameObject);

        }
        else if (Input.GetKey(KeyCode.Escape) && slots == true)
        {
            menu = true;
            slots = false;
            mainMenu.SetActive(menu);
            slotsMenu.SetActive(options);
        }
    }

}
