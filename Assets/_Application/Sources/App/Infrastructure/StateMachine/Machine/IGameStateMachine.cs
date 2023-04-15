using _Application.Sources.App.Infrastructure.StateMachine.StateBase;

namespace _Application.Sources.App.Infrastructure.StateMachine.Machine
{
    public interface IGameStateMachine
    {
        void Enter<TState>() where TState : GameState;
        void Enter<TState, TPayload>(TPayload payload) where TState : GameState<TPayload>;
    }
}