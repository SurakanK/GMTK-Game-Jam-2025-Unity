using System;
using UnityEngine;
using UnityEngine.Pool;

public partial class UIGameplayController
{
    private ObjectPool<T> CreateObjectPool<T>(T prefab, Transform root) where T : UIBase
    {
        return new ObjectPool<T>(
            createFunc: () => CreatePool(prefab, root),
            actionOnGet: GetPool,
            actionOnRelease: ReleasePool
        );
    }

    private void ReleasePool<T>(T entity) where T : UIBase
    {
        entity.gameObject.SetActive(false);
    }

    private void GetPool<T>(T entity) where T : UIBase
    {
        entity.gameObject.SetActive(true);
    }

    private T CreatePool<T>(T prefab, Transform root) where T : UIBase
    {
        return GameObject.Instantiate(prefab, root);
    }
}