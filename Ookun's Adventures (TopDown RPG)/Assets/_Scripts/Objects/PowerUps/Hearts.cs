using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : PowerUp
{
    public FloatValue PlayerHealth;
    public FloatValue HearthContainers;
    public float HealthIncrease;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth.RuntimeValue += HealthIncrease;
            if (PlayerHealth.RuntimeValue > HearthContainers.InitialValue * 2f)
            {
                PlayerHealth.RuntimeValue = HearthContainers.InitialValue * 2f;
            }
            PowerUpSignal.Raise();
            Destroy(this.gameObject);
            PickUpEffects();
        }
    }
}
