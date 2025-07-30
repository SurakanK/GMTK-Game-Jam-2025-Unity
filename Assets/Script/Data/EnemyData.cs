using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Object Data/EnemyData", order = 0)]
public class EnemyData : CharacterData
{
    public List<DropTableItemData> itemDropData;
}