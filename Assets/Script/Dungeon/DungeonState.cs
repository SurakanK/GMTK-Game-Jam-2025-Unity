using System.Collections.Generic;
using Spine.Unity;
using StatePatternInUnity;
using UnityEngine;

public class DungeonState : RoomStateMachine
{
    public SpriteRenderer caveBg;
    public SpriteRenderer npc;
    public SpriteRenderer chest;
    public BasePlayerCharacter player;
    public BaseEnemyCharacter enemy;
    public Transform bgTransform;
    public SkeletonAnimation BgCave;

    public void SetBgCave(SkeletonAnimation skBgCave)
    {
        if (BgCave != null)
            Destroy(BgCave.gameObject);
        BgCave = Instantiate(skBgCave, bgTransform);
    }

    public void BgWalk()
    {
        if (BgCave != null)
            BgCave.AnimationState.SetAnimation(0, GameAnim.Move, false);
    }
}