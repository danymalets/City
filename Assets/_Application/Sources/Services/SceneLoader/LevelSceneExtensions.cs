using System;

namespace Sources.Services.SceneLoader
{
    public static class LevelSceneExtensions
    {
        public static string GetSceneName(this LevelSceneType sceneType)
        {
            switch (sceneType)
            {
                case LevelSceneType.Main: return nameof(LevelSceneType.Main);
                default: throw new ArgumentOutOfRangeException(nameof(sceneType), sceneType, null);
            }
        }
    }
}