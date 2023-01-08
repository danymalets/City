using Sources.Game.Characters;
using Sources.Game.Ecs.MonoEntities;
using Sources.Game.Ecs.Utils;
using Sources.Game.GameObjects.Cars;
using UnityEditor;
using UnityEngine;

namespace Sources.Infrastructure.Services.AssetsManager
{
    public interface IAssetsService : IService
    {
        string CitySceneName { get; }
        CarMonoEntity CarMonoEntity { get; }
    }
}