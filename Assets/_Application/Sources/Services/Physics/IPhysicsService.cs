using _Application.Sources.Utils.Data;
using Sources.Di;
using UnityEngine;

namespace Sources.Services.Physics
{
    public interface IPhysicsService : IService
    {
        bool AutoSimulation { get; set; }
        void Simulate(float step);
        Collider[] OverlapBox(Vector3 center, Vector3 halfExtents, Quaternion orientation, int layerMask);
        void SyncTransforms();
        bool CheckBox(Vector3 center, Vector3 halfExtents, Quaternion orientation, int layerMask);
        bool CheckBox(BoxColliderData monoBoxCollider, int layerMask);
        bool CheckCapsule(Vector3 start, Vector3 end, float radius, int layerMask);
    }
}