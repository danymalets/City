using Sources.Game.GameObjects.Cars;
using Sources.Utilities.StateTrees.Base;
using Sources.Utilities.StateTrees.States;
using UnityEngine.AI;

namespace Sources.Game.Characters.StateTree.InCar.DriveToPoint
{
    public class DriveByNavMeshState : LeafState<Car>
    {
        private readonly CurrentPathData _currentPathData;
        private NavMeshPath _navMeshPath;

        public DriveByNavMeshState(NodeStateBase parent, CurrentPathData currentPathData) : base(parent)
        {
            _currentPathData = currentPathData;
        }

        public override void OnEnter(Car car)
        {
            RegeneratePath(car);
            _coroutineContext.RunEachSeconds(1f, () => RegeneratePath(car));
        }

        private void RegeneratePath(Car car)
        {
            //car.
        }

        // private bool TryGetPath(Car car, Vector3 position, out Path path)
        // {
        //     _navMeshPath = new NavMeshPath();
        //     if (!car.NavMeshAgent.CalculatePath(position, _navMeshPath))
        //     {
        //         path = default;
        //         return false;
        //     }
        // }

        protected override void OnExit()
        {
        }
    }
}