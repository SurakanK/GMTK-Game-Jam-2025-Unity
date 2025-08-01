using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CharacterInfoSO", menuName = "ScriptableObject/CharacterInfoSO", order = 1)]
public class CharacterInfoSO : ScriptableObject
{
    public string characterName;
    public uint characterId;
    public List<Sprite> characterImages = new List<Sprite>();

    public string GetName()
    {
        return characterName; 
    }
   
}
