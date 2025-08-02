using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class DungeonBossRoomState : DungeonBaseState
{
    public DungeonBossRoomState(DungeonState stateMachine, RoomData roomData) : base(stateMachine, roomData) { }
    public EnemyData enemyData;

    public override void OnActive()
    {
        base.OnActive();
        DungeonState.player.gameObject.SetActive(true);
        DungeonState.enemy.gameObject.SetActive(true);
        DungeonState.npc.gameObject.SetActive(false);
        DungeonState.chest.gameObject.SetActive(false);
        SpawnEnemy();
    }

    public override void Update()
    {
        base.Update();
    }

    public override async UniTask OnTransition()
    {
        await base.OnTransition();
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
    }

    public override void OnEnded()
    {
        base.OnEnded();
        SpawnItemManager.Instance.Clear();
    }

    private void SpawnEnemy()
    {
        CharacterData randomEnemy = GameInstance.Instance.enemies.GetRandomValue();
        if (randomEnemy is not EnemyData enemyData)
            return;
        this.enemyData = enemyData;
        DungeonState.enemy.Initialized(enemyData);
    }

    public void PlayerAttack()
    {
        Player.AttackState();
        Enemy.DeadState();
    }
}