using Sources.Services.SceneLoaderServices;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Common.Scene
{
    public interface ILevelContext : IService, ISceneContext
    {
        Transform UserSpawnPoint { get; }
        Camera CameraMonoEntity { get; }
        IMapCamera MapCamera { get; } 
    }
}