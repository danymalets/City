namespace Sources.Game.Characters.NpcStateMachines
{
    public abstract class CustomNpcState : NpcState
    {
        protected CustomNpcState(NpcStateMachine stateMachine) : base(stateMachine)
        {
        }

        public void Enter() =>
            OnEnter();

        protected abstract void OnEnter();
    }
    
    public abstract class CustomNpcState<TPayload> : NpcState
    {
        protected CustomNpcState(NpcStateMachine stateMachine) : base(stateMachine)
        {
        }

        public void Enter(TPayload payload) =>
            OnEnter(payload);

        protected abstract void OnEnter(TPayload payload);
    }
}