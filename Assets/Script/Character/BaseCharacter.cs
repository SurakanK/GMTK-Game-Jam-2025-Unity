
using Newtonsoft.Json;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract partial class BaseCharacter : CharacterStateMachine
{
    public int ClientId;

    [Header("Setting")]
    public CharacterData defaultData;

    [Header("Element")]
    public CharacterReferencePoints ReferencePoints;
    internal CharacterEquipment Equipment;
    internal CharacterInventory Inventory;
    internal Rigidbody2D Rigidbody2d;
    internal Vector2 direction;
    internal Vector2 LastDirection;
    internal bool isAttacking = false;
    internal BaseEnemyCharacter Enemy => this as BaseEnemyCharacter;
    internal BasePlayerCharacter Player => this as BasePlayerCharacter;

    protected void Initialize()
    {
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

    public void SpawnBullet()
    {
        Equipment?.WeaponSlotLeft?.SpawnBullet();
    }

    public abstract void Dead();
    public T GetData<T>() where T : CharacterData
    {
        return defaultData as T;
    }
}