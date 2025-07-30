using System;
using UnityEngine;

public class CharacterIdleState : CharacterBaseState
{
    public CharacterIdleState(BaseCharacter stateMachine) : base(stateMachine) { }

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
    }
}