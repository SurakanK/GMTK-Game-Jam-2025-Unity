using System.Collections.Generic;
using UnityEngine;

public class DungeonCore : MonoBehaviour
{
    public DungeonData DungeonData;
    
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

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        DungeonData.Generate(ref _rooms);
    }
}

public enum RoomType
{
    Empty,
    NPC,
    Chest,
    Boss
}