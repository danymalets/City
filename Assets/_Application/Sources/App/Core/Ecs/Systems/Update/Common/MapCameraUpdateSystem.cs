using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects;
using Sources.App.Core.Ecs.Aspects.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Services.AssetsServices.IdleCarSpawns.Common;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.Common
{
    public class MapCameraUpdateSystem : DUpdateSystem
    {
        private Filter _userFiler;
        private readonly IMapCamera _mapCamera;

        public MapCameraUpdateSystem()
        {
            _mapCamera = DiContainer.Resolve<ILevelContext>().MapCamera;
        }

        protected override void OnInitFilters()
        {
            _userFiler = _world.Filter<UserTag>().Build();
        }

        protected override void OnUpdate(float deltaTime)
        {
            PlayerPointAspect playerPointAspect = _userFiler.GetSingleton()
                .GetAspect<PlayerPointAspect>();
            
            _mapCamera.Position = playerPointAspect.GetPosition().GetXZ();

            _mapCamera.EulerAngleY = playerPointAspect.GetRotation().eulerAngles.y;
        }
    }
}