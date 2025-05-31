using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public void UseSelectedItem()
    {
        Item selectedItem = Inventory.GetSelectedItem();

        if (selectedItem is IUsable usableItem)
        {
            usableItem.Use(this);  
        }
    }
}
