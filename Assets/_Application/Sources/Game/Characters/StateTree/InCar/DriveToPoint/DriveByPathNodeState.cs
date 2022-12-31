using Sources.Game.GameObjects.Cars;
using Sources.Utilities.StateTrees.Base;
using Sources.Utilities.StateTrees.States;

namespace Sources.Game.Characters.StateTree.InCar.DriveToPoint
{
    public class DriveByPathNodeState : NodeState<Car>
    {
        private readonly CurrentPathData _currentPathData;

        public DriveByPathNodeState(NodeStateBase parent) : base(parent)
        {
            _currentPathData = new CurrentPathData();
            
            _children = new StateBase[]
            {
                new DriveByRoadState(this, _currentPathData),
                new DriveByNavMeshState(this, _currentPathData),
            };
        }

        public override void OnEnter(Car payload)
        {
        }

        protected override void OnExit()
        {
        }
    }
}