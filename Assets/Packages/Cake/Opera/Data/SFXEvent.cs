using System;

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

        public override bool Equals(Object p_obj)
        {
            //Check for null and compare run-time types.
            if ((p_obj == null) || !this.GetType().Equals(p_obj.GetType()))
            {
                return false;
            }
            else
            {
                SFXEvent p = (SFXEvent) p_obj;
                return Value == p.Value;
            }
        }

        public static bool operator ==(SFXEvent p_obj1, SFXEvent p_obj2)
        {
            return p_obj1.Value == p_obj2.Value;
        }

        public static bool operator !=(SFXEvent p_obj1, SFXEvent p_obj2)
        {
            return p_obj1.Value != p_obj2.Value;
        }
    }
}