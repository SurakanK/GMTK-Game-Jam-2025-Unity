using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacter : UIBase
{
    public Animator healthIcon;
    public Image faceIcon;
    public List<UIBuffEntity> uiBuffs;

    void Start()
    {
        OnEvent();
    }

    private void OnEvent()
    {
        GameEvent.Instance.EventHealthChange -= UpdateHealth;
        GameEvent.Instance.EventHealthChange += UpdateHealth;
        GameEvent.Instance.EventBuffChange += OnEventBuffChange;
    }

    private void UpdateHealth(int health, int maxHealth)
    {
        if (healthIcon == null)
            return;
        healthIcon.speed = GameUtils.MapReverse(health, 0, maxHealth, 0.5f, 2);
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