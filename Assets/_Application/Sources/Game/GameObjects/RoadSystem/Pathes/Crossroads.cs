using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using Sources.Utilities;
using Sources.Utilities.Extensions;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Sources.Game.GameObjects.RoadSystem.Pathes
{
    public class Crossroads : PathGenerator
    {
        private const int PointsCount = 8;

        public Road Up;

        public Road Right;

        public Road Down;

        public Road Left;
        
        private Road[] GetAllRoads() => new Road[] { Up, Right, Down, Left };
        
        private float _oneRoadLength;
        

        public override IEnumerable<Path> Generate()
        {
            List<CrossroadsSideData> sideData = GetSideData();
            List<Path> pathes = new();

            foreach (CrossroadsSideData firstSideData in sideData)
            {
                foreach (CrossroadsSideData secondSideData in sideData)
                {
                    if (firstSideData != secondSideData)
                    {
                        pathes.AddRange(GetPathes(
                            firstSideData.Targets, secondSideData.Sources, 
                            GetAllRoads().First(r => r != null).OneRoadLength / 2));
                    }
                }
            }

            return pathes;
        }

        private List<CrossroadsSideData> GetSideData()
        {
            List<CrossroadsSideData> sideData = new();

            foreach (Road road in new[] { Up, Right, Down, Left })
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
            IEnumerable<Checkpoint> targetsEnumerable,
            float turnLength)
        {
            Checkpoint[] sources = sourcesEnumerable.ToArray();
            Checkpoint[] targets = targetsEnumerable.ToArray();

            List<Path> pathes = new();

            for (int i = 0; i < Mathf.Min(sources.Length, targets.Length); i++)
            {
                pathes.AddRange(GetPathes(sources[i], targets[i], turnLength));
            }

            return pathes;
        }

        private IEnumerable<Path> GetPathes(
            Checkpoint source,
            Checkpoint target,
            float turnLength)
        {
            if (DMath.Equals(source.Position.z, target.Position.z) ||
                DMath.Equals(source.Position.x, target.Position.x))
            {
                List<Path> tpathes = new() { new Path(source, target) };
                return tpathes;
            }
            
            
            List<IConnectingPoint> points = new();

            Vector3 anchor = GetAnchorPoint(source, target);

            Vector3 sourcePosition = Vector3.MoveTowards(anchor, source.Position, turnLength);
            Vector3 targetPosition = Vector3.MoveTowards(anchor, target.Position, turnLength);
            
            for (int i = 0; i <= PointsCount; i++)
            {
                float progress = (float)i / PointsCount;
                Vector3 first = Vector3.Lerp(sourcePosition, anchor, progress);
                Vector3 second = Vector3.Lerp(anchor, targetPosition, progress);
                Vector3 result = Vector3.Lerp(first, second, progress);

                
                if (i == 0)
                    points.Add(source);
                else if (i == PointsCount)
                    points.Add(target);
                else
                    points.Add(new AdditionalPoint(result, Quaternion.identity,false));
            }

            List<Path> pathes = new();

            for (int i = 0; i < points.Count - 1; i++)
            {
                pathes.Add(new Path(points[i], points[i + 1]));
            }

            return pathes;
        }

        private Vector3 GetAnchorPoint(Checkpoint source, Checkpoint target)
        {
            if (DMath.NotEquals(source.Direction.x, 0))
                return new Vector3(target.Position.x, source.Position.y, source.Position.z);
            else if (DMath.NotEquals(source.Direction.z, 0))
                return new Vector3(source.Position.x, source.Position.y, target.Position.z);
            else
                throw new InvalidOperationException();
        }
    }
}