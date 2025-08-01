using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "BaseBuff", menuName = "BaseBuff/BuffBlockDamage", order = 0)]
public class BuffBlockDamage : BaseBuff
{
    public override void Apply(BaseCharacter target)
    {
        owner = target;
        owner.Stats += stats;
    }

    public override void Remove()
    {
        owner.Stats -= stats;
        owner.RemoveBuff(this);
    }
}