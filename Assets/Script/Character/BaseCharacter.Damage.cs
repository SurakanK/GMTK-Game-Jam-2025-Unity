
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

        float damage = Stats.damage;
        Target.ReciveDamage(this, damage);
        ReciveDamageAoE(damage);
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
        
    }

    public bool CanAttack()
    {
        return true;
    }
}