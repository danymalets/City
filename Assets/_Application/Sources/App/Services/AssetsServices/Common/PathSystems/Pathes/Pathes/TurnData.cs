using System.Collections.Generic;
using UnityEngine.Assertions;

namespace Sources.App.Services.AssetsServices.Common.PathSystems.Pathes.Pathes
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
        public PathPoint TargetPoint { get; set; }
        public PathLine FirstPathLine { get; }
        
        public PathPoint DependentPoint { get; set; }
        public List<TurnData> BlockableTurns { get; } = new();

        public TurnData(int delta, PathPoint targetPoint, PathLine firstPathLine)
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