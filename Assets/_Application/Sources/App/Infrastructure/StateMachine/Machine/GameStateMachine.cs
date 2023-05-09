using System;
using System.Collections.Generic;
using Sources.App.Infrastructure.StateMachine.StateBase;
using Sources.App.Infrastructure.StateMachine.States;

namespace Sources.App.Infrastructure.StateMachine.Machine
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, GameStateBase> _states;
        
        private GameStateBase _activeState;

        public GameStateMachine()
        {
            _states = new Dictionary<Type, GameStateBase>
            {
                [typeof(RegistrationState)] = new RegistrationState(this),
                [typeof(BootstrapState)] = new BootstrapState(this),
                [typeof(MainUiState)] = new MainUiState(this),
                [typeof(LoadLevelState)] = new LoadLevelState(this),
                [typeof(LevelState)] = new LevelState(this),
            };
        }
        
        public void Enter<TState>() where TState : GameState
        {
            TState state = ChangeState<TState>();
            state.Enter();
        }
        
        public void Enter<TState, TPayload>(TPayload payload) 
            where TState : GameState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }
        
        public void Enter<TState, TPayload1, TPayload2>(TPayload1 payload1, TPayload2 payload2) 
            where TState : GameState<TPayload1, TPayload2>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload1, payload2);
        }
        
        private TState ChangeState<TState>() where TState : StateBase.GameStateBase
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;
            
            return state;
        }
        
        private TState GetState<TState>() where TState : StateBase.GameStateBase => 
            (TState)_states[typeof(TState)];
    }
}