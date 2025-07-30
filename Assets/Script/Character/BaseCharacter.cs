
using Newtonsoft.Json;
using UnityEngine;

public abstract partial class BaseCharacter : CharacterStateMachine
{
    [Header("Setting")]
    public CharacterData defaultData;

    [Header("Element")]
    public CharacterReferencePoints ReferencePoints;
    internal CharacterInventory Inventory;
    internal bool isAttacking = false;
    internal BaseEnemyCharacter Enemy => this as BaseEnemyCharacter;
    internal BasePlayerCharacter Player => this as BasePlayerCharacter;

    protected void Initialize()
    {
        Inventory = GetComponent<CharacterInventory>();

        ApplyStats();
    }

    protected virtual void SetAttacking(bool attacking)
    {
        this.isAttacking = attacking;
    }

    public bool IsCharacter()
    {
        return this is BasePlayerCharacter;
    }

    public bool IsEnemy()
    {
        return this is BaseEnemyCharacter;
    }

    public bool IsDead()
    {
        return IsCurrentState<CharacterDeadState>(out _);
    }

    public abstract void Dead();
    public T GetData<T>() where T : CharacterData
    {
        return defaultData as T;
    }
}