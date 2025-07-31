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

            if (_curAmount > 1)
            {
                UIGeneric.ShowInputAmountField(
                    OnConfirm,
                    null,
                    "Drop Item",
                    "Enter amount to drop.",
                    itemDrop.Data.amount,
                    itemDrop.Data.amount,
                    "Amount..."
                );

                void OnConfirm(string amount)
                {
                    DrpoItem(int.Parse(amount));
                }
            }
            else
            {
                DrpoItem(1);
            }
        }
    }

    private void DrpoItem(int amount)
    {
        if (amount <= 0)
            return;
        if (amount > _curAmount)
            amount = _curAmount;

    }
}