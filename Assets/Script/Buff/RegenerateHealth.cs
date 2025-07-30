using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "BaseBuff", menuName = "BaseBuff/RegenerateHealth", order = 0)]
public class RegenerateHealth : BaseBuff
{
    public int regenAmount = 5;

    public override void Apply(BaseCharacter target)
    {
        owner = target;
        Interval().Forget();
    }

    private async UniTaskVoid Interval()
    {
        float elapsed = 0f;
        float tickInterval = Mathf.Max(0.01f, tickRateEffect);

        while (elapsed < duration || duration == 0)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(tickInterval));

            int curHealth = owner.currentHealth;
            int newHealth = Mathf.Clamp(curHealth + regenAmount, 0, owner.MaxHealth);
            if (curHealth != newHealth)
            {
                owner.currentHealth = newHealth;
            }

            elapsed += tickInterval;
        }

        Remove();
    }

    public override void Remove()
    {
        owner.RemoveBuff(this);
    }
}