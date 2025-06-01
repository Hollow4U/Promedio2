using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoCrop : Crop
{
    protected override int GetBasePrice()
    {
        return 10; 
    }
    private void Start()
    {
        totalGrowDays = 5; 
         growthTime = new FastGrowth(); 
    }
}
