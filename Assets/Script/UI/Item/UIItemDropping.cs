using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIItemDropping : UIBaseItem, IDropHandler
{
    private ScrollRect _scrollRect;
    public InventoryItemData Data;
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

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent(out UIItemDragging itemDrop))
        {
            GameInstance.Inventory.Swap(itemDrop.slotIndex, slotIndex);
        }
    }
}