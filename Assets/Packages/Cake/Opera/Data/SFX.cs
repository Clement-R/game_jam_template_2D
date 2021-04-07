namespace Cake.Opera.Data
{
    [System.Serializable]
    public class SFX
    {
        public SFXEvent Event;
        public SFXSound Sound;

        public SFX(SFXEvent p_event)
        {
            Event = p_event;
        }
    }
}