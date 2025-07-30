using UnityEngine;

public class UIItemEntity : UISelection<InventoryItemData>
{
    [Header("Setting")]
    public SlotType slotType;

    [Header("DragDrop Componemt")]
    public UIItemDragging uiItemDrag;
    public UIItemDropping uiItemDrop;

    public override void UIUpdate()
    {
        if (!Data.TryGetItemData(out ItemData ItemData))
            return;

        SetImage(ItemData.icon);
        SetName(ItemData.title.name.text);
        SetAmount(Data.amount, ItemData.stackAmount);

        if (uiItemDrag != null)
            uiItemDrag.Initialized(Data, Index);
        if (uiItemDrop != null)
            uiItemDrop.Initialized(Data, Index);

        base.UIUpdate();
    }
}