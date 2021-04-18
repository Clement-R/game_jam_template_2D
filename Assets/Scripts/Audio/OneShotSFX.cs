using Cake.Millefeuille;
using Cake.Opera;

public class OneShotSFX : AOneShotSFX
{
    protected override ISoundSystem GetSoundSystem()
    {
        return Container.Get<SoundsManager>();
    }
}