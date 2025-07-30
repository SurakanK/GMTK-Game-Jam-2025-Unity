
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

public class CharacterData : BaseObject
{
    public BaseCharacter prefab;

    [Header("Stats")]
    public StatsData stats;

    [Header("Buff")]
    public List<BaseBuff> defaultBuff;

    [Header("EquipItem")]
    public BaseWeapon weapon;

    public void Apply(BaseCharacter owner)
    {
        // Apply Stats
        stats.Apply(owner);

        // Equip Weapon
        InitializeWeapon(owner);

        // Apply buff
        ApplyBuff(owner);
    }

    private void InitializeWeapon(BaseCharacter owner)
    {
        if (owner.Equipment)
        {
            if (weapon)
            {
                if (WeaponExtensions.TryGetWeapon(owner, weapon.DataId, out BaseWeapon baseWeapon))
                {
                    owner.Stats += baseWeapon.Stats;
                    owner.Equipment.EquipWeapon(baseWeapon);
                }
            }
        }
    }

    private void ApplyBuff(BaseCharacter owner)
    {
        foreach (BaseBuff buff in defaultBuff)
        {
            owner.AddBuff(buff);
        }
    }
}