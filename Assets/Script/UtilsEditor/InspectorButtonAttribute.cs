using UnityEngine;

[System.AttributeUsage(System.AttributeTargets.Field)]
public class InspectorButtonAttribute : PropertyAttribute
{
    public readonly string methodName;
    public readonly string labelText;

    public InspectorButtonAttribute(string methodName, string labelText = "")
    {
        this.methodName = methodName;
        this.labelText = labelText;
    }
}