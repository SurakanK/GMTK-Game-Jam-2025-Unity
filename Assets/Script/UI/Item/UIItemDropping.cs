using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIItemDropping : UIBaseItem, IDropHandler
{
    private ScrollRect _scrollRect;
    public InventoryItemData Data;
    public UIItemSlotEquipEntity uiSlotItem;
    public int slotIndex = -1;

    void Start()
    {
        if (_scrollRect == null)
            _scrollRect = GetComponentInParent<ScrollRect>();
    }

    public void Initialized(InventoryItemData data, int index)
    {
        Data = data;
        slotIndex = index;
    }

    public void Initialized(UIItemSlotEquipEntity uiItemSlot)
    {
        uiSlotItem = uiItemSlot;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent(out UIItemDragging itemDrop))
        {
            if (uiSlotItem == null)
            {
                // Dragging from inventory to inventory
                if (itemDrop.uiSlotItem == null)
                {
                    if (itemDrop.slotIndex == slotIndex)
                        return;
                    // SwapItem
                }
                else
                {
                    // Dragging from slot equip to item inventory
                    if (CanSwapToEquip(Data, itemDrop.uiSlotItem))
                    {
                        // SwapToEquip from item inventory
                      
                    }
                    else
                    {
                        // Unequip item
                      
                    }
                }
            }
            else
            {
                if (!CanDropping(itemDrop.Data))
                    return;
                // Dragging from inventory to slot equip
            }
        }
    }

    private bool CanSwapToEquip(InventoryItemData data, UIItemSlotEquipEntity from)
    {
        return IsValidEquipTarget(data, from.slotType);
    }

    private bool CanDropping(InventoryItemData data)
    {
        if (uiSlotItem == null)
            return false;

        if (data.objectId == Data.objectId)
            return false;

        return IsValidEquipTarget(data, uiSlotItem.slotType);
    }

    private bool IsValidEquipTarget(InventoryItemData data, SlotType targetSlot)
    {
        if (!data.TryGetItemData(out ItemData itemData))
            return false;

        if (itemData.IsItem(out _))
        {
            switch (targetSlot)
            {
                case SlotType.WeaponRightHand:
                case SlotType.Armor:
                case SlotType.Helmet:
                case SlotType.RingLeft:
                case SlotType.RingRight:
                    return true;
            }
        }

        if (itemData.IsWeapon(out _) && targetSlot == SlotType.WeaponLeftHand)
            return true;

        return false;
    }
}