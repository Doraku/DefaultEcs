namespace DefaultSlap.Component
{
    public struct HitDelay
    {
        public float Delay;
        public float Current;

        public HitDelay(float value)
        {
            Delay = value;
            Current = value;
        }
    }
}
