using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects;
using Sources.App.Core.Ecs.Components.NavPathes;
using Sources.App.Core.Ecs.Components.Npc;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.Player
{
    public class PlayerNavigationMoveSystem : DUpdateSystem
    {
        private Filter _playerFilter;
        
        protected override void OnInitFilters()
        {
            _playerFilter = _world.Filter<PlayerTag, OnNavPath>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _playerFilter)
            {
                Vector3 position = playerEntity.GetAspect<PlayerPointAspect>()
                    .GetPosition();
                ref OnNavPath onNavPath = ref playerEntity.Get<OnNavPath>();
                ref PlayerTargetAngle playerTargetAngle = ref playerEntity.Get<PlayerTargetAngle>();

                Vector3[] path = onNavPath.Path;

                if (onNavPath.LastCompetedPoint == path.Length - 1)
                {
                    playerEntity.Add<NavPathCompletedEvent>();
                    continue;
                }

                if (IsEnded(path[onNavPath.LastCompetedPoint],
                        path[onNavPath.LastCompetedPoint + 1], 
                        position))
                {
                    onNavPath.LastCompetedPoint++;
                    
                    if (onNavPath.LastCompetedPoint == path.Length - 1)
                    {
                        playerEntity.Add<NavPathCompletedEvent>();
                        continue;
                    }
                }

                playerTargetAngle.Value = GetAngle(path[onNavPath.LastCompetedPoint],
                    path[onNavPath.LastCompetedPoint + 1]);
                
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