using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using UnityEngine;

namespace Cake.Opera.Data
{
    [CreateAssetMenu(fileName = "Sounds", menuName = "Audio/Sounds", order = 0)]
    public class Sounds : ScriptableObject
    {
        public List<SFX> Values = new List<SFX>();

        public SFXSound Get(SFXEvent p_event)
        {
            SFX entry = Values.FirstOrDefault(e => e.Event == p_event);
            if (entry == null)
                return null;

            return entry.Sound;
        }

        public SFXSound Get(string p_eventName)
        {
            SFX entry = Values.FirstOrDefault(e => e.Event.Value == p_eventName);
            if (entry == null)
                return null;

            return entry.Sound;
        }

        [ContextMenu("Populate")]
        private void Populate()
        {
            Type soundEventsType = typeof(SoundEvents);
            List<FieldInfo> eventsFields = soundEventsType.GetFields().ToList();

            var values = eventsFields.Select(e => (string) e.GetValue(null));
            List<string> currentValues = Values.Select(e => e.Event.Value).ToList();

            // Find old values and remove them
            var oldValues = currentValues.Except(values);
            foreach (var eventName in oldValues)
            {
                var entry = Values.FirstOrDefault(e => e.Event.Value == eventName);
                Values.Remove(entry);
            }

            // Find missing values and create entries
            var missingValues = values.Except(currentValues);
            foreach (var value in missingValues)
            {
                Values.Add(new SFX(new SFXEvent(value)));
            }
        }
    }
}