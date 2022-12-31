using Sources.Game.Characters.StateTree.InCar.DriveToPoint;
using Sources.Game.GameObjects.Cars;
using Sources.Utilities.StateTrees.Base;
using Sources.Utilities.StateTrees.States;

namespace Sources.Game.Characters.StateTree.InCar
{
    public class InCarNodeState : NodeState<Car>
    {
        public InCarNodeState(NodeStateBase parent) : base(parent)
        {
            _children = new StateBase[]
            {
                new DriveByPathNodeState(this),
                new WaitForFrontTrigger(this)
            };
        }

        public override void OnEnter(Car car)
        {
        }

        protected override void OnExit()
        {
        }
    }
}