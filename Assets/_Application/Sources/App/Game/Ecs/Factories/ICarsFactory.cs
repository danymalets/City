using Scellecs.Morpeh;
using Sources.Data;
using Sources.Data.MonoViews;
using Sources.Services.Di;
using UnityEngine;

namespace Sources.App.Game.Ecs.Factories
{
    public interface ICarsFactory : IService
    {
        Entity CreateCar(CarColorData carColorData, Vector3 position, Quaternion rotation);
        Entity CreateCar(ICarMonoEntity carPrefab, CarColorType? colorType, Vector3 position, Quaternion rotation);
        Entity CreateRandomCar(Vector3 position, Quaternion rotation);

        bool TryCreateRandomCarOnPath(Point point, out Entity createdCar);
    }
}