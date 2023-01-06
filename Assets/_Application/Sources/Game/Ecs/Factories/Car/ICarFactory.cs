using Scellecs.Morpeh;
using Sources.Infrastructure.Services;
using UnityEngine;

namespace Sources.Game.Ecs.Factories
{
    public interface ICarFactory : IService
    {
        Entity CreateCar(Vector3 position, Quaternion rotation);
    }
}