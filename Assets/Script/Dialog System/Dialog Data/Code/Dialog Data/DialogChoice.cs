using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum StatChange
{
    None,Money, Charm,Creative,Socialize,Stress,Intelligent
}

[System.Serializable]
public class DialogChoice
{
    [TextArea]
    public string text;
    public StatChange statChange;
    public int statValue;
    public DialogInfoSO NextDialog;
}
