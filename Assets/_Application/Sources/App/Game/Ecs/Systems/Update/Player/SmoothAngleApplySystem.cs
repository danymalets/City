using Scellecs.Morpeh;
using Sources.App.DMorpeh.MorpehUtils.Extensions;
using Sources.App.DMorpeh.MorpehUtils.Systems;
using Sources.App.Game.Ecs.Components.Player;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.App.Game.Ecs.DefaultComponents.Views;
using UnityEngine;

namespace Sources.App.Game.Ecs.Systems.Update.Player
{
    public class SmoothAngleApplySystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnConstruct()
        {
            _filter = _world.Filter<PlayerTag>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                IRigidbody physicBody = playerEntity.GetAccess<IRigidbody>();
                PlayerSmoothAngle playerSmoothAngle = playerEntity.Get<PlayerSmoothAngle>();
                
                physicBody.MoveRotation(Quaternion.Euler(0, playerSmoothAngle.Value, 0));
            }
        }
    }
}