using Scellecs.Morpeh;
using Sources.App.Data.Cars;
using Sources.App.Data.Points;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Core.Ecs.Factories
{
    public interface ICarsFactory : IService
    {
        bool TryCreateRandomCarOnPath(Point point, bool isIdle, out Entity createdCar);
        bool TryCreateCar(CarType carType, CarColorType? carColor, Vector3 position, 
            Quaternion rotation, bool isIdle, out Entity createdCar);
    }
}