using System;
using TMPro;
using UnityEngine;

public class UIGanericInputField : UIBase
{
    [Header("UI Element")]
    public TMP_InputField _inputField;
    public TextMeshProUGUI _textHeader;
    public TextMeshProUGUI _textMessage;
    public TextMeshProUGUI _textButtonConfirm;

    private Action<string> _eventConfirm;
    private Action _eventCancel;

    private int _maxAmount;

    void Awake()
    {
        _inputField.onValueChanged.AddListener(OnValueChanged);
    }

    private void OnValueChanged(string textChanged)
    {
        if (_maxAmount <= 0)
            return;
        if (int.TryParse(textChanged, out int amount))
        {
            if (amount > _maxAmount)
                _inputField.text = _maxAmount.ToString();
        }
    }

    public void ShowInputField(
        TMP_InputField.ContentType contentType,
        Action<string> EventConfirm,
        Action EventCancel,
        string textHeader,
        string textMessage,
        string textPlaceholder,
        string textButtonConfirm,
        string textInput,
        int amount,
        int maxAmount
    )
    {
        _maxAmount = 0;
        _eventConfirm = EventConfirm;
        _eventCancel = EventCancel;

        if (_textHeader)
            _textHeader.text = textHeader;
        if (_textMessage)
            _textMessage.text = textMessage;
        if (_textButtonConfirm)
            _textButtonConfirm.text = textButtonConfirm;

        if (_inputField)
        {
            _inputField.contentType = contentType;
            
            if (_inputField.placeholder is TextMeshProUGUI placeholderText)
                placeholderText.text = textPlaceholder;

            if (!string.IsNullOrEmpty(textInput))
                _inputField.text = textInput;
            if (amount > 0)
                _inputField.text = amount.ToString();
            if (maxAmount > 0)
                _maxAmount = maxAmount;
        }
        OnShow();
    }

    void OnDisable()
    {
        _eventConfirm = null;
        _eventCancel = null;
    }

    public void OnClickConfirm()
    {
        if (string.IsNullOrEmpty(_inputField.text))
            return;
        _eventConfirm?.Invoke(_inputField.text);
        _inputField.text = string.Empty;
        OnHide();
    }

    public void OnClickCancel()
    {
        _eventCancel?.Invoke();
        OnHide();
    }
}