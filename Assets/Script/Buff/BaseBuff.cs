using UnityEngine;

public abstract class BaseBuff : GameData
{
    [Header("Buff Settings")]
    public float duration;
    public float tickRateEffect;
    public StatsData stats;
    protected BaseCharacter owner;

    public abstract void Apply(BaseCharacter target);
    public abstract void Remove();

    public BaseBuff Clone()
    {
        return Instantiate(this);
    }
}
