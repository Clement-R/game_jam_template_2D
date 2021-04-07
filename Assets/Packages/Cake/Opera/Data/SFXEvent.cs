namespace Cake.Opera.Data
{
    [System.Serializable]
    public class SFXEvent
    {
        public string Event;
        public SFX Sound;

        public SFXEvent(string p_event)
        {
            Event = p_event;
        }
    }
}