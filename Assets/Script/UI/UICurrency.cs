using TMPro;
using UnityEngine;

public class UICurrency : UIBase
{
    public TextMeshProUGUI textCurrency;
    public TextMeshProUGUI textOutstanding;

    void Start()
    {
        OnEvent();

        UpdateCurrency(BaseGamePlay.Currency);
        UpdateOutstanding(BaseGamePlay.Outstanding);
    }

    private void OnEvent()
    {
        GameEvent.Instance.EventCurrencyChange -= UpdateCurrency;
        GameEvent.Instance.EventCurrencyChange += UpdateCurrency;
        GameEvent.Instance.EventOutstandingChange -= UpdateOutstanding;
        GameEvent.Instance.EventOutstandingChange += UpdateOutstanding;
    }

    private void UpdateCurrency(int amount)
    {
        if (textCurrency != null)
        {
            textCurrency.text = amount.ToString();
        }
    }

    private void UpdateOutstanding(int amount)
    {
        if (textOutstanding != null)
        {
            Color color = amount <= 0 ? GameColor.Red : GameColor.Green;
            textOutstanding.text = amount.ToString();
            textOutstanding.color = color;
        }
    }
}