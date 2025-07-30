using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "RangedWeapon", menuName = "Weapon/RangedWeapon", order = 0)]
public class RangedWeapon : BaseWeapon
{
    [Header("Ranged Setting")]
    public BulletProjectile bulletPrefab;
    public bool isProjectile;

    public override void Attack()
    {
        if (!IsRangedWeapon())
            return;
    }

    public override BaseWeapon Clone()
    {
        return Instantiate(this);
    }

    public override async UniTaskVoid SpawnBullet()
    {
        Bullet bullet = Factory.GetBulletPool(bulletPrefab);

        bullet.gameObject.SetActive(false);
        bullet.transform.SetPositionAndRotation(
            Owner.ReferencePoints.arrowSpawnTransfrom.position,
            Owner.ReferencePoints.arrowSpawnTransfrom.rotation
        );

        await UniTask.Yield();
        await Fade.FadeGameobject(bullet.gameObject, 0, true);
        bullet.gameObject.SetActive(true);

        bullet.Launch(GetTargetPosition(), this);

        if (bullet is BulletProjectile projectile)
        {
            projectile.OnProjectileFinished = null;
            projectile.OnDestroy = null;
            projectile.OnProjectileFinished += onProjectileFinished;
            projectile.OnDestroy += onDestroy;

            void onProjectileFinished()
            {
                DestroyBulletCoroutine(bullet).Forget();
            }

            void onDestroy()
            {
                int id = bulletPrefab.GetInstanceID();
                Factory.DestroyBullet(id, bullet);
            }
        }
    }

    private Vector3 GetTargetPosition()
    {
        return Owner.Target.transform.position;
    }

    private async UniTask DestroyBulletCoroutine(Bullet bullet)
    {
        int id = bulletPrefab.GetInstanceID();
        await UniTask.Delay(TimeSpan.FromSeconds(2f));
        await Fade.FadeGameobject(bullet.gameObject, 1f, false);
        Factory.DestroyBullet(id, bullet);
    }
}
