using Sources.Infrastructure.StateMachine.StateBase;

namespace Sources.Infrastructure.StateMachine.Machine
{
    public interface IGameStateMachine
    {
        void Enter<TState>() where TState : GameState;
        void Enter<TState, TPayload>(TPayload payload) where TState : GameState<TPayload>;
    }
}