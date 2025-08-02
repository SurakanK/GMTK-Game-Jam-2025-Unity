using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShop : UIBase
{
    public List<SelectBuyItem> itemSell;
    public List<SelectBuyBuff> buyBuffSell;

    public Image imageBag;
    public List<Sprite> iconBag;
    public int slotPrice;

    void Awake()
    {
        OnEvent();
        SetIconBag();
    }

    private void OnEvent()
    {
        foreach (var item in itemSell)
        {
            item.button.onClick.AddListener(() =>
            {
                BuyWeapon(item.itemSell);
            });
        }

        foreach (var buff in buyBuffSell)
        {
            buff.button.onClick.AddListener(() =>
            {
                BuyBuff(buff.itemSell);
            });
        }
    }

    private void SetIconBag()
    {
        if (BaseGamePlay.Inventory.curSlot == 25)
        {
            imageBag.gameObject.SetActive(false);
            return;
        }

        Sprite sprite = BaseGamePlay.Inventory.curSlot <= 10 ? iconBag[0] : iconBag[1];
        imageBag.sprite = sprite;
    }

    public void OnClickBuySloyInventory()
    {
        if (!CheckCurrencyAmount(slotPrice))
            return;

        int increaseSlot = BaseGamePlay.Inventory.curSlot <= 10 ? 5 : 10;
        BaseGamePlay.Inventory.curSlot += increaseSlot;
        BaseGamePlay.Currency -= slotPrice;
        UIGameplayController.Instance.panelInventory.SetLockSlot();
        SetIconBag();
    }

    private void BuyWeapon(ItemData itemData)
    {
        if (!CheckCurrencyAmount(itemData.price))
            return;

        if (!BaseGamePlay.Inventory.CheckSlotLimit())
        {
            UIGeneric.ShowMessage(
                null,
                null,
                "Inventory Full",
                "Please drop some items",
                "Ok"
                );
            return;
        }
        BaseGamePlay.Currency -= itemData.price;
        BaseGamePlay.Inventory.IncreaseItem(itemData);
    }

    private void BuyBuff(BaseBuff buff)
    {
        if (!CheckCurrencyAmount(buff.price))
            return;

        if (GamePlayerCharacter.PlayerCharacter.AddBuff(buff.DataId))
        {
            BaseGamePlay.Currency -= buff.price;
        }
    }

    private bool CheckCurrencyAmount(int price)
    {
        if (BaseGamePlay.Currency < price)
        {
            UIGeneric.ShowMessage(
                null,
                null,
                "Insufficient Funds",
                "Not enough gold.",
                "Ok"
            );
            return false;
        }
        return true;
    }
}

[Serializable]
public class SelectBuyItem
{
    public Button button;
    public ItemData itemSell;
}

[Serializable]
public class SelectBuyBuff
{
    public Button button;
    public BaseBuff itemSell;
}