using Sources.Game.Ecs.Components.Views.CarForwardTriggers;
using UnityEngine;

namespace Sources.Infrastructure.Services
{
    public interface IPhysicsService : IService
    {
        bool AutoSimulation { get; set; }
        void Simulate(float step);
        Collider[] OverlapBox(Vector3 center, Vector3 halfExtents, Quaternion orientation, int layerMask);
        void SyncTransforms();
        bool CheckBox(Vector3 center, Vector3 halfExtents, Quaternion orientation, int layerMask);
        bool CheckBox(IMonoBox monoBox, int layerMask);
    }
}