namespace Sources.App.Services.AssetsServices.Common.IdleCarSpawns.Common
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