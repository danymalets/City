using Sources.Game.GameObjects.Cars;
using Sources.Utilities.StateTrees.Base;
using Sources.Utilities.StateTrees.States;

namespace Sources.Game.Characters.StateTree.InCar.DriveToPoint
{
    public class DriveByRoadState : LeafState<Car>
    {
        private readonly CurrentPathData _currentPathData;

        public DriveByRoadState(NodeStateBase parent, CurrentPathData currentPathData) : base(parent)
        {
            _currentPathData = currentPathData;
        }

        public override void OnEnter(Car payload)
        {
            throw new System.NotImplementedException();
        }

        protected override void OnExit()
        {
            throw new System.NotImplementedException();
        }
    }
}