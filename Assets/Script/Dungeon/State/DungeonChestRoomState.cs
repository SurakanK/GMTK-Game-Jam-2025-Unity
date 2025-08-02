using System;
using Cysharp.Threading.Tasks;
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

        UIGameplayController.Instance.buttonLeave.gameObject.SetActive(true);
        UIGameplayController.Instance.buttonNext.gameObject.SetActive(Player.currentHealth > 0);

        if (RoomData.itemDropData.TryGetDropTable(out DropTableItemData dropTable))
            SpawnItemManager.Instance.SpawnItem(dropTable.itemData);
    }

    public override void Update()
    {
        base.Update();
    }

    public override async UniTask OnTransition()
    {
        await base.OnTransition();

        if (TransitionController.Instance != null)
        {
            await TransitionController.Instance.TriggerFadeOutTransition();
        }
        else
        {
            Debug.LogWarning("TransitionController.Instance is null!");
        }
    }



    public override void OnEnded()
    {
        SpawnItemManager.Instance.Clear();
    }
}