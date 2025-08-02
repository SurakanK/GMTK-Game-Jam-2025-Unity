
using UnityEngine;

public partial class BaseEnemyCharacter : BaseCharacter
{
    public EnemyData EnemyData;
    public void Initialized(EnemyData enemyData)
    {
        EnemyData = enemyData;
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
        ChangeState(GetStateInstance(EnemyStateType.Dead));
    }

    public override void Dead()
    {
        Factory.Instance.Destroy(this);
    }
}