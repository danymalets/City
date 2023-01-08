using Sources.Game.Ecs.Utils;
using UnityEngine;

namespace Sources.Game.Ecs.Components.Views.CarBorder
{
    public interface ICarBorders : IMonoComponent
    {
        Vector3 Center { get; }
        Vector3 HalfExtents { get; }
    }
}