using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStat
{
    Paused,
    Played
}

[CreateAssetMenu]

public class GameStatEnum: ScriptableObject, ISerializationCallbackReceiver
{
    public GameStat CurrentGameState;

    public GameStat StartingGameStat;

    public void OnAfterDeserialize()
    {
        StartingGameStat = GameStat.Played;
    }

    public void OnBeforeSerialize() { }
}