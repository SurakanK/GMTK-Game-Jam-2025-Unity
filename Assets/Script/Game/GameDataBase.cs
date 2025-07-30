using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "GameDataBase", menuName = "GameDataBase", order = 0)]
public class GameDataBase : ScriptableObject
{
    public List<BaseBuff> baseBuffs;
    public List<BaseWeapon> weapons;
    public List<ItemData> currency;
    public List<AbilityData> abilities;
    public List<ItemData> items;

    public void RegisterGameData(GameInstance gameInstance)
    {
        RegisterToDict(gameInstance.items, items.Select(e => e.Clone()).ToList());
        RegisterToDict(gameInstance.buffs, baseBuffs.Select(e => e.Clone()).ToList());
        RegisterToDict(gameInstance.weapons, weapons.Select(e => e.Clone()).ToList());
        RegisterToDict(gameInstance.currency, currency.Select(e => e.Clone()).ToList());
        RegisterToDict(gameInstance.abilities, abilities.Select(e => e.Clone()).ToList());
    }

    private void RegisterToDict<T>(Dictionary<string, T> target, List<T> source) where T : IIdentifiableData
    {
        foreach (var item in source)
        {
            if (item == null)
                continue;
            if (!target.ContainsKey(item.DataId))
                target.Add(item.DataId, item);
            else
                Debug.LogWarning($"Duplicate key found: {item.DataId} in {typeof(T).Name}");
        }
    }
}