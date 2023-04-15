using Scellecs.Morpeh;
using Sources.App.Data.Cars;
using Sources.App.Data.MonoEntities;
using Sources.App.Data.Points;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Core.Ecs.Factories
{
    public interface ICarsFactory : IService
    {
        Entity CreateCar(CarColorData carColorData, Vector3 position, Quaternion rotation);
        Entity CreateCar(ICarMonoEntity carPrefab, CarColorType? colorType, Vector3 position, Quaternion rotation);
        Entity CreateRandomCar(Vector3 position, Quaternion rotation);

        bool TryCreateRandomCarOnPath(Point point, out Entity createdCar);
    }
}