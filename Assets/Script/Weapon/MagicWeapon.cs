using Cysharp.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "MagicWeapon", menuName = "Weapon/MagicWeapon", order = 0)]
public class MagicWeapon : BaseWeapon
{
    public override void Attack()
    {
        throw new System.NotImplementedException();
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