using Scellecs.Morpeh;
using UnityEngine;

namespace Sources.App.Core.Ecs.Components.Player
{
    public struct PlayerFollowTransform : IComponent
    {
        public Vector3 Position;
        public Quaternion Rotation;
    }
}