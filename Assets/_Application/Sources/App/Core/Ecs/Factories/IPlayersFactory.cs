using Scellecs.Morpeh;
using Sources.App.Data.Pathes;
using Sources.App.Data.Points;
using Sources.App.Services.AssetsServices.Monos.MonoEntities;
using Sources.App.Services.AssetsServices.Monos.MonoEntities.Player;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Core.Ecs.Factories
{
    public interface IPlayersFactory : IService
    {
        IPlayerMonoEntity GetRandomPlayerPrefab();
        Entity CreateUserInCar(IPlayerMonoEntity playerPrefab, Entity carEntity);
        Entity CreateUser(IPlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation);
        Entity CreateNpc(IPlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation);
        bool TryCreateRandomNpc(Point point, out Entity createdEntity);
        Entity CreateNpcOnPath(IPlayerMonoEntity playerPrefab, Vector3 position, Quaternion rotation, PathLine pathLine);
        Entity CreateNpcInCarOnPath(IPlayerMonoEntity playerPrefab, Entity carEntity, PathLine pathLine);
        public Entity CreateRandomNpcInCarOnPath(Entity car, Point point);
    }
}