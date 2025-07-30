using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public class UITier : UIBase
{
    public TextMeshProUGUI textTier;
    public Transform starContent;
    public Image starPoint;
    private ObjectPool<Image> pool;
    private ObjectPool<Image> Pool
    {
        get
        {
            if (pool == null)
                pool = CreateObjectPool();
            return pool;
        }
        set { pool = value; }
    }

    private List<Image> poolList = new List<Image>();

    void OnDestroy()
    {
        pool?.Clear();
    }

    private ObjectPool<Image> CreateObjectPool()
    {
        return new ObjectPool<Image>(
            createFunc: () => CreatePool(starPoint),
            actionOnGet: GetPool,
            actionOnRelease: ReleasePool
        );
    }

    private Image CreatePool(Image prefab)
    {
        return GameObject.Instantiate(prefab, starContent);
    }

    private void GetPool(Image image)
    {
        image.gameObject.SetActive(true);
    }

    private void ReleasePool(Image image)
    {
        image.gameObject.SetActive(false);
    }

    public void SetTier(int tier)
    {
        if (textTier != null)
        {
            textTier.text = $"{tier}";
        }

        if (starPoint != null && starContent != null)
        {
            foreach (var star in poolList.ToArray())
                Pool.Release(star);

            poolList.Clear();

            for (int i = 0; i < tier; i++)
            {
                poolList.Add(Pool.Get());
            }
        }
    }
}