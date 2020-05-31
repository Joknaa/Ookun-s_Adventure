using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartingMenu : Menus
{

    public string SceneToLoad;


    public void Fun_StartGame()
    {
        SceneManager.LoadScene(SceneToLoad);

    }


}
