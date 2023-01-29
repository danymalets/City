using Sources.Game.Ecs.Utils;
using UnityEngine;

namespace Sources.Game.Ecs.Components.Views.Transform
{
    public interface ITransform : IMonoComponent
    {
        Vector3 Position { get; set; }
        Quaternion Rotation { get; set; }
        Vector3 TransformPoint(Vector3 point);
        Vector3 InverseTransformPoint(Vector3 point);
    }
}