using System.Linq;
using Sources.Game.GameObjects.Cars;

namespace Sources.Game.Characters.NpcStateMachines
{
    public class NpcStateMachine
    {
        private readonly NpcState[] _states;

        private NpcState _currentState;

        public NpcStateMachine(Car car)
        {
            _states = new NpcState[] {
                new DriveByPathState(this, car)
            };
        }

        public void Enter<TState>() 
            where TState : CustomNpcState
        {
            CustomNpcState state = _states.First(state => state is TState) as CustomNpcState;
            _currentState?.Quit();
            state.Enter();
            _currentState = state;
        }
        
        public void Enter<TState, TPayload>(TPayload payload) 
            where TState : CustomNpcState<TPayload>
        {
            CustomNpcState<TPayload> state = _states.First(state => state is TState) as CustomNpcState<TPayload>;
            _currentState?.Quit();
            state.Enter(payload);
            _currentState = state;
        }
    }
}