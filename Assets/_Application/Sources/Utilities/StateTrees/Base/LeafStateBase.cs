namespace Sources.Utilities.StateTrees.Base
{
    public abstract class LeafStateBase : StateBase
    {
        protected LeafStateBase(NodeStateBase parent) : base(parent)
        {
        }

        protected override void ExitInternal()
        {
            OnExit();
        }

        protected abstract void OnExit();
    }
}