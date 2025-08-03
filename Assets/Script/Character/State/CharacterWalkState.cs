using System;
using Cysharp.Threading.Tasks;
using Spine;
using UnityEngine;

public class CharacterWalkState : CharacterBaseState
{
    public CharacterWalkState(BaseCharacter stateMachine) : base(stateMachine) { }

    public override void OnActive()
    {
        base.OnActive();
        Player.entity.AnimationState.SetAnimation(0, GameAnim.Walk, true);
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