using Scellecs.Morpeh;
using Sources.App.Game.Ecs.Components.Camera;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.Data.MonoEntities;
using Sources.Utils.DMorpeh.DefaultComponents.Views;
using Sources.Utils.DMorpeh.MorpehUtils.Extensions;

namespace Sources.App.Game.Ecs.Factories
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