using Sources.Infrastructure.StateMachine.Machine;

namespace Sources.Infrastructure.StateMachine.StateBase
{
    public abstract class GameStateBase
    {
        protected readonly IGameStateMachine _stateMachine;

        protected GameStateBase(IGameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        protected virtual void OnExit()
        {
        }

        public void Exit()
        {
            OnExit();
        }
    }
}