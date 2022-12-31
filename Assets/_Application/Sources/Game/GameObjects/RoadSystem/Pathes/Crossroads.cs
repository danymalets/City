using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using UnityEngine;

namespace Sources.Game.GameObjects.RoadSystem.Pathes
{
    public class Crossroads : PathGenerator
    {
        private const int Segments = 10;

        [SerializeField]
        private Road _up;

        [SerializeField]
        private Road _right;

        [SerializeField]
        private Road _down;

        [SerializeField]
        private Road _left;

        public override IEnumerable<Path> Generate()
        {
            List<CrossroadsSideData> sideData = GetSideData();
            List<Path> pathes = new List<Path>();

            foreach (CrossroadsSideData firstSideData in sideData)
            {
                foreach (CrossroadsSideData secondSideData in sideData)
                {
                    if (firstSideData != secondSideData)
                    {
                        pathes.AddRange(GetPathes(
                            firstSideData.Targets, secondSideData.Sources));
                    }
                }
            }

            return pathes;
        }

        private List<CrossroadsSideData> GetSideData()
        {
            List<CrossroadsSideData> sideData = new List<CrossroadsSideData>();

            foreach (Road road in new[] { _up, _right, _down, _left })
            {
                if (road == null)
                    continue;

                road.GetCheckpoints(transform.position,
                    out IEnumerable<Checkpoint> sources,
                    out IEnumerable<Checkpoint> targets);

                sideData.Add(new CrossroadsSideData(sources, targets));
            }

            return sideData;
        }

        private IEnumerable<Path> GetPathes(
            IEnumerable<Checkpoint> sourcesEnumerable,
            IEnumerable<Checkpoint> targetsEnumerable)
        {
            Checkpoint[] sources = sourcesEnumerable.ToArray();
            Checkpoint[] targets = targetsEnumerable.ToArray();

            List<Path> pathes = new List<Path>();

            for (int i = 0; i < Mathf.Min(sources.Length, targets.Length); i++)
            {
                pathes.AddRange(GetPathes(sources[i], targets[i]));
            }

            return pathes;
        }

        private IEnumerable<Path> GetPathes(
            Checkpoint source,
            Checkpoint target)
        {
            List<IConnectingPoint> points = new List<IConnectingPoint>();

            Vector3 anchor = GetAnchorPoint(source, target);

            for (int i = 0; i <= Segments; i++)
            {
                float progress = (float)i / Segments;
                Vector3 first = Vector3.Lerp(source.Position, anchor, progress);
                Vector3 second = Vector3.Lerp(anchor, target.Position, progress);
                Vector3 result = Vector3.Lerp(first, second, progress);

                if (i == 0)
                    points.Add(source);
                else if (i == Segments)
                    points.Add(target);
                else
                    points.Add(new AdditionalPoint(result));
            }

            List<Path> pathes = new List<Path>();

            for (int i = 0; i < points.Count - 1; i++)
            {
                pathes.Add(new Path(points[i], points[i + 1]));
            }

            return pathes;
        }

        private Vector3 GetAnchorPoint(Checkpoint source, Checkpoint target)
        {
            if (!Mathf.Approximately(source.Direction.x, 0))
                return new Vector3(target.Position.x, source.Position.y, source.Position.z);
            else if (!Mathf.Approximately(source.Direction.z, 0))
                return new Vector3(source.Position.x, source.Position.y, target.Position.z);
            else
                throw new InvalidOperationException();
        }
    }
}