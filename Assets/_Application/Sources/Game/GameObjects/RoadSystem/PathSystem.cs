using System.Collections.Generic;
using Sources.Game.GameObjects.RoadSystem.Pathes;
using Sources.Infrastructure.Services;
using UnityEngine;

namespace Sources.Game.GameObjects.RoadSystem
{
    public class PathSystem : MonoBehaviour, IPathesAccessService
    {
        private readonly List<Path> _pathes = new List<Path>();

        public IEnumerable<Path> Pathes => _pathes;

        private void Awake()
        {
            foreach (PathGenerator pathGenerator in FindObjectsOfType<PathGenerator>())
            {
                _pathes.AddRange(pathGenerator.Generate());
            }
        }

        private void OnEnable()
        {
        }

        private void OnDisable()
        {
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            foreach (Path path in _pathes)
            {
                Gizmos.DrawLine(path.Source.Position, path.Target.Position);
            }
        }    
    }

    public interface IPathesAccessService : IService
    {
        IEnumerable<Path> Pathes { get; }
    }
}