using System;
using UnityEngine;
using UnityEngine.UI;

public class UIItemEntity : UISelection<InventoryItemData>
{
    [Header("DragDrop Componemt")]
    public Image imageSelect;
    public UIItemDragging uiItemDrag;
    public UIItemDropping uiItemDrop;

    public override void UIUpdate()
    {
        if (!Data.TryGetItemData(out ItemData ItemData))
            return;

        SetImage(ItemData.icon);
        SetName(ItemData.title.name.text);
        SetAmount(Data.amount, ItemData.stack);

        if (uiItemDrag != null)
            uiItemDrag.Initialized(Data, Index);
        if (uiItemDrop != null)
            uiItemDrop.Initialized(Data, Index);

        base.UIUpdate();
    }

    internal void SetHighlight(bool isHighlight)
    {
        if (imageSelect != null)
            imageSelect.gameObject.SetActive(isHighlight);
    }
}