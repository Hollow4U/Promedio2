using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static  InventoryManager Instance { get; private set; }
    
    public List<Item> inventory = new List<Item>();

    public int selectedIndex = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    public Item GetSelectedItem()
    {
        if (inventory.Count == 0 || selectedIndex < 0 || selectedIndex >= inventory.Count)
            return null;

        return inventory[selectedIndex];
    }

    public void ChangeSelectedItem(int direction)
    {
        if (inventory.Count == 0) return;

        selectedIndex = (selectedIndex + direction + inventory.Count) % inventory.Count;
        Debug.Log($"Ítem seleccionado: {GetSelectedItem()?.itemname}");
    }



    public void AddItem (Item newItem)
    {
        if(newItem is IStackable newStack)
        {
            foreach (Item existing in inventory)
            {
                if(existing.itemname == newItem.name && existing is IStackable stackableExist)
                {
                    if (existing is CropItem existingCrop && newItem is CropItem newCrop)
                    {
                        if (existingCrop.quality != newCrop.quality)
                            continue;
                    }

                    int emptySpace = existing.maxStack - stackableExist.quantity;
                    int amountToAdd = Math.Min(emptySpace, newStack.quantity);

                    stackableExist.AddQuantity(amountToAdd);
                    newStack.quantity -= amountToAdd;

                    if (newStack.quantity <= 0)
                    {
                        return;
                    }
                }
            }
            inventory.Add(newItem);
        }
    }

    public void RemoveItem(Item itemToRemove, int amount)
    {
        if (itemToRemove is IStackable toRemoveStack)
        {
            foreach (Item existing in inventory)
            {
                if (existing.itemname == itemToRemove.name && existing is IStackable stackableExist)
                {
                    if (existing is CropItem existingCrop && itemToRemove is CropItem targetCrop)
                    {
                        if (existingCrop.quality != targetCrop.quality)
                            continue;
                    }

                    if (stackableExist.quantity >= amount)
                    {
                        stackableExist.quantity -= amount;

                        if (stackableExist.quantity == 0)
                        {
                            inventory.Remove(existing);
                        }
                        return;
                    }
                    else
                    {
                        Debug.LogWarning("No hay suficientes items para remover");
                        return;
                    }
                }
            }
            Debug.LogWarning("El item a remover no se encontró");
        }
    }


    public void UIupdate()
    {
        //feature/game
    }
}
