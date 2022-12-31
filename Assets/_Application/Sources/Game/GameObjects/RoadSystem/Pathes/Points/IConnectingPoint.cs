using System.Collections.Generic;
using UnityEngine;

namespace Sources.Game.GameObjects.RoadSystem.Pathes.Points
{
    public interface IConnectingPoint
    {
        Vector3 Position { get; }
        List<Path> Sources { get; }
        List<Path> Targets { get; }
    }
}