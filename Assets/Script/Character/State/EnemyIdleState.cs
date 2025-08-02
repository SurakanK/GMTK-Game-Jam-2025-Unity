using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyIdleState : CharacterBaseState
{
    public EnemyIdleState(BaseCharacter stateMachine) : base(stateMachine) { }
    private BaseEnemyCharacter Enemy => BaseCharacter.Enemy;
    public override void OnActive()
    {
        base.OnActive();
        Enemy.entity.AnimationState.SetAnimation(0, GameAnim.Idle, true);
        HashSet<string> highlightItem = Enemy.EnemyData.weaponWeakness.Select(e => e.DataId).ToHashSet();
        UIGameplayController.Instance.panelInventory.HighlightItem(highlightItem);
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