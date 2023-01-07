using Sources.Game.Ecs.Utils;
using UnityEngine;
using UnityEngine.UIElements;

namespace Sources.Game.Ecs.Components
{
    public class TransformComponent : MonoProvider<ITransform>, ITransform
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