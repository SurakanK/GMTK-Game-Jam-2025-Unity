using UnityEngine;

public class DungeonNPCRoomState : DungeonBaseState
{
    public DungeonNPCRoomState(DungeonState stateMachine, RoomData roomData) : base(stateMachine, roomData) { }

    public override void OnActive()
    {
        base.OnActive();
        DungeonState.player.gameObject.SetActive(true);
        DungeonState.enemy.gameObject.SetActive(false);
        DungeonState.npc.gameObject.SetActive(true);
        DungeonState.chest.gameObject.SetActive(false);

        UIGameplayController.Instance.buttonLeave.gameObject.SetActive(true);
        UIGameplayController.Instance.buttonNext.gameObject.SetActive(Player.currentHealth > 0);
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