using StatePatternInUnity;
using UnityEngine;

public class DungeonState : StateMachine
{
    public SpriteRenderer caveBg;
    public SpriteRenderer npc;
    public SpriteRenderer chest;
    public BasePlayerCharacter player;
    public BaseEnemyCharacter enemy;
}