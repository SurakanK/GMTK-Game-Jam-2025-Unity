using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public partial class BaseEnemyCharacter : BaseCharacter
{
    [Header("Follow Setting")]
    public bool avoidFollowEnemy;
    public float followBackDistance;

    [Header("Chase Setting")]
    public bool avoidChaseEnemy;
    public float chaseBackDistance;

    void Awake()
    {
     
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