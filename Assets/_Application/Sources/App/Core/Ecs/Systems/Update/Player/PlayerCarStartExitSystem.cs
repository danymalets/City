using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects;
using Sources.App.Core.Ecs.Aspects.Player;
using Sources.App.Core.Ecs.Components.Car;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Player.InCar;
using Sources.App.Core.Ecs.Components.Player.User;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Cars;
using Sources.App.Data.Constants;
using Sources.App.Data.Players;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.Player
{
    public class PlayerCarStartExitSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<PlayerTag, PlayerInCar, PlayerStartExitCarRequest>().Build();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                playerEntity.GetAspect<PlayerExitCarAspect>().StartExitCar();
            }
        }
    }
}