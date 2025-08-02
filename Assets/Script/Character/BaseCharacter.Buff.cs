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

    public bool AddBuff(string buffId)
    {
        if (GameInstance.Instance.buffs.TryGetValue(buffId, out BaseBuff baseBuff))
        {
            return AddBuff(baseBuff);
        }
        return false;
    }

    public bool AddBuff(BaseBuff buff)
    {
        if (buff == null)
            return false;

        if (curBuffs.Any(e => e.GetType() == buff.GetType()))
            return false;

        BaseBuff buffClone = buff.Clone();
        curBuffs.Add(buffClone);
        buffClone.Apply(this);
        GameEvent.Instance.EventBuffChange?.Invoke(curBuffs);
        return true;
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