using System.Collections.Generic;
using UnityEngine;

namespace Sources.Game.GameObjects.RoadSystem.Pathes.Points
{
    public class AdditionalPoint : IConnectingPoint
    {
        public bool IsRoot { get; }
        public Vector3 Position { get; }
        public Quaternion Rotation { get; set; }
        public List<Path> Sources { get; } = new();
        public List<Path> Targets { get; } = new();

        public AdditionalPoint(Vector3 position, Quaternion rotation, bool isRoot)
        {
            Position = position;
            Rotation = rotation;
            IsRoot = isRoot;
        }
    }
}