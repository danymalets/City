using Sources.Infrastructure.Bootstrap;
using Sources.Infrastructure.Services.Balance;

namespace Sources.Game
{
    public class LevelData
    {
        public int Level { get; }
        public LevelContextService LevelContext { get; }


        public LevelData(int level, LevelContextService levelContext)
        {
            Level = level;
            LevelContext = levelContext;
        }
    }
}