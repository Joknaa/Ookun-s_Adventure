using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PauseMenu : GameStatManager
{
    public GameStatEnum GameStat;
    [HideInInspector] public bool GamePaused;
    public GameObject PauseMenuScreen;
    //public string MenuScene;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseOrPlayTheGame();
        }
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
        GameStat.CurrentGameState = global::GameStat.Paused;
        PauseMenuScreen.SetActive(true);
        Time.timeScale = 0;
    }   

    void PlayTheGame()
    {
        GameStat.CurrentGameState = global::GameStat.Played;
        PauseMenuScreen.SetActive(false);
        Time.timeScale = 1;
    }
}
