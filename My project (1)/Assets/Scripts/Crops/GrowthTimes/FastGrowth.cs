using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastGrowth : IGrowth
{
    public void Grow(Crop crop)
    {
        if (!crop.isWatered) return;

        crop.currentGrowDay += 2;
        crop.isWatered = false; 
    }
}
