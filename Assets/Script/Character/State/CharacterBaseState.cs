using static CharacterStateMachine;
using StatePatternInUnity;
using UnityEngine;

public abstract class CharacterBaseState : IState
{
    protected readonly BaseCharacter BaseCharacter;
    protected BasePlayerCharacter Player => DungeonCore.Instance.dungeon.player;
    protected BaseEnemyCharacter Enemy => DungeonCore.Instance.dungeon.enemy;

    protected CharacterBaseState(BaseCharacter baseCharacter)
    {
        BaseCharacter = baseCharacter;
    }

    public override void OnInitialized()
    {
        base.OnInitialized();
    }

    public override void OnActive()
    {
        base.OnActive();
        Color color = Color.yellow;
        Debug.Log(string.Format("<color=#{0:X2}{1:X2}{2:X2}> Active state: </color> {3}", (byte)(color.r * 255f), (byte)(color.g * 255f), (byte)(color.b * 255f), this.GetType().FullName));
    }

    public override void OnEnded()
    {
        base.OnEnded();
        Color color = Color.magenta;
        Debug.Log(string.Format("<color=#{0:X2}{1:X2}{2:X2}> Ended state: </color> {3}", (byte)(color.r * 255f), (byte)(color.g * 255f), (byte)(color.b * 255f), this.GetType().FullName));
    }

    protected IState GetStateInstance(PlayerStateType state)
    {
        return BaseCharacter.GetStateInstance(state);
    }

    protected IState GetStateInstance(EnemyStateType state)
    {
        return BaseCharacter.GetStateInstance(state);
    }

    protected void ChangeState(IState newState)
    {
        BaseCharacter.ChangeState(newState);
    }
}
