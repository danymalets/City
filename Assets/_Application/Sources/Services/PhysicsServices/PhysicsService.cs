using Sources.Utils.CommonUtils.Data;
using UnityEngine;

namespace Sources.Services.PhysicsServices
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
        
        public bool CheckBox(BoxColliderData monoBoxCollider, int layerMask) => 
            CheckBox(monoBoxCollider.Center, monoBoxCollider.HalfExtents, monoBoxCollider.Rotation, layerMask);
        
        public bool CheckCapsule(Vector3 start, Vector3 end, float radius, int layerMask) => 
            Physics.CheckCapsule(start, end, radius, layerMask);

        public void SyncTransforms() => 
            Physics.SyncTransforms();
    }
}