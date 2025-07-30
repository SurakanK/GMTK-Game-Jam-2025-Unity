using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine.Pool;

partial class Factory
{
    private static Dictionary<int, ObjectPool<Bullet>> bulletPool = new();

    public static Bullet GetBulletPool(Bullet bullet)
    {
        int id = bullet.GetInstanceID();
        if (!bulletPool.ContainsKey(id))
            bulletPool[id] = CreateObjectPool(bullet);
        return bulletPool[id].Get();
    }

    public static void DestroyBullet(int id ,Bullet bullet)
    {
        if (bulletPool.TryGetValue(id, out ObjectPool<Bullet> pool))
        {
            pool.Release(bullet);
        }
    }
}