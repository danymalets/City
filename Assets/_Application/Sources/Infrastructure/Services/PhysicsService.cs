using Sources.Game.Ecs.Components.Views.CarForwardTriggers;
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

        public bool CheckBox(Vector3 center, Vector3 halfExtents, Quaternion orientation, int layerMask) => 
            Physics.CheckBox(center, halfExtents, orientation, layerMask, QueryTriggerInteraction.Ignore);
        
        public bool CheckBox(IMonoBox monoBox, int layerMask) => 
            CheckBox(monoBox.Center, monoBox.HalfExtents, monoBox.Rotation, layerMask);

        public void SyncTransforms() => 
            Physics.SyncTransforms();
    }
}