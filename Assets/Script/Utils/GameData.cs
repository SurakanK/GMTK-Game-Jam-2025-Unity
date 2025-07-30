using System;
using System.Linq;
using UnityEngine;
public class GameData : ScriptableObject, IIdentifiableData
{
    public TitleFormat title;
    public Sprite icon;

    private string _objectId;

    public string Name
    {
        get
        {
            //TODO: Localization
            return title.name.text;
        }
    }

    public string DataId
    {
        get
        {
            return name.Replace("(Clone)", "");
        }
    }

    public string ObjectId
    {
        set { _objectId = value; }
        get
        {
            if (string.IsNullOrEmpty(_objectId))
                _objectId = Guid.NewGuid().ToString("N");
            return _objectId;
        }
    }

    public string Tag
    {
        get
        {
            return DataId.Split("_").First();
        }
    }
}