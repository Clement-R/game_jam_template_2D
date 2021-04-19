using Cake.Opera;

namespace Example.Light
{
    public class OneShotSFX : AOneShotSFX
    {
        protected override ISoundSystem GetSoundSystem()
        {
            return SoundsManager.Instance;
        }
    }
}