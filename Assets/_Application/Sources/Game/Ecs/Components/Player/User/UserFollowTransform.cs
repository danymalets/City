using Scellecs.Morpeh;
using UnityEngine;

namespace Sources.Game.Ecs.Components.Player.User
{
    public struct UserFollowTransform : IComponent
    {
        public Vector3 Position;
        public Quaternion Rotation;
    }
}