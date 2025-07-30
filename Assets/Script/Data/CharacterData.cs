
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

    public void Apply(BaseCharacter owner)
    {
        // Apply Stats
        stats.Apply(owner);

        // Apply buff
        ApplyBuff(owner);
    }

    private void ApplyBuff(BaseCharacter owner)
    {
        foreach (BaseBuff buff in defaultBuff)
        {
            owner.AddBuff(buff);
        }
    }
}