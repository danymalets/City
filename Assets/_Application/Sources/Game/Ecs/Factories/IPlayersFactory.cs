using Scellecs.Morpeh;
using Sources.Game.Ecs.MonoEntities;
using Sources.Game.GameObjects.RoadSystem.Pathes;
using Sources.Infrastructure.Services;
using UnityEngine;

namespace Sources.Game.Ecs.Factories
{
    public interface IPlayersFactory : IService
    {
        PlayerMonoEntity GetRandomPlayerPrefab();
        Entity CreateUserInCar(PlayerMonoEntity playerPrefab, Entity carEntity);
        Entity CreateUser(PlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation);
        Entity CreateNpc(PlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation);
        Entity CreateNpcOnPath(PlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation, PathLine pathLine);
        Entity CreateNpcInCar(PlayerMonoEntity playerPrefab, Entity carEntity, PathLine pathLine);
    }
}