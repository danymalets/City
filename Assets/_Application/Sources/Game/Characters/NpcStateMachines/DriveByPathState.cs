using Sources.Game.GameObjects.Cars;
using Sources.Game.GameObjects.RoadSystem.Pathes;
using Sources.Infrastructure.Services.CoroutineRunner;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Characters.NpcStateMachines
{
    public class DriveByPathState : CustomNpcState
    {
        private readonly Car _car;
        private readonly CoroutineContext _coroutineContext;
        private Path _currentPath;
        private Path _nextPath;
        private float _distanceProgress;

        public DriveByPathState(NpcStateMachine stateMachine, Car car) : base(stateMachine)
        {
            _car = car;

            _coroutineContext = new CoroutineContext();
        }

        protected override void OnEnter()
        {
            Debug.Log("enter");

            _currentPath = _car.CarData.CurrentPath;
            _nextPath = _currentPath.Target.Targets.GetRandom();
            _distanceProgress = _car.CarData.DistanceProgress;
            
            _car.SetMotorCoefficient(0.2f);
            
            _coroutineContext.RunEachFixedUpdate(FixedUpdate);
        }

        private void FixedUpdate()
        {
            // if (Vector3Utility.SqrDistance(_car.RootPosition, _nextPath.GetPointNearSource()) <
            //     Vector3Utility.SqrDistance(_car.RootPosition, _currentPath.Target.Position))
            // {
            //     _currentPath = _nextPath;
            //     _nextPath = _currentPath.Target.Targets.GetRandom();
            //     _distanceProgress = 0;
            // }

            //Vector3 point = _currentPath.GetNearestPoint(_car.RootPosition, ref _distanceProgress);

            //float distanceToNearest = Vector3Utility.SqrDistance(point, _car.RootPosition);
            //Debug.Log($"d to n {distanceToNearest} progr {_distanceProgress}");

            float signedAngle = Vector3.SignedAngle(
                _car.transform.forward.WithY(0),
                _currentPath.Target.Position - _car.RootPosition,
                Vector3.up);
            
            _car.TrySetAngle(signedAngle);

            _car.SetBreak(_car.HasCarInFront());
        }

        protected override void OnQuit()
        {
            _coroutineContext.StopAllCoroutines();
            Debug.Log("quit");
        }
    }
}