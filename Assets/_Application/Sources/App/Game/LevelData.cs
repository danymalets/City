using Sources.Monos;

namespace Sources.App.Game
{
    public class LevelData
    {
        public int Level { get; }
        public LevelContext LevelContext { get; }

        public LevelData(int level, LevelContext levelContext)
        {
            Level = level;
            LevelContext = levelContext;
        }
    }
}