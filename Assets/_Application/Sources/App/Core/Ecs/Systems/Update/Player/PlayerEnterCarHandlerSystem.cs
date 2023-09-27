using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects;
using Sources.App.Core.Ecs.Aspects.Player;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Player.InCar;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Cars;
using Sources.App.Data.Constants;
using Sources.App.Data.Players;
using Sources.App.Services.BalanceServices;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.DefaultComponents.Monos;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.Player
{
    public class PlayerEnterCarHandlerSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<UserTag, PlayerEnterCarEvent>().Without<PlayerInCar>().Build();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                ref CarPlaceData carPlaceData = ref playerEntity.Get<PlayerEnterCarEvent>().CarPlaceData;
                
                playerEntity.GetAspect<PlayerEnterCarAspect>().StartEnterCarWithAnimation(carPlaceData);
            }
        }
    }
}