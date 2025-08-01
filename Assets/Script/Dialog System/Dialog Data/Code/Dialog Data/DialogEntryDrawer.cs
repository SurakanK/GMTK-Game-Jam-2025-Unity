using System.Collections;
using UnityEngine;
using UnityEditor;


[CustomPropertyDrawer(typeof(DialogEntry))]
public class DialogEntryDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Get the properties
        SerializedProperty characterDataProp = property.FindPropertyRelative("characterData");
        SerializedProperty textProp = property.FindPropertyRelative("text");
        SerializedProperty spriteNumberProp = property.FindPropertyRelative("spriteNumber");
        SerializedProperty picturePositionProp = property.FindPropertyRelative("picturePosition");
        SerializedProperty backgroundImageProp = property.FindPropertyRelative("BackgroundImage"); // Added background image

        SerializedProperty multipleCharacterProp = property.FindPropertyRelative("MultipleCharacter");

        SerializedProperty supportCharacterDataProp = property.FindPropertyRelative("SupportCharacterData1");
        SerializedProperty supportCharacterSpriteNumberProp = property.FindPropertyRelative("SupportCharacterSpriteNumber1");
        SerializedProperty supportCharacterPicturePositionProp = property.FindPropertyRelative("SupportCharacterPicturePosition1");

        // Begin property drawing
        EditorGUI.BeginProperty(position, label, property);

        // Calculate the rects for each field
        Rect characterDataRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
        Rect textRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight + 2, position.width, EditorGUIUtility.singleLineHeight * 3);
        Rect spriteNumberRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * 4 + 4, position.width, EditorGUIUtility.singleLineHeight);
        Rect picturePositionRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * 5 + 6, position.width, EditorGUIUtility.singleLineHeight);
        Rect backgroundImageRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * 6 + 8, position.width, EditorGUIUtility.singleLineHeight); // Added background image rect

        Rect multipleCharacterRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * 7 + 10, position.width, EditorGUIUtility.singleLineHeight);

        // Draw the main character's fields
        EditorGUI.PropertyField(characterDataRect, characterDataProp);
        EditorGUI.PropertyField(textRect, textProp);

        // Draw the spriteNumber dropdown
        if (characterDataProp.objectReferenceValue != null)
        {
            CharacterInfoSO characterData = characterDataProp.objectReferenceValue as CharacterInfoSO;
            DrawSpriteDropdown(spriteNumberRect, spriteNumberProp, characterData);
        }
        else
        {
            EditorGUI.LabelField(spriteNumberRect, "Sprite", "Assign CharacterInfoSO first");
        }

        EditorGUI.PropertyField(picturePositionRect, picturePositionProp);

        // Draw Background Image field
        EditorGUI.PropertyField(backgroundImageRect, backgroundImageProp, new GUIContent("Background Image"));

        // Draw the MultipleCharacter toggle
        EditorGUI.PropertyField(multipleCharacterRect, multipleCharacterProp);

        // If MultipleCharacter is true, draw the support character fields
        if (multipleCharacterProp.boolValue)
        {
            Rect supportCharacterDataRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * 8 + 12, position.width, EditorGUIUtility.singleLineHeight);
            Rect supportCharacterSpriteNumberRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * 9 + 14, position.width, EditorGUIUtility.singleLineHeight);
            Rect supportCharacterPicturePositionRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * 10 + 16, position.width, EditorGUIUtility.singleLineHeight);

            EditorGUI.PropertyField(supportCharacterDataRect, supportCharacterDataProp);

            if (supportCharacterDataProp.objectReferenceValue != null)
            {
                CharacterInfoSO supportCharacterData = supportCharacterDataProp.objectReferenceValue as CharacterInfoSO;
                DrawSpriteDropdown(supportCharacterSpriteNumberRect, supportCharacterSpriteNumberProp, supportCharacterData);
            }
            else
            {
                EditorGUI.LabelField(supportCharacterSpriteNumberRect, "Support Sprite", "Assign SupportCharacterData1 first");
            }

            EditorGUI.PropertyField(supportCharacterPicturePositionRect, supportCharacterPicturePositionProp);
        }

        // End property drawing
        EditorGUI.EndProperty();
    }

    private void DrawSpriteDropdown(Rect position, SerializedProperty spriteProp, CharacterInfoSO characterData)
    {
        // Get the names of the images in characterImages
        string[] options = new string[characterData.characterImages.Count];
        for (int i = 0; i < options.Length; i++)
        {
            options[i] = characterData.characterImages[i]?.name ?? "Unnamed";
        }

        // Draw the spriteNumber dropdown
        spriteProp.intValue = EditorGUI.Popup(position, "Sprite", spriteProp.intValue, options);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        // Adjust the height based on whether MultipleCharacter is true
        bool multipleCharacter = property.FindPropertyRelative("MultipleCharacter").boolValue;
        return EditorGUIUtility.singleLineHeight * (multipleCharacter ? 12 : 8) + (multipleCharacter ? 16 : 10); // Adjusted height to account for BackgroundImage
    }
}
