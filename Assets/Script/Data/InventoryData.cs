using UnityEngine;

public struct InventoryItemData
{
    public string objectId;
    public string itemId;
    public int amount;
    public int slotIndex;
    public SlotType slotType;

    public bool TryGetItemData(out ItemData itemData)
    {
        itemData = null;
        if (GameInstance.AllItems.TryGetValue(itemId, out ItemData item))
            itemData = item;
        else
            Debug.LogError($"No item {itemId} in Database");
        return itemData != null;
    }
}