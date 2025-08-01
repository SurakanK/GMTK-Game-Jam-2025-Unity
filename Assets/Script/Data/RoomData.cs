using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoomData", menuName = "Object Data/RoomData", order = 0)]
public class RoomData : BaseObject
{
    public RoomType type;
    public Sprite caveBg;
    public List<DropTableItemData> itemDropData;
}
