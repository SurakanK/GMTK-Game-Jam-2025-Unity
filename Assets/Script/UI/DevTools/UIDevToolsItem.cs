using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class UIDevToolsItem : UIBase
{
    [Header("UI Item List")]
    [SerializeField] private Transform _content;
    [SerializeField] private UIDevToolsItemEntity _prefab;
    [SerializeField] private string _tag;

    private HashSet<string> Tag => new HashSet<string>(
        _tag.Split(',')
        .Select(t => t.Trim())
        .Where(t => !string.IsNullOrEmpty(t))
    );

    private ItemData _curSelectedData;
    public ItemData CurSelectedData => _curSelectedData;

    private UICacheList<UIDevToolsItemEntity> _cacheList;
    protected UICacheList<UIDevToolsItemEntity> CacheList
    {
        get
        {
            if (_cacheList == null)
            {
                _cacheList = new UICacheList<UIDevToolsItemEntity>();
                _cacheList.CreateCacheUI(_content, _prefab);
            }
            return _cacheList;
        }
    }

    void Start()
    {
        CreateList();
    }

    private void CreateList()
    {
        var sortItem = GameInstance.AllItems.Values
            .Where(e => Tag.Any(tag => e.DataId.Contains(tag)))
            .ToList();
        CacheList.Generate(sortItem.ToList(), (i, data, ui) =>
        {
            ui.EventSelected += OnSelected;
        }, null);
    }

    private void OnSelected(GameData data, int index)
    {
        if (GamePlayerCharacter.PlayerCharacter == null)
            return;

        if (data is not ItemData item)
            return;

        if (item.IsItem(out ItemData itemData))
        {
            BaseGamePlay.Inventory.IncreaseItem(itemData);
        }
        else if (item.IsWeapon(out BaseWeapon weaponData))
        {
            BaseGamePlay.Inventory.IncreaseItem(weaponData);
        }
    }
}
