using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    private Stack<GameObject> menus = new Stack<GameObject>();
    public GameObject mainMenu;
    private GameObject currentMenu;

    private void Awake() {
        currentMenu = mainMenu;
    }

    public void OpenMenu(GameObject menu) {
        // Store current menu on the stack
        menus.Push(currentMenu);
        // Close menu
        currentMenu.SetActive(false);

        // Open new menu
        menu.SetActive(true);
        currentMenu = menu;
    }

    public void CloseMenu() {
        // Close current
        currentMenu.SetActive(false);
        // Get new menu
        currentMenu = menus.Pop();
        // Open new
        currentMenu.SetActive(true);
    }
}
