using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIItemSlotEquipEntity : UIItemEntity
{
    public UnityAction EventEquipped;
    public UnityAction EventUnEquipped;

    public List<GameObject> showSlotEmpty;
    public List<GameObject> showSlotItem;

    void Start()
    {
        if (uiItemDrag != null)
            uiItemDrag.Initialized(this);
        if (uiItemDrop != null)
            uiItemDrop.Initialized(this);
    }

    public override void UIUpdate()
    {
        if (string.IsNullOrEmpty(Data.itemId) ||
            Data.itemId == GameWeapons.HandId ||
            !Data.TryGetItemData(out ItemData ItemData))
        {
            EventUnEquipped?.Invoke();
            SetSlotEmpty();
            return;
        }

        SetImage(ItemData.icon);
        SetName(ItemData.title.name.text);
        SetAmount(Data.amount, ItemData.stack);

        if (uiItemDrag != null)
            uiItemDrag.Initialized(Data, Index);
        if (uiItemDrop != null)
            uiItemDrop.Initialized(Data, Index);

        EventUnEquipped?.Invoke();
        SetSlotItem();
    }

    private void SetSlotEmpty()
    {
        foreach (var obj in showSlotEmpty)
            obj.SetActive(true);
        foreach (var obj in showSlotItem)
            obj.SetActive(false);
    }

    private void SetSlotItem()
    {
        foreach (var obj in showSlotEmpty)
            obj.SetActive(false);
        foreach (var obj in showSlotItem)
            obj.SetActive(true);
    }
}