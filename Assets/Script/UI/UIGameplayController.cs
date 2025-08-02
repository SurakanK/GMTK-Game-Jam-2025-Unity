using TMPro;
using UnityEngine;
using UnityEngine.UI;


public partial class UIGameplayController : MonoBehaviour
{
    [Header("UI GamePlay")]
    [SerializeField] public UIInventory panelInventory;
    [SerializeField] public UICharacter panelCharacter;
    [SerializeField] public UICurrency panelCurrency;
    [SerializeField] public TextMeshProUGUI textLevel;

    [Header("UI Button")]
    [SerializeField] public Button buttonNext;
    [SerializeField] public Button buttonLeave;

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
        OnEvent();
    }

    private void OnEvent()
    {
        GameEvent.Instance.EventLevelChange -= OnEventLevelChange;
        GameEvent.Instance.EventLevelChange += OnEventLevelChange;
    }

    private void OnEventLevelChange(int level)
    {
        if (textLevel)
            textLevel.text = $"Level: {level}";
    }

    public void OnClickNext()
    {
        DungeonCore.Instance.NextRoom();
    }

    public void OnClickLeave()
    {

    }
}