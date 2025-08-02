using static CharacterStateMachine;
using StatePatternInUnity;
using UnityEngine;
using System;
using Cysharp.Threading.Tasks;

public abstract class DungeonBaseState : IRoomState
{
    protected readonly DungeonState DungeonState;
    protected readonly RoomData RoomData;

    public BaseEnemyCharacter Enemy => DungeonState.enemy;
    public BasePlayerCharacter Player => DungeonState.player;

    protected DungeonBaseState(DungeonState dungeonState, RoomData roomData)
    {
        DungeonState = dungeonState;
        RoomData = roomData;
        SetBgCave(roomData.caveBg);
    }

    private void SetBgCave(Sprite bgCave)
    {
        if (DungeonState.caveBg != null)
            DungeonState.caveBg.sprite = bgCave;
    }

    public override void OnInitialized()
    {
        base.OnInitialized();
    }

    public override void OnActive()
    {
        base.OnActive();
        Color color = Color.green;
        Debug.Log(string.Format("<color=#{0:X2}{1:X2}{2:X2}> Active state: </color> {3}", (byte)(color.r * 255f), (byte)(color.g * 255f), (byte)(color.b * 255f), this.GetType().FullName));
    }

    public override void OnEnded()
    {
        base.OnEnded();
        Color color = Color.red;
        Debug.Log(string.Format("<color=#{0:X2}{1:X2}{2:X2}> Ended state: </color> {3}", (byte)(color.r * 255f), (byte)(color.g * 255f), (byte)(color.b * 255f), this.GetType().FullName));
    }

    public override async UniTask OnTransition()
    {
        await base.OnTransition();
        Color color = Color.grey;
        Debug.Log(string.Format("<color=#{0:X2}{1:X2}{2:X2}> Transition State: </color> {3}", (byte)(color.r * 255f), (byte)(color.g * 255f), (byte)(color.b * 255f), this.GetType().FullName));
    }

    protected void ChangeState(IRoomState newState)
    {
        DungeonState.ChangeState(newState);
    }
}
