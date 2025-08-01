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
        if (gameDataBase != null)
            gameDataBase.RegisterGameData(this);
    }

    [Header("Gameplay Rule")]
    public BaseGameRule gameRule;

    [Header("Game DataBase")]
    public GameDataBase gameDataBase;

    internal Dictionary<string, BaseBuff> buffs = new();
    internal Dictionary<string, BaseWeapon> weapons = new();
    internal Dictionary<string, ItemData> currency = new();
    internal Dictionary<string, ItemData> items = new();
    internal Dictionary<string, AbilityData> abilities = new();
    internal Dictionary<string, CharacterData> enemies = new();

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

                // Add item
                foreach (var pair in items)
                    _allItems[pair.Key] = pair.Value;
            }
            return _allItems;
        }
    }
}