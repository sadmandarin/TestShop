#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ConditionalFieldAttribute))]
public class ConditionalFieldDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        ConditionalFieldAttribute conditional = (ConditionalFieldAttribute)attribute;
        SerializedProperty conditionProperty = property.serializedObject.FindProperty(conditional.ConditionFieldName);

        if (conditionProperty != null)
        {
            bool conditionMet = conditionProperty.boolValue;
            if (conditional.Inverse) conditionMet = !conditionMet;

            if (conditionMet)
            {
                EditorGUI.PropertyField(position, property, label, true);
            }
        }
        else
        {
            EditorGUI.PropertyField(position, property, label, true);
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        ConditionalFieldAttribute conditional = (ConditionalFieldAttribute)attribute;
        SerializedProperty conditionProperty = property.serializedObject.FindProperty(conditional.ConditionFieldName);

        if (conditionProperty != null)
        {
            bool conditionMet = conditionProperty.boolValue;
            if (conditional.Inverse) conditionMet = !conditionMet;

            if (conditionMet)
            {
                return EditorGUI.GetPropertyHeight(property, label);
            }
            else
            {
                return 0;
            }
        }
        else
        {
            return EditorGUI.GetPropertyHeight(property, label);
        }
    }
}
#endif