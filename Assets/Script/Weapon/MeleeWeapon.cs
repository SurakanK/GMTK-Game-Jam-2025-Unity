using Cysharp.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "MeleeWeapon", menuName = "Weapon/MeleeWeapon", order = 0)]
public class MeleeWeapon : BaseWeapon
{
    public override void Attack()
    {
        if (!IsMeleeWeapon())
            return;
        Owner.Attack();
    }

    public override UniTaskVoid SpawnBullet()
    {
        throw new System.NotImplementedException();
    }

    public override BaseWeapon Clone()
    {
        return Instantiate(this);
    }
}