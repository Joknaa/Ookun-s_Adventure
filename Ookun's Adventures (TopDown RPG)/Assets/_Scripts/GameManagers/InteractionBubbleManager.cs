using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionBubbleManager : MonoBehaviour
{
    public GameObject InteractionBubble;
    
    public void ChangeBubbleStatTo(bool Value)
    {
        if (Value)
        {
            InteractionBubble.SetActive(true);
        }
        else
        {
            InteractionBubble.SetActive(false);
        }
    }
}