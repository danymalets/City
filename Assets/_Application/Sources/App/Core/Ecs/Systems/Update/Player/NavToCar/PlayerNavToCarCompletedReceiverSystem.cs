using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.NavPathes;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.Player
{
    public class PlayerNavToCarCompletedReceiverSystem : DUpdateSystem
    {
        private Filter _playerFilter;
        
        protected override void OnInitFilters()
        {
            _playerFilter = _world.Filter<PlayerTag, OnNavToCar, NavPathCompletedEvent>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _playerFilter)
            {
                playerEntity.Set(new NavToCarCompletedEvent
                {
                    PlaceData = playerEntity.Get<OnNavToCar>().PlaceData
                });
            }
        }
    }
}