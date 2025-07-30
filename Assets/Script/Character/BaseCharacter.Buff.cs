using System;
using System.Collections.Generic;
using System.Linq;

partial class BaseCharacter
{
    protected List<BaseBuff> curBuffs = new List<BaseBuff>();

    public void AddBuff(string buffId)
    {
        if (GameInstance.Instance.buffs.TryGetValue(buffId, out BaseBuff baseBuff))
        {
            AddBuff(baseBuff);
        }
    }

    public void AddBuff(BaseBuff buff)
    {
        if (buff == null)
            return;

        if (curBuffs.Any(e => e.GetType() == buff.GetType()))
            return;

        BaseBuff buffClone = buff.Clone();
        curBuffs.Add(buffClone);
        buffClone.Apply(this);
    }

    public void RemoveBuff(BaseBuff buff)
    {
        curBuffs.Remove(buff);
    }

    public void ClearAllBuff()
    {
        for (int i = curBuffs.Count - 1; i >= 0; i--)
        {
            RemoveBuff(curBuffs[i]);
        }
    }

    public bool TryToGetBuff<T>(out T result) where T : BaseBuff
    {
        result = curBuffs.OfType<T>().FirstOrDefault();
        return result != null;
    }
}