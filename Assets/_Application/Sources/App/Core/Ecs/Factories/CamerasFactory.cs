using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Camera;
using Sources.App.Core.Ecs.Components.SimulationCamera;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Services.AssetsServices.Monos.MonoEntities;
using Sources.App.Services.AssetsServices.Monos.MonoEntities.Camera;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;

namespace Sources.App.Core.Ecs.Factories
{
    public class CamerasFactory : Factory, ICamerasFactory
    {
        public Entity CreateCamera()
        {
            CameraMonoEntity cameraMonoEntity = _levelContext.CameraMonoEntity;
            return _world.CreateFromMono(cameraMonoEntity)
                .SetRef<ITransform>(cameraMonoEntity.Transform)
                .SetRef<ICamera>(cameraMonoEntity.Camera)
                .Add<CameraTag>()
                .Add<CameraYAngle>()
                .Add<CameraTargetBackDistance>()
                .Add<CameraTargetHeight>()
                .Add<CameraSmoothBackDistance>()
                .Add<CameraSmoothHeight>()
                .Add<CameraXTargetAngle>()
                .Add<CameraXSmoothAngle>()
                .Add<CameraSmoothFollowY>();
        }
        
        public Entity CreateSimulationCamera()
        {
            return _world.CreateEntity()
                .Add<SimulationCameraTag>()
                .Add<SimulationCameraPosition>()
                .Add<SimulationCameraDirection>();
        }
    }
}