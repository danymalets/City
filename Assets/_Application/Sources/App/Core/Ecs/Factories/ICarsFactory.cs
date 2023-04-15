using _Application.Sources.App.Data.Cars;
using _Application.Sources.App.Data.MonoEntities;
using _Application.Sources.App.Data.Points;
using _Application.Sources.Utils.Di;
using Scellecs.Morpeh;
using UnityEngine;

namespace _Application.Sources.App.Core.Ecs.Factories
{
    public interface ICarsFactory : IService
    {
        Entity CreateCar(CarColorData carColorData, Vector3 position, Quaternion rotation);
        Entity CreateCar(ICarMonoEntity carPrefab, CarColorType? colorType, Vector3 position, Quaternion rotation);
        Entity CreateRandomCar(Vector3 position, Quaternion rotation);

        bool TryCreateRandomCarOnPath(Point point, out Entity createdCar);
    }
}