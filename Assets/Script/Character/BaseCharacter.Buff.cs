using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

partial class BaseCharacter
{
    private List<BaseBuff> _curBuffs = new();
    protected List<BaseBuff> curBuffs
    {
        get { return _curBuffs; }
        set { _curBuffs = value; }
    }

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
        GameEvent.Instance.EventBuffChange?.Invoke(curBuffs);
    }

    public void RemoveBuff(BaseBuff buff)
    {
        buff.Remove();
        curBuffs.Remove(buff);
        GameEvent.Instance.EventBuffChange?.Invoke(curBuffs);
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