using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class DungeonEmptyRoomState : DungeonBaseState
{
    public DungeonEmptyRoomState(DungeonState stateMachine, RoomData roomData) : base(stateMachine, roomData) { }

    public override void OnActive()
    {
        base.OnActive();
        DungeonState.player.gameObject.SetActive(true);
        DungeonState.enemy.gameObject.SetActive(false);
        DungeonState.npc.gameObject.SetActive(false);
        DungeonState.chest.gameObject.SetActive(false);

        UIGameplayController.Instance.buttonLeave.gameObject.SetActive(true);
    }

    public override void Update()
    {
        base.Update();
    }

    public override async UniTask OnTransition()
    {
        await base.OnTransition();
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
    }

    public override void OnEnded()
    {
        base.OnEnded();
    }

}