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

            SerializedProperty eventValueProperty = property.FindPropertyRelative("Value");

            // Get fields by reflection
            Type soundEventsType = typeof(SoundEvents);
            List<FieldInfo> eventsFields = soundEventsType.GetFields().ToList();

            var options = eventsFields
                .Select(e => (string) e.GetValue(null))
                .ToList();

            // Properties
            var currentEvent = eventValueProperty.stringValue;
            var currentEventIndex = options.IndexOf(currentEvent);
            if (currentEventIndex == -1)
                currentEventIndex = 0;

            var index = EditorGUI.Popup(new Rect(0, position.height + 10, position.width, 20), currentEventIndex, options.ToArray());

            eventValueProperty.stringValue = options[index];

            EditorGUI.EndProperty();
        }
    }
}