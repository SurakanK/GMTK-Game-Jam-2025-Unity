using System;
using UnityEngine;

[Serializable]
public class DropTableItemData : BaseDropTable
{
    public int minDrop;
    public int maxDrop;
    public ItemData itemData;

    [Header("Setting")]
    public int OverrideAmount;
}