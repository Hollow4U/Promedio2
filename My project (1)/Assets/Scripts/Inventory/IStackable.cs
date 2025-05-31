using UnityEngine;

public interface IStackable
{
    int quantity { get; set; }
    void AddQuantity(int amount);
}
