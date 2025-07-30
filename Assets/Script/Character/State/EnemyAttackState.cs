using Cysharp.Threading.Tasks;
using UnityEngine;
using System.Threading;
using System;

public class EnemyAttackState : CharacterBaseState
{
    public EnemyAttackState(BaseCharacter stateMachine) : base(stateMachine) { }
    private BaseEnemyCharacter Enemy => BaseCharacter.Enemy;

    public override void OnActive()
    {
        base.OnActive();
        BaseCharacter.AnimAttackTriggerEvent += OnAnimAttackTriggerEvent;
        Attacking();
    }

    private void Attacking()
    {
        BaseCharacter.isAttacking = true;
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
        Weapon.Attack();
    }

    private void OnFinishedEvent()
    {
        if (BaseCharacter.CanAttack())
        {
            Attacking();
            return;
        }
    }
}