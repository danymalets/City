using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Camera;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.MonoEntities;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;

namespace Sources.App.Core.Ecs.Factories
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