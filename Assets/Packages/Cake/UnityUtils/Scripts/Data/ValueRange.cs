namespace Cake.Data
{
    [System.Serializable]
    public class ValueRange
    {
        public float Min;
        public float Max;

        public ValueRange(float p_min, float p_max)
        {
            Min = p_min;
            Max = p_max;
        }

        public float Random()
        {
            return UnityEngine.Random.Range(Min, Max);
        }
    }
}