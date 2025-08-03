using System.Collections.Generic;
using UnityEngine;

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

    public static SoundManager Sound;

    private void Awake()
    {
        if (gameDataBase != null)
            gameDataBase.RegisterGameData(this);
        BaseGamePlay.Instance.Initialized();
        Sound = gameObject.AddComponent<SoundManager>();
    }

    [Header("Gameplay Rule")]
    public BaseGameRule gameRule;

    [Header("Game DataBase")]
    public GameDataBase gameDataBase;

    internal Dictionary<string, BaseBuff> buffs = new();
    internal Dictionary<string, BaseWeapon> weapons = new();
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