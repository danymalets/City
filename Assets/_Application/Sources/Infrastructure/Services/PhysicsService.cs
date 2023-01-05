using UnityEngine;

namespace Sources.Infrastructure.Services
{
    public class PhysicsService : IPhysicsService
    {
        private bool _autoSimulate;

        public bool AutoSimulation
        {
            get => Physics.autoSimulation;
            set => Physics.autoSimulation = value;
        }

        public void Simulate(float step) => 
            Physics.Simulate(step);
    }
}