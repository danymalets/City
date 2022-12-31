using Sources.Infrastructure.Services.SceneLoader;
using UnityEngine;

namespace Sources.Infrastructure.Services.Balance
{
    [CreateAssetMenu(fileName = "Level_", menuName = "Level Balance")]
    public class LevelBalance : ScriptableObject
    {
        [SerializeField]
        private int _level;
        [SerializeField]
        private LevelSceneType _levelSceneType;

        public int Level => _level;
        public LevelSceneType LevelSceneType => _levelSceneType;
    }
}