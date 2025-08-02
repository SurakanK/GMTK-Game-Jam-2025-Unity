using Cysharp.Threading.Tasks;
using UnityEngine;

public class CharacterTakeDamageState : CharacterBaseState
{
    public CharacterTakeDamageState(BaseCharacter stateMachine) : base(stateMachine) { }

    public override void OnActive()
    {
        base.OnActive();
        if (Player.TryToGetBuff(out BuffBlockDamage buff))
            Player.RemoveBuff(buff);
        else
            Player.currentHealth -= 1;

        UIGameplayController.Instance.buttonLeave.gameObject.SetActive(true);
        UIGameplayController.Instance.buttonNext.gameObject.SetActive(Player.currentHealth > 0);
        UIGameplayController.Instance.panelCharacter.ShowFace().Forget();
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