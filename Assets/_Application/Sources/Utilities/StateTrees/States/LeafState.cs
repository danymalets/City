using Sources.Utilities.StateTrees.Base;

namespace Sources.Utilities.StateTrees.States
{
    public abstract class LeafState : LeafStateBase, IState
    {
        protected LeafState(NodeStateBase parent) : base(parent)
        {
        }

        public abstract void OnEnter();
    }
    
    public abstract class LeafState<TPayload> : LeafStateBase, IState<TPayload>
    {
        protected LeafState(NodeStateBase parent) : base(parent)
        {
        }

        public abstract void OnEnter(TPayload payload);
    }
}