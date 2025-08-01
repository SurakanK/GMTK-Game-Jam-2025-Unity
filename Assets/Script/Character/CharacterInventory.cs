using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    private List<InventoryItemData> _nonEquipItem = new();
    public List<InventoryItemData> nonEquipItem
    {
        get { return _nonEquipItem; }
        set { _nonEquipItem = value; }
    }

    public void IncreaseItem(ItemData data)
    {
        List<InventoryItemData> inventory = nonEquipItem;
        if (data.amount <= 0)
            return;

        if (data.stack <= 0)
            data.stack = 1;

        for (int i = 0; i < inventory.Count && data.amount > 0; i++)
        {
            InventoryItemData item = inventory[i];
            if (item.itemId != data.DataId || item.amount >= data.stack)
                continue;

            int space = data.stack - item.amount;
            int toAdd = Math.Min(space, data.amount);
            item.amount += toAdd;
            data.amount -= toAdd;
            InventoryItemData itemUpdate = inventory[i] = item;
            GameEvent.Instance.EventNonEquipItemChanged?.Invoke(itemUpdate);
        }

        while (data.amount > 0)
        {
            int toAdd = Math.Min(data.stack, data.amount);
            data.amount -= toAdd;

            InventoryItemData newItem = new InventoryItemData
            {
                objectId = Guid.NewGuid().ToString("N"),
                itemId = data.DataId,
                amount = toAdd,
                slotIndex = inventory.Count
            };
            inventory.Add(newItem);
            GameEvent.Instance.EventNonEquipItemChanged?.Invoke(newItem);
        }
    }

    public void Swap(int indexA, int indexB)
    {
        List<InventoryItemData> list = nonEquipItem;
        if (indexA < 0 || indexA >= list.Count || indexB < 0 || indexB >= list.Count)
        {
            Debug.LogWarning("Swap index out of range");
            return;
        }

        InventoryItemData temp = list[indexA];
        list[indexA] = list[indexB];
        list[indexB] = temp;
        GameEvent.Instance.EventNonEquipItemChanged?.Invoke(temp);
    }
}