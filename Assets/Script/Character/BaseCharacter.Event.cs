
using System;
using UnityEngine.Events;

public partial class BaseCharacter
{
    public UnityAction RemoveUIEvent;
    public UnityAction AnimAttackTriggerEvent;
    public UnityAction<StatsData> CurrentStatsChangeEvent;
    public UnityAction<int> CurrentHealthChangeEvent;
    public UnityAction<int> CurrentStaminaChangeEvent;
    public Action<InventoryItemData> EventNonEquipItemChanged;
}