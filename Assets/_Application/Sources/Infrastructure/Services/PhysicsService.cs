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

        public Collider[] OverlapBox(Vector3 center, Vector3 halfExtents, Quaternion orientation, int layerMask) => 
            Physics.OverlapBox(center, halfExtents, orientation, layerMask, QueryTriggerInteraction.Ignore);

        public void SyncTransforms() => 
            Physics.SyncTransforms();
    }
}