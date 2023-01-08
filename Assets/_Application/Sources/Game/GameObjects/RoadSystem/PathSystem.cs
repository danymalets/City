using System.Collections.Generic;
using Sources.Game.Ecs.Utils;
using Sources.Game.GameObjects.RoadSystem.Pathes;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using Sources.Infrastructure.Services;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.GameObjects.RoadSystem
{
    public class PathSystem : MonoBehaviour, IPathSystem
    {
        private readonly List<Path> _pathes = new();
        private readonly HashSet<IConnectingPoint> _points = new ();
        private readonly List<IConnectingPoint> _rootPoints = new();

        public IEnumerable<Path> Pathes => _pathes;
        public IEnumerable<IConnectingPoint> RootPoints => _rootPoints;

        private void Awake()
        {
            foreach (PathGenerator pathGenerator in FindObjectsOfType<PathGenerator>())
            {
                _pathes.AddRange(pathGenerator.Generate());
            }

            foreach (Path path in _pathes)
            {
                _points.Add(path.Source);
                _points.Add(path.Target);
            }

            foreach (IConnectingPoint point in _points)
            {
                if (point.IsRoot)
                    _rootPoints.Add(point);
            }

            // foreach (IConnectingPoint point in _points)
            // {
            //     if (!point.IsRoot)
            //         continue;
            //     
            //     GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //     sphere.transform.position = point.Position;
            //     sphere.transform.localScale *= 0.8f;
            //
            //     
            //     GameObject sphere0 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //     sphere0.transform.position = point.Position + 0.8f * point.Rotation.GetForward();
            //     sphere0.transform.localScale *= 0.4f;
            // }
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            foreach (Path path in _pathes)
            {
                Gizmos.DrawLine(path.Source.Position, path.Target.Position);
            }
            
            Gizmos.color = Color.black;
            foreach (IConnectingPoint point in _rootPoints)
            {
                Gizmos.DrawCube(point.Position, Vector3.one * 1f);
            }
        }    
    }
}