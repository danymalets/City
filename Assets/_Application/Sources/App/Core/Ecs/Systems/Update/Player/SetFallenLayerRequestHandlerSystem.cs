using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Common;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Constants;
using Sources.Utils.MorpehWrapper.DefaultComponents.Monos;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using ICollider = Sources.Utils.MorpehWrapper.DefaultComponents.Monos.ICollider;

namespace Sources.App.Core.Ecs.Systems.Update.Player
{
    public class SetFallenLayerRequestHandlerSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<SetLayerRequest>().Build();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                int layer = entity.Get<SetLayerRequest>().Layer;
                ICollider[] colliders = entity.GetRef<ICollider[]>();

                foreach (ICollider collider in colliders)
                {
                    collider.Layer = layer;
                }
            }
        }
    }
}