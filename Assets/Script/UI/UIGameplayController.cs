using System;
using UnityEngine;
using UnityEngine.Pool;

public partial class UIGameplayController : MonoBehaviour
{
    [Header("UI Target")]
    [SerializeField] private UITarget _uiTarget;

    [Header("UI Stats")]
    [SerializeField] private Transform _statsRoot;
    [SerializeField] private UICharacterStatus _uiCharacterStatusPrefab;

    [Header("UI GamePlay")]
    [SerializeField] public UIInventory panelInventory;
    [SerializeField] public UIEquipment panelEquipment;

    private ObjectPool<UICharacterStatus> _uiCharacterStatusPool;

    public static UIGameplayController _instance;
    public static UIGameplayController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<UIGameplayController>();
            }
            return _instance;
        }
    }

    void Start()
    {
        _uiCharacterStatusPool = CreateObjectPool(_uiCharacterStatusPrefab, _statsRoot);
    }

    public void InitializedUI(BaseCharacter baseCharacter)
    {
        AddUICharacterStatus(baseCharacter);
    }

    public void InitializedUIOwner()
    {
        if (panelInventory != null)
            panelInventory.Initialized();
        if (panelEquipment != null)
            panelEquipment.Initialized();
    }

    private void AddUICharacterStatus(BaseCharacter baseCharacter)
    {
        if (!_uiCharacterStatusPrefab)
            return;

        UICharacterStatus uiCharacter = _uiCharacterStatusPool.Get();
        uiCharacter.Initialized(baseCharacter);

        baseCharacter.RemoveUIEvent += OnRemoveUI;
        void OnRemoveUI()
        {
            baseCharacter.RemoveUIEvent -= OnRemoveUI;
            RemoveUICharacterStatus(uiCharacter);
        }
    }

    public void SetUITarget(BaseCharacter baseCharacter)
    {
        _uiTarget.Initialized(baseCharacter);
    }

    public void RemoveUICharacterStatus(UICharacterStatus uiCharacterStatus)
    {
        if (!uiCharacterStatus)
            return;

        _uiCharacterStatusPool.Release(uiCharacterStatus);
    }
}