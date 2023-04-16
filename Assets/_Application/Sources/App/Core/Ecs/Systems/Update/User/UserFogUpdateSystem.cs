using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Common;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.User
{
    public class UserFogUpdateSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly IFog _fog;

        public UserFogUpdateSystem()
        {
            _fog = DiContainer.Resolve<ILevelContext>().Fog;
            
        }

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<UserTag>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            Entity userEntity = _filter.GetSingleton();
            
            _fog.Position = userEntity.GetAspect<PlayerPointAspect>().GetPosition();
        }
    }
}