
using System;
using UnityEngine.Events;

public partial class BaseCharacter
{
    public UnityAction RemoveUIEvent;
    public UnityAction AnimAttackTriggerEvent;

    public UnityAction<BaseCharacter> TargetChangeEvent;
    public UnityAction<StatsData> CurrentStatsChangeEvent;
    public UnityAction<int> CurrentHealthChangeEvent;
    public UnityAction<int> CurrentStaminaChangeEvent;
    public Action<InventoryItemData> EventNonEquipItemChanged;

    private void OnCharacterEvent()
    {
       
    }

    private void OnTargetOnChange(BaseCharacter next)
    {
        TargetChangeEvent?.Invoke(next);
    }

    private void OnCurrentStstsChange(StatsData next)
    {
        CurrentStatsChangeEvent?.Invoke(next);
    }

    private void OnCurrentHealthChange(int next)
    {
        CurrentHealthChangeEvent?.Invoke(next);
    }

    private void OnCurrentStaminaChange(int next)
    {
        CurrentStaminaChangeEvent?.Invoke(next);
    }

    private void OnNonEquipItemChanged(InventoryItemData next)
    {
        EventNonEquipItemChanged?.Invoke(next);
    }

    private void OnWeaponSlotLeftChanged(InventoryItemData next)
    {
        if (WeaponExtensions.TryGetWeapon(this, next.itemId, out BaseWeapon baseWeapon))
        {
            baseWeapon.ObjectId = next.objectId;
            Equipment.EquipWeapon(baseWeapon);
        }
    }

    private void OnWeaponSlotRightChanged(InventoryItemData next)
    {
    }

    private void OnHelmetSlotChanged(InventoryItemData next)
    {
    }

    private void OnArmorSlotChanged(InventoryItemData next)
    {
    }

    private void OnRingSlotLeftChanged(InventoryItemData next)
    {
    }

    private void OnRingSlotRightChanged(InventoryItemData next)
    {
    }
}