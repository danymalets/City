using Sources.Infrastructure.Bootstrap;
using Sources.Infrastructure.Services.Balance;

namespace Sources.Game
{
    public class LevelData
    {
        public int Level { get; }
        public LevelContext LevelContext { get; }

        public LevelBalance LevelBalance { get; }

        public LevelData(int level, LevelContext levelContext, LevelBalance levelBalance)
        {
            Level = level;
            LevelContext = levelContext;
            LevelBalance = levelBalance;
        }
    }
}