namespace Sources.Game.Characters.NpcStateMachines
{
    public abstract class NpcState
    {
        protected readonly NpcStateMachine _stateMachine;

        protected NpcState(NpcStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Quit() =>
            OnQuit();
        protected abstract void OnQuit();
    }
}