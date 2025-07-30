using UnityEngine;

public class CharacterDeadState : CharacterBaseState
{
    public CharacterDeadState(BaseCharacter stateMachine) : base(stateMachine) { }

    public override void OnActive()
    {
        base.OnActive();
        BaseCharacter.RemoveUIEvent?.Invoke();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void OnEnded()
    {
        base.OnEnded();
    }

    private void OnFinishedEvent()
    {
        BaseCharacter.Dead();
    }
}