using System.Collections.Generic;
using Sources.App.Game.GameObjects.RoadSystem.Pathes;
using UnityEngine;

namespace Sources.App.Game.GameObjects.RoadSystem
{
    public class PathSystem : MonoBehaviour, IPathSystem
    {
        private readonly List<PathLine> _pathes = new();

        public IEnumerable<PathLine> Pathes => _pathes;
        public IEnumerable<Road> Roads => GetComponentsInChildren<Road>(true);
        public IEnumerable<Crossroads> Crossroads => GetComponentsInChildren<Crossroads>(true);
    }
}