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

    private readonly Dictionary<System.Type, EnemyStateType> EnemyStateMap = new()
    {
        { typeof(EnemyIdleState), EnemyStateType.Idle },
        { typeof(EnemyAttackState), EnemyStateType.Attack },
    };

    private readonly Dictionary<System.Type, PlayerStateType> PlayerStateMap = new()
    {
        { typeof(CharacterIdleState), PlayerStateType.Idle },
        { typeof(CharacterAttackState), PlayerStateType.Attack },
        { typeof(CharacterDeadState), PlayerStateType.Dead },
    };

    public IState GetStateInstance(PlayerStateType type)
    {
        BaseCharacter baseCharacter = this as BaseCharacter;
        if (!baseCharacter)
            return null;

        return type switch
        {
            PlayerStateType.Idle => new CharacterIdleState(baseCharacter),
            PlayerStateType.Attack => new CharacterAttackState(baseCharacter),
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

    public EnemyStateType GetEnemyStateType()
    {
        if (State == null) return EnemyStateType.Idle;

        var type = State.GetType();
        if (EnemyStateMap.TryGetValue(type, out var result))
            return result;

        return EnemyStateType.Idle;
    }

    public PlayerStateType GetPlayerStateType()
    {
        if (State == null) return PlayerStateType.Idle;

        var type = State.GetType();
        if (PlayerStateMap.TryGetValue(type, out var result))
            return result;

        return PlayerStateType.Idle;
    }
}