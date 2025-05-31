using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSeed", menuName = "Items/Seed")]
public class SeedItem : Item, IStackable
{
    public int growDays;
    public int quantity {  get; set; }
    public void AddQuantity(int amount) => quantity += amount;
}
