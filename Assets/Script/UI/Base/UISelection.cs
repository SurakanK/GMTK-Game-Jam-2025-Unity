using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UISelection<T> : UIBaseItem, IUISelection
{
    public UnityAction<T, int> EventSelected;
    public UnityAction<T, int> EventDeSelected;
    private Toggle _toggle;
    private bool _isSelected;
    private int _index;
    public int Index { get { return _index; } set { _index = value; } }

    protected T _data;
    public T Data
    {
        get { return _data; }
        set
        {
            _data = value;
            UIUpdate();
        }
    }

    void OnDestroy()
    {
        EventSelected = null;
        EventDeSelected = null;
    }

    public void Clear()
    {
        OnClear();
    }

    public override void OnShow()
    {
        base.OnShow();
    }

    public void Selected()
    {
        if (_isSelected)
            return;

        _isSelected = true;
        EventSelected?.Invoke(Data, _index);
        OnSelected();
    }

    public void DeSelect()
    {
        if (!_isSelected)
            return;
        _isSelected = false;
        EventDeSelected?.Invoke(Data, _index);
        OnDeSelect();
    }

    public void SetData(object data, int index)
    {
        _index = index;
        if (data is T casted)
        {
            Data = casted;
        }
    }

    public void Awake()
    {
        if (TryGetComponent(out Toggle toggle))
        {
            _toggle = toggle;
            _toggle.onValueChanged.RemoveAllListeners();
            _toggle.onValueChanged.AddListener(OnValueChanged);

            ToggleGroup toggleGroup = _toggle.GetComponentInParent<ToggleGroup>();
            if (toggleGroup)
                _toggle.group = toggleGroup;
        }
        else if (TryGetComponent(out Button button))
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(OnButtonClicked);
        }
    }

    public override void Destroy()
    {
        base.Destroy();
        if (_toggle)
            _toggle.onValueChanged.RemoveAllListeners();

        EventSelected = null;
    }

    public override void OnClear()
    {
        base.OnClear();
        EventSelected = null;

        if (_toggle)
        {
            _isSelected = false;
            _toggle.isOn = false;
        }
    }

    private void OnValueChanged(bool isOn)
    {
        if (isOn)
            Selected();
        else
            DeSelect();
    }

    private void OnButtonClicked()
    {
        EventSelected?.Invoke(Data, _index);
    }

    public virtual void OnSelected() { }
    public virtual void OnDeSelect() { }

    public void ForceSelect()
    {
        if (_toggle != null) { }
        _toggle.isOn = true;
    }
}