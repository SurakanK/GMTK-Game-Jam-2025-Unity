
using System;

[Serializable]
public class TextFormat
{
    public string text;
    public string localKey;
}

[Serializable]
public class TitleFormat
{
    public TextFormat name;
    public TextFormat description;
}