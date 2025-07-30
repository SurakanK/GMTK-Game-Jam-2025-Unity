using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIInventory : UIBase
{
    [Header("UI Item List")]
    [SerializeField] private Transform _content;
    [SerializeField] private UIItemEntity _prefab;

    [Header("Event")]
    public UnityEvent OnNoItemData;

    private InventoryItemData _curSelectedData;
    public InventoryItemData CurSelectedData => _curSelectedData;

    private string _tag;
    private HashSet<string> Tag => new HashSet<string>(
        _tag.Split(',')
        .Select(t => t.Trim())
        .Where(t => !string.IsNullOrEmpty(t))
    );

    private UICacheList<UIItemEntity> _cacheList;
    protected UICacheList<UIItemEntity> CacheList
    {
        get
        {
            if (_cacheList == null)
            {
                _cacheList = new UICacheList<UIItemEntity>();
                _cacheList.CreateCacheUI(_content, _prefab);
            }
            return _cacheList;
        }
    }

    public void Initialized()
    {
        if (GamePlayerCharacter.PlayerCharacter == null)
            return;
        GamePlayerCharacter.PlayerCharacter.EventNonEquipItemChanged += OnInventoryChange;
        CreateList();
    }

    private void CreateList()
    {
        CacheList.Clear();

        CacheList.Generate(GamePlayerCharacter.Inventory.nonEquipItem, (i, data, ui) =>
        {
          
        }, NoItemData);

        if (CacheList.Caches.Count > 0)
            SortByTag(_tag);
    }

    public void SortByTag(string tag)
    {
        _tag = tag;
        for (int i = 0; i < CacheList.Caches.Count; i++)
        {
            UIItemEntity ui = CacheList.Caches[i];
            ui.gameObject.SetActive(false);
            if (!ui.Data.TryGetItemData(out ItemData itemData))
                continue;
            if (!string.IsNullOrEmpty(_tag) && !Tag.Any(tag => itemData.Tag.Contains(tag)))
                continue;
            ui.gameObject.SetActive(true);
        }
    }

    public virtual void NoItemData()
    {
        OnNoItemData?.Invoke();
    }

    private void OnInventoryChange(InventoryItemData newItem)
    {
        CreateList();
    }
}