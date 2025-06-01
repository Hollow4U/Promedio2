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
        switch (quality)
        {
            case CropQuality.Gold:
                return basePrice * 3;
            case CropQuality.Silver:
                return basePrice * 2;
            case CropQuality.Normal:
            default:
                return basePrice;
        }
    }
}
