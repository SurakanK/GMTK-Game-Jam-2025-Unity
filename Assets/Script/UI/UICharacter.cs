using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacter : UIBase
{
    public Animator healthIcon;
    public Image faceIcon;
    public List<UIBuffEntity> uiBuffs;

    public void Initialized()
    {
        OnEvent();
    }

    private void OnEvent()
    {
        GameEvent.Instance.EventHealthChange -= UpdateHealth;
        GameEvent.Instance.EventHealthChange += UpdateHealth;
        GameEvent.Instance.EventBuffChange -= OnEventBuffChange;
        GameEvent.Instance.EventBuffChange += OnEventBuffChange;
    }

    private void UpdateHealth(int health, int maxHealth)
    {
        if (healthIcon == null)
            return;
            
        float speed = health > 0? GameUtils.MapReverse(health, 0, maxHealth, 0.5f, 2): 0;
        healthIcon.speed = speed;
    }

    private void OnEventBuffChange(List<BaseBuff> buffs)
    {
        foreach (UIBuffEntity uiBuff in uiBuffs)
            uiBuff.ResetUI();

        int count = Mathf.Min(buffs.Count, uiBuffs.Count);
        for (int i = 0; i < count; i++)
        {
            if (uiBuffs[i] != null)
                uiBuffs[i].Data = buffs[i];
        }
    }
}