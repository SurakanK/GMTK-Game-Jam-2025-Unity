using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIToggleGroupSelection : MonoBehaviour
{
    [SerializeField]
    private ToggleGroup _uiToggleGroup;

    [SerializeField]
    private List<ToggleSelection> _uiToggleSelection;

    private int _currentSelection;

    void Awake()
    {
        OnEvent();
    }

    private void OnEvent()
    {
        for (int i = 0; i < _uiToggleSelection.Count; i++)
        {
            ToggleSelection toggleSelection = _uiToggleSelection[i];

            if (toggleSelection.uiToggle)
            {
                if (_uiToggleGroup != null)
                    toggleSelection.uiToggle.group = _uiToggleGroup;

                toggleSelection.uiToggle.onValueChanged.AddListener(onChange =>
                {
                    OnToggleValueChanged(onChange, toggleSelection);
                });
            }

            if (i == 0)
                toggleSelection.uiBase.SetActive(true);
        }
    }

    private void OnToggleValueChanged(bool onChange, ToggleSelection toggleSelection)
    {
        int objectId = toggleSelection.uiToggle.GetInstanceID();
        if (onChange && objectId == _currentSelection)
            return;

        if (onChange)
            _currentSelection = objectId;

        if (toggleSelection.uiBase)
            toggleSelection.uiBase.SetActive(onChange);
    }
}

[Serializable]
public class ToggleSelection
{
    [SerializeField]
    public Toggle uiToggle;
    [SerializeField]
    public UIBase uiBase;
}