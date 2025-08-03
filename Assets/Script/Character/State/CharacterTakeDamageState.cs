using System;
using Cysharp.Threading.Tasks;
using Spine;
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

        var anim = Player.entity.AnimationState.SetAnimation(0, GameAnim.Hit, false);
        anim.Complete += OnFinishAnimation;
        UIGameplayController.Instance.buttonLeave.gameObject.SetActive(true);
        UIGameplayController.Instance.buttonNext.gameObject.SetActive(Player.currentHealth > 0);
        UIGameplayController.Instance.panelCharacter.ShowFace().Forget();
    }

    private void OnFinishAnimation(TrackEntry trackEntry)
    {
        Player.IdleState();
        ShowSummary();
        trackEntry.Complete -= OnFinishAnimation;
    }

    public void ShowSummary()
    {
        if (Player.currentHealth <= 0)
            UIGameSummary.Instance.Show();
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