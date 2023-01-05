using Sources.Game.Ecs.Utils;
using UnityEngine;

namespace Sources.Game.Ecs.Components
{
    public interface ITransform : IMono
    {
        Transform Transform { get; }
    }
}