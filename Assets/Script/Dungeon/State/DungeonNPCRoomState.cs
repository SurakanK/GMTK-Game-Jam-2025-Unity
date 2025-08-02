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

        ShowItem();
    }

    private void ShowItem()
    {
        for (int i = 0; i < 3; i++)
        {
            if (RoomData.itemDropData.TryGetDropTable(out DropTableItemData dropTable))
                SpawnItemManager.Instance.ShowItem(dropTable.itemData, i);
        }
    }

    public override void Update()
    {
        base.Update();
    }

    public override void OnEnded()
    {
        base.OnEnded();
        SpawnItemManager.Instance.Clear();
    }
}