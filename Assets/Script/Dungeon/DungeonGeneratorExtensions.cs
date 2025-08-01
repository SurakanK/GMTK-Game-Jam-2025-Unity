using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class DungeonGeneratorExtensions
{

    public static bool TryGetTableByLevel(this List<RoomTableLevel> tableLevels, int level, out RoomTableLevel roomTableLevel)
    {
        roomTableLevel = null;
        if (tableLevels == null || tableLevels.Count <= 0)
            return false;

        for (int i = 0; i < tableLevels.Count; i++)
        {
            if (level > tableLevels[i].level)
                continue;
            roomTableLevel = tableLevels[i];
            return true;
        }

        roomTableLevel = tableLevels.Last();
        return true;
    }

    public static void Generate(this DungeonData data, ref List<RoomData> result)
    {
        int level = GameInstance.Level;
        if (data.roomTableLevels.TryGetTableByLevel(level, out RoomTableLevel roomTableLevel))
        {
            for (int i = 0; i < roomTableLevel.randomAmount; i++)
            {
                if (roomTableLevel.roomTableData.TryGetDropTable(out RoomTableData roomData))
                {
                    result.Add(roomData.room);
                }
            }
        }
    }
}