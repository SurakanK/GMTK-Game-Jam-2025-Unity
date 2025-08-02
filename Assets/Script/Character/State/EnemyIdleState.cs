using UnityEngine;

public class EnemyIdleState : CharacterBaseState
{
    public EnemyIdleState(BaseCharacter stateMachine) : base(stateMachine) { }

    public override void OnActive()
    {
        base.OnActive();
        BaseCharacter.entity.AnimationName = GameAnim.Idle;
    }

    public override void Update()
    {
        base.Update();
    }

    public override void OnEnded()
    {
        base.OnEnded();
    }
}