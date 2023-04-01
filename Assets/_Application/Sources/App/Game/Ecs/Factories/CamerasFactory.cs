using Scellecs.Morpeh;
using Sources.App.DMorpeh.MorpehUtils.Extensions;
using Sources.App.Game.Ecs.Components.Camera;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.App.Game.Ecs.DefaultComponents.Views;
using Sources.App.Game.Ecs.MonoEntities;

namespace Sources.App.Game.Ecs.Factories
{
    public class CamerasFactory : Factory, ICamerasFactory
    {

        public Entity CreateCamera()
        {
            CameraMonoEntity cameraMonoEntity = _levelContext.CameraMonoEntity;
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