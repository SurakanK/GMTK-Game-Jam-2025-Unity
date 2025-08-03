using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class BaseGamePlay : MonoBehaviour
{
    public static bool isGameStart;
    private static int _level = 1;
    public static int Level
    {
        get { return _level; }
        set
        {
            _level = value;
            GameEvent.Instance.EventLevelChange?.Invoke(_level);
        }
    }

    private static int _devel = 1;
    public static int Day
    {
        get { return _devel; }
        set
        {
            _devel = value;
            GameEvent.Instance.EventDayChange?.Invoke(_devel);
        }
    }

    private static int _currency;
    public static int Currency
    {
        get { return _currency; }
        set
        {
            _currency = value;
            GameEvent.Instance.EventCurrencyChange?.Invoke(_currency);
        }
    }

    private static int _outstanding;
    public static int Outstanding
    {
        get { return _outstanding; }
        set
        {
            _outstanding = value;
            GameEvent.Instance.EventOutstandingChange?.Invoke(_outstanding);
        }
    }


    private static CharacterInventory _inventory;
    public static CharacterInventory Inventory
    {
        get
        {
            if (_inventory == null)
                _inventory = FindAnyObjectByType<CharacterInventory>();
            return _inventory;
        }
    }

    public static BaseGamePlay _instance;
    public static BaseGamePlay Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<BaseGamePlay>();
            }
            return _instance;
        }
    }

    public void Initialized()
    {
        if (GameInstance.Instance.gameRule == null)
            return;

        RestartGame();

        UIGameplayController.Instance.panelInventory.Initialized();
        UIGameplayController.Instance.panelCharacter.Initialized();
    }

    public async void OnClickGoToCave()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(1.2f));
        UIManager.Instance.GoToCave();
        DungeonCore.Instance.NextRoom();
    }

    public void RestartGame()
    {
        Day = 0;
        DungeonCore.Instance.dungeon.player.InitializePlayer();
        Level = GameInstance.Instance.gameRule.StartLevel;
        Currency = GameInstance.Instance.gameRule.StartCurrency;
        Outstanding = GameInstance.Instance.gameRule.Outstanding;
        Inventory.curSlot = GameInstance.Instance.gameRule.LimitSlot;
    }
}