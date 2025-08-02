using System;
using TMPro;
using UnityEngine;

public class UIGanericMessage : UIBase
{
    [Header("UI Element")]
    public TextMeshProUGUI _textHeader;
    public TextMeshProUGUI _textMessage;
    public TextMeshProUGUI _textButtonConfirm;

    private Action _eventConfirm;
    private Action _eventCancel;

    private int _maxAmount;


    public void ShowMessage(
        Action EventConfirm,
        Action EventCancel,
        string textHeader,
        string textMessage,
        string textButtonConfirm
    )
    {
        _eventConfirm = EventConfirm;
        _eventCancel = EventCancel;

        if (_textHeader)
            _textHeader.text = textHeader;
        if (_textMessage)
            _textMessage.text = textMessage;
        if (_textButtonConfirm)
            _textButtonConfirm.text = textButtonConfirm;

        OnShow();
    }

    void OnDisable()
    {
        _eventConfirm = null;
        _eventCancel = null;
    }

    public void OnClickConfirm()
    {
        _eventConfirm?.Invoke();
        OnHide();
    }

    public void OnClickCancel()
    {
        _eventCancel?.Invoke();
        OnHide();
    }
}