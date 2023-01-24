using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Sources.Game.GameObjects.RoadSystem.Pathes.Points
{
    public class TurnData
    {
        private int _blockedCount = 0;
        public int Delta { get; }
        public Point TargetPoint { get; set; } = null;
        public PathLine FirstPathLine { get; }
        public List<TurnData> BlockableTurns { get; } = new();

        public TurnData(int delta, Point targetPoint, PathLine firstPathLine)
        {
            Delta = delta;
            TargetPoint = targetPoint;
            FirstPathLine = firstPathLine;
        }

        public void IncreaseBlocked()
        {
            // Debug.Log($"block before inc {_blockedCount}");

            // Debug.Log($"inc");
            _blockedCount++;
        }

        public void DecreaseBlocked()
        {
            // Debug.Log($"dec");

            _blockedCount--;
            // Debug.Log($"block after dec {_blockedCount}");
        }

        public bool IsBlocked()
        {
            Assert.IsTrue(_blockedCount >= 0);
            return _blockedCount > 0;
        }
    }
}