using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.Views;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Player
{
    public class SmoothAngleApplySystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<PlayerTag>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                ITransform transform = playerEntity.GetMono<ITransform>();
                SmoothAngle smoothAngle = playerEntity.Get<SmoothAngle>();
                
                transform.Rotation = Quaternion.Euler(0, smoothAngle.Value, 0);
            }
        }
    }
}