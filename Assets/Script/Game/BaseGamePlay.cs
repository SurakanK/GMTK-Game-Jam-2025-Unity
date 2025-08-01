using UnityEngine;

public class BaseGamePlay : MonoBehaviour
{
    void Awake()
    {
        Initialized();
    }

    private void Initialized()
    {
        if (GameInstance.Instance.gameRule == null)
            return;

        GameInstance.Level = GameInstance.Instance.gameRule.StartLevel;
        GameInstance.Currency = GameInstance.Instance.gameRule.StartCurrency;
        GameInstance.Outstanding = GameInstance.Instance.gameRule.Outstanding;
    }
}