
using UnityEngine;

public partial class BaseCharacter
{
    private BaseCharacter _target;
    public BaseCharacter Target
    {
        get { return _target; }
        set { _target = value; }
    }

    public void Attack()
    {
        if (Target == null)
            return;

        float damage = CalculateDamage(Stats, Target.Stats).damage;
        Target.ReciveDamage(this, damage);
        ReciveDamageAoE(damage);
    }

    public void BulletHit(BaseCharacter attacker, StatsData weaponStats)
    {
        float damage = CalculateDamage(weaponStats, Stats).damage;
        ReciveDamage(attacker, damage);
    }

    public void ReciveDamage(BaseCharacter attacker, float damage)
    {
        if (damage <= 0)
            return;
            
        ApplyDamage(attacker, damage);
    }

    private void ReciveDamageAoE(float damage)
    {
        Enemy.ReciveDamage(this, damage);
    }

    protected virtual void ApplyDamage(BaseCharacter attacker, float damage)
    {
        if (damage <= 0)
            return;
        currentHealth -= Mathf.CeilToInt(damage);

        if (currentHealth <= 0)
        {
            if (IsEnemy())
                Enemy.DeadState();
            else
            if (attacker != null)
                attacker.Target = null;
        }
    }

    private (float damage, bool isCrit) CalculateDamage(StatsData weaponStats, StatsData targetStats)
    {
        // Hit chance
        if (!CalculateHitChance(weaponStats, targetStats))
            return (0f, false);

        float damage = CalculateAllDamage(weaponStats, targetStats);
        var crit = CalculateCritical(weaponStats, damage);
        return (crit.damage, crit.isCrit);
    }

    private bool CalculateHitChance(StatsData weaponStats, StatsData targetStats)
    {
        float denominator = weaponStats.accuracyRate + targetStats.evasionRate;
        if (denominator <= 0f)
            return false;

        float hitChance = Mathf.Clamp01(weaponStats.accuracyRate / denominator);
        if (hitChance <= 0f)
            return false;

        return Random.value <= hitChance;
    }

    private float CalculateAllDamage(StatsData weaponStats, StatsData targetStats)
    {
        float phys = Mathf.Max(weaponStats.physicalDamage.value - targetStats.physicalDefens, 0f);

        float fire = CalculateElementalDamage(
            weaponStats.fireDamage, targetStats.fireDefens,
            weaponStats.elementalDamage, targetStats.elementalDefens);

        float cold = CalculateElementalDamage(
            weaponStats.coldDamage, targetStats.coldDefens,
            weaponStats.elementalDamage, targetStats.elementalDefens);

        float lightning = CalculateElementalDamage(
            weaponStats.lightningDamage, targetStats.lightningDefens,
            weaponStats.elementalDamage, targetStats.elementalDefens);

        return phys + fire + cold + lightning;
    }

    private float CalculateElementalDamage(StatsRange baseDamage, float baseDefens, StatsRange elementalDamage, float elementalDefens)
    {
        if (baseDamage.value == 0f && elementalDamage.value == 0f)
            return 0f;

        float totalDamage = baseDamage.value + elementalDamage.value;
        float totalDefens = baseDefens + elementalDefens;
        return Mathf.Max(totalDamage - totalDefens, 0f);
    }

    private (float damage, bool isCrit) CalculateCritical(StatsData weaponStats, float damage)
    {
        bool isCrit = Random.value < weaponStats.criticalRate;
        if (isCrit)
            damage *= 1.5f;
        return (damage, isCrit);
    }

    public bool CanAttack()
    {
        return true;
    }
}