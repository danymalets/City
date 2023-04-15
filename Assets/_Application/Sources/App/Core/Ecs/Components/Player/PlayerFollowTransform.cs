using Scellecs.Morpeh;
using UnityEngine;

namespace _Application.Sources.App.Core.Ecs.Components.Player
{
    public struct PlayerFollowTransform : IComponent
    {
        public Vector3 Position;
        public Quaternion Rotation;
    }
}