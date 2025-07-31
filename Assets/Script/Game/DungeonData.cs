using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Dungeon", menuName = "Game/Game Dungeon")]
public class DungeonData : ScriptableObject
{
    [Header("Dungeon Data")]
    public List<RoomTableLevel> roomTableLevels;
}

[Serializable]
public class RoomTableLevel
{
    public int level;
    public int randomAmount;
    public List<RoomTableData> roomTableData;
}