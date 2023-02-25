using Sources.Game.Ecs.Utils;
using UnityEngine;

namespace Sources.Game.Ecs.Components.Views.Physic
{
    public interface IPhysicBody : IMonoComponent
    {
        void DestroyBody();
        float SignedSpeed { get; }
        Vector3 Velocity { get; set; }
        Vector3 LocalVelocity { get; set; }
        Vector3 Position { get; set; }
        Quaternion Rotation { get; set; }
        void MoveRotation(Quaternion euler);
    }
}