using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class DungeonNPCRoomState : DungeonBaseState
{
    public DungeonNPCRoomState(DungeonState stateMachine, RoomData roomData) : base(stateMachine, roomData) { }

    public override void OnActive()
    {
        base.OnActive();
        DungeonState.player.gameObject.SetActive(true);
        DungeonState.enemy.gameObject.SetActive(false);
        DungeonState.chest.gameObject.SetActive(false);

        DungeonState.npc.gameObject.SetActive(true);
        DungeonState.npc.FadeIn(DungeonState, 0.2f);

        UIGameplayController.Instance.buttonNext.interactable = true;
        UIGameplayController.Instance.buttonLeave.interactable = true;
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

    public override async UniTask OnTransition()
    {
        await base.OnTransition();
        DungeonState.npc.FadeOut(DungeonState, 0.2f);
        SpawnItemManager.Instance.Clear();
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
        DungeonState.npc.gameObject.SetActive(false);
        base.OnEnded();
    }
}