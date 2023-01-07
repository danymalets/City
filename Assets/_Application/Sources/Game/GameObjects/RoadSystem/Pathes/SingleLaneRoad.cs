using System.Collections.Generic;
using System.Linq;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.GameObjects.RoadSystem.Pathes
{
    public class SingleLaneRoad : PathGenerator
    {
        private const float MinLength = 5f;
        
        [SerializeField]
        private PathData[] _pathData;

        public override IEnumerable<Path> Generate()
        {
            return _pathData.SelectMany(GetPathes);
        }

        private static IEnumerable<Path> GetPathes(PathData pathData)
        {
            List<IConnectingPoint> points = new();

            Vector3 source = pathData.Source.Position;
            Vector3 target = pathData.Target.Position;

            float distance = Vector3.Distance(source, target);

            int pointsCount = Mathf.CeilToInt(distance / MinLength) + 1;

            for (int i = 0; i <= pointsCount; i++)
            {
                float progress = (float)i / pointsCount;
                Vector3 position = Vector3.Lerp(source, target, progress);
                
                if (i == 0)
                    points.Add(pathData.Source);
                else if (i == pointsCount)
                    points.Add(pathData.Target);
                else
                    points.Add(new AdditionalPoint(position, Quaternion.LookRotation(target - source), true));
            }

            for (int i = 0; i < points.Count - 1; i++)
            {
                yield return new Path(points[i], points[i + 1]);
            }
        }

        public IEnumerable<Checkpoint> Sources => _pathData.Select(pathData => pathData.Source);
        public IEnumerable<Checkpoint> Targets => _pathData.Select(pathData => pathData.Target);
    }
}