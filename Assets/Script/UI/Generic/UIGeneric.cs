using System;
using UnityEngine;
using TMPro;

public class UIGeneric : MonoBehaviour
{
    [Header("UI Element")]
    public UIGanericLoading UILoading;
    public UIGanericMessage UIMessage;
    public UIGanericInputField UIInputField;

    public static UIGeneric _instance;
    public static UIGeneric Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<UIGeneric>();
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public static void ShowLoading(bool isActive)
    {
        if (Instance.UILoading)
            Instance.UILoading.ShowLoading(isActive);
    }

    public static void ShowMessage(
        Action EventConfirm,
        Action EventCancel,
        string textHeader,
        string textMessage = "",
        string textButtonConfirm = "Confirm")
    {
        if (Instance.UIMessage)
            Instance.UIMessage.ShowMessage(
                EventConfirm,
                EventCancel,
                textHeader,
                textMessage,
                textButtonConfirm
            );
    }

    public static void ShowInputAmountField(
            Action<string> EventConfirm,
            Action EventCancel,
            string textHeader,
            string textMessage = "",
            int amount = 0,
            int maxAmount = 0,
            string textPlaceholder = "",
            string textButtonConfirm = "Confirm")
    {
        if (Instance.UIInputField)
            Instance.UIInputField.ShowInputField(
                TMP_InputField.ContentType.IntegerNumber,
                EventConfirm,
                EventCancel,
                textHeader,
                textMessage,
                textPlaceholder,
                textButtonConfirm,
                string.Empty,
                amount,
                maxAmount
            );
    }

    public static void ShowInputField(
        Action<string> EventConfirm,
        Action EventCancel,
        string textHeader,
        string textMessage = "",
        string textInput = "",
        string textPlaceholder = "",
        string textButtonConfirm = "Confirm")
    {
        if (Instance.UIInputField)
            Instance.UIInputField.ShowInputField(
                TMP_InputField.ContentType.Standard,
                EventConfirm,
                EventCancel,
                textHeader,
                textMessage,
                textPlaceholder,
                textButtonConfirm,
                textInput,
                0,
                0
            );
    }
}