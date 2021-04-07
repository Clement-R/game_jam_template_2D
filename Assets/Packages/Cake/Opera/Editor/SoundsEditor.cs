using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using UnityEngine;

using UnityEditor;

namespace Cake.Opera.Data
{
    [CustomEditor(typeof(Sounds))]
    public class SoundsEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            SerializedProperty valuesProperty = serializedObject.FindProperty("Values");;

            for (int i = 0; i < valuesProperty.arraySize; i++)
            {
                SerializedProperty entry = valuesProperty.GetArrayElementAtIndex(i);

                EditorGUILayout.PropertyField(entry);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}