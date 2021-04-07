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
    [CustomPropertyDrawer(typeof(SFXEvent))]
    public class SFXEventEditor : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            SerializedProperty eventProperty = property.FindPropertyRelative("Event");
            SerializedProperty soundProperty = property.FindPropertyRelative("Sound");

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(eventProperty.stringValue, GUILayout.Width(200f));
            soundProperty.objectReferenceValue = EditorGUILayout.ObjectField(soundProperty.objectReferenceValue, typeof(SFX), false);
            EditorGUILayout.EndHorizontal();

            EditorGUI.EndProperty();
        }
    }
}