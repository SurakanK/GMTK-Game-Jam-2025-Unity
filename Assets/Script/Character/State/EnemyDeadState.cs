using System;
using System.Collections.Generic;
using System.Linq;
using Spine;
using UnityEngine;

public class EnemyDeadState : CharacterBaseState
{
    public EnemyDeadState(BaseCharacter stateMachine) : base(stateMachine) { }
    private BaseEnemyCharacter Enemy => BaseCharacter.Enemy;
    public override void OnActive()
    {
        base.OnActive();
        var anim = Enemy.entity.AnimationState.SetAnimation(0, GameAnim.Die, false);
        anim.Complete += OnFinishAnimation;
    }

    private void OnFinishAnimation(TrackEntry trackEntry)
    {
        Enemy.entity.FadeOut(Enemy, 0.2f);
        if (Enemy.EnemyData.itemDropData.TryGetDropTable(out DropTableItemData dropTable))
            SpawnItemManager.Instance.SpawnItem(dropTable.itemData);
        
        trackEntry.Complete -= OnFinishAnimation;
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