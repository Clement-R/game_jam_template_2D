using System.Collections.Generic;

using UnityEngine;

using Cake.Data;

namespace Cake.Opera.Data
{
    [CreateAssetMenu(fileName = "SFX", menuName = "Game/SFX", order = 1)]
    public class SFX : ScriptableObject
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
        [Range(0f, 1f)]
        public float Pitch = 0.5f;
        public ValueRange PitchRange = new ValueRange(0f, 1f);
    }
}