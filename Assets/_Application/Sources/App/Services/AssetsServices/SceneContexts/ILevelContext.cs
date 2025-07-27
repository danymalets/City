using Sources.App.Services.AssetsServices.Common.Scene;
using Sources.Services.SceneLoaderServices;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.SceneContexts
{
    public interface ILevelContext : IService, ISceneContext
    {
        Transform UserSpawnPoint { get; }
        Camera CameraMonoEntity { get; }
        IMapCamera MapCamera { get; } 
    }
}