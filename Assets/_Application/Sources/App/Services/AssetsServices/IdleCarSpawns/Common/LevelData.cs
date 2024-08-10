namespace Sources.App.Services.AssetsServices.IdleCarSpawns.Common
{
    public class LevelData
    {
        public int Level { get; }
        public LevelSceneContext LevelContext { get; }

        public LevelData(int level, LevelSceneContext levelContext)
        {
            Level = level;
            LevelContext = levelContext;
            
        }
    }
}