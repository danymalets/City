using Scellecs.Morpeh;
using Sources.App.Game.Ecs.MonoEntities;
using Sources.App.Game.GameObjects.RoadSystem.Pathes.Points;
using Sources.AssetsManager;
using Sources.Di;
using UnityEngine;

namespace Sources.App.Game.Ecs.Factories
{
    public interface ICarsFactory : IService
    {
        Entity CreateCar(CarColorData carColorData, Vector3 position, Quaternion rotation);
        Entity CreateCar(CarMonoEntity carPrefab, CarColorType? colorType, Vector3 position, Quaternion rotation);
        Entity CreateRandomCar(Vector3 position, Quaternion rotation);

        bool TryCreateRandomCarOnPath(Point point, out Entity createdCar);
    }
}