
using UnityEngine;

namespace Sources.Game.Components.Old.CarCollider
{
    public struct BoxColliderData
    {
        public Vector3 Center { get; }

        public Vector3 HalfExtents { get; }
        
        public Quaternion Rotation { get; }

        public BoxColliderData(Vector3 center, Vector3 halfExtents, Quaternion rotation)
        {
            Center = center;
            HalfExtents = halfExtents;
            Rotation = rotation;
        }
    }
}