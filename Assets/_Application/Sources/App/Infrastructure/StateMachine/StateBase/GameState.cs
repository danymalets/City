using Sources.App.Infrastructure.StateMachine.Machine;

namespace Sources.App.Infrastructure.StateMachine.StateBase
{
    public abstract class GameState : GameStateBase
    {
        protected GameState(IGameStateMachine stateMachine) : base(stateMachine)
        {
        }
        
        public void Enter()
        {
            OnEnter();
        }
        
        protected abstract void OnEnter();
    }
    
    public abstract class GameState<TPayload> : GameStateBase
    {
        protected GameState(IGameStateMachine stateMachine) : base(stateMachine)
        {
        }

        public void Enter(TPayload payload)
        {
            OnEnter(payload);
        }
        
        protected abstract void OnEnter(TPayload payload);
    }
    
    public abstract class GameState<TPayload1, TPayload2> : GameStateBase
    {
        protected GameState(IGameStateMachine stateMachine) : base(stateMachine)
        {
        }

        public void Enter(TPayload1 payload1, TPayload2 payload2)
        {
            OnEnter(payload1, payload2);
        }
        
        protected abstract void OnEnter(TPayload1 payload1, TPayload2 payload2);
    }
}