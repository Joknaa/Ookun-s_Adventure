using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public Sprite ItemSprite;
    public string ItemDescription;
    public bool IsKey;
    public bool IsCoin;

}
