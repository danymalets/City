using System.Collections.Generic;
using System.Linq;
using _Application.Sources.App.Data.Cars;
using _Application.Sources.App.Data.Pathes;
using _Application.Sources.Utils.CommonUtils.Libs;
using UnityEngine;
using UnityEngine.Assertions;

namespace _Application.Sources.App.Data.Points
{
    public class Point
    {
        public bool IsSpawnPoint { get; }
        public Vector3 Position { get; }
        public Vector3 Direction { get; }
        public List<TurnData> Targets { get; } = new();
        public List<PathLine> Sources { get; } = new();
        public Quaternion Rotation => Quaternion.LookRotation(Direction);

        public Point(Vector3 position, Vector3 direction, bool isSpawnPoint)
        {
            Position = position;
            Direction = direction;
            IsSpawnPoint = isSpawnPoint;
        }

        public bool IsSimple()
        {
            DAssert.IsTrue(Targets.Count != 0);
            return Targets.Count == 1;
        }
        
        public bool IsSimpleBack()
        {
            DAssert.IsTrue(Sources.Count != 0);
            return Sources.Count == 1;
        }

        public PathLine GetSimpleTarget()
        {
            Assert.IsTrue(IsSimple());
            return Targets[0].FirstPathLine;
        }

        public Point GetPreviousPoint()
        {
            Assert.IsTrue(IsSimpleBack());
            return Sources[0].Source;
        }
        
        public TurnData GetSimpleTurn()
        {
            Assert.IsTrue(IsSimple());
            return Targets[0];
        }
        
        public PathLine GetPreviousPathLine()
        {
            Assert.IsTrue(IsSimpleBack());
            return Sources[0];
        }
        
        public TurnData GetPreviousTurn()
        {
            Assert.IsTrue(IsSimpleBack());
            return GetPreviousPoint().Targets.First(td => td.FirstPathLine == Sources[0]);
        }

        public TurnData GetTurn(int delta) => Targets.First(t => t.Delta == delta);
    }
}