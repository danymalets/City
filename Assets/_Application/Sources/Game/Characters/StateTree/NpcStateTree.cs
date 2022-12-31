using Sources.Game.Characters.StateTree.InCar;
using Sources.Game.GameObjects.Cars;
using Sources.Utilities.StateTrees.Base;
using Sources.Utilities.StateTrees.States;

namespace Sources.Game.Characters.StateTree
{
    public class NpcStateTree : RootState, IState<Car>
    {
        public NpcStateTree()
        {
            _children = new StateBase[]
            {
                new InCarNodeState(this)
            };
        }

        public override void OnEnter() =>
            throw new System.NotImplementedException();

        public void OnEnter(Car car) =>
            Enter<InCarNodeState, Car>(car);

        protected override void OnExit()
        {
        }
    }
}