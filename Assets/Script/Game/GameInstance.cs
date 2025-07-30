using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameInstance : MonoBehaviour
{
    public static GameInstance _instance;
    public static GameInstance Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<GameInstance>();
            }
            return _instance;
        }
    }

    public static BaseGameRule GameRule => Instance.gameRule;
    public static Dictionary<string, ItemData> AllItems => Instance.allItems;

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
        if (gameDataBase != null)
        {
            gameDataBase.RegisterGameData(this);
        }

        if (GameObject.FindWithTag(GameTag.VegetableTilemap).TryGetComponent(out Tilemap tilemap))
        {
            vegetableTilemap = tilemap;
        }
    }

    [Header("Gameplay Rule")]
    public BaseGameRule gameRule;

    [Header("Game DataBase")]
    public GameDataBase gameDataBase;

    [Header("Spawn Data")]
    public GameSpawnData gameSpawnData;

    internal Tilemap vegetableTilemap;

    internal Dictionary<string, BaseBuff> buffs = new();
    internal Dictionary<string, BaseWeapon> weapons = new();
    internal Dictionary<string, ItemData> currency = new();
    internal Dictionary<string, AbilityData> abilities = new();

    private Dictionary<string, ItemData> _allItems;
    public Dictionary<string, ItemData> allItems
    {
        get
        {
            if (_allItems == null)
            {
                _allItems = new();

                // Add all currency
                foreach (var pair in currency)
                    _allItems[pair.Key] = pair.Value;

                // Add weapons
                 foreach (var pair in weapons)
                    _allItems[pair.Key] = pair.Value;
            }
            return _allItems;
        }
    }
}