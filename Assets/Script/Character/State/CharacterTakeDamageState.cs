using UnityEngine;

public class CharacterTakeDamageState : CharacterBaseState
{
    public CharacterTakeDamageState(BaseCharacter stateMachine) : base(stateMachine) { }

    public override void OnActive()
    {
        base.OnActive();
        if (Player.TryToGetBuff(out BuffBlockDamage buff))
        {
            Player.RemoveBuff(buff);
            return;
        }
        Player.currentHealth -= 1;
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