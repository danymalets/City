using Leopotam.Ecs;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Tags;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Times;
using Sources.Utilities;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Camera
{
    public class CameraRotationSystem : IEcsRunSystem
    {
        private EcsFilter<CameraTag, Rotation> _cameraFilter;
        private EcsFilter<UserTag, PlayerInCar> _userFilter;
        private readonly ITimeService _time;

        public CameraRotationSystem()
        {
            _time = DiContainer.Resolve<ITimeService>();
        }

        public void Run()
        {
            foreach (int i in _cameraFilter)
            {
                ref Rotation cameraRotation = ref _cameraFilter.Get2(i);
                
                foreach (int j in _userFilter)
                {
                    Quaternion userCarRotation = _userFilter.Get2(j).Car.Get<Rotation>().Value;

                    cameraRotation.Value = cameraRotation.Value.WithEulerY(userCarRotation.eulerAngles.y);
                }
            }
        }
    }
}