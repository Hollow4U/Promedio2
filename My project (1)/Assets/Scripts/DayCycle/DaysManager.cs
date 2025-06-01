using UnityEngine;
using System;
using System.Collections.Generic;

public class DayCycleManager : MonoBehaviour
{
    public static DayCycleManager Instance { get; private set; }
    public static event Action<int> OnDayAdvanced;

    public Func<Crop, bool> CanCropGrow;

    private int _currentDay = 1;
    public int CurrentDay => _currentDay;
    public static List<Crop> ActiveCrops = new List<Crop>();

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        else Instance = this;
    }
    public void AdvanceDay()
    {
        _currentDay++;
        OnDayAdvanced?.Invoke(_currentDay);
        GrowWateredCrops();
    }

    private void GrowWateredCrops()
    {
        foreach (Crop crop in ActiveCrops)
        {

            bool canGrow = CanCropGrow?.Invoke(crop) ?? true;

            if (crop.isWatered && canGrow)
            {
                crop.Grow();
                crop.isWatered = false;
            }
        }
    }
}
