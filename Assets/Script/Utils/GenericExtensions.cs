using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class GenericExtensions
{
    public static Vector3 RandomPoint(this List<Vector2> spawnPoints)
    {
        return spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Count)];
    }

    public static TValue GetRandomValue<TKey, TValue>(this Dictionary<TKey, TValue> dict)
    {
        if (dict == null || dict.Count == 0)
            throw new InvalidOperationException("Dictionary is empty or null.");

        int index = UnityEngine.Random.Range(0, dict.Count);
        return dict.Values.ElementAt(index);
    }
}