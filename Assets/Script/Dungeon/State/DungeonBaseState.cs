using static CharacterStateMachine;
using StatePatternInUnity;
using UnityEngine;

public abstract class DungeonBaseState : IState
{
    protected readonly DungeonState DungeonState;
    protected DungeonBaseState(DungeonState dungeonState)
    {
        DungeonState = dungeonState;
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

    protected void ChangeState(IState newState)
    {
        DungeonState.ChangeState(newState);
    }
}
