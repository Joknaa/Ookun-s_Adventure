using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
{
    public float InitialValue;

    [HideInInspector] public float RuntimeValue;


    public void OnAfterDeserialize()
    {
        RuntimeValue = InitialValue;
    }

    public void OnBeforeSerialize()
    {

    }


}
