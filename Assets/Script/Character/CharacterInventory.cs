using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BaseCharacter))]
public class CharacterInventory : MonoBehaviour
{
    public List<InventoryItemData> nonEquipItem = new();
    public BaseWeapon weaponSlotLeft;
    public ItemData weaponSlotRight;
    public ItemData helmetSlot;
    public ItemData armorSlot;
    public ItemData ringSlotLeft;
    public ItemData ringSlotRight;
}