using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatManager : MonoBehaviour
{
    public GameStatEnum GameStat;
    public PlayerController PlayerControllerScript;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("test 01");
            PlayerControllerScript.PlayerAnimator.SetBool("Moving", false); // issue here !!
            Debug.Log("test 02");

            GameStat.CurrentGameState = global::GameStat.Paused;
        }
 
    }
}
