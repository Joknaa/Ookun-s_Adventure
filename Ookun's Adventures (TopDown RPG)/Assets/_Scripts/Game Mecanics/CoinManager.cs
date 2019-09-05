using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public Inventory PlayerInventory;
    public TextMeshProUGUI CoinText;


    public void UpdateCoinCout()
    {
        CoinText.text = "" + PlayerInventory.NumberOfCoins;
    }
}
