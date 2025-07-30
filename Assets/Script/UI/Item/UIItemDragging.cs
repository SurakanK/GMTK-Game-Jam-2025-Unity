using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UIItemDragging : UIBaseItem, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Canvas _canvas;
    private CanvasGroup _canvasGroup;
    private Transform _originalParent;
    private ScrollRect _scrollRect;
    private bool _isDragging;

    public InventoryItemData Data;
    public UIItemSlotEquipEntity uiSlotItem;
    public int slotIndex = -1;

    void Start()
    {
        _canvas = GetComponentInParent<Canvas>();
        _canvasGroup = GetComponent<CanvasGroup>();

        if (_canvasGroup == null)
            _canvasGroup = gameObject.AddComponent<CanvasGroup>();

        if (_scrollRect == null)
            _scrollRect = GetComponentInParent<ScrollRect>();
    }

    void OnDestroy()
    {

    }

    public void Initialized(InventoryItemData data, int index)
    {
        Data = data;
        slotIndex = index;

        if (!data.TryGetItemData(out ItemData ItemData))
            return;
        SetImage(ItemData.icon);
    }

    public void Initialized(UIItemSlotEquipEntity uiItemSlot)
    {
        uiSlotItem = uiItemSlot;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (string.IsNullOrEmpty(Data.itemId))
            return;

        if (_scrollRect != null)
        {
            if (Mathf.Abs(eventData.delta.x) < Mathf.Abs(eventData.delta.y))
            {
                _scrollRect.SendMessage("OnBeginDrag", eventData);
                eventData.pointerDrag = _scrollRect.gameObject;
                return;
            }
        }

        _isDragging = true;
        _canvasGroup.blocksRaycasts = false;
        _originalParent = transform.parent;
        transform.SetParent(_canvas.transform);
        OnShow();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!_isDragging)
            return;
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!_isDragging)
            return;

        _isDragging = false;
        _canvasGroup.blocksRaycasts = true;
        transform.SetParent(_originalParent);
        transform.localPosition = Vector3.zero;
        OnHide();
    }
}