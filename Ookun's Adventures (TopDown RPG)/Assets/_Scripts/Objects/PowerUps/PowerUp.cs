using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public Signals PowerUpSignal;
    public GameObject PickUpEffect;


    public void PickUpEffects()
    {
        if (PickUpEffect != null)
        {
            GameObject Effect = Instantiate(PickUpEffect, transform.position, Quaternion.identity);
            Destroy(Effect, 1f);

        }
    }

}
