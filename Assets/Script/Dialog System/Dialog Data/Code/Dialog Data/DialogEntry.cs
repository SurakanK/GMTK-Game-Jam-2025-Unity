using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public enum PicturePosition
{
    Left, Middle, Right
}

[System.Serializable]
public class DialogEntry
{
    public CharacterInfoSO characterData;   
    [TextArea]
    public string text;
    public int spriteNumber; // Index to the characterImages list in CharacterData
    public PicturePosition picturePosition;
    public Sprite BackgroundImage;    
    //For Multiple Character
    public bool MultipleCharacter; // Toggle for showing support character fields
    public CharacterInfoSO SupportCharacterData1;
    public int SupportCharacterSpriteNumber1; // Index to the characterImages list in CharacterData
    public PicturePosition SupportCharacterPicturePosition1;

    public DialogEntry(CharacterInfoSO data, string dialogText, int sprite)
    {
        characterData = data;
        text = dialogText;
        spriteNumber = sprite;
    }
}
