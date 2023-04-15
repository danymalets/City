using _Application.Sources.App.Data.Common;

namespace _Application.Sources.App.Data
{
    public class LevelData
    {
        public int Level { get; }
        public ILevelContext LevelContext { get; }

        public LevelData(int level, ILevelContext levelContext)
        {
            Level = level;
            LevelContext = levelContext;
            
        }
    }
}