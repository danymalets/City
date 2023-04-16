using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects;
using Sources.App.Core.Ecs.Components.Npc;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Core.Ecs.Despawners;
using Sources.App.Core.Services;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.Generation
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
            PlayerPointAspect playerPointAspect = _userFilter.GetSingleton().GetAspect<PlayerPointAspect>();

            foreach (Entity npcEntity in _npcFilter)
            {
                Vector3 npcPosition = npcEntity.GetAspect<PlayerPointAspect>().GetPosition();

                Vector2 directionToEntity = (Quaternion.Inverse(playerPointAspect.GetRotation()) *
                                             (npcPosition - playerPointAspect.GetPosition())).GetXZ();

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