using System;
using System.Linq;
using Sources.Utilities.StateTrees.States;

namespace Sources.Utilities.StateTrees.Base
{
    public abstract class NodeStateBase : StateBase
    {
        protected StateBase[] _children;
        protected StateBase _current;

        protected NodeStateBase(NodeStateBase parent) : base(parent)
        {
        }

        public void Enter<TState>()
            where TState : StateBase, IState =>
            EnterInternal<TState>(state => state.Enter());

        public void Enter<TState, TPayload>(TPayload payload)
            where TState : StateBase, IState<TPayload> =>
            EnterInternal<TState>(state => state.Enter(payload));

        private void EnterInternal<TState>(Action<TState> enter)
            where TState : StateBase
        {
            TState state = GetState<TState>();
            _current?.Exit();
            enter(state);
            _current = state;
        }

        protected override void ExitInternal()
        {
            _current?.Exit();
            OnExit();
        }

        protected abstract void OnExit();

        private TState GetState<TState>() where TState : StateBase =>
            _children.First(state => state is TState) as TState;
    }
}