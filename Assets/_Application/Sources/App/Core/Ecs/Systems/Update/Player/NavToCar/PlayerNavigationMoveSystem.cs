using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects;
using Sources.App.Core.Ecs.Aspects.Player;
using Sources.App.Core.Ecs.Components.NavPathes;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Player.Npc;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.Player.NavToCar
{
    public class PlayerNavigationMoveSystem : DUpdateSystem
    {
        private Filter _playerFilter;
        
        protected override void OnInitFilters()
        {
            _playerFilter = _world.Filter<PlayerTag, PLayerOnNavPath>().Build();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _playerFilter)
            {
                Vector3 position = playerEntity.GetAspect<PlayerPointAspect>()
                    .GetPosition();
                ref PLayerOnNavPath pLayerOnNavPath = ref playerEntity.Get<PLayerOnNavPath>();
                ref PlayerTargetAngle playerTargetAngle = ref playerEntity.Get<PlayerTargetAngle>();

                Vector3[] path = pLayerOnNavPath.Path;

                if (pLayerOnNavPath.LastCompetedPoint == path.Length - 1)
                {
                    playerEntity.Add<NavPathCompletedEvent>();
                    continue;
                }

                if (IsEnded(path[pLayerOnNavPath.LastCompetedPoint],
                        path[pLayerOnNavPath.LastCompetedPoint + 1], 
                        position))
                {
                    pLayerOnNavPath.LastCompetedPoint++;
                    
                    if (pLayerOnNavPath.LastCompetedPoint == path.Length - 1)
                    {
                        playerEntity.Add<NavPathCompletedEvent>();
                        continue;
                    }
                }

                playerTargetAngle.Value = GetAngle(path[pLayerOnNavPath.LastCompetedPoint],
                    path[pLayerOnNavPath.LastCompetedPoint + 1]);
                
                ref PlayerTargetSpeed playerTargetSpeed = ref playerEntity.Get<PlayerTargetSpeed>();
                playerTargetSpeed.Value = 3.5f;
            }
        }

        private bool IsEnded(Vector3 source, Vector3 target, Vector3 obj) =>
            obj == target || Vector3.Dot(source - target, obj - target) < 0;

        private float GetAngle(Vector3 source, Vector3 target) =>
            Quaternion.LookRotation((target - source).GetX0Z(),
                Vector3.up).eulerAngles.y;
    }
}