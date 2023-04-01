using UnityEngine;

namespace Sources.App.Game.Components.Old.CarEnterPointsData
{
    public interface IEnterPoint
    {
        Vector3 Position { get; }
        Quaternion Rotation { get; }
    }
}