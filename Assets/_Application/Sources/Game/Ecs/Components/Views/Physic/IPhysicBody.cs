using Sources.Game.Ecs.Utils;
using UnityEngine;

namespace Sources.Game.Ecs.Components.Views
{
    public interface IPhysicBody : IMonoComponent
    {
        float SignedSpeed { get; }
        Vector3 Velocity { get; set; }
        Vector3 LocalVelocity { get; set; }
    }
}