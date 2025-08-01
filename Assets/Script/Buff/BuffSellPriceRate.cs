using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "BaseBuff", menuName = "BaseBuff/BuffSellPriceRate", order = 0)]
public class BuffSellPriceRate : BaseBuff
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