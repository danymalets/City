using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Sources.Game.GameObjects.RoadSystem.Pathes.Points
{
    public class TurnData
    {
        private int _blockedCount = 0;
        
        /// <summary>
        /// Describe turn direction:
        /// -1: left turn,
        /// 0: forward turn,
        /// 1: right turn.
        /// </summary>
        public int Delta { get; }
        public Point TargetPoint { get; set; }
        public PathLine FirstPathLine { get; }
        
        public Point DependentPoint { get; set; }
        public List<TurnData> BlockableTurns { get; } = new();

        public TurnData(int delta, Point targetPoint, PathLine firstPathLine)
        {
            Delta = delta;
            TargetPoint = targetPoint;
            FirstPathLine = firstPathLine;
        }

        public void IncreaseBlocked()
        {
            _blockedCount++;
        }

        public void DecreaseBlocked()
        {
            _blockedCount--;
        }

        public bool IsBlocked()
        {
            Assert.IsTrue(_blockedCount >= 0);
            return _blockedCount > 0;
        }

    }
}