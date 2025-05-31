using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Crop : MonoBehaviour
{
    public int currentGrowDay = 0;
    public int totalGrowDays = 3;
    public CropQuality quality;
    public bool isWatered;

    protected IGrowth growthTime;
    protected abstract int GetBasePrice();

    public void SetGrowthTime(IGrowth time)
    {
        growthTime = time;
    }

    public void Water()
    {
        isWatered = true;
    }

    public void Grow()
    {
        growthTime?.Grow(this);
    }


    public bool IsReadyToHarvest
    {
        get
        {
            return currentGrowDay >= totalGrowDays;
        }
    }

    public CropItem Harvest()
    {
        AssignQuality();
        Destroy(gameObject);

        CropItem cropItem = ScriptableObject.CreateInstance<CropItem>();
        cropItem.itemname = this.GetType().Name;
        cropItem.quality = this.quality;
        cropItem.quantity = 1;
        cropItem.basePrice = GetBasePrice();

        return cropItem;
    }

    protected void AssignQuality()
    {
        int rng = Random.Range(0, 100);
        if (rng < 10)
        {
            quality = CropQuality.Gold;
        }      
        else if (rng < 30)
        {
            quality = CropQuality.Silver;
        } 
        else
        {
            quality = CropQuality.Normal;
        }   
    }

    
}
