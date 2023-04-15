using _Application.Sources.App.Core.Ecs.Components.Camera;
using _Application.Sources.App.Core.Ecs.Components.Tags;
using _Application.Sources.App.Data.MonoEntities;
using _Application.Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Scellecs.Morpeh;

namespace _Application.Sources.App.Core.Ecs.Factories
{
    public class CamerasFactory : Factory, ICamerasFactory
    {
        public Entity CreateCamera()
        {
            ICameraMonoEntity cameraMonoEntity = _levelContext.CameraMonoEntity;
            return _world.CreateFromMono(cameraMonoEntity)
                .SetAccess<ITransform>(cameraMonoEntity.Transform)
                .SetAccess<ICamera>(cameraMonoEntity.Camera)
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
    }
}