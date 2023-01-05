using Sources.Game.Ecs.Components.Views;
using Sources.Game.GameObjects.RoadSystem.Pathes;
using Sources.Infrastructure.Services.Pool;
using UnityEngine;
using UnityEngine.AI;

namespace Sources.Game.GameObjects.Cars
{
    [RequireComponent(typeof(CarEngine))]
    [RequireComponent(typeof(CarData))]
    public class Car : RespawnableBehaviour
    {
        public CarData CarData { get; private set; }
        private CarEngine _carEngine;

        [SerializeField]
        private CarTrigger _frontCarTrigger;
        
        [SerializeField]
        private CarTrigger _backCarTrigger;

        [SerializeField]
        private NavMeshAgent _navMeshAgent;

        public NavMeshAgent NavMeshAgent => _navMeshAgent;

        private void Awake()
        {
            CarData = GetComponent<CarData>();
            _carEngine = GetComponent<CarEngine>();
        }

        public void Setup(Path path, float distanceProgress)
        {
            CarData.Setup(path, distanceProgress);
        }

        public void SetMotorCoefficient(float vertical) =>
            _carEngine.SetMotorCoefficient(vertical);
        
        public void SetAngleCoefficient(float horizontal) =>
            _carEngine.SetAngleCoefficient(horizontal);
        
        public void TrySetAngle(float angle) =>
            _carEngine.TrySetAngle(angle);

        public bool HasCarInFront() =>
            _frontCarTrigger.HasCarInTrigger;

        public Vector3 RootPosition => _carEngine.RootPosition;

        public bool HasCarInBack() =>
            _backCarTrigger.HasCarInTrigger;
    }
}