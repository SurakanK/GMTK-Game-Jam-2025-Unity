using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DungeonCore : MonoBehaviour
{
    public DungeonData DungeonData;
    public DungeonState dungeon;
    private List<RoomData> _rooms = new();
    public List<RoomData> Room => _rooms;

    public static DungeonCore _instance;
    public static DungeonCore Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<DungeonCore>();
            }
            return _instance;
        }
    }
    
    public void NextRoom()
    {
        dungeon.ChangeState(GetRoom());
    }

    public DungeonBaseState GetRoom()
    {
        if (Room == null || Room.Count == 0)
            DungeonData.Generate(ref _rooms);
        RoomData roomData = Room[0];
        Room.RemoveAt(0);

        return roomData.type switch
        {
            RoomType.Empty => new DungeonEmptyRoomState(dungeon, roomData),
            RoomType.Chest => new DungeonChestRoomState(dungeon, roomData),
            RoomType.NPC => new DungeonNPCRoomState(dungeon, roomData),
            RoomType.Boss => new DungeonBossRoomState(dungeon, roomData),
            _ => null
        };
    }
}

public enum RoomType
{
    Empty,
    NPC,
    Chest,
    Boss
}