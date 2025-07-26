using System.Collections.Generic;
using Sources.App.Services.AssetsServices.Common.Scene;
using Sources.Services.SceneLoaderServices;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.SceneContexts
{
    public partial class LevelSceneContext : SceneContext, ILevelContext
    {
        [SerializeField]
        private Transform _userSpawnPoint;

        [SerializeField]
        private Camera _cameraMonoEntity;

        [SerializeField]
        private MapCamera _mapCamera;
        
        public Transform UserSpawnPoint => _userSpawnPoint;
        public Camera CameraMonoEntity => _cameraMonoEntity;
        public IMapCamera MapCamera => _mapCamera;
    }
}