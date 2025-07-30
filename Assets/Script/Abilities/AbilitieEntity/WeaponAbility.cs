
using Newtonsoft.Json;
using UnityEngine;

internal class WeaponAbility : BaseAbility
{
    public WeaponAbility(BaseCharacter owner, AbilityData abilitieData) : base(owner, abilitieData)
    {
        Owner.Stats += abilitieData.stats;
    }

    public override void Apply(Trigger trigger, BaseCharacter target)
    {
        base.Apply(trigger, target);
    }

    public override void Remove()
    {
        base.Remove();
        Owner.Stats -= abilitieData.stats;
    }
}