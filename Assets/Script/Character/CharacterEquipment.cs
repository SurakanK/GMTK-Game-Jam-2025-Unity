using UnityEngine;
using UnityEngine.Events;
using UnityEngine.U2D.Animation;

[RequireComponent(typeof(BaseCharacter))]
public class CharacterEquipment : MonoBehaviour
{
    [SerializeField] private SpriteResolver leftHandSprite;
    [SerializeField] private SpriteResolver rightHandSprite;

    public UnityAction<BaseWeapon> OnChangeWeaponSlotLeft;
    public UnityAction<ItemData> OnChangeWeaponSlotRight;
    public UnityAction<ItemData> OnChangeHelmetSlot;
    public UnityAction<ItemData> OnChangeArmorSlot;
    public UnityAction<ItemData> OnChangeRingSlotLeft;
    public UnityAction<ItemData> OnChangeRingSlotRight;

    private BaseCharacter _owner;
    public BaseWeapon WeaponSlotLeft
    {
        get => _owner.Inventory.weaponSlotLeft;
        set
        {
            if (value != null)
            _owner.Inventory.weaponSlotLeft = value;
            OnChangeWeaponSlotLeft?.Invoke(value);
        }
    }
    public ItemData WeaponSlotRight
    {
        get => _owner.Inventory.weaponSlotRight;
        set
        {
            _owner.Inventory.weaponSlotRight = value;
            OnChangeWeaponSlotRight?.Invoke(value);
        }
    }
    public ItemData HelmetSlot
    {
        get => _owner.Inventory.helmetSlot;
        set
        {
            _owner.Inventory.helmetSlot = value;
            OnChangeHelmetSlot?.Invoke(value);
        }
    }

    public ItemData ArmorSlot
    {
        get => _owner.Inventory.armorSlot;
        set
        {
            _owner.Inventory.armorSlot = value;
            OnChangeArmorSlot?.Invoke(value);
        }
    }
    public ItemData RingSlotLeft
    {
        get => _owner.Inventory.ringSlotLeft;
        set
        {
            _owner.Inventory.ringSlotLeft = value;
            OnChangeRingSlotLeft?.Invoke(value);
        }
    }
    public ItemData RingSlotRight
    {
        get => _owner.Inventory.ringSlotRight;
        set
        {
            _owner.Inventory.ringSlotRight = value;
            OnChangeRingSlotRight?.Invoke(value);
        }
    }

    void Awake()
    {
        _owner = GetComponent<BaseCharacter>();
    }

    public void EquipWeapon(BaseWeapon weapon)
    {
        if (weapon == null)
            return;

        if (WeaponSlotLeft != null)
            UnequipWeapon(weapon);

        if (!weapon.IsRangedWeapon())
        {
            WeaponSlotLeft = weapon;
        }
        else
        {
            WeaponSlotLeft = weapon;
        }
    }

    public void UnequipWeapon(BaseWeapon weapon)
    {
        WeaponSlotLeft = null;
    }
}

public enum HandSlot
{
    LeftHand,
    RightHand,
}

public enum SlotType
{
    None,
    Inventory,
    WeaponLeftHand,
    WeaponRightHand,
    Helmet,
    Armor,
    RingLeft,
    RingRight
}