using Leopotam.Ecs;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Tags;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;
using Sources.Infrastructure.Services.Times;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Camera
{
    public class CameraPositionSystem : IEcsRunSystem
    {
        private EcsFilter<CameraTag, Rotation, Position> _cameraFilter;
        private EcsFilter<UserTag, PlayerInCar> _userFilter;
        private readonly TimeService _time;
        private readonly CameraBalance _cameraBalance;

        public CameraPositionSystem()
        {
            _cameraBalance = DiContainer.Resolve<IBalanceService>()
                .CameraBalance;
        }

        public void Run()
        {
            if (_cameraFilter.GetEntitiesCount() < 1)
                return;
            
            if (_userFilter.GetEntitiesCount() < 1)
                return;

            Rotation cameraRotation = _cameraFilter.Get2(0);
            ref Position cameraPosition = ref _cameraFilter.Get3(0);

            Vector3 userCarPosition = _userFilter.Get2(0).Car.Get<Position>().Value;

            cameraPosition.Value = (userCarPosition - cameraRotation.Value * Vector3.forward *
                _cameraBalance.CameraBackDistance).WithY(_cameraBalance.CameraHeight);
        }
    }
}