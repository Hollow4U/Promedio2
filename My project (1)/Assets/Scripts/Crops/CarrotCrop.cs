using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotCrop : Crop
{
    protected override int GetBasePrice()
    {
        return 40;
    }
    private void Start()
    {
        totalGrowDays = 5;
        growthTime = new SlowGrowth();
    }
}
