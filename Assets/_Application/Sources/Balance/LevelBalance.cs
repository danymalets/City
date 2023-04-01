using Sources.Services.SceneLoader;
using UnityEngine;

namespace Sources.Balance
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