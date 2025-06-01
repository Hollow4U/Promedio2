using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlowGrowth : IGrowth
{
    public void Grow(Crop crop)
    {
        if (!crop.isWatered) return;

        crop.currentGrowDay += 1;
        crop.isWatered = false;
    }
}
