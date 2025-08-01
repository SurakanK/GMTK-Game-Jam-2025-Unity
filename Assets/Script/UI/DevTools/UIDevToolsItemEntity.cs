using TMPro;
using UnityEngine;

public class UIDevToolsItemEntity : UISelection<GameData>
{
    [Header("UI DevTools")]
    public TextMeshProUGUI textDataId;
    public TextMeshProUGUI textName;

    public override void UIUpdate()
    {
        if (textDataId != null)
            textDataId.text = $"+{Data.DataId}";
        if (textName != null)
            textName.text = $"{Data.Name}";
    }
}