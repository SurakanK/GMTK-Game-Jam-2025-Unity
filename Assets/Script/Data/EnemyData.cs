using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Object Data/EnemyData", order = 0)]
public class EnemyData : CharacterData
{
    public List<BaseWeapon> weaponWeakness;
    public List<DropTableItemData> itemDropData;

    public HashSet<string> weaponWeaknessIds => weaponWeakness.Select(e => e.DataId).ToHashSet();
}