using Sources.Game.Ecs.Utils;
using UnityEngine;

namespace Sources.Game.Ecs.Components.Views.CarForwardTriggers
{
    public interface IMonoBox : IMonoComponent
    {
        Vector3 Center { get; }

        Vector3 HalfExtents { get; }
        
        Quaternion Rotation { get; }
    }
}