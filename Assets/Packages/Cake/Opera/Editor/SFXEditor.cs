using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

namespace Cake.Opera.Data
{
    [CustomPropertyDrawer(typeof(SFX))]
    public class SFXEditor : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            SerializedProperty eventProperty = property.FindPropertyRelative("Event");
            SerializedProperty eventNameProperty = eventProperty.FindPropertyRelative("Value");
            SerializedProperty soundProperty = property.FindPropertyRelative("Sound");

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(eventNameProperty.stringValue, GUILayout.Width(150f));
            soundProperty.objectReferenceValue = EditorGUILayout.ObjectField(soundProperty.objectReferenceValue, typeof(SFXSound), false);
            EditorGUILayout.EndHorizontal();

            EditorGUI.EndProperty();
        }
    }
}