using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : PowerUp
{
    public Inventory PlayerInventory;
    public Item Coin;

    private void Start()
    {
        PowerUpSignal.Raise();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().PlaySound("PickUp_Coin");
            PlayerInventory.AddItem(Coin);
            PowerUpSignal.Raise();
            Destroy(this.gameObject);
            PickUpEffects();

        }
    }
}
