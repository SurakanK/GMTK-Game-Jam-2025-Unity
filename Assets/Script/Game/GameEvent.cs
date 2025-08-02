using System;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    public Action<int> EventLevelChange;
    public Action<int> EventCurrencyChange;
    public Action<int> EventOutstandingChange;
    public Action<int, int> EventHealthChange;
    public Action<List<BaseBuff>> EventBuffChange;

    public Action<bool> EventDragging;
    public Action EventNonEquipItemChanged;

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
}

