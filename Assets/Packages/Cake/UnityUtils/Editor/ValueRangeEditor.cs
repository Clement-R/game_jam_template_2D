using UnityEngine;

using UnityEditor;

namespace Cake.Data
{
    [CustomPropertyDrawer(typeof(ValueRange))]
    public class ValueRangeDrawer : PropertyDrawer
    {
        // Draw the property inside the given rect
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            // Draw label
            EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            // Don't make child fields be indented
            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 1;

            // Properties
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(property.FindPropertyRelative("Min"), new GUIContent("Min"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("Max"), new GUIContent("Max"));
            EditorGUILayout.EndHorizontal();

            // Set indent back to what it was
            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }
    }
}