using System;
using System.Collections.Generic;
using UnityEngine;

partial class PlayerData
{
    [Header("Player Debug")]
    public PlayerDebug playerDebug;

    public void InitializedDebug(BaseCharacter owner)
    {
        AddItemsStart(owner);
    }

    private void AddItemsStart(BaseCharacter owner)
    {
        if (playerDebug.itemsStartData.Count <= 0)
            return;
        for (int i = 0; i < playerDebug.itemsStartData.Count; i++)
        {
            PlayerItemStartData data = playerDebug.itemsStartData[i];
            ItemData item = data.itemData.Clone();
            item.amount = data.amount;
            BaseGamePlay.Inventory.IncreaseItem(item);
        }
    }
}

[Serializable]
public struct PlayerDebug
{
    public List<PlayerItemStartData> itemsStartData;
}

[Serializable]
public class PlayerItemStartData
{
    public ItemData itemData;
    public int amount;
}