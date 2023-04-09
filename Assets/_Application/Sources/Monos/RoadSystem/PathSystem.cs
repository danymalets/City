using System.Collections.Generic;
using Sources.Data;
using Sources.Data.Pathes;
using Sources.Monos.RoadSystem.Pathes;
using UnityEngine;

namespace Sources.Monos.RoadSystem
{
    public class PathSystem : MonoBehaviour, IPathSystem
    {
        private readonly List<PathLine> _pathes = new();

        public IEnumerable<PathLine> Pathes => _pathes;
        public IEnumerable<IRoad> Roads => GetComponentsInChildren<Road>(true);
        public IEnumerable<ICrossroads> Crossroads => GetComponentsInChildren<Crossroads>(true);
    }
}