
using UnityEngine;

public partial class BaseEnemyCharacter : BaseCharacter
{
    public SpriteRenderer body;

    public void Initialized(EnemyData enemyData)
    {
        defaultData = enemyData;
        Initialize();

        if (body != null)
            body.sprite = enemyData.body;
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