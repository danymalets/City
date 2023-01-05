using Leopotam.Ecs;
using Sources.Infrastructure.Services;
using UnityEngine;

namespace Sources.Game.Ecs.Factories
{
    public interface ICarFactory : IService
    {
        EcsEntity CreateCar(Vector3 position, Quaternion rotation);
    }
}