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

    public int curSlot;

    public void IncreaseItem(ItemData data)
    {

        List<InventoryItemData> inventory = nonEquipItem;

        if (!CheckSlotLimit())
            return;

        if (data.amount <= 0)
            data.amount = 1;

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
            GameEvent.Instance.EventNonEquipItemChanged?.Invoke();
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
            GameEvent.Instance.EventNonEquipItemChanged?.Invoke();
        }
    }

    public void RemoveItemAt(int removeAt)
    {
        List<InventoryItemData> newInventory = nonEquipItem;
        if (removeAt < 0 || removeAt >= newInventory.Count)
            return;

        newInventory.RemoveAt(removeAt);
        SortSlotIndex();

        GameEvent.Instance.EventNonEquipItemChanged?.Invoke();
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
        GameEvent.Instance.EventNonEquipItemChanged?.Invoke();
    }

    private void SortSlotIndex()
    {
        List<InventoryItemData> list = nonEquipItem;
        for (int i = 0; i < list.Count; i++)
        {
            var item = list[i];
            item.slotIndex = i;
            list[i] = item;
        }
    }

    public bool HasItem(HashSet<string> ids)
    {
        return nonEquipItem.Any(e => ids.Contains(e.itemId));
    }

    public bool HasItem(string itemId)
    {
        int total = 0;
        foreach (var item in nonEquipItem)
        {
            if (item.itemId == itemId)
                total += item.amount;

            if (total >= 1)
                return true;
        }
        return false;
    }

    public bool CheckSlotLimit()
    {
        return nonEquipItem.Count + 1 <= curSlot;
    }
}