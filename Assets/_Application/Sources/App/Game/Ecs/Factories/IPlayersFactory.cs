using Scellecs.Morpeh;
using Sources.Monos.MonoEntities;
using Sources.Monos.RoadSystem.Pathes;
using Sources.Monos.RoadSystem.Pathes.Points;
using Sources.Services.Di;
using UnityEngine;

namespace Sources.App.Game.Ecs.Factories
{
    public interface IPlayersFactory : IService
    {
        PlayerMonoEntity GetRandomPlayerPrefab();
        Entity CreateUserInCar(PlayerMonoEntity playerPrefab, Entity carEntity);
        Entity CreateUser(PlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation);
        Entity CreateNpc(PlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation);
        bool TryCreateRandomNpc(Point point, out Entity createdEntity);
        Entity CreateNpcOnPath(PlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation, PathLine pathLine);
        Entity CreateNpcInCarOnPath(PlayerMonoEntity playerPrefab, Entity carEntity, PathLine pathLine);
        public Entity CreateRandomNpcInCarOnPath(Entity car, Point point);
    }
}