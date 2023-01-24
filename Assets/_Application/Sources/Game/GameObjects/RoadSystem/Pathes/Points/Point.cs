using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Sources.Game.GameObjects.RoadSystem.Pathes.Points
{
    public class Point
    {
        public bool IsSpawnPoint { get; }
        public Vector3 Position { get; }
        public Vector3 Direction { get; }
        public List<TurnData> Targets { get; } = new();
        public List<PathLine> Sources { get; } = new();
        
        public Point(Vector3 position, Vector3 direction, bool isSpawnPoint)
        {
            Position = position;
            Direction = direction;
            IsSpawnPoint = isSpawnPoint;
        }

        public bool IsSimple()
        {
            Assert.IsTrue(Targets.Count != 0);
            return Targets.Count == 1;
        }
        
        public bool IsSimpleBack()
        {
            Assert.IsTrue(Sources.Count != 0);
            return Sources.Count == 1;
        }

        public PathLine GetSimpleTarget()
        {
            Assert.IsTrue(IsSimple());
            return Targets[0].FirstPathLine;
        }
        
        public TurnData GetSimpleTurn()
        {
            Assert.IsTrue(IsSimple());
            return Targets[0];
        }

        public TurnData GetSimpleSourceTurn()
        {
            Assert.IsTrue(IsSimpleBack());
            return Sources[0].Source.Targets.First(td => td.FirstPathLine == Sources[0]);
        }
    }
}