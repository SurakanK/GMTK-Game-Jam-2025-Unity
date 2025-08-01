using System;
using UnityEngine;
using UnityEngine.Pool;

public partial class UIGameplayController : MonoBehaviour
{
    [Header("UI GamePlay")]
    [SerializeField] public UIInventory panelInventory;
    [SerializeField] public UICharacter panelCharacter;
    [SerializeField] public UICurrency panelCurrency;

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

    public void InitializedUI()
    {
        if (panelInventory != null)
            panelInventory.Initialized();
    }
}