using UnityEngine;

using Cake.Behaviour;
using Cake.Opera.Data;
using Cake.Pooling;

public class SoundSystem
{
    private Sounds m_sounds;
    private GameObject m_oneShotSFX;

    public SoundSystem(Sounds p_sounds, GameObject p_oneShotSFX)
    {
        m_sounds = p_sounds;
        m_oneShotSFX = p_oneShotSFX;
    }

    public void PlaySFX(string p_eventName)
    {
        SFXSound sfx = m_sounds.Get(p_eventName);
        if (sfx == null)
        {
            Debug.Log($"{p_eventName} wasn't found in registered sounds");
        }

        Play(sfx);
    }

    public void PlaySFX(SFXEvent p_event)
    {
        SFXSound sfx = m_sounds.Get(p_event);
        if (sfx == null)
        {
            Debug.Log($"{p_event.Value} wasn't found in registered sounds");
        }

        Play(sfx);
    }

    public void Play(SFXSound p_sfx)
    {
        var player = SimplePool.Spawn(m_oneShotSFX);

        var audioSource = player.GetComponent<AudioSource>();
        audioSource.clip = p_sfx.GetClip();
        audioSource.volume = p_sfx.GetVolume();
        audioSource.pitch = p_sfx.GetPitch();
        audioSource.outputAudioMixerGroup = p_sfx.MixerGroup;
        audioSource.Play();

        var autoDestroy = player.GetComponent<SFXAutoDestroy>();
        autoDestroy.Destroy();
    }
}