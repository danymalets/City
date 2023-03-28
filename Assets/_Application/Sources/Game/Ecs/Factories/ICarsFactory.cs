using Scellecs.Morpeh;
using Sources.Game.Ecs.MonoEntities;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;
using UnityEngine;

namespace Sources.Game.Ecs.Factories
{
    public interface ICarsFactory : IService
    {
        Entity CreateCar(CarColorData carColorData, Vector3 position, Quaternion rotation);
        Entity CreateCar(CarMonoEntity carPrefab, CarColorType? colorType, Vector3 position, Quaternion rotation);
        Entity CreateRandomCar(Vector3 position, Quaternion rotation);

        bool TryCreateRandomCarOnPath(Point point, out Entity createdCar);
    }
}