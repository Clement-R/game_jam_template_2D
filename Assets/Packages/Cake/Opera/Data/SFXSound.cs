using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Audio;

using Cake.Data;

namespace Cake.Opera.Data
{
    [CreateAssetMenu(fileName = "SFX", menuName = "Audio/SFX", order = 1)]
    public class SFXSound : ScriptableObject
    {
        // Clip(s)
        public AudioClip Clip;
        public bool Random;
        public List<AudioClip> Clips;

        // Volume
        public bool VolumeRandom;
        [Range(0f, 1f)]
        public float Volume = 1f;
        public ValueRange VolumeRange = new ValueRange(0f, 1f);

        // Pitch
        public bool PitchRandom;
        [Range(0.5f, 1.5f)]
        public float Pitch = 1f;
        public ValueRange PitchRange = new ValueRange(0.5f, 1.5f);

        // Group
        public AudioMixerGroup MixerGroup;

        public AudioClip GetClip()
        {
            if (Random)
            {
                return Clips.Random();
            }
            else
            {
                return Clip;
            }
        }

        public float GetVolume()
        {
            if (VolumeRandom)
            {
                return VolumeRange.Random();
            }
            else
            {
                return Volume;
            }
        }

        public float GetPitch()
        {
            if (PitchRandom)
            {
                return PitchRange.Random();
            }
            else
            {
                return Pitch;
            }
        }
    }
}