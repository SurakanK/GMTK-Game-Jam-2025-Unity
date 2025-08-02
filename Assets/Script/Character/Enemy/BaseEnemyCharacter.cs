
using UnityEngine;

public partial class BaseEnemyCharacter : BaseCharacter
{
    public void Initialized(EnemyData enemyData)
    {
        defaultData = enemyData;
        Initialize();
        SpawnEntity();
        IdleState();
    }

    public void IdleState()
    {
        ChangeState(GetStateInstance(EnemyStateType.Idle));
    }

    public void AttackState()
    {
        ChangeState(GetStateInstance(EnemyStateType.Attack));
    }

    public void DeadState()
    {
        ChangeState(GetStateInstance(PlayerStateType.Dead));
    }

    public override void Dead()
    {
        Factory.Instance.Destroy(this);
    }
}