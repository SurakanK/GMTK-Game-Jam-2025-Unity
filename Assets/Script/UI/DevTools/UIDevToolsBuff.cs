using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class UIDevToolsBuff : UIBase
{
    [Header("UI Item List")]
    [SerializeField] private Transform _content;
    [SerializeField] private UIDevToolsItemEntity _prefab;

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
        List<BaseBuff> buffs = GameInstance.Instance.buffs.Values.ToList();
        CacheList.Generate(buffs, (i, data, ui) =>
        {
            ui.EventSelected += OnSelected;
        }, null);
    }

    private void OnSelected(GameData data, int index)
    {
        if (GamePlayerCharacter.PlayerCharacter == null)
            return;
        GamePlayerCharacter.PlayerCharacter.AddBuff(data.DataId);
    }
}
