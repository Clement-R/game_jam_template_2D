using Cake.Opera.Data;

public interface ISoundSystem
{
    void PlaySFX(string p_eventName);

    void PlaySFX(SFXEvent p_event);

    void Play(SFXSound p_sfx);
}