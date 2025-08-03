using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGameSummary : UIBase
{
    public static UIGameSummary _instance;
    public static UIGameSummary Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<UIGameSummary>();
            }
            return _instance;
        }
    }

    public Image imageBg;
    public TextMeshProUGUI textLevelSummary;
    public List<Sprite> bg;

    public void Show()
    {
        Debug.Log("Show");
        OnShow();
        Sprite sprite = BaseGamePlay.Outstanding >= 0 ? bg[0] : bg[1];
        imageBg.sprite = sprite;
        textLevelSummary.text = BaseGamePlay.Level.ToString();
    }
}