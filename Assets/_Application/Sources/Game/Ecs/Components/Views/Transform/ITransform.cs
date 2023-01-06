using Sources.Game.Ecs.Utils;
using UnityEngine;

namespace Sources.Game.Ecs.Components
{
    public interface ITransform : IMonoComponent
    {
        Vector3 Position { get; set; }
        Quaternion Rotation { get; set; }
    }
}