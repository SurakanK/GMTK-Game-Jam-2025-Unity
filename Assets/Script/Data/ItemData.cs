using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Object Data/ItemData", order = 0)]
public class ItemData : BaseObject
{
    [Header("Drop Model")]
    public BaseItem prefab;

    [Header("Drop Setting")]
    public int min = 1;
    public int max = 1;

    [Header("Data")]
    public int amount = 0;
    public int stackAmount = int.MaxValue;

    [Header("Setting Currency")]
    public int softCurrency;
    public int hardCurrency;

    public  SlotType slotType = SlotType.None;
    public InventoryItemData inventoryItemData
    {
        get
        {
            return new InventoryItemData()
            {
                objectId = ObjectId,
                itemId = DataId,
                slotType = slotType,
                amount = 1,
            };
        }
    }

    public ItemData Clone()
    {
        return Instantiate(this);
    }
}