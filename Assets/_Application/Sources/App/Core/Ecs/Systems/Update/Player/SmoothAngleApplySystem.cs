using _Application.Sources.App.Core.Ecs.Components.Player;
using _Application.Sources.App.Core.Ecs.Components.Tags;
using _Application.Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using Scellecs.Morpeh;
using UnityEngine;

namespace _Application.Sources.App.Core.Ecs.Systems.Update.Player
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