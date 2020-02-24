using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Menus : GameStatManager
{

    public GameObject MainMenu;
    public GameObject OptionMenu;
    public Slider VolumeSlider;


    public void Fun_NavigateMenu(GameObject MenuToActivate)
    {
        bool MenuToActivateIsActive = MenuToActivate.activeInHierarchy;
        if (MenuToActivateIsActive)
        {
            MenuToActivate.gameObject.SetActive(false);
            MainMenu.gameObject.SetActive(true);
        }
        else
        {
            MenuToActivate.gameObject.SetActive(true);
            MainMenu.gameObject.SetActive(false);
        }
    }


    public void Fun_SoundVolume()
    {

    }


    // if Exit is pressed => Exit the current build
    public void Fun_ExitGame()
    {
        Application.Quit();
        Debug.Log("test i am exiting ");
    }

}
