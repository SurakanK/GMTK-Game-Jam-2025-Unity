using System.Collections.Generic;
using UnityEngine;

public partial class Factory : MonoBehaviour
{
    private GameSpawnData _gameSpawnData;
    public static Factory _instance;
    public static Factory Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<Factory>();
            }
            return _instance;
        }
    }

    void Start()
    {
        Initialized();
    }

    private void Initialized()
    {
        _gameSpawnData = GameInstance.Instance.gameSpawnData.Clone();
        InitializedEnemy();
    }

    private void UpdateSpawn()
    {
        UpdateEnemySpawn();
    }

    public void Destroy(BaseCharacter entity)
    {
     
    }
}
