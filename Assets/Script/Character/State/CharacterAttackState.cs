using UnityEngine;

public class CharacterAttackState : CharacterBaseState
{
    public CharacterAttackState(BaseCharacter stateMachine) : base(stateMachine) { }

    public override void OnActive()
    {
        base.OnActive();

    }

    public override void Update()
    {
        base.Update();
    }

    public override void OnEnded()
    {
        base.OnEnded();
        BaseCharacter.AnimAttackTriggerEvent -= OnAnimAttackTriggerEvent;
        BaseCharacter.isAttacking = false;
    }

    private void OnAnimAttackTriggerEvent()
    {
        BaseCharacter.AnimAttackTriggerEvent -= OnAnimAttackTriggerEvent;
    }

    private void OnFinishedEvent()
    {
        if (BaseCharacter.isAttacking)
        {
            OnActive();
            return;
        }
    }
}