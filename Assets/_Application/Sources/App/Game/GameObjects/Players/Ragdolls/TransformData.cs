using UnityEngine;

namespace Sources.App.Game.GameObjects.Players.Ragdolls
{
    public class TransformData
    {
        public Transform Transform { get; }
        public Vector3 Position { get; }
        public Quaternion Rotation { get; }

        public TransformData(Transform transform, Vector3 position, Quaternion rotation)
        {
            Transform = transform;
            Position = position;
            Rotation = rotation;
        }
    }
}