using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DropTable
{
    [Header("Random Ability")]
    public List<DropTableAbilityData> abilityDropTables;
    [Header("Random Stats")]
    public List<DropTableStatsData> statsDropTables;
}