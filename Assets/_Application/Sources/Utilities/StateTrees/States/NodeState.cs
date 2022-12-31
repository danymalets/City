using Sources.Utilities.StateTrees.Base;

namespace Sources.Utilities.StateTrees.States
{
    public abstract class NodeState : NodeStateBase, IState
    {
        protected NodeState(NodeStateBase parent) : base(parent)
        {
        }

        public abstract void OnEnter();
    }
    
    public abstract class NodeState<TPayload> : NodeStateBase, IState<TPayload>
    {
        protected NodeState(NodeStateBase parent) : base(parent)
        {
        }

        public abstract void OnEnter(TPayload payload);
    }
}