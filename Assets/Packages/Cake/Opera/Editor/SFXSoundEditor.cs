using UnityEditor;

namespace Cake.Opera.Data
{
    [CustomEditor(typeof(SFXSound))]
    [CanEditMultipleObjects]
    public class SFXSoundEditor : Editor
    {
        // Clip(s)
        private SerializedProperty m_random;
        private SerializedProperty m_clip;
        private SerializedProperty m_clips;

        // Pitch
        private SerializedProperty m_pitchRandom;
        private SerializedProperty m_pitch;
        private SerializedProperty m_pitchRange;

        // Volume
        private SerializedProperty m_volumeRandom;
        private SerializedProperty m_volume;
        private SerializedProperty m_volumeRange;

        void OnEnable()
        {
            // Clip(s)
            m_random = serializedObject.FindProperty("Random");
            m_clip = serializedObject.FindProperty("Clip");
            m_clips = serializedObject.FindProperty("Clips");

            // Pitch
            m_pitchRandom = serializedObject.FindProperty("PitchRandom");
            m_pitch = serializedObject.FindProperty("Pitch");
            m_pitchRange = serializedObject.FindProperty("PitchRange");

            // Volume
            m_volumeRandom = serializedObject.FindProperty("VolumeRandom");
            m_volume = serializedObject.FindProperty("Volume");
            m_volumeRange = serializedObject.FindProperty("VolumeRange");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            // Clip(s)
            EditorGUILayout.PropertyField(m_random);

            if (m_random.boolValue)
            {
                EditorGUILayout.PropertyField(m_clips);
            }
            else
            {
                EditorGUILayout.PropertyField(m_clip);
            }

            // Pitch
            EditorGUILayout.PropertyField(m_pitchRandom);

            if (m_pitchRandom.boolValue)
            {
                EditorGUILayout.PropertyField(m_pitchRange);
            }
            else
            {
                EditorGUILayout.PropertyField(m_pitch);
            }

            // Volume
            EditorGUILayout.PropertyField(m_volumeRandom);

            if (m_volumeRandom.boolValue)
            {
                EditorGUILayout.PropertyField(m_volumeRange);
            }
            else
            {
                EditorGUILayout.PropertyField(m_volume);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}