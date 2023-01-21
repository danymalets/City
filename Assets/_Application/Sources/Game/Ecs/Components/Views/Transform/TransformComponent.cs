using UnityEngine;

namespace Sources.Game.Ecs.Components.Views.Transform
{
    public class TransformComponent : MonoBehaviour, ITransform
    {
        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        public Quaternion Rotation
        {
            get => transform.rotation;
            set => transform.rotation = value;
        }
    }
}