using System;
using UnityEngine;

[Serializable]
public struct StatsData
{
    [Header("General")]
    public int maxHealth;
    public int maxStamina;
    public float moveSpeed;

    [Header("Damage")]
    public StatsRange physicalDamage;
    public StatsRange fireDamage;
    public StatsRange coldDamage;
    public StatsRange lightningDamage;
    public StatsRange elementalDamage;

    [Header("Defense")]
    public float physicalDefens;
    public float fireDefens;
    public float coldDefens;
    public float lightningDefens;
    public float elementalDefens;

    [Header("Rate")]
    public float atkRate;
    public float atkArea;
    public float criticalRate;
    public float accuracyRate;
    public float evasionRate;

    [Header("Status")]
    public bool isCanRespawn;

    public void Apply(BaseCharacter owner)
    {
        owner.Stats = owner.Stats + this;
        owner.currentHealth = maxHealth;
        owner.currentStamina = maxStamina;
    }

    public static StatsData operator +(StatsData a, StatsData b)
    {
        return new StatsData
        {
            maxHealth = a.maxHealth + b.maxHealth,
            maxStamina = a.maxStamina + b.maxStamina,
            moveSpeed = a.moveSpeed + b.moveSpeed,

            physicalDamage = a.physicalDamage + b.physicalDamage,
            fireDamage = a.fireDamage + b.fireDamage,
            coldDamage = a.coldDamage + b.coldDamage,
            lightningDamage = a.lightningDamage + b.lightningDamage,
            elementalDamage = a.elementalDamage + b.elementalDamage,

            physicalDefens = a.physicalDefens + b.physicalDefens,
            fireDefens = a.fireDefens + b.fireDefens,
            coldDefens = a.coldDefens + b.coldDefens,
            lightningDefens = a.lightningDefens + b.lightningDefens,
            elementalDefens = a.elementalDefens + b.elementalDefens,

            atkRate = a.atkRate + b.atkRate,
            atkArea = a.atkArea + b.atkArea,
            criticalRate = a.criticalRate + b.criticalRate,
            accuracyRate = a.accuracyRate + b.accuracyRate,
            evasionRate = a.evasionRate + b.evasionRate,

            isCanRespawn = a.isCanRespawn | b.isCanRespawn,
        };
    }

    public static StatsData operator -(StatsData a, StatsData b)
    {
        return new StatsData
        {
            maxHealth = a.maxHealth - b.maxHealth,
            maxStamina = a.maxStamina - b.maxStamina,
            moveSpeed = a.moveSpeed - b.moveSpeed,

            physicalDamage = a.physicalDamage - b.physicalDamage,
            fireDamage = a.fireDamage - b.fireDamage,
            coldDamage = a.coldDamage - b.coldDamage,
            lightningDamage = a.lightningDamage - b.lightningDamage,
            elementalDamage = a.elementalDamage - b.elementalDamage,

            physicalDefens = a.physicalDefens - b.physicalDefens,
            fireDefens = a.fireDefens - b.fireDefens,
            coldDefens = a.coldDefens - b.coldDefens,
            lightningDefens = a.lightningDefens - b.lightningDefens,
            elementalDefens = a.elementalDefens - b.elementalDefens,

            atkRate = a.atkRate - b.atkRate,
            atkArea = a.atkArea - b.atkArea,
            criticalRate = a.criticalRate - b.criticalRate,
            accuracyRate = a.accuracyRate - b.accuracyRate,
            evasionRate = a.evasionRate - b.evasionRate,

            isCanRespawn = a.isCanRespawn && !b.isCanRespawn,
        };
    }
}

[Serializable]
public struct StatsRange
{
    public float min;
    public float max;
    public float value
    {
        get
        {
            return GetRandom();
        }
    }

    public StatsRange(float min, float max)
    {
        this.min = min;
        this.max = max;
    }

    public float GetRandom()
    {
        return UnityEngine.Random.Range(min, max);
    }

    public static StatsRange operator +(StatsRange a, StatsRange b)
    {
        return new StatsRange(a.min + b.min, a.max + b.max);
    }

    public static StatsRange operator -(StatsRange a, StatsRange b)
    {
        return new StatsRange(a.min - b.min, a.max - b.max);
    }
}