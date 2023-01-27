using UnityEngine;

namespace Sources.Game.Ecs.Components.Views.CarEnterPointsData
{
    public interface IEnterPoint
    {
        Vector3 Position { get; }
        Quaternion Rotation { get; }
    }
}