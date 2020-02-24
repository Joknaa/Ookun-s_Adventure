using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public Item ShowenItem;
    public List<Item> Items = new List<Item>();
    public int NumberOfKeys = 0;
    public int NumberOfCoins = 0;

    public void Awake()
    {
       NumberOfCoins = 0;
       NumberOfKeys = 0;
    }

    public void AddItem(Item ItemToAdd)
    {
        // is the Item a key ?
        if (ItemToAdd.IsKey)
        {
            NumberOfKeys++;
        } else if (ItemToAdd.IsCoin)
        {
            NumberOfCoins++;
        } else 
        {
            if (!Items.Contains(ItemToAdd))
            {
                Items.Add(ItemToAdd);
            }
        }
    }

}
