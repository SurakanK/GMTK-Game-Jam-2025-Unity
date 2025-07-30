using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "AbilityData", menuName = "Ability/AbilityData", order = 0)]
public class AbilityData : GameData
{
    public AbilityType type;
    public Trigger[] Trigger;
    public AbilityAction action;

    [Header("Stats")]
    public StatsData stats;

    [Header("Buff")]
    public List<BaseBuff> buffs;
    [Header("DeBuff")]
    public List<BaseBuff> deBuffs;

    public AbilityData Clone()
    {
        return Instantiate(this);
    }
}

[Serializable]
public class AbilityAction
{

    public TargetType Target;
    public TargetType Owner;
}