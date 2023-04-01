using System.Collections.Generic;
using Sources.Data.RoadSystem.Pathes;
using UnityEngine;

namespace Sources.Data.RoadSystem
{
    public class PathSystem : MonoBehaviour, IPathSystem
    {
        private readonly List<PathLine> _pathes = new();

        public IEnumerable<PathLine> Pathes => _pathes;
        public IEnumerable<Road> Roads => GetComponentsInChildren<Road>(true);
        public IEnumerable<Crossroads> Crossroads => GetComponentsInChildren<Crossroads>(true);
    }
}