using System.Collections.Generic;
using Sources.Game.Ecs.Utils;
using Sources.Game.GameObjects.RoadSystem.Pathes;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using Sources.Infrastructure.Services;
using Sources.Utilities.Extensions;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Game.GameObjects.RoadSystem
{
    public class PathSystem : MonoBehaviour, IPathSystem
    {
        private readonly List<PathLine> _pathes = new();

        public IEnumerable<PathLine> Pathes => _pathes;
        public IEnumerable<Road> Roads => GetComponentsInChildren<Road>();
        public IEnumerable<Crossroads> Crossroads => GetComponentsInChildren<Crossroads>();
    }
}