namespace Sources.Infrastructure.Services
{
    public interface IPhysicsService : IService
    {
        bool AutoSimulation { get; set; }
        void Simulate(float step);
    }
}