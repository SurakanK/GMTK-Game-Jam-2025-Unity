using UnityEngine;
using UnityEngine.Events;

public abstract class Bullet : MonoBehaviour
{
    protected StatsData weaponStats;
    protected BaseCharacter Owner;
    public UnityAction OnDestroy { get; set; }

    public virtual void Launch(Vector3 position, BaseWeapon weapon)
    {
        Owner = weapon.Owner;
        weaponStats = weapon.Stats;
    }

    protected void ApplyDamage(BaseCharacter opponent)
    {
        if (opponent == null)
            return;
        opponent.BulletHit(Owner, weaponStats);
    }
}