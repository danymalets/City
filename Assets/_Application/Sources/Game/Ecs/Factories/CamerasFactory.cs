using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Camera;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.DefaultComponents;
using Sources.Game.Ecs.DefaultComponents.Monos;
using Sources.Game.Ecs.DefaultComponents.Views;
using Sources.Game.Ecs.MonoEntities;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using UnityEngine;

namespace Sources.Game.Ecs.Factories
{
    public class CamerasFactory : Factory, ICamerasFactory
    {
        public CamerasFactory(World world) : base(world)
        {
        }

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