using Sources.Infrastructure.Services.Balance;

namespace Sources.Game
{
    public class LevelData
    {
        public int Level { get; }

        public LevelBalance LevelBalance { get; }

        public LevelData(int level, LevelBalance levelBalance)
        {
            Level = level;
            LevelBalance = levelBalance;
        }
    }
}