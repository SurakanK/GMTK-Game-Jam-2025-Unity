using System.Collections.Generic;
using StatePatternInUnity;
using UnityEngine;

public class DungeonState : RoomStateMachine
{
    public SpriteRenderer caveBg;
    public SpriteRenderer npc;
    public SpriteRenderer chest;
    public BasePlayerCharacter player;
    public BaseEnemyCharacter enemy;    
}