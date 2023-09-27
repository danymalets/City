using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.SimulationCamera;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Services.AssetsServices.IdleCarSpawns.Common;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

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
            _filter = _world.Filter<SimulationCameraTag>().Build();
        }

        protected override void OnUpdate(float deltaTime)
        {
            Entity userEntity = _filter.GetSingleton();
            
            Vector2 position = userEntity.Get<SimulationCameraPosition>().Position;
            
            _fog.Position = new Vector3(position.x, 0, position.y);
        }
    }
}