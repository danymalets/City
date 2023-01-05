using Sources.Game.Characters;
using Sources.Game.Ecs.Utils;
using Sources.Game.GameObjects.Cars;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Sources.Infrastructure.Services.AssetsManager
{
    public class AssetsService : MonoBehaviour, IAssetsService
    {
        [SerializeField]
        private string _citySceneNameName;

        [SerializeField]
        private MonoEntity _userCarEntity;

        public string CitySceneName => _citySceneNameName;
        public MonoEntity UserCarMonoEntity => _userCarEntity;
    }
}