using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum DialogType
{
    Boxtype, Chattype
}

[CreateAssetMenu(fileName = "DialogInfoSO", menuName = "ScriptableObject/DialogInfoSO", order = 1)]
public class DialogInfoSO : ScriptableObject
{
    public DialogType DialogType;
    //if Boxtype
    public List<DialogEntry> dialogEntries = new List<DialogEntry>();
    [Header("Dialog Choice will be the lasting to be apper in dialog!")]
    public List<DialogChoice> dialogChoices = new List<DialogChoice>();

    //if Chattype    
    public int CurrentDialogIndex= new int();

    public void AddBoxDialog(DialogEntry entry)
    {
        dialogEntries.Add(entry); 
    }

}
