using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "BaseBuff", menuName = "BaseBuff/RegenerateStamina", order = 0)]
public class RegenerateStamina : BaseBuff
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

            int curStamina = owner.currentStamina;
            int newStamina = Mathf.Clamp(curStamina + regenAmount, 0, owner.MaxStamina);
            if (curStamina != newStamina)
            {
                owner.currentStamina = newStamina;
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