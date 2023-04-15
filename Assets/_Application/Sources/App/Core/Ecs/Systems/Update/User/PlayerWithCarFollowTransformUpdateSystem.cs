using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Cars;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.User
{
    public class PlayerWithCarFollowTransformUpdateSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnConstruct()
        {
            _filter = _world.Filter<PlayerTag, PlayerInCar>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                Entity carEntity = playerEntity.Get<PlayerInCar>().Car;
                
                IWheelsSystem wheels = carEntity.GetAccess<IWheelsSystem>();
                ITransform transform = carEntity.GetAccess<ITransform>();
                ref PlayerFollowTransform playerFollowTransform = ref playerEntity.Get<PlayerFollowTransform>();

                playerFollowTransform.Position = wheels.RootPosition;
                playerFollowTransform.Rotation = transform.Rotation;
            }
        }
    }
}