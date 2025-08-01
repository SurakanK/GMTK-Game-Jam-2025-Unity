using System;
using UnityEngine;

[Serializable]
public struct StatsData
{
    [Header("General")]
    public int maxHealth;
    public int damage;
    public float sellPriceRate;
    public float blockDamage;
    public float dungeonFee;

    public void Apply(BaseCharacter owner)
    {
        owner.Stats = owner.Stats + this;
        owner.currentHealth = maxHealth;
    }

    public static StatsData operator +(StatsData a, StatsData b)
    {
        return new StatsData
        {
            maxHealth = a.maxHealth + b.maxHealth,
            damage = a.damage + b.damage,
            sellPriceRate = a.sellPriceRate + b.sellPriceRate,
            blockDamage = a.blockDamage + b.blockDamage,
            dungeonFee = a.dungeonFee + b.dungeonFee,
        };
    }

    public static StatsData operator -(StatsData a, StatsData b)
    {
        return new StatsData
        {
            maxHealth = a.maxHealth - b.maxHealth,
            damage = a.damage - b.damage,
            sellPriceRate = a.sellPriceRate - b.sellPriceRate,
            blockDamage = a.blockDamage - b.blockDamage,
            dungeonFee = a.dungeonFee - b.dungeonFee,
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