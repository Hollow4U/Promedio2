using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropItem : Item, IStackable, ISell
{
    public CropQuality quality; 
    public int quantity { get; set; }

    public void AddQuantity(int amount) => quantity += amount;

    public int GetSellPrice()
    {
        return quality switch
        {
            CropQuality.Gold => basePrice * 3,
            CropQuality.Silver => basePrice * 2,
            _ => basePrice
        };
    }
}
