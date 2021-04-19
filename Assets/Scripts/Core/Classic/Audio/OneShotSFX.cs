using Cake.Millefeuille;
using Cake.Opera;

namespace Example.Classic
{
    public class OneShotSFX : AOneShotSFX
    {
        protected override ISoundSystem GetSoundSystem()
        {
            return Container.Get<SoundsManager>();
        }
    }
}