using System.Collections.Generic;
using UnityEngine;

namespace Sources.Game.GameObjects.RoadSystem.Pathes.Points
{
    public class AdditionalPoint : IConnectingPoint
    {
        public Vector3 Position { get; }
        public List<Path> Sources { get; } = new List<Path>();
        public List<Path> Targets { get; } = new List<Path>();

        public AdditionalPoint(Vector3 position)
        {
            Position = position;
        }
    }
}