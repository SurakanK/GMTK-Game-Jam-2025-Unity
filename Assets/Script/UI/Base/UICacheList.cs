using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class UICacheList<TUI> where TUI : Component, IUISelection
{
    public Transform content;
    public TUI prefab;
    private ObjectPool<TUI> pool;

    private List<TUI> activeList = new();
    public List<TUI> Caches => activeList;

    public void CreateCacheUI(Transform content, TUI prefab)
    {
        this.content = content;
        this.prefab = prefab;
        pool = CreateObjectPool();
    }

    private ObjectPool<TUI> CreateObjectPool()
    {
        return new ObjectPool<TUI>(
            createFunc: () => CreatePool(prefab),
            actionOnGet: GetPool,
            actionOnRelease: ReleasePool
        );
    }

    private TUI CreatePool(TUI prefab)
    {
        return GameObject.Instantiate(prefab, content);
    }

    private void GetPool(TUI entity)
    {
        entity.gameObject.SetActive(true);

        Transform parent = entity.transform.parent;
        int insertIndex = 0;

        for (int i = 0; i < parent.childCount; i++)
        {
            Transform sibling = parent.GetChild(i);
            if (sibling == entity.transform)
                continue;

            if (sibling.gameObject.activeSelf)
                insertIndex++;
        }

        entity.transform.SetSiblingIndex(insertIndex);
    }

    private void ReleasePool(TUI entity)
    {
        entity.gameObject.SetActive(false);
    }

    public void Generate<TValue>(IList<TValue> dataList, Action<int, TValue, TUI> onGenerate = null, Action onNoItem = null)
    {
        Clear();

        if (dataList.Count <= 0)
        {
            onNoItem?.Invoke();
            return;
        }

        for (int i = 0; i < dataList.Count; i++)
        {
            TUI ui = pool.Get();
            ui.SetData(dataList[i], i);
            activeList.Add(ui);
            onGenerate?.Invoke(i, dataList[i], ui);
        }
    }

    public void Clear()
    {
        foreach (var ui in activeList)
        {
            pool.Release(ui);
            ui.Clear();
        }
        activeList.Clear();
    }

    public void ForceSelect(int index)
    {
        if (activeList.Count <= 0)
            return;
        if (activeList[index] is IUISelection uiSelection)
        {
            uiSelection.ForceSelect();
        }
    }
}