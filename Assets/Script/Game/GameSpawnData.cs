using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSpawnData", menuName = "GameSpawnData", order = 0)]
public class GameSpawnData : ScriptableObject
{
    public List<SpawnData> enemysSpawnData = new List<SpawnData>();
    public List<Vector2> userSpawnPoint = new List<Vector2>();

    public GameSpawnData Clone()
    {
        return Instantiate(this);
    }
}

[Serializable]
public class SpawnData
{
    public int spawnId;
    public BaseObject baseObject;
    public List<Vector2> position;
    public int spawnAmount;
    public float delayTime;
    public bool avoidSpawnRepeat;
    public float spawnCooldown { get; set; }

    public static SpawnData Create()
    {
        return new SpawnData
        {
          
        };
    }

    private List<float> spawnCooldowns = new List<float>();
    private List<int> spawnPointHandle = new List<int>();

    private int _curAmount;
    public int curAmount
    {
        get => _curAmount;
        set
        {
            if (value < _curAmount && spawnCooldowns.Count < spawnAmount)
            {
                spawnCooldowns.Add(delayTime);
            }
            _curAmount = value;
        }
    }

    public int GetSpawnAount()
    {
        if (spawnCooldowns.Count > 0)
        {
            if (avoidSpawnRepeat)
                return 0;
                
            for (int i = spawnCooldowns.Count - 1; i >= 0; i--)
            {
                spawnCooldowns[i] -= 0.2f;
                if (spawnCooldowns[i] < 0)
                {
                    spawnCooldowns.RemoveAt(i);
                    spawnPointHandle.RemoveAt(i);
                    return 1;
                }
            }
            return 0;
        }
        return Mathf.Max(0, spawnAmount - curAmount);
    }

    public Vector3 GetRandomPosition()
    {
        List<int> pointEmpty = new List<int>();
        for (int i = 0; i < position.Count; i++)
        {
            if (!spawnPointHandle.Contains(i))
                pointEmpty.Add(i);
        }

        int randomIndex = pointEmpty[UnityEngine.Random.Range(0, pointEmpty.Count)];
        spawnPointHandle.Add(randomIndex);
        return position[randomIndex];
    }
}