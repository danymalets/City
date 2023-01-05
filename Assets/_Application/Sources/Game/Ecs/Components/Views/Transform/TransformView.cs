using Sources.Game.Ecs.Utils;
using UnityEngine;
using UnityEngine.UIElements;

namespace Sources.Game.Ecs.Components
{
    public class TransformView : MonoViewComponent<ITransform>, ITransform
    {
        public Transform Transform => transform;
    }
}