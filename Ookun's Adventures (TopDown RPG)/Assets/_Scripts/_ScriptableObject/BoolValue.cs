using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class BoolValue : ScriptableObject, ISerializationCallbackReceiver
{
    [HideInInspector] public bool RunTimeValue;

     public bool InitialValue;

    public void OnAfterDeserialize()
    {
        RunTimeValue = InitialValue;
    }

    public void OnBeforeSerialize() { }

}
