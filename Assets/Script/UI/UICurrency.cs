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
            int from = int.Parse(textCurrency.text);
            StartCoroutine(GameUtils.LerpTextValue(textCurrency, from, amount, 0.5f, null));
        }
    }

    private void UpdateOutstanding(int amount)
    {
        if (textOutstanding != null)
        {
            Color color = amount <= 0 ? GameColor.Red : GameColor.Green;
            textOutstanding.color = color;
            int from = int.Parse(textOutstanding.text);
            StartCoroutine(GameUtils.LerpTextValue(textOutstanding, from, amount, 0.5f, null));
        }
    }
}