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
    public int stack = int.MaxValue;
    public int sellPrice = 0;
    public int price = 0;

    [Header("SFX")]
    public AudioClip SpawnItem;
    public AudioClip ClickItem;
    public AudioClip UsingItem;
    public AudioClip Attack;

    public InventoryItemData inventoryItemData
    {
        get
        {
            return new InventoryItemData()
            {
                objectId = ObjectId,
                itemId = DataId,
                amount = 1,
            };
        }
    }

    public ItemData Clone()
    {
        return Instantiate(this);
    }
}