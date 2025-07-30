using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public abstract class BaseWeapon : ItemData
{
    [Header("Setting")]
    public string spriteId;

    [Header("Weapon Stats")]
    public StatsData stats;
    public StatsData Stats => stats;

    public List<AbilityData> abilityData;

    [Header("Weapon Setting")]
    public bool isAoeDamage;

    [Header("Random Data")]
    public DropTable dropTable;

    private BaseCharacter _owner;
    public BaseCharacter Owner
    {
        get { return _owner; }
        set { _owner = value; }
    }

    public abstract BaseWeapon Clone();

    public void SetOwner(BaseCharacter owner)
    {
        _owner = owner;
    }

    public bool IsMeleeWeapon()
    {
        return this is MeleeWeapon;
    }

    public bool IsRangedWeapon()
    {
        return this is RangedWeapon;
    }

    public bool IsMagicWeapon()
    {
        return this is MagicWeapon;
    }

    public bool IsProjectileWeapon()
    {
        return this is RangedWeapon ||
                this is MagicWeapon;
    }

    public abstract UniTaskVoid SpawnBullet();
    public abstract void Attack();
}

public static class WeaponExtensions
{
    public static bool TryGetWeapon(BaseCharacter owner, string itemId, out BaseWeapon weapon)
    {
        weapon = null;
        if (GameInstance.Instance.weapons.TryGetValue(itemId, out BaseWeapon baseWeapon))
        {
            weapon = baseWeapon.Clone();
            weapon.slotType = SlotType.WeaponLeftHand;
            weapon.amount = 1;
            weapon.SetOwner(owner);
        }
        return weapon != null;
    }
}