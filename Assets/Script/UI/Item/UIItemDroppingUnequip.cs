using System;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIItemDroppingUnequip : UIBase, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent(out UIItemDragging itemDrop))
        {
            if (itemDrop.uiSlotItem == null)
                return;
                
            // Unequip item
        }
    }
}