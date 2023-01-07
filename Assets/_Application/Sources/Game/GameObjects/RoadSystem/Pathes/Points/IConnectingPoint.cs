using System.Collections.Generic;
using UnityEngine;

namespace Sources.Game.GameObjects.RoadSystem.Pathes.Points
{
    public interface IConnectingPoint
    {
        bool IsRoot { get; }
        Vector3 Position { get; }
        Quaternion Rotation { get; }
        List<Path> Sources { get; }
        List<Path> Targets { get; }
    }
}