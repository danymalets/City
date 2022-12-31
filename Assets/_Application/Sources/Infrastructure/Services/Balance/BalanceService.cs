using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Sources.Infrastructure.Services.Balance
{
    public class BalanceService : IBalanceService
    {
        private const string BalancePath = "Balance";
        private const string LevelBalancePattern = "Level_{0}";
        
        private LevelBalance[] _levelBalances;
        
        public int LevelsCount { get; private set; }

        public void Load()
        {
            LevelsCount = Resources.LoadAll<LevelBalance>(BalancePath).Length;
            
            _levelBalances = new LevelBalance[LevelsCount];

            for (int level = 1; level <= LevelsCount; level++)
            {
                string path = Path.Combine(BalancePath, string.Format(LevelBalancePattern, level));
                LevelBalance levelBalance = Resources.Load<LevelBalance>(path);

                if (levelBalance == null)
                    throw new NullReferenceException($"Level {level} balance not found");

                _levelBalances[level - 1] = levelBalance;
            }
        }
        
        public LevelBalance GetLevelBalance(int levelNumber) =>
            _levelBalances[levelNumber - 1];

        public IEnumerable<LevelBalance> LevelData => _levelBalances;
    }   
}