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
using UnityEngine.UIElements;
using ITransform = Sources.Game.Ecs.Components.Views.Transform.ITransform;

namespace Sources.Game.Ecs.Systems.Update.Generation
{
    public class InactiveNpcDespawnSystem : DUpdateSystem
    {
        private readonly float _sqrMaxRadius;
        private Filter _npcFilter;
        private Filter _userFilter;

        public InactiveNpcDespawnSystem()
        {
            SimulationBalance simulationBalance = DiContainer.Resolve<Balance>().SimulationBalance;

            _sqrMaxRadius = DMath.Sqr(simulationBalance.MaxActiveRadius);
        }

        protected override void OnInitFilters()
        {
            _userFilter = _world.Filter<UserTag>();
            _npcFilter = _world.Filter<NpcTag>().Without<PlayerInCar>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            Vector3 userPosition = _userFilter.GetSingleton().Get<UserFollowTransform>().Position;

            foreach (Entity npcEntity in _npcFilter)
            {
                Vector3 npcPosition = npcEntity.GetMono<ITransform>().Position;

                if (DMath.Greater(DVector3.SqrDistance(npcPosition, userPosition), _sqrMaxRadius))
                {
                    _despawner.DespawnNpc(npcEntity);
                }
            }
        }
    }
}