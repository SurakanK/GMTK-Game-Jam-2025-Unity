using UnityEngine;

public class DungeonChestRoomState : DungeonBaseState
{
    public DungeonChestRoomState(DungeonState stateMachine, RoomData roomData) : base(stateMachine, roomData) { }

    public override void OnActive()
    {
        base.OnActive();
        DungeonState.player.gameObject.SetActive(true);
        DungeonState.enemy.gameObject.SetActive(false);
        DungeonState.npc.gameObject.SetActive(false);
        DungeonState.chest.gameObject.SetActive(true);
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