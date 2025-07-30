using UnityEngine;
using UnityEngine.Pool;

partial class Factory
{
    private static ObjectPool<T> CreateObjectPool<T>(T prefab) where T : Component
    {
        return new ObjectPool<T>(
            createFunc: () => CreatePool(prefab),
            actionOnGet: GetPool,
            actionOnRelease: ReleasePool
        );
    }

    private static T CreatePool<T>(T prefab) where T : Component
    {
        return Instantiate(prefab);
    }

    private static void GetPool<T>(T entity) where T : Component
    {
        entity.gameObject.SetActive(true);
    }

    private static void ReleasePool<T>(T entity) where T : Component
    {
        if (!Application.isPlaying)
            return;
        entity.gameObject.SetActive(false);
    }
}