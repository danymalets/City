using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Npc;
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
        private Filter _npcFilter;
        private Filter _userFilter;
        private readonly SimulationBalance _simulationBalance;

        public InactiveNpcDespawnSystem()
        {
            _simulationBalance = DiContainer.Resolve<Balance>().SimulationBalance;
        }

        protected override void OnConstruct()
        {
            _userFilter = _world.Filter<UserTag>();
            _npcFilter = _world.Filter<NpcTag>().Without<AlwaysActive>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            Vector3 userPosition = _userFilter.GetSingleton().Get<PlayerFollowTransform>().Position;

            float npcSqrMaxRadius = DMath.Sqr(_simulationBalance.MaxNpcActiveRadius);
            float carSqrMaxRadius = DMath.Sqr(_simulationBalance.MaxCarActiveRadius + 0.1f);
            
            foreach (Entity npcEntity in _npcFilter)
            {
                Vector3 npcPosition = npcEntity.Get<PlayerFollowTransform>().Position;

                if (npcEntity.Has<PlayerInCar>())
                {
                    if (DMath.Greater(DVector3.SqrDistance(npcPosition, userPosition), carSqrMaxRadius))
                    {
                        _despawner.DespawnNpc(npcEntity);
                    }
                }
                else
                {
                    if (DMath.Greater(DVector3.SqrDistance(npcPosition, userPosition), npcSqrMaxRadius))
                    {
                        _despawner.DespawnNpc(npcEntity);
                    }
                }
            }
        }
    }
}