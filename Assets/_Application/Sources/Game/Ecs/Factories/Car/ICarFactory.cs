using Scellecs.Morpeh;
using Sources.Game.Ecs.MonoEntities;
using Sources.Infrastructure.Services;
using UnityEngine;

namespace Sources.Game.Ecs.Factories
{
    public interface ICarFactory : IService
    {
        Entity CreateCar(CarMonoEntity carPrefab, Vector3 position, Quaternion rotation);
    }
}