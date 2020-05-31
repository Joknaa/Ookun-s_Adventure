using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PauseMenu : Menus
{
    [HideInInspector] public bool GamePaused;

    public GameStatEnum GameStat;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
            PauseOrPlayTheGame();
    }

    public void PauseOrPlayTheGame()
    {
        GamePaused = GameStat.CurrentGameState == global::GameStat.Paused;
        if (GamePaused)
        {
            PlayTheGame();
        }
        else
        {
            PauseTheGame();
        }
    }

    void PauseTheGame()
    {
        Debug.Log("game paused");
        GameStat.CurrentGameState = global::GameStat.Paused;
        Menu.SetActive(true);
        Time.timeScale = 0;
    }   

    void PlayTheGame()
    {
        GameStat.CurrentGameState = global::GameStat.Played;
        Menu.SetActive(false);
        Time.timeScale = 1;
    }
}
