
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIBaseItem : UIBase
{
    [Header("UI Item")]
    public Image bg;
    public Image imageItem;
    public TextMeshProUGUI textTitle;
    public TextMeshProUGUI textDescription;
    public TextMeshProUGUI textAmount;
    public TextMeshProUGUI textLevel;
    public TextMeshProUGUI textEnchantLevel;
    public TextMeshProUGUI textRarity;
    public UITier uiTier;

    public virtual void UIUpdate() { }
    public virtual void OnClear() { }
    public virtual void Destroy() { }
    public virtual void Refresh()
    {
        UIUpdate();
    }

    void OnDestroy()
    {
        Destroy();
    }

    protected void DisableUI(Component ui)
    {
        if (ui != null)
            ui.gameObject.SetActive(false);
    }

    protected void DisableUI(GameObject ui)
    {
        if (ui != null)
            ui.gameObject.SetActive(false);
    }

    protected void SetImage(Sprite sprite)
    {
        if (imageItem)
        {
            if (sprite != null)
            {
                imageItem.sprite = sprite;
                imageItem.gameObject.SetActive(true);
            }
            else
            {
                imageItem.gameObject.SetActive(false);
            }
        }
    }

    protected void SetName(string text = "")
    {
        if (textTitle)
        {
            if (text != string.Empty)
            {
                textTitle.text = text;
                textTitle.gameObject.SetActive(true);
            }
            else
            {
                textTitle.gameObject.SetActive(false);
            }
        }
    }

    protected void SetAmount(int amount, int maxStack)
    {
        if (textAmount)
        {
            if (amount > 1)
            {
                textAmount.text = $"{GameUtils.AmountFormat(amount)}/{GameUtils.AmountFormat(maxStack)}";
                textAmount.gameObject.SetActive(true);
            }
            else
            {
                textAmount.gameObject.SetActive(false);
            }
        }
    }

    protected void SetDescription(string text = "")
    {
        if (textDescription)
        {
            if (text != string.Empty)
            {
                textDescription.text = text;
                textDescription.gameObject.SetActive(true);
            }
            else
            {
                textDescription.gameObject.SetActive(false);
            }
        }
    }

    protected void SetLevel(int level = 0)
    {
        if (textLevel)
        {
            if (level > 0)
            {
                textLevel.text = $"Lv.{level}";
                textLevel.gameObject.SetActive(true);
            }
            else
            {
                textLevel.gameObject.SetActive(false);
            }
        }
    }

    protected void SetEnchantLevel(int enchantLevel = 0)
    {
        if (textEnchantLevel)
        {
            if (enchantLevel > 0)
            {
                textEnchantLevel.text = $"+{enchantLevel}";
                textEnchantLevel.gameObject.SetActive(true);
            }
            else
            {
                textEnchantLevel.gameObject.SetActive(false);
            }
        }
    }

    protected void SetTier(int tier)
    {
        if (uiTier != null)
        {
            uiTier.SetTier(tier);
        }
    }
}