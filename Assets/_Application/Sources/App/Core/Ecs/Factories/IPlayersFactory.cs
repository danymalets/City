using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Data;
using Sources.App.Services.AssetsServices.Common.MonoEntities.Player;
using Sources.App.Services.AssetsServices.Common.PathSystems.Pathes.Pathes;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Core.Ecs.Factories
{
    public interface IPlayersFactory : IService
    {
        PlayerMonoEntity GetRandomPlayerPrefab();
        Entity CreateUserInCar(PlayerMonoEntity playerPrefab, Entity carEntity);
        Entity CreateUser(PlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation);
        Entity CreateNpc(PlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation);
        bool TryCreateRandomNpc(PathPoint point, out Entity createdEntity);
        Entity CreateNpcOnPath(PlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation, PathLine pathLine);
        Entity CreateNpcInCarOnPath(PlayerMonoEntity playerPrefab, Entity carEntity, PathLine pathLine);
        public Entity CreateRandomNpcInCarOnPath(Entity car, PathPoint point);
    }
}