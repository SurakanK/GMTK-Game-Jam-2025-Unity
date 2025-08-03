using UnityEngine.EventSystems;

public class UIDropSellArea : UIBase, IDropHandler
{
    public StatsData stats => DungeonCore.Instance.dungeon.player.Stats;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent(out UIItemDragging itemDrop))
        {

            if (!GameInstance.AllItems.TryGetValue(itemDrop.Data.itemId, out ItemData itemData))
                return;

            // drop to sell item 
            UIGeneric.ShowMessage(
               () => OnConfirm(itemDrop.Data, itemData),
               null,
               "Item Sale",
               $"Sell this item for {itemData.sellPrice} gold?");
        }
    }

    public void OnConfirm(InventoryItemData data, ItemData itemData)
    {
        BaseGamePlay.Currency += itemData.sellPrice;
        BaseGamePlay.Inventory.RemoveItemAt(data.slotIndex);
    }
}