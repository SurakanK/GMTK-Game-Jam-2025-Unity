using System;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    public Action<bool> EventDragging;
    public Action<InventoryItemData> EventNonEquipItemChanged;

    public static GameEvent _instance;
    public static GameEvent Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<GameEvent>();
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
}

