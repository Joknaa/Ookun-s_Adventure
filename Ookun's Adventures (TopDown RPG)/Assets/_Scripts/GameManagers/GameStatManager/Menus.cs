using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menus : GameStatManager
{
    public GameObject Menu;

    public void Fun_NavigateMenu(GameObject MenuToActivate)
    {
        bool MenuToActivateIsActive = MenuToActivate.activeInHierarchy;
        if (MenuToActivateIsActive)
        {
            MenuToActivate.gameObject.SetActive(false);
            Menu.gameObject.SetActive(true);
        }
        else
        {
            MenuToActivate.gameObject.SetActive(true);
            Menu.gameObject.SetActive(false);
        }
    }

    public void Fun_ExitGame()
    {
        Application.Quit();
        Debug.Log("test i am exiting ");
    }
}
