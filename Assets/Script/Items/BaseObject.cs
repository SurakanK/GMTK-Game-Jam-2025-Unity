public class BaseObject : GameData
{
    public bool IsCharacter(out CharacterData characterData)
    {
        characterData = this as CharacterData;
        return characterData != null;
    }

    public bool IsItem(out ItemData itemData)
    {
        itemData = this as ItemData;
        return itemData != null && itemData.GetType() == typeof(ItemData);
    }

    public bool IsWeapon(out BaseWeapon weaponData)
    {
        weaponData = this as BaseWeapon;
        return weaponData != null;
    }
}