using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class StartingMenu : GameStatManager
{
    public string SceneToLoad;
    public GameObject OptionMenu;
    public GameObject MainMenu;
    public Slider VolumeSlider;



    public void Fun_StartGame()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
    public void Fun_OptionMenu()
    {
        bool OptionMenuActive = OptionMenu.activeInHierarchy;
        if (OptionMenuActive)
        {
            OptionMenu.gameObject.SetActive(false);
            MainMenu.gameObject.SetActive(true);
        } else
        {
            OptionMenu.gameObject.SetActive(true);
            MainMenu.gameObject.SetActive(false);
        }

    }
    public void Fun_SoundVolume()
    {
    }


    // if Exit is pressed => Exit the current build
    public void Fun_ExitGame()
    {
    }

}
