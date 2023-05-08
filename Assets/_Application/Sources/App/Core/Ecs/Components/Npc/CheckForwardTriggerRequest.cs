using Scellecs.Morpeh;
using UnityEngine;

namespace Sources.App.Core.Ecs.Components.Npc
{
    public struct CheckForwardTriggerRequest : IComponent
    {
        public Vector3 Center;
        public Quaternion Rotation;
        public Vector3 Size;
    }
}