using System.Collections.Generic;
using UnityEngine;

public static class GenericExtensions
{
    public static Vector3 RandomPoint(this List<Vector2> spawnPoints)
    {
        return spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Count)];
    }
}