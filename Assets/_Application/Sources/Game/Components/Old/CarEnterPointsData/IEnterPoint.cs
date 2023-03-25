using UnityEngine;

namespace Sources.Game.Components.Old.CarEnterPointsData
{
    public interface IEnterPoint
    {
        Vector3 Position { get; }
        Quaternion Rotation { get; }
    }
}