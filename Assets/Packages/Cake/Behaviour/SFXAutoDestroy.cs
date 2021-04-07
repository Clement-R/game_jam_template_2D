using UnityEngine;

using Cake.Behaviour;

namespace Cake.Behaviour
{
    public class SFXAutoDestroy : AutoDestroy
    {
        protected override float GetDuration()
        {
            var audioSource = GetComponent<AudioSource>();
            if (audioSource == null || audioSource.clip == null)
                return 0f;

            return audioSource.clip.length;
        }
    }
}