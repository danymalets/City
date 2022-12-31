using Sources.Utilities.StateTrees.Base;

namespace Sources.Utilities.StateTrees.States
{
    public abstract class RootState : RootStateBase, IState
    {
        public abstract void OnEnter();
    }
    
    public abstract class RootState<TPayload> : RootStateBase, IState<TPayload>
    {
        public abstract void OnEnter(TPayload payload);
    }
}