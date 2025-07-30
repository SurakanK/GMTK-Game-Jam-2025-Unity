using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

partial class Factory
{
    private static Dictionary<string, ObjectPool<BaseItem>> _itemDropPool = new();
    private static Dictionary<string, BaseItem> _itemInstance = new();
    public static IReadOnlyDictionary<string, BaseItem> ItemInstance => _itemInstance;

    public static BaseItem GetItemPool(ItemData itemData)
    {
        if (itemData.prefab == null)
            return null;

        string id = itemData.DataId;
        if (!_itemDropPool.ContainsKey(id))
            _itemDropPool[id] = CreateObjectPool(itemData.prefab);
        BaseItem item = _itemDropPool[id].Get();
        return item;
    }

    public static void Spawn(InventoryItemData dropItem)
    {
        if (GameInstance.AllItems.TryGetValue(dropItem.itemId, out ItemData item))
        {
            ItemData clone = item.Clone();
            clone.amount = dropItem.amount;

            BaseItem spawned = GetItemPool(item);
            if (spawned == null)
                return;
            _itemInstance[dropItem.objectId] = spawned;
        }
    }

    public static void DestroyItem(string objectId)
    {
        if (!ItemInstance.TryGetValue(objectId, out BaseItem item))
            return;
    }
}