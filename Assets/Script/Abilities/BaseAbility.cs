using UnityEngine;

public abstract class BaseAbility
{
    public string DataId
    {
        get
        {
            return abilitieData.DataId;
        }
    }

    public BaseCharacter Owner;
    public BaseCharacter Traget;
    public AbilityData abilitieData;

    public static BaseAbility Create(BaseCharacter owner, AbilityData abilitieData)
    {
        switch (abilitieData.type)
        {
            case AbilityType.Weapon: return new WeaponAbility(owner, abilitieData);
            default: return null;
        }
    }

    public BaseAbility(BaseCharacter owner, AbilityData abilitieData)
    {
        this.Owner = owner;
        this.abilitieData = abilitieData.Clone();
        Initialized();
    }

    public virtual void Initialized()
    {

    }

    public virtual void Apply(Trigger trigger, BaseCharacter target = null)
    {
        if (abilitieData.action.Target == TargetType.Self)
        {
            Traget = this.Owner;
        }
        else
        {
            Traget = target;
        }
    }

    public virtual void Remove() { }
}

public enum Trigger
{
    Start,
    Attack,
    Equip,
    TakeDamage,
    Death,
    SendDamage,
    Shoot,
}

public enum TargetType
{
    Self,
    Opponent,
}

public enum AbilityType
{
    Tools,
    Weapon,
}
