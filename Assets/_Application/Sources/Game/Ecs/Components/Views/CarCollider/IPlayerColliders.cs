using Sources.Game.Ecs.Utils;
using UnityEngine;

namespace Sources.Game.Ecs.Components.Views.CarCollider
{
    public interface IPlayerColliders : IMonoComponent
    {
        Collider[] Colliders { get; }
    }
}