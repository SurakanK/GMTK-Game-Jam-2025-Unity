using System.Collections;
using TMPro;
using UnityEngine;

public class UIBank : UIBase
{
    private int CurrencyMoney, Debt = 0;
    [SerializeField] TextMeshProUGUI DebtText;
    [SerializeField] TMP_InputField TMP_PaidDebt;

    private Coroutine debtAnimCoroutine;

    private void Start()
    {
        // Get current values from BaseGamePlay
        CurrencyMoney = BaseGamePlay.Currency;
        Debt = BaseGamePlay.Outstanding;

        // Show initial debt in the UI
        DebtText.text = Debt.ToString();

        Debug.Log("Debt: " + Debt);
        Debug.Log("CurrencyMoney: " + CurrencyMoney);
    }

    public void PayDebt()
    {
        Debug.Log("TMP_PaidDebt.text: " + TMP_PaidDebt.text);

        if (int.TryParse(TMP_PaidDebt.text, out int paidAmount))
        {
            if (paidAmount > BaseGamePlay.Currency)
            {
                Debug.Log("Player have money: " + CurrencyMoney);
                Debug.LogWarning("Player tried to pay more than they have.");
                TMP_PaidDebt.text = "Not enough money";
                return;
            }

            Debug.Log("Before pay debt: " + Debt);
            Debug.Log("Before pay CurrencyMoney: " + CurrencyMoney);


            Debug.Log("Before pay BaseGamePlay.debt: " + BaseGamePlay.Outstanding);
            Debug.Log("Before pay BaseGamePlay.CurrencyMoney: " + BaseGamePlay.Currency);

            Debug.Log("Paid: " + paidAmount);

            paidAmount = Mathf.Clamp(paidAmount, 0, Mathf.Abs(Debt)); // Ensure no overpaying debt
            int previousDebt = Debt;
          
            BaseGamePlay.Outstanding += paidAmount;
            BaseGamePlay.Currency -= paidAmount;

            AnimateDebt(previousDebt, Debt, 0.5f);

            TMP_PaidDebt.text = "";

            Debug.Log("After pay debt: " + Debt);
            Debug.Log("After pay CurrencyMoney: " + CurrencyMoney);

            Debug.Log("After pay BaseGamePlay.debt: " + BaseGamePlay.Outstanding);
            Debug.Log("After pay BaseGamePlay.CurrencyMoney: " + BaseGamePlay.Currency);
        }
        else
        {
            Debug.LogWarning("Invalid input in TMP_PaidDebt");
        }
    }


    private void AnimateDebt(int from, int to, float duration)
    {
        if (debtAnimCoroutine != null)
            StopCoroutine(debtAnimCoroutine);

        debtAnimCoroutine = StartCoroutine(AnimateDebtCoroutine(from, to, duration));
    }

    private IEnumerator AnimateDebtCoroutine(int from, int to, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            int value = Mathf.RoundToInt(Mathf.Lerp(from, to, t));
            DebtText.text = value.ToString();
            yield return null;
        }

        DebtText.text = to.ToString(); 
    }
}
