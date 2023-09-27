using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects;
using Sources.App.Core.Ecs.Aspects.Player;
using Sources.App.Core.Ecs.Components.Camera;
using Sources.App.Core.Ecs.Components.SimulationAreas;
using Sources.App.Core.Ecs.Components.SimulationCamera;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.Generation
{
    public class SimulationCameraUpdateSystem : DUpdateSystem
    {
        private Filter _simulationAreaFilter;
        private Filter _simulationCameraFilter;
        private Filter _userFilter;
        private Filter _cameraFilter;

        protected override void OnInitFilters()
        {
            _simulationCameraFilter = _world.Filter<SimulationCameraTag>().Build();
            _cameraFilter = _world.Filter<CameraTag>().Build();
            _userFilter = _world.Filter<UserTag>().Build();
        }

        protected override void OnUpdate(float deltaTime)
        {
            Entity simulationCamera = _simulationCameraFilter.GetSingleton();

            PlayerPointAspect playerPointAspect = _userFilter.GetSingleton()
                .GetAspect<PlayerPointAspect>();

            // todo: backDistance change smooth
            
            float backDistance = _cameraFilter.GetSingleton()
                .Get<CameraTargetBackDistance>().Value;
            
            ref SimulationCameraPosition simulationCameraPosition = 
                ref simulationCamera.Get<SimulationCameraPosition>();
            
            ref SimulationCameraDirection simulationCameraDirection = 
                ref simulationCamera.Get<SimulationCameraDirection>();
            
            Vector2 userPosition = playerPointAspect.GetPosition().GetXZ();
            Vector2 normalDirection = (playerPointAspect.GetRotation() * Vector3.forward).GetXZ().normalized;

            Vector2 simulationCameraPositionValue = userPosition - normalDirection * backDistance;
            
            simulationCameraPosition.Position = simulationCameraPositionValue;
            simulationCameraDirection.NormalDirection = normalDirection;
        }
    }
}