using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIItemDroppingArea : UIBase, IDropHandler
{
    private InventoryItemData _itemData;
    private int _curAmount;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent(out UIItemDragging itemDrop))
        {
            _itemData = itemDrop.Data;
            _curAmount = _itemData.amount;

            if (!GameInstance.AllItems.TryGetValue(itemDrop.Data.itemId, out ItemData itemData))
                return;

            // drop in boss room
            if (DungeonCore.Instance.dungeon.IsCurrentState(out DungeonBossRoomState bossState))
            {
                if (itemData.IsWeapon(out _) && bossState.Enemy.IsCurrentState<EnemyIdleState>(out _))
                {
                    if (bossState.enemyData.weaponWeaknessIds.Contains(itemData.DataId))
                    {
                        BaseGamePlay.Inventory.RemoveItemAt(itemDrop.slotIndex);
                        bossState.DeadState();
                    }
                    else
                    {
                        UIGeneric.ShowMessage(
                        null,
                        null,
                        "Boss Immune",
                        "Choose a weapon that exploits its weakness.",
                        "Ok"
                        );
                    }
                    return;
                }
            }

            UIGeneric.ShowMessage(
               () => OnConfirm(itemDrop.Data),
               null,
               "Drop Item",
               "Are you sure you want to destroy this item?");
        }
    }

    public void OnConfirm(InventoryItemData data)
    {
        BaseGamePlay.Inventory.RemoveItemAt(data.slotIndex);
    }

    private void DrpoItem(int amount)
    {
        if (amount <= 0)
            return;
        if (amount > _curAmount)
            amount = _curAmount;

    }
}