using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    public string itemname;
    public Sprite icon;
    public int basePrice;
    public int maxStack = 99;
}
