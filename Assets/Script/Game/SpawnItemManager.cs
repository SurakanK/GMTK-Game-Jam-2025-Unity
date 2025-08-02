using System.Collections.Generic;
using UnityEngine;

public class SpawnItemManager : MonoBehaviour
{
    public BaseItem itemDropPrefab;
    public Transform starPoint;
    public List<Transform> spawnPoint;
    private List<BaseItem> itemSpawned = new();

    public static SpawnItemManager _instance;
    public static SpawnItemManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<SpawnItemManager>();
            }
            return _instance;
        }
    }

    public void SpawnItem(ItemData data)
    {
        int curSpawn = Random.Range(0, spawnPoint.Count);
        Vector3 startPos = starPoint.position;
        Vector3 endPos = spawnPoint[curSpawn].position;
        Vector3 centerPos = startPos * 0.85f;

        QuadraticCurve curve = new QuadraticCurve(startPos, endPos, centerPos);
        BaseItem itemDrop = Instantiate(itemDropPrefab, startPos, Quaternion.identity);
        itemDrop.Launch(curve, 3);
        itemDrop.Initialized(data);
        itemSpawned.Add(itemDrop);
    }

    public void PickUpItem(BaseItem itemDrop)
    {
        Vector3 startPos = itemDrop.transform.position;
        Vector3 endPos = DungeonCore.Instance.dungeon.player.transform.position;
        Vector3 centerPos = (startPos + endPos) * 0.5f;

        QuadraticCurve curve = new QuadraticCurve(startPos, endPos, centerPos);
        itemDrop.Launch(curve, 4, () =>
        {
            itemSpawned.Remove(itemDrop);
            Destroy(itemDrop.gameObject);
            BaseGamePlay.Inventory.IncreaseItem(itemDrop.itemData);
        });
    }
}