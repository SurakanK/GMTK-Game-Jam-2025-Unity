using System.Collections.Generic;
using UnityEngine;

partial class BaseCharacter
{
    public Dictionary<string, BaseAbility> Abilities = new();

    private void IncreaseAbility(AbilityData abilityData)
    {
        BaseAbility abilitie = BaseAbility.Create(this, abilityData);
        if (!Abilities.TryAdd(abilitie.DataId, abilitie))
        {
            //TODO: message have ablility
        }
    }

    private void DecreaseAbility(AbilityData abilityData)
    {
        if (Abilities.ContainsKey(abilityData.DataId))
        {
            Abilities[abilityData.DataId].Remove();
            Abilities.Remove(abilityData.DataId);
        }
        else
        {
            //TODO: message not have ablility
        }
    }

    public void IncreaseWeaponAbility(BaseWeapon weapon)
    {
        foreach (AbilityData abilityData in weapon.abilityData)
        {
            IncreaseAbility(abilityData);
        }
    }

    public void DecreaseWeaponAbility(BaseWeapon weapon)
    {
        foreach (AbilityData abilityData in weapon.abilityData)
        {
            DecreaseAbility(abilityData);
        }
    }
}