using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Update()
    {
        InventoryUse(); 
        SelectItem();
    }
    public void SelectItem()
    {
        float scroll = Input.mouseScrollDelta.y;
        if (scroll != 0)
        {
            int direction = scroll > 0 ? 1 : -1;
            InventoryManager.Instance.ChangeSelectedItem(direction);
        }
    }

    public void InventoryUse()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Item selectedItem = InventoryManager.Instance.GetSelectedItem();
            Debug.Log($"Ítem seleccionado: {selectedItem?.itemname}"); 
            if (selectedItem is IUsable usableItem)
            {
                Debug.Log("Llamando a Use()"); 
                usableItem.Use(this);
            }
        }
    }
}
