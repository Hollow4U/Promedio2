using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class DayAdvance : MonoBehaviour
{
    private Button _button;


    public void AdvanceDay()
    {
        Debug.Log("Siguiente dia");
        DayCycleManager.Instance.AdvanceDay();
    }
}