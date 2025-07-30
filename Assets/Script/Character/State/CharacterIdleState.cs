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
        BaseCharacter.Rigidbody2d.velocity = Vector2.zero;
    }

    public override void OnEnded()
    {
        base.OnEnded();
    }
}