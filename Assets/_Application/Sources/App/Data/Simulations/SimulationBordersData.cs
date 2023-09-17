namespace Sources.App.Data.Simulations
{
    public struct SimulationBordersData
    {
        public float Radius { get; }
        public float BackDistance { get; }
        public float Delta { get; }

        public SimulationBordersData(float radius, float backDistance, float delta)
        {
            Radius = radius;
            BackDistance = backDistance;
            Delta = delta;
        }
    }
}