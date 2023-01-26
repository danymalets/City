using Scellecs.Morpeh;
using Sources.Game.Ecs.MonoEntities;
using Sources.Game.GameObjects.RoadSystem;
using Sources.Game.GameObjects.RoadSystem.Pathes;
using Sources.Infrastructure.Services;
using UnityEngine;

namespace Sources.Game.Ecs.Factories
{
    public interface IFactory : IService
    {
        Entity CreateCar(CarMonoEntity carPrefab, Vector3 position, Quaternion rotation);
        Entity CreateNpcInCar(PlayerMonoEntity playerPrefab, Entity carEntity, PathLine pathLine);
        Entity CreateUserInCar(PlayerMonoEntity playerPrefab, Entity carEntity);
        Entity CreateUser(PlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation);
        Entity CreateCamera();
        Entity CreateNpcOnPath(PlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation, PathLine pathLine);
        Entity CreatePathes<TTag>(IPathSystem pathSystem) where TTag : struct, IComponent;
    }
}