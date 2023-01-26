using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Player.User;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.Views.CarEngine;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;
using Sources.Utilities;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Generation
{
    public class InactiveCarsDespawnSystem : DUpdateSystem
    {
        private readonly float _sqrMaxRadius;
        private Filter _npcFilter;
        private Filter _userFilter;

        public InactiveCarsDespawnSystem()
        {
            SimulationBalance simulationBalance = DiContainer.Resolve<Balance>().SimulationBalance;

            _sqrMaxRadius = DMath.Sqr(simulationBalance.MaxActiveRadius);
        }

        protected override void OnInitFilters()
        {
            _userFilter = _world.Filter<UserTag>();
            _npcFilter = _world.Filter<NpcTag, PlayerInCar>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            Vector3 userPosition = _userFilter.GetSingleton().Get<UserFollowTransform>().Position;

            foreach (Entity npcEntity in _npcFilter)
            {
                Entity carEntity = npcEntity.Get<PlayerInCar>().Car;
                Vector3 carPosition = carEntity.GetMono<ICarWheels>().RootPosition;

                if (DMath.Greater(DVector3.SqrDistance(carPosition, userPosition), _sqrMaxRadius))
                {
                    _despawner.DespawnNpc(npcEntity);
                    _despawner.DespawnCar(carEntity);
                }
            }
        }
    }
}