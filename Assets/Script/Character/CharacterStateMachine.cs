using System.Collections.Generic;
using System.Diagnostics;
using StatePatternInUnity;

public class CharacterStateMachine : StateMachine
{
    public enum PlayerStateType
    {
        Idle,
        Attack,
        TakeDamage,
        Dead,
    }

    public enum EnemyStateType
    {
        Idle,
        Attack,
        Dead,
    }

    public IState GetStateInstance(PlayerStateType type)
    {
        BaseCharacter baseCharacter = this as BaseCharacter;
        if (!baseCharacter)
            return null;

        return type switch
        {
            PlayerStateType.Idle => new CharacterIdleState(baseCharacter),
            PlayerStateType.Attack => new CharacterAttackState(baseCharacter),
            PlayerStateType.TakeDamage => new CharacterTakeDamageState(baseCharacter),
            PlayerStateType.Dead => new CharacterDeadState(baseCharacter),
            _ => null
        };
    }

    public IState GetStateInstance(EnemyStateType type)
    {
        BaseCharacter baseCharacter = this as BaseCharacter;
        if (!baseCharacter)
            return null;

        return type switch
        {
            EnemyStateType.Idle => new EnemyIdleState(baseCharacter),
            EnemyStateType.Attack => new EnemyAttackState(baseCharacter),
            EnemyStateType.Dead => new EnemyDeadState(baseCharacter),
            _ => null
        };
    }
}