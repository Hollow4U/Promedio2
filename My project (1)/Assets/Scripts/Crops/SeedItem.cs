using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSeed", menuName = "Items/Seed")]
public class SeedItem : Item, IStackable, IUsable
{
    public GameObject cropPrefab;
    [SerializeField] public int quantity { get; set; }

    public void AddQuantity(int amount) => quantity += amount;

    public void Use(Player player)
    {
 
        Instantiate(cropPrefab, player.transform.position, Quaternion.identity);
      
    }
}
