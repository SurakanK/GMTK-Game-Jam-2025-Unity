using System;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class UICharacterStatus : UIFollow
{
    [Header("UI Element")]
    [SerializeField] private TextMeshProUGUI textName;
    [SerializeField] public Slider progressHealth;
    [SerializeField] public Slider progressStamina;

    [Header("Setting")]
    [SerializeField] public float _estimatedTimeShow;

    internal BaseCharacter owner;
    private CanvasGroup _canvasGroup;
    private float _timeShow;
    private float TimeShow
    {
        set
        {
            _timeShow = value;
            _canvasGroup.UIFade(true, false);
        }
    }

    void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Initialized(BaseCharacter baseCharacter)
    {
        if (!baseCharacter)
            return;

        owner = baseCharacter;
        followAt = owner.ReferencePoints.uiCharacterTransfrom;
        progressHealth.maxValue = owner.MaxHealth;
        progressStamina.maxValue = owner.MaxStamina;

        owner.CurrentStatsChangeEvent += OnCurrentStatsChangeEvent;
        owner.CurrentHealthChangeEvent += OnCurrentHealthChange;
        owner.CurrentStaminaChangeEvent += OnCurrentStaminaChange;

        if (owner.IsEnemy())
            progressStamina.gameObject.SetActive(false);

        _canvasGroup.UIFade(owner.IsCharacter(), false);
        UpdatePosition();
    }

    private void OnCurrentStatsChangeEvent(StatsData next)
    {
        owner.Stats = next;
        UpdateMaxValue(progressHealth, next.maxHealth);
        UpdateMaxValue(progressStamina, next.maxStamina);
    }

    private void OnDestroy()
    {
        if (owner != null)
        {
            owner.CurrentStatsChangeEvent -= OnCurrentStatsChangeEvent;
            owner.CurrentHealthChangeEvent -= OnCurrentHealthChange;
            owner.CurrentStaminaChangeEvent -= OnCurrentStaminaChange;
        }
    }

    private void OnCurrentHealthChange(int next)
    {
        progressHealth.value = next;
    }

    private void OnCurrentStaminaChange(int next)
    {
        progressStamina.value = next;
    }

    protected override void LateUpdate()
    {
        base.LateUpdate();

        // enemy hide ui when no attack
        if (owner.IsEnemy() && _timeShow > 0)
        {
            _timeShow -= Time.deltaTime;
            if (_timeShow <= 0)
                _canvasGroup.UIFade(false, true, 0.2f);
        }
    }

    private void UpdateMaxValue(Slider progressBar, int newMaxValue)
    {
        if (progressBar.maxValue != newMaxValue)
            progressBar.maxValue = newMaxValue;
    }
}