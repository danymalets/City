using Scellecs.Morpeh;
using Sources.Game.Ecs.MonoEntities;
using Sources.Game.GameObjects.RoadSystem;
using Sources.Game.GameObjects.RoadSystem.Pathes;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;
using UnityEngine;

namespace Sources.Game.Ecs.Factories
{
    public interface IFactory : IService
    {
        Entity CreateNpcInCar(PlayerMonoEntity playerPrefab, Entity carEntity, PathLine pathLine);
        Entity CreateUserInCar(PlayerMonoEntity playerPrefab, Entity carEntity);
        Entity CreateUser(PlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation);
        Entity CreateCamera();
        Entity CreateNpcOnPath(PlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation, PathLine pathLine);
        Entity CreatePathes<TTag>(IPathSystem pathSystem) where TTag : struct, IComponent;
        Entity CreateCar(CarType carType, CarColorType carColor, Vector3 position, Quaternion rotation);
        Entity CreateRandomCar(Vector3 position, Quaternion rotation);
        Entity CreateCar(CarMonoEntity carPrefab, CarColorType colorType, Vector3 position, Quaternion rotation);
        PlayerMonoEntity GetRandomPlayerPrefab();
        Entity CreateNpc(PlayerMonoEntity playerPrefab, Vector3 vector3, Quaternion identity);
    }
}