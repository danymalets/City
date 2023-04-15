using Scellecs.Morpeh;
using UnityEngine;

namespace _Application.Sources.App.Core.Ecs.Components.Car
{
    public struct ForwardTrigger : IComponent
    {
        public Vector3 Center;
        public Quaternion Rotation;
        public Vector3 Size;
    }
}