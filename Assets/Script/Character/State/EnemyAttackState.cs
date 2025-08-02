using System;
using Cysharp.Threading.Tasks;
using Spine;

public class EnemyAttackState : CharacterBaseState
{
    public EnemyAttackState(BaseCharacter stateMachine) : base(stateMachine) { }

    public override void OnActive()
    {
        base.OnActive();
        var anim = Enemy.entity.AnimationState.SetAnimation(0, GameAnim.Attack, false);
        Attack().Forget();
        anim.Complete += OnFinishAnimation;
    }

    private void OnFinishAnimation(TrackEntry trackEntry)
    {
        Enemy.entity.FadeOut(Enemy, 0.2f);
        trackEntry.Complete -= OnFinishAnimation;
    }

    private async UniTask Attack()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(0.4f));
        Player.TakeDamageState();
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