using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class VectorValue : ScriptableObject, ISerializationCallbackReceiver
{
    [Header("Value running in game: ")]
    public Vector2 InitialValue;

    [Header("default value when starting the game: ")]
    public Vector2 DefaultValue;

    public void OnAfterDeserialize() {
        InitialValue = DefaultValue;
    }

    public void OnBeforeSerialize() { }


}
