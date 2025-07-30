using UnityEngine;

public class CharacterAttackState : CharacterBaseState
{
    public CharacterAttackState(BaseCharacter stateMachine) : base(stateMachine) { }

    public override void OnActive()
    {
        base.OnActive();

        // no equip weapons
        if (Equipment.WeaponSlotLeft == null)
        {
            ChangeDefaultState();
            return;
        }

        BaseCharacter.Rigidbody2d.velocity = Vector2.zero;
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
        Weapon.Attack();
    }

    private void OnFinishedEvent()
    {
        if (BaseCharacter.isAttacking)
        {
            OnActive();
            return;
        }
        ChangeDefaultState();
    }
}