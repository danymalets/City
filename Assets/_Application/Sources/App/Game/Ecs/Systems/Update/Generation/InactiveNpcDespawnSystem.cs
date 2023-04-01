using Scellecs.Morpeh;
using Sources.App.DMorpeh.MorpehUtils.Extensions;
using Sources.App.DMorpeh.MorpehUtils.Systems;
using Sources.App.Game.Ecs.Components.Npc;
using Sources.App.Game.Ecs.Components.Player;
using Sources.App.Game.Ecs.Components.Player.User;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.App.Game.Ecs.Despawners;
using Sources.App.Infrastructure.Services;
using Sources.Utils.Extensions;
using Sources.Utils.Libs;
using UnityEngine;

namespace Sources.App.Game.Ecs.Systems.Update.Generation
{
    public class InactiveNpcDespawnSystem : DUpdateSystem
    {
        private Filter _npcFilter;
        private Filter _userFilter;
        private readonly SimulationSettings _simulationSettings;
        private readonly IPlayersDespawner _playersDespawner;

        public InactiveNpcDespawnSystem()
        {
            _simulationSettings = DiContainer.Resolve<SimulationSettings>();
            _playersDespawner = DiContainer.Resolve<IPlayersDespawner>();
        }

        protected override void OnConstruct()
        {
            _userFilter = _world.Filter<UserTag>();
            _npcFilter = _world.Filter<NpcTag>().Without<AlwaysActive>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            PlayerFollowTransform userTransform = _userFilter.GetSingleton().Get<PlayerFollowTransform>();

            foreach (Entity npcEntity in _npcFilter)
            {
                Vector3 npcPosition = npcEntity.Get<PlayerFollowTransform>().Position;

                Vector2 directionToEntity = (Quaternion.Inverse(userTransform.Rotation) *
                                             (npcPosition - userTransform.Position)).GetXZ();

                if (npcEntity.Has<PlayerInCar>())
                {
                    Vector2 maxSize = new(_simulationSettings.CarMaxActiveRadius, _simulationSettings.CarMaxActiveRadius);

                    if (directionToEntity.y < 0)
                    {
                        maxSize.y = _simulationSettings.BackCarMaxActiveRadius;
                    }
                    
                    maxSize.x += 0.01f;
                    maxSize.y += 0.01f;
                    
                    if (!DMath.InEllipse(directionToEntity, maxSize))
                    {
                        _playersDespawner.DespawnNpc(npcEntity);
                    }
                }
                else
                {
                    Vector2 maxSize = new(_simulationSettings.NpcMaxActiveRadius, _simulationSettings.NpcMaxActiveRadius);

                    if (directionToEntity.y < 0)
                    {
                        maxSize.y = _simulationSettings.BackNpcMaxActiveRadius;
                    }
                    
                    if (!DMath.InEllipse(directionToEntity, maxSize))
                    {
                        _playersDespawner.DespawnNpc(npcEntity);
                    }
                }
            }
        }
    }
}