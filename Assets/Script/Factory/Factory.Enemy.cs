
using System.Collections.Generic;
using UnityEngine;

public partial class Factory
{
    private List<SpawnData> enemySpawn = new List<SpawnData>();

    private void InitializedEnemy()
    {

    }

    private void UpdateEnemySpawn()
    {
        foreach (SpawnData spawn in enemySpawn)
        {
            for (int i = 0; i < spawn.GetSpawnAount(); i++)
            {
                Spawn(spawn, spawn.baseObject, spawn.GetRandomPosition());
            }
        }
    }

    private void Spawn(SpawnData spawnData, BaseObject baseItem, Vector3 position)
    {
        if (!baseItem)
            return;

        if (baseItem.IsCharacter(out CharacterData characterData))
        {
           
        }
    }
}