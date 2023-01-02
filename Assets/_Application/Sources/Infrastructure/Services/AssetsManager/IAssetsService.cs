using Sources.Game.Characters;
using Sources.Game.GameObjects.Cars;
using UnityEditor;
using UnityEngine;

namespace Sources.Infrastructure.Services.AssetsManager
{
    public interface IAssetsService : IService
    {
        GameObject CarPrefab { get; }
        GameObject PlayerPrefab { get; }
        string CityScene { get; }
    }
}