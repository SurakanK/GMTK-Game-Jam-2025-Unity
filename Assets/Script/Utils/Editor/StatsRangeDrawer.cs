using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(StatsRange))]
public class StatsRangeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        var minProp = property.FindPropertyRelative("min");
        var maxProp = property.FindPropertyRelative("max");

        position.height = EditorGUIUtility.singleLineHeight;

        GUIStyle richFoldout = new GUIStyle(EditorStyles.foldout);
        richFoldout.richText = true;
        string labelText = $"{label.text}";
        if (minProp.floatValue > 0f || maxProp.floatValue > 0f)
            labelText += $": <color=#ff00ff>[{minProp.floatValue} - {maxProp.floatValue}]</color>";

        property.isExpanded = EditorGUI.Foldout(position, property.isExpanded, labelText, true, richFoldout);

        if (property.isExpanded)
        {
            EditorGUI.indentLevel++;
            Rect minRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight + 2, position.width, EditorGUIUtility.singleLineHeight);
            Rect maxRect = new Rect(position.x, minRect.y + EditorGUIUtility.singleLineHeight + 2, position.width, EditorGUIUtility.singleLineHeight);

            EditorGUI.PropertyField(minRect, minProp);
            EditorGUI.PropertyField(maxRect, maxProp);
            EditorGUI.indentLevel--;
        }

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        if (!property.isExpanded)
            return EditorGUIUtility.singleLineHeight;

        return (EditorGUIUtility.singleLineHeight + 2) * 3;
    }
}
