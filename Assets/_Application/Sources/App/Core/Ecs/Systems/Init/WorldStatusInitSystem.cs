using Sources.App.Core.Ecs.Components.Tags;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Init
{
    public class WorldStatusInitSystem : DInitializer
    {
        public WorldStatusInitSystem()
        {
        }

        protected override void OnInitialize()
        {
            _world.CreateEntity()
                .AllowFixedAwaiters()
                .Add<WorldStatusTag>();
        }
    }
}