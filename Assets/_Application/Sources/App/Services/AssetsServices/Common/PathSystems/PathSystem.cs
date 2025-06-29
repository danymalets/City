using System.Collections.Generic;
using Sources.App.Services.AssetsServices.Common.PathSystems.Pathes;
using Sources.App.Services.AssetsServices.Common.PathSystems.Pathes.Pathes;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Common.PathSystems
{
    public class PathSystem : MonoBehaviour, IPathSystem
    {
        private readonly List<PathLine> _pathes = new();

        public IEnumerable<PathLine> Pathes => _pathes;
        public IEnumerable<IRoad> Roads => GetComponentsInChildren<Road>(true);
        public IEnumerable<ICrossroads> Crossroads => GetComponentsInChildren<Crossroads>(true);
    }
}