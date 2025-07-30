using System;
using UnityEngine;
using UnityEngine.Events;

public class UIEquipment : UIBase
{
    [Header("Equipment Slot")]
    [SerializeField] private UIItemSlotEquipEntity _uiSlotWeaponLeft;
    [SerializeField] private UIItemSlotEquipEntity _uiSlotWeaponRight;
    [SerializeField] private UIItemSlotEquipEntity _uiSlotHelmet;
    [SerializeField] private UIItemSlotEquipEntity _uiSlotArmor;
    [SerializeField] private UIItemSlotEquipEntity _uiSlotRingLeft;
    [SerializeField] private UIItemSlotEquipEntity _uiSlotRingRight;

    private CharacterEquipment Equipment;

    public void Initialized()
    {
        if (GamePlayerCharacter.PlayerCharacter != null)
        {
            Equipment = GamePlayerCharacter.PlayerCharacter.Equipment;
            if (Equipment != null)
                OnEvent();
        }
    }

    private void OnEvent()
    {
        Equipment.OnChangeWeaponSlotLeft -= OnChangeWeaponSlotLeft;
        Equipment.OnChangeWeaponSlotLeft += OnChangeWeaponSlotLeft;

        Equipment.OnChangeWeaponSlotRight -= OnChangeWeaponSlotRight;
        Equipment.OnChangeWeaponSlotRight += OnChangeWeaponSlotRight;

        Equipment.OnChangeHelmetSlot -= OnChangeHelmetSlot;
        Equipment.OnChangeHelmetSlot += OnChangeHelmetSlot;

        Equipment.OnChangeArmorSlot -= OnChangeArmorSlot;
        Equipment.OnChangeArmorSlot += OnChangeArmorSlot;

        Equipment.OnChangeRingSlotLeft -= OnChangeRingSlotLeft;
        Equipment.OnChangeRingSlotLeft += OnChangeRingSlotLeft;

        Equipment.OnChangeRingSlotRight -= OnChangeRingSlotRight;
        Equipment.OnChangeRingSlotRight += OnChangeRingSlotRight;
    }

    private void OnChangeWeaponSlotLeft(BaseWeapon weapon)
    {
        if (weapon == null)
        {
            _uiSlotWeaponLeft.Data = new InventoryItemData();
            return;
        }
        _uiSlotWeaponLeft.Data = weapon.inventoryItemData;
    }

    private void OnChangeWeaponSlotRight(ItemData weapon)
    {
        throw new NotImplementedException();
    }

    private void OnChangeHelmetSlot(ItemData weapon)
    {
        throw new NotImplementedException();
    }

    private void OnChangeArmorSlot(ItemData weapon)
    {
        throw new NotImplementedException();
    }

    private void OnChangeRingSlotLeft(ItemData weapon)
    {
        throw new NotImplementedException();
    }

    private void OnChangeRingSlotRight(ItemData weapon)
    {
        throw new NotImplementedException();
    }
}