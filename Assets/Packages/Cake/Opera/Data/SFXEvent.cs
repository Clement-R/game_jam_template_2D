namespace Cake.Opera.Data
{
    [System.Serializable]
    public class SFXEvent
    {
        public string Value = string.Empty;

        public SFXEvent(string p_event)
        {
            Value = p_event;
        }
    }
}