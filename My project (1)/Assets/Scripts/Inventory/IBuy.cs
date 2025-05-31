using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuy 
{
   int SellPrice { get; }
    void OnBuy();
}
