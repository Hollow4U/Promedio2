using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSeed", menuName = "Items/Seed")]
public class SeedItem : Item, IStackable, IUsable
{
    public GameObject cropPrefab;
    public int quantity { get; set; }

    public void AddQuantity(int amount) => quantity += amount;

    public void Use(Player player)
    {
        if (quantity <= 0) return;
        Instantiate(cropPrefab, player.transform.position, Quaternion.identity);
        quantity--;

        if (quantity == 0)
        {
            InventoryManager.Instance.RemoveItem(this, 0); 
        }
    }
}
