using ProjectWItch.Scripts.Items;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> container = new List<InventorySlot>();

    public void AddItem(ItemObject item, int amount, Sprite sprite)
    {
        bool hasItem = false;

        for (int i = 0; i < container.Count; i++)
        {
            if (container[i].item == item)
            {
                container[i].AddAmount(amount);
                hasItem = true;
                break;
            }
        }

        if (!hasItem)
        {
            Debug.Log(sprite);

            container.Add(new InventorySlot(item, amount, sprite));
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;
    public Sprite sprite;

    public InventorySlot(ItemObject item, int amount, Sprite sprite)
    {
        this.item = item;
        this.amount = amount;
        this.sprite = sprite;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }
}
