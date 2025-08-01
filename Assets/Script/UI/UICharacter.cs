using UnityEngine;
using UnityEngine.UI;

public class UICharacter : UIBase
{
    public Animator healthIcon;
    public Image faceIcon;

    void Start()
    {
        OnEvent();
    }

    private void OnEvent()
    {
        GameEvent.Instance.EventHealthChange -= UpdateHealth;
        GameEvent.Instance.EventHealthChange += UpdateHealth;
    }

    private void UpdateHealth(int health, int maxHealth)
    {
        if (healthIcon == null)
            return;
        healthIcon.speed = GameUtils.MapReverse(health, 0, maxHealth, 0.5f, 2);
    }
}