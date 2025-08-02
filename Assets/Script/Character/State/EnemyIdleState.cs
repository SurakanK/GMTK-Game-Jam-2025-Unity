using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class EnemyIdleState : CharacterBaseState
{
    public EnemyIdleState(BaseCharacter stateMachine) : base(stateMachine) { }
    public override void OnActive()
    {
        base.OnActive();
        Enemy.entity.AnimationState.SetAnimation(0, GameAnim.Idle, true);
        HashSet<string> highlightItem = Enemy.EnemyData.weaponWeakness.Select(e => e.DataId).ToHashSet();
        UIGameplayController.Instance.panelInventory.HighlightItem(highlightItem);

        if (!BaseGamePlay.Inventory.HasItem(highlightItem))
            Attack().Forget();
    }

    private async UniTask Attack()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        Enemy.AttackState();
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